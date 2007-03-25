using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;
using MonoTorrent.Client;
using System.IO;

namespace MonoTorrent.GUI.Settings
{
    public class GuiGeneralSettings : ISettings
    {

        #region Private Fields
        
        // DEFAULT VALUE

        //private bool allowLegacyConnections = true;
        //private int minEncryptionLevel = EncryptionType.None;
        private int listenPort = EngineSettings.DefaultSettings().ListenPort;
        private int globalMaxConnections = EngineSettings.DefaultSettings().GlobalMaxConnections;
        private int globalMaxHalfOpenConnections = EngineSettings.DefaultSettings().GlobalMaxHalfOpenConnections;
        private int globalMaxDownloadSpeed = EngineSettings.DefaultSettings().GlobalMaxDownloadSpeed;
        private int globalMaxUploadSpeed = EngineSettings.DefaultSettings().GlobalMaxUploadSpeed;
        private string savePath = Path.Combine(Environment.CurrentDirectory, "Downloads");
        private string torrentsPath = Path.Combine(Environment.CurrentDirectory, "Torrents");
        private bool useuPnP =  EngineSettings.DefaultSettings().UsePnP;
        
        #endregion Private Fields
        
        #region Properties

        /*public bool AllowLegacyConnections
        {
            get { return allowLegacyConnections; }
            set { allowLegacyConnections = value; }
        }

        public int MinEncryptionLevel
        {
            get { return minEncryptionLevel; }
            set { minEncryptionLevel = value; }
        }*/

        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        public string TorrentsPath
        {
            get { return torrentsPath; }
            set { torrentsPath = value; }
        }

        public int GlobalMaxConnections
        {
            get { return globalMaxConnections; }
            set { globalMaxConnections = value; }
        }

        public int GlobalMaxHalfOpenConnections
        {
            get { return globalMaxHalfOpenConnections; }
            set { globalMaxHalfOpenConnections = value; }
        }

        public int GlobalMaxDownloadSpeed
        {
            get { return globalMaxDownloadSpeed; }
            set { globalMaxDownloadSpeed = value; }
        }

        public int GlobalMaxUploadSpeed
        {
            get { return globalMaxUploadSpeed; }
            set { globalMaxUploadSpeed = value; }
        }

        public int ListenPort
        {
            get { return listenPort; }
            set { listenPort = value; }
        }

        public bool UsePnP
        {
            get { return useuPnP; }
            set { useuPnP = value;  }
        }

        #endregion Properties

        #region ISettings Membres

        public IBEncodedValue Encode()
        {
            BEncodedDictionary result = new BEncodedDictionary();
            result.Add(new BEncodedString("SavePath"), new BEncodedString(SavePath));
            result.Add(new BEncodedString("GlobalMaxConnections"), new BEncodedNumber(GlobalMaxConnections));
            result.Add(new BEncodedString("GlobalMaxHalfOpenConnections"), new BEncodedNumber(GlobalMaxHalfOpenConnections));
            result.Add(new BEncodedString("GlobalMaxDownloadSpeed"), new BEncodedNumber(GlobalMaxDownloadSpeed));
            result.Add(new BEncodedString("GlobalMaxUploadSpeed"), new BEncodedNumber(GlobalMaxUploadSpeed));
            result.Add(new BEncodedString("ListenPort"), new BEncodedNumber(ListenPort));
            result.Add(new BEncodedString("UsePnP"), new BEncodedString(UsePnP.ToString()));
            result.Add(new BEncodedString("TorrentsPath"), new BEncodedString(TorrentsPath));
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
                if (val.TryGetValue(new BEncodedString("SavePath"), out result))
                    SavePath = result.ToString();

                if (val.TryGetValue(new BEncodedString("GlobalMaxConnections"), out result))
                    GlobalMaxConnections = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("GlobalMaxHalfOpenConnections"), out result))
                    GlobalMaxHalfOpenConnections = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("GlobalMaxDownloadSpeed"), out result))
                    GlobalMaxDownloadSpeed = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("GlobalMaxUploadSpeed"), out result))
                    GlobalMaxUploadSpeed = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("ListenPort"), out result))
                    ListenPort = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("UsePnP"), out result))
                    UsePnP = Convert.ToBoolean(result.ToString());

                if (val.TryGetValue(new BEncodedString("TorrentsPath"), out result))
                    TorrentsPath = result.ToString();
            }
        }

        #endregion

        public EngineSettings GetEngineSettings()
        {
            return new EngineSettings(SavePath, UsePnP, GlobalMaxConnections, GlobalMaxHalfOpenConnections,
                                   ListenPort, GlobalMaxDownloadSpeed, GlobalMaxUploadSpeed);
        }
    }
}
