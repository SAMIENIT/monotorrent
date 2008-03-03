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

        private TorrentSettings settings;
        private string savePath = new EngineSettings().SavePath;

        #endregion

        #region Properties

        public int MaxDownloadSpeed
        {
            get { return settings.MaxDownloadSpeed; }
            set { settings.MaxDownloadSpeed = value; }
        }

        public int MaxUploadSpeed
        {
            get { return settings.MaxUploadSpeed; }
            set { settings.MaxUploadSpeed = value; }
        }
                
        public int MaxConnections
        {
            get { return settings.MaxConnections; }
            set { settings.MaxConnections = value; }
        }
                
        public int UploadSlots
        {
            get { return settings.UploadSlots; }
            set { settings.UploadSlots = value; }
        }

        public string SavePath
        {
            get { return this.savePath; }
            set { this.savePath = value; }
        }

        #endregion

        #region ISettings Membres

        public BEncodedValue Encode()
        {
            BEncodedDictionary result = new BEncodedDictionary();
            result.Add(new BEncodedString("MaxDownloadSpeed"), new BEncodedNumber(MaxDownloadSpeed));
            result.Add(new BEncodedString("MaxUploadSpeed"), new BEncodedNumber(MaxUploadSpeed));
            result.Add(new BEncodedString("MaxConnections"), new BEncodedNumber(MaxConnections));
            result.Add(new BEncodedString("UploadSlots"), new BEncodedNumber(UploadSlots));
            result.Add(new BEncodedString("SavePath"), new BEncodedString(savePath));
            return result;
        }

        public void Decode(BEncodedValue value)
        {
            BEncodedDictionary val = value as BEncodedDictionary;
            if (val != null)
            {
                //if do not find key do not throw exception just continue with default value ;)
                BEncodedValue result;
                //For number maybe best is to do ((int)((BEncodedNumber)result).Number) but keep using convert and ToString()

                if (val.TryGetValue(new BEncodedString("MaxDownloadSpeed"), out result))
                    MaxDownloadSpeed = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("MaxUploadSpeed"), out result))
                    MaxUploadSpeed = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("MaxConnections"), out result))
                    MaxConnections = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("UploadSlots"), out result))
                    UploadSlots = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("SavePath"), out result))
                    savePath = result.ToString();
            }
        }

        #endregion

        public GuiTorrentSettings()
            :this(new TorrentSettings())
        {

        }

        public GuiTorrentSettings(TorrentSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            this.settings = settings;
        }

        public TorrentSettings GetTorrentSettings()
        { 
            return new TorrentSettings(UploadSlots, MaxConnections, MaxDownloadSpeed, MaxUploadSpeed);
        }
    }
}
