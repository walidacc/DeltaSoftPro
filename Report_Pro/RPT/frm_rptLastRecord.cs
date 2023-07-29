using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frm_rptLastRecord : frm_ReportMaster
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_rptLastRecord()
        {
            InitializeComponent();
        }


        private void reportPreveiw()
        {
            RPT.rpt_lastRecordReport rpt = new RPT.rpt_lastRecordReport();
            DataSet1 ds = new DataSet1();
            DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();

            dt1 = dal.getDataTabl_1(@"SELECT x.code,descr,descr_E,user_id,Y.LD FROM RecordedBranches_tbl as X
                Left join (select code ,MAx(LastDate) as LD from lastRecord_tbl as t group by t.code) as Y on Y.code=X.code  where x.code like '"+txtBranch.ID.Text+ "%' and user_id Like '"+txtUser.ID.Text+ "%' and isnull(Y.LD,'2023-01-01') <='"+txtDate.Value.ToString("yyyy-MM-dd")+"' ");


           
            ds.Tables.Add(dt1);
            ds.WriteXmlSchema("schema1.xml");

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            this.Cursor = Cursors.Default;
            rpt.DataDefinition.FormulaFields["L_Date"].Text = "'" +txtDate.Value.ToString("dd/MM/yyyy") + "'";
           /// rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
            //rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
            //rpt.DataDefinition.FormulaFields["Acc_name"].Text = " '" + UC_Acc1.Desc.Text + "'";
            //rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
            //rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
            //rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
            //rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
            //rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
            rpt.DataDefinition.FormulaFields["Branch"].Text = "'" + txtBranch.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["User"].Text = "'" + txtUser.Desc.Text + "'";


            panel2.Visible = false;


        }

        public override void preview()
        {
            reportPreveiw();
            base.preview();
        }


        public override void Option()
        {
            panel2.Visible = true;
            base.Option();
        }
    }
}
