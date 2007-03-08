using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;
using MonoTorrent.Common;

namespace MonoTorrent.GUI
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
            this.splitContainer1.SplitterMoved += new SplitterEventHandler(splitContainer1_SplitterMoved);
            this.torrentsView.Items.Add(new ListViewItem("testesttest"));
            this.managers = new List<TorrentManager>();
            this.engine = new ClientEngine(EngineSettings.DefaultSettings(), TorrentSettings.DefaultSettings());
            SetSplitWindowSize();
        }

        void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SetSplitWindowSize();
        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
            SetSplitWindowSize();
        }


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


        private void SetSplitWindowSize()
        {
            // First i have to set the height and width of my split box correctly.
            this.splitContainer1.Height = this.Height - this.statusBar.Height
                                          - this.menuBar.Height - panelMainControls.Height - 36;
            this.splitContainer1.Width = this.Width - 8;

            // Then make sure that torrentsview and details view are the right width
            this.torrentsView.Width = this.splitContainer1.Width;
            this.detailsView.Width = this.splitContainer1.Width;


            this.trackerPanel.Width = this.splitContainer1.Width - this.trackerPanel.Location.X * 4;
            this.generalPanel.Width = this.splitContainer1.Width - this.trackerPanel.Location.X * 4;

            // Now i calculate what height they should each be
            this.torrentsView.Height = (int)(this.splitContainer1.Height * ((float)this.splitContainer1.SplitterDistance / this.splitContainer1.Height)
                                       - this.splitContainer1.SplitterWidth);
            this.detailsView.Height = (int)(this.splitContainer1.Height * (1.0f - (float)this.splitContainer1.SplitterDistance / this.splitContainer1.Height)
                                       - this.splitContainer1.SplitterWidth);

        }
    }
}
