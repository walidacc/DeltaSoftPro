using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frm_BalanceSheet : frm_ReportMaster
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_BalanceSheet()
        {
            InitializeComponent();
        }

     
        public override void preview()
        {

            Cursor.Current = Cursors.WaitCursor;
            panel1.Visible = false;

            RPT.rpt_Balance_Sheet rpt = new RPT.rpt_Balance_Sheet();

            DataSet1 ds = new DataSet1();
            DataTable dt1 = new DataTable();

            dt1 = (dal.getDataTabl("Get_BalanceSheet_", FromDate.Value.ToString("yyyy-MM-dd"), ToDate.Value.ToString("yyyy-MM-dd"), "", txtBranch.ID.Text, "", "", "", "", "", dal.db1));
            ds.Tables.Add(dt1);
            ////ds.WriteXmlSchema("schema_rpt.xml");
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            Cursor.Current = Cursors.Default;


            base.preview();
        }

        public override void Option()
        {
            panel1.Visible = true;
            base.Option();
        }
    }
}
