namespace MonoTorrent.GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTorrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.torrentsView = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colProgress = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colSeeds = new System.Windows.Forms.ColumnHeader();
            this.colLeeches = new System.Windows.Forms.ColumnHeader();
            this.colDownSpeed = new System.Windows.Forms.ColumnHeader();
            this.colUpSpeed = new System.Windows.Forms.ColumnHeader();
            this.colDownloaded = new System.Windows.Forms.ColumnHeader();
            this.colUploaded = new System.Windows.Forms.ColumnHeader();
            this.colRatio = new System.Windows.Forms.ColumnHeader();
            this.detailsView = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.generalPanel = new System.Windows.Forms.GroupBox();
            this.trackerPanel = new System.Windows.Forms.GroupBox();
            this.tabPeers = new System.Windows.Forms.TabPage();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.tabPieces = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelMainControls = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuBar.SuspendLayout();
            this.detailsView.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelMainControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.Control;
            this.menuBar.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuAbout});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(0);
            this.menuBar.Size = new System.Drawing.Size(722, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 24);
            this.menuFile.Text = "File";
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(37, 24);
            this.menuEdit.Text = "Edit";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(48, 24);
            this.menuAbout.Text = "About";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTorrentToolStripMenuItem,
            this.addTorrentToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createTorrentToolStripMenuItem
            // 
            this.createTorrentToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createTorrentToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.createTorrentToolStripMenuItem.Name = "createTorrentToolStripMenuItem";
            this.createTorrentToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.createTorrentToolStripMenuItem.Text = "Create Torrent";
            this.createTorrentToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addTorrentToolStripMenuItem
            // 
            this.addTorrentToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addTorrentToolStripMenuItem.Name = "addTorrentToolStripMenuItem";
            this.addTorrentToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addTorrentToolStripMenuItem.Text = "Add Torrent";
            this.addTorrentToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.showToolbarToolStripMenuItem,
            this.showStatusBarToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            // 
            // showToolbarToolStripMenuItem
            // 
            this.showToolbarToolStripMenuItem.Name = "showToolbarToolStripMenuItem";
            this.showToolbarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showToolbarToolStripMenuItem.Text = "Show Toolbar";
            // 
            // showStatusBarToolStripMenuItem
            // 
            this.showStatusBarToolStripMenuItem.Name = "showStatusBarToolStripMenuItem";
            this.showStatusBarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showStatusBarToolStripMenuItem.Text = "Show StatusBar";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.helpToolStripMenuItem.Text = "About";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 451);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(722, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip";
            // 
            // torrentsView
            // 
            this.torrentsView.AllowColumnReorder = true;
            this.torrentsView.AllowDrop = true;
            this.torrentsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSize,
            this.colProgress,
            this.colStatus,
            this.colSeeds,
            this.colLeeches,
            this.colDownSpeed,
            this.colUpSpeed,
            this.colDownloaded,
            this.colUploaded,
            this.colRatio});
            this.torrentsView.Location = new System.Drawing.Point(0, 5);
            this.torrentsView.Margin = new System.Windows.Forms.Padding(5);
            this.torrentsView.Name = "torrentsView";
            this.torrentsView.Size = new System.Drawing.Size(722, 190);
            this.torrentsView.TabIndex = 0;
            this.torrentsView.UseCompatibleStateImageBehavior = false;
            this.torrentsView.View = System.Windows.Forms.View.Details;
            this.torrentsView.DragEnter += new System.Windows.Forms.DragEventHandler(this.TorrentsView_DragEnter);
            this.torrentsView.DragDrop += new System.Windows.Forms.DragEventHandler(this.TorrentsView_DragDrop);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colProgress
            // 
            this.colProgress.Text = "Progress";
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
            // detailsView
            // 
            this.detailsView.Controls.Add(this.tabGeneral);
            this.detailsView.Controls.Add(this.tabDetails);
            this.detailsView.Controls.Add(this.tabPeers);
            this.detailsView.Controls.Add(this.tabPieces);
            this.detailsView.Location = new System.Drawing.Point(0, 0);
            this.detailsView.Margin = new System.Windows.Forms.Padding(0);
            this.detailsView.Name = "detailsView";
            this.detailsView.Padding = new System.Drawing.Point(0, 0);
            this.detailsView.SelectedIndex = 0;
            this.detailsView.Size = new System.Drawing.Size(722, 343);
            this.detailsView.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.AutoScroll = true;
            this.tabGeneral.Controls.Add(this.generalPanel);
            this.tabGeneral.Controls.Add(this.trackerPanel);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(714, 317);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // generalPanel
            // 
            this.generalPanel.Location = new System.Drawing.Point(15, 164);
            this.generalPanel.Margin = new System.Windows.Forms.Padding(10);
            this.generalPanel.MinimumSize = new System.Drawing.Size(450, 0);
            this.generalPanel.Name = "generalPanel";
            this.generalPanel.Size = new System.Drawing.Size(727, 195);
            this.generalPanel.TabIndex = 0;
            this.generalPanel.TabStop = false;
            this.generalPanel.Text = "General";
            // 
            // trackerPanel
            // 
            this.trackerPanel.Location = new System.Drawing.Point(15, 10);
            this.trackerPanel.Margin = new System.Windows.Forms.Padding(10);
            this.trackerPanel.MinimumSize = new System.Drawing.Size(450, 0);
            this.trackerPanel.Name = "trackerPanel";
            this.trackerPanel.Size = new System.Drawing.Size(684, 134);
            this.trackerPanel.TabIndex = 0;
            this.trackerPanel.TabStop = false;
            this.trackerPanel.Text = "Tracker";
            // 
            // tabPeers
            // 
            this.tabPeers.AutoScroll = true;
            this.tabPeers.Location = new System.Drawing.Point(4, 22);
            this.tabPeers.Name = "tabPeers";
            this.tabPeers.Size = new System.Drawing.Size(714, 317);
            this.tabPeers.TabIndex = 2;
            this.tabPeers.Text = "Peers";
            this.tabPeers.UseVisualStyleBackColor = true;
            // 
            // tabDetails
            // 
            this.tabDetails.AutoScroll = true;
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(714, 317);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.Text = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // tabPieces
            // 
            this.tabPieces.AutoScroll = true;
            this.tabPieces.Location = new System.Drawing.Point(4, 22);
            this.tabPieces.Name = "tabPieces";
            this.tabPieces.Size = new System.Drawing.Size(714, 317);
            this.tabPieces.TabIndex = 3;
            this.tabPieces.Text = "Pieces";
            this.tabPieces.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Location = new System.Drawing.Point(0, 69);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.torrentsView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detailsView);
            this.splitContainer1.Size = new System.Drawing.Size(722, 382);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelMainControls
            // 
            this.panelMainControls.Controls.Add(this.button7);
            this.panelMainControls.Controls.Add(this.button6);
            this.panelMainControls.Controls.Add(this.button5);
            this.panelMainControls.Controls.Add(this.button4);
            this.panelMainControls.Controls.Add(this.button3);
            this.panelMainControls.Controls.Add(this.button2);
            this.panelMainControls.Controls.Add(this.button1);
            this.panelMainControls.Location = new System.Drawing.Point(3, 27);
            this.panelMainControls.Name = "panelMainControls";
            this.panelMainControls.Size = new System.Drawing.Size(644, 39);
            this.panelMainControls.TabIndex = 3;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(273, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 33);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Image = global::MonoTorrent.GUI.Properties.Resources.tools2;
            this.button6.Location = new System.Drawing.Point(228, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 33);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(183, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 33);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = global::MonoTorrent.GUI.Properties.Resources.Sign_pause;
            this.button4.Location = new System.Drawing.Point(138, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 33);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = global::MonoTorrent.GUI.Properties.Resources.Sign_greaterThan;
            this.button3.Location = new System.Drawing.Point(93, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 33);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = global::MonoTorrent.GUI.Properties.Resources.Sign_subtraction;
            this.button2.Location = new System.Drawing.Point(48, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 33);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 33);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 473);
            this.Controls.Add(this.panelMainControls);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainWindow";
            this.Text = "MonoTorrent";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.detailsView.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panelMainControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ListView torrentsView;
        private System.Windows.Forms.TabControl detailsView;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTorrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStatusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colProgress;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSeeds;
        private System.Windows.Forms.ColumnHeader colLeeches;
        private System.Windows.Forms.ColumnHeader colDownSpeed;
        private System.Windows.Forms.ColumnHeader colUpSpeed;
        private System.Windows.Forms.ColumnHeader colDownloaded;
        private System.Windows.Forms.ColumnHeader colUploaded;
        private System.Windows.Forms.ColumnHeader colRatio;
        private System.Windows.Forms.TabPage tabPeers;
        private System.Windows.Forms.TabPage tabPieces;
        private System.Windows.Forms.GroupBox trackerPanel;
        private System.Windows.Forms.GroupBox generalPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelMainControls;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}

