namespace Report_Pro.PL
{
    partial class frm_Update_invoiceData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Update_invoiceData));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.invDate = new System.Windows.Forms.DateTimePicker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.invNo = new System.Windows.Forms.TextBox();
            this.txt_inv_no = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_VatNo = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Supp = new System.Windows.Forms.TextBox();
            this.G_date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.acc_ser = new System.Windows.Forms.TextBox();
            this.txtTransaction = new Report_Pro.MyControls.UC_Transaction();
            this.txtBranch = new Report_Pro.MyControls.UC_Branch();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Name = "label2";
            // 
            // invDate
            // 
            resources.ApplyResources(this.invDate, "invDate");
            this.invDate.Name = "invDate";
            this.invDate.ValueChanged += new System.EventHandler(this.invDate_ValueChanged);
            this.invDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_custom_date_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // invNo
            // 
            resources.ApplyResources(this.invNo, "invNo");
            this.invNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.invNo.Name = "invNo";
            this.invNo.TextChanged += new System.EventHandler(this.invNo_TextChanged);
            this.invNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_custom_no_KeyDown);
            // 
            // txt_inv_no
            // 
            resources.ApplyResources(this.txt_inv_no, "txt_inv_no");
            this.txt_inv_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_inv_no.Name = "txt_inv_no";
            this.txt_inv_no.TextChanged += new System.EventHandler(this.txt_inv_no_TextChanged);
            this.txt_inv_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_inv_no_KeyDown);
            this.txt_inv_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_inv_no_KeyUp);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Name = "label6";
            // 
            // btn_save
            // 
            resources.ApplyResources(this.btn_save, "btn_save");
            this.btn_save.Name = "btn_save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            resources.ApplyResources(this.btn_cancel, "btn_cancel");
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Name = "label8";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Name = "label9";
            // 
            // txt_VatNo
            // 
            resources.ApplyResources(this.txt_VatNo, "txt_VatNo");
            this.txt_VatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_VatNo.Name = "txt_VatNo";
            this.txt_VatNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Name = "label7";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txt_Supp
            // 
            resources.ApplyResources(this.txt_Supp, "txt_Supp");
            this.txt_Supp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Supp.Name = "txt_Supp";
            // 
            // G_date
            // 
            resources.ApplyResources(this.G_date, "G_date");
            this.G_date.Name = "G_date";
            this.G_date.ValueChanged += new System.EventHandler(this.new_G_date_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // acc_ser
            // 
            resources.ApplyResources(this.acc_ser, "acc_ser");
            this.acc_ser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.acc_ser.Name = "acc_ser";
            // 
            // txtTransaction
            // 
            resources.ApplyResources(this.txtTransaction, "txtTransaction");
            this.txtTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransaction.Name = "txtTransaction";
            // 
            // txtBranch
            // 
            resources.ApplyResources(this.txtBranch, "txtBranch");
            this.txtBranch.BackColor = System.Drawing.Color.Transparent;
            this.txtBranch.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBranch.Name = "txtBranch";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Name = "label10";
            // 
            // frm_Update_invoiceData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTransaction);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.acc_ser);
            this.Controls.Add(this.G_date);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Supp);
            this.Controls.Add(this.txt_VatNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_inv_no);
            this.Controls.Add(this.invNo);
            this.Controls.Add(this.invDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_Update_invoiceData";
            this.Load += new System.EventHandler(this.frm_Update_custom_no_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Update_custom_no_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker invDate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox invNo;
        private System.Windows.Forms.TextBox txt_inv_no;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txt_VatNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Supp;
        private System.Windows.Forms.DateTimePicker G_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox acc_ser;
        private MyControls.UC_Branch txtBranch;
        private MyControls.UC_Transaction txtTransaction;
        private System.Windows.Forms.Label label10;
    }
}