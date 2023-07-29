using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_SearchClient : XtraForm
    {
        public int x_=100, y_=100;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string _tFinal = "1";

        public string Client_Vendor;
        public frm_SearchClient()
        {
            InitializeComponent();
            searchAcc_();
            txtSearchName.Focus();
        }

        private void frm_SearchAcc_Load(object sender, EventArgs e)
        {
            searchAcc_();
           
        }

        private void txtsearchID_TextChanged(object sender, EventArgs e)
        {
            searchAcc_();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            searchAcc_();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchAcc_();
        }

        private void radioTransaction_CheckedChanged(object sender, EventArgs e)
        {
            searchAcc_();
        }

        private void DGV1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchAcc_()
        {
            string MainClient="";

            if (Client_Vendor == "c")
            {
            MainClient = dal.GetCell_1(@"SELECT Costmers_acc_no FROM wh_BRANCHES where Branch_code ='" + Properties.Settings.Default.BranchId + "' ").ToString();
            }
            else if(Client_Vendor == "v")
            {
            MainClient = dal.GetCell_1(@"SELECT Suppliers_acc_no FROM wh_BRANCHES where Branch_code ='" + Properties.Settings.Default.BranchId + "' ").ToString();

            }

            DataTable dt1 = dal.getDataTabl_1(@"select ACC_NO,PAYER_NAME,case when ISNULL(payer_l_name,'')='' then PAYER_NAME else payer_l_name end as payer_l_name  FROM payer2
            where BRANCH_code = '" +txtbranchCode.Text + "' and Acc_No like '"+MainClient+"%'   and Acc_No like '" + txtsearchID.Text + "%' and(PAYER_NAME like '%" + txtSearchName.Text + "%' or payer_l_name like '%" + txtSearchName.Text + "%') and t_final='1' ");

            if (dt1.Rows.Count > 0)
            {
                int B_rowscount = dt1.Rows.Count;

                DGV1.Rows.Clear();
                DGV1.Rows.Add(B_rowscount);
                for (int i = 0; i <= (B_rowscount - 1); i++)
                {


                    DGV1.Rows[i].Cells[0].Value = dt1.Rows[i]["ACC_NO"];
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        DGV1.Rows[i].Cells[1].Value = dt1.Rows[i]["PAYER_NAME"];
                    }
                    else
                    {
                        DGV1.Rows[i].Cells[1].Value = dt1.Rows[i]["payer_l_name"];
                    }
                }
            }
            else
            {
                DGV1.Rows.Clear();
            }
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchAcc_();
        }
    }
}
