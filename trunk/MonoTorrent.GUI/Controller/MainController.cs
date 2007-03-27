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
        private ListView torrentsView;
        private IDictionary<ListViewItem, TorrentManager> itemToTorrent;
        private SettingsBase settingsBase;

        public MainController(ListView torrentsView, SettingsBase settings)
        {
            this.torrentsView = torrentsView;
            this.settingsBase = settings;
            itemToTorrent = new Dictionary<ListViewItem, TorrentManager>();

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

        }


        #region Helper

        /// <summary>
        /// get all row selected in list view
        /// </summary>
        /// <returns></returns>
        public IList<TorrentManager> GetSelectedTorrents()
        {
            IList<TorrentManager> result = new List<TorrentManager>();
            foreach (ListViewItem item in torrentsView.SelectedItems)
                result.Add(itemToTorrent[item]);
            return result;
        }

        private delegate void UpdateHandler(TorrentManager torrent);

        /// <summary>
        /// update torrent in gui
        /// </summary>
        /// <param name="torrent"></param>
        public void Update(TorrentManager torrent)
        {
            ListViewItem item = GetItemFromTorrent(torrent);
            item.SubItems[0].Text = torrent.Torrent.Name;
            item.SubItems[1].Text = torrent.Torrent.Size.ToString();
            UpdateState(torrent);
        }

        /// <summary>
        /// update torretn state in view
        /// </summary>
        /// <param name="torrent"></param>
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
            torrentsView.Invoke(new UpdateHandler(Update), torrent);
        }

        /// <summary>
        /// event torrent state change
        /// </summary>
        /// <param name="sender">TorrentManager</param>
        /// <param name="args"></param>
        private void OnTorrentStateChange(object sender, EventArgs args)
        {
            TorrentManager torrent = (TorrentManager)sender;
            torrentsView.Invoke(new UpdateHandler(UpdateState), torrent);
        }

        #endregion

        #region Controller Action

        public void Create()
        {
            string storagePath = Environment.CurrentDirectory;
            TorrentCreator creator = new TorrentCreator();

            creator.Create(storagePath);
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
            ListViewItem item = new ListViewItem(newPath);
            for (int i = 0; i < 10; i++)
                item.SubItems.Add("");
            torrentsView.Items.Add(item);
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
                optionWindow = new OptionWindow(this, settingsBase);
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
