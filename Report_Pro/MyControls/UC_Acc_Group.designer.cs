namespace Report_Pro.MyControls
{
    partial class UC_Acc_Group
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Acc_Group));
            this.dgv1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.branchID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMainAcc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFinal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn1 = new DevComponents.DotNetBar.ButtonX();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Desc = new System.Windows.Forms.TextBox();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ID = new System.Windows.Forms.TextBox();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgv1, "dgv1");
            this.dgv1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // branchID
            // 
            // 
            // 
            // 
            this.branchID.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.branchID, "branchID");
            this.branchID.Name = "branchID";
            // 
            // txtMainAcc
            // 
            // 
            // 
            // 
            this.txtMainAcc.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.txtMainAcc, "txtMainAcc");
            this.txtMainAcc.Name = "txtMainAcc";
            // 
            // txtFinal
            // 
            // 
            // 
            // 
            this.txtFinal.Border.Class = "TextBoxBorder";
            resources.ApplyResources(this.txtFinal, "txtFinal");
            this.txtFinal.Name = "txtFinal";
            // 
            // layoutControl1
            // 
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Controls.Add(this.btn1);
            this.layoutControl1.Controls.Add(this.ID);
            this.layoutControl1.Controls.Add(this.Desc);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(689, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            // 
            // btn1
            // 
            this.btn1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn1.Image = ((System.Drawing.Image)(resources.GetObject("btn1.Image")));
            resources.ApplyResources(this.btn1, "btn1");
            this.btn1.Name = "btn1";
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(321, 20);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Desc;
            this.layoutControlItem4.Location = new System.Drawing.Point(110, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Size = new System.Drawing.Size(211, 20);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // Desc
            // 
            this.Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.Desc, "Desc");
            this.Desc.Name = "Desc";
            this.Desc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Desc_KeyUp);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ID;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(80, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 20);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // ID
            // 
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            this.ID.TextChanged += new System.EventHandler(this.ID_TextChanged_1);
            this.ID.Enter += new System.EventHandler(this.ID_Enter);
            this.ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ID_KeyDown);
            this.ID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ID_KeyUp);
            this.ID.Leave += new System.EventHandler(this.ID_Leave);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn1;
            this.layoutControlItem3.Location = new System.Drawing.Point(80, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Size = new System.Drawing.Size(30, 20);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // UC_Acc_Group
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtMainAcc);
            this.Controls.Add(this.branchID);
            this.Name = "UC_Acc_Group";
            this.Leave += new System.EventHandler(this.UC_Acc_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv1;
        public DevComponents.DotNetBar.Controls.TextBoxX branchID;
        public DevComponents.DotNetBar.Controls.TextBoxX txtMainAcc;
        public DevComponents.DotNetBar.Controls.TextBoxX txtFinal;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevComponents.DotNetBar.ButtonX btn1;
        public System.Windows.Forms.TextBox ID;
        public System.Windows.Forms.TextBox Desc;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
