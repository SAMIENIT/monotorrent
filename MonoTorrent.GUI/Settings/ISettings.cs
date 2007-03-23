using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.Common;
using MonoTorrent.BEncoding;

namespace MonoTorrent.GUI.Settings
{
    public interface ISettings
    {
        IBEncodedValue Encode();

        void Decode(IBEncodedValue value);
    }
}
