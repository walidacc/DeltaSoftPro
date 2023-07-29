namespace Report_Pro.Group
{
    partial class frm_rep_Fees_Consolidated
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
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rep_Fees_Consolidated));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Acc_Group = new Report_Pro.MyControls.UC_Acc_Group();
            this.toDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.fromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtAcc = new Report_Pro.MyControls.UC_Acc();
            this.txtBranch = new Report_Pro.MyControls.UC_AccBranch();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTotals = new System.Windows.Forms.RadioButton();
            this.rdoDetials = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.toDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            // 
            // crystalReportViewer1
            // 
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            // 
            // Acc_Group
            // 
            resources.ApplyResources(this.Acc_Group, "Acc_Group");
            this.Acc_Group.BackColor = System.Drawing.Color.Transparent;
            this.Acc_Group.Name = "Acc_Group";
            // 
            // toDate
            // 
            resources.ApplyResources(this.toDate, "toDate");
            // 
            // 
            // 
            this.toDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.toDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.toDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.toDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.toDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.toDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.toDate.ButtonClear.DisplayPosition = ((int)(resources.GetObject("toDate.ButtonClear.DisplayPosition")));
            this.toDate.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toDate.ButtonClear.Image")));
            this.toDate.ButtonClear.Text = resources.GetString("toDate.ButtonClear.Text");
            this.toDate.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("toDate.ButtonCustom.DisplayPosition")));
            this.toDate.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("toDate.ButtonCustom.Image")));
            this.toDate.ButtonCustom.Text = resources.GetString("toDate.ButtonCustom.Text");
            this.toDate.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("toDate.ButtonCustom2.DisplayPosition")));
            this.toDate.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("toDate.ButtonCustom2.Image")));
            this.toDate.ButtonCustom2.Text = resources.GetString("toDate.ButtonCustom2.Text");
            this.toDate.ButtonDropDown.DisplayPosition = ((int)(resources.GetObject("toDate.ButtonDropDown.DisplayPosition")));
            this.toDate.ButtonDropDown.Image = ((System.Drawing.Image)(resources.GetObject("toDate.ButtonDropDown.Image")));
            this.toDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.toDate.ButtonDropDown.Text = resources.GetString("toDate.ButtonDropDown.Text");
            this.toDate.ButtonDropDown.Visible = true;
            this.toDate.ButtonFreeText.DisplayPosition = ((int)(resources.GetObject("toDate.ButtonFreeText.DisplayPosition")));
            this.toDate.ButtonFreeText.Image = ((System.Drawing.Image)(resources.GetObject("toDate.ButtonFreeText.Image")));
            this.toDate.ButtonFreeText.Text = resources.GetString("toDate.ButtonFreeText.Text");
            // 
            // 
            // 
            this.toDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("toDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.toDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.toDate.MonthCalendar.Category = resources.GetString("toDate.MonthCalendar.Category");
            this.toDate.MonthCalendar.ClearButtonVisible = true;
            this.toDate.MonthCalendar.CommandParameter = ((object)(resources.GetObject("toDate.MonthCalendar.CommandParameter")));
            // 
            // 
            // 
            this.toDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.toDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.toDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.toDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.toDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.toDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.toDate.MonthCalendar.DayNames = ((string[])(resources.GetObject("toDate.MonthCalendar.DayNames")));
            this.toDate.MonthCalendar.Description = resources.GetString("toDate.MonthCalendar.Description");
            this.toDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.toDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("toDate.MonthCalendar.MarkedDates")));
            this.toDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("toDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.toDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.toDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.toDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.toDate.MonthCalendar.Tag = resources.GetString("toDate.MonthCalendar.Tag");
            this.toDate.MonthCalendar.Text = resources.GetString("toDate.MonthCalendar.Text");
            this.toDate.MonthCalendar.TodayButtonVisible = true;
            this.toDate.MonthCalendar.Tooltip = resources.GetString("toDate.MonthCalendar.Tooltip");
            this.toDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("toDate.MonthCalendar.WeeklyMarkedDays")));
            this.toDate.Name = "toDate";
            // 
            // fromDate
            // 
            resources.ApplyResources(this.fromDate, "fromDate");
            // 
            // 
            // 
            this.fromDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.fromDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.fromDate.ButtonClear.DisplayPosition = ((int)(resources.GetObject("fromDate.ButtonClear.DisplayPosition")));
            this.fromDate.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("fromDate.ButtonClear.Image")));
            this.fromDate.ButtonClear.Text = resources.GetString("fromDate.ButtonClear.Text");
            this.fromDate.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("fromDate.ButtonCustom.DisplayPosition")));
            this.fromDate.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("fromDate.ButtonCustom.Image")));
            this.fromDate.ButtonCustom.Text = resources.GetString("fromDate.ButtonCustom.Text");
            this.fromDate.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("fromDate.ButtonCustom2.DisplayPosition")));
            this.fromDate.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("fromDate.ButtonCustom2.Image")));
            this.fromDate.ButtonCustom2.Text = resources.GetString("fromDate.ButtonCustom2.Text");
            this.fromDate.ButtonDropDown.DisplayPosition = ((int)(resources.GetObject("fromDate.ButtonDropDown.DisplayPosition")));
            this.fromDate.ButtonDropDown.Image = ((System.Drawing.Image)(resources.GetObject("fromDate.ButtonDropDown.Image")));
            this.fromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.fromDate.ButtonDropDown.Text = resources.GetString("fromDate.ButtonDropDown.Text");
            this.fromDate.ButtonDropDown.Visible = true;
            this.fromDate.ButtonFreeText.DisplayPosition = ((int)(resources.GetObject("fromDate.ButtonFreeText.DisplayPosition")));
            this.fromDate.ButtonFreeText.Image = ((System.Drawing.Image)(resources.GetObject("fromDate.ButtonFreeText.Image")));
            this.fromDate.ButtonFreeText.Text = resources.GetString("fromDate.ButtonFreeText.Text");
            // 
            // 
            // 
            this.fromDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("fromDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.fromDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.fromDate.MonthCalendar.Category = resources.GetString("fromDate.MonthCalendar.Category");
            this.fromDate.MonthCalendar.ClearButtonVisible = true;
            this.fromDate.MonthCalendar.CommandParameter = ((object)(resources.GetObject("fromDate.MonthCalendar.CommandParameter")));
            // 
            // 
            // 
            this.fromDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fromDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.fromDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fromDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.fromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.fromDate.MonthCalendar.DayNames = ((string[])(resources.GetObject("fromDate.MonthCalendar.DayNames")));
            this.fromDate.MonthCalendar.Description = resources.GetString("fromDate.MonthCalendar.Description");
            this.fromDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 8, 1, 0, 0, 0, 0);
            this.fromDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("fromDate.MonthCalendar.MarkedDates")));
            this.fromDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("fromDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.fromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.fromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.fromDate.MonthCalendar.Tag = resources.GetString("fromDate.MonthCalendar.Tag");
            this.fromDate.MonthCalendar.Text = resources.GetString("fromDate.MonthCalendar.Text");
            this.fromDate.MonthCalendar.TodayButtonVisible = true;
            this.fromDate.MonthCalendar.Tooltip = resources.GetString("fromDate.MonthCalendar.Tooltip");
            this.fromDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("fromDate.MonthCalendar.WeeklyMarkedDays")));
            this.fromDate.Name = "fromDate";
            // 
            // txtAcc
            // 
            resources.ApplyResources(this.txtAcc, "txtAcc");
            this.txtAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtAcc.Name = "txtAcc";
            // 
            // txtBranch
            // 
            resources.ApplyResources(this.txtBranch, "txtBranch");
            this.txtBranch.Name = "txtBranch";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBranch);
            this.panel1.Controls.Add(this.txtAcc);
            this.panel1.Controls.Add(this.Acc_Group);
            this.panel1.Controls.Add(this.fromDate);
            this.panel1.Controls.Add(this.toDate);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rdoTotals);
            this.groupBox1.Controls.Add(this.rdoDetials);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdoTotals
            // 
            resources.ApplyResources(this.rdoTotals, "rdoTotals");
            this.rdoTotals.Checked = true;
            this.rdoTotals.Name = "rdoTotals";
            this.rdoTotals.TabStop = true;
            this.rdoTotals.UseVisualStyleBackColor = true;
            // 
            // rdoDetials
            // 
            resources.ApplyResources(this.rdoDetials, "rdoDetials");
            this.rdoDetials.Name = "rdoDetials";
            this.rdoDetials.UseVisualStyleBackColor = true;
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
            // frm_rep_Fees_Consolidated
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_rep_Fees_Consolidated";
            this.Load += new System.EventHandler(this.frm_rep_Fees_Load);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.toDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput toDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput fromDate;
        private MyControls.UC_Acc txtAcc;
        private MyControls.UC_AccBranch txtBranch;
        private Report_Pro.MyControls.UC_Acc_Group Acc_Group;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTotals;
        private System.Windows.Forms.RadioButton rdoDetials;
    }
}