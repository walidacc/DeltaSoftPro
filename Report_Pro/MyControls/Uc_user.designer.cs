namespace Report_Pro.MyControls
{
    partial class Uc_user
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_LastRecord));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btn1 = new DevComponents.DotNetBar.ButtonX();
            this.txtFinal = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ID = new System.Windows.Forms.TextBox();
            this.Desc = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtuser = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            resources.ApplyResources(this.dgv1, "dgv1");
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // btn1
            // 
            resources.ApplyResources(this.btn1, "btn1");
            this.btn1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn1.Image = global::Report_Pro.Properties.Resources.search_16;
            this.btn1.Name = "btn1";
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // txtFinal
            // 
            resources.ApplyResources(this.txtFinal, "txtFinal");
            // 
            // 
            // 
            this.txtFinal.Border.Class = "TextBoxBorder";
            this.txtFinal.ButtonCustom.DisplayPosition = ((int)(resources.GetObject("txtFinal.ButtonCustom.DisplayPosition")));
            this.txtFinal.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtFinal.ButtonCustom.Image")));
            this.txtFinal.ButtonCustom.Text = resources.GetString("txtFinal.ButtonCustom.Text");
            this.txtFinal.ButtonCustom2.DisplayPosition = ((int)(resources.GetObject("txtFinal.ButtonCustom2.DisplayPosition")));
            this.txtFinal.ButtonCustom2.Image = ((System.Drawing.Image)(resources.GetObject("txtFinal.ButtonCustom2.Image")));
            this.txtFinal.ButtonCustom2.Text = resources.GetString("txtFinal.ButtonCustom2.Text");
            this.txtFinal.Name = "txtFinal";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btn1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Desc, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // ID
            // 
            resources.ApplyResources(this.ID, "ID");
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID.Name = "ID";
            this.ID.TextChanged += new System.EventHandler(this.ID_TextChanged);
            this.ID.Enter += new System.EventHandler(this.ID_Enter);
            this.ID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ID_KeyUp);
            this.ID.Leave += new System.EventHandler(this.ID_Leave);
            // 
            // Desc
            // 
            resources.ApplyResources(this.Desc, "Desc");
            this.Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Desc.Name = "Desc";
            this.Desc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Desc_KeyUp);
            this.Desc.Leave += new System.EventHandler(this.Desc_Leave);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // txtuser
            // 
            resources.ApplyResources(this.txtuser, "txtuser");
            this.txtuser.Name = "txtuser";
            // 
            // Uc_LastRecord
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtFinal);
            this.Name = "Uc_LastRecord";
            this.Leave += new System.EventHandler(this.UC_AccBranch_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgv1;
        private DevComponents.DotNetBar.ButtonX btn1;
        public DevComponents.DotNetBar.Controls.TextBoxX txtFinal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.TextBox Desc;
        public System.Windows.Forms.TextBox ID;
        public System.Windows.Forms.TextBox txtuser;
    }
}
