using System;
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
    public partial class frm_returnSales : frm_Master
    {
        string btntype = "0";
        Int32 m;
        //string Jor_no;
        string btn_name;
        decimal old_balance, old_cost, new_balance, new_cost;
        Dates date_ = new Dates();
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        int currencyNo = 2;

        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();
        DataTable dt_inv_total = new DataTable();
        DataTable dt_inv = new DataTable();


        public frm_returnSales()
        {

            InitializeComponent();


            
           // creatDattable();
           



            txt_InvSM.Text = Program.salesman;
            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranch_Id.Text = Properties.Settings.Default.BranchAccID;
            userID.Text = Program.userID;






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
            RefreshData();


        }

        public override void Attachment()
        {
            DataTable dt_ = dal.getDataTabl_1(@"select ser_no,Transaction_code from wh_inv_data where Ser_no= '" +txt_InvNu.Text + "' and Cyear ='" + txt_cyear.Text + "' and Transaction_code = '" + Doc_Type.Text + "' and Branch_code = '" + txtBranch_Id.Text + "'");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = txt_InvNu.Text;
                frmUpload.docType =Doc_Type.Text;
                frmUpload.branchID = Properties.Settings.Default.BranchId;
                frmUpload.ShowDialog();
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            base.Attachment();
        }

        public override void New()
        {
            ClearTextBoxes();
            invGrid1.dgv1.Rows.Clear();
            invGrid1.total_inv();

            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranch_Id.Text = Properties.Settings.Default.BranchAccID;
            AccType.Text = Properties.Settings.Default.TRANS_TO_ACC;
            txt_InvSM.Text = Program.salesman;
            userID.Text = Program.userID;
            Uc_Cost.ID.Text = Program.userCostCode;


            txt_Acc.branchID.Text = txtBranch_Id.Text;
            txt_Acc.txtFinal.Text = "1";
            txt_Acc.txtMainAcc.Text = dal.GetCell_1("SELECT Costmers_acc_no FROM wh_BRANCHES  where BRANCH_code='" + txtStore_ID.Text + "'").ToString();

            get_data();
            get_invSer();


            base.New();
        }

        private void get_data()
        {


            DataTable dt1 = dal.getDataTabl_1(@"SELECT SALES_ACC_NO,Cash_acc_no,K_M_ACC_NO_SALES,Sales_Cost_Acc_no,Invintory_Acc_no FROM wh_BRANCHES where BRANCH_code= '" + Properties.Settings.Default.BranchId + "'");
            if (dt1.Rows.Count > 0)
            {
                txtAcc2.ID.Text = dt1.Rows[0]["SALES_ACC_NO"].ToString();
                txt_CashAcc.ID.Text = dt1.Rows[0]["Cash_acc_no"].ToString();
                txt_vatAcc.ID.Text = dt1.Rows[0]["K_M_ACC_NO_SALES"].ToString();
                txtInventory.ID.Text = dt1.Rows[0]["Invintory_Acc_no"].ToString();
                txtCostOfSales.ID.Text = dt1.Rows[0]["Sales_Cost_Acc_no"].ToString();


            }
            txt_cyear.Text = Properties.Settings.Default.C_year;

        }



        public override void GoFrist()
        {
            MessageBox.Show("frist");
            base.GoFrist();
        }

        private void Get_Inv(string _transaction)
        {
            //PL.frmSerch frm = new PL.frmSerch();
            //frm.ShowDialog();
            getSalesInv(txtSearchInv.Text, txtStore_ID.Text, _transaction, txt_InvDate.Value.ToString("yy"));
            if (dt_inv.Rows.Count > 0)
            {
                //Doc_Type.Text = dt_inv.Rows[0]["Transaction_code"].ToString();
                txtInvNo.Text = dt_inv.Rows[0]["ser_no"].ToString();
                txtInvDate.Text = dt_inv.Rows[0]["G_date"].ToString();
                txt_Acc.ID.Text = dt_inv.Rows[0]["Acc_no"].ToString();
                txt_PayType.ID.Text = dt_inv.Rows[0]["Payment_Type"].ToString();
                //  Uc_Project.ID.Text = dt_inv.Rows[0]["PROJECT_NO"].ToString();
                //txt_InvNot.Text = dt_inv.Rows[0]["Inv_Notes"].ToString();
                txt_address.Text = dt_inv.Rows[0]["Adress"].ToString();
                //Uc_Cost.ID.Text = dt_inv.Rows[0]["Sales_man_Id"].ToString();
                cashCustomer.ID.Text = dt_inv.Rows[0]["Costmer_No"].ToString();
              
                //txt_sandNo.Text = dt_inv.Rows[0]["Sanad_no"].ToString();
                //AccSer_No.Text = dt_inv.Rows[0]["acc_serial_no"].ToString();
                txtSoNo.Text = dt_inv.Rows[0]["SO_no"].ToString();
                Po_No.Text = dt_inv.Rows[0]["Po_no"].ToString();
                txt_Qutation.Text = dt_inv.Rows[0]["QUOT_REF_NO"].ToString();
                txtQuotationDate.Text = dt_inv.Rows[0]["QUOT_REF_DATE"].ToString();
                txt_attn.Text = dt_inv.Rows[0]["Cash_costomer_name"].ToString();
                PaymentTearms.SelectedValue = dt_inv.Rows[0]["TermsOfPaymentE"].ToString();
                DelevryTearms.SelectedValue = dt_inv.Rows[0]["DelevryE"].ToString();
                if (dt_inv.Rows[0]["BankNo"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_inv.Rows[0]["BankNo"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }

                invGrid1.dgv1.Rows.Clear();
                int rowscount = dt_inv.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)

                    {

                        invGrid1.dgv1.Rows[i].HeaderCell.Value = dt_inv.Rows[i]["main_counter"].ToString().ParseInt(0) + 1;

                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_inv.Rows[i]["ITEM_NO"].ToString();
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_inv.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_inv.Rows[i]["descr_eng"].ToString();
                        }


                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_inv.Rows[i]["DETAILS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_inv.Rows[i]["Unit"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_inv.Rows[i]["Weight"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_invQty"].Value = dt_inv.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_inv.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_inv.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = "0";
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_inv.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_inv.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_inv.Rows[i]["TAX_OUT"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_inv.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_inv.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_inv.Rows[i]["disc_"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);

                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_inv.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = dt_inv.Rows[i]["Pice_Total_Cost"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_inv.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                        //row.Ser.Text = (dt_Q.Rows[i]["main_counter"].ToString().ToDecimal() + 1).ToString("N0");


                        //row.KeyDown += inv_Grid1.r_KeyDown;
                        //row.DoubleClick += inv_Grid1.r_DoubleClick;
                        //row.KeyUp += inv_Grid1.r_KeyUP;
                        //row.Click += inv_Grid1.r_Click;


                        //inv_Grid1.flowLayoutPanel1.Controls.Add(row);
                        //                   i = i + 1;

                    }

                    invGrid1.total_inv();

                    // txtSearch.Text = "";

                    groupPanel1.Visible = false;

                    IsNew = true;

                }
            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void search_Inv(string _transaction)
        {
            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            getSalesInv(frm.txtSearch.t.Text, txtStore_ID.Text, _transaction, txt_InvDate.Value.ToString("yy"));
            if (dt_inv.Rows.Count > 0)
            {
                Doc_Type.Text = dt_inv.Rows[0]["Transaction_code"].ToString();
                txt_InvDate.Text = dt_inv.Rows[0]["G_date"].ToString();
                txt_Acc.ID.Text = dt_inv.Rows[0]["Acc_no"].ToString();
                txt_PayType.ID.Text = dt_inv.Rows[0]["Payment_Type"].ToString();
              //  Uc_Project.ID.Text = dt_inv.Rows[0]["PROJECT_NO"].ToString();
                txt_InvNot.Text = dt_inv.Rows[0]["Inv_Notes"].ToString();
                txt_address.Text = dt_inv.Rows[0]["Adress"].ToString();
                Uc_Cost.ID.Text = dt_inv.Rows[0]["Sales_man_Id"].ToString();
                cashCustomer.ID.Text = dt_inv.Rows[0]["Costmer_No"].ToString();
                txt_InvNu.Text = dt_inv.Rows[0]["ser_no"].ToString();
                txt_sandNo.Text = dt_inv.Rows[0]["Sanad_no"].ToString();
                AccSer_No.Text = dt_inv.Rows[0]["acc_serial_no"].ToString();
                txtSoNo.Text = dt_inv.Rows[0]["SO_no"].ToString();
                Po_No.Text = dt_inv.Rows[0]["Po_no"].ToString();
                txtInvNo.Text = dt_inv.Rows[0]["Inv_no"].ToString();
                txtInvDate.Text = dt_inv.Rows[0]["Inv_date"].ToString(); 
                txt_Qutation.Text           = dt_inv.Rows[0]["QUOT_REF_NO"].ToString();
                txtQuotationDate.Text       = dt_inv.Rows[0]["QUOT_REF_DATE"].ToString();
                txt_attn.Text               = dt_inv.Rows[0]["Cash_costomer_name"].ToString();
                PaymentTearms.SelectedValue = dt_inv.Rows[0]["TermsOfPaymentE"].ToString();
                DelevryTearms.SelectedValue = dt_inv.Rows[0]["DelevryE"].ToString();
                if (dt_inv.Rows[0]["BankNo"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_inv.Rows[0]["BankNo"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }

                invGrid1.dgv1.Rows.Clear();
                int rowscount = dt_inv.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)

                    {

                        invGrid1.dgv1.Rows[i].HeaderCell.Value = dt_inv.Rows[i]["main_counter"].ToString().ParseInt(0) + 1;

                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_inv.Rows[i]["ITEM_NO"].ToString();
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_inv.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_inv.Rows[i]["descr_eng"].ToString();
                        }


                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_inv.Rows[i]["DETAILS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_inv.Rows[i]["Unit"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_inv.Rows[i]["Weight"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_inv.Rows[i]["QTY_ADD"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_inv.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_inv.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = "0";
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_inv.Rows[i]["QTY_ADD"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_inv.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_inv.Rows[i]["TAX_IN"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_inv.Rows[i]["QTY_ADD"].ToString().ToDecimal() * dt_inv.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_inv.Rows[i]["disc_"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);

                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_inv.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = dt_inv.Rows[i]["Pice_Total_Cost"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_inv.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                        //row.Ser.Text = (dt_Q.Rows[i]["main_counter"].ToString().ToDecimal() + 1).ToString("N0");


                        //row.KeyDown += inv_Grid1.r_KeyDown;
                        //row.DoubleClick += inv_Grid1.r_DoubleClick;
                        //row.KeyUp += inv_Grid1.r_KeyUP;
                        //row.Click += inv_Grid1.r_Click;


                        //inv_Grid1.flowLayoutPanel1.Controls.Add(row);
                        //                   i = i + 1;

                    }

                    invGrid1.total_inv();

                   // txtSearch.Text = "";

                    groupPanel1.Visible = false;

                    IsNew = false;

                }
            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override void GoPrevious()
        {
           
            base.GoPrevious();
        }



        private void showInvoice(string Sh_ser,  string sh_transaction)
        {

getSalesInv(Sh_ser, txtStore_ID.Text, sh_transaction, Properties.Settings.Default.C_year);
            if (dt_inv.Rows.Count > 0)
            {
                Doc_Type.Text = dt_inv.Rows[0]["Transaction_code"].ToString();

                txt_InvDate.Text = dt_inv.Rows[0]["G_date"].ToString();
                txt_Acc.ID.Text = dt_inv.Rows[0]["Acc_no"].ToString();
                txt_PayType.ID.Text = dt_inv.Rows[0]["Payment_Type"].ToString();
                //  Uc_Project.ID.Text = dt_inv.Rows[0]["PROJECT_NO"].ToString();
                txt_InvNot.Text = dt_inv.Rows[0]["Inv_Notes"].ToString();
                txt_address.Text = dt_inv.Rows[0]["Adress"].ToString();
                Uc_Cost.ID.Text = dt_inv.Rows[0]["Sales_man_Id"].ToString();
                cashCustomer.ID.Text = dt_inv.Rows[0]["Costmer_No"].ToString();
                txt_InvNu.Text = dt_inv.Rows[0]["ser_no"].ToString();
                txt_sandNo.Text = dt_inv.Rows[0]["Sanad_no"].ToString();
                AccSer_No.Text = dt_inv.Rows[0]["acc_serial_no"].ToString();
                txtSoNo.Text = dt_inv.Rows[0]["SO_no"].ToString();
                Po_No.Text = dt_inv.Rows[0]["Po_no"].ToString();
                txt_Qutation.Text = dt_inv.Rows[0]["QUOT_REF_NO"].ToString();
                txtQuotationDate.Text = dt_inv.Rows[0]["QUOT_REF_DATE"].ToString();
                txt_attn.Text = dt_inv.Rows[0]["Cash_costomer_name"].ToString();
                PaymentTearms.SelectedValue = dt_inv.Rows[0]["TermsOfPaymentE"].ToString();
                DelevryTearms.SelectedValue = dt_inv.Rows[0]["DelevryE"].ToString();
                if (dt_inv.Rows[0]["BankNo"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_inv.Rows[0]["BankNo"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }

                invGrid1.dgv1.Rows.Clear();
                int rowscount = dt_inv.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)

                    {

                        invGrid1.dgv1.Rows[i].HeaderCell.Value = dt_inv.Rows[i]["main_counter"].ToString().ParseInt(0) + 1;

                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_inv.Rows[i]["ITEM_NO"].ToString();
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_inv.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_inv.Rows[i]["descr_eng"].ToString();
                        }


                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_inv.Rows[i]["DETAILS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_inv.Rows[i]["Unit"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_inv.Rows[i]["Weight"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_inv.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_inv.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_inv.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = "0";
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_inv.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_inv.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_inv.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_inv.Rows[i]["TAX_OUT"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_inv.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_inv.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_inv.Rows[i]["disc_"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);

                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_inv.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = dt_inv.Rows[i]["Pice_Total_Cost"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_inv.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                        //row.Ser.Text = (dt_Q.Rows[i]["main_counter"].ToString().ToDecimal() + 1).ToString("N0");


                        //row.KeyDown += inv_Grid1.r_KeyDown;
                        //row.DoubleClick += inv_Grid1.r_DoubleClick;
                        //row.KeyUp += inv_Grid1.r_KeyUP;
                        //row.Click += inv_Grid1.r_Click;


                        //inv_Grid1.flowLayoutPanel1.Controls.Add(row);
                        //                   i = i + 1;

                    }

                    invGrid1.total_inv();

                    // txtSearch.Text = "";

                    groupPanel1.Visible = false;

                    IsNew = false;

                }
            }


        }











        private void get_invSer()
        {
           

                   txt_sandNo.Text = dal.getDataTabl_1(@"select isnull(XS+1,1) from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txt_cyear.Text + "'").Rows[0][0].ToString();
               
                   txt_InvNu.Text = dal.getDataTabl_1(@"select isnull("+Doc_Type.Text+"+1,1) from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txt_cyear.Text + "'").Rows[0][0].ToString();
                        
           
        }

        private void Payment_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_invSer();
            invGrid1.total_inv();
        }

        private void paied_amount_KeyUp(object sender, KeyEventArgs e)
        {
            invGrid1.balance_amount.Text = (invGrid1.txtNetTotal.Text.ToDecimal() - invGrid1.paied_amount.Text.ToDecimal()).ToString();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            btntype = "0";
            get_invSer();
            tabControlPanel1.Enabled = true;
            tabControlPanel2.Enabled = true;
            tabControlPanel3.Enabled = true;
            invGrid1.Enabled = true;

            dt.Clear();
            invGrid1.dgv1.DataSource = null;
            invGrid1.dgv1.Refresh();
            invGrid1.dgv1.Rows.Clear();


            BSave.Enabled = true;
            txt_InvNot.Focus();
            
        }



        private void add_inv_data()
        {
            get_invSer();
            dal.open_1();
            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {
                cmd.CommandText = @"insert into wh_inv_data(Ser_no, Branch_code, Transaction_code, Cyear, Sanad_no, G_date, ACC_TYPE, Acc_no,
                        Acc_Branch_code, Payment_Type, Sales_man_Id, acc_serial_no, Po_no, User_id, NetAmount, PanyedAmount,
                        Cash_costomer_name, total_cost, Inv_Notes, Costmer_No, Phone, Adress, K_M_ACC_NO, K_M_Credit_TAX,
                        K_M_Debit_TAX, COSTMER_K_M_NO, K_M_SER, KM_CODE_ACC, MAIN_KM_CODE)
                        values('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text +
                        "', '" + txt_InvDate.Value.ToString("yy") + "' ,'" + txtMainSer.Text +
                        "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','A', '" + txt_Acc.ID.Text +
                        "', '" + txtBranch_Id.Text + "', '" + txt_PayType.ID.Text +
                        "', '" + Uc_Cost.ID.Text + "', '" + AccSer_No.Text + "', '" + Po_No.Text + "' , '" + userID.Text +
                        "', '" + invGrid1.txtNetTotal.Text.ToDecimal() + "', '" + invGrid1.paied_amount.Text.ToDecimal() +
                        "', '" + cashCustomer.Desc.Text + "', '0', '" + txt_InvNot.Text + "', '" + cashCustomer.ID.Text +
                        "', '" + txt_custTel.Text + "', '" + txt_address.Text + "', '" + txt_vatAcc.Text + "', '" + invGrid1.txtTotalVAT.Text.ToDecimal() +
                        "', '0', '" + Cust_Vat_No.Text + "', '0','" + txtKmCode.Text + "','" + Vat_Class.Text + "')";
                cmd.ExecuteNonQuery();

                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                          && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                          && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                           )

                    {
                        cmd.CommandText = @" insert into wh_material_transaction (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc,DISC_R,DISC_R2,DISC_R3,
            G_DATE,Unit,Local_Price,USER_ID,main_counter,balance,Store_Code,Weight,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT) 
           values( '" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + txt_InvDate.Value.ToString("yy") +
            "' ,'" + txtMainSer.Text + "','" + invGrid1.dgv1.Rows[i].Cells[0].Value.ToString() + "' ,'0','" +
            invGrid1.dgv1.Rows[i].Cells[5].Value.ToString().ToDecimal() + "','" + invGrid1.dgv1.Rows[i].Cells[15].Value.ToString().ToDecimal() +
            "','" + ((invGrid1.dgv1.Rows[i].Cells[9].Value.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells[8].Value.ToString().ToDecimal()) + invGrid1.disc_Rate.Text.ToDecimal()) * 100 +
            "' ,'" + (invGrid1.dgv1.Rows[i].Cells[9].Value.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells[8].Value.ToString().ToDecimal()) * 100 + "' ,'0','" + (invGrid1.disc_Rate.Text.ToDecimal()) * 100 +
            "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + invGrid1.dgv1.Rows[i].Cells[3].Value.ToString() +
            "' ,'" + invGrid1.dgv1.Rows[i].Cells[6].Value.ToString().ToDecimal() + "' , '" + userID.Text + "','" +
            invGrid1.dgv1.Rows[i].Index + "', '" + invGrid1.dgv1.Rows[i].Cells[4].Value.ToString().ToDecimal() + "', '" + txtStore_ID.Text +
            "','" + invGrid1.dgv1.Rows[i].Cells[5].Value.ToString().ToDecimal() + "','" + invGrid1.dgv1.Rows[i].Cells[16].Value.ToString() +
            "' ,'0','" + invGrid1.dgv1.Rows[i].Cells[12].Value.ToString().ToDecimal() + "')";
            cmd.ExecuteNonQuery();
                    }
                }


                cmd.CommandText = @"Update wh_Serial set XVO='" + txt_InvNu.Text + "'  where Branch_code='" + txtStore_ID.Text
                     + "' and Cyear= '" + txt_cyear.Text + "' ";
                cmd.ExecuteNonQuery();
                trans.Commit();
                IsNew = false;
                MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

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





        private void BSave_Click(object sender, EventArgs e)
        {

            try
            {
            
                if (txt_Acc.ID.Text == string.Empty)
                {
                    MessageBox.Show("فضلا.. تاكد من اختيار العميل ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (invGrid1.dgv1.Rows.Count < 1)
                {
                    MessageBox.Show("فضلا.. تاكد من اختيار الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (txt_PayType.ID.Text.Trim() =="")
                {
                    MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (invGrid1.txtNetTotal.Text.ToDecimal() <= 0)
                {
                    MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او ياو", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               

                if (txt_PayType.ID.Text.Trim() == "11" || txt_PayType.ID.Text.Trim() == "12")
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
           
               
                get_invSer();

                AccSer_No.Text = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchId
                 + "' and ACC_YEAR= '" + acc_year.Text + "' ").Rows[0][0].ToString();//.PadLeft(4, '0');


                AddInv();
                AddInvDetails();
                //if (Convert.ToString(Payment_Type.SelectedValue) == "11")
                //{
                //    Add_sands();
                //}
                dal.Execute_1(@"UPDATE  wh_Serial SET "+ Doc_Type.Text+" = '" + txt_InvNu.Text + "' WHERE Branch_code = '" + txtStore_ID.Text+ "' and Cyear='" + txt_InvDate.Value.ToString("yy")+"' ");

                if (Properties.Settings.Default.TRANS_TO_ACC == "A")
                {
                    Add_Jor();
                    dal.Execute_1(@"UPDATE serial_no SET main_daily_ser = '" + AccSer_No.Text + "' WHERE BRANCH_CODE= '" + Properties.Settings.Default.BranchId + "' and ACC_YEAR='" + acc_year.Text + "' ");
                }
                MessageBox.Show("تم الحفظ بنجاح", "حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControlPanel1.Enabled = false;
                tabControlPanel2.Enabled = false;
                tabControlPanel3.Enabled = false;
                invGrid1.Enabled = false;

                BSave.Enabled = false;
            }



            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }

        }

        private void AddInv()
        {

           dal.Execute_1(@"insert into wh_inv_data(Ser_no, Branch_code, Transaction_code, Cyear, Sanad_no, G_date, ACC_TYPE, Acc_no,
                        Acc_Branch_code, Payment_Type, Sales_man_Id, acc_serial_no, Po_no, User_id, NetAmount, PanyedAmount,
                        Cash_costomer_name, total_cost, Inv_Notes, Costmer_No, Phone, Adress, K_M_ACC_NO, K_M_Credit_TAX,
                        K_M_Debit_TAX, COSTMER_K_M_NO, K_M_SER, KM_CODE_ACC, MAIN_KM_CODE)
                        values('" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text +
                        "', '" + txt_InvDate.Value.ToString("yy") + "' ,'" + txtMainSer.Text +
                        "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','A', '" + txt_Acc.ID.Text +
                        "', '" + txtBranch_Id.Text + "', '" + txt_PayType.ID.Text +
                        "', '" + Uc_Cost.ID.Text + "', '" + AccSer_No.Text + "', '" + Po_No.Text + "' , '" + userID.Text +
                        "', '" + invGrid1.txtNetTotal.Text.ToDecimal() + "', '" + invGrid1.paied_amount.Text.ToDecimal() +
                        "', '" +cashCustomer.Desc.Text + "', '0', '" + txt_InvNot.Text + "', '" + cashCustomer.ID.Text +
                        "', '" + txt_custTel.Text + "', '" + txt_address.Text + "', '" + txt_vatAcc.Text + "', '" + invGrid1.txtTotalVAT.Text.ToDecimal() +
                        "', '0', '" + Cust_Vat_No.Text + "', '0','" + txtKmCode.Text+"','" + Vat_Class.Text + "')");

               }



        private void Add_sands()
        {

            txt_sandNo.Text = dal.getDataTabl_1(@"select isnull(max(last_ser)+1,1) from Serails_tbl where Baranch_ID='" + Properties.Settings.Default.BranchId
                       + "' and Cyear= '" + acc_year.Text + "' and doc_Id =  'CR'").Rows[0][0].ToString();

            dal.Execute_1(@"Insert into Sands_tbl values( '" + acc_year.Text + "', '" + txt_Acc.ID.Text + "','"
             + txtBranch_Id.Text + "', '" + AccSer_No.Text + "','"+ Uc_Cost.ID.Text +"',0, '" + invGrid1.txtNetTotal.Text + "','"
             + txt_InvDate.Value.Date.ToString("yyyy/MM/dd") + "' , '" + txt_sandNo.Text + "','" 
             + txt_PayType.ID.Text + "','" + userID.Text + "',  'سداد فاتورة مبيعات ' +'" 
             + txt_PayType.Desc.Text + "' + ' رقم ' + '" + txt_InvNu.Text + "', '" + txt_Check.Text + "' ,'" 
             + Convert.ToString(cmb_Bank.SelectedValue) + "','" + (Check_Date.Value > Check_Date.MinDate ? 
             Check_Date.Value.Date.ToString("yyyy/MM/dd") : Check_Date.MinDate.Date.ToString("yyyy/MM/dd")) + "','" 
             + Convert.ToString(cmb_Pay.SelectedValue) + "','','" + txt_InvNot.Text + "','CR','" + txtStore_ID.Text 
             + "','" + invGrid1.txtTotalVAT.Text.ToDecimal() + "','" + txt_CashAcc.ID.Text + "','" + txt_InvNu.Text + "','" 
             + invGrid1.paied_amount.Text + "','"+ cashCustomer.Desc.Text +"')");


            DataTable dt_ = dal.getDataTabl_1("Select * from Serails_tbl where Baranch_ID= '" + txtStore_ID.Text + "' and Cyear='" + acc_year.Text
                          + "' and doc_Id = 'CR'");
            if (dt_.Rows.Count > 0)
            {


                dal.Execute_1(@"UPDATE Serails_tbl SET last_ser = '" + txt_sandNo.Text + "' WHERE Baranch_ID= '" +
                    Properties.Settings.Default.BranchId + "' and Cyear='" + acc_year.Text + "' and doc_Id = 'CR'");


            }

            else
            {
                dal.Execute_1(@"INSERT INTO Serails_tbl  Values ('" + txtStore_ID.Text + "' , '" + acc_year.Text + "' ,  'CR','','','" + txt_sandNo.Text + "'");
            }


        }



        private void AddInvDetails()
        {
            for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
            {
                if (invGrid1.dgv1.Rows[i].Cells[0].Value != null && invGrid1.dgv1.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0)
                    //&& dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal() > 0)
                {
            dal.Execute_1(@" insert into wh_material_transaction (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc,DISC_R,DISC_R2,DISC_R3,
            G_DATE,Unit,Local_Price,USER_ID,main_counter,balance,Store_Code,Weight,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT) 
           values( '" + txt_InvNu.Text + "', '" + txtStore_ID.Text + "', '" + Doc_Type.Text + "', '" + txt_InvDate.Value.ToString("yy") +
            "' ,'" + txtMainSer.Text + "','" + invGrid1.dgv1.Rows[i].Cells[0].Value.ToString() + "' ,'0','" +
            invGrid1.dgv1.Rows[i].Cells[5].Value.ToString().ToDecimal() + "','" + invGrid1.dgv1.Rows[i].Cells[15].Value.ToString().ToDecimal() +
            "','" + ((invGrid1.dgv1.Rows[i].Cells[9].Value.ToString().ToDecimal()/ invGrid1.dgv1.Rows[i].Cells[8].Value.ToString().ToDecimal()) + invGrid1.disc_Rate.Text.ToDecimal())*100 +
            "' ,'" + (invGrid1.dgv1.Rows[i].Cells[9].Value.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells[8].Value.ToString().ToDecimal())*100 + "' ,'0','" + (invGrid1.disc_Rate.Text.ToDecimal())*100 +
            "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + invGrid1.dgv1.Rows[i].Cells[3].Value.ToString()+
            "' ,'" + invGrid1.dgv1.Rows[i].Cells[6].Value.ToString().ToDecimal() + "' , '" + userID.Text + "','"+
            invGrid1.dgv1.Rows[i].Index+"', '" + invGrid1.dgv1.Rows[i].Cells[4].Value.ToString().ToDecimal() + "', '" + txtStore_ID.Text +
            "','" + invGrid1.dgv1.Rows[i].Cells[5].Value.ToString().ToDecimal() + "','" + invGrid1.dgv1.Rows[i].Cells[16].Value.ToString() +
            "' ,'0','" + invGrid1.dgv1.Rows[i].Cells[12].Value.ToString().ToDecimal() + "')");

                }
            }
        }


      
        private void Add_Main_transaction()
        {

        }

        private void Add_daily_transaction()
        {

        }

        private void BSearch_Click(object sender, EventArgs e)
        {

            PL.invoice_list_frm ord = new PL.invoice_list_frm();
            ord.trans_code = "xsc";
            ord.trans_code_1 = "xsd";
            ord.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string printModel = Properties.Settings.Default.inv_print;
            if (printModel == "1")
            {
                RPT.Rpt_inv reportInv = new RPT.Rpt_inv();
                RPT.Form1 frminv = new RPT.Form1();
                reportInv.SetDataSource(dal.getDataTabl("get_invDetails", txt_InvNu.Text, Doc_Type.Text, txt_InvDate.Value.Year.ToString()));
                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }

            else

            {
                RPT.Rpt_inv_1 reportInv = new RPT.Rpt_inv_1();
                RPT.Form1 frminv = new RPT.Form1();
                reportInv.SetDataSource(dal.getDataTabl("get_invDetails", txt_InvNu.Text, Doc_Type.Text, txt_InvDate.Value.Year.ToString()));
                //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                //reportInv.PrintToPrinter(1, false, 0, 15);
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }
               
        }


        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // Qutation_list_frm ord = new Qutation_list_frm();
            //ord.ShowDialog();

            //string invnu = Convert.ToString(ord.dg_orders_list.CurrentRow.Cells[0].Value);
            //string Trans_id = Convert.ToString(ord.dg_orders_list.CurrentRow.Cells[7].Value);
            // DateTime Cyear = DateTime.Parse(ord.dg_orders_list.CurrentRow.Cells[1].Value.ToString());
            //string cyear_ = Cyear.Year.ToString();
            // DataTable dtMain_ = dal.getDataTabl("get_Qutation", txt_Qutation.Text, Properties.Settings.Default.BranchId, "Qut", txt_InvDate.Value.Year.ToString());

            DataTable dtMain_ = dal.getDataTabl_1(@"SELECT Qutation_Tbl.*,Payment_name,dbo.Tafkeet(InvNetTotal,'SAR')as tfqtAR,saleman,C_Name,branch_name
            FROM Qutation_Tbl inner join wh_Payment_type on wh_Payment_type.Payment_type=Qutation_Tbl.Payment_Type
            inner join Customer_Tbl on Customer_Tbl.C_ID=Qutation_Tbl.custID
            inner join wh_BRANCHES on wh_BRANCHES.Branch_code=Qutation_Tbl.DepID
            where Qutation_Tbl.SerNO='" + txt_Qutation.Text + "' and DepID='" + Properties.Settings.Default.BranchId + "' and Qutation_Tbl.TransID='Qut' and Qutation_Tbl.Cyear='" + txt_InvDate.Value.Year.ToString() + "'");


            txt_InvNu.Text = dtMain_.Rows[0][0].ToString();
            txt_InvDate.Text = dtMain_.Rows[0][1].ToString();
            txt_Acc.ID.Text = dtMain_.Rows[0][2].ToString();
            txt_InvNot.Text = dtMain_.Rows[0][3].ToString();
            //invGrid1.TxtTotal.Text = dtMain_.Rows[0][4].ToString();
            //invGrid1.txtDiscount.Text = dtMain_.Rows[0][5].ToString();
            invGrid1.txtNetTotal.Text = dtMain_.Rows[0][6].ToString();
            txtStore_ID.Text = dtMain_.Rows[0][7].ToString();
            txt_PayType.ID.Text = dtMain_.Rows[0][11].ToString();
            txt_custTel.Text = dtMain_.Rows[0][13].ToString();
            txt_custFax.Text = dtMain_.Rows[0][15].ToString();
            txt_CustEmail.Text = dtMain_.Rows[0][16].ToString();
           
            DataTable dt_ = dal.getDataTabl_1(@"SELECT Qutation_Details_Tbl.*,Product_Tbl.Desc_pro,Product_Tbl.wight
            FROM Qutation_Details_Tbl inner join Product_Tbl on Qutation_Details_Tbl.Id_pro=Product_Tbl.Id_Pro
            where Qutation_Details_Tbl.Id_order='" + txt_Qutation.Text + "' and Qutation_Details_Tbl.BranchID='" + Properties.Settings.Default.BranchId
             + "' and Qutation_Details_Tbl.TransID='Qut' and Qutation_Details_Tbl.cyear='" + txt_InvDate.Value.Year.ToString() + "'");


            dt.Clear();
            int i = 0;
            DataRow row = null;
            foreach (DataRow r in dt_.Rows)
            {

                row = dt.NewRow();
                row[0] = dt_.Rows[i][0];
                row[1] = dt_.Rows[i][12];
                row[2] = dt_.Rows[i][14];
                row[3] = dt_.Rows[i][3];
                row[4] = dt_.Rows[i][4];
                row[5] = dt_.Rows[i][13];
                row[6] = dt_.Rows[i][5];
                row[7] = dt_.Rows[i][6];
                row[8] = dt_.Rows[i][7];
                row[9] = dt_.Rows[i][2];


                dt.Rows.Add(row);
                i = i + 1;
            }

          //  invGrid1.dgv1.DataSource = dt;
            

        }

            private void invoice_frm_Load(object sender, EventArgs e)
        {
            btnPrint.Visible = true;
            btnSearch.Visible = true;

            btnGoFrist.Visible = true;
            btnGoPrevious.Visible = true;
            btnGoNext.Visible = true;
            btn_GoLast.Visible = true;

            //txt_Acc.txtMainAcc.Text = "123";
            //txt_Acc.txtFinal.Text = "1";
            //txt_Acc.branchID.Text = Properties.Settings.Default.BranchAccID;
            New();

            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Syria));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.S));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Tunisia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Gold));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Bahrain));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Oman));

            switch (Properties.Settings.Default.Currency)
            {
                case "s":
                    currencyNo = 2;
                    break;
                case "BH":
                    currencyNo = 5;
                    break;
                case "OM":
                    currencyNo = 6;
                    break;
                case "DR":
                    currencyNo = 1;
                    break;
            }


   }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Add_Jor()
        {
            string cyear = txt_InvDate.Value.Year.ToString("yy");
            string H_Date = date_.GregToHijri(txt_InvDate.Text);
           

            dal.Execute_1(@"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
            balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO )
            Values('" + acc_year.Text+"', '"+txt_Acc.ID.Text+"', '"+ txtBranch_Id.Text + "','" + AccSer_No.Text + "','" + 
            Uc_Cost.ID.Text + "','" + invGrid1.txtNetValue.Text + "','" + 0 + "','" + invGrid1.txtNetValue.Text + "','" + H_Date + "','" + 
            txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" + 
            userID.Text + "','" + "فاتورة مبيعات " + txt_PayType.Desc.Text + " رقم " + txt_InvNu.Text + "','0','" + Doc_Type.Text + "','" + 
            txtStore_ID.Text + "','" + AccSer_No.Text + "')");


            dal.Execute_1(@"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
            balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO )
            Values('" + acc_year.Text + "', '" + txtAcc2.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
            Uc_Cost.ID.Text + "','" + 0 + "','" + invGrid1.txtNetTotal.Text.ToDecimal() + "','" + -invGrid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
            txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
            userID.Text + "','" + "فاتورة مبيعات " + txt_PayType.Desc.Text + " رقم " + txt_InvNu.Text + "','0','" + Doc_Type.Text + "','" +
            txtStore_ID.Text + "','" + AccSer_No.Text + "')");

            dal.Execute_1(@"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
            balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO )
            Values('" + acc_year.Text + "', '" + txt_vatAcc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
            Uc_Cost.ID.Text + "','" + 0 + "','" + invGrid1.txtTotalVAT.Text.ToDecimal() + "','" + -invGrid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
            txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
            userID.Text + "','" + "ضريبة فاتورة مبيعات " + txt_PayType.Desc.Text + " رقم " + txt_InvNu.Text + "','0','" + Doc_Type.Text + "','" +
            txtStore_ID.Text + "','" + AccSer_No.Text + "')");




        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

         
            DataTable dtMain_ = dal.getDataTabl_1(@"SELECT * FROM wh_Po_Cot_inv_data
                      where Ser_NO='" + txt_Qutation.Text + "' and Branch_code='" + Properties.Settings.Default.BranchId +
                      "' and Transaction_code ='CO' and Cyear='" + txt_InvDate.Value.ToString("yy") + "'");


    
            txt_Acc.ID.Text = dtMain_.Rows[0][8].ToString();
            txt_InvNot.Text = dtMain_.Rows[0]["Costomer_Notes"].ToString();
            txtStore_ID.Text = dtMain_.Rows[0]["Branch_code"].ToString();
            txt_PayType.ID.Text = dtMain_.Rows[0]["Payment_Type"].ToString();
            txt_custTel.Text = dtMain_.Rows[0]["Costomer_Phone"].ToString();
            txt_custFax.Text = dtMain_.Rows[0]["Costmer_fax"].ToString();
            txt_CustEmail.Text = dtMain_.Rows[0]["E_mail"].ToString();

            // DataTable dt_ = dal.getDataTabl("Get_Qutation_Details", txt_Qutation.Text, Properties.Settings.Default.BranchId, "Qut", txt_InvDate.Value.Year.ToString());

            DataTable dt_ = dal.getDataTabl_1(@" SELECT A.*,M.descr,M.Descr_eng,Weight,k.KM_RATIO
            FROM wh_Po_Cot_MATERIAL_TRANSACTION As A inner join wh_main_master As M on A.item_no=M.item_no 
			inner join KM_MATERIAL_CODE as K on K.KM_CODE=A.K_M_TYPE_ITEMS
            where A.SER_NO='" + txt_Qutation.Text + "' and A.Branch_code='" + Properties.Settings.Default.BranchId + "' and A.TRANSACTION_CODE='CO' and A.Cyear='" + txt_InvDate.Value.ToString("yy") + "'");

            dt.Clear();
            int i = 0;
            DataRow row = null;
            foreach (DataRow r in dt_.Rows)
            {

                row = dt.NewRow();
                row[0] = dt_.Rows[i]["ITEM_NO"];
                row[1] = dt_.Rows[i]["descr"];
                row[2] = dt_.Rows[i]["DETAILS"];
                row[3] = dt_.Rows[i]["Unit"];
                row[4] = dt_.Rows[i]["Weight"];
                row[5] = dt_.Rows[i]["QTY_TAKE"];
                row[6] = dt_.Rows[i]["Local_Price"];
                row[7] = '0';
                row[8] = dt_.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_.Rows[i]["Local_Price"].ToString().ToDecimal();
                row[9] = '0';
                row[10] = dt_.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_.Rows[i]["Local_Price"].ToString().ToDecimal();
                row[11] = dt_.Rows[i]["KM_RATIO"];
                row[12] = dt_.Rows[i]["TAX_OUT"];
                row[13] = dt_.Rows[i]["Weight"].ToString().ToDecimal() * dt_.Rows[i]["Local_Price"].ToString().ToDecimal();
                row[14] = '0';
                row[15] = '0';
                row[16] = dt_.Rows[i]["K_M_TYPE_ITEMS"];
                //row[9] = dt_.Rows[i][2];


                dt.Rows.Add(row);
                i = i + 1;
            }

            invGrid1.dgv1.DataSource = dt;
            invGrid1.total_inv();

        }

        
   

     
        void creatDattable()
        {
            dt.Columns.Add("رقم الصنف");
            dt.Columns.Add(" اسم الصنف");
            dt.Columns.Add(" الوصف");
            dt.Columns.Add(" الوحدة");
            dt.Columns.Add("الوزن");
            dt.Columns.Add(" الكمية");
            dt.Columns.Add("السعر");
            dt.Columns.Add("سعر الطن");
            dt.Columns.Add(" الاجمالي");
            dt.Columns.Add("الخصم");
            dt.Columns.Add("الصافي");
            dt.Columns.Add("نسبة الضريبة");
            dt.Columns.Add("مبلغ الضريبة");
            dt.Columns.Add("اجمالي الوزن");
            dt.Columns.Add("الرصيد");
            dt.Columns.Add("التكلفة");
            dt.Columns.Add("كود القيمة المضافة");
            invGrid1.dgv1.DataSource = dt;
        }

    
        
        private void print_sand_Click(object sender, EventArgs e)
        {
            try
            {
                RPT.Form1 frmSand = new RPT.Form1();
                RPT.CrystalReport5 print_sand = new RPT.CrystalReport5();
                DataTable dt1 = new DataTable();

                dt1 = dal.getDataTabl_1(@"select Sands_tbl.*,payer2.PAYER_NAME,p2.PAYER_NAME,bank_name,pay_name from Sands_tbl
            inner join payer2 on sands_tbl.Acc_no=payer2.Acc_No
            inner join payer2 as p2 on sands_tbl.Cash_acc=p2.Acc_No
            left join SHEEK_BANKS_TYPE on bank_no=sheek_bank
            left join pay_method on pay_id=sheek_or_cash
            where sanad_no='" + txt_sandNo.Text + "' and source_code='CR'");

                string tafqeet = dal.getDataTabl_1("select dbo.Tafkeet('" + dt1.Rows[0][24] + "','SAR')").Rows[0][0].ToString();
                print_sand.SetDataSource(dt1);
                print_sand.DataDefinition.FormulaFields["Tafqeet"].Text = "'" + tafqeet + "'";

                frmSand.crystalReportViewer1.ReportSource = print_sand;
                frmSand.ShowDialog();


                DataSet ds = new DataSet("sanads");
                ds.Tables.Add(dt1);

                ////ds.WriteXmlSchema("schema3.xml");
            }
            catch { }
        }

        private void cmb_Pay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(cmb_Pay.SelectedValue) == "04")
            {
                txt_Check.Enabled = true;
                cmb_Bank.Enabled = true;
                Check_Date.Enabled = true;
            }
            else
            {

                txt_Check.Enabled = false;
                cmb_Bank.Enabled = false;
                Check_Date.Enabled = false;
                txt_Check.Clear();
                cmb_Bank.SelectedIndex = -1;
                Check_Date.Text = "";

            }
        }

      

        private void btn_getDeleviries_Click(object sender, EventArgs e)
        {
            get_deleveries(txt_Acc.ID.Text);
           
        }

        private void get_deleveries(string accNo_)
        {
            DataTable dt_D1 = dal.getDataTabl_1(@"select A.Ser_no,A.SO_no,A.QUOT_REF_NO,A.Branch_code,A.Cyear,A.G_date,A.Transaction_code  from 
            wh_inv_data_Delevry As A
            WHERE A.QUOT_REF_NO like Case when '" + txt_SO_Search.Text.Trim() + "' = '' then '%' else '" + txt_SO_Search.Text.Trim() + "' end AND NULLIF(A.inv_no,'') is null and Acc_no = '" + accNo_ + "' ");
            invGrid1.dgv1.Rows.Clear();
            dgv_Delevery.Rows.Clear();

            if (dt_D1.Rows.Count > 0)
            {
                int rowscount = dt_D1.Rows.Count;
                dgv_Delevery.Rows.Add(rowscount);
                for (int i = 0; i <= (rowscount - 1); i++)

                {
                    dgv_Delevery.Rows[i].Cells[col_D_so.Name].Value = dt_D1.Rows[i]["SO_no"].ToString();
                    dgv_Delevery.Rows[i].Cells[col_D_ser.Name].Value = dt_D1.Rows[i]["ser_no"].ToString();
                    dgv_Delevery.Rows[i].Cells[col_D_year.Name].Value = dt_D1.Rows[i]["Cyear"].ToString();
                    dgv_Delevery.Rows[i].Cells[col_d_date.Name].Value = dt_D1.Rows[i]["G_date"].ToString();
                    dgv_Delevery.Rows[i].Cells[col_D_branch.Name].Value = dt_D1.Rows[i]["Branch_code"].ToString();
                    dgv_Delevery.Rows[i].Cells[col_D_transaction.Name].Value = dt_D1.Rows[i]["Transaction_code"].ToString();
                    dgv_Delevery.Rows[i].Cells[col_D_transaction.Name].Value = dt_D1.Rows[i]["Transaction_code"].ToString();

                }
            }
        }


        private void dgv_Delevery_Click(object sender, EventArgs e)
        {
            int i = dgv_Delevery.CurrentCell.RowIndex;

            DataTable dt_D_add = dal.getDataTabl_1(@"select a.Ser_no,A.Branch_code,A.Transaction_code,A.Cyear,A.G_date,A.Acc_no,A.Acc_Branch_code,A.Payment_Type,a.Sales_man_Id,A.User_id,A.Validity,A.TermsOfPaymentE,A.DelevryE,
            A.Costomer_adress,A.Costomer_Phone,A.Costmer_fax,A.Ref,A.E_mail,A.BankNo,A.PERM_SER,A.K_M_ACC_NO,A.COSTMER_K_M_NO,A.KM_CODE_ACC,A.MAIN_KM_CODE,A.Costomer_Notes,A.Cash_costomer_name,A.Costmer_no,A.QUOT_REF_NO,A.QUOT_REF_DATE,A.Po_no,A.SO_no
            ,B.ITEM_NO,C.weight,c.descr,isnull(NULLIF(C.Descr_eng,''),C.descr) as Descr_eng,B.DETAILS,B.QTY_TAKE, B.Unit,B.Local_Price ,B.Pice_Total_Cost 
            ,(select top 1 vat_ratio from VAT_RATIO_MASTER where  date_of_vat <= '" + invGrid1. invVAtDate.Value.ToString("yyyy-MM-dd") + "'  order by date_of_vat desc) as VatRatio " +
            ",isnull ((SELECT sum(QTY_Balance) AS baance FROM VIEW_balance AS V  WHERE V.item_no = b.ITEM_NO AND branch_code LIKE ' %'), 0) AS Balance " +
            "from wh_inv_data_Delevry As A " +
            "inner join wh_MATERIAL_TRANSACTION_Delevry as B " +
            "on A.Ser_no =B.SER_NO and A.Branch_code=B.Branch_code AND A.Cyear=B.Cyear AND A.Transaction_code=B.TRANSACTION_CODE " +
            "inner join wh_main_master as C on b.ITEM_NO=c.item_no " +
            "WHERE  A.Ser_no ='" + dgv_Delevery.Rows[i].Cells[col_D_ser.Name].Value.ToString() + "'  and A.Branch_code='" + dgv_Delevery.Rows[i].Cells[col_D_branch.Name].Value.ToString() + "' AND A.Cyear='" + dgv_Delevery.Rows[i].Cells[col_D_year.Name].Value.ToString() + "' AND A.Transaction_code='" + dgv_Delevery.Rows[i].Cells[col_D_transaction.Name].Value.ToString() + "'");

            if (dt_D_add.Rows.Count > 0)
            {
                txt_PayType.ID.Text = dt_D_add.Rows[0]["Payment_Type"].ToString();
                txt_address.Text = dt_D_add.Rows[0]["Costomer_adress"].ToString();
                txt_custTel.Text = dt_D_add.Rows[0]["Costomer_Phone"].ToString();
                txt_custFax.Text = dt_D_add.Rows[0]["Costmer_fax"].ToString();
                txtSoNo.Text = dt_D_add.Rows[0]["SO_no"].ToString();
                txt_Qutation.Text = dt_D_add.Rows[0]["QUOT_REF_NO"].ToString();
                txtQuotationDate.Text = dt_D_add.Rows[0]["QUOT_REF_DATE"].ToString();
                txt_CustEmail.Text = dt_D_add.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_D_add.Rows[0]["TermsOfPaymentE"].ToString();
                DelevryTearms.SelectedValue = dt_D_add.Rows[0]["DelevryE"].ToString();
                if (dt_D_add.Rows[0]["BankNo"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_D_add.Rows[0]["BankNo"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }
                Po_No.Text = dt_D_add.Rows[0]["Po_no"].ToString();
                Uc_Cost.ID.Text = dt_D_add.Rows[0]["Sales_man_Id"].ToString();
                Cust_Vat_No.Text = dt_D_add.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_D_add.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_D_add.Rows[0]["MAIN_KM_CODE"].ToString();
                txt_attn.Text = dt_D_add.Rows[0]["Cash_costomer_name"].ToString();
              txt_InvNot.Text = dt_D_add.Rows[0]["Costomer_Notes"].ToString();
                for (int ii = 0; ii < dt_D_add.Rows.Count; ii++)
                {
                    int n1 = invGrid1.dgv1.Rows.Add();
                    invGrid1.dgv1.Rows[n1].Cells["_code"].Value = dt_D_add.Rows[ii]["ITEM_NO"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_itemDesription"].Value = dt_D_add.Rows[ii]["descr"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_addDescription"].Value = dt_D_add.Rows[ii]["DETAILS"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_unit"].Value = dt_D_add.Rows[ii]["Unit"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_weight"].Value = dt_D_add.Rows[ii]["weight"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_qty"].Value = dt_D_add.Rows[ii]["QTY_TAKE"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_price"].Value = dt_D_add.Rows[ii]["Local_Price"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_vatRatio"].Value = dt_D_add.Rows[ii]["VatRatio"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_balance"].Value = dt_D_add.Rows[ii]["Balance"].ToString();
                    invGrid1.dgv1.Rows[n1].Cells["_cost"].Value = dt_D_add.Rows[ii]["Pice_Total_Cost"].ToString().ToDecimal().ToString("N" + dal.digits_);

                    invGrid1.dgv1.Rows[n1].Cells["_documentNo"].Value = dt_D_add.Rows[ii]["Ser_no"].ToString();
                }
                dgv_Delevery.Rows.RemoveAt(this.dgv_Delevery.CurrentRow.Index);

                for (int r = 0; r < invGrid1.dgv1.Rows.Count; r++)
                {

                    invGrid1.clculat_amount(r);
                    invGrid1.clculatTotalWeight(r);
                    invGrid1.clculatTonPrice(r);
                }
                invGrid1.total_inv();

            }



        }

       
        private void txt_SO_Search_KeyUp(object sender, KeyEventArgs e)
        {
            get_deleveries(txt_Acc.ID.Text);
        }

        private void Uc_Customer_Load(object sender, EventArgs e)
        {
            invGrid1.dgv1.Rows.Clear();
            dgv_Delevery.Rows.Clear();

            string Get_cust = @"SELECT p.ACC_NO,p.phone_no,p.fax_no,p.E_MAIL,p.COSTMER_K_M_NO
                            ,p.adress,p.adress_E,p.resp_name,p.resp_name_E,p.area_code,p.b_o_box
                            FROM PAYER2 as P 
                            where  BRANCH_code='" + txt_Acc.branchID.Text + "' and acc_no like '" + txt_Acc.txtMainAcc.Text + "%' and  ACC_NO ='" + txt_Acc.ID.Text + "'";

            DataTable dt_itme = dal.getDataTabl_1(Get_cust);
            if (dt_itme.Rows.Count > 0)
            {
                txt_custTel.Text = dt_itme.Rows[0]["phone_no"].ToString();
                txt_custFax.Text = dt_itme.Rows[0]["fax_no"].ToString();
                txt_CustEmail.Text = dt_itme.Rows[0]["E_MAIL"].ToString();
                Cust_Vat_No.Text = dt_itme.Rows[0]["COSTMER_K_M_NO"].ToString();
                txt_address.Text = dt_itme.Rows[0]["adress"].ToString();
                txt_attn.Text = dt_itme.Rows[0]["resp_name"].ToString();
                txt_area_code.Text = dt_itme.Rows[0]["area_code"].ToString();
                txt_BoBox.Text = dt_itme.Rows[0]["b_o_box"].ToString();

                txtKmCode.Text = txt_Acc.txtKMCode.Text;
                Vat_Class.Text = txt_Acc.KM_Code_Sales.Text;
                Vat_Class_Desc.Text = txt_Acc.KM_Desc_Sales.Text;
                Cust_Vat_Rate.Text = txt_Acc.KM_Ratio_Sales.Text;
                invGrid1.txtAccVat_Rate.Text = txt_Acc.KM_Ratio_Sales.Text;

                if (txt_Acc.ID.Text == dal.getDataTabl_1(@"select Cash_Costmer_Code FROM wh_BRANCHES where BRANCH_code='" + txt_Acc.branchID.Text + "'").Rows[0][0].ToString())
                {
                    txt_PayType.ID.Text = "11";
                    txt_PayType.Enabled = false;
                    //cashCustomer.Desc.Clear();

                }
                else
                {
                    txt_PayType.ID.Text = "";
                    txt_PayType.Enabled = true;
                    //  cashCustomer.Desc.Text = dt_itme.Rows[0][7].ToString();
                }


                invGrid1.total_inv();
            }
            //DataTable dt_M = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no FROM wh_BRANCHES where BRANCH_code like '" + Properties.Settings.Default.BranchId + "%'");
            //if (dt_M.Rows.Count > 0)
            //{
            //    string Acc_main = dt_M.Rows[0][0].ToString();
            //    string Acc_cash = dt_M.Rows[0][2].ToString();
            //    DataTable dt_cust = dal.getDataTabl_1(@"select P.*,A.MAIN_KM_CODE,a.MAIN_KM_DESC,b.KM_RATIO,b.KM_CODE FROM payer2 As P left join KM_MAIN_ACC_CODE as A on  ISNULL(NULLIF(P.KM_CODE_Sales, ''), 11) = A.MAIN_KM_CODE
            //    left join  KM_ACC_CODE as b on b.KM_CODE = a.KM_CODE where P.BRANCH_code like '" + Properties.Settings.Default.BranchId + "%' and P.ACC_NO = '" + txt_Acc.ID.Text + "' and(P.ACC_NO like '" + Acc_main + "%' or P.ACC_NO like '" + Acc_cash + "%') and P.t_final ='1'");
            //    txtBranch_Id.Text = Properties.Settings.Default.BranchId;
            //    if (dt_cust.Rows.Count > 0)
            //    {
            //        if (txt_Acc.ID.Text == Acc_cash)
            //        {
            //            cashCustomer.Enabled = true;
            //            txt_PayType.ID.Text = "11";
            //            txt_PayType.Enabled = false;
            //            Vat_Class.Text = dt_cust.Rows[0][68].ToString();
            //            Vat_Class_Desc.Text = dt_cust.Rows[0][69].ToString();
            //            if (dt_cust.Rows[0][70].ToString() == string.Empty)
            //            { Cust_Vat_Rate.Text = "0.05"; }
            //            else
            //            {
            //                Cust_Vat_Rate.Text = dt_cust.Rows[0][70].ToString().ToDecimal().ToString("N2");
            //            }
            //            txtKmCode.Text = dt_cust.Rows[0][71].ToString();
            //        }
            //        else
            //        {
            //            cashCustomer.Enabled = false;
            //            txt_PayType.ID.Text = "2";
            //            txt_PayType.Enabled = true;

            //            txt_custTel.Text = dt_cust.Rows[0][14].ToString();
            //            txt_address.Text = dt_cust.Rows[0][11].ToString();
            //            txt_custFax.Text = dt_cust.Rows[0][16].ToString();
            //            txt_CustEmail.Text = dt_cust.Rows[0][15].ToString();
            //            txt_BoBox.Text = dt_cust.Rows[0][12].ToString();
            //            txt_area_code.Text = dt_cust.Rows[0][19].ToString();
            //            Cust_Vat_No.Text = dt_cust.Rows[0][60].ToString();
            //            Vat_Class.Text = dt_cust.Rows[0][68].ToString();
            //            Vat_Class_Desc.Text = dt_cust.Rows[0][69].ToString();
            //            if (dt_cust.Rows[0][70].ToString() == string.Empty)
            //            { Cust_Vat_Rate.Text = "0.05"; }
            //            else
            //            {
            //                Cust_Vat_Rate.Text = dt_cust.Rows[0][70].ToString().ToDecimal().ToString("N2");
            //            }
            //            txtKmCode.Text = dt_cust.Rows[0][71].ToString();
            //        }
            //    }
            //    else
            //    {
            //        cashCustomer.Enabled = false;
            //        txt_custTel.Clear();
            //        txt_address.Clear();
            //        txt_custFax.Clear();
            //        txt_CustEmail.Clear();
            //        txt_BoBox.Clear();
            //        txt_area_code.Clear();
            //        Cust_Vat_No.Clear();
            //        Vat_Class.Clear();
            //        Vat_Class_Desc.Clear();
            //        Cust_Vat_Rate.Clear();


            //    }
            //    invGrid1.total_inv();
            //}
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
        private void getSalesInv(string ser_, string branch_, string transaction_, string cyear_)

        {
            dt_inv = this.dal.getDataTabl_1(@"select A.ser_no,A.Branch_code,A.Cyear,A.Transaction_code,
            A.G_date,A.Acc_no,A.Payment_Type,A.Sales_man_Id,A.Inv_no,A.Inv_date,a.Inv_Notes,A.Phone,
            A.Adress,A.PROJECT_NO,A.Costmer_No,A.Cash_costomer_name,A.REQUIST_NO,A.Ref,A.acc_serial_no,a.Sanad_no,A.SO_no,A.Po_no,A.QUOT_REF_NO,A.QUOT_REF_DATE,A.TermsOfPaymentE,A.DelevryE,BankNo,
            A.Qutation_No,A.REQUIST_NO,isnull(A.Dowen_Payment_Ratio,0) as Dowen_Payment_Ratio,A.Dowen_Payment_acc_no,
            isnull( A.Dowen_Payment,0) as Dowen_Payment,Isnull(A.Dowen_Payment_Vat,0) as Dowen_Payment_Vat,isnull(A.Sales_Vat,0) as Sales_Vat,A.Guarantee_Acc,isnull(A.Guarantee_Ratio,0) as Guarantee_Ratio,Isnull(A.Guarantee_Amount,0) as Guarantee_Amount
            ,B.modular,B.DP_Ratio,B.DP_Amount,B.VAT_RATIO,B.main_counter,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.DETAILS,B.BALANCE,B.Pice_Total_Cost,B.K_M_TYPE_ITEMS,
            B.Unit,B.Local_Price,isnull(B.TAX_IN,0)as TAX_IN ,isnull(B.TAX_OUT,0)as TAX_OUT , round(B.total_disc*B.local_price*QTY_TAKE/100,2) as disc_ ,
            p.PAYER_NAME,p.payer_l_name,p2.PAYER_NAME as lc_name ,p2.payer_l_name as lc_L_Name,P.adress,P.adress_E ,P.phone_no,P.fax_no,P.E_MAIL,P.COSTMER_K_M_NO, P.SEGEL_NO,P.ZAKAH_NO,
            M.descr,M.Descr_eng,m.Weight, br.branch_name,BR.WH_E_NAME,Br.Branch_Logo_A4,PT.Payment_name,U.unit_Description, U.unit_Description_E,J.PROJ_name,J.PROJ_E_name
            , B.VAT_RATIO as VatRatio " +
            "from wh_inv_data As A " +
            "inner join wh_material_transaction As B on a.Ser_no = b.SER_NO and a.Cyear = b.Cyear and a.Transaction_code = b.TRANSACTION_CODE and a.Branch_code = b.Branch_code  " +
            "inner join payer2 As P on a.Acc_no = p.ACC_NO and a.Acc_Branch_code = p.BRANCH_code  " +
            "left join(select* from payer2)as p2 on p2.ACC_NO = a.LC_ACC_NO and a.Acc_Branch_code = p2.BRANCH_code  " +
            "inner join wh_main_master as M on M.item_no=B.ITEM_NO  " +
            "inner join wh_BRANCHES As BR on BR.Branch_code = a.Branch_code  " +
            "inner join wh_Payment_type as PT on A.Payment_Type=PT.Payment_type  " +
            "left join  Wh_Unit as U on U.Wh_Unit = B.unit " +
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
, round(sum(b.QTY_ADD * Local_Price), 2) - round(sum(b.total_disc * B.local_price * QTY_ADD / 100), 2) + round(sum(isnull(b.TAX_IN, 0)), 2) as NetValue 
from   wh_material_transaction as B		
where b.SER_NO = '" + ser_ + "'  and b.Transaction_code = '" + transaction_ + "' and b.Branch_code = '" + branch_ + "' and b.Cyear = '" + cyear_ +
"'group by B.TRANSACTION_CODE,B.Branch_code,B.Cyear,B.SER_NO) as X " +
"inner join wh_inv_data as B " +
"on X.Ser_no = B.SER_NO and X.Branch_code = B.Branch_code and X.Cyear = b.Cyear and X.Transaction_code=b.TRANSACTION_CODE ");
        }

//, round(sum(b.QTY_TAKE* Local_Price), 2) - round(sum(b.total_disc* B.local_price* QTY_TAKE / 100), 2) + round(sum(isnull(b.TAX_OUT, 0)), 2) as NetValue



        public override void Print()
        {
           
                DataSet dataSet = new DataSet();

                RPT.Rpt_Pro_Frm frminv = new RPT.Rpt_Pro_Frm();
                getSalesInv(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
                //DataTable dt_1 = dal.getDataTabl("get_invDetails", txt_InvNu.Text, Doc_Type.Text, txt_InvDate.Value.Year.ToString(), Properties.Settings.Default.BranchId);

                string printModel = Properties.Settings.Default.inv_print;

                getInvoiceTotal(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
                ToWord toWord = new ToWord(Math.Abs(Convert.ToDecimal(dt_inv_total.Rows[0]["NetValue"].ToString())), currencies[currencyNo]);


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
                    RPT.Rpt_Return_Contract_Invoice reportInv = new RPT.Rpt_Return_Contract_Invoice();
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
                    RPT.Rpt_Return_Contract_Invoice reportInv = new RPT.Rpt_Return_Contract_Invoice();
                    reportInv.SetDataSource(dataSet);
                    reportInv.DataDefinition.FormulaFields["tafqeet_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                    reportInv.DataDefinition.FormulaFields["tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                    //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
                    //reportInv.PrintToPrinter(1, false, 0, 15);
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
            







           // DataSet ds = new DataSet();

           // RPT.frm_Rpt_Pro_Frm frminv = new RPT.frm_Rpt_Pro_Frm();
           // //DataTable dt_1 = dal.getDataTabl("get_invDetails", txt_InvNu.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"), Properties.Settings.Default.BranchId);
           // getSalesInv(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));

           // string printModel = Properties.Settings.Default.inv_print;

           // getInvoiceTotal(txt_InvNu.Text, Properties.Settings.Default.BranchId, Doc_Type.Text, txt_InvDate.Value.ToString("yy"));
           // DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp ");


           // string vat_no = dt_Co.Rows[0]["Comp_Vat_no"].ToString();
           // string Co_Name = dt_Co.Rows[0]["Company_e_name"].ToString();
           // string invDate = txt_InvDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
           // string TotalInv = dt_inv_total.Rows[0]["NetValue"].ToString().ToDecimal().ToString("N2");
           // string TotalTax = dt_inv_total.Rows[0]["tax"].ToString();

           // PictureBox pic_ = new PictureBox();
           // dal.pic1 = pic_;
           // dal.GetImsge(Co_Name, vat_no, invDate, TotalInv, TotalTax);

           // DataTable dQR = new DataTable();
           // using (MemoryStream ms = new MemoryStream())
           // {
           //     pic_.Image.Save(ms, ImageFormat.Bmp);

           //     byte[] byteImage = ms.ToArray();
           //     dQR.Columns.Add(new DataColumn("Barcode", typeof(byte[])));
           //     dQR.Rows.Add(byteImage);
           // }

            

           // ds.Tables.Add(dt_inv);
           // ds.Tables.Add(dQR);
           // ds.Tables.Add(dt_Co);
           //ds.WriteXmlSchema("schema_rpt.xml");

           // //if (printModel == "1")
           // //{
           //     RPT.Rpt_sales_Invoice_Portrait_total reportInv = new RPT.Rpt_sales_Invoice_Portrait_total();
           // reportInv.SetDataSource(ds);
           // //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
           // //reportInv.PrintToPrinter(1, false, 0, 15);
           // reportInv.DataDefinition.FormulaFields["decimal_"].Text = "'" + Properties.Settings.Default.digitNo_ + "'";
           // reportInv.DataDefinition.FormulaFields["Currency_"].Text = "'" + Properties.Settings.Default.Currency + "'";

           // //decimal balance_ = dt_inv_total.Rows[0]["NetValue"].ToString().ToDecimal();
           // //ToWord toWord = new ToWord(Math.Abs(Math.Round(balance_, dal.digits_)), currencies[currencyNo]);
           // //reportInv.DataDefinition.FormulaFields["Tafqeet"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
           // //reportInv.DataDefinition.FormulaFields["Tafqeet_E"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";



           // frminv.crystalReportViewer1.ReportSource = reportInv;
           //     frminv.ShowDialog();
           // //}

           // //else

           // //{
           // //    RPT.Rpt_sales_Invoice_3 reportInv = new RPT.Rpt_sales_Invoice_3();
           // //    reportInv.SetDataSource(dataSet);
           // //    //reportInv.PrintOptions.PrinterName = Properties.Settings.Default.Invoice_P;
           // //    //reportInv.PrintToPrinter(1, false, 0, 15);
           // //    frminv.crystalReportViewer1.ReportSource = reportInv;
           // //    frminv.ShowDialog();
           // //}




            base.Print();
        }

        public override void Search()
        {
            search_Inv(Doc_Type.Text);

            base.Search();
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

        private void AccSer_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Search_Cash_Click(object sender, EventArgs e)
        {
            search_Inv("XSC");
        }
        

        private void btn_Search_Credit_Click(object sender, EventArgs e)
        {
           

            if (rdoCash.Checked)
            {
                Get_Inv("XSC");
            }
            else if(rdoCredit.Checked)
            {
                Get_Inv("XSD");
                
            }
            else
            {
                Get_Inv("");
            }
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            go_next("XSC");
        }

        private void Go_frist(string _trans)
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='"+ _trans+"'  order by ser_no");
            Bnd1.DataSource = dtNaf;
            MyResult = dtNaf.Rows[0]["ser_no"].ToString();
            showInvoice(MyResult, _trans);
            IsNew = false;
            base.GoFrist();

        }

        private void go_previous (string _trans)
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "' order by ser_no");

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
            showInvoice(MyResult, _trans);
            IsNew = false;

        }

        private void go_next(string _trans)
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "' order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txt_InvNu.Text);
            if (RowNo < dtNaf.Rows.Count - 1 && RowNo != -1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[RowNo + 1]["ser_no"].ToString();
                showInvoice(MyResult, _trans);
            }


            IsNew = false;
        }

        private void go_last(string _trans)
        {

            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "'  order by ser_no");

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

            showInvoice(MyResult, _trans);
            IsNew = false;
        }

           



        private void next__Click(object sender, EventArgs e)
        {
            go_next("XSD");
        }

        private void last__Click(object sender, EventArgs e)
        {
            go_last("XSD");
        }

        private void previous__Click(object sender, EventArgs e)
        {
            go_previous("XSD");
        }

        private void first__Click_1(object sender, EventArgs e)
        {
            Go_frist("XSD");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Go_frist("XSC");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            go_previous("XSC");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            go_last("XSC");
        }

        private void AccType_Click(object sender, EventArgs e)
        {

        }

        private void headLbl_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void tabControlPanel4_Click(object sender, EventArgs e)
        {

        }

        public override void Save()
        {


            try
            {
                if (IsGridValid() == false)
                {
                    return;
                }



                if (txt_PayType.ID.Text.Trim()=="")
                {
                    MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToDecimal(invGrid1.txtNetTotal.Text) <= 0)
                {
                    MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_cyear.Text != Properties.Settings.Default.C_year)
                {
                    MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_Acc.ID.Text.Trim() == "")
                {
                    MessageBox.Show("فضلا.. تاكد من العميل", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Uc_Cost.ID.Text.Trim() == "")
                {
                    MessageBox.Show("فضلا.. تاكد من البائع", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (txtAcc2.ID.Text.Trim() == "" || txt_CashAcc.ID.Text.Trim() == "" || txt_vatAcc.ID.Text.Trim() == "" || txtCostOfSales.ID.Text.Trim() == "" || txtInventory.ID.Text.Trim() == "")
                {
                    MessageBox.Show("فضلا.. تاكد الحسابات الدائنة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                if (IsNew == true)
                {
                    //getSer();
                    add_wh_SaleOrder_inv_data();
                }
                //else
                //{
                //    Update_wh_SaleOrder_inv_data();
                //}

            }






            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;

            }


            base.Save();
        }

        private void getAccSer()
        {
            DataTable dt_AccSer = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) as main_daily_ser ,isnull(daily_sn_ser+1,1) as daily_sn_ser  from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchId
 + "' and ACC_YEAR= '" + acc_year.Text + "' ");//.PadLeft(4, '0');

            AccSer_No.Text = dt_AccSer.Rows[0]["main_daily_ser"].ToString();
            txtMainSer.Text = dt_AccSer.Rows[0]["daily_sn_ser"].ToString();
        }



        private void add_wh_SaleOrder_inv_data()
        {
            get_invSer();
            getAccSer();
            dal.open_1();
            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {
                cmd.CommandText = @"INSERT INTO wh_inv_data (Ser_no, Branch_code, Transaction_code, Cyear,Sanad_no, G_date, ACC_TYPE,
            Acc_no, Acc_Branch_code, Payment_Type, Sales_man_Id, User_id, Cash_costomer_name,
            Costomer_adress, Costomer_Phone, Costmer_fax, po_no, E_mail, TermsOfPaymentE, DelevryE, bankNo,
            K_M_ACC_NO, K_M_Credit_TAX, COSTMER_K_M_NO, KM_CODE_ACC, MAIN_KM_CODE, Inv_Notes, OPEN_VAT,
            VAT_RATIO,QUOT_REF_NO,QUOT_REF_DATE,SO_no,acc_serial_no,NetAmount,Inv_no,Inv_date)
            values('" + txt_InvNu.Text +
                "', '" + txtStore_ID.Text +
                "', '" + Doc_Type.Text +
                "', '" + txt_cyear.Text +
                "', '" + txt_sandNo.Text +
                "','" + txt_InvDate.Value.ToString("yyyy-MM-dd HH: mm:ss") +
                "', '" + AccType.Text +
                "', '" + txt_Acc.ID.Text +
                "', '" + txtBranch_Id.Text +
                "', '" + txt_PayType.ID.Text +
                "', '" + Uc_Cost.ID.Text +
                "',  '" + userID.Text +
                "', '" + txt_attn.Text +
                "', '" + txt_address.Text +
                "', '" + txt_custTel.Text +
                "', '" + txt_custFax.Text +
                "', '" +  Po_No.Text +
                "', '" + txt_CustEmail.Text +
                "', '" + Convert.ToString(PaymentTearms.SelectedValue) +
                "', '" + Convert.ToString(DelevryTearms.SelectedValue) +
                "', '" + Convert.ToString(txt_Bank.SelectedValue) +
                "', '" + txt_vatAcc.ID.Text +
                "', '" + invGrid1.txtTotalVAT.Text +
                "', '" + Cust_Vat_No.Text +
                "', '" + txtKmCode.Text +
                "', '" + Vat_Class.Text +
                "', '" + txt_InvNot.Text +
                "', '" + 0 +
                "', '" + Cust_Vat_Rate.Text +
                "','" + txt_Qutation.Text.ParseInt(0) +
                "','" + (dal.IsDateTime(txtQuotationDate.Text) ? txtQuotationDate.Text : "") +
                "', '"+ txtSoNo.Text.ParseInt(0)+
                "','"+ AccSer_No.Text+
                "','"+ invGrid1.txtNetTotal.Text+
                "', '"+txtInvNo.Text +
                "','"+txt_InvDate.Value.ToString("yyyy-MM-dd")+"')";
                cmd.ExecuteNonQuery();

                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                       && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                       && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                        )
                    {
                    cmd.CommandText = @" INSERT INTO wh_MATERIAL_TRANSACTION  (SER_NO, Branch_code, TRANSACTION_CODE, Cyear,SANAD_NO, ITEM_NO,QTY_ADD, QTY_TAKE,
                    Qty_Sales_Holding_balance,Qry_Purch_holding_balance,Return_Qty,COST_PRICE ,total_disc,DISC_R,DISC_R2,DISC_R3,G_DATE, Unit, Local_Price, USER_ID,
                    main_counter, balance, Backege, Pice_Total_Cost, DETAILS,TAX_IN,TAX_OUT, K_M_TYPE_ITEMS,DeleveryNote)
                    values ('" + txt_InvNu.Text +
                          "', '" + txtStore_ID.Text +
                          "', '" + Doc_Type.Text +
                          "', '" + txt_cyear.Text +
                          "', '" + 0 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + 0 +
                           "','"+ 0 + "' ,'" + 0 + "','" + 0 +
                           "', '" + invGrid1.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +

                         "','" + ((invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal()/ invGrid1.dgv1.Rows[i].Cells["_total"].FormattedValue.ToString().ToDecimal()  )  +  invGrid1.disc_Rate.Text.ToDecimal()) * 100 +
                         "' ,'" + (invGrid1.dgv1.Rows[i].Cells["_discount"].FormattedValue.ToString().ToDecimal() / invGrid1.dgv1.Rows[i].Cells["_total"].FormattedValue.ToString().ToDecimal()) * 100 + "' ,'0','" + (invGrid1.disc_Rate.Text.ToDecimal()) * 100 +
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
                          "', '" + 0 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].FormattedValue.ToString() + 
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_documentNo"].FormattedValue.ToString() + "') ";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"Update wh_inv_data_Delevry set Inv_no ='" + txt_InvNu.Text + "' ,Inv_date ='" + txt_InvDate.Value.ToString("yyyy-MM-dd") +
                            "'  where Ser_no='" + invGrid1.dgv1.Rows[i].Cells["_documentNo"].FormattedValue.ToString() +
                            "' and Cyear='" + txt_cyear.Text + "' and Branch_code='" + txtStore_ID.Text + "' and Transaction_code ='XVO'";
                        cmd.ExecuteNonQuery();
                    }
                }


                cmd.CommandText = @"Update wh_Serial set  " + Doc_Type.Text + " ='" + txt_InvNu.Text + "',XS='"+txt_sandNo.Text+"'  where Branch_code='" + txtStore_ID.Text
                     + "' and Cyear= '" + txt_cyear.Text + "' ";
                cmd.ExecuteNonQuery();

                if (Properties.Settings.Default.TRANS_TO_ACC == "A")
                {
                    string arabicDesc,englishDesc;
                    if (txt_PayType.ID.Text == "2")
                    {
                        
                        arabicDesc = "مرتجع مبيعات آجل رقم "+ txt_InvNu.Text + (Po_No.Text.Trim()!="" ? " طلب شراء " + Po_No.Text : "" );
                        englishDesc = "Credit Sales Returen No " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " PO " + Po_No.Text : "");
                    }
                    else
                    {
                        arabicDesc = "مرتجع مبيعات نقدي رقم " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " طلب شراء " + Po_No.Text : "");
                        englishDesc = "Cash Sales Returen No " + txt_InvNu.Text + (Po_No.Text.Trim() != "" ? " PO " + Po_No.Text : "");
                    }


                    string H_Date = date_.GregToHijri(txt_InvDate.Text);

                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txtAcc2.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + invGrid1.txtNetTotal.Text.ToDecimal() + "','" + 0 + "','" + invGrid1.txtNetTotal.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" +arabicDesc+ "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','"+ englishDesc  + "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txt_vatAcc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + invGrid1.txtTotalVAT.Text.ToDecimal() + "','" + 0 + "','" + invGrid1.txtTotalVAT.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + "ضريبة " + arabicDesc+ "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + "VAT " + englishDesc + "')";
                    cmd.ExecuteNonQuery();
                                        
                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txt_Acc.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + 0 + "','" + invGrid1.txtNetValue.Text + "','" +-invGrid1.txtNetValue.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" +arabicDesc+ "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + englishDesc+ "')";
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING, SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txtInventory.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + invGrid1.txtTotalCost.Text.ToDecimal() + "','" + 0 + "','" + invGrid1.txtTotalCost.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" + "تكلفة " + arabicDesc+ "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" + "Cost " + englishDesc+ "')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO daily_transaction ( ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh,
                    balance, h_date,g_date,sanad_no, SANAD_TYPE, sp_ser_no, user_name, desc2,POASTING,SOURCE_CODE, Wh_Branch_Code, MAIN_SER_NO,desc_E )
                    Values('" + acc_year.Text + "', '" + txtCostOfSales.ID.Text + "', '" + txtBranch_Id.Text + "','" + AccSer_No.Text + "','" +
                    Uc_Cost.ID.Text + "','" + 0 + "','" + invGrid1.txtTotalCost.Text + "','" + -invGrid1.txtTotalCost.Text.ToDecimal() + "','" + H_Date + "','" +
                    txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txt_InvNu.Text + "','" + Doc_Type.Text + "','" + Doc_Type.Text + txt_InvNu.Text + "','" +
                    userID.Text + "','" +"تكلفة "+ arabicDesc+ "','0','" + Doc_Type.Text + "','" +
                    txtStore_ID.Text + "','" + AccSer_No.Text + "','" +"Cost "+ englishDesc+ "')";
                    cmd.ExecuteNonQuery();



                    cmd.CommandText =  @"UPDATE serial_no SET main_daily_ser = '" + AccSer_No.Text + "', daily_sn_ser='"+txtMainSer.Text+"' WHERE BRANCH_CODE= '" + Properties.Settings.Default.BranchId + "' and ACC_YEAR='" + acc_year.Text + "' ";
                    cmd.ExecuteNonQuery();
                }



                trans.Commit();
                IsNew = false;
                MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);


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




    }
}


     