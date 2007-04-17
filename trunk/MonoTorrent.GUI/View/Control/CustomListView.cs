using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MonoTorrent.Client;

namespace MonoTorrent.GUI.View.Control
{

    public class CustomListView : ListView
    {
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            if (e.Item.GetType() == typeof(ICustomListView))
            {
                ICustomListView item = (ICustomListView)e.Item;
                item.CustomDraw(e);
            }
            else
            {
                e.DrawBackground();
                e.DrawFocusRectangle(e.Bounds);
                e.DrawText();
                e.DrawDefault = true;
            }

            base.OnDrawSubItem(e);
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            base.OnDrawColumnHeader(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.DrawText();

            base.OnDrawItem(e);
        }

    }
    
    public interface ICustomListView
    {
        void CustomDraw(DrawListViewSubItemEventArgs e);
    }

    public class BlockProgressBarListViewItem : ListViewItem, ICustomListView
    {

        public enum eState
        {
            Written,
            Received,
            Requested,
            RequestCancelled,
            NotRequested
        }

        public struct BlockItem
        {
            public int index;
            public eState state;
        }

        private List<BlockItem> blocks;

        public BlockProgressBarListViewItem(int blockCount)
        {
            this.blocks = new List<BlockItem>(blockCount);
        }

        public List<BlockItem> Blocks {
            get { return blocks; }
            set { blocks = value; }
        }

        public int BlockCount {
            get { return blocks.Count; }
            set { 
                // if size is less than before init 
                if (value < blocks.Count)
                    blocks = new List<BlockItem>(value);
                else
                    blocks.Capacity = value;
            }
        }

        SolidBrush requestedBrush = new SolidBrush(Color.Yellow);          // Requested
        SolidBrush receivedBrush = new SolidBrush(Color.Blue);          // In Memory
        SolidBrush writtenBrush = new SolidBrush(Color.Green);          // Written
        SolidBrush notRequestedBrush = new SolidBrush(Color.Black);     // Not requested
        SolidBrush requestCancelledBrush = new SolidBrush(Color.Red);     // RequestCancelled
        
        public void CustomDraw(DrawListViewSubItemEventArgs e)
        {
            Rectangle rect = this.Bounds;
            int width = rect.Width / this.blocks.Count;
            using (Graphics g = e.Graphics)
            {
                for (int i = 0; i < this.blocks.Count; i++)
                {
                    rect = new Rectangle(width * i, rect.Y, width, rect.Height);
                    switch (blocks[i].state)
                    {
                        case eState.Written:
                            g.FillRectangle(writtenBrush, rect);
                            break;
                        case eState.Received:
                            g.FillRectangle(receivedBrush, rect);
                            break;
                        case eState.Requested:
                            g.FillRectangle(requestedBrush, rect);
                            break;
                        case eState.NotRequested:
                            g.FillRectangle(notRequestedBrush, rect);
                            break;
                        case eState.RequestCancelled:
                            g.FillRectangle(requestCancelledBrush, rect);
                            break;
                            
                    }
                }
            }
        }
    }

    public class ProgressBarListViewItem : ListViewItem, ICustomListView
    {
        public void CustomDraw(DrawListViewSubItemEventArgs e)
        {
            Rectangle rect = this.Bounds;
            rect.Width = (rect.Width * this.value) / (maxValue - MinValue);

            using (Graphics g = e.Graphics)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), rect);
            }
        }

        private int value;
        private int maxValue;
        private int minValue;

        public int Value
        {
            get { return this.Value; }
            set
            {
                if ((value > MaxValue) || (value < MinValue))
                    throw new Exception("Value must be within min and max value.");

                this.value = value;
            }
        }

        public int MaxValue
        {
            get { return this.maxValue; }
            set
            {
                if (value < MinValue)
                    this.minValue = value;

                this.maxValue = value;
            }
        }

        public int MinValue
        {
            get { return this.minValue; }
            set
            {
                if (value > maxValue)
                    this.maxValue = value;

                this.minValue = value;
            }
        }
    }
}
