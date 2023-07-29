namespace Report_Pro.PL
{
    partial class frm_AddClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRespName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRespNameE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCreditLimit = new Report_Pro.MyControls.decimalText();
            this.txtCreditDays = new Report_Pro.MyControls.decimalText();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelephon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.KM_Purch = new Report_Pro.MyControls.UC_KM_Purch();
            this.KM_Sales = new Report_Pro.MyControls.UC_KM_Sales();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.txtBranch = new Report_Pro.MyControls.UC_AccBranch();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStoreID = new System.Windows.Forms.Label();
            this.txtMainAcc = new Report_Pro.MyControls.UC_Acc();
            this.label17 = new System.Windows.Forms.Label();
            this.txtLevel = new Report_Pro.MyControls.decimalText();
            this.txtMainLevel = new Report_Pro.MyControls.decimalText();
            this.Final = new System.Windows.Forms.Label();
            this.txtCrExpiry = new DevExpress.XtraEditors.DateEdit();
            this.txtCr = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAddress_E = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAccType = new System.Windows.Forms.Label();
            this.txt_Area = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_Block = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_Road = new DevComponents.DotNetBar.LabelX();
            this.lbl_Block = new DevComponents.DotNetBar.LabelX();
            this.txt_Road = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbl_Building = new DevComponents.DotNetBar.LabelX();
            this.txt_Building = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrExpiry.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrExpiry.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            this.headLbl.Size = new System.Drawing.Size(990, 35);
            this.headLbl.Text = "Clients";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(35, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(141, 164);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(115, 20);
            this.txtCode.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(141, 188);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(449, 20);
            this.txtName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(35, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNameE
            // 
            this.txtNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameE.Location = new System.Drawing.Point(141, 212);
            this.txtNameE.Name = "txtNameE";
            this.txtNameE.Size = new System.Drawing.Size(449, 20);
            this.txtNameE.TabIndex = 14;
            this.txtNameE.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(35, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name English";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtRespName
            // 
            this.txtRespName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRespName.Location = new System.Drawing.Point(141, 236);
            this.txtRespName.Name = "txtRespName";
            this.txtRespName.Size = new System.Drawing.Size(449, 20);
            this.txtRespName.TabIndex = 16;
            this.txtRespName.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(35, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Responsible";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRespNameE
            // 
            this.txtRespNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRespNameE.Location = new System.Drawing.Point(141, 260);
            this.txtRespNameE.Name = "txtRespNameE";
            this.txtRespNameE.Size = new System.Drawing.Size(449, 20);
            this.txtRespNameE.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(35, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Responsible English";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(35, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Credit Limit";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditLimit.DicemalDigits = 0;
            this.txtCreditLimit.Location = new System.Drawing.Point(141, 284);
            this.txtCreditLimit.maxmumNumber = 0D;
            this.txtCreditLimit.minimumNumber = 0D;
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.ProgramDigits = false;
            this.txtCreditLimit.Size = new System.Drawing.Size(154, 20);
            this.txtCreditLimit.TabIndex = 20;
            this.txtCreditLimit.Text = "0";
            this.txtCreditLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditDays.DicemalDigits = 0;
            this.txtCreditDays.Location = new System.Drawing.Point(436, 284);
            this.txtCreditDays.maxmumNumber = 0D;
            this.txtCreditDays.minimumNumber = 0D;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.ProgramDigits = false;
            this.txtCreditDays.Size = new System.Drawing.Size(154, 20);
            this.txtCreditDays.TabIndex = 22;
            this.txtCreditDays.Text = "0";
            this.txtCreditDays.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(330, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Credit Days";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTelephon
            // 
            this.txtTelephon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephon.Location = new System.Drawing.Point(141, 308);
            this.txtTelephon.Name = "txtTelephon";
            this.txtTelephon.Size = new System.Drawing.Size(154, 20);
            this.txtTelephon.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(35, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Telephon";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFax
            // 
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Location = new System.Drawing.Point(436, 308);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(154, 20);
            this.txtFax.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(330, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Fax";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(141, 356);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(449, 20);
            this.txtEmail.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(35, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Email";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(141, 380);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(449, 37);
            this.txtAddress.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(35, 380);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Address";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KM_Purch
            // 
            this.KM_Purch.BackColor = System.Drawing.SystemColors.Control;
            this.KM_Purch.Location = new System.Drawing.Point(141, 486);
            this.KM_Purch.Margin = new System.Windows.Forms.Padding(0);
            this.KM_Purch.Name = "KM_Purch";
            this.KM_Purch.Size = new System.Drawing.Size(449, 20);
            this.KM_Purch.TabIndex = 31;
            // 
            // KM_Sales
            // 
            this.KM_Sales.Location = new System.Drawing.Point(141, 510);
            this.KM_Sales.Margin = new System.Windows.Forms.Padding(0);
            this.KM_Sales.Name = "KM_Sales";
            this.KM_Sales.Size = new System.Drawing.Size(449, 20);
            this.KM_Sales.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(35, 486);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "VAT Purchase Class";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(35, 510);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "VAT Sales Class";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(35, 462);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 20);
            this.label14.TabIndex = 35;
            this.label14.Text = "VAT ID";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTaxID
            // 
            this.txtTaxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxID.Location = new System.Drawing.Point(141, 462);
            this.txtTaxID.Name = "txtTaxID";
            this.txtTaxID.Size = new System.Drawing.Size(267, 20);
            this.txtTaxID.TabIndex = 36;
            // 
            // txtBranch
            // 
            this.txtBranch.Enabled = false;
            this.txtBranch.Location = new System.Drawing.Point(141, 116);
            this.txtBranch.Margin = new System.Windows.Forms.Padding(0);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(449, 20);
            this.txtBranch.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(35, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 20);
            this.label15.TabIndex = 38;
            this.label15.Text = "Branch";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStoreID
            // 
            this.txtStoreID.BackColor = System.Drawing.SystemColors.Info;
            this.txtStoreID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStoreID.Location = new System.Drawing.Point(262, 164);
            this.txtStoreID.Name = "txtStoreID";
            this.txtStoreID.Size = new System.Drawing.Size(107, 20);
            this.txtStoreID.TabIndex = 42;
            this.txtStoreID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtStoreID.Visible = false;
            // 
            // txtMainAcc
            // 
            this.txtMainAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtMainAcc.Enabled = false;
            this.txtMainAcc.Location = new System.Drawing.Point(141, 140);
            this.txtMainAcc.Margin = new System.Windows.Forms.Padding(0);
            this.txtMainAcc.Name = "txtMainAcc";
            this.txtMainAcc.Size = new System.Drawing.Size(449, 20);
            this.txtMainAcc.TabIndex = 44;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(35, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "Code";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLevel
            // 
            this.txtLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLevel.DicemalDigits = 0;
            this.txtLevel.Enabled = false;
            this.txtLevel.Location = new System.Drawing.Point(474, 164);
            this.txtLevel.maxmumNumber = 0D;
            this.txtLevel.minimumNumber = 0D;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ProgramDigits = false;
            this.txtLevel.Size = new System.Drawing.Size(54, 20);
            this.txtLevel.TabIndex = 48;
            this.txtLevel.Text = "0";
            this.txtLevel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtMainLevel
            // 
            this.txtMainLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMainLevel.DicemalDigits = 0;
            this.txtMainLevel.Enabled = false;
            this.txtMainLevel.Location = new System.Drawing.Point(536, 162);
            this.txtMainLevel.maxmumNumber = 0D;
            this.txtMainLevel.minimumNumber = 0D;
            this.txtMainLevel.Name = "txtMainLevel";
            this.txtMainLevel.ProgramDigits = false;
            this.txtMainLevel.Size = new System.Drawing.Size(54, 20);
            this.txtMainLevel.TabIndex = 49;
            this.txtMainLevel.Text = "0";
            this.txtMainLevel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Final
            // 
            this.Final.BackColor = System.Drawing.SystemColors.Info;
            this.Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Final.Enabled = false;
            this.Final.Location = new System.Drawing.Point(430, 164);
            this.Final.Name = "Final";
            this.Final.Size = new System.Drawing.Size(38, 20);
            this.Final.TabIndex = 50;
            this.Final.Text = "1";
            this.Final.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCrExpiry
            // 
            this.txtCrExpiry.EditValue = null;
            this.txtCrExpiry.Location = new System.Drawing.Point(436, 332);
            this.txtCrExpiry.Name = "txtCrExpiry";
            this.txtCrExpiry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCrExpiry.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCrExpiry.Size = new System.Drawing.Size(154, 20);
            this.txtCrExpiry.TabIndex = 189;
            // 
            // txtCr
            // 
            this.txtCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCr.Location = new System.Drawing.Point(141, 332);
            this.txtCr.Name = "txtCr";
            this.txtCr.Size = new System.Drawing.Size(154, 20);
            this.txtCr.TabIndex = 188;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(330, 332);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 20);
            this.label16.TabIndex = 191;
            this.label16.Text = "CR Expiry Date";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Location = new System.Drawing.Point(35, 332);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 20);
            this.label18.TabIndex = 190;
            this.label18.Text = "CR Number";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress_E
            // 
            this.txtAddress_E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress_E.Location = new System.Drawing.Point(141, 421);
            this.txtAddress_E.Multiline = true;
            this.txtAddress_E.Name = "txtAddress_E";
            this.txtAddress_E.Size = new System.Drawing.Size(449, 37);
            this.txtAddress_E.TabIndex = 193;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(35, 421);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 20);
            this.label19.TabIndex = 192;
            this.label19.Text = "Address English";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAccType
            // 
            this.txtAccType.BackColor = System.Drawing.SystemColors.Info;
            this.txtAccType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccType.Location = new System.Drawing.Point(375, 164);
            this.txtAccType.Name = "txtAccType";
            this.txtAccType.Size = new System.Drawing.Size(36, 20);
            this.txtAccType.TabIndex = 194;
            this.txtAccType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtAccType.Visible = false;
            // 
            // txt_Area
            // 
            // 
            // 
            // 
            this.txt_Area.Border.Class = "TextBoxBorder";
            this.txt_Area.Location = new System.Drawing.Point(649, 455);
            this.txt_Area.Name = "txt_Area";
            this.txt_Area.Size = new System.Drawing.Size(92, 20);
            this.txt_Area.TabIndex = 201;
            this.txt_Area.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Area_KeyUp);
            // 
            // txt_Block
            // 
            // 
            // 
            // 
            this.txt_Block.Border.Class = "TextBoxBorder";
            this.txt_Block.Location = new System.Drawing.Point(649, 431);
            this.txt_Block.Name = "txt_Block";
            this.txt_Block.Size = new System.Drawing.Size(92, 20);
            this.txt_Block.TabIndex = 198;
            this.txt_Block.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Block_KeyUp);
            // 
            // lbl_Road
            // 
            this.lbl_Road.AutoSize = true;
            this.lbl_Road.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Road.Location = new System.Drawing.Point(618, 405);
            this.lbl_Road.Name = "lbl_Road";
            this.lbl_Road.Size = new System.Drawing.Size(26, 15);
            this.lbl_Road.TabIndex = 199;
            this.lbl_Road.Text = "Road";
            // 
            // lbl_Block
            // 
            this.lbl_Block.AutoSize = true;
            this.lbl_Block.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Block.Location = new System.Drawing.Point(617, 434);
            this.lbl_Block.Name = "lbl_Block";
            this.lbl_Block.Size = new System.Drawing.Size(27, 15);
            this.lbl_Block.TabIndex = 197;
            this.lbl_Block.Text = "Block";
            // 
            // txt_Road
            // 
            // 
            // 
            // 
            this.txt_Road.Border.Class = "TextBoxBorder";
            this.txt_Road.Location = new System.Drawing.Point(649, 405);
            this.txt_Road.Name = "txt_Road";
            this.txt_Road.Size = new System.Drawing.Size(92, 20);
            this.txt_Road.TabIndex = 200;
            this.txt_Road.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Road_KeyUp);
            // 
            // lbl_Building
            // 
            this.lbl_Building.AutoSize = true;
            this.lbl_Building.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Building.Location = new System.Drawing.Point(604, 382);
            this.lbl_Building.Name = "lbl_Building";
            this.lbl_Building.Size = new System.Drawing.Size(40, 15);
            this.lbl_Building.TabIndex = 195;
            this.lbl_Building.Text = "Building";
            // 
            // txt_Building
            // 
            // 
            // 
            // 
            this.txt_Building.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt_Building.Border.BorderBottomWidth = 1;
            this.txt_Building.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt_Building.Border.BorderLeftWidth = 1;
            this.txt_Building.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt_Building.Border.BorderRightWidth = 1;
            this.txt_Building.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt_Building.Border.BorderTopWidth = 1;
            this.txt_Building.Border.Class = "TextBoxBorder";
            this.txt_Building.Location = new System.Drawing.Point(649, 382);
            this.txt_Building.Name = "txt_Building";
            this.txt_Building.Size = new System.Drawing.Size(92, 20);
            this.txt_Building.TabIndex = 196;
            this.txt_Building.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Building_KeyUp);
            // 
            // frm_AddClient
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 710);
            this.Controls.Add(this.txt_Area);
            this.Controls.Add(this.txt_Block);
            this.Controls.Add(this.lbl_Road);
            this.Controls.Add(this.lbl_Block);
            this.Controls.Add(this.txt_Road);
            this.Controls.Add(this.lbl_Building);
            this.Controls.Add(this.txt_Building);
            this.Controls.Add(this.txtAccType);
            this.Controls.Add(this.txtAddress_E);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCrExpiry);
            this.Controls.Add(this.txtCr);
            this.Controls.Add(this.Final);
            this.Controls.Add(this.txtMainLevel);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtMainAcc);
            this.Controls.Add(this.txtStoreID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.txtTaxID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.KM_Sales);
            this.Controls.Add(this.KM_Purch);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTelephon);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCreditDays);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCreditLimit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRespNameE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRespName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNameE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Name = "frm_AddClient";
            this.Text = "frm_AddClient";
            this.Load += new System.EventHandler(this.frm_AddClient_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNameE, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRespName, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtRespNameE, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCreditLimit, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtCreditDays, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtTelephon, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtFax, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.KM_Purch, 0);
            this.Controls.SetChildIndex(this.KM_Sales, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtTaxID, 0);
            this.Controls.SetChildIndex(this.txtBranch, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtStoreID, 0);
            this.Controls.SetChildIndex(this.txtMainAcc, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.txtLevel, 0);
            this.Controls.SetChildIndex(this.txtMainLevel, 0);
            this.Controls.SetChildIndex(this.Final, 0);
            this.Controls.SetChildIndex(this.txtCr, 0);
            this.Controls.SetChildIndex(this.txtCrExpiry, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtAddress_E, 0);
            this.Controls.SetChildIndex(this.txtAccType, 0);
            this.Controls.SetChildIndex(this.txt_Building, 0);
            this.Controls.SetChildIndex(this.lbl_Building, 0);
            this.Controls.SetChildIndex(this.txt_Road, 0);
            this.Controls.SetChildIndex(this.lbl_Block, 0);
            this.Controls.SetChildIndex(this.lbl_Road, 0);
            this.Controls.SetChildIndex(this.txt_Block, 0);
            this.Controls.SetChildIndex(this.txt_Area, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtCrExpiry.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrExpiry.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRespName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRespNameE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MyControls.decimalText txtCreditLimit;
        private MyControls.decimalText txtCreditDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelephon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label11;
        private MyControls.UC_KM_Purch KM_Purch;
        private MyControls.UC_KM_Sales KM_Sales;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTaxID;
        private MyControls.UC_AccBranch txtBranch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label txtStoreID;
        private MyControls.UC_Acc txtMainAcc;
        private System.Windows.Forms.Label label17;
        private MyControls.decimalText txtLevel;
        private MyControls.decimalText txtMainLevel;
        private System.Windows.Forms.Label Final;
        private DevExpress.XtraEditors.DateEdit txtCrExpiry;
        private System.Windows.Forms.TextBox txtCr;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAddress_E;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label txtAccType;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Area;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Block;
        private DevComponents.DotNetBar.LabelX lbl_Road;
        private DevComponents.DotNetBar.LabelX lbl_Block;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Road;
        private DevComponents.DotNetBar.LabelX lbl_Building;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Building;
    }
}