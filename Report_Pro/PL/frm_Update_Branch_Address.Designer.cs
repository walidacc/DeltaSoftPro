namespace Report_Pro.PL
{
    partial class frm_Update_Branch_Address
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtAddress_E = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtStore = new Report_Pro.MyControls.UC_Branch();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(143, 70);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(345, 53);
            this.txtAddress.TabIndex = 0;
            // 
            // txtAddress_E
            // 
            this.txtAddress_E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress_E.Location = new System.Drawing.Point(143, 129);
            this.txtAddress_E.Multiline = true;
            this.txtAddress_E.Name = "txtAddress_E";
            this.txtAddress_E.Size = new System.Drawing.Size(345, 53);
            this.txtAddress_E.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(59, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Store";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(59, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Arabic Address";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(59, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "English Address";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(387, 234);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtStore
            // 
            this.txtStore.BackColor = System.Drawing.Color.Transparent;
            this.txtStore.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtStore.Location = new System.Drawing.Point(143, 42);
            this.txtStore.Margin = new System.Windows.Forms.Padding(0);
            this.txtStore.Name = "txtStore";
            this.txtStore.Size = new System.Drawing.Size(345, 20);
            this.txtStore.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(143, 189);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(246, 20);
            this.txtPhone.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(59, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phone No";
            // 
            // frm_Update_Branch_Address
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 312);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtStore);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddress_E);
            this.Controls.Add(this.txtAddress);
            this.Name = "frm_Update_Branch_Address";
            this.Text = "frm_Update_Branch_Address";
            this.Load += new System.EventHandler(this.frm_Update_Branch_Address_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtAddress_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private MyControls.UC_Branch txtStore;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
    }
}