
using CrystalDecisions.Shared;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
//using Microsoft.Office.Interop.Excel;

namespace Report_Pro.PL
{
    public partial class frm_samples : Form
    {
       
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        int currencyNo = 2;
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();

        DataTable dt_inv;
        DataTable dt_inv_total;



        public frm_samples()
        {
            InitializeComponent();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_getDataFromExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;
            int xlRow;
            string strfileName;
            OpenFileDialog obf = new OpenFileDialog();
            obf.Filter = "chose Excel File |*.xlsx;*.xls;*.xlm";
            obf.ShowDialog();
            strfileName = obf.FileName;
            if (strfileName != String.Empty)
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strfileName);
                xlWorksheet = xlWorkbook.Worksheets["Sheet1"];
                xlRange = xlWorksheet.UsedRange;
                int i = 0;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    i++;
                    dgv_Inv.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text, xlRange.Cells[xlRow, 6].Text);

                }
                
            }

        }
        private void dgv_Inv_DoubleClick(object sender, EventArgs e)
        {
            string inv_no = dgv_Inv.CurrentRow.Cells[0].Value.ToString();
            string brnch_code = dgv_Inv.CurrentRow.Cells[1].Value.ToString();
            string trans_code = dgv_Inv.CurrentRow.Cells[4].Value.ToString();
            string cyear = dgv_Inv.CurrentRow.Cells[3].Value.ToString();
            RPT.Form1 frm = new RPT.Form1();
            DataSet dataSet = new DataSet();
            getSalesInv(inv_no, brnch_code, trans_code, cyear);
            getInvoiceTotal(inv_no, brnch_code, trans_code, cyear);

            string code = "Alusaimi Steel " + System.Environment.NewLine + "Invoice No. :" + dgv_Inv.CurrentRow.Cells[0].Value.ToString() + System.Environment.NewLine + "Branch Code :" + dgv_Inv.CurrentRow.Cells[1].Value.ToString() + System.Environment.NewLine + "Total Value :" + dt_inv_total.Rows[0]["NetValue"] + System.Environment.NewLine + "VAT Value :" + dt_inv_total.Rows[0]["tax"];


            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap bmp = qRCode.GetGraphic(7);
            DataTable dQR = new DataTable();
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Bmp);

                byte[] byteImage = ms.ToArray();

                //picQR.Image = bmp;

                // RPT.QR_rpt rpt = new RPT.QR_rpt();
                dQR.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
                dQR.Rows.Add(byteImage);
            }



            dataSet.Tables.Add(dt_inv);
            dataSet.Tables.Add(dQR);
            //dataSet.WriteXmlSchema("schema_rpt.xml");


            if (trans_code == "XSD" || trans_code == "XSC")
            {
                RPT.Rpt_inv rptInv = new RPT.Rpt_inv();
                //RPT.print_PurchaseInv rptInv = new RPT.print_PurchaseInv();
                rptInv.SetDataSource(dataSet);
                rptInv.DataDefinition.FormulaFields["Branch_"].Text = "'" + dgv_Inv.CurrentRow.Cells[1].Value.ToString() + " - " + dgv_Inv.CurrentRow.Cells[2].Value.ToString() + "'";
                ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["NetValue"].ToString())), currencies[currencyNo]);
                rptInv.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";


                frm.crystalReportViewer1.ReportSource = rptInv;
            }
            else
            {
                // RPT.Rpt_inv rptInv = new RPT.Rpt_inv();
                RPT.print_PurchaseInv rptInv = new RPT.print_PurchaseInv();
                rptInv.SetDataSource(dataSet);
                rptInv.DataDefinition.FormulaFields["Branch_"].Text = "'" + dgv_Inv.CurrentRow.Cells[1].Value.ToString() + " - " + dgv_Inv.CurrentRow.Cells[2].Value.ToString() + "'";
                ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["NetValue"].ToString())), currencies[currencyNo]);
                rptInv.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";


                frm.crystalReportViewer1.ReportSource = rptInv;
            }

            frm.ShowDialog();

            //rptInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;

            //rptInv.PrintToPrinter(1, false, 0, 0);
            //rptInv.Close();
            //rptInv.Dispose();
        }


        private void getSalesInv(string ser_, string branch_, string transaction_, string cyear_)

        {
            dt_inv = this.dal.getDataTabl_1(@"select A.ser_no,A.Sanad_no,A.Branch_code,A.Cyear,A.Transaction_code,A.G_date,A.Acc_no,A.Payment_Type,A.Sales_man_Id,A.Inv_no,A.Inv_date,a.Inv_Notes,A.Phone,A.Adress,A.PROJECT_NO,A.Costmer_No,A.Cash_costomer_name,A.REQUIST_NO,A.Ref
            ,A.acc_serial_no,A.QUOT_REF_NO,A.QUOT_REF_DATE,A.SO_no,A.Po_no,A.DelevryE,A.TermsOfPaymentE,BankNo
            ,B.modular,B.VAT_RATIO,B.main_counter,B.DETAILS,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.Unit,B.Local_Price,isnull(B.TAX_IN,0)as TAX_IN ,isnull(B.TAX_OUT,0)as TAX_OUT , round(isnull(Nullif(b.total_disc,''),0)*QTY_TAKE/100,2) as disc_ ,B.Pice_Total_Cost,b.balance,B.K_M_TYPE_ITEMS,B.DeleveryNote
            ,p.PAYER_NAME,p.payer_l_name,P.Max_Sales_Am,P.CREDIT_AGE,p2.PAYER_NAME as lc_name ,p2.payer_l_name as lc_L_Name,P.adress,P.adress_E ,P.phone_no,P.fax_no,P.E_MAIL,P.COSTMER_K_M_NO, P.SEGEL_NO,P.ZAKAH_NO,
            M.descr,M.Descr_eng,m.Weight, br.branch_name,BR.Branch_Logo_Small ,BR.WH_E_NAME,Br.Branch_Logo_A4,PT.Payment_name,PT.Payment_name_E,U.unit_Description, U.unit_Description_E,cost.COST_name,cost.COST_E_NAME,SP.Payment_name,SP.Notes
            ,(select top 1 vat_ratio from VAT_RATIO_MASTER where cast(A.G_date as date ) between date_of_vat and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by date_of_vat desc) as VatRatio ,VAT.VAT_RATIO*100 as Acc_VatRAtio " +
            "from wh_inv_data As A " +
            "inner join wh_material_transaction As B on a.Ser_no = b.SER_NO and a.Cyear = b.Cyear and a.Transaction_code = b.TRANSACTION_CODE and a.Branch_code = b.Branch_code  " +
            "inner join payer2 As P on a.Acc_no = p.ACC_NO and a.Acc_Branch_code = p.BRANCH_code  " +
            "left join(select * from payer2)as p2 on p2.ACC_NO = a.LC_ACC_NO and a.Acc_Branch_code = p2.BRANCH_code  " +
            "inner join wh_main_master as M on M.item_no=B.ITEM_NO  " +
            "inner join wh_BRANCHES As BR on BR.Branch_code = a.Branch_code  " +
            "inner join wh_Payment_type as PT on A.Payment_Type=PT.Payment_type  " +
            "left join  Wh_Unit as U on U.Wh_Unit = B.unit " +
            "left join Sal_Pyment_type As SP on SP.Payment_type = A.TermsOfPaymentE " +
            "inner join  COST_CENTER as cost on cost.COST_CODE = A.Sales_man_Id " +
            "inner join VAT_ACC as VAT on VAT.VAT_ID = isnull(A.MAIN_KM_CODE,11)" +
            "where a.SER_NO = '" + ser_ + "' and a.Transaction_code = '" + transaction_ + "' and a.Branch_code = '" + branch_ + "' and a.Cyear = '" + cyear_ + "'");
        }



    //    private void getSalesInv(string ser_, string branch_, string transaction_, string cyear_)

    //    {
    //        dt_inv = this.dal.getDataTabl_1(@"select A.ser_no,A.Branch_code,A.Cyear,A.Transaction_code,A.G_date,A.Acc_no,A.Payment_Type,A.Sales_man_Id,A.Inv_no,A.Inv_date,a.Inv_Notes,A.Phone,
    //        B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.Unit,B.Local_Price,isnull(B.TAX_IN,0)as TAX_IN ,isnull(B.TAX_OUT,0)as TAX_OUT , round(b.total_disc*B.local_price*QTY_TAKE/100,2) as disc_ ,p.PAYER_NAME,p.payer_l_name,p2.PAYER_NAME as lc_name ,p2.payer_l_name as lc_L_Name,
    //        m.descr,m.Descr_eng, br.branch_name,BR.WH_E_NAME,PT.Payment_name 
    //        ,(select top 1 vat_ratio from VAT_RATIO_MASTER where cast(A.G_date as date ) between date_of_vat and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by date_of_vat desc) as VatRatio " +
    //        "from wh_inv_data As A " +
    //        "inner join wh_material_transaction As B on a.Ser_no = b.SER_NO and a.Cyear = b.Cyear and a.Transaction_code = b.TRANSACTION_CODE and a.Branch_code = b.Branch_code  " +
    //        "inner join payer2 As P on a.Acc_no = p.ACC_NO and a.Acc_Branch_code = p.BRANCH_code  " +
    //        "left join(select* from payer2)as p2 on p2.ACC_NO = a.LC_ACC_NO and a.Acc_Branch_code = p2.BRANCH_code  " +
    //        "inner join wh_main_master as M on M.item_no = b.ITEM_NO  " +
    //        "inner join wh_BRANCHES As BR on BR.Branch_code = a.Branch_code  " +
    //        "inner join wh_Payment_type as PT on A.Payment_Type=PT.Payment_type  " +
    //        "where a.SER_NO = '" + ser_ + "' and a.Transaction_code = '" + transaction_ + "' and a.Branch_code = '" + branch_ + "' and a.Cyear = '" + cyear_ + "'");
    //    }
    ////    (select case when B.K_M_TYPE_ITEMS =1 and CAST(B.G_DATE as date ) between '2018-01-01' and '2020-06-30'   then 5  when B.K_M_TYPE_ITEMS =1 and CAST(B.G_DATE as date ) > '2020-06-30' then 15  else 0 end)as VatRatio

        private void getInvoiceTotal(string ser_, string branch_, string transaction_, string cyear_)
        {
            dt_inv_total = dal.getDataTabl_1(@"select round(sum(b.QTY_TAKE*Local_Price),2) as TotalValue
            , round(sum(b.total_disc * B.local_price * QTY_TAKE / 100), 2) as discount
            , round(sum(isnull(b.TAX_OUT, 0)), 2) as tax
            , round(sum(b.QTY_TAKE * Local_Price), 2) - round(sum(b.total_disc * B.local_price * QTY_TAKE / 100), 2) + round(sum(isnull(b.TAX_OUT, 0)), 2) as NetValue
            , round(sum(b.QTY_ADD * Local_Price), 2) - round(sum(b.total_disc * B.local_price * QTY_ADD / 100), 2) + round(sum(isnull(b.TAX_IN, 0)), 2) as NetValuePurch 
            from wh_material_transaction as b
            where b.SER_NO = '" + ser_ + "'  and b.Transaction_code = '" + transaction_ + "' and b.Branch_code = '" + branch_ + "' and b.Cyear = '" + cyear_ + "'  " +
            "group by TRANSACTION_CODE,Branch_code,Cyear,SER_NO");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            dgv1.Rows.Clear();
            dgv_Inv.Visible = false;
            dgv1.Visible = true;

            //try
            //{
                for (int i = 0; i < dgv_Inv.Rows.Count; i++)
                {
                    string _ser = dgv_Inv.Rows[i].Cells[0].Value.ToString();
                    string _branch = dgv_Inv.Rows[i].Cells[1].Value.ToString();
                    string _year = dgv_Inv.Rows[i].Cells[3].Value.ToString();
                    string _transaction = dgv_Inv.Rows[i].Cells[4].Value.ToString();
                    DataTable dt_s = dal.getDataTabl_1(@"SELECT A.Ser_no,A.Transaction_code,A.Branch_code,A.Cyear,A.G_date,A.Payment_Type,
                T.INV_NAME, A.Inv_no, A.Inv_date, A.acc_serial_no, p.PAYER_NAME, p.payer_l_name,
                B.branch_name, C.Payment_name, A.Acc_no,D.unit, sum(D.QTY_TAKE - D.QTY_ADD) As Qty
                , ROUND(sum((D.QTY_TAKE - D.QTY_ADD) * D.Local_Price) - sum(((D.QTY_TAKE - D.QTY_ADD) * D.Local_Price * D.total_disc) / 100), 2) AS Value
                , sum(D.TAX_OUT) - sum(D.TAX_IN) As Vat
                ,A.po_no
                FROM wh_inv_data as A
                INNER JOIN payer2 As P ON A.Acc_no = P.ACC_NO AND A.Acc_Branch_code = P.BRANCH_code
                INNER JOIN wh_BRANCHES As B ON A.Branch_code = B.Branch_code
                INNER JOIN wh_Payment_type As C ON A.Payment_Type = C.Payment_type
                INNER JOIN wh_material_transaction As D ON A.Ser_no = D.SER_NO
                AND A.Branch_code = D.Branch_code AND A.Transaction_code = D.TRANSACTION_CODE AND A.Cyear = D.Cyear
                inner join WH_INV_TYPE As T  on T.INV_CODE = A.Transaction_code


                WHERE A.Transaction_code = '" + _transaction + "'  and A.Branch_code = '" + _branch + "' and A.Cyear='" + _year + "' and  A.Ser_no='" + _ser +
                    "' group by    A.Ser_no, A.Transaction_code, A.Branch_code,A.Cyear, A.G_date, A.Payment_Type, A.Inv_no," +
                    "A.Inv_date, A.acc_serial_no, P.PAYER_NAME, B.branch_name, C.Payment_name, A.Acc_no," +
                    "T.INV_NAME, p.payer_l_name,A.po_no,D.unit");

                   // dgv1.DataSource = dt_s;
                    dgv1.Rows.Add(dt_s.Rows[0]["Ser_no"].ToString(), dt_s.Rows[0]["Branch_code"].ToString(), dt_s.Rows[0]["branch_name"].ToString(), dt_s.Rows[0]["Cyear"].ToString(), dt_s.Rows[0]["Transaction_code"].ToString(), dt_s.Rows[0]["INV_NAME"].ToString(), dt_s.Rows[0]["po_no"].ToString());
                   // i++;

                }

            //}
            //catch (Exception)
            //{

                
            //}
            

        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            string inv_no = dgv1.CurrentRow.Cells[0].Value.ToString();
            string brnch_code = dgv1.CurrentRow.Cells[1].Value.ToString();
            string trans_code = dgv1.CurrentRow.Cells[4].Value.ToString();
            string cyear = dgv1.CurrentRow.Cells[3].Value.ToString();
            RPT.Form1 frm = new RPT.Form1();
            DataSet dataSet = new DataSet();
            getSalesInv(inv_no, brnch_code, trans_code, cyear);
            getInvoiceTotal(inv_no, brnch_code, trans_code, cyear);

            string code = "Alusaimi Steel " + System.Environment.NewLine + "Invoice No. :" + dgv1.CurrentRow.Cells[0].Value.ToString() + System.Environment.NewLine + "Branch Code :" + dgv1.CurrentRow.Cells[1].Value.ToString() + System.Environment.NewLine + "Total Value :" + dt_inv_total.Rows[0]["NetValue"] + System.Environment.NewLine + "VAT Value :" + dt_inv_total.Rows[0]["tax"];


            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap bmp = qRCode.GetGraphic(7);
            DataTable dQR = new DataTable();
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Bmp);

                byte[] byteImage = ms.ToArray();

                //picQR.Image = bmp;

                // RPT.QR_rpt rpt = new RPT.QR_rpt();
                dQR.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
                dQR.Rows.Add(byteImage);
            }



            dataSet.Tables.Add(dt_inv);
            dataSet.Tables.Add(dQR);
            //dataSet.WriteXmlSchema("schema_rpt.xml");


            if (trans_code == "XSD" || trans_code == "XSC")
            {
                RPT.Rpt_inv rptInv = new RPT.Rpt_inv();
                //RPT.print_PurchaseInv rptInv = new RPT.print_PurchaseInv();
                rptInv.SetDataSource(dataSet);
                rptInv.DataDefinition.FormulaFields["Branch_"].Text = "'" + dgv1.CurrentRow.Cells[1].Value.ToString() + " - " + dgv1.CurrentRow.Cells[2].Value.ToString() + "'";
                ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["NetValue"].ToString())), currencies[currencyNo]);
                rptInv.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";


                frm.crystalReportViewer1.ReportSource = rptInv;
            }
            else
            {
                // RPT.Rpt_inv rptInv = new RPT.Rpt_inv();
                RPT.print_PurchaseInv rptInv = new RPT.print_PurchaseInv();
                rptInv.SetDataSource(dataSet);
                rptInv.DataDefinition.FormulaFields["Branch_"].Text = "'" + dgv1.CurrentRow.Cells[1].Value.ToString() + " - " + dgv1.CurrentRow.Cells[2].Value.ToString() + "'";
                ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["NetValue"].ToString())), currencies[currencyNo]);
                rptInv.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";


                frm.crystalReportViewer1.ReportSource = rptInv;
            }

            frm.ShowDialog();

            //rptInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;

            //rptInv.PrintToPrinter(1, false, 0, 0);
            //rptInv.Close();
            //rptInv.Dispose();
        }

        private void frm_samples_Load(object sender, EventArgs e)
        {
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Syria));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.S));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Tunisia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Gold));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Bahrain));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Oman));
            string currency = Properties.Settings.Default.Currency;
            if (!(currency == "s"))
            {
                if (!(currency == "BH"))
                {
                    if (!(currency == "OM"))
                    {
                        if (!(currency == "DR"))
                            return;
                        currencyNo = 1;
                    }
                    else
                        currencyNo = 6;
                }
                else
                    currencyNo = 5;
            }
            else
                currencyNo = 2;

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportToBdf_Click(object sender, EventArgs e)
        {
            exportInvoicesToBDF();
        }

        private void exportInvoicesToBDF()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            string selectedPath = folderBrowserDialog.SelectedPath;

            for (int i = 0; i < dgv_Inv.Rows.Count; ++i)
            {
                if (dgv_Inv.Rows[i].Cells[_colSer.Name].FormattedValue.ToString() != string.Empty && dgv_Inv.Rows[i].Cells[_colBranch.Name].FormattedValue.ToString() != string.Empty
                    && dgv_Inv.Rows[i].Cells[_colTransaction.Name].FormattedValue.ToString() != string.Empty && dgv_Inv.Rows[i].Cells[_colYear.Name].FormattedValue.ToString() != string.Empty)
                {
                    string ser_1 = dgv_Inv.Rows[i].Cells[_colSer.Name].FormattedValue.ToString();
                    string text1 = dgv_Inv.Rows[i].Cells[_colBranch.Name].FormattedValue.ToString();
                    string text2 = dgv_Inv.Rows[i].Cells[_colTransaction.Name].FormattedValue.ToString();
                    string cyear_1 = dgv_Inv.Rows[i].Cells[_colYear.Name].FormattedValue.ToString();


                    if (dgv_Inv.Rows[i].Cells[_colTransaction.Name].FormattedValue.ToString() == "xpc")
                    {
                        RPT.print_PurchaseInv printPurchaseInv = new RPT.print_PurchaseInv();
                        Form1 form1 = new Form1();
                        DataSet dataSet = new DataSet();

                        getSalesInv(ser_1, text1, text2, cyear_1);
                        dataSet.Tables.Add(dt_inv);
                        //dataSet.WriteXmlSchema("schema_rpt.xml");
                        printPurchaseInv.SetDataSource(dataSet);
                        printPurchaseInv.DataDefinition.FormulaFields["Branch_"].Text = "'" + dgv_Inv.Rows[i].Cells[_colBranch.Name].FormattedValue.ToString() + " - " + dgv_Inv.Rows[i].Cells[_colBranchName.Name].FormattedValue.ToString() + "'";

                        getInvoiceTotal(ser_1, text1, text2, cyear_1);
                        ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(this.dt_inv_total.Rows[0]["NetValuePurch"].ToString())), this.currencies[this.currencyNo]);
                        printPurchaseInv.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                        string str = dgv_Inv.Rows[i].Cells[_colTransaction.Name].FormattedValue.ToString() + " - " + dgv_Inv.Rows[i].Cells[_colSer.Name].FormattedValue.ToString();
                        printPurchaseInv.ExportToDisk(ExportFormatType.PortableDocFormat, folderBrowserDialog.SelectedPath + "\\" + str + ".pdf");
                        printPurchaseInv.Close();
                        printPurchaseInv.Dispose();
                    }
                    else
                    {


                        DataSet ds = new DataSet();
                        RPT.frm_Rpt_Pro_Frm frminv = new RPT.frm_Rpt_Pro_Frm();


                        getSalesInv(ser_1, text1, text2, cyear_1);

                        string printModel = Properties.Settings.Default.inv_print;


                        getInvoiceTotal(ser_1, text1, text2, cyear_1);
                        ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["NetValue"].ToString())), currencies[currencyNo]);

                        DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp where company_no = left('" + text1 + "',1)");

                        string vat_no = dt_Co.Rows[0]["Comp_Vat_no"].ToString();
                        string Co_Name = dt_Co.Rows[0]["Company_e_name"].ToString();
                        string invDate = Convert.ToDateTime(dt_inv.Rows[0]["G_date"]).ToString("yyyy-MM-dd hh:mm:ss");
                        string TotalInv = dt_inv_total.Rows[0]["NetValue"].ToString().ToDecimal().ToString("N2");
                        string TotalTax = dt_inv_total.Rows[0]["tax"].ToString();

                        PictureBox pic_ = new PictureBox();
                        dal.pic1 = pic_;
                        dal.GetImsge(Co_Name, vat_no, invDate, TotalInv, TotalTax);

                        DataTable dQR = new DataTable();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic_.Image.Save(ms, ImageFormat.Bmp);

                            byte[] byteImage = ms.ToArray();
                            dQR.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
                            dQR.Rows.Add(byteImage);
                        }



                        ds.Tables.Add(dt_inv);
                        ds.Tables.Add(dQR);
                        ds.Tables.Add(dt_Co);
                        ds.WriteXmlSchema("schema_rpt.xml");
                        string str = dgv_Inv.Rows[i].Cells[_colTransaction.Name].FormattedValue.ToString() + " " + dgv_Inv.Rows[i].Cells[_colSer.Name].FormattedValue.ToString();
                        if (Program.PrintMode == "1") //english
                        {
                            RPT.Rpt_sales_Invoice_Portrait_total reportInv = new RPT.Rpt_sales_Invoice_Portrait_total();
                            reportInv.SetDataSource(ds);
                            reportInv.DataDefinition.FormulaFields["decimal_"].Text = "'" + Properties.Settings.Default.digitNo_ + "'";
                            reportInv.DataDefinition.FormulaFields["Currency_"].Text = "'" + Properties.Settings.Default.Currency + "'";
                            reportInv.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, folderBrowserDialog.SelectedPath + "\\" + str + ".pdf");
                            reportInv.Close();
                            reportInv.Dispose();
                        }

                        else if (Program.PrintMode == "3") // both

                        {
                            RPT.Rpt_sales_Invoice_2 reportInv = new RPT.Rpt_sales_Invoice_2();
                            reportInv.SetDataSource(ds);

                            reportInv.ExportToDisk(ExportFormatType.PortableDocFormat, folderBrowserDialog.SelectedPath + "\\" + str + ".pdf");
                            reportInv.Close();
                            reportInv.Dispose();

                        }
                        else

                        {
                            RPT.Rpt_sales_Invoice_2 reportInv = new RPT.Rpt_sales_Invoice_2();
                            reportInv.DataDefinition.FormulaFields["tafqeet"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                            reportInv.DataDefinition.FormulaFields["tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                            reportInv.SetDataSource(ds);

                            reportInv.ExportToDisk(ExportFormatType.PortableDocFormat, folderBrowserDialog.SelectedPath + "\\" + str + ".pdf");
                            reportInv.Close();
                            reportInv.Dispose();
                        }
                    }
                }
            }
            int num2 = (int)MessageBox.Show("Invoices was Exprted ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }



    }
}
