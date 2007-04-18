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
        {
            this.DoubleBuffered = true;
            this.FullRowSelect = true;
            this.OwnerDraw = true;
            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(SpecialListView_DrawColumnHeader);
            this.DrawSubItem += new DrawListViewSubItemEventHandler(SpecialListView_DrawSubItem);
            this.DrawItem += new DrawListViewItemEventHandler(SpecialListView_DrawItem);
            this.MouseMove += new MouseEventHandler(SpecialListView_MouseMove);
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
            ImageListViewSubItem item = e.SubItem as ImageListViewSubItem;
            if (item == null)
            {
                e.DrawBackground();
                e.DrawFocusRectangle(e.Bounds);
                e.DrawText();
                return;
            }

            using (e.Graphics)
                item.Drawable.Draw(e.Graphics, e.Bounds);
        }
    }
}
