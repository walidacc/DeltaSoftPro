namespace Report_Pro.RPT
{
    partial class frm_BS_TB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.Button1 = new System.Windows.Forms.Button();
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
            this.RB4 = new System.Windows.Forms.RadioButton();
            this.RB3 = new System.Windows.Forms.RadioButton();
            this.RB2 = new System.Windows.Forms.RadioButton();
            this.RB1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RB_S_Acc = new System.Windows.Forms.RadioButton();
            this.RB_M_Acc = new System.Windows.Forms.RadioButton();
            this.RB_All_Acc = new System.Windows.Forms.RadioButton();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Uc_BS_Acc = new Report_Pro.MyControls.Uc_BS_Acc();
            this.UC_Branch = new Report_Pro.MyControls.UC_Branch();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            // headLbl
            // 
          
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.buttonX6);
            this.panel1.Controls.Add(this.Button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1285, 49);
            this.panel1.TabIndex = 51;
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Location = new System.Drawing.Point(1088, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(83, 31);
            this.btnReport.TabIndex = 291;
            this.btnReport.Text = "التقرير";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.buttonX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Location = new System.Drawing.Point(1196, 12);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(83, 31);
            this.buttonX6.TabIndex = 290;
            this.buttonX6.Text = "خيارات";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(918, 12);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(83, 31);
            this.Button1.TabIndex = 37;
            this.Button1.Text = "التقرير";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Visible = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 73);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1285, 684);
            this.crystalReportViewer1.TabIndex = 54;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DataGridView1);
            this.panel3.Controls.Add(this.groupPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1285, 684);
            this.panel3.TabIndex = 56;
            // 
            // DataGridView1
            // 
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
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersWidth = 43;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(1285, 654);
            this.DataGridView1.TabIndex = 42;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "رقم الحساب";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "اسم الحساب";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "مستوي الحساب";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "نوع الحساب";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column4
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "الرصيد السابق";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 160;
            // 
            // Column5
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "مدين";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 160;
            // 
            // Column6
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "دائن";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 160;
            // 
            // Column7
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "الرصيد الحالي";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 160;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.T_Eb);
            this.groupPanel2.Controls.Add(this.T_Cr);
            this.groupPanel2.Controls.Add(this.T_Bb);
            this.groupPanel2.Controls.Add(this.T_Db);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel2.Location = new System.Drawing.Point(0, 654);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1285, 30);
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
            this.groupPanel2.TabIndex = 41;
            // 
            // T_Eb
            // 
            this.T_Eb.BackColor = System.Drawing.Color.White;
            this.T_Eb.Location = new System.Drawing.Point(3, 1);
            this.T_Eb.Name = "T_Eb";
            this.T_Eb.Size = new System.Drawing.Size(157, 20);
            this.T_Eb.TabIndex = 46;
            // 
            // T_Cr
            // 
            this.T_Cr.BackColor = System.Drawing.Color.White;
            this.T_Cr.Location = new System.Drawing.Point(162, 1);
            this.T_Cr.Name = "T_Cr";
            this.T_Cr.Size = new System.Drawing.Size(157, 20);
            this.T_Cr.TabIndex = 45;
            // 
            // T_Bb
            // 
            this.T_Bb.BackColor = System.Drawing.Color.White;
            this.T_Bb.Location = new System.Drawing.Point(480, 1);
            this.T_Bb.Name = "T_Bb";
            this.T_Bb.Size = new System.Drawing.Size(157, 20);
            this.T_Bb.TabIndex = 43;
            // 
            // T_Db
            // 
            this.T_Db.BackColor = System.Drawing.Color.White;
            this.T_Db.Location = new System.Drawing.Point(321, 1);
            this.T_Db.Name = "T_Db";
            this.T_Db.Size = new System.Drawing.Size(157, 20);
            this.T_Db.TabIndex = 44;
            // 
            // FromDate
            // 
            this.FromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.FromDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.FromDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.FromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.FromDate.ButtonDropDown.Visible = true;
            this.FromDate.Location = new System.Drawing.Point(128, 64);
            // 
            // 
            // 
            this.FromDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
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
            this.FromDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.FromDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.FromDate.MonthCalendar.TodayButtonVisible = true;
            this.FromDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(104, 20);
            this.FromDate.TabIndex = 265;
            // 
            // UserName
            // 
            this.UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserName.BackColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(898, 139);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(100, 20);
            this.UserName.TabIndex = 42;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.RBtnAll);
            this.GroupBox1.Controls.Add(this.RBtn4);
            this.GroupBox1.Controls.Add(this.RBtn1);
            this.GroupBox1.Controls.Add(this.RBtn3);
            this.GroupBox1.Controls.Add(this.RBtn2);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(670, 11);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(472, 35);
            this.GroupBox1.TabIndex = 48;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            // 
            // RBtnAll
            // 
            this.RBtnAll.AutoSize = true;
            this.RBtnAll.Checked = true;
            this.RBtnAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtnAll.Location = new System.Drawing.Point(415, 12);
            this.RBtnAll.Name = "RBtnAll";
            this.RBtnAll.Size = new System.Drawing.Size(55, 17);
            this.RBtnAll.TabIndex = 32;
            this.RBtnAll.TabStop = true;
            this.RBtnAll.Text = "الجميع";
            this.RBtnAll.UseVisualStyleBackColor = true;
            // 
            // RBtn4
            // 
            this.RBtn4.AutoSize = true;
            this.RBtn4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn4.Location = new System.Drawing.Point(6, 11);
            this.RBtn4.Name = "RBtn4";
            this.RBtn4.Size = new System.Drawing.Size(95, 17);
            this.RBtn4.TabIndex = 30;
            this.RBtn4.Text = "المستوي الرابع";
            this.RBtn4.UseVisualStyleBackColor = true;
            // 
            // RBtn1
            // 
            this.RBtn1.AutoSize = true;
            this.RBtn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn1.Location = new System.Drawing.Point(315, 12);
            this.RBtn1.Name = "RBtn1";
            this.RBtn1.Size = new System.Drawing.Size(94, 17);
            this.RBtn1.TabIndex = 27;
            this.RBtn1.Text = "المستوي الاول";
            this.RBtn1.UseVisualStyleBackColor = true;
            // 
            // RBtn3
            // 
            this.RBtn3.AutoSize = true;
            this.RBtn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn3.Location = new System.Drawing.Point(106, 12);
            this.RBtn3.Name = "RBtn3";
            this.RBtn3.Size = new System.Drawing.Size(98, 17);
            this.RBtn3.TabIndex = 29;
            this.RBtn3.Text = "المستوي الثالث";
            this.RBtn3.UseVisualStyleBackColor = true;
            // 
            // RBtn2
            // 
            this.RBtn2.AutoSize = true;
            this.RBtn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBtn2.Location = new System.Drawing.Point(210, 12);
            this.RBtn2.Name = "RBtn2";
            this.RBtn2.Size = new System.Drawing.Size(99, 17);
            this.RBtn2.TabIndex = 28;
            this.RBtn2.Text = "المستوي الثاني";
            this.RBtn2.UseVisualStyleBackColor = true;
            // 
            // ToDate
            // 
            this.ToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ToDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.ToDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ToDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.ToDate.ButtonDropDown.Visible = true;
            this.ToDate.Location = new System.Drawing.Point(128, 88);
            // 
            // 
            // 
            this.ToDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
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
            this.ToDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ToDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.ToDate.MonthCalendar.TodayButtonVisible = true;
            this.ToDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(104, 20);
            this.ToDate.TabIndex = 266;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.RB4);
            this.GroupBox2.Controls.Add(this.RB3);
            this.GroupBox2.Controls.Add(this.RB2);
            this.GroupBox2.Controls.Add(this.RB1);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(668, 89);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(472, 35);
            this.GroupBox2.TabIndex = 49;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Visible = false;
            // 
            // RB4
            // 
            this.RB4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB4.AutoSize = true;
            this.RB4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB4.Location = new System.Drawing.Point(47, 14);
            this.RB4.Name = "RB4";
            this.RB4.Size = new System.Drawing.Size(97, 17);
            this.RB4.TabIndex = 37;
            this.RB4.Text = "الارصدة الصفرية";
            this.RB4.UseVisualStyleBackColor = true;
            // 
            // RB3
            // 
            this.RB3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB3.AutoSize = true;
            this.RB3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB3.Location = new System.Drawing.Point(156, 13);
            this.RB3.Name = "RB3";
            this.RB3.Size = new System.Drawing.Size(116, 17);
            this.RB3.TabIndex = 36;
            this.RB3.Text = "الارصدة غير الصفرية";
            this.RB3.UseVisualStyleBackColor = true;
            // 
            // RB2
            // 
            this.RB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB2.AutoSize = true;
            this.RB2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB2.Location = new System.Drawing.Point(290, 13);
            this.RB2.Name = "RB2";
            this.RB2.Size = new System.Drawing.Size(111, 17);
            this.RB2.TabIndex = 34;
            this.RB2.Text = "الحسابات المتحركة";
            this.RB2.UseVisualStyleBackColor = true;
            // 
            // RB1
            // 
            this.RB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB1.AutoSize = true;
            this.RB1.Checked = true;
            this.RB1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB1.Location = new System.Drawing.Point(406, 13);
            this.RB1.Name = "RB1";
            this.RB1.Size = new System.Drawing.Size(55, 17);
            this.RB1.TabIndex = 35;
            this.RB1.TabStop = true;
            this.RB1.Text = "الجميع";
            this.RB1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.RB_S_Acc);
            this.groupBox3.Controls.Add(this.RB_M_Acc);
            this.groupBox3.Controls.Add(this.RB_All_Acc);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(670, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 35);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // RB_S_Acc
            // 
            this.RB_S_Acc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB_S_Acc.AutoSize = true;
            this.RB_S_Acc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_S_Acc.Location = new System.Drawing.Point(194, 14);
            this.RB_S_Acc.Name = "RB_S_Acc";
            this.RB_S_Acc.Size = new System.Drawing.Size(105, 17);
            this.RB_S_Acc.TabIndex = 44;
            this.RB_S_Acc.Text = "الحسابات الفرعية";
            this.RB_S_Acc.UseVisualStyleBackColor = true;
            // 
            // RB_M_Acc
            // 
            this.RB_M_Acc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RB_M_Acc.AutoSize = true;
            this.RB_M_Acc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_M_Acc.Location = new System.Drawing.Point(303, 14);
            this.RB_M_Acc.Name = "RB_M_Acc";
            this.RB_M_Acc.Size = new System.Drawing.Size(111, 17);
            this.RB_M_Acc.TabIndex = 43;
            this.RB_M_Acc.Text = "الحسابات الرئيسية";
            this.RB_M_Acc.UseVisualStyleBackColor = true;
            // 
            // RB_All_Acc
            // 
            this.RB_All_Acc.AutoSize = true;
            this.RB_All_Acc.Checked = true;
            this.RB_All_Acc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_All_Acc.Location = new System.Drawing.Point(415, 12);
            this.RB_All_Acc.Name = "RB_All_Acc";
            this.RB_All_Acc.Size = new System.Drawing.Size(55, 17);
            this.RB_All_Acc.TabIndex = 32;
            this.RB_All_Acc.TabStop = true;
            this.RB_All_Acc.Text = "الجميع";
            this.RB_All_Acc.UseVisualStyleBackColor = true;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.Uc_BS_Acc);
            this.groupPanel1.Controls.Add(this.UC_Branch);
            this.groupPanel1.Controls.Add(this.groupBox3);
            this.groupPanel1.Controls.Add(this.GroupBox2);
            this.groupPanel1.Controls.Add(this.ToDate);
            this.groupPanel1.Controls.Add(this.GroupBox1);
            this.groupPanel1.Controls.Add(this.UserName);
            this.groupPanel1.Controls.Add(this.FromDate);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 73);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1285, 178);
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
            this.groupPanel1.TabIndex = 55;
            // 
            // Uc_BS_Acc
            // 
            this.Uc_BS_Acc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Uc_BS_Acc.BackColor = System.Drawing.Color.Transparent;
            this.Uc_BS_Acc.Location = new System.Drawing.Point(128, 36);
            this.Uc_BS_Acc.Margin = new System.Windows.Forms.Padding(0);
            this.Uc_BS_Acc.Name = "Uc_BS_Acc";
            this.Uc_BS_Acc.Size = new System.Drawing.Size(322, 20);
            this.Uc_BS_Acc.TabIndex = 306;
            // 
            // UC_Branch
            // 
            this.UC_Branch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Branch.BackColor = System.Drawing.Color.Transparent;
            this.UC_Branch.Cursor = System.Windows.Forms.Cursors.Default;
            this.UC_Branch.Location = new System.Drawing.Point(128, 11);
            this.UC_Branch.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Branch.Name = "UC_Branch";
            this.UC_Branch.Size = new System.Drawing.Size(322, 20);
            this.UC_Branch.TabIndex = 303;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(49, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 308;
            this.label1.Text = "Branch";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(49, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 309;
            this.label2.Text = "BS Account";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(49, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 310;
            this.label3.Text = "From Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(49, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 311;
            this.label4.Text = "To Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_BS_TB
            // 
            //this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            //this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 757);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_BS_TB";
            this.Text = "frm_BS_TB";
            this.Load += new System.EventHandler(this.frm_TB_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.groupPanel1, 0);
            this.panel1.ResumeLayout(false);
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

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        internal System.Windows.Forms.Button Button1;
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
        internal System.Windows.Forms.RadioButton RB4;
        internal System.Windows.Forms.RadioButton RB3;
        internal System.Windows.Forms.RadioButton RB2;
        internal System.Windows.Forms.RadioButton RB1;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton RB_S_Acc;
        internal System.Windows.Forms.RadioButton RB_M_Acc;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        internal System.Windows.Forms.RadioButton RB_All_Acc;
        private MyControls.UC_Branch UC_Branch;
        private MyControls.Uc_BS_Acc Uc_BS_Acc;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}