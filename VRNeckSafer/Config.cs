using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace VRNeckSafer
{
    public class ButtonConfig
    {
        public string JoystickGUID;
        public string Button;
        public string ModJoystickGUID;
        public string ModButton;
        public bool UseModifier;
        public bool Use8WayHat;
        public bool Invert;
        public bool Toggle;
        [JsonIgnore]
        public bool togglestate;
        public bool laststate;
        public ButtonConfig()
        {
            JoystickGUID = "none";
            Button = "none";
            ModJoystickGUID = "none";
            ModButton = "none";
            UseModifier = false;
            Use8WayHat = false;
            Invert = false;
            Toggle = false;
            togglestate = false;
            laststate = false;
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
        public bool StartMinimized;
        public bool MinimizeToTray;
        public string GameMode;
        public string AppMode;
        public string PosCompensation;
        public int PitchLimForAutorot;
        public static string configfilename;
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
            GameMode = "Auto";
            AppMode = "Overlay";
            PosCompensation = "when seated";
            StartMinimized = false;
            MinimizeToTray = false;
            PitchLimForAutorot = 90;
            AutoSteps = new List<int[]>();
        }

        static public Config ReadConfig()
        {
            try
            {
                configfilename = @".\VRNeckSafer.cfg";
                string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                    configfilename = @".\" + args[1];

                Config c = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configfilename));
                if (c.AutoSteps.Count == 0)
                {
                    c.AutoSteps.Add(new int[5] { 60, 51, 10, 0, 0 });
                    c.AutoSteps.Add(new int[5] { 70, 61, 20, 5, 1 });
                    c.AutoSteps.Add(new int[5] { 80, 71, 30, 7, 3 });
                    c.AutoSteps.Add(new int[5] { 90, 81, 40, 10, 5 });
                    c.AutoSteps.Add(new int[5] { 100, 91, 50, 10, 5 });
                    c.AutoSteps.Add(new int[5] { 110, 101, 60, 10, 5 });
                    c.AutoSteps.Add(new int[5] { 120, 111, 70, 10, 5 });
                }
                return c;
            }
            catch (Exception)
            {
                Config conf = new Config();
                if (conf.AutoSteps.Count == 0)
                {
                    conf.AutoSteps.Add(new int[5] { 60, 51, 10, 0, 0 });
                    conf.AutoSteps.Add(new int[5] { 70, 61, 20, 5, 1 });
                    conf.AutoSteps.Add(new int[5] { 80, 71, 30, 7, 3 });
                    conf.AutoSteps.Add(new int[5] { 90, 81, 40, 10, 5 });
                    conf.AutoSteps.Add(new int[5] { 100, 91, 50, 10, 5 });
                    conf.AutoSteps.Add(new int[5] { 110, 101, 60, 10, 5 });
                    conf.AutoSteps.Add(new int[5] { 120, 111, 70, 10, 5 });
                }

                conf.WriteConfig();
                return conf;
            }
        }

        public void WriteConfig()
        {
            File.WriteAllText(configfilename, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
