namespace Report_Pro.PL
{
    partial class frm_PoApproved
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.chApproved = new System.Windows.Forms.CheckBox();
            this.chNotApproved = new System.Windows.Forms.CheckBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.colSerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransactionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfirmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAcc = new Report_Pro.MyControls.UC_Acc();
            this.txtUser = new Report_Pro.MyControls.Uc_user();
            this.txtBranch = new Report_Pro.MyControls.UC_Branch();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAcc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtToDate);
            this.panel1.Controls.Add(this.txtFromDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBranch);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.chApproved);
            this.panel1.Controls.Add(this.chNotApproved);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 154);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(35, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vendor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(35, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "User";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(35, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "To Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(35, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "From Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(100, 108);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(106, 20);
            this.txtToDate.TabIndex = 6;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(100, 82);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(106, 20);
            this.txtFromDate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Branch";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(590, 28);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(111, 28);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // chApproved
            // 
            this.chApproved.AutoSize = true;
            this.chApproved.Location = new System.Drawing.Point(456, 12);
            this.chApproved.Name = "chApproved";
            this.chApproved.Size = new System.Drawing.Size(73, 17);
            this.chApproved.TabIndex = 1;
            this.chApproved.Text = "Approved";
            this.chApproved.UseVisualStyleBackColor = true;
            // 
            // chNotApproved
            // 
            this.chNotApproved.AutoSize = true;
            this.chNotApproved.Checked = true;
            this.chNotApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chNotApproved.Location = new System.Drawing.Point(456, 35);
            this.chNotApproved.Name = "chNotApproved";
            this.chNotApproved.Size = new System.Drawing.Size(90, 17);
            this.chNotApproved.TabIndex = 1;
            this.chNotApproved.Text = "NotApproved";
            this.chNotApproved.UseVisualStyleBackColor = true;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerNo,
            this.colBranchCode,
            this.colBranch,
            this.colYear,
            this.colDate,
            this.colTransactionCode,
            this.colAccNo,
            this.colVendor,
            this.colUserID,
            this.colUser,
            this.colConfirmed});
            this.dgv1.Location = new System.Drawing.Point(0, 154);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1102, 363);
            this.dgv1.TabIndex = 1;
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // colSerNo
            // 
            this.colSerNo.HeaderText = "No";
            this.colSerNo.Name = "colSerNo";
            this.colSerNo.ReadOnly = true;
            this.colSerNo.Width = 60;
            // 
            // colBranchCode
            // 
            this.colBranchCode.HeaderText = "Branch Code";
            this.colBranchCode.Name = "colBranchCode";
            this.colBranchCode.ReadOnly = true;
            this.colBranchCode.Width = 70;
            // 
            // colBranch
            // 
            this.colBranch.HeaderText = "Branch";
            this.colBranch.Name = "colBranch";
            this.colBranch.ReadOnly = true;
            this.colBranch.Width = 160;
            // 
            // colYear
            // 
            this.colYear.HeaderText = "Year";
            this.colYear.Name = "colYear";
            this.colYear.ReadOnly = true;
            this.colYear.Visible = false;
            this.colYear.Width = 50;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 140;
            // 
            // colTransactionCode
            // 
            this.colTransactionCode.HeaderText = "Transaction Code";
            this.colTransactionCode.Name = "colTransactionCode";
            this.colTransactionCode.ReadOnly = true;
            this.colTransactionCode.Visible = false;
            this.colTransactionCode.Width = 50;
            // 
            // colAccNo
            // 
            this.colAccNo.HeaderText = "Account#";
            this.colAccNo.Name = "colAccNo";
            this.colAccNo.ReadOnly = true;
            this.colAccNo.Width = 80;
            // 
            // colVendor
            // 
            this.colVendor.HeaderText = "Vendor";
            this.colVendor.Name = "colVendor";
            this.colVendor.ReadOnly = true;
            this.colVendor.Width = 350;
            // 
            // colUserID
            // 
            this.colUserID.HeaderText = "User ID";
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;
            this.colUserID.Visible = false;
            this.colUserID.Width = 50;
            // 
            // colUser
            // 
            this.colUser.HeaderText = "User";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            this.colUser.Width = 120;
            // 
            // colConfirmed
            // 
            this.colConfirmed.HeaderText = "Confirmed";
            this.colConfirmed.Name = "colConfirmed";
            this.colConfirmed.ReadOnly = true;
            this.colConfirmed.Width = 60;
            // 
            // txtAcc
            // 
            this.txtAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtAcc.Location = new System.Drawing.Point(100, 33);
            this.txtAcc.Margin = new System.Windows.Forms.Padding(0);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(343, 20);
            this.txtAcc.TabIndex = 11;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(100, 57);
            this.txtUser.Margin = new System.Windows.Forms.Padding(0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(343, 20);
            this.txtUser.TabIndex = 9;
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.Color.Transparent;
            this.txtBranch.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBranch.Location = new System.Drawing.Point(100, 9);
            this.txtBranch.Margin = new System.Windows.Forms.Padding(0);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(343, 20);
            this.txtBranch.TabIndex = 3;
            // 
            // frm_PoApproved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 529);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_PoApproved";
            this.Text = "frm_PoApproved";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtToDate;
        private System.Windows.Forms.DateTimePicker txtFromDate;
        private System.Windows.Forms.Label label1;
        private MyControls.UC_Branch txtBranch;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.CheckBox chApproved;
        private System.Windows.Forms.CheckBox chNotApproved;
        private System.Windows.Forms.Label label4;
        private MyControls.Uc_user txtUser;
        private System.Windows.Forms.Label label5;
        private MyControls.UC_Acc txtAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfirmed;
    }
}