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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupAuto = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SetHoldButton4 = new System.Windows.Forms.Button();
            this.SetHoldButton3 = new System.Windows.Forms.Button();
            this.SetHoldButton2 = new System.Windows.Forms.Button();
            this.SetHoldButton1 = new System.Windows.Forms.Button();
            this.autoCB = new System.Windows.Forms.CheckBox();
            this.AutorotGridView = new System.Windows.Forms.DataGridView();
            this.act = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.loopTimer = new System.Windows.Forms.Timer(this.components);
            this.HMDYawBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SetResetButton = new System.Windows.Forms.Button();
            this.HMDYawLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.modeLB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.transFNUP = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.angleNUD = new System.Windows.Forms.NumericUpDown();
            this.transLRNUP = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.snapRB = new System.Windows.Forms.RadioButton();
            this.additivRB = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SetLeftButton = new System.Windows.Forms.Button();
            this.SetRightButton = new System.Windows.Forms.Button();
            this.RightLabel = new System.Windows.Forms.Label();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.advancedConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimzedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.use8wayHATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.appModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceSeatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceStandingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PosCompensationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inSeatedModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inStandingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetOptionsToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutorotGridView)).BeginInit();
            this.HMDYawBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transFNUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transLRNUP)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupAuto
            // 
            this.groupAuto.Controls.Add(this.label2);
            this.groupAuto.Controls.Add(this.SetHoldButton4);
            this.groupAuto.Controls.Add(this.SetHoldButton3);
            this.groupAuto.Controls.Add(this.SetHoldButton2);
            this.groupAuto.Controls.Add(this.SetHoldButton1);
            this.groupAuto.Controls.Add(this.autoCB);
            this.groupAuto.Controls.Add(this.AutorotGridView);
            this.groupAuto.Controls.Add(this.AddButton);
            this.groupAuto.Controls.Add(this.DeleteButton);
            this.groupAuto.Location = new System.Drawing.Point(12, 283);
            this.groupAuto.Name = "groupAuto";
            this.groupAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupAuto.Size = new System.Drawing.Size(256, 181);
            this.groupAuto.TabIndex = 13;
            this.groupAuto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 54;
            this.label2.Text = "Hold Buttons";
            // 
            // SetHoldButton4
            // 
            this.SetHoldButton4.Location = new System.Drawing.Point(8, 148);
            this.SetHoldButton4.Name = "SetHoldButton4";
            this.SetHoldButton4.Size = new System.Drawing.Size(66, 23);
            this.SetHoldButton4.TabIndex = 45;
            this.SetHoldButton4.Text = "Hold 4";
            this.SetHoldButton4.UseVisualStyleBackColor = true;
            this.SetHoldButton4.Click += new System.EventHandler(this.SetHoldButton4_Click);
            // 
            // SetHoldButton3
            // 
            this.SetHoldButton3.Location = new System.Drawing.Point(8, 119);
            this.SetHoldButton3.Name = "SetHoldButton3";
            this.SetHoldButton3.Size = new System.Drawing.Size(66, 23);
            this.SetHoldButton3.TabIndex = 44;
            this.SetHoldButton3.Text = "Hold 3";
            this.SetHoldButton3.UseVisualStyleBackColor = true;
            this.SetHoldButton3.Click += new System.EventHandler(this.SetHoldButton3_Click);
            // 
            // SetHoldButton2
            // 
            this.SetHoldButton2.Location = new System.Drawing.Point(8, 90);
            this.SetHoldButton2.Name = "SetHoldButton2";
            this.SetHoldButton2.Size = new System.Drawing.Size(66, 23);
            this.SetHoldButton2.TabIndex = 43;
            this.SetHoldButton2.Text = "Hold 2";
            this.SetHoldButton2.UseVisualStyleBackColor = true;
            this.SetHoldButton2.Click += new System.EventHandler(this.SetHoldButton2_Click);
            // 
            // SetHoldButton1
            // 
            this.SetHoldButton1.Location = new System.Drawing.Point(9, 61);
            this.SetHoldButton1.Name = "SetHoldButton1";
            this.SetHoldButton1.Size = new System.Drawing.Size(66, 23);
            this.SetHoldButton1.TabIndex = 42;
            this.SetHoldButton1.Text = "Hold 1";
            this.SetHoldButton1.UseVisualStyleBackColor = true;
            this.SetHoldButton1.Click += new System.EventHandler(this.SetHoldButton1_Click);
            // 
            // autoCB
            // 
            this.autoCB.AutoSize = true;
            this.autoCB.Cursor = System.Windows.Forms.Cursors.Default;
            this.autoCB.Location = new System.Drawing.Point(13, 20);
            this.autoCB.Name = "autoCB";
            this.autoCB.Size = new System.Drawing.Size(59, 17);
            this.autoCB.TabIndex = 15;
            this.autoCB.Text = "Enable";
            this.autoCB.UseVisualStyleBackColor = true;
            this.autoCB.CheckedChanged += new System.EventHandler(this.autoCB_CheckedChanged);
            // 
            // AutorotGridView
            // 
            this.AutorotGridView.AllowUserToAddRows = false;
            this.AutorotGridView.AllowUserToDeleteRows = false;
            this.AutorotGridView.AllowUserToResizeColumns = false;
            this.AutorotGridView.AllowUserToResizeRows = false;
            this.AutorotGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AutorotGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.act,
            this.deact,
            this.rot,
            this.LR,
            this.Fwd});
            this.AutorotGridView.Location = new System.Drawing.Point(81, 47);
            this.AutorotGridView.Name = "AutorotGridView";
            this.AutorotGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AutorotGridView.Size = new System.Drawing.Size(169, 123);
            this.AutorotGridView.TabIndex = 39;
            this.AutorotGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AutorotGridView_CellValueChanged);
            this.AutorotGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.AutorotGridView_RowsAdded);
            this.AutorotGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.AutorotGridView_RowsRemoved);
            // 
            // act
            // 
            this.act.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.act.HeaderText = "act";
            this.act.Name = "act";
            this.act.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.act.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.act.ToolTipText = "Activation angle";
            this.act.Width = 30;
            // 
            // deact
            // 
            this.deact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deact.HeaderText = "deact";
            this.deact.Name = "deact";
            this.deact.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.deact.ToolTipText = "Deactivation angle";
            this.deact.Width = 30;
            // 
            // rot
            // 
            this.rot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.rot.HeaderText = "rotation";
            this.rot.Name = "rot";
            this.rot.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rot.Width = 30;
            // 
            // LR
            // 
            this.LR.HeaderText = "L/R";
            this.LR.Name = "LR";
            this.LR.Width = 30;
            // 
            // Fwd
            // 
            this.Fwd.HeaderText = "Fwd";
            this.Fwd.Name = "Fwd";
            this.Fwd.Width = 30;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(156, 18);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(43, 23);
            this.AddButton.TabIndex = 40;
            this.AddButton.Text = "add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(207, 18);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(43, 23);
            this.DeleteButton.TabIndex = 41;
            this.DeleteButton.Text = "del";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(235, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Set Reset button to the same button as in game:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "-  IL-2:  \"Defaulr VR View\"  ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "-  DCS: \"recenter VR Headset\"";
            // 
            // loopTimer
            // 
            this.loopTimer.Interval = 10;
            this.loopTimer.Tick += new System.EventHandler(this.loopTimer_Tick);
            // 
            // HMDYawBox
            // 
            this.HMDYawBox.Controls.Add(this.label3);
            this.HMDYawBox.Controls.Add(this.SetResetButton);
            this.HMDYawBox.Controls.Add(this.HMDYawLabel);
            this.HMDYawBox.Controls.Add(this.label11);
            this.HMDYawBox.Controls.Add(this.label12);
            this.HMDYawBox.Controls.Add(this.label10);
            this.HMDYawBox.Location = new System.Drawing.Point(12, 19);
            this.HMDYawBox.Name = "HMDYawBox";
            this.HMDYawBox.Size = new System.Drawing.Size(256, 100);
            this.HMDYawBox.TabIndex = 31;
            this.HMDYawBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "Calibration";
            // 
            // SetResetButton
            // 
            this.SetResetButton.Location = new System.Drawing.Point(165, 59);
            this.SetResetButton.Name = "SetResetButton";
            this.SetResetButton.Size = new System.Drawing.Size(71, 35);
            this.SetResetButton.TabIndex = 28;
            this.SetResetButton.Text = "Set Reset Button";
            this.SetResetButton.UseVisualStyleBackColor = true;
            this.SetResetButton.Click += new System.EventHandler(this.SetResetButton_Click);
            // 
            // HMDYawLabel
            // 
            this.HMDYawLabel.AutoSize = true;
            this.HMDYawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HMDYawLabel.Location = new System.Drawing.Point(67, 21);
            this.HMDYawLabel.Name = "HMDYawLabel";
            this.HMDYawLabel.Size = new System.Drawing.Size(101, 13);
            this.HMDYawLabel.TabIndex = 27;
            this.HMDYawLabel.Text = "HMD yaw: 0 deg";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(237, 470);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VersionLabel.Size = new System.Drawing.Size(28, 13);
            this.VersionLabel.TabIndex = 34;
            this.VersionLabel.Text = "v2.0";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // modeLB
            // 
            this.modeLB.AutoSize = true;
            this.modeLB.Location = new System.Drawing.Point(6, 470);
            this.modeLB.Name = "modeLB";
            this.modeLB.Size = new System.Drawing.Size(86, 13);
            this.modeLB.TabIndex = 35;
            this.modeLB.Text = "(Mode: standing)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.transFNUP);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.angleNUD);
            this.groupBox1.Controls.Add(this.transLRNUP);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.snapRB);
            this.groupBox1.Controls.Add(this.additivRB);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.SetLeftButton);
            this.groupBox1.Controls.Add(this.SetRightButton);
            this.groupBox1.Controls.Add(this.RightLabel);
            this.groupBox1.Controls.Add(this.LeftLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 146);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(7, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 15);
            this.label25.TabIndex = 53;
            this.label25.Text = "Mode";
            // 
            // transFNUP
            // 
            this.transFNUP.Location = new System.Drawing.Point(168, 97);
            this.transFNUP.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.transFNUP.Name = "transFNUP";
            this.transFNUP.Size = new System.Drawing.Size(44, 20);
            this.transFNUP.TabIndex = 26;
            this.transFNUP.ValueChanged += new System.EventHandler(this.transFNUP_ValueChanged);
            this.transFNUP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.transFNUP_KeyUp);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(131, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 15);
            this.label24.TabIndex = 52;
            this.label24.Text = "Translation";
            // 
            // angleNUD
            // 
            this.angleNUD.Location = new System.Drawing.Point(34, 72);
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
            this.angleNUD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.angleNUD_KeyUp);
            // 
            // transLRNUP
            // 
            this.transLRNUP.Location = new System.Drawing.Point(168, 71);
            this.transLRNUP.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.transLRNUP.Name = "transLRNUP";
            this.transLRNUP.Size = new System.Drawing.Size(44, 20);
            this.transLRNUP.TabIndex = 25;
            this.transLRNUP.ValueChanged += new System.EventHandler(this.transLRNUP_ValueChanged);
            this.transLRNUP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.transLRNUP_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "deg";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(215, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "cm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(135, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "L/R";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(7, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 15);
            this.label23.TabIndex = 51;
            this.label23.Text = "Rotation";
            // 
            // snapRB
            // 
            this.snapRB.AutoSize = true;
            this.snapRB.Checked = true;
            this.snapRB.Location = new System.Drawing.Point(12, 120);
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
            this.additivRB.Location = new System.Drawing.Point(68, 120);
            this.additivRB.Name = "additivRB";
            this.additivRB.Size = new System.Drawing.Size(89, 17);
            this.additivRB.TabIndex = 12;
            this.additivRB.Text = "Accumulative";
            this.additivRB.UseVisualStyleBackColor = true;
            this.additivRB.CheckedChanged += new System.EventHandler(this.additivRB_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(135, 99);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Fwd.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(5, -1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 16);
            this.label19.TabIndex = 48;
            this.label19.Text = "Manual rotation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "+/-";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(215, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "cm";
            // 
            // SetLeftButton
            // 
            this.SetLeftButton.Location = new System.Drawing.Point(39, 23);
            this.SetLeftButton.Name = "SetLeftButton";
            this.SetLeftButton.Size = new System.Drawing.Size(72, 23);
            this.SetLeftButton.TabIndex = 36;
            this.SetLeftButton.Text = "Set Button";
            this.SetLeftButton.UseVisualStyleBackColor = true;
            this.SetLeftButton.Click += new System.EventHandler(this.SetLeftButton_Click);
            // 
            // SetRightButton
            // 
            this.SetRightButton.Location = new System.Drawing.Point(166, 23);
            this.SetRightButton.Name = "SetRightButton";
            this.SetRightButton.Size = new System.Drawing.Size(72, 23);
            this.SetRightButton.TabIndex = 37;
            this.SetRightButton.Text = "Set Button";
            this.SetRightButton.UseVisualStyleBackColor = true;
            this.SetRightButton.Click += new System.EventHandler(this.SetRightButton_Click);
            // 
            // RightLabel
            // 
            this.RightLabel.AutoSize = true;
            this.RightLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightLabel.Location = new System.Drawing.Point(133, 24);
            this.RightLabel.Margin = new System.Windows.Forms.Padding(0);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(35, 22);
            this.RightLabel.TabIndex = 39;
            this.RightLabel.Text = "R :";
            // 
            // LeftLabel
            // 
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftLabel.Location = new System.Drawing.Point(4, 23);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(36, 24);
            this.LeftLabel.TabIndex = 38;
            this.LeftLabel.Text = "L :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(16, 280);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(91, 16);
            this.label26.TabIndex = 54;
            this.label26.Text = "Autorotation";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedConfigToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(276, 24);
            this.menuStrip.TabIndex = 55;
            this.menuStrip.Text = "menuStrip";
            // 
            // advancedConfigToolStripMenuItem
            // 
            this.advancedConfigToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.advancedConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMinimzedToolStripMenuItem,
            this.minimizeToTrayToolStripMenuItem,
            this.toolStripSeparator1,
            this.use8wayHATToolStripMenuItem,
            this.toolStripSeparator2,
            this.appModeToolStripMenuItem,
            this.gameModeToolStripMenuItem,
            this.PosCompensationToolStripMenuItem,
            this.toolStripSeparator3,
            this.resetOptionsToDefaultToolStripMenuItem});
            this.advancedConfigToolStripMenuItem.Name = "advancedConfigToolStripMenuItem";
            this.advancedConfigToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.advancedConfigToolStripMenuItem.Text = "Options";
            // 
            // startMinimzedToolStripMenuItem
            // 
            this.startMinimzedToolStripMenuItem.CheckOnClick = true;
            this.startMinimzedToolStripMenuItem.Name = "startMinimzedToolStripMenuItem";
            this.startMinimzedToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.startMinimzedToolStripMenuItem.Text = "Start minimzed";
            this.startMinimzedToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.startMinimzedToolStripMenuItem_CheckStateChanged);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.CheckOnClick = true;
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.minimizeToTrayToolStripMenuItem.Text = "Minimize to tray";
            this.minimizeToTrayToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_CheckStateChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // use8wayHATToolStripMenuItem
            // 
            this.use8wayHATToolStripMenuItem.CheckOnClick = true;
            this.use8wayHATToolStripMenuItem.Name = "use8wayHATToolStripMenuItem";
            this.use8wayHATToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.use8wayHATToolStripMenuItem.Text = "Use 8-way HAT";
            this.use8wayHATToolStripMenuItem.CheckedChanged += new System.EventHandler(this.use8wayHATToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // appModeToolStripMenuItem
            // 
            this.appModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overlayToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.appModeToolStripMenuItem.Name = "appModeToolStripMenuItem";
            this.appModeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.appModeToolStripMenuItem.Text = "App  mode";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.ToolTipText = "Changes require restart!";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // overlayToolStripMenuItem
            // 
            this.overlayToolStripMenuItem.Name = "overlayToolStripMenuItem";
            this.overlayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.overlayToolStripMenuItem.Text = "Overlay";
            this.overlayToolStripMenuItem.ToolTipText = "Changes require restart!";
            this.overlayToolStripMenuItem.Click += new System.EventHandler(this.overlayToolStripMenuItem_Click);
            // 
            // gameModeToolStripMenuItem
            // 
            this.gameModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.forceSeatedToolStripMenuItem,
            this.forceStandingToolStripMenuItem});
            this.gameModeToolStripMenuItem.Name = "gameModeToolStripMenuItem";
            this.gameModeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.gameModeToolStripMenuItem.Text = "Game mode";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // forceSeatedToolStripMenuItem
            // 
            this.forceSeatedToolStripMenuItem.Name = "forceSeatedToolStripMenuItem";
            this.forceSeatedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forceSeatedToolStripMenuItem.Text = "Force seated";
            this.forceSeatedToolStripMenuItem.Click += new System.EventHandler(this.forceSeatedToolStripMenuItem_Click);
            // 
            // forceStandingToolStripMenuItem
            // 
            this.forceStandingToolStripMenuItem.Name = "forceStandingToolStripMenuItem";
            this.forceStandingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.forceStandingToolStripMenuItem.Text = "Force standing";
            this.forceStandingToolStripMenuItem.Click += new System.EventHandler(this.forceStandingToolStripMenuItem_Click);
            // 
            // PosCompensationToolStripMenuItem
            // 
            this.PosCompensationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inSeatedModeToolStripMenuItem,
            this.inStandingModeToolStripMenuItem,
            this.alwaysToolStripMenuItem,
            this.neverToolStripMenuItem});
            this.PosCompensationToolStripMenuItem.Name = "PosCompensationToolStripMenuItem";
            this.PosCompensationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.PosCompensationToolStripMenuItem.Text = "Position compensation";
            // 
            // inSeatedModeToolStripMenuItem
            // 
            this.inSeatedModeToolStripMenuItem.Name = "inSeatedModeToolStripMenuItem";
            this.inSeatedModeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.inSeatedModeToolStripMenuItem.Text = "in seated mode";
            this.inSeatedModeToolStripMenuItem.Click += new System.EventHandler(this.inSeatedModeToolStripMenuItem_Click);
            // 
            // inStandingModeToolStripMenuItem
            // 
            this.inStandingModeToolStripMenuItem.Name = "inStandingModeToolStripMenuItem";
            this.inStandingModeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.inStandingModeToolStripMenuItem.Text = "in standing mode";
            this.inStandingModeToolStripMenuItem.Click += new System.EventHandler(this.inStandingModeToolStripMenuItem_Click);
            // 
            // alwaysToolStripMenuItem
            // 
            this.alwaysToolStripMenuItem.Name = "alwaysToolStripMenuItem";
            this.alwaysToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.alwaysToolStripMenuItem.Text = "always";
            this.alwaysToolStripMenuItem.Click += new System.EventHandler(this.alwaysToolStripMenuItem_Click);
            // 
            // neverToolStripMenuItem
            // 
            this.neverToolStripMenuItem.Name = "neverToolStripMenuItem";
            this.neverToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.neverToolStripMenuItem.Text = "never";
            this.neverToolStripMenuItem.Click += new System.EventHandler(this.neverToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // resetOptionsToDefaultToolStripMenuItem
            // 
            this.resetOptionsToDefaultToolStripMenuItem.Name = "resetOptionsToDefaultToolStripMenuItem";
            this.resetOptionsToDefaultToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.resetOptionsToDefaultToolStripMenuItem.Text = "Reset options to default";
            this.resetOptionsToDefaultToolStripMenuItem.Click += new System.EventHandler(this.resetOptionsToDefaultToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "VRNeckSafer";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 491);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.modeLB);
            this.Controls.Add(this.HMDYawBox);
            this.Controls.Add(this.groupAuto);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(292, 3070);
            this.MinimumSize = new System.Drawing.Size(292, 530);
            this.Name = "MainForm";
            this.Text = "VRNeckSafer";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupAuto.ResumeLayout(false);
            this.groupAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutorotGridView)).EndInit();
            this.HMDYawBox.ResumeLayout(false);
            this.HMDYawBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transFNUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transLRNUP)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupAuto;
        private System.Windows.Forms.CheckBox autoCB;
        private System.Windows.Forms.Timer loopTimer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox HMDYawBox;
        private System.Windows.Forms.Label HMDYawLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label modeLB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.NumericUpDown transFNUP;
        private System.Windows.Forms.NumericUpDown transLRNUP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown angleNUD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SetLeftButton;
        private System.Windows.Forms.RadioButton additivRB;
        private System.Windows.Forms.Button SetRightButton;
        private System.Windows.Forms.RadioButton snapRB;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView AutorotGridView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SetHoldButton4;
        private System.Windows.Forms.Button SetHoldButton3;
        private System.Windows.Forms.Button SetHoldButton2;
        private System.Windows.Forms.Button SetHoldButton1;
        private System.Windows.Forms.Button SetResetButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem advancedConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem use8wayHATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimzedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceSeatedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceStandingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn act;
        private System.Windows.Forms.DataGridViewTextBoxColumn deact;
        private System.Windows.Forms.DataGridViewTextBoxColumn rot;
        private System.Windows.Forms.DataGridViewTextBoxColumn LR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fwd;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem PosCompensationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetOptionsToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inSeatedModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inStandingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neverToolStripMenuItem;
    }
}

