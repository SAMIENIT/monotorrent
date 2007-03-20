using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;
using MonoTorrent.Common;
using MonoTorrent.GUI.Settings;

namespace MonoTorrent.GUI.View
{
    public partial class MainWindow : Form
    {
        private List<TorrentManager> managers;
        private ClientEngine engine;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            GuiViewSettings settings = GuiViewSettings.Instance;
            settings.Decode();
            this.Width = settings.FormWidth;
            this.Height = settings.FormHeight;
            splitContainer1.SplitterDistance = settings.SplitterDistance;
            //TEST CODE
            this.torrentsView.Items.Add(new ListViewItem("testesttest"));
            this.managers = new List<TorrentManager>();
            this.engine = new ClientEngine(EngineSettings.DefaultSettings(), TorrentSettings.DefaultSettings());
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuiViewSettings settings = GuiViewSettings.Instance;
            settings.FormWidth = this.Width;
            settings.FormHeight = this.Height;
            settings.SplitterDistance = splitContainer1.SplitterDistance;

            settings.Encode();
        }

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
                        this.managers.Add(this.engine.LoadTorrent(s));
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

        }

        private void StartToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void PauseToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void StopToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void DelToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void OptionToolStripButton_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
