using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;

namespace MonoTorrent.GUI.View
{
    public partial class TorrentSettingWindow : Form
    {
        public TorrentSettingWindow()
        {
            InitializeComponent();
        }
        public TorrentSettingWindow(TorrentSettings defaultSettings, string savePath)
        {
            InitializeComponent();
            UploadSlotsNumericUpDown.Value = defaultSettings.UploadSlots;
            MaxConnectionsNumericUpDown.Value = defaultSettings.MaxConnections;
            MaxDownloadSpeedNumericUpDown.Value = defaultSettings.MaxDownloadSpeed;
            MaxUploadSpeedNumericUpDown.Value = defaultSettings.MaxUploadSpeed;
            FastResumeCheckBox.Checked = defaultSettings.FastResumeEnabled;
            SavePathTextBox.Text = savePath;
        }
        public TorrentSettings Settings
        {
            get { return new TorrentSettings(Convert.ToInt32(UploadSlotsNumericUpDown.Value),
                                            Convert.ToInt32(MaxConnectionsNumericUpDown.Value),
                                            Convert.ToInt32(MaxDownloadSpeedNumericUpDown.Value),
                                            Convert.ToInt32(MaxUploadSpeedNumericUpDown.Value),
                                            FastResumeCheckBox.Checked); }
        }

        public string SavePath
        {
            get { return SavePathTextBox.Text; }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Save Path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}