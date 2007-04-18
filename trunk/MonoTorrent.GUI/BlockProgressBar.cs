using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Client;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MonoTorrent.GUI
{
    class BlockProgressBar : IDrawable
    {
        private BlockEventArgs args;

        public BlockProgressBar(BlockEventArgs piece)
        {
            this.args = piece;
        }

        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Rectangle bounds)
        {
            using (SolidBrush requestedBrush = new SolidBrush(Color.Red))          // Requested
            using (SolidBrush receivedBrush = new SolidBrush(Color.Blue))          // In Memory
            using (SolidBrush writtenBrush = new SolidBrush(Color.Green))          // Written
            using (SolidBrush notRequestedBrush = new SolidBrush(Color.Yellow))    // Not requested
            {
                Rectangle rect = bounds;
                float width = (float)rect.Width / args.Piece.BlockCount;
                for (int i = 0; i < this.args.Piece.BlockCount; i++)
                {
                    RectangleF newArea = new RectangleF(rect.X + (width * i), rect.Y, width, rect.Height);
                    if (args.Piece[i].Written)
                        graphics.FillRectangle(writtenBrush, newArea);

                    else if (args.Piece[i].Received)
                        graphics.FillRectangle(receivedBrush, newArea);

                    else if (args.Piece[i].Requested)
                        graphics.FillRectangle(requestedBrush, newArea);

                    else
                        graphics.FillRectangle(notRequestedBrush, newArea);
                }
            }
        }
    }
}
