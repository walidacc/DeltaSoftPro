﻿namespace Report_Pro.RPT
{
    partial class frm_rpt_InventoryItems
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpt_InventoryItems));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totSalesWeight = new System.Windows.Forms.Label();
            this.dataGridView1 = new ADGV.AdvancedDataGridView();
            this.totMonthelySalesWeight = new System.Windows.Forms.Label();
            this.Item = new Report_Pro.MyControls.UC_Items();
            this.totBalance = new System.Windows.Forms.Label();
            this.thick_2 = new Report_Pro.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totBalanceWeight = new System.Windows.Forms.Label();
            this.thick_1 = new Report_Pro.NumericTextBox();
            this.totSales = new System.Windows.Forms.Label();
            this.dTP2 = new System.Windows.Forms.DateTimePicker();
            this.totMonthelySales = new System.Windows.Forms.Label();
            this.dTP1 = new System.Windows.Forms.DateTimePicker();
            this.totBalancePeriod = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chC = new System.Windows.Forms.CheckBox();
            this.chS = new System.Windows.Forms.CheckBox();
            this.chX = new System.Windows.Forms.CheckBox();
            this.chR = new System.Windows.Forms.CheckBox();
            this.chZ = new System.Windows.Forms.CheckBox();
            this.chP = new System.Windows.Forms.CheckBox();
            this.chF = new System.Windows.Forms.CheckBox();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.Group1 = new Report_Pro.MyControls.Uc_Group();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.Uc_Transaction = new Report_Pro.MyControls.UC_Transaction();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.Branch = new Report_Pro.MyControls.UC_Branch();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.Group = new Report_Pro.MyControls.Uc_Group();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmb_DimCategory = new System.Windows.Forms.ComboBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1424, 49);
            this.panel1.TabIndex = 0;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_print.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_print.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_print.Image = global::Report_Pro.Properties.Resources.printer_icon;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_print.Location = new System.Drawing.Point(237, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(104, 37);
            this.btn_print.TabIndex = 119;
            this.btn_print.Text = "Print";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReport.Image = global::Report_Pro.Properties.Resources.Reports2;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReport.Location = new System.Drawing.Point(125, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(104, 37);
            this.btnReport.TabIndex = 117;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnOption
            // 
            this.btnOption.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOption.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOption.ForeColor = System.Drawing.Color.White;
            this.btnOption.Image = global::Report_Pro.Properties.Resources.choose;
            this.btnOption.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOption.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOption.Location = new System.Drawing.Point(13, 4);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(104, 37);
            this.btnOption.TabIndex = 118;
            this.btnOption.Text = "Option";
            this.btnOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOption.UseVisualStyleBackColor = false;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.groupBox1.Controls.Add(this.totSalesWeight);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.totMonthelySalesWeight);
            this.groupBox1.Controls.Add(this.Item);
            this.groupBox1.Controls.Add(this.totBalance);
            this.groupBox1.Controls.Add(this.thick_2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.totBalanceWeight);
            this.groupBox1.Controls.Add(this.thick_1);
            this.groupBox1.Controls.Add(this.totSales);
            this.groupBox1.Controls.Add(this.dTP2);
            this.groupBox1.Controls.Add(this.totMonthelySales);
            this.groupBox1.Controls.Add(this.dTP1);
            this.groupBox1.Controls.Add(this.totBalancePeriod);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelX10);
            this.groupBox1.Controls.Add(this.Group1);
            this.groupBox1.Controls.Add(this.labelX9);
            this.groupBox1.Controls.Add(this.Uc_Transaction);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.labelX8);
            this.groupBox1.Controls.Add(this.labelX7);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Controls.Add(this.Branch);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.Group);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.cmb_DimCategory);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1424, 834);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // totSalesWeight
            // 
            this.totSalesWeight.BackColor = System.Drawing.SystemColors.Highlight;
            this.totSalesWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totSalesWeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totSalesWeight.ForeColor = System.Drawing.SystemColors.Window;
            this.totSalesWeight.Location = new System.Drawing.Point(854, 794);
            this.totSalesWeight.Name = "totSalesWeight";
            this.totSalesWeight.Size = new System.Drawing.Size(150, 30);
            this.totSalesWeight.TabIndex = 8;
            this.totSalesWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateContextFilters = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.DateWithTime = false;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(1, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.ForestGreen;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1423, 603);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.TimeFilter = false;
            this.dataGridView1.SortStringChanged += new System.EventHandler(this.dataGridView1_SortStringChanged);
            this.dataGridView1.FilterStringChanged += new System.EventHandler(this.dataGridView1_FilterStringChanged);
            this.dataGridView1.BindingContextChanged += new System.EventHandler(this.dataGridView1_BindingContextChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // totMonthelySalesWeight
            // 
            this.totMonthelySalesWeight.BackColor = System.Drawing.SystemColors.Highlight;
            this.totMonthelySalesWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totMonthelySalesWeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totMonthelySalesWeight.ForeColor = System.Drawing.SystemColors.Window;
            this.totMonthelySalesWeight.Location = new System.Drawing.Point(1154, 794);
            this.totMonthelySalesWeight.Name = "totMonthelySalesWeight";
            this.totMonthelySalesWeight.Size = new System.Drawing.Size(150, 30);
            this.totMonthelySalesWeight.TabIndex = 7;
            this.totMonthelySalesWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Item
            // 
            this.Item.Location = new System.Drawing.Point(554, 18);
            this.Item.Margin = new System.Windows.Forms.Padding(0);
            this.Item.MaximumSize = new System.Drawing.Size(1000, 800);
            this.Item.MinimumSize = new System.Drawing.Size(320, 20);
            this.Item.Name = "Item";
            this.Item.Size = new System.Drawing.Size(321, 20);
            this.Item.TabIndex = 60;
            // 
            // totBalance
            // 
            this.totBalance.BackColor = System.Drawing.SystemColors.Highlight;
            this.totBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totBalance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totBalance.ForeColor = System.Drawing.SystemColors.Window;
            this.totBalance.Location = new System.Drawing.Point(404, 794);
            this.totBalance.Name = "totBalance";
            this.totBalance.Size = new System.Drawing.Size(150, 30);
            this.totBalance.TabIndex = 6;
            this.totBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thick_2
            // 
            this.thick_2.decimaldigit = 2;
            this.thick_2.Location = new System.Drawing.Point(370, 100);
            this.thick_2.Name = "thick_2";
            this.thick_2.Size = new System.Drawing.Size(64, 20);
            this.thick_2.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 794);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totBalanceWeight
            // 
            this.totBalanceWeight.BackColor = System.Drawing.SystemColors.Highlight;
            this.totBalanceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totBalanceWeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totBalanceWeight.ForeColor = System.Drawing.SystemColors.Window;
            this.totBalanceWeight.Location = new System.Drawing.Point(554, 794);
            this.totBalanceWeight.Name = "totBalanceWeight";
            this.totBalanceWeight.Size = new System.Drawing.Size(150, 30);
            this.totBalanceWeight.TabIndex = 4;
            this.totBalanceWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thick_1
            // 
            this.thick_1.decimaldigit = 2;
            this.thick_1.Location = new System.Drawing.Point(113, 100);
            this.thick_1.Name = "thick_1";
            this.thick_1.Size = new System.Drawing.Size(64, 20);
            this.thick_1.TabIndex = 90;
            this.thick_1.TextChanged += new System.EventHandler(this.thick_1_TextChanged);
            // 
            // totSales
            // 
            this.totSales.BackColor = System.Drawing.SystemColors.Highlight;
            this.totSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totSales.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totSales.ForeColor = System.Drawing.SystemColors.Window;
            this.totSales.Location = new System.Drawing.Point(704, 794);
            this.totSales.Name = "totSales";
            this.totSales.Size = new System.Drawing.Size(150, 30);
            this.totSales.TabIndex = 4;
            this.totSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dTP2
            // 
            this.dTP2.Location = new System.Drawing.Point(322, 126);
            this.dTP2.Name = "dTP2";
            this.dTP2.Size = new System.Drawing.Size(112, 20);
            this.dTP2.TabIndex = 87;
            // 
            // totMonthelySales
            // 
            this.totMonthelySales.BackColor = System.Drawing.SystemColors.Highlight;
            this.totMonthelySales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totMonthelySales.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totMonthelySales.ForeColor = System.Drawing.SystemColors.Window;
            this.totMonthelySales.Location = new System.Drawing.Point(1004, 794);
            this.totMonthelySales.Name = "totMonthelySales";
            this.totMonthelySales.Size = new System.Drawing.Size(150, 30);
            this.totMonthelySales.TabIndex = 4;
            this.totMonthelySales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dTP1
            // 
            this.dTP1.Location = new System.Drawing.Point(113, 126);
            this.dTP1.Name = "dTP1";
            this.dTP1.Size = new System.Drawing.Size(112, 20);
            this.dTP1.TabIndex = 86;
            // 
            // totBalancePeriod
            // 
            this.totBalancePeriod.BackColor = System.Drawing.SystemColors.Highlight;
            this.totBalancePeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totBalancePeriod.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totBalancePeriod.ForeColor = System.Drawing.SystemColors.Window;
            this.totBalancePeriod.Location = new System.Drawing.Point(1304, 794);
            this.totBalancePeriod.Name = "totBalancePeriod";
            this.totBalancePeriod.Size = new System.Drawing.Size(110, 30);
            this.totBalancePeriod.TabIndex = 4;
            this.totBalancePeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chC);
            this.groupBox2.Controls.Add(this.chS);
            this.groupBox2.Controls.Add(this.chX);
            this.groupBox2.Controls.Add(this.chR);
            this.groupBox2.Controls.Add(this.chZ);
            this.groupBox2.Controls.Add(this.chP);
            this.groupBox2.Controls.Add(this.chF);
            this.groupBox2.Location = new System.Drawing.Point(554, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 79);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Classification";
            // 
            // chC
            // 
            this.chC.AutoSize = true;
            this.chC.Checked = true;
            this.chC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chC.Location = new System.Drawing.Point(15, 28);
            this.chC.Name = "chC";
            this.chC.Size = new System.Drawing.Size(80, 17);
            this.chC.TabIndex = 78;
            this.chC.Text = "Commercial";
            this.chC.UseVisualStyleBackColor = true;
            this.chC.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chS
            // 
            this.chS.AutoSize = true;
            this.chS.Checked = true;
            this.chS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chS.Location = new System.Drawing.Point(266, 28);
            this.chS.Name = "chS";
            this.chS.Size = new System.Drawing.Size(46, 17);
            this.chS.TabIndex = 83;
            this.chS.Text = "WIP";
            this.chS.UseVisualStyleBackColor = true;
            // 
            // chX
            // 
            this.chX.AutoSize = true;
            this.chX.Checked = true;
            this.chX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chX.Location = new System.Drawing.Point(15, 52);
            this.chX.Name = "chX";
            this.chX.Size = new System.Drawing.Size(59, 17);
            this.chX.TabIndex = 84;
            this.chX.Text = "Secrap";
            this.chX.UseVisualStyleBackColor = true;
            // 
            // chR
            // 
            this.chR.AutoSize = true;
            this.chR.Checked = true;
            this.chR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chR.Location = new System.Drawing.Point(196, 28);
            this.chR.Name = "chR";
            this.chR.Size = new System.Drawing.Size(47, 17);
            this.chR.TabIndex = 82;
            this.chR.Text = "Raw";
            this.chR.UseVisualStyleBackColor = true;
            // 
            // chZ
            // 
            this.chZ.AutoSize = true;
            this.chZ.Checked = true;
            this.chZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chZ.Location = new System.Drawing.Point(112, 52);
            this.chZ.Name = "chZ";
            this.chZ.Size = new System.Drawing.Size(59, 17);
            this.chZ.TabIndex = 79;
            this.chZ.Text = "Others";
            this.chZ.UseVisualStyleBackColor = true;
            // 
            // chP
            // 
            this.chP.AutoSize = true;
            this.chP.Checked = true;
            this.chP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chP.Location = new System.Drawing.Point(196, 52);
            this.chP.Name = "chP";
            this.chP.Size = new System.Drawing.Size(64, 17);
            this.chP.TabIndex = 81;
            this.chP.Text = "S. Parts";
            this.chP.UseVisualStyleBackColor = true;
            // 
            // chF
            // 
            this.chF.AutoSize = true;
            this.chF.Checked = true;
            this.chF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chF.Location = new System.Drawing.Point(112, 28);
            this.chF.Name = "chF";
            this.chF.Size = new System.Drawing.Size(63, 17);
            this.chF.TabIndex = 80;
            this.chF.Text = "Finshed";
            this.chF.UseVisualStyleBackColor = true;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            this.labelX10.Location = new System.Drawing.Point(53, 72);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(51, 17);
            this.labelX10.TabIndex = 77;
            this.labelX10.Text = "To Group";
            // 
            // Group1
            // 
            this.Group1.Location = new System.Drawing.Point(113, 72);
            this.Group1.Margin = new System.Windows.Forms.Padding(0);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(321, 20);
            this.Group1.TabIndex = 76;
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            this.labelX9.Location = new System.Drawing.Point(483, 44);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(62, 17);
            this.labelX9.TabIndex = 75;
            this.labelX9.Text = "Transaction";
            // 
            // Uc_Transaction
            // 
            this.Uc_Transaction.Location = new System.Drawing.Point(554, 46);
            this.Uc_Transaction.Margin = new System.Windows.Forms.Padding(0);
            this.Uc_Transaction.Name = "Uc_Transaction";
            this.Uc_Transaction.Size = new System.Drawing.Size(321, 20);
            this.Uc_Transaction.TabIndex = 74;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(48, 128);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(57, 17);
            this.labelX1.TabIndex = 73;
            this.labelX1.Text = "From Date";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            this.labelX8.Location = new System.Drawing.Point(295, 102);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(69, 17);
            this.labelX8.TabIndex = 70;
            this.labelX8.Text = "To Thickness";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            this.labelX7.Location = new System.Drawing.Point(22, 102);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(82, 17);
            this.labelX7.TabIndex = 69;
            this.labelX7.Text = "From Thickness";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Location = new System.Drawing.Point(64, 18);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(40, 17);
            this.labelX6.TabIndex = 66;
            this.labelX6.Text = "Branch";
            // 
            // Branch
            // 
            this.Branch.BackColor = System.Drawing.Color.Transparent;
            this.Branch.Cursor = System.Windows.Forms.Cursors.Default;
            this.Branch.Location = new System.Drawing.Point(113, 16);
            this.Branch.Margin = new System.Windows.Forms.Padding(0);
            this.Branch.Name = "Branch";
            this.Branch.Size = new System.Drawing.Size(321, 20);
            this.Branch.TabIndex = 65;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(516, 17);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(29, 17);
            this.labelX3.TabIndex = 62;
            this.labelX3.Text = "Item";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(40, 45);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(64, 17);
            this.labelX2.TabIndex = 61;
            this.labelX2.Text = "From Group";
            // 
            // Group
            // 
            this.Group.Location = new System.Drawing.Point(113, 44);
            this.Group.Margin = new System.Windows.Forms.Padding(0);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(321, 20);
            this.Group.TabIndex = 59;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(468, 71);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(77, 17);
            this.labelX5.TabIndex = 64;
            this.labelX5.Text = "Materials Type";
            // 
            // cmb_DimCategory
            // 
            this.cmb_DimCategory.FormattingEnabled = true;
            this.cmb_DimCategory.Location = new System.Drawing.Point(554, 73);
            this.cmb_DimCategory.Name = "cmb_DimCategory";
            this.cmb_DimCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_DimCategory.Size = new System.Drawing.Size(321, 21);
            this.cmb_DimCategory.TabIndex = 63;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(269, 128);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(45, 17);
            this.labelX4.TabIndex = 58;
            this.labelX4.Text = "To Date";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frm_rpt_InventoryItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 881);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_rpt_InventoryItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.rpt_InventoryBranches_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totBalanceWeight;
        private System.Windows.Forms.Label totSales;
        private System.Windows.Forms.Label totMonthelySales;
        private System.Windows.Forms.Label totBalancePeriod;
        private System.Windows.Forms.Button btn_print;
        public MyControls.Uc_Group Group1;
        public MyControls.UC_Transaction Uc_Transaction;
        public MyControls.UC_Branch Branch;
        public MyControls.UC_Items Item;
        public MyControls.Uc_Group Group;
        public System.Windows.Forms.ComboBox cmb_DimCategory;
        public System.Windows.Forms.CheckBox chC;
        public System.Windows.Forms.CheckBox chS;
        public System.Windows.Forms.CheckBox chX;
        public System.Windows.Forms.CheckBox chR;
        public System.Windows.Forms.CheckBox chZ;
        public System.Windows.Forms.CheckBox chP;
        public System.Windows.Forms.CheckBox chF;
        public System.Windows.Forms.DateTimePicker dTP2;
        public System.Windows.Forms.DateTimePicker dTP1;
        public NumericTextBox thick_2;
        public NumericTextBox thick_1;
        private ADGV.AdvancedDataGridView dataGridView1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label totBalance;
        private System.Windows.Forms.Label totSalesWeight;
        private System.Windows.Forms.Label totMonthelySalesWeight;
    }
}