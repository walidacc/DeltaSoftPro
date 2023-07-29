namespace Report_Pro.PL
{
    partial class frm_Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Group));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_co = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_cat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDesc_En = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Lbl_position = new System.Windows.Forms.Label();
            this.Btn_Last = new System.Windows.Forms.Button();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.Btn_Prev = new System.Windows.Forms.Button();
            this.Btn_Frist = new System.Windows.Forms.Button();
            this.TxtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_exit = new System.Windows.Forms.Button();
            this.Btn_exprt_S = new System.Windows.Forms.Button();
            this.Btn_export_all = new System.Windows.Forms.Button();
            this.Btn_print_S = new System.Windows.Forms.Button();
            this.Btn_print_all = new System.Windows.Forms.Button();
            this.Btn_updt = new System.Windows.Forms.Button();
            this.Btn_del = new System.Windows.Forms.Button();
            this.Btn_sav = new System.Windows.Forms.Button();
            this.Btn_add = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dGlist = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGlist)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cmb_co);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_cat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtDesc_En);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Lbl_position);
            this.groupBox1.Controls.Add(this.Btn_Last);
            this.groupBox1.Controls.Add(this.Btn_Next);
            this.groupBox1.Controls.Add(this.Btn_Prev);
            this.groupBox1.Controls.Add(this.Btn_Frist);
            this.groupBox1.Controls.Add(this.TxtDesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtId);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cmb_co
            // 
            this.cmb_co.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmb_co, "cmb_co");
            this.cmb_co.FormattingEnabled = true;
            this.cmb_co.Name = "cmb_co";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmb_cat
            // 
            this.cmb_cat.FormattingEnabled = true;
            resources.ApplyResources(this.cmb_cat, "cmb_cat");
            this.cmb_cat.Name = "cmb_cat";
            this.cmb_cat.SelectedIndexChanged += new System.EventHandler(this.cmb_cat_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TxtDesc_En
            // 
            resources.ApplyResources(this.TxtDesc_En, "TxtDesc_En");
            this.TxtDesc_En.Name = "TxtDesc_En";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Lbl_position
            // 
            resources.ApplyResources(this.Lbl_position, "Lbl_position");
            this.Lbl_position.Name = "Lbl_position";
            // 
            // Btn_Last
            // 
            resources.ApplyResources(this.Btn_Last, "Btn_Last");
            this.Btn_Last.Name = "Btn_Last";
            this.Btn_Last.UseVisualStyleBackColor = true;
            this.Btn_Last.Click += new System.EventHandler(this.Btn_Last_Click);
            // 
            // Btn_Next
            // 
            resources.ApplyResources(this.Btn_Next, "Btn_Next");
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.UseVisualStyleBackColor = true;
            this.Btn_Next.Click += new System.EventHandler(this.Btn_Next_Click);
            // 
            // Btn_Prev
            // 
            resources.ApplyResources(this.Btn_Prev, "Btn_Prev");
            this.Btn_Prev.Name = "Btn_Prev";
            this.Btn_Prev.UseVisualStyleBackColor = true;
            this.Btn_Prev.Click += new System.EventHandler(this.Btn_Prev_Click);
            // 
            // Btn_Frist
            // 
            resources.ApplyResources(this.Btn_Frist, "Btn_Frist");
            this.Btn_Frist.Name = "Btn_Frist";
            this.Btn_Frist.UseVisualStyleBackColor = true;
            this.Btn_Frist.Click += new System.EventHandler(this.Btn_Frist_Click);
            // 
            // TxtDesc
            // 
            resources.ApplyResources(this.TxtDesc, "TxtDesc");
            this.TxtDesc.Name = "TxtDesc";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TxtId
            // 
            resources.ApplyResources(this.TxtId, "TxtId");
            this.TxtId.Name = "TxtId";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_exit);
            this.groupBox2.Controls.Add(this.Btn_exprt_S);
            this.groupBox2.Controls.Add(this.Btn_export_all);
            this.groupBox2.Controls.Add(this.Btn_print_S);
            this.groupBox2.Controls.Add(this.Btn_print_all);
            this.groupBox2.Controls.Add(this.Btn_updt);
            this.groupBox2.Controls.Add(this.Btn_del);
            this.groupBox2.Controls.Add(this.Btn_sav);
            this.groupBox2.Controls.Add(this.Btn_add);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // Btn_exit
            // 
            resources.ApplyResources(this.Btn_exit, "Btn_exit");
            this.Btn_exit.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.Btn_exit.Name = "Btn_exit";
            this.Btn_exit.UseVisualStyleBackColor = true;
            this.Btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
            // 
            // Btn_exprt_S
            // 
            resources.ApplyResources(this.Btn_exprt_S, "Btn_exprt_S");
            this.Btn_exprt_S.Image = global::Report_Pro.Properties.Resources.excel;
            this.Btn_exprt_S.Name = "Btn_exprt_S";
            this.Btn_exprt_S.UseVisualStyleBackColor = true;
            this.Btn_exprt_S.Click += new System.EventHandler(this.Btn_exprt_S_Click);
            // 
            // Btn_export_all
            // 
            resources.ApplyResources(this.Btn_export_all, "Btn_export_all");
            this.Btn_export_all.Image = global::Report_Pro.Properties.Resources.excel;
            this.Btn_export_all.Name = "Btn_export_all";
            this.Btn_export_all.UseVisualStyleBackColor = true;
            this.Btn_export_all.Click += new System.EventHandler(this.Btn_export_all_Click);
            // 
            // Btn_print_S
            // 
            resources.ApplyResources(this.Btn_print_S, "Btn_print_S");
            this.Btn_print_S.Image = global::Report_Pro.Properties.Resources.printer_icon;
            this.Btn_print_S.Name = "Btn_print_S";
            this.Btn_print_S.UseVisualStyleBackColor = true;
            this.Btn_print_S.Click += new System.EventHandler(this.Btn_print_S_Click);
            // 
            // Btn_print_all
            // 
            resources.ApplyResources(this.Btn_print_all, "Btn_print_all");
            this.Btn_print_all.Image = global::Report_Pro.Properties.Resources.printer_icon;
            this.Btn_print_all.Name = "Btn_print_all";
            this.Btn_print_all.UseVisualStyleBackColor = true;
            this.Btn_print_all.Click += new System.EventHandler(this.Btn_print_all_Click);
            // 
            // Btn_updt
            // 
            resources.ApplyResources(this.Btn_updt, "Btn_updt");
            this.Btn_updt.Image = global::Report_Pro.Properties.Resources.update;
            this.Btn_updt.Name = "Btn_updt";
            this.Btn_updt.UseVisualStyleBackColor = true;
            this.Btn_updt.Click += new System.EventHandler(this.Btn_updt_Click);
            // 
            // Btn_del
            // 
            resources.ApplyResources(this.Btn_del, "Btn_del");
            this.Btn_del.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.Btn_del.Name = "Btn_del";
            this.Btn_del.UseVisualStyleBackColor = true;
            // 
            // Btn_sav
            // 
            resources.ApplyResources(this.Btn_sav, "Btn_sav");
            this.Btn_sav.Image = global::Report_Pro.Properties.Resources.save_Icon;
            this.Btn_sav.Name = "Btn_sav";
            this.Btn_sav.UseVisualStyleBackColor = true;
            this.Btn_sav.Click += new System.EventHandler(this.Btn_sav_Click);
            // 
            // Btn_add
            // 
            resources.ApplyResources(this.Btn_add, "Btn_add");
            this.Btn_add.Image = global::Report_Pro.Properties.Resources.new_1;
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.UseVisualStyleBackColor = true;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dGlist);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // dGlist
            // 
            this.dGlist.AllowUserToAddRows = false;
            this.dGlist.AllowUserToDeleteRows = false;
            this.dGlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGlist.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dGlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dGlist, "dGlist");
            this.dGlist.Name = "dGlist";
            this.dGlist.ReadOnly = true;
            this.dGlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGlist.SelectionChanged += new System.EventHandler(this.dGlist_SelectionChanged);
            // 
            // Cat_Frm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Cat_Frm";
            this.Load += new System.EventHandler(this.Cat_Frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Last;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.Button Btn_Prev;
        private System.Windows.Forms.Button Btn_Frist;
        private System.Windows.Forms.TextBox TxtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_position;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dGlist;
        private System.Windows.Forms.Button Btn_exit;
        private System.Windows.Forms.Button Btn_exprt_S;
        private System.Windows.Forms.Button Btn_export_all;
        private System.Windows.Forms.Button Btn_print_S;
        private System.Windows.Forms.Button Btn_print_all;
        private System.Windows.Forms.Button Btn_updt;
        private System.Windows.Forms.Button Btn_del;
        private System.Windows.Forms.Button Btn_sav;
        private System.Windows.Forms.TextBox TxtDesc_En;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_cat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_co;
        private System.Windows.Forms.Label label5;
    }
}