﻿using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Report_Pro.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Report_Pro.Classes.Master;

namespace Report_Pro.CTR
{
    public partial class frm_Bank_payment_voucher : frm_Master
    {

        string db1 = Properties.Settings.Default.Database_1;
        DAL.dbDataContext sdb = new DAL.dbDataContext();
        DAL.Sands_Detail SandDetail;
        DAL.Sands_tbl sands;
        DAL.serial_no serialNo;
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        int currencyNo = 2;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        //DAL.dbDataContext sdb = new DAL.dbDataContext();
        DataTable dt_db = new DataTable();
        DataTable dt_cr = new DataTable();
        DataTable dt_Bdata;

        public frm_Bank_payment_voucher()
        {
            InitializeComponent();

            dt_Bdata = dal.getDataTabl_1(@"select Costmers_acc_no,Bank_Cash_box,Cash_acc_no,Suppliers_acc_no,Expensive_Acc_no from wh_BRANCHES where Branch_code= '" + Properties.Settings.Default.BranchId + "' ");



            paied_amount.DicemalDigits = Properties.Settings.Default.digitNo_;
            txtFees.DicemalDigits = Properties.Settings.Default.digitNo_;
            txtFeesVat.DicemalDigits = Properties.Settings.Default.digitNo_;

            cmb_Pay.DataSource = dal.getDataTabl_1("SELECT * FROM pay_method where pay_ID in ('04','05')");
            if (Properties.Settings.Default.lungh == "0")
            {
                cmb_Pay.DisplayMember = "Pay_name";
            }
            else
            {
                cmb_Pay.DisplayMember = "Pay_name_E";
            }
            cmb_Pay.ValueMember = "Pay_ID";
            cmb_Pay.SelectedIndex = 0;


            New();
            RefreshData();
        }

        public override void RefreshData()
        {

            base.RefreshData();
        }



        public override void PreviewDeailyEntry(string _ser, string _branch, string _cyear)
        {
            base.PreviewDeailyEntry(AccSer_No.TextS, txtStore_ID.Text, acc_year.Text);
        }



        public override void Save()

        {

            //sanadValidity();

            if (paied_amount.Value <= 0)
            {
                MessageBox.Show("فضلا.. تاكد من مبلغ السند", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_Pay.SelectedIndex < 0)
            {
                MessageBox.Show("فضلا.. تاكد من طريقة السداد", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtFees.Value>0 && txtFeesAcc.ID.Text.Trim() == "") 
            {
                MessageBox.Show("فضلا.. تاكد من حساب المصاريف البنكية", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtFeesVat.Value > 0 && txtVatAcc.ID.Text.Trim() == "")
            {
                MessageBox.Show("فضلا.. تاكد من حساب الضريبة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Account.ID.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من الحساب ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CashAcc.ID.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من حساب النقدية / البنك ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Cost.ID.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من مركز التكلفة ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCust.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من اسم الحساب ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDescr.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من البيان ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsNew == true)
            {
                getJorSer();
                int JorSer;
                if (AccSer_No.TextS.Contains('M'))
                {
                    var Jor_ser = AccSer_No.TextS.Split('M');
                    JorSer = Convert.ToInt32(Jor_ser[1]);
                }

                else
                {
                    JorSer = Convert.ToInt32(AccSer_No.TextS);
                }


                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    DataGridViewRow DgRow = dgv2.Rows[i];
                    if (DgRow.Cells[0].Value != null && DgRow.Cells[8].Value != null)
                    {
                        var SandDetail = new DAL.Sands_Detail
                        {
                            ACC_YEAR = acc_year.Text,
                            BRANCH_code = txtStore_ID.Text,
                            ser_no = txt_sandNo.TextS,
                            SOURCE_CODE = "DB",
                            g_date = txt_sandDate.Value.Date,
                            Inv_No = Convert.ToInt32(DgRow.Cells[0].Value),
                            Inv_Date = Convert.ToDateTime(DgRow.Cells[2].Value),
                            Po_no = DgRow.Cells[3].Value.ToString(),
                            Inv_Amount = DgRow.Cells[4].Value.ToString().ToDecimal(),
                            Returened = DgRow.Cells[5].Value.ToString().ToDecimal(),
                            OldPaid = DgRow.Cells[6].Value.ToString().ToDecimal(),
                            OldBalance = DgRow.Cells[7].Value.ToString().ToDecimal(),
                            CurrentPaid = DgRow.Cells[8].Value.ToString().ToDecimal(),
                            NewBalance = DgRow.Cells[9].Value.ToString().ToDecimal(),
                            main_counter = DgRow.Index,
                            Inv_Transaction_Code = DgRow.Cells[11].Value.ToString(),
                            cyear = DgRow.Cells[1].Value.ToString(),
                            totalPaid = DgRow.Cells[10].Value.ToString().ToDecimal(),
                        };

                        sdb.Sands_Details.InsertOnSubmit(SandDetail);



                        //}
                        //else
                        //{
                        //    sdb.Sands_Details.DeleteAllOnSubmit(sdb.Sands_Details.Where(x => x.ser_no == txt_sandNo.TextS && x.ACC_YEAR == acc_year.Text && x.BRANCH_code == txtStore_ID.Text && x.SOURCE_CODE == txt_source_code.Text));
                        //    sdb.Sands_Details.InsertOnSubmit(SandDetail);
                        //}


                    }

                }





                sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                {
                    ACC_YEAR = acc_year.Text,
                    ACC_NO = Account.ID.Text,
                    // ACC_NO = CashAcc.ID.Text,
                    BRANCH_code = txtStore_ID.Text,
                    ser_no = AccSer_No.TextS,
                    COST_CENTER = Cost.ID.Text,
                    meno = paied_amount.Value,
                    loh = 0,
                    balance = paied_amount.Value,
                    g_date = txt_sandDate.Value.Date,
                    sanad_no = txt_sandNo.TextS,
                    user_name = Program.userID,
                    desc2 = txtDescr.Text + " - سند صرف رقم " + txt_sandNo.TextS,
                    POASTING = false,
                    CAT_CODE = "1",
                    MAIN_SER_NO = JorSer,
                    Wh_Branch_Code = txtStore_ID.Text,
                    SANAD_TYPE = Payment_Type.Text,
                    SANAD_TYPE2 = txt_sanad_type2.Text,
                    desc_E = txtDescr_E.Text + " - Payment voucher No. " + txt_sandNo.TextS,
                    SOURCE_CODE = txt_source_code.Text,
                    sheek_or_cash = cheuqeOrCash.Text,
                    Sheek = cmb_Pay.Text,
                    payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                    sp_ser_no = txtSpecialNo.Text,
                    sheek_no = txt_Check.Text,
                    sheek_bank = CustBank.Desc.Text,
                    sheek_date = dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                    notes = txtCust.Text,
                    shequeBank_no = CustBank.ID.Text,

                });



                if (txtFees.Value > 0)
                {

                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = txtFeesAcc.ID.Text,
                        // ACC_NO = CashAcc.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = txtFees.Value,
                        loh = 0,
                        balance = paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "رسوم " + txtDescr.Text + " - سند صرف رقم " + txt_sandNo.TextS,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = txtDescr_E.Text + " - Payment voucher No. " + txt_sandNo.TextS,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,

                    });


                }


                if (txtFeesVat.Value > 0)
                {

                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = txtVatAcc.ID.Text,
                        // ACC_NO = CashAcc.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = txtFeesVat.Value,
                        loh = 0,
                        balance = paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "ضريبة رسوم " + txtDescr.Text + " - سند صرف رقم " + txt_sandNo.TextS,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = txtDescr_E.Text + " - Payment voucher No. " + txt_sandNo.TextS,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,

                    });
                }


                sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                {
                    ACC_YEAR = acc_year.Text,
                    ACC_NO = CashAcc.ID.Text,
                    // ACC_NO = Account.ID.Text,
                    BRANCH_code = txtStore_ID.Text,
                    ser_no = AccSer_No.TextS,
                    COST_CENTER = Cost.ID.Text,
                    meno = 0,
                    loh = paied_amount.Value,
                    balance = -paied_amount.Value,
                    g_date = txt_sandDate.Value.Date,
                    sanad_no = txt_sandNo.TextS,
                    user_name = Program.userID,
                    desc2 = txtDescr.Text + " - سند صرف رقم " + txt_sandNo.TextS,
                    POASTING = false,
                    CAT_CODE = "1",
                    MAIN_SER_NO = JorSer,
                    Wh_Branch_Code = txtStore_ID.Text,
                    SANAD_TYPE = Payment_Type.Text,
                    SANAD_TYPE2 = txt_sanad_type2.Text,
                    desc_E = txtDescr_E.Text + " - Payment voucher No. " + txt_sandNo.TextS,
                    SOURCE_CODE = txt_source_code.Text,
                    sheek_or_cash = cheuqeOrCash.Text,
                    Sheek = cmb_Pay.Text,
                    payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                    sp_ser_no = txtSpecialNo.Text,
                    sheek_no = txt_Check.Text,
                    sheek_bank = CustBank.Desc.Text,
                    sheek_date = /*cheuqeOrCash.Text == "S" */dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                    notes = txtCust.Text,
                    shequeBank_no = CustBank.ID.Text,
                });


                if (txtFees.Value > 0)
                {
                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = CashAcc.ID.Text,
                        // ACC_NO = Account.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = 0,
                        loh = txtFees.Value,
                        balance = -paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "رسوم " + txtDescr.Text + " - سند صرف رقم " + txt_sandNo.TextS,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = txtDescr_E.Text + " - Payment voucher No. " + txt_sandNo.TextS,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = /*cheuqeOrCash.Text == "S" */dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,
                    });

                }


                if (txtFeesVat.Value > 0)
                {
                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = CashAcc.ID.Text,
                        // ACC_NO = Account.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = 0,
                        loh = txtFeesVat.Value,
                        balance = -paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "ضريبة رسوم " + txtDescr.Text + " - سند صرف رقم " + txt_sandNo.TextS,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = txtDescr_E.Text + " - Payment voucher No. " + txt_sandNo.TextS,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = /*cheuqeOrCash.Text == "S" */dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,
                    });

                }

                sdb.serial_nos.Where(p => p.ACC_YEAR == acc_year.Text && p.BRANCH_CODE == txtStore_ID.Text)
               .ToList().ForEach(x =>
               {
                   x.daily_sn_ser = Convert.ToInt32(txt_sandNo.TextS);
                   x.main_daily_ser = JorSer;
                   x.HEWALA_sarf_ser = Convert.ToInt32(txt_sandNo.TextS);
               });


            }
            //========================== edit sanad ========================
            else
            {
                int JorSer;
                if (AccSer_No.TextS.Contains('M'))
                {
                    var Jor_ser = AccSer_No.TextS.Split('M');
                    JorSer = Convert.ToInt32(Jor_ser[1]);
                }

                else
                {
                    JorSer = Convert.ToInt32(AccSer_No.TextS);
                }

                sdb.Sands_Details.DeleteAllOnSubmit(sdb.Sands_Details.Where(x => x.ser_no == txt_sandNo.TextS && x.ACC_YEAR == acc_year.Text && x.BRANCH_code == txtStore_ID.Text && x.SOURCE_CODE == txt_source_code.Text));

                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    DataGridViewRow DgRow = dgv2.Rows[i];
                    if (DgRow.Cells[0].Value != null && DgRow.Cells[8].Value != null)
                    {
                        var SandDetail = new DAL.Sands_Detail
                        {
                            ACC_YEAR = acc_year.Text,
                            BRANCH_code = txtStore_ID.Text,
                            ser_no = txt_sandNo.TextS,
                            SOURCE_CODE = txt_source_code.Text,
                            g_date = txt_sandDate.Value.Date,
                            Inv_No = Convert.ToInt32(DgRow.Cells[0].Value),
                            Inv_Date = Convert.ToDateTime(DgRow.Cells[2].Value),
                            Po_no = DgRow.Cells[3].Value.ToString(),
                            Inv_Amount = DgRow.Cells[4].Value.ToString().ToDecimal(),
                            Returened = DgRow.Cells[5].Value.ToString().ToDecimal(),
                            OldPaid = DgRow.Cells[6].Value.ToString().ToDecimal(),
                            OldBalance = DgRow.Cells[7].Value.ToString().ToDecimal(),
                            CurrentPaid = DgRow.Cells[8].Value.ToString().ToDecimal(),
                            NewBalance = DgRow.Cells[9].Value.ToString().ToDecimal(),
                            main_counter = DgRow.Index,
                            Inv_Transaction_Code = DgRow.Cells[11].Value.ToString(),
                            cyear = DgRow.Cells[1].Value.ToString(),
                            totalPaid = DgRow.Cells[10].Value.ToString().ToDecimal(),
                        };

                        sdb.Sands_Details.InsertOnSubmit(SandDetail);
                    }

                }


                    sdb.daily_transactions.DeleteAllOnSubmit(sdb.daily_transactions.Where(x => x.ser_no == AccSer_No.TextS && x.BRANCH_code == txtStore_ID.Text));
                sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                {
                    ACC_YEAR = acc_year.Text,
                    ACC_NO = Account.ID.Text,
                    // ACC_NO = CashAcc.ID.Text,
                    BRANCH_code = txtStore_ID.Text,
                    ser_no = AccSer_No.TextS,
                    COST_CENTER = Cost.ID.Text,
                    meno = paied_amount.Value,
                    loh = 0,
                    balance = paied_amount.Value,
                    g_date = txt_sandDate.Value.Date,
                    sanad_no = txt_sandNo.TextS,
                    user_name = Program.userID,
                    desc2 = txtDescr.Text /*+ " - سند صرف رقم " + txt_sandNo.TextS*/,
                    POASTING = false,
                    CAT_CODE = "1",
                    MAIN_SER_NO = JorSer,
                    Wh_Branch_Code = txtStore_ID.Text,
                    SANAD_TYPE = Payment_Type.Text,
                    SANAD_TYPE2 = txt_sanad_type2.Text,
                    desc_E = txtDescr_E.Text /*+ " - Payment voucher No. " + txt_sandNo.TextS*/,
                    SOURCE_CODE = txt_source_code.Text,
                    sheek_or_cash = cheuqeOrCash.Text,
                    Sheek = cmb_Pay.Text,
                    payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                    sp_ser_no = txtSpecialNo.Text,
                    sheek_no = txt_Check.Text,
                    sheek_bank = CustBank.Desc.Text,
                    sheek_date = dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                    notes = txtCust.Text,
                    shequeBank_no = CustBank.ID.Text,

                });



                if (txtFees.Value > 0)
                {

                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = txtFeesAcc.ID.Text,
                        // ACC_NO = CashAcc.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = txtFees.Value,
                        loh = 0,
                        balance = paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "رسوم " + txtDescr.Text /*+ " - سند صرف رقم " + txt_sandNo.TextS*/,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = "Fees "+ txtDescr_E.Text /*+ " - Payment voucher No. " + txt_sandNo.TextS*/,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,

                    });


                }


                if (txtFeesVat.Value > 0)
                {

                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = txtVatAcc.ID.Text,
                        // ACC_NO = CashAcc.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = txtFeesVat.Value,
                        loh = 0,
                        balance = paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "ضريبة رسوم " + txtDescr.Text /*+ " - سند صرف رقم " + txt_sandNo.TextS*/,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = "Fees VAT "+txtDescr_E.Text /*+ " - Payment voucher No. " + txt_sandNo.TextS*/,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,

                    });
                }


                sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                {
                    ACC_YEAR = acc_year.Text,
                    ACC_NO = CashAcc.ID.Text,
                    // ACC_NO = Account.ID.Text,
                    BRANCH_code = txtStore_ID.Text,
                    ser_no = AccSer_No.TextS,
                    COST_CENTER = Cost.ID.Text,
                    meno = 0,
                    loh = paied_amount.Value,
                    balance = -paied_amount.Value,
                    g_date = txt_sandDate.Value.Date,
                    sanad_no = txt_sandNo.TextS,
                    user_name = Program.userID,
                    desc2 = txtDescr.Text /*+ " - سند صرف رقم " + txt_sandNo.TextS*/,
                    POASTING = false,
                    CAT_CODE = "1",
                    MAIN_SER_NO = JorSer,
                    Wh_Branch_Code = txtStore_ID.Text,
                    SANAD_TYPE = Payment_Type.Text,
                    SANAD_TYPE2 = txt_sanad_type2.Text,
                    desc_E = txtDescr_E.Text /*+ " - Payment voucher No. " + txt_sandNo.TextS*/,
                    SOURCE_CODE = txt_source_code.Text,
                    sheek_or_cash = cheuqeOrCash.Text,
                    Sheek = cmb_Pay.Text,
                    payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                    sp_ser_no = txtSpecialNo.Text,
                    sheek_no = txt_Check.Text,
                    sheek_bank = CustBank.Desc.Text,
                    sheek_date = /*cheuqeOrCash.Text == "S" */dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                    notes = txtCust.Text,
                    shequeBank_no = CustBank.ID.Text,
                });


                if (txtFees.Value > 0)
                {
                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = CashAcc.ID.Text,
                        // ACC_NO = Account.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = 0,
                        loh = txtFees.Value,
                        balance = -paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "رسوم " + txtDescr.Text /*+ " - سند صرف رقم " + txt_sandNo.TextS*/,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = "Fees " + txtDescr_E.Text /*+ " - Payment voucher No. " + txt_sandNo.TextS*/,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = /*cheuqeOrCash.Text == "S" */dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,
                    });

                }


                if (txtFeesVat.Value > 0)
                {
                    sdb.daily_transactions.InsertOnSubmit(new DAL.daily_transaction() // Part
                    {
                        ACC_YEAR = acc_year.Text,
                        ACC_NO = CashAcc.ID.Text,
                        // ACC_NO = Account.ID.Text,
                        BRANCH_code = txtStore_ID.Text,
                        ser_no = AccSer_No.TextS,
                        COST_CENTER = Cost.ID.Text,
                        meno = 0,
                        loh = txtFeesVat.Value,
                        balance = -paied_amount.Value,
                        g_date = txt_sandDate.Value.Date,
                        sanad_no = txt_sandNo.TextS,
                        user_name = Program.userID,
                        desc2 = "ضريبة رسوم " + txtDescr.Text /*+ " - سند صرف رقم " + txt_sandNo.TextS*/,
                        POASTING = false,
                        CAT_CODE = "1",
                        MAIN_SER_NO = JorSer,
                        Wh_Branch_Code = txtStore_ID.Text,
                        SANAD_TYPE = Payment_Type.Text,
                        SANAD_TYPE2 = txt_sanad_type2.Text,
                        desc_E = "Fees VAT " + txtDescr_E.Text /*+ " - Payment voucher No. " + txt_sandNo.TextS*/,
                        SOURCE_CODE = txt_source_code.Text,
                        sheek_or_cash = cheuqeOrCash.Text,
                        Sheek = cmb_Pay.Text,
                        payType_No = Convert.ToString(cmb_Pay.SelectedValue),
                        sp_ser_no = txtSpecialNo.Text,
                        sheek_no = txt_Check.Text,
                        sheek_bank = CustBank.Desc.Text,
                        sheek_date = /*cheuqeOrCash.Text == "S" */dal.IsDateTime(Check_Date.Text.ToString()) ? Check_Date.Value.Date : (DateTime)System.Data.SqlTypes.SqlDateTime.Null,
                        notes = txtCust.Text,
                        shequeBank_no = CustBank.ID.Text,
                    });

                }
            }



                sdb.SubmitChanges();
            IsNew = false;
            MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

            base.Save();
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        void LoadSanad(string SanadNo, string SanadYear, string SanadBranch, string SanadSource)
        {
            dgv2.Rows.Clear();
            //using (var db = new DAL.dbDataContext())
            //{
            var _sandDetail = (from d in sdb.Sands_Details.Where(x => x.ser_no == SanadNo && x.ACC_YEAR == SanadYear && x.BRANCH_code == SanadBranch && x.SOURCE_CODE == SanadSource)
                               select new
                               {
                                   d.Inv_No,
                                   d.ACC_YEAR,
                                   d.Inv_Date,
                                   d.Po_no,
                                   d.Inv_Amount,
                                   d.Returened,
                                   d.OldPaid,
                                   d.OldBalance,
                                   d.CurrentPaid,
                                   d.NewBalance,
                                   d.Inv_Transaction_Code,
                                   d.cyear,
                                   d.totalPaid,
                               }).ToList();

            //from d in db.InvoiceDetails.Where(x => x.InoiceID == inv.ID)

            DataTable dt = ToDataTable(_sandDetail);



            if (dt.Rows.Count == 0)
                return;

            foreach (DataRow row in dt.Rows)
            {
                DataGridViewRow dgvr = dgv2.Rows[dgv2.Rows.Add()];
                dgvr.Cells[col_invNo.Index].Value = row["Inv_No"];
                dgvr.Cells[col_year.Index].Value = row["cyear"];
                dgvr.Cells[col_invDate.Index].Value = row["Inv_Date"];
                dgvr.Cells[col_poNo.Index].Value = row["Po_no"];
                dgvr.Cells[col_invAmount.Index].Value = row["Inv_Amount"];
                dgvr.Cells[col_retruned.Index].Value = row["Returened"];
                dgvr.Cells[col_oldPaid.Index].Value = row["OldPaid"];
                dgvr.Cells[col_oldBalance.Index].Value = row["OldBalance"];
                dgvr.Cells[col_currentPaid.Index].Value = row["CurrentPaid"];
                dgvr.Cells[col_newBalance.Index].Value = row["NewBalance"];
                dgvr.Cells[col_transactionCode.Index].Value = row["Inv_Transaction_Code"];
                dgvr.Cells[col_sanadBalance.Index].Value = row["totalPaid"];


            }


            GetData();
        }




        public override void SetData()
        {


            //DailyTransaction.ACC_YEAR = acc_year.Text;
            //DailyTransaction.ACC_NO = CashAcc.ID.Text;
            //DailyTransaction.BRANCH_code = txtStore_ID.Text;
            //DailyTransaction.ser_no = AccSer_No.TextS;
            //DailyTransaction.COST_CENTER = Cost.ID.Text;
            //DailyTransaction.meno = paied_amount.Value;
            //DailyTransaction.loh = 0;
            //DailyTransaction.balance = paied_amount.Value;
            //DailyTransaction.g_date = txt_sandDate.Value.Date;
            //DailyTransaction.sanad_no = txt_sandNo.TextS;
            //DailyTransaction.user_name = Program.userID;
            //DailyTransaction.desc2 = txtDescr.Text;
            //DailyTransaction.POASTING = false;
            //DailyTransaction.CAT_CODE = "1";
            //DailyTransaction.MAIN_SER_NO = JorSer;
            //DailyTransaction.Wh_Branch_Code = txtStore_ID.Text;
            //DailyTransaction.SANAD_TYPE2 = txt_sanad_type2.Text;
            //DailyTransaction.desc_E = txtDescr_E.Text;
            //DailyTransaction.SOURCE_CODE = txt_source_code.Text;
            //DailyTransaction.sheek_or_cash = cheuqeOrCash.Text;
            //DailyTransaction.Sheek = Convert.ToString(cmb_Pay.SelectedValue);
            //DailyTransaction.sp_ser_no = txt_source_code.Text;
            //DailyTransaction.sheek_no = txt_Check.Text;
            //DailyTransaction.sheek_bank = Convert.ToString(cmb_Bank.SelectedValue);
            //DailyTransaction.sheek_date = Check_Date.Value.Date;
            //DailyTransaction.notes = txtCust.Text;



















            base.SetData();
        }

        public override void GetData()
        {

            //  acc_year.Text = sands.ACC_YEAR      ; 
            //  CashAcc.ID.Text= sands.ACC_NO           ; 
            //  txtStore_ID.Text= sands.BRANCH_code      ; 
            //  txt_sandNo.TextS= sands.ser_no          ; 
            //  Cost.ID.Text= sands.COST_CENTER      ; 
            //  paied_amount.Value= sands.loh.ToString().ToDecimal()             ;
            //// txt_sandDate.Text = sands.g_date.Value.ToString() == "" ? DateTime.Today.ToString() : sands.g_date.Value.ToString();
            ////  AccSer_No.TextS= sands.acc_serial_no    ; 
            //  Program.userID= sands.user_name        ; 
            //  txtDescr.Text= sands.desc2            ; 
            //  txtStore_ID.Text= sands.Wh_Branch_Code   ; 
            //  Payment_Type.Text= sands.SANAD_TYPE       ; 
            //  txtDescr_E.Text= sands.desc_E           ; 
            //  txt_source_code.Text= sands.SOURCE_CODE      ; 
            //  cheuqeOrCash.Text= sands.sheek_or_cash    ; 
            //  txt_Check.Text= sands.sheek_no         ; 
            //  glkp_bank.Text= sands.sheek_bank       ; 
            //  Check_Date.Value   =     sands.sheek_date.Value       ;  
            //  txtCust.Text= sands.CashCust_name    ; 






            base.GetData();
        }


        public override void New()
        {
            btnSearch.Enabled = false;
            ClearTextBoxes();

            txt_sandDate.Value = DateTime.Today;
            acc_year.Text = "cy";
            Payment_Type.Text = "2";
            user_id.Text = Program.userID;
            txtStore_ID.Text = Properties.Settings.Default.BranchAccID;
            txt_source_code.Text = "SH";
            txt_sanad_type2.Text = "BP";
            Account.txtFinal.Text = "1";
            cheuqeOrCash.Text = "S";
            //Account.txtMainAcc.Text = dt_Bdata.Rows[0]["Expensive_Acc_no"].ToString();
            //Account.ID.Text = dt_Bdata.Rows[0]["Expensive_Acc_no"].ToString();

            // CashAcc.ID.Text = dt_Bdata.Rows[0]["Cash_acc_no"].ToString();
            CashAcc.txtMainAcc.Text = dt_Bdata.Rows[0]["Bank_Cash_box"].ToString();
            CashAcc.txtFinal.Text = "1";
            Account.branchID.Text = Properties.Settings.Default.BranchAccID.ToString();
            CashAcc.branchID.Text = Properties.Settings.Default.BranchAccID.ToString();


            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            getJorSer();
            sands = new DAL.Sands_tbl();
            base.New();
        }


        private void frm_recet_Load(object sender, EventArgs e)
        {


            //New();

            btnPrint.Visible = true;
            btnStatment.Visible = true; ;
            btnPreviewDaliyEntry.Visible = true;
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

        private void BSave_Click(object sender, EventArgs e)
        {
            sanadValidity();
            Add_Jor();


        }

        private void sanadValidity()
        {

            if (paied_amount.Value <= 0)
            {
                MessageBox.Show("فضلا.. تاكد من مبلغ السند", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_Pay.SelectedIndex < 0)
            {
                MessageBox.Show("فضلا.. تاكد من طريقة السداد", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (Account.ID.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من الحساب ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CashAcc.ID.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من حساب النقدية / البنك ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Cost.ID.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من مركز التكلفة ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCust.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من اسم العميل ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDescr.Text == "")
            {
                MessageBox.Show("فضلا.. تاكد من البيان ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }



        private void Add_sands()
        {
            //getJorSer();
            //dal.Execute_1(@"Insert into Sands_tbl values( '" + acc_year.Text + "', '" + Account.ID.Text + "','"
            // + txtStore_ID.Text + "', '" + txt_sandNo.TextS + "','" + Cost.ID.Text + "',0, '" + paied_amount.Text + "','" + txt_sandDate.Value.Date.ToString("yyyy/MM/dd")
            //+ "' , '" + AccSer_No.TextS + "','" + Payment_Type.Text + "','" + user_id.Text + "','"+ txtDescr.Text + "', '" + txt_Check.Text + "' ,'" +
            //Convert.ToString(cmb_Bank.SelectedValue) + "','" + (Check_Date.Value > Check_Date.MinDate ? Check_Date.Value.Date.ToString("yyyy/MM/dd") : Check_Date.MinDate.Date.ToString("yyyy/MM/dd"))
            //+ "','" + Convert.ToString(cmb_Pay.SelectedValue) + "','','','"+ txt_source_code.Text+"','" + txtStore_ID.Text 
            //+ "','','" + CashAcc.ID.Text + "','','" + paied_amount.Text + "','"+ txtCust.Text +"','','','','','','','','','','','','','')");


            //dal.Execute_1(@"UPDATE serial_no SET BOX_ED_SER='" + txt_sandNo.TextS + "' WHERE BRANCH_CODE=  '" + txtStore_ID.Text + "' and ACC_YEAR='" + acc_year.Text + "' ");


        }

        private void Add_Jor()
        {
            ////string cyear = txt_InvDate.Value.Year.ToString();
            //string H_Date;
            //// DataTable dtCurrntdate_ =  dal.getDataTabl("convertdate_G", txt_sandDate.Value);
            //H_Date = dal.convertToHijri(txt_sandDate.Value.ToString());
            ////this.AccSer_No.TextS = dal.getDataTabl("get_ser", Properties.Settings.Default.BranchId, txt_InvDate.Value.Year.ToString(), "ENT").Rows[0][0].ToString().PadLeft(4, '0');

            ////==================////=============================////==============


            //int JorSer;
            //if (AccSer_No.TextS.Contains('M'))
            //{
            //    var Jor_ser = AccSer_No.TextS.Split('M');
            //    JorSer = Convert.ToInt32(Jor_ser[1]);
            //}

            //else
            //{
            //    JorSer = Convert.ToInt32(AccSer_No.TextS);
            //}


            //if (dal.sqlconn_1.State == ConnectionState.Closed)
            //{
            //    dal.sqlconn_1.Open();
            //}
            //SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            //SqlTransaction trans;
            //trans = dal.sqlconn_1.BeginTransaction();
            //cmd.Connection = dal.sqlconn_1;
            //cmd.Transaction = trans;


            //try
            //{

            //    cmd.CommandText = @"INSERT INTO daily_transaction(ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh
            //        , balance, g_date, sanad_no, SANAD_TYPE, user_name, desc2, POASTING, CAT_CODE, MAIN_SER_NO,Wh_Branch_Code
            //        ,SANAD_TYPE2,desc_E,SOURCE_CODE,sheek_or_cash,Sheek,sp_ser_no,sheek_no,sheek_bank,sheek_date,notes)
            //        VALUES('" + acc_year.Text + "','" + CashAcc.ID.Text + "','" + txtStore_ID.Text + "','" +
            //        AccSer_No.TextS + "','"+Cost.ID.Text+"','" + paied_amount.Value + "','0','" + paied_amount.Value + "','" + txt_sandDate.Value.ToString("yyyy/MM/dd HH:mm:ss") +
            //        "','" + txt_sandNo.TextS + "','2','" + Program.userID + "','" + txtDescr.Text + "','0','1','" + JorSer + "','"+txtStore_ID.Text+"','"+ 
            //        txt_sanad_type2.Text+ "','"+txtDescr_E.Text+ "','" + txt_source_code.Text + "','"+cheuqeOrCash.Text+"','"+ 
            //        Convert.ToString(cmb_Pay.SelectedValue)+"','"+ txt_source_code.Text + "','"+txt_Check.Text+"','"+ 
            //        Convert.ToString(cmb_Bank.SelectedValue)+ "',   '" + (Check_Date.Value.ToString("yyyy/MM/dd") == null ? string.Empty : Check_Date.Value.ToString("yyyy/MM/dd")) + "','" + txtCust.Text + "')";
            //    cmd.ExecuteNonQuery();



            //    cmd.CommandText = @"INSERT INTO daily_transaction(ACC_YEAR, ACC_NO, BRANCH_code, ser_no, COST_CENTER, meno, loh
            //        , balance, g_date, sanad_no, SANAD_TYPE, user_name, desc2, POASTING, CAT_CODE, MAIN_SER_NO,Wh_Branch_Code
            //        ,SANAD_TYPE2,desc_E,SOURCE_CODE,sheek_or_cash,Sheek,sp_ser_no,sheek_no,sheek_bank,sheek_date,notes)
            //        VALUES('" + acc_year.Text + "','" + Account.ID.Text + "','" + txtStore_ID.Text + "','" +
            //        AccSer_No.TextS + "','"+Cost.ID.Text+"','0','" + paied_amount.Value + "','" + -paied_amount.Value + "','" + txt_sandDate.Value.ToString("yyyy/MM/dd HH:mm:ss") +
            //        "','" + txt_sandNo.TextS + "','2','" + Program.userID + "','" + txtDescr.Text + "','0','1','" + JorSer + "','" + txtStore_ID.Text + "','" + 
            //        txt_sanad_type2.Text + "','" + txtDescr_E.Text + "','"+ txt_source_code.Text+ "','" + cheuqeOrCash.Text + "','" + 
            //        Convert.ToString(cmb_Pay.SelectedValue) + "','" + txt_source_code.Text + "','" + txt_Check.Text + "','" + 
            //        Convert.ToString(cmb_Bank.SelectedValue) + "',  '" + (Check_Date.Value.ToString("yyyy/MM/dd") == null? string.Empty : Check_Date.Value.ToString("yyyy/MM/dd")) + "','" + txtCust.Text+"')";
            //    cmd.ExecuteNonQuery();


            //    for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
            //    {
            //        DataGridViewRow DgRow = dgv2.Rows[i];
            //        if (DgRow.Cells[0].Value != null && DgRow.Cells[8].Value != null)
            //        {
            //            cmd.CommandText = @"INSERT INTO Sands_Details(ACC_YEAR,BRANCH_code,ser_no,SOURCE_CODE,g_date,Inv_No
            //            ,Inv_Date,Po_no,Inv_Amount,Returened,OldPaid,OldBalance,CurrentPaid,NewBalance,main_counter,Inv_Transaction_Code)
            //            Values ('" + acc_year.Text + "','" + txtStore_ID.Text + "','" + txt_sandNo.TextS + "', '" +
            //            txt_source_code.Text + "','" + txt_sandDate.Value.ToString("yyyy/MM/dd HH: mm:ss") + "','" + DgRow.Cells[0].Value + "','" +
            //            (Convert.ToDateTime(DgRow.Cells[2].Value)).ToString("yyyy/MM/dd HH: mm:ss") + "','" + DgRow.Cells[3].Value + "','" + DgRow.Cells[4].Value + "','" + DgRow.Cells[5].Value + "','" +
            //            DgRow.Cells[6].Value + "','" + DgRow.Cells[7].Value + "','" + DgRow.Cells[8].Value + "','" + DgRow.Cells[9].Value + "','" + 
            //            DgRow.Index + "','" + DgRow.Cells[11].Value + "')";

            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"update wh_inv_data 
            //                set PanyedAmount = '" + DgRow.Cells[8].Value +
            //                "' where  Ser_no = '"+DgRow.Cells[0].Value + 
            //                "' and Branch_code = '"+txtStore_ID.Text + 
            //                "' and Transaction_code = '"+DgRow.Cells[11].Value + 
            //                "' and Cyear='" + DgRow.Cells[1].Value+"' ";
            //            cmd.ExecuteNonQuery();

            //        }
            //    }


            //    cmd.CommandText = @"UPDATE serial_no SET daily_sn_ser='" + txt_sandNo.TextS + "' , main_daily_ser = '" + JorSer + "',BOX_ED_SER='" + txt_sandNo.TextS + "' WHERE BRANCH_CODE=  '" + txtStore_ID.Text + "' and ACC_YEAR='" + acc_year.Text + "' ";
            //    cmd.ExecuteNonQuery();


            //    trans.Commit();
            //    BSave.Enabled = false;
            //    MessageBox.Show("تم الحفظ بنجاح", "حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //}
            //catch (Exception ex)
            //{


            //    trans.Rollback();
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    dal.sqlconn_1.Close();
            //}



        }

        //        //---
        //        // UpdateJor();

        //    }














        //    //=====================///====================///===========

        //    //     }




        //    dal.Execute("Add_daily_transaction",
        //    acc_year.Text,
        //    CashAcc.ID.Text,
        //    txtStore_ID.Text,
        //    AccSer_No.TextS,
        //    "",
        //    "",
        //    "",
        //    paied_amount.Text,
        //    0,
        //    paied_amount.Text,
        //    H_Date,
        //    txt_sandDate.Value,
        //    txt_sandNo.TextS,
        //    txt_source_code.Text,
        //    txt_source_code.Text + txt_sandNo.TextS,
        //    user_id.Text,
        //    txtDescr.Text,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    String.Empty, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //   txt_source_code.Text, txtStore_ID.Text, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, '0', DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    txtCust.Text, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //    DBNull.Value, DBNull.Value, DBNull.Value, AccSer_No.TextS);

        //    dal.Execute("Add_daily_transaction",
        // acc_year.Text,
        // Account.ID.Text,
        // txtStore_ID.Text,
        // AccSer_No.TextS,
        // "",
        // "",
        // "",
        // 0,
        // paied_amount.Value,
        // -paied_amount.Value,
        // H_Date,
        // txt_sandDate.Value,
        // txt_sandNo.TextS,
        // txt_source_code.Text,
        // txt_source_code.Text + txt_sandNo.TextS,
        // user_id.Text,
        // txtDescr.Text,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // String.Empty, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        //txt_source_code.Text, txtStore_ID.Text, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, '0', DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // txtCust.Text, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
        // DBNull.Value, DBNull.Value, DBNull.Value, AccSer_No.TextS);

        //   dal.Execute_1(@"UPDATE serial_no SET daily_sn_ser='" + txt_sandNo.TextS + "' , main_daily_ser = '" + AccSer_No + "' WHERE BRANCH_CODE=  '" + txtStore_ID.Text + "' and ACC_YEAR='" + acc_year.Text + "' ");

        //}


        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_Pay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CashAcc.ID.Clear();
            //if (Convert.ToString(cmb_Pay.SelectedValue) == "04")
            //{
            //    txt_Check.Enabled = true;
            //    CustBank.Enabled = true;
            //    Check_Date.Enabled = true;
            //    cheuqeOrCash.Text = "S";
            //    txt_sanad_type2.Text = "BP";
            //    txt_source_code.Text = "SH";
            //    CashAcc.Enabled = true;
            //    CashAcc.txtMainAcc.Text = dt_Bdata.Rows[0]["Bank_Cash_box"].ToString();
            //}
            //else if (Convert.ToString(cmb_Pay.SelectedValue) == "05")
            //{
            //    txt_Check.Enabled = false;
            //    CustBank.Enabled = false;
            //    Check_Date.Enabled = false;
            //    cheuqeOrCash.Text = "S";
            //    txt_sanad_type2.Text = "BP";
            //    txt_source_code.Text = "SH";
            //    txt_Check.Clear();
            //    CustBank.ID.Text = "";
            //    CustBank.Desc.Text = "";
            //    Check_Date.Text = "";
            //    CashAcc.Enabled = true;
            //    CashAcc.txtMainAcc.Text = dt_Bdata.Rows[0]["Bank_Cash_box"].ToString();

            //}
            
            //getJorSer();
        }

        private void txtAcc_Load(object sender, EventArgs e)
        {

        }














        private void print_sand_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (Properties.Settings.Default.lungh == "0")
            {

                Form1 frmSand = new Form1();
                CrystalReport5 rpt = new CrystalReport5();
                DataTable dt1 = new DataTable();

                dt1 = dal.getDataTabl_1(@"select A.*,B.*,P.PAYER_NAME,C.branch_name from (SELECT ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek
                ,Dafter_no,Dafter_ser,SANAD_TYPE2  FROM daily_transaction where SANAD_TYPE2='" + txt_sanad_type2.Text + "' and BRANCH_code='" + txtStore_ID.Text + "' and  ser_no='" + AccSer_No.TextS + "' and  meno>0) as A " +
                "inner join wh_BRANCHES as C on C.Branch_code=A.Branch_code " +
                ",(select acc_no as acc_cr,desc2 as desc_cr  from daily_transaction where SANAD_TYPE2='" + txt_sanad_type2.Text + "' and BRANCH_code='" + txtStore_ID.Text + "' and  ser_no='" + AccSer_No.TextS + "' and loh>0)  as B " +
                "inner join payer2 as P on P.ACC_NO=B.acc_cr");


                decimal balance_ = Convert.ToDecimal(dt1.Rows[0]["meno"].ToString());
                ToWord toWord = new ToWord(Math.Abs(Math.Round(balance_, dal.digits_)), currencies[currencyNo]);
                rpt.DataDefinition.FormulaFields["Tafqeet"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";


                DataSet ds = new DataSet("sanads");
                ds.Tables.Add(dt1);
                rpt.SetDataSource(ds);
                frmSand.crystalReportViewer1.ReportSource = rpt;
                frmSand.ShowDialog();

                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.Report_P;
                //rpt.PrintToPrinter(2, true, 0, 15);


                ////ds.WriteXmlSchema("schema3.xml");
            }
            else
            {
                Form1 frmSand = new Form1();
                CTR.print_CashReceipt rpt = new CTR.print_CashReceipt();
                DataTable dt1 = new DataTable();

                dt1 = dal.getDataTabl_1(@"select A.*,B.*,P.PAYER_NAME,p.PAYER_l_NAME,C.branch_name from (SELECT ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek
                ,Dafter_no,Dafter_ser,SANAD_TYPE2  FROM daily_transaction where SANAD_TYPE2='" + txt_sanad_type2.Text + "' and BRANCH_code='" + txtStore_ID.Text + "' and  ser_no='" + AccSer_No.TextS + "' and  meno>0) as A " +
                "inner join wh_BRANCHES as C on C.Branch_code=A.Branch_code " +
                ",(select acc_no as acc_cr,desc2 as desc_cr  from daily_transaction where SANAD_TYPE2='" + txt_sanad_type2.Text + "' and BRANCH_code='" + txtStore_ID.Text + "' and  ser_no='" + AccSer_No.TextS + "' and loh>0)  as B " +
                "inner join payer2 as P on P.ACC_NO=B.acc_cr");


                decimal balance_ = Convert.ToDecimal(dt1.Rows[0]["meno"].ToString());
                ToWord toWord = new ToWord(Math.Abs(Math.Round(balance_, dal.digits_)), currencies[currencyNo]);
                rpt.DataDefinition.FormulaFields["Tafqeet"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";


                DataSet ds = new DataSet("sanads");
                ds.Tables.Add(dt1);
                rpt.SetDataSource(ds);
                frmSand.crystalReportViewer1.ReportSource = rpt;
                frmSand.ShowDialog();




                ////ds.WriteXmlSchema("schema3.xml");
                //}
                //catch { }
            }
            //}
            //catch { }

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
                    else if (control is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                        (control as DevComponents.Editors.DateTimeAdv.DateTimeInput).Value = DateTime.Now;
                    else if (control is DevComponents.Editors.DoubleInput)
                        (control as DevComponents.Editors.DoubleInput).Value = 0;

                    else
                        func(control.Controls);
            };
            func(Controls);
            // txtCoId.Text = Properties.Settings.Default.CoId;
            //BranchId.Text = Properties.Settings.Default.BranchId;
        }


        private void BSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frm_search_recect frm_recet = new frm_search_recect();
            //    frm_recet.txt_source_code.Text = "CR";
            //    frm_recet.ShowDialog();


            //    int ii = frm_recet.DGV1.CurrentRow.Index;

            DataTable dt_ = dal.getDataTabl_1(@"select * from (SELECT ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek
                ,Dafter_no,Dafter_ser,SANAD_TYPE2  FROM daily_transaction where SANAD_TYPE2='cr' and BRANCH_code='a21106' and  ser_no='74654'and  meno>0) as A
                , (select acc_no as acc_cr  from daily_transaction where SANAD_TYPE2='cr' and BRANCH_code='a21106' and  ser_no='74654' and loh>0)  as cr_acc ");

            if (dt_.Rows.Count > 0)
            {

                acc_year.Text = dt_.Rows[0]["ACC_YEAR"].ToString();
                Account.ID.Text = dt_.Rows[0]["acc_cr"].ToString();
                AccSer_No.TextS = dt_.Rows[0]["ser_no"].ToString();
                Cost.ID.Text = dt_.Rows[0]["COST_CENTER"].ToString();
                paied_amount.Text = dt_.Rows[0]["meno"].ToString();
                txt_sandDate.Text = dt_.Rows[0]["g_date"].ToString();
                txt_sandNo.TextS = dt_.Rows[0]["sanad_no"].ToString();
                Payment_Type.Text = "2";
                user_id.Text = dt_.Rows[0]["user_name"].ToString();
                txtDescr.Text = dt_.Rows[0]["desc2"].ToString();
                txt_Check.Text = dt_.Rows[0]["sheek_no"].ToString();
                CustBank.ID.Text = dt_.Rows[0]["sheek_bank"].ToString();
                Check_Date.Text = dt_.Rows[0]["sheek_date"].ToString();
                cmb_Pay.Text = dt_.Rows[0]["Sheek"].ToString();
                txt_source_code.Text = dt_.Rows[0]["SOURCE_CODE"].ToString();
                txtStore_ID.Text = dt_.Rows[0]["Wh_Branch_Code"].ToString();
                CashAcc.ID.Text = dt_.Rows[0]["ACC_NO"].ToString();
                txt_sanad_type2.Text = dt_.Rows[0]["SANAD_TYPE2"].ToString();
                txtCust.Text = dt_.Rows[0]["notes"].ToString();
            }
            //}
            //catch { }
        }


        private void search_1_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            showData("S",txtStore_ID.Text, frm.txtSearch.t.Text);






           
        }

        public override void GoPrevious()
        {
            
            showData("S",txtStore_ID.Text, (txt_sandNo.TextS.ParseInt(0) - 1).ToString());

            base.GoPrevious();
        }

        public override void GoNext()
        {
            string ser = dal.getDataTabl_1(@"select isnull((BOX_ED_SER),1) from serial_no where Branch_code='" + txtStore_ID.Text
                        + "' and ACC_YEAR= '" + acc_year.Text + "' ").Rows[0][0].ToString();

            if (txt_sandNo.TextS.ParseInt(0) < ser.ParseInt(0))
            {
                showData("S", txtStore_ID.Text, (txt_sandNo.TextS.ParseInt(0) + 1).ToString());
            }
            else
            {
                MessageBox.Show("This is the Last Recored --- هذا هو السجل الاخير");
                return;

            } 

            base.GoNext();
        }

        public override void GoLast()
        {
            string ser = dal.getDataTabl_1(@"select isnull((BOX_ED_SER),1) from serial_no where Branch_code='" + txtStore_ID.Text
                        + "' and ACC_YEAR= '" + acc_year.Text + "' ").Rows[0][0].ToString();

            showData("S", txtStore_ID.Text, ser);

            base.GoLast();
        }


        private void showData(string _serchType, string _branch,string _sanad)
        {
            //dgv1.Rows.Clear();
            //dgv2.Rows.Clear();

            //PL.frmSerch frm = new PL.frmSerch();
            //frm.ShowDialog();

            getSanadData(_serchType, _branch, _sanad);
            ClearTextBoxes();
            if (dt_db.Rows.Count > 0 && dt_cr.Rows.Count > 0)
            {
                acc_year.Text = dt_db.Rows[0]["ACC_YEAR"].ToString();
                txtStore_ID.Text = dt_db.Rows[0]["BRANCH_code"].ToString();
                Account.branchID.Text = dt_db.Rows[0]["BRANCH_code"].ToString();
                Account.ID.Text = dt_db.Rows[0]["ACC_NO"].ToString();
                CashAcc.ID.Text = dt_cr.Rows[0]["ACC_No"].ToString();
                if (dt_db.Rows.Count > 1)
                {
                    txtFeesAcc.ID.Text = dt_db.Rows[1]["ACC_NO"].ToString();
                    txtFees.Text = dt_db.Rows[1]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
                }
                if (dt_db.Rows.Count > 2)
                {
                    txtVatAcc.ID.Text = dt_db.Rows[2]["ACC_NO"].ToString();
                    txtFeesVat.Text = dt_db.Rows[2]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
                }
                AccSer_No.TextS = dt_db.Rows[0]["ser_no"].ToString();
                Cost.ID.Text = dt_db.Rows[0]["COST_CENTER"].ToString();
                paied_amount.Text = dt_db.Rows[0]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
                
                
                txt_sandDate.Text = dt_db.Rows[0]["g_date"].ToString();
                txt_sandNo.TextS = dt_db.Rows[0]["sanad_no"].ToString();
                Payment_Type.Text = "2";
                user_id.Text = dt_db.Rows[0]["user_name"].ToString();
                txtDescr.Text = dt_db.Rows[0]["desc2"].ToString();
                txt_Check.Text = dt_db.Rows[0]["sheek_no"].ToString();
                CustBank.ID.Text = dt_db.Rows[0]["shequeBank_no"].ToString();
                Check_Date.Text = dt_db.Rows[0]["sheek_date"].ToString();
                cmb_Pay.SelectedValue = dt_db.Rows[0]["payType_No"].ToString();
                txt_source_code.Text = dt_db.Rows[0]["SOURCE_CODE"].ToString();
                txt_sanad_type2.Text = dt_db.Rows[0]["SANAD_TYPE2"].ToString();
                txtCust.Text = dt_db.Rows[0]["notes"].ToString();
                txtDescr_E.Text = dt_db.Rows[0]["desc_E"].ToString();
                cheuqeOrCash.Text = dt_db.Rows[0]["sheek_or_cash"].ToString();
                LoadSanad(txt_sandNo.TextS, acc_year.Text, txtStore_ID.Text, txt_source_code.Text);

            }

            Get_Total();
            IsNew = false;







            //DataTable dt_ = dal.getDataTabl_1(@" select * from (SELECT ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,g_date,sanad_no,SANAD_TYPE,sp_ser_no
            //,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek,payType_No,shequeBank_no
            //,Dafter_no,Dafter_ser,SANAD_TYPE2,desc_E  FROM daily_transaction where SANAD_TYPE2 in('CE','BP') and BRANCH_code='" + _branch + "' and  sanad_no ='" + _sanad + "' and  meno>0) as A " +
            //", (select acc_no as acc_cr,desc2 as desc_cr   from daily_transaction where SANAD_TYPE2 in('CE','BP') and BRANCH_code='" + _branch + "' and  sanad_no ='" + _sanad + "' and loh>0)  as cr_acc ");

            //ClearTextBoxes();
            ////G_Search.Visible = false;
            //if (dt_.Rows.Count > 0)
            //{
            //    acc_year.Text = dt_.Rows[0]["ACC_YEAR"].ToString();
            //    txtStore_ID.Text = dt_.Rows[0]["Wh_Branch_Code"].ToString();
            //    Account.branchID.Text = dt_.Rows[0]["Wh_Branch_Code"].ToString();
            //    Account.ID.Text = dt_.Rows[0]["ACC_NO"].ToString();
            //    AccSer_No.TextS = dt_.Rows[0]["ser_no"].ToString();
            //    Cost.ID.Text = dt_.Rows[0]["COST_CENTER"].ToString();
            //    paied_amount.Text = dt_.Rows[0]["meno"].ToString();
            //    txt_sandDate.Text = dt_.Rows[0]["g_date"].ToString();
            //    txt_sandNo.TextS = dt_.Rows[0]["sanad_no"].ToString();
            //    Payment_Type.Text = dt_.Rows[0]["SANAD_TYPE"].ToString();
            //    user_id.Text = dt_.Rows[0]["user_name"].ToString();
            //    txtDescr.Text = dt_.Rows[0]["desc_cr"].ToString();
            //    txt_Check.Text = dt_.Rows[0]["sheek_no"].ToString();
            //    CustBank.ID.Text = dt_.Rows[0]["shequeBank_no"].ToString();
            //    Check_Date.Text = dt_.Rows[0]["sheek_date"].ToString();
            //    cmb_Pay.SelectedValue = dt_.Rows[0]["payType_No"].ToString();
            //    txt_source_code.Text = dt_.Rows[0]["SOURCE_CODE"].ToString();
            //    CashAcc.ID.Text = dt_.Rows[0]["acc_cr"].ToString();
            //    txt_sanad_type2.Text = dt_.Rows[0]["SANAD_TYPE2"].ToString();
            //    txtCust.Text = dt_.Rows[0]["notes"].ToString();
            //    txtDescr_E.Text = dt_.Rows[0]["desc_E"].ToString();
            //    cheuqeOrCash.Text = dt_.Rows[0]["sheek_or_cash"].ToString();
            //    txtSpecialNo.Text = dt_.Rows[0]["sp_ser_no"].ToString();

            //    LoadSanad(txt_sandNo.TextS, acc_year.Text, txtStore_ID.Text, txt_source_code.Text);
            //}
            //Get_Total();
            //IsNew = false;
        }

        private void search_2_Click(object sender, EventArgs e)
        {

            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            showData("J", txtStore_ID.Text, frm.txtSearch.t.Text);




            //dgv1.Rows.Clear();
            //dgv2.Rows.Clear();

            //PL.frmSerch frm = new PL.frmSerch();
            //frm.ShowDialog();

            //getSanadData("J",txtStore_ID.Text, frm.txtSearch.t.Text);
            //ClearTextBoxes();
            //if (dt_db.Rows.Count > 0 && dt_cr.Rows.Count > 0)
            //{
            //    acc_year.Text = dt_db.Rows[0]["ACC_YEAR"].ToString();
            //    txtStore_ID.Text = dt_db.Rows[0]["Wh_Branch_Code"].ToString();
            //    Account.branchID.Text = dt_db.Rows[0]["Wh_Branch_Code"].ToString();
            //    Account.ID.Text = dt_db.Rows[0]["ACC_NO"].ToString();
            //    CashAcc.ID.Text = dt_cr.Rows[0]["ACC_No"].ToString();
            //    txtFeesAcc.ID.Text = dt_db.Rows[1]["ACC_NO"].ToString();
            //    txtVatAcc.ID.Text = dt_db.Rows[2]["ACC_NO"].ToString();
            //    AccSer_No.TextS = dt_db.Rows[0]["ser_no"].ToString();
            //    Cost.ID.Text = dt_db.Rows[0]["COST_CENTER"].ToString();
            //    paied_amount.Text = dt_db.Rows[0]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
            //    txtFees.Text = dt_db.Rows[1]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
            //    txtFeesVat.Text = dt_db.Rows[2]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
            //    txt_sandDate.Text = dt_db.Rows[0]["g_date"].ToString();
            //    txt_sandNo.TextS = dt_db.Rows[0]["sanad_no"].ToString();
            //    Payment_Type.Text = "2";
            //    user_id.Text = dt_db.Rows[0]["user_name"].ToString();
            //    txtDescr.Text = dt_db.Rows[0]["desc2"].ToString();
            //    txt_Check.Text = dt_db.Rows[0]["sheek_no"].ToString();
            //    CustBank.ID.Text = dt_db.Rows[0]["shequeBank_no"].ToString();
            //    Check_Date.Text = dt_db.Rows[0]["sheek_date"].ToString();
            //    cmb_Pay.SelectedValue = dt_db.Rows[0]["payType_No"].ToString();
            //    txt_source_code.Text = dt_db.Rows[0]["SOURCE_CODE"].ToString();
            //    txt_sanad_type2.Text = dt_db.Rows[0]["SANAD_TYPE2"].ToString();
            //    txtCust.Text = dt_db.Rows[0]["notes"].ToString();
            //    txtDescr_E.Text = dt_db.Rows[0]["desc_E"].ToString();
            //    cheuqeOrCash.Text = dt_db.Rows[0]["sheek_or_cash"].ToString();
            //    LoadSanad(txt_sandNo.TextS, acc_year.Text, txtStore_ID.Text, txt_source_code.Text);

            //}

            //Get_Total();
            //IsNew = false;
        }



        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            //txtsearch.Clear();
            //G_Search.Visible = false;
        }





        private void getJorSer()
        {
            DataTable dt_Ser = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) as main_daily_ser ,isnull((BOX_SARF_SER)+1,1) as BOX_SARF_SER,isnull((HEWALA_sarf_ser)+1,1) as HEWALA_sarf_ser from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchId
                   + "' and ACC_YEAR= '" + acc_year.Text + "'");
            if (dt_Ser.Rows.Count > 0)
            {
                AccSer_No.TextS = dal.GetCell_1("select Main_Acc_Company from Wh_Configration").ToString() + dt_Ser.Rows[0]["main_daily_ser"].ToString().PadLeft(4, '0');

                if (txt_source_code.Text == "CR")
                {
                    txt_sandNo.TextS = dt_Ser.Rows[0]["BOX_SARF_SER"].ToString();
                }
                else if (txt_source_code.Text == "SH")
                {
                    txt_sandNo.TextS = dt_Ser.Rows[0]["HEWALA_sarf_ser"].ToString();
                }



            }
            //DataTable dt_Ser = dal.getDataTabl_1(@"select isnull((BOX_SARF_SER)+1,1) as BOX_SARF_SER,isnull((HEWALA_sarf_ser)+1,1) as HEWALA_sarf_ser from serial_no where Branch_code='" + txtStore_ID.Text
            //              + "' and ACC_YEAR= '" + acc_year.Text + "' ");
           
            ////txt_sandNo.TextS = dal.getDataTabl_1(@"select isnull((BOX_SARF_SER)+1,1),isnull((HEWALA_sarf_ser)+1,1) from serial_no where Branch_code='" + txtStore_ID.Text
            ////              + "' and ACC_YEAR= '" + acc_year.Text + "' ").Rows[0][0].ToString();



        }


        private void Acc_Cr_Click(object sender, EventArgs e)
        {
        }


        private void getSanadData(string searchType, string _branch, string _accSer)
        {
            if (searchType == "J")
            {
                dt_db = dal.getDataTabl_1(@"select A.*,P.PAYER_NAME,isnull(nullif(PAYER_l_NAME,''),PAYER_NAME) as PAYER_l_NAME ,C.branch_name,isnull(nullif(WH_E_NAME,''),branch_name) as WH_E_NAME,S.BANK_NAME,S.BANK_NAME_E 
                from (SELECT LEFT(BRANCH_code,1) as com_code,ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,loh,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek,payType_No,shequeBank_no,ISNULL(NULLIF(desc_E, ''), desc2) as desc_E
                ,Dafter_no,Dafter_ser,SANAD_TYPE2,sorting_ser  FROM daily_transaction where SANAD_TYPE2='BP' and BRANCH_code='" + _branch + "' and  ser_no='" + _accSer +
                "' and  meno>0) as A " +
                "inner join wh_BRANCHES as C on C.Branch_code=A.Branch_code " +
                "left join SHEEK_BANKS_TYPE  as S on S.BANK_NO =A.shequeBank_no " +
                "inner join payer2 as P on P.ACC_NO=A.ACC_NO and P.BRANCH_code=a.BRANCH_code  order by sorting_ser");

                dt_cr = dal.getDataTabl_1(@"select A.*,P.PAYER_NAME,isnull(nullif(PAYER_l_NAME,''),PAYER_NAME) as PAYER_l_NAME ,C.branch_name,isnull(nullif(WH_E_NAME,''),branch_name) as WH_E_NAME,S.BANK_NAME,S.BANK_NAME_E 
                from (SELECT LEFT(BRANCH_code,1) as com_code,ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,loh,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek,payType_No,shequeBank_no,ISNULL(NULLIF(desc_E, ''), desc2) as desc_E
                ,Dafter_no,Dafter_ser,SANAD_TYPE2,sorting_ser  FROM daily_transaction where SANAD_TYPE2='BP' and BRANCH_code='" + _branch + "' and  ser_no='" + _accSer +
                "' and  loh>0) as A " +
                "inner join wh_BRANCHES as C on C.Branch_code=A.Branch_code " +
                "left join SHEEK_BANKS_TYPE  as S on S.BANK_NO =A.shequeBank_no " +
                "inner join payer2 as P on P.ACC_NO=A.ACC_NO and P.BRANCH_code=a.BRANCH_code  order by sorting_ser");
            }
            else if (searchType == "S")
            {
                dt_db = dal.getDataTabl_1(@"select A.*,P.PAYER_NAME,isnull(nullif(PAYER_l_NAME,''),PAYER_NAME) as PAYER_l_NAME ,C.branch_name,isnull(nullif(WH_E_NAME,''),branch_name) as WH_E_NAME,S.BANK_NAME,S.BANK_NAME_E 
                from (SELECT LEFT(BRANCH_code,1) as com_code,ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,loh,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek,payType_No,shequeBank_no,ISNULL(NULLIF(desc_E, ''), desc2) as desc_E
                ,Dafter_no,Dafter_ser,SANAD_TYPE2,sorting_ser  FROM daily_transaction where SANAD_TYPE2='BP' and BRANCH_code='" + _branch + "' and  sanad_no='" + _accSer +
                "' and  meno>0) as A " +
                "inner join wh_BRANCHES as C on C.Branch_code=A.Branch_code " +
                "left join SHEEK_BANKS_TYPE  as S on S.BANK_NO =A.shequeBank_no " +
                "inner join payer2 as P on P.ACC_NO=A.ACC_NO and P.BRANCH_code=a.BRANCH_code  order by sorting_ser");

                dt_cr = dal.getDataTabl_1(@"select A.*,P.PAYER_NAME,isnull(nullif(PAYER_l_NAME,''),PAYER_NAME) as PAYER_l_NAME ,C.branch_name,isnull(nullif(WH_E_NAME,''),branch_name) as WH_E_NAME,S.BANK_NAME,S.BANK_NAME_E 
                from (SELECT LEFT(BRANCH_code,1) as com_code,ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER,meno,loh,g_date,sanad_no,SANAD_TYPE,sp_ser_no
                ,user_name,desc2,sheek_no,sheek_bank,sheek_date,sheek_or_cash,notes,SOURCE_CODE,Wh_Branch_Code,Sheek,payType_No,shequeBank_no,ISNULL(NULLIF(desc_E, ''), desc2) as desc_E
                ,Dafter_no,Dafter_ser,SANAD_TYPE2,sorting_ser  FROM daily_transaction where SANAD_TYPE2='BP' and BRANCH_code='" + _branch + "' and  sanad_no='" + _accSer +
                "' and  loh>0) as A " +
                "inner join wh_BRANCHES as C on C.Branch_code=A.Branch_code " +
                "left join SHEEK_BANKS_TYPE  as S on S.BANK_NO =A.shequeBank_no " +
                "inner join payer2 as P on P.ACC_NO=A.ACC_NO and P.BRANCH_code=a.BRANCH_code  order by sorting_ser");

            }

        }

        public override void Attachment()
        {
            DataTable dt_ = dal.getDataTabl_1(@"select ser_no from daily_transaction where Ser_no= '" + AccSer_No.TextS + "' and ACC_YEAR ='" + acc_year.Text + "' and Branch_code = '" + txtStore_ID.Text + "'");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = AccSer_No.TextS;
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


        public override void Print()
        {

            // CTR.CrystalReport5 rpt = new CTR.CrystalReport5();
            CTR.rpt_Bank_voucher rpt = new CTR.rpt_Bank_voucher();
            DataSet ds = new DataSet();
            getSanadData("J",txtStore_ID.Text , AccSer_No.TextS);
   
            DataTable dtCurrency = dal.getDataTabl_1(@"SELECT Currency_Code, Currency_Name , Change_Factor , Currency_Name_e , sub_Currency_Name , sub_Currency_Name_E 
            FROM  Wh_Currency  where Currency_Code = '"+Properties.Settings.Default.Currency+"'");
            if (dt_db.Rows.Count > 0)
            {
                DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp where Company_No='" + dt_db.Rows[0]["com_code"] + "'  ");

                DataTable dtSanadInv = dal.getDataTabl_1(@" select * from  Sands_Details where ser_no = '" + dt_db.Rows[0]["sanad_no"] + "' and BRANCH_code ='" + dt_db.Rows[0]["Branch_code"] + "' and SOURCE_CODE = '" + dt_db.Rows[0]["SOURCE_CODE"] + "' ");
                ds.Tables.Add(dtSanadInv);
                ds.Tables.Add(dt_Co);
                rpt.DataSource = ds;
                ds.WriteXmlSchema("schema3.xml");

                decimal balance_ = Convert.ToDecimal(dt_db.Rows[0]["meno"].ToString());
                ToWord toWord = new ToWord(Math.Abs(Math.Round(balance_, dal.digits_)), currencies[currencyNo]);
                if (Properties.Settings.Default.lungh == "0")
                {
                    rpt.txtAmountinLetter.Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                    rpt.txtAccount.Text = dt_db.Rows[0]["PAYER_NAME"].ToString();
                    rpt.txtChequeBank.Text = dt_db.Rows[0]["BANK_NAME"].ToString();
                    rpt.txtDesc1.Text = dt_db.Rows[0]["desc2"].ToString();
                    rpt.txtBranch.Text = dt_db.Rows[0]["branch_name"].ToString();
                    rpt.txtCruncy.Text = dtCurrency.Rows[0]["Currency_Name_e"].ToString();
                    rpt.txtSubCruncy.Text = dtCurrency.Rows[0]["sub_Currency_Name"].ToString();
                    rpt.txtCreditAcc.Text = dt_cr.Rows[0]["PAYER_NAME"].ToString();
                }
                else
                {
                    rpt.txtAmountinLetter.Text = "'" + toWord.ConvertToEnglish().ToString() + "'";
                    rpt.txtAccount.Text = dt_db.Rows[0]["PAYER_l_NAME"].ToString();
                    rpt.txtChequeBank.Text = dt_db.Rows[0]["BANK_NAME_E"].ToString();
                    rpt.txtDesc1.Text = dt_db.Rows[0]["desc_E"].ToString();
                    rpt.txtBranch.Text = dt_db.Rows[0]["WH_E_NAME"].ToString();
                    rpt.txtCruncy.Text = dtCurrency.Rows[0]["Currency_Name"].ToString(); 
                    rpt.txtSubCruncy.Text = dtCurrency.Rows[0]["sub_Currency_Name_E"].ToString();
                    rpt.txtCreditAcc.Text = dt_cr.Rows[0]["PAYER_l_NAME"].ToString();

                }
                if (dt_db.Rows[0]["payType_No"].ToString() == "04")
                {

                    rpt.chCheque.Checked = true;

                    rpt.txtChequeDate.Text = "";
                    rpt.txtChequeNo.Text = dt_db.Rows[0]["sheek_no"].ToString();
                    rpt.txtChequeDate.Text = Convert.ToDateTime(dt_db.Rows[0]["sheek_date"]).ToString("dd/MM/yyyy");
                }

                else if (dt_db.Rows[0]["payType_No"].ToString() == "02")
                {
                    rpt.chMada.Checked = true;

                }

                else if (dt_db.Rows[0]["payType_No"].ToString() == "03")
                {

                    rpt.chVisa.Checked = true;

                }

                else if (dt_db.Rows[0]["payType_No"].ToString() == "05")
                {

                    rpt.chTransfer.Checked = true;

                }

                else
                {
                    rpt.chCash.Checked = true;
                    

                }



                rpt.txtSer.Text = dt_db.Rows[0]["Sanad_No"].ToString();
                rpt.txtDate.Text = Convert.ToDateTime(dt_db.Rows[0]["g_date"]).ToString("dd/MM/yyyy");
                rpt.txtAmount.Text = Math.Floor(dt_db.Rows[0]["meno"].ToString().ToDecimal()).ToString("N0");
                rpt.txtSubAmount.Text = ((dt_db.Rows[0]["meno"].ToString().ToDecimal() - Math.Floor(dt_db.Rows[0]["meno"].ToString().ToDecimal())) * dal.dicimalRate().ToString().ToDecimal()).ToString("N0");
                if (dt_db.Rows.Count > 1)
                {
                    rpt.txtFees.Text = dt_db.Rows[1]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
                }
                if (dt_db.Rows.Count > 2)
                {
                    rpt.txtFeesTax.Text = dt_db.Rows[2]["meno"].ToString().ToDecimal().ToString("N" + dal.digits_);
                }
                rpt.txtUser.Text = dt_db.Rows[0]["user_name"].ToString();
                rpt.txtEnteryNo.Text = dt_db.Rows[0]["ser_no"].ToString();
                
              
                if (dt_Co.Rows[0]["stamp_pic"].ToString() != string.Empty)
                {
                    using (MemoryStream mStream = new MemoryStream((Byte[])dt_Co.Rows[0]["stamp_pic"]))
                    {
                        rpt.Pic2.Image = Image.FromStream(mStream);
                    }
                }
                if (dt_Co.Rows[0]["h_pic"].ToString() != string.Empty)
                {
                    using (MemoryStream ms_Hpic = new MemoryStream((Byte[])dt_Co.Rows[0]["h_pic"]))
                    {
                        rpt.PicH.Image = Image.FromStream(ms_Hpic);
                    }
                }

                
                if (Encoding.ASCII.GetString((Byte[]) dt_Co.Rows[0]["f_pic"]) != string.Empty)
                {
                    using (MemoryStream ms_Fpic = new MemoryStream((Byte[])dt_Co.Rows[0]["f_pic"]))
                    {
                        rpt.picF.Image = Image.FromStream(ms_Fpic);
                    }
                }
              
                rpt.ShowPreview();


            }
            base.Print();
        }


        public override void Report()
        {
            var frm = new RPT.frm_statment_Rpt();
            frm.canChangeAcc = false;
            frm.UC_Acc1.ID.Text = Account.ID.Text;
            Forms.frm_Main.OpenForm(frm, true);

            base.Report();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("not allawed");
            return;
        }


        private void Btn_NonPayInvoice_Click(object sender, EventArgs e)
        {
            getNonPaidInvoices();
            getbalance();
        }



        private void getNonPaidInvoices()
        {
            if (Account.ID.Text.Trim() != string.Empty)
            {
                DataTable dt_inv = dal.getDataTabl_1(@"
                    select x.Ser_no,x.Cyear,x.Branch_code,x.Transaction_code,x.G_date,x.Acc_no,x.Acc_Branch_code,x.Payment_Type
                    ,x.Inv_no,x.Inv_date,x.Po_no,x.Inv_Notes,x.NetAmount,x.Vat,B.paidAmount
                    ,x.InvoiceAmount,isnull(y.returnAmount,0) as returnAmount,(x.InvoiceAmount+isnull(y.returnAmount,0) - isnull(B.paidAmount,0)) as Balance

                    from( SELECT A.Ser_no,A.Cyear,A.Branch_code,A.Transaction_code,A.G_date,A.Acc_no,A.Acc_Branch_code,A.Payment_Type,A.Inv_no,A.Inv_date,A.Po_no,A.Inv_Notes
					,sum((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price) - sum(((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price * D.total_disc) / 100) AS NetAmount
					, sum(D.TAX_IN) - sum(D.TAX_OUT) As Vat
					,sum((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price) - sum(((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price * D.total_disc) / 100)+(sum(D.TAX_IN) - sum(D.TAX_OUT)) as InvoiceAmount
                    FROM  wh_inv_data As A  
					inner join wh_material_transaction as D on A.Ser_no = D.SER_NO and A.Cyear = D.Cyear and a.Transaction_code = D.TRANSACTION_CODE and a.Branch_code = D.Branch_code  where A.Transaction_code ='xpc'
					
					group by A.Ser_no,A.Cyear,A.Branch_code,A.Transaction_code,A.G_date,A.Acc_no,A.Acc_Branch_code,A.Payment_Type
                    ,A.Inv_no,A.Inv_date,Po_no,A.Inv_Notes) as x

                    left join (SELECT cyear,BRANCH_code,Inv_No,Inv_Transaction_Code, sum(isnull(CurrentPaid,0)) as paidAmount  FROM Sands_Details where SOURCE_CODE ='DB' group by cyear,BRANCH_code,Inv_Transaction_Code,Inv_No ) as B
                    on  B.cyear = x.Cyear and B.BRANCH_code = x.BRANCH_code and B.Inv_No=x.Ser_no and B.Inv_Transaction_Code =x.Transaction_code 


                    left join (SELECT A.Branch_code,A.Acc_no,A.Payment_Type,A.Inv_no,A.Inv_date
					,sum((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price) - sum(((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price * D.total_disc) / 100) AS NetAmount
					, sum(D.TAX_IN) - sum(D.TAX_OUT) As Vat
					,sum((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price) - sum(((D.QTY_ADD - D.QTY_TAKE) * D.Local_Price * D.total_disc) / 100)+sum(D.TAX_IN) - sum(D.TAX_OUT) as returnAmount
                    FROM  wh_inv_data As A  
					inner join wh_material_transaction as D on A.Ser_no = D.SER_NO and A.Cyear = D.Cyear and a.Transaction_code = D.TRANSACTION_CODE and a.Branch_code = D.Branch_code  where A.Transaction_code  in('xpr','xpt')
					
					group by A.Branch_code,A.Acc_no,A.Payment_Type,A.Inv_no,A.Inv_date) as Y
                    on x.Acc_no = y.Acc_no and x.Branch_code = y.Branch_code  and x.Ser_no =y.Inv_no and cast(x.G_date as date ) = cast(y.Inv_date as date ) and x.Payment_Type = y.Payment_Type
                    where x.acc_no =  '" + Account.ID.Text + 
                    "' and x.InvoiceAmount+isnull(y.returnAmount,0)- isnull(B.paidAmount,0)<>0 ORDER BY x.G_date");

                if (dt_inv.Rows.Count > 0)
                {
                    int B_rowscount = dt_inv.Rows.Count;

                    dgv1.Rows.Clear();
                    dgv1.Rows.Add(B_rowscount);
                    for (int i = 0; i <= (B_rowscount - 1); i++)
                    {


                        dgv1.Rows[i].Cells[0].Value = dt_inv.Rows[i]["Ser_no"];
                        dgv1.Rows[i].Cells[1].Value = dt_inv.Rows[i]["Cyear"];
                        dgv1.Rows[i].Cells[2].Value = dt_inv.Rows[i]["G_date"];
                        dgv1.Rows[i].Cells[3].Value = dt_inv.Rows[i]["Po_no"];
                        dgv1.Rows[i].Cells[4].Value = dt_inv.Rows[i]["InvoiceAmount"];
                        dgv1.Rows[i].Cells[5].Value = dt_inv.Rows[i]["returnAmount"];
                        dgv1.Rows[i].Cells[6].Value = dt_inv.Rows[i]["paidAmount"];
                        dgv1.Rows[i].Cells[7].Value = dt_inv.Rows[i]["Balance"];
                        dgv1.Rows[i].Cells[8].Value = dt_inv.Rows[i]["Transaction_code"];


                    }
                }
                else
                {
                    dgv1.Rows.Clear();
                }
                Get_Total();
            }

        }

        private void getbalance()
        {
            DateTime FromDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime ToDate = DateTime.Today;
            DataTable dt2 = dal.getDataTabl_1("select (sum(isnull(meno,0))-sum(isnull(loh,0))) as bal from daily_transaction where acc_no = '" + Account.ID.Text + "'");
            //  ,  FromDate, ToDate, Account.ID.Text, "", "", FromDate, "", db1, Properties.Settings.Default.Currency));

            accountBalance.Text = dt2.Rows[0]["bal"].ToString().ToDecimal().ToString("N" + dal.digits_);
        }





        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
            {
                if (dgv2.Rows[i].Cells[0].Value.ToString() == dgv1.CurrentRow.Cells[0].Value.ToString() && dgv2.Rows[i].Cells[1].Value.ToString() == dgv1.CurrentRow.Cells[1].Value.ToString())
                {
                    dgv2.Rows.RemoveAt(i);
                    Get_Total();
                }
            }


            int n1 = dgv2.Rows.Add();
            if (paied_amount.Value > 0 && paied_amount.Value > (txtTotalPaid.Value + dgv1.CurrentRow.Cells[7].Value.ToString().ToDecimal()))
            {

                dgv2.Rows[n1].Cells[0].Value = dgv1.CurrentRow.Cells[0].Value;
                dgv2.Rows[n1].Cells[1].Value = dgv1.CurrentRow.Cells[1].Value.ToString();
                dgv2.Rows[n1].Cells[2].Value = dgv1.CurrentRow.Cells[2].Value;
                dgv2.Rows[n1].Cells[3].Value = dgv1.CurrentRow.Cells[3].Value;
                dgv2.Rows[n1].Cells[4].Value = dgv1.CurrentRow.Cells[4].Value;
                dgv2.Rows[n1].Cells[5].Value = dgv1.CurrentRow.Cells[5].Value;
                dgv2.Rows[n1].Cells[6].Value = dgv1.CurrentRow.Cells[6].Value;
                dgv2.Rows[n1].Cells[7].Value = dgv1.CurrentRow.Cells[7].Value;
                dgv2.Rows[n1].Cells[8].Value = dgv1.CurrentRow.Cells[7].Value;
                dgv2.Rows[n1].Cells[9].Value = (dgv2.Rows[n1].Cells[7].Value.ToString().ToDecimal() - dgv2.Rows[n1].Cells[8].Value.ToString().ToDecimal());
                dgv2.Rows[n1].Cells[11].Value = dgv1.CurrentRow.Cells[8].Value.ToString();


                dgv1.Rows.RemoveAt(this.dgv1.CurrentRow.Index);
                //txtDescr.Text = arabicDesc();
                ////+ " -سند رقم " + txt_sandNo.TextS;
                //txtDescr_E.Text = englishDesc();
                //    //+ " -Sanad No " + txt_sandNo.TextS;
            }


            else if (paied_amount.Value > 0 && paied_amount.Value > txtTotalPaid.Value && paied_amount.Value < (txtTotalPaid.Value + dgv1.CurrentRow.Cells[7].Value.ToString().ToDecimal()))
            {

                dgv2.Rows[n1].Cells[0].Value = dgv1.CurrentRow.Cells[0].Value;
                dgv2.Rows[n1].Cells[1].Value = dgv1.CurrentRow.Cells[1].Value.ToString();
                dgv2.Rows[n1].Cells[2].Value = dgv1.CurrentRow.Cells[2].Value;
                dgv2.Rows[n1].Cells[3].Value = dgv1.CurrentRow.Cells[3].Value;
                dgv2.Rows[n1].Cells[4].Value = dgv1.CurrentRow.Cells[4].Value;
                dgv2.Rows[n1].Cells[5].Value = dgv1.CurrentRow.Cells[5].Value;
                dgv2.Rows[n1].Cells[6].Value = dgv1.CurrentRow.Cells[6].Value;
                dgv2.Rows[n1].Cells[7].Value = dgv1.CurrentRow.Cells[7].Value;
                dgv2.Rows[n1].Cells[8].Value = paied_amount.Value - txtTotalPaid.Value;
                dgv2.Rows[n1].Cells[9].Value = (dgv2.Rows[n1].Cells[7].Value.ToString().ToDecimal() - dgv2.Rows[n1].Cells[8].Value.ToString().ToDecimal());
                dgv2.Rows[n1].Cells[11].Value = dgv1.CurrentRow.Cells[8].Value.ToString();

                // dgv1.CurrentRow.Cells[6].Value = dgv2.Rows[n1].Cells[8].Value.ToString();
                //dgv1.CurrentRow.Cells[7].Value = dgv1.CurrentRow.Cells[7].Value.ToString().ToDecimal() - dgv1.CurrentRow.Cells[6].Value.ToString().ToDecimal();

                // dgv1.Rows.RemoveAt(this.dgv1.CurrentRow.Index);

            }
            else if (paied_amount.Value > 0 && paied_amount.Value <= txtTotalPaid.Value)
            {
                return;
            }

            else
            {

                dgv2.Rows[n1].Cells[0].Value = dgv1.CurrentRow.Cells[0].Value;
                dgv2.Rows[n1].Cells[1].Value = dgv1.CurrentRow.Cells[1].Value.ToString();
                dgv2.Rows[n1].Cells[2].Value = dgv1.CurrentRow.Cells[2].Value;
                dgv2.Rows[n1].Cells[3].Value = dgv1.CurrentRow.Cells[3].Value;
                dgv2.Rows[n1].Cells[4].Value = dgv1.CurrentRow.Cells[4].Value;
                dgv2.Rows[n1].Cells[5].Value = dgv1.CurrentRow.Cells[5].Value;
                dgv2.Rows[n1].Cells[6].Value = dgv1.CurrentRow.Cells[6].Value;
                dgv2.Rows[n1].Cells[7].Value = dgv1.CurrentRow.Cells[7].Value;
                dgv2.Rows[n1].Cells[8].Value = dgv1.CurrentRow.Cells[7].Value;
                dgv2.Rows[n1].Cells[9].Value = (dgv2.Rows[n1].Cells[7].Value.ToString().ToDecimal() - dgv2.Rows[n1].Cells[8].Value.ToString().ToDecimal());
                dgv2.Rows[n1].Cells[11].Value = dgv1.CurrentRow.Cells[8].Value.ToString();
                dgv1.Rows.RemoveAt(this.dgv1.CurrentRow.Index);
            }

            if (n1 > 0)
            {
                dgv2.Rows[n1].Cells[10].Value = (dgv2.Rows[n1].Cells[8].Value.ToString().ToDecimal() + dgv2.Rows[n1 - 1].Cells[10].Value.ToString().ToDecimal()).ToString();
            }
            else
            {
                dgv2.Rows[n1].Cells[10].Value = dgv2.Rows[n1].Cells[8].Value;
            }

            txtDescr.Text = arabicDesc();
            //+ " -سند رقم " + txt_sandNo.TextS;
            txtDescr_E.Text = englishDesc();
            Get_Total();

        }






        private void Get_Total()
        {
            txtTotalInvoices.Text =
                         (from DataGridViewRow row in dgv1.Rows
                          where row.Cells[0].FormattedValue.ToString() != string.Empty
                          select (row.Cells[7].FormattedValue).ToString().ToDecimal()).Sum().ToString("n" + dal.digits_);

            txtTotalChoseInvoices.Text =
             (from DataGridViewRow row in dgv2.Rows
              where row.Cells[col_invNo.Index].FormattedValue.ToString() != string.Empty
              select (row.Cells[col_oldBalance.Index].FormattedValue).ToString().ToDecimal()).Sum().ToString("n" + dal.digits_);

            txtTotalPaid.Text =
           (from DataGridViewRow row in dgv2.Rows
            where row.Cells[col_invNo.Index].FormattedValue.ToString() != string.Empty
            select (row.Cells[col_currentPaid.Index].FormattedValue).ToString().ToDecimal()).Sum().ToString("n" + dal.digits_);

            txtBalance.Text =
          (from DataGridViewRow row in dgv2.Rows
           where row.Cells[col_invNo.Index].FormattedValue.ToString() != string.Empty
           select (row.Cells[col_newBalance.Index].FormattedValue).ToString().ToDecimal()).Sum().ToString("n" + dal.digits_);

            txtNoOfInvoices.Text =
               (from DataGridViewRow row in dgv2.Rows
                where row.Cells[col_invNo.Index].FormattedValue.ToString() != string.Empty
                select (row.Cells[col_invNo.Index].FormattedValue).ToString()).Count().ToString();


        }


        private void paied_amount_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
            {
                if (dgv2.Rows[i].Cells[col_sanadBalance.Index].Value.ToString().ToDecimal() > paied_amount.Value)
                {
                    dgv2.Rows.RemoveAt(i);
                    Get_Total();
                }
            }
        }

        private void dgv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8)
            {

                string _inv = dgv2.CurrentRow.Cells[0].Value.ToString();
                string _year = dgv2.CurrentRow.Cells[1].Value.ToString();


                for (int i = 0; i <= dgv1.Rows.Count - 1; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value.ToString() == _inv && dgv1.Rows[i].Cells[1].Value.ToString() == _year)
                    {
                        dgv1.Rows[i].Cells[6].Value = dgv1.Rows[i].Cells[6].Value.ToString().ToDecimal() - dgv2.CurrentRow.Cells[8].Value.ToString().ToDecimal();
                        dgv1.Rows[i].Cells[7].Value = dgv1.Rows[i].Cells[7].Value.ToString().ToDecimal() + dgv2.CurrentRow.Cells[8].Value.ToString().ToDecimal();

                        dgv2.Rows.RemoveAt(this.dgv2.CurrentRow.Index);
                        Get_Total();
                        return;
                    }
                }
                int n1 = dgv1.Rows.Add();
                dgv1.Rows[n1].Cells[0].Value = dgv2.CurrentRow.Cells[0].Value;
                dgv1.Rows[n1].Cells[1].Value = dgv2.CurrentRow.Cells[1].Value.ToString();
                dgv1.Rows[n1].Cells[2].Value = dgv2.CurrentRow.Cells[2].Value;
                dgv1.Rows[n1].Cells[3].Value = dgv2.CurrentRow.Cells[3].Value;
                dgv1.Rows[n1].Cells[4].Value = dgv2.CurrentRow.Cells[4].Value;
                dgv1.Rows[n1].Cells[5].Value = dgv2.CurrentRow.Cells[5].Value;
                dgv1.Rows[n1].Cells[6].Value = dgv2.CurrentRow.Cells[6].Value;
                dgv1.Rows[n1].Cells[7].Value = dgv2.CurrentRow.Cells[7].Value;
                dgv1.Rows[n1].Cells[8].Value = dgv2.CurrentRow.Cells[11].Value.ToString();
                dgv2.Rows.RemoveAt(this.dgv2.CurrentRow.Index);

                Get_Total();
                txtDescr.Text = arabicDesc();
                txtDescr_E.Text = englishDesc();
            }
        }


        private string arabicDesc()
        {
            string _invoices = "";
            if (dgv2.Rows.Count > 0)
            {

                _invoices = "سداد فواتير ( ";
                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    if (dgv2.Rows[i].Cells[0].Value != null)
                    {
                        string _invNo = "";
                        if (dgv2.Rows[i].Cells[8].Value.ToString().ToDecimal() < dgv2.Rows[i].Cells[4].Value.ToString().ToDecimal())
                        {
                            _invNo = "دفعة من " + dgv2.Rows[i].Cells[0].Value.ToString();
                        }
                        else
                        {
                            _invNo = dgv2.Rows[i].Cells[0].Value.ToString();
                        }
                        if (i < dgv2.Rows.Count - 1)
                        {
                            _invoices += _invNo + " & ";
                        }
                        else
                        {
                            _invoices += _invNo + " )";
                        }
                    }
                }
                //for (int i = dgv2.Rows.Count - 1; i <= dgv2.Rows.Count - 1; i++)
                //{
                //    _invoices += dgv2.Rows[i].Cells[0].Value.ToString() + " )";

                //}

            }
            return _invoices;
        }

        private string englishDesc()
        {
            string _invoices = "";
            if (dgv2.Rows.Count > 0)
            {
                _invoices = "payment of Invices ( ";
                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    if (dgv2.Rows[i].Cells[0].Value != null)
                    {
                        string _invNo = "";
                        if (dgv2.Rows[i].Cells[8].Value.ToString().ToDecimal() < dgv2.Rows[i].Cells[4].Value.ToString().ToDecimal())
                        {
                            _invNo = "Part of " + dgv2.Rows[i].Cells[0].Value.ToString();
                        }
                        else
                        {
                            _invNo = dgv2.Rows[i].Cells[0].Value.ToString();
                        }



                        if (i < dgv2.Rows.Count - 1)
                        {
                            _invoices += _invNo + " & ";
                        }
                        else
                        {
                            _invoices += _invNo + " )";

                        }
                    }
                }
                //for (int i = dgv2.Rows.Count - 1; i <= dgv2.Rows.Count - 1; i++)
                //{
                //    _invoices += dgv2.Rows[i].Cells[0].Value.ToString() + " )";

                //}

            }
            return _invoices;
        }


        private void glkp_bank_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
                Forms.frm_Main.OpenFormByName(nameof(CTR.frm_ChequeBanks));
        }

        private void Account_Load(object sender, EventArgs e)
        {
            txtCust.Text = Account.Desc.Text;
        }

     



        private void button1_Click(object sender, EventArgs e)
        {
            Forms.frm_Main.OpenFormByName(nameof(CTR.frm_ChequeBanks));
        }

   

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;

            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                dgv1.ClearSelection();
                foreach (DataGridViewRow row in dgv1.Rows)
                {

                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        dgv1.FirstDisplayedScrollingRowIndex = row.Index;

                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty && e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (Account.ID.Text.Trim() != string.Empty)
            {
                DataTable dt_inv = dal.getDataTabl_1(@"select x.Ser_no,x.Cyear,x.Branch_code,x.Transaction_code,x.G_date,x.Acc_no,x.Acc_Branch_code,x.Payment_Type
                ,x.Inv_no,x.Inv_date,x.Po_no,x.Inv_Notes,x.NetAmount,x.K_M_Credit_TAX,B.paidAmount
                ,x.InvoiceAmount,isnull(y.returnAmount,0) as returnAmount,(x.InvoiceAmount+isnull(y.returnAmount,0) - isnull(B.paidAmount,0)) as Balance
				,p.PAYER_NAME,P.payer_l_name,p.CREDIT_AGE,P.E_MAIL,P.phone_no,P.resp_name,P.resp_name_E,P.RESP_PHONE

                from( SELECT Ser_no,Cyear,Branch_code,Transaction_code,G_date,Acc_no,Acc_Branch_code,Payment_Type
                ,Inv_no,Inv_date,Po_no,NetAmount,K_M_Credit_TAX,PanyedAmount,(NetAmount+K_M_Credit_TAX) as InvoiceAmount,Inv_Notes
                FROM  wh_inv_data  where Transaction_code ='xsd') as x

                left join (SELECT cyear,BRANCH_code,Inv_No,Inv_Transaction_Code, sum(isnull(CurrentPaid,0)) as paidAmount  FROM Sands_Details where SOURCE_CODE ='cr' group by cyear,BRANCH_code,Inv_Transaction_Code,Inv_No ) as B
                on  B.cyear = x.Cyear and B.BRANCH_code = x.BRANCH_code and B.Inv_No=x.Ser_no and B.Inv_Transaction_Code =x.Transaction_code 

                left join ( SELECT Branch_code,Acc_no,Payment_Type,Inv_no,Inv_date,sum(NetAmount) as NetAmount ,sum(K_M_Debit_TAX) as K_M_Debit_TAX,sum((isnull(NetAmount,0)- isnull(K_M_Debit_TAX,0))) as returnAmount
                FROM  wh_inv_data where Transaction_code in('xsr','xst') 
                group by  Branch_code,Acc_no,Payment_Type,Inv_no,Inv_date) as Y
                on x.Acc_no = y.Acc_no and x.Branch_code = y.Branch_code  and x.Ser_no =y.Inv_no and cast(x.G_date as date ) = cast(y.Inv_date as date ) and x.Payment_Type = y.Payment_Type
                inner join payer2 as P on P.ACC_NO = x.Acc_no and P.BRANCH_code = x.Acc_Branch_code
                where x.acc_no =  '" + Account.ID.Text + "' and x.InvoiceAmount+isnull(y.returnAmount,0)- isnull(B.paidAmount,0)<>0 order by x.G_date");

                DataSet ds = new DataSet();
                ds.Tables.Add(dt_inv);
                ////ds.WriteXmlSchema("schemaInv.xml");
                RPT.rpt_NonPaidInvoices rpt = new RPT.rpt_NonPaidInvoices();
                rpt.SetDataSource(ds);
                RPT.Form1 frm = new RPT.Form1();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();

            }


        }


        private void dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                //if (dgv2.CurrentRow.Cells[8].Value.ToString().ToDecimal() < 0)
                //{
                //    MessageBox.Show("Current Paid cannot be negative --- المبلغ المسدد لايمكن ان يكون سالب");
                //    dgv2.CurrentRow.Cells[8].Selected = true; 
                //    //return;
                //}

                if (dgv2.CurrentRow.Cells[7].Value.ToString().ToDecimal() >= dgv2.CurrentRow.Cells[8].Value.ToString().ToDecimal() || dgv2.CurrentRow.Cells[8].Value.ToString().ToDecimal() < 0)
                {
                    dgv2.CurrentRow.Cells[9].Value = (dgv2.CurrentRow.Cells[7].Value.ToString().ToDecimal() - dgv2.CurrentRow.Cells[8].Value.ToString().ToDecimal());
                    Get_Total();
                }
                else
                {
                    MessageBox.Show("Check Current Paid  --- تأكد من المبلغ المسدد");
                    dgv2.CurrentRow.Cells[8].Selected = true;
                    dgv2.BeginEdit(true);
                    dgv2.CurrentRow.Cells[8].Value = 0;
                                  

                }
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void CashAcc_Load(object sender, EventArgs e)
        {
            DataTable dt_BankData = dal.getDataTabl_1(@"select BankFeesAcc,BankVatAcc from BanksTbl where Acc_No = '" + CashAcc.ID.Text + "'");
            if (dt_BankData.Rows.Count > 0)
            {
                txtFeesAcc.ID.Text = dt_BankData.Rows[0]["BankFeesAcc"].ToString();
                txtVatAcc.ID.Text = dt_BankData.Rows[0]["BankVatAcc"].ToString();
            }
            else
            {
                txtFeesAcc.ID.Clear();
                txtVatAcc.ID.Clear();
            }
        }

        private void acc_year_Click(object sender, EventArgs e)
        {

        }
    }
}
