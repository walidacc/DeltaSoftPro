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
    public partial class Uc_AccountOption : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string btnKind = "";

        public Uc_AccountOption()
        {
            InitializeComponent();

        }

        private void setDgvLocation(int _x, int _y)
        {
            if (Properties.Settings.Default.lungh == "0")
            {
                dgv1.Location = new Point(_x - AccountDesc.Width, _y + 20);

            }
            else
            {
                dgv1.Location = new Point(_x - AccountID.Width, _y + 20);

            }
        }

        private void search_(string btn, string MainID)
            {


                dgv1.Visible = true;
            if (btn == "Account")
            {
                btnKind = "Account";
                setDgvLocation(btnAccount.Location.X, btnAccount.Location.Y);
                if (Properties.Settings.Default.lungh == "0")
                {
                    dgv1.DataSource = dal.getDataTabl_1(@"select ACC_NO,PAYER_NAME from payer2 
                       where (PAYER_NAME like '%" + AccountDesc.Text +
                       "%' or isnull(payer_l_name,'') like '%" + AccountDesc.Text + "%'  ) " +
                       "and ( Acc_No like '" + MainID + "%' or  Acc_No like '" + txtAccCash.Text + "') " +
                       "and BRANCH_code like '" + BranchID.Text + "%'  and t_final like '" + txtFinal.Text + "%' ORDER BY acc_no ");
                }
                else
                {
                    dgv1.DataSource = dal.getDataTabl_1(@"select ACC_NO,isnull(nullif(payer_l_name,''),PAYER_NAME) as payer_l_name from payer2 
                       where (PAYER_NAME like '%" + AccountDesc.Text +
                       "%' or isnull(payer_l_name,'') like '%" + AccountDesc.Text + "%'  ) " +
                       "and ( Acc_No like '" + MainID + "%' or  Acc_No like '" + txtAccCash.Text + "') " +
                       "and BRANCH_code like '" + BranchID.Text + "%'  and t_final like '" + txtFinal.Text + "%' ORDER BY acc_no ");
                }


            }




            else if (btn == "Branch")
            {
                btnKind = "Branch";
                setDgvLocation(btnBranch.Location.X, btnBranch.Location.Y);

                if (Properties.Settings.Default.lungh == "0")
                {
                    if (Program.userID.ToLower() == "administrator")
                    {
                        dgv1.DataSource = dal.getDataTabl_1(@"select Branch_code,branch_name from  BRANCHS 
                        where  t_final like '" + txtStoreFinal.Text + "%' and branch_name like '%" + BranchDesc.Text + "%'");
                    }
                    else
                    {
                        dgv1.DataSource = dal.getDataTabl_1(@"select A.Branch_code,A.branch_name from  BRANCHS As A inner join Acc_users_branch As B on A.Branch_code =B.branch_code
                            where b.User_id = '" + Program.userID.ToString() + "' and t_final like '" + txtStoreFinal.Text + "%' and branch_name like '%" + BranchDesc.Text + "%'");
                    }

                }
                else
                {
                    if (Program.userID.ToLower() == "administrator")
                    {
                        dgv1.DataSource = dal.getDataTabl_1(@"select Branch_code, isnull(nullif(BRANCH_E_NAME,''),branch_name) as BRANCH_E_NAME from  BRANCHS
                      where  t_final like '" + txtStoreFinal.Text + "%' and isnull(BRANCH_E_NAME,'') like '%" + BranchDesc.Text + "%'");

                    }
                    else
                    {
                        dgv1.DataSource = dal.getDataTabl_1(@"select A.Branch_code, isnull(nullif(A.BRANCH_E_NAME,''),A.branch_name) as BRANCH_E_NAME from  BRANCHS As A inner join Acc_users_branch As B on A.Branch_code =B.branch_code
                      where b.User_id = '" + Program.userID.ToString() + "' and t_final like '" + txtStoreFinal.Text + "%' and isnull(BRANCH_E_NAME,'') like '%" + BranchDesc.Text + "%'");
                    }
                }
            }

            else if (btn == "Cost")
            {
                btnKind = "Cost";
                setDgvLocation(btnCost.Location.X, btnCost.Location.Y);
                if(Properties.Settings.Default.lungh == "0")
                {
                dgv1.DataSource = dal.getDataTabl_1(" select cost_code,COST_name from COST_CENTER  where (COST_name like '%" + CostDesc.Text + "%' or isnull(COST_E_NAME,'') like '%" + CostDesc.Text + "%'  )  ORDER BY cost_code ");
                }
                else
                {
                    dgv1.DataSource = dal.getDataTabl_1(" select cost_code,isnull(Nullif(COST_E_NAME,''),COST_name) as COST_E_NAME  from COST_CENTER  where (COST_name like '%" + CostDesc.Text + "%' or isnull(COST_E_NAME,'') like '%" + CostDesc.Text + "%'  )  ORDER BY cost_code ");
                }


            }

            else if (btn == "Cat")
            {
                btnKind = "Cat";
                setDgvLocation(btnCat.Location.X, btnCat.Location.Y);
                if (Properties.Settings.Default.lungh == "0")
                {
                    dgv1.DataSource = dal.getDataTabl_1(" select CAT_CODE,CAT_NAME from CATEGORY  where CAT_NAME like '%" + CatDesc.Text + "%' or  CAT_NAME_E like '%" + CatDesc.Text + "%'  ORDER BY CAT_CODE ");
                }
                else
                {
                    dgv1.DataSource = dal.getDataTabl_1(" select CAT_CODE,isnull(Nullif(CAT_NAME_E,''),CAT_NAME) as CAT_NAME_E  from CATEGORY  where CAT_NAME like '%" + CatDesc.Text + "%' or  CAT_NAME_E like '%" + CatDesc.Text + "%'  ORDER BY CAT_CODE ");
                }
            }


                dgv1.Columns[0].Width = 72;


            }


            private void get_desc(string btn, string MainID, string Final)
            {
            if (btn == "Account")
                {
                    DataTable dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name,
                    B.MAIN_KM_CODE as V_PurchCode ,B.MAIN_KM_DESC as V_PurchDesc,
                    C.MAIN_KM_CODE as V_SalesCode,C.MAIN_KM_DESC as V_SalesDesc,
                    D.KM_RATIO as V_PurchRatio,
                    E.KM_RATIO as V_SalesRatio
                    from payer2 As A 
                   left join KM_MAIN_ACC_CODE As B on isnull(A.KM_CODE_Purch,21)=B.MAIN_KM_CODE
				   left join KM_MAIN_ACC_CODE As C on isnull(A.KM_CODE_Sales,11)=C.MAIN_KM_CODE
				   left join KM_ACC_CODE As D on B.KM_CODE=D.KM_CODE
				   left join KM_ACC_CODE As E on C.KM_CODE=E.KM_CODE
                   where A.ACC_NO= '" + AccountID.Text + "'  and (A.acc_no like '" + MainID + "%' or  A.acc_no like '" + txtAccCash.Text + "') and A.BRANCH_code like '" + BranchID.Text + "'+'%' and A.t_final like '" + Final + "%' ");

                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            AccountDesc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                        }
                        else
                        {
                            AccountDesc.Text = dt_.Rows[0]["payer_l_name"].ToString();
                        }
                        KM_Code_Purch.Text = dt_.Rows[0]["V_PurchCode"].ToString();
                        KM_Desc_Purch.Text = dt_.Rows[0]["V_PurchDesc"].ToString();
                        KM_Ratio_Purch.Text = dt_.Rows[0]["V_PurchRatio"].ToString();
                        KM_Code_Sales.Text = dt_.Rows[0]["V_SalesCode"].ToString();
                        KM_Desc_Sales.Text = dt_.Rows[0]["V_SalesDesc"].ToString();
                        KM_Ratio_Sales.Text = dt_.Rows[0]["V_SalesRatio"].ToString();
                    }
                    else
                    {
                    //AccountID.Clear();
                    AccountDesc.Clear();
                    KM_Code_Purch.Clear();
                    KM_Desc_Purch.Clear();
                    KM_Ratio_Purch.Clear();
                    KM_Code_Sales.Clear();
                    KM_Desc_Sales.Clear();
                    KM_Ratio_Sales.Clear();
                }

                }
                else if (btn == "Branch")
                {
                    DataTable dt_;

                    if (Program.userID.ToLower() == "administrator")
                    {
                        dt_ = dal.getDataTabl_1(@"select branch_name,BRANCH_E_NAME from  BRANCHS
                      where  t_final like '" + txtStoreFinal.Text + "%' and Branch_code='" + BranchID.Text + "'");
                     
                    }
                    else
                    {
                        dt_ = dal.getDataTabl_1(@"select A.branch_name,A.BRANCH_E_NAME from  BRANCHS As A inner join Acc_users_branch As B on A.Branch_code =B.branch_code
                   where b.User_id = '" + Program.userID.ToString() + "' and t_final like '" + Final + "%' and A.Branch_code='" + BranchID.Text + "'");
                        //select branch_name,WH_E_NAME,ACC_BRANCH from wh_BRANCHES  where T_final like '" + txtTfinal.Text + "%' and Branch_code='" + ID.Text + "' ");

                    }
                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                        BranchDesc.Text = dt_.Rows[0]["branch_name"].ToString();
                        }
                        else
                        {
                        BranchDesc.Text = dt_.Rows[0]["BRANCH_E_NAME"].ToString();
                        }
                    }
                    else
                    {
                    //BranchID.Clear();
                   BranchDesc.Clear();
                        

                    }

                    dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name,
                    B.MAIN_KM_CODE as V_PurchCode ,B.MAIN_KM_DESC as V_PurchDesc,
                    C.MAIN_KM_CODE as V_SalesCode,C.MAIN_KM_DESC as V_SalesDesc,
                    D.KM_RATIO as V_PurchRatio,
                    E.KM_RATIO as V_SalesRatio
                    from payer2 As A 
                   left join KM_MAIN_ACC_CODE As B on isnull(A.KM_CODE_Purch,21)=B.MAIN_KM_CODE
				   left join KM_MAIN_ACC_CODE As C on isnull(A.KM_CODE_Sales,11)=C.MAIN_KM_CODE
				   left join KM_ACC_CODE As D on B.KM_CODE=D.KM_CODE
				   left join KM_ACC_CODE As E on C.KM_CODE=E.KM_CODE
                   where A.ACC_NO= '" + AccountID.Text + "'  and (A.acc_no like '" + txtMainAcc.Text + "%' or  A.acc_no like '" + txtAccCash.Text + "') and A.BRANCH_code like '" + BranchID.Text + "'+'%' and A.t_final like '" + txtFinal.Text + "%' ");

                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            AccountDesc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                        }
                        else
                        {
                            AccountDesc.Text = dt_.Rows[0]["payer_l_name"].ToString();
                        }
                        KM_Code_Purch.Text = dt_.Rows[0]["V_PurchCode"].ToString();
                        KM_Desc_Purch.Text = dt_.Rows[0]["V_PurchDesc"].ToString();
                        KM_Ratio_Purch.Text = dt_.Rows[0]["V_PurchRatio"].ToString();
                        KM_Code_Sales.Text = dt_.Rows[0]["V_SalesCode"].ToString();
                        KM_Desc_Sales.Text = dt_.Rows[0]["V_SalesDesc"].ToString();
                        KM_Ratio_Sales.Text = dt_.Rows[0]["V_SalesRatio"].ToString();
                    }
                    else
                    {
                        AccountID.Clear();
                        AccountDesc.Clear();
                        KM_Code_Purch.Clear();
                        KM_Desc_Purch.Clear();
                        KM_Ratio_Purch.Clear();
                        KM_Code_Sales.Clear();
                        KM_Desc_Sales.Clear();
                        KM_Ratio_Sales.Clear();
                    }




                }
                else if (btn == "Cost")
                {
                    DataTable dt_ = dal.getDataTabl_1(@"select COST_CODE,COST_name, isnull(Nullif(COST_E_NAME,''),COST_name) as COST_E_NAME  from COST_CENTER 
                   where COST_CODE = '" + CostID.Text + "' ");
 
                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            CostDesc.Text = dt_.Rows[0]["COST_name"].ToString();
                        }
                        else
                        {
                        CostDesc.Text = dt_.Rows[0]["COST_E_NAME"].ToString();
                        }
                    }
                    else
                    {
                   // CostID.Clear();
                    CostDesc.Clear();
                    }


                }

            else if (btn == "Cat")
            {
                DataTable dt_ = dal.getDataTabl_1(@"select CAT_CODE,CAT_NAME,isnull(Nullif(CAT_NAME_E,''),CAT_NAME) as CAT_NAME_E  from CATEGORY  
                   where CAT_CODE = '" + CatID.Text + "' ");

                if (dt_.Rows.Count > 0)
                {
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        CatDesc.Text = dt_.Rows[0]["CAT_NAME"].ToString();
                    }
                    else
                    {
                        CatDesc.Text = dt_.Rows[0]["CAT_NAME_E"].ToString();
                    }
                }
                else
                {
                    //CatID.Clear();
                    CatDesc.Clear();
                }


            }

    

            }




            public void leaveID(string btn, string MainID, string Final)
            {
                if (btn == "Account")
                {
                    DataTable dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name,
                    B.MAIN_KM_CODE as V_PurchCode ,B.MAIN_KM_DESC as V_PurchDesc,
                    C.MAIN_KM_CODE as V_SalesCode,C.MAIN_KM_DESC as V_SalesDesc,
                    D.KM_RATIO as V_PurchRatio,
                    E.KM_RATIO as V_SalesRatio
                    from payer2 As A 
                   left join KM_MAIN_ACC_CODE As B on isnull(A.KM_CODE_Purch,21)=B.MAIN_KM_CODE
				   left join KM_MAIN_ACC_CODE As C on isnull(A.KM_CODE_Sales,11)=C.MAIN_KM_CODE
				   left join KM_ACC_CODE As D on B.KM_CODE=D.KM_CODE
				   left join KM_ACC_CODE As E on C.KM_CODE=E.KM_CODE
                   where A.ACC_NO= '" + AccountID.Text + "'  and (A.acc_no like '" + MainID + "%' or  A.acc_no like '" + txtAccCash.Text + "') and A.BRANCH_code like '" + BranchID.Text + "'+'%' and A.t_final like '" + Final + "%' ");

                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            AccountDesc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                        }
                        else
                        {
                            AccountDesc.Text = dt_.Rows[0]["payer_l_name"].ToString();
                        }
                        KM_Code_Purch.Text = dt_.Rows[0]["V_PurchCode"].ToString();
                        KM_Desc_Purch.Text = dt_.Rows[0]["V_PurchDesc"].ToString();
                        KM_Ratio_Purch.Text = dt_.Rows[0]["V_PurchRatio"].ToString();
                        KM_Code_Sales.Text = dt_.Rows[0]["V_SalesCode"].ToString();
                        KM_Desc_Sales.Text = dt_.Rows[0]["V_SalesDesc"].ToString();
                        KM_Ratio_Sales.Text = dt_.Rows[0]["V_SalesRatio"].ToString();
                    }
                    else
                    {
                        AccountID.Clear();
                        AccountDesc.Clear();
                        KM_Code_Purch.Clear();
                        KM_Desc_Purch.Clear();
                        KM_Ratio_Purch.Clear();
                        KM_Code_Sales.Clear();
                        KM_Desc_Sales.Clear();
                        KM_Ratio_Sales.Clear();
                    }

                }
                else if (btn == "Branch")
                {
                    DataTable dt_;

                    if (Program.userID.ToLower() == "administrator")
                    {
                        dt_ = dal.getDataTabl_1(@"select branch_name,BRANCH_E_NAME from  BRANCHS
                      where  t_final like '" + txtStoreFinal.Text + "%' and Branch_code='" + BranchID.Text + "'");
                     
                    }
                    else
                    {
                        dt_ = dal.getDataTabl_1(@"select A.branch_name,A.BRANCH_E_NAME from  BRANCHS As A inner join Acc_users_branch As B on A.Branch_code =B.branch_code
                   where b.User_id = '" + Program.userID.ToString() + "' and t_final like '" + Final + "%' and A.Branch_code='" + BranchID.Text + "'");
                        //select branch_name,WH_E_NAME,ACC_BRANCH from wh_BRANCHES  where T_final like '" + txtTfinal.Text + "%' and Branch_code='" + ID.Text + "' ");

                    }
                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                        BranchDesc.Text = dt_.Rows[0]["branch_name"].ToString();
                        }
                        else
                        {
                        BranchDesc.Text = dt_.Rows[0]["BRANCH_E_NAME"].ToString();
                        }
                    }
                    else
                    {
                    BranchID.Clear();
                    BranchDesc.Clear();
                        

                    }

                    dt_ = dal.getDataTabl_1(@"select A.PAYER_NAME,A.payer_l_name,
                    B.MAIN_KM_CODE as V_PurchCode ,B.MAIN_KM_DESC as V_PurchDesc,
                    C.MAIN_KM_CODE as V_SalesCode,C.MAIN_KM_DESC as V_SalesDesc,
                    D.KM_RATIO as V_PurchRatio,
                    E.KM_RATIO as V_SalesRatio
                    from payer2 As A 
                   left join KM_MAIN_ACC_CODE As B on isnull(A.KM_CODE_Purch,21)=B.MAIN_KM_CODE
				   left join KM_MAIN_ACC_CODE As C on isnull(A.KM_CODE_Sales,11)=C.MAIN_KM_CODE
				   left join KM_ACC_CODE As D on B.KM_CODE=D.KM_CODE
				   left join KM_ACC_CODE As E on C.KM_CODE=E.KM_CODE
                   where A.ACC_NO= '" + AccountID.Text + "'  and (A.acc_no like '" + txtMainAcc.Text + "%' or  A.acc_no like '" + txtAccCash.Text + "') and A.BRANCH_code like '" + BranchID.Text + "'+'%' and A.t_final like '" + txtFinal.Text + "%' ");

                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            AccountDesc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                        }
                        else
                        {
                            AccountDesc.Text = dt_.Rows[0]["payer_l_name"].ToString();
                        }
                        KM_Code_Purch.Text = dt_.Rows[0]["V_PurchCode"].ToString();
                        KM_Desc_Purch.Text = dt_.Rows[0]["V_PurchDesc"].ToString();
                        KM_Ratio_Purch.Text = dt_.Rows[0]["V_PurchRatio"].ToString();
                        KM_Code_Sales.Text = dt_.Rows[0]["V_SalesCode"].ToString();
                        KM_Desc_Sales.Text = dt_.Rows[0]["V_SalesDesc"].ToString();
                        KM_Ratio_Sales.Text = dt_.Rows[0]["V_SalesRatio"].ToString();
                    }
                    else
                    {
                        AccountID.Clear();
                        AccountDesc.Clear();
                        KM_Code_Purch.Clear();
                        KM_Desc_Purch.Clear();
                        KM_Ratio_Purch.Clear();
                        KM_Code_Sales.Clear();
                        KM_Desc_Sales.Clear();
                        KM_Ratio_Sales.Clear();
                    }




                }
                else if (btn == "Cost")
                {
                    DataTable dt_ = dal.getDataTabl_1(@"select COST_CODE,COST_name, isnull(Nullif(COST_E_NAME,''),COST_name) as COST_E_NAME  from COST_CENTER 
                   where COST_CODE = '" + CostID.Text + "' ");
 
                    if (dt_.Rows.Count > 0)
                    {
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            CostDesc.Text = dt_.Rows[0]["COST_name"].ToString();
                        }
                        else
                        {
                        CostDesc.Text = dt_.Rows[0]["COST_E_NAME"].ToString();
                        }
                    }
                    else
                    {
                    CostID.Clear();
                    CostDesc.Clear();
                    }


                }

            else if (btn == "Cat")
            {
                DataTable dt_ = dal.getDataTabl_1(@"select CAT_CODE,CAT_NAME,isnull(Nullif(CAT_NAME_E,''),CAT_NAME) as CAT_NAME_E  from CATEGORY  
                   where CAT_CODE = '" + CatID.Text + "' ");

                if (dt_.Rows.Count > 0)
                {
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        CatDesc.Text = dt_.Rows[0]["CAT_NAME"].ToString();
                    }
                    else
                    {
                        CatDesc.Text = dt_.Rows[0]["CAT_NAME_E"].ToString();
                    }
                }
                else
                {
                    CatID.Clear();
                    CatDesc.Clear();
                }


            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BranchDesc_KeyUp(object sender, KeyEventArgs e)
        {
            search_("Branch","");
        }

        private void AccountDesc_KeyUp(object sender, KeyEventArgs e)
        {
            search_("Account", txtMainAcc.Text);
        }

        private void CostDesc_KeyUp(object sender, KeyEventArgs e)
        {
            search_("Cost", "");
        }

        private void CatDesc_KeyUp(object sender, KeyEventArgs e)
        {
            search_("Cat", "");
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            search_("Branch", "");
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            search_("Account", txtMainAcc.Text);
        }

        private void btnCost_Click(object sender, EventArgs e)
        {
            search_("Cost","");
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            search_("Cat","");
        }

        private void BranchID_Enter(object sender, EventArgs e)
        {
            dgv1.Visible = false;
        }

        private void AccountID_Enter(object sender, EventArgs e)
        {
            dgv1.Visible = false;
        }

        private void CostID_Enter(object sender, EventArgs e)
        {
            dgv1.Visible = false;
        }

        private void CatID_Enter(object sender, EventArgs e)
        {
            dgv1.Visible = false;
        }

        private void BranchID_Leave(object sender, EventArgs e)
        {
            leaveID("Branch", "","");
        }
    

        private void AccountID_Leave(object sender, EventArgs e)
        {
            leaveID("Account", txtMainAcc.Text, txtFinal.Text);
        }

        private void CostID_Leave(object sender, EventArgs e)
        {
            leaveID("Cost", "","");
        }


        private void CatID_Leave(object sender, EventArgs e)
        {
            leaveID("Cat", "","");
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            get_desc("Account", txtMainAcc.Text, txtFinal.Text);
        }

        private void BranchID_TextChanged(object sender, EventArgs e)
        {
            get_desc("Branch","",txtStoreFinal.Text);
        }

        private void CostID_TextChanged(object sender, EventArgs e)
        {
            get_desc("Cost", "", "");
        }

        private void CatID_TextChanged(object sender, EventArgs e)
        {
            get_desc("Cat", "", "");
        }

        private void BranchID_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            int ii = dgv1.CurrentCell.RowIndex;
            if (btnKind == "Account")
            {
                AccountID.Text = dgv1.Rows[ii].Cells[0].Value.ToString();
                AccountDesc.Text = dgv1.Rows[ii].Cells[1].Value.ToString();
                AccountID.Focus();
            }

            else if (btnKind == "Branch")
            {
                BranchID.Text = dgv1.Rows[ii].Cells[0].Value.ToString();
                BranchDesc.Text = dgv1.Rows[ii].Cells[1].Value.ToString();
                BranchID.Focus();
            }

            else if (btnKind == "Cost")
            {
                CostID.Text = dgv1.Rows[ii].Cells[0].Value.ToString();
                CostDesc.Text = dgv1.Rows[ii].Cells[1].Value.ToString();
                CostID.Focus();
            }


            else if (btnKind == "Cat")
            {
                CatID.Text = dgv1.Rows[ii].Cells[0].Value.ToString();
                CatDesc.Text = dgv1.Rows[ii].Cells[1].Value.ToString();
                CatID.Focus();
            }

           
            dgv1.Visible = false;
            //this.Height = 22;
            //this.SendToBack();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Uc_AccountOption_Load(object sender, EventArgs e)
        {
            FromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            ToDate.Value = DateTime.Today;
        }
    }
}
