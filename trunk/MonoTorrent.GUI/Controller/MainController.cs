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
		private ReaderWriterLock peerlocker;
		
		public MainController(MainWindow mainForm, SettingsBase settings)
        {
			this.mainForm = mainForm;
            this.settingsBase = settings;
            itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();
			itemToPeers = new Dictionary<ListViewItem, PeerConnectionID>();
			peerlocker = new ReaderWriterLock();
			
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

		#region Peer

		public void CreatePeer(PeerConnectionID peerID)
		{
			ListViewItem item = new ListViewItem(peerID.Peer.PeerId);

			ListViewItem.ListViewSubItem subitem = item.SubItems[0];
			subitem.Name = "PeerId";

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "ClientApp";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "LocationPeer";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "Download";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "Upload";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "DownloadSpeed";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "UploadSpeed";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "IsSeeder";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "Encryption";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "IsChoking";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "IsInterested";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "IsRequestingPiecesCount";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "PiecesSent";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "SupportsFastPeer";
			item.SubItems.Add(subitem);

			mainForm.PeersView.Items.Add(item);
			lock (itemToPeers)
				itemToPeers.Add(item, peerID);
		}

		public void DeletePeer(PeerConnectionID id)
		{
			lock (itemToPeers)
				foreach (KeyValuePair<ListViewItem, PeerConnectionID> entry in itemToPeers)
				{
					if (entry.Value != id)
						continue;

					itemToPeers.Remove(entry.Key);
					mainForm.PeersView.Items.Remove(entry.Key);
					return;
				}
		}

		private delegate void PeerHandler(PeerConnectionID peerID);

		public void UpdatePeers()
		{
			try
			{
				this.mainForm.PeersView.BeginUpdate();
				lock (itemToPeers)
					foreach (KeyValuePair<ListViewItem, PeerConnectionID> entry in itemToPeers)
					{
						peerlocker.AcquireReaderLock(1000);
						if (entry.Value.Peer.Connection == null)
							entry.Key.SubItems["ClientApp"].Text = "PEER DISPOSED";
						else
						{
							entry.Key.SubItems["Download"].Text = FormatSizeValue(entry.Value.Peer.Connection.Monitor.DataBytesDownloaded);
							entry.Key.SubItems["Upload"].Text = FormatSizeValue(entry.Value.Peer.Connection.Monitor.DataBytesUploaded);
							entry.Key.SubItems["DownloadSpeed"].Text = FormatSpeedValue(entry.Value.Peer.Connection.Monitor.DownloadSpeed);
							entry.Key.SubItems["UploadSpeed"].Text = FormatSpeedValue(entry.Value.Peer.Connection.Monitor.UploadSpeed);
							entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.Peer.Connection.IsRequestingPiecesCount.ToString();
							entry.Key.SubItems["PiecesSent"].Text = entry.Value.Peer.Connection.PiecesSent.ToString();
						}
						peerlocker.ReleaseReaderLock();
					}
			}
			finally
			{
				this.mainForm.PeersView.EndUpdate();
			}
		}

		#endregion

		#region torrent

		public void UpdateAllStats()
		{

            UpdateTorrentsView();
            UpdatePiecesTab();
			UpdatePeers();
		}

		private void UpdateTorrentsView()
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
			item.SubItems["colName"].Text = torrent.Torrent.Name;
			item.SubItems["colSize"].Text = FormatSizeValue(torrent.Torrent.Size);
            UpdateState(torrent);
        }

        /// <summary>
        /// update torrent state in view
        /// </summary>
        /// <param name="torrent"></param>
        public void UpdateState(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
			item.SubItems["colProgress"].Text = string.Format("{0:0.00} %", torrent.Progress);
			item.SubItems["colStatus"].Text = torrent.State.ToString();
			item.SubItems["colSeeds"].Text = torrent.Peers.Seeds().ToString();
			item.SubItems["colLeeches"].Text = torrent.Peers.Leechs().ToString();
			item.SubItems["colDownSpeed"].Text = FormatSpeedValue(torrent.Monitor.DownloadSpeed);
			item.SubItems["colUpSpeed"].Text = FormatSpeedValue(torrent.Monitor.UploadSpeed);
			//I put only download of file and not the download of protocole
			item.SubItems["colDownloaded"].Text = FormatSizeValue(torrent.Monitor.DataBytesDownloaded);
			// here i put all upload because we want to know whais bandwidth
			item.SubItems["colUploaded"].Text = FormatSizeValue(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded);
			//ratio is for all upload vs all download
			if (torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded != 0)
				item.SubItems["colRatio"].Text = string.Format("{0:0.00}", (float)(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded) / (torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded));
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
		
		public void OnPeerConnected(object sender, PeerConnectionEventArgs args)
		{
			if (!mainForm.IsDisposed)
				mainForm.Invoke(new PeerHandler(CreatePeer), args.PeerID);
		}

		public void OnPeerDisconnected(object sender, PeerConnectionEventArgs args)
		{
			if (!mainForm.IsDisposed)
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
            //if (!mainForm.IsDisposed)
            //    mainForm.Invoke(new UpdateHandler(Update), torrent);
        }

        /// <summary>
        /// event torrent state change
        /// </summary>
        /// <param name="sender">TorrentManager</param>
        /// <param name="args"></param>
        private void OnTorrentStateChange(object sender, EventArgs args)
        {
            //TorrentManager torrent = (TorrentManager)sender;
			//if (!mainForm.IsDisposed)
			//    mainForm.Invoke(new UpdateHandler(UpdateState), torrent);
        }
		// FIXME: Is this the best way to do this?
		private int counter = 0;
		/// <summary>
		/// event update stats change
		/// </summary>
		/// <param name="sender">clientengine</param>
		/// <param name="args"></param>
		private void OnUpdateStats(object sender, EventArgs args)
		{
			// Only update the screen every 8 ticks
			if (!mainForm.IsDisposed && ((counter++ % 8) == 0))
				mainForm.Invoke(new UpdateStatsHandler(UpdateAllStats));
		}


        private delegate void BlockDelegate(BlockEventArgs e);
        void torrent_PieceHashed(object sender, PieceHashedEventArgs e)
        {
            // When the piece has been hashed, we know it's finished
            lock (currentRequests)
                for (int i = 0; i < currentRequests.Count; i++)
                    if (currentRequests[i].Piece.Index == e.PieceIndex)
                    {
                        mainForm.Invoke(new BlockDelegate(mainForm.PiecesListView.Remove), currentRequests[i]);
                        currentRequests.RemoveAt(i);
                        return;
                    }
        }

        List<BlockEventArgs> currentRequests = new List<BlockEventArgs>();
        void PieceManager_BlockRequested(object sender, BlockEventArgs e)
        {
            lock (currentRequests)
            {
                currentRequests.Add(e);
                mainForm.Invoke(new BlockDelegate(mainForm.PiecesListView.Add), e);
            }
        }

        void PieceManager_BlockRequestCancelled(object sender, BlockEventArgs e)
        {
            // Do nothing (for the moment). I should do a fix for this
        }

        void PieceManager_BlockReceived(object sender, BlockEventArgs e)
        {
            // Do nothing
        }

        void FileManager_BlockWritten(object sender, BlockEventArgs e)
        {
            // Do nothing
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
                {
                    creator.Announces.Add(new List<string>());
                    creator.Announces[0].Add(window.TrackerURL);
                }
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

			ListViewItem.ListViewSubItem subitem = item.SubItems[0];
			subitem.Name = "colName";

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colSize";
			item.SubItems.Add(subitem);

			subitem = new ListViewItem.ListViewSubItem();
			subitem.Name = "colProgress";
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

			mainForm.TorrentsView.Items.Add(item);
            TorrentManager torrent = clientEngine.LoadTorrent(newPath, clientEngine.Settings.SavePath, settings);
            itemToTorrent.Add(item, torrent);
            torrent.PieceHashed += new EventHandler<PieceHashedEventArgs>(torrent_PieceHashed);
            torrent.PeersFound += OnTorrentChange;
            torrent.TorrentStateChanged += OnTorrentStateChange;
            torrent.FileManager.BlockWritten += new EventHandler<BlockEventArgs>(FileManager_BlockWritten);
            torrent.PieceManager.BlockReceived += new EventHandler<BlockEventArgs>(PieceManager_BlockReceived);
            torrent.PieceManager.BlockRequestCancelled += new EventHandler<BlockEventArgs>(PieceManager_BlockRequestCancelled);
            torrent.PieceManager.BlockRequested += new EventHandler<BlockEventArgs>(PieceManager_BlockRequested);
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



		public void UpdateGeneralTab()
		{
			IList<TorrentManager> torrents =  GetSelectedTorrents();
			if (torrents.Count == 0)
				return;
			TorrentManager torrent = torrents[0];
			
			mainForm.GenTabDateLabel.Text = torrent.Torrent.CreationDate.ToShortDateString();
			mainForm.GenTabFolderLabel.Text = torrent.SavePath;
			string hash = "";
			for (int i = 0; i < torrent.Torrent.InfoHash.Length; i++)
				hash += torrent.Torrent.InfoHash[i].ToString("X");

			mainForm.GenTabHashLabel.Text = hash;
			mainForm.GenTabInfosLabel.Text = torrent.Torrent.Comment;
			mainForm.GenTabPiecesxSizeLabel.Text = torrent.Torrent.Pieces.Count.ToString() + " X " + FormatSizeValue(torrent.Torrent.PieceLength);
			mainForm.GenTabSizeLabel.Text = FormatSizeValue(torrent.Torrent.Size);
			mainForm.GenTabStatusLabel.Text = torrent.State.ToString();
			mainForm.GenTabUpdateLabel.Text = torrent.TrackerManager.LastUpdated.ToShortTimeString();
			mainForm.GenTabURLLabel.Text = torrent.Torrent.Source;
			//todo handle update of update event
		}

        public void UpdatePiecesTab()
        {
            mainForm.PiecesListView.Invalidate();
        }


        public void UpdateDetailTab()
		{
			IList<TorrentManager> torrents = GetSelectedTorrents();
			if (torrents.Count == 0)
				return;
			TorrentManager torrent = torrents[0];

			mainForm.DetailTabClients.Text = "";
			mainForm.DetailTabDownload.Text = FormatSizeValue(torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded);
			mainForm.DetailTabDownloadSpeed.Text = FormatSpeedValue(torrent.Monitor.DownloadSpeed);
			DateTime elapsedTime = new DateTime();
			//TODO calcul the elapsedtime.

			mainForm.DetailTabElapsedTime.Text = "";

			double estimatedTime = 0;
			if (torrent.Monitor.DownloadSpeed > 0)
				estimatedTime = 3600.0 / ((torrent.Torrent.Size - torrent.Monitor.DataBytesDownloaded) / torrent.Monitor.DownloadSpeed);

			mainForm.DetailTabEstimatedTime.Text = new TimeSpan(0,0, (int)estimatedTime).ToString();
			mainForm.DetailTabPeers.Text = torrent.OpenConnections.ToString();
			mainForm.DetailTabPieces.Text = torrent.Torrent.Pieces.Count.ToString();
			mainForm.DetailTabUpload.Text = (torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded).ToString();
			mainForm.DetailTabUploadSpeed.Text = torrent.Monitor.UploadSpeed.ToString();
			//todo handle update of update event
		}
	}
}
