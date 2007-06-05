using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Utilities
{
    /// <summary>
    /// Parses startup arguments
    /// Arjen Balfoort, 27-5-2007
    /// 
    /// Fill PossibleSwitches with the switches you want to use
    /// and their descriptions
    /// 
    /// EXAMPLES
    ///     start torrent paths before using switches
    ///     start switches with / or -
    ///     seperate values from switches with spaces, : or =
    /// 
    /// my.exe /? (show help - or with /help)
    /// my.exe "path to file.txt" "another file.txt"
    /// my.exe "path to file.txt" /mini
    /// my.exe /s value1 value2 value3
    /// my.exe /s:value1 value2
    /// my.exe "first file" "second file" /mini /par1 par1_value /par2 par2_value1 par2_value2 /par3:par3_value1 par3_value2
    /// 
    /// CODE
    /// ArgumentParser ap = new ArgumentParser(args);
    /// if (!ap.ParseOk)
    ///     MessageBox.Show(ap.Help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
    /// else
    /// {
    ///     foreach (ArgumentParser.Switch sw in ap.PassedSwitches)
    ///     {
    ///         // make switch for each sw.SwitchName
    ///         foreach (string val in sw.SwitchValues)
    ///             // do something with each sw.SwitchValue
    ///     }
    /// }
    /// 
    /// </summary>
    public class ArgumentParser
	{
        /// <summary>
        /// Inherited StringDictionary with possible switches and their descriptions
        /// </summary>
        private class PossibleSwitches : StringDictionary
        {           
            public PossibleSwitches()
            {
                // Don't remove both of these:
                this.Add("?", "Show this message");         
                this.Add("help", "Show this message");
                
                // Application specific switches
                this.Add("mini", "Start with mini-window");
                this.Add("options", "Show options first");

            }
        }
        
        /// <summary>
        /// Contains passed switch name and values
        /// </summary>
        public class Switch
		{
			private string _sn;
            public StringCollection SwitchValues = new StringCollection();

            public Switch(string switchName)
			{
                _sn = switchName;
			}

			public string SwitchName
			{
				get { return _sn; }
			}
		}

        /// <summary>
        /// Inherited ArrayList that contains Switch objects
        /// </summary>
		public class Switches : ArrayList
		{
			public Switch this[string switchName]
			{
				get
				{
					foreach (Switch sw in this)
					{
                        if (sw.SwitchName == switchName)
						    return sw;
					}
                    return null;
				}
			}
		}

        /// <summary>
        /// Contains all passed switches
        /// </summary>
		public Switches PassedSwitches = new Switches();

        /// <summary>
        /// Indicates whether or not the parse was successful
        /// </summary>
        public bool ParseOk = true;

        /// <summary>
        /// Start class with arguments array
        /// </summary>
        /// <param name="args">Arguments array (string)</param>
		public ArgumentParser(string[] args)
		{
            ParseOk = ParseArgs(args);
		}

        /// <summary>
        /// Parses all passed arguments and fills PassedSwitches with switches and their values
        /// </summary>
        /// <param name="args">Arguments array (string)</param>
        /// <returns>Indicates whether or not parse was successful</returns>
		private bool ParseArgs(string[] args)
		{
			Switch sw = null;

			foreach (string arg in args)
			{
				switch (arg.Substring(0,1))
				{
					case "/":
					case "-":
                        // Check for subvalues
                        Regex re = new Regex(":|=");
                        string[] arrArg = re.Split(arg.Substring(1).ToLower());

                        sw = PassedSwitches[arrArg[0]];
						if (sw == null)
						{
                            // Check if help screen is called
                            // or switch is in PossibleSwitches
                            if (arrArg[0] == "?" || arrArg[0] == "help" || !SwitchOk(arrArg[0]))
                            {
                                PassedSwitches.Clear();
                                return false;
                            }
                            sw = new Switch(arrArg[0]);
							PassedSwitches.Add(sw);
						}

                        // Add values
                        for (int i = 1; i < arrArg.Length; i++)
                        {
                            sw.SwitchValues.Add(arrArg[i]);
                        }

						break;

					default:
                        // Value of switch when seperated by space
                        if (sw != null)
                        {
                            sw.SwitchValues.Add(arg);
                            break;
                        }
                        else
                        {
                            // Switch-less value
                            sw = PassedSwitches[""];
                            if (sw == null)
                            {
                                sw = new Switch("");
                                PassedSwitches.Add(sw);
                            }
                            sw.SwitchValues.Add(arg);
                            break;
                        }
				}
			}
            return true;
		}

        /// <summary>
        /// Checks a switch name against the PossibleSwitches entries
        /// </summary>
        /// <param name="checkSwitch">Name of a passed switch</param>
        /// <returns>Indicates whether or not checkSwitch was found in PossibleSwitches</returns>
        private bool SwitchOk(string checkSwitch)
        {
            PossibleSwitches ps = new PossibleSwitches();
            if (ps.ContainsKey(checkSwitch))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Builds a help string from the PossibleSwitches entries
        /// </summary>
        public string Help
        {
            get
            {
                string ret = string.Empty;
                PossibleSwitches ps = new PossibleSwitches();

                // To sort the keys: copy the keys to an array
                string[] keys = new string[ps.Count];
                ps.Keys.CopyTo(keys, 0);
                Array.Sort(keys);
                
                // Build return string
                for (int i = 0; i < ps.Count; i++)
                    ret += "/" + keys[i] + "\t\t" + ps[keys[i]] + "\n";

                return ret;
            }
        }
	}
}
