namespace Report_Pro.MyControls
{
    partial class UcJor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcJor));
            this.dGV_Item = new System.Windows.Forms.DataGridView();
            this.csMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rptStatment = new System.Windows.Forms.ToolStripMenuItem();
            this.chartOfAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chRecordVat = new System.Windows.Forms.CheckBox();
            this.txtTotal = new Report_Pro.MyControls.decimalText();
            this._Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._AccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._AccName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CostNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._VatSupp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._InvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._invNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._InvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._VatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Item)).BeginInit();
            this.csMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_Item
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            this.dGV_Item.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dGV_Item.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGV_Item.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGV_Item.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_Item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dGV_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Amount,
            this._AccNo,
            this._AccName,
            this._Desc,
            this._CostNo,
            this._CostName,
            this._CatCode,
            this._CatName,
            this._VatSupp,
            this._InvAmount,
            this._invNo,
            this._InvDate,
            this._VatID});
            this.tableLayoutPanel1.SetColumnSpan(this.dGV_Item, 2);
            this.dGV_Item.ContextMenuStrip = this.csMenu;
            resources.ApplyResources(this.dGV_Item, "dGV_Item");
            this.dGV_Item.EnableHeadersVisualStyles = false;
            this.dGV_Item.GridColor = System.Drawing.SystemColors.WindowText;
            this.dGV_Item.Name = "dGV_Item";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_Item.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dGV_Item.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dGV_Item.ShowCellToolTips = false;
            this.dGV_Item.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Item_CellDoubleClick);
            this.dGV_Item.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Item_CellEndEdit);
            this.dGV_Item.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dGV_Item_DefaultValuesNeeded);
            this.dGV_Item.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dGV_Item_RowsAdded);
            this.dGV_Item.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dGV_Item_RowsRemoved);
            this.dGV_Item.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dGV_Item_UserDeletedRow);
            this.dGV_Item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dGV_Item_KeyDown);
            // 
            // csMenu
            // 
            this.csMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rptStatment,
            this.chartOfAccount});
            this.csMenu.Name = "csMenu";
            resources.ApplyResources(this.csMenu, "csMenu");
            this.csMenu.Opening += new System.ComponentModel.CancelEventHandler(this.csMenu_Opening);
            // 
            // rptStatment
            // 
            this.rptStatment.Name = "rptStatment";
            resources.ApplyResources(this.rptStatment, "rptStatment");
            this.rptStatment.Click += new System.EventHandler(this.rptStatment_Click);
            // 
            // chartOfAccount
            // 
            this.chartOfAccount.Name = "chartOfAccount";
            resources.ApplyResources(this.chartOfAccount, "chartOfAccount");
            this.chartOfAccount.Click += new System.EventHandler(this.chartOfAccount_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.dGV_Item, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTotal, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chRecordVat);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // chRecordVat
            // 
            resources.ApplyResources(this.chRecordVat, "chRecordVat");
            this.chRecordVat.Name = "chRecordVat";
            this.chRecordVat.UseVisualStyleBackColor = true;
            this.chRecordVat.CheckedChanged += new System.EventHandler(this.chRecordVat_CheckedChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.DicemalDigits = 0;
            resources.ApplyResources(this.txtTotal, "txtTotal");
            this.txtTotal.maxmumNumber = 0D;
            this.txtTotal.minimumNumber = 0D;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ProgramDigits = true;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // _Amount
            // 
            this._Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Amount.FillWeight = 6F;
            resources.ApplyResources(this._Amount, "_Amount");
            this._Amount.Name = "_Amount";
            this._Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _AccNo
            // 
            this._AccNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._AccNo.FillWeight = 6F;
            resources.ApplyResources(this._AccNo, "_AccNo");
            this._AccNo.Name = "_AccNo";
            this._AccNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _AccName
            // 
            this._AccName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._AccName.FillWeight = 15F;
            resources.ApplyResources(this._AccName, "_AccName");
            this._AccName.Name = "_AccName";
            this._AccName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _Desc
            // 
            this._Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Desc.FillWeight = 22F;
            resources.ApplyResources(this._Desc, "_Desc");
            this._Desc.Name = "_Desc";
            this._Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _CostNo
            // 
            this._CostNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._CostNo.FillWeight = 4F;
            resources.ApplyResources(this._CostNo, "_CostNo");
            this._CostNo.Name = "_CostNo";
            this._CostNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _CostName
            // 
            this._CostName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._CostName.FillWeight = 9F;
            resources.ApplyResources(this._CostName, "_CostName");
            this._CostName.Name = "_CostName";
            this._CostName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _CatCode
            // 
            this._CatCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._CatCode.FillWeight = 4F;
            resources.ApplyResources(this._CatCode, "_CatCode");
            this._CatCode.Name = "_CatCode";
            this._CatCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _CatName
            // 
            this._CatName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._CatName.FillWeight = 9F;
            resources.ApplyResources(this._CatName, "_CatName");
            this._CatName.Name = "_CatName";
            this._CatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _VatSupp
            // 
            this._VatSupp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._VatSupp.FillWeight = 7F;
            resources.ApplyResources(this._VatSupp, "_VatSupp");
            this._VatSupp.Name = "_VatSupp";
            this._VatSupp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _InvAmount
            // 
            this._InvAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._InvAmount.FillWeight = 4.5F;
            resources.ApplyResources(this._InvAmount, "_InvAmount");
            this._InvAmount.Name = "_InvAmount";
            this._InvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _invNo
            // 
            this._invNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._invNo.FillWeight = 4.5F;
            resources.ApplyResources(this._invNo, "_invNo");
            this._invNo.Name = "_invNo";
            this._invNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _InvDate
            // 
            this._InvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._InvDate.FillWeight = 4.5F;
            resources.ApplyResources(this._InvDate, "_InvDate");
            this._InvDate.Name = "_InvDate";
            this._InvDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _VatID
            // 
            this._VatID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._VatID.FillWeight = 4.5F;
            resources.ApplyResources(this._VatID, "_VatID");
            this._VatID.Name = "_VatID";
            this._VatID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UcJor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "UcJor";
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Item)).EndInit();
            this.csMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dGV_Item;
        public decimalText txtTotal;
        private System.Windows.Forms.ContextMenuStrip csMenu;
        private System.Windows.Forms.ToolStripMenuItem rptStatment;
        private System.Windows.Forms.ToolStripMenuItem chartOfAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chRecordVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn _AccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _AccName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CostNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _VatSupp;
        private System.Windows.Forms.DataGridViewTextBoxColumn _InvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn _invNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _InvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _VatID;
        private System.Windows.Forms.Button button1;
    }
}
