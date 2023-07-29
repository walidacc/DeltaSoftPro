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
    public partial class frm_PurchaseOrder : frm_Master
    {
        string btntype = "0";
        string frmType = "ADD";
        Int32 m;
        DataTable dt_Q;
        //string Jor_no;
        string btn_name;
        decimal old_balance, old_cost, new_balance, new_cost;
        Dates date_ = new Dates();
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        int currencyNo = 2;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();




        public frm_PurchaseOrder()
        {

            InitializeComponent();

            if (Properties.Settings.Default.lungh == "0")
            {
                headLbl.Text = "طلب شراء";
            }
            else
            {
                headLbl.Text = "Purchase Order";
            }

            comboBox1.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            comboBox1.SelectedItem = DateTime.Now.Year;

            foreach (DataGridViewRow row in this.dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                dGV_Item.EnableHeadersVisualStyles = false;
            }

            FillComboCurrency();


            creatDattable();
            resizeDG();
            New();
            RefreshData();
        }



        public override void New()
        {
            ClearTextBoxes();
            btntype = "0";
            get_invSer();
            tabControlPanel1.Enabled = true;
            tabControlPanel2.Enabled = true;
            tabControlPanel3.Enabled = true;
            groupPanel7.Enabled = true;

            dt.Clear();
            dGV_Item.DataSource = null;
            dGV_Item.Refresh();
            dGV_Item.Rows.Clear();


            BSave.Enabled = true;
            txtBranch.Enabled = true;
            txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            GetBranchData(txtBranch.ID.Text);
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
        private void dGV_Item_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            total_inv();
        }



       


        private void حذفالسطرالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dGV_Item.Rows.RemoveAt(dGV_Item.CurrentRow.Index);
            }
            catch
            {
                return;
            }
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dGV_Item.Refresh();
            }
            catch
            {
                return;
            }
        }





        private void txt_InvNot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                //Btn_srch_cust.Focus();
            }
        }




        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            total_inv();
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

        private void Payment_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_invSer();
            total_inv();
        }

        private void paied_amount_KeyUp(object sender, KeyEventArgs e)
        {
            balance_amount.Text = (txtNetTotal.Text.ToDecimal() - paied_amount.Text.ToDecimal()).ToString();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BNew_Click(object sender, EventArgs e)
        {
            //ClearTextBoxes();
            //btntype = "0";
            //get_invSer();
            //tabControlPanel1.Enabled = true;
            //tabControlPanel2.Enabled = true;
            //tabControlPanel3.Enabled = true;
            //groupPanel7.Enabled = true;

            //dt.Clear();
            //dGV_Item.DataSource = null;
            //dGV_Item.Refresh();
            //dGV_Item.Rows.Clear();


            //BSave.Enabled = true;
            //txtBranch.Enabled = true;
            //txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            //GetBranchData(txtBranch.ID.Text);
            //txt_InvNot.Focus();
            
        }

        private void BSave_Click(object sender, EventArgs e)
        {
           
            //txtBranch.Enabled = false;
            //try
            //{

            //    if (txtBranch.ID.Text.Trim()=="")
            //    {
            //        MessageBox.Show("تأكد من اختيار الفرع", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }


            //    if (txtSupplier.ID.Text == string.Empty)
            //    {
            //        MessageBox.Show("فضلا.. تاكد من اختيار المورد ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    if (dGV_Item.Rows.Count < 1)
            //    {
            //        MessageBox.Show("فضلا.. تاكد من اختيار الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    if (txtcurrency.SelectedIndex < 0)
            //    {
            //        MessageBox.Show("فضلا.. تاكد من اختيار العملة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }


            //    if (Payment_Type.SelectedIndex < 0)
            //    {
            //        MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    if (txtNetTotal.Text.ToDecimal() <= 0)
            //    {
            //        MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    if (txt_Cyear.Text !=Properties.Settings.Default.C_year)
            //    {
            //        MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }






            //    get_invSer();

            
            //    AddInv();
            //    AddInvDetails();
              
            //    dal.Execute_1(@"UPDATE  wh_Serial SET "+ txt_transaction_code.Text+" = '" + txt_InvNu.Text + "' WHERE Branch_code = '" + txtStore_ID.Text+ "' and Cyear='" + txt_Cyear.Text+"' ");

               
            //    MessageBox.Show("تم الحفظ بنجاح", "حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //tabControlPanel1.Enabled = false;
            //    //tabControlPanel2.Enabled = false;
            //    //tabControlPanel3.Enabled = false;
            //    //groupPanel7.Enabled = false;txt
            //    BSave.Enabled = false;

            //}



            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;

            //}

        }

        private void add_wh_Po_Cot_inv_data()
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
                txtSupplier.ID.Text +"', '" + txtBranch_Id.Text +
                "', '" + Convert.ToString(Payment_Type.SelectedValue) +
                "', '" + Uc_Cost.ID.Text +
                "' , '" + userID.Text +
                "', '','" + txtSuppContact.Text +
                "','" + txt_InvNot.Text +
                "', '" + txt_address.Text +
                "', '" + txt_custTel.Text +
                "','" + txt_custFax.Text +
                "','" + txtRefrance.Text +
                "','" + txt_CustEmail.Text +
                "','" + Payment_Type.Text +
                "','" + ValidtyDays.Text +
                "','" + Convert.ToString(DelevryTearms.SelectedValue) +
                "','0','" +
                Convert.ToString(txtcurrency.SelectedValue) +
                "','1','" +
                Convert.ToString(PaymentTearms.SelectedValue) +
                "','" + userID.Text +
                "','" + Confirm_Persson.ID.Text +
                "','" + txtBranch.ID.Text +

                "','" + (chStop.Checked ? "C" : "") +
                "','" + Authorized_Persson.ID.Text +
                "', '" + txtVatAcc.ID.Text +
                "','0','" +
                Net_Vat.Text.ToDecimal() +
                "', '" + Cust_Vat_No.Text +
                "', '1','" +
                txtKmCode.Text +
                "','" + Vat_Class.Text +
                "','" + (chVAT.Checked ? "1" : "0") +
                "','" + Requst_Persson.ID.Text + "')";
                cmd.ExecuteNonQuery();


                for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                {
                    if (dGV_Item.Rows[i].Cells[0].Value != null && dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0)
                    //&& dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal() > 0)
                    {
                        cmd.CommandText = @"insert into wh_Po_Cot_MATERIAL_TRANSACTION 
                    (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO
                    ,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc
                    ,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Local_Price,FORIN_TYPE
                    ,USER_ID,main_counter,balance,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,DETAILS) 
                    values ('" + txt_InvNu.Text
                        + "', '" + txtStore_ID.Text
                        + "', '" + txt_transaction_code.Text
                        + "', '" + txt_Cyear.Text
                        + "' ,'" + txtMainSer.Text
                        + "','" + dGV_Item.Rows[i].Cells[0].Value.ToString()
                        + "' ,'0','" + dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal()
                        + "','" + dGV_Item.Rows[i].Cells[15].Value.ToString().ToDecimal()
                        + "','" + ((dGV_Item.Rows[i].Cells[9].Value.ToString().ToDecimal() / dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal()) + disc_Rate.Text.ToDecimal()) * 100
                        + "' ,'" + (dGV_Item.Rows[i].Cells[9].Value.ToString().ToDecimal() / dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal()) * 100
                        + "' ,'0','" + (disc_Rate.Text.ToDecimal()) * 100
                        + "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        + "','" + dGV_Item.Rows[i].Cells[3].Value.ToString()
                        + "' ,'" + dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal()
                        + "' , '" + Convert.ToString(txtcurrency.SelectedValue)
                        + "' , '" + userID.Text
                        + "','" + dGV_Item.Rows[i].Index
                        + "', '" + dGV_Item.Rows[i].Cells[4].Value.ToString().ToDecimal()
                        + "','" + dGV_Item.Rows[i].Cells[16].Value.ToString()
                        + "' ,'" + dGV_Item.Rows[i].Cells[12].Value.ToString().ToDecimal()
                        + "', '0','" + dGV_Item.Rows[i].Cells[2].Value.ToString() + "')";

                        cmd.ExecuteNonQuery();
                    }
                }

                cmd.CommandText = @"UPDATE wh_Serial SET PS = '" + txt_InvNu.Text + "' WHERE Branch_code = '" + txtStore_ID.Text + "' and Cyear='" + txt_Cyear.Text + "'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("تم الحفظ بنجاح", "حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                trans.Commit();

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
                "' and TRANSACTION_CODE = '" + txt_transaction_code.Text + "' and Cyear = '" + txt_Cyear.Text + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "delete from wh_Po_Cot_inv_data where SER_NO = '" + txt_InvNu.Text + "' and Branch_code = '" + txtStore_ID.Text +
                "' and TRANSACTION_CODE = '" + txt_transaction_code.Text + "' and Cyear = '" + txt_Cyear.Text + "'";
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
                "', '" + Convert.ToString(Payment_Type.SelectedValue) +
                "', '" + Uc_Cost.ID.Text +
                "' , '" + userID.Text +
                "', '','" + txtSuppContact.Text +
                "','" + txt_InvNot.Text +
                "', '" + txt_address.Text +
                "', '" + txt_custTel.Text +
                "','" + txt_custFax.Text +
                "','" + txtRefrance.Text +
                "','" + txt_CustEmail.Text +
                "','" + Payment_Type.Text +
                "','" + ValidtyDays.Text +
                "','" + Convert.ToString(DelevryTearms.SelectedValue) +
                "','0','" +
                Convert.ToString(txtcurrency.SelectedValue) +
                "','1','" +
                Convert.ToString(PaymentTearms.SelectedValue) +
                "','" + userID.Text +
                "','" + Confirm_Persson.ID.Text +
                "','" + txtBranch.ID.Text +

                "','" + (chStop.Checked ? "C" : "") +
                "','" + Authorized_Persson.ID.Text +
                "', '" + txtVatAcc.ID.Text +
                "','0','" +
                Net_Vat.Text.ToDecimal() +
                "', '" + Cust_Vat_No.Text +
                "', '1','" +
                txtKmCode.Text +
                "','" + Vat_Class.Text +
                "','" + (chVAT.Checked ? "1" : "0") +
                "','" + Requst_Persson.ID.Text + "')";
                cmd.ExecuteNonQuery();


                for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                {
                    if (dGV_Item.Rows[i].Cells[0].Value != null && dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0)
                    //&& dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal() > 0)
                    {
                        cmd.CommandText = @" insert into wh_Po_Cot_MATERIAL_TRANSACTION 
                    (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO
                    ,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc
                    ,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Local_Price,FORIN_TYPE
                    ,USER_ID,main_counter,balance,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,DETAILS) 
                    values( '" + txt_InvNu.Text
                        + "', '" + txtStore_ID.Text
                        + "', '" + txt_transaction_code.Text
                        + "', '" + txt_Cyear.Text
                        + "' ,'" + txtMainSer.Text
                        + "','" + dGV_Item.Rows[i].Cells[0].Value.ToString()
                        + "' ,'0','" + dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal()
                        + "','" + dGV_Item.Rows[i].Cells[15].Value.ToString().ToDecimal()
                        + "','" + ((dGV_Item.Rows[i].Cells[9].Value.ToString().ToDecimal() / dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal()) + disc_Rate.Text.ToDecimal()) * 100
                        + "' ,'" + (dGV_Item.Rows[i].Cells[9].Value.ToString().ToDecimal() / dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal()) * 100
                        + "' ,'0','" + (disc_Rate.Text.ToDecimal()) * 100
                        + "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        + "','" + dGV_Item.Rows[i].Cells[3].Value.ToString()
                        + "' ,'" + dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal()
                        + "' , '" + Convert.ToString(txtcurrency.SelectedValue)
                        + "' , '" + userID.Text
                        + "','" + dGV_Item.Rows[i].Index
                        + "', '" + dGV_Item.Rows[i].Cells[4].Value.ToString().ToDecimal()
                        + "','" + dGV_Item.Rows[i].Cells[16].Value.ToString()
                        + "' ,'" + dGV_Item.Rows[i].Cells[12].Value.ToString().ToDecimal()
                        + "', '0','" +dGV_Item.Rows[i].Cells[2].Value.ToString()+ "')";

                        cmd.ExecuteNonQuery();
                    }
                }

              

                MessageBox.Show("تم التعديل بنجاح", "تعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                trans.Commit();

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
            if (dGV_Item.Rows.Count < 1)
            {
                MessageBox.Show("فضلا.. تاكد من اختيار الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcurrency.SelectedIndex < 0)
            {
                MessageBox.Show("فضلا.. تاكد من اختيار العملة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (Payment_Type.SelectedIndex < 0)
            {
                MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNetTotal.Text.ToDecimal() <= 0)
            {
                MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_Cyear.Text != Properties.Settings.Default.C_year)
            {
                MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsNew == true)
            {
                //getSer();
                add_wh_Po_Cot_inv_data();
            }
            else
            {
                Update_wh_Po_Cot_inv_data();
            }


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
            ds.Tables.Add(dt_Q);
            // //ds.WriteXmlSchema("schema_rpt.xml");
            reportInv.SetDataSource(ds);

            if (NetValue.Text.ToDecimal() > 0)
            {
                ToWord toWord = new ToWord(Math.Abs(Math.Round(NetValue.Text.ToDecimal(), dal.digits_)), currencies[currencyNo]);
                reportInv.DataDefinition.FormulaFields["towords_"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";
            }
            else
            {
                ToWord toWord = new ToWord(0, currencies[currencyNo]);
                reportInv.DataDefinition.FormulaFields["towords_"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

            }



            frminv.crystalReportViewer1.ReportSource = reportInv;
            frminv.ShowDialog();


            base.Print();
        }

        public override void Attachment()
        {
            Frm_uploadImage frmUpload = new Frm_uploadImage();
            frmUpload.p_id = this.txt_InvNu.Text;
            frmUpload.branchID = Properties.Settings.Default.BranchId;
            frmUpload.ShowDialog();

            base.Attachment();
        }

        private void AddInv()
        {

            //           dal.Execute_1(@"insert into wh_Po_Cot_inv_data
            //            (Ser_no,Branch_code,Transaction_code,Cyear,Sanad_no
            //            ,G_date,ACC_TYPE,Acc_no,Acc_Branch_code,Payment_Type
            //            ,Sales_man_Id,User_id,Po_Status,Cash_costomer_name,Costomer_Notes
            //            ,Costomer_adress,Costomer_Phone,Costmer_fax,Ref,E_mail
            //            ,TermsOfPayment,Validity,DelevryE,requist_no,FORIN_TYPE
            //            ,PRINTING_SECURTY
            //,TermsOfPaymentE
            //,PREPAREDby
            //,RECEVEDby
            //,TO_BRANCH

            //,CANCELED
            //,aprovedBY
            //,K_M_ACC_NO
            //,K_M_Credit_TAX
            //,K_M_Debit_TAX
            //,COSTMER_K_M_NO
            //,K_M_SER
            //,KM_CODE_ACC
            //,MAIN_KM_CODE
            //,OPEN_VAT
            //,requstedBy)
            //values
            //     ('" + txt_InvNu.Text +
            //     "', '" + txtStore_ID.Text +
            //     "', '" + txt_transaction_code.Text +
            //    "', '" + txt_Cyear.Text.ToString() +
            //    "' ,'" + txtMainSer.Text +
            //    "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
            //    "','A', '" +
            //    txtSupplier.ID.Text +
            //    "', '" + txtBranch_Id.Text +
            //    "', '" + Convert.ToString(Payment_Type.SelectedValue) +
            //    "', '" + Uc_Cost.ID.Text +
            //    "' , '" + userID.Text +
            //    "', '','" +txtSuppContact.Text +
            //    "','" + txt_InvNot.Text +
            //    "', '" + txt_address.Text +
            //    "', '" + txt_custTel.Text +
            //    "','"+txt_custFax.Text +
            //    "','"+ txtRefrance.Text +
            //    "','"+ txt_CustEmail.Text+
            //    "','"+ Payment_Type.Text+
            //    "','" + ValidtyDays.Text +
            //    "','"+ Convert.ToString(DelevryTearms.SelectedValue)+
            //    "','0','"+
            //    Convert.ToString(txtcurrency.SelectedValue)+
            //    "','1','" +
            //    Convert.ToString(PaymentTearms.SelectedValue) +
            //    "','" + userID.Text +
            //    "','" + Confirm_Persson.ID.Text +
            //    "','" +txtBranch.ID.Text +

            //    "','" + (chStop.Checked ? "C" : "") +
            //    "','"+ Authorized_Persson.ID.Text +
            //    "', '" + txtVatAcc.ID.Text + 
            //    "','0','" +
            //    Net_Vat.Text.ToDecimal() +
            //    "', '" + Cust_Vat_No.Text +
            //    "', '1','" +
            //    txtKmCode.Text +
            //    "','" + Vat_Class.Text +
            //    "','" + (chVAT.Checked ? "1" : "0") +
            //    "','"+Requst_Persson.ID.Text+"')");

        }

        private void AddInvDetails()
       {
//            for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
//            {
//                if (dGV_Item.Rows[i].Cells[0].Value != null && dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0)
//                    //&& dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal() > 0)
//                {
//                    dal.Execute_1(@" insert into wh_Po_Cot_MATERIAL_TRANSACTION 
//                    (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO
//                    ,ITEM_NO,QTY_ADD,QTY_TAKE,COST_PRICE,total_disc
//                    ,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Local_Price,FORIN_TYPE
//                    ,USER_ID,main_counter,balance,K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,DETAILS) 
//                    values( '" + txt_InvNu.Text 
//                    + "', '" + txtStore_ID.Text
//                    + "', '" + txt_transaction_code.Text 
//                    + "', '" + txt_Cyear.Text 
//                    +"' ,'" + txtMainSer.Text 
//                    + "','" + dGV_Item.Rows[i].Cells[0].Value.ToString() 
//                    + "' ,'0','" + dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() 
//                    + "','" + dGV_Item.Rows[i].Cells[15].Value.ToString().ToDecimal() 
//                    + "','" + ((dGV_Item.Rows[i].Cells[9].Value.ToString().ToDecimal()/  dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal()) + disc_Rate.Text.ToDecimal())*100 
//                    + "' ,'" + (dGV_Item.Rows[i].Cells[9].Value.ToString().ToDecimal() / dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal())*100 
//                    + "' ,'0','" + (disc_Rate.Text.ToDecimal())*100 
//                    + "', '" + txt_InvDate.Value.ToString("yyyy-MM-dd HH:mm:ss") 
//                    + "','" + dGV_Item.Rows[i].Cells[3].Value.ToString()
//                    + "' ,'" + dGV_Item.Rows[i].Cells[6].Value.ToString().ToDecimal()
//                    + "' , '" + Convert.ToString(txtcurrency.SelectedValue) 
//                    + "' , '" + userID.Text 
//                    + "','" + dGV_Item.Rows[i].Index 
//                    + "', '" + dGV_Item.Rows[i].Cells[4].Value.ToString().ToDecimal() 
//                    + "','" + dGV_Item.Rows[i].Cells[16].Value.ToString() 
//                    + "' ,'" + dGV_Item.Rows[i].Cells[12].Value.ToString().ToDecimal()
//                    + "', '0','" + dGV_Item.Rows[i].Cells[2].Value.ToString()+"')");


//                }
//            }
      }


        private void get_ItemData(string item_No)
        {
            DataTable dt = dal.getDataTabl_1(@"SELECT item_no,factory_no,descr,Descr_eng,Weight,unit,BALANCE,local_cost,isnull(NULLIF(A.KM_Code,''),1) as KM_Code
				, (select case when isnull(NULLIF(A.KM_Code,''),1) =1 then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end) as KM_RATIO
                FROM wh_main_master as A 
                inner join wh_Groups As B on A.group_code = B.group_code 
                 where item_no = '" + item_No + "' or factory_no = '" + item_No + "'");
            if (dt.Rows.Count > 0)
            {
                TxtId.Text = dt.Rows[0]["item_no"].ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    TxtDesc.Text = dt.Rows[0]["descr"].ToString();
                }
                else
                {
                    TxtDesc.Text = dt.Rows[0]["Descr_eng"].ToString();
                }
                Weight_.Text = dt.Rows[0]["Weight"].ToString().ToDecimal().ToString("N3");
                txtUnit.Text = dt.Rows[0]["unit"].ToString();
                txtBalance.Text = dt.Rows[0]["BALANCE"].ToString().ToDecimal().ToString("N1");
                txtCost.Text = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");

                VatRate.Text = dt.Rows[0]["KM_RATIO"].ToString().ToDecimal().ToString("N0");

                KM_TYPE_ITEMS.Text = dt.Rows[0]["KM_Code"].ToString();

                txtNote.Focus();


            }
            else
            {
                btn_braws.PerformClick();
            }
        }

       
        private void BSearch_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            comboBox1.SelectedItem = DateTime.Now.Year;
            txtsearch.Focus();    
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
                     
        }


        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

   
     
     
        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



       

        private void txtAcc_2_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void txtStore_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void txtStore_ID_TextChanged(object sender, EventArgs e)
        {

            

        }

        private void GetBranchData(string _branch)
        {
            DataTable dt = dal.getDataTabl_1(@"SELECT Branch_code,PUR_ACC_NO,Cash_acc_no,K_M_ACC_NO_PURCH,Suppliers_acc_no FROM wh_BRANCHES where branch_code = '" + _branch + "'");
            if (dt.Rows.Count > 0)
            {
                txtSupplier.branchID.Text= dt.Rows[0]["Branch_code"].ToString();
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

        private void tabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void TxtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRecord();
                //clculat_amount();

                //if (btntype == "0")
                //{
                    
                //        if (TxtPrice.Value <= 0)
                //        {
                //            MessageBox.Show("تأكد من السعر", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //            return;
                //        }

                //    if (ch_Doublicate.Checked == false)
                //    {

                //    for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                //        {
                //            if (dGV_Item.Rows[i].Cells[0].Value.ToString() == TxtId.Text)
                //            {
                //                    MessageBox.Show("هذا الصنف مضاف من قبل", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                return;
                //            }
                //        }
                //    }
                    
                //    addrow_new();
                //    btntype = "0";


                //}
                //else if (btntype == "1")
                //{
                //    editrow();
                //    btntype = "0";

                //}
               
            }
        }


       private void addRecord()
        {
            clculat_amount();

            if (btntype == "0")
            {

                if (TxtPrice.Value <= 0)
                {
                    MessageBox.Show("تأكد من السعر", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (ch_Doublicate.Checked == false)
                {

                    for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                    {
                        if (dGV_Item.Rows[i].Cells[0].Value.ToString() == TxtId.Text)
                        {
                            MessageBox.Show("هذا الصنف مضاف من قبل", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }

                addrow_new();
                btntype = "0";


            }
            else if (btntype == "1")
            {
                editrow();
                btntype = "0";

            }

        }


        void clculat_amount()
        {
            //try
            //{
                txt_subTOt.Text = (TxtQty.Text.ToDecimal() * TxtPrice.Text.ToDecimal()).ToString("N" + dal.digits_);
                Txtvalue.Text = (TxtQty.Text.ToDecimal() * TxtPrice.Text.ToDecimal() - TxtDisc.Text.ToDecimal()).ToString("N" + dal.digits_);

                VatValue.Text = (Txtvalue.Text.ToDecimal() * (VatRate.Text.ToDecimal()< Cust_Vat_Rate.Text.ToDecimal() ? VatRate.Text.ToDecimal(): Cust_Vat_Rate.Text.ToDecimal())/100).ToString("N" + dal.digits_);

                totWeight.Text = (TxtQty.Text.ToDecimal() * Weight_.Text.ToDecimal()).ToString("N3");
            //}
            //catch
            //{
            //    return;
            //}
        }
        void addrow_new()
        {
            DataRow r = dt.NewRow();
            r[0] = TxtId.Text;
            r[1] = TxtDesc.Text;
            r[2] = txtNote.Text;
            r[3] = txtUnit.Text;
            r[4] = Weight_.Text.ToDecimal().ToString("N3");
            r[5] = TxtQty.Text.ToDecimal().ToString("N2");
            r[6] = TxtPrice.Text.ToDecimal().ToString("N" + dal.digits_);
            r[7] = Price_ton.Text.ToDecimal().ToString("N0");
            r[8] = txt_subTOt.Text.ToDecimal().ToString("N" + dal.digits_); ;
            r[9] = TxtDisc.Text.ToDecimal().ToString("N" + dal.digits_); ;
            r[10] = Txtvalue.Text.ToDecimal().ToString("N" + dal.digits_); ;
            r[11] = VatRate.Text.ToDecimal().ToString("N2"); ;
            r[12] = VatValue.Text.ToDecimal().ToString("N" + dal.digits_); ;
            r[13] = totWeight.Text.ToDecimal().ToString("N3"); ;
            r[14] = txtBalance.Text.ToDecimal().ToString("N0"); ;
            r[15] = txtCost.Text.ToDecimal().ToString("N" + dal.digits_); ;
            r[16] = KM_TYPE_ITEMS.Text;
         

            dt.Rows.Add(r);
            dGV_Item.DataSource = dt;
            clear_texts();
            btn_braws.Focus();
            total_inv();
            resizeDG();
        }

        void editrow()
        {
            dGV_Item.Rows[m].Cells[0].Value = TxtId.Text;
            dGV_Item.Rows[m].Cells[1].Value = TxtDesc.Text;
            dGV_Item.Rows[m].Cells[2].Value = txtNote.Text;
            dGV_Item.Rows[m].Cells[3].Value = txtUnit.Text;
            dGV_Item.Rows[m].Cells[4].Value = Weight_.Text.ToDecimal().ToString("N3");
            dGV_Item.Rows[m].Cells[5].Value = TxtQty.Text.ToDecimal().ToString("N2");
            dGV_Item.Rows[m].Cells[6].Value = TxtPrice.Text.ToDecimal().ToString("N" + dal.digits_);
            dGV_Item.Rows[m].Cells[7].Value = Price_ton.Text.ToDecimal().ToString("N0");
            dGV_Item.Rows[m].Cells[8].Value = txt_subTOt.Text.ToDecimal().ToString("N" + dal.digits_);
            dGV_Item.Rows[m].Cells[9].Value = TxtDisc.Text.ToDecimal().ToString("N" + dal.digits_);
            dGV_Item.Rows[m].Cells[10].Value = Txtvalue.Text.ToDecimal().ToString("N" + dal.digits_);
            dGV_Item.Rows[m].Cells[11].Value = VatRate.Text.ToDecimal().ToString("N2");
            dGV_Item.Rows[m].Cells[12].Value = VatValue.Text.ToDecimal().ToString("N" + dal.digits_); 
            dGV_Item.Rows[m].Cells[13].Value = totWeight.Text.ToDecimal().ToString("N3");
            dGV_Item.Rows[m].Cells[14].Value = txtBalance.Text.ToDecimal().ToString("N0");
            dGV_Item.Rows[m].Cells[15].Value = txtCost.Text.ToDecimal().ToString("N" + dal.digits_);
            dGV_Item.Rows[m].Cells[16].Value = KM_TYPE_ITEMS.Text;


            total_inv();
            clear_texts();
            btn_braws.Focus();
            resizeDG();

        }



        private void total_inv()
        {

            TxtTotal.Text =
               (from DataGridViewRow row in dGV_Item.Rows
                where row.Cells[8].FormattedValue.ToString() != string.Empty
                select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
            txtDiscount_1.Text =
                (from DataGridViewRow row in dGV_Item.Rows
                 where row.Cells[9].FormattedValue.ToString() != string.Empty
                 select Convert.ToDouble(row.Cells[9].FormattedValue)).Sum().ToString();




            if (TxtTotal.Text.ToDecimal() > 0)
            {
                ////disc_Rate.Text = (txtDiscount.Text.ToDecimal() /NetValue.Text.ToDecimal()).ToString();
                disc_Rate.Text = ((txtDiscount.Text.ToDecimal() / 1.05.ToString().ToDecimal()) / (TxtTotal.Text.ToDecimal() - txtDiscount_1.Text.ToDecimal())).ToString();
                
            }
            txtNetTotal.Text = (TxtTotal.Text.ToDecimal() - txtDiscount_1.Text.ToDecimal() - (txtDiscount.Text.ToDecimal() / 1.05.ToString().ToDecimal())).ToString("N"+dal.digits_);


            for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
            {
                if (dGV_Item.Rows[i].Cells[0].Value != null && dGV_Item.Rows[i].Cells[4].Value.ToString().ToDecimal() > 0
                   && dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0)
                {
                    if (dGV_Item.Rows[i].Cells[11].Value.ToString().ToDecimal() > Cust_Vat_Rate.Text.ToDecimal())
                    {
                        dGV_Item.Rows[i].Cells[12].Value = Math.Round((dGV_Item.Rows[i].Cells[10].Value.ToString().ToDecimal() * Cust_Vat_Rate.Text.ToDecimal()/100 * (1 - disc_Rate.Text.ToDecimal())), 3);
                    }
                    else
                    {
                        dGV_Item.Rows[i].Cells[12].Value = Math.Round((dGV_Item.Rows[i].Cells[10].Value.ToString().ToDecimal() * dGV_Item.Rows[i].Cells[11].Value.ToString().ToDecimal()/100 * (1 - disc_Rate.Text.ToDecimal())), 3);
                    }
                }
            }
            Net_Vat.Text =
                (from DataGridViewRow row in dGV_Item.Rows
                 where row.Cells[12].FormattedValue.ToString() != string.Empty
                 select Convert.ToDouble(row.Cells[12].FormattedValue)).Sum().ToString("N" + dal.digits_);

            NetValue.Text = (txtNetTotal.Text.ToDecimal() + Net_Vat.Text.ToDecimal()).ToString("N" + dal.digits_);

            if (Convert.ToString(Payment_Type.SelectedValue) == "2")
            {
                paied_amount.Text = "0";
            }
            else if (Convert.ToString(Payment_Type.SelectedValue) == "11" || Convert.ToString(Payment_Type.SelectedValue) == "12")
            {
                paied_amount.Text = NetValue.Text;
            }

            balance_amount.Text = (NetValue.Text.ToDecimal() - paied_amount.Text.ToDecimal()).ToString();


        }
        void clear_texts()
        {
            TxtId.Clear();
            TxtDesc.Clear();
            txtNote.Clear();
            txtUnit.Clear();
            TxtQty.Value=0;
            TxtPrice.Value = 0;
            txt_subTOt.Clear();
            TxtDisc.Value = 0;
            Txtvalue.Clear();
            VatRate.Clear();
            VatValue.Clear();
            txtBalance.Clear();
            txtCost.Clear();

        }

        void resizeDG()
        {

            this.dGV_Item.Columns[0].Width = this.TxtId.Width;
            this.dGV_Item.Columns[1].Width = this.TxtDesc.Width;
            this.dGV_Item.Columns[2].Width = this.txtNote.Width;
            this.dGV_Item.Columns[3].Width = this.txtUnit.Width;
            this.dGV_Item.Columns[4].Width = this.Weight_.Width;
            this.dGV_Item.Columns[5].Width = this.TxtQty.Width;
            this.dGV_Item.Columns[6].Width = this.TxtPrice.Width;
            this.dGV_Item.Columns[7].Width = this.Price_ton.Width;
            this.dGV_Item.Columns[8].Width = this.txt_subTOt.Width;
            this.dGV_Item.Columns[9].Width = this.TxtDisc.Width;
            this.dGV_Item.Columns[10].Width = this.Txtvalue.Width;
            this.dGV_Item.Columns[11].Width = this.VatRate.Width;
            this.dGV_Item.Columns[12].Width = this.VatValue.Width;
            this.dGV_Item.Columns[13].Width = this.totWeight.Width;
            this.dGV_Item.Columns[14].Width = this.txtBalance.Width;
            this.dGV_Item.Columns[15].Width = this.txtCost.Width;
            //this.dGV_Item.Columns[16].Visible = false;


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
            dGV_Item.DataSource = dt;
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtQty.Value > 0)
            {

                TxtPrice.Focus();
            }
        }

        private void TxtQty_KeyUp(object sender, KeyEventArgs e)
        {
            clculat_amount();
        
        }

        private void TxtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            clculat_amount();
            //get_B_C();
        }

        private void TxtDisc_KeyUp(object sender, KeyEventArgs e)
        {
           
            clculat_amount();
            //get_B_C();
        }

        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter && TxtPrice.Text != string.Empty)
            {
                TxtDisc.Focus();
            }

            if (e.KeyCode == Keys.F1)
            {
                PL.list_H_price item_h_price = new PL.list_H_price();
                //item_h_price.dataGridView1.DataSource = dal.getDataTabl("item_H_prices_sales", TxtId.Text, txtSupplier.ID.Text);
                //item_h_price.ShowDialog();


            }

            if (e.KeyCode == Keys.F2)
            {
               

                PL.list_H_price item_h_price = new PL.list_H_price();
                //item_h_price.dataGridView1.DataSource = dal.getDataTabl("item_H_prices_sales", TxtId.Text,"%");
                //item_h_price.ShowDialog();



            }

        }

        private void TxtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtId.Text != "")
            {

                get_ItemData(TxtId.Text);
                clculat_amount();

            }
            //if (e.KeyCode == Keys.Enter && TxtId.Text != string.Empty)
            //{
            //    DataTable dt = dal.getDataTabl("get_product_name", TxtId.Text, Properties.Settings.Default.StoreID);
            //    if (dt.Rows.Count > 0)
            //    {
            //        if (Properties.Settings.Default.lungh == "0")
            //        {
            //            TxtId.Text = dt.Rows[0][0].ToString();
            //            TxtDesc.Text = dt.Rows[0][2].ToString();
            //            VatRate.Text = dt.Rows[0][13].ToString();
            //            cmb_unit.SelectedValue = dt.Rows[0][8].ToString();

            //        }
            //        else
            //        {

            //            TxtId.Text = dt.Rows[0][0].ToString();
            //            TxtDesc.Text = dt.Rows[0][3].ToString();
            //            VatRate.Text = dt.Rows[0][13].ToString();
            //            cmb_unit.SelectedValue = dt.Rows[0][8].ToString();

            //        }
            //        get_B_C();
            //        txtNote.Focus();


            //    }
            //    else
            //    {
            //        btn_braws.PerformClick();
            //    }


            //}
        }

        private void get_B_C()
        {
            string StockItem = dal.getDataTabl_1("select stock_Kind from Product_Tbl where Id_Pro='" + TxtId.Text + "'").Rows[0][0].ToString();
            if (StockItem == "01")
            {
                DataTable dt_B_c = new DataTable();
                dt_B_c = dal.getDataTabl("getBalnceAndCost", TxtId.Text, txtStore_ID.Text);
                if (dt_B_c.Rows.Count > 0)
                {
                    txtBalance.Text = dt_B_c.Rows[0][0].ToString().ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
                    txtCost.Text = dt_B_c.Rows[0][1].ToString().ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
                    old_balance = Convert.ToDecimal(dt_B_c.Rows[0][0].ToString().ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_));
                    old_cost = Convert.ToDecimal(dt_B_c.Rows[0][1].ToString().ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_));
                }
                else
                {
                    txtBalance.Text = "0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
                    txtCost.Text = "0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
                    old_balance = Convert.ToDecimal("0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_));
                    old_cost = Convert.ToDecimal("0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_));
                }
                new_balance = old_balance - TxtQty.Text.ToDecimal();
                new_cost = old_cost;
                txtBalance.Text = new_balance.ToString("N" + Properties.Settings.Default.digitNo_);
                txtCost.Text = new_cost.ToString("N" + Properties.Settings.Default.digitNo_);
            }
            else 
            {
                txtBalance.Text = "0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
                txtCost.Text = "0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);

            }  
        }


        private void btn_braws_Click(object sender, EventArgs e)
        {

            try
            {
                clear_texts();

                PL.frm_search_items frm = new PL.frm_search_items();
                frm.ShowDialog();
                get_ItemData(frm.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                return;
            }

            ////try
            ////{
            //clear_texts();
            //product_list_frm frm = new product_list_frm();
            //frm.ShowDialog();
            //this.TxtId.Text = frm.dGV_pro_list.CurrentRow.Cells[0].Value.ToString();
            //this.TxtDesc.Text = frm.dGV_pro_list.CurrentRow.Cells[2].Value.ToString();
            //this.txtUnit.Text = frm.dGV_pro_list.CurrentRow.Cells[8].Value.ToString();
            //this.VatRate.Text = frm.dGV_pro_list.CurrentRow.Cells[11].Value.ToString();
            
            //get_B_C();
            //txtNote.Focus();
           
        }

        private void dGV_Item_DoubleClick(object sender, EventArgs e)
        {

            btntype = "1";
            m = dGV_Item.CurrentRow.Index;
            //try
            //{
                //DataTable itemdata_ = dal.getDataTabl("get_product_name", dGV_Item.CurrentRow.Cells[0].Value.ToString(), Properties.Settings.Default.CoId);
                TxtId.Text = dGV_Item.CurrentRow.Cells[0].Value.ToString();
                TxtDesc.Text = dGV_Item.CurrentRow.Cells[1].Value.ToString();
                txtNote.Text = dGV_Item.CurrentRow.Cells[2].Value.ToString();
                txtUnit.Text = dGV_Item.CurrentRow.Cells[3].Value.ToString();
                Weight_.Text = dGV_Item.CurrentRow.Cells[4].Value.ToString();
                TxtQty.Text = dGV_Item.CurrentRow.Cells[5].Value.ToString();
                TxtPrice.Text = dGV_Item.CurrentRow.Cells[6].Value.ToString();
                Price_ton.Text = dGV_Item.CurrentRow.Cells[7].Value.ToString().ToDecimal().ToString("N0");
                txt_subTOt.Text = dGV_Item.CurrentRow.Cells[8].Value.ToString();
                TxtDisc.Text = dGV_Item.CurrentRow.Cells[9].Value.ToString().ToDecimal().ToString("N"+dal.digits_); ;
                Txtvalue.Text = dGV_Item.CurrentRow.Cells[10].Value.ToString();
                VatRate.Text = dGV_Item.CurrentRow.Cells[11].Value.ToString();
                VatValue.Text = dGV_Item.CurrentRow.Cells[12].Value.ToString();
                totWeight.Text = dGV_Item.CurrentRow.Cells[13].Value.ToString();
                txtBalance.Text = dGV_Item.CurrentRow.Cells[14].Value.ToString();
                txtCost.Text = dGV_Item.CurrentRow.Cells[15].Value.ToString();
                KM_TYPE_ITEMS.Text = dGV_Item.CurrentRow.Cells[16].Value.ToString();
                TxtId.Focus();
            //}
            //catch
            //{
            //    return;
            //}
        }


        private void txtNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TxtQty.Focus();
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

        private void frm_PurchaseOrder_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
             btnPrint.Visible = true;

            Ch_Aprrove.Enabled = Session.UserSettings.General.CanChangeStore;

            PaymentTearms.DataSource = dal.getDataTabl_1("select Payment_type,Payment_name,Notes from Sal_Pyment_type");
            PaymentTearms.ValueMember = "Payment_type";
           

            DelevryTearms.DataSource = dal.getDataTabl_1("select DeLEVRY_CODE ,DeLEVRY_Name,DELEVER_NAME_E from WH_PO_DELEVRY_CODE");
            DelevryTearms.ValueMember = "DeLEVRY_CODE";
            if (Properties.Settings.Default.lungh=="0")
            {
            DelevryTearms.DisplayMember = "DeLEVRY_Name";
            PaymentTearms.DisplayMember = "Payment_name";
            }
            else
            {
                DelevryTearms.DisplayMember = "DELEVER_NAME_E";
                PaymentTearms.DisplayMember = "Notes";
            }
            PaymentTearms.SelectedIndex = -1;
            DelevryTearms.SelectedIndex = -1;



            txt_InvSM.Text = Program.salesman;
            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            txtBranch_Id.Text = Properties.Settings.Default.BranchAccID;
            userID.Text = Program.userID;
            txt_Cyear.Text = Properties.Settings.Default.C_year;

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

            



            get_invSer();
            txtSupplier.txtMainAcc.Text = "234";
            txtSupplier.txtFinal.Text = "1";

            GetBranchData(txtBranch.ID.Text);

        }

        private void Uc_Customer_Load(object sender, EventArgs e)
        {

            DataTable dt_M = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no FROM wh_BRANCHES where BRANCH_code like '"+txtBranch_Id.Text+"%'");
            if (dt_M.Rows.Count > 0)
            {
                string Acc_main = dt_M.Rows[0]["Suppliers_acc_no"].ToString();
                string Acc_cash = dt_M.Rows[0]["Cash_acc_no"].ToString();
                DataTable dt_cust = dal.getDataTabl_1(@"select 
                                p.phone_no      
                                ,P.adress        
                                ,fax_no        
                                ,p.E_MAIL        
                                ,p.b_o_box       
                                ,p.area_code     
                                ,p.COSTMER_K_M_NO
                                FROM payer2 As P
                                 where P.BRANCH_code like '" + txtBranch.txtAccBranch.Text + "%' and P.ACC_NO = '" + txtSupplier.ID.Text + "' and(P.ACC_NO like '" + Acc_main + "%' or P.ACC_NO like '" + Acc_cash + "%') and P.t_final ='1'");
            //    txtBranch_Id.Text = Properties.Settings.Default.BranchId;
                if (dt_cust.Rows.Count > 0)
                {
                    if (txtSupplier.ID.Text == Acc_cash)
                    {

                        Payment_Type.SelectedValue = "11";
                        Payment_Type.Enabled = false;

                        //    inv_Grid1.txtAccVat_Rate.Text = txtSupplier.KM_Ratio_Purch.Text;

                    }
                    else
                    {

                        Payment_Type.SelectedValue = "2";
                        Payment_Type.Enabled = true;


                    }

                    txt_custTel.Text = dt_cust.Rows[0]["phone_no"].ToString();
                    txt_address.Text = dt_cust.Rows[0]["adress"].ToString();
                    txt_custFax.Text = dt_cust.Rows[0]["fax_no"].ToString();
                    txt_CustEmail.Text = dt_cust.Rows[0]["E_MAIL"].ToString();
                    txt_BoBox.Text = dt_cust.Rows[0]["b_o_box"].ToString();
                    txt_area_code.Text = dt_cust.Rows[0]["area_code"].ToString();
                    Cust_Vat_No.Text = dt_cust.Rows[0]["COSTMER_K_M_NO"].ToString();

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


                }
                total_inv();
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

      

     
       
        private void Btn_DelRow_Click(object sender, EventArgs e)
        {
            if (this.dGV_Item.SelectedRows.Count > 0)
            {
                dGV_Item.Rows.RemoveAt(this.dGV_Item.SelectedRows[0].Index);
                total_inv();
                foreach (DataGridViewRow row in this.dGV_Item.Rows)
                {
                    row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BEdit_Click(object sender, EventArgs e)
        {

            if (Ch_Aprrove.Checked == true)
            {
                MessageBox.Show("يجب الغاء الموافقة علي الطلب قبل التعديل");
                return;
            }


            //try
            //{
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
                if (dGV_Item.Rows.Count < 1)
                {
                    MessageBox.Show("فضلا.. تاكد من اختيار الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtcurrency.SelectedIndex < 0)
                {
                    MessageBox.Show("فضلا.. تاكد من اختيار العملة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (Payment_Type.SelectedIndex < 0)
                {
                    MessageBox.Show("فضلا.. تاكد من نوع الفاتورة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNetTotal.Text.ToDecimal() <= 0)
                {
                    MessageBox.Show("لايمكن حفظ فاتورة بقيمة اقل من او يساوي صفر", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_Cyear.Text != Properties.Settings.Default.C_year)
                {
                    MessageBox.Show("لايمكن الحفظ في سنوات سابقة", "خطأ !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


 
            dal.Execute_1(@"Delete from wh_Po_Cot_MATERIAL_TRANSACTION  where Ser_no ='"+ txt_InvNu.Text+ "' and Branch_code ='" + txtStore_ID.Text + "' and Cyear='"+txt_Cyear.Text+"' and Transaction_code ='PS'");
            dal.Execute_1(@"Delete from wh_Po_Cot_inv_data where Ser_no ='" + txt_InvNu.Text + "' and Branch_code ='"+txtStore_ID.Text+ "' and Cyear='" + txt_Cyear.Text + "' and Transaction_code ='PS'");
            AddInv();
            AddInvDetails();

        
            MessageBox.Show("تم الحفظ بنجاح", "حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            BSave.Enabled = false;
        //}



        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;

        //    }

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

        private void groupPanel6_Click(object sender, EventArgs e)
        {

        }

        private void Ch_Aprrove_CheckedChanged(object sender, EventArgs e)
        {
            if (Ch_Aprrove.Checked)
            {
                Ch_Aprrove.BackColor = Color.Green;
            }
            else
            {
                Ch_Aprrove.BackColor = Color.Transparent;
            }
        }

      
        private void btn_UpdateApproved_Click(object sender, EventArgs e)
        {
            dal.Execute_1(@"update wh_Po_Cot_inv_data set Confermed ='" + (Ch_Aprrove.Checked ? "1" : "0") + "',ConfermedBy='" + Program.userID + "' where Ser_no ='" + txt_InvNu.Text + "' and Branch_code ='" + txtStore_ID.Text + "' and Cyear='" + txt_Cyear.Text + "' and Transaction_code ='PS'");
            txtAprovedPy.Text= Program.salesman;
        }

        private void chVAT_CheckedChanged(object sender, EventArgs e)
        {
            if (chVAT.Checked == true)
            {
            VatValue.ReadOnly = false;
            }
            else
            {
                VatValue.ReadOnly = true;
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            addRecord();
        }

        private void tabControlPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtAprovedPy_Click(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Srearch_Click(object sender, EventArgs e)
        {
            frmType = "EDIT";
            txtBranch.Enabled = false;
            getQuotation(txtsearch.Text, txtStore_ID.Text, txt_transaction_code.Text, comboBox1.Text.Substring(comboBox1.Text.Length - 2));
            if (dt_Q.Rows.Count > 0)
                {
                txtBranch.ID.Text = dt_Q.Rows[0]["Branch_code"].ToString();
                txtStore_ID.Text = dt_Q.Rows[0]["Branch_code"].ToString();
                txtBranch_Id.Text = dt_Q.Rows[0]["Acc_Branch_code"].ToString();
                txtSupplier.branchID.Text = dt_Q.Rows[0]["Acc_Branch_code"].ToString();
                txt_Cyear.Text = dt_Q.Rows[0]["Cyear"].ToString();
                txt_InvDate.Text = dt_Q.Rows[0]["G_date"].ToString();
                txtSupplier.ID.Text = dt_Q.Rows[0]["Acc_no"].ToString();
                Payment_Type.SelectedValue = dt_Q.Rows[0]["Payment_Type"].ToString();
                Uc_Cost.ID.Text = dt_Q.Rows[0]["Sales_man_Id"].ToString();
                txt_address.Text = dt_Q.Rows[0]["Costomer_adress"].ToString();
                txt_custTel.Text = dt_Q.Rows[0]["Costomer_Phone"].ToString();
                txt_custFax.Text = dt_Q.Rows[0]["Costmer_fax"].ToString();
                txtRefrance.Text = dt_Q.Rows[0]["Ref"].ToString();
                txt_CustEmail.Text = dt_Q.Rows[0]["E_mail"].ToString();
                PaymentTearms.SelectedValue = dt_Q.Rows[0]["termsOfPaymentE"].ToString();
                ValidtyDays.Value = dt_Q.Rows[0]["Validity"].ToString().ParseInt(0);
                DelevryTearms.SelectedValue = dt_Q.Rows[0]["DelevryE"].ToString();
                txtVatAcc.ID.Text = dt_Q.Rows[0]["K_M_ACC_NO"].ToString();     
                Net_Vat.Text = dt_Q.Rows[0]["K_M_Credit_TAX"].ToString();
                Cust_Vat_No.Text = dt_Q.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtKmCode.Text = dt_Q.Rows[0]["KM_CODE_ACC"].ToString();
                Vat_Class.Text = dt_Q.Rows[0]["MAIN_KM_CODE"].ToString();
                txtSuppContact.Text = dt_Q.Rows[0]["Cash_costomer_name"].ToString();
                //if (dt_Q.Rows[0]["VAT_RATIO"].ToString() == string.Empty)
                //{ Cust_Vat_Rate.Text = "0.15"; }
                //else
                //{
                //    Cust_Vat_Rate.Text = dt_Q.Rows[0]["VAT_RATIO"].ToString().ToDecimal().ToString("N2");
                //}
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
                if(dt_Q.Rows[0]["CANCELED"].ToString() == "C")
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


                dt.Clear();
                    int i = 0;
                    DataRow row = null;
                    foreach (DataRow r in dt_Q.Rows)
                    {

                        row = dt.NewRow();
                        row[0] = dt_Q.Rows[i]["ITEM_NO"].ToString();
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            row[1] = dt_Q.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            row[1] = dt_Q.Rows[i]["Descr_eng"].ToString();
                        }
                        row[2] = dt_Q.Rows[i]["DETAILS"].ToString();
                        row[3] = dt_Q.Rows[i]["Unit"].ToString();
                        row[4] = dt_Q.Rows[i]["Weight"].ToString().ToDecimal().ToString("N3");
                        row[5] = dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal().ToString("N2");
                        row[6] = dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                    if (dt_Q.Rows[i]["Weight"].ToString().ToDecimal() > 0)
                    {
                        row[7] = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() / dt_Q.Rows[i]["Weight"].ToString().ToDecimal() * 1000).ToString("N0");
                    }
                        row[8] = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                        row[9] =  (dt_Q.Rows[i]["DISC_R"].ToString().ToDecimal()/100*row[8].ToString().ToDecimal()).ToString("N"+dal.digits_);
                    row[10] = (row[8].ToString().ToDecimal() - row[9].ToString().ToDecimal()).ToString("N" + dal.digits_);
                    //row[10] = (dt_Q.Rows[i]["Local_Price"].ToString().ToDecimal() * dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal()).ToString("N" + dal.digits_);
                    row[11] = dt_Q.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N0");
                        row[12] = dt_Q.Rows[i]["TAX_IN"].ToString().ToDecimal().ToString("N"+dal.digits_);
                        row[13] = (dt_Q.Rows[i]["QTY_TAKE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3"); 
                        row[14] = dt_Q.Rows[i]["BALANCE"].ToString().ToDecimal().ToString("N0");
                        row[15] = (dt_Q.Rows[i]["COST_PRICE"].ToString().ToDecimal() * dt_Q.Rows[i]["Weight"].ToString().ToDecimal()).ToString("n3");
                        row[16] = dt_Q.Rows[i]["K_M_TYPE_ITEMS"].ToString().ToDecimal().ToString("N0");


                    dt.Rows.Add(row);
                        i = i + 1;
                    }
                    dGV_Item.DataSource = dt;
                    resizeDG();
                    total_inv();
                    txtsearch.Text = "";
                    groupBox1.Visible = false;
                    BSave.Enabled = false;
                    BEdit.Enabled = true;
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
            ,A.Payment_Type,A.Sales_man_Id,A.User_id,A.Po_Status,A.Po_Expire_Date,A.Cash_costomer_name,A.Costomer_adress
            ,A.Costomer_Phone,A.Costmer_fax,A.Ref,A.E_mail,A.TermsOfPayment,A.Validity,A.DelevryE,isnull(A.FORIN_TYPE,'') as FORIN_TYPE
            ,A.K_M_ACC_NO,A.K_M_Credit_TAX,A.COSTMER_K_M_NO,A.KM_CODE_ACC,A.MAIN_KM_CODE,A.Costomer_Notes,A.VAT_RATIO,A.COMP_TAX_NO
            ,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.Unit,B.DISC_R,B.DISC_R2,B.DISC_R3,B.total_disc,B.Local_Price,B.TAX_IN,B.TAX_OUT,B.DETAILS,B.Pice_Total_Cost,isnull(NULLIF(B.K_M_TYPE_ITEMS, ''),1) as K_M_TYPE_ITEMS,B.COST_PRICE
            ,M.descr,isnull(NULLIF(M.Descr_eng,''),M.Descr) as Descr_eng,m.Weight,m.BALANCE ,K.KM_RATIO,
            SP.Payment_name,SP.Notes,
            DP.DeLEVRY_Name,DP.DELEVER_NAME_E,U.USER_NAME
			,P.PAYER_NAME,isnull(NULLIF(P.payer_l_name,''),P.PAYER_NAME) as payer_l_name,BR.LONG_ADESS_A,Br.LONG_ADESS_E,BR.ADRESS,BR.PHONE_NO,BR.FAX_NO,Br.branch_name ,br.WH_E_NAME
            ,B.DETAILS,A.aprovedBY,A.RECEVEDby,A.requstedBy
  			,C1.CAT_NAME as confirm_A ,C1.CAT_NAME_E as confirm_E
			,C2.CAT_NAME as auth_A,C2.CAT_NAME_E as auth_E
			,C3.CAT_NAME as Requst_A,C3.CAT_NAME_E as Requst_E
            ,C3.Mobile,C3.Email,co.Company_a_name,co.Company_e_name,A.Sales_man_Id,cost.COST_name,cost.COST_E_NAME
            ,A.termsOfPaymentE,A.Confermed,A.ConfermedBy,A.CANCELED
            ,(select case when isnull(NULLIF(A.KM_CODE_ACC,''),1) =1 and  (isnull(NULLIF(B.K_M_TYPE_ITEMS,''),1) =1 or B.K_M_TYPE_ITEMS ='')   then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end)  as VatRatio  " +
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
            "inner join Wh_Oiner_Comp As co on co.Company_No = BR.Company_code " +
            "Left join COST_CENTER as cost on cost.COST_CODE = A.Sales_man_Id "+
            "where A.Ser_no = '" + ser_ + "'  and A.Branch_code = '" + branch_ + "'  and A.transaction_code = '" + transaction_ + "'  and A.cyear = '" + cyear_ + "'");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }






    }
}


     