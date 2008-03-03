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
    public class MainController : IDisposable
	{
		#region Private field

		private ClientEngine clientEngine;
        private OptionWindow optionWindow;
        private AboutWindow aboutWindow;
		private MainWindow mainForm;
        private MiniWindow miniWindow;
        private IDictionary<ListViewItem, TorrentManager> itemToTorrent;
        private SettingsBase settingsBase;
        private IDictionary<ListViewItem, PeerId> itemToPeers;
		private ReaderWriterLock peerlocker;
        private Icon mono;
        private int maxDownload;

		#endregion

		#region Constructor and destructor

		public MainController(MainWindow mainForm)
        {
			this.mainForm = mainForm;
			itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();
			itemToPeers = new Dictionary<ListViewItem, PeerId>();
			peerlocker = new ReaderWriterLock();
			settingsBase = new SettingsBase();
            mono = ResourceHandler.GetIcon("mono", 16, 16);

            this.miniWindow = new MiniWindow(this);

			LoadViewSettings();
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

            WaitHandle[] handles = clientEngine.StopAll();
            foreach (WaitHandle wh in handles)
                if (wh != null)
                    wh.WaitOne();

            clientEngine.Dispose();
               
			GuiTorrentSettings torrentSettings;
            foreach (KeyValuePair<ListViewItem, TorrentManager> keypair in this.itemToTorrent)
            {
                TorrentManager torrent = keypair.Value;
                torrent.PieceHashed -= OnTorrentChange;
                torrent.PeersFound -= OnTorrentChange;
                torrent.TorrentStateChanged -= OnTorrentStateChange;
                torrentSettings = new GuiTorrentSettings(torrent.Settings);
                torrentSettings.SavePath = torrent.SavePath;
                settingsBase.SaveSettings<GuiTorrentSettings>("Torrent Settings for " + torrent.Torrent.TorrentPath, torrentSettings);
                torrent.PeerConnected += OnPeerConnected;
                torrent.PeerDisconnected += OnPeerDisconnected;
            }

			clientEngine.StatsUpdate -= OnUpdateStats;
			UpdateViewSettings();
		}

		#endregion

		#region Peer

        public void CreatePeer(PeerId id)
        {
            if (!id.IsValid)
                return;

            ListViewItem item = new ListViewItem(id.Name);
            ListViewItem.ListViewSubItem subitem = item.SubItems[0];
            subitem.Name = "PeerId";
            subitem.Text = id.Name;

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "ClientApp";
            item.SubItems.Add(subitem);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "LocationPeer";
            item.SubItems.Add(subitem);
            subitem.Text = id.Location.ToString();


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "Download";
            item.SubItems.Add(subitem);
            subitem.Text = FormatSizeValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "Upload";
            item.SubItems.Add(subitem);
            subitem.Text = FormatSizeValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "DownloadSpeed";
            item.SubItems.Add(subitem);
            subitem.Text = FormatSpeedValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "UploadSpeed";
            item.SubItems.Add(subitem);
            subitem.Text = FormatSpeedValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "IsSeeder";
            item.SubItems.Add(subitem);
            subitem.Text = id.IsSeeder ? "Yes" : "No";

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "Encryption";
            item.SubItems.Add(subitem);
            //subitem.Text = FormatBool(id.Peer.EncryptionSupported == EncryptionMethods.RC4Encryption);
            //FIXME: This isn't right!

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "IsChoking";
            item.SubItems.Add(subitem);
            subitem.Text = FormatBool(id.IsChoking);

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "IsInterested";
            item.SubItems.Add(subitem);
            subitem.Text = FormatBool(id.IsInterested);

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "IsRequestingPiecesCount";
            item.SubItems.Add(subitem);
            subitem.Text = id.IsRequestingPiecesCount.ToString();

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "PiecesSent";
            item.SubItems.Add(subitem);
            subitem.Text = id.PiecesSent.ToString();

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "SupportsFastPeer";
            item.SubItems.Add(subitem);
            subitem.Text = FormatBool(id.SupportsFastPeer);

            mainForm.PeersView.Items.Add(item);
            lock (itemToPeers)
                itemToPeers.Add(item, id);
        }

        public void DeletePeer(PeerId id)
		{
			lock (itemToPeers)
                foreach (KeyValuePair<ListViewItem, PeerId> entry in itemToPeers)
				{
					if (entry.Value != id)
						continue;

					itemToPeers.Remove(entry.Key);
					mainForm.PeersView.Items.Remove(entry.Key);
					return;
				}
		}

        private delegate void PeerHandler(PeerId PeerId);

		public void UpdatePeers()
		{
            try
            {
                this.mainForm.PeersView.BeginUpdate();
                lock (itemToPeers)
                    foreach (KeyValuePair<ListViewItem, PeerId> entry in itemToPeers)
                    {
                        if (!entry.Value.IsValid)
                        {
                            entry.Key.SubItems[1].Text = "PEER DISPOSED";
                            for (int i = 1; i < entry.Key.SubItems.Count; i++)
                                entry.Key.SubItems[i].Text = string.Empty;
                        }

                        else
                        {
                            entry.Key.SubItems["PeerId"].Text = entry.Value.Name;
                            entry.Key.SubItems["IsSeeder"].Text = FormatBool(entry.Value.IsSeeder);
                            entry.Key.SubItems["IsChoking"].Text = FormatBool(entry.Value.IsChoking);
                            entry.Key.SubItems["IsInterested"].Text = FormatBool(entry.Value.IsInterested);
                            entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.IsRequestingPiecesCount.ToString();
                            entry.Key.SubItems["PiecesSent"].Text = entry.Value.PiecesSent.ToString();
                            entry.Key.SubItems["ClientApp"].Text = entry.Value.ClientSoftware.Client.ToString();
                            entry.Key.SubItems["Download"].Text = FormatSizeValue(entry.Value.Monitor.DataBytesDownloaded);
                            entry.Key.SubItems["Upload"].Text = FormatSizeValue(entry.Value.Monitor.DataBytesUploaded);
                            entry.Key.SubItems["DownloadSpeed"].Text = FormatSpeedValue(entry.Value.Monitor.DownloadSpeed);
                            entry.Key.SubItems["UploadSpeed"].Text = FormatSpeedValue(entry.Value.Monitor.UploadSpeed);
                            entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.AmRequestingPiecesCount.ToString();
                            entry.Key.SubItems["PiecesSent"].Text = entry.Value.PiecesSent.ToString();
                        }
                }
            }
            finally
            {
                this.mainForm.PeersView.EndUpdate();
            }
		}

		#endregion

		#region Torrent

		public void UpdateAllStats()
		{
            try
            {
                UpdateTorrentsView();
                UpdatePiecesTab();
                UpdatePeers();

                IList<TorrentManager> torrents = GetSelectedTorrents();
                if (torrents.Count == 0)
                {
                    ClearDetailTab();
                    ClearGeneralTab();
                    return;
                }
                TorrentManager torrent = torrents[0];

                SmallUpdateGeneralTab(torrent);
                SmallUpdateDetailTab(torrent);
                if (miniWindow.Visible)
                    UpdateMiniWindow();

                UpdateStatsGraph();
                UpdateNotifyIcon();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Bloody hell! It crashed:");
            }
		}

        /// <summary>
        /// NEW:
        /// Update the notify icon:
        ///     Icon with progress indicator
        ///     and information text
        /// </summary>
        public void UpdateNotifyIcon()
        {
            if (this.mainForm.WindowState == FormWindowState.Minimized)
            {
                int iconInt = 16;
                double dl = clientEngine.TotalDownloadSpeed;
                double ul = clientEngine.TotalUploadSpeed;
                if (dl == 0 && ul == 0)
                {
                    // No acivity: show grey mono icon
                    this.mainForm.NotifyIconSystray.Icon = ResourceHandler.GetIcon("mono_grey", iconInt, iconInt);
                }
                else
                {
                    // Build a system tray icon with downloadspeed indication
                    if (maxDownload == 0)
                    {
                        maxDownload = clientEngine.Settings.GlobalMaxDownloadSpeed;
                        // With a minimimum of 16 Kb (1 Kb per pixel)
                        maxDownload = 1024 * 16;
                    }
                    if (maxDownload < dl)
                        // If no MaxDownloadSpeed is given, create your own temporarily
                        maxDownload = (int)(dl * 1.25);

                    // Calculate the dimensions and position of the progress indicator
                    int h = (int)(dl / (maxDownload / iconInt));
                    int w = 3;
                    int x = iconInt - w;
                    int y = iconInt - h;

                    // Create a new icon from the mono icon and the progress indicator
                    Bitmap bmp = new Bitmap(iconInt, iconInt);
                    Graphics grs = Graphics.FromImage(bmp);
                    grs.DrawIcon(mono, 0, 0);
                    grs.FillRectangle(Brushes.Green, x, y, w, h);
                    Icon sysIcon = Icon.FromHandle(bmp.GetHicon());

                    // Show the new icon in the system tray
                    this.mainForm.NotifyIconSystray.Icon = sysIcon;
                }

                // Show info text when hovering over system tray icon
                string niTxt = Application.ProductName + " " + Application.ProductVersion
                               + "\nDown: " + FormatSpeedValue(dl).ToString() 
                             + " | Up: " + FormatSpeedValue(ul).ToString();

                this.mainForm.NotifyIconSystray.Text = niTxt; 
            }
        }
        
        /// <summary>
        /// Update the TorrentsView grid
        /// </summary>
        private void UpdateTorrentsView()
		{
			try
			{
				this.mainForm.TorrentsView.BeginUpdate();
				foreach (KeyValuePair<ListViewItem, TorrentManager> keypair in this.itemToTorrent)
					UpdateState(keypair.Value);
			}
			finally
			{
				this.mainForm.TorrentsView.EndUpdate();
			}
		}

        /// <summary>
        /// Update torrent state in view
        /// </summary>
        /// <param name="torrent">Torrent</param>
        public void UpdateState(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
			item.SubItems["colStatus"].Text = torrent.State.ToString();
            
            item.SubItems["colSeeds"].Text = torrent.Peers.Seeds.ToString();
			item.SubItems["colLeeches"].Text = torrent.Peers.Leechs.ToString() + " (" + torrent.Peers.Available.ToString() + ")";
			item.SubItems["colDownSpeed"].Text = FormatSpeedValue(torrent.Monitor.DownloadSpeed);
			item.SubItems["colUpSpeed"].Text = FormatSpeedValue(torrent.Monitor.UploadSpeed);
			//I put only download of file and not the download of protocole
			item.SubItems["colDownloaded"].Text = FormatSizeValue(torrent.Monitor.DataBytesDownloaded);
			// here i put all upload because we want to know whais bandwidth
			item.SubItems["colUploaded"].Text = FormatSizeValue(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded);
			//ratio is for all upload vs all download
			if (torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded != 0)
				item.SubItems["colRatio"].Text = string.Format("{0:0.00}", (float)(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded) / (torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded));

            if (torrent.Monitor.DownloadSpeed > 0)
            {
                double secs = (torrent.Torrent.Size - (torrent.Torrent.Size * (torrent.Progress / 100))) / torrent.Monitor.DownloadSpeed;
                TimeSpan s = TimeSpan.FromSeconds(secs);
                item.SubItems["colRemaining"].Text = string.Format("{0:00}:{1:00}:{2:00}", s.Days * 24 + s.Hours, s.Minutes, s.Seconds);
            }
            else
                item.SubItems["colRemaining"].Text = string.Empty;
        }

		#endregion

		#region Helper

		public string FormatBool(bool flag)
		{
			return flag ? "Yes" : "No";
		}

		public string FormatSpeedValue(double value)
		{
			return FormatSizeValue(value) + "/s";
		}

		public string FormatSizeValue(long value)
		{
            return FormatSizeValue((double)value);
		}

        /// <summary>
        /// Creates a readable string for passed bytes
        /// </summary>
        /// <param name="value">Bytes</param>
        /// <returns>String</returns>
        public string FormatSizeValue(double value)
        {
            if (value < 1024)
                return String.Format("{0:0.00} B", value);
            if (value < 1024 * 1024)
                return String.Format("{0:0.00} kB", value / (1024));
            if (value < 1024 * 1024 * 1024)
                return String.Format("{0:0.00} MB", value / (1024 * 1024));

            return String.Format("{0:0.00} GB", value / (1024 * 1024 * 1024));
        }

        /// <summary>
        /// Get all row selected in list view
        /// </summary>
        /// <returns>TorrentManager IList</returns>
        public IList<TorrentManager> GetSelectedTorrents()
        {
            IList<TorrentManager> result = new List<TorrentManager>();
			foreach (ListViewItem item in mainForm.TorrentsView.SelectedItems)
                result.Add(itemToTorrent[item]);
            return result;
        }

        /// <summary>
        /// Gets the selected torrent in grid
        /// If more than 1: return first
        /// </summary>
        /// <returns>TorrentManager</returns>
        public TorrentManager GetSelectedTorrent()
        {
            IList<TorrentManager> result = GetSelectedTorrents();
            if (result.Count > 0)
                return result[0];
            return null;
        }
        
        /// <summary>
        /// get row in listview from torrent
        /// </summary>
        /// <param name="torrent"></param>
        /// <returns></returns>
        private ListViewItem GetItemFromTorrent(TorrentManager torrent)
        {
            foreach (ListViewItem item in itemToTorrent.Keys)
            {
                if (itemToTorrent[item] == torrent)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion

        #region Event methods
		
		public void OnPeerConnected(object sender, PeerConnectionEventArgs args)
		{
			if (!mainForm.IsDisposing)
				mainForm.Invoke(new PeerHandler(CreatePeer), args.PeerID);
		}

		public void OnPeerDisconnected(object sender, PeerConnectionEventArgs args)
		{
            if (!mainForm.IsDisposing)
				mainForm.Invoke(new PeerHandler(DeletePeer), args.PeerID);
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
            TorrentManager torrent = (TorrentManager)sender;
            if (!mainForm.IsDisposing)
                mainForm.Invoke(new UpdateHandler(UpdateState), torrent);
        }

		// FIXME: Is this the best way to do this?
		private int counter = 0;
		/// <summary>
		/// event update stats change
		/// </summary>
		/// <param name="sender">clientengine</param>
		/// <param name="args"></param>
        private delegate void UpdateStatsHandler();
		private void OnUpdateStats(object sender, EventArgs args)
		{
			// Only update the screen every 8 ticks
            if (!mainForm.IsDisposing && ((counter++ % 8) == 0))
				mainForm.Invoke(new UpdateStatsHandler(UpdateAllStats));

            if (counter % 80 == 0)
                MonoTorrent.GUI.Helper.MemoryUtility.OptimizeMemoryUsage();
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

        List<BlockEventArgs> currentRequests = new List<BlockEventArgs>();
        void PieceManager_BlockRequested(object sender, BlockEventArgs e)
        {
            lock (currentRequests)
            {
                bool contains = false;
                for (int i = 0; i < currentRequests.Count; i++)
                    if (currentRequests[i].Piece.Equals(e.Piece))
                    {
                        contains = true;
                        break;
                    }

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
                    creator.Announces.Add(new List<string>());
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
        public void Add(bool asUrl)
        {
            try
            {
                if (asUrl)
                {
                    // Show the url dialogue
                    TorrentUrl tu = new TorrentUrl();
                    if (tu.ShowDialog() == DialogResult.OK)
                    {
                        Add(Utilities.Global.TorrentPath);
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
                        Add(dialogue.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Add :" + e.ToString());
            }
        }

        /// <summary>
        /// Add torrent file
        /// </summary>
        /// <param name="fileName">Torrent file path</param>
        public void Add(string fileName)
        {
            TorrentSettingWindow window = new TorrentSettingWindow(new TorrentSettings(), clientEngine.Settings.SavePath);
            if (window.ShowDialog() == DialogResult.OK)
            {
                Add(fileName, window.Settings, window.SavePath);
            }

        }

        /// <summary>
        /// Add torrent file
        /// </summary>
        /// <param name="fileName">Torrent file path</param>
        /// <param name="settings">Torrent settings</param>
        /// <param name="savePath">Save path</param>
        public void Add(string fileName, TorrentSettings settings, string savePath)
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
                        MessageBox.Show("This torrent already exist in torrent folder.");
                        return;
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
                        return;
                    }
                    torrent = Torrent.Load(new Uri(fileName), newPath);
                }
                else
                {
                    MessageBox.Show("This is not a valid torrent path or url.");
                    return;
                }
            }

            ListViewItem item = new ListViewItem(Path.GetFileName(newPath));

			ListViewItem.ListViewSubItem subitem = item.SubItems[0];
			subitem.Name = "colName";

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colSize";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colStatus";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colSeeds";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colLeeches";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colDownSpeed";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colUpSpeed";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colDownloaded";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colUploaded";
			item.SubItems.Add(subitem);

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "colRatio";
            item.SubItems.Add(subitem);

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "colRemaining";
            item.SubItems.Add(subitem);

			mainForm.TorrentsView.Items.Add(item);
            
            // Add torrent to manager
            TorrentManager manager = new TorrentManager(torrent, savePath, settings);
            clientEngine.Register(manager);
            ImageListView.ImageListViewSubItem sitem = new ImageListView.ImageListViewSubItem(new TorrentProgressBar(manager));
            sitem.Name = "colProgress";
            item.SubItems.Insert(2,sitem);
            itemToTorrent.Add(item, manager);
            manager.PieceHashed += new EventHandler<PieceHashedEventArgs>(torrent_PieceHashed);
            manager.PeersFound += OnTorrentChange;
            manager.TorrentStateChanged += OnTorrentStateChange;
            manager.FileManager.BlockWritten += new EventHandler<BlockEventArgs>(FileManager_BlockWritten);
            manager.PieceManager.BlockReceived += new EventHandler<BlockEventArgs>(PieceManager_BlockReceived);
            manager.PieceManager.BlockRequestCancelled += new EventHandler<BlockEventArgs>(PieceManager_BlockRequestCancelled);
            manager.PieceManager.BlockRequested += new EventHandler<BlockEventArgs>(PieceManager_BlockRequested);
            manager.PeerConnected += OnPeerConnected;
            manager.PeerDisconnected += OnPeerDisconnected;
            item.SubItems["colSize"].Text = FormatSizeValue(manager.Torrent.Size);
            item.SubItems["colName"].Text = manager.Torrent.Name;
            manager.HashCheck(false);
        }

        /// <summary>
        /// Remove torrent
        /// </summary>
        public void Del()
        {
            try
            {
                if (MessageBox.Show("Are you sure ?", "Delete Torrent", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (TorrentManager torrent in GetSelectedTorrents())
                    {
                        GetItemFromTorrent(torrent).Remove();
                        clientEngine.Unregister(torrent);
                        
                        File.Delete(torrent.Torrent.TorrentPath);
                        foreach (TorrentFile file in torrent.Torrent.Files)
                        {
                            File.Delete(Path.Combine(torrent.SavePath, file.Path));
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Del :" + e.ToString());
            }
        }

        /// <summary>
        /// Start selected torrents
        /// If none are selected: start all
        /// </summary>
        public void Start()
        {
            try
            {
                // NEW: add all torrents when none are selected
                IList<TorrentManager> tmList = GetSelectedTorrents();
                if (tmList.Count == 0)
                {
                    foreach (TorrentManager tm in itemToTorrent.Values)
                        tmList.Add(tm);
                    if (tmList.Count > 0)
                        mainForm.TorrentsView.Items[0].Selected = true;
                }

                foreach (TorrentManager torrent in tmList)
                {
                    // 
                    // Isn't there a better way?
                    //while (torrent.State == TorrentState.Hashing)
                    //    Thread.Sleep(1000);

                    //if (torrent.State == TorrentState.Paused || torrent.State == TorrentState.Stopped)
                    //    clientEngine.Start(torrent);
                    if ( torrent.State == TorrentState.Paused
                         || torrent.State == TorrentState.Stopped)
                        torrent.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Start :"+ e.ToString(), "Exception Torrent Start");
            }
        }

        /// <summary>
        /// Stop selected torrents
        /// </summary>
        public void Stop()
        {
            try
            {
                foreach (TorrentManager torrent in GetSelectedTorrents())
                {
                    if (torrent.State != TorrentState.Stopped)
                        torrent.Stop();
                }
                this.mainForm.PiecesListView.Items.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

        /// <summary>
        /// Pause selected torrent
        /// </summary>
        public void Pause()
        {
            try
            {
                foreach (TorrentManager torrent in GetSelectedTorrents())
                {
                    if (torrent.State != TorrentState.Paused
                        && torrent.State != TorrentState.Stopped)
                        torrent.Pause();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

        /// <summary>
        /// Show options window
        /// </summary>
        public void Option()
        {
            if (optionWindow == null || optionWindow.IsDisposed)
            {
                optionWindow = new OptionWindow(this, settingsBase);
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

		#region Settings

		/// <summary>
        /// update general settings
        /// </summary>
        /// <param name="settings"></param>
		public void UpdateGeneralSettings(GuiGeneralSettings settings)
        {
            settingsBase.SaveSettings<GuiGeneralSettings>("General Settings", settings);
            EngineSettings savedSettings = settings.GetEngineSettings();
            EngineSettings engine = clientEngine.Settings;
            engine.AllowLegacyConnections = savedSettings.AllowLegacyConnections;
            engine.GlobalMaxConnections = savedSettings.GlobalMaxDownloadSpeed;
            engine.GlobalMaxUploadSpeed = savedSettings.GlobalMaxUploadSpeed;
            engine.HaveSupressionEnabled = savedSettings.HaveSupressionEnabled;
            engine.ListenPort = savedSettings.ListenPort;
            engine.MaxOpenFiles = savedSettings.MaxOpenFiles;
            engine.MaxReadRate = savedSettings.MaxReadRate;
            engine.MaxWriteRate = savedSettings.MaxWriteRate;
            engine.MinEncryptionLevel = savedSettings.MinEncryptionLevel;
            engine.SavePath = savedSettings.SavePath;
		}

        /// <summary>
        /// Load saved view settings
        /// </summary>
		public void LoadViewSettings()
		{
			GuiViewSettings guisettings = settingsBase.LoadSettings<GuiViewSettings>("Graphical Settings");
			mainForm.Width = guisettings.FormWidth;
			mainForm.Height = guisettings.FormHeight;
			mainForm.Splitter.SplitterDistance = guisettings.SplitterDistance;
			mainForm.TabGeneral.VerticalScroll.Value = guisettings.VScrollValue;
			mainForm.TabGeneral.HorizontalScroll.Value = guisettings.HScrollValue;
			// show/Hide component of GUI
			mainForm.ShowStatusBar(guisettings.ShowStatusbar);
			mainForm.ShowToolBar(guisettings.ShowToolbar);
			mainForm.ShowDetail(guisettings.ShowDetail);

			for (int i = 0; i < guisettings.TorrentViewColumnWidth.Count; i++)
			{
				mainForm.TorrentsView.Columns[i].Width = guisettings.TorrentViewColumnWidth[i];
			}

			for (int i = 0; i < guisettings.PeerViewColumnWidth.Count; i++)
			{
				mainForm.PeersView.Columns[i].Width = guisettings.PeerViewColumnWidth[i];
			}

			for (int i = 0; i < guisettings.PieceViewColumnWidth.Count; i++)
			{
				mainForm.PiecesListView.Columns[i].Width = guisettings.PieceViewColumnWidth[i];
			}

            // Load the selected buttons
            LoadButtons();
		}

        /// <summary>
        /// NEW: Loads the images for the buttons in the menu bar
        /// If no path to a button strip image is provided,
        /// the default images from the resource file are used
        /// </summary>
        public void LoadButtons()
        {
            string imgPath = GuiViewSettings.CustomButtonPath;
            Image AddTorrent;
            Image AddTorrentFromUrl;
            Image CreateTorrent;
            Image DeleteTorrent;
            Image StartTorrent;
            Image PauseTorrent;
            Image StopTorrent;
            Image Up;
            Image Down;
            Image Rss;
            Image Options;
            
            // Get the images
            if (File.Exists(imgPath))
            {
                ButtonHandler bh = new ButtonHandler(imgPath);
                AddTorrent = bh.AddTorrent;
                AddTorrentFromUrl = bh.AddTorrentFromUrl;
                CreateTorrent = bh.CreateTorrent;
                DeleteTorrent = bh.DeleteTorrent;
                StartTorrent = bh.StartTorrent;
                PauseTorrent = bh.PauseTorrent;
                StopTorrent = bh.StopTorrent;
                Up = bh.Up;
                Down = bh.Down;
                Rss = bh.Rss;
                Options = bh.Options;
            }
            else
            {
                AddTorrent = ResourceHandler.GetImage("list_add");
                AddTorrentFromUrl = ResourceHandler.GetImage("list_add_url");
                CreateTorrent = ResourceHandler.GetImage("document_new");
                DeleteTorrent = ResourceHandler.GetImage("list_remove");
                StartTorrent = ResourceHandler.GetImage("media_playback_start");
                PauseTorrent = ResourceHandler.GetImage("media_playback_pause");
                StopTorrent = ResourceHandler.GetImage("media_playback_stop");
                Up = ResourceHandler.GetImage("go_up");
                Down = ResourceHandler.GetImage("go_down");
                Rss = ResourceHandler.GetImage("rss");
                Options = ResourceHandler.GetImage("preferences_system");
            }

            // Load the images in the toolstrip
            mainForm.MainToolStrip.Items["AddToolStripButton"].Image = AddTorrent;
            mainForm.MainToolStrip.Items["AddUrlToolStripButton"].Image = AddTorrentFromUrl;
            mainForm.MainToolStrip.Items["CreateToolStripButton"].Image = CreateTorrent;
            mainForm.MainToolStrip.Items["DelToolStripButton"].Image = DeleteTorrent;
            mainForm.MainToolStrip.Items["StartToolStripButton"].Image = StartTorrent;
            mainForm.MainToolStrip.Items["PauseToolStripButton"].Image = PauseTorrent;
            mainForm.MainToolStrip.Items["StopToolStripButton"].Image = StopTorrent;
            mainForm.MainToolStrip.Items["UpStripButton"].Image = Up;
            mainForm.MainToolStrip.Items["DownStripButton"].Image = Down;
            mainForm.MainToolStrip.Items["RssStripButton"].Image = Rss;
            mainForm.MainToolStrip.Items["OptionToolStripButton"].Image = Options;

            // End the menustrip
            ToolStripMenuItem tsmi = mainForm.MainMenuStrip.Items["menuFile"] as ToolStripMenuItem;
            tsmi.DropDownItems["addATorrentToolStripMenuItem"].Image = AddTorrent;
            tsmi.DropDownItems["deleteATorrentToolStripMenuItem"].Image = DeleteTorrent;
            tsmi.DropDownItems["createATorrentToolStripMenuItem"].Image = CreateTorrent;

            tsmi = mainForm.MainMenuStrip.Items["menuTorrent"] as ToolStripMenuItem;
            tsmi.DropDownItems["startTorrentToolStripMenuItem"].Image = StartTorrent;
            tsmi.DropDownItems["pauseTorrentToolStripMenuItem"].Image = PauseTorrent;
            tsmi.DropDownItems["stopTorrentToolStripMenuItem"].Image = StopTorrent;
            tsmi.DropDownItems["upTorrentToolStripMenuItem"].Image = Up;
            tsmi.DropDownItems["downTorrentToolStripMenuItem"].Image = Down;

            tsmi = mainForm.MainMenuStrip.Items["menuView"] as ToolStripMenuItem;
            tsmi.DropDownItems["optionToolStripMenuItem"].Image = Options;
        }

        /// <summary>
        /// Save view settings
        /// </summary>
		public void UpdateViewSettings()
		{
			GuiViewSettings guisettings = new GuiViewSettings();

            // NEW: when closing from system tray you don't want to save this
            if (this.mainForm.WindowState != FormWindowState.Minimized)
            {
                guisettings.FormWidth = mainForm.Width;
                guisettings.FormHeight = mainForm.Height;
                guisettings.SplitterDistance = mainForm.Splitter.SplitterDistance;
            }

			guisettings.VScrollValue = mainForm.TabGeneral.VerticalScroll.Value;
			guisettings.HScrollValue = mainForm.TabGeneral.HorizontalScroll.Value;
			guisettings.ShowDetail = mainForm.ShowDetailMenuItem.Checked;
			guisettings.ShowStatusbar = mainForm.ShowStatusbarMenuItem.Checked;
			guisettings.ShowToolbar = mainForm.ShowToolbarMenuItem.Checked;
			foreach (ColumnHeader col in mainForm.TorrentsView.Columns)
			{
				guisettings.TorrentViewColumnWidth.Add(col.Width);
			}
			foreach (ColumnHeader col in mainForm.PeersView.Columns)
			{
				guisettings.PeerViewColumnWidth.Add(col.Width);
			}
			foreach (ColumnHeader col in mainForm.PiecesListView.Columns)
			{
				guisettings.PieceViewColumnWidth.Add(col.Width);
			}
			settingsBase.SaveSettings<GuiViewSettings>("Graphical Settings", guisettings);		
		}

		#endregion

		#region General tab

		public void UpdateGeneralTab()
		{
			IList<TorrentManager> torrents =  GetSelectedTorrents();
			if (torrents.Count == 0)
				return;
			TorrentManager torrent = torrents[0];
			
			mainForm.GenTabDateLabel.Text = torrent.Torrent.CreationDate.ToShortDateString();
			mainForm.GenTabFolderLabel.Text = Path.Combine(torrent.SavePath, torrent.Torrent.Name);
			string hash = string.Empty;
			for (int i = 0; i < torrent.Torrent.InfoHash.Length; i++)
				hash += torrent.Torrent.InfoHash[i].ToString("X");

			mainForm.GenTabHashLabel.Text = hash;
			mainForm.GenTabInfosLabel.Text = torrent.Torrent.Comment;
			mainForm.GenTabPiecesxSizeLabel.Text = torrent.Torrent.Pieces.Count.ToString() + " X " + FormatSizeValue(torrent.Torrent.PieceLength);
			mainForm.GenTabSizeLabel.Text = FormatSizeValue(torrent.Torrent.Size);
            //mainForm.GenTabURLLabel.Text = torrent.Torrent.Source;
            mainForm.GenTabURLLabel.Text = torrent.TrackerManager.CurrentTracker.ToString();
            SmallUpdateGeneralTab(torrent);
		}

        public void SmallUpdateGeneralTab(TorrentManager torrent)
        {
            mainForm.GenTabStatusLabel.Text = torrent.TrackerManager.CurrentTracker.State.ToString();
            mainForm.GenTabUpdateLabel.Text = torrent.TrackerManager.LastUpdated.ToShortTimeString();
            mainForm.TrackerMessage.Text = string.Empty;
            mainForm.TrackerMessage.Text = torrent.TrackerManager.CurrentTracker.FailureMessage;
            mainForm.TrackerMessage.AppendText(Environment.NewLine);
            mainForm.TrackerMessage.AppendText(torrent.TrackerManager.CurrentTracker.WarningMessage);
        }

        private void ClearGeneralTab()
        {
            mainForm.GenTabDateLabel.Text = "...";
            mainForm.GenTabFolderLabel.Text = "...";
            mainForm.GenTabHashLabel.Text = "...";
            mainForm.GenTabInfosLabel.Text = "...";
            mainForm.GenTabPiecesxSizeLabel.Text = "...";
            mainForm.GenTabSizeLabel.Text = "...";
            mainForm.GenTabURLLabel.Text = "...";
            mainForm.GenTabStatusLabel.Text = "...";
            mainForm.GenTabUpdateLabel.Text = "...";
            mainForm.TrackerMessage.Text = "...";
        }

        #endregion

        #region Detail tab
        
        public void UpdateDetailTab()
        {
            IList<TorrentManager> torrents = GetSelectedTorrents();
            if (torrents.Count == 0)
                return;
            TorrentManager torrent = torrents[0];

            SmallUpdateDetailTab(torrent);
        }

        public void SmallUpdateDetailTab(TorrentManager torrent)
        {
            mainForm.DetailTabClients.Text = string.Empty;
            mainForm.DetailTabDownload.Text = FormatSizeValue(torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded);
            mainForm.DetailTabDownloadSpeed.Text = FormatSpeedValue(torrent.Monitor.DownloadSpeed);

            DateTime elapsedTime;
            if (torrent.State == TorrentState.Stopped || torrent.State == TorrentState.Paused)
                elapsedTime = new DateTime(0);
            else
                elapsedTime = DateTime.Now.AddTicks(-torrent.StartTime.Ticks);
            mainForm.DetailTabElapsedTime.Text = elapsedTime.ToLongTimeString();// elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;

            if (torrent.Monitor.DownloadSpeed > 0)
            {
                double secs = (torrent.Torrent.Size - (torrent.Torrent.Size * (torrent.Progress / 100))) / torrent.Monitor.DownloadSpeed;
                DateTime dt = new DateTime().AddSeconds(secs);
                mainForm.DetailTabEstimatedTime.Text = dt.ToString("hh:mm:ss");
            }
            else
                mainForm.DetailTabEstimatedTime.Text = string.Empty;

            //double estimatedTime = 0;
            //if (torrent.Monitor.DownloadSpeed > 0)
            //    estimatedTime = 3600.0 / ((torrent.Torrent.Size - torrent.Monitor.DataBytesDownloaded) / torrent.Monitor.DownloadSpeed);
            //mainForm.DetailTabEstimatedTime.Text = new TimeSpan(0, 0, (int)estimatedTime).ToString();

            mainForm.DetailTabPeers.Text = torrent.OpenConnections.ToString();
            mainForm.DetailTabPieces.Text = torrent.Torrent.Pieces.Count.ToString();
            mainForm.DetailTabUpload.Text = FormatSizeValue(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded);
            mainForm.DetailTabUploadSpeed.Text = FormatSpeedValue(torrent.Monitor.UploadSpeed);
        }

        private void ClearDetailTab()
        {
            mainForm.DetailTabClients.Text = "...";
            mainForm.DetailTabDownload.Text = "...";
            mainForm.DetailTabDownloadSpeed.Text = "...";
            mainForm.DetailTabElapsedTime.Text = "...";
            mainForm.DetailTabEstimatedTime.Text = "...";
            mainForm.DetailTabPeers.Text = "...";
            mainForm.DetailTabPieces.Text = "...";
            mainForm.DetailTabUpload.Text = "...";
            mainForm.DetailTabUploadSpeed.Text = "...";
        }

        #endregion

		#region Piece tab

		public void UpdatePiecesTab()
        {
            TorrentManager selectedTorrent = GetSelectedTorrent();
            if (selectedTorrent == null)
                return;
			try
			{
				mainForm.PiecesListView.BeginUpdate();
                mainForm.PiecesListView.Items.Clear();

				lock (currentRequests)
				{
                    // First sort them according to the piece index
                    currentRequests.Sort(new Comparison<BlockEventArgs>(delegate (BlockEventArgs left, BlockEventArgs right) {
                        return left.Piece.Index.CompareTo(right.Piece.Index);
                    }));

                    // Render them onto the listview
					for (int i = 0; i < this.currentRequests.Count; i++)
					{
                        if (this.currentRequests[i].ID.TorrentManager != selectedTorrent)
							continue;

						ListViewItem item = new ListViewItem(this.currentRequests[i].Piece.Index.ToString());
						item.SubItems.Add(FormatSizeValue(this.currentRequests[i].Block.RequestLength));
                        item.SubItems.Add(this.currentRequests[i].Piece.BlockCount.ToString());
						item.SubItems.Add(new ImageListView.ImageListViewSubItem(new BlockProgressBar(this.currentRequests[i])));
						mainForm.PiecesListView.Items.Add(item);
					}
				}
			}
			finally
			{
				mainForm.PiecesListView.EndUpdate();
			}
		}

		#endregion

		#region Files tab

		internal void UpdateFilesTab()
        {
			mainForm.filesTreeView.Nodes.Clear();
			IList<TorrentManager> torrents = GetSelectedTorrents();
			if (torrents.Count == 0)
			{
				mainForm.filesTreeView.TopNode = new TreeNode("");
				return;
			}
            TorrentManager torrent = torrents[0];

			try
			{
				mainForm.filesTreeView.BeginUpdate();

				TreeNode newNode = null;

				mainForm.filesTreeView.TopNode = new TreeNode(torrent.Torrent.Name);

                //recurse on all file to create folder
                foreach (TorrentFile file in torrent.Torrent.Files)
                {
                    string path = Path.GetDirectoryName(file.Path);

                    TreeNodeCollection nodes = mainForm.filesTreeView.Nodes;

                    if (!string.IsNullOrEmpty(path))
                    {
                        string[] splitedPath = path.Split(System.IO.Path.DirectorySeparatorChar);

                        foreach (string str in splitedPath)
                        {
                            if (string.IsNullOrEmpty(str))
                                continue;

                            if (!nodes.ContainsKey(str))
                            {
                                newNode = new TreeNode(str);
                                newNode.Name = str;
                                newNode.SelectedImageKey = "folder";
                                newNode.ImageKey = "folder";
                                nodes.Add(newNode);
                            }
                            nodes = nodes[str].Nodes;
                        }
                    }
                }

				//recurse on all file to add file
                foreach (TorrentFile file in torrent.Torrent.Files)
                {
                    string path = Path.GetDirectoryName(file.Path);
                    string filename = Path.GetFileName(file.Path);

                    TreeNodeCollection nodes = mainForm.filesTreeView.Nodes;

                    if (!string.IsNullOrEmpty(path))
                    {
                        string[] splitedPath = path.Split(System.IO.Path.DirectorySeparatorChar);

                        foreach (string str in splitedPath)
                        {
                            if (string.IsNullOrEmpty(str))
                                continue;
                            nodes = nodes[str].Nodes;
                        }
                    }
                    newNode = new TreeNode(filename);
                    newNode.Name = filename;
                    newNode.SelectedImageKey = "file";
                    newNode.ImageKey = "file";
                    switch (file.Priority)
                    {
                        case Priority.DoNotDownload:
                            newNode.StateImageKey = "doNotDownload";
                            newNode.ToolTipText = "Do not download!";
                            break;
                        case Priority.High:
                            newNode.StateImageKey = "high";
                            newNode.ToolTipText = "High";
                            break;
                        case Priority.Highest:
                            newNode.StateImageKey = "highest";
                            newNode.ToolTipText = "Highest";
                            break;
                        case Priority.Immediate:
                            newNode.StateImageKey = "immediate";
                            newNode.ToolTipText = "Immediate!";
                            break;
                        case Priority.Low:
                            newNode.StateImageKey = "low";
                            newNode.ToolTipText = "Low";
                            break;
                        case Priority.Lowest:
                            newNode.StateImageKey = "lowest";
                            newNode.ToolTipText = "Lowest";
                            break;
                        case Priority.Normal:
                            newNode.StateImageKey = "normal";
                            newNode.ToolTipText = "Normal";
                            break;
                        default:
                            break;
                    }
                    newNode.Tag = file;
                    nodes.Add(newNode);
                }
			}
			finally
			{
				mainForm.filesTreeView.EndUpdate();
			}
		}

		internal void ChangeFilePriority(TreeNode treeNode)
		{
			TorrentFile file = treeNode.Tag as TorrentFile;
			if (file == null) return;

			switch (file.Priority)
			{
				case Priority.DoNotDownload:
					treeNode.StateImageKey = "lowest";
					file.Priority = Priority.Lowest;
					treeNode.ToolTipText = "Lowest";
					break;
				case Priority.High:
					treeNode.StateImageKey = "highest";
					file.Priority = Priority.Highest;
					treeNode.ToolTipText = "Highest";
					break;
				case Priority.Highest:
					treeNode.StateImageKey = "immediate";
					file.Priority = Priority.Immediate;
					treeNode.ToolTipText = "Immediate!";
					break;
				case Priority.Immediate:
					treeNode.StateImageKey = "doNotDownload";
					file.Priority = Priority.DoNotDownload;
					treeNode.ToolTipText = "Do not download!";
					break;
				case Priority.Low:
					treeNode.StateImageKey = "normal";
					file.Priority = Priority.Normal;
					treeNode.ToolTipText = "Normal";
					break;
				case Priority.Lowest:
					treeNode.StateImageKey = "low";
					file.Priority = Priority.Low;
					treeNode.ToolTipText = "Low";
					break;
				case Priority.Normal:
					treeNode.StateImageKey = "high";
					file.Priority = Priority.High;
					treeNode.ToolTipText = "High";
					break;
				default:
					break;
			}
		}

		#endregion

        #region Statistics tab

        private void UpdateStatsGraph()
        {
            mainForm.StatsGraph.AddDownloadValue(clientEngine.TotalDownloadSpeed);
            mainForm.StatsGraph.AddUploadValue(clientEngine.TotalUploadSpeed);
            mainForm.StatsGraph.Invalidate();
        }

        #endregion

        #region MiniWindow

        internal void switchToMiniWindow(bool flag)
        {
            if (flag)
            {
                mainForm.Hide();
                LoadMiniWindow();
                miniWindow.Show();
            }
            else 
            {
                miniWindow.Hide();
                mainForm.Show();
            }
        }

        internal void LoadMiniWindow()
        {
            miniWindow.ListView.Items.Clear();

            foreach (TorrentManager torrent in itemToTorrent.Values)
            {
                ListViewItem item = new ListViewItem(torrent.Torrent.Name);

			    ListViewItem.ListViewSubItem subitem = item.SubItems[0];
			    subitem.Name = "colName";

                ImageListView.ImageListViewSubItem sitem = new ImageListView.ImageListViewSubItem(new TorrentProgressBar(torrent));
                sitem.Name = "colProgress";
                item.SubItems.Add(sitem);

                miniWindow.ListView.Items.Add(item);
            }
        }

        private void UpdateMiniWindow()
        {
            miniWindow.ListView.Invalidate();
        }

        #endregion

    }
}
