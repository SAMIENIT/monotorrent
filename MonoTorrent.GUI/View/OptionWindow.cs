using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MonoTorrent.GUI.Settings;
using MonoTorrent.GUI.Controller;

namespace MonoTorrent.GUI.View
{
    public partial class OptionWindow : Form
    {
        private MainController controller;

        public OptionWindow()
        {
            InitializeComponent();
        }

        public OptionWindow(MainController mainController, SettingsBase settings)
        {
            InitializeComponent();
            this.controller = mainController;
            GuiGeneralSettings genSettings = settings.LoadSettings<GuiGeneralSettings>("General Settings");
            MaxConnectionsNumericUpDown.Value = genSettings.GlobalMaxConnections;
            MaxDownloadSpeedNumericUpDown.Value = genSettings.GlobalMaxDownloadSpeed;
            HalfOpenConnectionsNumericUpDown.Value = genSettings.GlobalMaxHalfOpenConnections;
            MaxUploadSpeedNumericUpDown.Value = genSettings.GlobalMaxUploadSpeed;
            ListenPortNumericUpDown.Value = genSettings.ListenPort;
            SavePathTextBox.Text = genSettings.SavePath;
            TorrentPathTextBox.Text = genSettings.TorrentsPath;
            UseUPnPCheckBox.Checked = genSettings.UsePnP;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SavePathTextBox.Text))
            {
                MessageBox.Show("Bad Save Path");
                return;
            }
            if (!Directory.Exists(TorrentPathTextBox.Text))
            {
                MessageBox.Show("Bad torrents Path");
                return;
            }
            //TODO check updowns
            GuiGeneralSettings settings = new GuiGeneralSettings();
            settings.GlobalMaxConnections = Convert.ToInt32(MaxConnectionsNumericUpDown.Value);
            settings.GlobalMaxDownloadSpeed = Convert.ToInt32(MaxDownloadSpeedNumericUpDown.Value);
            settings.GlobalMaxHalfOpenConnections = Convert.ToInt32(HalfOpenConnectionsNumericUpDown.Value);
            settings.GlobalMaxUploadSpeed = Convert.ToInt32(MaxUploadSpeedNumericUpDown.Value);
            settings.ListenPort = Convert.ToInt32(ListenPortNumericUpDown.Value);
            settings.SavePath = SavePathTextBox.Text;
            settings.TorrentsPath = TorrentPathTextBox.Text;
            settings.UsePnP = UseUPnPCheckBox.Checked;
            controller.UpdateSettings(settings);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SavePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Save Path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void TorrentsPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Torrent Path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TorrentPathTextBox.Text = dialog.SelectedPath;
            }
        }

        #region Helpers

        private bool IsNumber(string str)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(str);
            }
            catch
            {
                return false;
            }
            if ( result >= 0 )
                return true;
            return false;
        }

        #endregion
    }
}