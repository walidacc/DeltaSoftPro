namespace Report_Pro.PL
{
    partial class frm_samples
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnExportToBdf = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btn_getDataFromExcel = new DevComponents.DotNetBar.ButtonX();
            this.dgv_Inv = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this._colSer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colBranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colTransactionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this._serNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._transaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._transactionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnExportToBdf);
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.btn_getDataFromExcel);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1370, 53);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // btnExportToBdf
            // 
            this.btnExportToBdf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToBdf.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportToBdf.Location = new System.Drawing.Point(608, 3);
            this.btnExportToBdf.Name = "btnExportToBdf";
            this.btnExportToBdf.Size = new System.Drawing.Size(148, 33);
            this.btnExportToBdf.TabIndex = 2;
            this.btnExportToBdf.Text = "Export To Bdf";
            this.btnExportToBdf.Click += new System.EventHandler(this.btnExportToBdf_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(176, 9);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(148, 26);
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "Get Invoice Data";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btn_getDataFromExcel
            // 
            this.btn_getDataFromExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_getDataFromExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_getDataFromExcel.Location = new System.Drawing.Point(9, 9);
            this.btn_getDataFromExcel.Name = "btn_getDataFromExcel";
            this.btn_getDataFromExcel.Size = new System.Drawing.Size(148, 26);
            this.btn_getDataFromExcel.TabIndex = 0;
            this.btn_getDataFromExcel.Text = "Get Data From Excel";
            this.btn_getDataFromExcel.Click += new System.EventHandler(this.btn_getDataFromExcel_Click);
            // 
            // dgv_Inv
            // 
            this.dgv_Inv.AllowUserToAddRows = false;
            this.dgv_Inv.AllowUserToDeleteRows = false;
            this.dgv_Inv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Inv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Inv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colSer,
            this._colBranch,
            this._colBranchName,
            this._colYear,
            this._colTransaction,
            this._colTransactionName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Inv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Inv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Inv.Location = new System.Drawing.Point(0, 53);
            this.dgv_Inv.Name = "dgv_Inv";
            this.dgv_Inv.ReadOnly = true;
            this.dgv_Inv.RowHeadersVisible = false;
            this.dgv_Inv.RowHeadersWidth = 51;
            this.dgv_Inv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Inv.Size = new System.Drawing.Size(1370, 469);
            this.dgv_Inv.TabIndex = 300;
            this.dgv_Inv.DoubleClick += new System.EventHandler(this.dgv_Inv_DoubleClick);
            // 
            // _colSer
            // 
            this._colSer.HeaderText = "الرقم";
            this._colSer.Name = "_colSer";
            this._colSer.ReadOnly = true;
            this._colSer.Width = 60;
            // 
            // _colBranch
            // 
            this._colBranch.HeaderText = "كود الفرع";
            this._colBranch.Name = "_colBranch";
            this._colBranch.ReadOnly = true;
            // 
            // _colBranchName
            // 
            this._colBranchName.HeaderText = "الفرع";
            this._colBranchName.Name = "_colBranchName";
            this._colBranchName.ReadOnly = true;
            this._colBranchName.Width = 180;
            // 
            // _colYear
            // 
            this._colYear.HeaderText = "السنة";
            this._colYear.Name = "_colYear";
            this._colYear.ReadOnly = true;
            // 
            // _colTransaction
            // 
            this._colTransaction.HeaderText = "كود الحركة";
            this._colTransaction.Name = "_colTransaction";
            this._colTransaction.ReadOnly = true;
            // 
            // _colTransactionName
            // 
            this._colTransactionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._colTransactionName.HeaderText = "الحركة";
            this._colTransactionName.Name = "_colTransactionName";
            this._colTransactionName.ReadOnly = true;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._serNo,
            this._branch,
            this._branchName,
            this._year,
            this._transaction,
            this._transactionName,
            this._po});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv1.Location = new System.Drawing.Point(0, 53);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1370, 469);
            this.dgv1.TabIndex = 301;
            this.dgv1.Visible = false;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // _serNo
            // 
            this._serNo.HeaderText = "الرقم";
            this._serNo.Name = "_serNo";
            this._serNo.ReadOnly = true;
            // 
            // _branch
            // 
            this._branch.HeaderText = "كود الفرع";
            this._branch.Name = "_branch";
            this._branch.ReadOnly = true;
            // 
            // _branchName
            // 
            this._branchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._branchName.HeaderText = "الفرع";
            this._branchName.Name = "_branchName";
            this._branchName.ReadOnly = true;
            // 
            // _year
            // 
            this._year.HeaderText = "السنة";
            this._year.Name = "_year";
            this._year.ReadOnly = true;
            // 
            // _transaction
            // 
            this._transaction.HeaderText = "كود الحركة";
            this._transaction.Name = "_transaction";
            this._transaction.ReadOnly = true;
            // 
            // _transactionName
            // 
            this._transactionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._transactionName.HeaderText = "الحركة";
            this._transactionName.Name = "_transactionName";
            this._transactionName.ReadOnly = true;
            // 
            // _po
            // 
            this._po.HeaderText = "طلب الشراء";
            this._po.Name = "_po";
            this._po.ReadOnly = true;
            // 
            // frm_samples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 522);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.dgv_Inv);
            this.Controls.Add(this.groupPanel1);
            this.Name = "frm_samples";
            this.Text = "frm_samples";
            this.Load += new System.EventHandler(this.frm_samples_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_getDataFromExcel;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Inv;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _serNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn _branchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _year;
        private System.Windows.Forms.DataGridViewTextBoxColumn _transaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn _transactionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _po;
        private DevComponents.DotNetBar.ButtonX btnExportToBdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colSer;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colBranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colTransactionName;
    }
}