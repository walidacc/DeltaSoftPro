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
  public partial class frm_rep_Fees : frm_ReportMaster
  {
    private DataAccesslayer1 dal = new DataAccesslayer1();


        public frm_rep_Fees()
        { 
            InitializeComponent();
        }

    private void groupPanel2_Click(object sender, EventArgs e)
    {
    }

        public override void preview()
        {
            groupPanel2.Visible = false;

            DataSet dataSet1 = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTabl1 = dal.getDataTabl_1("select  C.Gr_Code,C.Gr_name," +
                "  SUM(CASE WHEN B.Temp1 like '" + Acc_Group.ID.Text + "%' and A.Cost_Center Like '" + UcCost.ID.Text + "%'  and (A.acc_no like '321%' or A.acc_no like '324%') and A.Acc_no not in ('3210135','3210139','3210163','3210164')   and CAST(A.g_date as date) between '" + this.fromDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.toDate.Value.ToString("yyyy-MM-dd") + "' THEN  meno-loh else 0 END) as GA_ " +
                ", SUM(CASE WHEN B.Temp1 like '" + Acc_Group.ID.Text + "%' and A.Cost_Center Like '" + UcCost.ID.Text + "%' and A.acc_no like '322%' and A.Acc_no not in ('3220135','3220139','3220163','3220164','3220168') and CAST(A.g_date as date) between '" + this.fromDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.toDate.Value.ToString("yyyy-MM-dd") + "' THEN  meno-loh else 0 END) as Sal_ " +
                ", SUM(CASE WHEN B.Temp1 like '" + Acc_Group.ID.Text + "%' and A.Cost_Center Like '" + UcCost.ID.Text + "%' and (A.acc_no like '325%' or A.Acc_no in ('3210135','3210139','3210163','3210164','3210168','3220135','3220139','3220163','3220164','3220168'))  and CAST(A.g_date as date) between '" + this.fromDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.toDate.Value.ToString("yyyy-MM-dd") + "' THEN  meno-loh else 0 END) as Indust_ " +
                ", SUM(CASE WHEN B.Temp1 like '" + Acc_Group.ID.Text + "%' and A.Cost_Center Like '" + UcCost.ID.Text + "%' and (A.acc_no like '321%' or A.acc_no like '324%')  and A.Acc_no not in ('3210135','3210139','3210163','32164') and CAST(A.g_date as date) between DATEADD(year, -1, '" + this.fromDate.Value.ToString("yyyy-MM-dd") + "') and DATEADD(year, -1, '" + this.toDate.Value.ToString("yyyy-MM-dd") + "') THEN  meno-loh else 0 END) as prev_GA_ " +
                ", SUM(CASE WHEN B.Temp1 like '" + Acc_Group.ID.Text + "%' and A.Cost_Center Like '" + UcCost.ID.Text + "%' and A.acc_no like '322%' and A.Acc_no not in ('3220135','3220139','3220163','3220164','3220168') and CAST(A.g_date as date) between DATEADD(year, -1, '" + this.fromDate.Value.ToString("yyyy-MM-dd") + "') and DATEADD(year, -1, '" + this.toDate.Value.ToString("yyyy-MM-dd") + "') THEN  meno-loh else 0 END) as prev_Sal_ " +
                ", SUM(CASE WHEN B.Temp1 like '" + Acc_Group.ID.Text + "%' and A.Cost_Center Like '" + UcCost.ID.Text + "%' and (A.acc_no like '325%' or A.Acc_no in ('3210135','3210139','3210163','3210164','3210168','3220135','3220139','3220163','3220164','3220168')) and CAST(A.g_date as date) between DATEADD(year, -1, '" + this.fromDate.Value.ToString("yyyy-MM-dd") + "') and DATEADD(year, -1, '" + this.toDate.Value.ToString("yyyy-MM-dd") + "') THEN  meno-loh else 0 END) as prev_Indust_ " +
                ", c.Prev_no,d.Gr_name " +
                "from daily_transaction  as A  " +
                "inner join payer2 as b  on A.ACC_NO=B.ACC_NO and A.BRANCH_code = b.BRANCH_code " +
                "inner join Wh_Costmers_Vendors_Group as C on b.Temp1 =C.Gr_Code " +
                "inner join Wh_Costmers_Vendors_Group as D on C.Prev_no =D.Gr_Code " +
                "where A.BRANCH_code like '" + txtBranch.ID.Text + "%' and A.acc_no like '" + txtAcc.ID.Text + 
                "%'  group by  C.Gr_Code,C.Gr_name,c.Prev_no,d.Gr_name");
            dataSet1.Tables.Add(dataTabl1);
            dataSet1.WriteXmlSchema("schema1.xml");

            if (rdo1.Checked == true)
            {
                rpt_feesReport rptFeesReport = new rpt_feesReport();
                rptFeesReport.SetDataSource(dataTabl1);
                crystalReportViewer1.ReportSource = rptFeesReport;
                FormulaFieldDefinition formulaField1 = rptFeesReport.DataDefinition.FormulaFields["From_date"];
                DateTime dateTime = fromDate.Value;
                string str1 = "'" + dateTime.ToString("yyyy/MM/dd") + "'";
                formulaField1.Text = str1;
                FormulaFieldDefinition formulaField2 = rptFeesReport.DataDefinition.FormulaFields["To_Date"];
                dateTime = toDate.Value;
                string str2 = "'" + dateTime.ToString("yyyy/MM/dd") + "'";
                formulaField2.Text = str2;
                rptFeesReport.DataDefinition.FormulaFields["company_name"].Text = "'" + Settings.Default.head_txt + "'";
                rptFeesReport.DataDefinition.FormulaFields["Branch_Name"].Text = "'" + Settings.Default.Branch_txt + "'";
                rptFeesReport.DataDefinition.FormulaFields["Branch_"].Text = "'" + txtBranch.Desc.Text + "'";
                rptFeesReport.DataDefinition.FormulaFields["Acc_Group"].Text = "'" + Acc_Group.Desc.Text + "'";
            }
            else
            {
                rpt_feesReport_detials rptFeesReport = new rpt_feesReport_detials();
                rptFeesReport.SetDataSource(dataTabl1);
                crystalReportViewer1.ReportSource = rptFeesReport;
                FormulaFieldDefinition formulaField1 = rptFeesReport.DataDefinition.FormulaFields["From_date"];
                DateTime dateTime = fromDate.Value;
                string str1 = "'" + dateTime.ToString("yyyy/MM/dd") + "'";
                formulaField1.Text = str1;
                FormulaFieldDefinition formulaField2 = rptFeesReport.DataDefinition.FormulaFields["To_Date"];
                dateTime = toDate.Value;
                string str2 = "'" + dateTime.ToString("yyyy/MM/dd") + "'";
                formulaField2.Text = str2;
                rptFeesReport.DataDefinition.FormulaFields["company_name"].Text = "'" + Settings.Default.head_txt + "'";
                rptFeesReport.DataDefinition.FormulaFields["Branch_Name"].Text = "'" + Settings.Default.Branch_txt + "'";
                rptFeesReport.DataDefinition.FormulaFields["Branch_"].Text = "'" + txtBranch.Desc.Text + "'";
                rptFeesReport.DataDefinition.FormulaFields["Acc_Group"].Text = "'" + Acc_Group.Desc.Text + "'";
            }



            base.preview();
        }



        public override void Option()
        {
            groupPanel2.Visible = true;
            base.Option();
        }

      
   
    private void frm_rep_Fees_Load(object sender, EventArgs e)
    {
        Acc_Group.txtFinal.Text = "0";
            fromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            toDate.Value = DateTime.Today;
        }

        
    }
}
