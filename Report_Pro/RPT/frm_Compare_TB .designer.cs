﻿namespace Report_Pro.RPT
{
    partial class frm_Compare_TB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Compare_TB));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.T_Eb = new System.Windows.Forms.TextBox();
            this.T_Cr = new System.Windows.Forms.TextBox();
            this.T_Bb = new System.Windows.Forms.TextBox();
            this.T_Db = new System.Windows.Forms.TextBox();
            this.FromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.UserName = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RBtnAll = new System.Windows.Forms.RadioButton();
            this.RBtn4 = new System.Windows.Forms.RadioButton();
            this.RBtn1 = new System.Windows.Forms.RadioButton();
            this.RBtn3 = new System.Windows.Forms.RadioButton();
            this.RBtn2 = new System.Windows.Forms.RadioButton();
            this.ToDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RB_S_Acc = new System.Windows.Forms.RadioButton();
            this.RB_M_Acc = new System.Windows.Forms.RadioButton();
            this.RB_All_Acc = new System.Windows.Forms.RadioButton();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UC_Branch = new Report_Pro.MyControls.UC_AccBranch();
            this.UC_Catogry = new Report_Pro.MyControls.UC_Catogry();
            this.UC_cost = new Report_Pro.MyControls.UC_cost();
            this.UC_Acc = new Report_Pro.MyControls.UC_Acc();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.DataGridView1);
            this.panel3.Controls.Add(this.groupPanel2);
            this.panel3.Name = "panel3";
            // 
            // DataGridView1
            // 
            resources.ApplyResources(this.DataGridView1, "DataGridView1");
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column8
            // 
            resources.ApplyResources(this.Column8, "Column8");
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // groupPanel2
            // 
            resources.ApplyResources(this.groupPanel2, "groupPanel2");
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.T_Eb);
            this.groupPanel2.Controls.Add(this.T_Cr);
            this.groupPanel2.Controls.Add(this.T_Bb);
            this.groupPanel2.Controls.Add(this.T_Db);
            this.groupPanel2.Name = "groupPanel2";
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // T_Eb
            // 
            resources.ApplyResources(this.T_Eb, "T_Eb");
            this.T_Eb.BackColor = System.Drawing.Color.White;
            this.T_Eb.Name = "T_Eb";
            // 
            // T_Cr
            // 
            resources.ApplyResources(this.T_Cr, "T_Cr");
            this.T_Cr.BackColor = System.Drawing.Color.White;
            this.T_Cr.Name = "T_Cr";
            // 
            // T_Bb
            // 
            resources.ApplyResources(this.T_Bb, "T_Bb");
            this.T_Bb.BackColor = System.Drawing.Color.White;
            this.T_Bb.Name = "T_Bb";
            // 
            // T_Db
            // 
            resources.ApplyResources(this.T_Db, "T_Db");
            this.T_Db.BackColor = System.Drawing.Color.White;
            this.T_Db.Name = "T_Db";
            // 
            // FromDate
            // 
            resources.ApplyResources(this.FromDate, "FromDate");
            // 
            // 
            // 
            this.FromDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemDisabledText;
            this.FromDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromDate.ButtonClear.DisplayPosition = ((int)(resources.GetObject("FromDate.ButtonClear.DisplayPosition")));
            this.FromDate.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("FromDate.ButtonClear.Image")));
            this.FromDate.ButtonClear.Text = resources.GetString("FromDate.ButtonClear.Text");
            this.FromDate.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("FromDate.ButtonCustom.DisplayPosition")));
            this.FromDate.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("FromDate.ButtonCustom.Image")));
            this.FromDate.ButtonCustom.Text = resources.GetString("FromDate.ButtonCustom.Text");
            this.FromDate.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("FromDate.ButtonCustom2.DisplayPosition")));
            this.FromDate.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("FromDate.ButtonCustom2.Image")));
            this.FromDate.ButtonCustom2.Text = resources.GetString("FromDate.ButtonCustom2.Text");
            this.FromDate.ButtonDropDown.DisplayPosition = ((int)(resources.GetObject("FromDate.ButtonDropDown.DisplayPosition")));
            this.FromDate.ButtonDropDown.Image = ((System.Drawing.Image)(resources.GetObject("FromDate.ButtonDropDown.Image")));
            this.FromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.FromDate.ButtonDropDown.Text = resources.GetString("FromDate.ButtonDropDown.Text");
            this.FromDate.ButtonDropDown.Visible = true;
            this.FromDate.ButtonFreeText.DisplayPosition = ((int)(resources.GetObject("FromDate.ButtonFreeText.DisplayPosition")));
            this.FromDate.ButtonFreeText.Image = ((System.Drawing.Image)(resources.GetObject("FromDate.ButtonFreeText.Image")));
            this.FromDate.ButtonFreeText.Text = resources.GetString("FromDate.ButtonFreeText.Text");
            // 
            // 
            // 
            this.FromDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("FromDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.FromDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromDate.MonthCalendar.Category = resources.GetString("FromDate.MonthCalendar.Category");
            this.FromDate.MonthCalendar.ClearButtonVisible = true;
            this.FromDate.MonthCalendar.CommandParameter = ((object)(resources.GetObject("FromDate.MonthCalendar.CommandParameter")));
            // 
            // 
            // 
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromDate.MonthCalendar.DayNames = ((string[])(resources.GetObject("FromDate.MonthCalendar.DayNames")));
            this.FromDate.MonthCalendar.Description = resources.GetString("FromDate.MonthCalendar.Description");
            this.FromDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.FromDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("FromDate.MonthCalendar.MarkedDates")));
            this.FromDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("FromDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromDate.MonthCalendar.Tag = resources.GetString("FromDate.MonthCalendar.Tag");
            this.FromDate.MonthCalendar.Text = resources.GetString("FromDate.MonthCalendar.Text");
            this.FromDate.MonthCalendar.TodayButtonVisible = true;
            this.FromDate.MonthCalendar.Tooltip = resources.GetString("FromDate.MonthCalendar.Tooltip");
            this.FromDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("FromDate.MonthCalendar.WeeklyMarkedDays")));
            this.FromDate.Name = "FromDate";
            // 
            // UserName
            // 
            resources.ApplyResources(this.UserName, "UserName");
            this.UserName.BackColor = System.Drawing.Color.White;
            this.UserName.Name = "UserName";
            // 
            // GroupBox1
            // 
            resources.ApplyResources(this.GroupBox1, "GroupBox1");
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.RBtnAll);
            this.GroupBox1.Controls.Add(this.RBtn4);
            this.GroupBox1.Controls.Add(this.RBtn1);
            this.GroupBox1.Controls.Add(this.RBtn3);
            this.GroupBox1.Controls.Add(this.RBtn2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.TabStop = false;
            // 
            // RBtnAll
            // 
            resources.ApplyResources(this.RBtnAll, "RBtnAll");
            this.RBtnAll.Checked = true;
            this.RBtnAll.Name = "RBtnAll";
            this.RBtnAll.TabStop = true;
            this.RBtnAll.UseVisualStyleBackColor = true;
            // 
            // RBtn4
            // 
            resources.ApplyResources(this.RBtn4, "RBtn4");
            this.RBtn4.Name = "RBtn4";
            this.RBtn4.UseVisualStyleBackColor = true;
            // 
            // RBtn1
            // 
            resources.ApplyResources(this.RBtn1, "RBtn1");
            this.RBtn1.Name = "RBtn1";
            this.RBtn1.UseVisualStyleBackColor = true;
            // 
            // RBtn3
            // 
            resources.ApplyResources(this.RBtn3, "RBtn3");
            this.RBtn3.Name = "RBtn3";
            this.RBtn3.UseVisualStyleBackColor = true;
            // 
            // RBtn2
            // 
            resources.ApplyResources(this.RBtn2, "RBtn2");
            this.RBtn2.Name = "RBtn2";
            this.RBtn2.UseVisualStyleBackColor = true;
            // 
            // ToDate
            // 
            resources.ApplyResources(this.ToDate, "ToDate");
            // 
            // 
            // 
            this.ToDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemDisabledText;
            this.ToDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToDate.ButtonClear.DisplayPosition = ((int)(resources.GetObject("ToDate.ButtonClear.DisplayPosition")));
            this.ToDate.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("ToDate.ButtonClear.Image")));
            this.ToDate.ButtonClear.Text = resources.GetString("ToDate.ButtonClear.Text");
            this.ToDate.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("ToDate.ButtonCustom.DisplayPosition")));
            this.ToDate.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("ToDate.ButtonCustom.Image")));
            this.ToDate.ButtonCustom.Text = resources.GetString("ToDate.ButtonCustom.Text");
            this.ToDate.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("ToDate.ButtonCustom2.DisplayPosition")));
            this.ToDate.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("ToDate.ButtonCustom2.Image")));
            this.ToDate.ButtonCustom2.Text = resources.GetString("ToDate.ButtonCustom2.Text");
            this.ToDate.ButtonDropDown.DisplayPosition = ((int)(resources.GetObject("ToDate.ButtonDropDown.DisplayPosition")));
            this.ToDate.ButtonDropDown.Image = ((System.Drawing.Image)(resources.GetObject("ToDate.ButtonDropDown.Image")));
            this.ToDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ToDate.ButtonDropDown.Text = resources.GetString("ToDate.ButtonDropDown.Text");
            this.ToDate.ButtonDropDown.Visible = true;
            this.ToDate.ButtonFreeText.DisplayPosition = ((int)(resources.GetObject("ToDate.ButtonFreeText.DisplayPosition")));
            this.ToDate.ButtonFreeText.Image = ((System.Drawing.Image)(resources.GetObject("ToDate.ButtonFreeText.Image")));
            this.ToDate.ButtonFreeText.Text = resources.GetString("ToDate.ButtonFreeText.Text");
            // 
            // 
            // 
            this.ToDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("ToDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.ToDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToDate.MonthCalendar.Category = resources.GetString("ToDate.MonthCalendar.Category");
            this.ToDate.MonthCalendar.ClearButtonVisible = true;
            this.ToDate.MonthCalendar.CommandParameter = ((object)(resources.GetObject("ToDate.MonthCalendar.CommandParameter")));
            // 
            // 
            // 
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToDate.MonthCalendar.DayNames = ((string[])(resources.GetObject("ToDate.MonthCalendar.DayNames")));
            this.ToDate.MonthCalendar.Description = resources.GetString("ToDate.MonthCalendar.Description");
            this.ToDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.ToDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("ToDate.MonthCalendar.MarkedDates")));
            this.ToDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("ToDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToDate.MonthCalendar.Tag = resources.GetString("ToDate.MonthCalendar.Tag");
            this.ToDate.MonthCalendar.Text = resources.GetString("ToDate.MonthCalendar.Text");
            this.ToDate.MonthCalendar.TodayButtonVisible = true;
            this.ToDate.MonthCalendar.Tooltip = resources.GetString("ToDate.MonthCalendar.Tooltip");
            this.ToDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("ToDate.MonthCalendar.WeeklyMarkedDays")));
            this.ToDate.Name = "ToDate";
            // 
            // GroupBox2
            // 
            resources.ApplyResources(this.GroupBox2, "GroupBox2");
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.RB2);
            this.GroupBox2.Controls.Add(this.RB1);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.TabStop = false;
            // 
            // RB2
            // 
            resources.ApplyResources(this.RB2, "RB2");
            this.RB2.Checked = true;
            this.RB2.Name = "RB2";
            this.RB2.TabStop = true;
            this.RB2.UseVisualStyleBackColor = true;
            // 
            // RB1
            // 
            resources.ApplyResources(this.RB1, "RB1");
            this.RB1.Name = "RB1";
            this.RB1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.RB_S_Acc);
            this.groupBox3.Controls.Add(this.RB_M_Acc);
            this.groupBox3.Controls.Add(this.RB_All_Acc);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // RB_S_Acc
            // 
            resources.ApplyResources(this.RB_S_Acc, "RB_S_Acc");
            this.RB_S_Acc.Name = "RB_S_Acc";
            this.RB_S_Acc.UseVisualStyleBackColor = true;
            // 
            // RB_M_Acc
            // 
            resources.ApplyResources(this.RB_M_Acc, "RB_M_Acc");
            this.RB_M_Acc.Name = "RB_M_Acc";
            this.RB_M_Acc.UseVisualStyleBackColor = true;
            // 
            // RB_All_Acc
            // 
            resources.ApplyResources(this.RB_All_Acc, "RB_All_Acc");
            this.RB_All_Acc.Checked = true;
            this.RB_All_Acc.Name = "RB_All_Acc";
            this.RB_All_Acc.TabStop = true;
            this.RB_All_Acc.UseVisualStyleBackColor = true;
            // 
            // groupPanel1
            // 
            resources.ApplyResources(this.groupPanel1, "groupPanel1");
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.UC_Branch);
            this.groupPanel1.Controls.Add(this.UC_Catogry);
            this.groupPanel1.Controls.Add(this.UC_cost);
            this.groupPanel1.Controls.Add(this.UC_Acc);
            this.groupPanel1.Controls.Add(this.groupBox3);
            this.groupPanel1.Controls.Add(this.GroupBox2);
            this.groupPanel1.Controls.Add(this.ToDate);
            this.groupPanel1.Controls.Add(this.GroupBox1);
            this.groupPanel1.Controls.Add(this.UserName);
            this.groupPanel1.Controls.Add(this.FromDate);
            this.groupPanel1.Name = "groupPanel1";
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            // 
            // UC_Branch
            // 
            resources.ApplyResources(this.UC_Branch, "UC_Branch");
            this.UC_Branch.Name = "UC_Branch";
            this.UC_Branch.Load += new System.EventHandler(this.UC_Branch_Load);
            // 
            // UC_Catogry
            // 
            resources.ApplyResources(this.UC_Catogry, "UC_Catogry");
            this.UC_Catogry.Name = "UC_Catogry";
            // 
            // UC_cost
            // 
            resources.ApplyResources(this.UC_cost, "UC_cost");
            this.UC_cost.Name = "UC_cost";
            // 
            // UC_Acc
            // 
            resources.ApplyResources(this.UC_Acc, "UC_Acc");
            this.UC_Acc.BackColor = System.Drawing.Color.Transparent;
            this.UC_Acc.Name = "UC_Acc";
            // 
            // frm_Compare_TB
            // 
            resources.ApplyResources(this, "$this");
            //this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            //this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_Compare_TB";
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.groupPanel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        internal System.Windows.Forms.TextBox T_Eb;
        internal System.Windows.Forms.TextBox T_Cr;
        internal System.Windows.Forms.TextBox T_Bb;
        internal System.Windows.Forms.TextBox T_Db;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromDate;
        internal System.Windows.Forms.TextBox UserName;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RadioButton RBtnAll;
        internal System.Windows.Forms.RadioButton RBtn4;
        internal System.Windows.Forms.RadioButton RBtn1;
        internal System.Windows.Forms.RadioButton RBtn3;
        internal System.Windows.Forms.RadioButton RBtn2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToDate;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.RadioButton RB2;
        internal System.Windows.Forms.RadioButton RB1;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton RB_S_Acc;
        internal System.Windows.Forms.RadioButton RB_M_Acc;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        internal System.Windows.Forms.RadioButton RB_All_Acc;
        private MyControls.UC_Acc UC_Acc;
        private MyControls.UC_cost UC_cost;
      
        private MyControls.UC_Catogry UC_Catogry;
        private MyControls.UC_AccBranch UC_Branch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}