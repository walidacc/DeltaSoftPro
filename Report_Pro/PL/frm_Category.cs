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
    public partial class frm_Category : frm_Master
    {

        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        TreeNode _selectedNode = null;
        DataTable _acountsTb = null;
        string _parent;

        public frm_Category()
        {
            InitializeComponent();
        }

        private void frm_Category_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = true;

            tv1.Nodes.Clear();
            _acountsTb = dal.getDataTabl_1(@"SELECT CAT_CODE,CAT_NAME,IsNull(CAT_NAME_E,'') as CAT_NAME_E,isnull(NullIf(PREV_NO,''),0) AS PREV_NO,T_FINAL,T_LEVEL FROM CATEGORY");

            PopulateTreeView("0", null);


            //DataTable dt_ = dal.getDataTabl_1(@"SELECT CAT_CODE,CAT_NAME,REF_NO,NOTES,NOTES2,BRANCH_CODE,CAT_NAME_E,Mobile,Email FROM CATEGORY

            cmbMain.DataSource = dal.getDataTabl_1(@"SELECT CAT_CODE, CAT_NAME,IsNull(NullIf(CAT_NAME_E,''),CAT_NAME)as CAT_NAME_E FROM CATEGORY where T_FINAL=0");
            cmbMain.ValueMember = "CAT_CODE";
            if (Properties.Settings.Default.lungh == "0")
            {
            cmbMain.DisplayMember = "CAT_NAME";
            }
            else
            {
                cmbMain.DisplayMember = "CAT_NAME_E";
            }
            cmbMain.SelectedIndex = -1;
        }

        private void PopulateTreeView(string parentId, TreeNode parentNode)
        {

            TreeNode childNode;
            foreach (DataRow dr in _acountsTb.Select("PREV_NO = '" + parentId + "'"))
            {
                TreeNode t = new TreeNode();
                t.Text = dr["CAT_CODE"].ToString() + " - " + dr["CAT_NAME"].ToString();
                t.Name = dr["CAT_CODE"].ToString();
                t.Tag = _acountsTb.Rows.IndexOf(dr);
                if (dr["T_FINAL"].ToString() == "0")
                {
                    t.ImageIndex = 0;
                    t.SelectedImageIndex = 1;
                }
                else
                {
                    t.ImageIndex = 2;
                    t.SelectedImageIndex = 6;
                }
                if (parentNode == null)
                {

                    tv1.Nodes.Add(t);
                    childNode = t;
                }
                else
                {

                    parentNode.Nodes.Add(t);

                    childNode = t;

                }

                PopulateTreeView((dr["CAT_CODE"].ToString()), childNode);
            }
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedIndex = -1;
                    else if (control is DateTimePicker)
                        (control as DateTimePicker).Value = DateTime.Now;
                    else if (control is DevComponents.Editors.DoubleInput)
                        (control as DevComponents.Editors.DoubleInput).Value = 0;

                    else
                        func(control.Controls);
            };

            func(Controls);
          //  BranchId.Text = Properties.Settings.Default.BranchId;
        }

        private void AddData(TreeNode nod)
        {
            try
            {
                if (tv1.SelectedNode != null)
                {
                    DataRow r = _acountsTb.Rows[int.Parse(nod.Tag.ToString())];
                    if (r["T_FINAL"].ToString() == "0")
                    {
                        ClearTextBoxes();
                        panel2.Visible = true;
                        cmbMain.SelectedValue = r["CAT_CODE"].ToString();
                        txtLevel.Text = (Int32.Parse(r["T_LEVEL"].ToString()) + 1).ToString();
                    }
                    else
                    {
                        MessageBox.Show("لايمكن الاضافة الي حساب فرعي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("يرجي تحديد الحساب الرئيسي من شجرة الحسابات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void searchCat()
        {
            DataTable dt_ = dal.getDataTabl_1(@"SELECT CAT_CODE,CAT_NAME,REF_NO,NOTES,NOTES2,BRANCH_CODE,CAT_NAME_E,Mobile,Email, T_FINAL, PREV_NO,T_LEVEL FROM CATEGORY
            where 
            isnull(CAT_CODE,'') like '" + txtSearch_Code.Text+
            "%' and (isnull(CAT_NAME,'')      like '%" + txtSearch_Name.Text+ "%' or isnull(CAT_NAME_E,'')    like '%" + txtSearch_Name.Text +
            "%') And isnull(NOTES,'')         like '" + txtSearch_NID.Text+
            "%' and isnull(NOTES2,'')       like '%" + txtSearch_IBan.Text+
            "' and isnull(BRANCH_CODE,'')   like '" + txtSearch_Branch.ID.Text+
            "%' and isnull(Mobile,'')        like '" + txtSearch_Mobile.Text+
            "%' and isnull(Email ,'')        like '%" + txtSearch_Email.Text+"%'");
            if (dt_.Rows.Count > 0)
            {
                dgv1.Rows.Clear();
                int rowscount = dt_.Rows.Count;
                if (rowscount > 0)
                {
                    dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)
                    {
                        dgv1.Rows[i].Cells["_No"].Value = dt_.Rows[i]["CAT_CODE"].ToString();
                        dgv1.Rows[i].Cells["_EmployeeID"].Value = dt_.Rows[i]["REF_NO"].ToString();
                        dgv1.Rows[i].Cells["_Name"].Value = dt_.Rows[i]["CAT_NAME"].ToString();
                        dgv1.Rows[i].Cells["_Name_English"].Value = dt_.Rows[i]["CAT_NAME_E"].ToString();
                        dgv1.Rows[i].Cells["_National_ID"].Value = dt_.Rows[i]["NOTES"].ToString();
                        dgv1.Rows[i].Cells["_IBan"].Value = dt_.Rows[i]["NOTES2"].ToString();
                        dgv1.Rows[i].Cells["_Email"].Value = dt_.Rows[i]["Email"].ToString();
                        dgv1.Rows[i].Cells["_Mobile"].Value = dt_.Rows[i]["Mobile"].ToString();
                        dgv1.Rows[i].Cells["_Branch_Code"].Value = dt_.Rows[i]["BRANCH_CODE"].ToString();
                        dgv1.Rows[i].Cells["_final"].Value = dt_.Rows[i]["T_FINAL"].ToString();
                        dgv1.Rows[i].Cells["_PrevNo"].Value = dt_.Rows[i]["PREV_NO"].ToString();
                        dgv1.Rows[i].Cells["_level"].Value = dt_.Rows[i]["T_LEVEL"].ToString();

                    }
                }
            }
        }

        public override void Search()
        {
            group_Search.Visible = true;
             base.Search();
        }

        private void txtSearch_Code_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();
        }

        private void txtSearch_Name_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();
        }

        private void txtSearch_NID_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();

        }

        private void txtSearch_IBan_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();
        }

        private void txtSearch_Branch_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();
        }

        private void txtSearch_Email_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();
        }

        private void txtSearch_Mobile_KeyUp(object sender, KeyEventArgs e)
        {
            searchCat();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            group_Search.Visible = false;
        }

       

        //'" + (radioParent.Checked ? "0" : "1")+"'
        //AccLevel.Text = (Int32.Parse(r[23].ToString()) + 1).ToString()

        public override void New()
        {

          
            _selectedNode = tv1.SelectedNode;
            AddData(_selectedNode);
            IsNew = true;

            base.New();
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            int i = dgv1.CurrentCell.RowIndex;

            txtCode.Text = dgv1.Rows[i].Cells["_No"].Value.ToString();
            txtEmpId.Text = dgv1.Rows[i].Cells["_EmployeeID"].Value.ToString();
            txtName.Text = dgv1.Rows[i].Cells["_Name"].Value.ToString();
            txtName_E.Text = dgv1.Rows[i].Cells["_Name_English"].Value.ToString();
            txtIdNo.Text = dgv1.Rows[i].Cells["_National_ID"].Value.ToString();
            txtIBan.Text = dgv1.Rows[i].Cells["_IBan"].Value.ToString();
            txtEmail.Text = dgv1.Rows[i].Cells["_Email"].Value.ToString();
            txtMobile.Text = dgv1.Rows[i].Cells["_Mobile"].Value.ToString();
            txtBranch.ID.Text = dgv1.Rows[i].Cells["_Branch_code"].Value.ToString();
            cmbMain.SelectedValue= dgv1.Rows[i].Cells["_PrevNo"].Value.ToString();
            if (dgv1.Rows[i].Cells["_Final"].Value.ToString() == "0")
            {
                radioParent.Checked = true;
            }
            else
            {
                radioTransaction.Checked = true;
            }
            txtLevel.Text = dgv1.Rows[i].Cells["_level"].Value.ToString();



            group_Search.Visible = false;
            IsNew = false;

        }

        public override void Save()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dal.sqlconn_1;
            dal.open_1();
            if (IsNew == true)
            {

                cmd.CommandText = @"INSERT INTO CATEGORY
                (CAT_CODE, CAT_NAME, REF_NO, REF_AMOUNT, REF_START_DATE, REF_END_DATE, G_DATE
                , NOTES, NOTES2, T_LEVEL, T_FINAL, MAIN_NO, PREV_NO, USER_ID, CAT_STOPED
                , BRANCH_CODE, CAT_NAME_E, Mobile, Email)
                VALUES (@PREV_NO+@CAT_CODE,@CAT_NAME,@REF_NO,@REF_AMOUNT,@REF_START_DATE
                ,@REF_END_DATE,@G_DATE,@NOTES,@NOTES2,@T_LEVEL,@T_FINAL,@MAIN_NO
                ,@PREV_NO,@USER_ID,@CAT_STOPED,@BRANCH_CODE,@CAT_NAME_E,@Mobile,@Email)";
            }
            else
            {
                cmd.CommandText = @"UPDATE CATEGORY
                    Set CAT_CODE = @CAT_CODE
                    ,CAT_NAME = @CAT_NAME
                    ,REF_NO = @REF_NO
                    ,REF_AMOUNT = @REF_AMOUNT
                    ,REF_START_DATE = @REF_START_DATE
                    ,REF_END_DATE = @REF_END_DATE
                    ,G_DATE = @G_DATE
                    ,NOTES = @NOTES
                    ,NOTES2 = @NOTES2
                    ,T_LEVEL = @T_LEVEL
                    ,T_FINAL = @T_FINAL
                    ,MAIN_NO = @MAIN_NO
                    ,PREV_NO = @PREV_NO
                    ,USER_ID = @USER_ID
                    ,CAT_STOPED = @CAT_STOPED
                    ,BRANCH_CODE = @BRANCH_CODE
                    ,CAT_NAME_E = @CAT_NAME_E
                    ,Mobile = @Mobile
                    ,Email = @Email
                    where CAT_CODE = @CAT_CODE";
            }

            cmd.Parameters.AddWithValue("@CAT_CODE",txtCode.Text);
            cmd.Parameters.AddWithValue("@CAT_NAME",txtName.Text);
            cmd.Parameters.AddWithValue("@REF_NO", txtEmpId.Text);
            cmd.Parameters.AddWithValue("@REF_AMOUNT","");
            cmd.Parameters.AddWithValue("@REF_START_DATE", DateTime.Now);
            cmd.Parameters.AddWithValue("@REF_END_DATE", DateTime.Now);
            cmd.Parameters.AddWithValue("@G_DATE", DateTime.Now);
            cmd.Parameters.AddWithValue("@NOTES",txtIdNo.Text);
            cmd.Parameters.AddWithValue("@NOTES2",txtIBan.Text);
            cmd.Parameters.AddWithValue("@T_LEVEL",txtLevel.Text);
            cmd.Parameters.AddWithValue("@T_FINAL", radioParent.Checked ? "0" : "1");
            cmd.Parameters.AddWithValue("@MAIN_NO",Convert.ToString(cmbMain.SelectedValue));
            cmd.Parameters.AddWithValue("@PREV_NO", Convert.ToString(cmbMain.SelectedValue));
            cmd.Parameters.AddWithValue("@USER_ID",Program.userID);
            cmd.Parameters.AddWithValue("@CAT_STOPED","");
            cmd.Parameters.AddWithValue("@BRANCH_CODE",txtBranch.ID.Text);
            cmd.Parameters.AddWithValue("@CAT_NAME_E",txtName_E.Text);
            cmd.Parameters.AddWithValue("@Mobile",txtMobile.Text);
            cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
            cmd.ExecuteNonQuery();
            base.Save();
        }

        private void txtLevel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
