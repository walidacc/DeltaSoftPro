namespace Report_Pro.MyControls
{
    partial class UC_TB
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TB));
            this.ToDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.FromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCatogry = new Report_Pro.MyControls.UC_Catogry();
            this.txtCost = new Report_Pro.MyControls.UC_cost();
            this.txtBranch = new Report_Pro.MyControls.UC_AccBranch();
            this.txtAcc = new Report_Pro.MyControls.UC_Acc();
            this.RB4 = new System.Windows.Forms.RadioButton();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.RB3 = new System.Windows.Forms.RadioButton();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB_S_Acc = new System.Windows.Forms.RadioButton();
            this.RB_All_Acc = new System.Windows.Forms.RadioButton();
            this.RB_M_Acc = new System.Windows.Forms.RadioButton();
            this.RBtn4 = new System.Windows.Forms.RadioButton();
            this.RBtnAll = new System.Windows.Forms.RadioButton();
            this.RBtn3 = new System.Windows.Forms.RadioButton();
            this.RBtn1 = new System.Windows.Forms.RadioButton();
            this.RBtn2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToDate
            // 
            resources.ApplyResources(this.ToDate, "ToDate");
            // 
            // 
            // 
            this.ToDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
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
            this.ToDate.Click += new System.EventHandler(this.ToDate_Click);
            // 
            // FromDate
            // 
            resources.ApplyResources(this.FromDate, "FromDate");
            // 
            // 
            // 
            this.FromDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCatogry
            // 
            resources.ApplyResources(this.txtCatogry, "txtCatogry");
            this.txtCatogry.Name = "txtCatogry";
            // 
            // txtCost
            // 
            resources.ApplyResources(this.txtCost, "txtCost");
            this.txtCost.Name = "txtCost";
            // 
            // txtBranch
            // 
            resources.ApplyResources(this.txtBranch, "txtBranch");
            this.txtBranch.Name = "txtBranch";
            // 
            // txtAcc
            // 
            resources.ApplyResources(this.txtAcc, "txtAcc");
            this.txtAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtAcc.Name = "txtAcc";
            // 
            // RB4
            // 
            resources.ApplyResources(this.RB4, "RB4");
            this.RB4.BackColor = System.Drawing.Color.Transparent;
            this.RB4.Name = "RB4";
            this.RB4.UseVisualStyleBackColor = false;
            // 
            // RB1
            // 
            resources.ApplyResources(this.RB1, "RB1");
            this.RB1.BackColor = System.Drawing.Color.Transparent;
            this.RB1.Name = "RB1";
            this.RB1.UseVisualStyleBackColor = false;
            // 
            // RB3
            // 
            resources.ApplyResources(this.RB3, "RB3");
            this.RB3.BackColor = System.Drawing.Color.Transparent;
            this.RB3.Name = "RB3";
            this.RB3.UseVisualStyleBackColor = false;
            // 
            // RB2
            // 
            resources.ApplyResources(this.RB2, "RB2");
            this.RB2.BackColor = System.Drawing.Color.Transparent;
            this.RB2.Name = "RB2";
            this.RB2.UseVisualStyleBackColor = false;
            // 
            // RB_S_Acc
            // 
            resources.ApplyResources(this.RB_S_Acc, "RB_S_Acc");
            this.RB_S_Acc.BackColor = System.Drawing.Color.Transparent;
            this.RB_S_Acc.Name = "RB_S_Acc";
            this.RB_S_Acc.UseVisualStyleBackColor = false;
            // 
            // RB_All_Acc
            // 
            resources.ApplyResources(this.RB_All_Acc, "RB_All_Acc");
            this.RB_All_Acc.BackColor = System.Drawing.Color.Transparent;
            this.RB_All_Acc.Checked = true;
            this.RB_All_Acc.Name = "RB_All_Acc";
            this.RB_All_Acc.TabStop = true;
            this.RB_All_Acc.UseVisualStyleBackColor = false;
            // 
            // RB_M_Acc
            // 
            resources.ApplyResources(this.RB_M_Acc, "RB_M_Acc");
            this.RB_M_Acc.BackColor = System.Drawing.Color.Transparent;
            this.RB_M_Acc.Name = "RB_M_Acc";
            this.RB_M_Acc.UseVisualStyleBackColor = false;
            // 
            // RBtn4
            // 
            resources.ApplyResources(this.RBtn4, "RBtn4");
            this.RBtn4.BackColor = System.Drawing.Color.Transparent;
            this.RBtn4.Name = "RBtn4";
            this.RBtn4.UseVisualStyleBackColor = false;
            // 
            // RBtnAll
            // 
            resources.ApplyResources(this.RBtnAll, "RBtnAll");
            this.RBtnAll.BackColor = System.Drawing.Color.Transparent;
            this.RBtnAll.Checked = true;
            this.RBtnAll.Name = "RBtnAll";
            this.RBtnAll.TabStop = true;
            this.RBtnAll.UseVisualStyleBackColor = false;
            // 
            // RBtn3
            // 
            resources.ApplyResources(this.RBtn3, "RBtn3");
            this.RBtn3.BackColor = System.Drawing.Color.Transparent;
            this.RBtn3.Name = "RBtn3";
            this.RBtn3.UseVisualStyleBackColor = false;
            // 
            // RBtn1
            // 
            resources.ApplyResources(this.RBtn1, "RBtn1");
            this.RBtn1.BackColor = System.Drawing.Color.Transparent;
            this.RBtn1.Name = "RBtn1";
            this.RBtn1.UseVisualStyleBackColor = false;
            // 
            // RBtn2
            // 
            resources.ApplyResources(this.RBtn2, "RBtn2");
            this.RBtn2.BackColor = System.Drawing.Color.Transparent;
            this.RBtn2.Name = "RBtn2";
            this.RBtn2.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.RBtn4);
            this.groupBox1.Controls.Add(this.RBtnAll);
            this.groupBox1.Controls.Add(this.RBtn2);
            this.groupBox1.Controls.Add(this.RBtn3);
            this.groupBox1.Controls.Add(this.RBtn1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.RB_S_Acc);
            this.groupBox2.Controls.Add(this.RB_All_Acc);
            this.groupBox2.Controls.Add(this.RB_M_Acc);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.RB4);
            this.groupBox3.Controls.Add(this.RB1);
            this.groupBox3.Controls.Add(this.RB2);
            this.groupBox3.Controls.Add(this.RB3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // UC_TB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCatogry);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtBranch);
            this.Name = "UC_TB";
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public DevComponents.Editors.DateTimeAdv.DateTimeInput ToDate;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput FromDate;
        public System.Windows.Forms.RadioButton RB4;
        public System.Windows.Forms.RadioButton RB1;
        public System.Windows.Forms.RadioButton RB3;
        public System.Windows.Forms.RadioButton RB2;
        public System.Windows.Forms.RadioButton RB_S_Acc;
        public System.Windows.Forms.RadioButton RB_All_Acc;
        public System.Windows.Forms.RadioButton RB_M_Acc;
        public System.Windows.Forms.RadioButton RBtn4;
        public System.Windows.Forms.RadioButton RBtnAll;
        public System.Windows.Forms.RadioButton RBtn3;
        public System.Windows.Forms.RadioButton RBtn1;
        public System.Windows.Forms.RadioButton RBtn2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public UC_Catogry txtCatogry;
        public UC_cost txtCost;
        public UC_AccBranch txtBranch;
        public UC_Acc txtAcc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
