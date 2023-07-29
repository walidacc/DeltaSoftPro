namespace Report_Pro.RPT
{
    partial class frm_statmentOfIncom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_statmentOfIncom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.Button2 = new System.Windows.Forms.Button();
            this.T_Eb = new System.Windows.Forms.TextBox();
            this.T_Cr = new System.Windows.Forms.TextBox();
            this.T_Db = new System.Windows.Forms.TextBox();
            this.T_Bb = new System.Windows.Forms.TextBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.OP = new Report_Pro.MyControls.UC_TB();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.buttonX6);
            this.panel1.Controls.Add(this.Button2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Name = "btnPrint";
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Name = "btnReport";
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            resources.ApplyResources(this.buttonX6, "buttonX6");
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // Button2
            // 
            resources.ApplyResources(this.Button2, "Button2");
            this.Button2.Name = "Button2";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // T_Eb
            // 
            resources.ApplyResources(this.T_Eb, "T_Eb");
            this.T_Eb.BackColor = System.Drawing.Color.White;
            this.T_Eb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Eb.Name = "T_Eb";
            // 
            // T_Cr
            // 
            resources.ApplyResources(this.T_Cr, "T_Cr");
            this.T_Cr.BackColor = System.Drawing.Color.White;
            this.T_Cr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Cr.Name = "T_Cr";
            // 
            // T_Db
            // 
            resources.ApplyResources(this.T_Db, "T_Db");
            this.T_Db.BackColor = System.Drawing.Color.White;
            this.T_Db.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Db.Name = "T_Db";
            // 
            // T_Bb
            // 
            resources.ApplyResources(this.T_Bb, "T_Bb");
            this.T_Bb.BackColor = System.Drawing.Color.White;
            this.T_Bb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_Bb.Name = "T_Bb";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.tableLayoutPanel1.SetColumnSpan(this.DataGridView1, 7);
            resources.ApplyResources(this.DataGridView1, "DataGridView1");
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 15F;
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 35F;
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column8
            // 
            resources.ApplyResources(this.Column8, "Column8");
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.FillWeight = 12.5F;
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0.00";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.FillWeight = 12.5F;
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0.00";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column6.FillWeight = 12.5F;
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0.00";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column7.FillWeight = 12.5F;
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            // 
            // OP
            // 
            this.OP.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.OP, "OP");
            this.OP.Name = "OP";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.T_Bb, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.T_Db, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.T_Cr, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.T_Eb, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.DataGridView1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.crystalReportViewer2, "crystalReportViewer2");
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            // 
            // frm_statmentOfIncom
            // 
            //this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            //this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.OP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_statmentOfIncom";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.OP, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer2, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        internal System.Windows.Forms.Button Button2;
        private MyControls.UC_TB OP;
        internal System.Windows.Forms.TextBox T_Eb;
        internal System.Windows.Forms.TextBox T_Cr;
        internal System.Windows.Forms.TextBox T_Db;
        internal System.Windows.Forms.TextBox T_Bb;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}