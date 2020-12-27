using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using System.IO;

namespace VRNeckSafer
{
    class JoystickStuff
    {
        DirectInput DInput;
        public IList<DeviceInstance> ll;
        public Joystick Stick;
        public JoystickStuff()
        {
            DInput = new DirectInput();
            ll = DInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
        }
        public Joystick GetJoystick(int index)
        {
            return new Joystick(DInput, ll[index].InstanceGuid);
        }

        public void setJoystick(Guid guid)
        {
            Stick = new Joystick(DInput, guid);
            Stick.Acquire();
        }
        public bool IsButtonPressed(int but, int pov)
        {
            if (Stick == null) return false;

            if ((pov == -1) && (but == -1)) return false;

            JoystickState State = Stick.GetCurrentState();
            if (pov == -1)
            {  
                return State.Buttons[but - 1];
            }
            else
            {
                if (State.PointOfViewControllers[pov] == -1) return false;
                return Math.Abs(State.PointOfViewControllers[pov] - but) < 5000;
            }
        }
        public void setJoystickButton(String guid, String butstr, ref int but, ref int pov)
        {
            foreach (DeviceInstance joy in ll)
            {
               if (joy.InstanceGuid.ToString() == guid)
                {
                    but = -1;
                    pov = -1;

                    if (butstr.StartsWith("But:"))
                    {
                        int.TryParse(butstr.Substring(5), out but);
                        pov = -1;
                    }
                    else if ((butstr.StartsWith("Pov ")))
                    {
                        int.TryParse(butstr.Substring(4, 1), out pov);
                        switch (butstr.Substring(7))
                        {
                            case "U":
                                but = 0;
                                break;
                            case "R":
                                but = 9000;
                                break;
                            case "D":
                                but = 18000;
                                break;
                            case "L":
                                but = 27000;
                                break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
