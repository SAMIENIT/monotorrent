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
using Utilities;

namespace MonoTorrent.GUI.View
{
    public partial class OptionWindow : Form
    {
        private MainController controller;

        public OptionWindow()
        {
            InitializeComponent();
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
        }

        public OptionWindow(MainController mainController, SettingsBase settings)
        {
            InitializeComponent();
            this.controller = mainController;
            this.Icon = MonoTorrent.GUI.Properties.Resources.mono;
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

        private void AssociateButton_Click(object sender, EventArgs e)
        {
            // Should you do a platform check to make sure you're on windows?
            try
            {
                string rootKey = "MonoTorrent.torrent";
                Microsoft.Win32.RegistryKey RegKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(".torrent");
                RegKey.SetValue("", rootKey);
                RegKey.Close();

                RegKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(rootKey);
                RegKey.SetValue("", "Torrent Metadata");
                RegKey.Close();

                // Add icon
                RegKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(rootKey + "\\DefaultIcon");
                RegKey.SetValue("", "\"" + Application.ExecutablePath + "\",0");
                RegKey.Close();

                // Add command
                RegKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(rootKey + "\\Shell\\open\\Command");
                RegKey.SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                RegKey.Close();

            }
            catch (System.Security.SecurityException se)
            {
                MessageBox.Show("Can't write to the registry! \r\n" + se.ToString());
                return;
            }
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

			GuiGeneralSettings settings = new GuiGeneralSettings();

			try
			{
				settings.GlobalMaxConnections = Convert.ToInt32(MaxConnectionsNumericUpDown.Value);
				settings.GlobalMaxDownloadSpeed = Convert.ToInt32(MaxDownloadSpeedNumericUpDown.Value);
				settings.GlobalMaxHalfOpenConnections = Convert.ToInt32(HalfOpenConnectionsNumericUpDown.Value);
				settings.GlobalMaxUploadSpeed = Convert.ToInt32(MaxUploadSpeedNumericUpDown.Value);
				settings.ListenPort = Convert.ToInt32(ListenPortNumericUpDown.Value);
			}
			catch (FormatException ex)
			{
				MessageBox.Show("You must set a number! \r\n" + ex.ToString());
				return;
			}
			settings.SavePath = SavePathTextBox.Text;
			settings.TorrentsPath = TorrentPathTextBox.Text;
			settings.UsePnP = UseUPnPCheckBox.Checked;
			controller.UpdateGeneralSettings(settings);
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