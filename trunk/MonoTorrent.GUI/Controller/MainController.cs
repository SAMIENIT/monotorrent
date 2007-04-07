using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client;
using System.Windows.Forms;
using MonoTorrent.GUI.View;
using MonoTorrent.GUI.Settings;
using System.IO;
using MonoTorrent.Common;
namespace MonoTorrent.GUI.Controller
{
    public class MainController
    {
        private ClientEngine clientEngine;
        private OptionWindow optionWindow;
        private AboutWindow aboutWindow;
		private MainWindow mainForm;
        private IDictionary<ListViewItem, TorrentManager> itemToTorrent;
        private SettingsBase settingsBase;
		private IDictionary<ListViewItem, PeerConnectionID> itemToPeers;

		public MainController(MainWindow mainForm, SettingsBase settings)
        {
			this.mainForm = mainForm;
            this.settingsBase = settings;
            itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();
			itemToPeers = new Dictionary<ListViewItem, PeerConnectionID>();

            //get general settings in file
            GuiGeneralSettings genSettings = settings.LoadSettings<GuiGeneralSettings>("General Settings");
            clientEngine = new ClientEngine( genSettings.GetEngineSettings(), 
                TorrentSettings.DefaultSettings());

            // Create Torrents path
            if (!Directory.Exists(genSettings.TorrentsPath))
                Directory.CreateDirectory(genSettings.TorrentsPath);

            //load all torrents in torrents folder
            foreach (string file in Directory.GetFiles(genSettings.TorrentsPath, "*.torrent"))
            {
                GuiTorrentSettings torrentSettings = settings.LoadSettings<GuiTorrentSettings>("Torrent Settings for " + file);
                Add(file, torrentSettings.GetTorrentSettings());
            }

			//subscribe to event for update
			clientEngine.StatsUpdate += OnUpdateStats;

			ClientEngine.ConnectionManager.PeerConnected += OnPeerConnected;
			ClientEngine.ConnectionManager.PeerDisconnected += OnPeerDisconnected;
        }

		public void OnPeerConnected(object sender, PeerConnectionEventArgs args)
		{
			ListViewItem item = new ListViewItem(args.PeerID.Peer.PeerId);
			for (int i = 0; i < 14; i++)
				item.SubItems.Add("");

			mainForm.PeersView.Items.Add(item);
			lock(itemToPeers)
				itemToPeers.Add(item,args.PeerID);
			try
			{
				this.mainForm.PeersView.BeginUpdate();
				UpdatePeers();
			}
			finally
			{
				this.mainForm.PeersView.EndUpdate();
			}

		}

		public void OnPeerDisconnected(object sender, PeerConnectionEventArgs args)
		{
			lock (itemToPeers)
				foreach (KeyValuePair<ListViewItem, PeerConnectionID> entry in itemToPeers)
				{
					if (entry.Value != args.PeerID)
						continue;

					itemToPeers.Remove(entry.Key);
					return;
				}
		}

		/// <summary>
		/// close all before exit
		/// </summary>
 		public void Exit()
		{
			//TODO : Exit => dispose
			clientEngine.Stop();
			GuiTorrentSettings torrentSettings;
			foreach (TorrentManager torrent in clientEngine.Torrents)
			{
				torrent.PieceHashed -= OnTorrentChange;
				torrent.PeersFound -= OnTorrentChange;
				torrent.TorrentStateChanged -= OnTorrentStateChange;
				torrentSettings = new GuiTorrentSettings();
				torrentSettings.SetTorrentSettings(torrent.Settings);
				settingsBase.SaveSettings<GuiTorrentSettings>("Torrent Settings for " + torrent.Torrent.TorrentPath, torrentSettings);
			}

			clientEngine.StatsUpdate -= OnUpdateStats;
		}

        #region Helper

		public void UpdatePeers()
		{
			try
			{
				this.mainForm.PeersView.BeginUpdate();
				lock (itemToPeers)
					foreach (KeyValuePair<ListViewItem, PeerConnectionID> entry in itemToPeers)
					{
						lock (entry.Value)
						{
							if (entry.Value.Peer.Connection == null)
								entry.Key.SubItems[1].Text = "PEER DISPOSED";
							else
							{
								entry.Key.SubItems[0].Text = entry.Value.Peer.PeerId;
								entry.Key.SubItems[1].Text = entry.Value.Peer.Location;
								entry.Key.SubItems[2].Text = FormatBool(entry.Value.Peer.IsSeeder);
								entry.Key.SubItems[3].Text = entry.Value.Peer.EncryptionSupported.ToString();
								entry.Key.SubItems[4].Text = FormatBool(entry.Value.Peer.Connection.IsChoking);
								entry.Key.SubItems[5].Text = FormatBool(entry.Value.Peer.Connection.IsInterested);
								entry.Key.SubItems[6].Text = entry.Value.Peer.Connection.AddressBytes.ToString();
								entry.Key.SubItems[7].Text = entry.Value.Peer.Connection.IsRequestingPiecesCount.ToString();
								entry.Key.SubItems[8].Text = entry.Value.Peer.Connection.PiecesSent.ToString();
								entry.Key.SubItems[9].Text = FormatBool(entry.Value.Peer.Connection.SupportsFastPeer);
								entry.Key.SubItems[10].Text = FormatSizeValue(entry.Value.Peer.Connection.Monitor.DataBytesDownloaded);
								entry.Key.SubItems[11].Text = FormatSizeValue(entry.Value.Peer.Connection.Monitor.DataBytesUploaded);
								entry.Key.SubItems[12].Text = FormatSpeedValue(entry.Value.Peer.Connection.Monitor.DownloadSpeed);
								entry.Key.SubItems[13].Text = FormatSpeedValue(entry.Value.Peer.Connection.Monitor.UploadSpeed);
								entry.Key.SubItems[14].Text = entry.Value.Peer.Connection.ClientApp.Client.ToString();
							}
						}
					}
			}
			finally
			{
				this.mainForm.PeersView.EndUpdate();
			}
		}

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
			if (value < 1000)
				return String.Format("{0:0.00} o", value);
			if (value < 1000000)
				return String.Format("{0:0.00} Ko", value / 1000.0);
			if (value < 1000000000)
				return String.Format("{0:0.00} Mo", value/1000000.0);
			return String.Format("{0:0.00} Go", value/1000000000.0);
		}

		public string FormatSizeValue(double value)
		{
			return FormatSizeValue(Convert.ToInt64(value));
		}
		public void UpdateAllStats()
		{
			try
			{
				this.mainForm.TorrentsView.BeginUpdate();
				foreach (TorrentManager torrent in clientEngine.Torrents)
					UpdateState(torrent);
			}
			finally
			{
				this.mainForm.TorrentsView.EndUpdate();
			}
			UpdatePeers();
		}

        /// <summary>
        /// get all row selected in list view
        /// </summary>
        /// <returns></returns>
        public IList<TorrentManager> GetSelectedTorrents()
        {
            IList<TorrentManager> result = new List<TorrentManager>();
			foreach (ListViewItem item in mainForm.TorrentsView.SelectedItems)
                result.Add(itemToTorrent[item]);
            return result;
        }

        private delegate void UpdateHandler(TorrentManager torrent);
		private delegate void UpdateStatsHandler();

        /// <summary>
        /// update torrent in gui
        /// </summary>
        /// <param name="torrent"></param>
        public void Update(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
            item.SubItems[0].Text = torrent.Torrent.Name;
            item.SubItems[1].Text = FormatSizeValue(torrent.Torrent.Size);
            UpdateState(torrent);
        }

        /// <summary>
        /// update torrent state in view
        /// </summary>
        /// <param name="torrent"></param>
        public void UpdateState(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
			item.SubItems[2].Text = string.Format("{0:0.00} %", torrent.Progress);
            item.SubItems[3].Text = torrent.State.ToString();
            item.SubItems[4].Text = torrent.Seeds().ToString();
            item.SubItems[5].Text = torrent.Leechs().ToString();
			item.SubItems[6].Text = FormatSpeedValue(torrent.DownloadSpeed());
			item.SubItems[7].Text = FormatSpeedValue(torrent.UploadSpeed());
            item.SubItems[8].Text = FormatSizeValue(torrent.Monitor.DataBytesDownloaded);
            item.SubItems[9].Text = FormatSizeValue(torrent.Monitor.DataBytesUploaded);
            item.SubItems[10].Text = torrent.AvailablePeers.ToString();//FIXME ratio here
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

        #region Event Methode

        /// <summary>
        /// event torrent change
        /// </summary>
        /// <param name="sender">TorrentManager</param>
        /// <param name="args">nothing</param>
        private void OnTorrentChange(object sender, EventArgs args)
        {
            TorrentManager torrent = (TorrentManager)sender;
			if (!mainForm.IsDisposed)
				mainForm.Invoke(new UpdateHandler(Update), torrent);
        }

        /// <summary>
        /// event torrent state change
        /// </summary>
        /// <param name="sender">TorrentManager</param>
        /// <param name="args"></param>
        private void OnTorrentStateChange(object sender, EventArgs args)
        {
            TorrentManager torrent = (TorrentManager)sender;
			if (!mainForm.IsDisposed)
				mainForm.Invoke(new UpdateHandler(UpdateState), torrent);
        }

		/// <summary>
		/// event update stats change
		/// </summary>
		/// <param name="sender">clientengine</param>
		/// <param name="args"></param>
		private void OnUpdateStats(object sender, EventArgs args)
		{
			if (!mainForm.IsDisposed)
				mainForm.Invoke(new UpdateStatsHandler(UpdateAllStats));
		}

        #endregion

        #region Controller Action

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
                    creator.AddAnnounce(window.TrackerURL);
                string newPath = Path.Combine(window.SaveTo, Path.GetFileName(window.FromPath));
                creator.Create(newPath);
            }
        }

        public void Add()
        {
            try
            {
                System.Windows.Forms.OpenFileDialog dialogue = new OpenFileDialog();
                dialogue.Filter = "Torrent File (*.torrent)|*.torrent|Tous les fichiers (*.*)|*.*";
                dialogue.Title = "Open";
                dialogue.DefaultExt = ".torrent";
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    Add(dialogue.FileName);                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Add :" + e.ToString());
            }
        }

        public void Add(string fileName)
        {
            Add(fileName, clientEngine.DefaultTorrentSettings);
        }

        public void Add(string fileName, TorrentSettings settings)
        {
            GuiGeneralSettings genSettings = settingsBase.LoadSettings<GuiGeneralSettings>("General Settings");
            string newPath = Path.Combine(genSettings.TorrentsPath, Path.GetFileName(fileName));
            if (newPath != fileName)
            {
                if (File.Exists(newPath))
                {
                    MessageBox.Show("This torrent already exist in torrent folder.");
                    return;
                }
                File.Copy(fileName, newPath);
            }
            ListViewItem item = new ListViewItem(Path.GetFileName(newPath));
            for (int i = 0; i < 10; i++)
                item.SubItems.Add("");
			mainForm.TorrentsView.Items.Add(item);
            TorrentManager torrent = clientEngine.LoadTorrent(newPath, clientEngine.Settings.SavePath, settings);
            itemToTorrent.Add(item, torrent);
            torrent.PieceHashed += OnTorrentChange;
            torrent.PeersFound += OnTorrentChange;
            torrent.TorrentStateChanged += OnTorrentStateChange;
        }

        public void Del()
        {
            try
            {
                if (MessageBox.Show("Are you sure ?", "Delete Torrent", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (TorrentManager torrent in GetSelectedTorrents())
                    {
                        GetItemFromTorrent(torrent).Remove();
                        clientEngine.Remove(torrent);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Del :" + e.ToString());
            }
        }

        public void Start()
        {
            try
            {
                foreach (TorrentManager torrent in GetSelectedTorrents())
                {
                    if ( torrent.State == TorrentState.Paused 
                        || torrent.State == TorrentState.Stopped)
                        clientEngine.Start(torrent);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Start :"+ e.ToString());
            }
        }

        public void Stop()
        {
            try
            {
                foreach (TorrentManager torrent in GetSelectedTorrents())
                {
                    if (torrent.State != TorrentState.Stopped)
                        clientEngine.Stop(torrent);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

        public void Pause()
        {
            try
            {
                foreach (TorrentManager torrent in GetSelectedTorrents())
                {
                    if (torrent.State != TorrentState.Paused
                        && torrent.State != TorrentState.Stopped)
                    clientEngine.Pause(torrent);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

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

        /// <summary>
        /// update general settings
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateSettings(GuiGeneralSettings settings)
        {
            settingsBase.SaveSettings<GuiGeneralSettings>("General Settings", settings);
            clientEngine.Settings = settings.GetEngineSettings();
        }
        
        
    }
}
