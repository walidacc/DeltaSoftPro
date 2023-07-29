using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_heatNO : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        int _dg;
        public frm_heatNO()
        {
            InitializeComponent();
        }

        private void frm_heatNO_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            if (txtNoOfCoils.Value <= 0 || txtWidth.Value <= 0)
            {
            MessageBox.Show(dal.rm.GetString("msgError") , dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int newHeatNo = dal.GetCell_1(@"SELECT max(SUBSTRING(Material_Id,2,LEN(Material_Id)))+1 FROM WH_FA_HEAT_NO_MASTER where Material_Id like 'H%'").ToString().ParseInt(0);
            int rowscount = txtNoOfCoils.Text.ParseInt(0);


            dgv2.Rows.Clear();
            if (rowscount > 0)
            {
                dgv2.Rows.Add(rowscount);
                for (int i = 0; i <= (rowscount - 1); i++)
                {
                    dgv2.Rows[i].Cells[_matrialid.Name].Value = "H" + (newHeatNo + i).ToString().PadLeft(7, '0');
                    dgv2.Rows[i].Cells[_width.Name].Value = txtWidth.Text;
                    dgv2.Rows[i].Cells[_heatNo.Name].Value = txtHeatNo.Text;

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTotalWeight.Text.ToDecimal() != txtCoilsWeight.Text.ToDecimal())
            {
                MessageBox.Show(dal.rm.GetString("msgError") + " No Items", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlCommand cmd = dal.sqlconn_1.CreateCommand();
            SqlTransaction trans;
            trans = dal.sqlconn_1.BeginTransaction();
            cmd.Connection = dal.sqlconn_1;
            cmd.Transaction = trans;
            try
            {



                for (int i = 0; i <= dgv2.Rows.Count - 1; i++)
                {
                    if (dgv2.Rows[i].Cells[_weight.Name].FormattedValue.ToString() != string.Empty && dgv2.Rows[i].Cells[_matrialid.Name].FormattedValue.ToString() != string.Empty)
                    {

                        cmd.CommandText = @"INSERT INTO WH_FA_HEAT_NO_MASTER
                        (Ser_no,BRANCH_CODE,TRANSACTION_CODE,CYEAR,main_counter,Item_no,Material_Id,Heat_no,X,Y
                        ,Weight,QTY_OUT,C,SI,MN,P,TS,YP,EL,B,USER_ID,G_DATE)
                        VALUES('" + txtInvNo.Text + "','" + Properties.Settings.Default.BranchId + "','" + txtTransactionCode.Text +
                        "','" + Properties.Settings.Default.C_year + "','" + txtMainCounter.Text + "','" + txtItemNo.Text +
                        "','" + dgv2.Rows[i].Cells[_matrialid.Name].FormattedValue.ToString() +
                        "','" + dgv2.Rows[i].Cells[_heatNo.Name].FormattedValue.ToString() +
                        "','" + dgv2.Rows[i].Cells[_lenth.Name].FormattedValue.ToString() +
                        "','" + dgv2.Rows[i].Cells[_width.Name].FormattedValue.ToString() +
                        "','" + dgv2.Rows[i].Cells[_weight.Name].FormattedValue.ToString() +
                        "','0','0','0','0','0','0','0','0','0','" + Program.userID + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();

                MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dal.close_1();
            }



        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            txtItemNo.Text = dgv1.CurrentRow.Cells[_itemNo.Name].Value.ToString();
            txtMainCounter.Text = dgv1.CurrentRow.Cells[_MainCounter.Name].Value.ToString();
            txtTotalWeight.Text = dgv1.CurrentRow.Cells[_Qty.Name].Value.ToString();


            DataTable dt_c = dal.getDataTabl_1(@"SELECT Ser_no,BRANCH_CODE,TRANSACTION_CODE,CYEAR,main_counter,Item_no,Material_Id
            ,Heat_no,X,Y,Weight,QTY_OUT,C,SI,MN,P,TS,YP,EL,B,RE,USER_ID,G_DATE,Source_Material_id
            ,PREV_BRANCH_CODE,START_TRANS_DATE,END_TRANS_DATE
            FROM WH_FA_HEAT_NO_MASTER
            where BRANCH_CODE = '"+Properties.Settings.Default.BranchId+"' and TRANSACTION_CODE = '"+txtTransactionCode.Text+"' and Ser_no ='"+txtInvNo.Text+
            "' and CYEAR ='" + Properties.Settings.Default.C_year + "' and Item_no ='"+txtItemNo.Text+"' ");
            int rowscount = dt_c.Rows.Count;


            if (rowscount > 0)
            {
                btnFillGrid.Enabled = false;
                btnUpdate.Enabled = false;

                dgv2.Rows.Add(rowscount);
                for (int i = 0; i <= (rowscount - 1); i++)

                {

                    dgv2.Rows[i].Cells[_heatNo.Name].Value = dt_c.Rows[i]["Heat_no"].ToString();
                    dgv2.Rows[i].Cells[_weight.Name].Value = dt_c.Rows[i]["Weight"].ToString().ToDecimal().ToString("N0");
                    dgv2.Rows[i].Cells[_matrialid.Name].Value = dt_c.Rows[i]["Heat_no"].ToString();
                    dgv2.Rows[i].Cells[_lenth.Name].Value = dt_c.Rows[i]["X"].ToString().ToDecimal().ToString("N0");
                    dgv2.Rows[i].Cells[_width.Name].Value = dt_c.Rows[i]["Y"].ToString().ToDecimal().ToString("N0");

                }
               
            }
            else
            {
                btnFillGrid.Enabled = true;
                btnUpdate.Enabled = true;
            }

            TotalWeight();
        }

        private void dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv2.CurrentCell.RowIndex;
            int c = dgv2.CurrentCell.ColumnIndex;
            if (c == 1)
            {
                if (isCellNotNull(c, r) == true)
                {

                    TotalWeight();
                    //SendKeys.Send("{up}");
                    //dgv1.CurrentCell = dgv1[7, i];
                }
            }
        }

        private void TotalWeight()
        {
            txtCoilsWeight.Text =
                (from DataGridViewRow row in dgv2.Rows
                 where row.Cells["_weight"].FormattedValue.ToString() != string.Empty && row.Cells["_matrialid"].FormattedValue.ToString() != string.Empty
                 select (row.Cells["_weight"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);

        }

        bool isCellNotNull(int _col, int _row)
        {
            if (dgv2[_col, _row].Value != null)
            {
                if (dgv2[_col, _row].Value.ToString().ToDecimal() <= 0)
                {
                    return false;
                }
            }
            else if (dgv2[_col, _row].Value == null || dgv2[_col, _row].Value == DBNull.Value || String.IsNullOrEmpty(dgv2[_col, _row].Value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }

            return true;
        }


        private void dgv2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string senderText = (sender as TextBox).Text;
            string senderName = (sender as TextBox).Name;
            string[] splitByDecimal = senderText.Split('.');
            int cursorPosition = (sender as TextBox).SelectionStart;


            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (senderText.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar)
            && (senderText.IndexOf('.') < cursorPosition
             && splitByDecimal.Length > 1
            && splitByDecimal[1].Length == _dg))
            {
                e.Handled = true;
            }
        }
    }
}
