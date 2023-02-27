using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftLauncher
{
    public class Config
    {
        private string gameInstallLocation = Directories.DefaultInstallLocation;
        private bool checkforLauncherUpdates;

        [JsonProperty]
        public string GameInstallLocation
        {
            get 
            {
                return gameInstallLocation; 
            }
            set 
            { 
                gameInstallLocation = value;
                SaveSettings();
            }
        }

        [JsonProperty]
        public bool CheckforLauncherUpdates
        {
            get
            {
                return checkforLauncherUpdates; 
            }
            set
            { 
                checkforLauncherUpdates = value;
                SaveSettings();
            }
        }

        [JsonConstructor]
        public Config()
        {
            GameInstallLocation = Directories.DefaultInstallLocation;
            checkforLauncherUpdates = true;
        }

        public static Config GetSettings()
        {
            if (File.Exists(Directories.ConfigLocation))
            {
                return JsonConvert.DeserializeObject<Config>(File.ReadAllText(Directories.ConfigLocation));
            }
            var cfg = new Config();
            cfg.GameInstallLocation = Directories.DefaultInstallLocation;
            cfg.CheckforLauncherUpdates = true;
            cfg.SaveSettings();
            return cfg;
        }

        public void SaveSettings()
        {
            if (!Directory.Exists(Directories.tNPLauncher))
            {
                Directory.CreateDirectory(Directories.tNPLauncher);
            }

            File.WriteAllText(Directories.ConfigLocation, JsonConvert.SerializeObject(this, Formatting.Indented));

        }

    }
}
