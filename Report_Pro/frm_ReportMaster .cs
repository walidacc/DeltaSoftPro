using DevExpress.XtraEditors;
using Report_Pro.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro
{
    public partial class frm_ReportMaster : XtraForm
    {
       bool IsNew;

        public static string ErrorText
        {
            get
            {
                return "هذا الحقل مطلوب";
            }
        }

        public frm_ReportMaster()
        {
            InitializeComponent();
        }


        private void frm_Master_Load(object sender, EventArgs e)
        {
        
        }


       
        public virtual void Report()
        {

        }

        public virtual void preview()
        {
           
        }

        public int canEdit=1 ;

        public virtual void CloseForm(Form frm)
        {
            frm.Close();
        }
        public virtual void MaxForm(Form frm)
        {
            if (frm.WindowState == FormWindowState.Normal)
            {
                frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
            }
        }
        public virtual void MinForm(Form frm)
        {
            frm.WindowState=FormWindowState.Minimized;
        }



        public virtual void Option()
        {

        }

        public virtual void RefreshData()
        {

        }
        public virtual bool IsDataVailde()
        {
            return true;
        }



 

        private void btn_Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (CheckActionAuthorization(this.Name, Master.Actions.Print))
            //    Print();
        }

        


        public static bool CheckActionAuthorization(string formName, Master.Actions actions, DAL.wh_USER user = null)
        {
            if (user == null)
                user = Session.User;

            if (user.CAN_GIVE_PERM == (byte)Master.UserType.Admin)
                return true;
            else
            {
                var screen = Session.ScreensAccesses.SingleOrDefault(x => x.ScreenName == formName);
                bool flag = true;
                if (screen != null)
                {
                    switch (actions)
                    {
                        case Master.Actions.Add:
                            flag = screen.CanAdd;
                            break;
                        case Master.Actions.Edit:
                            flag = screen.CanEdit;

                            break;
                        case Master.Actions.Delete:
                            flag = screen.CanDelete;

                            break;
                        case Master.Actions.Print:
                            flag = screen.CanPrint;

                            break;
                        default:
                            break;
                    }
                }
                if (flag == false)
                {
                    XtraMessageBox.Show(
         text: "غير مصرح لك ",
         caption: "",
         icon: MessageBoxIcon.Error,
         buttons: MessageBoxButtons.OK
         );
                }
                return flag;
            }


        }





        private void frm_Master_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                Report();
            }
            if (e.KeyCode == Keys.F1)
            {
                Option();
            }
         
        }


       

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReportMaster));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btn_Option = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_preview = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Report = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_exportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbLanguh = new System.Windows.Forms.ToolStripComboBox();
            this.headLbl = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Controls.Add(this.menuStrip1);
            this.panelHeader.Controls.Add(this.headLbl);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Option,
            this.btn_preview,
            this.btn_Report,
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem2,
            this.btn_exportToExcel,
            this.cmbLanguh});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // btn_Option
            // 
            this.btn_Option.Image = global::Report_Pro.Properties.Resources.optionspivottable_32x32;
            this.btn_Option.Name = "btn_Option";
            resources.ApplyResources(this.btn_Option, "btn_Option");
            this.btn_Option.Click += new System.EventHandler(this.btn_Option_Click);
            // 
            // btn_preview
            // 
            this.btn_preview.Image = global::Report_Pro.Properties.Resources.printpreview_32x32;
            this.btn_preview.Name = "btn_preview";
            resources.ApplyResources(this.btn_preview, "btn_preview");
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // btn_Report
            // 
            this.btn_Report.Image = global::Report_Pro.Properties.Resources.report_32x32;
            this.btn_Report.Name = "btn_Report";
            resources.ApplyResources(this.btn_Report, "btn_Report");
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xToolStripMenuItem.Image = global::Report_Pro.Properties.Resources.Exit_icon;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            resources.ApplyResources(this.xToolStripMenuItem, "xToolStripMenuItem");
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xToolStripMenuItem1.Image = global::Report_Pro.Properties.Resources.selectall_32x321;
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            resources.ApplyResources(this.xToolStripMenuItem1, "xToolStripMenuItem1");
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.xToolStripMenuItem2.Image = global::Report_Pro.Properties.Resources.remove_32x321;
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            resources.ApplyResources(this.xToolStripMenuItem2, "xToolStripMenuItem2");
            this.xToolStripMenuItem2.Click += new System.EventHandler(this.xToolStripMenuItem2_Click);
            // 
            // btn_exportToExcel
            // 
            this.btn_exportToExcel.Image = global::Report_Pro.Properties.Resources.excel;
            this.btn_exportToExcel.Name = "btn_exportToExcel";
            resources.ApplyResources(this.btn_exportToExcel, "btn_exportToExcel");
            this.btn_exportToExcel.Click += new System.EventHandler(this.btn_exportToExcel_Click);
            // 
            // cmbLanguh
            // 
            this.cmbLanguh.Items.AddRange(new object[] {
            resources.GetString("cmbLanguh.Items"),
            resources.GetString("cmbLanguh.Items1")});
            this.cmbLanguh.Name = "cmbLanguh";
            resources.ApplyResources(this.cmbLanguh, "cmbLanguh");
            // 
            // headLbl
            // 
            this.headLbl.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.headLbl, "headLbl");
            this.headLbl.Name = "headLbl";
            this.headLbl.Click += new System.EventHandler(this.headLbl_Click);
            // 
            // frm_ReportMaster
            // 
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.panelHeader);
            this.Name = "frm_ReportMaster";
            this.Load += new System.EventHandler(this.frm_ReportMaster_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForm(this);
        }

       

        private void btn_Max_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MaxForm(this);
        }

        private void btn_Min_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MinForm(this);
        }

        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       }

       

     

        private void frm_ReportMaster_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.lungh == "0")
            {
                cmbLanguh.SelectedIndex = 1;
            }
            else
            {

                cmbLanguh.SelectedIndex = 0;
                
            }
        }

        private void btn_Option_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Option();
        }

        private void btn_preview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Print))
              
            preview();
        }

        private void btn_Report_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (CheckActionAuthorization(this.Name, Master.Actions.Print))
               
                Report();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Option_Click(object sender, EventArgs e)
        {
            Option();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {

            if (CheckActionAuthorization(this.Name, Master.Actions.Print))

                Report();
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Print))

                preview();
        }

        private void headLbl_Click(object sender, EventArgs e)
        {

        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm(this);
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MaxForm(this);
        }

        private void xToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MinForm(this);
        }

        private void btn_exportToExcel_Click(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Print))

                exportToExcel();
        }

      
        public virtual void exportToExcel()
        {

        }
    }
    }

