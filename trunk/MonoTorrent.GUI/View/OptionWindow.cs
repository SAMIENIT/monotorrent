using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections.Specialized;
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
        private MainWindow mainWindow;
        private Bitmap DefaultButtons;
        private string ButtonsDir = string.Empty;
        private StringCollection Buttons = new StringCollection();

        public OptionWindow()
        {
            InitializeComponent();
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
            GetButtonImages();
        }

        public OptionWindow(MainWindow mainWindow, MainController mainController, SettingsBase settings)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.controller = mainController;
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
            GetButtonImages();

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

        #region General

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
			mainWindow.UpdateGeneralSettings(settings);
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

        #endregion

        #region Appearances

        /// <summary>
        /// Gets all button images in the Resources\Buttons subdir
        /// </summary>
        private void GetButtonImages()
        {
            string fileSelected = GuiViewSettings.CustomButtonPath;
            string fileName = string.Empty;
            string fileExt = string.Empty;
            int selectIndex = 0;
            
            // Add default item to the listbox
            lstButtons.Items.Clear();
            lstButtons.Items.Add("[default]");

            ButtonsDir = Path.Combine(Application.StartupPath, @"Resources\Buttons");
            if (Directory.Exists(ButtonsDir))
            {
                
                string[] BtnFiles = Global.GetFiles(ButtonsDir, new string[] { "*.bmp", "*.jpg", "*.gif", "*.png", "*.jpeg" });
                for (int i = 0; i < BtnFiles.Length; i++)
                {
                    try
                    {
                        // Create a bitmap object, just to verify this is an image
                        Bitmap bmp = new Bitmap(BtnFiles[i]);
                        FileInfo fi = new FileInfo(BtnFiles[i]);
                        fileExt = fi.Extension;
                        fileName = fi.Name.Replace(fileExt, "").Replace("_", " ");
                        // Add to the Buttons StringCollection and listbox
                        Buttons.Add(BtnFiles[i]);
                        lstButtons.Items.Add(fileName);
                        // Select this item in the listbox
                        if (fileSelected == BtnFiles[i])
                            selectIndex = i + 1;
                    }
                    catch
                    {
                        // Skip: this is not an image
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(ButtonsDir);
            }

            lstButtons.SelectedIndex = selectIndex;
        }

        private void lstButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show example in picturebox
            if (lstButtons.SelectedIndex == 0)
            {
                // Show the default buttons
                picExample.Image = GetDefaultButtons();
            }
            else
            {
                // Show the selected buttons image
                string bmpPath = Path.Combine(ButtonsDir, Buttons[lstButtons.SelectedIndex - 1]);
                if (File.Exists(bmpPath))
                {
                    Bitmap bmp = new Bitmap(bmpPath);
                    if (bmp.Width > picExample.Width)
                    {
                        // Trim bitmap to prevent clipping: show only whole buttons
                        int h = bmp.Height;
                        int w = picExample.Width - (picExample.Width % h);
                        bmp = (Bitmap)Global.GetSquareFromImage(bmp, 0, 0, w, h);
                    }
                    picExample.Image = (Image)bmp;
                }
            }
        }

        /// <summary>
        /// Creates a bitmap of all default buttons from the resource file
        /// </summary>
        /// <returns>Image</returns>
        private Image GetDefaultButtons()
        {
            // Get height of image
            if (DefaultButtons == null)
            {
                Image img = ResourceHandler.GetImage("list_add");
                int sz = img.Height;

                // Create new image of buttons
                DefaultButtons = new Bitmap((11 * sz), sz);
                Graphics grs = Graphics.FromImage(DefaultButtons);
                grs.DrawImage(img, 0, 0);
                grs.DrawImage(ResourceHandler.GetImage("list_add_url"), sz, 0);
                grs.DrawImage(ResourceHandler.GetImage("document_new"), (2 * sz), 0);
                grs.DrawImage(ResourceHandler.GetImage("list_remove"), (3 * sz), 0);
                grs.DrawImage(ResourceHandler.GetImage("media_playback_start"), (4 * sz), 0);
                grs.DrawImage(ResourceHandler.GetImage("media_playback_pause"), (5 * sz), 0);
                grs.DrawImage(ResourceHandler.GetImage("media_playback_stop"), (6 * sz), 0);
                grs.DrawImage(ResourceHandler.GetImage("go_up"), (7 * sz), 0);
                grs.DrawImage(ResourceHandler.GetImage("go_down"), (8 * sz), 0);
            }

            return (Image)DefaultButtons;
        }

        private void QuitButtonApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButtonApp_Click(object sender, EventArgs e)
        {
            // Save settings
            GuiViewSettings guisettings = new GuiViewSettings();
            string btnPath = string.Empty;
            if (lstButtons.SelectedIndex > 0)
                btnPath = Buttons[lstButtons.SelectedIndex - 1];
            GuiViewSettings.CustomButtonPath = btnPath;
            SettingsBase settingsBase = new SettingsBase();
            settingsBase.SaveSettings<GuiViewSettings>("Graphical Settings", guisettings);

            this.mainWindow.LoadButtons();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

    }
}