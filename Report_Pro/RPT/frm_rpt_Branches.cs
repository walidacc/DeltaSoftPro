using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using Report_Pro.DAL;
using Report_Pro.MyControls;
using Report_Pro.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
  public partial class frm_rpt_Branches : frm_ReportMaster
  {
    private DataAccesslayer1 dal = new DataAccesslayer1();


        public frm_rpt_Branches()
        { 
            InitializeComponent();
        }

    private void groupPanel2_Click(object sender, EventArgs e)
    {
    }

        public override void Option()
        {
            groupPanel2.Visible = true;
            base.Option();
        }

        public override void preview()
        {

            groupPanel2.Visible = false;
            rpt_branches_summry rptBranchesSummry = new rpt_branches_summry();
            DataSet1 dataSet1 = new DataSet1();
            DataTable dataTable = new DataTable();
            DataTable dataTabl1 = dal.getDataTabl_1(@"select D.BRANCH_code,B.BRANCH_name,sum (case  when acc_no like '4%' and cast(g_date as date) between '" +
                fromDate.Value.ToString("yyyy/MM/dd") + "' and '" + toDate.Value.ToString("yyyy/MM/dd") + "'  then (loh-meno) end) as sales_  " +
                ", sum (case  when (acc_no like '123%' or ACC_NO like '12708%') and cast(g_date as date)<'" +
                fromDate.Value.ToString("yyyy/MM/dd") + "'  then (meno-loh) end) as Cust_1  " +
                ", sum (case  when (acc_no like '123%' or ACC_NO like '12708%') and cast(g_date as date)<='" +
                toDate.Value.ToString("yyyy/MM/dd") + "'  then (meno-loh) end) as Cust_2  " +
                ", sum (case  when acc_no like '32%' and cast(g_date as date) between '" +
                fromDate.Value.ToString("yyyy/MM/dd") + "'  and '" + toDate.Value.ToString("yyyy/MM/dd") + "'   then (meno-loh) end) as fees_  " +
                ", sum (case  when acc_no like '31%' and cast(g_date as date) between '" +
                fromDate.Value.ToString("yyyy/MM/dd") + "'  and '" + toDate.Value.ToString("yyyy/MM/dd") + "'   then (meno-loh) end) as purch_  " +
                ",sum (case  when acc_no like '121%' and cast(g_date as date) <= '" + toDate.Value.ToString("yyyy/MM/dd") + "'   then (meno-loh) end) as Cash_  " +
                "from daily_transaction as D " +
                "inner join BRANCHS As B on B.BRANCH_code=D.BRANCH_code  " +
                "where D.BRANCH_code like '" + txtBranch.ID.Text +
                "%'  group by D.BRANCH_code,B.BRANCH_name");
            dataSet1.Tables.Add(dataTabl1);
            dataSet1.WriteXmlSchema("schema1.xml");
            rptBranchesSummry.SetDataSource(dataSet1);
            crystalReportViewer1.ReportSource = rptBranchesSummry;

            base.preview();
        }



    private void frm_rep_Fees_Load(object sender, EventArgs e)
    {
            fromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            toDate.Value = DateTime.Today;
        }

      
    }
}
