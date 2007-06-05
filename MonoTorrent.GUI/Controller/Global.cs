using System;
using System.Collections.Specialized;
using System.Text;
using System.IO;

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
    }
}
