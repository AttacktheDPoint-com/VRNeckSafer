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
        public JoystickStuff js;
        public VRStuff vr;
        public Config conf;

        public int joy_offset_angle;
        public int auto_offset_angle;
        public int sum_offset_angle;
        public int last_offset_angle;

        public float trans_offset_LR;
        public float trans_offset_F;
        public Vector3 trans_offset;

        public int hmdYaw;

        public bool lastpressed;
        private System.Drawing.Color ControlText;

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
            if (conf.Auto) enableAuto(true);
            else enableAuto(false);

            if (conf.Use8WayHat) use8wayHATToolStripMenuItem.Checked = true;
            if (conf.StartMinimized) startMinimzedToolStripMenuItem.Checked = true;
            if (conf.MinimizeToTray) minimizeToTrayToolStripMenuItem.Checked = true;

            for (int i = 0; i < conf.AutoSteps.Count; i++)
            {
                string [] r=new string[5]
                { 
                    conf.AutoSteps[i][0].ToString(),
                    conf.AutoSteps[i][1].ToString(),
                    conf.AutoSteps[i][2].ToString(),
                    conf.AutoSteps[i][3].ToString(),
                    conf.AutoSteps[i][4].ToString(),
                };
                AutorotGridView.Rows.Add(r);
            }

            AutorotGridView.RowHeadersVisible = false;
            AutorotGridView.Columns[0].HeaderText = @"act";
            AutorotGridView.Columns[1].HeaderText = @"de";
            AutorotGridView.Columns[2].HeaderText = @"rot";
            AutorotGridView.Columns[3].HeaderText = @"L/R";
            AutorotGridView.Columns[4].HeaderText = @"Fwd";


            setButtonToolTip(SetLeftButton, conf.LeftButton);
            setButtonToolTip(SetRightButton, conf.RightButton);
            setButtonToolTip(SetResetButton, conf.ResetButton);
            setButtonToolTip(SetHoldButton1, conf.HoldButton1);
            setButtonToolTip(SetHoldButton2, conf.HoldButton2);
            setButtonToolTip(SetHoldButton3, conf.HoldButton3);
            setButtonToolTip(SetHoldButton4, conf.HoldButton4);

            setLabelToolTip(LeftLabel, conf.LeftButton);
            setLabelToolTip(RightLabel, conf.RightButton);

            loopTimer.Start();
        }

        private void enableAuto(bool enable)
        {
            AddButton.Enabled = enable;
            DeleteButton.Enabled = enable;
            SetHoldButton1.Enabled = enable;
            SetHoldButton2.Enabled = enable;
            SetHoldButton3.Enabled = enable;
            SetHoldButton4.Enabled = enable;
            label2.Enabled = enable;
            AutorotGridView.Enabled = enable;
            AutorotGridView.ForeColor = enable?SystemColors.ControlText: System.Drawing.Color.Gray;
            if (!enable) auto_offset_angle = 0;
        }

        private void setButtonToolTip(Button b, ButtonConfig bc)
        {
            string Text = js.NameFromGuid(bc.JoystickGUID) + ": " + bc.Button;
            if (bc.UseModifier)
            {
                Text += "   +   " + js.NameFromGuid(bc.ModJoystickGUID) + ": " + bc.ModButton;
            }
            toolTip1.SetToolTip(b, Text);
        }

        private void setLabelToolTip(Label l, ButtonConfig bc)
        {
            string Text = js.NameFromGuid(bc.JoystickGUID) + ": " + bc.Button;
            if (bc.UseModifier)
            {
                Text += "   +   " + js.NameFromGuid(bc.ModJoystickGUID) + ": " + bc.ModButton;
            }
            toolTip1.SetToolTip(l, Text);
        }

        private void angleNUD_ValueChanged(object sender, EventArgs e)
        {
            conf.Angle = (int)angleNUD.Value;
            conf.WriteConfig();
        }
        private void angleNUD_KeyUp(object sender, KeyEventArgs e)
        {
            conf.Angle = (int)angleNUD.Value;
            conf.WriteConfig();
        }

        private void additivRB_CheckedChanged(object sender, EventArgs e)
        {
            conf.Additiv = additivRB.Checked;
            groupAuto.Enabled = !additivRB.Checked;
            HMDYawBox.Enabled = !additivRB.Checked;
            transLRNUP.Enabled = !additivRB.Checked;
            transFNUP.Enabled = !additivRB.Checked;
            label14.Enabled = !additivRB.Checked;
            label15.Enabled = !additivRB.Checked;
            label16.Enabled = !additivRB.Checked;
            label17.Enabled = !additivRB.Checked;
            conf.WriteConfig();
        }

        private void autoCB_CheckedChanged(object sender, EventArgs e)
        {
            conf.Auto = autoCB.Checked;
            enableAuto(autoCB.Checked);
            conf.WriteConfig();
        }

        bool checkButtonPress(Button b, ButtonConfig bc)
        {
            bool pressed = js.IsButtonPressed(conf.Use8WayHat, bc);
            if (pressed)
            {
                b.ForeColor = System.Drawing.Color.LightGreen;
                b.BackColor = SystemColors.ControlText;
            }
            else
            {
                b.ForeColor = SystemColors.ControlText;
                b.BackColor = SystemColors.Control;
            }
            return pressed;
        }
        private void loopTimer_Tick(object sender, EventArgs e)
        {

            bool l_pressed = checkButtonPress(SetLeftButton, conf.LeftButton);
            bool r_pressed = checkButtonPress(SetRightButton, conf.RightButton);
            bool autofrozen = 
                checkButtonPress(SetHoldButton1, conf.HoldButton1) ||
                checkButtonPress(SetHoldButton2, conf.HoldButton2) ||
                checkButtonPress(SetHoldButton3, conf.HoldButton3) ||
                checkButtonPress(SetHoldButton4, conf.HoldButton4);

            
            if (l_pressed)
            {
                LeftLabel.ForeColor = System.Drawing.Color.LightGreen;
                LeftLabel.BackColor = SystemColors.ControlText;
            }
            else
            {
                LeftLabel.ForeColor = SystemColors.ControlText;
                LeftLabel.BackColor = SystemColors.Control;
            }
            if (r_pressed)
            {
                RightLabel.ForeColor = System.Drawing.Color.LightGreen;
                RightLabel.BackColor = SystemColors.ControlText;
            }
            else
            {
                RightLabel.ForeColor = SystemColors.ControlText;
                RightLabel.BackColor = SystemColors.Control;
            }
            trans_offset = new Vector3(0, 0, 0);

            if (vr.isSeatedMode())
            {
                modeLB.Text = "(playing mode: seated)";
            }
            else
            {
                modeLB.Text = "(playing mode: standing)";
            }

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
                {
                    joy_offset_angle = 0;
                    trans_offset.X = 0;
                    trans_offset.Z = 0;
                }
                if (checkButtonPress(SetResetButton,conf.ResetButton))
                {
                    vr.getHmdSeatedPositionOffset();
                    vr.getHmdYawOffset();
                }

                int hmdYaw = -(vr.getHmdYaw() + sum_offset_angle);

                while (hmdYaw < -180) hmdYaw += 360;
                while (hmdYaw > 180) hmdYaw -= 360;

                if (vr.HmdIsActive())
                    HMDYawLabel.Text = "HMD yaw: " + hmdYaw + " deg";
                else
                    HMDYawLabel.Text = "HMD yaw: standby";

                if (autoCB.Checked && !autofrozen)
                {
                    calcAutoRotAndTrans(hmdYaw, ref auto_offset_angle, ref trans_offset);
                }
            }

            sum_offset_angle = joy_offset_angle + auto_offset_angle;


            if (last_offset_angle != sum_offset_angle)
            {
                vr.setOffset(sum_offset_angle, trans_offset);
            }

            lastpressed = l_pressed || r_pressed;

            last_offset_angle = sum_offset_angle;

            Text = "VRNeckSafer (" + sum_offset_angle + " deg)";
        }

        private void calcAutoRotAndTrans(int yaw, ref int arot, ref Vector3 atrans)
        {
            int yawsign = (yaw > 0) ? 1 : -1;
            int absyaw = yaw * yawsign;
            int arotsign = (arot > 0) ? 1 : -1;
            int absarot = arot * arotsign;
            int autorot = 0;
            int transx = 0;
            int transz = 0;


            int act;
            int deact = 0;
            int rot;
            int tx;
            int tz;

            for (int i = 0; i < conf.AutoSteps.Count; i++)
            {
                act = conf.AutoSteps[i][0];
                deact = conf.AutoSteps[i][1];
                rot = conf.AutoSteps[i][2];
                tx = conf.AutoSteps[i][3];
                tz = conf.AutoSteps[i][4];

                if (absyaw >= act)
                {
                    autorot = rot;
                    transx = tx;
                    transz = tz;
                }
                else
                {
                    break;
                }
            }

            if ((autorot < absarot) && (absyaw >= deact))
            {
                return;
            }
            arot = yawsign*autorot;
            if (transx > fabs(atrans.X)) atrans.X = (float)transx / 100.0F * -yawsign;
            if (transz > fabs(atrans.Z)) atrans.Z = (float)transz / 100.0F * -yawsign;
        }
        private void zeroBT_Click(object sender, EventArgs e)
        {
            vr.getHmdSeatedPositionOffset();
            vr.getHmdYaw();
        }

        private float fabs(float i)
        {
            return i < 0F ? -i : i;
        }

        private void transFNUP_ValueChanged(object sender, EventArgs e)
        {
            conf.TransF = (int)transFNUP.Value;
            trans_offset_F = (float)transFNUP.Value / 100F;
            conf.WriteConfig();
        }
        private void transFNUP_KeyUp(object sender, KeyEventArgs e)
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

        private void transLRNUP_KeyUp(object sender, KeyEventArgs e)
        {
            conf.TransLR = (int)transLRNUP.Value;
            trans_offset_LR = (float)transLRNUP.Value / 100F;
            conf.WriteConfig();
        }



        private void AddButton_Click(object sender, EventArgs e)
        {
            int[] i = new int[5];
            i[0] = conf.AutoSteps[conf.AutoSteps.Count - 1][0] + 10;
            i[1] = conf.AutoSteps[conf.AutoSteps.Count - 1][0] + 1;
            i[2] = conf.AutoSteps[conf.AutoSteps.Count - 1][2];
            i[3] = conf.AutoSteps[conf.AutoSteps.Count - 1][3];
            i[4] = conf.AutoSteps[conf.AutoSteps.Count - 1][4];
            conf.AutoSteps.Add(i);
            string[] s = new string[5]
            {
                conf.AutoSteps[conf.AutoSteps.Count-1][0].ToString(),
                conf.AutoSteps[conf.AutoSteps.Count-1][1].ToString(),
                conf.AutoSteps[conf.AutoSteps.Count-1][2].ToString(),
                conf.AutoSteps[conf.AutoSteps.Count-1][3].ToString(),
                conf.AutoSteps[conf.AutoSteps.Count-1][4].ToString(),
            };
            AutorotGridView.Rows.Add(s);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (conf.AutoSteps.Count > 1)
            {
                conf.AutoSteps.RemoveAt(conf.AutoSteps.Count - 1);
                AutorotGridView.Rows.Remove(AutorotGridView.Rows[AutorotGridView.RowCount - 1]);
            }
        }

        private void AutorotGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int val;

            if (e.RowIndex == -1) return;
            string s = AutorotGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            int.TryParse(s, out val);
            conf.AutoSteps[e.RowIndex][e.ColumnIndex]= val;
            conf.WriteConfig();
        }

        private void AutorotGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AutorotGridView.Height = AutorotGridView.RowCount * 22 + 22;
            AutorotGridView.MaximumSize = new System.Drawing.Size(AutorotGridView.Width, Size.Height - groupAuto.Location.Y - 124);

            conf.WriteConfig();
        }

        private void AutorotGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            AutorotGridView.Height = AutorotGridView.RowCount * 22 + 22;
            AutorotGridView.MaximumSize = new System.Drawing.Size(AutorotGridView.Width, Size.Height - groupAuto.Location.Y - 124);
            conf.WriteConfig();
        }

        private void startMinimzedToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            conf.StartMinimized = startMinimzedToolStripMenuItem.Checked;
            conf.WriteConfig();
        }

        private void minimizeToTrayToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            conf.MinimizeToTray = minimizeToTrayToolStripMenuItem.Checked;
            conf.WriteConfig();
        }

        private void use8wayHATToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            conf.Use8WayHat = use8wayHATToolStripMenuItem.Checked;
            conf.WriteConfig();
        }

        private void SetLeftButton_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Left Rotation:", conf.LeftButton);
            frm.ShowDialog();
            setButtonToolTip(SetLeftButton, conf.LeftButton);
            setLabelToolTip(LeftLabel, conf.LeftButton);
        }

        private void SetRightButton_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Right Rotation:", conf.RightButton);
            frm.ShowDialog();
            setButtonToolTip(SetRightButton, conf.RightButton);
            setLabelToolTip(RightLabel, conf.RightButton);
        }

        private void SetResetButton_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Reset:", conf.ResetButton);
            frm.ShowDialog();
            setButtonToolTip(SetResetButton, conf.ResetButton);
        }

        private void SetHoldButton1_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Reset:", conf.HoldButton1);
            frm.ShowDialog();
            setButtonToolTip(SetHoldButton1, conf.HoldButton1);
        }

        private void SetHoldButton2_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Reset:", conf.HoldButton2);
            frm.ShowDialog();
            setButtonToolTip(SetHoldButton2, conf.HoldButton2);
        }

        private void SetHoldButton3_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Reset:", conf.HoldButton3);
            frm.ShowDialog();
            setButtonToolTip(SetHoldButton3, conf.HoldButton3);
        }

        private void SetHoldButton4_Click(object sender, EventArgs e)
        {
            ButtonForm frm = new ButtonForm(this, "Button for Reset:", conf.HoldButton4);
            frm.ShowDialog();
            setButtonToolTip(SetHoldButton4, conf.HoldButton4);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            modeLB.Location = new System.Drawing.Point(modeLB.Location.X, Size.Height - 60);
            VersionLabel.Location = new System.Drawing.Point(VersionLabel.Location.X, Size.Height - 60);
            groupAuto.Height = Size.Height - groupAuto.Location.Y - 67;

            AutorotGridView.Height = AutorotGridView.RowCount * 22 + 22;
            AutorotGridView.MaximumSize = new System.Drawing.Size(AutorotGridView.Width, Size.Height - groupAuto.Location.Y - 124);
        }
    }
}
