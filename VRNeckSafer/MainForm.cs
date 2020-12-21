using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SharpDX.DirectInput;
using Newtonsoft.Json;

namespace VRNeckSafer
{

    public partial class MainForm : Form
    {
        JoystickStuff js;
        VRStuff vr;
        Config conf;

        public int but_left;
        public int pov_left;
        public int but_right;
        public int pov_right;
        public int but_reset;
        public int pov_reset;

        public int joy_offset_angle;
        public int auto_offset_angle;
        public int sum_offset_angle;
        public int last_offset_angle;

        public int hmdYaw;
        public int hmdYawOffset;

        public bool lastpressed;
        public MainForm()
        {

            conf = Config.ReadConfig();

            InitializeComponent();

            js = new JoystickStuff();
            vr = new VRStuff();

            angleNUD.Value = conf.Angle;
            additivRB.Checked = conf.Additiv;
            autoCB.Checked = conf.Auto;
            activateNUP.Value = conf.ActivationAngle;
            deactivateNUD.Value = conf.DeactivationAngle;
            leftCB.Text = conf.LeftButton;
            rightCB.Text = conf.RightButton;
            resetCB.Text = conf.ResetButton;
            if (conf.Auto) enableAuto(true);
            else enableAuto(false);

            for (int i = 0; i < js.ll.Count; i++)
            {
                JoystickCB.Items.Add(js.ll[i].InstanceName);
                if (js.ll[i].InstanceGuid.ToString() == conf.JoystickGUID)
                {
                    JoystickCB.SelectedIndex = i;
                    js.setJoystick(js.ll[i].InstanceGuid);
                }
            }

            js.setJoystickButton(conf.JoystickGUID, conf.LeftButton, ref but_left, ref pov_left);
            js.setJoystickButton(conf.JoystickGUID, conf.RightButton, ref but_right, ref pov_right);
            js.setJoystickButton(conf.JoystickGUID, conf.ResetButton, ref but_reset, ref pov_reset);

            setComboBoxes();

            loopTimer.Start();
        }

        private void enableAuto(bool enable)
        {
            label4.Enabled = enable;
            label5.Enabled = enable;
            label6.Enabled = enable;
            label7.Enabled = enable;
            label10.Enabled = enable;
            label11.Enabled = enable;
            label12.Enabled = enable;
            hmdyawLB.Enabled = enable;
            zeroBT.Enabled = enable;
            activateNUP.Enabled = enable;
            deactivateNUD.Enabled = enable;
            resetCB.Enabled = enable;
            if (!enable) auto_offset_angle = 0;
        }
        private void setComboBoxes()
        {
            if (JoystickCB.Items.Count == 0) return;
            if (JoystickCB.SelectedIndex == -1)
                JoystickCB.SelectedIndex = 0;

            JoystickCB.Text = JoystickCB.Items[JoystickCB.SelectedIndex].ToString();

            leftCB.Items.Clear();
            rightCB.Items.Clear();
            resetCB.Items.Clear();

            //            Joystick joy = js.GetJoystick(JoystickCB.SelectedIndex);

            for (int i = 0; i < js.GetJoystick(JoystickCB.SelectedIndex).Capabilities.ButtonCount; i++)
            {
                leftCB.Items.Add("But: " + (i+1));
                rightCB.Items.Add("But: " + (i + 1));
                resetCB.Items.Add("But: " + (i + 1));
            }
            for (int i = 0; i < js.GetJoystick(JoystickCB.SelectedIndex).Capabilities.PovCount; i++)
            {
                leftCB.Items.Add("Pov " + i + ": U");
                leftCB.Items.Add("Pov " + i + ": D");
                leftCB.Items.Add("Pov " + i + ": L");
                leftCB.Items.Add("Pov " + i + ": R");
                rightCB.Items.Add("Pov " + i + ": U");
                rightCB.Items.Add("Pov " + i + ": D");
                rightCB.Items.Add("Pov " + i + ": L");
                rightCB.Items.Add("Pov " + i + ": R");
                resetCB.Items.Add("Pov " + i + ": U");
                resetCB.Items.Add("Pov " + i + ": D");
                resetCB.Items.Add("Pov " + i + ": L");
                resetCB.Items.Add("Pov " + i + ": R");
                
            }

        }
        private void JoystickCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conf.JoystickGUID = js.ll[JoystickCB.SelectedIndex].InstanceGuid.ToString();
            conf.WriteConfig();
            setComboBoxes();
            js.setJoystick(js.ll[JoystickCB.SelectedIndex].InstanceGuid);
        }

        private void leftCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conf.LeftButton = leftCB.SelectedItem.ToString();
            conf.WriteConfig();
            js.setJoystickButton(conf.JoystickGUID, conf.LeftButton, ref but_left, ref pov_left);
        }

        private void rightCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conf.RightButton = rightCB.SelectedItem.ToString();
            conf.WriteConfig();
            js.setJoystickButton(conf.JoystickGUID, conf.RightButton, ref but_right, ref pov_right);
        }

        private void angleNUD_ValueChanged(object sender, EventArgs e)
        {
            conf.Angle = (int)angleNUD.Value;
            conf.WriteConfig();
        }

        private void activateNUP_ValueChanged(object sender, EventArgs e)
        {
            conf.ActivationAngle = (int)activateNUP.Value;
            conf.WriteConfig();
        }

        private void deactivateNUD_ValueChanged(object sender, EventArgs e)
        {
            conf.DeactivationAngle = (int)deactivateNUD.Value;
            conf.WriteConfig();
        }

        private void additivRB_CheckedChanged(object sender, EventArgs e)
        {
            conf.Additiv = additivRB.Checked;
            groupAuto.Enabled =!additivRB.Checked;
            conf.WriteConfig();
        }

        private void autoCB_CheckedChanged(object sender, EventArgs e)
        {
            conf.Auto = autoCB.Checked;
            enableAuto(autoCB.Checked);
            conf.WriteConfig();
        }
        private void loopTimer_Tick(object sender, EventArgs e)
        {

            bool l_pressed = js.IsButtonPressed(but_left, pov_left);
            bool r_pressed = js.IsButtonPressed(but_right, pov_right);

            if (additivRB.Checked)
            {
                if (l_pressed && !lastpressed)
                    joy_offset_angle -= (int)angleNUD.Value;
                if (r_pressed && !lastpressed)
                    joy_offset_angle += (int)angleNUD.Value;
            }
            else
            {
                if (l_pressed)
                    joy_offset_angle = -(int)angleNUD.Value;
                if (r_pressed)
                    joy_offset_angle = (int)angleNUD.Value;
                if (!(l_pressed || r_pressed))
                    joy_offset_angle = 0;

                if (autoCB.Checked)
                {
                    if (js.IsButtonPressed(but_reset, pov_reset))
                        hmdYawOffset = vr.getHmdYaw();

                    int y = vr.getHmdYaw();
                    int hmdYaw = -(vr.getHmdYaw() - hmdYawOffset + sum_offset_angle);
                    if (hmdYaw < -180)
                        hmdYaw += 360;
                    if (hmdYaw > 180) 
                        hmdYaw -= 360;

                    hmdyawLB.Text = "HMD yaw: " + hmdYaw + " deg";

                    if (hmdYaw > 0 && hmdYaw > activateNUP.Value)
                    {
                        auto_offset_angle = (int)angleNUD.Value;
                    }
                    else if (hmdYaw > 0 && hmdYaw < deactivateNUD.Value)
                    {
                        auto_offset_angle = 0;
                    }
                    else if (hmdYaw < 0 && hmdYaw < -activateNUP.Value)
                    {
                        auto_offset_angle = -(int)angleNUD.Value;
                    }
                    else if (hmdYaw < 0 && hmdYaw > -deactivateNUD.Value)
                    {
                        auto_offset_angle = 0;
                    }
                }
                else
                    hmdyawLB.Text = "Hmd yaw: -- deg";
            }

            sum_offset_angle = joy_offset_angle + auto_offset_angle;

            if (last_offset_angle != sum_offset_angle)
                vr.setOffsetAngle((float)((sum_offset_angle) * Math.PI/180.0));


            lastpressed = l_pressed || r_pressed;

            last_offset_angle = sum_offset_angle;

            Text = "VRNeckSafer (" + sum_offset_angle + " deg)";
        }

        private void zeroBT_Click(object sender, EventArgs e)
        {
            hmdYawOffset = vr.getHmdYaw();
        }

        private void resetCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conf.ResetButton = resetCB.SelectedItem.ToString();
            conf.WriteConfig();
            js.setJoystickButton(conf.JoystickGUID, conf.ResetButton, ref but_reset, ref pov_reset);
        }
    }
}
