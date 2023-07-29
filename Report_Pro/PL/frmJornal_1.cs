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




namespace Report_Pro.PL
{
    public partial class frmJornal_1 : frm_Master
    {
        string savtype = "0";
        string btntype = "0";
        Int32 m;


        public DataTable dt_jor = new DataTable();
        DAL.dbDataContext sdb = new DAL.dbDataContext();
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        Dates date_ = new Dates();
        public frmJornal_1()
        {
            InitializeComponent();


            creatDattable();
            resizeDG();




            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = Properties.Settings.Default.DateFormate;
            try
            {
                DataTable dtCurrntdate_ = dal.getDataTabl_1("select FORMAT ('" + dateTimePicker1.Value.ToShortDateString() + "', 'dd/MM/yyyy', 'ar-SA' )");
                mTxt_H.Text = dtCurrntdate_.Rows[0][0].ToString();
                mTxt_H.Mask = "00/00/0000";
            }
            catch { }

            txtSer_code.Text = "X1";
            txtSanad_type.Text = "6";
            New();
            //getJorSer();

          //  savtype = "0";

        }


        public frmJornal_1(string branchCode,string serNo)
        {
            InitializeComponent();


            creatDattable();
            resizeDG();
            showDetails(branchCode, serNo);
            IsNew = false;

            //dateTimePicker1.Value = DateTime.Now;
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = Properties.Settings.Default.DateFormate;
            //try
            //{
            //    DataTable dtCurrntdate_ = dal.getDataTabl_1("select FORMAT ('" + dateTimePicker1.Value.ToShortDateString() + "', 'dd/MM/yyyy', 'ar-SA' )");
            //    mTxt_H.Text = dtCurrntdate_.Rows[0][0].ToString();
            //    mTxt_H.Mask = "00/00/0000";
            //}
            //catch { }

            //txtSer_code.Text = "X1";
            //txtSanad_type.Text = "6";
            //New();
            //getJorSer();

            //  savtype = "0";

        }

        private void get_CostDesc()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("select Cost_name  FROM COST_CENTER where COST_CODE = '" + txtCostNo.Text + "'");
                if (dt_.Rows.Count > 0)
                {
                    txtCostDesc.Text = dt_.Rows[0][0].ToString();
                }
                else
                { txtCostDesc.Text = ""; }
            }
            catch { }
        }



        private void get_CatDesc()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("SELECT CAT_NAME  FROM CATEGORY where CAT_CODE='" + txtCatNo.Text + "' ");
                if (dt_.Rows.Count > 0)
                {
                    txtCatDesc.Text = dt_.Rows[0][0].ToString();
                }
                else
                {

                    txtCatDesc.Clear();

                }
            }

            catch { }
        }






        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void dateTimeInput1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{


            //    try
            //    {

            //        DataTable dtCurrntdate_ = dal.getDataTabl("convertdate_G", dateTimePicker1.Value);
            //        mTxt_H.Text = dtCurrntdate_.Rows[0][0].ToString();
            //        mTxt_H.Mask = "00/00/0000";

            //    }


            //    catch
            //    //(Exception ex)
            //    {
            //        //MessageBox.Show(ex.Message);
            //    }

            //    mTxt_H.Focus();
            //}
        }


        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                dateTimePicker1.Text = date_.HijriToGreg(mTxt_H.Text, "");
                //    try
                //    {
                //        dateTimePicker1.Text = HijriToGreg(mTxt_H.Text);

                //        //DataTable dtCurrntdate_ = dal.getDataTabl("convertdate_h",  mTxt_H.Text);
                //        //dateTimePicker1.Text = dtCurrntdate_.Rows[0][0].ToString();

                //    }
                //    catch
                //    //(Exception ex)
                //    {
                //        //MessageBox.Show(ex.Message);
                //    }
            }
        }









        void resizeDG()
        {
            dGV_Item.Columns[0].Width = (int)(dGV_Item.Width * 0.05);// txt_Db.Width;
            dGV_Item.Columns[1].Width = (int)(dGV_Item.Width * 0.05); // txt_Cr.Width;
            dGV_Item.Columns[2].Width = (int)(dGV_Item.Width * 0.06); //txtAccNo.Width;
            dGV_Item.Columns[3].Width = (int)(dGV_Item.Width * 0.15);// txtAccName.Width;
            dGV_Item.Columns[4].Width = (int)(dGV_Item.Width * 0.18); //txt_Desc.Width;
            dGV_Item.Columns[5].Width = (int)(dGV_Item.Width * 0.04);// txtCostNo.Width;
            dGV_Item.Columns[6].Width = (int)(dGV_Item.Width * 0.09); //txtCostDesc.Width;
            dGV_Item.Columns[7].Width = (int)(dGV_Item.Width * 0.04); //txtCatNo.Width;
            dGV_Item.Columns[8].Width = (int)(dGV_Item.Width * 0.09); //txtCatDesc.Width;
            dGV_Item.Columns[9].Width = (int)(dGV_Item.Width * 0.07); //txt_Desc.Width;
            dGV_Item.Columns[10].Width = (int)(dGV_Item.Width * 0.045);// txtCostNo.Width;
            dGV_Item.Columns[11].Width = (int)(dGV_Item.Width * 0.045); //txtCostDesc.Width;
            dGV_Item.Columns[12].Width = (int)(dGV_Item.Width * 0.045); //txtCatNo.Width;
            dGV_Item.Columns[13].Width = (int)(dGV_Item.Width * 0.045); //txtCatDesc.Width;

            foreach (DataGridViewRow row in this.dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                dGV_Item.EnableHeadersVisualStyles = false;


            }
        }





        void total_inv()
        {
            totalDebit.Text =
                (from DataGridViewRow row in dGV_Item.Rows
                 where row.Cells[2].FormattedValue.ToString() != string.Empty
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[0].FormattedValue).ToString().ToDecimal()).Sum().ToString();
            totalCredit.Text =
               (from DataGridViewRow row in dGV_Item.Rows
                where row.Cells[2].FormattedValue.ToString() != string.Empty
                //select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
                select (row.Cells[1].FormattedValue).ToString().ToDecimal()).Sum().ToString();

            //  txtdiff.Text = ((Convert.ToDecimal(totalDebit.Text) - Convert.ToDecimal(totalCredit.Text)).ToString());

            if (Convert.ToDecimal(totalDebit.Text).ToString() == Convert.ToDecimal(totalCredit.Text).ToString())
            {
                pictureBox2.Image = global::Report_Pro.Properties.Resources.Ok_icon;
            }
            else
            {
                pictureBox2.Image = global::Report_Pro.Properties.Resources.Cross_icon1;

            }

        }









        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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



        private void BtnDelRow_Click(object sender, EventArgs e)
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




        void Update_M_Transaction()
        {
            string cyear = dateTimePicker1.Value.Year.ToString();

            dal.Execute("Update_M_Transaction", cyear, Properties.Settings.Default.CoId, Properties.Settings.Default.BranchId, txtSerNo.TextS.ToString(), totalDebit.Value, totalCredit.Value, dateTimePicker1.Value, mTxt_H.Text.ToString(), txtMainNote.Text.ToString(),
            Main_serNo.TextS.ToString(), txtSanad_type.Text, txtSer_code.Text, Program.userID, Main_serNo.TextS, "", "", "", "", "",
            "", "", "", "");

        }

        void Add_M_transaction()
        {
            string cyear = dateTimePicker1.Value.Year.ToString();

            dal.Execute("Add_M_transaction", cyear, Properties.Settings.Default.CoId, Properties.Settings.Default.BranchId, txtSerNo.TextS.ToString(), totalDebit.Value, totalCredit.Value, dateTimePicker1.Value, mTxt_H.Text.ToString(), txtMainNote.Text.ToString(),
            Main_serNo.TextS.ToString(), txtSanad_type.Text, txtSer_code.Text, Program.userID, Main_serNo.TextS, "", "", "", "", "",
            "", "", "", "");

        }

        void Add_D_transaction()
        {
            for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
            {
                DataGridViewRow DgRow = dGV_Item.Rows[i];
                if (dGV_Item.Rows[i].Cells[2].Value != null)
                {
                    if (dGV_Item.Rows[i].Cells[0].Value == null)
                    {
                        dGV_Item.Rows[i].Cells[0].Value = 0;
                    }

                    if (dGV_Item.Rows[i].Cells[1].Value == null)
                    {
                        dGV_Item.Rows[i].Cells[1].Value = 0;
                    }

                    dal.Execute_1(@"insert into daily_transaction (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                , meno, loh, balance, h_date, g_date
                , sanad_no, SANAD_TYPE, user_name, desc2, POASTING,notes
                , CAT_CODE, MAIN_SER_NO) Value ('" + txt_Cyear.Text + "','" + DgRow.Cells[2].Value.ToString() + "', '" +
                    Properties.Settings.Default.BranchId + "','" + txtSerNo.TextS.ToString() + "','" + Convert.ToString(DgRow.Cells[5].Value) + "','" +
                    DgRow.Cells[0].Value.ToString().ToDecimal() + "','" + DgRow.Cells[1].Value.ToString().ToDecimal() + "','" +
                    (DgRow.Cells[0].Value.ToString().ToDecimal() - DgRow.Cells[1].Value.ToString().ToDecimal()) + "','" +
                    mTxt_H.Text.ToString() + "','" +
                    dateTimePicker1.Value + "','" +
                    Main_serNo.TextS + "','" +
                    txtSanad_type.Text + "','" +
                    Program.userID + "','" +
                    dGV_Item.Rows[i].Cells[4].Value.ToString() + "','0','" +
                    txtMainNote.Text + "','" +
                    Convert.ToString(DgRow.Cells[7].Value) + "','" +
                    Main_serNo.TextS + "')");

                }

            }
        }


        void update_D_transaction()
        {
            string cyear = dateTimePicker1.Value.Year.ToString();
            dal.Execute("updatedetials", cyear, Properties.Settings.Default.CoId, Properties.Settings.Default.BranchId, txtSerNo.TextS.ToString());
        }


        void delete_D_transaction()
        {
            dal.Execute("delete_D_transaction", txt_Cyear.Text, Properties.Settings.Default.BranchId, txtSerNo.TextS.ToString());
        }







        private void getJorSer()
        {

            JorSer.Text = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchAccID
                  + "' and ACC_YEAR= '" + txt_Cyear.Text + "'").Rows[0][0].ToString();
            txtSerNo.TextS = dal.GetCell_1("select Main_Acc_Company from Wh_Configration").ToString() + JorSer.Text.PadLeft(4, '0');
            //dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchAccID
            //  + "' and ACC_YEAR= '" + txt_Cyear.Text + "'").Rows[0][0].ToString().PadLeft(4, '0');


            Main_serNo.TextS = dal.getDataTabl_1(@"select isnull(daily_sn_ser+1,1) from serial_no where BRANCH_CODE='" + Properties.Settings.Default.BranchAccID
                 + "' and ACC_YEAR= '" + txt_Cyear.Text + "' ").Rows[0][0].ToString();//.PadLeft(4, '0');



            //int JorSer;
            //if (txtSerNo.TextS.Contains('M'))
            //{
            //    var Jor_ser = txtSerNo.TextS.Split('M');
            //    JorSer = Convert.ToInt32(Jor_ser[1]);
            //}

            //else
            //{
            //    JorSer = Convert.ToInt32(txtSerNo.Text);
            //}



        }


        private void getCloseJorSer()
        {

            this.txtSerNo.TextS = "C" + dal.getDataTabl_1(@"select isnull(max(last_ser)+1,1) from Serails_tbl where Baranch_ID='" + Properties.Settings.Default.BranchId
                     + "' and Cyear= '" + txt_Cyear.Text + "' and doc_Id =  'CENT'").Rows[0][0].ToString().PadLeft(4, '0');

            this.Main_serNo.TextS = dal.getDataTabl_1(@"select isnull(max(last_ser)+1,1) from Serails_tbl where Baranch_ID='" + Properties.Settings.Default.BranchId
                 + "' and Cyear= '" + txt_Cyear.Text + "' and doc_Id =  'CENT'").Rows[0][0].ToString();//.PadLeft(4, '0');

        }

      

        private void showDetails(string _brnch,string _ser)
        {


            ////==============================  احضار تفاصيل القيد =========================================================//
            int count_ = 0;
            DataTable dt_ = new DataTable();
            dt_.Clear();
            //dt_ = dal.getDataTabl("GetDaily_transaction", Properties.Settings.Default.BranchId, txtsearch.Text);
            dt_ = dal.getDataTabl_1(@"SELECT D.ACC_YEAR ,D.ACC_NO ,D.BRANCH_code ,D.ser_no ,D.sorting_ser ,D.COST_CENTER ,D.meno ,D.loh,D.balance 
                                    ,D.h_date ,D.g_date ,D.sanad_no,d.SANAD_TYPE,D.user_name,D.desc2,D.desc_E,D.POASTING ,D.CAT_CODE ,D.notes
                                    ,D.MAIN_SER_NO,SANAD_TYPE2,sp_ser_no,Supplier_Name,isnull(vat_amont,0) as vat_amont ,inv_no,inv_date,vat_no,P.PAYER_NAME,C.COST_name
                                    ,T.CAT_NAME,U.USER_NAME
                                    FROM daily_transaction as D
                                    inner join payer2 as P on P.ACC_NO=D.ACC_NO and P.BRANCH_code=D.BRANCH_code
                                    left join COST_CENTER  as C on C.COST_CODE=D.COST_CENTER
                                    left join CATEGORY as T on T.CAT_CODE=D.CAT_CODE
                                    inner join wh_USERS as U on U.USER_ID=D.user_name
                                    where  D.BRANCH_code='" + _brnch + "' and D.ser_no='" + _ser + "' order by sorting_ser");
            if (dt_.Rows.Count > 0)
            {
                txtSerNo.TextS = dt_.Rows[0]["ser_no"].ToString();
                mTxt_H.Text = dt_.Rows[0]["h_date"].ToString();
                dateTimePicker1.Text = dt_.Rows[0]["g_date"].ToString();
                Main_serNo.TextS = dt_.Rows[0]["MAIN_SER_NO"].ToString();
                txtSanad_type.Text = dt_.Rows[0]["SANAD_TYPE"].ToString();
                txt_sp_ser.TextS = dt_.Rows[0]["sp_ser_no"].ToString();
                txtMainNote.Text = dt_.Rows[0]["notes"].ToString();
                txt_Cyear.Text = dt_.Rows[0]["ACC_YEAR"].ToString();



                dt_jor.Clear();
                int i = 0;
                DataRow row = null;
                foreach (DataRow r in dt_.Rows)
                {

                    row = dt_jor.NewRow();
                    row[0] = Convert.ToDecimal(dt_.Rows[i]["meno"]).ToString("n" + dal.digits_);
                    row[1] = Convert.ToDecimal(dt_.Rows[i]["loh"]).ToString("n" + dal.digits_);
                    row[2] = dt_.Rows[i]["acc_no"].ToString();
                    row[3] = dt_.Rows[i]["PAYER_NAmE"].ToString();
                    row[4] = dt_.Rows[i]["desc2"].ToString();
                    row[5] = dt_.Rows[i]["COST_CENTER"].ToString();
                    row[6] = dt_.Rows[i]["COST_name"].ToString();
                    row[7] = dt_.Rows[i]["CAT_CODE"].ToString();
                    row[8] = dt_.Rows[i]["CAT_NAME"].ToString();
                    row[9]  = dt_.Rows[i]["Supplier_Name"].ToString();
                    row[10] = Convert.ToDecimal(dt_.Rows[i]["vat_amont"]).ToString("n" + dal.digits_);
                    row[11]  = dt_.Rows[i]["inv_no"].ToString();
                    row[12]  = dt_.Rows[i]["inv_date"].ToString();
                    row[13]  = dt_.Rows[i]["vat_no"].ToString();

                    //row[8] = dt_.Rows[i][7];
                    //row[9] = dt_.Rows[i][2];


                    dt_jor.Rows.Add(row);
                    i = i + 1;
                }

                dGV_Item.DataSource = dt_jor;
                resizeDG();
                total_inv();

            }


            else
            {
                MessageBox.Show(" رقم القيد غير موجود .... فضلا تأكد من الرقم ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtsearch.Focus();
                //txtsearch.SelectAll();
            }

        }



        private void GetcloseJor()
        {


            ////==============================  احضار تفاصيل القيد =========================================================//
            int count_ = 0;
            DataTable dt_ = new DataTable();
            dt_.Clear();
            dt_ = dal.getDataTabl("Get_CloseJor", date_close.MinDate, date_close.Value.Date, "", Properties.Settings.Default.BranchId, "", "1", "");
            if (dt_.Rows.Count > 0)
            {
                //txtSerNo.Text = dt_.Rows[0][3].ToString();
                //mTxt_H.Text = dt_.Rows[0][11].ToString();
                dateTimePicker1.Value = date_close.Value.Date;
                //Main_serNo.TextS = dt_.Rows[0][13].ToString();
                //txtSanad_type.Text = dt_.Rows[0][14].ToString();
                //txt_sp_ser.TextS = dt_.Rows[0][15].ToString();
                //txtMainNote.Text = dt_.Rows[0][31].ToString();
                txt_Cyear.Text = "cy";



                dt_jor.Clear();
                int i = 0;
                DataRow row = null;
                foreach (DataRow r in dt_.Rows)
                {

                    row = dt_jor.NewRow();
                    row[0] = Convert.ToDecimal(dt_.Rows[i][0]).ToString("n" + dal.digits_);
                    row[1] = Convert.ToDecimal(dt_.Rows[i][1]).ToString("n" + dal.digits_);
                    row[2] = dt_.Rows[i][2].ToString();
                    row[3] = dt_.Rows[i][3].ToString();
                    row[4] = "اقفال الرصيد";
                    row[5] = "";
                    row[6] = "";
                    row[7] = "1";
                    row[8] = "";
                    row[9] = 0;
                    row[10] = "";
                    row[11] = "";
                    row[12] = "";
                    row[13] = "";

                    //row[8] = dt_.Rows[i][7];
                    //row[9] = dt_.Rows[i][2];


                    dt_jor.Rows.Add(row);
                    i = i + 1;
                }

                dGV_Item.DataSource = dt_jor;
                resizeDG();
                total_inv();

            }


            else
            {
                MessageBox.Show(" رقم القيد غير موجود .... فضلا تأكد من الرقم ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtsearch.Focus();
                //txtsearch.SelectAll();
            }

        }



      
     




        private void BNew_Click(object sender, EventArgs e)
        {
            newJor();
        }

        private void newJor() {
            AccBranch.ID.Text = Properties.Settings.Default.BranchAccID;
            txt_docId.Text = "JOR";
            savtype = "0";
            dateTimePicker1.Value = DateTime.Now;
        //    mTxt_H.Text = date_.GregToHijri(dateTimePicker1.Text);
            //txtsearch.Clear();
            //groupBox1.Visible = false;
            txtMainNote.Clear();
            txtSerNo.TextS="";
            Main_serNo.TextS = "";
            txt_sp_ser.TextS = "";
            dt_jor.Clear();
            dGV_Item.DataSource = null;
            BSave.Enabled = true;
            getJorSer(); }


        public override void Save()
        {

            //DataTable dt_ = dal.getDataTabl_1("select ser_no,MAIN_SER_NO from daily_transaction WHERE BRANCH_code='" + Properties.Settings.Default.BranchId + "' and ser_no='" + txtSerNo.Text + "'");

            //if (dt_.Rows.Count > 0)

            total_inv();
            if (totalDebit.Value <= 0 || totalCredit.Value <= 0 || totalDebit.Value != totalCredit.Value)
            {
                MessageBox.Show("تأكد من توازن القيد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (IsNew == false)
            {
                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;
                try
                {


                    cmd.CommandText = @"Delete from daily_transaction where Ser_no = '" + txtSerNo.TextS + "' and Branch_code = '" + Properties.Settings.Default.BranchAccID + "'  and ACC_YEAR = '" + txt_Cyear.Text + "' ";
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                    {
                        DataGridViewRow DgRow = dGV_Item.Rows[i];
                        if (dGV_Item.Rows[i].Cells[2].Value != null)
                        {
                            if (dGV_Item.Rows[i].Cells[0].Value == null)
                            {
                                dGV_Item.Rows[i].Cells[0].Value = 0;
                            }

                            if (dGV_Item.Rows[i].Cells[1].Value == null)
                            {
                                dGV_Item.Rows[i].Cells[1].Value = 0;
                            }

                            cmd.CommandText = @"insert into daily_transaction 
                            (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING
                            ,notes, CAT_CODE, MAIN_SER_NO,SANAD_TYPE2,D.desc_E
                            ,Supplier_Name,vat_amont,inv_no,inv_date,vat_no) 
                            Values ('" + txt_Cyear.Text + 
                            "' , '" + DgRow.Cells[2].Value.ToString() + 
                            "' , '" + Properties.Settings.Default.BranchAccID + 
                            "' , '" + txtSerNo.TextS.ToString() + 
                            "' , '" + Convert.ToString(DgRow.Cells[5].Value) + 
                            "' , '" + DgRow.Cells[0].Value.ToString().ToDecimal() + 
                            "' , '" + DgRow.Cells[1].Value.ToString().ToDecimal() + 
                            "' , '" + (DgRow.Cells[0].Value.ToString().ToDecimal() - DgRow.Cells[1].Value.ToString().ToDecimal()) + 
                            "' , '" + mTxt_H.Text.ToString() + 
                            "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd HH: mm:ss") + 
                            "' , '" + Main_serNo.TextS + 
                            "' , '" + txtSanad_type.Text + 
                            "' , '" + Program.userID + 
                            "' , '" + dGV_Item.Rows[i].Cells[4].Value.ToString() + 
                            "' , '" + 0 + 
                            "' , '" + txtMainNote.Text + 
                            "' , '" + Convert.ToString(DgRow.Cells[7].Value) + 
                            "' , '" + Main_serNo.TextS +
                            "' , '" + txtSanad_type2.Text +
                           "' , '" + dGV_Item.Rows[i].Cells[4].Value.ToString() +
                           "' , '" + Convert.ToString(DgRow.Cells[9].Value) +
                           "' , '" + Convert.ToString(DgRow.Cells[10].Value) +
                           "' , '" + Convert.ToString(DgRow.Cells[11].Value) +
                           "' , '" + Convert.ToString(DgRow.Cells[12].Value) +
                           "' , '" + Convert.ToString(DgRow.Cells[13].Value) + "' )";

                            cmd.ExecuteNonQuery();

                        }

                    }

                    trans.Commit();
                    //                   MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            else if (IsNew == true)
            {
                getJorSer();
                for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                {
                    DataGridViewRow DgRow = dGV_Item.Rows[i];
                    if (dGV_Item.Rows[i].Cells[2].Value != null)
                    {
                        if (dGV_Item.Rows[i].Cells[0].Value == null)
                        {
                            dGV_Item.Rows[i].Cells[0].Value = 0;
                        }

                        if (dGV_Item.Rows[i].Cells[1].Value == null)
                        {
                            dGV_Item.Rows[i].Cells[1].Value = 0;
                        }


                        var daily_transaction = new DAL.daily_transaction()
                        {
                            ACC_YEAR = txt_Cyear.Text,
                            ACC_NO = DgRow.Cells[2].Value.ToString(),
                            BRANCH_code = Properties.Settings.Default.BranchAccID,
                            ser_no = txtSerNo.TextS,
                            COST_CENTER = Convert.ToString(DgRow.Cells[5].Value),
                            meno = DgRow.Cells[0].Value.ToString().ToDecimal(),
                            loh = DgRow.Cells[1].Value.ToString().ToDecimal(),
                            balance = DgRow.Cells[0].Value.ToString().ToDecimal() - DgRow.Cells[1].Value.ToString().ToDecimal(),
                            h_date = mTxt_H.Text.ToString(),
                            g_date = dateTimePicker1.Value.Date,
                            sanad_no = Main_serNo.TextS,
                            SANAD_TYPE = txtSanad_type.Text,
                            user_name = Program.userID,
                            desc2 = dGV_Item.Rows[i].Cells[4].Value.ToString(),
                            POASTING = false,
                            CAT_CODE = Convert.ToString(DgRow.Cells[7].Value),
                            MAIN_SER_NO = Convert.ToInt32(Main_serNo.TextS),
                            SANAD_TYPE2   = txtSanad_type2.Text ,
      desc_E      = dGV_Item.Rows[i].Cells[4].Value.ToString() ,
      Supplier_Name = Convert.ToString(DgRow.Cells[9].Value),
      //vat_amont     = Convert.ToString(DgRow.Cells[10].Value ,
      //inv_no        = Convert.ToString(DgRow.Cells[11].Value) ,
      //inv_date      = Convert.ToString(DgRow.Cells[12].Value ,
      //       vat_no = Convert.ToString(DgRow.Cells[13].Value ,


                    };
                        sdb.daily_transactions.InsertOnSubmit(daily_transaction);
                    }
                }
            sdb.serial_nos.Where(p => p.ACC_YEAR == txt_Cyear.Text && p.BRANCH_CODE == Properties.Settings.Default.BranchAccID)
    .ToList().ForEach(x =>
    {
        x.daily_sn_ser = Convert.ToInt32(Main_serNo.TextS);
        x.main_daily_ser = Convert.ToInt32(JorSer.Text);
        //x.BOX_ED_SER = Convert.ToInt32(txt_sandNo.TextS);
    });
        }





            //             SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            //             SqlTransaction trans;
            //             trans = dal.sqlconn_1.BeginTransaction();
            //             cmd.Connection = dal.sqlconn_1;
            //             cmd.Transaction = trans;

            //             try
            //             {



            //                 for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
            //                 {
            //                     DataGridViewRow DgRow = dGV_Item.Rows[i];
            //                     if (dGV_Item.Rows[i].Cells[2].Value != null)
            //                     {
            //                         if (dGV_Item.Rows[i].Cells[0].Value == null)
            //                         {
            //                             dGV_Item.Rows[i].Cells[0].Value = 0;
            //                         }

            //                         if (dGV_Item.Rows[i].Cells[1].Value == null)
            //                         {
            //                             dGV_Item.Rows[i].Cells[1].Value = 0;
            //                         }
            //                         getJorSer();
            //                         cmd.CommandText = @"insert into daily_transaction (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
            //                         , meno, loh, balance, h_date, g_date
            //                         , sanad_no, SANAD_TYPE, user_name, desc2, POASTING,notes
            //                         , CAT_CODE, MAIN_SER_NO) Values ('" + txt_Cyear.Text + "','" + DgRow.Cells[2].Value.ToString() + "', '" +
            //                           Properties.Settings.Default.BranchAccID + "','" + txtSerNo.TextS.ToString() + "','" + Convert.ToString(DgRow.Cells[5].Value) + "','" +
            //                          DgRow.Cells[0].Value.ToString().ToDecimal() + "','" + DgRow.Cells[1].Value.ToString().ToDecimal() + "','" +
            //                          (DgRow.Cells[0].Value.ToString().ToDecimal() - DgRow.Cells[1].Value.ToString().ToDecimal()) + "','" +
            //                          mTxt_H.Text.ToString() + "','" +
            //                          dateTimePicker1.Value.ToString("yyyy/MM/dd HH: mm:ss") + "','" +
            //                          Main_serNo.TextS + "','" +
            //                          txtSanad_type.Text + "','" +
            //                          Program.userID + "','" +
            //                          dGV_Item.Rows[i].Cells[4].Value.ToString() + "','0','" +
            //                          txtMainNote.Text + "','" +
            //                          Convert.ToString(DgRow.Cells[7].Value) + "','" +
            //                          Main_serNo.TextS + "')";

            //                         cmd.ExecuteNonQuery();


            //                     }

            //                 }

            //                 cmd.CommandText = @"UPDATE serial_no SET daily_sn_ser='" + Main_serNo.TextS + "' , main_daily_ser = '" + JorSer.Text + "' WHERE BRANCH_CODE=  '" + Properties.Settings.Default.BranchAccID + "' and ACC_YEAR='" + txt_Cyear.Text + "' ";
            //                 cmd.ExecuteNonQuery();

            //                 trans.Commit();
            ////                 MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

            //             }
            //             catch (Exception ex)
            //             {
            //                 trans.Rollback();
            //                 MessageBox.Show(ex.Message);
            //             }
            //             finally
            //             {
            //                 dal.sqlconn_1.Close();
            //             }



            sdb.SubmitChanges();
            base.Save();
        }

     

        public override void Print()
        {
            base.Print();

            RPT.Form1 frm = new RPT.Form1();

            RPT.rpt_DailyEntry rpt_DailyEntry = new RPT.rpt_DailyEntry();
            rpt_DailyEntry.SetDataSource(dal.getDataTabl_1(@"SELECT D.*,P.PAYER_NAME,C.COST_name,T.CAT_NAME,U.USER_NAME
                FROM daily_transaction as D
                inner join payer2 as P on P.ACC_NO=D.ACC_NO and P.BRANCH_code=D.BRANCH_code
                left join COST_CENTER  as C on C.COST_CODE=D.COST_CENTER
                left join CATEGORY as T on T.CAT_CODE=D.CAT_CODE
                inner join wh_USERS as U on U.USER_ID=D.user_name
                where  D.BRANCH_code='" + Properties.Settings.Default.BranchAccID + "' and D.ser_no='" + txtSerNo.TextS + "' order by sorting_ser"));

            rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + AccBranch.ID.Text + "'";
            rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + AccBranch.Desc.Text + "'";
            rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";

            frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            frm.ShowDialog();


        }


        public override void New()
        {
            resizeDG();
            newJor();
            base.New();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            DataTable dt_ = dal.getDataTabl_1("select ser_no,MAIN_SER_NO from daily_transaction WHERE BRANCH_code='" + Properties.Settings.Default.BranchId + "' and ser_no='" + txtSerNo.TextS + "'");

            if (dt_.Rows.Count > 0)
            {
                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;
                try
                {


                    cmd.CommandText = @"Delete from daily_transaction where Ser_no = '" + txtSerNo.TextS + "' and Branch_code = '" + Properties.Settings.Default.BranchAccID + "'  and ACC_YEAR = '" + txt_Cyear.Text + "' ";
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                    {
                        DataGridViewRow DgRow = dGV_Item.Rows[i];
                        if (dGV_Item.Rows[i].Cells[2].Value != null)
                        {
                            if (dGV_Item.Rows[i].Cells[0].Value == null)
                            {
                                dGV_Item.Rows[i].Cells[0].Value = 0;
                            }

                            if (dGV_Item.Rows[i].Cells[1].Value == null)
                            {
                                dGV_Item.Rows[i].Cells[1].Value = 0;
                            }

                            cmd.CommandText = @"insert into daily_transaction (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING,notes
                            , CAT_CODE, MAIN_SER_NO) Values ('" + txt_Cyear.Text + "','" + DgRow.Cells[2].Value.ToString() + "', '" +
                             Properties.Settings.Default.BranchAccID + "','" + txtSerNo.TextS.ToString() + "','" + Convert.ToString(DgRow.Cells[5].Value) + "','" +
                            DgRow.Cells[0].Value.ToString().ToDecimal() + "','" + DgRow.Cells[1].Value.ToString().ToDecimal() + "','" +
                            (DgRow.Cells[0].Value.ToString().ToDecimal() - DgRow.Cells[1].Value.ToString().ToDecimal()) + "','" +
                            mTxt_H.Text.ToString() + "','" +
                            dateTimePicker1.Value.ToString("yyyy/MM/dd HH: mm:ss") + "','" +
                            Main_serNo.TextS + "','" +
                            txtSanad_type.Text + "','" +
                            Program.userID + "','" +
                            dGV_Item.Rows[i].Cells[4].Value.ToString() + "','0','" +
                            txtMainNote.Text + "','" +
                            Convert.ToString(DgRow.Cells[7].Value) + "','" +
                            Main_serNo.TextS + "')";

                            cmd.ExecuteNonQuery();

                        }

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

            else
            {

                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;
                try
                {



                    for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                    {
                        DataGridViewRow DgRow = dGV_Item.Rows[i];
                        if (dGV_Item.Rows[i].Cells[2].Value != null)
                        {
                            if (dGV_Item.Rows[i].Cells[0].Value == null)
                            {
                                dGV_Item.Rows[i].Cells[0].Value = 0;
                            }

                            if (dGV_Item.Rows[i].Cells[1].Value == null)
                            {
                                dGV_Item.Rows[i].Cells[1].Value = 0;
                            }
                            getJorSer();

                            cmd.CommandText = @"insert into daily_transaction (ACC_YEAR,ACC_NO,BRANCH_code,ser_no,COST_CENTER
                            , meno, loh, balance, h_date, g_date
                            , sanad_no, SANAD_TYPE, user_name, desc2, POASTING,notes
                            , CAT_CODE, MAIN_SER_NO) Values ('" + txt_Cyear.Text + "','" + DgRow.Cells[2].Value.ToString() + "', '" +
                             Properties.Settings.Default.BranchAccID + "','" + txtSerNo.TextS.ToString() + "','" + Convert.ToString(DgRow.Cells[5].Value) + "','" +
                            DgRow.Cells[0].Value.ToString().ToDecimal() + "','" + DgRow.Cells[1].Value.ToString().ToDecimal() + "','" +
                            (DgRow.Cells[0].Value.ToString().ToDecimal() - DgRow.Cells[1].Value.ToString().ToDecimal()) + "','" +
                            mTxt_H.Text.ToString() + "','" +
                            dateTimePicker1.Value + "','" +
                            Main_serNo.TextS + "','" +
                            txtSanad_type.Text + "','" +
                            Program.userID + "','" +
                            dGV_Item.Rows[i].Cells[4].Value.ToString() + "','0','" +
                            txtMainNote.Text + "','" +
                            Convert.ToString(DgRow.Cells[7].Value) + "','" +
                            Main_serNo.TextS + "')";

                            cmd.ExecuteNonQuery();

                        }

                    }

                    cmd.CommandText = @"UPDATE serial_no SET daily_sn_ser='" + Main_serNo.TextS + "' , main_daily_ser = '" + txtSerNo.TextS + "' WHERE BRANCH_CODE=  '" + Properties.Settings.Default.BranchAccID + "' and ACC_YEAR='" + txt_Cyear.Text + "' ";
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

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



        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            if (savtype == "1")
            {
                total_inv();
                if (totalDebit.Value <= 0 || totalCredit.Value <= 0 || totalDebit.Value != totalCredit.Value)
                {
                    MessageBox.Show("تأكد من توازن القيد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Update_M_Transaction();
                //update_D_transaction();
                delete_D_transaction();
                Add_D_transaction();
                //dal.Execute("clear_daily_transaction_Frist");

                MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BSave.Enabled = false;
                savtype = "1";

            }

        }

        private void BtnPrint_Click_1(object sender, EventArgs e)
        {


        }

        private void get_desc()
        {
            //try
            //{
                DataTable dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name from payer2 As A 
                   where A.ACC_NO= '" + txtAccNo.Text + "'  and A.BRANCH_code = '" + AccBranch.ID.Text+ "' and A.t_final = 1 ");


                if (dt_.Rows.Count > 0)
                {
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        txtAccName.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                    }
                    else
                    {
                        txtAccName.Text = dt_.Rows[0]["payer_l_name"].ToString();
                    }
                    txt_Desc.Focus();
                }
                else
                {

                PL.frm_SearchAcc F = new frm_SearchAcc();
                F.txtbranchCode.Text = AccBranch.ID.Text;
                F.ShowDialog();
                int ii = F.DGV1.CurrentCell.RowIndex;


                txtAccNo.Text = F.DGV1.Rows[ii].Cells[0].Value.ToString();
                txtAccName.Text = F.DGV1.Rows[ii].Cells[1].Value.ToString();
                txt_Desc.Focus();


                //txtAccName.Clear();
                //    txtAccNo.Focus();
                //    txtAccNo.SelectAll();


                }
            //}
            //catch { }
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

            //try
            //{
            //    DataTable dtCurrntdate_ = dal.getDataTabl_1("select FORMAT ( '"+ dateTimePicker1.Value+"', 'dd/MM/yyyy', 'ar-SA' )" );
            //    mTxt_H.Text = dtCurrntdate_.Rows[0][0].ToString();
            //    mTxt_H.Mask = "00/00/0000";
            //}


            //catch { }

        }

        private void dGV_Item_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGV_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btntype = "0";
                //dGV_Item.Focus();
                m = dGV_Item.CurrentRow.Index;


                //try
                //{
                   //DataTable itemdata_ = dal.getDataTabl("get_product_name", dGV_Item.CurrentRow.Cells[0].Value.ToString(), Properties.Settings.Default.CoId);
                    txt_Db.Text = dGV_Item.CurrentRow.Cells[0].Value.ToString();
                    txt_Cr.Text = dGV_Item.CurrentRow.Cells[1].Value.ToString();
                    txtAccNo.Text = dGV_Item.CurrentRow.Cells[2].Value.ToString();
                    txtAccName.Text = dGV_Item.CurrentRow.Cells[3].Value.ToString();
                    txt_Desc.Text = dGV_Item.CurrentRow.Cells[4].Value.ToString();
                    txtCostNo.Text = dGV_Item.CurrentRow.Cells[5].Value.ToString();
                    txtCostDesc.Text = dGV_Item.CurrentRow.Cells[6].Value.ToString();
                    txtCatNo.Text = dGV_Item.CurrentRow.Cells[7].Value.ToString();
                    txtCatDesc.Text = dGV_Item.CurrentRow.Cells[8].Value.ToString();
                    txt_Supp.Text = dGV_Item.CurrentRow.Cells[9].Value.ToString();
                    txt_docValue.Text = dGV_Item.CurrentRow.Cells[10].Value.ToString();
                    txt_docNo.Text = dGV_Item.CurrentRow.Cells[11].Value.ToString();
                    txt_docDate.Text = dGV_Item.CurrentRow.Cells[12].Value.ToString();
                    txt_VatNo.Text = dGV_Item.CurrentRow.Cells[13].Value.ToString();
                    txt_Db.Focus();
                //}
                //catch
                //{
                //    return;
                //}



            }

        }

        private void dGV_Item_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool nonNumberEntered = true;
            char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == DecimalSeparator)
            {
                nonNumberEntered = false;
            }

            if (nonNumberEntered)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void frmJornal_Load(object sender, EventArgs e)
        {
             btnPrint.Visible = true;
                    
        }

        private void PersistentDataGridViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {

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













        private void labelX31_Click(object sender, EventArgs e)
        {

        }
        void addrow_new()
        {


            DataRow r = dt_jor.NewRow();
            r[0] = txt_Db.Text;
            r[1] = txt_Cr.Text;
            r[2] = txtAccNo.Text;
            r[3] = txtAccName.Text;
            r[4] = txt_Desc.Text;
            r[5] = txtCostNo.Text;
            r[6] = txtCostDesc.Text;
            r[7] = txtCatNo.Text;
            r[8] = txtCatDesc.Text;
            r[9] = txt_Supp.Text;
            r[10] = txt_docValue.Text;
            r[11] = txt_docNo.Text;
            r[12] = txt_docDate.Text;
            r[13] = txt_VatNo.Text;
            dt_jor.Rows.Add(r);

            dGV_Item.DataSource = dt_jor;
          //  dGV_Item.CurrentCell = dGV_Item.Rows[dGV_Item.Rows.Count - 1].Cells[0];


            clear_texts();

            total_inv();
            resizeDG();
        }

        void editrow()
        {
            dGV_Item.Rows[m].Cells[0].Value = txt_Db.Text;
            dGV_Item.Rows[m].Cells[1].Value = txt_Cr.Text;
            dGV_Item.Rows[m].Cells[2].Value = txtAccNo.Text;
            dGV_Item.Rows[m].Cells[3].Value = txtAccName.Text;
            dGV_Item.Rows[m].Cells[4].Value = txt_Desc.Text;
            dGV_Item.Rows[m].Cells[5].Value = txtCostNo.Text;
            dGV_Item.Rows[m].Cells[6].Value = txtCostDesc.Text;
            dGV_Item.Rows[m].Cells[7].Value = txtCatNo.Text;
            dGV_Item.Rows[m].Cells[8].Value = txtCatDesc.Text;
            dGV_Item.Rows[m].Cells[9].Value = txt_Supp.Text;
            dGV_Item.Rows[m].Cells[10].Value = txt_docValue.Text;
            dGV_Item.Rows[m].Cells[11].Value = txt_docNo.Text;
            dGV_Item.Rows[m].Cells[12].Value = txt_docDate.Text;
            dGV_Item.Rows[m].Cells[13].Value = txt_VatNo.Text;

            total_inv();
            clear_texts();

            resizeDG();

        }



        void clear_texts()
        {
            txt_Db.Clear();
            txt_Cr.Clear();
            txtAccNo.Clear();
            txtAccName.Clear();
            txt_Desc.Clear();
            txtCostNo.Clear();
            txtCostDesc.Clear();
            txtCatNo.Clear();
            txtCatDesc.Clear();
            txt_docValue.Value = 0;
            txt_Supp.Clear();
            txt_VatNo.Text = "";
            txt_docDate.Text = "";
            txt_docNo.Clear();

        }


        void creatDattable()
        {
            dt_jor.Columns.Add("مدين");
            dt_jor.Columns.Add(" دائن");
            dt_jor.Columns.Add(" كود الحساب");
            dt_jor.Columns.Add(" اسم الحساب");
            dt_jor.Columns.Add("البيان");
            dt_jor.Columns.Add(" كود الكلفة");
            dt_jor.Columns.Add("مركز الكلفة");
            dt_jor.Columns.Add("رقم التصنيف");
            dt_jor.Columns.Add("التصنيف");
            dt_jor.Columns.Add("المورد");
            dt_jor.Columns.Add("قيمة الفاتورة");
            dt_jor.Columns.Add("رقم الفاتورة");
            dt_jor.Columns.Add("تاريخ الفاتورة");
            dt_jor.Columns.Add("الرقم الضريبي");
            dGV_Item.DataSource = dt_jor;
            //dGV_Item.Columns[7].Visible = false;
            //dGV_Item.Columns[8].Visible = false;
           
        }

        private void labelX30_Click(object sender, EventArgs e)
        {

        }

        private void dGV_Item_DoubleClick(object sender, EventArgs e)
        {
            btntype = "1";
            m = dGV_Item.CurrentRow.Index;
            try
            {
                //DataTable itemdata_ = dal.getDataTabl("get_product_name", dGV_Item.CurrentRow.Cells[0].Value.ToString(), Properties.Settings.Default.CoId);
                txt_Db.Text = dGV_Item.CurrentRow.Cells[0].Value.ToString();
                txt_Cr.Text = dGV_Item.CurrentRow.Cells[1].Value.ToString();
                txtAccNo.Text = dGV_Item.CurrentRow.Cells[2].Value.ToString();
                txtAccName.Text = dGV_Item.CurrentRow.Cells[3].Value.ToString();
                txt_Desc.Text = dGV_Item.CurrentRow.Cells[4].Value.ToString();
                txtCostNo.Text = dGV_Item.CurrentRow.Cells[5].Value.ToString();
                txtCostDesc.Text = dGV_Item.CurrentRow.Cells[6].Value.ToString();
                txtCatNo.Text = dGV_Item.CurrentRow.Cells[7].Value.ToString();
                txtCatDesc.Text = dGV_Item.CurrentRow.Cells[8].Value.ToString();
                txt_Supp.Text = dGV_Item.CurrentRow.Cells[9].Value.ToString();
                txt_docValue.Text = dGV_Item.CurrentRow.Cells[10].Value.ToString();
                txt_docNo.Text = dGV_Item.CurrentRow.Cells[11].Value.ToString();
                txt_docDate.Text = dGV_Item.CurrentRow.Cells[12].Value.ToString();
                txt_VatNo.Text = dGV_Item.CurrentRow.Cells[13].Value.ToString();
                txt_Db.Focus();
            }
            catch
            {
                return;
            }
        }

        private void txt_accNo_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void txt_Db_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txt_Db.Text.ToDecimal() != 0)
                {
                    txt_Cr.Text = "0";
                    txt_Cr.Focus();
                }
                else
                {
                    txt_Cr.Focus();
                }

            }
        }

        private void txt_Cr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txt_Cr.Text.ToDecimal() != 0)
                {
                    txt_Db.Text = "0";
                    txtAccNo.Focus();
                }

                else
                {
                    txtAccNo.Focus();
                }

            }
        }

        private void txt_Db_KeyUp(object sender, KeyEventArgs e)
        {




        }

        private void txt_Db_Leave(object sender, EventArgs e)
        {
            if (txt_Db.Text.ToDecimal() != 0)
            {
                txt_Cr.Text = "0";

            }

        }

        private void txt_Cr_Leave(object sender, EventArgs e)
        {
            if (txt_Cr.Text.ToDecimal() != 0)
            {
                txt_Db.Text = "0";

            }

        }

        private void txt_Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCostNo.Focus();
            }
            else if (e.KeyCode == Keys.F2)
            {
                txt_Desc.Text = dGV_Item.Rows[dGV_Item.Rows.Count - 1].Cells[4].Value.ToString();
            }
        }

        private void txt_costId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_CostDesc();
                txtCatNo.Focus();
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //string V =
            //    s.Replace(" ", "").Length



            if ((txt_Db.Value > 0 || txt_Cr.Value > 0) && txtAccNo.Text != "")

            {
                total_inv();

                if (btntype == "0")
                {
                    addrow_new();
                    btntype = "0";
                    txt_Db.Focus();


                }
                else if (btntype == "1")
                {
                    editrow();
                    btntype = "0";
                    txt_Db.Focus();
                }
            }
            else
            {
                MessageBox.Show("تأكد من البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txt_Supp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_docValue.Focus();
            }
        }

        private void txt_docNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_docDate.Focus();
            }
        }

        private void txt_docDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_VatNo.Focus();
                txt_VatNo.SelectAll();
            }
        }


        private void txt_docValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_docNo.Focus();
            }
        }

        private void mTxt_H_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                DataTable dtCurrntdate_ = dal.getDataTabl("convertdate_H", mTxt_H.Text);
                dateTimePicker1.Text = dtCurrntdate_.Rows[0][0].ToString();

            }
            catch
            {

            }
        }



        private void txt_VatNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter.Focus();
            }

        }

        private void frmJornal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btntype = "0";
                dGV_Item.Focus();
                m = dGV_Item.CurrentRow.Index;

                try
                {
                    //DataTable itemdata_ = dal.getDataTabl("get_product_name", dGV_Item.CurrentRow.Cells[0].Value.ToString(), Properties.Settings.Default.CoId);
                    txt_Db.Text = dGV_Item.CurrentRow.Cells[0].Value.ToString();
                    txt_Cr.Text = dGV_Item.CurrentRow.Cells[1].Value.ToString();
                    txtAccNo.Text = dGV_Item.CurrentRow.Cells[2].Value.ToString();
                    txtAccName.Text = dGV_Item.CurrentRow.Cells[3].Value.ToString();
                    txt_Desc.Text = dGV_Item.CurrentRow.Cells[4].Value.ToString();
                    txtCostNo.Text = dGV_Item.CurrentRow.Cells[5].Value.ToString();
                    txtCostDesc.Text = dGV_Item.CurrentRow.Cells[6].Value.ToString();
                    txtCatNo.Text = dGV_Item.CurrentRow.Cells[7].Value.ToString();
                    txtCatDesc.Text = dGV_Item.CurrentRow.Cells[8].Value.ToString();
                    txt_Supp.Text = dGV_Item.CurrentRow.Cells[9].Value.ToString();
                    txt_docValue.Text = dGV_Item.CurrentRow.Cells[10].Value.ToString().ToDecimal().ToString();
                    txt_docNo.Text = dGV_Item.CurrentRow.Cells[11].Value.ToString();
                    txt_docDate.Text = dGV_Item.CurrentRow.Cells[12].Value.ToString();
                    txt_VatNo.Text = dGV_Item.CurrentRow.Cells[13].Value.ToString();

                }
                catch
                {
                    return;
                }

                txt_Db.Focus();
            }


        }



        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txt_docId.Text = "CENT";
            getCloseJorSer();
            GetcloseJor();
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void labelX28_Click(object sender, EventArgs e)
        {

        }

        private void labelX17_Click(object sender, EventArgs e)
        {

        }

        private void labelX15_Click(object sender, EventArgs e)
        {

        }

        private void txtAcc_Load(object sender, EventArgs e)
        {

        }

        private void txtAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAccNo.Text != string.Empty)
            {
                if (txtCatNo.Text == "")
                {
                    txtCatNo.Text = "1";
                }
                txt_Desc.Focus();


            }
        }

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCostNo.Text != string.Empty)
                {
                    txtCatNo.Focus();

                }

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void HD_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mTxt_H_Click(object sender, EventArgs e)
        {
            mTxt_H.Focus();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mTxt_H.Text = date_.GregToHijri(dateTimePicker1.Text);

            }
        }

     
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
          
             

            
        }

        private void txtAcc_Load_1(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void txt_Desc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAcc_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAccNo.Text.Trim() != string.Empty)
            {
                txt_Desc.Focus();
            }
        }

        private void txtCost_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCostNo.Text.Trim() != string.Empty)
            {
                txtCatNo.Focus();
            }
        }


        private void txtCatogry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_CatDesc();
                if (txtAccNo.Text.StartsWith("238"))
                {
                    txt_Supp.Focus();
                }

                else
                {
                    btnEnter.Focus();
                }

               

            }
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Cr_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelX18_Click(object sender, EventArgs e)
        {

        }

        private void txtAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_desc();
            }
        }

        private void txt_docValue_TextChanged(object sender, EventArgs e)
        {

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
            PL.frm_ChoseAccBranch frm = new frm_ChoseAccBranch();
            frm.ShowDialog();
            newJor();


        }

        private void txtAccName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Desc_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtCostDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_VatNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtAccNo_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name from payer2 As A 
                   where A.ACC_NO= '" + txtAccNo.Text + "'  and A.BRANCH_code = '" + AccBranch.ID.Text + "' and A.t_final = 1 ");


                if (dt_.Rows.Count > 0)
                {
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        txtAccName.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                    }
                    else
                    {
                        txtAccName.Text = dt_.Rows[0]["payer_l_name"].ToString();
                    }
                    txt_Desc.Focus();
                    if(txtAccNo.Text.StartsWith("238"))
                    {
                        tableLayoutPanel2.Visible = true;
                    }

                    else 
                    {
                        tableLayoutPanel2.Visible = false;
                    }
                }
                else
                {
                    txtAccNo.Clear();
                    txtAccName.Clear();
                    //txtAccNo.Focus();
                    //txtAccNo.SelectAll();
                }
            }
            catch { }
        }

        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            mTxt_H.Text = date_.GregToHijri(dateTimePicker1.Text);
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            mTxt_H.Text = date_.GregToHijri(dateTimePicker1.Text);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSerNo_Click(object sender, EventArgs e)
        {
            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            foreach (DataGridViewRow row in dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
            }
            clear_texts();
            showDetails(AccBranch.ID.Text, frm.txtSearch.t.Text);
            IsNew = false;
            savtype = "1";
        }

        private void btn_getDataFromExcel_Click(object sender, EventArgs e)
        {

        }
    }
}

