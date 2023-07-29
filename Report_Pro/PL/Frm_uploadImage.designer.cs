namespace Report_Pro.PL
{
    partial class Frm_uploadImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_uploadImage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgv2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._docType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.pb = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SelectScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_UploadFromScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.btnGoFrist = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoNext = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_GoLast = new System.Windows.Forms.ToolStripMenuItem();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "background1.jpg");
            this.imageList1.Images.SetKeyName(1, "background2.jpg");
            this.imageList1.Images.SetKeyName(2, "adope_image.jpg");
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Tabs.Add(this.tabItem2);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.tabControlPanel1, "tabControlPanel1");
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            resources.ApplyResources(this.tabItem1, "tabItem1");
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.dgv2);
            resources.ApplyResources(this.tabControlPanel3, "tabControlPanel3");
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this._docType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgv2, "dgv2");
            this.dgv2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv2.Name = "dgv2";
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // _docType
            // 
            resources.ApplyResources(this._docType, "_docType");
            this._docType.Name = "_docType";
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            resources.ApplyResources(this.tabItem3, "tabItem3");
            // 
            // pb
            // 
            resources.ApplyResources(this.pb, "pb");
            this.pb.Name = "pb";
            this.pb.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnSave,
            this.btnDelete,
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem2,
            this.btn_SelectScanner,
            this.btn_UploadFromScanner,
            this.toolStripTextBox1,
            this.btnGoFrist,
            this.btnGoPrevious,
            this.btnGoNext,
            this.btn_GoLast});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Report_Pro.Properties.Resources.Add_Icon;
            this.btnNew.Name = "btnNew";
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Report_Pro.Properties.Resources.save_Icon;
            this.btnSave.Name = "btnSave";
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Report_Pro.Properties.Resources.cancel_32x321;
            this.btnDelete.Name = "btnDelete";
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.xToolStripMenuItem, "xToolStripMenuItem");
            this.xToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xToolStripMenuItem.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.xToolStripMenuItem1, "xToolStripMenuItem1");
            this.xToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xToolStripMenuItem1.Image = global::Report_Pro.Properties.Resources.selectall_32x321;
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.xToolStripMenuItem2, "xToolStripMenuItem2");
            this.xToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xToolStripMenuItem2.Image = global::Report_Pro.Properties.Resources.remove_32x321;
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            this.xToolStripMenuItem2.Click += new System.EventHandler(this.xToolStripMenuItem2_Click);
            // 
            // btn_SelectScanner
            // 
            this.btn_SelectScanner.Name = "btn_SelectScanner";
            resources.ApplyResources(this.btn_SelectScanner, "btn_SelectScanner");
            this.btn_SelectScanner.Click += new System.EventHandler(this.btn_SelectScanner_Click);
            // 
            // btn_UploadFromScanner
            // 
            this.btn_UploadFromScanner.Name = "btn_UploadFromScanner";
            resources.ApplyResources(this.btn_UploadFromScanner, "btn_UploadFromScanner");
            this.btn_UploadFromScanner.Click += new System.EventHandler(this.btn_UploadFromScanner_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            // 
            // btnGoFrist
            // 
            resources.ApplyResources(this.btnGoFrist, "btnGoFrist");
            this.btnGoFrist.Image = global::Report_Pro.Properties.Resources.doublefirst_32x32;
            this.btnGoFrist.Name = "btnGoFrist";
            // 
            // btnGoPrevious
            // 
            resources.ApplyResources(this.btnGoPrevious, "btnGoPrevious");
            this.btnGoPrevious.Image = global::Report_Pro.Properties.Resources.prev_32x32;
            this.btnGoPrevious.Name = "btnGoPrevious";
            // 
            // btnGoNext
            // 
            resources.ApplyResources(this.btnGoNext, "btnGoNext");
            this.btnGoNext.Image = global::Report_Pro.Properties.Resources.next_32x32;
            this.btnGoNext.Name = "btnGoNext";
            // 
            // btn_GoLast
            // 
            resources.ApplyResources(this.btn_GoLast, "btn_GoLast");
            this.btn_GoLast.Image = global::Report_Pro.Properties.Resources.doublelast_32x32;
            this.btn_GoLast.Name = "btn_GoLast";
            // 
            // axAcroPDF1
            // 
            resources.ApplyResources(this.axAcroPDF1, "axAcroPDF1");
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            // 
            // lbDevices
            // 
            resources.ApplyResources(this.lbDevices, "lbDevices");
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Name = "lbDevices";
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            resources.ApplyResources(this.tabItem2, "tabItem2");
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.ListBox1);
            resources.ApplyResources(this.tabControlPanel2, "tabControlPanel2");
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // ListBox1
            // 
            this.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ListBox1, "ListBox1");
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Name = "ListBox1";
            // 
            // Frm_uploadImage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ControlBox = false;
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Frm_uploadImage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_uploadImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv2;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn _docType;
        private System.Windows.Forms.PictureBox pb;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem btnNew;
        public System.Windows.Forms.ToolStripMenuItem btnSave;
        public System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        public System.Windows.Forms.ToolStripMenuItem btnGoFrist;
        public System.Windows.Forms.ToolStripMenuItem btnGoPrevious;
        public System.Windows.Forms.ToolStripMenuItem btnGoNext;
        public System.Windows.Forms.ToolStripMenuItem btn_GoLast;
        private System.Windows.Forms.ToolStripMenuItem btn_SelectScanner;
        private System.Windows.Forms.ToolStripMenuItem btn_UploadFromScanner;
        private System.Windows.Forms.ListBox lbDevices;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        internal System.Windows.Forms.ListBox ListBox1;
        private DevComponents.DotNetBar.TabItem tabItem2;
    }
}