namespace Report_Pro.RPT
{
    partial class frm_project_materails
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
            this.dTP2 = new System.Windows.Forms.DateTimePicker();
            this.dTP1 = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoByProject = new System.Windows.Forms.RadioButton();
            this.rdoDetials = new System.Windows.Forms.RadioButton();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.UC_Items = new Report_Pro.MyControls.UC_Items();
            this.UC_Cost = new Report_Pro.MyControls.UC_cost();
            this.UC_Acc = new Report_Pro.MyControls.UC_Acc();
            this.UC_Branch = new Report_Pro.MyControls.UC_Branch();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTP2
            // 
            this.dTP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dTP2.Location = new System.Drawing.Point(379, 100);
            this.dTP2.Name = "dTP2";
            this.dTP2.Size = new System.Drawing.Size(104, 20);
            this.dTP2.TabIndex = 1;
            // 
            // dTP1
            // 
            this.dTP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dTP1.Location = new System.Drawing.Point(379, 76);
            this.dTP1.Name = "dTP1";
            this.dTP1.Size = new System.Drawing.Size(104, 20);
            this.dTP1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 35);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(987, 459);
            this.crystalReportViewer1.TabIndex = 5;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ToolPanelWidth = 300;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // labelX6
            // 
            this.labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.Location = new System.Drawing.Point(901, 57);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(38, 15);
            this.labelX6.TabIndex = 288;
            this.labelX6.Text = "الحساب";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(901, 33);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(24, 15);
            this.labelX1.TabIndex = 292;
            this.labelX1.Text = "الفرع";
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(901, 105);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(30, 15);
            this.labelX3.TabIndex = 300;
            this.labelX3.Text = "الصنف";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rdoByProject);
            this.groupPanel1.Controls.Add(this.rdoDetials);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.UC_Items);
            this.groupPanel1.Controls.Add(this.UC_Cost);
            this.groupPanel1.Controls.Add(this.UC_Acc);
            this.groupPanel1.Controls.Add(this.UC_Branch);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.dTP2);
            this.groupPanel1.Controls.Add(this.dTP1);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 35);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(987, 280);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.Transparent;
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
            this.groupPanel1.TabIndex = 6;
            // 
            // rdoByProject
            // 
            this.rdoByProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoByProject.AutoSize = true;
            this.rdoByProject.Location = new System.Drawing.Point(409, 53);
            this.rdoByProject.Name = "rdoByProject";
            this.rdoByProject.Size = new System.Drawing.Size(74, 17);
            this.rdoByProject.TabIndex = 312;
            this.rdoByProject.Text = "By Project";
            this.rdoByProject.UseVisualStyleBackColor = true;
            // 
            // rdoDetials
            // 
            this.rdoDetials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDetials.AutoSize = true;
            this.rdoDetials.Checked = true;
            this.rdoDetials.Location = new System.Drawing.Point(426, 30);
            this.rdoDetials.Name = "rdoDetials";
            this.rdoDetials.Size = new System.Drawing.Size(57, 17);
            this.rdoDetials.TabIndex = 311;
            this.rdoDetials.TabStop = true;
            this.rdoDetials.Text = "Detials";
            this.rdoDetials.UseVisualStyleBackColor = true;
            // 
            // labelX5
            // 
            this.labelX5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.Location = new System.Drawing.Point(487, 103);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(42, 15);
            this.labelX5.TabIndex = 310;
            this.labelX5.Text = "الي تاريخ";
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(487, 79);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(40, 15);
            this.labelX4.TabIndex = 309;
            this.labelX4.Text = "من تاريخ";
            // 
            // UC_Items
            // 
            this.UC_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Items.Location = new System.Drawing.Point(563, 102);
            this.UC_Items.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Items.Name = "UC_Items";
            this.UC_Items.Size = new System.Drawing.Size(334, 20);
            this.UC_Items.TabIndex = 308;
            // 
            // UC_Cost
            // 
            this.UC_Cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Cost.Location = new System.Drawing.Point(563, 79);
            this.UC_Cost.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Cost.Name = "UC_Cost";
            this.UC_Cost.Size = new System.Drawing.Size(334, 20);
            this.UC_Cost.TabIndex = 307;
            // 
            // UC_Acc
            // 
            this.UC_Acc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Acc.BackColor = System.Drawing.Color.Transparent;
            this.UC_Acc.Location = new System.Drawing.Point(563, 54);
            this.UC_Acc.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Acc.Name = "UC_Acc";
            this.UC_Acc.Size = new System.Drawing.Size(334, 20);
            this.UC_Acc.TabIndex = 306;
            // 
            // UC_Branch
            // 
            this.UC_Branch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_Branch.BackColor = System.Drawing.Color.Transparent;
            this.UC_Branch.Cursor = System.Windows.Forms.Cursors.Default;
            this.UC_Branch.Location = new System.Drawing.Point(563, 30);
            this.UC_Branch.Margin = new System.Windows.Forms.Padding(0);
            this.UC_Branch.Name = "UC_Branch";
            this.UC_Branch.Size = new System.Drawing.Size(334, 20);
            this.UC_Branch.TabIndex = 305;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(901, 82);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 15);
            this.labelX2.TabIndex = 296;
            this.labelX2.Text = "مركز التكلفة";
            // 
            // frm_project_materails
            // 
            //this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            //this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 494);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frm_project_materails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الصرف للمشاريع";
            this.Controls.SetChildIndex(this.crystalReportViewer1, 0);
            this.Controls.SetChildIndex(this.groupPanel1, 0);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dTP2;
        private System.Windows.Forms.DateTimePicker dTP1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private MyControls.UC_Branch UC_Branch;
        private MyControls.UC_Acc UC_Acc;
        private DevComponents.DotNetBar.LabelX labelX4;
        private MyControls.UC_Items UC_Items;
        private MyControls.UC_cost UC_Cost;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.RadioButton rdoByProject;
        private System.Windows.Forms.RadioButton rdoDetials;
    }
}