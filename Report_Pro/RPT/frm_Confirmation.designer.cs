﻿namespace Report_Pro.RPT
{
    partial class frm_Confirmation
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.btn_Email = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lX1 = new DevComponents.DotNetBar.LabelX();
            this.RB3 = new System.Windows.Forms.RadioButton();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.UC_Branch = new Report_Pro.MyControls.UC_Branch();
            this.UC_Acc = new Report_Pro.MyControls.UC_Acc();
            this.panel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.buttonX4);
            this.panel2.Controls.Add(this.btn_Email);
            this.panel2.Controls.Add(this.buttonX2);
            this.panel2.Controls.Add(this.buttonX1);
            this.panel2.Controls.Add(this.buttonX7);
            this.panel2.Controls.Add(this.buttonX3);
            this.panel2.Controls.Add(this.buttonX5);
            this.panel2.Controls.Add(this.buttonX6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 63);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(120, 35);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(128, 25);
            this.buttonX4.TabIndex = 302;
            this.buttonX4.Text = "ارسال بالايميل";
            this.buttonX4.Tooltip = "<font color=\"#ED1C24\">التقرير</font><b></b>";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // btn_Email
            // 
            this.btn_Email.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btn_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Email.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Email.Location = new System.Drawing.Point(120, 5);
            this.btn_Email.Name = "btn_Email";
            this.btn_Email.Size = new System.Drawing.Size(128, 25);
            this.btn_Email.TabIndex = 301;
            this.btn_Email.Text = "ارسال بالايميل";
            this.btn_Email.Tooltip = "<font color=\"#ED1C24\">التقرير</font><b></b>";
            this.btn_Email.Click += new System.EventHandler(this.btn_Email_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(496, 33);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(128, 25);
            this.buttonX2.TabIndex = 300;
            this.buttonX2.Text = "حفظ المصادقات PDF";
            this.buttonX2.Tooltip = "<font color=\"#ED1C24\">التقرير</font><b></b>";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(264, 33);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(128, 25);
            this.buttonX1.TabIndex = 299;
            this.buttonX1.Text = "حفظ المصادقات PDF";
            this.buttonX1.Tooltip = "<font color=\"#ED1C24\">التقرير</font><b></b>";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX7.Location = new System.Drawing.Point(264, 5);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(128, 25);
            this.buttonX7.TabIndex = 298;
            this.buttonX7.Text = "مصادقات مراجعين البحرين";
            this.buttonX7.Tooltip = "<font color=\"#ED1C24\">التقرير</font><b></b>";
            this.buttonX7.ClientSizeChanged += new System.EventHandler(this.buttonX7_ClientSizeChanged);
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(496, 5);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(128, 25);
            this.buttonX3.TabIndex = 296;
            this.buttonX3.Text = "مصادقة مراجعين المجمعة";
            this.buttonX3.Tooltip = "<font color=\"#ED1C24\">التقرير</font><b></b>";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.buttonX5.Location = new System.Drawing.Point(12, 8);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(30, 22);
            this.buttonX5.TabIndex = 293;
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Location = new System.Drawing.Point(659, 14);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(83, 32);
            this.buttonX6.TabIndex = 289;
            this.buttonX6.Text = "خيارات";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.FromDate);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.lX1);
            this.groupPanel1.Controls.Add(this.RB3);
            this.groupPanel1.Controls.Add(this.RB2);
            this.groupPanel1.Controls.Add(this.RB1);
            this.groupPanel1.Controls.Add(this.UC_Branch);
            this.groupPanel1.Controls.Add(this.ToDate);
            this.groupPanel1.Controls.Add(this.UC_Acc);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 63);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(800, 175);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(714, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 311;
            this.label4.Text = "من تاريخ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FromDate
            // 
            this.FromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDate.Location = new System.Drawing.Point(618, 63);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(97, 20);
            this.FromDate.TabIndex = 310;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(714, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 309;
            this.label3.Text = "الي تاريخ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(714, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 308;
            this.label2.Text = "الحساب";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(714, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 307;
            this.label1.Text = "الفرع";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lX1
            // 
            this.lX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lX1.AutoSize = true;
            this.lX1.BackColor = System.Drawing.Color.Transparent;
            this.lX1.Location = new System.Drawing.Point(218, 66);
            this.lX1.Name = "lX1";
            this.lX1.Size = new System.Drawing.Size(0, 0);
            this.lX1.TabIndex = 306;
            this.lX1.UseMnemonic = false;
            // 
            // RB3
            // 
            this.RB3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB3.AutoSize = true;
            this.RB3.BackColor = System.Drawing.Color.Transparent;
            this.RB3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB3.Location = new System.Drawing.Point(461, 140);
            this.RB3.Name = "RB3";
            this.RB3.Size = new System.Drawing.Size(97, 17);
            this.RB3.TabIndex = 305;
            this.RB3.Text = "الارصدة الصفرية";
            this.RB3.UseVisualStyleBackColor = false;
            this.RB3.CheckedChanged += new System.EventHandler(this.RB4_CheckedChanged);
            // 
            // RB2
            // 
            this.RB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB2.AutoSize = true;
            this.RB2.BackColor = System.Drawing.Color.Transparent;
            this.RB2.Checked = true;
            this.RB2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB2.Location = new System.Drawing.Point(565, 140);
            this.RB2.Name = "RB2";
            this.RB2.Size = new System.Drawing.Size(116, 17);
            this.RB2.TabIndex = 304;
            this.RB2.TabStop = true;
            this.RB2.Text = "الارصدة غير الصفرية";
            this.RB2.UseVisualStyleBackColor = false;
            this.RB2.CheckedChanged += new System.EventHandler(this.RB3_CheckedChanged);
            // 
            // RB1
            // 
            this.RB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB1.AutoSize = true;
            this.RB1.BackColor = System.Drawing.Color.Transparent;
            this.RB1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB1.Location = new System.Drawing.Point(690, 140);
            this.RB1.Name = "RB1";
            this.RB1.Size = new System.Drawing.Size(55, 17);
            this.RB1.TabIndex = 303;
            this.RB1.Text = "الجميع";
            this.RB1.UseVisualStyleBackColor = false;
            this.RB1.CheckedChanged += new System.EventHandler(this.RB1_CheckedChanged);
            // 
            // ToDate
            // 
            this.ToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDate.Location = new System.Drawing.Point(618, 86);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(97, 20);
            this.ToDate.TabIndex = 300;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 238);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 212);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ToolPanelWidth = 300;
            // 
            // UC_Branch
            // 
            this.UC_Branch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Branch.BackColor = System.Drawing.Color.Transparent;
            this.UC_Branch.Cursor = System.Windows.Forms.Cursors.Default;
            this.UC_Branch.Location = new System.Drawing.Point(376, 10);
            this.UC_Branch.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Branch.Name = "UC_Branch";
            this.UC_Branch.Size = new System.Drawing.Size(339, 20);
            this.UC_Branch.TabIndex = 302;
            // 
            // UC_Acc
            // 
            this.UC_Acc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Acc.BackColor = System.Drawing.Color.Transparent;
            this.UC_Acc.Location = new System.Drawing.Point(376, 37);
            this.UC_Acc.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Acc.Name = "UC_Acc";
            this.UC_Acc.Size = new System.Drawing.Size(339, 20);
            this.UC_Acc.TabIndex = 0;
            // 
            // frm_Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "frm_Confirmation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frm_Confirmation";
            this.Load += new System.EventHandler(this.frm_Confirmation_Load);
            this.panel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private MyControls.UC_Acc UC_Acc;
        private MyControls.UC_Branch UC_Branch;
        private System.Windows.Forms.DateTimePicker ToDate;
        internal System.Windows.Forms.RadioButton RB3;
        internal System.Windows.Forms.RadioButton RB2;
        internal System.Windows.Forms.RadioButton RB1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.LabelX lX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btn_Email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FromDate;
        private DevComponents.DotNetBar.ButtonX buttonX4;
    }
}