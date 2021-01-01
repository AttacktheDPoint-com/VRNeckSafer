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
using SharpDX;

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

        public float trans_offset_LR;
        public float trans_offset_F;
        public Vector3 trans_offset;

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
            transFNUP.Value = conf.TransF;
            transLRNUP.Value = conf.TransLR;
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

            js.setJoystickButton(conf.JoystickGUID, conf.LeftButton, conf.Use8WayHat, ref but_left, ref pov_left);
            js.setJoystickButton(conf.JoystickGUID, conf.RightButton, conf.Use8WayHat, ref but_right, ref pov_right);
            js.setJoystickButton(conf.JoystickGUID, conf.ResetButton, conf.Use8WayHat, ref but_reset, ref pov_reset);

            setComboBoxes();

            loopTimer.Start();
        }

        private void enableAuto(bool enable)
        {
            label4.Enabled = enable;
            label5.Enabled = enable;
            label6.Enabled = enable;
            label7.Enabled = enable;
            activateNUP.Enabled = enable;
            deactivateNUD.Enabled = enable;
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

            leftCB.Items.Add("none");
            rightCB.Items.Add("none");
            resetCB.Items.Add("none");

            for (int i = 0; i < js.GetJoystick(JoystickCB.SelectedIndex).Capabilities.ButtonCount; i++)
            {
                leftCB.Items.Add("But: " + (i + 1));
                rightCB.Items.Add("But: " + (i + 1));
                resetCB.Items.Add("But: " + (i + 1));
            }
            for (int i = 0; i < js.GetJoystick(JoystickCB.SelectedIndex).Capabilities.PovCount; i++)
            {
                if (conf.Use8WayHat)
                {
                    for (int j = 0; j < 360; j += 45)
                    {
                        leftCB.Items.Add("P" + i + ": " + j);
                        rightCB.Items.Add("P" + i + ": " + j);
                        resetCB.Items.Add("P" + i + ": " + j);
                    }
                }
                else
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
            js.setJoystickButton(conf.JoystickGUID, conf.LeftButton, conf.Use8WayHat, ref but_left, ref pov_left);
        }

        private void rightCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conf.RightButton = rightCB.SelectedItem.ToString();
            conf.WriteConfig();
            js.setJoystickButton(conf.JoystickGUID, conf.RightButton, conf.Use8WayHat, ref but_right, ref pov_right);
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
            HMDYawBox.Enabled = !additivRB.Checked;
            translationBox1.Enabled = !additivRB.Checked;
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

            bool l_pressed = js.IsButtonPressed(conf.Use8WayHat, but_left, pov_left);
            bool r_pressed = js.IsButtonPressed(conf.Use8WayHat, but_right, pov_right);

            trans_offset = new Vector3(0, 0, 0);

            if (additivRB.Checked)
            {
                if (l_pressed && !lastpressed)
                    joy_offset_angle -= (int)angleNUD.Value;
                if (r_pressed && !lastpressed)
                    joy_offset_angle += (int)angleNUD.Value;
                HMDYawLabel.Text = "HMD yaw: -- deg";
            }
            else
            {
                if (l_pressed)
                {
                    joy_offset_angle = -(int)angleNUD.Value;
                    trans_offset.X = trans_offset_LR;
                    trans_offset.Z = trans_offset_F;
                }
                else if (r_pressed)
                {
                    joy_offset_angle = (int)angleNUD.Value;
                    trans_offset.X = -trans_offset_LR;
                    trans_offset.Z = trans_offset_F;
                }
                else
                    joy_offset_angle = 0;

                if (js.IsButtonPressed(conf.Use8WayHat, but_reset, pov_reset))
                {
                    vr.getHmdSeatedPositionOffset();
                    hmdYawOffset = vr.getHmdYaw();
                }

                int hmdYaw = -(vr.getHmdYaw() - hmdYawOffset + sum_offset_angle);

                if (hmdYaw < -180)
                    hmdYaw += 360;
                if (hmdYaw > 180)
                    hmdYaw -= 360;

                if (vr.HmdIsActive())
                    HMDYawLabel.Text = "HMD yaw: " + hmdYaw + " deg";
                else
                    HMDYawLabel.Text = "HMD yaw: standby";

                if (autoCB.Checked)
                {

                    if (hmdYaw > 0 && hmdYaw > activateNUP.Value)
                    {
                        auto_offset_angle = (int)angleNUD.Value;
                        trans_offset.X = -trans_offset_LR;
                        trans_offset.Z = trans_offset_F;
                    }
                    else if (hmdYaw > 0 && hmdYaw < deactivateNUD.Value)
                    {
                        auto_offset_angle = 0;
                    }
                    else if (hmdYaw < 0 && hmdYaw < -activateNUP.Value)
                    {
                        auto_offset_angle = -(int)angleNUD.Value;
                        trans_offset.X = trans_offset_LR;
                        trans_offset.Z = trans_offset_F;
                    }
                    else if (hmdYaw < 0 && hmdYaw > -deactivateNUD.Value)
                    {
                        auto_offset_angle = 0;
                    }
                }
            }

            sum_offset_angle = joy_offset_angle + auto_offset_angle;

            if (last_offset_angle != sum_offset_angle)
            {
                if (autoCB.Checked && !additivRB.Checked && last_offset_angle != 0)
                {
                    sum_offset_angle = 0;
                    trans_offset.X = 0;
                    trans_offset.Z = 0;
                }

                trans_offset = vr.rotateCoord(trans_offset, -(float)((hmdYawOffset+ sum_offset_angle) * Math.PI / 180.0F));
                vr.setOffsetAngle(sum_offset_angle, trans_offset);
            }

            lastpressed = l_pressed || r_pressed;

            last_offset_angle = sum_offset_angle;

            Text = "VRNeckSafer (" + sum_offset_angle + " deg)";

            debugLabel.Text = vr.debugMsg;
        }

        private void zeroBT_Click(object sender, EventArgs e)
        {
            hmdYawOffset = vr.getHmdYaw();
        }

        private void resetCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conf.ResetButton = resetCB.SelectedItem.ToString();
            conf.WriteConfig();
            js.setJoystickButton(conf.JoystickGUID, conf.ResetButton, conf.Use8WayHat, ref but_reset, ref pov_reset);
        }

        private void transFNUP_ValueChanged(object sender, EventArgs e)
        {
            conf.TransF = (int)transFNUP.Value;
            trans_offset_F = (float)transFNUP.Value / 100F;
            conf.WriteConfig();
        }
        private void transLRNUP_ValueChanged(object sender, EventArgs e)
        {
            conf.TransLR = (int)transLRNUP.Value;
            trans_offset_LR = (float)transLRNUP.Value / 100F;
            conf.WriteConfig();
        }

    }
}
