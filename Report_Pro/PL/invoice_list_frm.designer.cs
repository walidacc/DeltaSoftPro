namespace Report_Pro.PL
{
    partial class invoice_list_frm
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
            this.txtSearch2 = new System.Windows.Forms.TextBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnSrch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.dg_orders_list = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_exit = new System.Windows.Forms.Button();
            this.Btn_print = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_orders_list)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSearch2);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.btnSrch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSrch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 135);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(621, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "العميل";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(621, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "الرقم";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch2
            // 
            this.txtSearch2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch2.Location = new System.Drawing.Point(369, 64);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(253, 20);
            this.txtSearch2.TabIndex = 8;
            this.txtSearch2.TextChanged += new System.EventHandler(this.txtSearch2_TextChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(501, 90);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 7;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // btnSrch
            // 
            this.btnSrch.Image = global::Report_Pro.Properties.Resources.search_16;
            this.btnSrch.Location = new System.Drawing.Point(280, 46);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(56, 31);
            this.btnSrch.TabIndex = 5;
            this.btnSrch.UseVisualStyleBackColor = true;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ابحث هنا :";
            // 
            // txtSrch
            // 
            this.txtSrch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSrch.Location = new System.Drawing.Point(369, 38);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(253, 20);
            this.txtSrch.TabIndex = 3;
            this.txtSrch.TextChanged += new System.EventHandler(this.txtSrch_TextChanged);
            // 
            // dg_orders_list
            // 
            this.dg_orders_list.AllowUserToAddRows = false;
            this.dg_orders_list.AllowUserToDeleteRows = false;
            this.dg_orders_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_orders_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_orders_list.Location = new System.Drawing.Point(0, 0);
            this.dg_orders_list.Name = "dg_orders_list";
            this.dg_orders_list.ReadOnly = true;
            this.dg_orders_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_orders_list.Size = new System.Drawing.Size(713, 312);
            this.dg_orders_list.TabIndex = 0;
            this.dg_orders_list.DoubleClick += new System.EventHandler(this.dg_orders_list_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.Btn_exit);
            this.panel3.Controls.Add(this.Btn_print);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 46);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "الي";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "من";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(143, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(49, 20);
            this.textBox2.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Image = global::Report_Pro.Properties.Resources.printer_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(316, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 33);
            this.button1.TabIndex = 20;
            this.button1.Text = "طباعة الفواتير";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_exit
            // 
            this.Btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_exit.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.Btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_exit.Location = new System.Drawing.Point(465, 6);
            this.Btn_exit.Name = "Btn_exit";
            this.Btn_exit.Size = new System.Drawing.Size(107, 33);
            this.Btn_exit.TabIndex = 18;
            this.Btn_exit.Text = "خروج";
            this.Btn_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_exit.UseVisualStyleBackColor = true;
            this.Btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
            // 
            // Btn_print
            // 
            this.Btn_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_print.Image = global::Report_Pro.Properties.Resources.printer_icon;
            this.Btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_print.Location = new System.Drawing.Point(578, 6);
            this.Btn_print.Name = "Btn_print";
            this.Btn_print.Size = new System.Drawing.Size(107, 33);
            this.Btn_print.TabIndex = 19;
            this.Btn_print.Text = "طباعة الفاتورة";
            this.Btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_print.UseVisualStyleBackColor = true;
            this.Btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dg_orders_list);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 312);
            this.panel2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(621, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "العام";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // invoice_list_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "invoice_list_frm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ادارة المبيعات";
            this.Load += new System.EventHandler(this.order_list_frm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_orders_list)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Btn_exit;
        private System.Windows.Forms.Button Btn_print;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dg_orders_list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch2;
        private System.Windows.Forms.Label label6;
    }
}