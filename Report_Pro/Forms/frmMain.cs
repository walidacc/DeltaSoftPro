using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Report_Pro.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Report_Pro.Forms
{
    public partial class frmMain : XtraForm
    {
       
        //public static frmMain _instance;
        //public static frmMain Instance
            
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new frmMain();

        //        return _instance;
        //    }

        //}

        public frmMain()
        {
            InitializeComponent();

        //  ribbonControl1.but += RibbonControl1_ItemClick;
            
           
            
        }

        private void RibbonControl1_ItemClick(object sender, EventArgs e)
        {
            var tag = Tag as string;
            if (tag != string.Empty)
            {
                //Panel pn = new Panel();
                //pn.Dock = DockStyle.Fill;
                //pn.BackColor = Color.Blue;
                //fluentDesignFormContainer1.Controls.Add(pn);
                OpenFormByName(tag);


            }
        }

        private void AccordionControl1_ElementClick(object sender, ElementClickEventArgs e)
        {
           
            var tag = e.Element.Tag as string;
            if(tag != string.Empty)
            {
                //Panel pn = new Panel();
                //pn.Dock = DockStyle.Fill;
                //pn.BackColor = Color.Blue;
                //fluentDesignFormContainer1.Controls.Add(pn);
                OpenFormByName(tag);
                

            }
           
        }



        public void OpenFormByName(string name)
        {

            Form frm = null;

            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == name);
            if (ins != null)
            {
               // frm = Application.OpenForms[frm.Name];
               
                frm = Activator.CreateInstance(ins) as Form;
                if (Application.OpenForms[frm.Name] != null)
                {
                    
                   
                   frm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    //    frm.Show();
                }

                 frm.WindowState = FormWindowState.Maximized;
                 frm.BringToFront();

            }


            if (frm != null)
            {
                frm.Name = name;

                OpenForm(frm);

            }
        }
        public void OpenForm(Form frm, bool OpenInDialog = false)
        {
            if (Session.User.CAN_GIVE_PERM == (byte)Master.UserType.Admin)
            {
                frm.MdiParent = this;
                frm.Show();

                return;
            }
            var screen = Session.ScreensAccesses.SingleOrDefault(x => x.ScreenName == frm.Name);
            if (screen != null)
            {
                if (screen.CanOpen == true)
                {
                    if (OpenInDialog)
                    { frm.ShowDialog(); }

                    else

                    { frm.Show(); }

                    return;

                }
                else
                {
                    XtraMessageBox.Show(
           text: "غير مصرح لك ",
           caption: "",
           icon: MessageBoxIcon.Error,
           buttons: MessageBoxButtons.OK
           );
                    return;
                }

            }



        }

        private void Load_items()
        {
            //accordionControl1.Elements.Clear();
            var screens = Session.ScreensAccesses.Where(X => X.CanShow == true || Session.User.CAN_GIVE_PERM == (byte)Master.UserType.Admin);
            screens.Where(s => s.ParentScreenID == 0).ToList().ForEach(s =>
            {
                AccordionControlElement elm = new AccordionControlElement()
                {
                    
                    Text =( Properties.Settings.Default.lungh =="0") ?  s.ScreenCaption : (s.ScreenCaption_E == null || s.ScreenCaption_E == "" ? s.ScreenCaption : s.ScreenCaption_E),
                    //  Text = s.ScreenCaption,
                    Tag = s.ScreenName,
                    Name = s.ScreenName,
                    Style = ElementStyle.Group

                };
              //        accordionControl1.Elements.Add(elm);
                AddAccordionElement(elm, s.ScreenID);
            });
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
           // accordionControl1.Elements.Clear();
            var screens = Session.ScreensAccesses.Where(X => X.CanShow == true || Session.User.CAN_GIVE_PERM == (byte)Master.UserType.Admin);
            screens.Where(s => s.ParentScreenID == 0).ToList().ForEach(s =>
               {
                   AccordionControlElement elm = new AccordionControlElement()
                   {
                       Text = (Properties.Settings.Default.lungh == "0") ? s.ScreenCaption : (s.ScreenCaption_E == null || s.ScreenCaption_E == "" ? s.ScreenCaption : s.ScreenCaption_E),

                       // Text = s.ScreenCaption,
                       Tag = s.ScreenName,
                       Name = s.ScreenName,
                       Style = ElementStyle.Group

                   };
                   //accordionControl1.Elements.Add(elm);
                   AddAccordionElement(elm, s.ScreenID);
               });
        }

        void AddAccordionElement(AccordionControlElement parent ,int parentID)
        {
            var screens = Session.ScreensAccesses.Where(X => X.CanShow == true || Session.User.CAN_GIVE_PERM == (byte)Master.UserType.Admin);
            screens.Where(s => s.ParentScreenID == parentID).ToList().ForEach(s =>
            {
                AccordionControlElement elm = new AccordionControlElement()
                {
                    Text = (Properties.Settings.Default.lungh == "0") ? s.ScreenCaption : (s.ScreenCaption_E == null || s.ScreenCaption_E == "" ? s.ScreenCaption : s.ScreenCaption_E),

                 //   Text = s.ScreenCaption,
                    Tag = s.ScreenName,
                    Name = s.ScreenName,
                    Style = ElementStyle.Item

                };
                parent.Elements.Add(elm);
            });
            }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

            public static void lang(string lge)
        {
            System.Globalization.CultureInfo TypeOfLanguage = new System.Globalization.CultureInfo(lge);
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
        }


       



        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Form> formList = new List<Form>();
            foreach (Form openForm in (System.Collections.ReadOnlyCollectionBase)Application.OpenForms)
                formList.Add(openForm);
            foreach (Form form in formList)
            {
                if (form.Name != "frm_Main" && form.Name != "login_frm")
                    form.Close();
            }
            
            if (Properties.Settings.Default.lungh != "0")
            {
               
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                    Properties.Settings.Default.lungh = "0";
                    lang("ar");
                
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                Properties.Settings.Default.lungh = "1";
                lang("en");
            }
            Properties.Settings.Default.Save();
            this.Controls.Clear();
            this.InitializeComponent();
            Load_items();
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;


        }

        private void btnChangeStore_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frm_Main" && f.Name != "login_frm")
                    f.Close();
            }

           frm_Main.OpenForm(new PL.frm_ChoseStore(),true);

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.C_year = cmbYear.Text;
            Properties.Settings.Default.Save();

        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            OpenFormByName("Frm_Config");
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            OpenFormByName(btnCofig.Tag.ToString());
        }

        private void office2007StartButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnCompanyData_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_CompanyData");
        }

        private void btnCofig_Click(object sender, EventArgs e)
        {
            OpenFormByName(btnCofig.Tag.ToString());
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {

        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_AddClient");
        }

        private void btnSalesQuotation_Click(object sender, EventArgs e)
        {
            OpenFormByName("frmQuotation");
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            OpenFormByName("frmSalesOrder");
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            OpenFormByName("frmDelivryNote");
        }

        private void btn_SalesInvoice_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.invoice_frm));

        }

        

        private void btnSalesRpt_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_rpt_Sales_by_Br");
        }

        private void btnSalesVatRpt_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_Export_sales");
        }

        private void btnItemQuery_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_check_item_Price_Copy");
        }

        private void btnClientTB_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_Customers_TB");
        }

        private void btnCashClientSalesRpt_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_CashCustomer_statment");
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_PurchaseInvoice");
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_PurchaseOrder_1");
        }

        private void btnVendors_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_AddVendor");
        }

        private void btnUpdateAccData_Click(object sender, EventArgs e)
        {
            OpenFormByName("UpdateAccData");
        }

        private void btnCoilReport_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_Rpt_Coils");
        }

        private void btnProductionRpt_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_rpt_Productin");
        }

       
        private void btnItems_Click(object sender, EventArgs e)
        {
            OpenFormByName("frmProducts");
        }

        private void btnInventoryRpt_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_Inventory_Report");
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_Item_Transaction");
        }

       
        private void btnBackup_Click(object sender, EventArgs e)
        {
            OpenFormByName("backup_Frm");
        }

        private void btnRestor_Click(object sender, EventArgs e)
        {
            OpenFormByName("restor_Frm");
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            OpenFormByName("frm_statment_Rpt");
        }

        private void btnDailyEntry_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frmJornal));
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frm_TB));
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frmAgeReport));
        }

        private void btnTransferAccountTransaction_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_Update_Classification));
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frmAcc));
        }

        private void btnClssification_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_Category));
        }

        private void btnReportDailyEntry_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frm_Daliy_rpt));
        }

        private void rb_Account_Click(object sender, EventArgs e)
        {

        }

        private void btnLanguh_Click(object sender, EventArgs e)
        {
            List<Form> formList = new List<Form>();
            foreach (Form openForm in (System.Collections.ReadOnlyCollectionBase)Application.OpenForms)
                formList.Add(openForm);
            foreach (Form form in formList)
            {
                if (form.Name != "frmMain" && form.Name != "login_frm")
                    form.Close();
            }
            string ietfLanguageTag = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;
            if (!(ietfLanguageTag == "ar"))
            {
                if (ietfLanguageTag == "en")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                    Properties.Settings.Default.lungh = "0";
                    btnLanguh.Text = "AR";
                }
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                Properties.Settings.Default.lungh = "1";
                btnLanguh.Text = "EN";
            }
            Properties.Settings.Default.Save();
            // this.Controls.Clear();
            // this.InitializeComponent();
            //// this.loadMenu();
            // this.WindowState = FormWindowState.Normal;
            // this.WindowState = FormWindowState.Maximized;
            Forms.frmMain.ActiveForm.Dispose();
            Forms.frmMain sd = new Forms.frmMain();
            sd.Show();


        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {

        }

        private void btnCashVoucher_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(CTR.frm_Cash_Receipt));
        }

        private void btnCashPaymentVoucher_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(CTR.frm_PettyCashPayment));
        }

        private void btnPurchaseReports_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frm_rpt_Purchases));
        }

        private void btnTaxPurchaseReports_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frm_Purchase_reports));
        }

        private void btnPoReport_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frm_rpt_Po));
        }

        private void buttonItem21_Click_1(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_close_purch_to_lc));
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_production));
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_ScanToPDF));
        }

        private void btn_AccessProfile_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_AccessProfile));
        }

        private void btn_AccessProfileList_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_AccessProfileList));
        }

        private void btn_UserSettingsProfile_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_UserSettingsProfile));
        }

        private void btn_UserSettingsProfileList_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_UserSettingsProfileList));
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_Users));
        }

        private void btn_UserList_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frm_UserList));
        }

        private void btn_AssetAdditions_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frmAssetAdditions));


        }

        private void btnUpdateInvoiceData_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_Update_invoiceData));
        }

        private void btnAssetes_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frmAssetes));

        }

        private void btn_AssetesGroup_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frmAssetesGroup));

        }

        private void btnCoilClose_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(Forms.frmCoileClose));

        }

        private void btnBankPaymentVoucher_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(CTR.frm_Bank_payment_voucher));
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_returnSales));
        }

        private void btnCoseStore_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != nameof(Forms.frmMain) && f.Name != nameof(RPT.login_frm))
                    f.Close();
            }

            OpenFormByName(nameof(PL.frm_ChoseStore));

        }

        private void btnBankDeposit_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(CTR.frm_BankDeposit));

        }

        private void btnChoseBranch_Click(object sender, EventArgs e)
        {

        }

        private void btnStores_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frmStores));

        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_Con_Invoice));

        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_Project));
        }

        private void btnInventoryReportByGroups_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(RPT.frm_Inventory_Report_ByGroup));
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_send_sms));

        }

        private void btn_Group_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.frm_Group));

        }

        private void btnDownpayment_Click(object sender, EventArgs e)
        {
            OpenFormByName(nameof(PL.invoice_frm_copy));

        }
    }
}
