using System;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Utilities
{
    /// <summary>
    /// Holds all global variables
    /// </summary>
    static class Global
    {
        
        /// <summary>
        /// Name of config file
        /// </summary>
        public static string ConfigFile
        {
            get { return "config.dat"; }
        }

        /// <summary>
        /// Path to config file
        /// </summary>
        public static string ConfigPath
        {
            get { return Path.Combine(_startupPath, ConfigFile); }
        }
        
        /// <summary>
        /// Startup path
        /// </summary>
        private static string _startupPath = string.Empty;
        public static string StartupPath
        {
            get { return _startupPath; }
            set { _startupPath = value; }
        }

        /// <summary>
        /// Torrent path or url
        /// </summary>
        private static string _torrentPath = string.Empty;
        public static string TorrentPath
        {
            get { return _torrentPath; }
            set { _torrentPath = value; }
        }

        #region Arguments

        /// <summary>
        /// Torrent files to load
        /// </summary>
        private static StringCollection _TorrentFiles = new StringCollection();
        public static StringCollection TorrentFiles
        {
            get { return _TorrentFiles; }
            set { _TorrentFiles = value; }
        }

        /// <summary>
        /// Start in mini-window
        /// </summary>
        private static bool _mini = false;
        public static bool Mini
        {
            get { return _mini; }
            set { _mini = value; }
        }

        /// <summary>
        /// Start with options window
        /// </summary>
        private static bool _options = false;
        public static bool Options
        {
            get { return _options; }
            set { _options = value; }
        }

        #endregion

        #region Global Functions

        /// <summary>
        /// Directory.Getfiles cannot use multiple patterns...
        /// </summary>
        /// <param name="path">Path to the directory</param>
        /// <param name="patterns">All patterns you want to search</param>
        /// <returns>String array with file paths</returns>
        public static string[] GetFiles(string path, string[] patterns)
        {
            StringCollection sc = new StringCollection();
            foreach (string pattern in patterns)
            {
                string[] files = Directory.GetFiles(path, pattern);
                sc.AddRange(files);
            }
            string[] ret = new string[sc.Count];
            sc.CopyTo(ret, 0);
            return ret;
        }

        /// <summary>
        /// Returns an image from a given position, width and hight
        /// </summary>
        /// <param name="x">x-position in the original image</param>
        /// <param name="y">y-position in the original image</param>
        /// <param name="width">Width of the new image</param>
        /// <param name="height">Height of the new image</param>
        /// <returns>The new image</returns>
        public static Image GetSquareFromImage(Image OriginalImage, int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, OriginalImage.PixelFormat);
            bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);

            using (Graphics graph = Graphics.FromImage(bmp))
            {
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graph.DrawImage(OriginalImage,
                    new Rectangle(0, 0, width, height),
                    new Rectangle(x, y, width, height),
                    GraphicsUnit.Pixel);
            }
            return (Image)bmp;
        }

        /// <summary>
        /// Check whether or not a string represents a number
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>Boolean</returns>
        public static bool IsNumber(string str)
        {
            double result = 0;
            return double.TryParse(str, out result) && result >= 0;
        }

        #endregion

    }
}
