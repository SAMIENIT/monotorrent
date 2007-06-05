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

namespace MonoTorrent.GUI.View
{
    public partial class MainWindow : Form
    {
        private MainController mainController;
        
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
		}

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
            mainController = new MainController(this);

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
			mainController.ChangeFilePriority(e.Node);
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
                        mainController.Add(s);
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
            mainController.Add();
        }

        private void StartToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Start();
        }

        private void PauseToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Pause();
        }

        private void StopToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Stop();
        }

        private void DelToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Del();
        }

        private void OptionToolStripButton_Click(object sender, EventArgs e)
        {
            mainController.Option();
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
            mainController.Add();
        }

        private void createATorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Create();
        }

        private void deleteATorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Del();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Option();
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
            mainController.Start();
        }

        private void stopTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Stop();
        }

        private void pauseTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Pause();
        }

        private void upTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Up();
        }

        private void downTorrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Down();
        }

        private void changeTorrentSavePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change save path
            string oldPath = string.Empty;
            string newPath = string.Empty;
            bool downloading = false;
            TorrentManager tm = mainController.GetSelectedTorrent();

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
                        mainController.Stop();
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
                    mainController.UpdateGeneralTab();

                    // Start torrent
                    if (downloading)
                        mainController.Start();
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
			mainController.UpdateGeneralTab();
			mainController.UpdatePiecesTab();
			mainController.UpdateDetailTab();
            mainController.UpdateFilesTab();
		}

        private void miniWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.switchToMiniWindow(true);
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

        // NEW: used to minimize to the system tray
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                mainController.UpdateNotifyIcon();

                notifyIcon.Visible = true;
                this.Hide();
            }
        }

        // NEW: used to restore from the system tray
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
            // NEW: Execute startup arguments
            if (Global.Options)
                mainController.Option();
            if (Global.Mini)
            {
                mainController.switchToMiniWindow(true);
                mainController.Start();
            }
        }

        #endregion
    }
}
