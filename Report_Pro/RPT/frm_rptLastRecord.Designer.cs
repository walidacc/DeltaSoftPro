namespace Report_Pro.RPT
{
    partial class frm_rptLastRecord
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
            this.txtBranch = new Report_Pro.MyControls.Uc_LastRecord();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtUser = new Report_Pro.MyControls.Uc_user();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            this.headLbl.Size = new System.Drawing.Size(842, 35);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtUser);
            this.panel2.Controls.Add(this.txtBranch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 171);
            this.panel2.TabIndex = 10;
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(87, 19);
            this.txtBranch.Margin = new System.Windows.Forms.Padding(0);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(405, 20);
            this.txtBranch.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 233);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(842, 238);
            this.crystalReportViewer1.TabIndex = 11;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(87, 48);
            this.txtUser.Margin = new System.Windows.Forms.Padding(0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(405, 20);
            this.txtUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Branch";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(31, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "User";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtDate.ButtonDropDown.Visible = true;
            this.txtDate.Location = new System.Drawing.Point(87, 71);
            // 
            // 
            // 
            this.txtDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtDate.MonthCalendar.DisplayMonth = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.txtDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtDate.MonthCalendar.TodayButtonVisible = true;
            this.txtDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(200, 20);
            this.txtDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(31, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_rptLastRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 471);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Name = "frm_rptLastRecord";
            this.Text = "frm_rptLastRecord";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private MyControls.Uc_LastRecord txtBranch;
        private MyControls.Uc_user txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtDate;
    }
}