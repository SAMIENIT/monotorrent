using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using MonoTorrent.GUI.View;
using System.IO;
using Utilities;
using Nat;
using MonoTorrent.GUI.Controller;

namespace MonoTorrent.GUI
{
    static class Program
    {
        private static MainController mainController;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ParseArguments(args);

            // Set startup path
            Global.StartupPath = Application.StartupPath;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainController = new MainController();
            MainWindow window = new MainWindow(mainController);
            Application.Run(window);
        }

        private static void ParseArguments(string[] args)
        {
            // Parse arguments
            ArgumentParser ap = new ArgumentParser(args);
            if (!ap.ParseOk)
            {
                MessageBox.Show(ap.Help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (ArgumentParser.Switch sw in ap.PassedSwitches)
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
    }
}