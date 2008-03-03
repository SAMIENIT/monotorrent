using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;
using MonoTorrent.Client;
using System.IO;
using MonoTorrent.Common;

namespace MonoTorrent.GUI.Settings
{
    public class GuiGeneralSettings : ISettings
    {
        private EngineSettings settings;
		public GuiGeneralSettings()
		{
			if (string.IsNullOrEmpty(StartDirectory))
				StartDirectory = Environment.CurrentDirectory;

            settings = new EngineSettings();
			savePath = Path.Combine(StartDirectory, "Downloads");
			torrentsPath = Path.Combine(StartDirectory, "Torrents");
		}
		//get at start because after when we go in openfile dialog it change the folder
		public static string StartDirectory;

        #region Private Fields
        
        private string savePath;
        private string torrentsPath;
        private bool useuPnP;
        
        #endregion Private Fields
        
        #region Properties

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
            get { return settings.GlobalMaxConnections; }
            set { settings.GlobalMaxConnections = value; }
        }

        public int GlobalMaxHalfOpenConnections
        {
            get { return settings.GlobalMaxHalfOpenConnections; }
            set { settings.GlobalMaxHalfOpenConnections = value; }
        }

        public int GlobalMaxDownloadSpeed
        {
            get { return settings.GlobalMaxDownloadSpeed; }
            set { settings.GlobalMaxDownloadSpeed = value; }
        }

        public int GlobalMaxUploadSpeed
        {
            get { return settings.GlobalMaxUploadSpeed; }
            set { settings.GlobalMaxUploadSpeed = value; }
        }

        public int ListenPort
        {
            get { return settings.ListenPort; }
            set { settings.ListenPort = value; }
        }

        public bool UsePnP
        {
            get { return useuPnP; }
            set { useuPnP = value;  }
        }

        #endregion Properties

        #region ISettings Membres

        public BEncodedValue Encode()
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

        public void Decode(BEncodedValue value)
        {
            BEncodedDictionary val = value as BEncodedDictionary;
            if (val != null)
            {
                //if do not find key do not throw exception just continue with default value ;)
                BEncodedValue result;
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
            return new EngineSettings(SavePath, ListenPort, GlobalMaxConnections, GlobalMaxHalfOpenConnections,
                                   GlobalMaxDownloadSpeed, GlobalMaxUploadSpeed,EncryptionType.None, true);
        }
    }
}
