using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_PoApproved : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();      
        DataTable dtPO = new DataTable();
        public frm_PoApproved()
        {
            InitializeComponent();
        }

       

        private void getData()
        {
            string approve = "";
            if (chApproved.Checked)
            { approve = "1"; }
            else
            {
                approve = "9";
            }
            string notApprove = "";
            if (chNotApproved.Checked)
            { notApprove = ""; }
            else
            {
                notApprove = "9";
            }


            dtPO = dal.getDataTabl_1(@"select A.Ser_no,A.Branch_code,WB.branch_name,WB.WH_E_NAME,a.G_date ,A.Cyear,A.Transaction_code,A.Acc_no,P.PAYER_NAME,P.payer_l_name,A.User_id,U.USER_NAME,A.Confermed
            from wh_Po_Cot_inv_data as A
            inner join payer2 as P  on p.ACC_NO = A.Acc_no and P.BRANCH_code = A.Acc_Branch_code
            inner join wh_BRANCHES as WB  on A.Branch_code = WB.Branch_code
            inner join wh_USERS as U on A.User_id = U.USER_ID
            where A.Transaction_code = 'PS' and isnull(A.Po_Status,'') <> 'S' and isnull(A.CANCELED,'') <>'C'
            and CASt(A.G_DAte as date) between '" + txtFromDate.Value.ToString("yyyy-MM-dd")+ "' and '" + txtToDate.Value.ToString("yyyy-MM-dd") +
            "' and A.Branch_code like '"+txtBranch.ID.Text+
            "%' and a.Acc_no like '"+txtAcc.ID.Text+
            "%' and (isnull(A.Confermed,'') ='"+approve+ "' or isnull(A.Confermed,'') ='" + notApprove + 
            "') and a.User_id like '"+txtUser.ID.Text+"%'");
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            getData();
            dgv1.Rows.Clear();
          
            int db_rowscount = dtPO.Rows.Count;
            int db_dgvrows = db_rowscount;

            if (dtPO.Rows.Count > 0)
            {
                dgv1.Rows.Add(db_dgvrows);
                for (int i = 0; i <= (db_rowscount - 1); i++)
                {
                    dgv1.Rows[i].Cells[colSerNo.Name].Value = dtPO.Rows[i]["Ser_no"].ToString();
                    dgv1.Rows[i].Cells[colBranchCode.Name].Value = dtPO.Rows[i]["Branch_code"].ToString();
                    dgv1.Rows[i].Cells[colBranch.Name].Value = dtPO.Rows[i]["branch_name"].ToString();
                    dgv1.Rows[i].Cells[colYear.Name].Value = dtPO.Rows[i]["Cyear"].ToString();
                    dgv1.Rows[i].Cells[colDate.Name].Value = dtPO.Rows[i]["G_date"].ToString();
                    dgv1.Rows[i].Cells[colTransactionCode.Name].Value = dtPO.Rows[i]["Transaction_code"].ToString();
                    dgv1.Rows[i].Cells[colAccNo.Name].Value = dtPO.Rows[i]["Acc_no"].ToString();
                    dgv1.Rows[i].Cells[colVendor.Name].Value = dtPO.Rows[i]["PAYER_NAME"].ToString();
                    dgv1.Rows[i].Cells[colUserID.Name].Value = dtPO.Rows[i]["User_id"].ToString();
                    dgv1.Rows[i].Cells[colUser.Name].Value = dtPO.Rows[i]["USER_NAME"].ToString();
                    dgv1.Rows[i].Cells[colConfirmed.Name].Value = dtPO.Rows[i]["Confermed"].ToString();


                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
         
            string _ser = dgv1.CurrentRow.Cells[colSerNo.Name].Value.ToString();
            string _branch = dgv1.CurrentRow.Cells[colBranchCode.Name].Value.ToString();
            string _transaction = dgv1.CurrentRow.Cells[colTransactionCode.Name].Value.ToString();
            string _year = dgv1.CurrentRow.Cells[colYear.Name].Value.ToString();
            var frm = new PL.frm_PurchaseOrder_1(_ser, _branch, _transaction, _year);
            Forms.frm_Main.OpenForm(frm, true);

        }

       
    }
}
