using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_Project : frm_Master
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string btntype = "0";
        string btntype_1 = "0";
        Int32 m;
        Int32 m_1;
        public frm_Project()
        {
            InitializeComponent();
        }

        private void frm_Projects_Load(object sender, EventArgs e)
        {
            DataTable dt_B_Data = dal.getDataTabl_1(@"select guarantee_Acc,downpayment_Acc from  wh_BRANCHES where Branch_code = '" + Properties.Settings.Default.BranchId + "'");
            txt_DP_Acc.txtFinal.Text = "1";
            txt_G_Acc.txtFinal.Text = "1";
            txt_DP_Acc.txtMainAcc.Text = dt_B_Data.Rows[0]["downpayment_Acc"].ToString();
            txt_G_Acc.txtMainAcc.Text = dt_B_Data.Rows[0]["guarantee_Acc"].ToString();
            cmb_Category.DataSource = dal.getDataTabl_1(@"SELECT ID, descr, descr_E FROM projects_Category");
            cmb_Priority.DataSource = dal.getDataTabl_1(@"SELECT ID, descr, descr_E FROM projects_Priority");
            cmb_Status.DataSource = dal.getDataTabl_1(@"SELECT ID, descr, descr_E FROM projects_Status");

            cmb_Category.ValueMember = "ID";
            cmb_Priority.ValueMember = "ID";
            cmb_Status.ValueMember = "ID";
            if (Properties.Settings.Default.lungh == "0")
            {
                cmb_Category.DisplayMember = "descr";
                cmb_Priority.DisplayMember = "descr";
                cmb_Status.DisplayMember = "descr";
            }
            else
            {
                cmb_Category.DisplayMember = "descr_E";
                cmb_Priority.DisplayMember = "descr_E";
                cmb_Status.DisplayMember = "descr_E";
            }

            txt_project_ID.Text = _ser().ToString();

         
           
        }

        private int _ser()
        {
            
           int  serNo = dal.GetCell_1(@"SELECT isnull(max(CAST(PROJ_CODE AS int))+1,1) FROM Projects").ToString().ParseInt(0);
            return serNo;
        }
        

        private void BSave_Click(object sender, EventArgs e)
        {
           
        }

        public override void Save()
        {
            if (txt_project_ID.Text.Trim() != string.Empty && txt_Name.Text.Trim() != string.Empty)
            {


                if (dal.getDataTabl_1("select PROJ_CODE from Projects where PROJ_CODE='" + txt_project_ID.Text + "'").Rows.Count > 0)
                {

                    dal.Execute_1(@"Update Projects set 
                    PROJ_CODE ='" + txt_project_ID.Text + "',PROJ_name ='" + txt_Name.Text + "',PROJ_E_NAME ='" + txt_Name_E.Text + "',OINER_NOTES ='" + txt_Owner.Text + "',OINER_NOTES_E ='" + txt_Owner_E.Text + "',Category ='" + Convert.ToString(cmb_Category.SelectedValue) +
                    "',P_Priority ='" + Convert.ToString(cmb_Priority.SelectedValue) + "',P_Status='" + Convert.ToString(cmb_Status.SelectedValue) + "',Start_Date ='" + start_Date.Value.ToString("yyyy-MM-dd") +
                    "',End_Date ='" + end_Date.Value.ToString("yyyy-MM-dd") + "',Budget ='" + txt_Budget.Value + "',Budget_in_Days ='" + txt_BudgetDays.Value + "',Notes ='" + txt_Note.Text +
                    "',DP_Acc = '" + txt_DP_Acc.ID.Text + "',Project_Amount='" + txt_Amount.Value + "',DP_Ratio = '" + txt_DP_Ratio.Value + "',DP_Amount='" + txt_DP_Amount.Value +
                    "',Guarantee_Acc='" + txt_G_Acc.ID.Text + "',Guarantee_Ratio='" + txt_G_Ratio.Text.ToDecimal() + "',t_final='1'  where PROJ_CODE ='" + txt_project_ID.Text + "' ");
                    IsNew = false;
                    MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else

                {
                    dal.Execute_1(@"INSERT INTO Projects (PROJ_CODE,PROJ_name,PROJ_E_NAME,OINER_NOTES,OINER_NOTES_E,Category,P_Priority,P_Status,
                Start_Date,End_Date,Budget_in_Days,Budget,Notes,DP_Acc,Project_Amount,DP_Ratio,DP_Amount,Guarantee_Acc,Guarantee_Ratio,t_final)
                Values ('" + txt_project_ID.Text + "','" + txt_Name.Text + "','" + txt_Name_E.Text + "','" + txt_Owner.Text + "','" + txt_Owner_E.Text + "','" + Convert.ToString(cmb_Category.SelectedValue) +
                    "','" + Convert.ToString(cmb_Priority.SelectedValue) + "','" + Convert.ToString(cmb_Status.SelectedValue) + "','" + start_Date.Value.ToString("yyyy-MM-dd") +
                    "','" + end_Date.Value.ToString("yyyy-MM-dd") + "','" + txt_BudgetDays.Value + "','" + txt_Budget.Value + "','" + txt_Note.Text + "','" + txt_DP_Acc.ID.Text +
                    "','" + txt_Amount.Value + "','" + txt_DP_Ratio.Value + "','" + txt_DP_Amount.Value + "','" + txt_G_Acc.ID.Text + "','" + txt_G_Ratio.Text.ToDecimal() + "','1') ");
                    IsNew = false;
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            base.Save();
        }

        private void txt_Name_E_Enter(object sender, EventArgs e)
        {
            CultureInfo en = new CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(en);
        }

        private void txt_Name_E_Leave(object sender, EventArgs e)
        {
            CultureInfo ar = new CultureInfo("ar-sa");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(ar);
        }

        private void txt_Owner_E_Leave(object sender, EventArgs e)
        {
            CultureInfo ar = new CultureInfo("ar-sa");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(ar);
        }

        private void txt_Owner_E_Enter(object sender, EventArgs e)
        {
            CultureInfo en = new CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(en);
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BNew_Click(object sender, EventArgs e)
        {
         
        }

        public override void New()
        {
            dal.ClearTextBoxes(this);

            txt_project_ID.Text = _ser().ToString();
            txt_Name.Focus();
            base.New();
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
            // txtCoId.Text = Properties.Settings.Default.CoId;
            //BranchId.Text = Properties.Settings.Default.BranchId;
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            
        }
        public override void Search()
        {
            PL.frmSerch frm = new PL.frmSerch();
            frm.lblHead.Text = "Enter Sanad No.";
            frm.ShowDialog();
            if (frm.Close_Type == 1)
            {
                DataTable dt_Pro = dal.getDataTabl_1(@"SELECT PROJ_CODE,PROJ_name,PROJ_E_NAME,OINER_NOTES,
                OINER_NOTES_E,Category,P_Priority,P_Status,Start_Date,End_Date,Budget_in_Days,Budget,
                Notes,DP_Acc,Project_Amount,DP_Ratio,DP_Amount,Guarantee_Acc,Guarantee_Ratio
                FROM Projects where PROJ_CODE='" + frm.txtSearch.t.Text + "'");

                if (dt_Pro.Rows.Count > 0)
                {
                    txt_project_ID.Text = dt_Pro.Rows[0]["PROJ_CODE"].ToString();
                    txt_Name.Text = dt_Pro.Rows[0]["PROJ_name"].ToString();
                    txt_Name_E.Text = dt_Pro.Rows[0]["PROJ_E_NAME"].ToString();
                    txt_Owner.Text = dt_Pro.Rows[0]["OINER_NOTES"].ToString();
                    txt_Owner_E.Text = dt_Pro.Rows[0]["OINER_NOTES_E"].ToString();
                    cmb_Category.SelectedValue = dt_Pro.Rows[0]["Category"].ToString();
                    cmb_Priority.SelectedValue = dt_Pro.Rows[0]["P_Priority"].ToString();
                    cmb_Status.SelectedValue = dt_Pro.Rows[0]["P_Status"].ToString();
                    start_Date.Text = dt_Pro.Rows[0]["Start_Date"].ToString();
                    end_Date.Text = dt_Pro.Rows[0]["End_Date"].ToString();
                    txt_Budget.Text = dt_Pro.Rows[0]["Budget"].ToString().ToDecimal().ToString("N0");
                    txt_BudgetDays.Text = dt_Pro.Rows[0]["Budget_in_Days"].ToString().ParseInt(0).ToString();
                    txt_Note.Text = dt_Pro.Rows[0]["Notes"].ToString();
                    txt_DP_Acc.ID.Text = dt_Pro.Rows[0]["DP_Acc"].ToString();
                    txt_Amount.Text = dt_Pro.Rows[0]["Project_Amount"].ToString().ToDecimal().ToString("N0");
                    txt_DP_Ratio.Text = dt_Pro.Rows[0]["DP_Ratio"].ToString();
                    txt_DP_Amount.Text = dt_Pro.Rows[0]["DP_Amount"].ToString().ToDecimal().ToString("N0");
                    txt_G_Acc.ID.Text = dt_Pro.Rows[0]["Guarantee_Acc"].ToString();
                    txt_G_Ratio.Text = dt_Pro.Rows[0]["Guarantee_Ratio"].ToString().ToDecimal().ToString("N0");
                    //Get_PItems(frm.txtSearch.t.Text);
                    //Get_MainItems(frm.txtSearch.t.Text);
                    IsNew = false;
                }
            }
            
            base.Search();
        }


        private void doubleInput1_ValueChanged(object sender, EventArgs e)
        {
            txt_DP_Amount.Value = txt_Amount.Value * txt_DP_Ratio.Value / 100;
        }

        private void txt_DP_Ratio_ValueChanged(object sender, EventArgs e)
        {
            txt_DP_Amount.Value = txt_Amount.Value * txt_DP_Ratio.Value / 100;

        }

        private void BDel_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAttache_Click(object sender, EventArgs e)
        {

        }

        public override void Attachment()
        {
            DataTable dt_ = dal.getDataTabl_1(@"select PROJ_CODE from PROJECTS  where PROJ_CODE= '" + txt_project_ID.Text + "' ");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = txt_project_ID.Text;
                frmUpload.docType = "Pro";
                frmUpload.branchID = "";
                frmUpload.ShowDialog();
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            base.Attachment();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
