namespace Report_Pro.CTR
{
    partial class frm_BankDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BankDeposit));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.mTxt_H = new System.Windows.Forms.MaskedTextBox();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtCustBank = new Report_Pro.MyControls.UC_CustBank();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDepositType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBankAcc = new Report_Pro.MyControls.UC_Acc();
            this.btnImportFromExcel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCreditAcc = new Report_Pro.MyControls.UC_Acc();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new Report_Pro.MyControls.decimalText();
            this.txtCheuqeDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt_Cheuqe_bank = new System.Windows.Forms.TextBox();
            this.txt_Cheuqe_No = new System.Windows.Forms.TextBox();
            this.txt_Sheek = new System.Windows.Forms.TextBox();
            this.txt_Cheuqe_Or_Cash = new System.Windows.Forms.TextBox();
            this.txt_Pay_Type_No = new System.Windows.Forms.TextBox();
            this.txt_Source_Code = new System.Windows.Forms.TextBox();
            this.txt_Sheque_Bank_No = new System.Windows.Forms.TextBox();
            this.txt_docId = new System.Windows.Forms.TextBox();
            this.txt_Cyear = new System.Windows.Forms.TextBox();
            this.lblCheckTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSanad_type2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_sp_ser = new Report_Pro.MyControls.textWithButton();
            this.txtSanadNo = new Report_Pro.MyControls.textWithButton();
            this.txtSerNo = new Report_Pro.MyControls.textWithButton();
            this.txtMainNote = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSer_code = new System.Windows.Forms.TextBox();
            this.txtSanad_type = new System.Windows.Forms.TextBox();
            this.Main_serNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.AccBranch = new Report_Pro.MyControls.UC_AccBranch();
            this.btnChooseBranch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheuqeDate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // miniToolStrip
            // 
            resources.ApplyResources(this.miniToolStrip, "miniToolStrip");
            this.miniToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.miniToolStrip.Name = "miniToolStrip";
            // 
            // mTxt_H
            // 
            resources.ApplyResources(this.mTxt_H, "mTxt_H");
            this.mTxt_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mTxt_H.Name = "mTxt_H";
            this.mTxt_H.ValidatingType = typeof(System.DateTime);
            this.mTxt_H.Click += new System.EventHandler(this.mTxt_H_Click);
            this.mTxt_H.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            this.mTxt_H.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mTxt_H_KeyUp);
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDate.Name = "txtDate";
            this.txtDate.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            this.txtDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyUp);
            // 
            // groupPanel1
            // 
            resources.ApplyResources(this.groupPanel1, "groupPanel1");
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtCustBank);
            this.groupPanel1.Controls.Add(this.button1);
            this.groupPanel1.Controls.Add(this.label17);
            this.groupPanel1.Controls.Add(this.label16);
            this.groupPanel1.Controls.Add(this.txtCheckNo);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Controls.Add(this.txtDepositType);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.txtBankAcc);
            this.groupPanel1.Controls.Add(this.btnImportFromExcel);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.txtCreditAcc);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.txtAmount);
            this.groupPanel1.Controls.Add(this.txtCheuqeDate);
            this.groupPanel1.Controls.Add(this.txt_Cheuqe_bank);
            this.groupPanel1.Controls.Add(this.txt_Cheuqe_No);
            this.groupPanel1.Controls.Add(this.txt_Sheek);
            this.groupPanel1.Controls.Add(this.txt_Cheuqe_Or_Cash);
            this.groupPanel1.Controls.Add(this.txt_Pay_Type_No);
            this.groupPanel1.Controls.Add(this.txt_Source_Code);
            this.groupPanel1.Controls.Add(this.txt_Sheque_Bank_No);
            this.groupPanel1.Controls.Add(this.txt_docId);
            this.groupPanel1.Controls.Add(this.txt_Cyear);
            this.groupPanel1.Controls.Add(this.lblCheckTotal);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtUser);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.txtSanad_type2);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.txt_sp_ser);
            this.groupPanel1.Controls.Add(this.txtSanadNo);
            this.groupPanel1.Controls.Add(this.txtSerNo);
            this.groupPanel1.Controls.Add(this.txtMainNote);
            this.groupPanel1.Controls.Add(this.label13);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.txtSer_code);
            this.groupPanel1.Controls.Add(this.txtSanad_type);
            this.groupPanel1.Controls.Add(this.Main_serNo);
            this.groupPanel1.Controls.Add(this.AccBranch);
            this.groupPanel1.Controls.Add(this.btnChooseBranch);
            this.groupPanel1.Controls.Add(this.txtDate);
            this.groupPanel1.Controls.Add(this.mTxt_H);
            this.groupPanel1.Name = "groupPanel1";
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
            // 
            // txtCustBank
            // 
            resources.ApplyResources(this.txtCustBank, "txtCustBank");
            this.txtCustBank.Name = "txtCustBank";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Image = global::Report_Pro.Properties.Resources.Add_Icon3;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Name = "label16";
            // 
            // txtCheckNo
            // 
            resources.ApplyResources(this.txtCheckNo, "txtCheckNo");
            this.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckNo.Name = "txtCheckNo";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Name = "label15";
            // 
            // txtDepositType
            // 
            resources.ApplyResources(this.txtDepositType, "txtDepositType");
            this.txtDepositType.FormattingEnabled = true;
            this.txtDepositType.Name = "txtDepositType";
            this.txtDepositType.SelectedIndexChanged += new System.EventHandler(this.txtDepositType_SelectedIndexChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Name = "label14";
            // 
            // txtBankAcc
            // 
            resources.ApplyResources(this.txtBankAcc, "txtBankAcc");
            this.txtBankAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtBankAcc.Name = "txtBankAcc";
            // 
            // btnImportFromExcel
            // 
            resources.ApplyResources(this.btnImportFromExcel, "btnImportFromExcel");
            this.btnImportFromExcel.Name = "btnImportFromExcel";
            this.btnImportFromExcel.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // txtCreditAcc
            // 
            resources.ApplyResources(this.txtCreditAcc, "txtCreditAcc");
            this.txtCreditAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtCreditAcc.Name = "txtCreditAcc";
            this.txtCreditAcc.Load += new System.EventHandler(this.txtCreditAcc_Load);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            // 
            // txtAmount
            // 
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.DicemalDigits = 3;
            this.txtAmount.maxmumNumber = 0D;
            this.txtAmount.minimumNumber = 0D;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ProgramDigits = false;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // txtCheuqeDate
            // 
            resources.ApplyResources(this.txtCheuqeDate, "txtCheuqeDate");
            // 
            // 
            // 
            this.txtCheuqeDate.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCheuqeDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemDisabledText;
            this.txtCheuqeDate.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCheuqeDate.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCheuqeDate.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCheuqeDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCheuqeDate.ButtonClear.DisplayPosition = ((int)(resources.GetObject("txtCheuqeDate.ButtonClear.DisplayPosition")));
            this.txtCheuqeDate.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("txtCheuqeDate.ButtonClear.Image")));
            this.txtCheuqeDate.ButtonClear.Text = resources.GetString("txtCheuqeDate.ButtonClear.Text");
            this.txtCheuqeDate.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("txtCheuqeDate.ButtonCustom.DisplayPosition")));
            this.txtCheuqeDate.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtCheuqeDate.ButtonCustom.Image")));
            this.txtCheuqeDate.ButtonCustom.Text = resources.GetString("txtCheuqeDate.ButtonCustom.Text");
            this.txtCheuqeDate.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("txtCheuqeDate.ButtonCustom2.DisplayPosition")));
            this.txtCheuqeDate.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("txtCheuqeDate.ButtonCustom2.Image")));
            this.txtCheuqeDate.ButtonCustom2.Text = resources.GetString("txtCheuqeDate.ButtonCustom2.Text");
            this.txtCheuqeDate.ButtonDropDown.DisplayPosition = ((int)(resources.GetObject("txtCheuqeDate.ButtonDropDown.DisplayPosition")));
            this.txtCheuqeDate.ButtonDropDown.Image = ((System.Drawing.Image)(resources.GetObject("txtCheuqeDate.ButtonDropDown.Image")));
            this.txtCheuqeDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtCheuqeDate.ButtonDropDown.Text = resources.GetString("txtCheuqeDate.ButtonDropDown.Text");
            this.txtCheuqeDate.ButtonDropDown.Visible = true;
            this.txtCheuqeDate.ButtonFreeText.DisplayPosition = ((int)(resources.GetObject("txtCheuqeDate.ButtonFreeText.DisplayPosition")));
            this.txtCheuqeDate.ButtonFreeText.Image = ((System.Drawing.Image)(resources.GetObject("txtCheuqeDate.ButtonFreeText.Image")));
            this.txtCheuqeDate.ButtonFreeText.Text = resources.GetString("txtCheuqeDate.ButtonFreeText.Text");
            // 
            // 
            // 
            this.txtCheuqeDate.MonthCalendar.AnnuallyMarkedDates = ((System.DateTime[])(resources.GetObject("txtCheuqeDate.MonthCalendar.AnnuallyMarkedDates")));
            // 
            // 
            // 
            this.txtCheuqeDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtCheuqeDate.MonthCalendar.Category = resources.GetString("txtCheuqeDate.MonthCalendar.Category");
            this.txtCheuqeDate.MonthCalendar.ClearButtonVisible = true;
            this.txtCheuqeDate.MonthCalendar.CommandParameter = ((object)(resources.GetObject("txtCheuqeDate.MonthCalendar.CommandParameter")));
            // 
            // 
            // 
            this.txtCheuqeDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtCheuqeDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtCheuqeDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtCheuqeDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCheuqeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtCheuqeDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtCheuqeDate.MonthCalendar.DayNames = ((string[])(resources.GetObject("txtCheuqeDate.MonthCalendar.DayNames")));
            this.txtCheuqeDate.MonthCalendar.Description = resources.GetString("txtCheuqeDate.MonthCalendar.Description");
            this.txtCheuqeDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.txtCheuqeDate.MonthCalendar.MarkedDates = ((System.DateTime[])(resources.GetObject("txtCheuqeDate.MonthCalendar.MarkedDates")));
            this.txtCheuqeDate.MonthCalendar.MonthlyMarkedDates = ((System.DateTime[])(resources.GetObject("txtCheuqeDate.MonthCalendar.MonthlyMarkedDates")));
            // 
            // 
            // 
            this.txtCheuqeDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtCheuqeDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtCheuqeDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtCheuqeDate.MonthCalendar.Tag = resources.GetString("txtCheuqeDate.MonthCalendar.Tag");
            this.txtCheuqeDate.MonthCalendar.Text = resources.GetString("txtCheuqeDate.MonthCalendar.Text");
            this.txtCheuqeDate.MonthCalendar.TodayButtonVisible = true;
            this.txtCheuqeDate.MonthCalendar.Tooltip = resources.GetString("txtCheuqeDate.MonthCalendar.Tooltip");
            this.txtCheuqeDate.MonthCalendar.WeeklyMarkedDays = ((System.DayOfWeek[])(resources.GetObject("txtCheuqeDate.MonthCalendar.WeeklyMarkedDays")));
            this.txtCheuqeDate.Name = "txtCheuqeDate";
            // 
            // txt_Cheuqe_bank
            // 
            resources.ApplyResources(this.txt_Cheuqe_bank, "txt_Cheuqe_bank");
            this.txt_Cheuqe_bank.Name = "txt_Cheuqe_bank";
            this.txt_Cheuqe_bank.ReadOnly = true;
            // 
            // txt_Cheuqe_No
            // 
            resources.ApplyResources(this.txt_Cheuqe_No, "txt_Cheuqe_No");
            this.txt_Cheuqe_No.Name = "txt_Cheuqe_No";
            this.txt_Cheuqe_No.ReadOnly = true;
            // 
            // txt_Sheek
            // 
            resources.ApplyResources(this.txt_Sheek, "txt_Sheek");
            this.txt_Sheek.Name = "txt_Sheek";
            this.txt_Sheek.ReadOnly = true;
            // 
            // txt_Cheuqe_Or_Cash
            // 
            resources.ApplyResources(this.txt_Cheuqe_Or_Cash, "txt_Cheuqe_Or_Cash");
            this.txt_Cheuqe_Or_Cash.Name = "txt_Cheuqe_Or_Cash";
            this.txt_Cheuqe_Or_Cash.ReadOnly = true;
            // 
            // txt_Pay_Type_No
            // 
            resources.ApplyResources(this.txt_Pay_Type_No, "txt_Pay_Type_No");
            this.txt_Pay_Type_No.Name = "txt_Pay_Type_No";
            this.txt_Pay_Type_No.ReadOnly = true;
            // 
            // txt_Source_Code
            // 
            resources.ApplyResources(this.txt_Source_Code, "txt_Source_Code");
            this.txt_Source_Code.Name = "txt_Source_Code";
            this.txt_Source_Code.ReadOnly = true;
            // 
            // txt_Sheque_Bank_No
            // 
            resources.ApplyResources(this.txt_Sheque_Bank_No, "txt_Sheque_Bank_No");
            this.txt_Sheque_Bank_No.Name = "txt_Sheque_Bank_No";
            this.txt_Sheque_Bank_No.ReadOnly = true;
            // 
            // txt_docId
            // 
            resources.ApplyResources(this.txt_docId, "txt_docId");
            this.txt_docId.Name = "txt_docId";
            this.txt_docId.ReadOnly = true;
            // 
            // txt_Cyear
            // 
            resources.ApplyResources(this.txt_Cyear, "txt_Cyear");
            this.txt_Cyear.Name = "txt_Cyear";
            this.txt_Cyear.ReadOnly = true;
            // 
            // lblCheckTotal
            // 
            resources.ApplyResources(this.lblCheckTotal, "lblCheckTotal");
            this.lblCheckTotal.BackColor = System.Drawing.SystemColors.Info;
            this.lblCheckTotal.ForeColor = System.Drawing.Color.Red;
            this.lblCheckTotal.Name = "lblCheckTotal";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // txtUser
            // 
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.BackColor = System.Drawing.Color.SeaShell;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Name = "txtUser";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Name = "label8";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Name = "label11";
            // 
            // txtSanad_type2
            // 
            resources.ApplyResources(this.txtSanad_type2, "txtSanad_type2");
            this.txtSanad_type2.Name = "txtSanad_type2";
            this.txtSanad_type2.ReadOnly = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Name = "label7";
            // 
            // txt_sp_ser
            // 
            resources.ApplyResources(this.txt_sp_ser, "txt_sp_ser");
            this.txt_sp_ser.buttonImage = global::Report_Pro.Properties.Resources.find_32x32;
            this.txt_sp_ser.buttonVisable = true;
            this.txt_sp_ser.LabelAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_sp_ser.LabelBackColor = System.Drawing.Color.Transparent;
            this.txt_sp_ser.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_sp_ser.LabelFont = new System.Drawing.Font("Tahoma", 8F);
            this.txt_sp_ser.LabelSize = new System.Drawing.Size(75, 20);
            this.txt_sp_ser.LabelText = "رقم القيد";
            this.txt_sp_ser.labelVisable = false;
            this.txt_sp_ser.Name = "txt_sp_ser";
            this.txt_sp_ser.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_sp_ser.TextBackColor = System.Drawing.SystemColors.Window;
            this.txt_sp_ser.TextColor = System.Drawing.SystemColors.WindowText;
            this.txt_sp_ser.textEnabal = false;
            this.txt_sp_ser.TextlFont = new System.Drawing.Font("Tahoma", 8F);
            this.txt_sp_ser.TextS = "";
            this.txt_sp_ser.TextSize = new System.Drawing.Size(108, 20);
            // 
            // txtSanadNo
            // 
            resources.ApplyResources(this.txtSanadNo, "txtSanadNo");
            this.txtSanadNo.buttonImage = global::Report_Pro.Properties.Resources.find_32x32;
            this.txtSanadNo.buttonVisable = true;
            this.txtSanadNo.LabelAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSanadNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSanadNo.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSanadNo.LabelFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtSanadNo.LabelSize = new System.Drawing.Size(75, 20);
            this.txtSanadNo.LabelText = "رقم القيد";
            this.txtSanadNo.labelVisable = false;
            this.txtSanadNo.Name = "txtSanadNo";
            this.txtSanadNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSanadNo.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtSanadNo.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtSanadNo.textEnabal = false;
            this.txtSanadNo.TextlFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtSanadNo.TextS = "";
            this.txtSanadNo.TextSize = new System.Drawing.Size(108, 20);
            this.txtSanadNo.Click += new System.EventHandler(this.txtSanadNo_Click);
            // 
            // txtSerNo
            // 
            resources.ApplyResources(this.txtSerNo, "txtSerNo");
            this.txtSerNo.buttonImage = global::Report_Pro.Properties.Resources.find_32x32;
            this.txtSerNo.buttonVisable = true;
            this.txtSerNo.LabelAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSerNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSerNo.LabelColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSerNo.LabelFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtSerNo.LabelSize = new System.Drawing.Size(75, 20);
            this.txtSerNo.LabelText = "رقم القيد";
            this.txtSerNo.labelVisable = false;
            this.txtSerNo.Name = "txtSerNo";
            this.txtSerNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerNo.TextBackColor = System.Drawing.SystemColors.Window;
            this.txtSerNo.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtSerNo.textEnabal = false;
            this.txtSerNo.TextlFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtSerNo.TextS = "";
            this.txtSerNo.TextSize = new System.Drawing.Size(108, 20);
            this.txtSerNo.Click += new System.EventHandler(this.txtSerNo_Click);
            // 
            // txtMainNote
            // 
            resources.ApplyResources(this.txtMainNote, "txtMainNote");
            this.txtMainNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMainNote.Name = "txtMainNote";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Name = "label12";
            // 
            // txtSer_code
            // 
            resources.ApplyResources(this.txtSer_code, "txtSer_code");
            this.txtSer_code.Name = "txtSer_code";
            this.txtSer_code.ReadOnly = true;
            // 
            // txtSanad_type
            // 
            resources.ApplyResources(this.txtSanad_type, "txtSanad_type");
            this.txtSanad_type.Name = "txtSanad_type";
            this.txtSanad_type.ReadOnly = true;
            // 
            // Main_serNo
            // 
            resources.ApplyResources(this.Main_serNo, "Main_serNo");
            // 
            // 
            // 
            this.Main_serNo.Border.Class = "TextBoxBorder";
            this.Main_serNo.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("Main_serNo.ButtonCustom.DisplayPosition")));
            this.Main_serNo.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("Main_serNo.ButtonCustom.Image")));
            this.Main_serNo.ButtonCustom.Text = resources.GetString("Main_serNo.ButtonCustom.Text");
            this.Main_serNo.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("Main_serNo.ButtonCustom2.DisplayPosition")));
            this.Main_serNo.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("Main_serNo.ButtonCustom2.Image")));
            this.Main_serNo.ButtonCustom2.Text = resources.GetString("Main_serNo.ButtonCustom2.Text");
            this.Main_serNo.Name = "Main_serNo";
            // 
            // AccBranch
            // 
            resources.ApplyResources(this.AccBranch, "AccBranch");
            this.AccBranch.Name = "AccBranch";
            this.AccBranch.Load += new System.EventHandler(this.AccBranch_Load);
            // 
            // btnChooseBranch
            // 
            resources.ApplyResources(this.btnChooseBranch, "btnChooseBranch");
            this.btnChooseBranch.Name = "btnChooseBranch";
            this.btnChooseBranch.UseVisualStyleBackColor = true;
            this.btnChooseBranch.Click += new System.EventHandler(this.btnChooseBranch_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Name = "panel1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.SystemColors.Info;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Name = "label4";
            // 
            // frm_BankDeposit
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.groupPanel1);
            this.Name = "frm_BankDeposit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmJornal_FormClosing);
            this.Load += new System.EventHandler(this.frmJornal_Load);
            this.Controls.SetChildIndex(this.groupPanel1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheuqeDate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
       // private DevComponents.DotNetBar.ButtonItem BtnPrint;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.MaskedTextBox mTxt_H;
        private System.Windows.Forms.DateTimePicker txtDate;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button btnChooseBranch;
        private MyControls.UC_AccBranch AccBranch;
        private DevComponents.DotNetBar.Controls.TextBoxX Main_serNo;
        private System.Windows.Forms.TextBox txtSer_code;
        private System.Windows.Forms.TextBox txtSanad_type;
        private System.Windows.Forms.TextBox txtMainNote;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private MyControls.textWithButton txt_sp_ser;
        private MyControls.textWithButton txtSanadNo;
        private MyControls.textWithButton txtSerNo;
        private System.Windows.Forms.TextBox txtSanad_type2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCheckTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Cheuqe_bank;
        private System.Windows.Forms.TextBox txt_Cheuqe_No;
        private System.Windows.Forms.TextBox txt_Sheek;
        private System.Windows.Forms.TextBox txt_Cheuqe_Or_Cash;
        private System.Windows.Forms.TextBox txt_Pay_Type_No;
        private System.Windows.Forms.TextBox txt_Source_Code;
        private System.Windows.Forms.TextBox txt_Sheque_Bank_No;
        private System.Windows.Forms.TextBox txt_docId;
        private System.Windows.Forms.TextBox txt_Cyear;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtCheuqeDate;
        private MyControls.decimalText txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private MyControls.UC_Acc txtCreditAcc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportFromExcel;
        private MyControls.UC_Acc txtBankAcc;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox txtDepositType;
        public System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCheckNo;
        private MyControls.UC_CustBank txtCustBank;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label17;
    }
}