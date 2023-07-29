using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

namespace Report_Pro.PL
{
    public partial class invoice_list_frm : Form
    {
        //BL.Cls_orders ord = new BL.Cls_orders();
        public string trans_code, trans_code_1;
        string cy=  Properties.Settings.Default.C_year;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public invoice_list_frm()

        {
            InitializeComponent();
       
        }


     

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            search_();
         // this.dg_orders_list.DataSource = dal.getDataTabl("serch_orders", txtSrch.Text.ToString(), trans_code, trans_code_1, cy);
        }

        private void search_()
        {
            //this.dg_orders_list.DataSource = dal.getDataTabl("serch_orders", txtSrch.Text.ToString(), trans_code, trans_code_1, cy);
            dg_orders_list.DataSource = dal.getDataTabl_1(@"SELECT Ser_no,G_date,PAYER_NAME,Inv_Notes,NetAmount,Payment_name,Sales_man_Id,Transaction_code,Cyear	  
FROM wh_inv_data as A
inner join payer2 as B
on B.ACC_NO=A.Acc_no and b.BRANCH_code=A.Branch_code
inner join wh_Payment_type As C on  A.Payment_Type=C.Payment_type

where Ser_no like  (CASE WHEN '" + txtSrch.Text.ToString() + "'<>'' then '" + txtSrch.Text.ToString() + "' else  '" + txtSrch.Text.ToString() + "%' end) " +
"and PAYER_NAME like '" + txtSearch2.Text.ToString() +
"%' and Cyear='"+cmbYear.SelectedValue+
"'  and (Transaction_code='" + trans_code+"' or Transaction_code='"+ trans_code_1+"')  and A.Branch_code='"+Properties.Settings.Default.BranchId+"' ");


            this.dg_orders_list.Columns[0].Width = 50;
            this.dg_orders_list.Columns[1].Width = 120;
            this.dg_orders_list.Columns[2].Width = 150;
            this.dg_orders_list.Columns[3].Width = 120;
            this.dg_orders_list.Columns[4].Width = 100;
            this.dg_orders_list.Columns[5].Width = 125;
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            string printModel = Properties.Settings.Default.inv_print;

            string invnu = Convert.ToString(dg_orders_list.CurrentRow.Cells[0].Value);
            string Trans_id = Convert.ToString(dg_orders_list.CurrentRow.Cells[7].Value);
            string cyear_ = Convert.ToString(dg_orders_list.CurrentRow.Cells[8].Value);
            if (Trans_id == "XPC" || Trans_id == "XPD")
            {
                if (printModel == "1")
                {
                    RPT.Rpt_Purch_inv reportInv = new RPT.Rpt_Purch_inv();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
                else
                {
                    RPT.Rpt_Purch_inv_1 reportInv = new RPT.Rpt_Purch_inv_1();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
            }

            else if (Trans_id == "XSC" || Trans_id == "XSD")
            {
                if (printModel == "1")
                {
                    RPT.Rpt_inv reportInv = new RPT.Rpt_inv();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
                else
                {
                    RPT.Rpt_inv_1 reportInv = new RPT.Rpt_inv_1();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }


            }

            else if (Trans_id == "XSR" || Trans_id == "XST")
            {
                if (printModel == "1")
                {
                    RPT.Rpt_inv_REturn reportInv = new RPT.Rpt_inv_REturn();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }

                else
                {
                    RPT.Rpt_inv_Return_1 reportInv = new RPT.Rpt_inv_Return_1();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
            }

            else if (Trans_id == "XPR")
            {
                if (printModel == "1")
                {
                    RPT.Rpt_Purchase_returen reportInv = new RPT.Rpt_Purchase_returen();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
                else
                {
                    RPT.Rpt_Purchase_returen_1 reportInv = new RPT.Rpt_Purchase_returen_1();
                    RPT.Form1 frminv = new RPT.Form1();
                    reportInv.SetDataSource(dal.getDataTabl("get_invDetails", invnu, Trans_id, cyear_));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
                }
            }
        }
          

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("فضلا.. تاكد من ارقام الفواتير  ", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //string invnu = Convert.ToString("");
                RPT.RptAll_Inv reportInv = new RPT.RptAll_Inv();

                RPT.Form1 frminv = new RPT.Form1();
                reportInv.SetDataSource(dal.getDataTabl("getAllInv", trans_code, trans_code_1, cy,textBox1.Text,textBox2.Text));
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();
            }
        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            search_();
        }

        private void order_list_frm_Load(object sender, EventArgs e)
        {

            cmbYear.DataSource = dal.getDataTabl_1(@"select DISTINCT Cyear from wh_inv_data");

            cmbYear.DisplayMember = "Cyear";
            cmbYear.ValueMember = "Cyear";
            cmbYear.SelectedValue = Properties.Settings.Default.C_year;
            //if (checkBox1.Checked == true)
            //{

            search_();

               //this.dg_orders_list.DataSource = dal.getDataTabl("serch_orders", txtSrch.Text.ToString(), trans_code, trans_code_1, cy);
               // this.dg_orders_list.Columns[0].Width = 50;
               // this.dg_orders_list.Columns[1].Width = 120;
               // this.dg_orders_list.Columns[2].Width = 150;
               // this.dg_orders_list.Columns[3].Width = 120;
               // this.dg_orders_list.Columns[4].Width = 100;
               // this.dg_orders_list.Columns[5].Width = 125;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    cy = Properties.Settings.Default.C_year;
            //}
            //else
            //{
            //    cy = "";
            //}
            //search_();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            search_();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            search_();
        }

        private void dg_orders_list_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
