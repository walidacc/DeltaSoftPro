namespace Report_Pro.MyControls
{
    partial class UC_KM_Sales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btn1 = new DevComponents.DotNetBar.ButtonX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ID = new System.Windows.Forms.TextBox();
            this.Desc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv1.Location = new System.Drawing.Point(0, 20);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.Size = new System.Drawing.Size(476, 140);
            this.dgv1.TabIndex = 20;
            this.dgv1.Visible = false;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // btn1
            // 
            this.btn1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn1.Image = global::Report_Pro.Properties.Resources.search_16;
            this.btn1.Location = new System.Drawing.Point(80, 0);
            this.btn1.Margin = new System.Windows.Forms.Padding(0);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(30, 20);
            this.btn1.TabIndex = 18;
            this.btn1.Click += new System.EventHandler(this.btn1_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Desc, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 20);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // ID
            // 
            this.ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID.Location = new System.Drawing.Point(0, 0);
            this.ID.Margin = new System.Windows.Forms.Padding(0);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(80, 20);
            this.ID.TabIndex = 0;
            this.ID.TextChanged += new System.EventHandler(this.ID_TextChanged);
            this.ID.Enter += new System.EventHandler(this.ID_Enter);
            this.ID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ID_KeyUp);
            // 
            // Desc
            // 
            this.Desc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Desc.Location = new System.Drawing.Point(110, 0);
            this.Desc.Margin = new System.Windows.Forms.Padding(0);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(366, 20);
            this.Desc.TabIndex = 1;
            this.Desc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Desc_KeyUp);
            // 
            // UC_KM_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_KM_Sales";
            this.Size = new System.Drawing.Size(476, 20);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv1;
        private DevComponents.DotNetBar.ButtonX btn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox ID;
        public System.Windows.Forms.TextBox Desc;
    }
}
