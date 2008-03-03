using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.GUI.Controller;
using Utilities;

namespace MonoTorrent.GUI.View
{
	public partial class MiniWindow : Form
	{
        private MainController controller;

		public MiniWindow(MainController mainController)
		{
            InitializeComponent();
            this.controller = mainController;
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
		}

        public Control.ImageListView ListView
        {
            get { return MiniListView; }
        }

        private void MiniWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.switchToMiniWindow(false);
            e.Cancel = true;
        }
    }
}