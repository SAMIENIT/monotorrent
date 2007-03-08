using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Common;

namespace MonoTorrent.GUI.Settings
{
    public interface ISettings
    {
        IBEncodedValue Encode();

        void Decode(string value);
    }
}
