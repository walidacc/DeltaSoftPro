namespace Report_Pro.PL
{
    partial class frm_heatNO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this._itemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._MainCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._AccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.txtTransactionCode = new System.Windows.Forms.TextBox();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.txtMainCounter = new System.Windows.Forms.TextBox();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.txtHeatNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.txtCoilsWeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new Report_Pro.MyControls.decimalText();
            this.txtNoOfCoils = new Report_Pro.MyControls.decimalText();
            this._heatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._matrialid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lenth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._itemNo,
            this._Description,
            this._unit,
            this._Qty,
            this._date,
            this._MainCounter,
            this._AccNo});
            this.dgv1.Location = new System.Drawing.Point(380, 12);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(705, 150);
            this.dgv1.TabIndex = 0;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // _itemNo
            // 
            this._itemNo.HeaderText = "Item No";
            this._itemNo.Name = "_itemNo";
            this._itemNo.ReadOnly = true;
            // 
            // _Description
            // 
            this._Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Description.HeaderText = "Description";
            this._Description.Name = "_Description";
            this._Description.ReadOnly = true;
            // 
            // _unit
            // 
            this._unit.HeaderText = "Unit";
            this._unit.Name = "_unit";
            this._unit.ReadOnly = true;
            this._unit.Width = 80;
            // 
            // _Qty
            // 
            this._Qty.HeaderText = "Qty";
            this._Qty.Name = "_Qty";
            this._Qty.ReadOnly = true;
            // 
            // _date
            // 
            this._date.HeaderText = "Date";
            this._date.Name = "_date";
            this._date.ReadOnly = true;
            // 
            // _MainCounter
            // 
            this._MainCounter.HeaderText = "Main Counter";
            this._MainCounter.Name = "_MainCounter";
            this._MainCounter.ReadOnly = true;
            this._MainCounter.Visible = false;
            // 
            // _AccNo
            // 
            this._AccNo.HeaderText = "Acc No";
            this._AccNo.Name = "_AccNo";
            this._AccNo.ReadOnly = true;
            this._AccNo.Visible = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transaction Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(31, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Invoice No";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(203, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Main Counter";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemNo
            // 
            this.txtItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemNo.Enabled = false;
            this.txtItemNo.Location = new System.Drawing.Point(109, 9);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(78, 20);
            this.txtItemNo.TabIndex = 5;
            // 
            // txtTransactionCode
            // 
            this.txtTransactionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionCode.Enabled = false;
            this.txtTransactionCode.Location = new System.Drawing.Point(295, 9);
            this.txtTransactionCode.Name = "txtTransactionCode";
            this.txtTransactionCode.Size = new System.Drawing.Size(64, 20);
            this.txtTransactionCode.TabIndex = 6;
            // 
            // txtInvNo
            // 
            this.txtInvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvNo.Enabled = false;
            this.txtInvNo.Location = new System.Drawing.Point(109, 32);
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(78, 20);
            this.txtInvNo.TabIndex = 7;
            // 
            // txtMainCounter
            // 
            this.txtMainCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMainCounter.Enabled = false;
            this.txtMainCounter.Location = new System.Drawing.Point(295, 32);
            this.txtMainCounter.Name = "txtMainCounter";
            this.txtMainCounter.Size = new System.Drawing.Size(64, 20);
            this.txtMainCounter.TabIndex = 8;
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalWeight.Enabled = false;
            this.txtTotalWeight.Location = new System.Drawing.Point(109, 55);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.Size = new System.Drawing.Size(78, 20);
            this.txtTotalWeight.TabIndex = 15;
            // 
            // txtHeatNo
            // 
            this.txtHeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeatNo.Location = new System.Drawing.Point(137, 116);
            this.txtHeatNo.Name = "txtHeatNo";
            this.txtHeatNo.Size = new System.Drawing.Size(125, 20);
            this.txtHeatNo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(269, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(31, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Weight";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(137, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Heat No";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(31, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "No of Coils";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv2
            // 
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._heatNo,
            this._weight,
            this._matrialid,
            this._lenth,
            this._width});
            this.dgv2.Location = new System.Drawing.Point(77, 186);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(755, 458);
            this.dgv2.TabIndex = 17;
            this.dgv2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dgv2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellEndEdit);
            this.dgv2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv2_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::Report_Pro.Properties.Resources.updatetableofcontents_32x32;
            this.btnUpdate.Location = new System.Drawing.Point(252, 142);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 39);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.Image = global::Report_Pro.Properties.Resources.fill_32x32;
            this.btnFillGrid.Location = new System.Drawing.Point(109, 142);
            this.btnFillGrid.Name = "btnFillGrid";
            this.btnFillGrid.Size = new System.Drawing.Size(94, 39);
            this.btnFillGrid.TabIndex = 18;
            this.btnFillGrid.Text = "Fill Grid";
            this.btnFillGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFillGrid.UseVisualStyleBackColor = true;
            this.btnFillGrid.Click += new System.EventHandler(this.btnFillGrid_Click);
            // 
            // txtCoilsWeight
            // 
            this.txtCoilsWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoilsWeight.Enabled = false;
            this.txtCoilsWeight.Location = new System.Drawing.Point(295, 652);
            this.txtCoilsWeight.Name = "txtCoilsWeight";
            this.txtCoilsWeight.Size = new System.Drawing.Size(127, 20);
            this.txtCoilsWeight.TabIndex = 20;
            // 
            // txtWidth
            // 
            this.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWidth.DicemalDigits = 0;
            this.txtWidth.Location = new System.Drawing.Point(269, 116);
            this.txtWidth.maxmumNumber = 0D;
            this.txtWidth.minimumNumber = 0D;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ProgramDigits = false;
            this.txtWidth.Size = new System.Drawing.Size(98, 20);
            this.txtWidth.TabIndex = 22;
            this.txtWidth.Text = "0";
            this.txtWidth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtNoOfCoils
            // 
            this.txtNoOfCoils.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfCoils.DicemalDigits = 0;
            this.txtNoOfCoils.Location = new System.Drawing.Point(31, 116);
            this.txtNoOfCoils.maxmumNumber = 0D;
            this.txtNoOfCoils.minimumNumber = 0D;
            this.txtNoOfCoils.Name = "txtNoOfCoils";
            this.txtNoOfCoils.ProgramDigits = false;
            this.txtNoOfCoils.Size = new System.Drawing.Size(98, 20);
            this.txtNoOfCoils.TabIndex = 21;
            this.txtNoOfCoils.Text = "0";
            this.txtNoOfCoils.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // _heatNo
            // 
            this._heatNo.FillWeight = 25F;
            this._heatNo.HeaderText = "Heat No";
            this._heatNo.Name = "_heatNo";
            this._heatNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _weight
            // 
            dataGridViewCellStyle1.Format = "N0";
            this._weight.DefaultCellStyle = dataGridViewCellStyle1;
            this._weight.FillWeight = 17F;
            this._weight.HeaderText = "Weight";
            this._weight.Name = "_weight";
            this._weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _matrialid
            // 
            this._matrialid.FillWeight = 24F;
            this._matrialid.HeaderText = "Matrial Id";
            this._matrialid.Name = "_matrialid";
            this._matrialid.ReadOnly = true;
            this._matrialid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _lenth
            // 
            dataGridViewCellStyle2.Format = "N0";
            this._lenth.DefaultCellStyle = dataGridViewCellStyle2;
            this._lenth.FillWeight = 17F;
            this._lenth.HeaderText = "Lenth";
            this._lenth.Name = "_lenth";
            this._lenth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _width
            // 
            dataGridViewCellStyle3.Format = "N0";
            this._width.DefaultCellStyle = dataGridViewCellStyle3;
            this._width.FillWeight = 17F;
            this._width.HeaderText = "Width";
            this._width.Name = "_width";
            this._width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frm_heatNO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 687);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtNoOfCoils);
            this.Controls.Add(this.txtCoilsWeight);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFillGrid);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.txtTotalWeight);
            this.Controls.Add(this.txtHeatNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMainCounter);
            this.Controls.Add(this.txtInvNo);
            this.Controls.Add(this.txtTransactionCode);
            this.Controls.Add(this.txtItemNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv1);
            this.Name = "frm_heatNO";
            this.Text = "frm_heatNO";
            this.Load += new System.EventHandler(this.frm_heatNO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemNo;
        private System.Windows.Forms.TextBox txtMainCounter;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.TextBox txtHeatNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button btnFillGrid;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtCoilsWeight;
        public System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _itemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn _date;
        private System.Windows.Forms.DataGridViewTextBoxColumn _MainCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn _AccNo;
        public System.Windows.Forms.TextBox txtTransactionCode;
        public System.Windows.Forms.TextBox txtInvNo;
        private MyControls.decimalText txtNoOfCoils;
        private MyControls.decimalText txtWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn _heatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn _matrialid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _lenth;
        private System.Windows.Forms.DataGridViewTextBoxColumn _width;
    }
}