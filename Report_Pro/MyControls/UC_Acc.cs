using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; using System.Linq;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class UC_Acc : UserControl
    {

        public int x;
        public int y;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public UC_Acc()
        {
            InitializeComponent();
        }



     


        private void ID_TextChanged(object sender, EventArgs e)
        {
           
        
        }

        private void ID_KeyUp(object sender, KeyEventArgs e)
        {
            get_desc();
            OnKeyUp(e);
            

        }

        private void get_desc()
        {

            DataTable dt_ = dal.getDataTabl_1(@"select  A.PAYER_NAME
		,ISNULL(NULLIF(A.payer_l_name, ''),A.PAYER_NAME) AS payer_l_name
        ,B.MAIN_KM_CODE as V_PurchCode 
		,B.MAIN_KM_DESC as V_PurchDesc
		,C.MAIN_KM_CODE as V_SalesCode
		,C.MAIN_KM_DESC as V_SalesDesc
        ,ISNULL(NULLIF(A.KM_CODE, ''), '1')as KM_CODE
		, (select case when  ISNULL(NULLIF(A.KM_CODE_Purch, ''), '21') =21 then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end) as PurchRatio
		, (select case when  ISNULL(NULLIF(A.KM_CODE_Sales, ''), '11') =11 then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end) as SalesRatio
        from payer2 As A 
        left join KM_MAIN_ACC_CODE As B on isnull(NULLIF(A.KM_CODE_Purch,''),21)=B.MAIN_KM_CODE
		left join KM_MAIN_ACC_CODE As C on isnull(NULLIF(A.KM_CODE_Sales,''),11)=C.MAIN_KM_CODE
        where A.ACC_NO= '" + ID.Text + "'  and (A.acc_no like '" + txtMainAcc.Text + "%' or A.acc_no like '" + txtAccCash.Text + "%')   and A.BRANCH_code like '" + branchID.Text + "%' and A.t_final like '" + txtFinal.Text + "%' ");


            if (dt_.Rows.Count > 0)
            {
                if (Properties.Settings.Default.lungh == "0")
                {
                    Desc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                }
                else
                {
                    Desc.Text = dt_.Rows[0]["payer_l_name"].ToString();
                }
                KM_Code_Purch.Text = dt_.Rows[0]["V_PurchCode"].ToString();
                KM_Desc_Purch.Text = dt_.Rows[0]["V_PurchDesc"].ToString();
                KM_Ratio_Purch.Text = dt_.Rows[0]["PurchRatio"].ToString().ToDecimal().ToString("N0");
                KM_Code_Sales.Text = dt_.Rows[0]["V_SalesCode"].ToString();
                KM_Desc_Sales.Text = dt_.Rows[0]["V_SalesDesc"].ToString();
                KM_Ratio_Sales.Text = dt_.Rows[0]["SalesRatio"].ToString().ToDecimal().ToString("N0");
                txtKMCode.Text = dt_.Rows[0]["KM_CODE"].ToString();
            }
            else
            {

                Desc.Clear();
                KM_Code_Purch.Clear();
                KM_Desc_Purch.Clear();
                KM_Ratio_Purch.Clear();
                KM_Code_Sales.Clear();
                KM_Desc_Sales.Clear();
                KM_Ratio_Sales.Clear();
                txtKMCode.Clear();
            }
        }
            
        
        
        private void btn1_Click(object sender, EventArgs e)
        {
           search_();
        }

        private void search_()
        {
            //try
            //{
                dgv1.Visible = true;
                this.Height = 150;
                this.BringToFront();
            if (Properties.Settings.Default.lungh == "0")
            {
            dgv1.DataSource = dal.getDataTabl_1("select ACC_NO,PAYER_NAME from payer2 where (PAYER_NAME like '%" + Desc.Text + "%' or payer_l_name like '%" + Desc.Text + "%'  )and ( Acc_No like '" + txtMainAcc.Text + "%' or  Acc_No like '" + txtAccCash.Text + "') and BRANCH_code like '" + branchID.Text + "%'  and t_final like '" + txtFinal.Text + "%' ORDER BY acc_no ");
            }
            else
            {
            dgv1.DataSource = dal.getDataTabl_1("select ACC_NO,isnull(nullif(PAYER_l_NAME,''), PAYER_NAME) as PAYER_l_NAME from payer2 where (PAYER_NAME like '%" + Desc.Text + "%' or payer_l_name like '%" + Desc.Text + "%'  )and ( Acc_No like '" + txtMainAcc.Text+ "%' or  Acc_No like '" + txtAccCash.Text + "') and BRANCH_code like '" + branchID.Text + "%'  and t_final like '" + txtFinal.Text + "%' ORDER BY acc_no ");
            }
                dgv1.Columns[0].Width = 72;
            //}
            //catch { }

        }

        private void Desc_KeyUp(object sender, KeyEventArgs e)
        {
            search_();
        }

        private void ID_Enter(object sender, EventArgs e)
        {
            dgv1.Visible = false;
            this.Height = 20;
           this.SendToBack();
          //  this.BackColor = Color.Red;
        }



        private void dgv1_DoubleClick(object sender, EventArgs e)
        {

            int ii = dgv1.CurrentCell.RowIndex;

            ID.Text = dgv1.Rows[ii].Cells[0].Value.ToString();
            Desc.Text = dgv1.Rows[ii].Cells[1].Value.ToString();

            dgv1.Visible = false;
            this.Height = 20;
            this.SendToBack();

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ID_TextChanged_1(object sender, EventArgs e)
        {
            get_desc();
            OnLoad(e);
            
        }

        private void UC_Acc_Leave(object sender, EventArgs e)
        {
          
        }

        public void ID_Leave(object sender, EventArgs e)
        {
            leaveID();
            OnLeave(e);
        }

        public void leaveID()
        {
           
                DataTable dt_ = dal.getDataTabl_1(@"select  A.PAYER_NAME
		,A.payer_l_name
        ,B.MAIN_KM_CODE as V_PurchCode 
		,B.MAIN_KM_DESC as V_PurchDesc
		,C.MAIN_KM_CODE as V_SalesCode
		,C.MAIN_KM_DESC as V_SalesDesc
        ,ISNULL(NULLIF(A.KM_CODE, ''), '1')as KM_CODE
		, (select case when  ISNULL(NULLIF(A.KM_CODE_Purch, ''), '21') =21 then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end) as PurchRatio
		, (select case when  ISNULL(NULLIF(A.KM_CODE_Sales, ''), '11') =11 then (select top 1 vat_ratio from (SELECT date_of_vat ,vat_ratio  FROM VAT_RATIO_MASTER  where date_of_vat <=  CAST(SYSDATETIME() as date )) as V order by V.date_of_vat DESC) else 0 end) as SalesRatio
        from payer2 As A 
        left join KM_MAIN_ACC_CODE As B on isnull(A.KM_CODE_Purch,21)=B.MAIN_KM_CODE
		left join KM_MAIN_ACC_CODE As C on isnull(A.KM_CODE_Sales,11)=C.MAIN_KM_CODE
        where A.ACC_NO= '" + ID.Text + "'  and (A.acc_no like '" + txtMainAcc.Text + "%' or A.acc_no like '" + txtAccCash.Text + "')   and A.BRANCH_code like '" + branchID.Text + "%' and A.t_final like '" + txtFinal.Text + "%' ");



            if (dt_.Rows.Count > 0)
            {
                if (Properties.Settings.Default.lungh == "0")
                {
                    Desc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                }
                else
                {
                    Desc.Text = dt_.Rows[0]["payer_l_name"].ToString();
                }
                KM_Code_Purch.Text = dt_.Rows[0]["V_PurchCode"].ToString();
                KM_Desc_Purch.Text = dt_.Rows[0]["V_PurchDesc"].ToString();
                KM_Ratio_Purch.Text = dt_.Rows[0]["PurchRatio"].ToString().ToDecimal().ToString("N0");
                KM_Code_Sales.Text = dt_.Rows[0]["V_SalesCode"].ToString();
                KM_Desc_Sales.Text = dt_.Rows[0]["V_SalesDesc"].ToString();
                KM_Ratio_Sales.Text = dt_.Rows[0]["SalesRatio"].ToString().ToDecimal().ToString("N0");
                txtKMCode.Text = dt_.Rows[0]["KM_CODE"].ToString();

                }
                else
                {
                    ID.Clear();
                    Desc.Clear();
                    KM_Code_Purch.Clear();
                    KM_Desc_Purch.Clear();
                    KM_Ratio_Purch.Clear();
                    KM_Code_Sales.Clear();
                    KM_Desc_Sales.Clear();
                    KM_Ratio_Sales.Clear();
                }

            
        }

        private void ID_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void branchID_TextChanged(object sender, EventArgs e)
        {
            leaveID();
        }
    }
}

