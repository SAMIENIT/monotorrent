using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace MonoTorrent.GUI.View
{
    public partial class TorrentUrl : Form
    {        
        public TorrentUrl()
        {
            InitializeComponent();
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Global.TorrentPath = txtUrl.Text.Trim();
            this.Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}