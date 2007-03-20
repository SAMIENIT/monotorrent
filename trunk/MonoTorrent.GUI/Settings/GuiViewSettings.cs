using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;
using System.IO;

namespace MonoTorrent.GUI.Settings
{
    class GuiViewSettings : ISettings
    {
        private GuiViewSettings()
        {
            storage = new BEncodedSettingsStorage(Path.Combine(Environment.CurrentDirectory, CONFIG_FILE));
        }

        private static GuiViewSettings instance;

        public static GuiViewSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuiViewSettings();
                }
                return instance;
            }
        }

        #region Member Variables

        private int width;
        private int height;
        private int splitterDistance;

        private readonly string CONFIG_FILE = "config.xml";
        private ISettingsStorage storage;

        #endregion

        #region Properties

        public int FormWidth
        {
            get { return width; }
            set { width = value; }
        }

        public int FormHeight
        {
            get { return height; }
            set { height = value; }
        }

        public int SplitterDistance
        {
            get { return splitterDistance; }
            set { splitterDistance = value; }
        }

        #endregion

        public void Encode()
        {
            storage.Store("FormWidth", width);
            storage.Store("FormHeight", height);
            storage.Store("SplitterDistance", splitterDistance);
            storage.Flush();
        }

        public void Decode()
        {
            width = (int) storage.Retrieve("FormWidth");
            height = (int) storage.Retrieve("FormHeight");
            splitterDistance = (int)storage.Retrieve("SplitterDistance");
        }
    }
}
