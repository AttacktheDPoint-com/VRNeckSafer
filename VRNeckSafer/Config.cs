using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRNeckSafer
{
    public class ButtonConfig
    {
        public string JoystickGUID;
        public string Button;
        public string ModJoystickGUID;
        public string ModButton;
        public bool UseModifier;
        public ButtonConfig()
        {
            JoystickGUID = "none";
            Button = "none";
            ModJoystickGUID = "none";
            ModButton = "none";
            UseModifier = false;
        }
    }

    public class Config
    {
        public ButtonConfig LeftButton;
        public ButtonConfig RightButton;
        public ButtonConfig ResetButton;
        public ButtonConfig HoldButton1;
        public ButtonConfig HoldButton2;
        public ButtonConfig HoldButton3;
        public ButtonConfig HoldButton4;
        public int Angle;
        public int TransLR;
        public int TransF;
        public bool Additiv;
        public bool Auto;
        public bool Use8WayHat;
        public bool StartMinimized;
        public bool MinimizeToTray;
        public string GameMode;
        public string AppMode;
        public List<int[]> AutoSteps;


        public Config()
        {
            LeftButton = new ButtonConfig();
            RightButton = new ButtonConfig();
            ResetButton = new ButtonConfig();
            HoldButton1 = new ButtonConfig();
            HoldButton2 = new ButtonConfig();
            HoldButton3 = new ButtonConfig();
            HoldButton4 = new ButtonConfig();
            Angle = 30;
            TransLR = 0;
            TransF = 0;
            Additiv = false;
            Auto = false;
            Use8WayHat = false;
            AutoSteps = new List<int[]>();
        }

        static public Config ReadConfig()
        {
            try
            {
                Config c= JsonConvert.DeserializeObject<Config>(File.ReadAllText(@".\VRNeckSafer.cfg"));
                if (c.AutoSteps.Count==0) c.AutoSteps.Add(new int[5] {90,80,10,0,0});
                return c;
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
