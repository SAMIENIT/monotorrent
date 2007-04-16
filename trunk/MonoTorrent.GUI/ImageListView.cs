using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;
using System.Drawing;

namespace MonoTorrent.GUI
{
    public class ImageListView : ListView
    {
        private List<BlockEventArgs> Pieces = new List<BlockEventArgs>();

        public void Add(BlockEventArgs e)
        {
            for (int i = 0; i < this.Pieces.Count; i++)

                if (this.Pieces[i].Piece.Index == e.Piece.Index)
                    return;

            this.Pieces.Add(e);
            this.Items.Add(CreatePiecesListItem(e));
        }

        public void Remove(BlockEventArgs e)
        {
            for (int i = 0; i < this.Pieces.Count; i++)
            {
                if (this.Pieces[i].Piece.Index != e.Piece.Index)
                    continue;

                this.Items.RemoveAt(i);
                this.Pieces.RemoveAt(i);
                return;
            }
        }

        private ListViewItem CreatePiecesListItem(BlockEventArgs e)
        {
            ListViewItem item = new ListViewItem(e.Piece.Index.ToString());
            item.SubItems.Add((e.Block.RequestLength.ToString()));
            item.SubItems.Add(e.Piece.BlockCount.ToString());

            ListViewItem.ListViewSubItem blockProgress = new ListViewItem.ListViewSubItem();
            blockProgress.Name = "BlockProgress";   // Hardcoded string. Used to replace this item by a rendering of the block progress bar
            item.SubItems.Add(blockProgress);
            return item;
        }

        public ImageListView()
        {
            this.FullRowSelect = true;
            this.OwnerDraw = true;
            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(SpecialListView_DrawColumnHeader);
            this.DrawSubItem += new DrawListViewSubItemEventHandler(SpecialListView_DrawSubItem);
            this.DrawItem += new DrawListViewItemEventHandler(SpecialListView_DrawItem);
            this.MouseMove +=new MouseEventHandler(SpecialListView_MouseMove);
        }

        void SpecialListView_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag == null)
            {
                item.Tag = "fixed";
                this.Invalidate(item.Bounds);
            }
        }

        void SpecialListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.DrawText();
        }

        void SpecialListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }



        void SpecialListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.SubItem.Name != "BlockProgress")
            {
                e.DrawBackground();
                e.DrawFocusRectangle(e.Bounds);
                e.DrawText();
                return;
            }

            BlockEventArgs args = Pieces[e.ItemIndex];
            using (Graphics g = e.Graphics)
            {
                Rectangle rect = e.Bounds;
                float width = (float)rect.Width / args.Piece.BlockCount;
                for (int i = 0; i < args.Piece.BlockCount; i++)
                {
                    RectangleF newDrawArea = new RectangleF(rect.X + (width * i), rect.Y, width, rect.Height);
                    if (args.Piece[i].Written)
                        g.FillRectangle(writtenBrush, newDrawArea);

                    else if (args.Piece[i].Received)
                        g.FillRectangle(receivedBrush, newDrawArea);

                    else if (args.Piece[i].Requested)
                        g.FillRectangle(requestedBrush, newDrawArea);

                    else
                        g.FillRectangle(notRequestedBrush, newDrawArea);
                }
            }
        }


        SolidBrush requestedBrush = new SolidBrush(Color.Red);          // Requested
        SolidBrush receivedBrush = new SolidBrush(Color.Blue);          // In Memory
        SolidBrush writtenBrush = new SolidBrush(Color.Green);          // Written
        SolidBrush notRequestedBrush = new SolidBrush(Color.Yellow);     // Not requested

    }
}
