using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;
using MonoTorrent.Client;

namespace MonoTorrent.GUI.Settings
{
    class GuiTorrentSettings : ISettings
    {
        #region Private Fields

        private int maxDownloadSpeed = TorrentSettings.DefaultSettings().MaxDownloadSpeed;
        private int maxUploadSpeed = TorrentSettings.DefaultSettings().MaxUploadSpeed;
        private int maxConnections = TorrentSettings.DefaultSettings().MaxConnections;
        private int uploadSlots = TorrentSettings.DefaultSettings().UploadSlots;


        #endregion

        #region Properties

        public int MaxDownloadSpeed
        {
            get { return this.maxDownloadSpeed; }
            set { this.maxDownloadSpeed = value; }
        }

        public int MaxUploadSpeed
        {
            get { return this.maxUploadSpeed; }
            set { this.maxUploadSpeed = value; }
        }
                
        public int MaxConnections
        {
            get { return this.maxConnections; }
            set { this.maxConnections = value; }
        }
                
        public int UploadSlots
        {
            get { return this.uploadSlots; }
            set { this.uploadSlots = value; }
        }

        #endregion

        #region ISettings Membres

        public IBEncodedValue Encode()
        {
            BEncodedDictionary result = new BEncodedDictionary();
            result.Add(new BEncodedString("MaxDownloadSpeed"), new BEncodedNumber(MaxDownloadSpeed));
            result.Add(new BEncodedString("MaxUploadSpeed"), new BEncodedNumber(MaxUploadSpeed));
            result.Add(new BEncodedString("MaxConnections"), new BEncodedNumber(MaxConnections));
            result.Add(new BEncodedString("UploadSlots"), new BEncodedNumber(UploadSlots));
            return result;
        }

        public void Decode(IBEncodedValue value)
        {
            BEncodedDictionary val = value as BEncodedDictionary;
            if (val != null)
            {
                //if do not find key do not throw exception just continue with default value ;)
                IBEncodedValue result;
                //For number maybe best is to do ((int)((BEncodedNumber)result).Number) but keep using convert and ToString()

                if (val.TryGetValue(new BEncodedString("MaxDownloadSpeed"), out result))
                    MaxDownloadSpeed = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("MaxUploadSpeed"), out result))
                    MaxUploadSpeed = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("MaxConnections"), out result))
                    MaxConnections = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("UploadSlots"), out result))
                    UploadSlots = Convert.ToInt32(result.ToString());
            }
        }

        #endregion

        public TorrentSettings GetTorrentSettings()
        { 
            return new TorrentSettings(UploadSlots, MaxConnections, MaxDownloadSpeed, MaxUploadSpeed);
        }
    }
}
