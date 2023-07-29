namespace Report_Pro.RPT
{
    partial class frm_rpt_Productin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_Productin));
            this.btn_preview1 = new DevExpress.XtraBars.BarButtonItem();
            //this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            //this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            //this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            //this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_DimCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dTP2 = new System.Windows.Forms.DateTimePicker();
            this.dTP1 = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCoileReport = new DevComponents.DotNetBar.ButtonX();
            this.txtcoileCod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo_5 = new System.Windows.Forms.RadioButton();
            this.rdo_4 = new System.Windows.Forms.RadioButton();
            this.rdo_3 = new System.Windows.Forms.RadioButton();
            this.rdo_2 = new System.Windows.Forms.RadioButton();
            this.rdo_1 = new System.Windows.Forms.RadioButton();
            this.btnMonthelyReport = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chX = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chF = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chZ = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chR = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chC = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.Items = new Report_Pro.MyControls.UC_Items();
            this.label11 = new System.Windows.Forms.Label();
            this.Uc_Group = new Report_Pro.MyControls.Uc_Group();
            this.label7 = new System.Windows.Forms.Label();
            this.UC_Branch = new Report_Pro.MyControls.UC_Branch();
            this.thick_2 = new System.Windows.Forms.NumericUpDown();
            this.thick_1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thick_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thick_1)).BeginInit();
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
            // barDockControlTop
            // 
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
            //// 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmb_DimCategory
            // 
            this.cmb_DimCategory.FormattingEnabled = true;
            this.cmb_DimCategory.Items.AddRange(new object[] {
            resources.GetString("cmb_DimCategory.Items"),
            resources.GetString("cmb_DimCategory.Items1"),
            resources.GetString("cmb_DimCategory.Items2")});
            resources.ApplyResources(this.cmb_DimCategory, "cmb_DimCategory");
            this.cmb_DimCategory.Name = "cmb_DimCategory";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dTP2
            // 
            resources.ApplyResources(this.dTP2, "dTP2");
            this.dTP2.Name = "dTP2";
            // 
            // dTP1
            // 
            resources.ApplyResources(this.dTP1, "dTP1");
            this.dTP1.Name = "dTP1";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnCoileReport);
            this.groupBox1.Controls.Add(this.txtcoileCod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnMonthelyReport);
            this.groupBox1.Controls.Add(this.buttonX7);
            this.groupBox1.Controls.Add(this.buttonX4);
            this.groupBox1.Controls.Add(this.buttonX5);
            this.groupBox1.Controls.Add(this.buttonX6);
            this.groupBox1.Controls.Add(this.buttonX3);
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Controls.Add(this.groupPanel2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Items);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Uc_Group);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.UC_Branch);
            this.groupBox1.Controls.Add(this.thick_2);
            this.groupBox1.Controls.Add(this.thick_1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dTP1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dTP2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_DimCategory);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCoileReport
            // 
            this.btnCoileReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.btnCoileReport, "btnCoileReport");
            this.btnCoileReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCoileReport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCoileReport.Name = "btnCoileReport";
            this.btnCoileReport.Click += new System.EventHandler(this.btnCoileReport_Click);
            // 
            // txtcoileCod
            // 
            resources.ApplyResources(this.txtcoileCod, "txtcoileCod");
            this.txtcoileCod.Name = "txtcoileCod";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Azure;
            this.groupBox2.Controls.Add(this.rdo_5);
            this.groupBox2.Controls.Add(this.rdo_4);
            this.groupBox2.Controls.Add(this.rdo_3);
            this.groupBox2.Controls.Add(this.rdo_2);
            this.groupBox2.Controls.Add(this.rdo_1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rdo_5
            // 
            resources.ApplyResources(this.rdo_5, "rdo_5");
            this.rdo_5.Name = "rdo_5";
            this.rdo_5.UseVisualStyleBackColor = true;
            // 
            // rdo_4
            // 
            resources.ApplyResources(this.rdo_4, "rdo_4");
            this.rdo_4.Name = "rdo_4";
            this.rdo_4.UseVisualStyleBackColor = true;
            // 
            // rdo_3
            // 
            resources.ApplyResources(this.rdo_3, "rdo_3");
            this.rdo_3.Name = "rdo_3";
            this.rdo_3.UseVisualStyleBackColor = true;
            // 
            // rdo_2
            // 
            resources.ApplyResources(this.rdo_2, "rdo_2");
            this.rdo_2.Name = "rdo_2";
            this.rdo_2.UseVisualStyleBackColor = true;
            // 
            // rdo_1
            // 
            resources.ApplyResources(this.rdo_1, "rdo_1");
            this.rdo_1.Checked = true;
            this.rdo_1.Name = "rdo_1";
            this.rdo_1.TabStop = true;
            this.rdo_1.UseVisualStyleBackColor = true;
            // 
            // btnMonthelyReport
            // 
            this.btnMonthelyReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.btnMonthelyReport, "btnMonthelyReport");
            this.btnMonthelyReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMonthelyReport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnMonthelyReport.Name = "btnMonthelyReport";
            this.btnMonthelyReport.Click += new System.EventHandler(this.btnMonthelyReport_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX7, "buttonX7");
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX4, "buttonX4");
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX5, "buttonX5");
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX6, "buttonX6");
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX3, "buttonX3");
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX2, "buttonX2");
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(this.buttonX1, "buttonX1");
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.chX);
            this.groupPanel2.Controls.Add(this.chF);
            this.groupPanel2.Controls.Add(this.chZ);
            this.groupPanel2.Controls.Add(this.chR);
            this.groupPanel2.Controls.Add(this.chC);
            this.groupPanel2.Controls.Add(this.chS);
            resources.ApplyResources(this.groupPanel2, "groupPanel2");
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
            this.groupPanel2.Click += new System.EventHandler(this.groupPanel2_Click);
            // 
            // chX
            // 
            resources.ApplyResources(this.chX, "chX");
            this.chX.BackColor = System.Drawing.Color.Transparent;
            this.chX.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chX.Checked = true;
            this.chX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chX.CheckValue = "Y";
            this.chX.Name = "chX";
            // 
            // chF
            // 
            resources.ApplyResources(this.chF, "chF");
            this.chF.BackColor = System.Drawing.Color.Transparent;
            this.chF.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chF.Checked = true;
            this.chF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chF.CheckValue = "Y";
            this.chF.Name = "chF";
            // 
            // chZ
            // 
            resources.ApplyResources(this.chZ, "chZ");
            this.chZ.BackColor = System.Drawing.Color.Transparent;
            this.chZ.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chZ.Checked = true;
            this.chZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chZ.CheckValue = "Y";
            this.chZ.Name = "chZ";
            // 
            // chR
            // 
            resources.ApplyResources(this.chR, "chR");
            this.chR.BackColor = System.Drawing.Color.Transparent;
            this.chR.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chR.Checked = true;
            this.chR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chR.CheckValue = "Y";
            this.chR.Name = "chR";
            // 
            // chC
            // 
            resources.ApplyResources(this.chC, "chC");
            this.chC.BackColor = System.Drawing.Color.Transparent;
            this.chC.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chC.Checked = true;
            this.chC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chC.CheckValue = "Y";
            this.chC.Name = "chC";
            // 
            // chS
            // 
            resources.ApplyResources(this.chS, "chS");
            this.chS.BackColor = System.Drawing.Color.Transparent;
            this.chS.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right;
            this.chS.Checked = true;
            this.chS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chS.CheckValue = "Y";
            this.chS.Name = "chS";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // Items
            // 
            resources.ApplyResources(this.Items, "Items");
            this.Items.Name = "Items";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // Uc_Group
            // 
            resources.ApplyResources(this.Uc_Group, "Uc_Group");
            this.Uc_Group.Name = "Uc_Group";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // UC_Branch
            // 
            this.UC_Branch.BackColor = System.Drawing.Color.Transparent;
            this.UC_Branch.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.UC_Branch, "UC_Branch");
            this.UC_Branch.Name = "UC_Branch";
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
            // frm_rpt_Productin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_rpt_Productin";
            //this.Controls.SetChildIndex(this.barDockControlTop, 0);
            //this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            //this.Controls.SetChildIndex(this.barDockControlRight, 0);
            //this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thick_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thick_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTP2;
        private System.Windows.Forms.DateTimePicker dTP1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_DimCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown thick_2;
        private System.Windows.Forms.NumericUpDown thick_1;
        private System.Windows.Forms.Label label7;
        private MyControls.UC_Branch UC_Branch;
        private System.Windows.Forms.Label label11;
        private MyControls.Uc_Group Uc_Group;
        private System.Windows.Forms.Label label10;
        private MyControls.UC_Items Items;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX chF;
        private DevComponents.DotNetBar.Controls.CheckBoxX chZ;
        private DevComponents.DotNetBar.Controls.CheckBoxX chR;
        private DevComponents.DotNetBar.Controls.CheckBoxX chC;
        private DevComponents.DotNetBar.Controls.CheckBoxX chS;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.Controls.CheckBoxX chX;
        private DevComponents.DotNetBar.ButtonX btnMonthelyReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdo_5;
        private System.Windows.Forms.RadioButton rdo_4;
        private System.Windows.Forms.RadioButton rdo_3;
        private System.Windows.Forms.RadioButton rdo_2;
        private System.Windows.Forms.RadioButton rdo_1;
        private DevComponents.DotNetBar.ButtonX btnCoileReport;
        private System.Windows.Forms.TextBox txtcoileCod;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraBars.BarButtonItem btn_preview1;
        //private DevExpress.XtraBars.BarDockControl barDockControlTop;
        ////private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        ////private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        ////private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}