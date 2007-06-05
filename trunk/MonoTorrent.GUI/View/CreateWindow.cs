using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.GUI.Controller;
using System.IO;
using Utilities;

namespace MonoTorrent.GUI.View
{
    public partial class CreateWindow : Form
    {
        private MainController mainController;

        public CreateWindow(MainController controller)
        {
            InitializeComponent();
            mainController = controller;
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
        }

        #region Properties

        private string fromPath;
        public string FromPath
        {
            get { return fromPath; }
        }

        private string saveTo;
        public string SaveTo
        {
            get { return saveTo; }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
        }

        private string createBy;
        public string CreateBy
        {
            get { return createBy; }
        }

        private string trackerURL;
        public string TrackerURL
        {
            get { return trackerURL; }
        }

        #endregion

        private void FromPathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "From Path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FromPathTextBox.Text = dialog.FileName;
            }
        }

        private void SaveToBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Save To";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveToTextBox.Text = dialog.SelectedPath;
            }
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FromPathTextBox.Text))
            {
                MessageBox.Show("Bad from path!");
                return;
            }

            if (!Directory.Exists(SaveToTextBox.Text))
            {
                MessageBox.Show("Bad save to!");
                return;
            }

            fromPath = FromPathTextBox.Text;
            saveTo = SaveToTextBox.Text;
            comment = CommentTextBox.Text;
            createBy = CreateByTextBox.Text;
            trackerURL = TrackerURLTextBox.Text;
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