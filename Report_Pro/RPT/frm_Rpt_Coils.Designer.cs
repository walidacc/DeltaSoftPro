namespace Report_Pro.RPT
{
    partial class frm_Rpt_Coils
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoWIP = new System.Windows.Forms.RadioButton();
            this.rdoRaw = new System.Windows.Forms.RadioButton();
            this.rdoFinshed = new System.Windows.Forms.RadioButton();
            this.rdoAll_1 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSourceID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fromDateProduction = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.ToDateProduction = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fromDatePurchase = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.ToDatePurchase = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtItem = new Report_Pro.MyControls.UC_Items();
            this.txtGroup = new Report_Pro.MyControls.Uc_Group();
            this.txtBranch = new Report_Pro.MyControls.UC_Branch();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThikness = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeatNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterialID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoBalanceUsed = new System.Windows.Forms.RadioButton();
            this.rdoBalanceNotUsed = new System.Windows.Forms.RadioButton();
            this.rdoBalanceZero = new System.Windows.Forms.RadioButton();
            this.rdoBalanceAll = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromDateProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDateProduction)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromDatePurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDatePurchase)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            this.headLbl.Size = new System.Drawing.Size(1014, 35);
            this.headLbl.Tag = "Coils Report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtSourceID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtItem);
            this.groupBox1.Controls.Add(this.txtGroup);
            this.groupBox1.Controls.Add(this.txtBranch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtThikness);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtWeight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHeatNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaterialID);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 276);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoWIP);
            this.groupBox5.Controls.Add(this.rdoRaw);
            this.groupBox5.Controls.Add(this.rdoFinshed);
            this.groupBox5.Controls.Add(this.rdoAll_1);
            this.groupBox5.Location = new System.Drawing.Point(596, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 41);
            this.groupBox5.TabIndex = 282;
            this.groupBox5.TabStop = false;
            // 
            // rdoWIP
            // 
            this.rdoWIP.AutoSize = true;
            this.rdoWIP.BackColor = System.Drawing.Color.Transparent;
            this.rdoWIP.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoWIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoWIP.Location = new System.Drawing.Point(168, 14);
            this.rdoWIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoWIP.Name = "rdoWIP";
            this.rdoWIP.Size = new System.Drawing.Size(45, 17);
            this.rdoWIP.TabIndex = 281;
            this.rdoWIP.Text = "WIP";
            this.rdoWIP.UseVisualStyleBackColor = false;
            // 
            // rdoRaw
            // 
            this.rdoRaw.AutoSize = true;
            this.rdoRaw.BackColor = System.Drawing.Color.Transparent;
            this.rdoRaw.Checked = true;
            this.rdoRaw.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoRaw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoRaw.Location = new System.Drawing.Point(82, 14);
            this.rdoRaw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoRaw.Name = "rdoRaw";
            this.rdoRaw.Size = new System.Drawing.Size(46, 17);
            this.rdoRaw.TabIndex = 280;
            this.rdoRaw.TabStop = true;
            this.rdoRaw.Text = "Raw";
            this.rdoRaw.UseVisualStyleBackColor = false;
            // 
            // rdoFinshed
            // 
            this.rdoFinshed.AutoSize = true;
            this.rdoFinshed.BackColor = System.Drawing.Color.Transparent;
            this.rdoFinshed.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoFinshed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoFinshed.Location = new System.Drawing.Point(253, 14);
            this.rdoFinshed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoFinshed.Name = "rdoFinshed";
            this.rdoFinshed.Size = new System.Drawing.Size(95, 17);
            this.rdoFinshed.TabIndex = 279;
            this.rdoFinshed.Text = "Finshed Goods";
            this.rdoFinshed.UseVisualStyleBackColor = false;
            // 
            // rdoAll_1
            // 
            this.rdoAll_1.AutoSize = true;
            this.rdoAll_1.BackColor = System.Drawing.Color.Transparent;
            this.rdoAll_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoAll_1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoAll_1.Location = new System.Drawing.Point(6, 14);
            this.rdoAll_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoAll_1.Name = "rdoAll_1";
            this.rdoAll_1.Size = new System.Drawing.Size(36, 17);
            this.rdoAll_1.TabIndex = 278;
            this.rdoAll_1.Text = "All";
            this.rdoAll_1.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(29, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "Source ID";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSourceID
            // 
            this.txtSourceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceID.Location = new System.Drawing.Point(103, 242);
            this.txtSourceID.Name = "txtSourceID";
            this.txtSourceID.Size = new System.Drawing.Size(134, 20);
            this.txtSourceID.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(29, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Item";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.fromDateProduction);
            this.groupBox4.Controls.Add(this.ToDateProduction);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(286, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(287, 68);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Production";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(65, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "From Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fromDateProduction
            // 
            // 
            // 
            // 
            this.fromDateProduction.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDateProduction.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.fromDateProduction.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDateProduction.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDateProduction.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDateProduction.BackgroundStyle.Class = "DateTimeInputBackground";
            this.fromDateProduction.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.fromDateProduction.ButtonDropDown.Visible = true;
            this.fromDateProduction.Location = new System.Drawing.Point(139, 16);
            // 
            // 
            // 
            this.fromDateProduction.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fromDateProduction.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.fromDateProduction.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.fromDateProduction.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fromDateProduction.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.fromDateProduction.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fromDateProduction.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDateProduction.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.fromDateProduction.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.fromDateProduction.MonthCalendar.DisplayMonth = new System.DateTime(2023, 3, 1, 0, 0, 0, 0);
            this.fromDateProduction.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.fromDateProduction.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fromDateProduction.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fromDateProduction.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fromDateProduction.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fromDateProduction.MonthCalendar.TodayButtonVisible = true;
            this.fromDateProduction.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fromDateProduction.Name = "fromDateProduction";
            this.fromDateProduction.Size = new System.Drawing.Size(135, 20);
            this.fromDateProduction.TabIndex = 19;
            // 
            // ToDateProduction
            // 
            // 
            // 
            // 
            this.ToDateProduction.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDateProduction.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.ToDateProduction.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDateProduction.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDateProduction.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDateProduction.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToDateProduction.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ToDateProduction.ButtonDropDown.Visible = true;
            this.ToDateProduction.Location = new System.Drawing.Point(139, 42);
            // 
            // 
            // 
            this.ToDateProduction.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToDateProduction.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToDateProduction.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToDateProduction.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToDateProduction.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDateProduction.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToDateProduction.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDateProduction.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToDateProduction.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToDateProduction.MonthCalendar.DisplayMonth = new System.DateTime(2023, 3, 1, 0, 0, 0, 0);
            this.ToDateProduction.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToDateProduction.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToDateProduction.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToDateProduction.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDateProduction.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToDateProduction.MonthCalendar.TodayButtonVisible = true;
            this.ToDateProduction.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToDateProduction.Name = "ToDateProduction";
            this.ToDateProduction.Size = new System.Drawing.Size(135, 20);
            this.ToDateProduction.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(65, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "To Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(29, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Group";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.fromDatePurchase);
            this.groupBox3.Controls.Add(this.ToDatePurchase);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(286, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 67);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(65, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "From Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // fromDatePurchase
            // 
            // 
            // 
            // 
            this.fromDatePurchase.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDatePurchase.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.fromDatePurchase.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDatePurchase.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDatePurchase.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDatePurchase.BackgroundStyle.Class = "DateTimeInputBackground";
            this.fromDatePurchase.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.fromDatePurchase.ButtonDropDown.Visible = true;
            this.fromDatePurchase.Location = new System.Drawing.Point(139, 16);
            // 
            // 
            // 
            this.fromDatePurchase.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fromDatePurchase.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.fromDatePurchase.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.fromDatePurchase.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fromDatePurchase.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.fromDatePurchase.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fromDatePurchase.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDatePurchase.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.fromDatePurchase.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.fromDatePurchase.MonthCalendar.DisplayMonth = new System.DateTime(2023, 3, 1, 0, 0, 0, 0);
            this.fromDatePurchase.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.fromDatePurchase.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.fromDatePurchase.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fromDatePurchase.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fromDatePurchase.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fromDatePurchase.MonthCalendar.TodayButtonVisible = true;
            this.fromDatePurchase.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fromDatePurchase.Name = "fromDatePurchase";
            this.fromDatePurchase.Size = new System.Drawing.Size(135, 20);
            this.fromDatePurchase.TabIndex = 19;
            // 
            // ToDatePurchase
            // 
            // 
            // 
            // 
            this.ToDatePurchase.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDatePurchase.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.ToDatePurchase.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDatePurchase.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDatePurchase.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDatePurchase.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToDatePurchase.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ToDatePurchase.ButtonDropDown.Visible = true;
            this.ToDatePurchase.Location = new System.Drawing.Point(139, 42);
            // 
            // 
            // 
            this.ToDatePurchase.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToDatePurchase.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToDatePurchase.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToDatePurchase.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToDatePurchase.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDatePurchase.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToDatePurchase.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDatePurchase.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToDatePurchase.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToDatePurchase.MonthCalendar.DisplayMonth = new System.DateTime(2023, 3, 1, 0, 0, 0, 0);
            this.ToDatePurchase.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToDatePurchase.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToDatePurchase.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToDatePurchase.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDatePurchase.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToDatePurchase.MonthCalendar.TodayButtonVisible = true;
            this.ToDatePurchase.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToDatePurchase.Name = "ToDatePurchase";
            this.ToDatePurchase.Size = new System.Drawing.Size(135, 20);
            this.ToDatePurchase.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(65, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "To Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(29, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Branch";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(103, 68);
            this.txtItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(360, 20);
            this.txtItem.TabIndex = 18;
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(103, 42);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(0);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(360, 20);
            this.txtGroup.TabIndex = 17;
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.Transparent;
            this.txtBranch.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBranch.Location = new System.Drawing.Point(103, 16);
            this.txtBranch.Margin = new System.Windows.Forms.Padding(0);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(360, 20);
            this.txtBranch.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(29, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Thickness";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtThikness
            // 
            this.txtThikness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThikness.Location = new System.Drawing.Point(103, 216);
            this.txtThikness.Name = "txtThikness";
            this.txtThikness.Size = new System.Drawing.Size(134, 20);
            this.txtThikness.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(29, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Width";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWidth
            // 
            this.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWidth.Location = new System.Drawing.Point(103, 190);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(134, 20);
            this.txtWidth.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(29, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Weight";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWeight
            // 
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight.Location = new System.Drawing.Point(103, 164);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(134, 20);
            this.txtWeight.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(29, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Heat No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHeatNo
            // 
            this.txtHeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeatNo.Location = new System.Drawing.Point(103, 138);
            this.txtHeatNo.Name = "txtHeatNo";
            this.txtHeatNo.Size = new System.Drawing.Size(134, 20);
            this.txtHeatNo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(29, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Material ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaterialID
            // 
            this.txtMaterialID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialID.Location = new System.Drawing.Point(103, 112);
            this.txtMaterialID.Name = "txtMaterialID";
            this.txtMaterialID.Size = new System.Drawing.Size(134, 20);
            this.txtMaterialID.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoBalanceUsed);
            this.groupBox2.Controls.Add(this.rdoBalanceNotUsed);
            this.groupBox2.Controls.Add(this.rdoBalanceZero);
            this.groupBox2.Controls.Add(this.rdoBalanceAll);
            this.groupBox2.Location = new System.Drawing.Point(596, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 41);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // rdoBalanceUsed
            // 
            this.rdoBalanceUsed.AutoSize = true;
            this.rdoBalanceUsed.BackColor = System.Drawing.Color.Transparent;
            this.rdoBalanceUsed.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoBalanceUsed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoBalanceUsed.Location = new System.Drawing.Point(155, 14);
            this.rdoBalanceUsed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoBalanceUsed.Name = "rdoBalanceUsed";
            this.rdoBalanceUsed.Size = new System.Drawing.Size(108, 17);
            this.rdoBalanceUsed.TabIndex = 281;
            this.rdoBalanceUsed.Text = "Under Production";
            this.rdoBalanceUsed.UseVisualStyleBackColor = false;
            this.rdoBalanceUsed.CheckedChanged += new System.EventHandler(this.rdoBalanceUsed_CheckedChanged);
            // 
            // rdoBalanceNotUsed
            // 
            this.rdoBalanceNotUsed.AutoSize = true;
            this.rdoBalanceNotUsed.BackColor = System.Drawing.Color.Transparent;
            this.rdoBalanceNotUsed.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoBalanceNotUsed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoBalanceNotUsed.Location = new System.Drawing.Point(64, 14);
            this.rdoBalanceNotUsed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoBalanceNotUsed.Name = "rdoBalanceNotUsed";
            this.rdoBalanceNotUsed.Size = new System.Drawing.Size(69, 17);
            this.rdoBalanceNotUsed.TabIndex = 280;
            this.rdoBalanceNotUsed.Text = "Not Used";
            this.rdoBalanceNotUsed.UseVisualStyleBackColor = false;
            this.rdoBalanceNotUsed.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdoBalanceZero
            // 
            this.rdoBalanceZero.AutoSize = true;
            this.rdoBalanceZero.BackColor = System.Drawing.Color.Transparent;
            this.rdoBalanceZero.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoBalanceZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoBalanceZero.Location = new System.Drawing.Point(285, 14);
            this.rdoBalanceZero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoBalanceZero.Name = "rdoBalanceZero";
            this.rdoBalanceZero.Size = new System.Drawing.Size(49, 17);
            this.rdoBalanceZero.TabIndex = 279;
            this.rdoBalanceZero.Text = "Used";
            this.rdoBalanceZero.UseVisualStyleBackColor = false;
            this.rdoBalanceZero.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdoBalanceAll
            // 
            this.rdoBalanceAll.AutoSize = true;
            this.rdoBalanceAll.BackColor = System.Drawing.Color.Transparent;
            this.rdoBalanceAll.Checked = true;
            this.rdoBalanceAll.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoBalanceAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdoBalanceAll.Location = new System.Drawing.Point(6, 14);
            this.rdoBalanceAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoBalanceAll.Name = "rdoBalanceAll";
            this.rdoBalanceAll.Size = new System.Drawing.Size(36, 17);
            this.rdoBalanceAll.TabIndex = 278;
            this.rdoBalanceAll.TabStop = true;
            this.rdoBalanceAll.Text = "All";
            this.rdoBalanceAll.UseVisualStyleBackColor = false;
            this.rdoBalanceAll.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 338);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1014, 311);
            this.crystalReportViewer1.TabIndex = 10;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frm_Rpt_Coils
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 649);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_Rpt_Coils";
            this.Text = "frm_Rpt_Coils";
            this.Load += new System.EventHandler(this.frm_Rpt_Coils_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fromDateProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDateProduction)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fromDatePurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDatePurchase)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton rdoBalanceNotUsed;
        public System.Windows.Forms.RadioButton rdoBalanceZero;
        public System.Windows.Forms.RadioButton rdoBalanceAll;
        public System.Windows.Forms.RadioButton rdoBalanceUsed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThikness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeatNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterialID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToDatePurchase;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fromDatePurchase;
        private MyControls.UC_Items txtItem;
        private MyControls.Uc_Group txtGroup;
        private MyControls.UC_Branch txtBranch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fromDateProduction;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToDateProduction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSourceID;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.RadioButton rdoWIP;
        public System.Windows.Forms.RadioButton rdoRaw;
        public System.Windows.Forms.RadioButton rdoFinshed;
        public System.Windows.Forms.RadioButton rdoAll_1;
    }
}