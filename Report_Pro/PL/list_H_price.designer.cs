namespace Report_Pro.PL
{
    partial class list_H_price
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(list_H_price));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_LS = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.txtItem = new Report_Pro.MyControls.UC_Items();
            this.txtAcc = new Report_Pro.MyControls.UC_Acc();
            this.txtBranch = new Report_Pro.MyControls.UC_Branch();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LS)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_LS
            // 
            this.dgv_LS.AllowUserToAddRows = false;
            this.dgv_LS.AllowUserToDeleteRows = false;
            this.dgv_LS.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_LS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_LS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column13,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column21,
            this.Column22,
            this.Column23});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_LS.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.dgv_LS, "dgv_LS");
            this.dgv_LS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_LS.Name = "dgv_LS";
            this.dgv_LS.ReadOnly = true;
            this.dgv_LS.RowHeadersVisible = false;
            this.dgv_LS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // Column13
            // 
            resources.ApplyResources(this.Column13, "Column13");
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column7
            // 
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.Column8, "Column8");
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            dataGridViewCellStyle3.Format = "N2";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Column9, "Column9");
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            dataGridViewCellStyle4.Format = "N3";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.Column10, "Column10");
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            dataGridViewCellStyle5.Format = "N0";
            this.Column11.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.Column11, "Column11");
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column12, "Column12");
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column21
            // 
            resources.ApplyResources(this.Column21, "Column21");
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column22
            // 
            resources.ApplyResources(this.Column22, "Column22");
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            // 
            // Column23
            // 
            resources.ApplyResources(this.Column23, "Column23");
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.toDate);
            this.panel1.Controls.Add(this.fromDate);
            this.panel1.Controls.Add(this.txtItem);
            this.panel1.Controls.Add(this.txtAcc);
            this.panel1.Controls.Add(this.txtBranch);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnReport
            // 
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // toDate
            // 
            resources.ApplyResources(this.toDate, "toDate");
            this.toDate.Name = "toDate";
            // 
            // fromDate
            // 
            resources.ApplyResources(this.fromDate, "fromDate");
            this.fromDate.Name = "fromDate";
            // 
            // txtItem
            // 
            resources.ApplyResources(this.txtItem, "txtItem");
            this.txtItem.Name = "txtItem";
            // 
            // txtAcc
            // 
            this.txtAcc.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.txtAcc, "txtAcc");
            this.txtAcc.Name = "txtAcc";
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.Transparent;
            this.txtBranch.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtBranch, "txtBranch");
            this.txtBranch.Name = "txtBranch";
            // 
            // list_H_price
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.dgv_LS);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "list_H_price";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_H_price_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_LS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        public System.Windows.Forms.DateTimePicker toDate;
        public System.Windows.Forms.DateTimePicker fromDate;
        public MyControls.UC_Items txtItem;
        public MyControls.UC_Acc txtAcc;
        public MyControls.UC_Branch txtBranch;
    }
}