using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;

namespace MonoTorrent.GUI.Settings
{
    class GuiViewSettings : ISettings
    {
        #region Member Variables
        private int width;
        private int height;

        private decimal splitMark;
        #endregion
        public IBEncodedValue Encode()
        {
            
            throw new Exception("The method or operation is not implemented.");
        }

        public void Decode(string value)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
