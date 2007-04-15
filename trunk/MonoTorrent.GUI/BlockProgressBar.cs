using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;
using System.Drawing;

namespace MonoTorrent.GUI
{
    public class BlockProgressBar : Control
    {
        private Piece piece;

        public BlockProgressBar(Piece piece)
        {
            this.piece = piece;
            this.Height = 16;
            this.Width = 256;
        }

        SolidBrush requestedBrush = new SolidBrush(Color.Red);          // Requested
        SolidBrush receivedBrush = new SolidBrush(Color.Blue);          // In Memory
        SolidBrush writtenBrush = new SolidBrush(Color.Green);          // Written
        SolidBrush notRequestedBrush = new SolidBrush(Color.Yellow);     // Not requested


        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                Rectangle rect = this.ClientRectangle;
                int width = rect.Width / this.piece.BlockCount;
                for (int i = 0; i < this.piece.BlockCount; i++)
                {
                    rect = new Rectangle(width * i, rect.Y, width, rect.Height);
                    if (piece[i].Written)
                        g.FillRectangle(writtenBrush, rect);

                    else if (piece[i].Received)
                        g.FillRectangle(receivedBrush, rect);

                    else if (piece[i].Requested)
                        g.FillRectangle(requestedBrush, rect);

                    else
                        g.FillRectangle(notRequestedBrush, rect);
                }
            }
        }
    }
}
