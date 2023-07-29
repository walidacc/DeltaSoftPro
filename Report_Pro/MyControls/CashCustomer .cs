﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; using System.Linq;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class CashCustomer : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public CashCustomer()
        {
            InitializeComponent();
        }

       

        private void ID_TextChanged(object sender, EventArgs e)
        {
            get_desc();
            OnLoad(e);

        }

        private void ID_KeyUp(object sender, KeyEventArgs e)
        {
            get_desc();
           
            }

        private void get_desc()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("select Costmer_Name from Wh_Cash_Costmers where Costmer_No= '" + ID.Text + "' and BRANCH_code like '" + branchID.Text + "'+'%'  ");
                if (dt_.Rows.Count > 0)
                {
                    Desc.Text = dt_.Rows[0][0].ToString();
                }
                else
                {

                    Desc.Clear();

                }
            }
            catch { }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            search_();

        }

        private void search_()
        {
            try
            {
                dgv1.Visible = true;
                this.Height = 130;
                this.BringToFront();
                dgv1.DataSource = dal.getDataTabl_1("select Costmer_No,Costmer_Name,Adress from  Wh_Cash_Costmers where Costmer_Name like '%" + Desc.Text + "%' and BRANCH_code like '" + branchID.Text + "'+'%' ORDER BY Costmer_No ");
                dgv1.Columns[0].Width = 50;
            }
            catch { }

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
            this.Height = 23;
            this.SendToBack();

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ID_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void UC_Acc_Leave(object sender, EventArgs e)
        {
            dgv1.Visible = false;
            this.Height = 23;
            this.SendToBack();

        }

        private void Desc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

