using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frm_statmentOfIncom : frm_ReportMaster
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string bal = "1";
        string lvl = "";
        string Acc_Kind = "";
        public frm_statmentOfIncom()
        {
            InitializeComponent();

           OP.FromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            OP.ToDate.Value = DateTime.Today;
        }


        private void choises()
        {
           
            if (OP.RBtnAll.Checked == true)
            { lvl = ""; }
            if (OP.RBtn1.Checked == true)
            { lvl = "0"; }
            if (OP.RBtn2.Checked == true)
            { lvl = "1"; }
            if (OP.RBtn3.Checked == true)
            { lvl = "2"; }
            if (OP.RBtn4.Checked == true)
            { lvl = "3"; }

            
            if (OP.RB1.Checked == true)
            { bal = "1"; }
            if (OP.RB2.Checked == true)
            { bal = "2"; }
            if (OP.RB3.Checked == true)
            { bal = "3"; }

            if (OP.RB4.Checked == true)
            { bal = "4"; }

            
            if (OP.RB_All_Acc.Checked == true)
            { Acc_Kind = ""; }
            else if (OP.RB_M_Acc.Checked == true)
            { Acc_Kind = "0"; }
            else if (OP.RB_S_Acc.Checked == true)
            { Acc_Kind = "1"; }
        }

        public override void Report()
        {


            Cursor.Current = Cursors.WaitCursor;

            //try
            //{

            tableLayoutPanel1.Visible = true;
            crystalReportViewer1.Visible = false;

            choises();

            //  DataTable Tb_dt=new DataTable();

            DataTable Tb_dt = dal.getDataTabl("Get_Income_", OP.FromDate.Value.Date, OP.ToDate.Value.Date, OP.txtAcc.ID.Text, OP.txtBranch.ID.Text, lvl, bal, Acc_Kind, Properties.Settings.Default.closeAcc, "", Properties.Settings.Default.Database_1, OP.txtCost.ID.Text);





            int B_rowscount = Tb_dt.Rows.Count;
            DataGridView1.Rows.Clear();
            DataGridView1.Rows.Add(B_rowscount);
            for (int i = 0; (i
                       <= (B_rowscount - 1)); i++)
            {


                DataGridView1.Rows[i].Cells[0].Value = Tb_dt.Rows[i]["acc_no"];
                DataGridView1.Rows[i].Cells[1].Value = Tb_dt.Rows[i]["PAYER_NAME"];
                DataGridView1.Rows[i].Cells[2].Value = Tb_dt.Rows[i]["t_level"];
                DataGridView1.Rows[i].Cells[3].Value = Tb_dt.Rows[i]["t_final"];
                DataGridView1.Rows[i].Cells[4].Value = Tb_dt.Rows[i]["B_balance"];
                DataGridView1.Rows[i].Cells[5].Value = Tb_dt.Rows[i]["db"];
                DataGridView1.Rows[i].Cells[6].Value = Tb_dt.Rows[i]["cr"];
                DataGridView1.Rows[i].Cells[7].Value = Tb_dt.Rows[i]["E_balance"];

            }
            total_TB();

            //}

            //catch
            //{
            //}

            OP.Visible = false;
            Cursor.Current = Cursors.Default;


            base.Report();
        }

        public override void preview()
        {

            Cursor.Current = Cursors.WaitCursor;
            tableLayoutPanel1.Visible = false;
            crystalReportViewer1.Visible = true;
            choises();
            DataTable Tb_dt = dal.getDataTabl("Get_Income_", OP.FromDate.Value.Date, OP.ToDate.Value.Date, OP.txtAcc.ID.Text, OP.txtBranch.ID.Text, lvl, bal, Acc_Kind, Properties.Settings.Default.closeAcc, "", Properties.Settings.Default.Database_1, OP.txtCost.ID.Text);
            RPT.rpt_statmentOfIncome rpt = new RPT.rpt_statmentOfIncome();
            DataSet ds = new DataSet();
            ds.Tables.Add(Tb_dt);
            ds.WriteXmlSchema("schema_rpt.xml");
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;

            OP.Visible = false;
            Cursor.Current = Cursors.Default;

            base.preview();
        }


        public override void Option()
        {
            OP.Visible = true;
            base.Option();
        }

          void total_TB()
        {
            T_Bb.Text =
                (from DataGridViewRow row in DataGridView1.Rows
                 where row.Cells[4].FormattedValue.ToString() != string.Empty && row.Cells[2].FormattedValue.ToString() == "0"
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[4].FormattedValue).ToString().ToDecimal()).Sum().ToString();
            T_Db.Text =
                (from DataGridViewRow row in DataGridView1.Rows
                 where row.Cells[5].FormattedValue.ToString() != string.Empty && row.Cells[2].FormattedValue.ToString() == "0"
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[5].FormattedValue).ToString().ToDecimal()).Sum().ToString();

            T_Cr.Text =
                (from DataGridViewRow row in DataGridView1.Rows
                 where row.Cells[6].FormattedValue.ToString() != string.Empty && row.Cells[2].FormattedValue.ToString() == "0"
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[6].FormattedValue).ToString().ToDecimal()).Sum().ToString();

            T_Eb.Text =
                (from DataGridViewRow row in DataGridView1.Rows
                 where row.Cells[7].FormattedValue.ToString() != string.Empty && row.Cells[2].FormattedValue.ToString() == "0"
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[7].FormattedValue).ToString().ToDecimal()).Sum().ToString();

        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            OP.Visible = true;
        }

      
    }
}
