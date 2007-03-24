using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;

namespace MonoTorrent.GUI.Settings
{
    class GuiTorrentSettings : ISettings
    {

        #region ISettings Membres

        public IBEncodedValue Encode()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Decode(IBEncodedValue value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
