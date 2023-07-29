using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; using System.Linq;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class Uc_user : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public Uc_user()
        {
            InitializeComponent();
        }

        private void ID_KeyUp(object sender, KeyEventArgs e)
        {
            get_desc();
            OnDoubleClick(e);
        }

        private void get_desc()
        {
           
                DataTable dt_ = dal.getDataTabl_1(@"SELECT USER_ID,USER_NAME FROM wh_USERS where USER_ID = '" + ID.Text + "' ");
                if (dt_.Rows.Count > 0)
                {
                    if (Properties.Settings.Default.lungh == "0")
                    {
                    Desc.Text = dt_.Rows[0]["USER_NAME"].ToString();
                    }
                    else
                    {
                        Desc.Text = dt_.Rows[0]["USER_NAME"].ToString();
                    }

                }
                else
                {

                    Desc.Clear();

                }
           
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            search_();

        }

        private void search_()
        {
            
                dgv1.Visible = true;
                Height = 150;
                BringToFront();
            if(Properties.Settings.Default.lungh == "0")
            {
                dgv1.DataSource = dal.getDataTabl_1(@"SELECT USER_ID,USER_NAME FROM wh_USERS where (USER_NAME like'%" + Desc.Text + "%') ");
            }
            else
            {
                dgv1.DataSource = dal.getDataTabl_1(@"SELECT USER_ID,USER_NAME FROM wh_USERS where (USER_NAME like'%" + Desc.Text + "%')");

            }
            dgv1.Columns[0].Width = 100;
            
           

        }

        private void Desc_KeyUp(object sender, KeyEventArgs e)
        {
            search_();
        }

        private void ID_Enter(object sender, EventArgs e)
        {
            dgv1.Visible = false;
            this.Height = 23;
            this.SendToBack();
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {

            int ii = dgv1.CurrentCell.RowIndex;

            ID.Text = dgv1.Rows[ii].Cells[0].Value.ToString();
            Desc.Text = dgv1.Rows[ii].Cells[1].Value.ToString();

            dgv1.Visible = false;
            Height = 20;
            SendToBack();
            OnDoubleClick(e);

        }

      

        private void ID_TextChanged(object sender, EventArgs e)
        {
            get_desc();
            OnLoad(e);

        }


        private void UC_AccBranch_Leave(object sender, EventArgs e)
        {
            dgv1.Visible = false;
            Height = 20;
            SendToBack();
        }

        private void ID_Leave(object sender, EventArgs e)
        {
            leave_();
            
        }

        private void leave_()
        {
            DataTable dt_ = dal.getDataTabl_1(@"SELECT USER_ID,USER_NAME FROM wh_USERS where USER_ID = '" + ID.Text + "'  ");
            if (dt_.Rows.Count > 0)
            {
                if (Properties.Settings.Default.lungh == "0")
                {
                    Desc.Text = dt_.Rows[0]["USER_NAME"].ToString();
                }
                else
                {
                    Desc.Text = dt_.Rows[0]["USER_NAME"].ToString();
                }

            }
            else
            {
                ID.Clear();
                Desc.Clear();

            }

        }
        private void Desc_Leave(object sender, EventArgs e)
        {

            leave_();
        }


       

       
    }
}
