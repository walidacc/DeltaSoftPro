using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.Forms
{
    public partial class frmCoileClose : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frmCoileClose()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dal.Execute_1(@"update WH_FA_HEAT_NO_MASTER set QTY_OUT = QTY_OUT+'"+txtCloseWeight.Value+"' where Material_Id = '" + txtMaterailID.Text + "'");
            MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);


        }



        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt_ = dal.getDataTabl_1(@"SELECT Item_no,Material_Id,Heat_no,Weight,QTY_OUT FROM VIEW_heat_no where Heat_no = '" + txtHeatNo.Text + "' or Material_Id = '" + txtMaterailID.Text + "'");
            if (dt_.Rows.Count > 0)
            {
                txtHeatNo.Clear();
                txtMaterailID.Clear();
                txtQtyIn.Text = "0";
                txtQtyOut.Text = "0";
                txtItem.ID.Text.Clone();
                txtCloseWeight.Text = "0";
                txtBalance.Text = "0";
                txtNewBalance.Text = "0";





                txtHeatNo.Text = dt_.Rows[0]["Heat_no"].ToString();
                txtMaterailID.Text = dt_.Rows[0]["Material_Id"].ToString();
                txtQtyIn.Text = dt_.Rows[0]["Weight"].ToString();
                txtQtyOut.Text = dt_.Rows[0]["QTY_OUT"].ToString();
                txtItem.ID.Text = dt_.Rows[0]["Item_no"].ToString();
                txtBalance.Text = (txtQtyIn.Value-txtQtyOut.Value).ToString("N3");
                txtNewBalance.Text = (txtQtyIn.Value - txtQtyOut.Value-txtCloseWeight.Value).ToString("N3");

            }
        }

        private void txtNewBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCloseWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCloseWeight_KeyUp(object sender, KeyEventArgs e)
        {
            txtNewBalance.Text = (txtQtyIn.Value - txtQtyOut.Value - txtCloseWeight.Value).ToString("N3");
        }

        private void frmCoileClose_Load(object sender, EventArgs e)
        {

        }
    }
}
