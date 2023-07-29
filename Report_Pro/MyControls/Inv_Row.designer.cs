namespace Report_Pro.MyControls
{
    partial class Inv_Row
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inv_Row));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Weight_ = new Report_Pro.MyControls.decimalText();
            this.Ser = new Report_Pro.MyControls.decimalText();
            this.qty = new Report_Pro.MyControls.decimalText();
            this.totWeight = new Report_Pro.MyControls.decimalText();
            this.TxtPrice = new Report_Pro.MyControls.decimalText();
            this.Price_ton = new Report_Pro.MyControls.decimalText();
            this.TxtDisc = new Report_Pro.MyControls.decimalText();
            this.VatRate = new Report_Pro.MyControls.decimalText();
            this.VatAccRate = new Report_Pro.MyControls.decimalText();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.KM_TYPE_ITEMS = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.TxtDesc = new System.Windows.Forms.TextBox();
            this.txt_subTOt = new System.Windows.Forms.TextBox();
            this.VatValue = new System.Windows.Forms.TextBox();
            this.Txtvalue = new Report_Pro.MyControls.decimalText();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.VatDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Weight_, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.Ser, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.qty, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.totWeight, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtPrice, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.Price_ton, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtDisc, 12, 0);
            this.tableLayoutPanel2.Controls.Add(this.VatRate, 14, 0);
            this.tableLayoutPanel2.Controls.Add(this.VatAccRate, 19, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtUnit, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNote, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCost, 17, 0);
            this.tableLayoutPanel2.Controls.Add(this.KM_TYPE_ITEMS, 18, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBalance, 16, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtDesc, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_subTOt, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.VatValue, 15, 0);
            this.tableLayoutPanel2.Controls.Add(this.Txtvalue, 13, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_Code, 2, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Weight_
            // 
            this.Weight_.BackColor = System.Drawing.Color.Ivory;
            this.Weight_.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Weight_.DicemalDigits = 0;
            resources.ApplyResources(this.Weight_, "Weight_");
            this.Weight_.maxmumNumber = 0D;
            this.Weight_.minimumNumber = 0D;
            this.Weight_.Name = "Weight_";
            this.Weight_.ProgramDigits = false;
            this.Weight_.ReadOnly = true;
            this.Weight_.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Ser
            // 
            this.Ser.BackColor = System.Drawing.Color.RoyalBlue;
            this.Ser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ser.DicemalDigits = 0;
            resources.ApplyResources(this.Ser, "Ser");
            this.Ser.maxmumNumber = 0D;
            this.Ser.minimumNumber = 0D;
            this.Ser.Name = "Ser";
            this.Ser.ProgramDigits = false;
            this.Ser.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // qty
            // 
            this.qty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.qty.DicemalDigits = 0;
            resources.ApplyResources(this.qty, "qty");
            this.qty.maxmumNumber = 0D;
            this.qty.minimumNumber = 0D;
            this.qty.Name = "qty";
            this.qty.ProgramDigits = false;
            this.qty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Qty_KeyDown);
            this.qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Qty_KeyUp);
            // 
            // totWeight
            // 
            this.totWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totWeight.DicemalDigits = 0;
            resources.ApplyResources(this.totWeight, "totWeight");
            this.totWeight.maxmumNumber = 0D;
            this.totWeight.minimumNumber = 0D;
            this.totWeight.Name = "totWeight";
            this.totWeight.ProgramDigits = false;
            this.totWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.totWeight_KeyDown);
            this.totWeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.totWeight_KeyUp);
            // 
            // TxtPrice
            // 
            this.TxtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPrice.DicemalDigits = 3;
            resources.ApplyResources(this.TxtPrice, "TxtPrice");
            this.TxtPrice.maxmumNumber = 0D;
            this.TxtPrice.minimumNumber = 0D;
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.ProgramDigits = false;
            this.TxtPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            this.TxtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyDown);
            this.TxtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyUp);
            // 
            // Price_ton
            // 
            this.Price_ton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Price_ton.DicemalDigits = 0;
            resources.ApplyResources(this.Price_ton, "Price_ton");
            this.Price_ton.maxmumNumber = 0D;
            this.Price_ton.minimumNumber = 0D;
            this.Price_ton.Name = "Price_ton";
            this.Price_ton.ProgramDigits = false;
            this.Price_ton.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Price_ton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Price_ton_KeyDown);
            this.Price_ton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Price_ton_KeyUp);
            // 
            // TxtDisc
            // 
            this.TxtDisc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDisc.DicemalDigits = 0;
            resources.ApplyResources(this.TxtDisc, "TxtDisc");
            this.TxtDisc.maxmumNumber = 0D;
            this.TxtDisc.minimumNumber = 0D;
            this.TxtDisc.Name = "TxtDisc";
            this.TxtDisc.ProgramDigits = false;
            this.TxtDisc.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TxtDisc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDisc_KeyDown);
            this.TxtDisc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtDisc_KeyUp);
            // 
            // VatRate
            // 
            this.VatRate.BackColor = System.Drawing.Color.Ivory;
            this.VatRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VatRate.DicemalDigits = 0;
            resources.ApplyResources(this.VatRate, "VatRate");
            this.VatRate.maxmumNumber = 0D;
            this.VatRate.minimumNumber = 0D;
            this.VatRate.Name = "VatRate";
            this.VatRate.ProgramDigits = false;
            this.VatRate.ReadOnly = true;
            this.VatRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // VatAccRate
            // 
            this.VatAccRate.BackColor = System.Drawing.Color.Ivory;
            this.VatAccRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VatAccRate.DicemalDigits = 0;
            resources.ApplyResources(this.VatAccRate, "VatAccRate");
            this.VatAccRate.maxmumNumber = 0D;
            this.VatAccRate.minimumNumber = 0D;
            this.VatAccRate.Name = "VatAccRate";
            this.VatAccRate.ProgramDigits = false;
            this.VatAccRate.ReadOnly = true;
            this.VatAccRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.Ivory;
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtUnit, "txtUnit");
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            this.txtNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNote_KeyDown);
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.Color.Ivory;
            this.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtCost, "txtCost");
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            // 
            // KM_TYPE_ITEMS
            // 
            this.KM_TYPE_ITEMS.BackColor = System.Drawing.Color.Ivory;
            this.KM_TYPE_ITEMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.KM_TYPE_ITEMS, "KM_TYPE_ITEMS");
            this.KM_TYPE_ITEMS.Name = "KM_TYPE_ITEMS";
            this.KM_TYPE_ITEMS.ReadOnly = true;
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.LightCyan;
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtBalance, "txtBalance");
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            // 
            // TxtDesc
            // 
            this.TxtDesc.BackColor = System.Drawing.Color.Ivory;
            this.TxtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TxtDesc, "TxtDesc");
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.ReadOnly = true;
            // 
            // txt_subTOt
            // 
            this.txt_subTOt.BackColor = System.Drawing.Color.Ivory;
            this.txt_subTOt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txt_subTOt, "txt_subTOt");
            this.txt_subTOt.Name = "txt_subTOt";
            this.txt_subTOt.ReadOnly = true;
            // 
            // VatValue
            // 
            this.VatValue.BackColor = System.Drawing.Color.Ivory;
            this.VatValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.VatValue, "VatValue");
            this.VatValue.Name = "VatValue";
            this.VatValue.ReadOnly = true;
            // 
            // Txtvalue
            // 
            this.Txtvalue.BackColor = System.Drawing.Color.Ivory;
            this.Txtvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txtvalue.DicemalDigits = 0;
            resources.ApplyResources(this.Txtvalue, "Txtvalue");
            this.Txtvalue.maxmumNumber = 0D;
            this.Txtvalue.minimumNumber = 0D;
            this.Txtvalue.Name = "Txtvalue";
            this.Txtvalue.ProgramDigits = false;
            this.Txtvalue.ReadOnly = true;
            this.Txtvalue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txt_Code
            // 
            this.txt_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txt_Code, "txt_Code");
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.DoubleClick += new System.EventHandler(this.txt_Code_DoubleClick);
            this.txt_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Code_KeyDown);
            // 
            // VatDate
            // 
            resources.ApplyResources(this.VatDate, "VatDate");
            this.VatDate.Name = "VatDate";
            // 
            // Inv_Row
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.VatDate);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Inv_Row";
            this.Load += new System.EventHandler(this.Inv_Row_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TextBox txt_Code;
        public System.Windows.Forms.TextBox txtNote;
        public System.Windows.Forms.TextBox TxtDesc;
        public System.Windows.Forms.TextBox txtUnit;
        public System.Windows.Forms.TextBox KM_TYPE_ITEMS;
        public System.Windows.Forms.TextBox txtBalance;
        public System.Windows.Forms.TextBox txtCost;
        public System.Windows.Forms.TextBox VatValue;
        public System.Windows.Forms.TextBox txt_subTOt;
        public decimalText VatRate;
        public decimalText VatAccRate;
        public decimalText Txtvalue;
        public decimalText TxtDisc;
        public decimalText Weight_;
        public decimalText qty;
        public decimalText totWeight;
        public decimalText TxtPrice;
        public decimalText Price_ton;
        public decimalText Ser;
        private System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.DateTimePicker VatDate;
    }
}
