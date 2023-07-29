using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class list_H_price : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
       
        public list_H_price()
        {
            InitializeComponent();
         }

        private void Form1_Load(object sender, EventArgs e)
        {
            fromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            toDate.Value = DateTime.Today;
            get_last_Sales();
        }



        private void get_last_Sales()
        {
            
            DataTable dt_Ls = dal.getDataTabl_1(@"select A.ser_no,A.G_DATE,A.QTY_TAKE,A.Local_Price,P.PAYER_NAME,C.branch_name,A.Branch_code,a.Cyear, A.TRANSACTION_CODE  from wh_material_transaction as A
            inner join wh_inv_data as B on A.SER_NO=B.Ser_no and A.TRANSACTION_CODE=B.TRANSACTION_CODE and a.Branch_code=b.Branch_code and a.Cyear=b.Cyear
            inner join payer2 as P on p.ACC_NO=b.Acc_no and b.Acc_Branch_code=p.BRANCH_code
            inner join wh_BRANCHES As C on A.Branch_code=C.Branch_code 
            where  B.Acc_no like '"+txtAcc.ID.Text+"%' and  item_no='" + txtItem.ID.Text + "'  and A.Branch_code like '" + txtBranch.ID.Text + "%'  and cast(A.G_DATE as Date) between '" + fromDate.Value.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.ToString("yyyy-MM-dd") + "' and A.TRANSACTION_CODE like 'xs%' order by G_DATE desc");



            if (dt_Ls.Rows.Count > 0)
            {

                dgv_LS.RowCount = dt_Ls.Rows.Count;

                for (int ii = 0; ii < dgv_LS.RowCount; ii++)
                {
                    dgv_LS.Rows[ii].Cells[0].Value = dt_Ls.Rows[ii]["branch_name"].ToString();
                    dgv_LS.Rows[ii].Cells[1].Value = dt_Ls.Rows[ii]["ser_no"].ToString();
                    dgv_LS.Rows[ii].Cells[2].Value = dt_Ls.Rows[ii]["G_DATE"];
                    dgv_LS.Rows[ii].Cells[3].Value = dt_Ls.Rows[ii]["QTY_TAKE"];
                    dgv_LS.Rows[ii].Cells[4].Value = dt_Ls.Rows[ii]["Local_Price"];

                    if (txtItem.itemWeight.Value > 0)
                    {
                        dgv_LS.Rows[ii].Cells[5].Value = (Math.Round(dt_Ls.Rows[ii]["Local_Price"].ToString().ToDecimal() / txtItem.itemWeight.Text.ToDecimal() * 1000, 0)).ToString("N0");
                    }
                    else
                    {
                        dgv_LS.Rows[ii].Cells[5].Value = 0;
                    }
                    dgv_LS.Rows[ii].Cells[6].Value = dt_Ls.Rows[ii]["PAYER_NAME"].ToString();
                    dgv_LS.Rows[ii].Cells[7].Value = dt_Ls.Rows[ii]["Branch_code"].ToString();
                    dgv_LS.Rows[ii].Cells[8].Value = dt_Ls.Rows[ii]["Cyear"].ToString();
                    dgv_LS.Rows[ii].Cells[9].Value = dt_Ls.Rows[ii]["TRANSACTION_CODE"].ToString();
                }
            }
            else
            {
                dgv_LS.DataSource = null;
                dgv_LS.Rows.Clear();
            }





        }




        private void list_H_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            get_last_Sales();
        }
    }
}
