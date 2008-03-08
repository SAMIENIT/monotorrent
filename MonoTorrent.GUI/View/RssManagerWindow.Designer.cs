namespace MonoTorrent.GUI.View
{
	partial class RssManagerWindow
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent ()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl ();
			this.FeedsTabPage = new System.Windows.Forms.TabPage ();
			this.FeedListbox = new System.Windows.Forms.ListBox ();
			this.RemoveFeedBtn = new System.Windows.Forms.Button ();
			this.AddFeedBtn = new System.Windows.Forms.Button ();
			this.label1 = new System.Windows.Forms.Label ();
			this.feedtxtbox = new System.Windows.Forms.TextBox ();
			this.FiltersTabPage = new System.Windows.Forms.TabPage ();
			this.BrowseBtn = new System.Windows.Forms.Button ();
			this.label7 = new System.Windows.Forms.Label ();
			this.FilterFeedCombo = new System.Windows.Forms.ComboBox ();
			this.SavePathTxtbox = new System.Windows.Forms.TextBox ();
			this.ExcludeTxtbox = new System.Windows.Forms.TextBox ();
			this.FilterTxtbox = new System.Windows.Forms.TextBox ();
			this.NameTxtbox = new System.Windows.Forms.TextBox ();
			this.label6 = new System.Windows.Forms.Label ();
			this.label5 = new System.Windows.Forms.Label ();
			this.label4 = new System.Windows.Forms.Label ();
			this.label3 = new System.Windows.Forms.Label ();
			this.label2 = new System.Windows.Forms.Label ();
			this.RemoveFilterBtn = new System.Windows.Forms.Button ();
			this.AddFilterBtn = new System.Windows.Forms.Button ();
			this.FilterListbox = new System.Windows.Forms.ListBox ();
			this.TorrentsTabPage = new System.Windows.Forms.TabPage ();
			this.RefreshTorrentBtn = new System.Windows.Forms.Button ();
			this.TorrentListBox = new System.Windows.Forms.ListBox ();
			this.TorrentsFeedCombo = new System.Windows.Forms.ComboBox ();
			this.HistoryTabPage = new System.Windows.Forms.TabPage ();
			this.ClearHistoryBtn = new System.Windows.Forms.Button ();
			this.RemoveHistoryBtn = new System.Windows.Forms.Button ();
			this.HistoryListbox = new System.Windows.Forms.ListBox ();
			this.CloseBtn = new System.Windows.Forms.Button ();
			this.tabControl1.SuspendLayout ();
			this.FeedsTabPage.SuspendLayout ();
			this.FiltersTabPage.SuspendLayout ();
			this.TorrentsTabPage.SuspendLayout ();
			this.HistoryTabPage.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add (this.FeedsTabPage);
			this.tabControl1.Controls.Add (this.FiltersTabPage);
			this.tabControl1.Controls.Add (this.TorrentsTabPage);
			this.tabControl1.Controls.Add (this.HistoryTabPage);
			this.tabControl1.Location = new System.Drawing.Point (12, 1);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size (514, 304);
			this.tabControl1.TabIndex = 0;
			// 
			// FeedsTabPage
			// 
			this.FeedsTabPage.Controls.Add (this.FeedListbox);
			this.FeedsTabPage.Controls.Add (this.RemoveFeedBtn);
			this.FeedsTabPage.Controls.Add (this.AddFeedBtn);
			this.FeedsTabPage.Controls.Add (this.label1);
			this.FeedsTabPage.Controls.Add (this.feedtxtbox);
			this.FeedsTabPage.Location = new System.Drawing.Point (4, 22);
			this.FeedsTabPage.Name = "FeedsTabPage";
			this.FeedsTabPage.Padding = new System.Windows.Forms.Padding (3);
			this.FeedsTabPage.Size = new System.Drawing.Size (506, 278);
			this.FeedsTabPage.TabIndex = 0;
			this.FeedsTabPage.Text = "Feeds";
			this.FeedsTabPage.UseVisualStyleBackColor = true;
			// 
			// FeedListbox
			// 
			this.FeedListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FeedListbox.FormattingEnabled = true;
			this.FeedListbox.Location = new System.Drawing.Point (7, 34);
			this.FeedListbox.Name = "FeedListbox";
			this.FeedListbox.Size = new System.Drawing.Size (412, 212);
			this.FeedListbox.TabIndex = 5;
			// 
			// RemoveFeedBtn
			// 
			this.RemoveFeedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveFeedBtn.Location = new System.Drawing.Point (425, 62);
			this.RemoveFeedBtn.Name = "RemoveFeedBtn";
			this.RemoveFeedBtn.Size = new System.Drawing.Size (75, 23);
			this.RemoveFeedBtn.TabIndex = 4;
			this.RemoveFeedBtn.Text = "Remove";
			this.RemoveFeedBtn.UseVisualStyleBackColor = true;
			this.RemoveFeedBtn.Click += new System.EventHandler (this.RemoveFeedBtn_Click);
			// 
			// AddFeedBtn
			// 
			this.AddFeedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AddFeedBtn.Location = new System.Drawing.Point (425, 33);
			this.AddFeedBtn.Name = "AddFeedBtn";
			this.AddFeedBtn.Size = new System.Drawing.Size (75, 23);
			this.AddFeedBtn.TabIndex = 3;
			this.AddFeedBtn.Text = "Add";
			this.AddFeedBtn.UseVisualStyleBackColor = true;
			this.AddFeedBtn.Click += new System.EventHandler (this.AddFeedBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (55, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Rss Feed:";
			// 
			// feedtxtbox
			// 
			this.feedtxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.feedtxtbox.Location = new System.Drawing.Point (68, 7);
			this.feedtxtbox.Name = "feedtxtbox";
			this.feedtxtbox.Size = new System.Drawing.Size (432, 20);
			this.feedtxtbox.TabIndex = 0;
			// 
			// FiltersTabPage
			// 
			this.FiltersTabPage.Controls.Add (this.BrowseBtn);
			this.FiltersTabPage.Controls.Add (this.label7);
			this.FiltersTabPage.Controls.Add (this.FilterFeedCombo);
			this.FiltersTabPage.Controls.Add (this.SavePathTxtbox);
			this.FiltersTabPage.Controls.Add (this.ExcludeTxtbox);
			this.FiltersTabPage.Controls.Add (this.FilterTxtbox);
			this.FiltersTabPage.Controls.Add (this.NameTxtbox);
			this.FiltersTabPage.Controls.Add (this.label6);
			this.FiltersTabPage.Controls.Add (this.label5);
			this.FiltersTabPage.Controls.Add (this.label4);
			this.FiltersTabPage.Controls.Add (this.label3);
			this.FiltersTabPage.Controls.Add (this.label2);
			this.FiltersTabPage.Controls.Add (this.RemoveFilterBtn);
			this.FiltersTabPage.Controls.Add (this.AddFilterBtn);
			this.FiltersTabPage.Controls.Add (this.FilterListbox);
			this.FiltersTabPage.Location = new System.Drawing.Point (4, 22);
			this.FiltersTabPage.Name = "FiltersTabPage";
			this.FiltersTabPage.Padding = new System.Windows.Forms.Padding (3);
			this.FiltersTabPage.Size = new System.Drawing.Size (506, 278);
			this.FiltersTabPage.TabIndex = 1;
			this.FiltersTabPage.Text = "Filters";
			this.FiltersTabPage.UseVisualStyleBackColor = true;
			// 
			// BrowseBtn
			// 
			this.BrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseBtn.Location = new System.Drawing.Point (447, 122);
			this.BrowseBtn.Name = "BrowseBtn";
			this.BrowseBtn.Size = new System.Drawing.Size (53, 23);
			this.BrowseBtn.TabIndex = 14;
			this.BrowseBtn.Text = "Browse";
			this.BrowseBtn.UseVisualStyleBackColor = true;
			this.BrowseBtn.Click += new System.EventHandler (this.BrowseBtn_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point (133, 157);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size (34, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Feed:";
			// 
			// FilterFeedCombo
			// 
			this.FilterFeedCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterFeedCombo.FormattingEnabled = true;
			this.FilterFeedCombo.Location = new System.Drawing.Point (200, 154);
			this.FilterFeedCombo.Name = "FilterFeedCombo";
			this.FilterFeedCombo.Size = new System.Drawing.Size (300, 21);
			this.FilterFeedCombo.TabIndex = 12;
			this.FilterFeedCombo.SelectedIndexChanged += new System.EventHandler (this.FilterFeedCombo_SelectedIndexChanged);
			// 
			// SavePathTxtbox
			// 
			this.SavePathTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SavePathTxtbox.Location = new System.Drawing.Point (200, 122);
			this.SavePathTxtbox.Name = "SavePathTxtbox";
			this.SavePathTxtbox.Size = new System.Drawing.Size (242, 20);
			this.SavePathTxtbox.TabIndex = 11;
			this.SavePathTxtbox.TextChanged += new System.EventHandler (this.SavePathTxtbox_TextChanged);
			// 
			// ExcludeTxtbox
			// 
			this.ExcludeTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ExcludeTxtbox.Location = new System.Drawing.Point (200, 90);
			this.ExcludeTxtbox.Name = "ExcludeTxtbox";
			this.ExcludeTxtbox.Size = new System.Drawing.Size (300, 20);
			this.ExcludeTxtbox.TabIndex = 10;
			this.ExcludeTxtbox.TextChanged += new System.EventHandler (this.ExcludeTxtbox_TextChanged);
			// 
			// FilterTxtbox
			// 
			this.FilterTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.FilterTxtbox.Location = new System.Drawing.Point (200, 59);
			this.FilterTxtbox.Name = "FilterTxtbox";
			this.FilterTxtbox.Size = new System.Drawing.Size (300, 20);
			this.FilterTxtbox.TabIndex = 9;
			this.FilterTxtbox.TextChanged += new System.EventHandler (this.FilterTxtbox_TextChanged);
			// 
			// NameTxtbox
			// 
			this.NameTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameTxtbox.Location = new System.Drawing.Point (200, 32);
			this.NameTxtbox.Name = "NameTxtbox";
			this.NameTxtbox.Size = new System.Drawing.Size (300, 20);
			this.NameTxtbox.TabIndex = 8;
			this.NameTxtbox.TextChanged += new System.EventHandler (this.NameTxtbox_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point (133, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size (60, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Save Path:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point (133, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size (48, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Exclude:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point (133, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (32, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Filter:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point (133, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (38, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point (133, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (85, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Filter Settings";
			// 
			// RemoveFilterBtn
			// 
			this.RemoveFilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.RemoveFilterBtn.Location = new System.Drawing.Point (69, 249);
			this.RemoveFilterBtn.Name = "RemoveFilterBtn";
			this.RemoveFilterBtn.Size = new System.Drawing.Size (57, 23);
			this.RemoveFilterBtn.TabIndex = 2;
			this.RemoveFilterBtn.Text = "Remove";
			this.RemoveFilterBtn.UseVisualStyleBackColor = true;
			this.RemoveFilterBtn.Click += new System.EventHandler (this.RemoveFilterBtn_Click);
			// 
			// AddFilterBtn
			// 
			this.AddFilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddFilterBtn.Location = new System.Drawing.Point (6, 249);
			this.AddFilterBtn.Name = "AddFilterBtn";
			this.AddFilterBtn.Size = new System.Drawing.Size (57, 23);
			this.AddFilterBtn.TabIndex = 1;
			this.AddFilterBtn.Text = "Add";
			this.AddFilterBtn.UseVisualStyleBackColor = true;
			this.AddFilterBtn.Click += new System.EventHandler (this.AddFilterBtn_Click);
			// 
			// FilterListbox
			// 
			this.FilterListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.FilterListbox.FormattingEnabled = true;
			this.FilterListbox.Location = new System.Drawing.Point (7, 7);
			this.FilterListbox.Name = "FilterListbox";
			this.FilterListbox.Size = new System.Drawing.Size (120, 238);
			this.FilterListbox.TabIndex = 0;
			this.FilterListbox.SelectedIndexChanged += new System.EventHandler (this.FilterListbox_SelectedIndexChanged);
			// 
			// TorrentsTabPage
			// 
			this.TorrentsTabPage.Controls.Add (this.RefreshTorrentBtn);
			this.TorrentsTabPage.Controls.Add (this.TorrentListBox);
			this.TorrentsTabPage.Controls.Add (this.TorrentsFeedCombo);
			this.TorrentsTabPage.Location = new System.Drawing.Point (4, 22);
			this.TorrentsTabPage.Name = "TorrentsTabPage";
			this.TorrentsTabPage.Size = new System.Drawing.Size (506, 278);
			this.TorrentsTabPage.TabIndex = 2;
			this.TorrentsTabPage.Text = "Torrents";
			this.TorrentsTabPage.UseVisualStyleBackColor = true;
			// 
			// RefreshTorrentBtn
			// 
			this.RefreshTorrentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RefreshTorrentBtn.Location = new System.Drawing.Point (419, 2);
			this.RefreshTorrentBtn.Name = "RefreshTorrentBtn";
			this.RefreshTorrentBtn.Size = new System.Drawing.Size (84, 23);
			this.RefreshTorrentBtn.TabIndex = 2;
			this.RefreshTorrentBtn.Text = "Refresh";
			this.RefreshTorrentBtn.UseVisualStyleBackColor = true;
			this.RefreshTorrentBtn.Click += new System.EventHandler (this.RefreshTorrentBtn_Click);
			// 
			// TorrentListBox
			// 
			this.TorrentListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TorrentListBox.FormattingEnabled = true;
			this.TorrentListBox.Location = new System.Drawing.Point (4, 32);
			this.TorrentListBox.Name = "TorrentListBox";
			this.TorrentListBox.Size = new System.Drawing.Size (499, 238);
			this.TorrentListBox.TabIndex = 1;
			this.TorrentListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler (this.TorrentListBox_MouseDoubleClick);
			// 
			// TorrentsFeedCombo
			// 
			this.TorrentsFeedCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TorrentsFeedCombo.FormattingEnabled = true;
			this.TorrentsFeedCombo.Location = new System.Drawing.Point (4, 4);
			this.TorrentsFeedCombo.Name = "TorrentsFeedCombo";
			this.TorrentsFeedCombo.Size = new System.Drawing.Size (409, 21);
			this.TorrentsFeedCombo.TabIndex = 0;
			this.TorrentsFeedCombo.SelectedIndexChanged += new System.EventHandler (this.TorrentsFeedCombo_SelectedIndexChanged);
			// 
			// HistoryTabPage
			// 
			this.HistoryTabPage.Controls.Add (this.ClearHistoryBtn);
			this.HistoryTabPage.Controls.Add (this.RemoveHistoryBtn);
			this.HistoryTabPage.Controls.Add (this.HistoryListbox);
			this.HistoryTabPage.Location = new System.Drawing.Point (4, 22);
			this.HistoryTabPage.Name = "HistoryTabPage";
			this.HistoryTabPage.Size = new System.Drawing.Size (506, 278);
			this.HistoryTabPage.TabIndex = 3;
			this.HistoryTabPage.Text = "History";
			this.HistoryTabPage.UseVisualStyleBackColor = true;
			// 
			// ClearHistoryBtn
			// 
			this.ClearHistoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearHistoryBtn.Location = new System.Drawing.Point (428, 37);
			this.ClearHistoryBtn.Name = "ClearHistoryBtn";
			this.ClearHistoryBtn.Size = new System.Drawing.Size (75, 23);
			this.ClearHistoryBtn.TabIndex = 2;
			this.ClearHistoryBtn.Text = "Clear";
			this.ClearHistoryBtn.UseVisualStyleBackColor = true;
			this.ClearHistoryBtn.Click += new System.EventHandler (this.ClearHistoryBtn_Click);
			// 
			// RemoveHistoryBtn
			// 
			this.RemoveHistoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveHistoryBtn.Location = new System.Drawing.Point (428, 8);
			this.RemoveHistoryBtn.Name = "RemoveHistoryBtn";
			this.RemoveHistoryBtn.Size = new System.Drawing.Size (75, 23);
			this.RemoveHistoryBtn.TabIndex = 1;
			this.RemoveHistoryBtn.Text = "Remove";
			this.RemoveHistoryBtn.UseVisualStyleBackColor = true;
			this.RemoveHistoryBtn.Click += new System.EventHandler (this.RemoveHistoryBtn_Click);
			// 
			// HistoryListbox
			// 
			this.HistoryListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HistoryListbox.FormattingEnabled = true;
			this.HistoryListbox.Location = new System.Drawing.Point (3, 8);
			this.HistoryListbox.Name = "HistoryListbox";
			this.HistoryListbox.Size = new System.Drawing.Size (419, 264);
			this.HistoryListbox.TabIndex = 0;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.Location = new System.Drawing.Point (451, 311);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size (75, 23);
			this.CloseBtn.TabIndex = 1;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new System.EventHandler (this.CloseBtn_Click);
			// 
			// RssManagerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (538, 346);
			this.Controls.Add (this.CloseBtn);
			this.Controls.Add (this.tabControl1);
			this.Name = "RssManagerWindow";
			this.Text = "RssManagerWindow";
			this.Load += new System.EventHandler (this.RssManagerWindow_Load);
			this.tabControl1.ResumeLayout (false);
			this.FeedsTabPage.ResumeLayout (false);
			this.FeedsTabPage.PerformLayout ();
			this.FiltersTabPage.ResumeLayout (false);
			this.FiltersTabPage.PerformLayout ();
			this.TorrentsTabPage.ResumeLayout (false);
			this.HistoryTabPage.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage FeedsTabPage;
		private System.Windows.Forms.TabPage FiltersTabPage;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.TabPage TorrentsTabPage;
		private System.Windows.Forms.TabPage HistoryTabPage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox feedtxtbox;
		private System.Windows.Forms.ListBox FeedListbox;
		private System.Windows.Forms.Button RemoveFeedBtn;
		private System.Windows.Forms.Button AddFeedBtn;
		private System.Windows.Forms.Button RefreshTorrentBtn;
		private System.Windows.Forms.ListBox TorrentListBox;
		private System.Windows.Forms.ComboBox TorrentsFeedCombo;
		private System.Windows.Forms.Button RemoveHistoryBtn;
		private System.Windows.Forms.ListBox HistoryListbox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox FilterFeedCombo;
		private System.Windows.Forms.TextBox SavePathTxtbox;
		private System.Windows.Forms.TextBox ExcludeTxtbox;
		private System.Windows.Forms.TextBox FilterTxtbox;
		private System.Windows.Forms.TextBox NameTxtbox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button RemoveFilterBtn;
		private System.Windows.Forms.Button AddFilterBtn;
		private System.Windows.Forms.ListBox FilterListbox;
		private System.Windows.Forms.Button ClearHistoryBtn;
		private System.Windows.Forms.Button BrowseBtn;
	}
}