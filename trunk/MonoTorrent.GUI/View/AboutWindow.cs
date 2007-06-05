using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Utilities;

namespace MonoTorrent.GUI.View
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
			label4.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Icon = ResourceHandler.GetIcon("mono", 16, 16);
        }
    }
}