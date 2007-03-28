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

namespace MonoTorrent.GUI.View
{
    public partial class MainWindow : Form
    {
        private MainController mainController;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SettingsBase settings = new SettingsBase();
            GuiViewSettings guisettings = settings.LoadSettings<GuiViewSettings>("Graphical Settings");
            this.Width = guisettings.FormWidth;
            this.Height = guisettings.FormHeight;
            splitContainer1.SplitterDistance = guisettings.SplitterDistance;
            tabGeneral.VerticalScroll.Value = guisettings.VScrollValue;
            tabGeneral.HorizontalScroll.Value = guisettings.HScrollValue;
            mainController = new MainController(torrentsView, settings);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsBase settings = new SettingsBase();
            GuiViewSettings guisettings = new GuiViewSettings();
            guisettings.FormWidth = this.Width;
            guisettings.FormHeight = this.Height;
            guisettings.SplitterDistance = splitContainer1.SplitterDistance;
            guisettings.VScrollValue = tabGeneral.VerticalScroll.Value;
            guisettings.HScrollValue = tabGeneral.HorizontalScroll.Value;
            settings.SaveSettings<GuiViewSettings>("Graphical Settings", guisettings);
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
            if (showToolbarToolStripMenuItem.Checked == true)
            {
                MaintoolStrip.Hide();
                splitContainer1.Dock = DockStyle.Fill;
                showToolbarToolStripMenuItem.Checked = false;
            }
            else
            {
                MaintoolStrip.Show();
                splitContainer1.Dock = DockStyle.None;
                splitContainer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                showToolbarToolStripMenuItem.Checked = true;
            }
        }

        private void showDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showDetailToolStripMenuItem.Checked == true)
            {
                //TODO : FIXME : find a way to hide the entire panel
                splitContainer1.Panel2.Hide();
                splitContainer1.SplitterDistance = 100000;
                showDetailToolStripMenuItem.Checked = false;
            }
            else
            {
                splitContainer1.Panel2.Show();
                splitContainer1.SplitterDistance = 100;
                showDetailToolStripMenuItem.Checked = true;
            }
        }

        private void showStatusbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showStatusbarToolStripMenuItem.Checked == true)
            {
                statusBar.Hide();
                showStatusbarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusBar.Show();
                showStatusbarToolStripMenuItem.Checked = true;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Stop();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Pause();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Up();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.Down();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.About();
        }

        #endregion



    }
}
