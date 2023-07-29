using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class Uc_Jor : UserControl
    {

        string savtype = "0";
        string btntype = "0";
        Int32 m;

        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public DataTable dt_jor = new DataTable();
        public Uc_Jor()
        {
            InitializeComponent();
        }



        void resizeDG()
        {
            dGV_Item.Columns[0].Width = (int)(dGV_Item.Width * 0.06);// txt_Db.Width;
            dGV_Item.Columns[1].Width = (int)(dGV_Item.Width * 0.06); //txtAccNo.Width;
            dGV_Item.Columns[2].Width = (int)(dGV_Item.Width * 0.16);// txtAccName.Width;
            dGV_Item.Columns[3].Width = (int)(dGV_Item.Width * 0.21); //txt_Desc.Width;
            dGV_Item.Columns[4].Width = (int)(dGV_Item.Width * 0.04);// txtCostNo.Width;
            dGV_Item.Columns[5].Width = (int)(dGV_Item.Width * 0.09); //txtCostDesc.Width;
            dGV_Item.Columns[6].Width = (int)(dGV_Item.Width * 0.04); //txtCatNo.Width;
            dGV_Item.Columns[7].Width = (int)(dGV_Item.Width * 0.09); //txtCatDesc.Width;
            dGV_Item.Columns[8].Width = (int)(dGV_Item.Width * 0.07); //txt_Desc.Width;
            dGV_Item.Columns[9].Width = (int)(dGV_Item.Width * 0.045);// txtCostNo.Width;
            dGV_Item.Columns[10].Width = (int)(dGV_Item.Width * 0.045); //txtCostDesc.Width;
            dGV_Item.Columns[11].Width = (int)(dGV_Item.Width * 0.045); //txtCatNo.Width;
            dGV_Item.Columns[12].Width = (int)(dGV_Item.Width * 0.045); //txtCatDesc.Width;

            foreach (DataGridViewRow row in this.dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                dGV_Item.EnableHeadersVisualStyles = false;


            }
        }


        void creatDattable()
        {
            dt_jor.Columns.Add("المبلغ");
            dt_jor.Columns.Add(" كود الحساب");
            dt_jor.Columns.Add(" اسم الحساب");
            dt_jor.Columns.Add("البيان");
            dt_jor.Columns.Add(" كود الكلفة");
            dt_jor.Columns.Add("مركز الكلفة");
            dt_jor.Columns.Add("رقم التصنيف");
            dt_jor.Columns.Add("التصنيف");
            dt_jor.Columns.Add("المورد");
            dt_jor.Columns.Add("قيمة الفاتورة");
            dt_jor.Columns.Add("رقم الفاتورة");
            dt_jor.Columns.Add("تاريخ الفاتورة");
            dt_jor.Columns.Add("الرقم الضريبي");
            dGV_Item.DataSource = dt_jor;
            //dGV_Item.Columns[7].Visible = false;
            //dGV_Item.Columns[8].Visible = false;

        }

        private void get_CostDesc()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("select Cost_name  FROM COST_CENTER where COST_CODE = '" + txtCostNo.Text + "'");
                if (dt_.Rows.Count > 0)
                {
                    txtCostDesc.Text = dt_.Rows[0][0].ToString();
                }
                else
                { txtCostDesc.Text = ""; }
            }
            catch { }
        }



        private void get_CatDesc()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("SELECT CAT_NAME  FROM CATEGORY where CAT_CODE='" + txtCatNo.Text + "' ");
                if (dt_.Rows.Count > 0)
                {
                    txtCatDesc.Text = dt_.Rows[0][0].ToString();
                }
                else
                {

                    txtCatDesc.Clear();

                }
            }

            catch { }
        }


        void total_inv()
        {
            txtTotal.Text =
                (from DataGridViewRow row in dGV_Item.Rows
                 where row.Cells[2].FormattedValue.ToString() != string.Empty
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[0].FormattedValue).ToString().ToDecimal()).Sum().ToString();
          


        }



        private void get_desc()
        {
            //try
            //{
            DataTable dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name from payer2 As A 
                   where A.ACC_NO= '" + txtAccNo.Text + "'  and A.BRANCH_code = '" + txtAccBranch.Text + "' and A.t_final = 1 ");


            if (dt_.Rows.Count > 0)
            {
                if (Properties.Settings.Default.lungh == "0")
                {
                    txtAccName.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                }
                else
                {
                    txtAccName.Text = dt_.Rows[0]["payer_l_name"].ToString();
                }
                txt_Desc.Focus();
            }
            else
            {

                PL.frm_SearchAcc F = new PL.frm_SearchAcc();
                F.ShowDialog();
                int ii = F.DGV1.CurrentCell.RowIndex;


                txtAccNo.Text = F.DGV1.Rows[ii].Cells[0].Value.ToString();
                txtAccName.Text = F.DGV1.Rows[ii].Cells[1].Value.ToString();
                txt_Desc.Focus();


                //txtAccName.Clear();
                //    txtAccNo.Focus();
                //    txtAccNo.SelectAll();


            }
            //}
            //catch { }
        }





        private void BtnDelRow_Click(object sender, EventArgs e)
        {
            if (this.dGV_Item.SelectedRows.Count > 0)
            {
                dGV_Item.Rows.RemoveAt(this.dGV_Item.SelectedRows[0].Index);
                total_inv();
                foreach (DataGridViewRow row in this.dGV_Item.Rows)
                {
                    row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                }
            }
        }

        private void txtAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get_desc();
            }
        }

        private void txtAccNo_Leave(object sender, EventArgs e)
        {
               DataTable dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name from payer2 As A 
                   where A.ACC_NO= '" + txtAccNo.Text + "'  and A.BRANCH_code = '" + txtAccBranch.Text + "' and A.t_final = 1 ");


                if (dt_.Rows.Count > 0)
                {
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        txtAccName.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                    }
                    else
                    {
                        txtAccName.Text = dt_.Rows[0]["payer_l_name"].ToString();
                    }
                    txt_Desc.Focus();
                    if (txtAccNo.Text.StartsWith("238"))
                    {
                        tableLayoutPanel2.Visible = true;
                    }

                    else
                    {
                        tableLayoutPanel2.Visible = false;
                    }
                }
                else
                {
                    txtAccNo.Clear();
                    txtAccName.Clear();
                    //txtAccNo.Focus();
                    //txtAccNo.SelectAll();
                }
           
        }
    }
}
