using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client;
using System.Windows.Forms;
using MonoTorrent.GUI.View;
using MonoTorrent.GUI.Settings;
namespace MonoTorrent.GUI.Controller
{
    class MainController
    {
        private ClientEngine clientEngine;
        private OptionWindow optionWindow;
        private ListView torrentsView;
        private IDictionary<ListViewItem, TorrentManager> itemToTorrent;

        public MainController(ListView torrentsView, SettingsBase settings)
        {
            this.torrentsView = torrentsView;
            clientEngine = new ClientEngine( EngineSettings.DefaultSettings(), TorrentSettings.DefaultSettings());
            itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();
            //TODO settings for engine and torrent in setting system
        }

        #region Helper

        public IList<TorrentManager> GetSelectedTorrents()
        {
            IList<TorrentManager> result = new List<TorrentManager>();
            foreach (ListViewItem item in torrentsView.SelectedItems)
                result.Add(itemToTorrent[item]);
            return result;
        }

        #endregion

        #region Event Methode

        private void OnTorrentChange(object sender, EventArgs args)
        {
            TorrentManager torrent = (TorrentManager)sender;
            Update(torrent);
        }

        private void OnTorrentStateChange(object sender, EventArgs args)
        {
            TorrentManager torrent = (TorrentManager)sender;
            UpdateState(torrent);
        }

        public void Update(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
            item.SubItems[0].Text = torrent.Torrent.Name;
            item.SubItems[1].Text = torrent.Torrent.Size.ToString();
            UpdateState(torrent);
        }

        public void UpdateState(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
            item.SubItems[2].Text = torrent.Progress.ToString();
            item.SubItems[3].Text = torrent.State.ToString();
            item.SubItems[4].Text = torrent.Seeds().ToString();
            item.SubItems[5].Text = torrent.Leechs().ToString();
            item.SubItems[6].Text = torrent.DownloadSpeed().ToString();
            item.SubItems[7].Text = torrent.UploadSpeed().ToString();
            item.SubItems[8].Text = torrent.Monitor.DataBytesDownloaded.ToString();
            item.SubItems[9].Text = torrent.Monitor.DataBytesUploaded.ToString();
            item.SubItems[10].Text = torrent.AvailablePeers.ToString();//FIXME ratio here

        }

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

        #region Controller Action

        //TODO NEW TORRENT (TorrentCreator)

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
            ListViewItem item = new ListViewItem(fileName);
            torrentsView.Items.Add(item);
            TorrentManager torrent = clientEngine.LoadTorrent(fileName);
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
                        clientEngine.Remove(torrent);
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
                    clientEngine.Start(torrent);
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
                    clientEngine.Stop(torrent);
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
                    clientEngine.Pause(torrent);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Stop :" + e.ToString());
            }
        }

        public void Option()
        {
            if (optionWindow == null)
            {
                optionWindow = new OptionWindow();
                optionWindow.Show();
            }
        }

        public void Up()
        {
            //TODO move up in prior
        }

        public void Down()
        {
            //TODO move down in prior
        }

        #endregion
    }
}
