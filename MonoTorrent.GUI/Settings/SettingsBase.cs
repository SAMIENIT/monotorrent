using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using MonoTorrent.BEncoding;

namespace MonoTorrent.GUI.Settings
{
    public class SettingsBase
    {
        private ISettingsStorage storage;
        private readonly string CONFIG_FILE = "config.dat";

        public SettingsBase()
        {
            storage = new BEncodedSettingsStorage(Path.Combine(Environment.CurrentDirectory, CONFIG_FILE));
        }
        public T LoadSettings<T>(string key) where T : ISettings, new()
        {
            T setting = new T();//set default value
            object val = storage.Retrieve(key);
            if (val != null)
            {
                if (val is BEncodedValue)
                    setting.Decode((BEncodedValue)val);
                else
                    throw new ArgumentException("Can not Decode value for key :" + key + " with value :" + val.ToString(), "key");
            }
            //no else because set default value when not in settings
            
            return setting;
        }

        public void SaveSettings<T>(string key, T setting) where T : ISettings
        {
            BEncodedValue val = setting.Encode();
            storage.Store(key,val);
            //here flush but maybe have to done it in another function to save all setting before flush in file
            storage.Flush();
        }
    }
}
