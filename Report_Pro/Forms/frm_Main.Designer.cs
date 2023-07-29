namespace Report_Pro.Forms
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangeStore = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnChangeBranch = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.fluentDesignFormControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            resources.ApplyResources(this.fluentDesignFormContainer1, "fluentDesignFormContainer1");
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Click += new System.EventHandler(this.fluentDesignFormContainer1_Click);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.Item.Default.BackColor = System.Drawing.SystemColors.Control;
            this.accordionControl1.Appearance.Item.Default.BackColor2 = ((System.Drawing.Color)(resources.GetObject("accordionControl1.Appearance.Item.Default.BackColor2")));
            this.accordionControl1.Appearance.Item.Default.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
            this.accordionControl1.Appearance.Item.Default.Options.UseBackColor = true;
            this.accordionControl1.Appearance.Item.Default.Options.UseForeColor = true;
            this.accordionControl1.Appearance.Item.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.accordionControl1.Appearance.Item.Hovered.Options.UseBackColor = true;
            resources.ApplyResources(this.accordionControl1, "accordionControl1");
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1});
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            resources.ApplyResources(this.accordionControlElement1, "accordionControlElement1");
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Controls.Add(this.cmbYear);
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnChangeStore,
            this.barEditItem1,
            this.barStaticItem1,
            this.btnChangeBranch,
            this.barStaticItem2,
            this.barEditItem2,
            this.barButtonItem3});
            resources.ApplyResources(this.fluentDesignFormControl1, "fluentDesignFormControl1");
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1,
            this.repositoryItemComboBox1});
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem1);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnChangeStore);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            resources.GetString("cmbYear.Items"),
            resources.GetString("cmbYear.Items1"),
            resources.GetString("cmbYear.Items2"),
            resources.GetString("cmbYear.Items3"),
            resources.GetString("cmbYear.Items4")});
            resources.ApplyResources(this.cmbYear, "cmbYear");
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnChangeStore
            // 
            resources.ApplyResources(this.btnChangeStore, "btnChangeStore");
            this.btnChangeStore.Id = 2;
            this.btnChangeStore.Name = "btnChangeStore";
            this.btnChangeStore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangeStore_ItemClick);
            // 
            // barEditItem1
            // 
            resources.ApplyResources(this.barEditItem1, "barEditItem1");
            this.barEditItem1.Edit = this.repositoryItemColorPickEdit1;
            this.barEditItem1.Id = 3;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemColorPickEdit1
            // 
            resources.ApplyResources(this.repositoryItemColorPickEdit1, "repositoryItemColorPickEdit1");
            this.repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemColorPickEdit1.Buttons"))))});
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Width = 100;
            // 
            // btnChangeBranch
            // 
            resources.ApplyResources(this.btnChangeBranch, "btnChangeBranch");
            this.btnChangeBranch.Id = 5;
            this.btnChangeBranch.Name = "btnChangeBranch";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.barStaticItem2.Id = 6;
            this.barStaticItem2.Name = "barStaticItem2";
            resources.ApplyResources(this.barStaticItem2, "barStaticItem2");
            this.barStaticItem2.Width = 150;
            // 
            // barEditItem2
            // 
            this.barEditItem2.Edit = this.repositoryItemComboBox1;
            this.barEditItem2.Id = 7;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemComboBox1
            // 
            resources.ApplyResources(this.repositoryItemComboBox1, "repositoryItemComboBox1");
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemComboBox1.Buttons"))))});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barButtonItem3
            // 
            resources.ApplyResources(this.barButtonItem3, "barButtonItem3");
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnChangeStore,
            this.barEditItem1,
            this.barStaticItem1,
            this.btnChangeBranch,
            this.barStaticItem2,
            this.barEditItem2,
            this.barButtonItem3});
            this.fluentFormDefaultManager1.MaxItemId = 9;
            this.fluentFormDefaultManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1,
            this.repositoryItemComboBox1});
            // 
            // frm_Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frm_Main";
            this.NavigationControl = this.accordionControl1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.fluentDesignFormControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnChangeStore;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnChangeBranch;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private System.Windows.Forms.ComboBox cmbYear;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}