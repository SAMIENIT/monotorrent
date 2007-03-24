using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;

namespace MonoTorrent.GUI.Settings
{
    class GuiEngineSettings : ISettings
    {

        #region Private Fields

        private bool allowLegacyConnections;
        private int minEncryptionLevel;
        private int listenPort;
        private int globalMaxConnections;
        private int globalMaxHalfOpenConnections;
        private int globalMaxDownloadSpeed;
        private int globalMaxUploadSpeed;
        private string savePath;
        private bool useuPnP;

        #endregion Private Fields
        
        #region Properties

        public bool AllowLegacyConnections
        {
            get { return allowLegacyConnections; }
            set { allowLegacyConnections = value; }
        }

        public int MinEncryptionLevel
        {
            get { return minEncryptionLevel; }
            set { minEncryptionLevel = value; }
        }

        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
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
            throw new Exception("The method or operation is not implemented.");
        }

        public void Decode(IBEncodedValue value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
