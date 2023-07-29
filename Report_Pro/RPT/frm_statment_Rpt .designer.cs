namespace Report_Pro.RPT
{
    partial class frm_statment_Rpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_statment_Rpt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.Project = new Report_Pro.MyControls.UC_Project();
            this.button1 = new System.Windows.Forms.Button();
            this.minimumDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo_Main = new System.Windows.Forms.RadioButton();
            this.rdo_Sub = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_All = new System.Windows.Forms.RadioButton();
            this.rdo_Due = new System.Windows.Forms.RadioButton();
            this.rdo_NonPaid = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UC_Acc1 = new Report_Pro.MyControls.UC_Acc();
            this.UC_Branch = new Report_Pro.MyControls.UC_AccBranch();
            this.UC_Catogry1 = new Report_Pro.MyControls.UC_Catogry();
            this.UC_cost1 = new Report_Pro.MyControls.UC_cost();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.chB_1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgv = new System.Windows.Forms.DataGridView();
            this._date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._costCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._accNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._accName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // headLbl
            // 
            resources.ApplyResources(this.headLbl, "headLbl");
            // 
            // crystalReportViewer1
            // 
            resources.ApplyResources(this.crystalReportViewer1, "crystalReportViewer1");
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // groupPanel1
            // 
            resources.ApplyResources(this.groupPanel1, "groupPanel1");
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.Project);
            this.groupPanel1.Controls.Add(this.button1);
            this.groupPanel1.Controls.Add(this.minimumDate);
            this.groupPanel1.Controls.Add(this.groupBox2);
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.UC_Acc1);
            this.groupPanel1.Controls.Add(this.UC_Branch);
            this.groupPanel1.Controls.Add(this.UC_Catogry1);
            this.groupPanel1.Controls.Add(this.UC_cost1);
            this.groupPanel1.Controls.Add(this.ToDate);
            this.groupPanel1.Controls.Add(this.FromDate);
            this.groupPanel1.Controls.Add(this.chB_1);
            this.groupPanel1.Name = "groupPanel1";
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
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
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Name = "label7";
            // 
            // Project
            // 
            resources.ApplyResources(this.Project, "Project");
            this.Project.Name = "Project";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // minimumDate
            // 
            resources.ApplyResources(this.minimumDate, "minimumDate");
            this.minimumDate.Name = "minimumDate";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.rdo_Main);
            this.groupBox2.Controls.Add(this.rdo_Sub);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rdo_Main
            // 
            resources.ApplyResources(this.rdo_Main, "rdo_Main");
            this.rdo_Main.BackColor = System.Drawing.Color.Transparent;
            this.rdo_Main.Name = "rdo_Main";
            this.rdo_Main.UseVisualStyleBackColor = false;
            // 
            // rdo_Sub
            // 
            resources.ApplyResources(this.rdo_Sub, "rdo_Sub");
            this.rdo_Sub.BackColor = System.Drawing.Color.Transparent;
            this.rdo_Sub.Checked = true;
            this.rdo_Sub.Name = "rdo_Sub";
            this.rdo_Sub.TabStop = true;
            this.rdo_Sub.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rdo_All);
            this.groupBox1.Controls.Add(this.rdo_Due);
            this.groupBox1.Controls.Add(this.rdo_NonPaid);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdo_All
            // 
            resources.ApplyResources(this.rdo_All, "rdo_All");
            this.rdo_All.BackColor = System.Drawing.Color.Transparent;
            this.rdo_All.Checked = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.TabStop = true;
            this.rdo_All.UseVisualStyleBackColor = false;
            // 
            // rdo_Due
            // 
            resources.ApplyResources(this.rdo_Due, "rdo_Due");
            this.rdo_Due.BackColor = System.Drawing.Color.Transparent;
            this.rdo_Due.Name = "rdo_Due";
            this.rdo_Due.UseVisualStyleBackColor = false;
            // 
            // rdo_NonPaid
            // 
            resources.ApplyResources(this.rdo_NonPaid, "rdo_NonPaid");
            this.rdo_NonPaid.BackColor = System.Drawing.Color.Transparent;
            this.rdo_NonPaid.Name = "rdo_NonPaid";
            this.rdo_NonPaid.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            // 
            // UC_Acc1
            // 
            resources.ApplyResources(this.UC_Acc1, "UC_Acc1");
            this.UC_Acc1.BackColor = System.Drawing.Color.Transparent;
            this.UC_Acc1.Name = "UC_Acc1";
            // 
            // UC_Branch
            // 
            resources.ApplyResources(this.UC_Branch, "UC_Branch");
            this.UC_Branch.Name = "UC_Branch";
            this.UC_Branch.Load += new System.EventHandler(this.UC_Branch_Load);
            // 
            // UC_Catogry1
            // 
            resources.ApplyResources(this.UC_Catogry1, "UC_Catogry1");
            this.UC_Catogry1.Name = "UC_Catogry1";
            // 
            // UC_cost1
            // 
            resources.ApplyResources(this.UC_cost1, "UC_cost1");
            this.UC_cost1.Name = "UC_cost1";
            // 
            // ToDate
            // 
            resources.ApplyResources(this.ToDate, "ToDate");
            this.ToDate.Name = "ToDate";
            // 
            // FromDate
            // 
            resources.ApplyResources(this.FromDate, "FromDate");
            this.FromDate.Name = "FromDate";
            this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
            // 
            // chB_1
            // 
            resources.ApplyResources(this.chB_1, "chB_1");
            this.chB_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chB_1.Name = "chB_1";
            this.chB_1.CheckedChanged += new System.EventHandler(this.chB_1_CheckedChanged);
            // 
            // dgv
            // 
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._date,
            this._ser,
            this._description,
            this._debit,
            this._credit,
            this._balance,
            this._branchCode,
            this._branch,
            this._costCode,
            this._cost,
            this._classCode,
            this._class,
            this._accNo,
            this._accName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // _date
            // 
            this._date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._date.FillWeight = 7F;
            this._date.Frozen = true;
            resources.ApplyResources(this._date, "_date");
            this._date.Name = "_date";
            this._date.ReadOnly = true;
            // 
            // _ser
            // 
            this._ser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._ser.FillWeight = 6F;
            this._ser.Frozen = true;
            resources.ApplyResources(this._ser, "_ser");
            this._ser.Name = "_ser";
            this._ser.ReadOnly = true;
            // 
            // _description
            // 
            this._description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._description.FillWeight = 23F;
            this._description.Frozen = true;
            resources.ApplyResources(this._description, "_description");
            this._description.Name = "_description";
            this._description.ReadOnly = true;
            // 
            // _debit
            // 
            this._debit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._debit.FillWeight = 7F;
            this._debit.Frozen = true;
            resources.ApplyResources(this._debit, "_debit");
            this._debit.Name = "_debit";
            this._debit.ReadOnly = true;
            // 
            // _credit
            // 
            this._credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._credit.FillWeight = 7F;
            this._credit.Frozen = true;
            resources.ApplyResources(this._credit, "_credit");
            this._credit.Name = "_credit";
            this._credit.ReadOnly = true;
            // 
            // _balance
            // 
            this._balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._balance.FillWeight = 7F;
            this._balance.Frozen = true;
            resources.ApplyResources(this._balance, "_balance");
            this._balance.Name = "_balance";
            this._balance.ReadOnly = true;
            // 
            // _branchCode
            // 
            this._branchCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._branchCode.FillWeight = 6F;
            this._branchCode.Frozen = true;
            resources.ApplyResources(this._branchCode, "_branchCode");
            this._branchCode.Name = "_branchCode";
            this._branchCode.ReadOnly = true;
            // 
            // _branch
            // 
            this._branch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._branch.FillWeight = 9F;
            this._branch.Frozen = true;
            resources.ApplyResources(this._branch, "_branch");
            this._branch.Name = "_branch";
            this._branch.ReadOnly = true;
            // 
            // _costCode
            // 
            this._costCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._costCode.FillWeight = 4F;
            this._costCode.Frozen = true;
            resources.ApplyResources(this._costCode, "_costCode");
            this._costCode.Name = "_costCode";
            this._costCode.ReadOnly = true;
            // 
            // _cost
            // 
            this._cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._cost.FillWeight = 10F;
            this._cost.Frozen = true;
            resources.ApplyResources(this._cost, "_cost");
            this._cost.Name = "_cost";
            this._cost.ReadOnly = true;
            // 
            // _classCode
            // 
            this._classCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._classCode.FillWeight = 4F;
            this._classCode.Frozen = true;
            resources.ApplyResources(this._classCode, "_classCode");
            this._classCode.Name = "_classCode";
            this._classCode.ReadOnly = true;
            // 
            // _class
            // 
            this._class.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._class.FillWeight = 10F;
            this._class.Frozen = true;
            resources.ApplyResources(this._class, "_class");
            this._class.Name = "_class";
            this._class.ReadOnly = true;
            // 
            // _accNo
            // 
            this._accNo.Frozen = true;
            resources.ApplyResources(this._accNo, "_accNo");
            this._accNo.Name = "_accNo";
            this._accNo.ReadOnly = true;
            // 
            // _accName
            // 
            this._accName.Frozen = true;
            resources.ApplyResources(this._accName, "_accName");
            this._accName.Name = "_accName";
            this._accName.ReadOnly = true;
            // 
            // frm_statment_Rpt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_statment_Rpt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_statment_Rpt_Load);
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.groupPanel1, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.groupPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private MyControls.UC_cost uC_cost;
        public MyControls.UC_Acc UC_Acc;
        private MyControls.UC_Branch uC_Branch1;
        private MyControls.UC_Catogry uC_Catogry;
        private MyControls.UC_AccBranch UC_Branch;
        public System.Windows.Forms.DateTimePicker FromDate;
        public System.Windows.Forms.DateTimePicker ToDate;
        public MyControls.UC_Acc UC_Acc1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.CheckBoxX chB_1;
        public MyControls.UC_Catogry UC_Catogry1;
        public MyControls.UC_cost UC_cost1;
        private System.Windows.Forms.RadioButton rdo_Due;
        private System.Windows.Forms.RadioButton rdo_NonPaid;
        private System.Windows.Forms.RadioButton rdo_All;
        private System.Windows.Forms.RadioButton rdo_Main;
        private System.Windows.Forms.RadioButton rdo_Sub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.DateTimePicker minimumDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _date;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ser;
        private System.Windows.Forms.DataGridViewTextBoxColumn _description;
        private System.Windows.Forms.DataGridViewTextBoxColumn _debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn _branchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn _costCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn _class;
        private System.Windows.Forms.DataGridViewTextBoxColumn _accNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _accName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private MyControls.UC_Project Project;
    }
}