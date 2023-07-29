using System;

namespace Report_Pro.RPT
{
    partial class frm_Inventory_Report_ByGroup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Inventory_Report_ByGroup));
            this.btn_preview1 = new DevExpress.XtraBars.BarButtonItem();
            //this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            //this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            //this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            //this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btn_stockByBranch = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.btnOptions = new DevComponents.DotNetBar.ButtonX();
            this.chX = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chF = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chZ = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chR = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chP = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chC = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dTP1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.Uc_Transaction = new Report_Pro.MyControls.UC_Transaction();
            this.thick_2 = new System.Windows.Forms.NumericUpDown();
            this.thick_1 = new System.Windows.Forms.NumericUpDown();
            this.Branch = new Report_Pro.MyControls.UC_Branch();
            this.cmb_DimCategory = new System.Windows.Forms.ComboBox();
            this.Item = new Report_Pro.MyControls.UC_Items();
            this.Group = new Report_Pro.MyControls.Uc_Group();
            this.dTP2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dTP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thick_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thick_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTP2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_preview1
            // 
            this.btn_preview1.Id = 15;
            this.btn_preview1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_preview1.ImageOptions.Image")));
            this.btn_preview1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_preview1.ImageOptions.LargeImage")));
            this.btn_preview1.Name = "btn_preview1";
            this.btn_preview1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            //// barDockControlTop
            //// 
            //this.barDockControlTop.CausesValidation = false;
            //resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            //// 
            //// barDockControlBottom
            //// 
            //this.barDockControlBottom.CausesValidation = false;
            //resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            //// 
            //// barDockControlLeft
            //// 
            //this.barDockControlLeft.CausesValidation = false;
            //resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            //// 
            //// barDockControlRight
            //// 
            //this.barDockControlRight.CausesValidation = false;
            //resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            this.headLbl.Click += new System.EventHandler(this.headLbl_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.buttonX6);
            this.panelEx1.Controls.Add(this.buttonX5);
            this.panelEx1.Controls.Add(this.buttonX4);
            this.panelEx1.Controls.Add(this.buttonX3);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.btn_stockByBranch);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.btnReport);
            this.panelEx1.Controls.Add(this.btnOptions);
            resources.ApplyResources(this.panelEx1, "panelEx1");
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.PapayaWhip;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.PapayaWhip;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.ImageFixedSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.buttonX6, "buttonX6");
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.ImageFixedSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.buttonX5, "buttonX5");
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.ImageFixedSize = new System.Drawing.Size(32, 32);
            resources.ApplyResources(this.buttonX4, "buttonX4");
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.buttonX3, "buttonX3");
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.buttonX2, "buttonX2");
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click_1);
            // 
            // btn_stockByBranch
            // 
            this.btn_stockByBranch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_stockByBranch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btn_stockByBranch, "btn_stockByBranch");
            this.btn_stockByBranch.Name = "btn_stockByBranch";
            this.btn_stockByBranch.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.buttonX1, "buttonX1");
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.Name = "btnReport";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOptions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // chX
            // 
            resources.ApplyResources(this.chX, "chX");
            this.chX.BackColor = System.Drawing.Color.Transparent;
            this.chX.Checked = true;
            this.chX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chX.CheckValue = "Y";
            this.chX.Name = "chX";
            // 
            // chF
            // 
            resources.ApplyResources(this.chF, "chF");
            this.chF.BackColor = System.Drawing.Color.Transparent;
            this.chF.Checked = true;
            this.chF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chF.CheckValue = "Y";
            this.chF.Name = "chF";
            // 
            // chZ
            // 
            resources.ApplyResources(this.chZ, "chZ");
            this.chZ.BackColor = System.Drawing.Color.Transparent;
            this.chZ.Checked = true;
            this.chZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chZ.CheckValue = "Y";
            this.chZ.Name = "chZ";
            // 
            // chR
            // 
            resources.ApplyResources(this.chR, "chR");
            this.chR.BackColor = System.Drawing.Color.Transparent;
            this.chR.Checked = true;
            this.chR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chR.CheckValue = "Y";
            this.chR.Name = "chR";
            // 
            // chP
            // 
            resources.ApplyResources(this.chP, "chP");
            this.chP.BackColor = System.Drawing.Color.Transparent;
            this.chP.Checked = true;
            this.chP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chP.CheckValue = "Y";
            this.chP.Name = "chP";
            // 
            // chC
            // 
            resources.ApplyResources(this.chC, "chC");
            this.chC.BackColor = System.Drawing.Color.Transparent;
            this.chC.Checked = true;
            this.chC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chC.CheckValue = "Y";
            this.chC.Name = "chC";
            // 
            // chS
            // 
            resources.ApplyResources(this.chS, "chS");
            this.chS.BackColor = System.Drawing.Color.Transparent;
            this.chS.Checked = true;
            this.chS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chS.CheckValue = "Y";
            this.chS.Name = "chS";
            // 
            // dTP1
            // 
            // 
            // 
            // 
            this.dTP1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.dTP1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dTP1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dTP1.ButtonDropDown.Visible = true;
            resources.ApplyResources(this.dTP1, "dTP1");
            // 
            // 
            // 
            this.dTP1.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("dTP1.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.dTP1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dTP1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dTP1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dTP1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dTP1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dTP1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dTP1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dTP1.MonthCalendar.DisplayMonth = new System.DateTime(2019, 12, 1, 0, 0, 0, 0);
            this.dTP1.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("dTP1.MonthCalendar.MarkedDates")));
            this.dTP1.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("dTP1.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.dTP1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dTP1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dTP1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dTP1.MonthCalendar.TodayButtonVisible = true;
            this.dTP1.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("dTP1.MonthCalendar.WeeklyMarkedDays")));
            this.dTP1.Name = "dTP1";
            // 
            // Uc_Transaction
            // 
            resources.ApplyResources(this.Uc_Transaction, "Uc_Transaction");
            this.Uc_Transaction.Name = "Uc_Transaction";
            // 
            // thick_2
            // 
            this.thick_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thick_2.DecimalPlaces = 2;
            resources.ApplyResources(this.thick_2, "thick_2");
            this.thick_2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.thick_2.Name = "thick_2";
            // 
            // thick_1
            // 
            this.thick_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thick_1.DecimalPlaces = 2;
            resources.ApplyResources(this.thick_1, "thick_1");
            this.thick_1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.thick_1.Name = "thick_1";
            // 
            // Branch
            // 
            this.Branch.BackColor = System.Drawing.Color.Transparent;
            this.Branch.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Branch, "Branch");
            this.Branch.Name = "Branch";
            // 
            // cmb_DimCategory
            // 
            this.cmb_DimCategory.FormattingEnabled = true;
            resources.ApplyResources(this.cmb_DimCategory, "cmb_DimCategory");
            this.cmb_DimCategory.Name = "cmb_DimCategory";
            // 
            // Item
            // 
            resources.ApplyResources(this.Item, "Item");
            this.Item.Name = "Item";
            this.Item.Click += new System.EventHandler(this.Item_Click);
            // 
            // Group
            // 
            resources.ApplyResources(this.Group, "Group");
            this.Group.Name = "Group";
            // 
            // dTP2
            // 
            // 
            // 
            // 
            this.dTP2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.dTP2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dTP2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dTP2.ButtonDropDown.Visible = true;
            resources.ApplyResources(this.dTP2, "dTP2");
            // 
            // 
            // 
            this.dTP2.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("dTP2.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.dTP2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dTP2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dTP2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dTP2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dTP2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dTP2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dTP2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dTP2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dTP2.MonthCalendar.DisplayMonth = new System.DateTime(2019, 12, 1, 0, 0, 0, 0);
            this.dTP2.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("dTP2.MonthCalendar.MarkedDates")));
            this.dTP2.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("dTP2.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.dTP2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dTP2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dTP2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dTP2.MonthCalendar.TodayButtonVisible = true;
            this.dTP2.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("dTP2.MonthCalendar.WeeklyMarkedDays")));
            this.dTP2.Name = "dTP2";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panelEx1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dTP2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Group);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.Item);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmb_DimCategory);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Branch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.thick_1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.thick_2);
            this.panel1.Controls.Add(this.Uc_Transaction);
            this.panel1.Controls.Add(this.dTP1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chX);
            this.groupBox1.Controls.Add(this.chC);
            this.groupBox1.Controls.Add(this.chF);
            this.groupBox1.Controls.Add(this.chS);
            this.groupBox1.Controls.Add(this.chZ);
            this.groupBox1.Controls.Add(this.chP);
            this.groupBox1.Controls.Add(this.chR);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // frm_Inventory_Report_ByGroup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_Inventory_Report_ByGroup";
            this.Load += new System.EventHandler(this.frm_Inventory_Report_Load);
            //this.Controls.SetChildIndex(this.barDockControlTop, 0);
            //this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            //this.Controls.SetChildIndex(this.barDockControlRight, 0);
            //this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dTP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thick_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thick_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTP2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            InventoryReportByGroup();
        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.ButtonX btnOptions;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dTP2;
        private MyControls.UC_Items Item;
        private MyControls.Uc_Group Group;
        private System.Windows.Forms.ComboBox cmb_DimCategory;
        private MyControls.UC_Branch Branch;
        private System.Windows.Forms.NumericUpDown thick_2;
        private System.Windows.Forms.NumericUpDown thick_1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btn_stockByBranch;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private MyControls.UC_Transaction Uc_Transaction;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dTP1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chX;
        private DevComponents.DotNetBar.Controls.CheckBoxX chF;
        private DevComponents.DotNetBar.Controls.CheckBoxX chZ;
        private DevComponents.DotNetBar.Controls.CheckBoxX chR;
        private DevComponents.DotNetBar.Controls.CheckBoxX chP;
        private DevComponents.DotNetBar.Controls.CheckBoxX chC;
        private DevComponents.DotNetBar.Controls.CheckBoxX chS;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraBars.BarButtonItem btn_preview1;
       //// private DevExpress.XtraBars.BarDockControl barDockControlTop;
        //private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}