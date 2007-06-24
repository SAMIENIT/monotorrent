using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Utilities
{
    public class ButtonHandler
    {
        #region Images

        private Image _OriginalImage;
        public Image OriginalImage
        {
            get { return _OriginalImage; }
        }

        private Image _AddTorrent;
        public Image AddTorrent
        {
            get { return _AddTorrent; }
        }

        private Image _AddTorrentFromUrl;
        public Image AddTorrentFromUrl
        {
            get { return _AddTorrentFromUrl; }
        }

        private Image _CreateTorrent;
        public Image CreateTorrent
        {
            get { return _CreateTorrent; }
        }

        private Image _DeleteTorrent;
        public Image DeleteTorrent
        {
            get { return _DeleteTorrent; }
        }

        private Image _StartTorrent;
        public Image StartTorrent
        {
            get { return _StartTorrent; }
        }

        private Image _PauseTorrent;
        public Image PauseTorrent
        {
            get { return _PauseTorrent; }
        }

        private Image _StopTorrent;
        public Image StopTorrent
        {
            get { return _StopTorrent; }
        }

        private Image _Up;
        public Image Up
        {
            get { return _Up; }
        }

        private Image _Down;
        public Image Down
        {
            get { return _Down; }
        }

        private Image _Search;
        public Image Search
        {
            get { return _Search; }
        }

        private Image _Rss;
        public Image Rss
        {
            get { return _Rss; }
        }

        private Image _Options;
        public Image Options
        {
            get { return _Options; }
        }

        #endregion

        public ButtonHandler(string ImagePath)
        {
            Bitmap bmp = new Bitmap(ImagePath);
            int sz = bmp.Height;

            // Original
            _OriginalImage = (Image)bmp;

            // Buttnons
            _AddTorrent = Global.GetSquareFromImage(OriginalImage, 0, 0, sz, sz);
            _AddTorrentFromUrl = Global.GetSquareFromImage(OriginalImage, sz, 0, sz, sz);
            _CreateTorrent = Global.GetSquareFromImage(OriginalImage, (2 * sz), 0, sz, sz);
            _DeleteTorrent = Global.GetSquareFromImage(OriginalImage, (3 * sz), 0, sz, sz);
            _StartTorrent = Global.GetSquareFromImage(OriginalImage, (4 * sz), 0, sz, sz);
            _PauseTorrent = Global.GetSquareFromImage(OriginalImage, (5 * sz), 0, sz, sz);
            _StopTorrent = Global.GetSquareFromImage(OriginalImage, (6 * sz), 0, sz, sz);
            _Up = Global.GetSquareFromImage(OriginalImage, (7 * sz), 0, sz, sz);
            _Down = Global.GetSquareFromImage(OriginalImage, (8 * sz), 0, sz, sz);
            _Search = Global.GetSquareFromImage(OriginalImage, (9 * sz), 0, sz, sz);
            _Rss = Global.GetSquareFromImage(OriginalImage, (10 * sz), 0, sz, sz);
            _Options = Global.GetSquareFromImage(OriginalImage, (11 * sz), 0, sz, sz);

        }

    }
}
