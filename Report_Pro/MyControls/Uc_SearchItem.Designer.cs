﻿namespace Report_Pro.MyControls
{
    partial class Uc_SearchItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_SearchItem));
            this.dGV_pro_list = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ch_SaveSearch = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSrch = new DevComponents.DotNetBar.ButtonX();
            this.txtserch_4 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radiobalance = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsrch_1 = new System.Windows.Forms.TextBox();
            this.txtSrch_3 = new System.Windows.Forms.TextBox();
            this.txtserch_2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_pro_list)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_pro_list
            // 
            this.dGV_pro_list.AllowUserToAddRows = false;
            this.dGV_pro_list.AllowUserToDeleteRows = false;
            this.dGV_pro_list.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGV_pro_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dGV_pro_list, "dGV_pro_list");
            this.dGV_pro_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dGV_pro_list.MultiSelect = false;
            this.dGV_pro_list.Name = "dGV_pro_list";
            this.dGV_pro_list.ReadOnly = true;
            this.dGV_pro_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_pro_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_pro_list_CellContentClick);
            this.dGV_pro_list.DoubleClick += new System.EventHandler(this.dGV_pro_list_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Controls.Add(this.button1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.groupPanel1.Controls.Add(this.ch_SaveSearch);
            this.groupPanel1.Controls.Add(this.btnSrch);
            this.groupPanel1.Controls.Add(this.txtserch_4);
            this.groupPanel1.Controls.Add(this.panel3);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.txtSrch);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtsrch_1);
            this.groupPanel1.Controls.Add(this.txtSrch_3);
            this.groupPanel1.Controls.Add(this.txtserch_2);
            resources.ApplyResources(this.groupPanel1, "groupPanel1");
            this.groupPanel1.Name = "groupPanel1";
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(198)))));
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
            // ch_SaveSearch
            // 
            resources.ApplyResources(this.ch_SaveSearch, "ch_SaveSearch");
            this.ch_SaveSearch.BackColor = System.Drawing.Color.Transparent;
            this.ch_SaveSearch.Name = "ch_SaveSearch";
            // 
            // btnSrch
            // 
            this.btnSrch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSrch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSrch.Image = global::Report_Pro.Properties.Resources.Search_icon1;
            resources.ApplyResources(this.btnSrch, "btnSrch");
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // txtserch_4
            // 
            this.txtserch_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtserch_4, "txtserch_4");
            this.txtserch_4.Name = "txtserch_4";
            this.txtserch_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtserch_4_KeyDown);
            this.txtserch_4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtserch_4_KeyUp);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.radioAll);
            this.panel3.Controls.Add(this.radiobalance);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // radioAll
            // 
            resources.ApplyResources(this.radioAll, "radioAll");
            this.radioAll.Name = "radioAll";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radiobalance
            // 
            resources.ApplyResources(this.radiobalance, "radiobalance");
            this.radiobalance.Checked = true;
            this.radiobalance.Name = "radiobalance";
            this.radiobalance.TabStop = true;
            this.radiobalance.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // txtSrch
            // 
            this.txtSrch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSrch, "txtSrch");
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSrch_KeyDown);
            this.txtSrch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSrch_KeyUp);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // txtsrch_1
            // 
            this.txtsrch_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtsrch_1, "txtsrch_1");
            this.txtsrch_1.Name = "txtsrch_1";
            this.txtsrch_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsrch_1_KeyDown);
            this.txtsrch_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsrch_1_KeyUp);
            // 
            // txtSrch_3
            // 
            this.txtSrch_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSrch_3, "txtSrch_3");
            this.txtSrch_3.Name = "txtSrch_3";
            this.txtSrch_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSrch_3_KeyDown);
            this.txtSrch_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSrch_3_KeyUp);
            // 
            // txtserch_2
            // 
            this.txtserch_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtserch_2, "txtserch_2");
            this.txtserch_2.Name = "txtserch_2";
            this.txtserch_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtserch_2_KeyDown);
            this.txtserch_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtserch_2_KeyUp);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Uc_SearchItem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dGV_pro_list);
            this.Controls.Add(this.panel1);
            this.Name = "Uc_SearchItem";
            this.Load += new System.EventHandler(this.Uc_SearchItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_pro_list)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dGV_pro_list;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSrch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radiobalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        public DevComponents.DotNetBar.Controls.CheckBoxX ch_SaveSearch;
        public System.Windows.Forms.TextBox txtserch_4;
        public System.Windows.Forms.TextBox txtSrch;
        public System.Windows.Forms.TextBox txtsrch_1;
        public System.Windows.Forms.TextBox txtSrch_3;
        public System.Windows.Forms.TextBox txtserch_2;
    }
}
