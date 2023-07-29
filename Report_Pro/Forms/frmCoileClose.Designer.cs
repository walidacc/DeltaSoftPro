namespace Report_Pro.Forms
{
    partial class frmCoileClose
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
            this.txtHeatNo = new System.Windows.Forms.TextBox();
            this.txtMaterailID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtQtyIn = new Report_Pro.MyControls.decimalText();
            this.txtQtyOut = new Report_Pro.MyControls.decimalText();
            this.txtBalance = new Report_Pro.MyControls.decimalText();
            this.txtCloseWeight = new Report_Pro.MyControls.decimalText();
            this.txtNewBalance = new Report_Pro.MyControls.decimalText();
            this.txtItem = new Report_Pro.MyControls.UC_Items();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHeatNo
            // 
            this.txtHeatNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeatNo.Location = new System.Drawing.Point(85, 28);
            this.txtHeatNo.Name = "txtHeatNo";
            this.txtHeatNo.Size = new System.Drawing.Size(115, 20);
            this.txtHeatNo.TabIndex = 0;
            // 
            // txtMaterailID
            // 
            this.txtMaterailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterailID.Location = new System.Drawing.Point(350, 28);
            this.txtMaterailID.Name = "txtMaterailID";
            this.txtMaterailID.Size = new System.Drawing.Size(115, 20);
            this.txtMaterailID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Heat No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(277, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Material ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Qty IN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Qty Take";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(12, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Balance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(277, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Qty Close";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(277, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "New Balance";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Report_Pro.Properties.Resources.save_Icon;
            this.button1.Location = new System.Drawing.Point(326, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Update";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(194, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 32);
            this.button2.TabIndex = 15;
            this.button2.Text = "Get Coil Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtQtyIn
            // 
            this.txtQtyIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyIn.DicemalDigits = 3;
            this.txtQtyIn.Location = new System.Drawing.Point(85, 135);
            this.txtQtyIn.maxmumNumber = 0D;
            this.txtQtyIn.minimumNumber = 0D;
            this.txtQtyIn.Name = "txtQtyIn";
            this.txtQtyIn.ProgramDigits = false;
            this.txtQtyIn.Size = new System.Drawing.Size(115, 20);
            this.txtQtyIn.TabIndex = 16;
            this.txtQtyIn.Text = "0.000";
            this.txtQtyIn.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // txtQtyOut
            // 
            this.txtQtyOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyOut.DicemalDigits = 3;
            this.txtQtyOut.Location = new System.Drawing.Point(85, 161);
            this.txtQtyOut.maxmumNumber = 0D;
            this.txtQtyOut.minimumNumber = 0D;
            this.txtQtyOut.Name = "txtQtyOut";
            this.txtQtyOut.ProgramDigits = false;
            this.txtQtyOut.Size = new System.Drawing.Size(115, 20);
            this.txtQtyOut.TabIndex = 17;
            this.txtQtyOut.Text = "0.000";
            this.txtQtyOut.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // txtBalance
            // 
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.DicemalDigits = 3;
            this.txtBalance.Location = new System.Drawing.Point(85, 187);
            this.txtBalance.maxmumNumber = 0D;
            this.txtBalance.minimumNumber = 0D;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ProgramDigits = false;
            this.txtBalance.Size = new System.Drawing.Size(115, 20);
            this.txtBalance.TabIndex = 18;
            this.txtBalance.Text = "0.000";
            this.txtBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            // 
            // txtCloseWeight
            // 
            this.txtCloseWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCloseWeight.DicemalDigits = 3;
            this.txtCloseWeight.Location = new System.Drawing.Point(350, 159);
            this.txtCloseWeight.maxmumNumber = 0D;
            this.txtCloseWeight.minimumNumber = 0D;
            this.txtCloseWeight.Name = "txtCloseWeight";
            this.txtCloseWeight.ProgramDigits = false;
            this.txtCloseWeight.Size = new System.Drawing.Size(115, 20);
            this.txtCloseWeight.TabIndex = 19;
            this.txtCloseWeight.Text = "0.000";
            this.txtCloseWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            this.txtCloseWeight.TextChanged += new System.EventHandler(this.txtCloseWeight_TextChanged);
            this.txtCloseWeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCloseWeight_KeyUp);
            // 
            // txtNewBalance
            // 
            this.txtNewBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewBalance.DicemalDigits = 3;
            this.txtNewBalance.Location = new System.Drawing.Point(350, 189);
            this.txtNewBalance.maxmumNumber = 0D;
            this.txtNewBalance.minimumNumber = 0D;
            this.txtNewBalance.Name = "txtNewBalance";
            this.txtNewBalance.ProgramDigits = false;
            this.txtNewBalance.Size = new System.Drawing.Size(115, 20);
            this.txtNewBalance.TabIndex = 20;
            this.txtNewBalance.Text = "0.000";
            this.txtNewBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            this.txtNewBalance.TextChanged += new System.EventHandler(this.txtNewBalance_TextChanged);
            // 
            // txtItem
            // 
            this.txtItem.Enabled = false;
            this.txtItem.Location = new System.Drawing.Point(85, 105);
            this.txtItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(380, 21);
            this.txtItem.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(12, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Item";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCoileClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 324);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.txtNewBalance);
            this.Controls.Add(this.txtCloseWeight);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtQtyOut);
            this.Controls.Add(this.txtQtyIn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaterailID);
            this.Controls.Add(this.txtHeatNo);
            this.Name = "frmCoileClose";
            this.Text = "frmCoileClose";
            this.Load += new System.EventHandler(this.frmCoileClose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeatNo;
        private System.Windows.Forms.TextBox txtMaterailID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MyControls.decimalText txtQtyIn;
        private MyControls.decimalText txtQtyOut;
        private MyControls.decimalText txtBalance;
        private MyControls.decimalText txtCloseWeight;
        private MyControls.decimalText txtNewBalance;
        private MyControls.UC_Items txtItem;
        private System.Windows.Forms.Label label8;
    }
}