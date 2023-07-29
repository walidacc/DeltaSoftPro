namespace Report_Pro.PL
{
    partial class frm_newItem
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.btn_AddItem = new System.Windows.Forms.Button();
            this.col_GroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GroupDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_itemDescAr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_itemDescEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItemDesEn = new System.Windows.Forms.Label();
            this.lblItemDesAr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_GroupCode,
            this.col_GroupDescr,
            this.col_itemDescAr,
            this.col_itemDescEn});
            this.dgv1.Location = new System.Drawing.Point(12, 95);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(576, 435);
            this.dgv1.TabIndex = 1;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchCode.Location = new System.Drawing.Point(86, 27);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(98, 20);
            this.txtSearchCode.TabIndex = 61;
            this.txtSearchCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchCode_KeyUp);
            // 
            // txtSearchName
            // 
            this.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchName.Location = new System.Drawing.Point(86, 52);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(233, 20);
            this.txtSearchName.TabIndex = 63;
            this.txtSearchName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchName_KeyUp);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Location = new System.Drawing.Point(293, 13);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(0, 13);
            this.lblGroupCode.TabIndex = 64;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(361, 13);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(0, 13);
            this.lblItemCode.TabIndex = 65;
            // 
            // btn_AddItem
            // 
            this.btn_AddItem.Location = new System.Drawing.Point(484, 26);
            this.btn_AddItem.Name = "btn_AddItem";
            this.btn_AddItem.Size = new System.Drawing.Size(103, 23);
            this.btn_AddItem.TabIndex = 66;
            this.btn_AddItem.Text = "Add Item Code";
            this.btn_AddItem.UseVisualStyleBackColor = true;
            this.btn_AddItem.Click += new System.EventHandler(this.btn_AddItem_Click);
            // 
            // col_GroupCode
            // 
            this.col_GroupCode.HeaderText = "Code";
            this.col_GroupCode.Name = "col_GroupCode";
            this.col_GroupCode.ReadOnly = true;
            // 
            // col_GroupDescr
            // 
            this.col_GroupDescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_GroupDescr.HeaderText = "Description";
            this.col_GroupDescr.Name = "col_GroupDescr";
            this.col_GroupDescr.ReadOnly = true;
            // 
            // col_itemDescAr
            // 
            this.col_itemDescAr.HeaderText = "Item Desc";
            this.col_itemDescAr.Name = "col_itemDescAr";
            this.col_itemDescAr.ReadOnly = true;
            this.col_itemDescAr.Visible = false;
            // 
            // col_itemDescEn
            // 
            this.col_itemDescEn.HeaderText = "Item Desc En";
            this.col_itemDescEn.Name = "col_itemDescEn";
            this.col_itemDescEn.ReadOnly = true;
            this.col_itemDescEn.Visible = false;
            // 
            // lblItemDesEn
            // 
            this.lblItemDesEn.AutoSize = true;
            this.lblItemDesEn.Location = new System.Drawing.Point(350, 65);
            this.lblItemDesEn.Name = "lblItemDesEn";
            this.lblItemDesEn.Size = new System.Drawing.Size(0, 13);
            this.lblItemDesEn.TabIndex = 68;
            // 
            // lblItemDesAr
            // 
            this.lblItemDesAr.AutoSize = true;
            this.lblItemDesAr.Location = new System.Drawing.Point(350, 42);
            this.lblItemDesAr.Name = "lblItemDesAr";
            this.lblItemDesAr.Size = new System.Drawing.Size(0, 13);
            this.lblItemDesAr.TabIndex = 67;
            // 
            // frm_newItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 544);
            this.Controls.Add(this.lblItemDesEn);
            this.Controls.Add(this.lblItemDesAr);
            this.Controls.Add(this.btn_AddItem);
            this.Controls.Add(this.lblItemCode);
            this.Controls.Add(this.lblGroupCode);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv1);
            this.Name = "frm_newItem";
            this.Text = "frm_NewItm";
            this.Load += new System.EventHandler(this.frm_newItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddItem;
        public System.Windows.Forms.Label lblGroupCode;
        public System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GroupDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_itemDescAr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_itemDescEn;
        public System.Windows.Forms.Label lblItemDesEn;
        public System.Windows.Forms.Label lblItemDesAr;
    }
}