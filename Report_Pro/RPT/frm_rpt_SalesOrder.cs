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
    public partial class frm_rpt_SalesOrder : frm_ReportMaster
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_rpt_SalesOrder()
        {
            InitializeComponent();
        }

        public override void preview()
        {
            groupPanel1.Visible = false;
            Cursor = Cursors.WaitCursor;
            DataSet ds = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dt_ = dal.getDataTabl_1(@"SELECT A.Acc_no,A.Ser_no,A.Branch_code,A.G_date,A.Cyear,A.Transaction_code,A.ITEM_NO,A.QTY_TAKE,A.PAYER_NAME,A.payer_l_name,A.descr,A.Descr_eng,A.QTY_ACT
              FROM VIEW_Get_All_Sale_order as A
             where A.BRANCH_code like '" + txtStore.ID.Text + "%' and A.acc_no like '" + txtAcc.ID.Text +
                "%' and cast(g_date as date) between '"+fromDate.Value.ToString("yyyy-MM-dd")+"' and '"+ toDate.Value.ToString("yyyy-MM-dd")+"'");
            ds.Tables.Add(dt_);
            ds.WriteXmlSchema("schema1.xml");
            RPT.rpt_salesOrders rpt = new RPT.rpt_salesOrders();

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;

            rpt.DataDefinition.FormulaFields["fromDate"].Text = "'" + fromDate.Value.ToString("dd/MM/yyyy") + "'" ;
            rpt.DataDefinition.FormulaFields["toDate"].Text = "'" + fromDate.Value.ToString("dd/MM/yyyy") + "'";




            Cursor = Cursors.Default;

            base.preview();
        }

        public override void Option()
        {
            groupPanel1.Visible = true;
            base.Option();
        }
    }
}
