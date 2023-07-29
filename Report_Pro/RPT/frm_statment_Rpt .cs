using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frm_statment_Rpt : frm_ReportMaster
    {

        //DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        DataTable dtTransaction = new DataTable();
        string db1 = Properties.Settings.Default.Database_1;
        string btn_name;

        public Boolean canChangeAcc;
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        int currencyNo = 2;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_statment_Rpt()
        {
            InitializeComponent();

            if(canChangeAcc == false)
            {
                UC_Acc1.Enabled = false;
                UC_cost1.Enabled = false;
                UC_Catogry1.Enabled = false;
                chB_1.Enabled = false;
            }
            else
            {
                UC_Acc1.Enabled = true;
                UC_cost1.Enabled = true;
                UC_Catogry1.Enabled = true;
                chB_1.Enabled = true;
            }
        }


        public override void preview()
        {

            dgv.Visible = false;
            crystalReportViewer1.Visible = true;
            if (rdo_Sub.Checked)
            {
                if (dal.getDataTabl_1(@" SELECT PAYER_NAME  FROM payer2  where ACC_NO = '" +UC_Acc1.ID.Text + "' and BRANCH_code like '" + UC_Branch.ID.Text +"%' and t_final=1").Rows.Count <= 0) 
                {
                    MessageBox.Show("لم يتم اختيار حساب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                    print_acc_A();
                    
              

            }
            else
            {
                if (dal.getDataTabl_1(@" SELECT PAYER_NAME  FROM payer2  where ACC_NO = '" + UC_Acc1.ID.Text + "' and BRANCH_code like '" + UC_Branch.ID.Text + "%'").Rows.Count <= 0)
                {
                    MessageBox.Show("لم يتم اختيار حساب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Properties.Settings.Default.lungh == "0")
                {
                    print_acc_all_A();
                }
                else
                {
                    print_all_E();
                }

            }
            base.preview();
        }



        public override void Report()
        {
            crystalReportViewer1.Visible = false;
            dgv.Visible = true;
            if (rdo_Main.Checked)
            {
                dgv.Columns[12].Visible = true;
                dgv.Columns[13].Visible = true;
            }
            else
            {
                dgv.Columns[12].Visible = false;
                dgv.Columns[13].Visible = false;
            }


            DataTable dt = new DataTable();
            dt = dal.getDataTabl("GetAcc_", UC_Branch.ID.Text, UC_Acc1.ID.Text, "", "", "", db1);
            if (dt.Rows.Count <= 0 && UC_cost1.ID.Text == string.Empty && UC_Catogry1.ID.Text == string.Empty)
            {
                MessageBox.Show("لم يتم اختيار حساب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Get_Transaction();
     
        }


        private DataTable getTransacton()
        {
            string _main = "1";
            if (rdo_Main.Checked)
            {
                _main = "0";
            }
            else
            {
                _main = "1";
            }

            dtTransaction = dal.getDataTabl_1(@" select A.ser_no,A.Acc_no,A.BRANCH_code,A.COST_CENTER,A.g_date,A.meno,A.loh,A.CAT_CODE,A.desc2
                ,ISNULL(A.desc_E,A.desc2) AS desc_E,P.PAYER_NAME,P.payer_l_name
				,B.branch_name,ISNULL(B.WH_E_NAME,B.branch_name) AS WH_E_NAME
				,C.CAT_NAME,ISNULL(C.CAT_NAME_E,C.CAT_NAME) AS CAT_NAME_E
				,S.COST_name,ISNULL(S.COST_E_NAME,s.COST_name) AS COST_E_NAME
                from daily_transaction as A
                inner join  payer2 as P on P.ACC_NO = A.ACC_NO and P.BRANCH_code=A.BRANCH_code
                inner join  wh_BRANCHES as B on  B.BRANCH_code=A.BRANCH_code
                left join  CATEGORY As C on  C.CAT_CODE=A.CAT_CODE
                left join  COST_CENTER as S on S.COST_CODE=A.COST_CENTER
                where cast(A.g_date as date) between '" + FromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") +
            "'and  A.ACC_NO like (case when '" +_main+"' = 0  then '" + UC_Acc1.ID.Text + "%' else '" + UC_Acc1.ID.Text + "' end)  and ISNULL(A.COST_CENTER,'') like '" + UC_cost1.ID.Text +
            "%'and ISNULL(A.CAT_CODE,'')  like '" + UC_Catogry1.ID.Text + "%' and  A.BRANCH_code like (CASE WHEN (select t_final  from BRANCHS where BRANCH_code='" + UC_Branch.ID.Text +
            "')='1' then '" + UC_Branch.ID.Text + "' else  '" + UC_Branch.ID.Text + "%' end) order by  A.acc_no ,A.G_date ");

            return dtTransaction;
        }


        private void Get_Transaction()

        {

            Cursor.Current = Cursors.WaitCursor;
            DataTable dt2 = new DataTable();

            dt2 = dal.getDataTabl_1(@"  select  
            SUM(CASE  WHEN  cast(A.g_date as date) > '" + minimumDate.Value.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) < '" + FromDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END) AS  Begining_balance " +
            ",SUM(CASE WHEN  cast(A.g_date as date) > '" + minimumDate.Value.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END) AS Ending_balance " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=0   and DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=30  THEN meno    ELSE 0 END) AS '1-30' " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=31  and DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=60  THEN meno    ELSE 0 END) AS '31-60' " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=61  and DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=90  THEN meno    ELSE 0 END) AS '61-90' " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=91  and DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=120  THEN meno    ELSE 0 END) AS '91-120' " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=121 and DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=150  THEN meno    ELSE 0 END) AS '121-250' " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=151 and DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=180  THEN meno    ELSE 0 END) AS '151-180' " +
            ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=181  THEN meno    ELSE 0 END) AS 'more180' " +
            ", ReportDB.dbo.Tafkeet(ABS(SUM(CASE WHEN cast(A.g_date as date) > '" + minimumDate.Value.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END)),'s') " +
            "from daily_transaction as A " +
            "where A.ACC_NO like '" + UC_Acc1.ID.Text + "%' and ISNULL(A.COST_CENTER,'') like '" + UC_cost1.ID.Text + "%' and ISNULL(A.CAT_CODE,'')  like '" + UC_Catogry1.ID.Text + "%' and A.BRANCH_code like(CASE WHEN (select t_final  from BRANCHS where BRANCH_code = '" + UC_Branch.ID.Text + "')= '1' then '" + UC_Branch.ID.Text + "' else '" + UC_Branch.ID.Text + "%' end) ");
          //  A.acc_no,
            //"group by   A.ACC_NO ");

           getTransacton();
            dgv.Rows.Clear();
            if (dtTransaction.Rows.Count > 0)
            {

                int B_rowscount = dtTransaction.Rows.Count;

                
                dgv.Rows.Add(B_rowscount + 1);
               

                for (int i = 1; i <= (B_rowscount); i++)
                {


                    dgv.Rows[i].Cells[0].Value =Convert.ToDateTime( dtTransaction.Rows[i - 1]["g_date"]).ToString("yyyy/MM/dd");
                    dgv.Rows[i].Cells[1].Value = dtTransaction.Rows[i - 1]["ser_no"];
                    if (Properties.Settings.Default.lungh == "0")
                    {
                       
                        dgv.Rows[i].Cells[2].Value = dtTransaction.Rows[i - 1]["desc2"];
                        dgv.Rows[i].Cells[7].Value = dtTransaction.Rows[i - 1]["branch_name"];
                        dgv.Rows[i].Cells[9].Value = dtTransaction.Rows[i - 1]["COST_name"];
                        dgv.Rows[i].Cells[11].Value = dtTransaction.Rows[i - 1]["CAT_NAME"];
                        dgv.Rows[i].Cells[13].Value = dtTransaction.Rows[i - 1]["PAYER_NAME"];
                    }
                    else
                    {
                       
                        dgv.Rows[i].Cells[2].Value = dtTransaction.Rows[i - 1]["desc_E"];
                        dgv.Rows[i].Cells[7].Value = dtTransaction.Rows[i - 1]["WH_E_NAME"];
                        dgv.Rows[i].Cells[9].Value = dtTransaction.Rows[i - 1]["COST_E_NAME"];
                        dgv.Rows[i].Cells[11].Value = dtTransaction.Rows[i - 1]["CAT_NAME_E"];
                        dgv.Rows[i].Cells[13].Value = dtTransaction.Rows[i - 1]["payer_l_name"];
                    }

                    dgv.Rows[i].Cells[3].Value = dtTransaction.Rows[i - 1]["meno"].ToString().ToDecimal().ToString("N"+dal.digits_);
                    dgv.Rows[i].Cells[4].Value = dtTransaction.Rows[i - 1]["loh"].ToString().ToDecimal().ToString("N" + dal.digits_);
                    dgv.Rows[i].Cells[6].Value = dtTransaction.Rows[i - 1]["BRANCH_code"];
                    dgv.Rows[i].Cells[8].Value = dtTransaction.Rows[i - 1]["COST_CENTER"];
                    dgv.Rows[i].Cells[10].Value = dtTransaction.Rows[i - 1]["CAT_CODE"];
                    dgv.Rows[i].Cells[12].Value = dtTransaction.Rows[i - 1]["Acc_no"];

                }

                
            }

            dgv.Rows[0].Cells[2].Value = "الرصيد السابق";
            dgv.Rows[0].Cells[5].Value =dt2.Rows[0]["Begining_balance"].ToString().ToDecimal().ToString("N" + dal.digits_); 
            get_Balance();
            //bs.DataSource = dgv.DataSource;
            //dgv.DataSource = bs;



            //////ds.WriteXmlSchema("schema1.xml");


            Cursor = Cursors.Default;
            groupPanel1.Visible = false;

        }


        private void get_Balance()
        {
            for (int i = 1; i<= dgv.Rows.Count - 1; i++)
            {
                double db = Convert.ToDouble(dgv.Rows[i].Cells[3].Value);
                double cr = Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
                double obl = Convert.ToDouble(dgv.Rows[i-1].Cells[5].Value);
               dgv.Rows[i].Cells[5].Value = (obl+db-cr).ToString().ToDecimal().ToString("N" + dal.digits_);
            }
        }


        private void print_acc_E()
        {
            RPT.Statment_acc_E rpt = new RPT.Statment_acc_E();
            DataSet1 ds = new DataSet1();
            //DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();


            DataTable dt1 = dal.getDataTabl_1(@" select A.ser_no,A.BRANCH_code,A.COST_CENTER,A.g_date,A.meno,A.loh,A.CAT_CODE,A.desc2
                ,ISNULL(A.desc_E,A.desc2) AS desc_E,P.PAYER_NAME,P.payer_l_name
				,B.branch_name,ISNULL(B.WH_E_NAME,B.branch_name) AS WH_E_NAME
				,C.CAT_NAME,ISNULL(C.CAT_NAME_E,C.CAT_NAME) AS CAT_NAME_E
				,S.COST_name,ISNULL(S.COST_E_NAME,s.COST_name) AS COST_E_NAME
                from daily_transaction as A
                inner join  payer2 as P on P.ACC_NO = A.ACC_NO and P.BRANCH_code=A.BRANCH_code
                inner join  wh_BRANCHES as B on  B.BRANCH_code=A.BRANCH_code
                left join  CATEGORY As C on  C.CAT_CODE=A.CAT_CODE
                left join  COST_CENTER as S on S.COST_CODE=A.COST_CENTER
                where cast(A.g_date as date) between '" + FromDate.Value.ToString("yyyy-MM-dd")+"' AND '"+ToDate.Value.ToString("yyyy-MM-dd")+
                "'and  A.ACC_NO = '"+UC_Acc1.ID.Text+"' and ISNULL(A.COST_CENTER,'') like '"+UC_cost1.ID.Text +
                "%'and ISNULL(A.CAT_CODE,'')  like '"+UC_Catogry1.ID.Text + "%' and  A.BRANCH_code like (CASE WHEN (select t_final  from BRANCHS where BRANCH_code='"+UC_Branch.ID.Text+
                "')='1' then '"+UC_Branch.ID.Text+ "' else  '" + UC_Branch.ID.Text + "%' end) order by A.G_date ");
            if (chB_1.Checked == true)
            {
                dt2 = (dal.getDataTabl("begin_statment_balance_", FromDate.Value.Date, ToDate.Value.Date, UC_Acc1.ID.Text, UC_cost1.ID.Text, UC_Catogry1.ID.Text, FromDate.Value.Date, UC_Branch.ID.Text, db1, Properties.Settings.Default.Currency));
                rpt.DataDefinition.FormulaFields["OB_studs"].Text = "'" + chB_1.Text + "'";

            }
            else
            {
                dt2 = (dal.getDataTabl("begin_statment_balance_", FromDate.Value.Date, ToDate.Value.Date, UC_Acc1.ID.Text, UC_cost1.ID.Text, UC_Catogry1.ID.Text, FromDate.MinDate, UC_Branch.ID.Text, db1, Properties.Settings.Default.Currency));
                rpt.DataDefinition.FormulaFields["OB_studs"].Text = "";
            }

            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);

            //ds.WriteXmlSchema("schema1.xml");

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            this.Cursor = Cursors.Default;
            rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("dd/MM/yyyy") + "'";
            rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("dd/MM/yyyy") + "'";
            rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Acc_name"].Text = "'" + UC_Acc1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
            rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt_EN + "'";
            rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";
            if (dt2.Rows.Count > 0)
            {
                ToWord toWord = new ToWord(Math.Abs(Math.Round(dt2.Rows[0][1].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
                rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";
            }
            else
            {

            ToWord toWord = new ToWord(Math.Abs(Math.Round("0".ToDecimal(), dal.digits_)), currencies[currencyNo]);
            rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

            }
            groupPanel1.Visible = false;

        }

        private void print_all_E()
        {
            DataTable dt_ch = new DataTable();

            DateTime miniDate = FromDate.Value.Date;
            if (chB_1.Checked == true)
            {
                miniDate = FromDate.Value.Date;
            }
            else
            {
                miniDate = FromDate.MinDate;
            }

            dt_ch = dal.getDataTabl_1(@"select * from (select p.acc_no,PAYER_NAME,ISNULL(NULLIF(payer_l_name,''),PAYER_NAME) As payer_l_name,A.Ending_balance ,ROW_NUMBER() OVER(PARTITION BY p.Acc_no ORDER BY p.acc_no) AS DuplicateCount from payer2 As P
                inner join (select  acc_no 
                , SUM(CASE WHEN cast(g_date as date) >= '" + miniDate.Date.ToString("yyyy-MM-dd") + "' and cast(g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd")+"' THEN meno - loh ELSE 0 END) AS Ending_balance" +
               " from daily_transaction  group by ACC_NO ) As A " +
              " on P.ACC_NO=A.ACC_NO " +
              " where p.ACC_NO like '" + UC_Acc1.ID.Text + "%' and A.Ending_balance<>0) As X where X.DuplicateCount=1");


            foreach (DataRow dr in dt_ch.Rows)
            {

                getStatmentData(dr[0].ToString());
                RPT.Statment_acc_E rpt = new RPT.Statment_acc_E();

                DataSet ds = new DataSet();
                ds.Tables.Add(dt1);
                ds.Tables.Add(dt2);
                ds.Tables.Add(dt3);
                rpt.SetDataSource(ds);
             //   crystalReportViewer1.ReportSource = rpt;
                rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("dd/MM/yyyy") + "'";
                rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("dd/MM/yyyy") + "'";
                rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + dr[0].ToString() + "'";
                rpt.DataDefinition.FormulaFields["Acc_name"].Text = " '" + dr[0].ToString() + "'+' - '+ '" + dr[2].ToString() + "'";
                rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.ID.Text + "'+' - '+'" + UC_cost1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt_EN + "'";
                rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";
                ToWord toWord = new ToWord(Math.Abs(Math.Round(dt2.Rows[0][1].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
                rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                rpt.PrintOptions.PrinterName = Properties.Settings.Default.Report_P;
                rpt.PrintToPrinter(1, false, 0, 15);

                //groupPanel1.Visible = false;

            }
        }


        private void getStatmentData(string _acc)
        {

           dt1  = dal.getDataTabl_1(@"select A.acc_no, A.ser_no,A.BRANCH_code,LEFT(A.BRANCH_code,1) as com_code,A.COST_CENTER,A.g_date,A.meno,A.loh,A.CAT_CODE,A.desc2
                ,ISNULL(A.desc_E,A.desc2) AS desc_E,P.PAYER_NAME,isnull(NullIf(P.payer_l_name,''),P.PAYER_NAME) as payer_l_name  
				,B.branch_name,ISNULL(B.BRANCH_E_NAME,B.branch_name) AS BRANCH_E_NAME
				,C.CAT_NAME,ISNULL(C.CAT_NAME_E,C.CAT_NAME) AS CAT_NAME_E
				,S.COST_name,ISNULL(S.COST_E_NAME,s.COST_name) AS COST_E_NAME
                ,A.PROJECT_NO,j.PROJ_name ,ISNULL(nullif(j.PROJ_E_NAME,''),J.PROJ_name) as PROJ_E_NAME
                from daily_transaction as A
                inner join  payer2 as P on P.ACC_NO = A.ACC_NO and P.BRANCH_code=A.BRANCH_code
                inner join  BRANCHS as B on  B.BRANCH_code=A.BRANCH_code
                left join  CATEGORY As C on  C.CAT_CODE=A.CAT_CODE
                left join  COST_CENTER as S on S.COST_CODE=A.COST_CENTER
                left join PROJECTS as J on ISNULL(A.PROJECT_NO,'') =J.PROJ_CODE
               where cast(A.g_date as date) between '" + FromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") +
               "'and  A.ACC_NO = '" + _acc + "' and ISNULL(A.COST_CENTER,'') like '" + UC_cost1.ID.Text +
              "%'and ISNULL(A.CAT_CODE,'')  like '" + UC_Catogry1.ID.Text + "%' and  A.BRANCH_code like (CASE WHEN (select t_final  from BRANCHS where BRANCH_code='" + UC_Branch.ID.Text +
              "')='1' then '" + UC_Branch.ID.Text + "' else  '" + UC_Branch.ID.Text + "%' end) " +
              "and isnull(A.PROJECT_NO ,'') like (CASE WHEN '" + Project.ID.Text +"'<>'' then '" + Project.ID.Text + "' else  '" + Project.ID.Text + "%' end)" +
              "order by A.G_date ");



            DateTime miniDate = FromDate.Value.Date;
            if (chB_1.Checked == true)
            {
                miniDate = FromDate.Value.Date;
            }
            else
            {
                miniDate = FromDate.MinDate;
            }


         dt2 = dal.getDataTabl_1(@"select  A.acc_no,
         SUM(CASE WHEN cast(A.g_date as date) > '" + miniDate.Date.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) < '" + FromDate.Value.ToString("yyyy-MM-dd") + "'  THEN meno - loh ELSE 0 END) AS  Begining_balance " +
        ", SUM(CASE WHEN cast(A.g_date as date) >= '" + miniDate.Date.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END) AS Ending_balance " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 0   and DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') <= 30  THEN meno    ELSE 0 END)  AS '1 - 30' " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 31  and DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') <= 60  THEN meno    ELSE 0 END)  AS '31 - 60' " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 61  and DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') <= 90  THEN meno    ELSE 0 END)  AS '61 - 90' " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 91  and DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') <= 120  THEN meno    ELSE 0 END) AS '91 - 120' " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 121 and DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') <= 150  THEN meno    ELSE 0 END) AS '121 - 250' " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 151 and DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') <= 180  THEN meno    ELSE 0 END) AS '151 - 180' " +
        ", SUM(CASE WHEN  DATEDIFF(Day, CAST(g_date as date), '" + ToDate.Value.ToString("yyyy-MM-dd") + "') >= 181  THEN meno    ELSE 0 END) AS 'more180' " +
        ", ReportDB.dbo.Tafkeet(ABS(SUM(CASE WHEN cast(A.g_date as date) >= '" + miniDate.Date.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END)), '" + Properties.Settings.Default.Currency + "') " +
        " from daily_transaction as A " +
        " where A.ACC_NO = '" + _acc + "' and ISNULL(A.COST_CENTER, '') like '" + UC_cost1.ID.Text + "%' and ISNULL(A.CAT_CODE, '')  like '" + UC_Catogry1.ID.Text + 
        "%' and  A.BRANCH_code like(CASE WHEN(select t_final  from BRANCHS where BRANCH_code = '" + UC_Branch.ID.Text + "') = '1' then '" + UC_Branch.ID.Text + "' else  '" + UC_Branch.ID.Text + "%' end)  " +
       " and isnull(A.PROJECT_NO ,'') like (CASE WHEN '" + Project.ID.Text + "'<>'' then '" + Project.ID.Text + "' else  '" + Project.ID.Text + "%' end) "+
        "group by   A.ACC_NO");

         dt3 = dal.getDataTabl_1(@"select * from Wh_Oiner_Comp where Company_No=left('" + Properties.Settings.Default.BranchAccID+ "',1)   ");

          
        }

       

        private void print_acc_A()

        {
            getStatmentData(UC_Acc1.ID.Text);

           
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt3);
            ds.WriteXmlSchema("schema1.xml");



            if ( cmbLanguh.SelectedIndex==1)
            {
                RPT.Statment_acc rpt = new RPT.Statment_acc();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
                rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("yyyy/MM/dd") + "'";
                rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
                rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Acc_name"].Text = " '" + UC_Acc1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";
                rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";
                if (dt2.Rows.Count > 0)
                {
                    ToWord toWord = new ToWord(Math.Abs(Math.Round(dt2.Rows[0]["Ending_balance"].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
                    rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
                }
                else
                {
                    ToWord toWord = new ToWord(0, currencies[currencyNo]);
                    rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";

                }
            }
            else
            {
                RPT.Statment_acc_E rpt = new RPT.Statment_acc_E();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
                rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("dd/MM/yyyy") + "'";
                rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("dd/MM/yyyy") + "'";
                rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Acc_name"].Text = "'" + UC_Acc1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
                rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
                rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt_EN + "'";
                rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";
                if (dt2.Rows.Count > 0)
                {
                    ToWord toWord = new ToWord(Math.Abs(Math.Round(dt2.Rows[0]["Ending_balance"].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
                    rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";
                }
                else
                {

                    ToWord toWord = new ToWord(Math.Abs(Math.Round("0".ToDecimal(), dal.digits_)), currencies[currencyNo]);
                    rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

                }
            }
            groupPanel1.Visible = false;
        }

        private void print_acc_all_A()
        {
            DataTable dt_ch = new DataTable();

            //dt_ch = dal.getDataTabl_1(@"select * from (select p.acc_no,PAYER_NAME,payer_l_name,A.Ending_balance ,ROW_NUMBER() OVER(PARTITION BY p.Acc_no ORDER BY p.acc_no) AS DuplicateCount from payer2 As P
            //inner join (select  acc_no
            //, SUM(CASE WHEN cast(g_date as date) >= '" + ToDate.MinDate.ToString("yyyy-MM-dd") + "' and cast(g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") +
            //"' THEN meno - loh ELSE 0 END) AS Ending_balance" +
            //" from daily_transaction  group by ACC_NO ) As A " +
            //" on P.ACC_NO=A.ACC_NO " +
            //" where p.ACC_NO like '" + UC_Acc1.ID.Text + "%' and A.Ending_balance<>0) As X where X.DuplicateCount=1");

            //foreach (DataRow dr in dt_ch.Rows)
            //{

            DataTable dt1;
            RPT.Statment_acc_Main rpt = new RPT.Statment_acc_Main();
            //and A.BRANCH_code like(CASE WHEN (select t_final  from BRANCHS where BRANCH_code= '"+UC_Branch.ID.Text+ "')= '1' then '" + UC_Branch.ID.Text + "' else  '" + UC_Branch.ID.Text + "%' end)
            if (chB_1.Checked == true)
            {
                dt1 = (dal.getDataTabl_1(@"select A.*,P.PAYER_NAME,P.payer_l_name,B.branch_name,C.CAT_NAME,S.COST_name,S.COST_E_NAME
                    from daily_transaction as A inner join  payer2 as P on P.ACC_NO = A.ACC_NO and P.BRANCH_code = A.BRANCH_code
                    inner join  wh_BRANCHES as B on  B.BRANCH_code = A.BRANCH_code
                    left join  CATEGORY As C on  C.CAT_CODE = A.CAT_CODE
                    left join  COST_CENTER as S on S.COST_CODE = A.COST_CENTER
                    where cast(A.g_date as date) between '" + FromDate.Value.ToString("yyyy-MM-dd") + "'  and '" + ToDate.Value.ToString("yyyy-MM-dd") +
                "' and  A.ACC_NO like '" + UC_Acc1.ID.Text + "%' and ISNULL(A.COST_CENTER, '') like '" + UC_cost1.ID.Text +
                "%' and ISNULL(A.CAT_CODE, '')  like '" + UC_Catogry1.ID.Text +
           "%' and A.BRANCH_code like (CASE WHEN (select t_final  from BRANCHS where BRANCH_code='" + UC_Branch.ID.Text + "')='1' then '" + UC_Branch.ID.Text + "' else  '" + UC_Branch.ID.Text + "%' end)  order by A.G_date"));

                //order by A.G_date
                //where cast(A.g_date as date) between '" + FromDate.Value.ToString("yyyy-MM-dd") + "'  and '" + ToDate.Value.ToString("yyyy-MM-dd") +
                //"' and  A.ACC_NO like '" +  UC_Acc1.ID.Text + "%' and ISNULL(A.COST_CENTER, '') like '" + UC_cost1.ID.Text +
                //"%' and ISNULL(A.CAT_CODE, '')  like '" + UC_Catogry1.ID.Text + "%'  order by A.G_date"));

                //dt2 = (dal.getDataTabl_1(@"select  A.acc_no,
                //SUM(CASE WHEN cast(A.g_date as date) > '" + FromDate.Value.ToString("yyyy-MM-dd") + "'  and cast(A.g_date as date) < '" + FromDate.Value.ToString("yyyy-MM-dd") +"'  THEN meno - loh ELSE 0 END) AS  Begining_balance " +
                //",SUM(CASE WHEN cast(A.g_date as date) >= '" + FromDate.Value.ToString("yyyy-MM-dd") + "'  and cast(A.g_date as date) <=  '" + ToDate.Value.ToString("yyyy-MM-dd") + "'  THEN meno - loh ELSE 0 END) AS Ending_balance " +
                //", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >=0 and DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') <=30  THEN meno    ELSE 0 END) AS '1-30'" +
                //",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >= 31 and DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') <= 60  THEN meno    ELSE 0 END) AS '31-60' " +
                //",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >= 61 and DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') <= 90  THEN meno    ELSE 0 END) AS '61-90' " +
                //",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >= 91 and DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') <= 120  THEN meno    ELSE 0 END) AS '91-120' " +
                //",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >= 121 and DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') <= 150  THEN meno    ELSE 0 END) AS '121-250' " +
                //",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >= 151 and DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') <= 180  THEN meno    ELSE 0 END) AS '151-180' " +
                //",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ), '" + ToDate.Value.ToString("yyyy-MM-dd") +"') >= 181  THEN meno    ELSE 0 END) AS 'more180'" +

                // ",ReportDB.dbo.Tafkeet(ABS(SUM(CASE WHEN cast(A.g_date as date) >= '" + FromDate.Value.ToString("yyyy-MM-dd") + "' and cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END)), '" + Properties.Settings.Default.Currency + "') "+

                //"from daily_transaction as A " +
                //"where A.ACC_NO like '"+ UC_Acc1.ID.Text + "%' and ISNULL(A.COST_CENTER,'') like '" +UC_cost1.ID.Text+ "%' and ISNULL(A.CAT_CODE,'')  like '"+UC_Catogry1.ID.Text+ "%' and  A.BRANCH_code like (CASE WHEN (select t_final  from BRANCHS where BRANCH_code='"+
                //UC_Branch.ID.Text+"')='1' then '" + UC_Branch.ID.Text + "' else  '"+ UC_Branch.ID.Text+"%' end) group by   A.ACC_NO"));

                //rpt.DataDefinition.FormulaFields["OB_studs"].Text = "'" + chB_1.Text + "'";
                //rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                //rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";

            }
            else
            {
                dt1 = dal.getDataTabl("acc_statment_", FromDate.Value.Date, ToDate.Value.Date, UC_Acc1.ID.Text, UC_cost1.ID.Text, UC_Catogry1.ID.Text, UC_Branch.ID.Text, db1);
                dt2 = (dal.getDataTabl("begin_statment_balance_", FromDate.Value.Date, ToDate.Value.Date, UC_Acc1.ID.Text, UC_cost1.ID.Text, UC_Catogry1.ID.Text, FromDate.MinDate, UC_Branch.ID.Text, db1, Properties.Settings.Default.Currency));
                rpt.DataDefinition.FormulaFields["OB_studs"].Text = "";
            }




            // MessageBox.Show(dt2.Rows[0][0].ToString());
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);




            ////ds.WriteXmlSchema("schema1.xml");

            rpt.SetDataSource(ds);

            //crystalReportViewer1.ReportSource = rpt;
            this.Cursor = Cursors.Default;
            rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
            //rpt.DataDefinition.FormulaFields["Acc_name"].Text = " '" + dr[1].ToString() + "'";
            rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
            // rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
            //rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";
            //rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";
            if (dt2.Rows.Count > 0)
            {
                ToWord toWord = new ToWord(Math.Abs(Math.Round(dt2.Rows[0][2].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
               // rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToArabic().ToString() + "'";
            }
            //rpt.PrintOptions.PrinterName = Properties.Settings.Default.Report_P;
            //rpt.PrintToPrinter(1, false, 0, 15);
            crystalReportViewer1.ReportSource = rpt;
            groupPanel1.Visible = false;

            //}

        }


        private void frm_statment_Rpt_Load(object sender, EventArgs e)
        {
            
           

            if ( canEdit == 1)
            {
                UC_Acc1.Enabled = true;
                UC_cost1.Enabled = true;
                UC_Catogry1.Enabled = true;
                chB_1.Enabled = true;
            }
            else
            {
                UC_Acc1.Enabled = false;
                UC_cost1.Enabled = false;
                UC_Catogry1.Enabled = false;
                chB_1.Enabled = false;
            }

            FromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            ToDate.Value = DateTime.Today;

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

            // date_period.Value = date_period.MinDate;
        }


   
        private void UC_Branch_Load(object sender, EventArgs e)
        {
            UC_Acc1.branchID.Text = UC_Branch.ID.Text;
        }

   
        public override void Option()
        {
                  base.Option();
            groupPanel1.Visible = true;
        }

        private void chB_1_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_1.Checked == true)
            {
                minimumDate.Value = FromDate.Value;
            }
            else
            {
                minimumDate.Value = minimumDate.MinDate;
            }
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            if (chB_1.Checked == true)
            {
                minimumDate.Value = FromDate.Value;
            }
            else
            {
                minimumDate.Value = minimumDate.MinDate;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.CurrentRow.Cells[6].Value != null && dgv.CurrentRow.Cells[1].Value!=null){

            var frm = new PL.frmJornal(dgv.CurrentRow.Cells[6].Value.ToString(), dgv.CurrentRow.Cells[1].Value.ToString());

               Forms.frm_Main.OpenForm(frm, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.Visible = false;
            crystalReportViewer1.Visible = true;
            RPT.rpt_Confirmation_Statment rpt = new RPT.rpt_Confirmation_Statment();
            DataSet1 ds = new DataSet1();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();


            dt1 = dal.getDataTabl_1(@" select A.ser_no,A.BRANCH_code,A.COST_CENTER,A.g_date,A.meno,A.loh,A.CAT_CODE,A.desc2
                ,ISNULL(A.desc_E,A.desc2) AS desc_E,P.PAYER_NAME,P.payer_l_name
				,B.branch_name,ISNULL(B.WH_E_NAME,B.branch_name) AS WH_E_NAME
				,C.CAT_NAME,ISNULL(C.CAT_NAME_E,C.CAT_NAME) AS CAT_NAME_E
				,S.COST_name,ISNULL(S.COST_E_NAME,s.COST_name) AS COST_E_NAME
                from daily_transaction as A
                inner join  payer2 as P on P.ACC_NO = A.ACC_NO and P.BRANCH_code=A.BRANCH_code
                inner join  wh_BRANCHES as B on  B.BRANCH_code=A.BRANCH_code
                left join  CATEGORY As C on  C.CAT_CODE=A.CAT_CODE
                left join  COST_CENTER as S on S.COST_CODE=A.COST_CENTER
                where cast(A.g_date as date) between '" + FromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") +
            "'and  A.ACC_NO = '" + UC_Acc1.ID.Text + "' and ISNULL(A.COST_CENTER,'') like '" + UC_cost1.ID.Text +
            "%'and ISNULL(A.CAT_CODE,'')  like '" + UC_Catogry1.ID.Text + "%' and  A.BRANCH_code like (CASE WHEN (select t_final  from BRANCHS where BRANCH_code='" + UC_Branch.ID.Text +
            "')='1' then '" + UC_Branch.ID.Text + "' else  '" + UC_Branch.ID.Text + "%' end) order by A.G_date ");
            if (chB_1.Checked == true)
            {
                dt2 = (dal.getDataTabl("begin_statment_balance_", FromDate.Value.Date, ToDate.Value.Date, UC_Acc1.ID.Text, UC_cost1.ID.Text, UC_Catogry1.ID.Text, FromDate.Value.Date, UC_Branch.ID.Text, db1, Properties.Settings.Default.Currency));
                rpt.DataDefinition.FormulaFields["OB_studs"].Text = "'" + chB_1.Text + "'";

            }
            else
            {
                dt2 = (dal.getDataTabl("begin_statment_balance_", FromDate.Value.Date, ToDate.Value.Date, UC_Acc1.ID.Text, UC_cost1.ID.Text, UC_Catogry1.ID.Text, FromDate.MinDate, UC_Branch.ID.Text, db1, Properties.Settings.Default.Currency));
                rpt.DataDefinition.FormulaFields["OB_studs"].Text = "";
            }

            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);

            //ds.WriteXmlSchema("schema1.xml");

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Cursor = Cursors.Default;
            rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("dd/MM/yyyy") + "'";
            rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("dd/MM/yyyy") + "'";
            rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Acc_name"].Text = "'" + UC_Acc1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
            rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt_EN + "'";
            rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";
            if (dt2.Rows.Count > 0)
            {
                ToWord toWord = new ToWord(Math.Abs(Math.Round(dt2.Rows[0][1].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
                rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";
            }
            else
            {

                ToWord toWord = new ToWord(Math.Abs(Math.Round("0".ToDecimal(), dal.digits_)), currencies[currencyNo]);
                rpt.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

            }
            groupPanel1.Visible = false;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
