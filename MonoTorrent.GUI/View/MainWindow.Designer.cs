namespace MonoTorrent.GUI.View
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.addATorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteATorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createATorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTorrent = new System.Windows.Forms.ToolStripMenuItem();
            this.startTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.upTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.changeTorrentSavePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatusbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miniWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.MaintoolStrip = new System.Windows.Forms.ToolStrip();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddUrlToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CreateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PauseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.StopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.UpStripButton = new System.Windows.Forms.ToolStripButton();
            this.DownStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.RssStripButton = new System.Windows.Forms.ToolStripButton();
            this.OptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.niContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.torrentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startTorrentContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTorrentContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTorrentContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.upTorrentContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downTorrentContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.changeTorrentSavePathContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.torrentsView = new MonoTorrent.GUI.View.Control.ImageListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colProgressBar = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colSeeds = new System.Windows.Forms.ColumnHeader();
            this.colLeeches = new System.Windows.Forms.ColumnHeader();
            this.colDownSpeed = new System.Windows.Forms.ColumnHeader();
            this.colUpSpeed = new System.Windows.Forms.ColumnHeader();
            this.colDownloaded = new System.Windows.Forms.ColumnHeader();
            this.colUploaded = new System.Windows.Forms.ColumnHeader();
            this.colRatio = new System.Windows.Forms.ColumnHeader();
            this.colRemaining = new System.Windows.Forms.ColumnHeader();
            this.detailsView = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.generalPanel = new System.Windows.Forms.GroupBox();
            this.HashLabel = new System.Windows.Forms.Label();
            this.PiecesxSizeLabel = new System.Windows.Forms.Label();
            this.InfosLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackerPanel = new System.Windows.Forms.GroupBox();
            this.TrackerMessageTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.URLLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.clientsLabel = new System.Windows.Forms.Label();
            this.uploadSpeedLabel = new System.Windows.Forms.Label();
            this.downloadSpeedLabel = new System.Windows.Forms.Label();
            this.estimatedTimeLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.piecesLabel = new System.Windows.Forms.Label();
            this.peersLabel = new System.Windows.Forms.Label();
            this.uploadLabel = new System.Windows.Forms.Label();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPeers = new System.Windows.Forms.TabPage();
            this.PeerListView = new System.Windows.Forms.ListView();
            this.PeerId = new System.Windows.Forms.ColumnHeader();
            this.ClientApp = new System.Windows.Forms.ColumnHeader();
            this.LocationPeer = new System.Windows.Forms.ColumnHeader();
            this.Download = new System.Windows.Forms.ColumnHeader();
            this.Upload = new System.Windows.Forms.ColumnHeader();
            this.DownloadSpeed = new System.Windows.Forms.ColumnHeader();
            this.UploadSpeed = new System.Windows.Forms.ColumnHeader();
            this.IsSeeder = new System.Windows.Forms.ColumnHeader();
            this.Encryption = new System.Windows.Forms.ColumnHeader();
            this.IsChoking = new System.Windows.Forms.ColumnHeader();
            this.IsInterested = new System.Windows.Forms.ColumnHeader();
            this.IsRequestingPiecesCount = new System.Windows.Forms.ColumnHeader();
            this.PiecesSent = new System.Windows.Forms.ColumnHeader();
            this.SupportsFastPeer = new System.Windows.Forms.ColumnHeader();
            this.tabPieces = new System.Windows.Forms.TabPage();
            this.piecesListView = new MonoTorrent.GUI.View.Control.ImageListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.FilesTreeView = new System.Windows.Forms.TreeView();
            this.tabStatsGraph = new System.Windows.Forms.TabPage();
            this.statsGraph = new MonoTorrent.GUI.View.Control.GraphicControl();
            this.menuBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.MaintoolStrip.SuspendLayout();
            this.niContextMenuStrip.SuspendLayout();
            this.torrentContextMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.detailsView.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.generalPanel.SuspendLayout();
            this.trackerPanel.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabPeers.SuspendLayout();
            this.tabPieces.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tabStatsGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.Control;
            this.menuBar.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTorrent,
            this.menuView,
            this.menuAbout});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(0);
            this.menuBar.Size = new System.Drawing.Size(692, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addATorrentToolStripMenuItem,
            this.deleteATorrentToolStripMenuItem,
            this.createATorrentToolStripMenuItem,
            this.toolStripSeparator7,
            this.quitToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 24);
            this.menuFile.Text = "&File";
            // 
            // addATorrentToolStripMenuItem
            // 
            this.addATorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.list_add;
            this.addATorrentToolStripMenuItem.Name = "addATorrentToolStripMenuItem";
            this.addATorrentToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addATorrentToolStripMenuItem.Text = "&Add a torrent";
            this.addATorrentToolStripMenuItem.Click += new System.EventHandler(this.addATorrentToolStripMenuItem_Click);
            // 
            // deleteATorrentToolStripMenuItem
            // 
            this.deleteATorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.list_remove;
            this.deleteATorrentToolStripMenuItem.Name = "deleteATorrentToolStripMenuItem";
            this.deleteATorrentToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteATorrentToolStripMenuItem.Text = "&Delete a torrent";
            this.deleteATorrentToolStripMenuItem.Click += new System.EventHandler(this.deleteATorrentToolStripMenuItem_Click);
            // 
            // createATorrentToolStripMenuItem
            // 
            this.createATorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.document_new;
            this.createATorrentToolStripMenuItem.Name = "createATorrentToolStripMenuItem";
            this.createATorrentToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.createATorrentToolStripMenuItem.Text = "&Create a torrent";
            this.createATorrentToolStripMenuItem.Click += new System.EventHandler(this.createATorrentToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(161, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // menuTorrent
            // 
            this.menuTorrent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTorrentToolStripMenuItem,
            this.pauseTorrentToolStripMenuItem,
            this.stopTorrentToolStripMenuItem,
            this.toolStripMenuItem3,
            this.upTorrentToolStripMenuItem,
            this.downTorrentToolStripMenuItem,
            this.toolStripMenuItem4,
            this.changeTorrentSavePathToolStripMenuItem});
            this.menuTorrent.Name = "menuTorrent";
            this.menuTorrent.Size = new System.Drawing.Size(55, 24);
            this.menuTorrent.Text = "&Torrent";
            // 
            // startTorrentToolStripMenuItem
            // 
            this.startTorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_start;
            this.startTorrentToolStripMenuItem.Name = "startTorrentToolStripMenuItem";
            this.startTorrentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.startTorrentToolStripMenuItem.Text = "&Start";
            this.startTorrentToolStripMenuItem.Click += new System.EventHandler(this.startTorrentToolStripMenuItem_Click);
            // 
            // pauseTorrentToolStripMenuItem
            // 
            this.pauseTorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_pause;
            this.pauseTorrentToolStripMenuItem.Name = "pauseTorrentToolStripMenuItem";
            this.pauseTorrentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pauseTorrentToolStripMenuItem.Text = "&Pause";
            this.pauseTorrentToolStripMenuItem.Click += new System.EventHandler(this.pauseTorrentToolStripMenuItem_Click);
            // 
            // stopTorrentToolStripMenuItem
            // 
            this.stopTorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_stop;
            this.stopTorrentToolStripMenuItem.Name = "stopTorrentToolStripMenuItem";
            this.stopTorrentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.stopTorrentToolStripMenuItem.Text = "Stop";
            this.stopTorrentToolStripMenuItem.Click += new System.EventHandler(this.stopTorrentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(170, 6);
            // 
            // upTorrentToolStripMenuItem
            // 
            this.upTorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.go_up;
            this.upTorrentToolStripMenuItem.Name = "upTorrentToolStripMenuItem";
            this.upTorrentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.upTorrentToolStripMenuItem.Text = "Up";
            this.upTorrentToolStripMenuItem.Click += new System.EventHandler(this.upTorrentToolStripMenuItem_Click);
            // 
            // downTorrentToolStripMenuItem
            // 
            this.downTorrentToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.go_down;
            this.downTorrentToolStripMenuItem.Name = "downTorrentToolStripMenuItem";
            this.downTorrentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.downTorrentToolStripMenuItem.Text = "Down";
            this.downTorrentToolStripMenuItem.Click += new System.EventHandler(this.downTorrentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(170, 6);
            // 
            // changeTorrentSavePathToolStripMenuItem
            // 
            this.changeTorrentSavePathToolStripMenuItem.Name = "changeTorrentSavePathToolStripMenuItem";
            this.changeTorrentSavePathToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.changeTorrentSavePathToolStripMenuItem.Text = "Change save path";
            this.changeTorrentSavePathToolStripMenuItem.Click += new System.EventHandler(this.changeTorrentSavePathToolStripMenuItem_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.toolStripSeparator3,
            this.showToolbarToolStripMenuItem,
            this.showDetailToolStripMenuItem,
            this.showStatusbarToolStripMenuItem,
            this.toolStripSeparator4,
            this.miniWindowToolStripMenuItem});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(41, 24);
            this.menuView.Text = "&View";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.preferences_system;
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.optionToolStripMenuItem.Text = "&Options";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // showToolbarToolStripMenuItem
            // 
            this.showToolbarToolStripMenuItem.Checked = true;
            this.showToolbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolbarToolStripMenuItem.Name = "showToolbarToolStripMenuItem";
            this.showToolbarToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.showToolbarToolStripMenuItem.Text = "Show Toolbar";
            this.showToolbarToolStripMenuItem.Click += new System.EventHandler(this.showToolbarToolStripMenuItem_Click);
            // 
            // showDetailToolStripMenuItem
            // 
            this.showDetailToolStripMenuItem.Checked = true;
            this.showDetailToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDetailToolStripMenuItem.Name = "showDetailToolStripMenuItem";
            this.showDetailToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.showDetailToolStripMenuItem.Text = "Show Detail";
            this.showDetailToolStripMenuItem.Click += new System.EventHandler(this.showDetailToolStripMenuItem_Click);
            // 
            // showStatusbarToolStripMenuItem
            // 
            this.showStatusbarToolStripMenuItem.Checked = true;
            this.showStatusbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStatusbarToolStripMenuItem.Name = "showStatusbarToolStripMenuItem";
            this.showStatusbarToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.showStatusbarToolStripMenuItem.Text = "Show Statusbar";
            this.showStatusbarToolStripMenuItem.Click += new System.EventHandler(this.showStatusbarToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
            // 
            // miniWindowToolStripMenuItem
            // 
            this.miniWindowToolStripMenuItem.Name = "miniWindowToolStripMenuItem";
            this.miniWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.miniWindowToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.miniWindowToolStripMenuItem.Text = "&Mini Window";
            this.miniWindowToolStripMenuItem.Click += new System.EventHandler(this.miniWindowToolStripMenuItem_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(40, 24);
            this.menuAbout.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusItem});
            this.statusBar.Location = new System.Drawing.Point(0, 420);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(692, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip";
            // 
            // statusItem
            // 
            this.statusItem.Name = "statusItem";
            this.statusItem.Size = new System.Drawing.Size(0, 17);
            // 
            // MaintoolStrip
            // 
            this.MaintoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripButton,
            this.AddUrlToolStripButton,
            this.CreateToolStripButton,
            this.toolStripSeparator1,
            this.DelToolStripButton,
            this.toolStripSeparator2,
            this.StartToolStripButton,
            this.PauseToolStripButton,
            this.StopToolStripButton,
            this.toolStripSeparator5,
            this.UpStripButton,
            this.DownStripButton,
            this.toolStripSeparator6,
            this.RssStripButton,
            this.OptionToolStripButton});
            this.MaintoolStrip.Location = new System.Drawing.Point(0, 24);
            this.MaintoolStrip.Name = "MaintoolStrip";
            this.MaintoolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MaintoolStrip.Size = new System.Drawing.Size(692, 39);
            this.MaintoolStrip.Stretch = true;
            this.MaintoolStrip.TabIndex = 2;
            this.MaintoolStrip.Text = "toolStrip1";
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.list_add;
            this.AddToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.AddToolStripButton.Text = "Add";
            this.AddToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.AddToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // AddUrlToolStripButton
            // 
            this.AddUrlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddUrlToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.list_add_url;
            this.AddUrlToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddUrlToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.AddUrlToolStripButton.Name = "AddUrlToolStripButton";
            this.AddUrlToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.AddUrlToolStripButton.Text = "Add from URL";
            this.AddUrlToolStripButton.Click += new System.EventHandler(this.AddUrlToolStripButton_Click);
            // 
            // CreateToolStripButton
            // 
            this.CreateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.document_new;
            this.CreateToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CreateToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.CreateToolStripButton.Name = "CreateToolStripButton";
            this.CreateToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.CreateToolStripButton.Text = "Create";
            this.CreateToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CreateToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.CreateToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.CreateToolStripButton.Click += new System.EventHandler(this.CreateToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // DelToolStripButton
            // 
            this.DelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.list_remove;
            this.DelToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DelToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.DelToolStripButton.Name = "DelToolStripButton";
            this.DelToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.DelToolStripButton.Text = "Delete";
            this.DelToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DelToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.DelToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.DelToolStripButton.Click += new System.EventHandler(this.DelToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // StartToolStripButton
            // 
            this.StartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_start;
            this.StartToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartToolStripButton.Name = "StartToolStripButton";
            this.StartToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.StartToolStripButton.Text = "Start";
            this.StartToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StartToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.StartToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.StartToolStripButton.Click += new System.EventHandler(this.StartToolStripButton_Click);
            // 
            // PauseToolStripButton
            // 
            this.PauseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PauseToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_pause;
            this.PauseToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PauseToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.PauseToolStripButton.Name = "PauseToolStripButton";
            this.PauseToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.PauseToolStripButton.Text = "Pause";
            this.PauseToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PauseToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.PauseToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.PauseToolStripButton.Click += new System.EventHandler(this.PauseToolStripButton_Click);
            // 
            // StopToolStripButton
            // 
            this.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_stop;
            this.StopToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StopToolStripButton.Name = "StopToolStripButton";
            this.StopToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.StopToolStripButton.Text = "Stop";
            this.StopToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StopToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.StopToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.StopToolStripButton.Click += new System.EventHandler(this.StopToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // UpStripButton
            // 
            this.UpStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.go_up;
            this.UpStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UpStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.UpStripButton.Name = "UpStripButton";
            this.UpStripButton.Size = new System.Drawing.Size(36, 36);
            this.UpStripButton.Text = "Up";
            this.UpStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UpStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.UpStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.UpStripButton.Click += new System.EventHandler(this.UpStripButton_Click);
            // 
            // DownStripButton
            // 
            this.DownStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DownStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.go_down;
            this.DownStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DownStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.DownStripButton.Name = "DownStripButton";
            this.DownStripButton.Size = new System.Drawing.Size(36, 36);
            this.DownStripButton.Text = "Down";
            this.DownStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DownStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.DownStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.DownStripButton.Click += new System.EventHandler(this.DownStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // RssStripButton
            // 
            this.RssStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RssStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.rss;
            this.RssStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RssStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.RssStripButton.Name = "RssStripButton";
            this.RssStripButton.Size = new System.Drawing.Size(36, 36);
            this.RssStripButton.Text = "RSS";
            this.RssStripButton.Click += new System.EventHandler(this.RssStripButton_Click);
            // 
            // OptionToolStripButton
            // 
            this.OptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OptionToolStripButton.Image = global::MonoTorrent.GUI.Properties.Resources.preferences_system;
            this.OptionToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OptionToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.OptionToolStripButton.Name = "OptionToolStripButton";
            this.OptionToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OptionToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.OptionToolStripButton.Text = "Options";
            this.OptionToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OptionToolStripButton.MouseLeave += new System.EventHandler(this.ClearStatusBar);
            this.OptionToolStripButton.MouseHover += new System.EventHandler(this.ItemMouseHover);
            this.OptionToolStripButton.Click += new System.EventHandler(this.OptionToolStripButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.niContextMenuStrip;
            this.notifyIcon.Text = "MonoTorrent";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // niContextMenuStrip
            // 
            this.niContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.niContextMenuStrip.Name = "niMenuStrip";
            this.niContextMenuStrip.Size = new System.Drawing.Size(124, 48);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.closeToolStripMenuItem.Text = "Quit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // torrentContextMenuStrip
            // 
            this.torrentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTorrentContextMenuItem,
            this.stopTorrentContextMenuItem,
            this.pauseTorrentContextMenuItem,
            this.toolStripMenuItem1,
            this.upTorrentContextMenuItem,
            this.downTorrentContextMenuItem,
            this.toolStripMenuItem2,
            this.changeTorrentSavePathContextMenuItem,
            this.deleteToolStripMenuItem});
            this.torrentContextMenuStrip.Name = "torrentMenuStrip";
            this.torrentContextMenuStrip.Size = new System.Drawing.Size(174, 170);
            // 
            // startTorrentContextMenuItem
            // 
            this.startTorrentContextMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_start;
            this.startTorrentContextMenuItem.Name = "startTorrentContextMenuItem";
            this.startTorrentContextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.startTorrentContextMenuItem.Text = "Start";
            this.startTorrentContextMenuItem.Click += new System.EventHandler(this.startTorrentContextMenuItem_Click);
            // 
            // stopTorrentContextMenuItem
            // 
            this.stopTorrentContextMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_stop;
            this.stopTorrentContextMenuItem.Name = "stopTorrentContextMenuItem";
            this.stopTorrentContextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.stopTorrentContextMenuItem.Text = "Stop";
            this.stopTorrentContextMenuItem.Click += new System.EventHandler(this.stopTorrentContextMenuItem_Click);
            // 
            // pauseTorrentContextMenuItem
            // 
            this.pauseTorrentContextMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.media_playback_pause;
            this.pauseTorrentContextMenuItem.Name = "pauseTorrentContextMenuItem";
            this.pauseTorrentContextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pauseTorrentContextMenuItem.Text = "Pause";
            this.pauseTorrentContextMenuItem.Click += new System.EventHandler(this.pauseTorrentContextMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
            // 
            // upTorrentContextMenuItem
            // 
            this.upTorrentContextMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.go_up;
            this.upTorrentContextMenuItem.Name = "upTorrentContextMenuItem";
            this.upTorrentContextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.upTorrentContextMenuItem.Text = "Up";
            this.upTorrentContextMenuItem.Click += new System.EventHandler(this.upTorrentContextMenuItem_Click);
            // 
            // downTorrentContextMenuItem
            // 
            this.downTorrentContextMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.go_down;
            this.downTorrentContextMenuItem.Name = "downTorrentContextMenuItem";
            this.downTorrentContextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.downTorrentContextMenuItem.Text = "Down";
            this.downTorrentContextMenuItem.Click += new System.EventHandler(this.downTorrentContextMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 6);
            // 
            // changeTorrentSavePathContextMenuItem
            // 
            this.changeTorrentSavePathContextMenuItem.Name = "changeTorrentSavePathContextMenuItem";
            this.changeTorrentSavePathContextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.changeTorrentSavePathContextMenuItem.Text = "Change save path";
            this.changeTorrentSavePathContextMenuItem.Click += new System.EventHandler(this.changeTorrentSavePathContextMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::MonoTorrent.GUI.Properties.Resources.list_remove;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.torrentsView);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detailsView);
            this.splitContainer1.Panel2MinSize = 15;
            this.splitContainer1.Size = new System.Drawing.Size(692, 360);
            this.splitContainer1.SplitterDistance = 115;
            this.splitContainer1.TabIndex = 3;
            // 
            // torrentsView
            // 
            this.torrentsView.AllowColumnReorder = true;
            this.torrentsView.AllowDrop = true;
            this.torrentsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSize,
            this.colProgressBar,
            this.colStatus,
            this.colSeeds,
            this.colLeeches,
            this.colDownSpeed,
            this.colUpSpeed,
            this.colDownloaded,
            this.colUploaded,
            this.colRatio,
            this.colRemaining});
            this.torrentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.torrentsView.FullRowSelect = true;
            this.torrentsView.Location = new System.Drawing.Point(0, 0);
            this.torrentsView.Margin = new System.Windows.Forms.Padding(5);
            this.torrentsView.Name = "torrentsView";
            this.torrentsView.OwnerDraw = true;
            this.torrentsView.Size = new System.Drawing.Size(692, 115);
            this.torrentsView.TabIndex = 0;
            this.torrentsView.UseCompatibleStateImageBehavior = false;
            this.torrentsView.View = System.Windows.Forms.View.Details;
            this.torrentsView.DragEnter += new System.Windows.Forms.DragEventHandler(this.TorrentsView_DragEnter);
            this.torrentsView.DragDrop += new System.Windows.Forms.DragEventHandler(this.TorrentsView_DragDrop);
            this.torrentsView.SelectedIndexChanged += new System.EventHandler(this.torrentsView_SelectedIndexChanged);
            this.torrentsView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.torrentsView_MouseUp);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colProgressBar
            // 
            this.colProgressBar.Text = "Progress";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colSeeds
            // 
            this.colSeeds.Text = "Seeds";
            // 
            // colLeeches
            // 
            this.colLeeches.Text = "Leechs";
            // 
            // colDownSpeed
            // 
            this.colDownSpeed.Text = "Download Speed";
            // 
            // colUpSpeed
            // 
            this.colUpSpeed.Text = "Upload Speed";
            // 
            // colDownloaded
            // 
            this.colDownloaded.Text = "Downloaded";
            // 
            // colUploaded
            // 
            this.colUploaded.Text = "Uploaded";
            // 
            // colRatio
            // 
            this.colRatio.Text = "Ratio";
            // 
            // colRemaining
            // 
            this.colRemaining.Text = "Remaining";
            // 
            // detailsView
            // 
            this.detailsView.Controls.Add(this.tabGeneral);
            this.detailsView.Controls.Add(this.tabDetails);
            this.detailsView.Controls.Add(this.tabPeers);
            this.detailsView.Controls.Add(this.tabPieces);
            this.detailsView.Controls.Add(this.tabFiles);
            this.detailsView.Controls.Add(this.tabStatsGraph);
            this.detailsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsView.Location = new System.Drawing.Point(0, 0);
            this.detailsView.Margin = new System.Windows.Forms.Padding(0);
            this.detailsView.Name = "detailsView";
            this.detailsView.Padding = new System.Drawing.Point(0, 0);
            this.detailsView.SelectedIndex = 0;
            this.detailsView.Size = new System.Drawing.Size(692, 241);
            this.detailsView.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.AutoScroll = true;
            this.tabGeneral.Controls.Add(this.generalPanel);
            this.tabGeneral.Controls.Add(this.trackerPanel);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(684, 215);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // generalPanel
            // 
            this.generalPanel.Controls.Add(this.HashLabel);
            this.generalPanel.Controls.Add(this.PiecesxSizeLabel);
            this.generalPanel.Controls.Add(this.InfosLabel);
            this.generalPanel.Controls.Add(this.DateLabel);
            this.generalPanel.Controls.Add(this.SizeLabel);
            this.generalPanel.Controls.Add(this.FolderLabel);
            this.generalPanel.Controls.Add(this.label9);
            this.generalPanel.Controls.Add(this.label8);
            this.generalPanel.Controls.Add(this.label7);
            this.generalPanel.Controls.Add(this.label6);
            this.generalPanel.Controls.Add(this.label5);
            this.generalPanel.Controls.Add(this.label4);
            this.generalPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.generalPanel.Location = new System.Drawing.Point(0, 76);
            this.generalPanel.Margin = new System.Windows.Forms.Padding(10);
            this.generalPanel.Name = "generalPanel";
            this.generalPanel.Size = new System.Drawing.Size(684, 135);
            this.generalPanel.TabIndex = 4;
            this.generalPanel.TabStop = false;
            this.generalPanel.Text = "General";
            // 
            // HashLabel
            // 
            this.HashLabel.AutoSize = true;
            this.HashLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HashLabel.Location = new System.Drawing.Point(86, 110);
            this.HashLabel.Name = "HashLabel";
            this.HashLabel.Size = new System.Drawing.Size(16, 13);
            this.HashLabel.TabIndex = 11;
            this.HashLabel.Text = "...";
            // 
            // PiecesxSizeLabel
            // 
            this.PiecesxSizeLabel.AutoSize = true;
            this.PiecesxSizeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PiecesxSizeLabel.Location = new System.Drawing.Point(86, 91);
            this.PiecesxSizeLabel.Name = "PiecesxSizeLabel";
            this.PiecesxSizeLabel.Size = new System.Drawing.Size(16, 13);
            this.PiecesxSizeLabel.TabIndex = 10;
            this.PiecesxSizeLabel.Text = "...";
            // 
            // InfosLabel
            // 
            this.InfosLabel.AutoSize = true;
            this.InfosLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InfosLabel.Location = new System.Drawing.Point(86, 73);
            this.InfosLabel.Name = "InfosLabel";
            this.InfosLabel.Size = new System.Drawing.Size(16, 13);
            this.InfosLabel.TabIndex = 9;
            this.InfosLabel.Text = "...";
            this.InfosLabel.Click += new System.EventHandler(this.InfosLabel_Click);
            this.InfosLabel.MouseHover += new System.EventHandler(this.InfosLabel_MouseHover);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DateLabel.Location = new System.Drawing.Point(86, 54);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(16, 13);
            this.DateLabel.TabIndex = 8;
            this.DateLabel.Text = "...";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SizeLabel.Location = new System.Drawing.Point(86, 35);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(16, 13);
            this.SizeLabel.TabIndex = 7;
            this.SizeLabel.Text = "...";
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FolderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FolderLabel.Location = new System.Drawing.Point(86, 16);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(16, 13);
            this.FolderLabel.TabIndex = 6;
            this.FolderLabel.Text = "...";
            this.FolderLabel.Click += new System.EventHandler(this.FolderLabel_Click);
            this.FolderLabel.MouseHover += new System.EventHandler(this.FolderLabel_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Pieces x size :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Hash :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Infos :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Size :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Folder :";
            // 
            // trackerPanel
            // 
            this.trackerPanel.Controls.Add(this.TrackerMessageTextBox);
            this.trackerPanel.Controls.Add(this.label19);
            this.trackerPanel.Controls.Add(this.UpdateLabel);
            this.trackerPanel.Controls.Add(this.StatusLabel);
            this.trackerPanel.Controls.Add(this.URLLabel);
            this.trackerPanel.Controls.Add(this.label3);
            this.trackerPanel.Controls.Add(this.label2);
            this.trackerPanel.Controls.Add(this.label1);
            this.trackerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackerPanel.Location = new System.Drawing.Point(0, 0);
            this.trackerPanel.Margin = new System.Windows.Forms.Padding(10);
            this.trackerPanel.Name = "trackerPanel";
            this.trackerPanel.Size = new System.Drawing.Size(684, 76);
            this.trackerPanel.TabIndex = 3;
            this.trackerPanel.TabStop = false;
            this.trackerPanel.Text = "Tracker";
            // 
            // TrackerMessageTextBox
            // 
            this.TrackerMessageTextBox.Enabled = false;
            this.TrackerMessageTextBox.Location = new System.Drawing.Point(323, 16);
            this.TrackerMessageTextBox.Multiline = true;
            this.TrackerMessageTextBox.Name = "TrackerMessageTextBox";
            this.TrackerMessageTextBox.Size = new System.Drawing.Size(239, 38);
            this.TrackerMessageTextBox.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(261, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Message :";
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.AutoSize = true;
            this.UpdateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UpdateLabel.Location = new System.Drawing.Point(86, 50);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(16, 13);
            this.UpdateLabel.TabIndex = 5;
            this.UpdateLabel.Text = "...";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatusLabel.Location = new System.Drawing.Point(86, 33);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(16, 13);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "...";
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.URLLabel.Location = new System.Drawing.Point(86, 16);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(16, 13);
            this.URLLabel.TabIndex = 3;
            this.URLLabel.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Update :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL :";
            // 
            // tabDetails
            // 
            this.tabDetails.AutoScroll = true;
            this.tabDetails.Controls.Add(this.clientsLabel);
            this.tabDetails.Controls.Add(this.uploadSpeedLabel);
            this.tabDetails.Controls.Add(this.downloadSpeedLabel);
            this.tabDetails.Controls.Add(this.estimatedTimeLabel);
            this.tabDetails.Controls.Add(this.label17);
            this.tabDetails.Controls.Add(this.label15);
            this.tabDetails.Controls.Add(this.label13);
            this.tabDetails.Controls.Add(this.label12);
            this.tabDetails.Controls.Add(this.piecesLabel);
            this.tabDetails.Controls.Add(this.peersLabel);
            this.tabDetails.Controls.Add(this.uploadLabel);
            this.tabDetails.Controls.Add(this.downloadLabel);
            this.tabDetails.Controls.Add(this.elapsedTimeLabel);
            this.tabDetails.Controls.Add(this.label18);
            this.tabDetails.Controls.Add(this.label16);
            this.tabDetails.Controls.Add(this.label14);
            this.tabDetails.Controls.Add(this.label11);
            this.tabDetails.Controls.Add(this.label10);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(684, 215);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // clientsLabel
            // 
            this.clientsLabel.AutoSize = true;
            this.clientsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clientsLabel.Location = new System.Drawing.Point(277, 80);
            this.clientsLabel.Name = "clientsLabel";
            this.clientsLabel.Size = new System.Drawing.Size(16, 13);
            this.clientsLabel.TabIndex = 25;
            this.clientsLabel.Text = "...";
            // 
            // uploadSpeedLabel
            // 
            this.uploadSpeedLabel.AutoSize = true;
            this.uploadSpeedLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uploadSpeedLabel.Location = new System.Drawing.Point(277, 57);
            this.uploadSpeedLabel.Name = "uploadSpeedLabel";
            this.uploadSpeedLabel.Size = new System.Drawing.Size(16, 13);
            this.uploadSpeedLabel.TabIndex = 24;
            this.uploadSpeedLabel.Text = "...";
            // 
            // downloadSpeedLabel
            // 
            this.downloadSpeedLabel.AutoSize = true;
            this.downloadSpeedLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.downloadSpeedLabel.Location = new System.Drawing.Point(277, 35);
            this.downloadSpeedLabel.Name = "downloadSpeedLabel";
            this.downloadSpeedLabel.Size = new System.Drawing.Size(16, 13);
            this.downloadSpeedLabel.TabIndex = 23;
            this.downloadSpeedLabel.Text = "...";
            // 
            // estimatedTimeLabel
            // 
            this.estimatedTimeLabel.AutoSize = true;
            this.estimatedTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.estimatedTimeLabel.Location = new System.Drawing.Point(277, 13);
            this.estimatedTimeLabel.Name = "estimatedTimeLabel";
            this.estimatedTimeLabel.Size = new System.Drawing.Size(16, 13);
            this.estimatedTimeLabel.TabIndex = 22;
            this.estimatedTimeLabel.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(178, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "Clients :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(178, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Upload speed:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(178, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Download speed :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(178, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Estimated time :";
            // 
            // piecesLabel
            // 
            this.piecesLabel.AutoSize = true;
            this.piecesLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.piecesLabel.Location = new System.Drawing.Point(88, 103);
            this.piecesLabel.Name = "piecesLabel";
            this.piecesLabel.Size = new System.Drawing.Size(16, 13);
            this.piecesLabel.TabIndex = 17;
            this.piecesLabel.Text = "...";
            // 
            // peersLabel
            // 
            this.peersLabel.AutoSize = true;
            this.peersLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.peersLabel.Location = new System.Drawing.Point(88, 80);
            this.peersLabel.Name = "peersLabel";
            this.peersLabel.Size = new System.Drawing.Size(16, 13);
            this.peersLabel.TabIndex = 12;
            this.peersLabel.Text = "...";
            // 
            // uploadLabel
            // 
            this.uploadLabel.AutoSize = true;
            this.uploadLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uploadLabel.Location = new System.Drawing.Point(88, 57);
            this.uploadLabel.Name = "uploadLabel";
            this.uploadLabel.Size = new System.Drawing.Size(16, 13);
            this.uploadLabel.TabIndex = 11;
            this.uploadLabel.Text = "...";
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.downloadLabel.Location = new System.Drawing.Point(88, 35);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(16, 13);
            this.downloadLabel.TabIndex = 10;
            this.downloadLabel.Text = "...";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(88, 13);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(16, 13);
            this.elapsedTimeLabel.TabIndex = 9;
            this.elapsedTimeLabel.Text = "...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(8, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Pieces :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(8, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Peers :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(8, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Upload :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(8, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Download :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(8, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Elapsed time :";
            // 
            // tabPeers
            // 
            this.tabPeers.AutoScroll = true;
            this.tabPeers.Controls.Add(this.PeerListView);
            this.tabPeers.Location = new System.Drawing.Point(4, 22);
            this.tabPeers.Name = "tabPeers";
            this.tabPeers.Size = new System.Drawing.Size(684, 215);
            this.tabPeers.TabIndex = 2;
            this.tabPeers.Text = "Peers";
            this.tabPeers.UseVisualStyleBackColor = true;
            // 
            // PeerListView
            // 
            this.PeerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PeerId,
            this.ClientApp,
            this.LocationPeer,
            this.Download,
            this.Upload,
            this.DownloadSpeed,
            this.UploadSpeed,
            this.IsSeeder,
            this.Encryption,
            this.IsChoking,
            this.IsInterested,
            this.IsRequestingPiecesCount,
            this.PiecesSent,
            this.SupportsFastPeer});
            this.PeerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PeerListView.Location = new System.Drawing.Point(0, 0);
            this.PeerListView.Name = "PeerListView";
            this.PeerListView.Size = new System.Drawing.Size(684, 215);
            this.PeerListView.TabIndex = 0;
            this.PeerListView.UseCompatibleStateImageBehavior = false;
            this.PeerListView.View = System.Windows.Forms.View.Details;
            // 
            // PeerId
            // 
            this.PeerId.Text = "PeerId";
            // 
            // ClientApp
            // 
            this.ClientApp.Text = "Client Software";
            this.ClientApp.Width = 89;
            // 
            // LocationPeer
            // 
            this.LocationPeer.Text = "Location";
            // 
            // Download
            // 
            this.Download.Text = "Download";
            this.Download.Width = 64;
            // 
            // Upload
            // 
            this.Upload.Text = "Upload";
            // 
            // DownloadSpeed
            // 
            this.DownloadSpeed.Text = "Download Speed";
            this.DownloadSpeed.Width = 97;
            // 
            // UploadSpeed
            // 
            this.UploadSpeed.Text = "Upload Speed";
            this.UploadSpeed.Width = 85;
            // 
            // IsSeeder
            // 
            this.IsSeeder.Text = "Seeder";
            // 
            // Encryption
            // 
            this.Encryption.Text = "Encryption type";
            // 
            // IsChoking
            // 
            this.IsChoking.Text = "Choking";
            // 
            // IsInterested
            // 
            this.IsInterested.Text = "Interested";
            // 
            // IsRequestingPiecesCount
            // 
            this.IsRequestingPiecesCount.Text = "Requesting pieces count";
            // 
            // PiecesSent
            // 
            this.PiecesSent.Text = "Pieces sent";
            // 
            // SupportsFastPeer
            // 
            this.SupportsFastPeer.Text = "Support fast peer";
            // 
            // tabPieces
            // 
            this.tabPieces.AutoScroll = true;
            this.tabPieces.Controls.Add(this.piecesListView);
            this.tabPieces.Location = new System.Drawing.Point(4, 22);
            this.tabPieces.Name = "tabPieces";
            this.tabPieces.Size = new System.Drawing.Size(684, 215);
            this.tabPieces.TabIndex = 3;
            this.tabPieces.Text = "Pieces";
            this.tabPieces.UseVisualStyleBackColor = true;
            // 
            // piecesListView
            // 
            this.piecesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.piecesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.piecesListView.FullRowSelect = true;
            this.piecesListView.Location = new System.Drawing.Point(0, 0);
            this.piecesListView.Name = "piecesListView";
            this.piecesListView.OwnerDraw = true;
            this.piecesListView.Size = new System.Drawing.Size(684, 215);
            this.piecesListView.TabIndex = 0;
            this.piecesListView.UseCompatibleStateImageBehavior = false;
            this.piecesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "#";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Size";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Blocs #";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Progress";
            this.columnHeader11.Width = 319;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.FilesTreeView);
            this.tabFiles.Location = new System.Drawing.Point(4, 22);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(684, 215);
            this.tabFiles.TabIndex = 4;
            this.tabFiles.Text = "Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // FilesTreeView
            // 
            this.FilesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesTreeView.Location = new System.Drawing.Point(3, 3);
            this.FilesTreeView.Name = "FilesTreeView";
            this.FilesTreeView.ShowNodeToolTips = true;
            this.FilesTreeView.Size = new System.Drawing.Size(678, 209);
            this.FilesTreeView.TabIndex = 0;
            // 
            // tabStatsGraph
            // 
            this.tabStatsGraph.Controls.Add(this.statsGraph);
            this.tabStatsGraph.Location = new System.Drawing.Point(4, 22);
            this.tabStatsGraph.Name = "tabStatsGraph";
            this.tabStatsGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatsGraph.Size = new System.Drawing.Size(684, 215);
            this.tabStatsGraph.TabIndex = 5;
            this.tabStatsGraph.Text = "Statistics";
            this.tabStatsGraph.UseVisualStyleBackColor = true;
            // 
            // statsGraph
            // 
            this.statsGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsGraph.Location = new System.Drawing.Point(3, 3);
            this.statsGraph.Name = "statsGraph";
            this.statsGraph.Size = new System.Drawing.Size(678, 209);
            this.statsGraph.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 442);
            this.Controls.Add(this.MaintoolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "MonoTorrent.GUI";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.MaintoolStrip.ResumeLayout(false);
            this.MaintoolStrip.PerformLayout();
            this.niContextMenuStrip.ResumeLayout(false);
            this.torrentContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.detailsView.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.generalPanel.ResumeLayout(false);
            this.generalPanel.PerformLayout();
            this.trackerPanel.ResumeLayout(false);
            this.trackerPanel.PerformLayout();
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabPeers.ResumeLayout(false);
            this.tabPieces.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.tabStatsGraph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.StatusStrip statusBar;
        private Control.ImageListView torrentsView;
        private System.Windows.Forms.TabControl detailsView;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSeeds;
        private System.Windows.Forms.ColumnHeader colLeeches;
        private System.Windows.Forms.ColumnHeader colDownSpeed;
        private System.Windows.Forms.ColumnHeader colUpSpeed;
        private System.Windows.Forms.ColumnHeader colDownloaded;
        private System.Windows.Forms.ColumnHeader colUploaded;
        private System.Windows.Forms.ColumnHeader colRatio;
        private System.Windows.Forms.ColumnHeader colRemaining;
        private System.Windows.Forms.TabPage tabPeers;
        private System.Windows.Forms.TabPage tabPieces;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStrip MaintoolStrip;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.ToolStripButton StartToolStripButton;
        private System.Windows.Forms.ToolStripButton PauseToolStripButton;
        private System.Windows.Forms.ToolStripButton StopToolStripButton;
        private System.Windows.Forms.ToolStripButton DelToolStripButton;
        private System.Windows.Forms.ToolStripButton OptionToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton DownStripButton;
        private System.Windows.Forms.ToolStripButton UpStripButton;
        private System.Windows.Forms.ToolStripMenuItem addATorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createATorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showToolbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStatusbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem deleteATorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton CreateToolStripButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView PeerListView;
        private System.Windows.Forms.ColumnHeader PeerId;
        private System.Windows.Forms.ColumnHeader ClientApp;
		private System.Windows.Forms.ColumnHeader LocationPeer;
        private System.Windows.Forms.ColumnHeader Download;
        private System.Windows.Forms.ColumnHeader Upload;
        private System.Windows.Forms.ColumnHeader DownloadSpeed;
        private Control.ImageListView piecesListView;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader UploadSpeed;
		private System.Windows.Forms.ColumnHeader IsSeeder;
		private System.Windows.Forms.ColumnHeader Encryption;
		private System.Windows.Forms.ColumnHeader IsChoking;
		private System.Windows.Forms.ColumnHeader IsInterested;
		private System.Windows.Forms.ColumnHeader IsRequestingPiecesCount;
		private System.Windows.Forms.ColumnHeader PiecesSent;
        private System.Windows.Forms.ColumnHeader SupportsFastPeer;
		private System.Windows.Forms.Label peersLabel;
		private System.Windows.Forms.Label uploadLabel;
		private System.Windows.Forms.Label downloadLabel;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label piecesLabel;
        private System.Windows.Forms.ColumnHeader colProgressBar;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.TreeView FilesTreeView;
        private System.Windows.Forms.ToolStripMenuItem miniWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusItem;
        private System.Windows.Forms.TabPage tabStatsGraph;
        private MonoTorrent.GUI.View.Control.GraphicControl statsGraph;
        private System.Windows.Forms.Label clientsLabel;
        private System.Windows.Forms.Label uploadSpeedLabel;
        private System.Windows.Forms.Label downloadSpeedLabel;
        private System.Windows.Forms.Label estimatedTimeLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox trackerPanel;
        private System.Windows.Forms.TextBox TrackerMessageTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label UpdateLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox generalPanel;
        private System.Windows.Forms.Label HashLabel;
        private System.Windows.Forms.Label PiecesxSizeLabel;
        private System.Windows.Forms.Label InfosLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip niContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip torrentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startTorrentContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTorrentContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseTorrentContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem upTorrentContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downTorrentContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem changeTorrentSavePathContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTorrent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem startTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem upTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem changeTorrentSavePathToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton AddUrlToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton RssStripButton;
    }
}

