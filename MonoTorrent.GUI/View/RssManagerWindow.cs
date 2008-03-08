using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MonoTorrent.GUI.Controller;
using MonoTorrent.GUI.Helper;

namespace MonoTorrent.GUI.View
{
	public partial class RssManagerWindow : Form
	{
		private RssManagerController controller;
		private BackgroundWorker fetchFeedsWorker;

		public RssManagerWindow (RssManagerController controller)
		{
			InitializeComponent ();
			this.controller = controller;
		}
		
		private void RssManagerWindow_Load (object sender, EventArgs e)
		{
			FilterFeedCombo.Items.Add ("All");
			FilterFeedCombo.SelectedIndex = 0;
			TorrentsFeedCombo.Items.Add ("All");
			TorrentsFeedCombo.SelectedIndex = 0;
			Restore ();
		}

		private void Restore ()
		{
			fetchFeedsWorker = new BackgroundWorker ();
			fetchFeedsWorker.DoWork += FetchFeeds;
			fetchFeedsWorker.RunWorkerCompleted += FetchFeedsCompleted;

			foreach (string feed in controller.Feeds) {
				FilterFeedCombo.Items.Add (feed);
				TorrentsFeedCombo.Items.Add (feed);
				FeedListbox.Items.Add (feed);
			}

			foreach (RssFilter filter in controller.Filters) {
				FilterListbox.Items.Add (filter);
			}

			foreach (RssItem item in controller.Items) {
				TorrentListBox.Items.Add (item);
			}

			foreach (RssItem histoItem in controller.History) {
				HistoryListbox.Items.Add (histoItem);
			}

			UpdateFeeds ();
		}

		private void UpdateFeeds ()
		{
			if (!fetchFeedsWorker.IsBusy)
				fetchFeedsWorker.RunWorkerAsync ();
		}


		private void FetchFeeds (object sender, DoWorkEventArgs args)
		{
			controller.Items.Clear ();

			foreach (string feed in controller.Feeds) {
				RssReader rssReader = new RssReader (feed);

				foreach (RssItem item in rssReader.Items) {
					controller.Items.Add (item);
				}
			}
		}


		private void FetchFeedsCompleted (object sender, RunWorkerCompletedEventArgs args)
		{
			this.Invoke (new updhandler(UpdateTorrentList));
		}

		private delegate void updhandler();

		private void UpdateTorrentList ()
		{
			TorrentListBox.Items.Clear ();
			foreach (RssItem item in controller.Items) {
				string tfeed = TorrentsFeedCombo.SelectedItem.ToString ();
				if (tfeed == "All" || item.Feed == tfeed)
					TorrentListBox.Items.Add (item);
			}
		}

		private void RemoveFeedBtn_Click (object sender, EventArgs e)
		{
			object item = FeedListbox.SelectedItem;
			FilterFeedCombo.Items.Remove (item);
			TorrentsFeedCombo.Items.Remove (item);
			FeedListbox.Items.Remove (item);
			controller.RemoveWatcher (item.ToString());
		}

		private void AddFeedBtn_Click (object sender, EventArgs e)
		{
			AddFeed (feedtxtbox.Text);
		}

		public void AddFeed (string feed)
		{
			FilterFeedCombo.Items.Add (feed);
			TorrentsFeedCombo.Items.Add (feed);
			FeedListbox.Items.Add (feed);
			controller.AddWatcher (feed);
		}

		private void CloseBtn_Click (object sender, EventArgs e)
		{
			this.Close ();
		}

		private void BrowseBtn_Click (object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog ();
			dialog.Description = "Save Path";
			if (dialog.ShowDialog () == DialogResult.OK) {
				SavePathTxtbox.Text = dialog.SelectedPath;
			}
		}

		private void AddFilterBtn_Click (object sender, EventArgs e)
		{
			RssFilter rssfilter = new RssFilter ();
			//filter.SavePath = controler.engine.Settings.SavePath;
			FilterListbox.Items.Add (rssfilter);
			controller.AddFilter (rssfilter);
		}

		private void RemoveFilterBtn_Click (object sender, EventArgs e)
		{
			RssFilter rssfilter = (RssFilter)FilterListbox.SelectedItem;
			controller.RemoveFilter (rssfilter);
			FilterListbox.Items.Remove (rssfilter);
		}

		private void RefreshTorrentBtn_Click (object sender, EventArgs e)
		{
			UpdateFeeds ();
		}

		private void RemoveHistoryBtn_Click (object sender, EventArgs e)
		{
			RssItem item = (RssItem)HistoryListbox.SelectedItem;
			controller.History.Remove (item);
			HistoryListbox.Items.Remove (item);			
		}

		private void ClearHistoryBtn_Click (object sender, EventArgs e)
		{
			HistoryListbox.Items.Clear ();
			controller.History.Clear ();
		}

		private void FilterListbox_SelectedIndexChanged (object sender, EventArgs e)
		{
			RssFilter filter = FilterListbox.SelectedItem as RssFilter;
			if (filter == null)
				return;
			NameTxtbox.Text = filter.Name;
			FilterTxtbox.Text = filter.Include;
			ExcludeTxtbox.Text = filter.Exclude;
			SavePathTxtbox.Text = filter.SavePath;
			FilterFeedCombo.SelectedValue = filter.Feed;
		}

		private void TorrentsFeedCombo_SelectedIndexChanged (object sender, EventArgs e)
		{
			UpdateTorrentList ();
		}

		private void TorrentListBox_MouseDoubleClick (object sender, MouseEventArgs e)
		{
			controller.AddTorrent ((RssItem)TorrentListBox.SelectedItem, null);
		}

		private void NameTxtbox_TextChanged (object sender, EventArgs e)
		{
			RssFilter filter = FilterListbox.SelectedItem as RssFilter;
			if (filter == null)
				return;
			filter.Name = NameTxtbox.Text;
			FilterListbox.Items[FilterListbox.SelectedIndex] = filter;
		}

		private void FilterTxtbox_TextChanged (object sender, EventArgs e)
		{
			RssFilter filter = FilterListbox.SelectedItem as RssFilter;
			if (filter == null)
				return;
			filter.Include = FilterTxtbox.Text;
		}

		private void ExcludeTxtbox_TextChanged (object sender, EventArgs e)
		{
			RssFilter filter = FilterListbox.SelectedItem as RssFilter;
			if (filter == null)
				return;
			filter.Exclude = ExcludeTxtbox.Text;
		}

		private void SavePathTxtbox_TextChanged (object sender, EventArgs e)
		{
			RssFilter filter = FilterListbox.SelectedItem as RssFilter;
			if (filter == null)
				return;
			filter.SavePath = SavePathTxtbox.Text;
		}

		private void FilterFeedCombo_SelectedIndexChanged (object sender, EventArgs e)
		{
			RssFilter filter = FilterListbox.SelectedItem as RssFilter;
			if (filter == null)
				return;
			filter.Feed = FilterFeedCombo.SelectedText;
		}
	}
}
//http://www.torrentvalley.com/rss.php?c=1&sc=2