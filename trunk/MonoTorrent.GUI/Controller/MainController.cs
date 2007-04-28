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

namespace MonoTorrent.GUI.Controller
{
    public class MainController : IDisposable
	{
		#region private field

		private ClientEngine clientEngine;
        private OptionWindow optionWindow;
        private AboutWindow aboutWindow;
		private MainWindow mainForm;
        private IDictionary<ListViewItem, TorrentManager> itemToTorrent;
        private SettingsBase settingsBase;
		private IDictionary<ListViewItem, PeerConnectionID> itemToPeers;
		private ReaderWriterLock peerlocker;

		#endregion

		#region constructor and destructor

		public MainController(MainWindow mainForm)
        {
			this.mainForm = mainForm;
			itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();
			itemToPeers = new Dictionary<ListViewItem, PeerConnectionID>();
			peerlocker = new ReaderWriterLock();
			settingsBase = new SettingsBase();

			LoadViewSettings();
            Init();
        }

		public void Init()
		{
			//get general settings in file
			GuiGeneralSettings genSettings = settingsBase.LoadSettings<GuiGeneralSettings>("General Settings");
			clientEngine = new ClientEngine(genSettings.GetEngineSettings(),
				TorrentSettings.DefaultSettings());

			// Create Torrents path
			if (!Directory.Exists(genSettings.TorrentsPath))
				Directory.CreateDirectory(genSettings.TorrentsPath);

			//load all torrents in torrents folder
			foreach (string file in Directory.GetFiles(genSettings.TorrentsPath, "*.torrent"))
			{
				GuiTorrentSettings torrentSettings = settingsBase.LoadSettings<GuiTorrentSettings>("Torrent Settings for " + file);
				Add(file, torrentSettings.GetTorrentSettings(),
					string.IsNullOrEmpty(torrentSettings.SavePath) ? clientEngine.Settings.SavePath : torrentSettings.SavePath);
			}

			//subscribe to event for update
			clientEngine.StatsUpdate += OnUpdateStats;

			ClientEngine.ConnectionManager.PeerConnected += OnPeerConnected;
			ClientEngine.ConnectionManager.PeerDisconnected += OnPeerDisconnected;
		}

		/// <summary>
		/// close all before exit
		/// </summary>
 		public void Dispose()
		{
            WaitHandle[] handle = clientEngine.Stop();
            WaitHandle.WaitAll(handle);

			GuiTorrentSettings torrentSettings;
			foreach (TorrentManager torrent in clientEngine.Torrents)
			{
				torrent.PieceHashed -= OnTorrentChange;
				torrent.PeersFound -= OnTorrentChange;
				torrent.TorrentStateChanged -= OnTorrentStateChange;
				torrentSettings = new GuiTorrentSettings();
				torrentSettings.SetTorrentSettings(torrent.Settings);
                torrentSettings.SavePath = torrent.SavePath;
				settingsBase.SaveSettings<GuiTorrentSettings>("Torrent Settings for " + torrent.Torrent.TorrentPath, torrentSettings);
			}

			clientEngine.StatsUpdate -= OnUpdateStats;
			UpdateViewSettings();
		}

		#endregion

		#region Peer

		public void CreatePeer(PeerConnectionID id)
        {
            lock (id)
            {
                if (id.Peer.Connection == null)
                    return;

                ListViewItem item = new ListViewItem(id.Peer.PeerId);
                ListViewItem.ListViewSubItem subitem = item.SubItems[0];
                subitem.Name = "PeerId";
                subitem.Text = id.Peer.PeerId;

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "ClientApp";
                item.SubItems.Add(subitem);


                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "LocationPeer";
                item.SubItems.Add(subitem);
                subitem.Text = id.Peer.Location;


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
                subitem.Text = id.Peer.IsSeeder ? "Yes" : "No";

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "Encryption";
                item.SubItems.Add(subitem);
                subitem.Text = FormatBool(id.Peer.EncryptionSupported == EncryptionMethods.RC4Encryption);
                //FIXME: This isn't right!

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "IsChoking";
                item.SubItems.Add(subitem);
                subitem.Text = FormatBool(id.Peer.Connection.IsChoking);

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "IsInterested";
                item.SubItems.Add(subitem);
                subitem.Text = FormatBool(id.Peer.Connection.IsInterested);

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "IsRequestingPiecesCount";
                item.SubItems.Add(subitem);
                subitem.Text = id.Peer.Connection.IsRequestingPiecesCount.ToString();

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "PiecesSent";
                item.SubItems.Add(subitem);
                subitem.Text = id.Peer.Connection.PiecesSent.ToString();

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Name = "SupportsFastPeer";
                item.SubItems.Add(subitem);
                subitem.Text = FormatBool(id.Peer.Connection.SupportsFastPeer);

                mainForm.PeersView.Items.Add(item);
                lock (itemToPeers)
                    itemToPeers.Add(item, id);
            }
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
                        lock (entry.Value)
                        {
                            if (entry.Value.Peer.Connection == null)
                            {
                                entry.Key.SubItems[0].Text = "PEER DISPOSED";
                                for (int i = 1; i < entry.Key.SubItems.Count; i++)
                                    entry.Key.SubItems[i].Text = "";
                            }

                            else
                            {
                                entry.Key.SubItems["PeerId"].Text = entry.Value.Peer.PeerId;
                                entry.Key.SubItems["IsSeeder"].Text = FormatBool(entry.Value.Peer.IsSeeder);
                                entry.Key.SubItems["IsChoking"].Text = FormatBool(entry.Value.Peer.Connection.IsChoking);
                                entry.Key.SubItems["IsInterested"].Text = FormatBool(entry.Value.Peer.Connection.IsInterested);
                                entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.Peer.Connection.IsRequestingPiecesCount.ToString();
                                entry.Key.SubItems["PiecesSent"].Text = entry.Value.Peer.Connection.PiecesSent.ToString();
                                entry.Key.SubItems["ClientApp"].Text = entry.Value.Peer.Connection.ClientApp.Client.ToString();
                                entry.Key.SubItems["Download"].Text = FormatSizeValue(entry.Value.Peer.Connection.Monitor.DataBytesDownloaded);
                                entry.Key.SubItems["Upload"].Text = FormatSizeValue(entry.Value.Peer.Connection.Monitor.DataBytesUploaded);
                                entry.Key.SubItems["DownloadSpeed"].Text = FormatSpeedValue(entry.Value.Peer.Connection.Monitor.DownloadSpeed);
                                entry.Key.SubItems["UploadSpeed"].Text = FormatSpeedValue(entry.Value.Peer.Connection.Monitor.UploadSpeed);
                                entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.Peer.Connection.IsRequestingPiecesCount.ToString();
                                entry.Key.SubItems["PiecesSent"].Text = entry.Value.Peer.Connection.PiecesSent.ToString();
                            }
                        }
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

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Bloody hell! It crashed:");
            }
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
        /// update torrent state in view
        /// </summary>
        /// <param name="torrent"></param>
        public void UpdateState(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
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
            return FormatSizeValue((double)value);
		}

        public string FormatSizeValue(double value)
        {
            if (value < 1024)
                return String.Format("{0:0.00} o", value);
            if (value < 1024 * 1024)
                return String.Format("{0:0.00} Ko", value / 1024);
            if (value < 1024 * 1024 * 1024)
                return String.Format("{0:0.00} Mo", value / (1024 * 1024));

            return String.Format("{0:0.00} Go", value / (1024 * 1024 * 1024));
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
            TorrentManager torrent = (TorrentManager)sender;
            if (!mainForm.IsDisposed)
                mainForm.Invoke(new UpdateHandler(UpdateState), torrent);
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

            if (counter % 80 == 0)
                MonoTorrent.GUI.Helper.MemoryUtility.OptimizeMemoryUsage();
		}


        private delegate void BlockDelegate(BlockEventArgs e);
        void torrent_PieceHashed(object sender, PieceHashedEventArgs e)
        {
            lock (currentRequests)
            {
                for (int i = 0; i < this.currentRequests.Count; i++)
                {
                    if (this.currentRequests[i].Piece.Index != e.PieceIndex)
                        continue;

                    this.currentRequests.RemoveAt(i);
                }
            }

            mainForm.Invoke(new Handler(UpdatePiecesTab));
        }
        /* //NOT USED
        private void RemoveFromPieceView(int pieceIndex)
        {
            lock (currentRequests)
            {
                for (int i = 0; i < this.currentRequests.Count; i++)
                {
                    if (this.currentRequests[i].Piece.Index != pieceIndex)
                        continue;

                    this.currentRequests.RemoveAt(i);
                    mainForm.Invoke(new Handler(UpdatePiecesTab));
                }
            }
        }
        */
        List<BlockEventArgs> currentRequests = new List<BlockEventArgs>();
        void PieceManager_BlockRequested(object sender, BlockEventArgs e)
        {
            lock (currentRequests)
            {
                currentRequests.Add(e);
            }
            mainForm.Invoke(new Handler(UpdatePiecesTab));
        }

        delegate void Handler();

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
            TorrentSettingWindow window = new TorrentSettingWindow(clientEngine.DefaultTorrentSettings,clientEngine.Settings.SavePath);
            if (window.ShowDialog() == DialogResult.OK)
            {
                Add(fileName, window.Settings, window.SavePath);
            }

        }

        public void Add(string fileName, TorrentSettings settings,string savePath)
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
            TorrentManager torrent = clientEngine.LoadTorrent(newPath, savePath, settings);
            ImageListView.ImageListViewSubItem sitem = new ImageListView.ImageListViewSubItem(new TorrentProgressBar(torrent));
            sitem.Name = "colProgress";
            item.SubItems.Insert(2,sitem);
            itemToTorrent.Add(item, torrent);
            torrent.PieceHashed += new EventHandler<PieceHashedEventArgs>(torrent_PieceHashed);
            torrent.PeersFound += OnTorrentChange;
            torrent.TorrentStateChanged += OnTorrentStateChange;
            torrent.FileManager.BlockWritten += new EventHandler<BlockEventArgs>(FileManager_BlockWritten);
            torrent.PieceManager.BlockReceived += new EventHandler<BlockEventArgs>(PieceManager_BlockReceived);
            torrent.PieceManager.BlockRequestCancelled += new EventHandler<BlockEventArgs>(PieceManager_BlockRequestCancelled);
            torrent.PieceManager.BlockRequested += new EventHandler<BlockEventArgs>(PieceManager_BlockRequested);
            item.SubItems["colSize"].Text = FormatSizeValue(torrent.Torrent.Size);
            item.SubItems["colName"].Text = torrent.Torrent.Name;
            torrent.HashCheck(false);
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

		#region settings

		/// <summary>
        /// update general settings
        /// </summary>
        /// <param name="settings"></param>
		public void UpdateGeneralSettings(GuiGeneralSettings settings)
        {
            settingsBase.SaveSettings<GuiGeneralSettings>("General Settings", settings);
            clientEngine.Settings = settings.GetEngineSettings();
		}

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
		}

		public void UpdateViewSettings()
		{
			GuiViewSettings guisettings = new GuiViewSettings();
			guisettings.FormWidth = mainForm.Width;
			guisettings.FormHeight = mainForm.Height;
			guisettings.SplitterDistance = mainForm.Splitter.SplitterDistance;
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

		#region general tab

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
            mainForm.GenTabURLLabel.Text = torrent.Torrent.Source;
            SmallUpdateGeneralTab(torrent);
		}

        public void SmallUpdateGeneralTab(TorrentManager torrent)
        {
            mainForm.GenTabStatusLabel.Text = torrent.State.ToString();
            mainForm.GenTabUpdateLabel.Text = torrent.TrackerManager.LastUpdated.ToShortTimeString();
            mainForm.TrackerMessage.Text = "";
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

        #region detail tab
        
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
            mainForm.DetailTabClients.Text = "";
            mainForm.DetailTabDownload.Text = FormatSizeValue(torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded);
            mainForm.DetailTabDownloadSpeed.Text = FormatSpeedValue(torrent.Monitor.DownloadSpeed);

            DateTime elapsedTime;
            if (torrent.State == TorrentState.Stopped || torrent.State == TorrentState.Paused)
                elapsedTime = new DateTime(0);
            else
                elapsedTime = DateTime.Now.AddTicks(-torrent.StartTime.Ticks);
            mainForm.DetailTabElapsedTime.Text = elapsedTime.ToLongTimeString();// elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;

            double estimatedTime = 0;
            if (torrent.Monitor.DownloadSpeed > 0)
                estimatedTime = 3600.0 / ((torrent.Torrent.Size - torrent.Monitor.DataBytesDownloaded) / torrent.Monitor.DownloadSpeed);

            mainForm.DetailTabEstimatedTime.Text = new TimeSpan(0, 0, (int)estimatedTime).ToString();
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

		#region piece tab

		public void UpdatePiecesTab()
        {
            mainForm.PiecesListView.Items.Clear();

            TorrentManager selectedTorrent = GetSelectedTorrent();
            if (selectedTorrent == null)
                return;
			try
			{
				mainForm.PiecesListView.BeginUpdate();

				lock (currentRequests)
				{
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

		#region files tab

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

				//recurse on all file
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

	}
}
