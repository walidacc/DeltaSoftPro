using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Report_Pro.Forms
{
    public partial class frm_close_purch_to_lc:frm_Master
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();

        DataTable dt1;
        public frm_close_purch_to_lc()
        {
            InitializeComponent();
        }

        private void frm_close_purch_to_lc_Load(object sender, EventArgs e)
        {
            Uc_AccBranch.ID.Text = Properties.Settings.Default.BranchAccID;
             btnPrint.Visible = true;
            getJorSer();
        }








        private void getData()
        {


            if(Uc_AccBranch.ID.Text == string.Empty)
            {
                MessageBox.Show("تاكد من اختيار الفرع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Uc_Vendor .ID.Text == string.Empty)
            {
                MessageBox.Show("تاكد من اختيار المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Uc_Lc.ID.Text == string.Empty)
            {
                MessageBox.Show("تاكد من اختيار الاعتماد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (txt_vend_inv_no.Text.Trim() == string.Empty)
            {
                MessageBox.Show("تاكد من رقم فاتورة المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!dal.IsDateTime(txt_vend_inv_date.Text))
            {
                MessageBox.Show("تاكد من تاريخ فاتورة المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            dt1 = dal.getDataTabl_1(@"SELECT ACC_NO,ser_no,cast(g_date as date) as g_date,desc2,loh-meno as amount,Sp_Inv_No,isnull(INv_NO,'') as INv_NO,in_date,LC_NO FROM daily_transaction 
                    where Acc_no = '" + Uc_Vendor.ID.Text + "'  and (SOURCE_CODE like 'xp%' or SOURCE_CODE like 'PEY%')  and ISNULL(inv_no ,'0')='0' and BRANCH_code = '" + Uc_AccBranch.ID.Text +
                       "' and Sp_Inv_No like '" + txtSearchByDelevry.Text + "%'  order by Sp_Inv_No ");


            dgv1.Rows.Clear();
            if (dt1.Rows.Count > 0)
            {
                int B_rowscount = dt1.Rows.Count;
                dgv1.Rows.Clear();
                dgv1.Rows.Add(B_rowscount);
                for (int i = 0; (i <= (B_rowscount - 1)); i++)
                {
                    dgv1.Rows[i].Cells[0].Value = dt1.Rows[i]["ser_no"];
                    dgv1.Rows[i].Cells[1].Value = dt1.Rows[i]["g_date"];
                    dgv1.Rows[i].Cells[2].Value = dt1.Rows[i]["desc2"];
                    dgv1.Rows[i].Cells[3].Value = dt1.Rows[i]["amount"].ToString().ToDecimal().ToString("N2");
                    dgv1.Rows[i].Cells[4].Value = dt1.Rows[i]["Sp_Inv_No"];
                }

                Get_Total();
            }
               
        }




        


        private void btn_GetData_Click(object sender, EventArgs e)
        {
            getData();
            txtDesc_db.Text = "تحويل قيمة فاتورة رقم " + txt_vend_inv_no.Text + " الي حساب اعتماد رقم " + Uc_Lc.ID.Text;
            txtDesc_cr.Text = "قيمة فاتورة رقم " + txt_vend_inv_no.Text + " من حساب المورد رقم " + Uc_Vendor.ID.Text;

        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
            {
                if (dgv2.Rows[i].Cells[4].Value.ToString() == dgv1.CurrentRow.Cells[4].Value.ToString())
                {
                    MessageBox.Show("هذا الاستلام مضاف من قبل", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            
            int n1 = dgv2.Rows.Add();
            dgv2.Rows[n1].Cells[0].Value = dgv1.CurrentRow.Cells[0].Value.ToString();
            dgv2.Rows[n1].Cells[1].Value = dgv1.CurrentRow.Cells[1].Value.ToString();
            dgv2.Rows[n1].Cells[2].Value = dgv1.CurrentRow.Cells[2].Value.ToString();
            dgv2.Rows[n1].Cells[3].Value = dgv1.CurrentRow.Cells[3].Value.ToString();
            dgv2.Rows[n1].Cells[4].Value = dgv1.CurrentRow.Cells[4].Value.ToString();
            dgv1.Rows.RemoveAt(this.dgv1.CurrentRow.Index);

            Get_Total();
        
        }

        private void dgv2_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count > 0)
            {
                int n1 = dgv1.Rows.Add();
                dgv1.Rows[n1].Cells[0].Value = dgv2.CurrentRow.Cells[0].Value.ToString();
                dgv1.Rows[n1].Cells[1].Value = dgv2.CurrentRow.Cells[1].Value.ToString();
                dgv1.Rows[n1].Cells[2].Value = dgv2.CurrentRow.Cells[2].Value.ToString();
                dgv1.Rows[n1].Cells[3].Value = dgv2.CurrentRow.Cells[3].Value.ToString();
                dgv1.Rows[n1].Cells[4].Value = dgv2.CurrentRow.Cells[4].Value.ToString();
                dgv2.Rows.RemoveAt(this.dgv2.CurrentRow.Index);
                Get_Total();
            }
        }
        private void Get_Total()
        {
            txt_totalAmount.Text =
                         (from DataGridViewRow row in dgv1.Rows
                          where row.Cells[0].FormattedValue.ToString() != string.Empty
                          select (row.Cells[3].FormattedValue).ToString().ToDecimal()).Sum().ToString();

            txt_totalAmount_1.Text =
             (from DataGridViewRow row in dgv2.Rows
              where row.Cells[0].FormattedValue.ToString() != string.Empty
              select (row.Cells[3].FormattedValue).ToString().ToDecimal()).Sum().ToString();


        }

        private void dgv1_SortStringChanged(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dt1;

        }

        private void txt_Sup_inv_KeyUp(object sender, KeyEventArgs e)
        {
            getData();
        }

        public override void Save()
        {

            if (Uc_AccBranch.ID.Text.Trim() != string.Empty && Uc_Vendor.ID.Text.Trim() != string.Empty
               && Uc_Lc.ID.Text.Trim() != string.Empty && dal.IsDateTime(txt_vend_inv_date.Text)
               && txt_vend_inv_no.Text.Trim() != string.Empty && txt_totalAmount_1.Value > 0)
            {
                int JorSer;
                getJorSer();
                if (txtSerNo.Text.Contains('M'))
                {
                    var Jor_ser = txtSerNo.Text.Split('M');
                    JorSer = Convert.ToInt32(Jor_ser[1]);
                }

                else
                {
                    JorSer = Convert.ToInt32(txtSerNo.Text);
                }

                string desc_1 = txtDesc_db.Text;
                //"تحويل قيمة فاتورة رقم " + txt_vend_inv_no.Text + " الي حساب اعتماد رقم " + Uc_Lc.ID.Text;
                string desc_2 = txtDesc_cr.Text; 
                    //"قيمة فاتورة رقم " + txt_vend_inv_no.Text + " من حساب المورد رقم " + Uc_Vendor.ID.Text;
                dal.Execute_1(@"INSERT INTO daily_transaction(ACC_YEAR, ACC_NO, BRANCH_code, ser_no,MAIN_MEZAN, COST_CENTER, meno, loh
                , balance, g_date, sanad_no, SANAD_TYPE, user_name, desc2, POASTING, CAT_CODE, MAIN_SER_NO,inv_no,inv_date)
                VALUES('" + txtAcc_year.Text + "','" + Uc_Vendor.ID.Text + "','" + Uc_AccBranch.ID.Text + "','" +
                    txtSerNo.Text + "','','1','" + txt_totalAmount_1.Value +
                    "','0','" + txt_totalAmount_1.Value + "','" + txt_entryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "','" +
                    Main_serNo.Text + "','6','" + Program.userID + "','" + desc_1 + "','0','1','" + JorSer + "','" + txt_vend_inv_no.Text + "','" + txt_vend_inv_date.Value.ToString("yyyy/MM/dd HH:mm:ss") + "')");

                dal.Execute_1(@"INSERT INTO daily_transaction(ACC_YEAR, ACC_NO, BRANCH_code, ser_no,MAIN_MEZAN, COST_CENTER, meno, loh
                , balance, g_date, sanad_no, SANAD_TYPE, user_name, desc2, POASTING, CAT_CODE, MAIN_SER_NO)
                VALUES('" + txtAcc_year.Text + "','" + Uc_Lc.ID.Text + "','" + Uc_AccBranch.ID.Text + "','" +
                   txtSerNo.Text + "','','1','0','" + txt_totalAmount_1.Value +
                   "','" + -txt_totalAmount_1.Value + "','" + txt_entryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "','" +
                   Main_serNo.Text + "','6','" + Program.userID + "','" + desc_2 + "','0','1','" + JorSer + "')");

                dal.Execute_1(@"UPDATE serial_no SET daily_sn_ser='" + Main_serNo.Text + "' , main_daily_ser = '" + JorSer + "' WHERE BRANCH_CODE=  '" + Uc_AccBranch.ID.Text + "' and ACC_YEAR='" + txtAcc_year.Text + "' ");


                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    DataGridViewRow row_ = dgv2.Rows[i];
                    dal.Execute_1(@"UPDATE daily_transaction SET inv_no='" + txt_vend_inv_no.Text + "',inv_date='" + txt_vend_inv_date.Value.ToString("yyyy/MM/dd HH:mm:ss") + "' WHERE ser_no=  '" + row_.Cells[0].Value.ToString() + "' and ACC_NO='" + Uc_Vendor.ID.Text + "' ");

                }




                MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("تأكد من البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
            base.Save();
        }


        public override void New()
        {
            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            txtDesc_cr.Clear();
            txtDesc_db.Clear();
            Uc_Vendor.ID.Clear();
            Uc_Lc.ID.Clear();
            txt_vend_inv_no.Clear();
            txt_vend_inv_date.Text = "";
            getJorSer();





            base.New();
        }

        public override void Print()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet ds = new DataSet();
            DataTable dtB = new DataTable();
            RPT.Form1 frm = new RPT.Form1();
            RPT.rpt_ClosedInvoices rpt = new RPT.rpt_ClosedInvoices();
            
            dtB.Columns.Add("JorNo", typeof(string));
            dtB.Columns.Add("JorDate", typeof(DateTime));
            dtB.Columns.Add("JorDesc", typeof(string));
            dtB.Columns.Add("Amount", typeof(decimal));
            dtB.Columns.Add("VendorInvNo", typeof(string));
           
            foreach (DataGridViewRow dgvrow in dgv2.Rows)
            {
                dtB.Rows.Add(dgvrow.Cells[0].Value, dgvrow.Cells[1].Value,
                dgvrow.Cells[2].Value, dgvrow.Cells[3].Value, dgvrow.Cells[4].Value);
            }

            //ds.Tables.Add(dtB);
            ////ds.WriteXmlSchema("reports.xml");
            rpt.SetDataSource(dtB);
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
            base.Print();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //if (Uc_AccBranch.ID.Text.Trim() != string.Empty && Uc_Vendor.ID.Text.Trim() != string.Empty
            //    && Uc_Lc.ID.Text.Trim() != string.Empty && dal.IsDateTime(txt_vend_inv_date.Text)
            //    && txt_vend_inv_no.Text.Trim() != string.Empty && txt_totalAmount_1.Value > 0)
            //{
            //    int JorSer;
            //    getJorSer();
            //    if (txtSerNo.Text.Contains('M'))
            //    {
            //        var Jor_ser = txtSerNo.Text.Split('M');
            //        JorSer = Convert.ToInt32(Jor_ser[1]);
            //    }

            //    else
            //    {
            //        JorSer = Convert.ToInt32(txtSerNo.Text);
            //    }

            //    string desc_1 = "تحويل قيمة فاتورة رقم " + txt_vend_inv_no.Text + " الي حساب اعتماد رقم " + Uc_Lc.ID.Text;
            //    string desc_2 = "قيمة فاتورة رقم " + txt_vend_inv_no.Text + " من حساب المورد رقم " + Uc_Vendor.ID.Text;
            //    dal.Execute_1(@"INSERT INTO daily_transaction(ACC_YEAR, ACC_NO, BRANCH_code, ser_no,MAIN_MEZAN, COST_CENTER, meno, loh
            //    , balance, g_date, sanad_no, SANAD_TYPE, user_name, desc2, POASTING, CAT_CODE, MAIN_SER_NO,inv_no,inv_date)
            //    VALUES('" + txtAcc_year.Text + "','" + Uc_Vendor.ID.Text + "','" + Uc_AccBranch.ID.Text + "','" +
            //        txtSerNo.Text + "','','1','" + txt_totalAmount_1.Value +
            //        "','0','" + txt_totalAmount_1.Value + "','" + txt_entryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "','" +
            //        Main_serNo.Text + "','6','" + Program.userID + "','"+desc_1+"','0','1','" + JorSer + "','" + txt_vend_inv_no.Text + "','" + txt_vend_inv_date.Value.ToString("yyyy/MM/dd HH:mm:ss") + "')");

            //    dal.Execute_1(@"INSERT INTO daily_transaction(ACC_YEAR, ACC_NO, BRANCH_code, ser_no,MAIN_MEZAN, COST_CENTER, meno, loh
            //    , balance, g_date, sanad_no, SANAD_TYPE, user_name, desc2, POASTING, CAT_CODE, MAIN_SER_NO)
            //    VALUES('" + txtAcc_year.Text + "','" + Uc_Lc.ID.Text + "','" + Uc_AccBranch.ID.Text + "','" +
            //       txtSerNo.Text + "','','1','0','" + txt_totalAmount_1.Value +
            //       "','" + -txt_totalAmount_1.Value + "','" + txt_entryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "','" +
            //       Main_serNo.Text + "','6','" + Program.userID + "','" + desc_2 + "','0','1','" + JorSer + "')");

            //    dal.Execute_1(@"UPDATE serial_no SET daily_sn_ser='" + Main_serNo.Text + "' , main_daily_ser = '" + JorSer + "' WHERE BRANCH_CODE=  '" + Uc_AccBranch.ID.Text + "' and ACC_YEAR='" + txtAcc_year.Text + "' ");


            //    for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
            //    {
            //        DataGridViewRow row_ = dgv2.Rows[i];
            //        dal.Execute_1(@"UPDATE daily_transaction SET inv_no='"+txt_vend_inv_no.Text+ "',inv_date='" + txt_vend_inv_date.Value.ToString("yyyy/MM/dd HH:mm:ss") + "' WHERE ser_no=  '" + row_.Cells[0].Value.ToString() + "' and ACC_NO='" + Uc_Vendor.ID.Text + "' ");

            //    }




            //    MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("تأكد من البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void getJorSer()
        {




            DataTable dt_jorSer = dal.getDataTabl_1(@"select isnull(main_daily_ser+1,1) as _ser,isnull(daily_sn_ser+1,1) as _mainSer from serial_no where BRANCH_CODE='" + Uc_AccBranch.ID.Text
                     + "' and ACC_YEAR= '" + txtAcc_year.Text + "'");
            if (dt_jorSer.Rows.Count > 0)
            {
                txtSerNo.Text = "M" +dt_jorSer.Rows[0]["_ser"].ToString().PadLeft(4, '0');
                Main_serNo.Text = dt_jorSer.Rows[0]["_mainSer"].ToString();
            }
            else
            {
                txtSerNo.Text = "";
                 Main_serNo.Text = "";
            }


            //Main_serNo.Text = dal.getDataTabl_1(@"select isnull(daily_sn_ser+1,1) from serial_no where BRANCH_CODE='" + Uc_AccBranch.ID.Text
            //     + "' and ACC_YEAR= '" + txtAcc_year.Text + "' ").Rows[0][0].ToString();//.PadLeft(4, '0');


        }

        private void Uc_AccBranch_Load(object sender, EventArgs e)
        {
            getJorSer();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            getData();
        }

        private void btn_Added_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv1.SelectedRows)
            {


                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    if (dgv2.Rows[i].Cells[4].Value.ToString() == r.Cells[4].Value.ToString())
                    {
                        MessageBox.Show("هذا الاستلام مضاف من قبل", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                int n1 = dgv2.Rows.Add();
                dgv2.Rows[n1].Cells[0].Value = r.Cells[0].Value.ToString();
                dgv2.Rows[n1].Cells[1].Value = r.Cells[1].Value.ToString();
                dgv2.Rows[n1].Cells[2].Value = r.Cells[2].Value.ToString();
                dgv2.Rows[n1].Cells[3].Value = r.Cells[3].Value.ToString();
                dgv2.Rows[n1].Cells[4].Value = dgv1.CurrentRow.Cells[4].Value.ToString();
                dgv1.Rows.RemoveAt(r.Index);

                Get_Total();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow r in dgv2.SelectedRows)
                {

                    int n1 = dgv1.Rows.Add();
                    dgv1.Rows[n1].Cells[0].Value = dgv2.CurrentRow.Cells[0].Value.ToString();
                    dgv1.Rows[n1].Cells[1].Value = dgv2.CurrentRow.Cells[1].Value.ToString();
                    dgv1.Rows[n1].Cells[2].Value = dgv2.CurrentRow.Cells[2].Value.ToString();
                    dgv1.Rows[n1].Cells[3].Value = dgv2.CurrentRow.Cells[3].Value.ToString();
                    dgv1.Rows[n1].Cells[4].Value = dgv2.CurrentRow.Cells[4].Value.ToString();
                    dgv2.Rows.RemoveAt(this.dgv2.CurrentRow.Index);
                    Get_Total();
                }
            }
        }

        private void Uc_Vendor_Load(object sender, EventArgs e)
        {

        }

        private void txt_totalAmount_1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void headLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_entryDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void txt_docId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSanad_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void txtSer_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSerNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Main_serNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void txtAcc_year_Click(object sender, EventArgs e)
        {

        }

        private void txtDesc_db_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDesc_cr_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintJor_Click(object sender, EventArgs e)
        {
            RPT.Form1 frm = new RPT.Form1();


            DataTable dt_print = dal.getDataTabl_1(@"SELECT D.ACC_NO,D.BRANCH_code,D.ser_no,D.sorting_ser
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
                where  D.BRANCH_code='" + Uc_AccBranch.ID.Text + "' and D.ser_no='" + txtSerNo.Text + "' order by sorting_ser");

            DataTable dt_Loan = dal.getDataTabl_1(@"SELECT A.id,A.LoanNo,A.BankId,A.LoanACC,A.LoanDate,A.NumberOfPayments,A.LoanValue,A.PaymentNo,A.PaymentValue
            ,A.StartDate,A.MaturityDate,A.Rate,A.LoanPurpose,A.LoanRefrance,A.Branch_code,A.Jor_ser_no
            ,B.PAYER_NAME,B.payer_l_name,C.Loan_Purpose,C.Loan_Purpose_E
			,SUM(CASE WHEN  cast( D.PaymentDate  as date) <= '2023-01-01' THEN  D.PaymentAmount else 0 END) as payment " +
         ",SUM(CASE WHEN  cast( D.PaymentDate  as date) <= '2023-01-01' THEN  D.PayMentInterest else 0 END) as PayMentInterest " +
          " ,D.PaymentDate FROM LoansTbl As A " +
          "inner Join payer2 as B  on A.BankId=B.ACC_NO and A.Branch_code=B.BRANCH_code " +
          "left join LoanPurpose as C on c.Id=A.LoanPurpose " +
          "left join LoanPaymentTbl As D on A.LoanNo = D.LoanNo  and A.PaymentNo = D.PaymentNo " +
          "where A.Branch_code = '" + Uc_AccBranch.ID.Text + "' and A.Jor_ser_no = '" + txtSerNo.Text + "' " +
          "group by A.id,A.LoanNo,A.BankId,A.LoanACC,A.LoanDate,A.NumberOfPayments,A.LoanValue,A.PaymentNo,A.PaymentValue " +
          ",A.StartDate,A.MaturityDate,A.Rate,A.LoanPurpose,A.LoanRefrance,A.Branch_code,A.Jor_ser_no " +
          ",B.PAYER_NAME,B.payer_l_name,C.Loan_Purpose,C.Loan_Purpose_E,D.PaymentDate");



            DataSet ds = new DataSet();
            ds.Tables.Add(dt_print);
            ds.Tables.Add(dt_Loan);
            ds.WriteXmlSchema("schema1.xml");
            if (Properties.Settings.Default.lungh == "0")
            {
                RPT.rpt_DailyEntry rpt_DailyEntry = new RPT.rpt_DailyEntry();
                rpt_DailyEntry.SetDataSource(ds);
                rpt_DailyEntry.DataDefinition.FormulaFields["_digits"].Text = "'" + dal.digits_ + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + Uc_AccBranch.ID.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + Uc_AccBranch.Desc.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName_E"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            }
            else
            {
                RPT.rpt_DailyEntry_E rpt_DailyEntry = new RPT.rpt_DailyEntry_E();
                rpt_DailyEntry.SetDataSource(ds);
                rpt_DailyEntry.DataDefinition.FormulaFields["_digits"].Text = "'" + dal.digits_ + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchCode"].Text = "'" + Uc_AccBranch.ID.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["branchName"].Text = "'" + Uc_AccBranch.Desc.Text + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt_DailyEntry.DataDefinition.FormulaFields["companyName_E"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                frm.crystalReportViewer1.ReportSource = rpt_DailyEntry;
            }
            frm.ShowDialog();


        }
    }  
}
