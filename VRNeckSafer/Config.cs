using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRNeckSafer
{
    class Config
    {
        public String JoystickGUID;
        public String LeftButton;
        public String RightButton;
        public String ResetButton;
        public int Angle;
        public int TransLR;
        public int TransF;
        public bool Additiv;
        public bool Auto;
        public int ActivationAngle;
        public int DeactivationAngle;

        public Config()
        {
            JoystickGUID = "none";
            LeftButton = "none";
            RightButton = "none";
            ResetButton = "none";
            Angle = 30;
            TransLR = 0;
            TransF = 0;
            Additiv = false;
            Auto = false;
            ActivationAngle = 70;
            DeactivationAngle = 60;
        }

        static public Config ReadConfig()
        {
            try
            {
                return JsonConvert.DeserializeObject<Config>(File.ReadAllText(@".\VRNeckSafer.cfg"));
            }
            catch (Exception)
            {
                Config conf = new Config();
                conf.WriteConfig();
                return conf;
            }
        }

        public void WriteConfig()
        {
            File.WriteAllText(@".\VRNeckSafer.cfg", JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
