﻿namespace Report_Pro.PL
{
    partial class test
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
            this.jorDebit1 = new jorRow.jorDebit();
            this.SuspendLayout();
            // 
            // jorDebit1
            // 
            this.jorDebit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jorDebit1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.jorDebit1.Location = new System.Drawing.Point(0, 0);
            this.jorDebit1.Margin = new System.Windows.Forms.Padding(2);
            this.jorDebit1.Name = "jorDebit1";
            this.jorDebit1.Size = new System.Drawing.Size(1294, 694);
            this.jorDebit1.TabIndex = 0;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1294, 694);
            this.Controls.Add(this.jorDebit1);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private jorRow.jorDebit jorDebit1;
    }
}