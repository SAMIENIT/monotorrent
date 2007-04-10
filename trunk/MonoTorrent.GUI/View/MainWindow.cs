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

		#region properties

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
		/// tab pieces list ( not used actually)
		/// </summary>
		public ListView PiecesListView
		{
			get { return this.piecesListView; }
		}
		
		/// <summary>
		/// main view
		/// </summary>
		public ListView TorrentsView
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

		#endregion

		private void MainWindow_Load(object sender, EventArgs e)
        {
            //recover all gui settings
            SettingsBase settings = new SettingsBase();
            GuiViewSettings guisettings = settings.LoadSettings<GuiViewSettings>("Graphical Settings");
            this.Width = guisettings.FormWidth;
            this.Height = guisettings.FormHeight;
            splitContainer1.SplitterDistance = guisettings.SplitterDistance;
            tabGeneral.VerticalScroll.Value = guisettings.VScrollValue;
            tabGeneral.HorizontalScroll.Value = guisettings.HScrollValue;
            // show/Hide component of GUI
            ShowStatusBar(guisettings.ShowStatusbar);
            ShowToolBar(guisettings.ShowToolbar);
            ShowDetail(guisettings.ShowDetail);
            
            //load maincontroller
            mainController = new MainController(this, settings);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
			//close client
			mainController.Exit();

            //Save all gui settings
            SettingsBase settings = new SettingsBase();
            GuiViewSettings guisettings = new GuiViewSettings();
            guisettings.FormWidth = this.Width;
            guisettings.FormHeight = this.Height;
            guisettings.SplitterDistance = splitContainer1.SplitterDistance;
            guisettings.VScrollValue = tabGeneral.VerticalScroll.Value;
            guisettings.HScrollValue = tabGeneral.HorizontalScroll.Value;
            guisettings.ShowDetail = showDetailToolStripMenuItem.Checked;
            guisettings.ShowStatusbar = showStatusbarToolStripMenuItem.Checked;
            guisettings.ShowToolbar = showToolbarToolStripMenuItem.Checked;
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

        /// <summary>
        /// Show or hide toolbar
        /// </summary>
        /// <param name="check">if true show else Hide</param>
        private void ShowToolBar(bool check)
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
        private void ShowDetail(bool check)
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
        private void ShowStatusBar(bool check)
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

		private void torrentsView_SelectedIndexChanged(object sender, EventArgs e)
		{
			mainController.UpdateGeneralTab();
			mainController.UpdatePiecesTab();
			mainController.UpdateDetailTab();
		}
    }
}
