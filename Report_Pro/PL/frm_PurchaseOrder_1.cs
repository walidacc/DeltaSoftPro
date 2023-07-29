using Report_Pro.Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Report_Pro.PL
{
    public partial class frm_PurchaseOrder_1 : frm_Master
    {
        
       
        DataTable dt_Q;
        Dates date_ = new Dates();
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        int currencyNo = 2;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();




        public frm_PurchaseOrder_1()
        {

            InitializeComponent();

            

            comboBox1.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            comboBox1.SelectedItem = DateTime.Now.Year;

            foreach (DataGridViewRow row in this.invGrid1.dgv1.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                invGrid1.dgv1.EnableHeadersVisualStyles = false;
            }

            


           
            New();
            RefreshData();
        }

        public frm_PurchaseOrder_1(string ser, string branch, string transaction, string year)
        {
            InitializeComponent();
            New();
            getPO(ser, branch, transaction, year);
            IsNew = false;

        }


       


        public override void New()
        {

            ClearTextBoxes();
            btn_UpdateApproved.Enabled = Session.UserSettings.General.CanChangeStore;
            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranch_Id.Text = Properties.Settings.Default.BranchAccID;
            userID.Text = Program.userID;

            FillComboCurrency();
            fillDelevryTearms();
            fillPaymentTearms();
            get_invSer();
            txt_InvSM.Text = Program.salesman;
            txtSupplier.txtMainAcc.Text = "234";
            txtSupplier.txtFinal.Text = "1";
            txtSupplier.branchID.Text = txtBranch.txtAccBranch.Text;

            invGrid1.dgv1.Rows.Clear();
            tabControlPanel1.Enabled = true;
            tabControlPanel2.Enabled = true;
            tabControlPanel3.Enabled = true;
            //txtBranch.Enabled = true;
            txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            GetBranchData(txtBranch.ID.Text);
            Ch_Aprrove.Checked = false;
            txt_Cyear.Text = Properties.Settings.Default.C_year;
            txt_InvNot.Focus();
            base.New();
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public override void Search()
        {
            groupBox1.Visible = true;
            comboBox1.SelectedItem = DateTime.Now.Year;
            txtsearch.Focus();
            base.Search();
        }
       

        private void txt_InvNot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                invGrid1.dgv1.CurrentCell = invGrid1.dgv1[0, 0];
            }
        }

        private void get_invSer()
        {
            txtMainSer.Text = dal.getDataTabl_1(@"select isnull(PS+1,1) from wh_Serial_MAIN where  Cyear=(select Cyear from Wh_Configration)").Rows[0][0].ToString();

            DataTable dtSer = dal.getDataTabl_1(@"select isnull(PS+1,1) from wh_Serial where Branch_code= '" + txtBranch.ID.Text + "' and Cyear=(select Cyear from Wh_Configration)");
            if (dtSer.Rows.Count > 0)
            {
                txt_InvNu.Text = dtSer.Rows[0][0].ToString();
            }
            else
            {
                txt_InvNu.Clear();
            }
        }

       
 
        bool IsGridValid()
        {

            int countR = 0;

            foreach (DataGridViewRow r in invGrid1.dgv1.Rows)
            {
                if (r.Cells["_code"].FormattedValue.ToString() != string.Empty && r.Cells["_qty"].FormattedValue.ToString().ToDecimal() > 0 && r.Cells["_price"].FormattedValue.ToString().ToDecimal() > 0)
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
                //if (IsNew == false)
                //{
                    cmd.CommandText = "delete from wh_Po_Cot_MATERIAL_TRANSACTION where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                    "' and TRANSACTION_CODE = '" + txt_transaction_code.Text + "' and Cyear = '" + txt_Cyear.Text + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from wh_Po_Cot_inv_data where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                    "' and TRANSACTION_CODE = '" + txt_transaction_code.Text + "' and Cyear = '" + txt_Cyear.Text + "'";
                    cmd.ExecuteNonQuery();
                //}
                //else
                //{
                //    get_invSer();
                //}
                //اضافة الفاتورة الجديدة
                cmd.CommandText = @"insert into wh_Po_Cot_inv_data
                (Ser_no,Branch_code,Transaction_code,Cyear,Sanad_no
                ,G_date,ACC_TYPE,Acc_no,Acc_Branch_code,Payment_Type
                ,Sales_man_Id,User_id,Po_Status,Cash_costomer_name,Costomer_Notes
                ,Costomer_adress,Costomer_Phone,Costmer_fax,Ref,E_mail
                ,TermsOfPayment,Validity,DelevryE,requist_no,FORIN_TYPE
                ,PRINTING_SECURTY,TermsOfPaymentE,PREPAREDby,RECEVEDby,TO_BRANCH
                ,CANCELED,aprovedBY,K_M_ACC_NO,K_M_Credit_TAX,K_M_Debit_TAX
                ,COSTMER_K_M_NO,K_M_SER,KM_CODE_ACC,MAIN_KM_CODE,OPEN_VAT
                ,requstedBy)
                values
                ('" + txt_InvNu.Text +
                "', '" + txtStore_ID.Text +
                "', '" + txt_transaction_code.Text +
                "', '" + txt_Cyear.Text.ToString() +
                "' ,'" + txtMainSer.Text +
                "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                "','A', '" +
                txtSupplier.ID.Text +
                "', '" + txtBranch_Id.Text +
                "', '" + Payment.ID.Text +
                "', '" + Uc_Cost.ID.Text +
                "' , '" + userID.Text +
                "','" + (chStop.Checked ? "S" : "") + 
                "','" + txtSuppContact.Text +
                "','" + txt_InvNot.Text +
                "', '" + txt_address.Text +
                "', '" + txt_custTel.Text +
                "','" + txt_custFax.Text +
                "','" + txtRefrance.Text +
                "','" + txt_CustEmail.Text +
                "','" + Payment.Desc.Text +
                "','" + ValidtyDays.Text +
                "','" + Convert.ToString(DelevryTearms.SelectedValue) +
                "','0','" +
                Convert.ToString(txtcurrency.SelectedValue) +
                "','1','" +
                Convert.ToString(PaymentTearms.SelectedValue) +
                "','" + userID.Text +
                "','" + Confirm_Persson.ID.Text +
                "','" + txtBranch.ID.Text +
                "','" + (chCanceled.Checked ? "C" : "") +
                "','" + Authorized_Persson.ID.Text +
                "', '" + txtVatAcc.ID.Text +
                "','0','" +
                invGrid1.txtTotalVAT.Text.ToDecimal() +
                "', '" + Cust_Vat_No.Text +
                "', '1','" +
                txtKmCode.Text +
                "','" + Vat_Class.Text +
                "','" + (chVAT.Checked ? "1" : "0") +
                "','" + Requst_Persson.ID.Text + "')";
                cmd.ExecuteNonQuery();


                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if ((invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty || invGrid1.dgv1.Rows[i].Cells["_code"].Value != null)
                        && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                        && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                    )
                    {
                        cmd.CommandText = @" insert into wh_Po_Cot_MATERIAL_TRANSACTION 
                    (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO
                    ,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc
                    ,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Local_Price,FORIN_TYPE
                    ,USER_ID,main_counter,balance,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,DETAILS,QTY_ADD2,QTY_TAKE2) 
                    values( '" + txt_InvNu.Text
                        + "', '" + txtStore_ID.Text
                        + "', '" + txt_transaction_code.Text
                        + "', '" + txt_Cyear.Text
                        + "' ,'" + txtMainSer.Text
                        + "','" + invGrid1.dgv1.Rows[i].Cells["_code"].Value
                        + "' ,'0','" + invGrid1.dgv1.Rows[i].Cells["_qty"].Value.ToString().ToDecimal()
                        + "','" + invGrid1.dgv1.Rows[i].Cells["_cost"].Value.ToString().ToDecimal()
                        + "','" + ((invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()) + invGrid1.disc_Rate.Text.ToDecimal()) * 100
                        + "' ,'" + (invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()) * 100
                        + "' ,'0','" + (invGrid1.disc_Rate.Text.ToDecimal()) * 100
                        + "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        + "','" + invGrid1.dgv1.Rows[i].Cells["_unit"].Value
                        + "' ,'" + invGrid1.dgv1.Rows[i].Cells["_price"].Value.ToString().ToDecimal()
                        + "' , '" + Convert.ToString(txtcurrency.SelectedValue)
                        + "' , '" + userID.Text
                        + "','" + invGrid1.dgv1.Rows[i].Index
                        + "', '" + invGrid1.dgv1.Rows[i].Cells["_balance"].Value.ToString().ToDecimal()
                        + "','" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value
                        + "' ,'" + invGrid1.dgv1.Rows[i].Cells["_vat"].Value.ToString().ToDecimal()
                        + "', '0','" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value 
                        + "','0','"+ invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value.ToString().ToDecimal()+"')";

                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                IsNew = false;
                MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                


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


        private void Add_wh_Po_Cot_inv_data()
        {

            if (IsNew == true)
            {
                get_invSer();
            }
                dal.open_1();
            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {

                // Add New Po

                if (IsNew == true)
                {

                    cmd.CommandText = @"UPDATE wh_Serial_MAIN SET PS = '" + txtMainSer.Text + "' WHERE Cyear='" + txt_Cyear.Text + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"UPDATE wh_Serial SET PS = '" + txt_InvNu.Text + "' WHERE Branch_code = '" + txtStore_ID.Text + "' and Cyear='" + txt_Cyear.Text + "'";
                    cmd.ExecuteNonQuery();

                    //اضافة الفاتورة الجديدة
                    cmd.CommandText = @"insert into wh_Po_Cot_inv_data
                (Ser_no,Branch_code,Transaction_code,Cyear,Sanad_no
                ,G_date,ACC_TYPE,Acc_no,Acc_Branch_code,Payment_Type
                ,Sales_man_Id,User_id,Po_Status,Cash_costomer_name,Costomer_Notes
                ,Costomer_adress,Costomer_Phone,Costmer_fax,Ref,E_mail
                ,TermsOfPayment,Validity,DelevryE,requist_no,FORIN_TYPE
                ,PRINTING_SECURTY,TermsOfPaymentE,PREPAREDby,RECEVEDby,TO_BRANCH
                ,CANCELED,aprovedBY,K_M_ACC_NO,K_M_Credit_TAX,K_M_Debit_TAX
                ,COSTMER_K_M_NO,K_M_SER,KM_CODE_ACC,MAIN_KM_CODE,OPEN_VAT
                ,requstedBy)
                values
                ('" + txt_InvNu.Text +
                    "', '" + txtStore_ID.Text +
                    "', '" + txt_transaction_code.Text +
                    "', '" + txt_Cyear.Text.ToString() +
                    "' ,'" + txtMainSer.Text +
                    "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                    "','A', '" +
                    txtSupplier.ID.Text +
                    "', '" + txtBranch_Id.Text +
                    "', '" + Payment.ID.Text +
                    "', '" + Uc_Cost.ID.Text +
                    "' , '" + userID.Text +
                    "','" + (chStop.Checked ? "S" : "") +
                    "','" + txtSuppContact.Text +
                    "','" + txt_InvNot.Text +
                    "', '" + txt_address.Text +
                    "', '" + txt_custTel.Text +
                    "','" + txt_custFax.Text +
                    "','" + txtRefrance.Text +
                    "','" + txt_CustEmail.Text +
                    "','" + Payment.Desc.Text +
                    "','" + ValidtyDays.Text +
                    "','" + Convert.ToString(DelevryTearms.SelectedValue) +
                    "','0','" +
                    Convert.ToString(txtcurrency.SelectedValue) +
                    "','1','" +
                    Convert.ToString(PaymentTearms.SelectedValue) +
                    "','" + userID.Text +
                    "','" + Confirm_Persson.ID.Text +
                    "','" + txtBranch.ID.Text +

                    "','" + (chCanceled.Checked ? "C" : "") +
                    "','" + Authorized_Persson.ID.Text +
                    "', '" + txtVatAcc.ID.Text +
                    "','0','" +
                   invGrid1.txtTotalVAT.Text.ToDecimal() +
                    "', '" + Cust_Vat_No.Text +
                    "', '1','" +
                    txtKmCode.Text +
                    "','" + Vat_Class.Text +
                    "','" + (chVAT.Checked ? "1" : "0") +
                    "','" + Requst_Persson.ID.Text +
                    "')";
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                    {
                        if ((invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty || invGrid1.dgv1.Rows[i].Cells["_code"].Value != null)
                            && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                            && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                        )
                        {
                            cmd.CommandText = @" insert into wh_Po_Cot_MATERIAL_TRANSACTION 
                    (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO
                    ,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc
                    ,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Local_Price,FORIN_TYPE
                    ,USER_ID,main_counter,balance,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,DETAILS,QTY_ADD2,QTY_TAKE2) 
                    values( '" + txt_InvNu.Text
                            + "', '" + txtStore_ID.Text
                            + "', '" + txt_transaction_code.Text
                            + "', '" + txt_Cyear.Text
                            + "' ,'" + txtMainSer.Text
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_code"].Value
                            + "' ,'0','" + invGrid1.dgv1.Rows[i].Cells["_qty"].Value.ToString().ToDecimal()
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_cost"].Value.ToString().ToDecimal()
                            + "','" + ((invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()) + invGrid1.disc_Rate.Text.ToDecimal()) * 100
                            + "' ,'" + (invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()) * 100
                            + "' ,'0','" + (invGrid1.disc_Rate.Text.ToDecimal()) * 100
                            + "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_unit"].Value
                            + "' ,'" + invGrid1.dgv1.Rows[i].Cells["_price"].Value.ToString().ToDecimal()
                            + "' , '" + Convert.ToString(txtcurrency.SelectedValue)
                            + "' , '" + userID.Text
                            + "','" + invGrid1.dgv1.Rows[i].Index
                            + "', '" + invGrid1.dgv1.Rows[i].Cells["_balance"].Value.ToString().ToDecimal()
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value
                            + "' ,'" + invGrid1.dgv1.Rows[i].Cells["_vat"].Value.ToString().ToDecimal()
                            + "', '0','" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value
                            + "','0','" + invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value.ToString().ToDecimal() + "')";

                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    IsNew = false;
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                // Update Old Po
                else
                {
                    //حذف الفاتورة القديمة
                    //if (IsNew == false)
                    //{
                    cmd.CommandText = "delete from wh_Po_Cot_MATERIAL_TRANSACTION where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                    "' and TRANSACTION_CODE = '" + txt_transaction_code.Text + "' and Cyear = '" + txt_Cyear.Text + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from wh_Po_Cot_inv_data where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                    "' and TRANSACTION_CODE = '" + txt_transaction_code.Text + "' and Cyear = '" + txt_Cyear.Text + "'";
                    cmd.ExecuteNonQuery();
                    //}
                    //else
                    //{
                    //    get_invSer();
                    //}
                    //اضافة الفاتورة الجديدة
                    cmd.CommandText = @"insert into wh_Po_Cot_inv_data
                (Ser_no,Branch_code,Transaction_code,Cyear,Sanad_no
                ,G_date,ACC_TYPE,Acc_no,Acc_Branch_code,Payment_Type
                ,Sales_man_Id,User_id,Po_Status,Cash_costomer_name,Costomer_Notes
                ,Costomer_adress,Costomer_Phone,Costmer_fax,Ref,E_mail
                ,TermsOfPayment,Validity,DelevryE,requist_no,FORIN_TYPE
                ,PRINTING_SECURTY,TermsOfPaymentE,PREPAREDby,RECEVEDby,TO_BRANCH
                ,CANCELED,aprovedBY,K_M_ACC_NO,K_M_Credit_TAX,K_M_Debit_TAX
                ,COSTMER_K_M_NO,K_M_SER,KM_CODE_ACC,MAIN_KM_CODE,OPEN_VAT
                ,requstedBy)
                values
                ('" + txt_InvNu.Text +
                    "', '" + txtStore_ID.Text +
                    "', '" + txt_transaction_code.Text +
                    "', '" + txt_Cyear.Text.ToString() +
                    "' ,'" + txtMainSer.Text +
                    "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                    "','A', '" +
                    txtSupplier.ID.Text +
                    "', '" + txtBranch_Id.Text +
                    "', '" + Payment.ID.Text +
                    "', '" + Uc_Cost.ID.Text +
                    "' , '" + userID.Text +
                    "','" + (chStop.Checked ? "S" : "") +
                    "','" + txtSuppContact.Text +
                    "','" + txt_InvNot.Text +
                    "', '" + txt_address.Text +
                    "', '" + txt_custTel.Text +
                    "','" + txt_custFax.Text +
                    "','" + txtRefrance.Text +
                    "','" + txt_CustEmail.Text +
                    "','" + Payment.Desc.Text +
                    "','" + ValidtyDays.Text +
                    "','" + Convert.ToString(DelevryTearms.SelectedValue) +
                    "','0','" +
                    Convert.ToString(txtcurrency.SelectedValue) +
                    "','1','" +
                    Convert.ToString(PaymentTearms.SelectedValue) +
                    "','" + userID.Text +
                    "','" + Confirm_Persson.ID.Text +
                    "','" + txtBranch.ID.Text +
                    "','" + (chCanceled.Checked ? "C" : "") +
                    "','" + Authorized_Persson.ID.Text +
                    "', '" + txtVatAcc.ID.Text +
                    "','0','" +
                    invGrid1.txtTotalVAT.Text.ToDecimal() +
                    "', '" + Cust_Vat_No.Text +
                    "', '1','" +
                    txtKmCode.Text +
                    "','" + Vat_Class.Text +
                    "','" + (chVAT.Checked ? "1" : "0") +
                    "','" + Requst_Persson.ID.Text + "')";
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                    {
                        if ((invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty || invGrid1.dgv1.Rows[i].Cells["_code"].Value != null)
                            && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                            && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                        )
                        {
                            cmd.CommandText = @" insert into wh_Po_Cot_MATERIAL_TRANSACTION 
                    (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO
                    ,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc
                    ,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Local_Price,FORIN_TYPE
                    ,USER_ID,main_counter,balance,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,DETAILS,QTY_ADD2,QTY_TAKE2) 
                    values( '" + txt_InvNu.Text
                            + "', '" + txtStore_ID.Text
                            + "', '" + txt_transaction_code.Text
                            + "', '" + txt_Cyear.Text
                            + "' ,'" + txtMainSer.Text
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_code"].Value
                            + "' ,'0','" + invGrid1.dgv1.Rows[i].Cells["_qty"].Value.ToString().ToDecimal()
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_cost"].Value.ToString().ToDecimal()
                            + "','" + ((invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()) + invGrid1.disc_Rate.Text.ToDecimal()) * 100
                            + "' ,'" + (invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()) * 100
                            + "' ,'0','" + (invGrid1.disc_Rate.Text.ToDecimal()) * 100
                            + "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_unit"].Value
                            + "' ,'" + invGrid1.dgv1.Rows[i].Cells["_price"].Value.ToString().ToDecimal()
                            + "' , '" + Convert.ToString(txtcurrency.SelectedValue)
                            + "' , '" + userID.Text
                            + "','" + invGrid1.dgv1.Rows[i].Index
                            + "', '" + invGrid1.dgv1.Rows[i].Cells["_balance"].Value.ToString().ToDecimal()
                            + "','" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value
                            + "' ,'" + invGrid1.dgv1.Rows[i].Cells["_vat"].Value.ToString().ToDecimal()
                            + "', '0','" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value
                            + "','0','" + invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value.ToString().ToDecimal() + "')";

                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    IsNew = false;
                    MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }




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

               
        

        public override void GoFrist()
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_Po_Cot_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and cyear = '" + Properties.Settings.Default.C_year + "' and Transaction_code='PS'  order by ser_no");
            Bnd1.DataSource = dtNaf;
            MyResult = dtNaf.Rows[0]["ser_no"].ToString();
           ShowPO(MyResult, txtStore_ID.Text, txt_transaction_code.Text, Properties.Settings.Default.C_year);
            IsNew = false;

            base.GoFrist();
        }



        public override void GoPrevious()
        {

            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_Po_Cot_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and cyear = '" + Properties.Settings.Default.C_year + "' and Transaction_code='PS'  order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txt_InvNu.Text);

            if (RowNo == -1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            }

            else
            { //RowNo is that Row
                if (RowNo != 0)
                {
                    //RowNo is that Row
                    MyResult = dtNaf.Rows[RowNo - 1]["ser_no"].ToString();
                }
                else
                {
                    MyResult = dtNaf.Rows[0]["ser_no"].ToString();

                }


            }


            ShowPO(MyResult, txtStore_ID.Text, txt_transaction_code.Text, Properties.Settings.Default.C_year);


            IsNew = false;


            base.GoPrevious();
        }

        public override void GoNext()
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_Po_Cot_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and cyear = '" + Properties.Settings.Default.C_year + "' and Transaction_code='PS'  order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txt_InvNu.Text);
            if (RowNo < dtNaf.Rows.Count - 1 && RowNo != -1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[RowNo + 1]["ser_no"].ToString();
                ShowPO(MyResult, txtStore_ID.Text, txt_transaction_code.Text, Properties.Settings.Default.C_year);
            }


            IsNew = false;

            base.GoNext();
        }

        public override void GoLast()
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_Po_Cot_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and cyear = '" + Properties.Settings.Default.C_year + "' and Transaction_code='PS'  order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txt_InvNu.Text);
            if (RowNo != dtNaf.Rows.Count - 1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            }
            //else
            //{ //RowNo is that Row
            //    MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            //}

            ShowPO(MyResult, txtStore_ID.Text, txt_transaction_code.Text, Properties.Settings.Default.C_year);
            IsNew = false;



            base.GoLast();
        }





        public override void Save()
        {
            if (txtBranch.ID.Text.Trim() == "")
            {
                MessageBox.Show("تأكد من اختيار الفرع", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSupplier.ID.Text == string.Empty)
            {
                MessageBox.Show("فضلا.. تاكد من اختيار المورد ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcurrency.SelectedIndex < 0)
            {
                MessageBox.Show("فضلا.. تاكد من اختيار العملة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Payment.ID.Text.Trim()=="")
            {
                MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_Cyear.Text != Properties.Settings.Default.C_year)
            {
                MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtRefrance.Text == string.Empty)
            {
                MessageBox.Show("يرجي التاكد من مرجع المورد", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (IsGridValid() == false)
            {
                return;
            }

            Add_wh_Po_Cot_inv_data();

            //if (IsNew == true)
            //{
            //    Add_wh_Po_Cot_inv_data();
            //}
            //else
            //{
              //  Update_wh_Po_Cot_inv_data();
            //}

           
            base.Save();
        }

        public override void Print()
        {

            if (Ch_Aprrove.Checked == false)
            {
                MessageBox.Show("يجب الموافقة علي الطلب قبل الطباعة");
                return;
            }


            string printModel = Properties.Settings.Default.inv_print;


            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Syria));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.S));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Tunisia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Gold));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Bahrain));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Kuwait));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Oman));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Qatar));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.D));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.EUR));



            switch (txtcurrency.SelectedValue.ToString())
            {
                case "DR":
                    currencyNo = 1;
                    break;

                case "S":
                    currencyNo = 2;
                    break;
                case "BH":
                    currencyNo = 5;
                    break;
                case "OM":
                    currencyNo = 7;
                    break;


                case "D":
                    currencyNo = 9;
                    break;

                case "EU":
                    currencyNo = 10;
                    break;

            }



            RPT.rpt_Purchase_Order_1 reportInv = new RPT.rpt_Purchase_Order_1();
            RPT.Form1 frminv = new RPT.Form1();
            DataSet ds = new DataSet();
            getQuotation(txt_InvNu.Text, txtStore_ID.Text, txt_transaction_code.Text, txt_Cyear.Text);

            DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp where Company_No=left('" +Properties.Settings.Default.BranchId + "',1)  ");


            ds.Tables.Add(dt_Q);
            ds.Tables.Add(dt_Co);

           
            ds.WriteXmlSchema("schema_rpt.xml");
            reportInv.SetDataSource(ds);

            if (invGrid1.txtNetValue.Text.ToDecimal() > 0)
            {
                ToWord toWord = new ToWord(Math.Abs(Math.Round(invGrid1.txtNetValue.Text.ToDecimal(), dal.digits_)), currencies[currencyNo]);
                reportInv.DataDefinition.FormulaFields["towords_"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";
            }
            else
            {
                ToWord toWord = new ToWord(0, currencies[currencyNo]);
                reportInv.DataDefinition.FormulaFields["towords_"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

            }
            reportInv.DataDefinition.FormulaFields["decimal_"].Text = "'" + dal.digits_ + "'";

           // string prinHeader = (rdoCompanyHeader.Checked ? "C" : "B");


            reportInv.SetParameterValue("header", rdoCompanyHeader.Checked ? "C" : "B");


            frminv.crystalReportViewer1.ReportSource = reportInv;
            frminv.ShowDialog();


            base.Print();
        }

        public override void Attachment()
        {
            DataTable dt_ = dal.getDataTabl_1(@"select ser_no,Transaction_code from wh_Po_Cot_inv_data where Ser_no= '" + txt_InvNu.Text + "' and Cyear ='" +txt_Cyear.Text + "' and Transaction_code = '" + txt_transaction_code.Text + "' and Branch_code = '" + txtBranch_Id.Text + "'");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = txt_InvNu.Text;
                frmUpload.docType =txt_transaction_code.Text;
                frmUpload.branchID = Properties.Settings.Default.BranchId;
                frmUpload.ShowDialog();
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            base.Attachment();
        }

    
        private void BSearch_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            comboBox1.SelectedItem = DateTime.Now.Year;
            txtsearch.Focus();    
        }

      

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

   
     
     
        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



       

     

        private void GetBranchData(string _branch)
        {
            DataTable dt = dal.getDataTabl_1(@"SELECT Branch_code,PUR_ACC_NO,Cash_acc_no,K_M_ACC_NO_PURCH,Suppliers_acc_no,ACC_BRANCH FROM wh_BRANCHES where branch_code = '" + _branch + "'");
            if (dt.Rows.Count > 0)
            {
                txtSupplier.branchID.Text= dt.Rows[0]["ACC_BRANCH"].ToString();
                txtSupplier.txtAccCash.Text = dt.Rows[0]["Cash_acc_no"].ToString();
                txtAcc2.ID.Text = dt.Rows[0]["PUR_ACC_NO"].ToString();
                txtCashAcc.ID.Text = dt.Rows[0]["Cash_acc_no"].ToString();
                txtVatAcc.ID.Text = dt.Rows[0]["K_M_ACC_NO_PURCH"].ToString();
                txtCustAcc.ID.Text = dt.Rows[0]["Suppliers_acc_no"].ToString();
                get_invSer();
            }
            else
            {
                txtAcc2.ID.Clear();
                txtCashAcc.ID.Clear();
                txtVatAcc.ID.Clear();
                txtCustAcc.ID.Clear();

            }
        }

    
        private void FillComboCurrency()
        {
            DataTable dt_currency = dal.getDataTabl_1("select * from Wh_Currency");
            txtcurrency.DataSource = dt_currency;
            txtcurrency.ValueMember = "Currency_Code";
            txtcurrency.DisplayMember = "Currency_Name";
            txtcurrency.SelectedIndex = -1;
        }

       private void fillPaymentTearms()
        {
            PaymentTearms.DataSource = dal.getDataTabl_1("select Payment_type,Payment_name,Notes from Sal_Pyment_type");
            PaymentTearms.ValueMember = "Payment_type";
            if (Properties.Settings.Default.lungh == "0")
            {
                PaymentTearms.DisplayMember = "Payment_name";
            }
            else
            {
                PaymentTearms.DisplayMember = "Notes";
            }
            PaymentTearms.SelectedIndex = -1;

        }

        private void fillDelevryTearms()
        {
            DelevryTearms.DataSource = dal.getDataTabl_1("select DeLEVRY_CODE ,DeLEVRY_Name,DELEVER_NAME_E from WH_PO_DELEVRY_CODE");
            DelevryTearms.ValueMember = "DeLEVRY_CODE";
            if (Properties.Settings.Default.lungh == "0")
            {
                DelevryTearms.DisplayMember = "DeLEVRY_Name";
            }
            else
            {
                DelevryTearms.DisplayMember = "DELEVER_NAME_E";
            }
            DelevryTearms.SelectedIndex = -1;
        }

        private void frm_PurchaseOrder_Load(object sender, EventArgs e)
        {


            //PaymentTearms.DataSource = dal.getDataTabl_1("select Payment_type,Payment_name,Notes from Sal_Pyment_type");
            //PaymentTearms.ValueMember = "Payment_type";


            //DelevryTearms.DataSource = dal.getDataTabl_1("select DeLEVRY_CODE ,DeLEVRY_Name,DELEVER_NAME_E from WH_PO_DELEVRY_CODE");
            //DelevryTearms.ValueMember = "DeLEVRY_CODE";
            //if (Properties.Settings.Default.lungh=="0")
            //{
            //DelevryTearms.DisplayMember = "DeLEVRY_Name";
            //PaymentTearms.DisplayMember = "Payment_name";
            //}
            //else
            //{
            //    DelevryTearms.DisplayMember = "DELEVER_NAME_E";
            //    PaymentTearms.DisplayMember = "Notes";
            //}
            //PaymentTearms.SelectedIndex = -1;
            //DelevryTearms.SelectedIndex = -1;

            //btn_UpdateApproved.Enabled = Session.UserSettings.General.CanChangeStore;

            //fillDelevryTearms();
            //fillPaymentTearms();
            //txt_InvSM.Text = Program.salesman;
            //txtStore_ID.Text = Properties.Settings.Default.BranchId;
            //txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            //txtBranch_Id.Text = Properties.Settings.Default.BranchAccID;
            //txtSupplier.branchID.Text = txtBranch.txtAccBranch.Text;

            //userID.Text = Program.userID;
            //txt_Cyear.Text = Properties.Settings.Default.C_year;

            //get_invSer();
            //txtSupplier.txtMainAcc.Text = "234";
            //txtSupplier.txtFinal.Text = "1";

            //GetBranchData(txtBranch.ID.Text);

        }

        private void Uc_Customer_Load(object sender, EventArgs e)
        {

            DataTable dt_M = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no FROM wh_BRANCHES where BRANCH_code like '"+txtBranch_Id.Text+"%'");
            if (dt_M.Rows.Count > 0)
            {
                string Acc_main = dt_M.Rows[0]["Suppliers_acc_no"].ToString();
                string Acc_cash = dt_M.Rows[0]["Cash_acc_no"].ToString();
                DataTable dt_cust = dal.getDataTabl_1(@"select 
                                p.phone_no,P.adress,fax_no,p.E_MAIL,p.b_o_box,p.area_code
                                ,p.COSTMER_K_M_NO,P.adress2,P.resp_name,P.resp_name_E FROM payer2 As P
                                where P.BRANCH_code like '" + txtBranch.txtAccBranch.Text + "%' and P.ACC_NO = '" + txtSupplier.ID.Text + "' and(P.ACC_NO like '" + Acc_main + "%' or P.ACC_NO like '" + Acc_cash + "%') and P.t_final ='1'");
            //    txtBranch_Id.Text = Properties.Settings.Default.BranchId;
                if (dt_cust.Rows.Count > 0)
                {
                    if (txtSupplier.ID.Text == Acc_cash)
                    {

                        Payment.ID.Text = "11";
                        Payment.Enabled = false;

                    //  invGrid1.txtAccVat_Rate.Text = txtSupplier.KM_Ratio_Purch.Text;

                    }
                    else
                    {

                        Payment.ID.Text = "2";
                        Payment.Enabled = true;


                    }

                    txt_custTel.Text = dt_cust.Rows[0]["phone_no"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                    txt_address.Text = dt_cust.Rows[0]["adress"].ToString();
                    }
                    else
                    {
                        txt_address.Text = dt_cust.Rows[0]["adress2"].ToString();
                    }
                    txt_custFax.Text = dt_cust.Rows[0]["fax_no"].ToString();
                    txt_CustEmail.Text = dt_cust.Rows[0]["E_MAIL"].ToString();
                    txt_BoBox.Text = dt_cust.Rows[0]["b_o_box"].ToString();
                    txt_area_code.Text = dt_cust.Rows[0]["area_code"].ToString();
                    Cust_Vat_No.Text = dt_cust.Rows[0]["COSTMER_K_M_NO"].ToString();
                    txtSuppContact.Text = dt_cust.Rows[0]["resp_name_E"].ToString();
                    txtKmCode.Text = txtSupplier.txtKMCode.Text;
                    Vat_Class.Text = txtSupplier.KM_Code_Purch.Text;
                    Vat_Class_Desc.Text = txtSupplier.KM_Desc_Purch.Text;
                    Cust_Vat_Rate.Text = txtSupplier.KM_Ratio_Purch.Text;
                    
                }
                else
                {
                   
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
                    txtSuppContact.Clear();


                }
                invGrid1.txtAccVat_Rate.Text = txtSupplier.KM_Ratio_Purch.Text;
                invGrid1.total_inv();
            }
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

      

     
       
       

        private void btnAddDelevery_Click(object sender, EventArgs e)
        {
            PL.frmAddDelevryTearms frm = new PL.frmAddDelevryTearms();
            frm.ShowDialog();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            PL.frmAddPaymentTearms frm = new PL.frmAddPaymentTearms();
            frm.ShowDialog();
        }

    
        private void txtBranch_Load(object sender, EventArgs e)
        {
            GetBranchData(txtBranch.ID.Text);
            txtSupplier.branchID.Text = txtBranch.txtAccBranch.Text;

           
        }

        private void btn_Cancl_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && txtsearch.Text.Trim() != "")
            {
                btn_Srearch.Focus();
            }
        }

       
        private void Ch_Aprrove_CheckedChanged(object sender, EventArgs e)
        {
            if (Ch_Aprrove.Checked)
            {
                if (Properties.Settings.Default.lungh == "0")
                {
                btn_UpdateApproved.Text = "الغاء الموافقةعلي الطلب";
                }
                else
                {
                    btn_UpdateApproved.Text = "Cancel Approval of the Order";
                }

            }
            else
            {
                if (Properties.Settings.Default.lungh == "0")
                {
                    btn_UpdateApproved.Text = "الموافقةعلي الطلب";
                }
                else
                {
                    btn_UpdateApproved.Text = "Approval of the Order";
                }
            }
        }

      
        private void btn_UpdateApproved_Click(object sender, EventArgs e)
        {
            if (Ch_Aprrove.Checked == true)
            {
                Ch_Aprrove.Checked = false;
            }
            else
            {
                Ch_Aprrove.Checked = true;
            }
            dal.Execute_1(@"update wh_Po_Cot_inv_data set Confermed ='" + (Ch_Aprrove.Checked ? "1" : "0") + "',ConfermedBy='" + Program.userID + "' where Ser_no ='" + txt_InvNu.Text + "' and Branch_code ='" + txtStore_ID.Text + "' and Cyear='" + txt_Cyear.Text + "' and Transaction_code ='PS'");
            txtAprovedPy.Text= Program.salesman;
        }

        private void chVAT_CheckedChanged(object sender, EventArgs e)
        {
            if (chVAT.Checked == true)
            {
                invGrid1.dgv1.Columns["_vat"].ReadOnly = false;
                invGrid1.dgv1.Columns["_vat"].Visible = true;
                invGrid1.dgv1.Columns["_vatRatio"].Visible = true;
            }
            else
            {
                invGrid1.dgv1.Columns["_vat"].ReadOnly = true;
                invGrid1.dgv1.Columns["_vat"].Visible = false;
                invGrid1.dgv1.Columns["_vatRatio"].Visible = false;
                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    invGrid1.clculat_amount(i);
                }
            }
            invGrid1.total_inv();


        }



        private void ShowPO(string ser_, string branch_, string transaction_, string cyear_)
        {
            //  getQuotation(txtsearch.Text, txtStore_ID.Text, txt_transaction_code.Text, comboBox1.Text.Substring(comboBox1.Text.Length - 2));
              getQuotation(ser_, branch_, transaction_, cyear_);

            if (dt_Q.Rows.Count > 0)
            {
                txtBranch.ID.Text = dt_Q.Rows[0]["Branch_code"].ToString();
                txtStore_ID.Text = dt_Q.Rows[0]["Branch_code"].ToString();
                txtBranch_Id.Text = dt_Q.Rows[0]["Acc_Branch_code"].ToString();
                txtSupplier.branchID.Text = dt_Q.Rows[0]["Acc_Branch_code"].ToString();
                txt_Cyear.Text = dt_Q.Rows[0]["Cyear"].ToString();
                txt_InvDate.Text = dt_Q.Rows[0]["G_date"].ToString();
                txtSupplier.ID.Text = dt_Q.Rows[0]["Acc_no"].ToString();
                Payment.ID.Text = dt_Q.Rows[0]["Payment_Type"].ToString();
                Uc_Cost.ID.Text = dt_Q.Rows[0]["Sales_man_Id"].ToString();
                //txt_address.Text = dt_Q.Rows[0]["Costomer_adress"].ToString();
                // txt_custTel.Text = dt_Q.Rows[0]["Costomer_Phone"].ToString();
                // txt_custFax.Text = dt_Q.Rows[0]["Costmer_fax"].ToString();
                txtRefrance.Text = dt_Q.Rows[0]["Ref"].ToString();
                // txt_CustEmail.Text = dt_Q.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_Q.Rows[0]["termsOfPaymentE"].ToString();
                ValidtyDays.Value = dt_Q.Rows[0]["Validity"].ToString().ParseInt(0);
                DelevryTearms.SelectedValue = dt_Q.Rows[0]["DelevryE"].ToString();
                txtVatAcc.ID.Text = dt_Q.Rows[0]["K_M_ACC_NO"].ToString();
                invGrid1.txtTotalVAT.Text = dt_Q.Rows[0]["K_M_Credit_TAX"].ToString();
                Cust_Vat_No.Text = dt_Q.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_Q.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_Q.Rows[0]["MAIN_KM_CODE"].ToString();
                // txtSuppContact.Text = dt_Q.Rows[0]["Cash_costomer_name"].ToString();
                userID.Text = dt_Q.Rows[0]["User_id"].ToString();
                txt_InvSM.Text = dt_Q.Rows[0]["USER_NAME"].ToString();
                Validty_Date.Value = txt_InvDate.Value.AddDays(ValidtyDays.Value);
                txt_InvNu.Text = dt_Q.Rows[0]["Ser_no"].ToString();
                txtMainSer.Text = dt_Q.Rows[0]["Sanad_no"].ToString();
                txt_InvNot.Text = dt_Q.Rows[0]["Costomer_Notes"].ToString();
                Requst_Persson.ID.Text = dt_Q.Rows[0]["requstedBy"].ToString();
                Authorized_Persson.ID.Text = dt_Q.Rows[0]["aprovedBY"].ToString();
                Confirm_Persson.ID.Text = dt_Q.Rows[0]["RECEVEDby"].ToString();
                if (dt_Q.Rows[0]["FORIN_TYPE"].ToString() == "")
                {
                    txtcurrency.SelectedValue = Properties.Settings.Default.Currency;
                }
                else
                {
                    txtcurrency.SelectedValue = dt_Q.Rows[0]["FORIN_TYPE"].ToString();
                }
                if (dt_Q.Rows[0]["CANCELED"].ToString() == "C")
                {
                    chStop.Checked = true;
                }
                else
                {
                    chStop.Checked = false;
                }
                if (dt_Q.Rows[0]["Confermed"].ToString() == "1")
                {
                    Ch_Aprrove.Checked = true;
                }
                else
                {
                    Ch_Aprrove.Checked = false;
                }
                txtAprovedPy.Text = dt_Q.Rows[0]["ConfermedBy"].ToString();


                invGrid1.dgv1.Rows.Clear();
                int rowscount = dt_Q.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)
                    {
                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_Q.Rows[i]["ITEM_NO"].ToString();

                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_Q.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_Q.Rows[i]["Descr_eng"].ToString();
                        }
                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_Q.Rows[i]["DETAILS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_Q.Rows[i]["Unit"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_Q.Rows[i]["Weight"].ToString().ToDecimal().ToString("N3");
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_Q.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_Q.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_Q.Rows[i]["DISC_R"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_Q.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_Q.Rows[i]["TAX_IN"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = (dt_Q.Rows[i]["COST_PRICE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_Q.Rows[i]["K_M_TYPE_ITEMS"].ToString().ToDecimal().ToString("N0");
                    }
                }
                invGrid1.total_inv();
            }
        }
      

       
        private void btn_Srearch_Click(object sender, EventArgs e)
        {
            getPO(txtsearch.Text, txtStore_ID.Text, txt_transaction_code.Text, comboBox1.Text.Substring(comboBox1.Text.Length - 2));
        }

        private void getPO(string _ser, string _branch, string _transaction, string _year)
        {
            txtBranch.Enabled = false;
            getQuotation(_ser, _branch, _transaction, _year);
            if (dt_Q.Rows.Count > 0)
            {
                txtBranch.ID.Text = dt_Q.Rows[0]["Branch_code"].ToString();
                txtStore_ID.Text = dt_Q.Rows[0]["Branch_code"].ToString();
                txtBranch_Id.Text = dt_Q.Rows[0]["Acc_Branch_code"].ToString();
                txtSupplier.branchID.Text = dt_Q.Rows[0]["Acc_Branch_code"].ToString();
                txt_Cyear.Text = dt_Q.Rows[0]["Cyear"].ToString();
                txt_InvDate.Text = dt_Q.Rows[0]["G_date"].ToString();
                txtSupplier.ID.Text = dt_Q.Rows[0]["Acc_no"].ToString();
                Payment.ID.Text = dt_Q.Rows[0]["Payment_Type"].ToString();
                Uc_Cost.ID.Text = dt_Q.Rows[0]["Sales_man_Id"].ToString();
                //txt_address.Text = dt_Q.Rows[0]["Costomer_adress"].ToString();
                // txt_custTel.Text = dt_Q.Rows[0]["Costomer_Phone"].ToString();
                // txt_custFax.Text = dt_Q.Rows[0]["Costmer_fax"].ToString();
                txtRefrance.Text = dt_Q.Rows[0]["Ref"].ToString();
                // txt_CustEmail.Text = dt_Q.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_Q.Rows[0]["termsOfPaymentE"].ToString();
                ValidtyDays.Value = dt_Q.Rows[0]["Validity"].ToString().ParseInt(0);
                DelevryTearms.SelectedValue = dt_Q.Rows[0]["DelevryE"].ToString();
                txtVatAcc.ID.Text = dt_Q.Rows[0]["K_M_ACC_NO"].ToString();
                invGrid1.txtTotalVAT.Text = dt_Q.Rows[0]["K_M_Credit_TAX"].ToString();
                Cust_Vat_No.Text = dt_Q.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_Q.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_Q.Rows[0]["MAIN_KM_CODE"].ToString();
                // txtSuppContact.Text = dt_Q.Rows[0]["Cash_costomer_name"].ToString();
                userID.Text = dt_Q.Rows[0]["User_id"].ToString();
                txt_InvSM.Text = dt_Q.Rows[0]["USER_NAME"].ToString();
                Validty_Date.Value = txt_InvDate.Value.AddDays(ValidtyDays.Value);
                txt_InvNu.Text = dt_Q.Rows[0]["Ser_no"].ToString();
                txtMainSer.Text = dt_Q.Rows[0]["Sanad_no"].ToString();
                txt_InvNot.Text = dt_Q.Rows[0]["Costomer_Notes"].ToString();
                Requst_Persson.ID.Text = dt_Q.Rows[0]["requstedBy"].ToString();
                Authorized_Persson.ID.Text = dt_Q.Rows[0]["aprovedBY"].ToString();
                Confirm_Persson.ID.Text = dt_Q.Rows[0]["RECEVEDby"].ToString();
                if (dt_Q.Rows[0]["FORIN_TYPE"].ToString() == "")
                {
                    txtcurrency.SelectedValue = Properties.Settings.Default.Currency;
                }
                else
                {
                    txtcurrency.SelectedValue = dt_Q.Rows[0]["FORIN_TYPE"].ToString();
                }
                if (dt_Q.Rows[0]["CANCELED"].ToString() == "C")
                {
                    chStop.Checked = true;
                }
                else
                {
                    chStop.Checked = false;
                }
                if (dt_Q.Rows[0]["Confermed"].ToString() == "1")
                {
                    Ch_Aprrove.Checked = true;
                }
                else
                {
                    Ch_Aprrove.Checked = false;
                }
                txtAprovedPy.Text = dt_Q.Rows[0]["ConfermedBy"].ToString();


                invGrid1.dgv1.Rows.Clear();
                int rowscount = dt_Q.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)
                    {
                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_Q.Rows[i]["ITEM_NO"].ToString();

                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_Q.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_Q.Rows[i]["Descr_eng"].ToString();
                        }
                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_Q.Rows[i]["DETAILS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_Q.Rows[i]["Unit"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_Q.Rows[i]["Weight"].ToString().ToDecimal().ToString("N3");
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_Q.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_Q.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_Q.Rows[i]["DISC_R"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_Q.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_Q.Rows[i]["TAX_IN"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = (dt_Q.Rows[i]["COST_PRICE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_Q.Rows[i]["K_M_TYPE_ITEMS"].ToString().ToDecimal().ToString("N0");
                    }
                }
                invGrid1.total_inv();
                groupBox1.Visible = false;
                IsNew = false;
            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_vactor = dal.getDataTabl_1("select * from Wh_Currency  where Currency_Code='" + txtcurrency.SelectedValue + "'");
                txt_Rate.Text = dt_vactor.Rows[0][2].ToString();
            }
            catch
            { txt_Rate.Text = "0"; }
        }



        private void getQuotation(string ser_, string branch_, string transaction_, string cyear_)
        {
            //try
            //{ //, ReportDB.dbo.Tafkeet('+@4+', '''+@5+''')  from wh_Po_Cot_inv_data As A
            dt_Q = dal.getDataTabl_1(@"select A.Ser_no,A.Branch_code,A.Transaction_code,A.Cyear,A.Sanad_no,A.G_date,A.Acc_no,A.Acc_Branch_code
            ,A.Payment_Type,A.Sales_man_Id,A.User_id,A.Po_Status,A.Po_Expire_Date,A.Ref
			,A.TermsOfPayment,A.Validity,A.DelevryE,isnull(A.FORIN_TYPE,'') as FORIN_TYPE,A.aprovedBY
			,A.RECEVEDby,A.requstedBy ,A.termsOfPaymentE,A.Confermed,A.ConfermedBy,A.CANCELED,A.K_M_ACC_NO
			,A.K_M_Credit_TAX,A.COSTMER_K_M_NO,A.KM_CODE_ACC,A.MAIN_KM_CODE,A.Costomer_Notes,A.VAT_RATIO,A.COMP_TAX_NO
            ,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.Unit,B.DISC_R,B.DISC_R2,B.DISC_R3,B.total_disc,B.Local_Price,B.TAX_IN
			,B.TAX_OUT,B.DETAILS,B.Pice_Total_Cost,isnull(NULLIF(B.K_M_TYPE_ITEMS, ''),1) as K_M_TYPE_ITEMS,B.COST_PRICE,B.DETAILS
            ,M.descr,isnull(NULLIF(M.Descr_eng,''),M.Descr) as Descr_eng,m.Weight,m.BALANCE ,K.KM_RATIO,
            SP.Payment_name,SP.Notes,
            DP.DeLEVRY_Name,DP.DELEVER_NAME_E,U.USER_NAME
			,P.PAYER_NAME,isnull(NULLIF(P.payer_l_name,''),P.PAYER_NAME) as payer_l_name,P.adress,P.adress2,P.phone_no,P.fax_no,P.resp_name,P.resp_name_E,P.E_MAIL
            ,BR.LONG_ADESS_A,Br.LONG_ADESS_E,BR.ADRESS,BR.PHONE_NO,BR.FAX_NO,Br.branch_name ,br.WH_E_NAME,Br.Branch_Logo_A4
    		,C1.CAT_NAME as confirm_A ,C1.CAT_NAME_E as confirm_E
			,C2.CAT_NAME as auth_A,C2.CAT_NAME_E as auth_E
			,C3.CAT_NAME as Requst_A,C3.CAT_NAME_E as Requst_E
            ,C3.Mobile,C3.Email,co.Company_a_name,co.Company_e_name,A.Sales_man_Id,cost.COST_name,cost.COST_E_NAME
            ,(select case when isnull(NULLIF(A.KM_CODE_ACC,''),1) =1 and  (isnull(NULLIF(B.K_M_TYPE_ITEMS,''),1) =1 or B.K_M_TYPE_ITEMS ='')   then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end)  as VatRatio    " +
            "from wh_Po_Cot_inv_data As A " +
            "Inner join wh_Po_Cot_MATERIAL_TRANSACTION As B " +
            "on A.Ser_no = B.SER_NO and A.Branch_code = B.Branch_code AND A.Transaction_code = B.TRANSACTION_CODE AND A.Cyear = B.Cyear " +
            "inner join wh_main_master AS M on M.item_no = B.ITEM_NO " +
            "left join KM_MATERIAL_CODE As K on K.KM_CODE = ISNULL(NULLIF(M.KM_CODE, ''), 1) " +
            "left join Sal_Pyment_type As SP on SP.Payment_type = A.termsOfPaymentE " +
            "left join WH_PO_DELEVRY_CODE As DP on DP.DeLEVRY_CODE = A.DelevryE " +
            "inner join wh_USERS As U on U.USER_ID = A.USER_ID " +
            "inner join wh_BRANCHES as BR on A.Branch_code = BR.Branch_code " +
            "inner join payer2 as P on P.acc_no = A.acc_no and p.BRANCH_code = BR.ACC_BRANCH " +
            "Left join CATEGORY as C1 on C1.CAT_CODE = A.RECEVEDby "+
            "Left join CATEGORY as C2 on C2.CAT_CODE = A.aprovedBY "+
            "Left join CATEGORY as C3 on C3.CAT_CODE = A.requstedBy "+
            "inner join Wh_Oiner_Comp As co on co.Company_No = left('"+Properties.Settings.Default.BranchId+"',1) " +
            "Left join COST_CENTER as cost on cost.COST_CODE = A.Sales_man_Id "+
            "where A.Ser_no = '" + ser_ + "'  and A.Branch_code = '" + branch_ + "'  and A.transaction_code = '" + transaction_ + "'  and A.cyear = '" + cyear_ + "' order by B.main_counter");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void groupPanel6_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            get_invSer();
            invGrid1.total_inv();
        }
    }
}


     