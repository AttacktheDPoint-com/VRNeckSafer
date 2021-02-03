using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using System.IO;

namespace VRNeckSafer
{
    public class JoystickButton
    {
        public String JoystickGUID;
        public String Button;
        public String ModJoystickGUID;
        public String ModButton;
    }

    public class JoystickStuff
    {
        DirectInput DInput;
        public IList<DeviceInstance> ll;
        public List<Joystick> Sticks;
//        public Joystick Stick;
        public JoyBut jb;

        public List<bool[]> LastButtons;
        public List<int[]> LastPOVs;

        public JoystickStuff()
        {
            DInput = new DirectInput();
            GetJoysticks();
        }

        public string NameFromGuid(string guid)
        {
            if (guid=="none" ) return guid;
            string name = "invalid";
            for (int i = 0; i < ll.Count; i++)
            {
                if (ll[i].InstanceGuid.ToString() == guid)
                {
                    name = ll[i].InstanceName;
                    break;
                }
            }
            return name;
        }
        public int IndexFromGuid(string guid)
        {
            int index=-1;
            for (int i = 0; i < ll.Count; i++)
            {
                if (ll[i].InstanceGuid.ToString() == guid)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void GetJoysticks()
        {
            ll = DInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            Sticks = new List<Joystick>();
            LastButtons = new List<bool[]>();
            LastPOVs = new List<int[]>();

            for (int i = 0; i < ll.Count; i++)
            {
                LastButtons.Add(new bool[128]);
                LastPOVs.Add(new int[4]);
                Sticks.Add(new Joystick(DInput, ll[i].InstanceGuid));
                Sticks[i].Acquire();

            }
        }

        public bool IsButtonPressed(bool use8wayhat, ButtonConfig butconf)
        {
            bool pressed = IsPressed(use8wayhat, butconf.JoystickGUID, butconf.Button);
            if (butconf.UseModifier)
                pressed = pressed && IsPressed(use8wayhat, butconf.ModJoystickGUID, butconf.ModButton);
            return butconf.Invert?!pressed:pressed;
        }
        public bool IsPressed(bool use8wayhat, string JoystickGUID, string Button)
        {
            int j, b=-1, p=-1;

            j = IndexFromGuid(JoystickGUID);
            if (j == -1) return false;

            if (Button.StartsWith("But:"))
            {
                int.TryParse(Button.Substring(5), out b);
            }
            else if ((Button.StartsWith("Pov ")))
            {
                int.TryParse(Button.Substring(4, 1), out p);
                switch (Button.Substring(7))
                {
                    case "U":
                        b = 0;
                        break;
                    case "R":
                        b = 9000;
                        break;
                    case "D":
                        b = 18000;
                        break;
                    case "L":
                        b = 27000;
                        break;
                }
            }
            else if ((Button.StartsWith("P")))
            {
                int.TryParse(Button.Substring(1, 1), out p);
                int.TryParse(Button.Substring(4), out b);
                b *= 100;
            }

            JoystickState State = Sticks[j].GetCurrentState();
            if ((p == -1) && (b == -1)) return false;

            if (p == -1)
            {
                return State.Buttons[b - 1];
            }
            else
            {
                if (State.PointOfViewControllers[p] == -1) return false;
                if (use8wayhat)
                     return State.PointOfViewControllers[p] == b;
                
                return Math.Abs(State.PointOfViewControllers[p] - b) < 5000;
            }
        }
        public JoyBut ScanJoysticks()
        {
            jb = new JoyBut() { joyIndex = -1, btn = -1, pov = -1 };

            bool found = false;
            for (int i = 0; i < Sticks.Count; i++)
            {
                JoystickState State = Sticks[i].GetCurrentState();
                for (int k = 0; k < Sticks[i].Capabilities.ButtonCount; k++)
                {
                    if (State.Buttons[k] != LastButtons[i][k])
                    {
                        jb.joyIndex = i;
                        jb.btn = k;
                        jb.pov = -1;
                        found = true;
                        break;
                    }
                }
                for (int k = 0; k < Sticks[i].Capabilities.PovCount; k++)
                {
                    if (State.PointOfViewControllers[k] != LastPOVs[i][k])
                    {
                        jb.joyIndex = i;
                        jb.btn = State.PointOfViewControllers[k];
                        jb.pov = k;
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
            return jb;
        }
        public void InitScan()
        {
            for (int i = 0; i < Sticks.Count; i++)
            {
                JoystickState State = Sticks[i].GetCurrentState();
                Array.Copy(State.Buttons, LastButtons[i], 128);
                Array.Copy(State.PointOfViewControllers, LastPOVs[i], 4);
            }
        }
    }

    public class JoyBut
    {
        public int joyIndex;
        public int btn;
        public int pov;

    }
}
