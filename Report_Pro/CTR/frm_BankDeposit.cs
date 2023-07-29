using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;
using System.Globalization;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net;

namespace Report_Pro.CTR
{
    public partial class frm_BankDeposit : frm_Master
    {
        //string savtype = "0";
        //string btntype = "0";
        //Int32 m;

        string _languh = Properties.Settings.Default.lungh;
        public DataTable dt_jor = new DataTable();
        DAL.dbDataContext sdb = new DAL.dbDataContext();
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        Dates date_ = new Dates();
        DataTable dt_Bdata;
        public frm_BankDeposit()
        {
            InitializeComponent();

            dt_Bdata = dal.getDataTabl_1(@"select Costmers_acc_no,Bank_Cash_box,Cash_acc_no,Suppliers_acc_no,Expensive_Acc_no from wh_BRANCHES where Branch_code= '" + Properties.Settings.Default.BranchId + "' ");

            txtDepositType.DataSource = dal.getDataTabl_1("SELECT * FROM pay_method");
            if (Properties.Settings.Default.lungh == "0")
            {
                txtDepositType.DisplayMember = "Pay_name";
            }
            else
            {
                txtDepositType.DisplayMember = "Pay_name_E";
            }
            txtDepositType.ValueMember = "Pay_ID";
            txtDepositType.SelectedIndex = -1;


            New();
           

        }



        public frm_BankDeposit(string branchCode, string serNo)
        {
            InitializeComponent();
            showDetails(branchCode, serNo);
            txtSer_code.Text = "X1";
            txtSanad_type.Text = "6";
            IsNew = false;

        }









        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    


        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                txtDate.Text = date_.HijriToGreg(mTxt_H.Text, "");
                
            }
        }









      














      



      



        private void getJorSer()
        {
         


         

            DataTable dt_Ser = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) as ser,isnull((BOX_SARF_SER)+1,1) as BOX_SARF_SER,isnull((HEWALA_sarf_ser)+1,1) as HEWALA_sarf_ser from serial_no where Branch_code='" + AccBranch.ID.Text
                          + "' and ACC_YEAR= '" + txt_Cyear.Text + "' ");

            txtSerNo.TextS = dal.GetCell_1("select Main_Acc_Company from Wh_Configration").ToString() + dt_Ser.Rows[0]["ser"].ToString().PadLeft(4, '0');
            Main_serNo.Text = dt_Ser.Rows[0]["ser"].ToString();

            if (txt_Source_Code.Text == "CR")
            {
                txtSanadNo.TextS = dt_Ser.Rows[0]["BOX_SARF_SER"].ToString();
            }
            else if (txt_Source_Code.Text == "BP")
            {
                txtSanadNo.TextS = dt_Ser.Rows[0]["HEWALA_sarf_ser"].ToString();
            }


            //Main_serNo.Text = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchAccID
            //      + "' and ACC_YEAR= '" + txt_Cyear.Text + "'").Rows[0][0].ToString();
            //txtSerNo.TextS = dal.GetCell_1("select Main_Acc_Company from Wh_Configration").ToString() + Main_serNo.Text.PadLeft(4, '0');
            ////dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchAccID
            ////  + "' and ACC_YEAR= '" + txt_Cyear.Text + "'").Rows[0][0].ToString().PadLeft(4, '0');


            //txtSanadNo.TextS = dal.getDataTabl_1(@"select isnull(daily_sn_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchAccID
            //     + "' and ACC_YEAR= '" + txt_Cyear.Text + "' ").Rows[0][0].ToString();//.PadLeft(4, '0');



            //int JorSer;
            //if (txtSerNo.TextS.Contains('M'))
            //{
            //    var Jor_ser = txtSerNo.TextS.Split('M');
            //    JorSer = Convert.ToInt32(Jor_ser[1]);
            //}

            //else
            //{
            //    JorSer = Convert.ToInt32(txtSerNo.TextS);
            //}



        }


        private void getCloseJorSer()
        {

            this.txtSerNo.TextS = "C" + dal.getDataTabl_1(@"select isnull(max(last_ser)+1,1) from Serails_tbl where Baranch_ID='" + Properties.Settings.Default.BranchId
                     + "' and Cyear= '" + txt_Cyear.Text + "' and doc_Id =  'CENT'").Rows[0][0].ToString().PadLeft(4, '0');

            this.txtSanadNo.TextS = dal.getDataTabl_1(@"select isnull(max(last_ser)+1,1) from Serails_tbl where Baranch_ID='" + Properties.Settings.Default.BranchId
                 + "' and Cyear= '" + txt_Cyear.Text + "' and doc_Id =  'CENT'").Rows[0][0].ToString();//.PadLeft(4, '0');

        }


        private void showDetails(string _brnch, string _ser)
        {


            ////==============================  احضار تفاصيل القيد =========================================================//

            DataTable dt_db = new DataTable();
            DataTable dt_cr = new DataTable();
            dt_db.Clear();
            dt_cr.Clear();
            //dt_ = dal.getDataTabl("GetDaily_transaction", Properties.Settings.Default.BranchId, txtsearch.Text);
            dt_db = dal.getDataTabl_1(@"SELECT D.ACC_YEAR, D.ACC_NO, D.BRANCH_code, D.ser_no, D.sorting_ser, D.COST_CENTER, D.meno, D.loh, D.balance
                                    , D.h_date, D.g_date, D.sanad_no, d.SANAD_TYPE, D.user_name AS user_id, D.desc2, ISNULL(NULLIF(D.desc_E,''),D.desc2) AS desc_E, D.POASTING, D.CAT_CODE, D.notes
                                    , D.MAIN_SER_NO, SANAD_TYPE2, sp_ser_no, Supplier_Name, isnull(vat_amont, 0) as vat_amont, inv_no, inv_date, vat_no
									, P.PAYER_NAME,ISNULL(NULLIF(P.payer_l_name,''),P.PAYER_NAME) AS payer_l_name, C.COST_name
                                    ,ISNULL(NULLIF(C.COST_E_NAME,''),C.COST_name) AS COST_E_NAME , T.CAT_NAME,ISNULL(NULLIF(T.CAT_NAME_E,''),T.CAT_NAME) AS CAT_NAME_E, U.USER_NAME
                                    ,sheek_no,sheek_bank,sheek_date,sheek_or_cash,SOURCE_CODE,Sheek,payType_No,shequeBank_no
                                    FROM daily_transaction as D
                                    inner join payer2 as P on P.ACC_NO = D.ACC_NO and P.BRANCH_code = D.BRANCH_code
                                    left join COST_CENTER as C on C.COST_CODE = D.COST_CENTER
                                    left join CATEGORY as T on T.CAT_CODE = D.CAT_CODE
                                    inner join wh_USERS as U on U.USER_ID = D.user_name
                                    where  D.BRANCH_code = '" + _brnch + "' and D.ser_no = '" + _ser + "' and D.meno>0 order by sorting_ser");


            dt_cr = dal.getDataTabl_1(@"SELECT D.ACC_YEAR, D.ACC_NO, D.BRANCH_code, D.ser_no, D.sorting_ser, D.COST_CENTER, D.meno, D.loh, D.balance
                                    , D.h_date, D.g_date, D.sanad_no, d.SANAD_TYPE, D.user_name AS user_id, D.desc2, ISNULL(NULLIF(D.desc_E,''),D.desc2) AS desc_E, D.POASTING, D.CAT_CODE, D.notes
                                    , D.MAIN_SER_NO, SANAD_TYPE2, sp_ser_no, Supplier_Name, isnull(vat_amont, 0) as vat_amont, inv_no, inv_date, vat_no
									, P.PAYER_NAME,ISNULL(NULLIF(P.payer_l_name,''),P.PAYER_NAME) AS payer_l_name, C.COST_name
                                    ,ISNULL(NULLIF(C.COST_E_NAME,''),C.COST_name) AS COST_E_NAME , T.CAT_NAME,ISNULL(NULLIF(T.CAT_NAME_E,''),T.CAT_NAME) AS CAT_NAME_E, U.USER_NAME
                                    ,sheek_no,sheek_bank,sheek_date,sheek_or_cash,SOURCE_CODE,Sheek,payType_No,shequeBank_no                                   
                                    FROM daily_transaction as D
                                    inner join payer2 as P on P.ACC_NO = D.ACC_NO and P.BRANCH_code = D.BRANCH_code
                                    left join COST_CENTER as C on C.COST_CODE = D.COST_CENTER
                                    left join CATEGORY as T on T.CAT_CODE = D.CAT_CODE
                                    inner join wh_USERS as U on U.USER_ID = D.user_name
                                    where  D.BRANCH_code = '" + _brnch + "' and D.ser_no = '" + _ser + "' and D.loh>0 order by sorting_ser");



            if (dt_db.Rows.Count > 0 || dt_cr.Rows.Count > 0)
            {
                txtSerNo.TextS = dt_db.Rows[0]["ser_no"].ToString();
                mTxt_H.Text = dt_db.Rows[0]["h_date"].ToString();
                txtDate.Text = dt_db.Rows[0]["g_date"].ToString();
                txtSanadNo.TextS = dt_db.Rows[0]["sanad_no"].ToString();
                txtSanad_type.Text = dt_db.Rows[0]["SANAD_TYPE"].ToString();
                txtBankAcc.ID.Text = dt_db.Rows[0]["Acc_no"].ToString();
                txt_sp_ser.TextS = dt_db.Rows[0]["sp_ser_no"].ToString();
                txtMainNote.Text = dt_db.Rows[0]["notes"].ToString();
                txt_Cyear.Text = dt_db.Rows[0]["ACC_YEAR"].ToString();
                Main_serNo.Text = dt_db.Rows[0]["MAIN_SER_NO"].ToString();
                txtUser.Text = dt_db.Rows[0]["user_name"].ToString();
                txtSanad_type2.Text = dt_db.Rows[0]["SANAD_TYPE2"].ToString();
                txt_Sheek.Text = dt_db.Rows[0]["Sheek"].ToString();
                txt_Source_Code.Text = dt_db.Rows[0]["SOURCE_CODE"].ToString();
                txt_Pay_Type_No.Text = dt_db.Rows[0]["payType_No"].ToString();
                txt_Cheuqe_Or_Cash.Text = dt_db.Rows[0]["sheek_or_cash"].ToString();
                txt_Cheuqe_No.Text = dt_db.Rows[0]["sheek_no"].ToString();
                txt_Cheuqe_bank.Text = dt_db.Rows[0]["sheek_bank"].ToString();
                txtCheuqeDate.Text = dt_db.Rows[0]["sheek_date"].ToString();
                txt_Sheque_Bank_No.Text = dt_db.Rows[0]["shequeBank_no"].ToString();


                txtAmount.Text = Convert.ToDecimal(dt_cr.Rows[0]["loh"]).ToString("n" + dal.digits_);
                txtCreditAcc.ID.Text = dt_cr.Rows[0]["acc_no"].ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    txtMainNote.Text = dt_cr.Rows[0]["desc2"].ToString();
                }
                else
                {
                    txtMainNote.Text = dt_cr.Rows[0]["desc_E"].ToString();
                }
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgError") , dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void showDetailsbySanad(string _brnch, string _ser,string _code)
        {


            ////==============================  احضار تفاصيل القيد =========================================================//
            
            DataTable dt_db = new DataTable();
            DataTable dt_cr = new DataTable();
            dt_db.Clear();
            dt_cr.Clear();
            //dt_ = dal.getDataTabl("GetDaily_transaction", Properties.Settings.Default.BranchId, txtsearch.Text);
            dt_db = dal.getDataTabl_1(@"SELECT D.ACC_YEAR, D.ACC_NO, D.BRANCH_code, D.ser_no, D.sorting_ser, D.COST_CENTER, D.meno, D.loh, D.balance
                                    , D.h_date, D.g_date, D.sanad_no, d.SANAD_TYPE, D.user_name AS user_id, D.desc2, ISNULL(NULLIF(D.desc_E,''),D.desc2) AS desc_E, D.POASTING, D.CAT_CODE, D.notes
                                    , D.MAIN_SER_NO, SANAD_TYPE2, sp_ser_no, Supplier_Name, isnull(vat_amont, 0) as vat_amont, inv_no, inv_date, vat_no
									, P.PAYER_NAME,ISNULL(NULLIF(P.payer_l_name,''),P.PAYER_NAME) AS payer_l_name, C.COST_name
                                    ,ISNULL(NULLIF(C.COST_E_NAME,''),C.COST_name) AS COST_E_NAME , T.CAT_NAME,ISNULL(NULLIF(T.CAT_NAME_E,''),T.CAT_NAME) AS CAT_NAME_E, U.USER_NAME
                                    ,sheek_no,sheek_bank,sheek_date,sheek_or_cash,SOURCE_CODE,Sheek,payType_No,shequeBank_no
                                    FROM daily_transaction as D
                                    inner join payer2 as P on P.ACC_NO = D.ACC_NO and P.BRANCH_code = D.BRANCH_code
                                    left join COST_CENTER as C on C.COST_CODE = D.COST_CENTER
                                    left join CATEGORY as T on T.CAT_CODE = D.CAT_CODE
                                    inner join wh_USERS as U on U.USER_ID = D.user_name
                                    where  D.BRANCH_code = '" + _brnch + "' and D.sanad_no = '" + _ser + "' and SANAD_TYPE2 = '" + _code + "' and D.meno>0 order by sorting_ser");


            dt_cr = dal.getDataTabl_1(@"SELECT D.ACC_YEAR, D.ACC_NO, D.BRANCH_code, D.ser_no, D.sorting_ser, D.COST_CENTER, D.meno, D.loh, D.balance
                                    , D.h_date, D.g_date, D.sanad_no, d.SANAD_TYPE, D.user_name AS user_id, D.desc2, ISNULL(NULLIF(D.desc_E,''),D.desc2) AS desc_E, D.POASTING, D.CAT_CODE, D.notes
                                    , D.MAIN_SER_NO, SANAD_TYPE2, sp_ser_no, Supplier_Name, isnull(vat_amont, 0) as vat_amont, inv_no, inv_date, vat_no
									, P.PAYER_NAME,ISNULL(NULLIF(P.payer_l_name,''),P.PAYER_NAME) AS payer_l_name, C.COST_name
                                    ,ISNULL(NULLIF(C.COST_E_NAME,''),C.COST_name) AS COST_E_NAME , T.CAT_NAME,ISNULL(NULLIF(T.CAT_NAME_E,''),T.CAT_NAME) AS CAT_NAME_E, U.USER_NAME
                                    ,sheek_no,sheek_bank,sheek_date,sheek_or_cash,SOURCE_CODE,Sheek,payType_No,shequeBank_no                                   
                                    FROM daily_transaction as D
                                    inner join payer2 as P on P.ACC_NO = D.ACC_NO and P.BRANCH_code = D.BRANCH_code
                                    left join COST_CENTER as C on C.COST_CODE = D.COST_CENTER
                                    left join CATEGORY as T on T.CAT_CODE = D.CAT_CODE
                                    inner join wh_USERS as U on U.USER_ID = D.user_name
                                    where  D.BRANCH_code = '" + _brnch + "' and D.sanad_no = '" + _ser + "' and SANAD_TYPE2 = '"+_code+"' and D.loh>0 order by sorting_ser");


            if (dt_db.Rows.Count > 0 || dt_cr.Rows.Count > 0)
            {
                txtSerNo.TextS = dt_db.Rows[0]["ser_no"].ToString();
                mTxt_H.Text = dt_db.Rows[0]["h_date"].ToString();
                txtDate.Text = dt_db.Rows[0]["g_date"].ToString();
                txtSanadNo.TextS = dt_db.Rows[0]["sanad_no"].ToString();
                txtSanad_type.Text = dt_db.Rows[0]["SANAD_TYPE"].ToString();
                txt_sp_ser.TextS = dt_db.Rows[0]["sp_ser_no"].ToString();
                txtBankAcc.ID.Text = dt_db.Rows[0]["acc_no"].ToString();
                txtMainNote.Text = dt_db.Rows[0]["notes"].ToString();
                txt_Cyear.Text = dt_db.Rows[0]["ACC_YEAR"].ToString();
                Main_serNo.Text = dt_db.Rows[0]["MAIN_SER_NO"].ToString();
                txtUser.Text = dt_db.Rows[0]["user_name"].ToString();
                txtSanad_type2.Text = dt_db.Rows[0]["SANAD_TYPE2"].ToString();
                txt_Sheek.Text = dt_db.Rows[0]["Sheek"].ToString();
                txt_Source_Code.Text = dt_db.Rows[0]["SOURCE_CODE"].ToString();
                txtDepositType.SelectedValue = dt_db.Rows[0]["payType_No"].ToString();
                txt_Cheuqe_Or_Cash.Text = dt_db.Rows[0]["sheek_or_cash"].ToString();
                txtCheckNo.Text = dt_db.Rows[0]["sheek_no"].ToString();
                txtCheuqeDate.Text = dt_db.Rows[0]["sheek_date"].ToString();
                txtCustBank.ID.Text = dt_db.Rows[0]["shequeBank_no"].ToString();
                txtAmount.Text = Convert.ToDecimal(dt_db.Rows[0]["meno"]).ToString("n" + dal.digits_);
                txtCreditAcc.ID.Text = dt_cr.Rows[0]["acc_no"].ToString();

                if (Properties.Settings.Default.lungh == "0")
                {
                    txtMainNote.Text = dt_cr.Rows[0]["desc2"].ToString();
                }
                else
                {
                    txtMainNote.Text = dt_cr.Rows[0]["desc_E"].ToString();
                }
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgError"), dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }




        private void BNew_Click(object sender, EventArgs e)
        {
            newJor();
        }

        private void newJor()
        {

            btnSearch.Enabled = false;
            dal.ClearTextBoxes(this);

            txtDate.Value = DateTime.Now;
            txtDate.Format = DateTimePickerFormat.Custom;
            txtDate.CustomFormat = Properties.Settings.Default.DateFormate;
            txt_Cyear.Text = "cy";
            txt_Pay_Type_No.Text = "2";
            txtUser.Text = Program.userID;
            AccBranch.ID.Text = Properties.Settings.Default.BranchAccID;
            txt_Source_Code.Text = "CR";
            txtSanad_type2.Text = "CB";
            txtSer_code.Text = "X1";
            txtSanad_type.Text = "6";
            txtCreditAcc.ID.Text = dt_Bdata.Rows[0]["Cash_acc_no"].ToString();
            txtCreditAcc.txtFinal.Text = "1";
            txtCreditAcc.branchID.Text = Properties.Settings.Default.BranchId.ToString();
            txt_docId.Text = "JOR";
            txtBankAcc.txtMainAcc.Text = dt_Bdata.Rows[0]["Bank_Cash_box"].ToString();
            txtBankAcc.txtFinal.Text = "1";
            //savtype = "0";


            GDateToHDate();
            txtMainNote.Clear();
            txtSerNo.TextS = "";
            txtSanadNo.TextS = "";
            txt_sp_ser.TextS = "";
            dt_jor.Clear();
            //dGV_Item.DataSource = null;
            getJorSer();

         
          



        }




        private void updateJor()
        {
            if (dal.sqlconn_1.State == ConnectionState.Closed)
            {
                dal.sqlconn_1.Open();
            }

            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {

                if (txtAmount.Value > 0 && txtCreditAcc.ID.Text != string.Empty && txtBankAcc.ID.Text != string.Empty)
                {
                    cmd.CommandText = @"Delete from daily_transaction where Ser_no = '" + txtSerNo.TextS + "' and Branch_code = '" + Properties.Settings.Default.BranchAccID + "'  and ACC_YEAR = '" + txt_Cyear.Text + "' ";
                cmd.ExecuteNonQuery();

                    cmd.CommandText = @"insert into daily_transaction 
                            (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING
                            ,notes, CAT_CODE, MAIN_SER_NO,SANAD_TYPE2,D.desc_E
                            ,sheek_no,sheek_bank,sheek_date,sheek_or_cash
                            ,SOURCE_CODE,Sheek,payType_No,shequeBank_no)  
                            Values ('" + txt_Cyear.Text +
                                  "' , '" + txtBankAcc.ID.Text +
                                  "' , '" + Properties.Settings.Default.BranchAccID +
                                  "' , '" + txtSerNo.TextS.ToString() +
                                  "' , '" + 1 +
                                  "' , '" + txtAmount.Text.ToDecimal() +
                                  "' , '" + 0 +
                                  "' , '" + txtAmount.Text.ToDecimal() +
                                  "' , '" + mTxt_H.Text.ToString() +
                                  "' , '" + txtDate.Value.ToString("yyyy/MM/dd HH: mm:ss") +
                                  "' , '" + txtSanadNo.TextS +
                                  "' , '" + txtSanad_type.Text +
                                  "' , '" + Program.userID +
                                  "','" + (_languh == "0" ? txtMainNote.Text : dal.TranslateToAr(txtMainNote.Text)) +
                                  "' , '" + 0 +
                                  "' , '" + txtMainNote.Text +
                                  "' , '" + 1 +
                                  "' , '" + Main_serNo.Text +
                                  "' , '" + txtSanad_type2.Text +
                                 "','" + (_languh == "0" ? dal.TranslateToEn(txtMainNote.Text) : txtMainNote.Text) +
                                 "' , '" + txtCheckNo.Text +
                                 "' , '" + txtCustBank.Desc.Text +
                                 "' , '" + (dal.IsDateTime(txtCheuqeDate.Text) ? txtCheuqeDate.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null) +
                                 "' , '" + txt_Cheuqe_Or_Cash.Text +
                                 "' , '" + txt_Source_Code.Text +
                                 "' , '" + txtDepositType.Text +
                                 "' , '" + Convert.ToString(txtDepositType.SelectedValue) +
                                 "' , '" + txtCustBank.ID.Text + "' )";


                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"insert into daily_transaction 
                            (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING
                            ,notes, CAT_CODE, MAIN_SER_NO,SANAD_TYPE2,D.desc_E
                            ,sheek_no,sheek_bank,sheek_date,sheek_or_cash
                            ,SOURCE_CODE,Sheek,payType_No,shequeBank_no)  
                            Values ('" + txt_Cyear.Text +
                               "' , '" + txtCreditAcc.ID.Text +
                               "' , '" + Properties.Settings.Default.BranchAccID +
                               "' , '" + txtSerNo.TextS.ToString() +
                               "' , '" + 1 +
                               "' , '" + 0 +
                               "' , '" + txtAmount.Text.ToDecimal() +
                               "' , '" + -txtAmount.Text.ToDecimal() +
                               "' , '" + mTxt_H.Text.ToString() +
                               "' , '" + txtDate.Value.ToString("yyyy/MM/dd HH: mm:ss") +
                               "' , '" + txtSanadNo.TextS +
                               "' , '" + txtSanad_type.Text +
                               "' , '" + Program.userID +
                               "','" + (_languh == "0" ? txtMainNote.Text : dal.TranslateToAr(txtMainNote.Text)) +
                               "' , '" + 0 +
                               "' , '" + txtMainNote.Text +
                               "' , '" + 1 +
                               "' , '" + Main_serNo.Text +
                               "' , '" + txtSanad_type2.Text +
                              "','" + (_languh == "0" ? dal.TranslateToEn(txtMainNote.Text) : txtMainNote.Text) +

                              "' , '" + txtCheckNo.Text +
                              "' , '" + txtCustBank.Desc.Text +
                                 "' , '" + (dal.IsDateTime(txtCheuqeDate.Text) ? txtCheuqeDate.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null) +
                              "' , '" + txt_Cheuqe_Or_Cash.Text +
                              "' , '" + txt_Source_Code.Text +
                               "' , '" + txtDepositType.Text +
                            "' , '" + Convert.ToString(txtDepositType.SelectedValue) +
                            "' , '" + txtCustBank.ID.Text + "' )";


                    cmd.ExecuteNonQuery();
                    //}

                }


                trans.Commit();
                  MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

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



        private void addJor()
        {

            getJorSer();

            if (dal.sqlconn_1.State == ConnectionState.Closed)
            {
                dal.sqlconn_1.Open();
            }

            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {
                DateTime sheekDate = dal.IsDateTime(txtCheuqeDate.Text.ToString()) ? txtCheuqeDate.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null;


                if (txtAmount.Value > 0 && txtCreditAcc.ID.Text != string.Empty && txtBankAcc.ID.Text != string.Empty)
                {
                    
                    cmd.CommandText = @"insert into daily_transaction 
                            (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING
                            ,notes, CAT_CODE, MAIN_SER_NO,SANAD_TYPE2,D.desc_E
                            ,sheek_no,sheek_bank,sheek_date,sheek_or_cash
                            ,SOURCE_CODE,Sheek,payType_No,shequeBank_no)  
                            Values ('" + txt_Cyear.Text +
                             "' , '" + txtBankAcc.ID.Text +
                             "' , '" + Properties.Settings.Default.BranchAccID +
                             "' , '" + txtSerNo.TextS.ToString() +
                             "' , '" + 1 +
                             "' , '" + txtAmount.Text.ToDecimal() +
                             "' , '" + 0 +
                             "' , '" + txtAmount.Text.ToDecimal() +
                             "' , '" + mTxt_H.Text.ToString() +
                             "' , '" + txtDate.Value.ToString("yyyy/MM/dd HH: mm:ss") +
                             "' , '" + txtSanadNo.TextS +
                             "' , '" + txtSanad_type.Text +
                             "' , '" + Program.userID +
                             "','" + (_languh == "0" ? txtMainNote.Text : dal.TranslateToAr(txtMainNote.Text)) +
                             "' , '" + 0 +
                             "' , '" + txtMainNote.Text +
                             "' , '" + 1 +
                             "' , '" + Main_serNo.Text +
                             "' , '" + txtSanad_type2.Text +
                            "','" + (_languh == "0" ? dal.TranslateToEn(txtMainNote.Text) : txtMainNote.Text) +
                            "' , '" + txtCheckNo.Text +
                            "' , '" + txtCustBank.Desc.Text +
                            "' , '" + sheekDate+
                            "' , '" + txt_Cheuqe_Or_Cash.Text +
                            "' , '" + txt_Source_Code.Text +
                            "' , '" + txtDepositType.Text +
                            "' , '" + Convert.ToString(txtDepositType.SelectedValue) +
                            "' , '" + txtCustBank.ID.Text + "' )";


                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"insert into daily_transaction 
                            (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING
                            ,notes, CAT_CODE, MAIN_SER_NO,SANAD_TYPE2,D.desc_E
                            ,sheek_no,sheek_bank,sheek_date,sheek_or_cash
                            ,SOURCE_CODE,Sheek,payType_No,shequeBank_no)  
                            Values ('" + txt_Cyear.Text +
                               "' , '" + txtCreditAcc.ID.Text +
                               "' , '" + Properties.Settings.Default.BranchAccID +
                               "' , '" + txtSerNo.TextS.ToString() +
                               "' , '" + 1 +
                               "' , '" + 0 +
                               "' , '" + txtAmount.Text.ToDecimal() +
                               "' , '" + -txtAmount.Text.ToDecimal() +
                               "' , '" + mTxt_H.Text.ToString() +
                               "' , '" + txtDate.Value.ToString("yyyy/MM/dd HH: mm:ss") +
                               "' , '" + txtSanadNo.TextS +
                               "' , '" + txtSanad_type.Text +
                               "' , '" + Program.userID +
                               "','" + (_languh == "0" ? txtMainNote.Text : dal.TranslateToAr(txtMainNote.Text)) +
                               "' , '" + 0 +
                               "' , '" + txtMainNote.Text +
                               "' , '" + 1 +
                               "' , '" + Main_serNo.Text +
                               "' , '" + txtSanad_type2.Text +
                              "','" + (_languh == "0" ? dal.TranslateToEn(txtMainNote.Text) : txtMainNote.Text) +

                              "' , '" + txtCheckNo.Text +
                              "' , '" + txtCustBank.Desc.Text +
                            "' , '" + sheekDate +
                              "' , '" + txt_Cheuqe_Or_Cash.Text +
                              "' , '" + txt_Source_Code.Text +
                               "' , '" + txtDepositType.Text +
                            "' , '" + Convert.ToString(txtDepositType.SelectedValue) +
                            "' , '" + txtCustBank.ID.Text + "' )";


                    cmd.ExecuteNonQuery();
                    //}

                }


                cmd.CommandText = @"UPDATE serial_no SET  main_daily_ser = '" + Main_serNo.Text + "' ,BOX_SARF_SER ='"+txtSanadNo.TextS+"' WHERE BRANCH_CODE=  '" + Properties.Settings.Default.BranchAccID + "' and ACC_YEAR='" + txt_Cyear.Text + "' ";
                cmd.ExecuteNonQuery();

                trans.Commit();
                          MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
                
            }
            finally
            {
                dal.sqlconn_1.Close();
            }


        }


      

        public override void Save()
        {

            



            if (IsNew == false)
            {
                updateJor();
                sdb.SubmitChanges();
            }

            else if (IsNew == true)
            {
               
                addJor();
                sdb.SubmitChanges();
            }

            
            base.Save();
        }

      

        public override void Print()
        {
            

            RPT.Form1 frm = new RPT.Form1();

            //  RPT.rpt_DailyEntry rpt_DailyEntry = new RPT.rpt_DailyEntry();
            DataTable dt_db = dal.getDataTabl_1(@"SELECT D.ACC_NO,D.BRANCH_code,D.ser_no,D.sorting_ser
                ,D.COST_CENTER,D.CAT_CODE,D.meno,D.loh,D.balance,D.h_date,D.g_date,D.sanad_no,D.desc2 ,D.desc_E,D.Supplier_Name
                ,D.vat_amont,D.vat_no,D.inv_date,D.vat_no,P.PAYER_NAME,isnull(P.payer_l_name,P.PAYER_NAME)as payer_l_name 
                ,C.COST_name,isnull(C.COST_E_NAME,C.COST_name) as COST_E_NAME
                ,T.CAT_NAME,isnull(T.CAT_NAME_E,T.CAT_NAME) as CAT_NAME_E
                ,U.USER_NAME,B.BRANCH_name,B.BRANCH_E_NAME,sheek_no,sheek_date
                            ,SOURCE_CODE,Sheek,payType_No,shequeBank_no,Bt.BANK_NAME,bt.BANK_NAME_E,Pm.Pay_name,Pm.Pay_name_E
                FROM daily_transaction as D
                inner join payer2 as P on P.ACC_NO=D.ACC_NO and P.BRANCH_code=D.BRANCH_code
                left join COST_CENTER  as C on C.COST_CODE=D.COST_CENTER
                left join CATEGORY as T on T.CAT_CODE=D.CAT_CODE
                inner join wh_USERS as U on U.USER_ID=D.user_name
				inner join BRANCHS As B on B.BRANCH_code = D.BRANCH_code
				left join SHEEK_BANKS_TYPE as Bt on Bt.BANK_NO = D.shequeBank_no
           		left join pay_method as Pm on Pm.Pay_ID = D.payType_No
           
                where  D.meno>0 and D.BRANCH_code='" + Properties.Settings.Default.BranchAccID + "' and D.ser_no='" + txtSerNo.TextS + "' order by sorting_ser");

            DataTable dt_cr = dal.getDataTabl_1(@"SELECT D.ACC_NO,D.BRANCH_code,D.ser_no,D.sorting_ser
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
           
                where  D.loh>0 and D.BRANCH_code='" + Properties.Settings.Default.BranchAccID + "' and D.ser_no='" + txtSerNo.TextS + "' order by sorting_ser");

            DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp where Company_No='A'");



            DataSet ds = new DataSet();
            ds.Tables.Add(dt_db);
            ds.Tables.Add(dt_cr);
            ds.Tables.Add(dt_Co);
          //  ds.WriteXmlSchema("schema_rpt.xml");

            if (Properties.Settings.Default.lungh == "0")
            {
                CTR.rpt_BankDeposit rpt_DailyEntry = new CTR.rpt_BankDeposit();
                rpt_DailyEntry.SetDataSource(ds);
                rpt_DailyEntry.SetParameterValue("EnterLanguh", "1");

                rpt_DailyEntry.DataDefinition.FormulaFields["_digits"].Text = "'" + dal.digits_ + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + AccBranch.ID.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + AccBranch.Desc.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName_E"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                ToWord toWord = new ToWord(Math.Abs(Math.Round(dt_db.Rows[0]["meno"].ToString().ToDecimal(), dal.digits_)), dal.currencies[dal.currency_No()]);
                rpt_DailyEntry.DataDefinition.FormulaFields["Tafqeet"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";


                frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            }
            else
            {
                CTR.rpt_BankDeposit rpt_DailyEntry = new CTR.rpt_BankDeposit();
                rpt_DailyEntry.SetDataSource(ds);
                rpt_DailyEntry.SetParameterValue("EnterLanguh", "0");
                rpt_DailyEntry.DataDefinition.FormulaFields["_digits"].Text = "'" + dal.digits_ + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + AccBranch.ID.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + AccBranch.Desc.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName_E"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            }
           frm.ShowDialog();





            //rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + AccBranch.ID.Text + "'";
            //rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + AccBranch.Desc.Text + "'";
            //rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";

            //frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            //frm.ShowDialog();

            base.Print();
        }


        public override void New()
        {
            newJor();

            base.New();
        }



        public override void GoFrist()
        {

            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@" select DISTINCT cast(sanad_no as int) as sanad_no from daily_transaction
            where SANAD_TYPE2='CB' and BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' order by sanad_no");

            Bnd1.DataSource = dtNaf;
            //int RowNo = Bnd1.Find("ser_no", txtSerNo.TextS);
            //if (RowNo != -1)
            //{
                //RowNo is that Row
                MyResult = dtNaf.Rows[0]["sanad_no"].ToString();
            //}
            //else
            //{ //RowNo is that Row
            //    MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            //}






            showDetailsbySanad(AccBranch.ID.Text, MyResult, "CB");


            base.GoFrist();

        }


        public override void GoPrevious()
        {

            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";

            dtNaf = dal.getDataTabl_1(@" select DISTINCT cast(sanad_no as int) as sanad_no from daily_transaction
            where SANAD_TYPE2='CB' and BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' order by sanad_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("sanad_no", txtSanadNo.TextS);
            if (RowNo == -1)
            {
                MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["sanad_no"].ToString();
            }
            else if (RowNo == 0)
            {
                MyResult = dtNaf.Rows[0]["sanad_no"].ToString();

            }
            else
            {
                MyResult = dtNaf.Rows[RowNo - 1]["sanad_no"].ToString();
            }

            showDetailsbySanad(AccBranch.ID.Text, MyResult, "CB");
            IsNew = false;


            base.GoPrevious();

        }


        public override void GoNext()
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";

            dtNaf = dal.getDataTabl_1(@" select DISTINCT cast(sanad_no as int) as sanad_no from daily_transaction
            where SANAD_TYPE2='CB' and BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' order  by sanad_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("sanad_no", txtSanadNo.TextS);
            if (RowNo < dtNaf.Rows.Count -1 && RowNo != -1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[RowNo + 1]["sanad_no"].ToString();
                showDetailsbySanad(AccBranch.ID.Text, MyResult,"CB");
            }
           
            base.GoNext();
        }

        public override void GoLast()
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";

            dtNaf = dal.getDataTabl_1(@" select DISTINCT cast(sanad_no as int) as sanad_no from daily_transaction
            where SANAD_TYPE2='CB' and BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "'  order by sanad_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("sanad_no", txtSanadNo.TextS);
                  MyResult = dtNaf.Rows[dtNaf.Rows.Count- 1]["sanad_no"].ToString();
            MyResult = dtNaf.Rows[RowNo - 1]["sanad_no"].ToString(); showDetailsbySanad(AccBranch.ID.Text, MyResult, "CB");



            base.GoLast();
        }

        public override void Attachment()

        //    (select ser_no, MAIN_SER_NO, ROW_NUMBER() OVER(PARTITION BY ser_no ORDER BY ser_no) AS DuplicateCount
        //FROM daily_transaction

        {
            DataTable dt_ = dal.getDataTabl_1(@"select ser_no from daily_transaction where Ser_no= '" + txtSerNo.TextS + "' and ACC_YEAR ='" + txt_Cyear.Text + "' and Branch_code = '" + AccBranch.ID.Text + "'");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = txtSerNo.TextS;
                frmUpload.docType = "JOR";
                frmUpload.branchID = Properties.Settings.Default.BranchAccID;
                frmUpload.ShowDialog();
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            base.Attachment();
        }



        private void BExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void txtAccId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }





        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void dTime_1_Leave(object sender, EventArgs e)
        {

      //      GDateToHDate();

        }

        private void GDateToHDate()
        {
            try
            {
                DataTable dtCurrntdate_ = dal.getDataTabl_1("select FORMAT ( '" + txtDate.Value + "', 'dd/MM/yyyy', 'ar-SA' )");
                mTxt_H.Text = dtCurrntdate_.Rows[0][0].ToString();
                mTxt_H.Mask = "00/00/0000";
            }


            catch { }
        }
      

       
        private void frmJornal_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = false;
            btnPreviewDaliyEntry.Visible = true;
            
        }


        public override void PreviewDeailyEntry(string _ser, string _branch, string _cyear)
        {
            base.PreviewDeailyEntry(txtSerNo.TextS,AccBranch.ID.Text, txt_Cyear.Text);
        }

        private void frmJornal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //            // Save column state data
            //            // including order, column width and whether or not the column is visible
            //            StringCollection stringCollection = new StringCollection();
            //#if true    // 2009/03/26:  This is the fix for the column order issue reported by Kevin Van Puyvelde
            //            int i = 0;
            //            foreach (DataGridViewColumn column in this.dGV_Item.Columns)
            //            {
            //                stringCollection.Add(string.Format(
            //                    "{0},{1},{2},{3}",
            //                    column.DisplayIndex.ToString("D2"), // Column order fix
            //                    column.Width,
            //                    column.Visible,
            //                    i++));
            //            }
            //#else       // *** This is the old code
            //            foreach(DataGridViewColumn column in this.contractorsDataGridView.Columns) {
            //                stringCollection.Add(string.Format(
            //                    "{0},{1},{2}",
            //                    column.DisplayIndex,
            //                    column.Width,
            //                    column.Visible));
            //            }
            //#endif
            //            Properties.Settings.Default.DGVFC_frmJornal = stringCollection;

            //            // Save location and size data
            //            // RestoreBounds remembers normal position if minimized or maximized
            //            if (this.WindowState == FormWindowState.Normal)
            //            {
            //                Properties.Settings.Default.DGVFL_frmJornal = this.Location;
            //                Properties.Settings.Default.DGVFS_frmJornal = this.Size;
            //            }
            //            else
            //            {
            //                Properties.Settings.Default.DGVFL_frmJornal = this.RestoreBounds.Location;
            //                Properties.Settings.Default.DGVFS_frmJornal = this.RestoreBounds.Size;
            //            }

            //            // Save the data
            //            Properties.Settings.Default.Save();
        }







        //void creatDattable()
        //{
        //   // dt_jor.Columns.Add("مدين");
        //   // dt_jor.Columns.Add(" دائن");
        //   // dt_jor.Columns.Add(" كود الحساب");
        //   // dt_jor.Columns.Add(" اسم الحساب");
        //   // dt_jor.Columns.Add("البيان");
        //   // dt_jor.Columns.Add(" كود الكلفة");
        //   // dt_jor.Columns.Add("مركز الكلفة");
        //   // dt_jor.Columns.Add("رقم التصنيف");
        //   // dt_jor.Columns.Add("التصنيف");
        //   // dt_jor.Columns.Add("المورد");
        //   // dt_jor.Columns.Add("قيمة الفاتورة");
        //   // dt_jor.Columns.Add("رقم الفاتورة");
        //   // dt_jor.Columns.Add("تاريخ الفاتورة");
        //   // dt_jor.Columns.Add("الرقم الضريبي");
        //   //// dGV_Item.DataSource = dt_jor;
           
        //}

      
     
    

      

      
      
     
       

    



        private void mTxt_H_KeyUp(object sender, KeyEventArgs e)
        {
            mTxt_H.Text = date_.GregToHijri(txtDate.Text);
        }



    
   



        

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txt_docId.Text = "CENT";
            getCloseJorSer();
          
        }

      

     

        private void mTxt_H_Click(object sender, EventArgs e)
        {
            mTxt_H.Focus();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mTxt_H.Text = date_.GregToHijri(txtDate.Text);

            }
        }

     
      



       

        private void txt_Db_Enter(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => (sender as TextBox).SelectAll()));

        }

        private void txt_Cr_Enter(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => (sender as TextBox).SelectAll()));

        }

        private void btnChooseBranch_Click(object sender, EventArgs e)
        {
            PL.frm_ChoseAccBranch frm = new PL.frm_ChoseAccBranch();
            frm.ShowDialog();
            newJor();


        }

     
    
        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            mTxt_H.Text = date_.GregToHijri(txtDate.Text);
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            mTxt_H.Text = date_.GregToHijri(txtDate.Text);
        }


        private void AccBranch_Load(object sender, EventArgs e)
        {
          //  db.txtAccBranch.Text = AccBranch.ID.Text;
        }

        private void txtSerNo_Click(object sender, EventArgs e)
        {
            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            showDetails(AccBranch.ID.Text, frm.txtSearch.t.Text);
            IsNew = false;
           
        }

       
        private void txtSanadNo_Click(object sender, EventArgs e)
        {

            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            showDetailsbySanad(AccBranch.ID.Text, frm.txtSearch.t.Text,"CB");
            IsNew = false;
        }

        private void txtCreditAcc_Load(object sender, EventArgs e)
        {

        }

        private void txtDepositType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (Convert.ToString(txtDepositType.SelectedValue) == "04")
            {
                txtCheckNo.Enabled    = true;
                txtCustBank.Enabled   = true;
                txtCheuqeDate.Enabled = true;
            }
            else
            {
                txtCheckNo.Enabled     = false;
                txtCustBank.Enabled    = false;
                txtCheuqeDate.Enabled = false;
                
            }
        }
    }
}

