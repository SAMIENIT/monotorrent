using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MonoTorrent.GUI
{
    public class StandardProgressBar : IDrawable
    {
        private TorrentManager manager;


        public StandardProgressBar(TorrentManager manager)
            : base()
        {
            this.manager = manager;
        }

        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Rectangle bounds)
        {
            float length = (float)this.manager.Progress / 100.0f;
            using (SolidBrush blue = new SolidBrush(Color.Blue))
            using (SolidBrush green = new SolidBrush(Color.Green))
            {
                graphics.FillRectangle(green, bounds.X, bounds.Y, bounds.Width * length, bounds.Height);
                graphics.FillRectangle(blue, bounds.X + (bounds.Width * length), bounds.Y, bounds.Width - bounds.Width * length, bounds.Height);
            }
        }
    }
}