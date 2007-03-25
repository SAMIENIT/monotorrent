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

        #endregion

        #region Interface Members

        public IBEncodedValue Encode()
        {
            BEncodedDictionary result = new BEncodedDictionary();
            result.Add(new BEncodedString("Width"), new BEncodedNumber(FormWidth));
            result.Add(new BEncodedString("height"), new BEncodedNumber(FormHeight));
            result.Add(new BEncodedString("splitterDistance"), new BEncodedNumber(SplitterDistance));
            result.Add(new BEncodedString("VScrollValue"), new BEncodedNumber(VScrollValue));
            result.Add(new BEncodedString("HScrollValue"), new BEncodedNumber(HScrollValue));
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
            }
        }

        #endregion

    }
}
