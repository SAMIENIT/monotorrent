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
            using (SolidBrush complete = new SolidBrush(Color.Blue))
            using (SolidBrush incomplete = new SolidBrush(Color.White))
            using(StringFormat format = new StringFormat())
            using(SolidBrush text = new SolidBrush(Color.Black))
            {
                format.Alignment = StringAlignment.Center;
                graphics.FillRectangle(complete, bounds.X, bounds.Y, bounds.Width * length, bounds.Height);
                graphics.FillRectangle(incomplete, bounds.X + (bounds.Width * length), bounds.Y, bounds.Width - bounds.Width * length, bounds.Height);
                graphics.DrawString(string.Format("{0:0.00} %",this.manager.Progress), new Font(FontFamily.GenericSansSerif, 7), text, bounds, format); 
            }
        }
    }
}