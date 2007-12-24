using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client;
using System.Windows.Forms;
using MonoTorrent.GUI.View;
using MonoTorrent.GUI.Settings;
using System.IO;
using MonoTorrent.Common;
using System.Threading;
using MonoTorrent.GUI.View.Control;
using System.Drawing;
using System.Resources;
using System.Reflection;
using Utilities;

namespace MonoTorrent.GUI.Controller
{
    public class PeerIdEventArgs : EventArgs
    {
        private PeerId peerId;

        public PeerId PeerId
        {
            get { return peerId; }
        }

        public PeerIdEventArgs(PeerId id)
        {
            this.peerId = id;
        }
    }

    public class TorrentManagerEventArgs : EventArgs
    {
        private TorrentManager manager;

        public TorrentManager Manager
        {
            get { return manager; }
        }

        public TorrentManagerEventArgs(TorrentManager manager)
        {
            this.manager = manager;
        }
    }

    public class MainController : IDisposable
	{
        public event EventHandler<PeerIdEventArgs> PeerConnected;
        public event EventHandler UpdatePeers;
        public event EventHandler<PeerIdEventArgs> PeerDisconnected;
        public event EventHandler<TorrentManagerEventArgs> UpdateStats;
        public event EventHandler UpdateAllStats;

        public double TotalDownloadSpeed
        {
            get { return this.clientEngine.TotalDownloadSpeed; }
        }

        public double TotalUploadSpeed
        {
            get { return this.clientEngine.TotalUploadSpeed; }
        }

		#region Private field

		private ClientEngine clientEngine;
        private OptionWindow optionWindow;
        private AboutWindow aboutWindow;
        private MiniWindow miniWindow;
        private SettingsBase settingsBase;
		private ReaderWriterLock peerlocker;
        private Icon mono;
        private int maxDownload;

		#endregion

        public MiniWindow MiniWindow
        {
            get { return miniWindow; }
            set { miniWindow = value; }
        }

        public SettingsBase SettingsBase
        {
            get { return settingsBase; }
        }

        public ClientEngine Engine
        {
            get { return clientEngine; }
        }
        public int MaxDownload
        {
            get { return maxDownload; }
            set { maxDownload = value; }
        }

        public Icon Mono
        {
            get { return mono; }
        }

		#region Constructor and destructor

		public MainController()
        {
			peerlocker = new ReaderWriterLock();
			settingsBase = new SettingsBase();
            mono = ResourceHandler.GetIcon("mono", 16, 16);

            Init();
        }

		public void Init()
		{
			//get general settings in file
			GuiGeneralSettings genSettings = settingsBase.LoadSettings<GuiGeneralSettings>("General Settings");
			clientEngine = new ClientEngine(genSettings.GetEngineSettings());

			// Create Torrents path
			if (!Directory.Exists(genSettings.TorrentsPath))
				Directory.CreateDirectory(genSettings.TorrentsPath);

            // Add torrents from startup paramters to torrents folder
            foreach (string file in Global.TorrentFiles)
            {
                if (File.Exists(file) && file.EndsWith(".torrent"))
                {
					// FIXME: This isn't cross platform. Use the "Path" class to do this
                    string newFile = genSettings.TorrentsPath + file.Substring(file.LastIndexOf("\\"));
                    if (!File.Exists(newFile))
                        File.Copy(file, newFile);
                }
            }

			//load all torrents in torrents folder
			foreach (string file in Directory.GetFiles(genSettings.TorrentsPath, "*.torrent"))
			{
				GuiTorrentSettings torrentSettings = settingsBase.LoadSettings<GuiTorrentSettings>("Torrent Settings for " + file);
				Add(file, torrentSettings.GetTorrentSettings(),	
                    string.IsNullOrEmpty(torrentSettings.SavePath) ? clientEngine.Settings.SavePath : torrentSettings.SavePath);
			}

			//subscribe to event for update
			clientEngine.StatsUpdate += OnUpdateStats;

			clientEngine.ConnectionManager.PeerConnected += OnPeerConnected;
            clientEngine.ConnectionManager.PeerDisconnected += OnPeerDisconnected;
		}

		/// <summary>
		/// close all before exit
		/// </summary>
 		public void Dispose()
		{
            //timeout 10 sec
            // This throws error: WaitAll for multiple handles on a STA thread is not supported
            // Use WaitOne
            //WaitHandle.WaitAll(handles,10000,true);

            //WaitHandle[] handles = clientEngine.StopAll();
            //foreach (WaitHandle wh in handles)
            //    if (wh != null)
            //        wh.WaitOne(10000, false);

            //clientEngine.Dispose();
#warning FIX THIS BAD BOY
            //GuiTorrentSettings torrentSettings;
            //foreach (KeyValuePair<ListViewItem, TorrentManager> keypair in this.itemToTorrent)
            //{
            //    TorrentManager torrent = keypair.Value;
            //    torrent.PieceHashed -= OnTorrentChange;
            //    torrent.PeersFound -= OnTorrentChange;
            //    torrent.TorrentStateChanged -= OnTorrentStateChange;
            //    torrentSettings = new GuiTorrentSettings();
            //    torrentSettings.SetTorrentSettings(torrent.Settings);
            //    torrentSettings.SavePath = torrent.SavePath;
            //    settingsBase.SaveSettings<GuiTorrentSettings>("Torrent Settings for " + torrent.Torrent.TorrentPath, torrentSettings);
            //}

            //clientEngine.StatsUpdate -= OnUpdateStats;
		}

		#endregion

		#region Peer

        public void DeletePeerMethod(PeerId id)
		{
            EventHandler<PeerIdEventArgs> h = PeerDisconnected;
            if (h != null)
                h(null, new PeerIdEventArgs(id));

		}

        public delegate void PeerHandler(PeerId PeerId);


		#endregion

		#region Torrent

		

		#endregion



        #region Event methods
		
		public void OnPeerConnected(object sender, PeerConnectionEventArgs args)
		{
            EventHandler<PeerIdEventArgs> h = PeerConnected;
            if (h != null)
                h(this, new PeerIdEventArgs(args.PeerID));
		}

        public void OnPeerDisconnected(object sender, PeerConnectionEventArgs args)
        {
            EventHandler<PeerIdEventArgs> h = PeerDisconnected;
            if (h != null)
                h(null, new PeerIdEventArgs(args.PeerID));
        }

        /// <summary>
        /// event torrent change
        /// </summary>
        /// <param name="sender">TorrentManager</param>
        /// <param name="args">nothing</param>
        private void OnTorrentChange(object sender, EventArgs args)
        {
            //TorrentManager torrent = (TorrentManager)sender;
            //if (!mainForm.IsDisposing)
            //    mainForm.Invoke(new UpdateHandler(Update), torrent);
        }

        /// <summary>
        /// event torrent state change
        /// </summary>
        /// <param name="sender">TorrentManager</param>
        /// <param name="args"></param>
        private delegate void UpdateHandler(TorrentManager torrent);
        private void OnTorrentStateChange(object sender, EventArgs args)
        {
            EventHandler<TorrentManagerEventArgs> h = UpdateStats;
            if (h != null)
                h(null, new TorrentManagerEventArgs((TorrentManager)sender));
        }

		// FIXME: Is this the best way to do this?
		private int counter = 0;
		/// <summary>
		/// event update stats change
		/// </summary>
		/// <param name="sender">clientengine</param>
		/// <param name="args"></param>
        public delegate void UpdateStatsHandler();
        public delegate void UpdateStateHandler(TorrentManager manager);

		private void OnUpdateStats(object sender, EventArgs args)
		{
            EventHandler h = UpdateAllStats;
            if (h != null)
                h(null, EventArgs.Empty);
		}

        void torrent_PieceHashed(object sender, PieceHashedEventArgs e)
        {
            lock (currentRequests)
            {
                for (int i = 0; i < this.currentRequests.Count; i++)
                {
                    if (this.currentRequests[i].Piece.Index == e.PieceIndex)
                        continue;

                    this.currentRequests.RemoveAt(i);
                    break;
                }
            }
        }

        public List<BlockEventArgs> GetCurrentRequests()
        {
            lock (currentRequests)
            {
                currentRequests.RemoveAll(delegate(BlockEventArgs other) { return other.Piece.AllBlocksWritten; });
                return new List<BlockEventArgs>(currentRequests);
            }
        }

        List<BlockEventArgs> currentRequests = new List<BlockEventArgs>();
        void PieceManager_BlockRequested(object sender, BlockEventArgs e)
        {
            lock (currentRequests)
            {
                bool contains = currentRequests.FindIndex(delegate(BlockEventArgs other) { return other.Piece.Equals(e.Piece); }) != -1;

                if (!contains && !e.Piece.AllBlocksWritten)
                    currentRequests.Add(e);
            }
        }

        delegate void Handler();

        void PieceManager_BlockRequestCancelled(object sender, BlockEventArgs e)
        {
            // Do nothing  - currently everything handled on the GUI update
        }

        void PieceManager_BlockReceived(object sender, BlockEventArgs e)
        {
            // Do nothing - currently everything handled on the GUI update
        }

        void FileManager_BlockWritten(object sender, BlockEventArgs e)
        {
            // Do nothing - currently everything handled on the GUI update
        }

        #endregion

        #region Controller action

        /// <summary>
        /// Create a new torrent
        /// </summary>
        public void Create()
        {
            CreateWindow window = new CreateWindow(this);
            if (window.ShowDialog() == DialogResult.OK)
            {
                TorrentCreator creator = new TorrentCreator();
                creator.Comment = window.Comment;
                creator.CreatedBy = window.CreateBy;
                creator.Path = window.FromPath;
                if (!String.IsNullOrEmpty(window.TrackerURL))
                {
                    creator.Announces.Add(new MonoTorrentCollection<string>());
                    creator.Announces[0].Add(window.TrackerURL);
                }
                string newPath = Path.Combine(window.SaveTo, Path.GetFileName(window.FromPath));
                creator.Create(newPath);
            }
        }

        /// <summary>
        /// Select a torrent file to add
        /// </summary>
        /// <param name="asUrl">Add a torrent file from url</param>
        public TorrentManager Add(bool asUrl)
        {
            try
            {
                if (asUrl)
                {
                    // Show the url dialogue
                    TorrentUrl tu = new TorrentUrl();
                    if (tu.ShowDialog() == DialogResult.OK)
                    {
                        return Add(Global.TorrentPath);
                    }
                }
                else
                {
                    // Show OpenFileDialog for local torrent file
                    System.Windows.Forms.OpenFileDialog dialogue = new OpenFileDialog();
                    dialogue.Filter = "Torrent File (*.torrent)|*.torrent|All files (*.*)|*.*";
                    dialogue.Title = "Open";
                    dialogue.DefaultExt = ".torrent";
                    if (dialogue.ShowDialog() == DialogResult.OK)
                    {
                        return Add(dialogue.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Add :" + e.ToString());
            }

            return null;
        }

        /// <summary>
        /// Add torrent file
        /// </summary>
        /// <param name="fileName">Torrent file path</param>
        public TorrentManager Add(string fileName)
        {
            TorrentSettingWindow window = new TorrentSettingWindow(TorrentSettings.DefaultSettings(), clientEngine.Settings.SavePath);
            if (window.ShowDialog() == DialogResult.OK)
            {
                return Add(fileName, window.Settings, window.SavePath);
            }
            return null;
        }

        /// <summary>
        /// Add torrent file
        /// </summary>
        /// <param name="fileName">Torrent file path</param>
        /// <param name="settings">Torrent settings</param>
        /// <param name="savePath">Save path</param>
        public TorrentManager Add(string fileName, TorrentSettings settings, string savePath)
        {
            GuiGeneralSettings genSettings = settingsBase.LoadSettings<GuiGeneralSettings>("General Settings");
            string newPath = string.Empty;
            Torrent torrent = null;

            if (File.Exists(fileName))
            {
                newPath = Path.Combine(genSettings.TorrentsPath, Path.GetFileName(fileName));
                if (newPath != fileName)
                {
                    if (File.Exists(newPath))
                    {
                        if (MessageBox.Show("This torrent already exist in torrent folder. Load anyway?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            File.Delete(newPath);
                        else
                            return null;
                    }
                    File.Copy(fileName, newPath);
                }
                torrent = Torrent.Load(newPath);
            }
            else
            {
                // Try as url
                if (fileName.IndexOf("//") > 0)
                {
                    newPath = Path.Combine(genSettings.TorrentsPath, fileName.Substring(fileName.LastIndexOf("/") + 1));
                    if (File.Exists(newPath))
                    {
                        MessageBox.Show("This torrent already exist in torrent folder.");
                        return null;
                    }
                    torrent = Torrent.Load(new Uri(fileName), newPath);
                }
                else
                {
                    MessageBox.Show("This is not a valid torrent path or url.");
                    return null;
                }
            }
            
            // Add torrent to manager
            TorrentManager manager = new TorrentManager(torrent, savePath, settings);
            clientEngine.Register(manager);

            manager.PieceHashed += new EventHandler<PieceHashedEventArgs>(torrent_PieceHashed);
            manager.PeersFound += OnTorrentChange;
            manager.TorrentStateChanged += OnTorrentStateChange;
            manager.FileManager.BlockWritten += new EventHandler<BlockEventArgs>(FileManager_BlockWritten);
            manager.PieceManager.BlockReceived += new EventHandler<BlockEventArgs>(PieceManager_BlockReceived);
            manager.PieceManager.BlockRequestCancelled += new EventHandler<BlockEventArgs>(PieceManager_BlockRequestCancelled);
            manager.PieceManager.BlockRequested += new EventHandler<BlockEventArgs>(PieceManager_BlockRequested);
            manager.HashCheck(false);

            return manager;
        }

        public void Remove(TorrentManager torrent)
        {
            clientEngine.Unregister(torrent);
        }

        public void Start(IList<TorrentManager> managers)
        {
            foreach (TorrentManager manager in managers)
                Start(manager);
        }

        /// <summary>
        /// Start selected torrents
        /// If none are selected: start all
        /// </summary>
        public void Start(TorrentManager manager)
        {
            try
            {
                // 
                // Isn't there a better way?
                //while (torrent.State == TorrentState.Hashing)
                //    Thread.Sleep(1000);

                //if (torrent.State == TorrentState.Paused || torrent.State == TorrentState.Stopped)
                //    clientEngine.Start(torrent);
                if (manager.State == TorrentState.Paused || manager.State == TorrentState.Stopped)
                    manager.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Start :" + e.ToString(), "Exception Torrent Start");
            }
        }

        /// <summary>
        /// Stop selected torrents
        /// </summary>
        public void Stop(TorrentManager manager)
        {
            try
            {
                if (manager.State != TorrentState.Stopped)
                    manager.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

        public void Stop(IList<TorrentManager> managers)
        {
            foreach (TorrentManager manager in managers)
                Stop(manager);
        }

        /// <summary>
        /// Pause selected torrent
        /// </summary>
        public void Pause(TorrentManager manager)
        {
            try
            {
                if (manager.State != TorrentState.Paused && manager.State != TorrentState.Stopped)
                    manager.Pause();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

        public void Pause(IList<TorrentManager> managers)
        {
            foreach (TorrentManager manager in managers)
                Pause(manager);
        }

        /// <summary>
        /// Show options window
        /// </summary>
        public void Option(MainWindow window)
        {
            if (optionWindow == null || optionWindow.IsDisposed)
            {
                optionWindow = new OptionWindow(window, this, settingsBase);
            }
            optionWindow.BringToFront();
            optionWindow.ShowDialog();

        }

        public void Up()
        {
            //TODO move up in prior
            MessageBox.Show("Not Implemented!");
        }

        public void Down()
        {
            //TODO move down in prior
            MessageBox.Show("Not Implemented!");
        }

        public void Rss()
        {
            //TODO Create rss downloader
            MessageBox.Show("Not Implemented!");
        }

        /// <summary>
        /// Show about window
        /// </summary>
        public void About()
        {
            if (aboutWindow == null || aboutWindow.IsDisposed)
            {
                aboutWindow = new AboutWindow();
            }
            aboutWindow.ShowDialog();
            aboutWindow.BringToFront();
        }

        #endregion

		




    }
}
