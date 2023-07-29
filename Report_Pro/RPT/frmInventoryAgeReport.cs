using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frmInventoryAgeReport : frm_ReportMaster
    {

        string btn_name;
        string M_than="0";
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();

        



        public frmInventoryAgeReport()
        {
            InitializeComponent();
            
           

        }



        public override void preview()
        {
            Cursor = Cursors.WaitCursor;

            if (rAll.Checked == true)
            { M_than = "0"; }
            else if (rM_30.Checked == true)
            { M_than = "30"; }
            else if (rM_60.Checked == true)
            { M_than = "60"; }
            else if (rM_90.Checked == true)
            { M_than = "90"; }
            else if (rM_120.Checked == true)
            { M_than = "120"; }
            else if (rM_150.Checked == true)
            { M_than = "150"; }
            else if (rM_180.Checked == true)
            { M_than = "180"; }


            RPT.InventoryAgeReport rpt = new RPT.InventoryAgeReport();
            //DataTable dtMainAcc = dal.getDataTabl_1(@"SELECT DISTINCT acc_no,PAYER_NAME,payer_l_name from payer2 where ACC_NO='"+ Uc_Acc.ID.Text+"'");

            DataTable dt_age = dal.getDataTabl_1(@"select A.ITEM_NO,B.descr,B.group_code
,SUM(CASE WHEN  cast(A.g_date as date) <= '2022-12-31' THEN QTY_ADD - QTY_TAKE ELSE 0 END) AS Ending_balance 
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=0   and DATEDIFF(Day,CAST(A.g_date as date ),'2022-12-31')<=30   THEN QTY_ADD    ELSE 0 END) AS '1-30' 
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=31  and DATEDIFF(Day,CAST(A.g_date as date ),'2022-12-31')<=60   THEN QTY_ADD    ELSE 0 END) AS '31-60'
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=61  and DATEDIFF(Day,CAST(A.g_date as date ),'2022-12-31')<=90   THEN QTY_ADD    ELSE 0 END) AS '61-90'
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=91  and DATEDIFF(Day,CAST(A.g_date as date ),'2022-12-31')<=120  THEN QTY_ADD    ELSE 0 END) AS '91-120' 
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=121 and DATEDIFF(Day,CAST(A.g_date as date ),'2022-12-31')<=150  THEN QTY_ADD    ELSE 0 END) AS '121-250'
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=151 and DATEDIFF(Day,CAST(A.g_date as date ),'2022-12-31')<=180  THEN QTY_ADD    ELSE 0 END) AS '151-180'
,SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ) ,'2022-12-31')>=181  THEN QTY_ADD    ELSE 0 END) AS more180   
from wh_material_transaction as A 
inner join wh_main_master  as B on A.ITEM_NO=B.item_no 
where A.item_no like '%' and B.group_code like '%' and Cyear='22'
group by a.ITEM_NO,b.descr,B.group_code");
           



//select A.ITEM_NO,B.descr
//		,SUM(CASE WHEN cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN QTY_ADD - QTY_TAKE ELSE 0 END) AS Ending_balance " +
//        ", SUM(CASE WHEN  DATEDIFF(Day,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=0 and DATEDIFF(Day   ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=30    THEN QTY_ADD    ELSE 0 END) AS '1-30' " +
//        ",SUM(CASE WHEN  DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=31 and DATEDIFF(Day  ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=60    THEN QTY_ADD    ELSE 0 END) AS '31-60' " +
//        ",SUM(CASE WHEN  DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=61 and DATEDIFF(Day  ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=90    THEN QTY_ADD    ELSE 0 END) AS '61-90' " +
//        ",SUM(CASE WHEN  DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=91 and DATEDIFF(Day  ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=120   THEN QTY_ADD    ELSE 0 END) AS '91-120' " +
//        ",SUM(CASE WHEN  DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=121 and DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=150  THEN QTY_ADD    ELSE 0 END) AS '121-250' " +
//        ",SUM(CASE WHEN  DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=151 and DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')<=180  THEN QTY_ADD    ELSE 0 END) AS '151-180' " +
//        ",SUM(CASE WHEN  DATEDIFF(Day ,CAST(A.g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd") + "')>=181  THEN QTY_ADD    ELSE 0 END) AS more180    " +
//        " from wh_material_transaction as A "+
//        "inner join wh_main_master as B on A.ITEM_NO = B.item_no" +
//        "where A.item_no like '%' and B.group_code like '%' and Cyear='22' " +
//        "group by A.ITEM_NO,B.descr");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt_age);
            ds.WriteXmlSchema("schema_rpt.xml");
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            rpt.DataDefinition.FormulaFields["M_"].Text = "'" + M_than + "'";
            rpt.SetParameterValue("EnterLanguh", cmbLanguh.SelectedIndex.ToString());
            if (cmbLanguh.SelectedIndex == 1)
            {
                rpt.DataDefinition.FormulaFields["Date_"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
            //    rpt.DataDefinition.FormulaFields["Acc_"].Text = " '" + dtMainAcc.Rows[0]["descr"].ToString() + "'";
                rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
                rpt.DataDefinition.FormulaFields["Branch_Name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";
            }
            else
            {
                rpt.DataDefinition.FormulaFields["Date_"].Text = "'" + ToDate.Value.ToString("dd/MM/yyyy") + "'";
               // rpt.DataDefinition.FormulaFields["Acc_"].Text = " '" + dtMainAcc.Rows[0]["payer_l_name"].ToString() + "'";
                rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt_EN + "'";
                rpt.DataDefinition.FormulaFields["Branch_Name"].Text = "'" + Properties.Settings.Default.Branch_txt_EN + "'";
            }

            groupPanel1.Visible = false;
            Cursor = Cursors.Default;


            base.preview();
        }


        private void Report_btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (rAll.Checked == true)
            { M_than = "0"; }
            else if (rM_30.Checked == true)
            { M_than = "30"; }
            else if (rM_60.Checked == true)
            { M_than = "60"; }
            else if (rM_90.Checked == true)
            { M_than = "90"; }
            else if (rM_120.Checked == true)
            { M_than = "120"; }
            else if (rM_150.Checked == true)
            { M_than = "150"; }
            else if (rM_180.Checked == true)
            { M_than = "180"; }


            RPT.AgeReport rpt = new RPT.AgeReport();

            DataTable dt_age = dal.getDataTabl_1(@"select a.acc_no,b.PAYER_NAME,a.BRANCH_code,c.BRANCH_name
		,SUM(CASE WHEN cast(A.g_date as date) <= '" + ToDate.Value.ToString("yyyy-MM-dd") + "' THEN meno - loh ELSE 0 END) AS Ending_balance " +
        ", SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd")+"')>=0 and DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+"')<=30  THEN meno    ELSE 0 END) AS '1-30' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+"')>=31 and DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+ "')<=60  THEN meno    ELSE 0 END) AS '31-60' " +
        ",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd")+"')>=61 and DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+ "')<=90  THEN meno    ELSE 0 END) AS '61-90' " +
        ",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd")+"')>=91 and DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+ "')<=120  THEN meno    ELSE 0 END) AS '91-120' " +
        ",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd")+"')>=121 and DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+ "')<=150  THEN meno    ELSE 0 END) AS '121-250' " +
        ",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd")+"')>=151 and DATEDIFF(Day,CAST(g_date as date ),'"+ ToDate.Value.ToString("yyyy-MM-dd")+ "')<=180  THEN meno    ELSE 0 END) AS '151-180' " +
        ",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'" + ToDate.Value.ToString("yyyy-MM-dd")+"')>=181  THEN meno    ELSE 0 END) AS more180    " +
        "from daily_transaction as A  " +
        "inner join payer2 as B on A.ACC_NO=b.ACC_NO and a.BRANCH_code=b.BRANCH_code " +
        "inner join BRANCHS as C on A.BRANCH_code=c.BRANCH_code " +
        "where A.ACC_NO like '"+Uc_Acc.ID.Text+"%' and ISNULL(A.COST_CENTER,'') like '%'  and a.BRANCH_code like '%' " +
        "group by a.ACC_NO,b.PAYER_NAME,a.BRANCH_code,c.BRANCH_name");

            rpt.SetDataSource (dt_age);
           // rpt.SetDataSource(dal.getDataTabl("AgeReport_",FromDate.Value.Date,ToDate.Value.Date,Uc_Acc.ID.Text,Uc_Cost.ID.Text,Uc_Catogry.ID.Text,Uc_Branch.ID.Text,dal.db1));
            crystalReportViewer1.ReportSource = rpt;
            rpt.DataDefinition.FormulaFields["M_"].Text = "'"+M_than+"'";
            rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
            rpt.DataDefinition.FormulaFields["Branch_Name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";
            rpt.DataDefinition.FormulaFields["Date_"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["Acc_"].Text = " '" + Uc_Acc.Desc.Text + "'";
            groupPanel1.Visible = false;
            Cursor = Cursors.Default;
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            groupPanel1.Visible = true;
        }


       
       

        private void Branch_name_MultilineChanged(object sender, EventArgs e)
        {
           
        }

        

       

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



     
      

      


      

        private void frm_statment_Rpt_Load(object sender, EventArgs e)
        {
            FromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            ToDate.Value = DateTime.Today;
        }

      
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void frmAgeReport_Load(object sender, EventArgs e)
        {

        }

        private void buttonX5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        // vendors aging
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (rAll.Checked == true)
            { M_than = "0"; }
            else if (rM_30.Checked == true)
            { M_than = "30"; }
            else if (rM_60.Checked == true)
            { M_than = "60"; }
            else if (rM_90.Checked == true)
            { M_than = "90"; }
            else if (rM_120.Checked == true)
            { M_than = "120"; }
            else if (rM_150.Checked == true)
            { M_than = "150"; }
            else if (rM_180.Checked == true)
            { M_than = "180"; }


            RPT.Supp_AgeReport rpt = new RPT.Supp_AgeReport();
            rpt.SetDataSource(dal.getDataTabl_1(@"select A.*,p.PAYER_NAME from ( select acc_no
		,SUM(CASE WHEN cast(g_date as date) <= '"+ToDate.Value.ToString("yyyy/MM/dd")+"' THEN loh - meno ELSE 0 END) AS Ending_balance "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=0 and DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')<=30  THEN loh    ELSE 0 END) AS '1-30' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=31 and DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')<=60  THEN loh    ELSE 0 END) AS '31-60' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=61 and DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')<=90  THEN loh    ELSE 0 END) AS '61-90' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=91 and DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')<=120  THEN loh    ELSE 0 END) AS '91-120' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=121 and DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')<=150  THEN loh    ELSE 0 END) AS '121-250' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=151 and DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')<=180  THEN loh    ELSE 0 END) AS '151-180' "+
		",SUM(CASE WHEN  DATEDIFF(Day,CAST(g_date as date ),'"+ToDate.Value.ToString("yyyy/MM/dd")+"')>=181  THEN loh    ELSE 0 END) AS more180 "+
	    " from daily_transaction  where ACC_NO like '"+Uc_Acc.ID.Text+"%'	 group by ACC_NO  ) as A  "+
	    "inner join ( select * from ( select   acc_no ,PAYER_NAME "+
        ",ROW_NUMBER() OVER(PARTITION BY Acc_no ORDER BY acc_no) AS DuplicateCount "+
        "from payer2 ) as B where b.DuplicateCount =1) as P on P.ACC_NO =a.ACC_NO order by A.ACC_NO"));
            //, FromDate.Value.Date, ToDate.Value.Date, Uc_Acc.ID.Text, Uc_Cost.ID.Text, Uc_Catogry.ID.Text, Uc_Branch.ID.Text, dal.db1));



            crystalReportViewer1.ReportSource = rpt;
            rpt.DataDefinition.FormulaFields["M_"].Text = "'" + M_than + "'";
            rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
            rpt.DataDefinition.FormulaFields["Branch_Name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";
            rpt.DataDefinition.FormulaFields["Date_"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["Acc_"].Text = " '" + Uc_Acc.Desc.Text + "'";
            groupPanel1.Visible = false;
            Cursor = Cursors.Default;


        }
    }
       
}
