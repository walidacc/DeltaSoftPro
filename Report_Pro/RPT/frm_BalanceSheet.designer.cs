namespace Report_Pro.RPT
{
    partial class frm_BalanceSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BalanceSheet));
            this.ToDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBranch = new Report_Pro.MyControls.UC_AccBranch();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            // 
            // ToDate
            // 
            // 
            // 
            // 
            this.ToDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.ToDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ToDate.ButtonDropDown.Visible = true;
            resources.ApplyResources(this.ToDate, "ToDate");
            // 
            // 
            // 
            this.ToDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("ToDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.ToDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ToDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.ToDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.ToDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("ToDate.MonthCalendar.MarkedDates")));
            this.ToDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("ToDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToDate.MonthCalendar.TodayButtonVisible = true;
            this.ToDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("ToDate.MonthCalendar.WeeklyMarkedDays")));
            this.ToDate.Name = "ToDate";
            // 
            // FromDate
            // 
            // 
            // 
            // 
            this.FromDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.FromDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.FromDate.ButtonDropDown.Visible = true;
            resources.ApplyResources(this.FromDate, "FromDate");
            // 
            // 
            // 
            this.FromDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("FromDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.FromDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.FromDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.FromDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.FromDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("FromDate.MonthCalendar.MarkedDates")));
            this.FromDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("FromDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromDate.MonthCalendar.TodayButtonVisible = true;
            this.FromDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("FromDate.MonthCalendar.WeeklyMarkedDays")));
            this.FromDate.Name = "FromDate";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // txtBranch
            // 
            resources.ApplyResources(this.txtBranch, "txtBranch");
            this.txtBranch.Name = "txtBranch";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBranch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.FromDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ToDate);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            // 
            // frm_BalanceSheet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_BalanceSheet";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.Editors.DateTimeAdv.DateTimeInput ToDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput FromDate;
        private MyControls.UC_AccBranch txtBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}