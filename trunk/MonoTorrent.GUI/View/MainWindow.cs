using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;
using MonoTorrent.Common;
using MonoTorrent.GUI.Settings;
using MonoTorrent.GUI.Controller;
using MonoTorrent.GUI.Properties;
using System.Reflection;
using Utilities;
using System.IO;
using MonoTorrent.GUI.View.Control;

namespace MonoTorrent.GUI.View
{
    public partial class MainWindow : Form
    {
        private MainController mainController;
        private IDictionary<ListViewItem, TorrentManager> itemToTorrent;

        public MainWindow(MainController mainController)
        {
            InitializeComponent();
            this.mainController = mainController;

            this.mainController.PeerConnected += delegate(object sender, PeerIdEventArgs e) {
                if (InvokeRequired)
                    Invoke(new MainController.PeerHandler(PeerConnected), e.PeerId);
                else
                    PeerConnected(e.PeerId);
            };

            this.mainController.PeerDisconnected += delegate(object sender, PeerIdEventArgs e) {
                if (InvokeRequired)
                    Invoke(new MainController.PeerHandler(PeerDisconnected), e.PeerId);
                else
                    PeerDisconnected(e.PeerId);
            };
            this.mainController.UpdatePeers += delegate {
                if (InvokeRequired)
                    Invoke(new MainController.UpdateStatsHandler(UpdatePeers));
                else
                    UpdatePeers();
            };
            this.mainController.UpdateStats += delegate(object sender, TorrentManagerEventArgs e) {
                if (InvokeRequired)
                    Invoke(new MainController.UpdateStateHandler(UpdateState), e.Manager);
                else
                    UpdateState(e.Manager);
            };

            this.mainController.UpdateAllStats += delegate
            {
                // Only update the screen every 8 ticks
                if (!IsDisposing && ((counter++ % 8) == 0))
                {
                    if (InvokeRequired)
                        Invoke(new MainController.UpdateStatsHandler(UpdateAllStats));
                    else
                        UpdateAllStats();
                }

                if (counter % 80 == 0)
                    MonoTorrent.GUI.Helper.MemoryUtility.OptimizeMemoryUsage();
            };
            LoadViewSettings();
            itemToPeers = new Dictionary<ListViewItem, PeerId>();
            itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
        }
        private long counter = 0;

        private void UpdatePeers()
        {
            try
            {
                this.PeersView.BeginUpdate();
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
                            entry.Key.SubItems["IsSeeder"].Text = Utilities.FormatBool(entry.Value.IsSeeder);
                            entry.Key.SubItems["IsChoking"].Text = Utilities.FormatBool(entry.Value.IsChoking);
                            entry.Key.SubItems["AmInterested"].Text = Utilities.FormatBool(entry.Value.AmInterested);
                            entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.IsRequestingPiecesCount.ToString();
                            entry.Key.SubItems["PiecesSent"].Text = entry.Value.PiecesSent.ToString();
                            entry.Key.SubItems["ClientApp"].Text = entry.Value.ClientSoftware.Client.ToString();
                            entry.Key.SubItems["Download"].Text = Utilities.FormatSizeValue(entry.Value.Monitor.DataBytesDownloaded);
                            entry.Key.SubItems["Upload"].Text = Utilities.FormatSizeValue(entry.Value.Monitor.DataBytesUploaded);
                            entry.Key.SubItems["DownloadSpeed"].Text = Utilities.FormatSpeedValue(entry.Value.Monitor.DownloadSpeed);
                            entry.Key.SubItems["UploadSpeed"].Text = Utilities.FormatSpeedValue(entry.Value.Monitor.UploadSpeed);
                            entry.Key.SubItems["IsRequestingPiecesCount"].Text = entry.Value.AmRequestingPiecesCount.ToString();
                            entry.Key.SubItems["PiecesSent"].Text = entry.Value.PiecesSent.ToString();
                        }
                    }
            }
            finally
            {
                PeersView.EndUpdate();
            }
        }

        private void ClearDetailTab()
        {
            DetailTabClients.Text = "...";
            DetailTabDownload.Text = "...";
            DetailTabDownloadSpeed.Text = "...";
            DetailTabElapsedTime.Text = "...";
            DetailTabEstimatedTime.Text = "...";
            DetailTabPeers.Text = "...";
            DetailTabPieces.Text = "...";
            DetailTabUpload.Text = "...";
            DetailTabUploadSpeed.Text = "...";
        }
        void PeerDisconnected(PeerId id)
        {
            lock (itemToPeers)
                foreach (KeyValuePair<ListViewItem, PeerId> entry in itemToPeers)
                {
                    if (entry.Value != id)
                        continue;

                    itemToPeers.Remove(entry.Key);
                    PeersView.Items.Remove(entry.Key);
                    return;
                }
        }

        void PeerConnected(PeerId id)
        {
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
            subitem.Text = id.Location;


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "Download";
            item.SubItems.Add(subitem);
            subitem.Text = Utilities.FormatSizeValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "Upload";
            item.SubItems.Add(subitem);
            subitem.Text = Utilities.FormatSizeValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "DownloadSpeed";
            item.SubItems.Add(subitem);
            subitem.Text = Utilities.FormatSpeedValue(0);


            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "UploadSpeed";
            item.SubItems.Add(subitem);
            subitem.Text = Utilities.FormatSpeedValue(0);


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
            subitem.Text = Utilities.FormatBool(id.IsChoking);

            subitem = new ListViewItem.ListViewSubItem();
            subitem.Name = "AmInterested";
            item.SubItems.Add(subitem);
            subitem.Text = Utilities.FormatBool(id.AmInterested);

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
            subitem.Text = Utilities.FormatBool(id.SupportsFastPeer);

            PeersView.Items.Add(item);
            lock (itemToPeers)
                itemToPeers.Add(item, id);
        }

        /// <summary>
        /// Update the TorrentsView grid
        /// </summary>
        private void UpdateTorrentsView()
        {
            try
            {
                TorrentsView.BeginUpdate();
                foreach (KeyValuePair<ListViewItem, TorrentManager> keypair in this.itemToTorrent)
                    UpdateState(keypair.Value);
            }
            finally
            {
                TorrentsView.EndUpdate();
            }
        }

        #region Helper


        /// <summary>
        /// Get all row selected in list view
        /// </summary>
        /// <returns>TorrentManager IList</returns>
        public IList<TorrentManager> GetSelectedTorrents()
        {
            IList<TorrentManager> result = new List<TorrentManager>();
            foreach (ListViewItem item in TorrentsView.SelectedItems)
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

        /// <summary>
        /// Remove torrent
        /// </summary>
        public void Del()
        {
            try
            {
                if (MessageBox.Show("Are you sure ?", "Delete Torrent", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                foreach (TorrentManager torrent in GetSelectedTorrents())
                {
                    if (torrent.State != TorrentState.Stopped)
                        torrent.Stop();

                    mainController.Remove(torrent);
                    GetItemFromTorrent(torrent).Remove();

                    File.Delete(torrent.Torrent.TorrentPath);
                    foreach (TorrentFile file in torrent.Torrent.Files)
                    {
                        File.Delete(Path.Combine(torrent.SavePath, file.Path));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Del :" + e.ToString());
            }
        }
        #endregion

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
            item.SubItems["colDownSpeed"].Text = Utilities.FormatSpeedValue(torrent.Monitor.DownloadSpeed);
            item.SubItems["colUpSpeed"].Text = Utilities.FormatSpeedValue(torrent.Monitor.UploadSpeed);
            //I put only download of file and not the download of protocole
            item.SubItems["colDownloaded"].Text = Utilities.FormatSizeValue(torrent.Monitor.DataBytesDownloaded);
            // here i put all upload because we want to know whais bandwidth
            item.SubItems["colUploaded"].Text = Utilities.FormatSizeValue(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded);
            //ratio is for all upload vs all download
            if (torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded != 0)
                item.SubItems["colRatio"].Text = string.Format("{0:0.00}", (float)(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded) / (torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded));

            if (torrent.Monitor.DownloadSpeed > 0)
            {
                double secs = (torrent.Torrent.Size - (torrent.Torrent.Size * (torrent.Progress / 100))) / torrent.Monitor.DownloadSpeed;
                DateTime dt = new DateTime().AddSeconds(secs);
                item.SubItems["colRemaining"].Text = dt.ToString("hh:mm:ss");
            }
            else
                item.SubItems["colRemaining"].Text = string.Empty;
        }

        #region Piece tab

        public void UpdatePiecesTab()
        {
            TorrentManager selectedTorrent = GetSelectedTorrent();
            if (selectedTorrent == null)
                return;
            try
            {
                PiecesListView.BeginUpdate();
                PiecesListView.Items.Clear();
                List<BlockEventArgs> currentRequests = mainController.GetCurrentRequests();
                // First sort them according to the piece index
                currentRequests.Sort(new Comparison<BlockEventArgs>(delegate(BlockEventArgs left, BlockEventArgs right)
                {
                    return left.Piece.Index.CompareTo(right.Piece.Index);
                }));

                // Render them onto the listview
                for (int i = 0; i < currentRequests.Count; i++)
                {
                    if (currentRequests[i].ID.TorrentManager != selectedTorrent)
                        continue;

                    ListViewItem item = new ListViewItem(currentRequests[i].Piece.Index.ToString());
                    item.SubItems.Add(Utilities.FormatSizeValue(currentRequests[i].Block.RequestLength / 1024.0));
                    item.SubItems.Add(currentRequests[i].Piece.BlockCount.ToString());
                    item.SubItems.Add(new ImageListView.ImageListViewSubItem(new BlockProgressBar(currentRequests[i])));
                    PiecesListView.Items.Add(item);
                }
            }
            finally
            {
                PiecesListView.EndUpdate();
            }
        }

        #endregion
        #region General tab

        public void UpdateGeneralTab()
        {
            IList<TorrentManager> torrents = GetSelectedTorrents();
            if (torrents.Count == 0)
                return;
            TorrentManager torrent = torrents[0];

            GenTabDateLabel.Text = torrent.Torrent.CreationDate.ToShortDateString();
            GenTabFolderLabel.Text = Path.Combine(torrent.SavePath, torrent.Torrent.Name);
            string hash = string.Empty;
            for (int i = 0; i < torrent.Torrent.InfoHash.Length; i++)
                hash += torrent.Torrent.InfoHash[i].ToString("X");

            GenTabHashLabel.Text = hash;
            GenTabInfosLabel.Text = torrent.Torrent.Comment;
            GenTabPiecesxSizeLabel.Text = torrent.Torrent.Pieces.Count.ToString() + " X " + Utilities.FormatSizeValue(torrent.Torrent.PieceLength);
            GenTabSizeLabel.Text = Utilities.FormatSizeValue(torrent.Torrent.Size);
            //GenTabURLLabel.Text = torrent.Torrent.Source;
            GenTabURLLabel.Text = torrent.TrackerManager.CurrentTracker.ToString();
            SmallUpdateGeneralTab(torrent);
        }

        public void SmallUpdateGeneralTab(TorrentManager torrent)
        {
            GenTabStatusLabel.Text = torrent.TrackerManager.CurrentTracker.State.ToString();
            GenTabUpdateLabel.Text = torrent.TrackerManager.LastUpdated.ToShortTimeString();
            TrackerMessage.Text = string.Empty;
            TrackerMessage.Text = torrent.TrackerManager.CurrentTracker.FailureMessage;
            TrackerMessage.AppendText(Environment.NewLine);
            TrackerMessage.AppendText(torrent.TrackerManager.CurrentTracker.WarningMessage);
        }

        private void ClearGeneralTab()
        {
            GenTabDateLabel.Text = "...";
            GenTabFolderLabel.Text = "...";
            GenTabHashLabel.Text = "...";
            GenTabInfosLabel.Text = "...";
            GenTabPiecesxSizeLabel.Text = "...";
            GenTabSizeLabel.Text = "...";
            GenTabURLLabel.Text = "...";
            GenTabStatusLabel.Text = "...";
            GenTabUpdateLabel.Text = "...";
            TrackerMessage.Text = "...";
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
            DetailTabClients.Text = string.Empty;
            DetailTabDownload.Text = Utilities.FormatSizeValue(torrent.Monitor.DataBytesDownloaded + torrent.Monitor.ProtocolBytesDownloaded);
            DetailTabDownloadSpeed.Text = Utilities.FormatSpeedValue(torrent.Monitor.DownloadSpeed);

            DateTime elapsedTime;
            if (torrent.State == TorrentState.Stopped || torrent.State == TorrentState.Paused)
                elapsedTime = new DateTime(0);
            else
                elapsedTime = DateTime.Now.AddTicks(-torrent.StartTime.Ticks);
            DetailTabElapsedTime.Text = elapsedTime.ToLongTimeString();// elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;

            if (torrent.Monitor.DownloadSpeed > 0)
            {
                double secs = (torrent.Torrent.Size - (torrent.Torrent.Size * (torrent.Progress / 100))) / torrent.Monitor.DownloadSpeed;
                DateTime dt = new DateTime().AddSeconds(secs);
                DetailTabEstimatedTime.Text = dt.ToString("hh:mm:ss");
            }
            else
                DetailTabEstimatedTime.Text = string.Empty;

            //double estimatedTime = 0;
            //if (torrent.Monitor.DownloadSpeed > 0)
            //    estimatedTime = 3600.0 / ((torrent.Torrent.Size - torrent.Monitor.DataBytesDownloaded) / torrent.Monitor.DownloadSpeed);
            //DetailTabEstimatedTime.Text = new TimeSpan(0, 0, (int)estimatedTime).ToString();

            DetailTabPeers.Text = torrent.OpenConnections.ToString();
            DetailTabPieces.Text = torrent.Torrent.Pieces.Count.ToString();
            DetailTabUpload.Text = Utilities.FormatSizeValue(torrent.Monitor.DataBytesUploaded + torrent.Monitor.ProtocolBytesUploaded);
            DetailTabUploadSpeed.Text = Utilities.FormatSpeedValue(torrent.Monitor.UploadSpeed);
        }



        #endregion

        #region Files tab

        internal void UpdateFilesTab()
        {
            filesTreeView.Nodes.Clear();
            IList<TorrentManager> torrents = GetSelectedTorrents();
            if (torrents.Count == 0)
            {
                filesTreeView.TopNode = new TreeNode("");
                return;
            }
            TorrentManager torrent = torrents[0];

            try
            {
                filesTreeView.BeginUpdate();

                TreeNode newNode = null;

                filesTreeView.TopNode = new TreeNode(torrent.Torrent.Name);

                //recurse on all file to create folder
                foreach (TorrentFile file in torrent.Torrent.Files)
                {
                    string path = Path.GetDirectoryName(file.Path);

                    TreeNodeCollection nodes = filesTreeView.Nodes;

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

                    TreeNodeCollection nodes = filesTreeView.Nodes;

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
                filesTreeView.EndUpdate();
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
            StatsGraph.AddDownloadValue(mainController.TotalDownloadSpeed);
            StatsGraph.AddUploadValue(mainController.TotalUploadSpeed);
            StatsGraph.Invalidate();
        }

        #endregion

        /// <summary>
        /// Save view settings
        /// </summary>
        public void UpdateViewSettings()
        {
            GuiViewSettings guisettings = new GuiViewSettings();

            // NEW: when closing from system tray you don't want to save this
            if (WindowState != FormWindowState.Minimized)
            {
                guisettings.FormWidth = Width;
                guisettings.FormHeight = Height;
                guisettings.SplitterDistance = Splitter.SplitterDistance;
            }

            guisettings.VScrollValue = TabGeneral.VerticalScroll.Value;
            guisettings.HScrollValue = TabGeneral.HorizontalScroll.Value;
            guisettings.ShowDetail = ShowDetailMenuItem.Checked;
            guisettings.ShowStatusbar = ShowStatusbarMenuItem.Checked;
            guisettings.ShowToolbar = ShowToolbarMenuItem.Checked;
            foreach (ColumnHeader col in TorrentsView.Columns)
            {
                guisettings.TorrentViewColumnWidth.Add(col.Width);
            }
            foreach (ColumnHeader col in PeersView.Columns)
            {
                guisettings.PeerViewColumnWidth.Add(col.Width);
            }
            foreach (ColumnHeader col in PiecesListView.Columns)
            {
                guisettings.PieceViewColumnWidth.Add(col.Width);
            }
            mainController.SettingsBase.SaveSettings<GuiViewSettings>("Graphical Settings", guisettings);
        }

        #region MiniWindow

        public void switchToMiniWindow(bool flag)
        {
            if (mainController.MiniWindow == null)
            {
                mainController.MiniWindow = new MiniWindow(this, mainController);
            }
            if (flag)
            {
                Hide();
                LoadMiniWindow();
                mainController.MiniWindow.Show();
            }
            else
            {
                mainController.MiniWindow.Hide();
                Show();
            }
        }

        internal void LoadMiniWindow()
        {
            mainController.MiniWindow.ListView.Items.Clear();

            foreach (TorrentManager torrent in itemToTorrent.Values)
            {
                ListViewItem item = new ListViewItem(torrent.Torrent.Name);

                ListViewItem.ListViewSubItem subitem = item.SubItems[0];
                subitem.Name = "colName";

                ImageListView.ImageListViewSubItem sitem = new ImageListView.ImageListViewSubItem(new TorrentProgressBar(torrent));
                sitem.Name = "colProgress";
                item.SubItems.Add(sitem);

                mainController.MiniWindow.ListView.Items.Add(item);
            }
        }

        private void UpdateMiniWindow()
        {
            mainController.MiniWindow.ListView.Invalidate();
        }

        #endregion
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
                if (mainController.MiniWindow != null && mainController.MiniWindow.Visible)
                    UpdateMiniWindow();

                UpdateStatsGraph();
                UpdateNotifyIcon();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Bloody hell! It crashed:");
            }
        }

        private Dictionary<ListViewItem, PeerId> itemToPeers;
		#region Properties

		#region gen tab

		public Label GenTabURLLabel
		{
			get { return URLLabel; }
		}

		public Label GenTabStatusLabel
		{
			get { return StatusLabel; }
		}

		public Label GenTabUpdateLabel
		{
			get { return UpdateLabel; }
		}

		public Label GenTabFolderLabel
		{
			get { return FolderLabel; }
		}

		public Label GenTabSizeLabel
		{
			get { return SizeLabel; }
		}

		public Label GenTabDateLabel
		{
			get { return DateLabel; }
		}

		public Label GenTabInfosLabel
		{
			get { return InfosLabel; }
		}

		public Label GenTabPiecesxSizeLabel
		{
			get { return PiecesxSizeLabel; }
		}
		
		public Label GenTabHashLabel
		{
			get { return HashLabel; }
		}

		#endregion

        /// <summary>
        /// treeview of files in torrent
        /// </summary>
        public TreeView filesTreeView
        {
            get { return FilesTreeView; }
        }
		/// <summary>
		/// tab pieces list ( not used actually)
		/// </summary>
        public Control.ImageListView PiecesListView
		{
			get { return this.piecesListView; }
		}
		
		/// <summary>
		/// main view
		/// </summary>
        public Control.ImageListView TorrentsView
		{
			get { return this.torrentsView; }
		}

		/// <summary>
		/// tab peers list
		/// </summary>
		public ListView PeersView
		{
			get { return this.PeerListView; }
		}

        public TextBox TrackerMessage
        {
            get { return TrackerMessageTextBox; }
        }

		public SplitContainer Splitter
		{
			get { return splitContainer1; }
		}

		public TabPage TabGeneral
		{
			get { return tabGeneral; }
		}

        public MenuStrip MainMenuBar
        {
            get { return menuBar; }
        }

        public ToolStrip MainToolStrip
        {
            get { return MaintoolStrip; }
        }

        public ToolStripMenuItem ShowStatusbarMenuItem
		{
			get { return showStatusbarToolStripMenuItem; }
		}

		public ToolStripMenuItem ShowToolbarMenuItem
		{
			get { return showToolbarToolStripMenuItem; }
		}

		public ToolStripMenuItem ShowDetailMenuItem
		{
			get { return showDetailToolStripMenuItem; }
		}

        public NotifyIcon NotifyIconSystray
        {
            get { return notifyIcon; }
        }

		#region Details

		public Label DetailTabElapsedTime
		{
			get { return elapsedTimeLabel; }
		}

		public Label DetailTabDownload
		{
			get { return downloadLabel; }
		}

		public Label DetailTabUpload
		{
			get { return uploadLabel; }
		}

		public Label DetailTabPeers
		{
			get { return peersLabel; }
		}

		public Label DetailTabEstimatedTime
		{
			get { return estimatedTimeLabel; }
		}

		public Label DetailTabDownloadSpeed
		{
			get { return downloadSpeedLabel; }
		}

		public Label DetailTabUploadSpeed
		{
			get { return uploadSpeedLabel; }
		}

		public Label DetailTabClients
		{
			get { return clientsLabel; }
		}

		public Label DetailTabPieces
		{
			get { return piecesLabel; }
		}
		#endregion

        public Control.GraphicControl StatsGraph
        {
            get { return statsGraph; }
        }
        public bool IsDisposing
        {
            get { return isDisposing || IsDisposed; }
        }
        private bool isDisposing = false;

		#endregion

		#region Form load/unload

		private void MainWindow_Load(object sender, EventArgs e)
        {           
			this.FilesTreeView.AfterExpand += new TreeViewEventHandler(FilesTreeViewExpand);
			this.FilesTreeView.AfterCollapse += new TreeViewEventHandler(FilesTreeViewCollapse);
			this.FilesTreeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(FilesTreeViewNodeDoubleClick);

            //Load images for treeview
            FilesTreeView.ImageList = new ImageList();
            FilesTreeView.ImageList.Images.Add("folder", ResourceHandler.GetImage("folder"));
            FilesTreeView.ImageList.Images.Add("openFolder", ResourceHandler.GetImage("folder_open"));
            FilesTreeView.ImageList.Images.Add("file", ResourceHandler.GetImage("file"));

            //load state images for treeview
            FilesTreeView.StateImageList = new ImageList();
            FilesTreeView.StateImageList.Images.Add("immediate", ResourceHandler.GetImage("immediate"));
            FilesTreeView.StateImageList.Images.Add("highest", ResourceHandler.GetImage("highest"));
            FilesTreeView.StateImageList.Images.Add("high", ResourceHandler.GetImage("high"));
            FilesTreeView.StateImageList.Images.Add("normal", ResourceHandler.GetImage("normal"));
            FilesTreeView.StateImageList.Images.Add("low", ResourceHandler.GetImage("low"));
            FilesTreeView.StateImageList.Images.Add("lowest", ResourceHandler.GetImage("lowest"));
            FilesTreeView.StateImageList.Images.Add("doNotDownload", ResourceHandler.GetImage("do_not_download"));

		}

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
			//close client
			// save gui
			// unsubscribe to event
            isDisposing = true;
			mainController.Dispose();
            UpdateViewSettings();
		}

		#endregion

		#region Treeview

		void FilesTreeViewCollapse(object sender, TreeViewEventArgs e)
		{
			e.Node.ImageKey = "folder";
            e.Node.SelectedImageKey = "folder";
		}

		void FilesTreeViewExpand(object sender, TreeViewEventArgs e)
		{
            e.Node.ImageKey = "openFolder";
            e.Node.SelectedImageKey = "openFolder";
		}

		void FilesTreeViewNodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			ChangeFilePriority(e.Node);
		}

		#endregion

        #region Drag Drop

        private void TorrentsView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect != DragDropEffects.Copy)
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string s in files)
            {
                if (s.EndsWith(".torrent", StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        TorrentManager manager = mainController.Add(s);
                        if (manager == null)
                            return;

                        CreateListViewItem(manager);
                    }
                    catch (TorrentException ex)
                    {
                        MessageBox.Show(this, ex.Message, "Invalid Torrent", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Please report this exception:" + Environment.NewLine + Environment.NewLine + ex.ToString(),
                                        "Unhandled Exception", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void CreateListViewItem(TorrentManager manager)
        {
            // The user may cancel adding a new torrent, then we get null.
            if (manager == null)
                return;

            ListViewItem item = new ListViewItem(Path.GetFileName(manager.Torrent.TorrentPath));
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

            item.SubItems["colSize"].Text = Utilities.FormatSizeValue(manager.Torrent.Size / 1024);
            item.SubItems["colName"].Text = manager.Torrent.Name;

            ImageListView.ImageListViewSubItem sitem = new ImageListView.ImageListViewSubItem(new TorrentProgressBar(manager));
            sitem.Name = "colProgress";
            item.SubItems.Insert(2, sitem);

            TorrentsView.Items.Add(item);
            itemToTorrent.Add(item, manager);
        }


        private void TorrentsView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        #endregion
        
        #region Buttons

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            CreateListViewItem(mainController.Add(false));
        }

        private void StartToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Start(GetSelectedTorrents());
        }

        private void PauseToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Pause(GetSelectedTorrents());
        }

        private void StopToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Stop(GetSelectedTorrents());
        }

        private void DelToolStripButton_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void OptionToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Option(this);
        }

        private void CreateToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Create();
        }

        private void DownStripButton_Click(object sender, EventArgs e)
        {
            mainController.Down();
        }

        private void UpStripButton_Click(object sender, EventArgs e)
        {
            mainController.Up();
        }

        #endregion

        #region Menu items

        private void addATorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateListViewItem(mainController.Add(false));
        }

        private void createATorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Create();
        }

        private void deleteATorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Option(this);
        }

        private void showToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowToolBar(!showToolbarToolStripMenuItem.Checked);
        }

        private void showDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetail(!showDetailToolStripMenuItem.Checked);
        }

        private void showStatusbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStatusBar(!showStatusbarToolStripMenuItem.Checked);
        }

        private void startTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Start(GetSelectedTorrents());
        }

        private void stopTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Stop(GetSelectedTorrents());
        }

        private void pauseTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Pause(GetSelectedTorrents());
        }

        private void upTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Up();
        }

        private void downTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Down();
        }

        private void RssStripButton_Click(object sender, EventArgs e)
        {
            mainController.Rss();
        }

        private void AddUrlToolStripButton_Click(object sender, EventArgs e)
        {
            CreateListViewItem(mainController.Add(true));
        }


        /// <summary>
        /// NEW:
        /// Update the notify icon:
        ///     Icon with progress indicator
        ///     and information text
        /// </summary>
        public void UpdateNotifyIcon()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                int iconInt = 16;
                double dl = mainController.TotalDownloadSpeed;
                double ul = mainController.TotalUploadSpeed;
                if (dl == 0 && ul == 0)
                {
                    // No acivity: show grey mono icon
                    NotifyIconSystray.Icon = ResourceHandler.GetIcon("mono_grey", iconInt, iconInt);
                }
                else
                {
                    // Build a system tray icon with downloadspeed indication
                    if (mainController.MaxDownload == 0)
                    {
                        mainController.MaxDownload = mainController.Engine.Settings.GlobalMaxDownloadSpeed;
                        // With a minimimum of 16 Kb (1 Kb per pixel)
                        mainController.MaxDownload = 1024 * 16;
                    }
                    if (mainController.MaxDownload < dl)
                        // If no MaxDownloadSpeed is given, create your own temporarily
                        mainController.MaxDownload = (int)(dl * 1.25);

                    // Calculate the dimensions and position of the progress indicator
                    int h = (int)(dl / (mainController.MaxDownload / iconInt));
                    int w = 3;
                    int x = iconInt - w;
                    int y = iconInt - h;

                    // Create a new icon from the mono icon and the progress indicator
                    Bitmap bmp = new Bitmap(iconInt, iconInt);
                    Graphics grs = Graphics.FromImage(bmp);
                    grs.DrawIcon(mainController.Mono, 0, 0);
                    grs.FillRectangle(Brushes.Green, x, y, w, h);
                    Icon sysIcon = Icon.FromHandle(bmp.GetHicon());

                    // Show the new icon in the system tray
                    NotifyIconSystray.Icon = sysIcon;
                }

                // Show info text when hovering over system tray icon
                StringBuilder sb = new StringBuilder();
                sb.Append(Application.ProductName);
                sb.Append(" ");
                sb.AppendLine(Application.ProductVersion);
                sb.Append("Down ");
                sb.Append(Utilities.FormatSpeedValue(dl));
                sb.Append(" | Up: ");
                sb.Append(Utilities.FormatSpeedValue(ul));
                NotifyIconSystray.Text = sb.ToString();
            }
        }
        
        private void changeTorrentSavePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change save path
            string oldPath = string.Empty;
            string newPath = string.Empty;
            bool downloading = false;
            TorrentManager tm = GetSelectedTorrent();

            if (tm != null)
            {
                // Ask for new folder
                folderBrowserDialog.SelectedPath = tm.SavePath;
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.Description = "Select new save path";
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    newPath = Path.Combine(folderBrowserDialog.SelectedPath, tm.Torrent.Name);
                    // Stop torrent
                    // TODO: do something about hashing file
                    if (tm.State == TorrentState.Downloading)
                    {
                        downloading = true;
                        mainController.Stop(GetSelectedTorrents());
                    }

                    // Move existing files to new path
                    oldPath = Path.Combine(tm.SavePath, tm.Torrent.Name);
                    if (Directory.Exists(oldPath))
                        Directory.Move(oldPath, newPath);
                    else if (File.Exists(oldPath))
                        File.Move(oldPath, newPath);

                    // Save new path
                    tm.FileManager.MoveFiles(folderBrowserDialog.SelectedPath, true);
                    // Refresh general tab
                    UpdateGeneralTab();

                    // Start torrent
                    if (downloading)
                        mainController.Start(GetSelectedTorrents());
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.About();
        }

        private void startTorrentContextMenuItem_Click(object sender, EventArgs e)
        {
            startTorrentToolStripMenuItem_Click(sender, e);
        }

        private void stopTorrentContextMenuItem_Click(object sender, EventArgs e)
        {
            stopTorrentToolStripMenuItem_Click(sender, e);
        }

        private void pauseTorrentContextMenuItem_Click(object sender, EventArgs e)
        {
            pauseTorrentToolStripMenuItem_Click(sender, e);
        }

        private void upTorrentContextMenuItem_Click(object sender, EventArgs e)
        {
            upTorrentToolStripMenuItem_Click(sender, e);
        }

        private void downTorrentContextMenuItem_Click(object sender, EventArgs e)
        {
            downTorrentToolStripMenuItem_Click(sender, e);
        }

        private void changeTorrentSavePathContextMenuItem_Click(object sender, EventArgs e)
        {
            changeTorrentSavePathToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteATorrentToolStripMenuItem_Click(sender, e);
        }

        private void torrentsView_MouseUp(object sender, MouseEventArgs e)
        {
            // Check if an item is selected before showing the menustrip
            if (e.Button == MouseButtons.Right)
            {
                bool showMnu = false;
                ListViewHitTestInfo hti = torrentsView.HitTest(e.X, e.Y);
                foreach (ListViewItem item in torrentsView.SelectedItems)
                {
                    if (hti.Item == item)
                    {
                        showMnu = true;
                        break;
                    }
                }
                if (showMnu)
                    // Show contextmenu
                    torrentContextMenuStrip.Show(torrentsView, new Point(e.X, e.Y));
            }
        }

        #endregion

		#region Show/Hide

		/// <summary>
        /// Show or hide toolbar
        /// </summary>
        /// <param name="check">if true show else Hide</param>
		internal void ShowToolBar(bool check)
        {
            if (check)
            {
                //to avoid bug in order of menu
                this.Controls.Add(splitContainer1);
                this.Controls.Add(MaintoolStrip);
                this.Controls.Add(menuBar);
                showToolbarToolStripMenuItem.Checked = true;
            }
            else
            {
                this.Controls.Remove(MaintoolStrip);
                //to have splitcontainer which take empty place
                splitContainer1.Dock = DockStyle.Fill;
                showToolbarToolStripMenuItem.Checked = false;
            }

        }

        /// <summary>
        /// Show Hide Detail
        /// </summary>
        /// <param name="check">if true show else Hide</param>
		internal void ShowDetail(bool check)
        {
            if (check)
            {
                splitContainer1.Panel2Collapsed = false;
                showDetailToolStripMenuItem.Checked = true;

            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                showDetailToolStripMenuItem.Checked = false;
            }

        }

        /// <summary>
        /// Show Hide status bar
        /// </summary>
        /// <param name="check">if true show else Hide</param>
        internal void ShowStatusBar(bool check)
        {
            if (check)
            {
                this.Controls.Add(statusBar);
                showStatusbarToolStripMenuItem.Checked = true;
                
            }
            else
            {
                this.Controls.Remove(statusBar);
                showStatusbarToolStripMenuItem.Checked = false;
            }
		}

		#endregion

        #region Events

        private void torrentsView_SelectedIndexChanged(object sender, EventArgs e)
		{
            UpdateGeneralTab();
            UpdatePiecesTab();
            UpdateDetailTab();
            UpdateFilesTab();
		}

        private void miniWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchToMiniWindow(true);
        }

        private void ItemMouseHover(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            statusItem.Text = button.Text;
        }

        private void ClearStatusBar(object sender, EventArgs e)
        {
            statusItem.Text = string.Empty;
        }

        private void FolderLabel_Click(object sender, EventArgs e)
        {
            if (FolderLabel.Text.IndexOf(@":\") > 0)
                System.Diagnostics.Process.Start(FolderLabel.Text);
        }

        private void FolderLabel_MouseHover(object sender, EventArgs e)
        {
            if (FolderLabel.Text.IndexOf(@":\") > 0)
                FolderLabel.Cursor = Cursors.Hand;
            else
                FolderLabel.Cursor = Cursors.Default;
        }

        private void InfosLabel_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(@"\w+\.[\w]{2,4}\S*");
            if (regExp.IsMatch(InfosLabel.Text))
            {
                string url = "http://" + regExp.Match(InfosLabel.Text).ToString();
                System.Diagnostics.Process.Start(url);
            }
        }

        private void InfosLabel_MouseHover(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex regExp = new System.Text.RegularExpressions.Regex(@"\w+\.[\w]{2,4}\S*");
            if (regExp.IsMatch(InfosLabel.Text))
                InfosLabel.Cursor = Cursors.Hand;
            else
                InfosLabel.Cursor = Cursors.Default;
        }

        // Used to minimize to the system tray
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                UpdateNotifyIcon();

                notifyIcon.Visible = true;
                this.Hide();
            }
        }

        // Used to restore from the system tray
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon_DoubleClick(sender, e);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quitToolStripMenuItem_Click(sender, e);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            // Execute startup arguments
            if (Global.Options)
                mainController.Option(this);
            if (Global.Mini)
            {
                switchToMiniWindow(true);
                mainController.Start(GetSelectedTorrents());
            }
        }

        #endregion

        #region Settings

        /// <summary>
        /// update general settings
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateGeneralSettings(GuiGeneralSettings settings)
        {
            mainController.SettingsBase.SaveSettings<GuiGeneralSettings>("General Settings", settings);
            EngineSettings savedSettings = settings.GetEngineSettings();
            mainController.Engine.Settings.CopyFrom(savedSettings);
        }

        /// <summary>
        /// Load saved view settings
        /// </summary>
        public void LoadViewSettings()
        {
            GuiViewSettings guisettings = mainController.SettingsBase.LoadSettings<GuiViewSettings>("Graphical Settings");
            Width = guisettings.FormWidth;
            Height = guisettings.FormHeight;
            Splitter.SplitterDistance = guisettings.SplitterDistance;
            TabGeneral.VerticalScroll.Value = guisettings.VScrollValue;
            TabGeneral.HorizontalScroll.Value = guisettings.HScrollValue;
            // show/Hide component of GUI
            ShowStatusBar(guisettings.ShowStatusbar);
            ShowToolBar(guisettings.ShowToolbar);
            ShowDetail(guisettings.ShowDetail);

            for (int i = 0; i < guisettings.TorrentViewColumnWidth.Count; i++)
            {
                TorrentsView.Columns[i].Width = guisettings.TorrentViewColumnWidth[i];
            }

            for (int i = 0; i < guisettings.PeerViewColumnWidth.Count; i++)
            {
                PeersView.Columns[i].Width = guisettings.PeerViewColumnWidth[i];
            }

            for (int i = 0; i < guisettings.PieceViewColumnWidth.Count; i++)
            {
                PiecesListView.Columns[i].Width = guisettings.PieceViewColumnWidth[i];
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
            MainToolStrip.Items["AddToolStripButton"].Image = AddTorrent;
            MainToolStrip.Items["AddUrlToolStripButton"].Image = AddTorrentFromUrl;
            MainToolStrip.Items["CreateToolStripButton"].Image = CreateTorrent;
            MainToolStrip.Items["DelToolStripButton"].Image = DeleteTorrent;
            MainToolStrip.Items["StartToolStripButton"].Image = StartTorrent;
            MainToolStrip.Items["PauseToolStripButton"].Image = PauseTorrent;
            MainToolStrip.Items["StopToolStripButton"].Image = StopTorrent;
            MainToolStrip.Items["UpStripButton"].Image = Up;
            MainToolStrip.Items["DownStripButton"].Image = Down;
            MainToolStrip.Items["RssStripButton"].Image = Rss;
            MainToolStrip.Items["OptionToolStripButton"].Image = Options;

            // End the menustrip
            ToolStripMenuItem tsmi = MainMenuStrip.Items["menuFile"] as ToolStripMenuItem;
            tsmi.DropDownItems["addATorrentToolStripMenuItem"].Image = AddTorrent;
            tsmi.DropDownItems["deleteATorrentToolStripMenuItem"].Image = DeleteTorrent;
            tsmi.DropDownItems["createATorrentToolStripMenuItem"].Image = CreateTorrent;

            tsmi = MainMenuStrip.Items["menuTorrent"] as ToolStripMenuItem;
            tsmi.DropDownItems["startTorrentToolStripMenuItem"].Image = StartTorrent;
            tsmi.DropDownItems["pauseTorrentToolStripMenuItem"].Image = PauseTorrent;
            tsmi.DropDownItems["stopTorrentToolStripMenuItem"].Image = StopTorrent;
            tsmi.DropDownItems["upTorrentToolStripMenuItem"].Image = Up;
            tsmi.DropDownItems["downTorrentToolStripMenuItem"].Image = Down;

            tsmi = MainMenuStrip.Items["menuView"] as ToolStripMenuItem;
            tsmi.DropDownItems["optionToolStripMenuItem"].Image = Options;
        }

        #endregion

    }
}
