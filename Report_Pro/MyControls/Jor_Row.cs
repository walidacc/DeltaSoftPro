﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; using System.Linq;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class Jor_Row : UserControl
    {
       // DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public Jor_Row()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
           // OnClick(e);
        }

        private void txtDebit_ValueChanged(object sender, EventArgs e)
        {
            OnLoad(e);
        }


      


     



   

      

        private void txtAccDesc_Click(object sender, EventArgs e)
        {

        }

        private void Jor_Row_Load(object sender, EventArgs e)
        {
            branchID.Text = Properties.Settings.Default.BranchAccID;

            
        }

        private void txtBalance_Click(object sender, EventArgs e)
        {

        }

      
       

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtDescription.Text.Trim()!= string.Empty)
            {
//                txtCat.ID.Focus();

            }
           
        }

        private void txtCatID_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCostID_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDebit_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void txtCredit_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void txtDocument_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // txtDocDate.Focus();
            }
        }

        private void txtDocDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               //txtVatNo.Focus();
            }
        }

        private void txtVatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtAcc_2.Focus();
            }
        }

        private void txtAcc_2_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void txtDocDate_Click(object sender, EventArgs e)
        {

        }

        private void txtCredit_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCatID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCatDesc_Click(object sender, EventArgs e)
        {

        }

        private void txtDocument_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVatNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtDb_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (txtAmount.Value!= 0)
                {
                    txtAccNo.Focus();
                }
                else
                {
                    txtAccNo.Focus();
                }

            }



        }

        private void txtDb_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

     

        private void txtCr_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

      

        private void txtAccID_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

       

      
        private void buttonX1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

      

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

       

        private void buttonX2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void txtCost_Load(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtDescription.Focus();
            OnClick(e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtAmount.Focus();
            OnDoubleClick(e);
        }

       
        private void Acc__Load(object sender, EventArgs e)
        {

        }

        private void ser__Click(object sender, EventArgs e)
        {

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ser__TextChanged(object sender, EventArgs e)
        {
            rowBackcolor();
        }
        private void rowBackcolor()
        {
            //if ((ser_.Text.ToDecimal()) % 2 == 0)
            //{
            //    this.BackColor = Color.Bisque;
            //}
            //else
            //{
            //    this.BackColor = Color.Transparent;
            //}
        }

        private void txtDescription_Load(object sender, EventArgs e)
        {

        }

        private void txtDocument_Load(object sender, EventArgs e)
        {

        }

        private void txtVatNo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
