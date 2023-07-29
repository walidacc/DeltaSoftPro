namespace Report_Pro.RPT
{
    partial class frm_Purchase_reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Purchase_reports));
            System.Windows.Forms.RadioButton rdo_byVendor;
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btn_1 = new DevComponents.DotNetBar.ButtonX();
            this.Report_btn = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btn_Report = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Branch_code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.button4 = new System.Windows.Forms.Button();
            this.Branch_name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdo_byItem = new System.Windows.Forms.RadioButton();
            this.ToDate_ = new System.Windows.Forms.DateTimePicker();
            this.FromDate_ = new System.Windows.Forms.DateTimePicker();
            this.Uc_Group = new Report_Pro.MyControls.Uc_Group();
            this.UC_Items = new Report_Pro.MyControls.UC_Items();
            this.UC_Acc = new Report_Pro.MyControls.UC_Acc();
            this.UC_Branch = new Report_Pro.MyControls.UC_Branch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            rdo_byVendor = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            // 
            // rdo_byVendor
            // 
            resources.ApplyResources(rdo_byVendor, "rdo_byVendor");
            rdo_byVendor.BackColor = System.Drawing.Color.Transparent;
            rdo_byVendor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            rdo_byVendor.Name = "rdo_byVendor";
            rdo_byVendor.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.btn_1);
            this.panel1.Controls.Add(this.Report_btn);
            this.panel1.Name = "panel1";
            // 
            // buttonX2
            // 
            resources.ApplyResources(this.buttonX2, "buttonX2");
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            resources.ApplyResources(this.buttonX1, "buttonX1");
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btn_1
            // 
            resources.ApplyResources(this.btn_1, "btn_1");
            this.btn_1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btn_1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_1.Name = "btn_1";
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // Report_btn
            // 
            resources.ApplyResources(this.Report_btn, "Report_btn");
            this.Report_btn.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.Report_btn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Report_btn.Name = "Report_btn";
            // 
            // labelX1
            // 
            resources.ApplyResources(this.labelX1, "labelX1");
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Name = "labelX1";
            // 
            // labelX5
            // 
            resources.ApplyResources(this.labelX5, "labelX5");
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Name = "labelX5";
            // 
            // btn_Report
            // 
            resources.ApplyResources(this.btn_Report, "btn_Report");
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ToDate
            // 
            resources.ApplyResources(this.ToDate, "ToDate");
            this.ToDate.Name = "ToDate";
            // 
            // FromDate
            // 
            resources.ApplyResources(this.FromDate, "FromDate");
            this.FromDate.Name = "FromDate";
            // 
            // crystalReportViewer1
            // 
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            // 
            // Branch_code
            // 
            resources.ApplyResources(this.Branch_code, "Branch_code");
            this.Branch_code.BackColor = System.Drawing.Color.MintCream;
            // 
            // 
            // 
            this.Branch_code.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_code.Border.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Branch_code.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_code.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_code.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_code.Border.Class = "TextBoxBorder";
            this.Branch_code.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("Branch_code.ButtonCustom.DisplayPosition")));
            this.Branch_code.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("Branch_code.ButtonCustom.Image")));
            this.Branch_code.ButtonCustom.Text = resources.GetString("Branch_code.ButtonCustom.Text");
            this.Branch_code.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("Branch_code.ButtonCustom2.DisplayPosition")));
            this.Branch_code.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("Branch_code.ButtonCustom2.Image")));
            this.Branch_code.ButtonCustom2.Text = resources.GetString("Branch_code.ButtonCustom2.Text");
            this.Branch_code.Name = "Branch_code";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.BackColor = System.Drawing.SystemColors.Info;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Branch_name
            // 
            resources.ApplyResources(this.Branch_name, "Branch_name");
            this.Branch_name.BackColor = System.Drawing.Color.MintCream;
            // 
            // 
            // 
            this.Branch_name.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_name.Border.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Branch_name.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_name.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_name.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Branch_name.Border.Class = "TextBoxBorder";
            this.Branch_name.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("Branch_name.ButtonCustom.DisplayPosition")));
            this.Branch_name.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("Branch_name.ButtonCustom.Image")));
            this.Branch_name.ButtonCustom.Text = resources.GetString("Branch_name.ButtonCustom.Text");
            this.Branch_name.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("Branch_name.ButtonCustom2.DisplayPosition")));
            this.Branch_name.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("Branch_name.ButtonCustom2.Image")));
            this.Branch_name.ButtonCustom2.Text = resources.GetString("Branch_name.ButtonCustom2.Text");
            this.Branch_name.Name = "Branch_name";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(rdo_byVendor);
            this.groupBox3.Controls.Add(this.rdo_byItem);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rdo_byItem
            // 
            resources.ApplyResources(this.rdo_byItem, "rdo_byItem");
            this.rdo_byItem.BackColor = System.Drawing.Color.Transparent;
            this.rdo_byItem.Checked = true;
            this.rdo_byItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdo_byItem.Name = "rdo_byItem";
            this.rdo_byItem.TabStop = true;
            this.rdo_byItem.UseVisualStyleBackColor = false;
            // 
            // ToDate_
            // 
            resources.ApplyResources(this.ToDate_, "ToDate_");
            this.ToDate_.Name = "ToDate_";
            // 
            // FromDate_
            // 
            resources.ApplyResources(this.FromDate_, "FromDate_");
            this.FromDate_.Name = "FromDate_";
            // 
            // Uc_Group
            // 
            resources.ApplyResources(this.Uc_Group, "Uc_Group");
            this.Uc_Group.Name = "Uc_Group";
            // 
            // UC_Items
            // 
            resources.ApplyResources(this.UC_Items, "UC_Items");
            this.UC_Items.Name = "UC_Items";
            // 
            // UC_Acc
            // 
            resources.ApplyResources(this.UC_Acc, "UC_Acc");
            this.UC_Acc.BackColor = System.Drawing.Color.Transparent;
            this.UC_Acc.Name = "UC_Acc";
            // 
            // UC_Branch
            // 
            resources.ApplyResources(this.UC_Branch, "UC_Branch");
            this.UC_Branch.BackColor = System.Drawing.Color.Transparent;
            this.UC_Branch.Cursor = System.Windows.Forms.Cursors.Default;
            this.UC_Branch.Name = "UC_Branch";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.UC_Branch);
            this.panel2.Controls.Add(this.FromDate_);
            this.panel2.Controls.Add(this.Uc_Group);
            this.panel2.Controls.Add(this.ToDate_);
            this.panel2.Controls.Add(this.UC_Items);
            this.panel2.Controls.Add(this.UC_Acc);
            this.panel2.Name = "panel2";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Name = "label7";
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
            // frm_Purchase_reports
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Purchase_reports";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Report;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private DevComponents.DotNetBar.LabelX labelX5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.Controls.TextBoxX Branch_code;
        private System.Windows.Forms.Button button4;
        private DevComponents.DotNetBar.Controls.TextBoxX Branch_name;
        private DevComponents.DotNetBar.ButtonX btn_1;
        private DevComponents.DotNetBar.ButtonX Report_btn;
        private System.Windows.Forms.DateTimePicker ToDate_;
        private System.Windows.Forms.DateTimePicker FromDate_;
        private MyControls.UC_Items UC_Items;
        private MyControls.UC_Acc UC_Acc;
        private MyControls.UC_Branch UC_Branch;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private Report_Pro.MyControls.Uc_Group Uc_Group;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdo_byItem;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        //private MyControls.UC_Items UC_Items;
    }
}