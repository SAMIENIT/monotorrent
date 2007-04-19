using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MonoTorrent.GUI.View.Control
{
    public class TorrentProgressBar : IDrawable
    {
        private TorrentManager manager;


        public TorrentProgressBar(TorrentManager manager)
            : base()
        {
            this.manager = manager;
        }

        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Rectangle bounds)
        {
            float length = (float)this.manager.Progress / 100.0f;
            using (SolidBrush blue = new SolidBrush(Color.CornflowerBlue))
            using (SolidBrush green = new SolidBrush(Color.LimeGreen))
            {
                graphics.FillRectangle(green, bounds.X, bounds.Y, bounds.Width * length, bounds.Height);
                graphics.FillRectangle(blue, bounds.X + (bounds.Width * length), bounds.Y, bounds.Width - bounds.Width * length, bounds.Height);
            }
        }
    }
}