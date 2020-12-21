namespace VRNeckSafer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.JoystickCB = new System.Windows.Forms.ComboBox();
            this.leftCB = new System.Windows.Forms.ComboBox();
            this.rightCB = new System.Windows.Forms.ComboBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.angleNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.snapRB = new System.Windows.Forms.RadioButton();
            this.additivRB = new System.Windows.Forms.RadioButton();
            this.groupAuto = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.resetCB = new System.Windows.Forms.ComboBox();
            this.hmdyawLB = new System.Windows.Forms.Label();
            this.zeroBT = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.autoCB = new System.Windows.Forms.CheckBox();
            this.deactivateNUD = new System.Windows.Forms.NumericUpDown();
            this.activateNUP = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.loopTimer = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.angleNUD)).BeginInit();
            this.groupAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deactivateNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activateNUP)).BeginInit();
            this.SuspendLayout();
            // 
            // JoystickCB
            // 
            this.JoystickCB.FormattingEnabled = true;
            this.JoystickCB.Location = new System.Drawing.Point(11, 32);
            this.JoystickCB.Name = "JoystickCB";
            this.JoystickCB.Size = new System.Drawing.Size(135, 21);
            this.JoystickCB.TabIndex = 11;
            this.JoystickCB.SelectedIndexChanged += new System.EventHandler(this.JoystickCB_SelectedIndexChanged);
            // 
            // leftCB
            // 
            this.leftCB.FormattingEnabled = true;
            this.leftCB.Location = new System.Drawing.Point(152, 32);
            this.leftCB.Name = "leftCB";
            this.leftCB.Size = new System.Drawing.Size(64, 21);
            this.leftCB.TabIndex = 2;
            this.leftCB.SelectedIndexChanged += new System.EventHandler(this.leftCB_SelectedIndexChanged);
            // 
            // rightCB
            // 
            this.rightCB.FormattingEnabled = true;
            this.rightCB.Location = new System.Drawing.Point(222, 32);
            this.rightCB.Name = "rightCB";
            this.rightCB.Size = new System.Drawing.Size(64, 21);
            this.rightCB.TabIndex = 3;
            this.rightCB.SelectedIndexChanged += new System.EventHandler(this.rightCB_SelectedIndexChanged);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(13, 16);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(45, 13);
            this.lable1.TabIndex = 4;
            this.lable1.Text = "Joystick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Left button";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Right button";
            // 
            // angleNUD
            // 
            this.angleNUD.Location = new System.Drawing.Point(34, 82);
            this.angleNUD.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleNUD.Name = "angleNUD";
            this.angleNUD.Size = new System.Drawing.Size(38, 20);
            this.angleNUD.TabIndex = 9;
            this.angleNUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.angleNUD.ValueChanged += new System.EventHandler(this.angleNUD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Rotation:";
            // 
            // snapRB
            // 
            this.snapRB.AutoSize = true;
            this.snapRB.Checked = true;
            this.snapRB.Location = new System.Drawing.Point(16, 116);
            this.snapRB.Name = "snapRB";
            this.snapRB.Size = new System.Drawing.Size(50, 17);
            this.snapRB.TabIndex = 1;
            this.snapRB.TabStop = true;
            this.snapRB.Text = "Snap";
            this.snapRB.UseVisualStyleBackColor = true;
            // 
            // additivRB
            // 
            this.additivRB.AutoSize = true;
            this.additivRB.Location = new System.Drawing.Point(16, 139);
            this.additivRB.Name = "additivRB";
            this.additivRB.Size = new System.Drawing.Size(57, 17);
            this.additivRB.TabIndex = 12;
            this.additivRB.Text = "Additiv";
            this.additivRB.UseVisualStyleBackColor = true;
            this.additivRB.CheckedChanged += new System.EventHandler(this.additivRB_CheckedChanged);
            // 
            // groupAuto
            // 
            this.groupAuto.Controls.Add(this.label12);
            this.groupAuto.Controls.Add(this.label11);
            this.groupAuto.Controls.Add(this.label10);
            this.groupAuto.Controls.Add(this.resetCB);
            this.groupAuto.Controls.Add(this.hmdyawLB);
            this.groupAuto.Controls.Add(this.zeroBT);
            this.groupAuto.Controls.Add(this.label7);
            this.groupAuto.Controls.Add(this.label6);
            this.groupAuto.Controls.Add(this.label5);
            this.groupAuto.Controls.Add(this.label4);
            this.groupAuto.Controls.Add(this.autoCB);
            this.groupAuto.Controls.Add(this.deactivateNUD);
            this.groupAuto.Controls.Add(this.activateNUP);
            this.groupAuto.Location = new System.Drawing.Point(119, 61);
            this.groupAuto.Name = "groupAuto";
            this.groupAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupAuto.Size = new System.Drawing.Size(167, 156);
            this.groupAuto.TabIndex = 13;
            this.groupAuto.TabStop = false;
            this.groupAuto.Text = "Autorotate";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(12, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "To calibrate HMD Yaw look";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(16, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "straight ahead and press";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(65, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "or";
            // 
            // resetCB
            // 
            this.resetCB.FormattingEnabled = true;
            this.resetCB.Location = new System.Drawing.Point(83, 128);
            this.resetCB.Name = "resetCB";
            this.resetCB.Size = new System.Drawing.Size(64, 21);
            this.resetCB.TabIndex = 23;
            this.resetCB.SelectedIndexChanged += new System.EventHandler(this.resetCB_SelectedIndexChanged);
            // 
            // hmdyawLB
            // 
            this.hmdyawLB.AutoSize = true;
            this.hmdyawLB.Location = new System.Drawing.Point(63, 18);
            this.hmdyawLB.Name = "hmdyawLB";
            this.hmdyawLB.Size = new System.Drawing.Size(59, 13);
            this.hmdyawLB.TabIndex = 22;
            this.hmdyawLB.Text = "HMD Yaw:";
            // 
            // zeroBT
            // 
            this.zeroBT.Location = new System.Drawing.Point(6, 127);
            this.zeroBT.Name = "zeroBT";
            this.zeroBT.Size = new System.Drawing.Size(58, 23);
            this.zeroBT.TabIndex = 20;
            this.zeroBT.Text = "reset";
            this.zeroBT.UseVisualStyleBackColor = true;
            this.zeroBT.Click += new System.EventHandler(this.zeroBT_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(116, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "deg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(116, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "deg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "deactivate <";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(20, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "activate >";
            // 
            // autoCB
            // 
            this.autoCB.AutoSize = true;
            this.autoCB.Cursor = System.Windows.Forms.Cursors.Default;
            this.autoCB.Location = new System.Drawing.Point(5, 17);
            this.autoCB.Name = "autoCB";
            this.autoCB.Size = new System.Drawing.Size(59, 17);
            this.autoCB.TabIndex = 15;
            this.autoCB.Text = "Enable";
            this.autoCB.UseVisualStyleBackColor = true;
            this.autoCB.CheckedChanged += new System.EventHandler(this.autoCB_CheckedChanged);
            // 
            // deactivateNUD
            // 
            this.deactivateNUD.Enabled = false;
            this.deactivateNUD.Location = new System.Drawing.Point(75, 68);
            this.deactivateNUD.Maximum = new decimal(new int[] {
            369,
            0,
            0,
            0});
            this.deactivateNUD.Name = "deactivateNUD";
            this.deactivateNUD.Size = new System.Drawing.Size(38, 20);
            this.deactivateNUD.TabIndex = 14;
            this.deactivateNUD.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.deactivateNUD.ValueChanged += new System.EventHandler(this.deactivateNUD_ValueChanged);
            // 
            // activateNUP
            // 
            this.activateNUP.Enabled = false;
            this.activateNUP.Location = new System.Drawing.Point(75, 42);
            this.activateNUP.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.activateNUP.Name = "activateNUP";
            this.activateNUP.Size = new System.Drawing.Size(38, 20);
            this.activateNUP.TabIndex = 10;
            this.activateNUP.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.activateNUP.ValueChanged += new System.EventHandler(this.activateNUP_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "deg";
            // 
            // loopTimer
            // 
            this.loopTimer.Interval = 20;
            this.loopTimer.Tick += new System.EventHandler(this.loopTimer_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "+/-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 221);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupAuto);
            this.Controls.Add(this.additivRB);
            this.Controls.Add(this.snapRB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.rightCB);
            this.Controls.Add(this.leftCB);
            this.Controls.Add(this.JoystickCB);
            this.Name = "MainForm";
            this.Text = "VRNeckSafer";
            ((System.ComponentModel.ISupportInitialize)(this.angleNUD)).EndInit();
            this.groupAuto.ResumeLayout(false);
            this.groupAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deactivateNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activateNUP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox JoystickCB;
        private System.Windows.Forms.ComboBox leftCB;
        private System.Windows.Forms.ComboBox rightCB;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown angleNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton snapRB;
        private System.Windows.Forms.RadioButton additivRB;
        private System.Windows.Forms.GroupBox groupAuto;
        private System.Windows.Forms.CheckBox autoCB;
        private System.Windows.Forms.NumericUpDown deactivateNUD;
        private System.Windows.Forms.NumericUpDown activateNUP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer loopTimer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label hmdyawLB;
        private System.Windows.Forms.Button zeroBT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox resetCB;
    }
}

