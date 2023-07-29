namespace Report_Pro.MyControls
{
    partial class Jor_Row
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jor_Row));
            this.branchID = new System.Windows.Forms.TextBox();
            this.txtAmount = new Report_Pro.MyControls.decimalText();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // branchID
            // 
            this.branchID.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.branchID, "branchID");
            this.branchID.Name = "branchID";
            // 
            // txtAmount
            // 
            resources.ApplyResources(this.txtAmount, "txtAmount");
            this.tableLayoutPanel1.SetColumnSpan(this.txtAmount, 2);
            this.txtAmount.DicemalDigits = 0;
            this.txtAmount.maxmumNumber = 0D;
            this.txtAmount.minimumNumber = 0D;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ProgramDigits = false;
            this.txtAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label2, 17, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAmount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 16, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAccNo, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Name = "label2";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescription, 6);
            this.txtDescription.Name = "txtDescription";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 6);
            this.label1.Name = "label1";
            this.tableLayoutPanel1.SetRowSpan(this.label1, 2);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.LightCyan;
            this.textBox1.Name = "textBox1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 4);
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtAccNo
            // 
            resources.ApplyResources(this.txtAccNo, "txtAccNo");
            this.tableLayoutPanel1.SetColumnSpan(this.txtAccNo, 2);
            this.txtAccNo.Name = "txtAccNo";
            // 
            // Jor_Row
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.branchID);
            this.Name = "Jor_Row";
            this.Load += new System.EventHandler(this.Jor_Row_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox branchID;
        private decimalText txtAmount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccNo;
    }
}
