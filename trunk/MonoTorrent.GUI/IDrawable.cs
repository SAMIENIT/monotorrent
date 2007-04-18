using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MonoTorrent.GUI
{
    public interface IDrawable
    {
        void Draw(Graphics graphics, Rectangle bounds);
    }
}
