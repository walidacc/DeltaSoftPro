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

    public partial class frmReciptMatrail : frm_Master
    {
    
        DataTable dt_Q;
         Int32 m;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();

  
        public frmReciptMatrail()
        {

            InitializeComponent();
            //comboBox1.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            //comboBox1.SelectedItem = DateTime.Now.Year;


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


        public override void New()
        {
            this.tabControl1.Enabled = true;
            this.invGrid1.Enabled = true;
            this.pictureBox1.Visible = false;
            ClearTextBoxes();
            invGrid1.dgv1.Rows.Clear();
            invGrid1.total_inv();
            getAllSalesOrders(txtStore_ID.Text, txtSearchByAcc.Text, txtSearchByNo.Text);

            Validty_Date.Value = txt_InvDate.Value.AddDays(ValidtyDays.Value);
            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranchID.Text = Properties.Settings.Default.BranchAccID;
            AccType.Text = Properties.Settings.Default.TRANS_TO_ACC;
            txt_InvSM.Text = Program.salesman;
            userID.Text = Program.userID;
            Uc_cost.txt_Tfinl.Text = "1";
            Uc_cost.ID.Text = Program.userCostCode;

            
            Uc_Acc.branchID.Text = txtBranchID.Text;
            Uc_Acc.txtFinal.Text = "1";
            Uc_Acc.txtMainAcc.Text = dal.GetCell_1("SELECT Costmers_acc_no FROM wh_BRANCHES  where BRANCH_code='" + txtStore_ID.Text + "'").ToString();

            get_data();
            getSer();
            base.New();
        }

        public override void Refresh()
        {
            base.Refresh();
        }


        public override void Save()
        {


            try
            {
                if (invGrid1.IsGridValid() == false)
                {
                    MessageBox.Show(dal.rm.GetString("msgNoItems"), dal.rm.GetString("msgNoItems_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                }
                if(invGrid1.checkValidBalance() == false)
                {
                    MessageBox.Show(dal.rm.GetString("msgNoBalance"), dal.rm.GetString("msgNoBalance_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (invGrid1.dgv1.Rows.Count < 1)
                //{
                //    return;
                //}


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

                if (year_.Text != Properties.Settings.Default.C_year)
                {
                    MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (IsNew == true)
                {
                    //getSer();
                    add_wh_DeleveryNote_inv_data();
                }
                else
                {
                    Update_wh_DeleveryNote_inv_data();
                }

            }



            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;

            }



            base.Save();
        }


        public override void Search()
        {
            groupPanel1.Visible = true;
            groupPanel1.BringToFront();
           // comboBox1.SelectedValue = Properties.Settings.Default.C_year;
            txtSearch.Focus();

            base.Search();
        }


        public override void Print()
        {
            string printModel = Properties.Settings.Default.inv_print;
            if (printModel == "1")
            {
                RPT.rpt_DeliveryNote rpt = new RPT.rpt_DeliveryNote();
                RPT.Form1 frm = new RPT.Form1();
                DataSet ds = new DataSet();
                getDelevery(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp ");


                ds.Tables.Add(dt_Q);
                ds.Tables.Add(dt_Co);
                ds.WriteXmlSchema("schema_rpt.xml");
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
                RPT.rpt_DeliveryNote rpt = new RPT.rpt_DeliveryNote();
                RPT.Form1 frm = new RPT.Form1();
                DataSet ds = new DataSet();
                getDelevery(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                DataTable dt_Co = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp ");


                ds.Tables.Add(dt_Q);
                ds.Tables.Add(dt_Co);

                ds.WriteXmlSchema("schema_rpt.xml");
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
        private void get_data()
        {
            DataTable Dt_3 = dal.getDataTabl_1(@"SELECT B.K_M_ACC_NO_SALES , PAYER_NAME FROM wh_BRANCHES AS B right join payer2 AS P on B.K_M_ACC_NO_SALES=P.ACC_NO and B.ACC_BRANCH=P.BRANCH_code where p.BRANCH_code='" + txtStore_ID.Text + "'");
            VAT_Acc.Text = Dt_3.Rows[0][0].ToString();
            year_.Text = Properties.Settings.Default.C_year;

        }




        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            //btntype = "0";
            get_data();
            getSer();
            Uc_cost.ID.Text = Program.userCostCode;
            tabControlPanel1.Enabled = true;
            tabControlPanel2.Enabled = true;
            //groupPanel7.Enabled = true;

            ////txt_CustID.Clear();
            ////txt_CustNm.Clear();
            ////txt_custTel.Clear();
            ////txt_CustEmail.Clear();
            ////txt_InvNot.Clear();
            ////AccSer_No.Clear();
            //dt.Clear();
            //dGV_Item.DataSource = null;
            //dGV_Item.Refresh();
            //dGV_Item.Rows.Clear();


         
            txt_InvNot.Focus();

        }

        private void getSer()
        {
            string get_ser = @"iF NOT EXISTS (SELECT XVO from wh_Serial where Branch_code='"+ txtStore_ID.Text+ "' and Cyear = '" + year_.Text +
                "')BEGIN " +
                "insert into wh_Serial (Branch_code ,Cyear ) values ('A21102',23)  END" +
                " else " +
                "select isnull(Nullif(XVO,'')+1,1)  from wh_Serial where Branch_code='" + txtStore_ID.Text + "' and Cyear = '" + year_.Text +"'";

//select isnull(Nullif(XVO,'')+1,1)  from wh_Serial where Branch_code='" + txtStore_ID.Text
//                     + "' and Cyear= '"+year_.Text+"'";
            txt_InvNu.Text = dal.getDataTabl_1(get_ser).Rows[0][0].ToString();//.PadLeft(4, '0');
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (invGrid1.IsGridValid() == false)
                {
                    MessageBox.Show("فضلا.. تاكد من اختيار الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (invGrid1.flowLayoutPanel1.Controls.Count < 1)
                //{
                //    return;
                //}


                if (txtPayType.ID.Text.Trim() == "")
                {
                    MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToDecimal(invGrid1.txtNetTotal.Text) <= 0)
                {
                    MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                if (txtPayType.ID.Text == "11")
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



                add_wh_DeleveryNote_inv_data();
            
            }



            catch (System.Exception ex)
            {
               
                MessageBox.Show(ex.Message);
                return;

            }

        }



        private void add_wh_DeleveryNote_inv_data()
        {
            getSer();
            dal.open_1();
            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection =dal.sqlconn_1;
            cmd.Transaction = trans;
            try {
            cmd.CommandText = @"INSERT INTO wh_inv_data_Delevry (Ser_no, Branch_code, Transaction_code, Cyear,Sanad_no, G_date, ACC_TYPE,
            Acc_no, Acc_Branch_code, Payment_Type, Sales_man_Id, User_id, Cash_costomer_name,
            Costomer_adress, Costomer_Phone, Costmer_fax, Po_no, E_mail, TermsOfPaymentE, Validity, DelevryE, bankNo,
            K_M_ACC_NO, K_M_Credit_TAX, COSTMER_K_M_NO, KM_CODE_ACC, MAIN_KM_CODE, Costomer_Notes, OPEN_VAT, VAT_RATIO,QUOT_REF_NO,SO_no)
            values('" + txt_InvNu.Text + 
            "', '" + txtStore_ID.Text + 
            "', '" + Doc_Type.Text + 
            "', '" + year_.Text +
            "', '" + 0 + 
            "','" + txt_InvDate.Value.ToString("yyyy-MM-dd HH: mm:ss") + 
            "', '" + AccType.Text + 
            "', '" + Uc_Acc.ID.Text + 
            "', '" + txtBranchID.Text + 
            "', '" + txtPayType.ID.Text +
            "', '" + Uc_cost.ID.Text + 
            "',  '" + userID.Text + 
            "', '" + txt_attn.Text + 
            "', '" + txt_address.Text + 
            "', '" + txt_custTel.Text + 
            "', '" + txt_custFax.Text + 
            "', '" + txtPoNo.Text + 
            "', '" + txt_CustEmail.Text +
            "', '" + Convert.ToString(PaymentTearms.SelectedValue) + 
            "', '" + ValidtyDays.Text + 
            "', '" + Convert.ToString(DelevryTearms.SelectedValue) +
            "', '" + Convert.ToString(txt_Bank.SelectedValue) + 
            "', '" + VAT_Acc.Text +
            "', '" + invGrid1.txtTotalVAT.Text + 
            "', '" + Cust_Vat_No.Text + 
            "', '" + txtKmCode.Text + 
            "', '" + Vat_Class.Text + 
            "', '" + txtInvNote.Text + 
            "', '" + 0 +
            "', '" + Cust_Vat_Rate.Text + 
            "', '" + txtQoutation.Text.ParseInt(0) + 
            "', '" + txtSoNo.Text.ParseInt(0) + "')";
                cmd.ExecuteNonQuery();

                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                          && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString().ToDecimal() >0
                          && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString().ToDecimal()>0
                           )

                    {              
                        cmd.CommandText = @" INSERT INTO wh_MATERIAL_TRANSACTION_Delevry   (SER_NO, Branch_code, TRANSACTION_CODE, Cyear,SANAD_NO, ITEM_NO, QTY_TAKE,
                    G_DATE, Unit, Local_Price, USER_ID, main_counter, balance, Backege, Pice_Total_Cost, DETAILS,
                    TAX_OUT, K_M_TYPE_ITEMS)
                    values ('" + txt_InvNu.Text +
                          "', '" + txtStore_ID.Text +
                          "', '" + Doc_Type.Text +
                          "', '" + year_.Text +
                          "', '" + 0 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() +
                          "', '" + userID.Text +
                          "', '" +  invGrid1.dgv1.Rows[i].Index +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + 1 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_cost"].Value.ToString().ToDecimal() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_vat"].Value.ToString().ToDecimal() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value + "') ";
                        cmd.ExecuteNonQuery();
                    }
                }


                cmd.CommandText = @"Update wh_Serial set XVO='" + txt_InvNu.Text + "'  where Branch_code='" + txtStore_ID.Text
                     + "' and Cyear= '" + year_.Text + "' ";
                cmd.ExecuteNonQuery();

                trans.Commit();
                MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);


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


        private void Update_wh_DeleveryNote_inv_data()
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
                cmd.CommandText = "delete from wh_MATERIAL_TRANSACTION_Delevry where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                "' and TRANSACTION_CODE = '" + Doc_Type.Text + "' and Cyear = '" + year_.Text + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from wh_inv_data_Delevry where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                "' and TRANSACTION_CODE = '" + Doc_Type.Text + "' and Cyear = '" + year_.Text + "'";
                cmd.ExecuteNonQuery();
                //اضافة الفاتورة بعد التعديل
                cmd.CommandText = @"INSERT INTO wh_inv_data_Delevry (Ser_no, Branch_code, Transaction_code, Cyear,Sanad_no, G_date, ACC_TYPE,
            Acc_no, Acc_Branch_code, Payment_Type, Sales_man_Id, User_id, Cash_costomer_name,
            Costomer_adress, Costomer_Phone, Costmer_fax, Po_no, E_mail, TermsOfPaymentE, Validity, DelevryE, bankNo,
            K_M_ACC_NO, K_M_Credit_TAX, COSTMER_K_M_NO, KM_CODE_ACC, MAIN_KM_CODE, Costomer_Notes, OPEN_VAT, VAT_RATIO,QUOT_REF_NO,SO_no)
            values('" + txt_InvNu.Text +
            "', '" + txtStore_ID.Text +
            "', '" + Doc_Type.Text +
            "', '" + year_.Text +
            "', '" + 0 +
            "','" + txt_InvDate.Value.ToString("yyyy-MM-dd HH: mm:ss") +
            "', '" + AccType.Text +
            "', '" + Uc_Acc.ID.Text +
            "', '" + txtBranchID.Text +
            "', '" + txtPayType.ID.Text +
            "', '" + Uc_cost.ID.Text +
            "',  '" + userID.Text +
            "', '" + txt_attn.Text +
            "', '" + txt_address.Text +
            "', '" + txt_custTel.Text +
            "', '" + txt_custFax.Text +
            "', '" + txtPoNo.Text +
            "', '" + txt_CustEmail.Text +
            "', '" + Convert.ToString(PaymentTearms.SelectedValue) +
            "', '" + ValidtyDays.Text +
            "', '" + Convert.ToString(DelevryTearms.SelectedValue) +
            "', '" + Convert.ToString(txt_Bank.SelectedValue) +
            "', '" + VAT_Acc.Text +
            "', '" + invGrid1.txtTotalVAT.Text +
            "', '" + Cust_Vat_No.Text +
            "', '" + txtKmCode.Text +
            "', '" + Vat_Class.Text +
            "', '" + txtInvNote.Text +
            "', '" + 0 +
            "', '" + Cust_Vat_Rate.Text +
           "', '" + txtQoutation.Text.ParseInt(0) +
            "', '" + txtSoNo.Text.ParseInt(0) + "')";
                cmd.ExecuteNonQuery();

                for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                {
                    if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                          && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                          && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                           )

                    {
                        cmd.CommandText = @" INSERT INTO wh_MATERIAL_TRANSACTION_Delevry   (SER_NO, Branch_code, TRANSACTION_CODE, Cyear,SANAD_NO, ITEM_NO, QTY_TAKE,
                    G_DATE, Unit, Local_Price, USER_ID, main_counter, balance, Backege, Pice_Total_Cost, DETAILS,
                    TAX_OUT, K_M_TYPE_ITEMS)
                    values ('" + txt_InvNu.Text +
                          "', '" + txtStore_ID.Text +
                          "', '" + Doc_Type.Text +
                          "', '" + year_.Text +
                          "', '" + 0 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() +
                          "', '" + userID.Text +
                          "', '" + invGrid1.dgv1.Rows[i].Index +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                          "', '" + 1 +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_cost"].Value.ToString().ToDecimal() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_vat"].Value.ToString().ToDecimal() +
                          "', '" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value + "') ";
                        cmd.ExecuteNonQuery();
                    }
                }



                // MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                dal.close_1();
            }
        }



        private void buttonItem1_Click(object sender, EventArgs e)
        {
            string printModel = Properties.Settings.Default.inv_print;
            if (printModel == "1")
            {
                RPT.rpt_SalesOrder rpt = new RPT.rpt_SalesOrder();
                RPT.Form1 frm = new RPT.Form1();
                DataSet ds = new DataSet();
                getSalesOrder(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                ds.Tables.Add(dt_Q);
                //ds.WriteXmlSchema("schema_rpt.xml");
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
                RPT.rpt_SalesOrder rpt = new RPT.rpt_SalesOrder();
                RPT.Form1 frm = new RPT.Form1();
                DataSet ds = new DataSet();
                getSalesOrder(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
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
        }


        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }





        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
     
        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.F1)
            {
                //PL.list_H_price item_h_price = new PL.list_H_price();
                //item_h_price.dataGridView1.DataSource = dal.getDataTabl("item_H_prices_sales", TxtId.Text, txt_CustID.Text);
                //item_h_price.ShowDialog();


            }

            if (e.KeyCode == Keys.F2)
            {
               

                //PL.list_H_price item_h_price = new PL.list_H_price();
                //item_h_price.dataGridView1.DataSource = dal.getDataTabl("item_H_prices_sales", TxtId.Text,"%");
                //item_h_price.ShowDialog();



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

            cmboYear1.SelectedValue = Properties.Settings.Default.C_year;

        }

      
      

        private void txt_InvDate_ValueChanged(object sender, EventArgs e)
        {
            invGrid1.invVAtDate.Value = txt_InvDate.Value;
        }


        private void Uc_Acc_Load(object sender, EventArgs e)
        {
            //string Get_cust = @"SELECT p.ACC_NO,p.phone_no,p.fax_no,p.E_MAIL,V.MAIN_KM_CODE,p.COSTMER_K_M_NO
            //    ,p.adress,p.adress_E,p.resp_name,p.resp_name_E,p.area_code,p.b_o_box,V.MAIN_KM_DESC,V.KM_CODE 
            //        FROM PAYER2 as P 
            //        inner join KM_MAIN_ACC_CODE as V on V.MAIN_KM_CODE = isnull(P.KM_CODE_Sales,'11') 
            //        where  BRANCH_code='" + Uc_Acc.branchID.Text + "' and acc_no like '" + Uc_Acc.txtMainAcc.Text + "%' and  ACC_NO ='" + Uc_Acc.ID.Text + "'";

            string Get_cust = @"SELECT p.ACC_NO,p.phone_no,p.fax_no,p.E_MAIL,p.COSTMER_K_M_NO
                            ,p.adress,p.adress_E,p.resp_name,p.resp_name_E,p.area_code,p.b_o_box
                            FROM PAYER2 as P 
                            where  BRANCH_code='" + Uc_Acc.branchID.Text + "' and acc_no like '" + Uc_Acc.txtMainAcc.Text + "%' and  ACC_NO ='" + Uc_Acc.ID.Text + "'";

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

                txtKmCode.Text = Uc_Acc.txtKMCode.Text;
                Vat_Class.Text = Uc_Acc.KM_Code_Sales.Text;
                Vat_Class_Desc.Text = Uc_Acc.KM_Desc_Sales.Text;
                Cust_Vat_Rate.Text =  Uc_Acc.KM_Ratio_Sales.Text;
                invGrid1.txtAccVat_Rate.Text = Uc_Acc.KM_Ratio_Sales.Text; 

                if (Uc_Acc.ID.Text == dal.getDataTabl_1(@"select Cash_Costmer_Code FROM wh_BRANCHES where BRANCH_code='" + Uc_Acc.branchID.Text + "'").Rows[0][0].ToString())
                {
                    Payment_Type.SelectedValue = "11";
                    Payment_Type.Enabled = false;
                    //cashCustomer.Desc.Clear();

                }
                else
                {
                    Payment_Type.SelectedIndex = -1;
                    Payment_Type.Enabled = true;
                  //  cashCustomer.Desc.Text = dt_itme.Rows[0][7].ToString();
                }


                invGrid1.total_inv();
            }

        }



        private void BSearch_Click(object sender, EventArgs e)
        {
            groupPanel1.Visible = true;
            groupPanel1.BringToFront();
            txtSearch.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

             getDelevery(txtSearch.Text, txtStore_ID.Text, Doc_Type.Text,cmboYear1.Text);
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
                txtPoNo.Text = dt_Q.Rows[0]["po_no"].ToString();
                txtSoNo.Text = dt_Q.Rows[0]["SO_no"].ToString();
                txtQoutation.Text = dt_Q.Rows[0]["QUOT_REF_NO"].ToString();
                txt_CustEmail.Text = dt_Q.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_Q.Rows[0]["TermsOfPaymentE"].ToString();
                ValidtyDays.Value = dt_Q.Rows[0]["Validity"].ToString().ParseInt(0);
                DelevryTearms.SelectedValue = dt_Q.Rows[0]["DelevryE"].ToString();
                if (dt_Q.Rows[0]["BankNo"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_Q.Rows[0]["BID"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }
                VAT_Acc.Text = dt_Q.Rows[0]["K_M_ACC_NO"].ToString();
                Cust_Vat_No.Text = dt_Q.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_Q.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_Q.Rows[0]["MAIN_KM_CODE"].ToString();
                txt_attn.Text = dt_Q.Rows[0]["Cash_costomer_name"].ToString();
                txtInvNote.Text = dt_Q.Rows[0]["Costomer_Notes"].ToString();
                Validty_Date.Value = txt_InvDate.Value.AddDays(ValidtyDays.Value);
                txtInvNo.Text = dt_Q.Rows[0]["inv_no"].ToString();
                txtInvDate.Text = dt_Q.Rows[0]["inv_Date"].ToString();
                invGrid1.dgv1.Rows.Clear();


                int rowscount = dt_Q.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)
                    {






                        //row.Ser.Value = dt_Q.Rows[i]["main_counter"].ToString().ParseInt(0)+1;
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
                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_Q.Rows[i]["Weight"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        if (dt_Q.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                        {
                            invGrid1.dgv1.Rows[i].Cells["_tonPrice"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_Q.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                        }
                        invGrid1.dgv1.Rows[i].Cells["_total"].Value = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_Q.Rows[i]["KM_RATIO"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_Q.Rows[i]["TAX_OUT"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_Q.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_oldBalance"].Value = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");

                    }
                }
                
                invGrid1.total_inv();
                
                txtSearch.Text = "";

                groupPanel1.Visible = false;
                if (txtInvNo.Text.Trim() != "")
                {
                    this.tabControl1.Enabled= false;
                    this.invGrid1.Enabled = false;
                    this.pictureBox1.Visible = true;
                }
                else
                {
                    this.tabControl1.Enabled = true;
                    this.invGrid1.Enabled = true;
                    this.pictureBox1.Visible = false;
                }

                IsNew = false;

            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Validty_Date_ValueChanged(object sender, EventArgs e)
        {

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
                getSalesOrder(txt_InvNu.Text, txtStore_ID.Text, Doc_Type.Text, year_.Text);
                ds.Tables.Add(dt_Q);
                ////ds.WriteXmlSchema("schema_rpt.xml");
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

        private void getSalesOrder(string ser_, string branch_, string transaction_, string cyear_)
        {
           
           dt_Q = dal.getDataTabl_1(@"SELECT * FROM VIEW_Get_Sale_order AS a
           where A.Ser_no = '" + ser_ + "'  and A.Branch_code = '" + branch_ + "'  and A.transaction_code = '" + transaction_ + "'  and A.cyear = '" + cyear_ + "' and A.QTY_TAKE - A.QTY_ACT > 0 order by A.main_counter ");

        }


        private void getDelevery(string ser_, string branch_, string transaction_, string cyear_)
        {
            try
            { //, ReportDB.dbo.Tafkeet('+@4+', '''+@5+''')  from wh_Po_Cot_inv_data As A
                dt_Q = dal.getDataTabl_1(@"select a.Ser_no,A.Branch_code,A.Transaction_code,A.Cyear,A.G_date,A.Acc_no,A.Acc_Branch_code,A.Payment_Type,a.Sales_man_Id,A.User_id,A.Validity,A.TermsOfPaymentE,A.DelevryE,
                A.Costomer_adress,A.Costomer_Phone,A.Costmer_fax,A.E_mail,A.BankNo,A.PERM_SER,A.K_M_ACC_NO,A.COSTMER_K_M_NO,A.KM_CODE_ACC,A.MAIN_KM_CODE,A.Costomer_Notes,A.Cash_costomer_name,A.Costmer_no,A.QUOT_REF_NO,A.QUOT_REF_DATE,A.Po_no,A.SO_no,A.inv_no,A.inv_date,
                B.main_counter, B.ITEM_NO,M.descr,M.Descr_eng,B.DETAILS,B.Unit,M.Weight,B.QTY_TAKE,B.Local_Price,B.TAX_OUT,M.balance,B.Pice_Total_Cost,B.K_M_TYPE_ITEMS,K.KM_RATIO,B.total_disc,B.DISC_R,B.DISC_R2,B.DISC_R3,
                x.PAYER_NAME,x.payer_l_name,SP.Payment_name,SP.Notes,A.VAT_RATIO,DP.DeLEVRY_Name,DP.DELEVER_NAME_E,U.USER_NAME,BA.*,WB.Branch_Logo,WB.Branch_Logo_Small,WB.Branch_Logo_A4,WB.branch_name,WB.WH_E_NAME,cost.COST_name
                ,cost.COST_E_NAME,PT.Payment_name,PT.Payment_name_E,X.adress,X.adress_E
                from wh_inv_data_Delevry As A             
                Inner join wh_MATERIAL_TRANSACTION_Delevry As B
                on A.Ser_no = B.SER_NO and A.Branch_code = B.Branch_code AND A.Transaction_code = B.TRANSACTION_CODE AND A.Cyear = B.Cyear
                inner join wh_BRANCHES as WB on A.BRANCH_code = WB.BRANCH_code
                inner join wh_Payment_type as PT on A.Payment_Type = PT.Payment_type
                inner join wh_main_master AS M on M.item_no = B.ITEM_NO
                left join KM_MATERIAL_CODE As K on K.KM_CODE = ISNULL(NULLIF(M.KM_CODE, ''), 1)
                left join Sal_Pyment_type As SP on SP.Payment_type = A.TermsOfPaymentE
                left join WH_PO_DELEVRY_CODE As DP on DP.DeLEVRY_CODE = A.DelevryE
                inner join wh_USERS As U on U.USER_ID = A.USER_ID
                inner join  COST_CENTER as cost on cost.COST_CODE = A.Sales_man_Id
                left join BanksTbl AS BA on BA.BID = A.BankNo
               
                inner join(SELECT t1.Acc_no , t1.PREV_NO , t1.PAYER_NAME , t1.payer_l_name , t1.t_level , t1.t_final
                , t1.MAIN_NO , t1.MAIN_MEZAN , t1.BRANCH_code , t1.Acc_stoped , t1.Max_Sales_Am , t1.Credit_AGE , t1.BRANCH_name
                , t1.BRANCH_E_NAME , t1.med_MEZAN,t1.adress,t1.adress_E

                from ( select p.* ,B.BRANCH_name,B.BRANCH_E_NAME ,ROW_NUMBER() OVER(PARTITION BY p.Acc_no ORDER BY p.acc_no) AS DuplicateCount
                FROM payer2 As P inner join BRANCHS As B on P.BRANCH_code = B.BRANCH_code )  as t1

                where  DuplicateCount = 1) as X  on A.Acc_no = X.acc_no and A.Branch_code = X.Branch_code

                where A.Ser_no = '" + ser_ + "'  and A.Branch_code = '" + branch_ + "'  and A.transaction_code = '" + transaction_ + "'  and A.cyear = '" + cyear_ + "' order by B.main_counter  ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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



        private void getAllSalesOrders(string _branch, string _accName, string _ser)
        {
           

            DataTable dt_AllQ = dal.getDataTabl_1(@"select X.Acc_no, X.Ser_no, X.Branch_code, X.G_date, X.Cyear, X.Transaction_code, X.ITEM_NO, X.QTY_TAKE, X.PAYER_NAME,X.payer_l_name, X.descr,X.Descr_eng,Qty_Act,(X.QTY_TAKE-isnull(Y.Qty_Act,0)) as PoBalance
                         from (select A.Acc_no, A.Ser_no, A.Branch_code, A.G_date, A.Cyear, A.Transaction_code, B.ITEM_NO, B.QTY_TAKE, C.PAYER_NAME, ISNULL(NULLIF (C.payer_l_name, ''), C.PAYER_NAME) AS payer_l_name, D.descr, 
                         ISNULL(NULLIF (D.Descr_eng, ''), D.descr) AS Descr_eng
						 FROM            dbo.wh_Po_Cot_inv_data AS A
						 INNER JOIN  dbo.wh_Po_Cot_MATERIAL_TRANSACTION AS B ON A.Branch_code = B.Branch_code AND A.Cyear = B.Cyear AND A.Transaction_code = B.TRANSACTION_CODE AND A.Ser_no = B.SER_NO
						 INNER JOIN  dbo.payer2 AS C ON A.Acc_no = C.ACC_NO AND A.Acc_Branch_code = C.BRANCH_code
						 INNER JOIN  dbo.wh_main_master AS D ON B.ITEM_NO = D.item_no
						 where a.Transaction_code='ps'
					     GROUP BY A.Acc_no, A.Ser_no, A.Branch_code, A.G_date, A.Cyear, A.Transaction_code, B.ITEM_NO, B.QTY_TAKE, C.PAYER_NAME, C.payer_l_name, D.descr, D.Descr_eng)as X
						 Left  join   (SELECT A1.ser_no,A1.Branch_code,A1.Po_no,A1.Cyear,A1.Transaction_code,b1.ITEM_NO, SUM(B1.QTY_add) AS Qty_Act
                                 FROM  dbo.wh_inv_data AS A1 
								 INNER JOIN dbo.wh_material_transaction AS B1 ON A1.Branch_code = B1.Branch_code AND A1.Cyear = B1.Cyear AND A1.Transaction_code = B1.TRANSACTION_CODE AND A1.Ser_no = B1.SER_NO
								 where A1.Transaction_code like 'xp%'
								  group by A1.ser_no,A1.Branch_code,A1.Cyear,A1.Po_no,A1.Transaction_code,B1.ITEM_NO) as Y
								 on X.Ser_no = Y.Po_no AND Y.Branch_code = X.Branch_code AND Y.ITEM_NO = X.ITEM_NO where (X.QTY_TAKE-isnull(Y.Qty_Act,0))>0");
            dgvQuotations.Rows.Clear();


            int rowscount = dt_AllQ.Rows.Count;


            if (rowscount > 0)
            {
                dgvQuotations.Rows.Add(rowscount);
                for (int i = 0; i <= (rowscount - 1); i++)

                {
                    // dgvQuotations.Rows[i].HeaderCell.Value = dt_Q.Rows[i]["main_counter"].ToString().ParseInt(0) + 1;
                    dgvQuotations.Rows[i].Cells[_poNo.Name].Value = dt_AllQ.Rows[i]["ser_no"].ToString();
                    dgvQuotations.Rows[i].Cells[_poDate.Name].Value = Convert.ToDateTime(dt_AllQ.Rows[i]["G_date"]).ToString("dd/MM/yyyy");
                    dgvQuotations.Rows[i].Cells[_item.Name].Value = dt_AllQ.Rows[i]["item_no"].ToString();
                    dgvQuotations.Rows[i].Cells[_soQty.Name].Value = dt_AllQ.Rows[i]["QTY_TAKE"].ToString();
                    dgvQuotations.Rows[i].Cells[_doneQty.Name].Value = dt_AllQ.Rows[i]["QTY_ACT"].ToString();
                    dgvQuotations.Rows[i].Cells[_balance.Name].Value = dt_AllQ.Rows[i]["QTY_TAKE"].ToString().ToDecimal()- dt_AllQ.Rows[i]["QTY_ACT"].ToString().ToDecimal();
                    dgvQuotations.Rows[i].Cells[_branchCode.Name].Value = dt_AllQ.Rows[i]["Branch_code"].ToString();
                    dgvQuotations.Rows[i].Cells[_transaction.Name].Value = dt_AllQ.Rows[i]["Transaction_code"].ToString();
                    dgvQuotations.Rows[i].Cells[_year.Name].Value = dt_AllQ.Rows[i]["Cyear"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        dgvQuotations.Rows[i].Cells[_itemDesc.Name].Value = dt_AllQ.Rows[i]["Descr"].ToString();
                    }
                    else
                    {
                        dgvQuotations.Rows[i].Cells[_itemDesc.Name].Value = dt_AllQ.Rows[i]["Descr_eng"].ToString();
                    }





                    //dgvQuotations.DataSource = dt_AllQ;
                }
            }
        }




        private void Cust_Vat_Rate_TextChanged(object sender, EventArgs e)
        {
            invGrid1.txtAccVat_Rate.Text = Cust_Vat_Rate.Text;
        }

  
    

        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            getAllSalesOrders(txtStore_ID.Text, txtSearchByAcc.Text, txtSearchByNo.Text);
            btnSearch.Visible = true;
             btnPrint.Visible = true;
           invGrid1.qtyOnly= true;
            invGrid1.checkBalance = true;
        }

        private void txtSearchByAcc_KeyUp(object sender, KeyEventArgs e)
        {
            getAllSalesOrders(txtStore_ID.Text, txtSearchByAcc.Text, txtSearchByNo.Text);
        }

        private void txtSearchByNo_KeyUp(object sender, KeyEventArgs e)
        {
            getAllSalesOrders(txtStore_ID.Text, txtSearchByAcc.Text, txtSearchByNo.Text);
        }

        private void dgvQuotations_DoubleClick(object sender, EventArgs e)
        {
            int ii = dgvQuotations.CurrentCell.RowIndex;

           
            getSalesOrder(dgvQuotations.Rows[ii].Cells["_soNo"].Value.ToString(), dgvQuotations.Rows[ii].Cells["_branchCode"].Value.ToString(), dgvQuotations.Rows[ii].Cells["_transaction"].Value.ToString(), dgvQuotations.Rows[ii].Cells["_year"].Value.ToString());

            if (dt_Q.Rows.Count > 0)
            {
                txtSoNo.Text = dt_Q.Rows[0]["Ser_no"].ToString();
                txtQoutation.Text = dt_Q.Rows[0]["QUOT_REF_NO"].ToString();
                Uc_Acc.ID.Text = dt_Q.Rows[0]["Acc_no"].ToString();
                txtPayType.ID.Text = dt_Q.Rows[0]["Payment_Type"].ToString();
                Uc_cost.ID.Text = dt_Q.Rows[0]["Sales_man_Id"].ToString();
                txt_address.Text = dt_Q.Rows[0]["Costomer_adress"].ToString();
                txt_custTel.Text = dt_Q.Rows[0]["Costomer_Phone"].ToString();
                txt_custFax.Text = dt_Q.Rows[0]["Costmer_fax"].ToString();
                txtPoNo.Text = dt_Q.Rows[0]["po_no"].ToString();
                txt_CustEmail.Text = dt_Q.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_Q.Rows[0]["TermsOfPaymentE"].ToString();
                DelevryTearms.SelectedValue = dt_Q.Rows[0]["DelevryE"].ToString();
                if (dt_Q.Rows[0]["BankNo"] != DBNull.Value)
                {
                    txt_Bank.SelectedValue = dt_Q.Rows[0]["BID"].ToString();
                }
                else
                { txt_Bank.SelectedValue = 0; }
                VAT_Acc.Text = dt_Q.Rows[0]["K_M_ACC_NO"].ToString();
                Cust_Vat_No.Text = dt_Q.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_Q.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_Q.Rows[0]["MAIN_KM_CODE"].ToString();
                txtInvNote.Text = dt_Q.Rows[0]["Costomer_Notes"].ToString();
                txt_attn.Text = dt_Q.Rows[0]["Cash_costomer_name"].ToString();


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
                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()- dt_Q.Rows[i]["QTY_ACT"].ToString().ToDecimal()).ToString("N2");
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
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_Q.Rows[i]["KM_RATIO"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_vat"].Value = dt_Q.Rows[i]["TAX_OUT"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        invGrid1.dgv1.Rows[i].Cells["_discount"].Value = (dt_Q.Rows[i]["DISC_R"].ToString().ToDecimal() / 100 * invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_netValue"].Value = (invGrid1.dgv1.Rows[i].Cells["_total"].Value.ToString().ToDecimal() - invGrid1.dgv1.Rows[i].Cells["_discount"].Value.ToString().ToDecimal()).ToString("N" + dal.digits_);

                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = (dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal()- invGrid1.dgv1.Rows[i].Cells["_qty"].Value.ToString().ToDecimal()).ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_oldBalance"].Value = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = dt_Q.Rows[i]["local_cost"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_Q.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_mainBalance"].Value = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() - dt_Q.Rows[i]["QTY_ACT"].ToString().ToDecimal()).ToString("N2");
                        

                    }

                    invGrid1.total_inv();

                    txtSearch.Text = "";

                    groupPanel1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void labelX41_Click(object sender, EventArgs e)
        {

        }

        private void tabControlPanel3_Click(object sender, EventArgs e)
        {

        }

        private void dgvQuotations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void invGrid1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


     