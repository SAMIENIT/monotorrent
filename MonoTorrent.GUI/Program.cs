using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using MonoTorrent.GUI.View;
using System.IO;
using Utilities;

namespace MonoTorrent.GUI
{   
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            //if (args.Length == 0)
            //{
            //    // Only for testing
            //    args = new string[3];
            //    args[0] = @"D:\Torrents\test1.torrent";
            //    args[1] = @"D:\Torrents\test2.torrent";
            //    args[2] = "/mini";
            //}
            
            // Parse arguments
            ArgumentParser ap = new ArgumentParser(args);
            if (!ap.ParseOk)
                MessageBox.Show(ap.Help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                foreach (Utilities.ArgumentParser.Switch sw in ap.PassedSwitches)
                {
                    switch (sw.SwitchName)
                    {
                        case "":
                            // Files to add
                            foreach (string val in sw.SwitchValues)
                            {
                                if (File.Exists(val))
                                    Global.TorrentFiles.Add(val);
                            }
                            break;
                        case "mini":
                            // Show as miniwindow
                            Global.Mini = true;
                            break;
                        case "options":
                            // Show options window first
                            Global.Options = true;
                            break;
                        default:
                            break;

                    }
                }
            }

            // Set startup path
            Global.StartupPath = Application.StartupPath;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}