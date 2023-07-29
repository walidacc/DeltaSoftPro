using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Report_Pro.PL
{
    public partial class frm_Con_Invoice : frm_Master
    {
        bool IsNew;

        string btntype = "0";
        Int32 m;
        //string Jor_no;
        string btn_name;
        decimal old_balance, old_cost, new_balance, new_cost;
        Dates date_ = new Dates();
        DataTable dt_inv;
        DataTable dt_inv_total;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();
        int currencyNo = 2;
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();




        public frm_Con_Invoice()
        {

            InitializeComponent();


          


            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranch_Id.Text = Properties.Settings.Default.BranchId;
            txt_InvSM.Text = Program.salesman;
            userID.Text = Program.userID;
          
            Payment_Type.DataSource = dal.getDataTabl_1("SELECT * FROM wh_Payment_type");

            if (Properties.Settings.Default.lungh == "0")
            {
                Payment_Type.DisplayMember = "Payment_name";
            }
            else
            {
                Payment_Type.DisplayMember = "Payment_name";
            }
            Payment_Type.ValueMember = "Payment_type";
            Payment_Type.SelectedIndex = -1;

            

            cmb_Pay.DataSource = dal.getDataTabl_1("SELECT * FROM pay_method");
            if (Properties.Settings.Default.lungh == "0")
            {
                cmb_Pay.DisplayMember = "Pay_name";
            

            }
            else
            {
                cmb_Pay.DisplayMember = "Pay_name_E";
              
            }
            cmb_Pay.ValueMember = "Pay_ID";
            cmb_Pay.SelectedIndex = -1;
           

            cmb_Bank.DataSource = dal.getDataTabl_1("SELECT * FROM SHEEK_BANKS_TYPE");

            if (Properties.Settings.Default.lungh == "0")
            {
                cmb_Bank.DisplayMember = "BANK_NAME";
            }
            else
            {
                cmb_Bank.DisplayMember = "BANK_NAME";
            }
            cmb_Bank.ValueMember = "BANK_NO";
            cmb_Bank.SelectedIndex = -1;


            M_Doc_Type.Text = "XS";

        }





  


      



     





        private void txt_InvNot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                //Btn_srch_cust.Focus();
            }
        }





        private void get_invSer()
        {
            //try
            //{
                DataTable dt_ser = 
                dt_ser = dal.getDataTabl_1(@"select isnull(XS+1,1)As xs_ser,isnull(XSD+1,1)As xsd_ser
                ,isnull(XSC+1,1) As xsc_ser,isnull(XSR+1,1)As xsr_ser,isnull(XST+1,1) As xst_ser 
                from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txt_InvDate.Value.Date.ToString("yy") + "'");
            if (dt_ser.Rows.Count > 0)
            {
                txtMainSer.Text = dt_ser.Rows[0]["xs_ser"].ToString();
                if (Convert.ToString(Payment_Type.SelectedValue) == "2")
                {
                    Doc_Type.Text = "XSD";
                    txt_InvNu.Text = dt_ser.Rows[0]["xsd_ser"].ToString();
                }
                else if (Convert.ToString(Payment_Type.SelectedValue) == "11" || Convert.ToString(Payment_Type.SelectedValue) == "12")
                {
                    Doc_Type.Text = "XSC";
                    txt_InvNu.Text = dt_ser.Rows[0]["xsc_ser"].ToString();

                }
            }
            else
            {
                txtMainSer.Text = "1";
                if (Convert.ToString(Payment_Type.SelectedValue) == "2")
                {
                    Doc_Type.Text = "XSD";
                    txt_InvNu.Text = "1";
                }
                else if (Convert.ToString(Payment_Type.SelectedValue) == "11" || Convert.ToString(Payment_Type.SelectedValue) == "12")
                {
                    Doc_Type.Text = "XSC";
                    txt_InvNu.Text = "1";

                }

            }


        }


       private void getAccSer()
        {
            DataTable dt_AccSer = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) as main_daily_ser ,isnull(daily_sn_ser+1,1) as daily_sn_ser  from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchId
            + "' and ACC_YEAR= '" + acc_year.Text + "' ");//.PadLeft(4, '0');
            if (dt_AccSer.Rows.Count > 0)
            {
                AccSer_No.Text = dt_AccSer.Rows[0]["main_daily_ser"].ToString();
                Main_AccSer_No.Text = dt_AccSer.Rows[0]["daily_sn_ser"].ToString();
            }
            else
            {
                dal.Execute_1(@"INSERT INTO serial_no (ACC_YEAR,BRANCH_CODE)
     VALUES ('" + acc_year.Text + "','" + Properties.Settings.Default.BranchId + "')");
                AccSer_No.Text = "1";
                Main_AccSer_No.Text = "1";
            }
        }

        private void Payment_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_invSer();
           // total_inv();
        }

       


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BNew_Click(object sender, EventArgs e)
        {

            _new();
            
        }

        public override void New()
        {
            _new();
            base.New();
        }

        public override void Print()
        {

            DataSet dataSet = new DataSet();

            RPT.Rpt_Pro_Frm frminv = new RPT.Rpt_Pro_Frm();
            getSalesInv(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
            //DataTable dt_1 = dal.getDataTabl("get_invDetails", txt_InvNu.Text, Doc_Type.Text, txt_InvDate.Value.Year.ToString(), Properties.Settings.Default.BranchId);

            string printModel = Properties.Settings.Default.inv_print;

            getInvoiceTotal(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
            ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["netDue"].ToString())), currencies[currencyNo]);


            DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp");


            string vat_no = dt_Co.Rows[0]["Comp_Vat_no"].ToString();
            string Co_Name = dt_Co.Rows[0]["Company_e_name"].ToString();
            string invDate = txt_InvDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
            string TotalInv = dt_inv_total.Rows[0]["NetValue"].ToString().ToDecimal().ToString("0.00");
            string TotalTax = dt_inv_total.Rows[0]["tax"].ToString().ToDecimal().ToString("0.00");

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


            dataSet.Tables.Add(dt_inv);
            dataSet.Tables.Add(dQR);
            dataSet.Tables.Add(dt_Co);
            dataSet.WriteXmlSchema("schema_rpt.xml");

            if (printModel == "1")
            {
                RPT.Rpt_Contract_Invoice_1 reportInv = new RPT.Rpt_Contract_Invoice_1();
                reportInv.SetDataSource(dataSet);
                reportInv.DataDefinition.FormulaFields["tafqeet_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                reportInv.DataDefinition.FormulaFields["tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }

            else

            {
                RPT.Rpt_Contract_Invoice_1 reportInv = new RPT.Rpt_Contract_Invoice_1();
                reportInv.SetDataSource(dataSet);
                reportInv.DataDefinition.FormulaFields["tafqeet_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                reportInv.DataDefinition.FormulaFields["tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }

            base.Print();
        }

        public override void Attachment()
        {
            DataTable dt_ = dal.getDataTabl_1(@"select ser_no from wh_inv_Data where Ser_no= '" + txt_InvNu.Text + "' and Cyear ='" + txtcyear.Text + "' and Branch_code = '" + txtStore_ID.Text + "'and transaction_code='"+ Doc_Type.Text+"'");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = txt_InvNu.Text;
                frmUpload.docType = Doc_Type.Text;
                frmUpload.branchID = txtStore_ID.Text;
                frmUpload.ShowDialog();
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            base.Attachment();
        }


        private void _new()
        {
            btntype = "0";
            dal.ClearTextBoxes(this);
            get_invSer();
            tabControlPanel1.Enabled = true;
            tabControlPanel2.Enabled = true;
            tabControlPanel3.Enabled = true;
            dt.Clear();
            BSave.Enabled = true;
            Payment_Type.Enabled = true;
            txtcyear.Text = Properties.Settings.Default.C_year;
            txt_InvNot.Focus();
            IsNew = true;

        }

        bool IsGridValid()
        {

            int countR = 0;

            foreach (MyControls.Con_Inv_Row c in inv_Grid1.flowLayoutPanel1.Controls)
            {
                if (c.txt_Code.Text != String.Empty && c.qty.Value > 0 && c.TxtPrice.Value > 0)
                {
                    countR++;
                }

            }
            if (countR > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgError") + " No Items", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }



        public override void Save()
        {

            if (Uc_Customer.ID.Text == string.Empty)
            {
                MessageBox.Show("فضلا.. تاكد من اختيار العميل ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (Payment_Type.SelectedIndex < 0)
            {
                MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inv_Grid1.txtNetTotal.Text.ToDecimal() <= 0)
            {
                MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }





            if (Convert.ToString(Payment_Type.SelectedValue) == "11")
            {
                if (cmb_Pay.SelectedIndex < 0)
                {
                    MessageBox.Show("فضلا.. تاكد من طريقة السداد", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cashCustomer.Desc.Text.Replace(" ", string.Empty) == "")
                {
                    MessageBox.Show("تأكد من اسم العميل النقدي", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



            }


            if (IsGridValid() == false)
            {
                return;
            }

            if (IsNew == true)
            {
                addInvoice();
            }
            else if (IsNew == false)
            {
                UpdateInvoice();
            }



            base.Save();    
        }

        private void BSave_Click(object sender, EventArgs e)
        {

            
                if (Uc_Customer.ID.Text == string.Empty)
                {
                    MessageBox.Show("فضلا.. تاكد من اختيار العميل ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            

                if (Payment_Type.SelectedIndex < 0)
                {
                    MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (inv_Grid1.txtNetTotal.Text.ToDecimal() <= 0)
                {
                    MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               



                if (Convert.ToString(Payment_Type.SelectedValue) == "11")
                {
                    if (cmb_Pay.SelectedIndex < 0)
                    {
                        MessageBox.Show("فضلا.. تاكد من طريقة السداد", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cashCustomer.Desc.Text.Replace(" ", string.Empty) == "")
                    {
                        MessageBox.Show("تأكد من اسم العميل النقدي", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }



                }


                if (IsGridValid() == false)
                {
                    return;
                }

            if (IsNew == true)
            {
                addInvoice();
            }
            else if (IsNew == false)
            {
                UpdateInvoice();
            }


         

            }
    



        private void addInvoice()
        {

                dal.Execute_1(@"iF NOT EXISTS " +
                 "(select Branch_code,Cyear  from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txtcyear.Text + "') BEGIN INSERT INTO wh_Serial (Branch_code,Cyear) VALUES('" + txtStore_ID.Text + "','" + txt_InvDate.Value.Date.ToString("yy") + "') end");



                if (Convert.ToString(Payment_Type.SelectedValue) == "2")
                {
                    Doc_Type.Text = "XSD";
                    txt_InvNu.Text = dal.getDataTabl_1(@"select isnull(XSD+1,1) from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txtcyear.Text + "'").Rows[0][0].ToString();
                }
                else if (Convert.ToString(Payment_Type.SelectedValue) == "11" || Convert.ToString(Payment_Type.SelectedValue) == "12")
                {
                    Doc_Type.Text = "XSC";
                    txt_InvNu.Text = dal.getDataTabl_1(@"select isnull(XSC+1,1) from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txtcyear.Text + "'").Rows[0][0].ToString();

                }

                get_invSer();
                getAccSer();


               // string cyear = txt_InvDate.Value.Year.ToString("yy");
                string H_Date = date_.GregToHijri(txt_InvDate.Text);


                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;

                try
                {
                cmd.CommandText = @"insert into wh_inv_data (Ser_no, Branch_code, Transaction_code, Cyear, Sanad_no, G_date, ACC_TYPE, Acc_no,
                 Acc_Branch_code, Payment_Type, Sales_man_Id, acc_serial_no, Po_no, User_id, NetAmount, PanyedAmount,
                 Cash_costomer_name, total_cost, Inv_Notes, Costmer_No, Phone, Adress, K_M_ACC_NO, K_M_Credit_TAX,
                 K_M_Debit_TAX, COSTMER_K_M_NO, K_M_SER, KM_CODE_ACC, MAIN_KM_CODE,PROJECT_NO,Ref,REQUIST_NO,Qutation_No,
                Dowen_Payment_acc_no,Dowen_Payment,Dowen_Payment_Vat,Sales_Vat,Dowen_Payment_Ratio,Guarantee_Acc,Guarantee_Ratio,Guarantee_Amount)
                 values('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text +
                    "', '" + txtcyear.Text + "' ,'" + txtMainSer.Text +
                    "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','A', '" + Uc_Customer.ID.Text +
                    "', '" + txtBranch_Id.Text + "', '" + Convert.ToString(Payment_Type.SelectedValue) +
                    "', '" + Uc_Cost.ID.Text + "', '" + AccSer_No.Text + "', '" + Po_No.Text + "' , '" + userID.Text +
                    "', '" + inv_Grid1.txtNetTotal.Text.ToDecimal() + "', '" + inv_Grid1.paied_amount.Text.ToDecimal() +
                    "', '" + cashCustomer.Desc.Text + "', '0', '" + txt_InvNot.Text + "', '" + cashCustomer.ID.Text +
                    "', '" + txt_custTel.Text + "', '" + txt_address.Text + "', '" + Vat_acc.Text + "', '" + inv_Grid1.txtTotalVAT.Text.ToDecimal() +
                    "', '0', '" + Cust_Vat_No.Text + "', '0','" + txtKmCode.Text + "','" + Vat_Class.Text + "','" + Uc_Project.ID.Text +
                    "','" + txt_Refrance.Text + "','" + Po_No.Text + "','" + txt_Qutation.Text + "','" + txt_DP_Acc.ID.Text + "','" + inv_Grid1.txt_DP_Disc.Text.ToDecimal() +
                    "','" + inv_Grid1.txtDPVat.Text.ToDecimal() + "','" + inv_Grid1.txtSalesVat.Text.ToDecimal() + "','" + txt_DP_Ratio.Text.ToDecimal() +
                    "','" + txt_G_Acc.ID.Text + "','" + txt_G_Ratio.Text.ToDecimal() + "','" + inv_Grid1.txtGrDiscount.Text.ToDecimal()+"')";

                    cmd.ExecuteNonQuery();


                    foreach (MyControls.Con_Inv_Row r in inv_Grid1.flowLayoutPanel1.Controls)
                    {

                        if (r.txt_Code.Text != string.Empty && r.qty.Value > 0 && r.TxtPrice.Value > 0)
                        {
                            cmd.CommandText = @" insert into wh_MATERIAL_TRANSACTION (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO,ITEM_NO,QTY_ADD,QTY_TAKE,total_disc,DISC_R,DISC_R2,DISC_R3,
                        G_DATE,Unit,Local_Price,USER_ID,main_counter,balance,Store_Code,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,modular,DP_Ratio,DP_Amount,VAT_RATIO) 
                       values( '" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + txtcyear.Text +
                            "' ,'" + txtMainSer.Text + "','" + r.txt_Code.Text + "' ,'0','" +
                           r.qty.Text + "','" + ((r.TxtDisc.Text.ToDecimal() / r.txt_subTOt.Text.ToDecimal()) + inv_Grid1.disc_Rate.Text.ToDecimal()) * 100 +
                            "' ,'" + (r.TxtDisc.Text.ToDecimal() / r.txt_subTOt.Text.ToDecimal()) * 100 + "' ,'0','" + (inv_Grid1.disc_Rate.Text.ToDecimal()) * 100 +
                            "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Convert.ToString(r.txtUnit.SelectedValue) +
                            "' ,'" + r.TxtPrice.Text.ToDecimal() + "' , '" + userID.Text + "','" +
                            inv_Grid1.flowLayoutPanel1.Controls.GetChildIndex(r) + "', '" + r.qty.Text.ToDecimal() + "', '" + txtStore_ID.Text +
                           "','" + r.KM_TYPE_ITEMS.Text + "' ,'0','" + r.VatValue.Text.ToDecimal() + "','" + r.txtNote.Text + "','" + r.txt_DP_Ratio.Value + "','" + r.TxtDisc.Value + "','" + r.VatRate.Value + "')";

                            cmd.ExecuteNonQuery();

                        }

                    }



                    cmd.CommandText = @"UPDATE  wh_Serial SET " + Doc_Type.Text.ToString() + "= '" + txt_InvNu.Text + "'," + M_Doc_Type.Text.ToString() + "= '" + txtMainSer.Text + "'  WHERE Branch_code = '" + txtStore_ID.Text + "' and Cyear='" + txtcyear.Text + "' ";
                    cmd.ExecuteNonQuery();

                string arabicDesc, englishDesc;
                if (Payment_Type.SelectedValue.ToString() == "2")
                {

                    arabicDesc = "فاتورة مبيعات آجل رقم " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " طلب شراء " + Po_No.Text : "");
                    englishDesc = "Credit Sales Invoice No " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " PO " + Po_No.Text : "");
                }
                else
                {
                    arabicDesc = "فاتورة مبيعات نقدي رقم " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " طلب شراء " + Po_No.Text : "");
                    englishDesc = "Cash Sales Invoice No " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " PO " + Po_No.Text : "");
                }

                cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + Uc_Customer.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + inv_Grid1.txtNetDue.Text + "','" + 0 + "','" + inv_Grid1.txtNetDue.Text + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + englishDesc + "')";
                    cmd.ExecuteNonQuery();

                if (inv_Grid1.txtGrDiscount.Text.ToDecimal() > 0)
                {
                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + txt_G_Acc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
               Uc_Cost.ID.Text + "','" + inv_Grid1.txtGrDiscount.Text + "','" + 0 + "','" + inv_Grid1.txtGrDiscount.Text + "','" + H_Date + "','" +
               txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
               userID.Text + "','" + "ضمان اعمال  " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
               txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + "Guarantee " + englishDesc + "')";
                    cmd.ExecuteNonQuery();
                }


                cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                 balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + txtAcc2_ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + 0 + "','" + inv_Grid1.txt_SubTot.Text.ToDecimal() + "','" + -inv_Grid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','"+englishDesc+"')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + Vat_acc.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + 0 + "','" + inv_Grid1.txtSalesVat.Text.ToDecimal() + "','" + -inv_Grid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + "ضريبة  " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" +"VAT "+ englishDesc + "')";
                    cmd.ExecuteNonQuery();

                    if (inv_Grid1.txt_DP_Disc.Text.ToDecimal() > 0)
                    {
                        cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txt_DP_Acc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                        Uc_Cost.ID.Text + "','" + inv_Grid1.txt_DP_Disc.Text.ToDecimal() + "','0','" + -inv_Grid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
                        txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                        userID.Text + "','" + "خصم دفعة مقدمة " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                        txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + "Down Payment Discount " + englishDesc + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + Vat_acc.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + inv_Grid1.txtDPVat.Text.ToDecimal() + "','0','" + -inv_Grid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + "خصم ضريبة دفعة مقدمة " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','"+ "Down Payment VAT Discount "+englishDesc+"'  )";
                        cmd.ExecuteNonQuery();


                    }



                    cmd.CommandText = @"UPDATE serial_no SET daily_sn_ser='" + Main_AccSer_No.Text + "' , main_daily_ser = '" + AccSer_No.Text + "' WHERE BRANCH_CODE=  '" + txtBranch_Id.Text + "' and ACC_YEAR='" + acc_year.Text + "' ";
                    cmd.ExecuteNonQuery();





                    trans.Commit();
                    MessageBox.Show("Data was saved ---- تم حفظ البيانات ", "Save --- حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);




                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dal.sqlconn_1.Close();
                }


            



        }



        private void UpdateInvoice()
        {
            string H_Date = date_.GregToHijri(txt_InvDate.Text);


            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;



            try
            {

                cmd.CommandText = @"delete from wh_material_transaction  where SER_NO = '" + txt_InvNu.Text + "'  and Transaction_code = '" + Doc_Type.Text + "' and Branch_code = '" + txtStore_ID.Text + "' and Cyear = '" + txtcyear.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"delete from wh_inv_data  where SER_NO = '" + txt_InvNu.Text + "'  and Transaction_code = '" + Doc_Type.Text + "' and Branch_code = '" + txtStore_ID.Text + "' and Cyear = '" + txtcyear.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"delete from daily_transaction  where SER_NO = '" + AccSer_No.Text + "'  and Branch_code = '" + txtBranch_Id.Text + "' and ACC_YEAR = '" + acc_year.Text + "' ";
                cmd.ExecuteNonQuery();



                cmd.CommandText = @"insert into wh_inv_data (Ser_no, Branch_code, Transaction_code, Cyear, Sanad_no, G_date, ACC_TYPE, Acc_no,
                 Acc_Branch_code, Payment_Type, Sales_man_Id, acc_serial_no, Po_no, User_id, NetAmount, PanyedAmount,
                 Cash_costomer_name, total_cost, Inv_Notes, Costmer_No, Phone, Adress, K_M_ACC_NO, K_M_Credit_TAX,
                 K_M_Debit_TAX, COSTMER_K_M_NO, K_M_SER, KM_CODE_ACC, MAIN_KM_CODE,PROJECT_NO,Ref,REQUIST_NO,Qutation_No,
                Dowen_Payment_acc_no,Dowen_Payment,Dowen_Payment_Vat,Sales_Vat,Dowen_Payment_Ratio,Guarantee_Acc,Guarantee_Ratio,Guarantee_Amount)
                 values('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text +
                    "', '" + txtcyear.Text + "' ,'" + txtMainSer.Text +
                    "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','A', '" + Uc_Customer.ID.Text +
                    "', '" + txtBranch_Id.Text + "', '" + Convert.ToString(Payment_Type.SelectedValue) +
                    "', '" + Uc_Cost.ID.Text + "', '" + AccSer_No.Text + "', '" + Po_No.Text + "' , '" + userID.Text +
                    "', '" + inv_Grid1.txtNetTotal.Text.ToDecimal() + "', '" + inv_Grid1.paied_amount.Text.ToDecimal() +
                    "', '" + cashCustomer.Desc.Text + "', '0', '" + txt_InvNot.Text + "', '" + cashCustomer.ID.Text +
                    "', '" + txt_custTel.Text + "', '" + txt_address.Text + "', '" + Vat_acc.Text + "', '" + inv_Grid1.txtTotalVAT.Text.ToDecimal() +
                    "', '0', '" + Cust_Vat_No.Text + "', '0','" + txtKmCode.Text + "','" + Vat_Class.Text + "','" + Uc_Project.ID.Text +
                    "','" + txt_Refrance.Text + "','" + Po_No.Text + "','" + txt_Qutation.Text + "','" + txt_DP_Acc.ID.Text + "','" + inv_Grid1.txt_DP_Disc.Text.ToDecimal() +
                    "','" + inv_Grid1.txtDPVat.Text.ToDecimal() + "','" + inv_Grid1.txtSalesVat.Text.ToDecimal() + "','" + txt_DP_Ratio.Text.ToDecimal() +
                    "','" + txt_G_Acc.ID.Text + "','" + txt_G_Ratio.Text.ToDecimal() + "','" + inv_Grid1.txtGrDiscount.Text.ToDecimal() + "')";

                cmd.ExecuteNonQuery();


                foreach (MyControls.Con_Inv_Row r in inv_Grid1.flowLayoutPanel1.Controls)
                {

                    if (r.txt_Code.Text != string.Empty && r.qty.Value > 0 && r.TxtPrice.Value > 0)
                    {
                        cmd.CommandText = @" insert into wh_MATERIAL_TRANSACTION (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO,ITEM_NO,QTY_ADD,QTY_TAKE,total_disc,DISC_R,DISC_R2,DISC_R3,
                        G_DATE,Unit,Local_Price,USER_ID,main_counter,balance,Store_Code,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,modular,DP_Ratio,DP_Amount,VAT_RATIO) 
                       values( '" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + txtcyear.Text +
                        "' ,'" + txtMainSer.Text + "','" + r.txt_Code.Text + "' ,'0','" +
                       r.qty.Text + "','" + ((r.TxtDisc.Text.ToDecimal() / r.txt_subTOt.Text.ToDecimal()) + inv_Grid1.disc_Rate.Text.ToDecimal()) * 100 +
                        "' ,'" + (r.TxtDisc.Text.ToDecimal() / r.txt_subTOt.Text.ToDecimal()) * 100 + "' ,'0','" + (inv_Grid1.disc_Rate.Text.ToDecimal()) * 100 +
                        "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Convert.ToString(r.txtUnit.SelectedValue) +
                        "' ,'" + r.TxtPrice.Text.ToDecimal() + "' , '" + userID.Text + "','" +
                        inv_Grid1.flowLayoutPanel1.Controls.GetChildIndex(r) + "', '" + r.qty.Text.ToDecimal() + "', '" + txtStore_ID.Text +
                       "','" + r.KM_TYPE_ITEMS.Text + "' ,'0','" + r.VatValue.Text.ToDecimal() + "','" + r.txtNote.Text + "','" + r.txt_DP_Ratio.Value + "','" + r.TxtDisc.Value + "','" + r.VatRate.Value + "')";

                        cmd.ExecuteNonQuery();

                    }

                }







                string arabicDesc, englishDesc;
                if (Payment_Type.SelectedValue.ToString() == "2")
                {

                    arabicDesc = "فاتورة مبيعات آجل رقم " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " طلب شراء " + Po_No.Text : "");
                    englishDesc = "Credit Sales Invoice No " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " PO " + Po_No.Text : "");
                }
                else
                {
                    arabicDesc = "فاتورة مبيعات نقدي رقم " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " طلب شراء " + Po_No.Text : "");
                    englishDesc = "Cash Sales Invoice No " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " PO " + Po_No.Text : "");
                }

                cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + Uc_Customer.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + inv_Grid1.txtNetDue.Text + "','" + 0 + "','" + inv_Grid1.txtNetDue.Text + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + englishDesc + "')";
                cmd.ExecuteNonQuery();

                if (inv_Grid1.txtGrDiscount.Text.ToDecimal() > 0)
                {
                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + txt_G_Acc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
               Uc_Cost.ID.Text + "','" + inv_Grid1.txtGrDiscount.Text + "','" + 0 + "','" + inv_Grid1.txtGrDiscount.Text + "','" + H_Date + "','" +
               txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
               userID.Text + "','" + "ضمان اعمال  " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
               txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + "Guarantee " + englishDesc + "')";
                    cmd.ExecuteNonQuery();
                }


                cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                 balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + txtAcc2_ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + 0 + "','" + inv_Grid1.txt_SubTot.Text.ToDecimal() + "','" + -inv_Grid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + englishDesc + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + Vat_acc.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                Uc_Cost.ID.Text + "','" + 0 + "','" + inv_Grid1.txtSalesVat.Text.ToDecimal() + "','" + -inv_Grid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
                txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                userID.Text + "','" + "ضريبة  " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + "VAT " + englishDesc + "')";
                cmd.ExecuteNonQuery();

                if (inv_Grid1.txt_DP_Disc.Text.ToDecimal() > 0)
                {
                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txt_DP_Acc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + inv_Grid1.txt_DP_Disc.Text.ToDecimal() + "','0','" + -inv_Grid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + "خصم دفعة مقدمة " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + "Down Payment Discount " + englishDesc + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO,desc_E )
                Values('" + acc_year.Text + "', '" + Vat_acc.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                Uc_Cost.ID.Text + "','" + inv_Grid1.txtDPVat.Text.ToDecimal() + "','0','" + -inv_Grid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
                txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                userID.Text + "','" + "خصم ضريبة دفعة مقدمة " + arabicDesc + "','0','" + Doc_Type.Text + "','" +
                txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "','" + "Down Payment VAT Discount " + englishDesc + "'  )";
                    cmd.ExecuteNonQuery();


                }





                trans.Commit();
                MessageBox.Show("Data was Updated ---- تم تعديل البيانات ", "Update --- تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dal.sqlconn_1.Close();
            }






        }




        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

    

        private void invoice_frm_Load(object sender, EventArgs e)
        {
            IsNew = true;
            DataTable dt_main = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no,downpayment_Acc FROM wh_BRANCHES where BRANCH_code ='" + Properties.Settings.Default.BranchId + "'");
            string Acc_main = dt_main.Rows[0]["Costmers_acc_no"].ToString();
            string Acc_cash = dt_main.Rows[0]["Cash_acc_no"].ToString();



            Uc_Customer.txtMainAcc.Text = Acc_main;
            Uc_Customer.txtAccCash.Text = Acc_cash;
            Uc_Customer.txtFinal.Text = "1";
            Uc_Customer.branchID.Text = Properties.Settings.Default.BranchId;
            txt_DP_Acc.txtMainAcc.Text = dt_main.Rows[0]["downpayment_Acc"].ToString();
            txt_DP_Acc.txtFinal.Text = "1";
            txt_DP_Acc.branchID.Text = Properties.Settings.Default.BranchId;

            DataTable Dt_1 = dal.getDataTabl_1(@"SELECT B.SALES_ACC_NO , PAYER_NAME FROM wh_BRANCHES AS B inner join payer2 AS P on B.SALES_ACC_NO=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code where B.BRANCH_code= '" + Properties.Settings.Default.BranchId + "'");
            if (Dt_1.Rows.Count > 0)
            {
                txtAcc2_ID.Text = Dt_1.Rows[0]["SALES_ACC_NO"].ToString();
                txtAcc2_Desc.Text = Dt_1.Rows[0]["PAYER_NAME"].ToString();
            }
            DataTable Dt_2 = dal.getDataTabl_1(@"SELECT B.Cash_acc_no , PAYER_NAME FROM wh_BRANCHES AS B inner join payer2 AS P on B.Cash_acc_no=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code where B.BRANCH_code= '" + Properties.Settings.Default.BranchId + "'");
            if (Dt_2.Rows.Count > 0)
            {
                txt_CashAcc_ID.Text = Dt_2.Rows[0]["Cash_acc_no"].ToString();
                txt_CashAcc_Desc.Text = Dt_2.Rows[0]["PAYER_NAME"].ToString();
            }

            DataTable Dt_3 = dal.getDataTabl_1(@"SELECT B.K_M_ACC_NO_SALES , PAYER_NAME FROM wh_BRANCHES AS B inner join payer2 AS P on B.K_M_ACC_NO_SALES=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code where B.BRANCH_code= '" + Properties.Settings.Default.BranchId + "'");
            if (Dt_3.Rows.Count > 0)
            {
                Vat_acc.Text = Dt_3.Rows[0]["K_M_ACC_NO_SALES"].ToString();
                Vat_acc_Desc.Text = Dt_3.Rows[0]["PAYER_NAME"].ToString();
            }
            txtcyear.Text = Properties.Settings.Default.C_year;

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

        private void Uc_Customer_Load(object sender, EventArgs e)
        {
            DataTable dt_M = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no FROM wh_BRANCHES where BRANCH_code like '" + Properties.Settings.Default.BranchId + "%'");
            if (dt_M.Rows.Count > 0)
            {
                string Acc_main = dt_M.Rows[0][0].ToString();
                string Acc_cash = dt_M.Rows[0][2].ToString();
                DataTable dt_cust = dal.getDataTabl_1(@"select P.*,A.MAIN_KM_CODE,a.MAIN_KM_DESC
            ,(select top 1 vat_ratio from VAT_RATIO_MASTER where  date_of_vat <= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'  order by date_of_vat desc)/100 as KM_RATIO" +
            ",b.KM_CODE FROM payer2 As P left join KM_MAIN_ACC_CODE as A on  ISNULL(NULLIF(P.KM_CODE_Sales, ''), 11) = A.MAIN_KM_CODE " +
            "left join  KM_ACC_CODE as b on b.KM_CODE = a.KM_CODE where P.BRANCH_code like '" + Properties.Settings.Default.BranchId + "%' and P.ACC_NO = '" + Uc_Customer.ID.Text + "' and(P.ACC_NO like '" + Acc_main + "%' or P.ACC_NO like '" + Acc_cash + "%') and P.t_final ='1'");
                txtBranch_Id.Text = Properties.Settings.Default.BranchId;
                if (dt_cust.Rows.Count > 0)
                {
                    if (Uc_Customer.ID.Text == Acc_cash)
                    {
                        cashCustomer.Enabled = true;
                        Payment_Type.SelectedValue = "11";
                        Payment_Type.Enabled = false;
                        Vat_Class.Text = dt_cust.Rows[0]["MAIN_KM_CODE"].ToString();
                        Vat_Class_Desc.Text = dt_cust.Rows[0]["MAIN_KM_DESC"].ToString();
                        if (dt_cust.Rows[0]["KM_RATIO"].ToString() == string.Empty)
                        { Cust_Vat_Rate.Text = "0.15";
                            inv_Grid1.txtAccVat_Rate.Text = Cust_Vat_Rate.Text;                      }
                        else
                        {
                            Cust_Vat_Rate.Text = dt_cust.Rows[0]["KM_RATIO"].ToString().ToDecimal().ToString("N2");
                            inv_Grid1.txtAccVat_Rate.Text = Cust_Vat_Rate.Text;
                        }
                        txtKmCode.Text = dt_cust.Rows[0]["KM_CODE"].ToString();
                    }
                    else
                    {
                        cashCustomer.Enabled = false;
                        Payment_Type.SelectedValue = "2";
                        Payment_Type.Enabled = true;

                        txt_custTel.Text = dt_cust.Rows[0]["phone_no"].ToString();
                        txt_address.Text = dt_cust.Rows[0]["adress"].ToString();
                        txt_custFax.Text = dt_cust.Rows[0]["fax_no"].ToString();
                        txt_CustEmail.Text = dt_cust.Rows[0]["E_MAIL"].ToString();
                        txt_BoBox.Text = dt_cust.Rows[0]["b_o_box"].ToString();
                        txt_area_code.Text = dt_cust.Rows[0]["RESP_B_O_BOX"].ToString();
                        Cust_Vat_No.Text = dt_cust.Rows[0]["COSTMER_K_M_NO"].ToString();
                        Vat_Class.Text = dt_cust.Rows[0]["MAIN_KM_CODE"].ToString();
                        Vat_Class_Desc.Text = dt_cust.Rows[0]["MAIN_KM_DESC"].ToString();
                        if (dt_cust.Rows[0]["KM_RATIO"].ToString() == string.Empty)
                        { Cust_Vat_Rate.Text = "0.15";
                            inv_Grid1.txtAccVat_Rate.Text = Cust_Vat_Rate.Text;
                        }
                        else
                        {
                            Cust_Vat_Rate.Text = dt_cust.Rows[0]["KM_RATIO"].ToString().ToDecimal().ToString("N2");
                            inv_Grid1.txtAccVat_Rate.Text = Cust_Vat_Rate.Text;
                        }
                        txtKmCode.Text = dt_cust.Rows[0]["KM_CODE"].ToString();
                    }
                }
                else
                {
                    cashCustomer.Enabled = false;
                    txt_custTel.Clear();
                    txt_address.Clear();
                    txt_custFax.Clear();
                    txt_CustEmail.Clear();
                    txt_BoBox.Clear();
                    txt_area_code.Clear();
                    Cust_Vat_No.Clear();
                    Vat_Class.Clear();
                    Vat_Class_Desc.Clear();
                    Cust_Vat_Rate.Clear();
                    inv_Grid1.txtAccVat_Rate.Clear();

                }
               inv_Grid1.total_inv();
            }

        }

        private void BSearch_Click(object sender, EventArgs e)
        {

        }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_DP_Ratio_ValueChanged(object sender, EventArgs e)
        {

            inv_Grid1.txt_downPayment_Ratio.Text = txt_DP_Ratio.Text.ToDecimal().ToString();
        }

        private void Uc_Project_Load(object sender, EventArgs e)
        {
            DataTable dt_ratio = dal.getDataTabl_1(@"select PROJ_CODE,DP_Ratio,DP_Acc,Guarantee_Acc,Guarantee_Ratio  from Projects where PROJ_CODE = '" + Uc_Project.ID.Text + "'");
            if (dt_ratio.Rows.Count > 0)
            {
                txt_DP_Ratio.Text = dt_ratio.Rows[0]["DP_Ratio"].ToString().ToDecimal().ToString("N0");
                txt_DP_Acc.ID.Text = dt_ratio.Rows[0]["DP_Acc"].ToString();
                txt_G_Ratio.Text = dt_ratio.Rows[0]["Guarantee_Ratio"].ToString().ToDecimal().ToString("N0");
                txt_G_Acc.ID.Text = dt_ratio.Rows[0]["Guarantee_Acc"].ToString();

            }
            else
            {
                txt_DP_Ratio.Text = "0".ToDecimal().ToString("N0");
                txt_DP_Acc.ID.Text = "";
            }
            inv_Grid1.txt_downPayment_Ratio.Text = txt_DP_Ratio.Text;
            inv_Grid1.txt_ProjectNo.Text = Uc_Project.ID.Text;
            

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();

            RPT.Rpt_Pro_Frm frminv = new RPT.Rpt_Pro_Frm();
            getSalesInv(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
            //DataTable dt_1 = dal.getDataTabl("get_invDetails", txt_InvNu.Text, Doc_Type.Text, txt_InvDate.Value.Year.ToString(), Properties.Settings.Default.BranchId);

            string printModel = Properties.Settings.Default.inv_print;

            getInvoiceTotal(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
            ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["netDue"].ToString())), currencies[currencyNo]);


            DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp ");


            string vat_no = dt_Co.Rows[0]["Comp_Vat_no"].ToString();
            string Co_Name = dt_Co.Rows[0]["Company_e_name"].ToString();
            string invDate = txt_InvDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
            string TotalInv = dt_inv_total.Rows[0]["NetValue"].ToString().ToDecimal().ToString("0.00");
            string TotalTax = dt_inv_total.Rows[0]["tax"].ToString().ToDecimal().ToString("0.00");

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


            dataSet.Tables.Add(dt_inv);
            dataSet.Tables.Add(dQR);
            dataSet.Tables.Add(dt_Co);
            dataSet.WriteXmlSchema("schema_rpt.xml");

            if (printModel == "1")
            {
                RPT.Rpt_Contract_Invoice_1 reportInv = new RPT.Rpt_Contract_Invoice_1();
                reportInv.SetDataSource(dataSet);
                reportInv.DataDefinition.FormulaFields["tafqeet_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                reportInv.DataDefinition.FormulaFields["tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }

            else

            {
                RPT.Rpt_Contract_Invoice_1 reportInv = new RPT.Rpt_Contract_Invoice_1();
                reportInv.SetDataSource(dataSet);
                reportInv.DataDefinition.FormulaFields["tafqeet_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                reportInv.DataDefinition.FormulaFields["tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }
        }

        private void getSalesInv(string ser_, string branch_, string transaction_, string cyear_)

        {
            dt_inv = this.dal.getDataTabl_1(@"select A.ser_no,A.Branch_code,A.Cyear,A.Transaction_code,
            A.G_date,A.Acc_no,A.Payment_Type,A.Sales_man_Id,A.Inv_no,A.Inv_date,a.Inv_Notes,A.Phone,
            A.Adress,A.PROJECT_NO,A.Costmer_No,A.Cash_costomer_name,A.REQUIST_NO,A.Ref,A.acc_serial_no,
            A.Qutation_No,A.REQUIST_NO,isnull(A.Dowen_Payment_Ratio,0) as Dowen_Payment_Ratio,A.Dowen_Payment_acc_no,
            A.Dowen_Payment,A.Dowen_Payment_Vat,A.Sales_Vat,A.Guarantee_Acc,isnull(A.Guarantee_Ratio,0) as Guarantee_Ratio,A.Guarantee_Amount,A.po_no,A.Ref
            ,B.modular,B.DP_Ratio,B.DP_Amount,B.VAT_RATIO,B.main_counter,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,
            B.Unit,B.Local_Price,isnull(B.TAX_IN,0)as TAX_IN ,isnull(B.TAX_OUT,0)as TAX_OUT , round(B.total_disc*B.local_price*QTY_TAKE/100,2) as disc_ ,
            p.PAYER_NAME,p.payer_l_name,p2.PAYER_NAME as lc_name ,p2.payer_l_name as lc_L_Name,P.adress,P.adress_E ,P.phone_no,P.fax_no,P.E_MAIL,P.COSTMER_K_M_NO, P.SEGEL_NO,P.ZAKAH_NO,
            M.descr,M.Descr_eng, br.branch_name,BR.WH_E_NAME,Br.Branch_Logo_A4,PT.Payment_name,U.unit_Description, U.unit_Description_E,J.PROJ_name,J.PROJ_E_name
            , B.VAT_RATIO as VatRatio " +
            "from wh_inv_data As A " +
            "inner join wh_material_transaction As B on a.Ser_no = b.SER_NO and a.Cyear = b.Cyear and a.Transaction_code = b.TRANSACTION_CODE and a.Branch_code = b.Branch_code  " +
            "inner join payer2 As P on a.Acc_no = p.ACC_NO and a.Acc_Branch_code = p.BRANCH_code  " +
            "left join(select* from payer2)as p2 on p2.ACC_NO = a.LC_ACC_NO and a.Acc_Branch_code = p2.BRANCH_code  " +
            "inner join wh_main_master as M on M.item_no=B.ITEM_NO  " +
            "inner join wh_BRANCHES As BR on BR.Branch_code = a.Branch_code  " +
            "inner join wh_Payment_type as PT on A.Payment_Type=PT.Payment_type  " +
            "left join  Wh_Unit as U on U.Wh_Unit = B.unit "+
            "left join Projects as J on J.PROJ_CODE = A.PROJECT_NO " +
            "where a.SER_NO = '" + ser_ + "' and a.Transaction_code = '" + transaction_ + "' and a.Branch_code = '" + branch_ + "' and a.Cyear = '" + cyear_ + "'");
        }
        //(select top 1 vat_ratio from VAT_RATIO_MASTER where cast(A.G_date as date ) between date_of_vat and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by date_of_vat desc)
        //(select case when B.K_M_TYPE_ITEMS =1 and CAST(B.G_DATE as date ) between '2018-01-01' and '2020-06-30'   then 5  when B.K_M_TYPE_ITEMS =1 and CAST(B.G_DATE as date ) > '2020-06-30' then 15  else 0 end)as VatRatio

        private void getInvoiceTotal(string ser_, string branch_, string transaction_, string cyear_)
        {
            dt_inv_total = dal.getDataTabl_1(@"select X.TotalValue,x.discount,X.tax,X.NetValue,isnull(B.Guarantee_Amount,0) asGuarantee_Amount ,(X.NetValue-isnull(B.Guarantee_Amount,0)) as netDue from (select B.TRANSACTION_CODE,B.Branch_code,B.Cyear,B.SER_NO,round(sum(b.QTY_TAKE*Local_Price),2) as TotalValue
, round(sum(b.total_disc * B.local_price * QTY_TAKE / 100), 2) as discount
, round(sum(isnull(b.TAX_OUT, 0)), 2) as tax
, round(sum(b.QTY_TAKE * Local_Price), 2) - round(sum(b.total_disc * B.local_price * QTY_TAKE / 100), 2) + round(sum(isnull(b.TAX_OUT, 0)), 2) as NetValue
, round(sum(b.QTY_ADD * Local_Price), 2) - round(sum(b.total_disc * B.local_price * QTY_ADD / 100), 2) + round(sum(isnull(b.TAX_IN, 0)), 2) as NetValuePurch 
from  wh_material_transaction as B		
where b.SER_NO = '" + ser_ + "'  and b.Transaction_code = '" + transaction_ + "' and b.Branch_code = '" + branch_ + "' and b.Cyear = '" + cyear_ + 
"'group by B.TRANSACTION_CODE,B.Branch_code,B.Cyear,B.SER_NO) as X " +
"inner join wh_inv_data as B " +
"on X.Ser_no = B.SER_NO and X.Branch_code = B.Branch_code and X.Cyear = b.Cyear and X.Transaction_code=b.TRANSACTION_CODE ");
        }

        private void btn_Search_Ser_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_Credit_Click(object sender, EventArgs e)
        {
            PL.invoice_list_frm ord = new PL.invoice_list_frm();
            ord.trans_code = "XSD";
            //ord.trans_code_1 = "xsd";
            ord.ShowDialog();

            int ii = ord.dg_orders_list.CurrentRow.Index;
            string ser_ = ord.dg_orders_list.CurrentRow.Cells[0].FormattedValue.ToString();
            string trans_ = ord.dg_orders_list.CurrentRow.Cells[7].FormattedValue.ToString();
            string year_ = ord.dg_orders_list.CurrentRow.Cells[8].FormattedValue.ToString();
            string branch_= Properties.Settings.Default.BranchId;

            //frm.txtSearch.t.Text, txtStore_ID.Text, _transaction, Properties.Settings.Default.C_year
            search_Inv(ser_,branch_, "XSD",year_);
           // BSave.Enabled = false;
        }

        private void search_Inv(string _no, string _branch, string _transaction, string _year)
        {
            //PL.frmSerch frm = new PL.frmSerch();
            //frm.ShowDialog();
            getSalesInv(_no, _branch, _transaction, _year);
            if (dt_inv.Rows.Count > 0)
            {
                Doc_Type.Text = dt_inv.Rows[0]["Transaction_code"].ToString();
                txtcyear.Text = dt_inv.Rows[0]["cyear"].ToString();
                txt_InvDate.Text = dt_inv.Rows[0]["G_date"].ToString();
                Uc_Customer.ID.Text = dt_inv.Rows[0]["Acc_no"].ToString();
                Payment_Type.SelectedValue = dt_inv.Rows[0]["Payment_Type"].ToString();
                Uc_Project.ID.Text = dt_inv.Rows[0]["PROJECT_NO"].ToString();
                txt_InvNot.Text = dt_inv.Rows[0]["Inv_Notes"].ToString();
                txt_address.Text = dt_inv.Rows[0]["Adress"].ToString();
                Uc_Cost.ID.Text = dt_inv.Rows[0]["Sales_man_Id"].ToString();
                cashCustomer.ID.Text = dt_inv.Rows[0]["Costmer_No"].ToString();
                txt_InvNu.Text = dt_inv.Rows[0]["ser_no"].ToString();
                AccSer_No.Text = dt_inv.Rows[0]["acc_serial_no"].ToString();
                txt_Refrance.Text = dt_inv.Rows[0]["Ref"].ToString();
                Po_No.Text = dt_inv.Rows[0]["REQUIST_NO"].ToString();
                txt_Qutation.Text = dt_inv.Rows[0]["Qutation_No"].ToString();
                txt_G_Acc.ID.Text = dt_inv.Rows[0]["Guarantee_Acc"].ToString();
                txt_G_Ratio.Text = dt_inv.Rows[0]["Guarantee_Ratio"].ToString().ToDecimal().ToString("N0");
                inv_Grid1.txtGrDiscount.Text = dt_inv.Rows[0]["Guarantee_Amount"].ToString().ToDecimal().ToString("N"+dal.digits_);
                int i = 0;
                inv_Grid1.flowLayoutPanel1.Controls.Clear();

                foreach (DataRow r in dt_inv.Rows)
                {


                    MyControls.Con_Inv_Row row = new MyControls.Con_Inv_Row();
                    row.Ser.Text = (r["main_counter"].ToString().ToDecimal()+1).ToString("N0");
                    row.txt_Code.Text = r["ITEM_NO"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                    row.TxtDesc.Text = r["descr"].ToString();
                    }
                    else
                    {
                        row.TxtDesc.Text = r["Descr_eng"].ToString();
                    }
                    row.txtNote.Text = r["modular"].ToString();
                    row.txtUnit.SelectedValue = r["Unit"].ToString();
                    row.qty.Text = r["QTY_TAKE"].ToString();
                    row.TxtPrice.Text = r["Local_Price"].ToString();
                    row.txt_subTOt.Text = (row.qty.Value * row.TxtPrice.Value).ToString();
                    row.txt_DP_Ratio.Text = r["DP_Ratio"].ToString().ToDecimal().ToString("N0");
                    row.TxtDisc.Text = r["DP_Amount"].ToString().ToDecimal().ToString();
                    row.Txtvalue.Text = (row.qty.Value * row.TxtPrice.Value - row.TxtDisc.Value).ToString();
                    row.VatRate.Text = r["VAT_RATIO"].ToString().ToDecimal().ToString();
                    row.VatValue.Text = r["TAX_OUT"].ToString().ToDecimal().ToString();
                    row.ProjectNo = Uc_Project.ID.Text;
                    inv_Grid1.flowLayoutPanel1.Controls.Add(row);
                    row.VatAccRate.Text = Cust_Vat_Rate.Text.ToDecimal().ToString("N2");
                    row.KeyDown += inv_Grid1.r_KeyDown;
                    row.KeyUp += inv_Grid1.r_KeyUP;
                    row.Enter += inv_Grid1.r_Enter;
                    row.Click += inv_Grid1.r_Click;
                    i = i + 1;
                }
                inv_Grid1.total_inv();
                Payment_Type.Enabled = false;
                IsNew = false;


            }
            else
            {
                _new();
                Payment_Type.Enabled = true; 
            }
        }

        private void btn_Search_Mser_Click(object sender, EventArgs e)
        {
            PL.invoice_list_frm ord = new PL.invoice_list_frm();
            ord.trans_code = "XSC";
            //ord.trans_code_1 = "xsd";
            ord.ShowDialog();

            int ii = ord.dg_orders_list.CurrentRow.Index;
            string ser_ = ord.dg_orders_list.CurrentRow.Cells[0].ToString();
            string trans_ = ord.dg_orders_list.CurrentRow.Cells[7].ToString();
            string year_ = ord.dg_orders_list.CurrentRow.Cells[8].ToString();
            string branch_ = Properties.Settings.Default.BranchId;

            //frm.txtSearch.t.Text, txtStore_ID.Text, _transaction, Properties.Settings.Default.C_year
            search_Inv(ser_, branch_, "XSC", year_);


           
           // BSave.Enabled = false;
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            foreach (MyControls.Con_Inv_Row r in inv_Grid1.flowLayoutPanel1.Controls)
            {
                if (r.txt_Code.Text != string.Empty && r.qty.Value > 0 && r.TxtPrice.Value > 0)
                {
                   dal.Execute_1( @" Update wh_MATERIAL_TRANSACTION set modular= '" + r.txtNote.Text +
                       "',Unit='" + Convert.ToString(r.txtUnit.SelectedValue) + "' where Ser_no = '" + txt_InvNu.Text + "'and  Branch_code ='" + txtStore_ID.Text + "' and Transaction_code = '" + Doc_Type.Text +"' and  Cyear = '" + txt_InvDate.Value.ToString("yy") + "' and main_counter='"+r.Ser.Value+"'-1 ");
                }
            }
        }

        private void labelX23_Click(object sender, EventArgs e)
        {

        }

        private void txt_G_Ratio_TextChanged(object sender, EventArgs e)
        {
            inv_Grid1.txtGRatio.Text = txt_G_Ratio.Text.ToDecimal().ToString();

        }

        private void AccSer_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel6_Click(object sender, EventArgs e)
        {

        }

        private void headLbl_Click(object sender, EventArgs e)
        {

        }

        private void Add_Jor()
        {
            string cyear = txt_InvDate.Value.Year.ToString("yy");
            string H_Date = date_.GregToHijri(txt_InvDate.Text);


            dal.Execute_1(@"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
            balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,PROJECT_NO )
            Values('" + acc_year.Text + "', '" + Uc_Customer.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
            Uc_Cost.ID.Text + "','" + inv_Grid1.txtNetValue.Text + "','" + 0 + "','" + inv_Grid1.txtNetValue.Text + "','" + H_Date + "','" +
            txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
            userID.Text + "','" + "فاتورة مبيعات " + Payment_Type.Text + " رقم " + txt_InvNu.Text + "','0','" + Doc_Type.Text + "','" +
            txtStore_ID.Text + "','" + AccSer_No.Text + "','"+Uc_Project.ID.Text+"')");


            dal.Execute_1(@"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
            balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO )
            Values('" + acc_year.Text + "', '" + txtAcc2_ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
            Uc_Cost.ID.Text + "','" + 0 + "','" +inv_Grid1.txtNetTotal.Text.ToDecimal() + "','" + -inv_Grid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
            txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
            userID.Text + "','" + "فاتورة مبيعات " + Payment_Type.Text + " رقم " + txt_InvNu.Text + "','0','" + Doc_Type.Text + "','" +
            txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "')");

            dal.Execute_1(@"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
            balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO )
            Values('" + acc_year.Text + "', '" + Vat_acc.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
            Uc_Cost.ID.Text + "','" + 0 + "','" + inv_Grid1.txtTotalVAT.Text.ToDecimal() + "','" + -inv_Grid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
            txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
            userID.Text + "','" + "ضريبة فاتورة مبيعات " + Payment_Type.Text + " رقم " + txt_InvNu.Text + "','0','" + Doc_Type.Text + "','" +
            txtStore_ID.Text + "','" + AccSer_No.Text + "','" + Uc_Project.ID.Text + "')");




        }



        private void txtStore_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = dal.getDataTabl("GetStores", txtStore_ID.Text.ToString());
                if (dt.Rows.Count > 0)
                {
                    // txtStore_Desc.Text = dt.Rows[0][2].ToString();
                    txtAcc2_ID.Text = dt.Rows[0][9].ToString();
                    txt_CashAcc_ID.Text = dt.Rows[0][12].ToString();
                    txt_CustAcc_ID.Text = dt.Rows[0][13].ToString();
                }
                else
                {
                    // txtStore_Desc.Text = "";
                }
            }
            catch
            {

            }
        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

       
      
        
    }
}


     