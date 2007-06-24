using System;
using System.Collections.Generic;
using System.Text;
using MonoTorrent.BEncoding;
using System.IO;

namespace MonoTorrent.GUI.Settings
{
    class GuiViewSettings : ISettings
    {
        public GuiViewSettings()
        {
        }

        #region Member Variables
        //default value
        private int width = 700;
        private int height = 500;
        private int splitterDistance = 190;
        private int vscrollValue = 0;
        private int hscrollValue = 0;
        private bool showToolbar = true;
        private bool showDetail = true;
        private bool showStatusbar = true;
        private List<int> torrentViewColumnWidth = new List<int>();
        private List<int> peerViewColumnWidth = new List<int>();
        private List<int> pieceViewColumnWidth = new List<int>();
        static string customButtonPath = string.Empty;
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

        public int VScrollValue
        {
            get { return vscrollValue; }
            set { vscrollValue = value; }
        }

        public int HScrollValue
        {
            get { return hscrollValue; }
            set { hscrollValue = value; }
        }

        public bool ShowToolbar
        {
            get { return showToolbar; }
            set { showToolbar = value; }
        }

        public bool ShowDetail
        {
            get { return showDetail; }
            set { showDetail = value; }
        }

        public bool ShowStatusbar
        {
            get { return showStatusbar; }
            set { showStatusbar = value; }
        }

        public List<int> TorrentViewColumnWidth
        {
            get { return torrentViewColumnWidth; }
            set { torrentViewColumnWidth = value; }
        }

        public List<int> PieceViewColumnWidth
        {
            get { return pieceViewColumnWidth; }
            set { pieceViewColumnWidth = value; }
        }

        public List<int> PeerViewColumnWidth
        {
            get { return peerViewColumnWidth; }
            set { peerViewColumnWidth = value; }
        }

        public static string CustomButtonPath
        {
            get { return customButtonPath; }
            set { customButtonPath = value; }
        }

        #endregion

        #region Interface Members

        public BEncodedValue Encode()
        {
            BEncodedDictionary result = new BEncodedDictionary();
            result.Add(new BEncodedString("Width"), new BEncodedNumber(FormWidth));
            result.Add(new BEncodedString("height"), new BEncodedNumber(FormHeight));
            result.Add(new BEncodedString("splitterDistance"), new BEncodedNumber(SplitterDistance));
            result.Add(new BEncodedString("VScrollValue"), new BEncodedNumber(VScrollValue));
            result.Add(new BEncodedString("HScrollValue"), new BEncodedNumber(HScrollValue));
            result.Add(new BEncodedString("ShowToolbar"), new BEncodedString(ShowToolbar.ToString()));
            result.Add(new BEncodedString("ShowDetail"), new BEncodedString(ShowDetail.ToString()));
            result.Add(new BEncodedString("ShowStatusbar"), new BEncodedString(ShowStatusbar.ToString()));
            for(int i =0; i < torrentViewColumnWidth.Count;i++)
                result.Add(new BEncodedString("TorrentViewColumnWidth" + i.ToString()), new BEncodedNumber(torrentViewColumnWidth[i]));
            for (int i = 0; i < peerViewColumnWidth.Count; i++)
                result.Add(new BEncodedString("PeerViewColumnWidth" + i.ToString()), new BEncodedNumber(peerViewColumnWidth[i]));
            for (int i = 0; i < pieceViewColumnWidth.Count; i++)
                result.Add(new BEncodedString("PieceViewColumnWidth" + i.ToString()), new BEncodedNumber(pieceViewColumnWidth[i]));
            result.Add(new BEncodedString("CustomButtonPath"), new BEncodedString(CustomButtonPath));
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

                if (val.TryGetValue(new BEncodedString("Width"), out result))
                    width = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("height"), out result))
                    height = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("splitterDistance"), out result))
                    splitterDistance = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("VScrollValue"), out result))
                    VScrollValue = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("HScrollValue"), out result))
                    HScrollValue = Convert.ToInt32(result.ToString());

                if (val.TryGetValue(new BEncodedString("ShowToolbar"), out result))
                    ShowToolbar = Convert.ToBoolean(result.ToString());

                if (val.TryGetValue(new BEncodedString("ShowDetail"), out result))
                    ShowDetail = Convert.ToBoolean(result.ToString());

                if (val.TryGetValue(new BEncodedString("ShowStatusbar"), out result))
                    ShowStatusbar = Convert.ToBoolean(result.ToString());
                
                int i =0;
                while (val.TryGetValue(new BEncodedString("TorrentViewColumnWidth" + i.ToString()), out result))
                {
                    torrentViewColumnWidth.Add(Convert.ToInt32(result.ToString()));
                    i++;
                }

                i = 0;
                while (val.TryGetValue(new BEncodedString("PeerViewColumnWidth" + i.ToString()), out result))
                {
                    peerViewColumnWidth.Add(Convert.ToInt32(result.ToString()));
                    i++;
                }

                i = 0;
                while (val.TryGetValue(new BEncodedString("PieceViewColumnWidth" + i.ToString()), out result))
                {
                    pieceViewColumnWidth.Add(Convert.ToInt32(result.ToString()));
                    i++;
                }

                if (val.TryGetValue(new BEncodedString("CustomButtonPath"), out result))
                    CustomButtonPath = result.ToString();
            }
        }

        #endregion

    }
}
