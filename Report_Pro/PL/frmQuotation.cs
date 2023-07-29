using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;
//using System.linq;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using CrystalDecisions.CrystalReports.Engine;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.SqlClient;

namespace Report_Pro.PL
{

    public partial class frmQuotation : frm_Master
    {
         DataTable dt_Q;
         Int32 m;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();


        public frmQuotation()
        {

            InitializeComponent();


          
            Validty_Date.Value = txt_InvDate.Value.AddDays(ValidtyDays.Value);
            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranchID.Text = Properties.Settings.Default.BranchAccID;
            AccType.Text = Properties.Settings.Default.TRANS_TO_ACC;
            txt_InvSM.Text = Program.salesman;
            userID.Text = Program.userID;
            Uc_cost.ID.Text = Program.userCostCode;

            PaymentTearms.DataSource = dal.getDataTabl_1("select Payment_type,Payment_name,Notes from Sal_Pyment_type");
            PaymentTearms.ValueMember = "Payment_type";


            DelevryTearms.DataSource = dal.getDataTabl_1("select DeLEVRY_CODE ,DeLEVRY_Name,DELEVER_NAME_E from WH_PO_DELEVRY_CODE");
            DelevryTearms.ValueMember = "DeLEVRY_CODE";

            txt_Bank.DataSource = dal.getDataTabl_1("select BID,BNameA,isnull(nullif(BNameE,''),BNameA) as BNameE from BanksTbl");
            txt_Bank.ValueMember = "BID";

            if (Properties.Settings.Default.lungh == "0")
            {
                DelevryTearms.DisplayMember = "DeLEVRY_Name";
                PaymentTearms.DisplayMember = "Payment_name";
                txt_Bank.DisplayMember = "BNameA";
            }
            else
            {
                DelevryTearms.DisplayMember = "DELEVER_NAME_E";
                PaymentTearms.DisplayMember = "Notes";
                txt_Bank.DisplayMember = "BNameE";
            }
            PaymentTearms.SelectedIndex = -1;
            DelevryTearms.SelectedIndex = -1;
            txt_Bank.SelectedIndex = -1;

            New();
               
            //get_data();
            //getSer();

        }


        private void get_data()
        {
            DataTable Dt_3 = dal.getDataTabl_1(@"SELECT B.K_M_ACC_NO_SALES , PAYER_NAME FROM wh_BRANCHES AS B right join payer2 AS P on B.K_M_ACC_NO_SALES=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code where p.BRANCH_code='" + txtStore_ID.Text + "'");
            VAT_Acc.Text = Dt_3.Rows[0][0].ToString();
            year_.Text = Properties.Settings.Default.C_year;
        }


       








      



        private void Payment_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

      



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public override void New()
        {
            ClearTextBoxes();
            get_data();
            getSer();
            Uc_cost.ID.Text = Program.userCostCode;
            invGrid1.dgv1.Rows.Clear();

            base.New();
        }



        

        private void getSer()
        {
            string get_ser = @"select isnull(max(CO)+1,1) from wh_Serial where Branch_code='" + Properties.Settings.Default.BranchId
                     + "' and Cyear= '"+year_.Text+"'";
            this.txt_InvNu.Text = dal.getDataTabl_1(get_ser).Rows[0][0].ToString();//.PadLeft(4, '0');
        }

     
        public override void Save()
        {

            if (invGrid1.dgv1.Rows.Count < 1)
            {
                MessageBox.Show("فضلا.. تاكد من اختيار الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txtPayType.ID.Text.Trim()=="")
            {
                MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDecimal(invGrid1.txtNetTotal.Text) <= 0)
            {
                MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (txtPayType.ID.Text.Trim()== "11")
            {

                //if (cashCustomer.ID.Text.Replace(" ", string.Empty) == "")
                //{
                //    MessageBox.Show("تأكد من اسم العميل النقدي", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


            }

            if (year_.Text != Properties.Settings.Default.C_year)
            {
                MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsNew == true)
            {
            getSer();
            add_wh_Po_Cot_inv_data();
            }
            else
            {
                Update_wh_Po_Cot_inv_data();
            }



            base.Save();

        }

        private void add_wh_Po_Cot_inv_data()
        {
            dal.open_1();
            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection =dal.sqlconn_1;
            cmd.Transaction = trans;
            try {
                cmd.CommandText = @"INSERT INTO wh_Po_Cot_inv_data (Ser_no, Branch_code, Transaction_code, Cyear,Sanad_no, G_date, ACC_TYPE,
            Acc_no, Acc_Branch_code, Payment_Type, Sales_man_Id, User_id, Cash_costomer_name,
            Costomer_adress, Costomer_Phone, Costmer_fax, Ref, E_mail, TermsOfPayment, Validity, DelevryE, PERM_SER,
            K_M_ACC_NO, K_M_Credit_TAX, COSTMER_K_M_NO, KM_CODE_ACC, MAIN_KM_CODE, Costomer_Notes, OPEN_VAT, VAT_RATIO)
            values('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + year_.Text +
                "', '" + 0 + "','" + txt_InvDate.Value.ToString("yyyy-MM-dd HH: mm:ss") + "', '" + AccType.Text + "', '" + Uc_Acc.ID.Text + "', '" + txtBranchID.Text + "', '" + txtPayType.ID.Text +
                "', '" + Uc_cost.ID.Text + "',  '" + userID.Text + "', ''" +
                ", '" + txt_address.Text + "', '" + txt_custTel.Text + "', '" + txt_custFax.Text + "', '" + CustomerRef.Text + "', '" + txt_CustEmail.Text +
                "', '" + Convert.ToString(PaymentTearms.SelectedValue) + "', '" + ValidtyDays.Text + "', '" + Convert.ToString(DelevryTearms.SelectedValue) +
                "', '" + Convert.ToString(txt_Bank.SelectedValue) + "', '" + VAT_Acc.Text +
                "', '" + invGrid1.txtTotalVAT.Text + "', '" + Cust_Vat_No.Text + "', '" + txtKmCode.Text + "', '" + Vat_Class.Text + "', '" + txt_attn.Text + "', '" + 0 +
                "', '" + Cust_Vat_Rate.Text + "')";
                cmd.ExecuteNonQuery();
                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                                          && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                                          && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                                           )
                    {
                        cmd.CommandText = @" INSERT INTO wh_Po_Cot_MATERIAL_TRANSACTION   (SER_NO, Branch_code, TRANSACTION_CODE, Cyear, ITEM_NO, QTY_TAKE,
                    G_DATE, Unit, Local_Price, USER_ID, main_counter, balance, Backege, Pice_Total_Cost, DETAILS,
                    TAX_OUT, K_M_TYPE_ITEMS)
                    values ('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + year_.Text + "', '" + invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() + 
                          "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() + 
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() + 
                          "', '" + userID.Text +
                          "', '" + invGrid1.dgv1.Rows[i].Index + 
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() + 
                          "', '" + 1 + 
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].FormattedValue.ToString() + 
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_vat"].FormattedValue.ToString() + 
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].FormattedValue.ToString() + "') ";
                        cmd.ExecuteNonQuery();
                    }
                }


                cmd.CommandText = @"Update wh_Serial set CO='" + txt_InvNu.Text + "'  where Branch_code='" + txtStore_ID.Text
                     + "' and Cyear= '" + year_.Text + "' ";
                cmd.ExecuteNonQuery();

                MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                trans.Commit();
                IsNew = false;
               
            }
            catch (Exception ex) {
                trans.Rollback();
                MessageBox.Show(ex.Message);         
            }
            finally
            {
                dal.close_1();
            }
           
        }


        private void Update_wh_Po_Cot_inv_data()
        {
            
               dal.open_1();
                 SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {
                //حذف الفاتورة القديمة
                cmd.CommandText = "delete from wh_Po_Cot_MATERIAL_TRANSACTION where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                "' and TRANSACTION_CODE = '" + Doc_Type.Text + "' and Cyear = '" + year_.Text + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from wh_Po_Cot_inv_data where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                "' and TRANSACTION_CODE = '" + Doc_Type.Text + "' and Cyear = '" + year_.Text + "'";
                cmd.ExecuteNonQuery();
                //اضافة الفاتورة بعد التعديل
                cmd.CommandText = @"INSERT INTO wh_Po_Cot_inv_data (Ser_no, Branch_code, Transaction_code, Cyear,Sanad_no, G_date, ACC_TYPE,
            Acc_no, Acc_Branch_code, Payment_Type, Sales_man_Id, User_id,Costmer_no, Cash_costomer_name,
            Costomer_adress, Costomer_Phone, Costmer_fax, Ref, E_mail, TermsOfPaymentE, Validity, DelevryE, PERM_SER,
            K_M_ACC_NO, K_M_Credit_TAX, COSTMER_K_M_NO, KM_CODE_ACC, MAIN_KM_CODE, Costomer_Notes, OPEN_VAT, VAT_RATIO)
            values('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + year_.Text +
                "', '" + 0 + "','" + txt_InvDate.Value.ToString("yyyy-MM-dd HH: mm:ss") + "', '" + AccType.Text + "', '" + Uc_Acc.ID.Text + "', '" + txtBranchID.Text + "', '" + txtPayType.ID.Text +
                "', '" + Uc_cost.ID.Text + "',  '" + userID.Text + "', '',''" +
                ", '" + txt_address.Text + "', '" + txt_custTel.Text + "', '" + txt_custFax.Text + "', '" + CustomerRef.Text + "', '" + txt_CustEmail.Text +
                "', '" + Convert.ToString(PaymentTearms.SelectedValue) + "', '" + ValidtyDays.Text + "', '" + Convert.ToString(DelevryTearms.SelectedValue) +
                "', '" + Convert.ToString(txt_Bank.SelectedValue) + "', '" + VAT_Acc.Text +
                "', '" + invGrid1.txtTotalVAT.Text + "', '" + Cust_Vat_No.Text + "', '" + txtKmCode.Text + "', '" + Vat_Class.Text + "', '" + txt_attn.Text + "', '" + 0 +
                "', '" + Cust_Vat_Rate.Text + "')";
                cmd.ExecuteNonQuery();
                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                                          && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                                          && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                                           )
                    {
                        cmd.CommandText = @" INSERT INTO wh_Po_Cot_MATERIAL_TRANSACTION   (SER_NO, Branch_code, TRANSACTION_CODE, Cyear, ITEM_NO, QTY_TAKE,
                    G_DATE, Unit, Local_Price, USER_ID, main_counter, balance, Backege, Pice_Total_Cost, DETAILS,
                    TAX_OUT, K_M_TYPE_ITEMS)
                    values ('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + year_.Text + "', '" + invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() +
                          "', '" + userID.Text +
                          "', '" + invGrid1.dgv1.Rows[i].Index +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + 1 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_vat"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].FormattedValue.ToString() + "') ";
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                trans.Commit();
                IsNew = false;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dal.close_1();
            }
        }



   
        public override void Print()
        {
            string printModel = Properties.Settings.Default.inv_print;
            if (printModel == "1")
            {
                RPT.rpt_SalesQuotation rpt = new RPT.rpt_SalesQuotation();
                RPT.Form1 frm = new RPT.Form1();
                DataSet ds = new DataSet();
                getQuotation(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                ds.Tables.Add(dt_Q);
                // ds.WriteXmlSchema("schema_rpt.xml");
                rpt.SetDataSource(ds);
                rpt.DataDefinition.FormulaFields["decimal_"].Text = "'" + Properties.Settings.Default.digitNo_ + "'";
                rpt.DataDefinition.FormulaFields["Currency_"].Text = "'" + Properties.Settings.Default.Currency + "'";
                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }

            else

            {
                RPT.rpt_SalesQuotation rpt = new RPT.rpt_SalesQuotation();
                RPT.Form1 frm = new RPT.Form1();
                DataSet ds = new DataSet();
                getQuotation(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                ds.Tables.Add(dt_Q);
                //ds.WriteXmlSchema("schema_rpt.xml");
                rpt.SetDataSource(ds);
                rpt.DataDefinition.FormulaFields["decimal_"].Text = "'" + Properties.Settings.Default.digitNo_ + "'";
                rpt.DataDefinition.FormulaFields["Currency_"].Text = "'" + Properties.Settings.Default.Currency + "'";
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
                ////reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                ////reportInv.PrintToPrinter(1, false, 0, 15);
                //frm.crystalReportViewer1.ReportSource = rpt;
                //frm.WindowState = FormWindowState.Maximized;
                //frm.ShowDialog();
            }

            base.Print();
        }


 

   
     
     
      
      
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedIndex = -1;
                    else if (control is DateTimePicker)
                        (control as DateTimePicker).Value = DateTime.Now;
                    else if (control is DevComponents.Editors.DoubleInput)
                        (control as DevComponents.Editors.DoubleInput).Value = 0;

                    else
                        func(control.Controls);
            };

            func(Controls);
            // txtCoId.Text = Properties.Settings.Default.CoId;
            //BranchId.Text = Properties.Settings.Default.BranchId;
        }

      
      
      
        private void txt_InvDate_ValueChanged(object sender, EventArgs e)
        {
               invGrid1.invVAtDate.Value = txt_InvDate.Value;
        }

       

        private void Uc_Acc_Load(object sender, EventArgs e)
        {
            string Get_cust = @"SELECT p.ACC_NO,p.phone_no,p.fax_no,p.E_MAIL,V.VAT_ID,p.COSTMER_K_M_NO
                    ,p.adress,p.adress_E,p.resp_name,p.resp_name_E,p.area_code,p.b_o_box,V.VAT_DESC,V.VAT_RATIO 
                    FROM PAYER2 as P 
                    inner join VAT_ACC as V on V.VAT_ID = isnull(P.KM_CODE_Sales,'11') 
                    where  BRANCH_code='" + Uc_Acc.branchID.Text + "' and acc_no like '" + Uc_Acc.txtMainAcc.Text + "%' and  ACC_NO ='" + Uc_Acc.ID.Text + "'";


            DataTable dt_itme = dal.getDataTabl_1(Get_cust);
            if (dt_itme.Rows.Count > 0)
            {
                txt_custTel.Text = dt_itme.Rows[0]["phone_no"].ToString();
                txt_custFax.Text = dt_itme.Rows[0]["fax_no"].ToString();
                txt_CustEmail.Text = dt_itme.Rows[0]["E_MAIL"].ToString();
                Vat_Class.Text = dt_itme.Rows[0]["VAT_ID"].ToString();
                Cust_Vat_No.Text = dt_itme.Rows[0]["COSTMER_K_M_NO"].ToString();
                Vat_Class_Desc.Text = dt_itme.Rows[0]["VAT_DESC"].ToString();
                Cust_Vat_Rate.Text = Uc_Acc.KM_Ratio_Sales.Text;
                //dt_itme.Rows[0]["VAT_RATIO"].ToString().ToDecimal().ToString("N2");
                invGrid1.txtAccVat_Rate.Text = Uc_Acc.KM_Ratio_Sales.Text; 
                txt_address.Text = dt_itme.Rows[0]["adress"].ToString();
                txt_attn.Text = dt_itme.Rows[0]["resp_name"].ToString();
                txt_area_code.Text = dt_itme.Rows[0]["area_code"].ToString();
                txt_BoBox.Text = dt_itme.Rows[0]["b_o_box"].ToString();
               
                if (Uc_Acc.ID.Text == dal.getDataTabl_1(@"select Cash_Costmer_Code FROM wh_BRANCHES where BRANCH_code='" + Uc_Acc.branchID.Text + "'").Rows[0][0].ToString())
                {
                    Payment_Type.SelectedValue = "11";
                    Payment_Type.Enabled = false;
                  //  cashCustomer.Desc.Clear();

                }
                else
                {
                    Payment_Type.SelectedIndex = -1;
                    Payment_Type.Enabled = true;
                    //cashCustomer.Desc.Text = dt_itme.Rows[0][7].ToString();
                }

                invGrid1.ClientCode = Uc_Acc.ID.Text;
                invGrid1.total_inv();
            }

        }

        
       

        public override void Search()
        {
            groupPanel1.Visible = true;
            groupPanel1.BringToFront();
            txtSearch.Focus();
          
            base.Search();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
          //  frmType = "EDIT";
            getQuotation(txtSearch.Text, txtStore_ID.Text, Doc_Type.Text,Properties.Settings.Default.C_year);
            // DataTable dt_Q = dal.getDataTabl("Get_Po_Cot", txtSearch.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"),0,"");
            if (dt_Q.Rows.Count > 0)
            {
                txt_InvNu.Text = dt_Q.Rows[0]["Ser_no"].ToString();
                txt_InvDate.Text = dt_Q.Rows[0]["G_date"].ToString();
                Uc_Acc.ID.Text = dt_Q.Rows[0]["Acc_no"].ToString();
                txtPayType.ID.Text = dt_Q.Rows[0]["Payment_Type"].ToString();
                Uc_cost.ID.Text = dt_Q.Rows[0]["Sales_man_Id"].ToString();
                txt_address.Text = dt_Q.Rows[0]["Costomer_adress"].ToString();
                txt_custTel.Text = dt_Q.Rows[0]["Costomer_Phone"].ToString();
                txt_custFax.Text = dt_Q.Rows[0]["Costmer_fax"].ToString();
                CustomerRef.Text = dt_Q.Rows[0]["Ref"].ToString();
                txt_CustEmail.Text = dt_Q.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_Q.Rows[0]["TermsOfPaymentE"].ToString();
                ValidtyDays.Value = dt_Q.Rows[0]["Validity"].ToString().ParseInt(0);
                DelevryTearms.SelectedValue = dt_Q.Rows[0]["DelevryE"].ToString();
                if (dt_Q.Rows[0]["PERM_SER"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_Q.Rows[0]["BID"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }
                VAT_Acc.Text = dt_Q.Rows[0]["K_M_ACC_NO"].ToString();
                Cust_Vat_No.Text = dt_Q.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_Q.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_Q.Rows[0]["MAIN_KM_CODE"].ToString();
                txt_attn.Text = dt_Q.Rows[0]["Costomer_Notes"].ToString();
                //if (dt_Q.Rows[0]["KM_RATIO"].ToString() == string.Empty)
                //{ Cust_Vat_Rate.Text = "0.05"; }
                //else
                //{
                //    Cust_Vat_Rate.Text = dt_Q.Rows[0]["KM_RATIO"].ToString().ToDecimal().ToString("N2");
                //}
                Validty_Date.Value = txt_InvDate.Value.AddDays(ValidtyDays.Value);


               

                invGrid1.dgv1.Rows.Clear();
                int rowscount = dt_Q.Rows.Count;
                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)

                    {
                        invGrid1.dgv1.Rows[i].HeaderCell.Value = dt_Q.Rows[i]["main_counter"].ToString().ParseInt(0) + 1;
                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_Q.Rows[i]["ITEM_NO"].ToString();
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_Q.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_Q.Rows[i]["descr_eng"].ToString();
                        }


                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_Q.Rows[i]["DETAILS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_Q.Rows[i]["Unit"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_Q.Rows[i]["Weight"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_Q.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_Q.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = "0";
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_Q.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_Q.Rows[i]["TAX_OUT"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_Q.Rows[i]["disc_"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);

                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = dt_Q.Rows[i]["Pice_Total_Cost"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_Q.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                      
                    }
                }
                               
                invGrid1.total_inv();
                
                txtSearch.Text = "";

                groupPanel1.Visible = false;
                IsNew = false;
            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode==Keys.Enter && txtSearch.Text != string.Empty)
            {
                btnOk.Focus();
            }
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {


            string printModel = Properties.Settings.Default.inv_print;
            if (printModel == "1")
            {
                RPT.rpt_SalesQuotation rpt = new RPT.rpt_SalesQuotation();
                DataSet ds = new DataSet();
                getQuotation(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                ds.Tables.Add(dt_Q);
                //ds.WriteXmlSchema("schema_rpt.xml");
                rpt.SetDataSource(ds);
                rpt.DataDefinition.FormulaFields["decimal_"].Text = "'" + Properties.Settings.Default.digitNo_ + "'";
                rpt.DataDefinition.FormulaFields["Currency_"].Text = "'" + Properties.Settings.Default.Currency + "'";

                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, (Application.StartupPath + "\\attachment.pdf"));
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem email = (Outlook.MailItem)(oApp.CreateItem(Outlook.OlItemType.olMailItem));



                //email.Sender = Application.Sea
                email.To = "";
                email.CC = Properties.Settings.Default.EmailCC;
                //email.Attachments.Add(Application.StartupPath + "\\attachment.pdf");
                email.Subject = "Quotation No. : " + this.txt_InvNu.Text;
                email.HTMLBody = ReadSignature();//here is where you add the signature...
                                              //so this line will read... mi.HTMLBody + ReadSignature(); Problem fixed!!
                email.Display(true);
                //email.Send();
              
            }
        }

      private void btnCancel_Click(object sender, EventArgs e)
        {
               txtSearch.Clear();
            groupPanel1.Visible = false;
         
        }

        private void getQuotation(string ser_, string branch_, string transaction_, string cyear_)
        {
            try
            { //, ReportDB.dbo.Tafkeet('+@4+', '''+@5+''')  from wh_Po_Cot_inv_data As A
                dt_Q = dal.getDataTabl_1(@"select a.Ser_no,A.Branch_code,A.Transaction_code,A.Cyear,A.G_date,A.Acc_no,A.Acc_Branch_code,A.Payment_Type,a.Sales_man_Id,A.User_id,A.Validity,A.TermsOfPaymentE,A.DelevryE,
                A.Costomer_adress,A.Costomer_Phone,A.Costmer_fax,A.Ref,A.E_mail,A.PERM_SER,A.K_M_ACC_NO,A.COSTMER_K_M_NO,A.KM_CODE_ACC,A.MAIN_KM_CODE,A.Costomer_Notes,A.Cash_costomer_name,A.Costmer_no,
                B.main_counter, B.ITEM_NO,M.descr,M.Descr_eng,B.DETAILS,B.Unit,M.Weight,B.QTY_TAKE,B.Local_Price,B.TAX_OUT,M.balance,B.Pice_Total_Cost,B.K_M_TYPE_ITEMS,K.KM_RATIO,
               round(isnull(Nullif(b.total_disc,''),0)*QTY_TAKE/100,2) as disc_ ,B.total_disc,B.DISC_R,B.DISC_R2,B.DISC_R3,
                x.PAYER_NAME,x.payer_l_name,SP.Payment_name,SP.Notes,A.VAT_RATIO,DP.DeLEVRY_Name,DP.DELEVER_NAME_E,U.USER_NAME,BA.*, br.branch_name,BR.WH_E_NAME,Br.Branch_Logo_A4
            ,(select top 1 vat_ratio from VAT_RATIO_MASTER where cast(A.G_date as date ) between date_of_vat and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by date_of_vat desc) as VatRatio " +
                "from wh_Po_Cot_inv_data As A "+
                "Inner join wh_Po_Cot_MATERIAL_TRANSACTION As B " +
                "on A.Ser_no = B.SER_NO and A.Branch_code = B.Branch_code AND A.Transaction_code = B.TRANSACTION_CODE AND A.Cyear = B.Cyear " +
                "inner join wh_main_master AS M on M.item_no = B.ITEM_NO " +
                "left join KM_MATERIAL_CODE As K on K.KM_CODE = ISNULL(NULLIF(M.KM_CODE, ''), 1) " +
                "left join Sal_Pyment_type As SP on SP.Payment_type = A.TermsOfPaymentE " +
                "left join WH_PO_DELEVRY_CODE As DP on DP.DeLEVRY_CODE = A.DelevryE " +
                "inner join wh_USERS As U on U.USER_ID = A.USER_ID " +
                "left join BanksTbl AS BA on BA.BID = A.PERM_SER " +
                "inner join wh_BRANCHES As BR on BR.Branch_code = A.Branch_code " +

                "inner join(SELECT t1.Acc_no , t1.PREV_NO , t1.PAYER_NAME , t1.payer_l_name , t1.t_level , t1.t_final " +
                ", t1.MAIN_NO , t1.MAIN_MEZAN , t1.BRANCH_code , t1.Acc_stoped , t1.Max_Sales_Am , t1.Credit_AGE , t1.BRANCH_name " +
                ", t1.BRANCH_E_NAME , t1.med_MEZAN " +

                "from( select p.* ,B.BRANCH_name ,B.BRANCH_E_NAME ,ROW_NUMBER() OVER(PARTITION BY p.Acc_no ORDER BY p.acc_no) AS DuplicateCount " +
                "FROM payer2 As P inner join BRANCHS As B on P.BRANCH_code = B.BRANCH_code )  as t1 " +

                "where DuplicateCount = 1) as X  on A.Acc_no = X.acc_no and A.Branch_code = X.Branch_code "+
                "where A.Ser_no = '" + ser_ + "'  and A.Branch_code = '" + branch_ + "'  and A.transaction_code = '" + transaction_ + "'  and A.cyear = '" + cyear_ + "' order by B.main_counter  ");
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void BtnAttache_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.Application mailApp = new Outlook.Application();
                Outlook.NameSpace myNam = mailApp.GetNamespace("MAPI");

                myNam.Logon(null, null, true, true);


                Outlook.MAPIFolder ofold = myNam.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
                Outlook._MailItem mi = (Outlook._MailItem)mailApp.CreateItem(Outlook.OlItemType.olMailItem);
                mi.To = "";
                mi.CC = "mohsabry81@hotmail.com";
                //mi.CC = emailcc.Text;
                //mi.CC = emailcc.Text;
                //mi.CC = emailcc.Text;
                //mi.CC = emailcc.Text;
                //mi.CC = emailcc.Text;
                //mi.CC = emailcc.Text;
                //mi.CC = emailcc.Text;
                mi.SentOnBehalfOfName = "mycompany.com";
                mi.Subject = "";
                mi.HTMLBody = ReadSignature();//here is where you add the signature...
                                              //so this line will read... mi.HTMLBody + ReadSignature(); Problem fixed!!
                mi.Display(true);
                mi.SaveSentMessageFolder = ofold;
                mi.Send();
            }
            catch { }
        }
        private string ReadSignature()

        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
            if
            (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.*");

                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();
                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }

            }
            return signature;
        }

     
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            PL.frmAddPaymentTearms frm = new PL.frmAddPaymentTearms();
            frm.ShowDialog();
        }

        private void btnAddDelevery_Click(object sender, EventArgs e)
        {
            PL.frmAddDelevryTearms frm = new PL.frmAddDelevryTearms();
            frm.ShowDialog();
        }

        private void frmQuotation_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
             btnPrint.Visible = true;
            get_BasicData();
        }

        private void get_BasicData()
        {
            Uc_Acc.branchID.Text = Properties.Settings.Default.BranchId;
            Uc_Acc.txtFinal.Text = "1";
            Uc_Acc.txtMainAcc.Text = dal.getDataTabl_1(@"select Costmers_acc_no FROM wh_BRANCHES where BRANCH_code='" + Properties.Settings.Default.BranchId + "'").Rows[0][0].ToString(); ;
            Uc_Acc.txtAccCash.Text = "";

            //DataTable Dt_1 = dal.getDataTabl_1(@"SELECT B.SALES_ACC_NO , PAYER_NAME FROM wh_BRANCHES AS B inner join payer2 AS P on B.SALES_ACC_NO=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code");
            //txtAcc2_ID.Text = Dt_1.Rows[0][0].ToString();
            //txtAcc2_Desc.Text = Dt_1.Rows[0][1].ToString();

            //DataTable Dt_2 = dal.getDataTabl_1(@"SELECT B.Cash_acc_no , PAYER_NAME FROM wh_BRANCHES AS B inner join payer2 AS P on B.Cash_acc_no=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code");
            //txt_CashAcc_ID.Text = Dt_2.Rows[0][0].ToString();
            //txt_CashAcc_Desc.Text = Dt_2.Rows[0][1].ToString();

            //DataTable Dt_3 = dal.getDataTabl_1(@"SELECT B.K_M_ACC_NO_SALES , PAYER_NAME FROM wh_BRANCHES AS B inner join payer2 AS P on B.K_M_ACC_NO_SALES=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code");
            //Vat_acc.Text = Dt_3.Rows[0][0].ToString();
            //Vat_acc_Desc.Text = Dt_3.Rows[0][1].ToString();

        }

       
        private void Cust_Vat_Rate_TextChanged(object sender, EventArgs e)
        {
            invGrid1.txtAccVat_Rate.Text = Cust_Vat_Rate.Text;
        }

     
    }
}


     