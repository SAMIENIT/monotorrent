using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MonoTorrent.Client;
using System.Drawing;

namespace MonoTorrent.GUI.View.Control
{
    public class ImageListView : ListView
    {
        public class ImageListViewSubItem : ListViewItem.ListViewSubItem
        {
            public IDrawable Drawable
            {
                get { return this.drawable; }
            }
            private IDrawable drawable;

            public ImageListViewSubItem(IDrawable drawable)
                : base()
            {
                this.drawable = drawable;
            }

            public ImageListViewSubItem(ListViewItem owner, string text, IDrawable drawable)
                : base(owner, text)
            {
                this.drawable = drawable;
            }

            public ImageListViewSubItem(ListViewItem owner, string text, Color forColor, Color backColor, Font font, IDrawable drawable)
                : base(owner, text, forColor, backColor, font)
            {
                this.drawable = drawable;
            }
        }

        public ImageListView()
            : base()
        {
            this.DoubleBuffered = true;
            this.FullRowSelect = true;
            this.OwnerDraw = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            ListViewItem item = this.GetItemAt(e.X, e.Y);

            if (item != null && item.Tag == null)
            {
                item.Tag = "fixed";
                this.Invalidate(item.Bounds);
            }
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }


        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            ImageListViewSubItem item = e.SubItem as ImageListViewSubItem;

            if (item == null)
            {
                e.DrawDefault = true;
                base.OnDrawSubItem(e);
            }
            else
            {
                using (e.Graphics)
                    item.Drawable.Draw(e.Graphics, e.Bounds);
            }
        }
    }
}