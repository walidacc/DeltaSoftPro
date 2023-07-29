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
using VScrollBar = System.Windows.Forms.VScrollBar;

namespace Report_Pro
{
    public partial class frm_Master : XtraForm
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public bool IsNew;
        public static string ErrorText
        {
            get
            {

                return "هذا الحقل مطلوب";
            }
        }
        public frm_Master()
        {
            InitializeComponent();
           
        }

        private void frm_Master_Load(object sender, EventArgs e)
        {
           
        }
        public virtual void Save()
        {

                //XtraMessageBox.Show("تم الحفظ بنجاح");
            RefreshData();
            IsNew = false;
        }
        public virtual void New()
        {
            GetData();
            IsNew = true;
        }
        public virtual void Delete()
        {

        }
        public virtual void Print()
        {

        }

        public virtual void Report()
        {

        }



       
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

        public virtual void GetData()
        {

        }

        public virtual void SetData()
        {

        }

        public virtual void Search()
        {
           // IsNew = false;
        }

        public virtual void GoFrist()
        {
            IsNew = false;
        }
        public virtual void GoPrevious()
        {
            IsNew = false;
        }
        public virtual void GoNext()
        {
            IsNew = false;
        }
        public virtual void GoLast()
        {
            IsNew = false;
        }

        public virtual void RefreshData()
        {

        }
        public virtual bool IsDataVailde()
        {
            return true;
        }

        public virtual void Attachment()
        {



        }

        public virtual void PreviewDeailyEntry(string _ser, string _branch, string _cyear)
        {

            RPT.Form1 frm = new RPT.Form1();


            DataTable dt_print = dal.getDataTabl_1(@"SELECT D.ACC_NO,D.BRANCH_code,D.ser_no,D.sorting_ser
                ,D.COST_CENTER,D.CAT_CODE,D.meno,D.loh,D.balance,D.h_date,D.g_date,D.sanad_no,D.desc2 ,D.desc_E,D.Supplier_Name
                ,D.vat_amont,D.vat_no,D.inv_date,D.vat_no,P.PAYER_NAME,isnull(P.payer_l_name,P.PAYER_NAME)as payer_l_name 
                ,C.COST_name,isnull(C.COST_E_NAME,C.COST_name) as COST_E_NAME
                ,T.CAT_NAME,isnull(T.CAT_NAME_E,T.CAT_NAME) as CAT_NAME_E
                ,U.USER_NAME,B.BRANCH_name,B.BRANCH_E_NAME
                FROM daily_transaction as D
                inner join payer2 as P on P.ACC_NO=D.ACC_NO and P.BRANCH_code=D.BRANCH_code
                left join COST_CENTER  as C on C.COST_CODE=D.COST_CENTER
                left join CATEGORY as T on T.CAT_CODE=D.CAT_CODE
                inner join wh_USERS as U on U.USER_ID=D.user_name
				inner join BRANCHS As B on B.BRANCH_code = D.BRANCH_code
                where  D.BRANCH_code='" + _branch + "' and D.ser_no='" + _ser + "' and D.ACC_YEAR ='" + _cyear + "' order by sorting_ser");


            DataTable dt_Loan = dal.getDataTabl_1(@"SELECT A.id,A.LoanNo,A.BankId,A.LoanACC,A.LoanDate,A.NumberOfPayments,A.LoanValue,A.PaymentNo,A.PaymentValue
            ,A.StartDate,A.MaturityDate,A.Rate,A.LoanPurpose,A.LoanRefrance,A.Branch_code,A.Jor_ser_no
            ,B.PAYER_NAME,B.payer_l_name,C.Loan_Purpose,C.Loan_Purpose_E
			,SUM(CASE WHEN  cast( D.PaymentDate  as date) <= '2023-01-01' THEN  D.PaymentAmount else 0 END) as payment " +
          ",SUM(CASE WHEN  cast( D.PaymentDate  as date) <= '2023-01-01' THEN  D.PayMentInterest else 0 END) as PayMentInterest " +
           " ,D.PaymentDate FROM LoansTbl As A " +
           "inner Join payer2 as B  on A.BankId=B.ACC_NO and A.Branch_code=B.BRANCH_code " +
           "left join LoanPurpose as C on c.Id=A.LoanPurpose " +
           "left join LoanPaymentTbl As D on A.LoanNo = D.LoanNo  and A.PaymentNo = D.PaymentNo " +
           "where A.Branch_code = '" + _branch + "' and A.Jor_ser_no = '" + _ser + "' " +
           "group by A.id,A.LoanNo,A.BankId,A.LoanACC,A.LoanDate,A.NumberOfPayments,A.LoanValue,A.PaymentNo,A.PaymentValue " +
           ",A.StartDate,A.MaturityDate,A.Rate,A.LoanPurpose,A.LoanRefrance,A.Branch_code,A.Jor_ser_no " +
           ",B.PAYER_NAME,B.payer_l_name,C.Loan_Purpose,C.Loan_Purpose_E,D.PaymentDate");

            if (dt_print.Rows.Count > 0)
            {

            DataSet ds = new DataSet();
            ds.Tables.Add(dt_print);
            ds.Tables.Add(dt_Loan);
            ds.WriteXmlSchema("schema1.xml");
            if (Properties.Settings.Default.lungh == "0")
            {
                RPT.rpt_DailyEntry rpt_DailyEntry = new RPT.rpt_DailyEntry();
                rpt_DailyEntry.SetDataSource(ds);
                rpt_DailyEntry.DataDefinition.FormulaFields["_digits"].Text = "'" + dal.digits_ + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" +dt_print.Rows[0]["BRANCH_code"].ToString() + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + dt_print.Rows[0]["BRANCH_name"].ToString() + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName_E"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            }
            else
            {
                RPT.rpt_DailyEntry_E rpt_DailyEntry = new RPT.rpt_DailyEntry_E();
                rpt_DailyEntry.SetDataSource(ds);
                rpt_DailyEntry.DataDefinition.FormulaFields["_digits"].Text = "'" + dal.digits_ + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + dt_print.Rows[0]["BRANCH_code"].ToString() + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + dt_print.Rows[0]["BRANCH_E_NAME"].ToString() + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName_E"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            }
            frm.ShowDialog();

            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckActionAuthorization(this.Name, IsNew ? Master.Actions.Add : Master.Actions.Edit))
                if (IsDataVailde())
                    Save();
        }

        private void btn_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Add))

                New();

        }

        private void btn_Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Print))
                Print();
        }





        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Delete))
                Delete();
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
         text: "You Don't have permission -- غير مصرح لك ",
         caption: "Error -- خطأ",
         icon: MessageBoxIcon.Error,
         buttons: MessageBoxButtons.OK
         );
                }
                return flag;
            }


        }





        private void frm_Master_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F1)
            //{
            //    Save();
            //}
            //if (e.KeyCode == Keys.F2)
            //{
            //    New();
            //}
            //if (e.KeyCode == Keys.F3)
            //{
            //    Delete();
            //}
            //if (e.KeyCode == Keys.F4)
            //{
            //    Print();
            //}
        }


       

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Master));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_New = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Print = new DevExpress.XtraBars.BarButtonItem();
            this.btn_close = new DevExpress.XtraBars.BarButtonItem();
            this.btn_search = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Max = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Min = new DevExpress.XtraBars.BarButtonItem();
            this.btn_statment = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btn_GoFrist = new DevExpress.XtraBars.BarButtonItem();
            this.btn_GoPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.btn_GoNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnGoLast = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Attachment = new DevExpress.XtraBars.BarButtonItem();
            this.panel_head = new System.Windows.Forms.Panel();
            this.headLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAttachment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStatment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPreviewDaliyEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.btnGoFrist = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGoNext = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_GoLast = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel_head.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Save,
            this.btn_New,
            this.btn_Delete,
            this.btn_Print,
            this.btn_close,
            this.btn_search,
            this.btn_Max,
            this.btn_Min,
            this.btn_statment,
            this.barStaticItem1,
            this.btn_GoFrist,
            this.btn_GoPrevious,
            this.barStaticItem2,
            this.btn_GoNext,
            this.btnGoLast,
            this.btn_Attachment});
            this.barManager1.MaxItemId = 16;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Manager = this.barManager1;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Manager = this.barManager1;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Manager = this.barManager1;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Manager = this.barManager1;
            // 
            // btn_Save
            // 
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.Id = 0;
            this.btn_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Save.ImageOptions.SvgImage")));
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Save_ItemClick);
            // 
            // btn_New
            // 
            resources.ApplyResources(this.btn_New, "btn_New");
            this.btn_New.Id = 1;
            this.btn_New.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_New.ImageOptions.SvgImage")));
            this.btn_New.Name = "btn_New";
            this.btn_New.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_New.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_New_ItemClick);
            // 
            // btn_Delete
            // 
            resources.ApplyResources(this.btn_Delete, "btn_Delete");
            this.btn_Delete.Id = 2;
            this.btn_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Delete.ImageOptions.SvgImage")));
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Delete_ItemClick);
            // 
            // btn_Print
            // 
            resources.ApplyResources(this.btn_Print, "btn_Print");
            this.btn_Print.Id = 3;
            this.btn_Print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Print.ImageOptions.SvgImage")));
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Print.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Print_ItemClick);
            // 
            // btn_close
            // 
            this.btn_close.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btn_close.Id = 4;
            this.btn_close.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_close.ImageOptions.SvgImage")));
            this.btn_close.Name = "btn_close";
            this.btn_close.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_close_ItemClick);
            // 
            // btn_search
            // 
            resources.ApplyResources(this.btn_search, "btn_search");
            this.btn_search.Id = 5;
            this.btn_search.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_search.ImageOptions.SvgImage")));
            this.btn_search.Name = "btn_search";
            this.btn_search.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_search.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_search.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_search_ItemClick);
            // 
            // btn_Max
            // 
            this.btn_Max.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btn_Max.Id = 6;
            this.btn_Max.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Max.ImageOptions.Image")));
            this.btn_Max.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Max.ImageOptions.LargeImage")));
            this.btn_Max.Name = "btn_Max";
            this.btn_Max.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Max_ItemClick);
            // 
            // btn_Min
            // 
            this.btn_Min.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btn_Min.Id = 7;
            this.btn_Min.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Min.ImageOptions.Image")));
            this.btn_Min.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Min.ImageOptions.LargeImage")));
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Min_ItemClick);
            // 
            // btn_statment
            // 
            resources.ApplyResources(this.btn_statment, "btn_statment");
            this.btn_statment.Id = 8;
            this.btn_statment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_statment.ImageOptions.Image")));
            this.btn_statment.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_statment.ImageOptions.LargeImage")));
            this.btn_statment.Name = "btn_statment";
            this.btn_statment.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_statment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_statment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_statment_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.Name = "barStaticItem1";
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Width = 100;
            // 
            // btn_GoFrist
            // 
            this.btn_GoFrist.Id = 10;
            this.btn_GoFrist.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_GoFrist.ImageOptions.Image")));
            this.btn_GoFrist.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_GoFrist.ImageOptions.LargeImage")));
            this.btn_GoFrist.Name = "btn_GoFrist";
            this.btn_GoFrist.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_GoFrist_ItemClick);
            // 
            // btn_GoPrevious
            // 
            this.btn_GoPrevious.Id = 11;
            this.btn_GoPrevious.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_GoPrevious.ImageOptions.Image")));
            this.btn_GoPrevious.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_GoPrevious.ImageOptions.LargeImage")));
            this.btn_GoPrevious.Name = "btn_GoPrevious";
            this.btn_GoPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_GoPrevious_ItemClick);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Id = 12;
            this.barStaticItem2.Name = "barStaticItem2";
            resources.ApplyResources(this.barStaticItem2, "barStaticItem2");
            this.barStaticItem2.Width = 25;
            // 
            // btn_GoNext
            // 
            this.btn_GoNext.Id = 13;
            this.btn_GoNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_GoNext.ImageOptions.Image")));
            this.btn_GoNext.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_GoNext.ImageOptions.LargeImage")));
            this.btn_GoNext.Name = "btn_GoNext";
            this.btn_GoNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_GoNext_ItemClick);
            // 
            // btnGoLast
            // 
            this.btnGoLast.Id = 14;
            this.btnGoLast.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGoLast.ImageOptions.Image")));
            this.btnGoLast.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGoLast.ImageOptions.LargeImage")));
            this.btnGoLast.Name = "btnGoLast";
            this.btnGoLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGoLast_ItemClick);
            // 
            // btn_Attachment
            // 
            resources.ApplyResources(this.btn_Attachment, "btn_Attachment");
            this.btn_Attachment.Id = 15;
            this.btn_Attachment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Attachment.ImageOptions.Image")));
            this.btn_Attachment.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Attachment.ImageOptions.LargeImage")));
            this.btn_Attachment.Name = "btn_Attachment";
            this.btn_Attachment.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Attachment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Attachment_ItemClick);
            // 
            // panel_head
            // 
            resources.ApplyResources(this.panel_head, "panel_head");
            this.panel_head.Controls.Add(this.headLbl);
            this.panel_head.Controls.Add(this.menuStrip1);
            this.panel_head.Name = "panel_head";
            // 
            // headLbl
            // 
            this.headLbl.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.headLbl, "headLbl");
            this.headLbl.Name = "headLbl";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnNew,
            this.btnDelete,
            this.btnPrint,
            this.btnSearch,
            this.btnAttachment,
            this.btnStatment,
            this.btnPreviewDaliyEntry,
            this.xToolStripMenuItem,
            this.xToolStripMenuItem1,
            this.xToolStripMenuItem2,
            this.toolStripTextBox1,
            this.btnGoFrist,
            this.btnGoPrevious,
            this.btnGoNext,
            this.btn_GoLast});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Report_Pro.Properties.Resources.save_Icon;
            this.btnSave.Name = "btnSave";
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColorChanged += new System.EventHandler(this.btnSave_BackColorChanged);
            this.btnSave.Click += new System.EventHandler(this.btn_Save_ItemClick);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Report_Pro.Properties.Resources.Add_Icon;
            this.btnNew.Name = "btnNew";
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Report_Pro.Properties.Resources.cancel_32x321;
            this.btnDelete.Name = "btnDelete";
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Report_Pro.Properties.Resources.printer_icon;
            this.btnPrint.Name = "btnPrint";
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Report_Pro.Properties.Resources.Search_icon1;
            this.btnSearch.Name = "btnSearch";
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAttachment
            // 
            this.btnAttachment.Image = global::Report_Pro.Properties.Resources.attachment_32x32;
            this.btnAttachment.Name = "btnAttachment";
            resources.ApplyResources(this.btnAttachment, "btnAttachment");
            this.btnAttachment.Tag = "";
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // btnStatment
            // 
            this.btnStatment.Image = global::Report_Pro.Properties.Resources.report;
            this.btnStatment.Name = "btnStatment";
            resources.ApplyResources(this.btnStatment, "btnStatment");
            this.btnStatment.Click += new System.EventHandler(this.btnStatment_Click);
            // 
            // btnPreviewDaliyEntry
            // 
            this.btnPreviewDaliyEntry.Image = global::Report_Pro.Properties.Resources.printpreview_32x32;
            this.btnPreviewDaliyEntry.Name = "btnPreviewDaliyEntry";
            resources.ApplyResources(this.btnPreviewDaliyEntry, "btnPreviewDaliyEntry");
            this.btnPreviewDaliyEntry.Click += new System.EventHandler(this.btnPreviewDaliyEntry_Click);
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
            this.btnGoFrist.Click += new System.EventHandler(this.btnGoFrist_Click);
            // 
            // btnGoPrevious
            // 
            resources.ApplyResources(this.btnGoPrevious, "btnGoPrevious");
            this.btnGoPrevious.Image = global::Report_Pro.Properties.Resources.prev_32x32;
            this.btnGoPrevious.Name = "btnGoPrevious";
            this.btnGoPrevious.Click += new System.EventHandler(this.btnGoPrevious_Click);
            // 
            // btnGoNext
            // 
            resources.ApplyResources(this.btnGoNext, "btnGoNext");
            this.btnGoNext.Image = global::Report_Pro.Properties.Resources.next_32x32;
            this.btnGoNext.Name = "btnGoNext";
            this.btnGoNext.Click += new System.EventHandler(this.btnGoNext_Click);
            // 
            // btn_GoLast
            // 
            resources.ApplyResources(this.btn_GoLast, "btn_GoLast");
            this.btn_GoLast.Image = global::Report_Pro.Properties.Resources.doublelast_32x32;
            this.btn_GoLast.Name = "btn_GoLast";
            this.btn_GoLast.Click += new System.EventHandler(this.btn_GoLast_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frm_Master
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_head);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Master";
            this.Load += new System.EventHandler(this.frm_Master_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Master_KeyDown_1);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel_head.ResumeLayout(false);
            this.panel_head.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private void btn_close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseForm(this);
        }

        private void btn_search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search();
        }

        private void btn_Max_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MaxForm(this);
        }

        private void btn_Min_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MinForm(this);
        }

        private void btn_statment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
                if (CheckActionAuthorization(this.Name, Master.Actions.Print))
                    Report();
            
        }

      

        private void btn_GoFrist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GoFrist();
        }

        private void btn_GoPrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GoPrevious();
        }

        private void btn_GoNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GoNext();
        }

        private void btnGoLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GoLast();
        }

        private void btn_Attachment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Attachment();
        }

        private void frm_Master_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                New();
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                if (CheckActionAuthorization(this.Name, Master.Actions.Print))
                    Print();
            }

            if (e.Control && e.KeyCode == Keys.F)
            {
                Search();
            }

            if (e.Control && e.KeyCode == Keys.T)
            {
                Search();
            }
        }

        private void btnSave_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void btn_Save_ItemClick(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(this.Name, IsNew ? Master.Actions.Add : Master.Actions.Edit))
                if (IsDataVailde())
                    Save();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Print))
                Print();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Add))

                New();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(this.Name, Master.Actions.Delete))
                Delete();
        }

        private void btnStatment_Click(object sender, EventArgs e)
        {

            if (CheckActionAuthorization(this.Name, Master.Actions.Print))
                Report();
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            Attachment();
        }

        private void btnGoNext_Click(object sender, EventArgs e)
        {
            GoNext();
        }

        private void crToolStripTextBox1_Click(object sender, EventArgs e)
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

        private void btnGoPrevious_Click(object sender, EventArgs e)
        {
            GoPrevious();
        }

        private void btnGoFrist_Click(object sender, EventArgs e)
        {
            GoFrist();
        }

        private void btn_GoLast_Click(object sender, EventArgs e)
        {
            GoLast();
        }

        private void btnPreviewDaliyEntry_Click(object sender, EventArgs e)
        {
            if (CheckActionAuthorization(nameof(PL.frmJornal), Master.Actions.Print))
                PreviewDeailyEntry("","","");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
