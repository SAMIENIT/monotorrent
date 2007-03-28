using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MonoTorrent.GUI.View
{
    public partial class CreateWindow : Form
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void FromPathBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "From Path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FromPathTextBox.Text = dialog.SelectedPath;
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
            // TODO
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}