using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MonoTorrent.GUI.View.Control
{
    public interface IDrawable
    {
        void Draw(Graphics graphics, Rectangle bounds);
    }
}
