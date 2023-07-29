namespace Report_Pro.MyControls
{
    partial class Uc_AccountOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_AccountOption));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCat = new DevComponents.DotNetBar.ButtonX();
            this.btnCost = new DevComponents.DotNetBar.ButtonX();
            this.btnAccount = new DevComponents.DotNetBar.ButtonX();
            this.AccountID = new System.Windows.Forms.TextBox();
            this.btnBranch = new DevComponents.DotNetBar.ButtonX();
            this.BranchDesc = new System.Windows.Forms.TextBox();
            this.BranchID = new System.Windows.Forms.TextBox();
            this.CostID = new System.Windows.Forms.TextBox();
            this.CatID = new System.Windows.Forms.TextBox();
            this.AccountDesc = new System.Windows.Forms.TextBox();
            this.CostDesc = new System.Windows.Forms.TextBox();
            this.CatDesc = new System.Windows.Forms.TextBox();
            this.dgv1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccCash = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.txtStoreFinal = new System.Windows.Forms.TextBox();
            this.KM_Code_Purch = new System.Windows.Forms.TextBox();
            this.KM_Desc_Purch = new System.Windows.Forms.TextBox();
            this.KM_Code_Sales = new System.Windows.Forms.TextBox();
            this.KM_Ratio_Purch = new System.Windows.Forms.TextBox();
            this.txtKMCode = new System.Windows.Forms.TextBox();
            this.KM_Ratio_Sales = new System.Windows.Forms.TextBox();
            this.KM_Desc_Sales = new System.Windows.Forms.TextBox();
            this.txtMainAcc = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FromDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.ToDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RBtnAll = new System.Windows.Forms.RadioButton();
            this.RBtn4 = new System.Windows.Forms.RadioButton();
            this.RBtn1 = new System.Windows.Forms.RadioButton();
            this.RBtn3 = new System.Windows.Forms.RadioButton();
            this.RBtn2 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.T_B = new System.Windows.Forms.RadioButton();
            this.Zero_B = new System.Windows.Forms.RadioButton();
            this.UnZero_B = new System.Windows.Forms.RadioButton();
            this.Credit_B = new System.Windows.Forms.RadioButton();
            this.debit_B = new System.Windows.Forms.RadioButton();
            this.All_B = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RB_S_Acc = new System.Windows.Forms.RadioButton();
            this.RB_M_Acc = new System.Windows.Forms.RadioButton();
            this.RB_All_Acc = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCat
            // 
            resources.ApplyResources(this.btnCat, "btnCat");
            this.btnCat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCat.Image = ((System.Drawing.Image)(resources.GetObject("btnCat.Image")));
            this.btnCat.Name = "btnCat";
            this.btnCat.Click += new System.EventHandler(this.btnCat_Click);
            // 
            // btnCost
            // 
            resources.ApplyResources(this.btnCost, "btnCost");
            this.btnCost.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCost.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCost.Image = ((System.Drawing.Image)(resources.GetObject("btnCost.Image")));
            this.btnCost.Name = "btnCost";
            this.btnCost.Click += new System.EventHandler(this.btnCost_Click);
            // 
            // btnAccount
            // 
            resources.ApplyResources(this.btnAccount, "btnAccount");
            this.btnAccount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccount.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.Image")));
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // AccountID
            // 
            resources.ApplyResources(this.AccountID, "AccountID");
            this.AccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountID.Name = "AccountID";
            this.AccountID.TextChanged += new System.EventHandler(this.AccountID_TextChanged);
            this.AccountID.Enter += new System.EventHandler(this.AccountID_Enter);
            this.AccountID.Leave += new System.EventHandler(this.AccountID_Leave);
            // 
            // btnBranch
            // 
            resources.ApplyResources(this.btnBranch, "btnBranch");
            this.btnBranch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBranch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBranch.Image = ((System.Drawing.Image)(resources.GetObject("btnBranch.Image")));
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // BranchDesc
            // 
            resources.ApplyResources(this.BranchDesc, "BranchDesc");
            this.BranchDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BranchDesc.Name = "BranchDesc";
            this.BranchDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BranchDesc_KeyUp);
            // 
            // BranchID
            // 
            resources.ApplyResources(this.BranchID, "BranchID");
            this.BranchID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BranchID.Name = "BranchID";
            this.BranchID.TextChanged += new System.EventHandler(this.BranchID_TextChanged);
            this.BranchID.Enter += new System.EventHandler(this.BranchID_Enter);
            this.BranchID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BranchID_KeyUp);
            this.BranchID.Leave += new System.EventHandler(this.BranchID_Leave);
            // 
            // CostID
            // 
            resources.ApplyResources(this.CostID, "CostID");
            this.CostID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CostID.Name = "CostID";
            this.CostID.TextChanged += new System.EventHandler(this.CostID_TextChanged);
            this.CostID.Enter += new System.EventHandler(this.CostID_Enter);
            this.CostID.Leave += new System.EventHandler(this.CostID_Leave);
            // 
            // CatID
            // 
            resources.ApplyResources(this.CatID, "CatID");
            this.CatID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CatID.Name = "CatID";
            this.CatID.TextChanged += new System.EventHandler(this.CatID_TextChanged);
            this.CatID.Enter += new System.EventHandler(this.CatID_Enter);
            this.CatID.Leave += new System.EventHandler(this.CatID_Leave);
            // 
            // AccountDesc
            // 
            resources.ApplyResources(this.AccountDesc, "AccountDesc");
            this.AccountDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountDesc.Name = "AccountDesc";
            this.AccountDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccountDesc_KeyUp);
            // 
            // CostDesc
            // 
            resources.ApplyResources(this.CostDesc, "CostDesc");
            this.CostDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CostDesc.Name = "CostDesc";
            this.CostDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CostDesc_KeyUp);
            // 
            // CatDesc
            // 
            resources.ApplyResources(this.CatDesc, "CatDesc");
            this.CatDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CatDesc.Name = "CatDesc";
            this.CatDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CatDesc_KeyUp);
            // 
            // dgv1
            // 
            resources.ApplyResources(this.dgv1, "dgv1");
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // lbl
            // 
            resources.ApplyResources(this.lbl, "lbl");
            this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl.Name = "lbl";
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // txtAccCash
            // 
            resources.ApplyResources(this.txtAccCash, "txtAccCash");
            this.txtAccCash.Name = "txtAccCash";
            // 
            // txtFinal
            // 
            resources.ApplyResources(this.txtFinal, "txtFinal");
            this.txtFinal.Name = "txtFinal";
            // 
            // txtStoreFinal
            // 
            resources.ApplyResources(this.txtStoreFinal, "txtStoreFinal");
            this.txtStoreFinal.Name = "txtStoreFinal";
            // 
            // KM_Code_Purch
            // 
            resources.ApplyResources(this.KM_Code_Purch, "KM_Code_Purch");
            this.KM_Code_Purch.Name = "KM_Code_Purch";
            // 
            // KM_Desc_Purch
            // 
            resources.ApplyResources(this.KM_Desc_Purch, "KM_Desc_Purch");
            this.KM_Desc_Purch.Name = "KM_Desc_Purch";
            this.KM_Desc_Purch.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // KM_Code_Sales
            // 
            resources.ApplyResources(this.KM_Code_Sales, "KM_Code_Sales");
            this.KM_Code_Sales.Name = "KM_Code_Sales";
            // 
            // KM_Ratio_Purch
            // 
            resources.ApplyResources(this.KM_Ratio_Purch, "KM_Ratio_Purch");
            this.KM_Ratio_Purch.Name = "KM_Ratio_Purch";
            // 
            // txtKMCode
            // 
            resources.ApplyResources(this.txtKMCode, "txtKMCode");
            this.txtKMCode.Name = "txtKMCode";
            // 
            // KM_Ratio_Sales
            // 
            resources.ApplyResources(this.KM_Ratio_Sales, "KM_Ratio_Sales");
            this.KM_Ratio_Sales.Name = "KM_Ratio_Sales";
            // 
            // KM_Desc_Sales
            // 
            resources.ApplyResources(this.KM_Desc_Sales, "KM_Desc_Sales");
            this.KM_Desc_Sales.Name = "KM_Desc_Sales";
            // 
            // txtMainAcc
            // 
            resources.ApplyResources(this.txtMainAcc, "txtMainAcc");
            this.txtMainAcc.Name = "txtMainAcc";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.FromDate, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.ToDate, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.GroupBox1, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.CatDesc, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.CostDesc, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.AccountDesc, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.BranchDesc, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCat, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnCost, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAccount, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnBranch, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BranchID, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.CatID, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.CostID, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.AccountID, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 5, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
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
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // FromDate
            // 
            resources.ApplyResources(this.FromDate, "FromDate");
            // 
            // 
            // 
            this.FromDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.FromDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
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
            this.tableLayoutPanel2.SetColumnSpan(this.FromDate, 2);
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
            // ToDate
            // 
            resources.ApplyResources(this.ToDate, "ToDate");
            // 
            // 
            // 
            this.ToDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ToDate.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
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
            this.tableLayoutPanel2.SetColumnSpan(this.ToDate, 2);
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
            // 
            // GroupBox1
            // 
            resources.ApplyResources(this.GroupBox1, "GroupBox1");
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.RBtnAll);
            this.GroupBox1.Controls.Add(this.RBtn4);
            this.GroupBox1.Controls.Add(this.RBtn1);
            this.GroupBox1.Controls.Add(this.RBtn3);
            this.GroupBox1.Controls.Add(this.RBtn2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.TabStop = false;
            // 
            // RBtnAll
            // 
            resources.ApplyResources(this.RBtnAll, "RBtnAll");
            this.RBtnAll.Checked = true;
            this.RBtnAll.Name = "RBtnAll";
            this.RBtnAll.TabStop = true;
            this.RBtnAll.UseVisualStyleBackColor = true;
            // 
            // RBtn4
            // 
            resources.ApplyResources(this.RBtn4, "RBtn4");
            this.RBtn4.Name = "RBtn4";
            this.RBtn4.UseVisualStyleBackColor = true;
            // 
            // RBtn1
            // 
            resources.ApplyResources(this.RBtn1, "RBtn1");
            this.RBtn1.Name = "RBtn1";
            this.RBtn1.UseVisualStyleBackColor = true;
            // 
            // RBtn3
            // 
            resources.ApplyResources(this.RBtn3, "RBtn3");
            this.RBtn3.Name = "RBtn3";
            this.RBtn3.UseVisualStyleBackColor = true;
            // 
            // RBtn2
            // 
            resources.ApplyResources(this.RBtn2, "RBtn2");
            this.RBtn2.Name = "RBtn2";
            this.RBtn2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.T_B);
            this.groupBox4.Controls.Add(this.Zero_B);
            this.groupBox4.Controls.Add(this.UnZero_B);
            this.groupBox4.Controls.Add(this.Credit_B);
            this.groupBox4.Controls.Add(this.debit_B);
            this.groupBox4.Controls.Add(this.All_B);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // T_B
            // 
            resources.ApplyResources(this.T_B, "T_B");
            this.T_B.Checked = true;
            this.T_B.Name = "T_B";
            this.T_B.TabStop = true;
            this.T_B.UseVisualStyleBackColor = true;
            // 
            // Zero_B
            // 
            resources.ApplyResources(this.Zero_B, "Zero_B");
            this.Zero_B.Name = "Zero_B";
            this.Zero_B.UseVisualStyleBackColor = true;
            // 
            // UnZero_B
            // 
            resources.ApplyResources(this.UnZero_B, "UnZero_B");
            this.UnZero_B.Name = "UnZero_B";
            this.UnZero_B.UseVisualStyleBackColor = true;
            // 
            // Credit_B
            // 
            resources.ApplyResources(this.Credit_B, "Credit_B");
            this.Credit_B.Name = "Credit_B";
            this.Credit_B.UseVisualStyleBackColor = true;
            // 
            // debit_B
            // 
            resources.ApplyResources(this.debit_B, "debit_B");
            this.debit_B.Name = "debit_B";
            this.debit_B.UseVisualStyleBackColor = true;
            // 
            // All_B
            // 
            resources.ApplyResources(this.All_B, "All_B");
            this.All_B.Name = "All_B";
            this.All_B.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.RB_S_Acc);
            this.groupBox3.Controls.Add(this.RB_M_Acc);
            this.groupBox3.Controls.Add(this.RB_All_Acc);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // RB_S_Acc
            // 
            resources.ApplyResources(this.RB_S_Acc, "RB_S_Acc");
            this.RB_S_Acc.Name = "RB_S_Acc";
            this.RB_S_Acc.UseVisualStyleBackColor = true;
            // 
            // RB_M_Acc
            // 
            resources.ApplyResources(this.RB_M_Acc, "RB_M_Acc");
            this.RB_M_Acc.Name = "RB_M_Acc";
            this.RB_M_Acc.UseVisualStyleBackColor = true;
            // 
            // RB_All_Acc
            // 
            resources.ApplyResources(this.RB_All_Acc, "RB_All_Acc");
            this.RB_All_Acc.Checked = true;
            this.RB_All_Acc.Name = "RB_All_Acc";
            this.RB_All_Acc.TabStop = true;
            this.RB_All_Acc.UseVisualStyleBackColor = true;
            // 
            // Uc_AccountOption
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.txtMainAcc);
            this.Controls.Add(this.txtKMCode);
            this.Controls.Add(this.KM_Ratio_Sales);
            this.Controls.Add(this.KM_Desc_Sales);
            this.Controls.Add(this.KM_Code_Sales);
            this.Controls.Add(this.KM_Ratio_Purch);
            this.Controls.Add(this.KM_Desc_Purch);
            this.Controls.Add(this.KM_Code_Purch);
            this.Controls.Add(this.txtStoreFinal);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtAccCash);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Uc_AccountOption";
            this.Load += new System.EventHandler(this.Uc_AccountOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDate)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox BranchDesc;
        public System.Windows.Forms.TextBox BranchID;
        private DevComponents.DotNetBar.ButtonX btnCat;
        private DevComponents.DotNetBar.ButtonX btnCost;
        private DevComponents.DotNetBar.ButtonX btnAccount;
        public System.Windows.Forms.TextBox AccountID;
        private DevComponents.DotNetBar.ButtonX btnBranch;
        public System.Windows.Forms.TextBox CostID;
        public System.Windows.Forms.TextBox CatID;
        public System.Windows.Forms.TextBox AccountDesc;
        public System.Windows.Forms.TextBox CostDesc;
        public System.Windows.Forms.TextBox CatDesc;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl;
        public System.Windows.Forms.TextBox KM_Code_Purch;
        public System.Windows.Forms.TextBox KM_Desc_Purch;
        public System.Windows.Forms.TextBox KM_Code_Sales;
        public System.Windows.Forms.TextBox KM_Ratio_Purch;
        public System.Windows.Forms.TextBox txtKMCode;
        public System.Windows.Forms.TextBox KM_Ratio_Sales;
        public System.Windows.Forms.TextBox KM_Desc_Sales;
        public System.Windows.Forms.TextBox txtAccCash;
        public System.Windows.Forms.TextBox txtFinal;
        public System.Windows.Forms.TextBox txtStoreFinal;
        public System.Windows.Forms.TextBox txtMainAcc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.RadioButton RBtnAll;
        public System.Windows.Forms.RadioButton RBtn4;
        public System.Windows.Forms.RadioButton RBtn1;
        public System.Windows.Forms.RadioButton RBtn3;
        public System.Windows.Forms.RadioButton RBtn2;
        public System.Windows.Forms.RadioButton T_B;
        public System.Windows.Forms.RadioButton Zero_B;
        public System.Windows.Forms.RadioButton UnZero_B;
        public System.Windows.Forms.RadioButton Credit_B;
        public System.Windows.Forms.RadioButton debit_B;
        public System.Windows.Forms.RadioButton All_B;
        public System.Windows.Forms.RadioButton RB_S_Acc;
        public System.Windows.Forms.RadioButton RB_M_Acc;
        public System.Windows.Forms.RadioButton RB_All_Acc;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput FromDate;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput ToDate;
    }
}
