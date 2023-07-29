namespace Report_Pro.PL
{
    partial class frm_lastRecorded
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_lastRecorded));
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.Label();
            this.txtLastRecordDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtName = new Report_Pro.MyControls.Uc_LastRecord();
            this.btnReport = new System.Windows.Forms.Button();
            this._g_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._l_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastRecordDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.Name = "txtDate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Name = "label2";
            // 
            // txtUserID
            // 
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Name = "txtUserID";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Name = "label5";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Image = global::Report_Pro.Properties.Resources.save_Icon;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Name = "txtUserName";
            // 
            // txtLastRecordDate
            // 
            resources.ApplyResources(this.txtLastRecordDate, "txtLastRecordDate");
            // 
            // 
            // 
            this.txtLastRecordDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLastRecordDate.ButtonClear.DisplayPosition = ((int)(resources.GetObject("txtLastRecordDate.ButtonClear.DisplayPosition")));
            this.txtLastRecordDate.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("txtLastRecordDate.ButtonClear.Image")));
            this.txtLastRecordDate.ButtonClear.Text = resources.GetString("txtLastRecordDate.ButtonClear.Text");
            this.txtLastRecordDate.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("txtLastRecordDate.ButtonCustom.DisplayPosition")));
            this.txtLastRecordDate.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtLastRecordDate.ButtonCustom.Image")));
            this.txtLastRecordDate.ButtonCustom.Text = resources.GetString("txtLastRecordDate.ButtonCustom.Text");
            this.txtLastRecordDate.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("txtLastRecordDate.ButtonCustom2.DisplayPosition")));
            this.txtLastRecordDate.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("txtLastRecordDate.ButtonCustom2.Image")));
            this.txtLastRecordDate.ButtonCustom2.Text = resources.GetString("txtLastRecordDate.ButtonCustom2.Text");
            this.txtLastRecordDate.ButtonDropDown.DisplayPosition = ((int)(resources.GetObject("txtLastRecordDate.ButtonDropDown.DisplayPosition")));
            this.txtLastRecordDate.ButtonDropDown.Image = ((System.Drawing.Image)(resources.GetObject("txtLastRecordDate.ButtonDropDown.Image")));
            this.txtLastRecordDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtLastRecordDate.ButtonDropDown.Text = resources.GetString("txtLastRecordDate.ButtonDropDown.Text");
            this.txtLastRecordDate.ButtonDropDown.Visible = true;
            this.txtLastRecordDate.ButtonFreeText.DisplayPosition = ((int)(resources.GetObject("txtLastRecordDate.ButtonFreeText.DisplayPosition")));
            this.txtLastRecordDate.ButtonFreeText.Image = ((System.Drawing.Image)(resources.GetObject("txtLastRecordDate.ButtonFreeText.Image")));
            this.txtLastRecordDate.ButtonFreeText.Text = resources.GetString("txtLastRecordDate.ButtonFreeText.Text");
            // 
            // 
            // 
            this.txtLastRecordDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("txtLastRecordDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.txtLastRecordDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtLastRecordDate.MonthCalendar.Category = resources.GetString("txtLastRecordDate.MonthCalendar.Category");
            this.txtLastRecordDate.MonthCalendar.ClearButtonVisible = true;
            this.txtLastRecordDate.MonthCalendar.CommandParameter = ((object)(resources.GetObject("txtLastRecordDate.MonthCalendar.CommandParameter")));
            // 
            // 
            // 
            this.txtLastRecordDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtLastRecordDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtLastRecordDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtLastRecordDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtLastRecordDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtLastRecordDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtLastRecordDate.MonthCalendar.DayNames = ((string[])(resources.GetObject("txtLastRecordDate.MonthCalendar.DayNames")));
            this.txtLastRecordDate.MonthCalendar.Description = resources.GetString("txtLastRecordDate.MonthCalendar.Description");
            this.txtLastRecordDate.MonthCalendar.DisplayMonth = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.txtLastRecordDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("txtLastRecordDate.MonthCalendar.MarkedDates")));
            this.txtLastRecordDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("txtLastRecordDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.txtLastRecordDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtLastRecordDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtLastRecordDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtLastRecordDate.MonthCalendar.Tag = resources.GetString("txtLastRecordDate.MonthCalendar.Tag");
            this.txtLastRecordDate.MonthCalendar.Text = resources.GetString("txtLastRecordDate.MonthCalendar.Text");
            this.txtLastRecordDate.MonthCalendar.TodayButtonVisible = true;
            this.txtLastRecordDate.MonthCalendar.Tooltip = resources.GetString("txtLastRecordDate.MonthCalendar.Tooltip");
            this.txtLastRecordDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("txtLastRecordDate.MonthCalendar.WeeklyMarkedDays")));
            this.txtLastRecordDate.Name = "txtLastRecordDate";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._g_date,
            this._name,
            this._user,
            this._l_date});
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.Load += new System.EventHandler(this.txtName_Load);
            // 
            // btnReport
            // 
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.Image = global::Report_Pro.Properties.Resources.report;
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // _g_date
            // 
            resources.ApplyResources(this._g_date, "_g_date");
            this._g_date.Name = "_g_date";
            this._g_date.ReadOnly = true;
            // 
            // _name
            // 
            this._name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this._name, "_name");
            this._name.Name = "_name";
            this._name.ReadOnly = true;
            // 
            // _user
            // 
            resources.ApplyResources(this._user, "_user");
            this._user.Name = "_user";
            this._user.ReadOnly = true;
            // 
            // _l_date
            // 
            resources.ApplyResources(this._l_date, "_l_date");
            this._l_date.Name = "_l_date";
            this._l_date.ReadOnly = true;
            // 
            // frm_lastRecorded
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtLastRecordDate);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate);
            this.Name = "frm_lastRecorded";
            this.Load += new System.EventHandler(this.frm_lastRecorded_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLastRecordDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtUserID;
        private System.Windows.Forms.Label label4;
        private MyControls.Uc_LastRecord txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtUserName;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtLastRecordDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn _g_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _user;
        private System.Windows.Forms.DataGridViewTextBoxColumn _l_date;
    }
}