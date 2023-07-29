using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_AddClient : frm_Master
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_AddClient()
        {
            InitializeComponent();
            New();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_AddClient_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            
            //txtBranch.ID.Text = Properties.Settings.Default.BranchAccID;
            //txtStoreID.Text = Properties.Settings.Default.BranchId;
            //txtMainAcc.ID.Text = dal.GetCell_1(@"SELECT Costmers_acc_no FROM wh_BRANCHES where Branch_code ='"+ txtStoreID.Text +"' ").ToString();
            //txtMainLevel.Text = dal.GetCell_1(@"SELECT t_level FROM payer2 where ACC_NO= '"+txtMainAcc.ID.Text+"' and BRANCH_code ='" + txtBranch.ID.Text + "' ").ToString();
            //txtLevel.Text = (txtMainLevel.Text.ToDecimal() + 1).ToString();
            //txtAccType.Text = "A";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void setAddress()
        {
            string Building = "";
            string Road = "";
            string Block = "";
            string Building_E = "";
            string Road_E = "";
            string Block_E = "";


            if (txt_Building.Text.Trim() != string.Empty)
            {
                Building = "مبني " + txt_Building.Text + " ";
                Building_E = "Building " + txt_Building.Text + " ";

            }
            else
            {
                Building = "";
                Building_E = "";
            }

            if (txt_Road.Text.Trim() != string.Empty)
            {
                Road = "طريق " + txt_Road.Text + " ";
                Road_E = "Road " + txt_Road.Text + " ";

            }
            else
            {
                Road = "";
                Road_E = "";
            }

            if (txt_Block.Text != string.Empty || txt_Area.Text != string.Empty)
            {

                Block = "بلوك " + txt_Block.Text + " " + txt_Area.Text;
                Block_E = "Block " + txt_Block.Text + " " + txt_Area.Text;

            }
            else
            {
                Block = "";
                Block_E = "";
            }

            txtAddress.Text = Building + Road + Block;
            txtAddress_E.Text = Building_E + Road_E + Block_E;

        }




        public override void New()
        {
            ClearTextBoxes();
            txtBranch.ID.Text = Properties.Settings.Default.BranchAccID;
            txtStoreID.Text = Properties.Settings.Default.BranchId;
            txtMainAcc.ID.Text = dal.GetCell_1(@"SELECT Costmers_acc_no FROM wh_BRANCHES where Branch_code ='" + txtStoreID.Text + "' ").ToString();
            txtMainLevel.Text = dal.GetCell_1(@"SELECT t_level FROM payer2 where ACC_NO= '" + txtMainAcc.ID.Text + "' and BRANCH_code ='" + txtBranch.ID.Text + "' ").ToString();
            txtLevel.Text = (txtMainLevel.Text.ToDecimal() + 1).ToString();
            txtAccType.Text = "A";
            txtCode.Text = dal.GetCell_1(@"SELECT SUBSTRING(cast(newCode as varchar),LEN(MAIN_NO)+1,len(newCode)-LEN(MAIN_NO)) from (
            SELECT max(cast (acc_no as int)+1) as newCode ,MAIN_NO  from payer2 where t_final =1 and MAIN_NO = '"+ txtMainAcc.ID.Text+"' group by MAIN_NO ) as X").ToString();
            KM_Purch.ID.Text = "21";
            KM_Sales.ID.Text = "11";
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



        public override void Save()
        {
            if (txtAccType.Text.Trim() != "" && txtMainAcc.ID.Text.Trim() != ""
                && txtCode.Text.Trim() != "" && txtBranch.ID.Text.Trim() != ""
                && txtLevel.Text.Trim() != "" && Final.Text == "1"
                && txtName.Text.Trim() != "" && KM_Purch.ID.Text.Trim() != ""
                && KM_Sales.ID.Text.Trim() != "")
            {
                if (IsNew == true)
                {
                    dal.Execute_1(@"INSERT INTO payer2
            (acc_type,ACC_NO,BRANCH_code,MAIN_NO,PAYER_NAME,payer_l_name,Max_Sales_Am
            ,adress,phone_no,E_MAIL,fax_no,t_final,resp_name,t_level,PREV_NO,user_id
            ,CREDIT_AGE,COSTMER_K_M_NO,KM_CODE_Sales,KM_CODE_Purch,resp_name_E,adress_E
            ,SEGEL_NO,SEGEL_Expiry) 
            Values ('" + txtAccType.Text + "','" + txtMainAcc.ID.Text + txtCode.Text + "','" + txtBranch.ID.Text + "','" + txtMainAcc.ID.Text +
                    "','" + txtName.Text + "','" + txtNameE.Text + "','" + txtCreditLimit.Text.ToDecimal() + "','" + txtAddress.Text +
                    "','" + txtTelephon.Text + "','" + txtEmail.Text + "','" + txtFax.Text + "','" + Final.Text +
                    "','" + txtRespName.Text + "','" + txtLevel.Text + "','" + txtMainAcc.ID.Text +
                    "','" + Program.userID + "','" + txtCreditDays.Text.ToDecimal() + "','" + txtTaxID.Text + "','" + KM_Sales.ID.Text +
                    "','" + KM_Purch.ID.Text + "','" + txtRespNameE.Text + "','" + txtAddress_E.Text + "','" + txtCr.Text + "','" + txtCrExpiry.Text + "')");
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    dal.Execute_1(@"Update payer2
            set 
            acc_type='" + txtAccType.Text +
                "', ACC_NO = '" + txtCode.Text +
                "', BRANCH_code = '" + txtBranch.ID.Text +
                "',MAIN_NO = '" + txtMainAcc.ID.Text +
                "',PAYER_NAME='" + txtName.Text +
                "',payer_l_name = '" + txtNameE.Text +
                "',Max_Sales_Am = '" + txtCreditLimit.Text.ToDecimal() +
                "',adress = '" + txtAddress.Text +
                "',phone_no = '" + txtTelephon.Text +
                "',E_MAIL = '" + txtEmail.Text +
                "',fax_no = '" + txtFax.Text +
                "',t_final = '" + Final.Text +
                "',resp_name = '" + txtRespName.Text +
                "',t_level = '" + txtLevel.Text +
                "',PREV_NO ='" + txtMainAcc.ID.Text +
                "',user_id = '" + Program.userID +
                "',CREDIT_AGE = '" + txtCreditDays.Text.ToDecimal() +
                "',COSTMER_K_M_NO = '" + txtTaxID.Text +
                "',KM_CODE_Sales = '" + KM_Sales.ID.Text +
                "',KM_CODE_Purch = '" + KM_Purch.ID.Text +
                "',resp_name_E = '" + txtRespNameE.Text +
                "',adress_E = '" + txtAddress_E.Text +
                "',SEGEL_NO = '" + txtCr.Text +
                "',SEGEL_Expiry = '" + txtCrExpiry.Text +
                "' where  ACC_NO = '" + txtCode.Text + "'");
                    MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                IsNew = false;
            }
            else {
                MessageBox.Show(dal.rm.GetString("msgError", dal.cul), dal.rm.GetString("msgError_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            base.Save();
        }


        public override void Search()
        {
          
            PL.frm_SearchClient frm = new PL.frm_SearchClient();
            frm.txtbranchCode.Text = txtBranch.ID.Text;
            frm.Client_Vendor = "c";
            frm.ShowDialog();
            ClearTextBoxes();
            int ii = frm.DGV1.CurrentCell.RowIndex;
            getAccData(frm.DGV1.Rows[ii].Cells[0].Value.ToString(), txtBranch.ID.Text);
            IsNew = false;
            base.Search();
        }

        private void getAccData(string _acc , string _branch)
        {
            DataTable dt_ = dal.getDataTabl_1(@"select acc_type
            ,ACC_NO,BRANCH_code,MAIN_NO,PAYER_NAME,payer_l_name,Max_Sales_Am,adress
            ,phone_no,E_MAIL,fax_no,t_final,resp_name,t_level,PREV_NO,user_id,CREDIT_AGE
            ,COSTMER_K_M_NO,KM_CODE_Sales,KM_CODE_Purch,resp_name_E,adress_E,SEGEL_NO,SEGEL_Expiry
            from payer2 where acc_no = '"+_acc+ "' and BRANCH_code like '"+ _branch + "%'");
            if (dt_.Rows.Count > 0)
            {
                txtAccType.Text = dt_.Rows[0]["acc_type"].ToString();
                txtMainAcc.ID.Text = dt_.Rows[0]["MAIN_NO"].ToString();
                txtCode.Text = dt_.Rows[0]["ACC_NO"].ToString();
                txtBranch.ID.Text = dt_.Rows[0]["BRANCH_code"].ToString();
                txtMainAcc.ID.Text = dt_.Rows[0]["MAIN_NO"].ToString();
                txtName.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                txtNameE.Text = dt_.Rows[0]["payer_l_name"].ToString();
                txtCreditLimit.Text = dt_.Rows[0]["Max_Sales_Am"].ToString();
                txtAddress.Text = dt_.Rows[0]["adress"].ToString();
                txtTelephon.Text = dt_.Rows[0]["phone_no"].ToString();
                txtEmail.Text = dt_.Rows[0]["E_MAIL"].ToString();
                txtFax.Text = dt_.Rows[0]["fax_no"].ToString();
                Final.Text = dt_.Rows[0]["t_final"].ToString();
                txtRespName.Text = dt_.Rows[0]["resp_name"].ToString();
                txtLevel.Text = dt_.Rows[0]["t_level"].ToString();
                txtMainAcc.ID.Text = dt_.Rows[0]["PREV_NO"].ToString();
                Program.userID = dt_.Rows[0]["user_id"].ToString();
                txtCreditDays.Text = dt_.Rows[0]["CREDIT_AGE"].ToString();
                txtTaxID.Text = dt_.Rows[0]["COSTMER_K_M_NO"].ToString();
                KM_Sales.ID.Text = dt_.Rows[0]["KM_CODE_Sales"].ToString();
                KM_Purch.ID.Text = dt_.Rows[0]["KM_CODE_Purch"].ToString();
                txtRespNameE.Text = dt_.Rows[0]["resp_name_E"].ToString();
                txtAddress_E.Text = dt_.Rows[0]["adress_E"].ToString();
                txtCr.Text = dt_.Rows[0]["SEGEL_NO"].ToString();
                txtCrExpiry.Text = dt_.Rows[0]["SEGEL_Expiry"].ToString();

            }


        }


        private void labelX11_Click(object sender, EventArgs e)
        {

        }

        private void txt_Building_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
        }

        private void txt_Road_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
        }

        private void txt_Block_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
        }

        private void txt_Area_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
        }
    }
}
