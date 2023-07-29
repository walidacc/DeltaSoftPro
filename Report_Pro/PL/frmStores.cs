using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using System.IO;

namespace Report_Pro.PL
{
   
    public partial class frmStores : Form
    {
      ResourceManager rm;
 TreeNode _selectedNode = null;
        DataTable _acountsTb = null;
        // bool _newNode, _thisLevel;
        // string _parent ;

        byte[] photo_aray;
    DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
                public frmStores()
        {
            InitializeComponent();

            cmb_Combany.DataSource = dal.getDataTabl_1(@"SELECT Company_No,Company_a_name,Company_e_name FROM Wh_Oiner_Comp");
            if (Properties.Settings.Default.lungh == "0")
            {
            cmb_Combany.DisplayMember = "Company_a_name";
            }
            else
            {
                cmb_Combany.DisplayMember = "Company_a_name";
            }
            cmb_Combany.ValueMember = "Company_No";



        }



        private void BSave_Click(object sender, EventArgs e)
        {
            updatestore();

            TV1.Nodes.Clear();
            _acountsTb = dal.getDataTabl_1("SELECT * FROM wh_BRANCHES");
            PopulateTreeView("0", null);

            txt_MBranch.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            //StoreId.Enabled = false;
            //MessageBox.Show(rm.GetString("SaveMessage"));
        }



        private void updatestore()
        {
            byte[] big_Logo = null;
            byte[] small_Logo = null;


            if (pictureBox1.Image == null)
            {

                big_Logo = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                big_Logo = ms.GetBuffer();
                ms.Close();
            }

            if (pictureBox2.Image == null)
            {
                small_Logo = null;
            }
            else
            {


                MemoryStream ms1 = new MemoryStream();
                pictureBox2.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                small_Logo = ms1.GetBuffer();
                ms1.Close();
            }






            DataTable dt = dal.getDataTabl_1(@"select Branch_code  from wh_BRANCHES where Branch_code ='" + txt_BranchCode.Text.ToString() + "'");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = dal.sqlconn_1;
            dal.open_1();

            if (dt.Rows.Count > 0)
            {
                cmd.CommandText = @"UPDATE WH_BRANCHES
                SET Branch_code                 = @Branch_code 
                ,branch_name                    = @branch_name 
                ,WH_E_NAME                      = @WH_E_NAME 
                ,wh_short_name                  = @wh_short_name 
                ,wh_stoped                      = @wh_stoped 
                ,ACC_BRANCH                     = @ACC_BRANCH 
                ,Company_code                   = @Company_code 
                ,Area_code                      = @Area_code 
                ,SALES_ACC_NO                   = @SALES_ACC_NO 
                ,PUR_ACC_NO                     = @PUR_ACC_NO 
                ,TRANS_TO_ACC                   = @TRANS_TO_ACC 
                ,Cash_acc_no                    = @Cash_acc_no 
                ,Costmers_acc_no                = @Costmers_acc_no 
                ,Suppliers_acc_no               = @Suppliers_acc_no 
                ,Opininig_balance_acc_no        = @Opininig_balance_acc_no 
                ,PHONE_NO                       = @PHONE_NO 
                ,FAX_NO                         = @FAX_NO 
                ,E_MAIL                         = @E_MAIL 
                ,t_final                        = @t_final 
                ,t_level                        = @t_level 
                ,PREV_NO                        = @PREV_NO 
                ,MAIN_NO                        = @MAIN_NO 
                ,G_DATE                         = @G_DATE 
                ,user_id                        = @user_id 
                ,Pur_Expensive_Acc_No           = @Pur_Expensive_Acc_No 
                ,Cargo_Expen_No                 = @Cargo_Expen_No 
                ,Invintory_Acc_no               = @Invintory_Acc_no 
                ,Transport_Exp_acc_no           = @Transport_Exp_acc_no 
                ,K_M_ACC_NO_SALES               = @K_M_ACC_NO_SALES 
                ,K_M_ACC_NO_PURCH               = @K_M_ACC_NO_PURCH 
                ,COMP_TAX_NO                    = @COMP_TAX_NO 
                ,Interval_Of_Reciving_Material  = @Interval_Of_Reciving_Material 
                ,LONG_ADESS_A                   = @LONG_ADESS_A
                ,LONG_ADESS_E                   = @LONG_ADESS_E
                ,Branch_Logo                    = @Branch_Logo
                ,Branch_Logo_Small              = @Branch_Logo_Small
                ,Branch_Logo_A4                 = @Branch_Logo_A4
                ,CR                             = @CR
                ,Website                        = @Website
                ,downpayment_Acc                = @downpayment_Acc
                ,Ohad_Acc_No                    = @Ohad_Acc_No
                ,print_mode                     = @print_mode
                ,guarantee_Acc                  =@guarantee_Acc
                where Branch_code               = @Branch_code ";
            }
            else
            {
                cmd.CommandText = @"INSERT INTO wh_BRANCHES ( 
                Branch_code
            ,branch_name
            ,WH_E_NAME
            ,wh_short_name 
            ,wh_stoped
            ,ACC_BRANCH
            ,Company_code
            ,Area_code
            ,SALES_ACC_NO
            ,PUR_ACC_NO
            ,TRANS_TO_ACC
            ,Cash_acc_no
            ,Costmers_acc_no
            ,Suppliers_acc_no
            ,Opininig_balance_acc_no
            ,PHONE_NO
            ,FAX_NO
            ,E_MAIL
            ,t_final
            ,t_level
            ,PREV_NO
            ,MAIN_NO
            ,G_DATE
            ,user_id
            ,Pur_Expensive_Acc_No
            ,Cargo_Expen_No
            ,Invintory_Acc_no
            ,Transport_Exp_acc_no
            ,K_M_ACC_NO_SALES
            ,K_M_ACC_NO_PURCH
            ,COMP_TAX_NO
            ,Interval_Of_Reciving_Material
            ,LONG_ADESS_A
            ,LONG_ADESS_E
            ,Branch_Logo
            ,Branch_Logo_Small
            ,Branch_Logo_A4
            ,CR
            ,Website
            ,downpayment_Acc
            ,print_mode
            ,guarantee_Acc)
            Values (
            @Branch_code 
            ,@branch_name 
            ,@WH_E_NAME 
            ,@wh_short_name 
            ,@wh_stoped 
            ,@ACC_BRANCH 
            ,@Company_code 
            ,@Area_code 
            ,@SALES_ACC_NO 
            ,@PUR_ACC_NO 
            ,@TRANS_TO_ACC 
            ,@Cash_acc_no 
            ,@Costmers_acc_no 
            ,@Suppliers_acc_no 
            ,@Opininig_balance_acc_no 
            ,@PHONE_NO 
            ,@FAX_NO 
            ,@E_MAIL 
            ,@t_final 
            ,@t_level 
            ,@PREV_NO 
            ,@MAIN_NO 
            ,@G_DATE 
            ,@user_id 
            ,@Pur_Expensive_Acc_No 
            ,@Cargo_Expen_No 
            ,@Invintory_Acc_no 
            ,@Transport_Exp_acc_no 
            ,@K_M_ACC_NO_SALES 
            ,@K_M_ACC_NO_PURCH 
            ,@COMP_TAX_NO 
            ,@Interval_Of_Reciving_Material 
            ,@LONG_ADESS_A
            ,@LONG_ADESS_E
            ,@Ohad_Acc_No
            ,@Branch_Logo
            ,@Branch_Logo_Small
            ,@Branch_Logo_A4
            ,@CR
            ,@Website
            ,@downpayment_Acc
            ,@print_mode
            ,@guarantee_Acc)";

            }


            cmd.Parameters.AddWithValue("@Branch_code", txt_BranchCode.Text);
            cmd.Parameters.AddWithValue("@branch_name", txt_BranchName.Text);
            cmd.Parameters.AddWithValue("@WH_E_NAME", txt_BrancName_L.Text);
            cmd.Parameters.AddWithValue("@wh_short_name", txt_ShortName.Text);
            cmd.Parameters.AddWithValue("@wh_stoped", (wh_active.Checked ? "1" : "0"));
            cmd.Parameters.AddWithValue("@ACC_BRANCH", txt_AccBranch.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Company_code", Convert.ToString(cmb_Combany.SelectedValue));
            cmd.Parameters.AddWithValue("@Area_code", txt_area.ID.Text);
            cmd.Parameters.AddWithValue("@SALES_ACC_NO", txt_SalesAcc.ID.Text);
            cmd.Parameters.AddWithValue("@PUR_ACC_NO", txt_PurAcc.ID.Text);
            cmd.Parameters.AddWithValue("@TRANS_TO_ACC", txt_Tranc_ToAcc.ID.Text);
            cmd.Parameters.AddWithValue("@Cash_acc_no", txt_CashAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Costmers_acc_no", txt_CostmersAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Suppliers_acc_no", txt_SuppliersAacc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Opininig_balance_acc_no", txt_OpeningAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@PHONE_NO", TxtTel.Text);
            cmd.Parameters.AddWithValue("@FAX_NO", TxtFax.Text);
            cmd.Parameters.AddWithValue("@E_MAIL", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@t_final", (radioParent.Checked ? "0" : "1"));
            cmd.Parameters.AddWithValue("@t_level", txt_BranchLevel.Text.ToString());
            cmd.Parameters.AddWithValue("@PREV_NO", txt_MBranch.Text.ToString());
            cmd.Parameters.AddWithValue("@MAIN_NO", txt_MBranch.Text.ToString());
            cmd.Parameters.AddWithValue("@G_DATE", Sdate.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@user_id", Program.userID.ToString());
            cmd.Parameters.AddWithValue("@Pur_Expensive_Acc_No", txt_PurFessAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Cargo_Expen_No", txt_CargoAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Invintory_Acc_no", txt_InventoryAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@Transport_Exp_acc_no", txt_BoanasAcc.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@K_M_ACC_NO_SALES", txt_KM_Sales.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@K_M_ACC_NO_PURCH", txt_KM_purchase.ID.Text.ToString());
            cmd.Parameters.AddWithValue("@COMP_TAX_NO", txt_KM_No.Text.ToString());
            cmd.Parameters.AddWithValue("@Interval_Of_Reciving_Material", 0);
            cmd.Parameters.AddWithValue("@LONG_ADESS_A", TxtAddress.Text);
            cmd.Parameters.AddWithValue("@LONG_ADESS_E", TxtAddress_E.Text);
            cmd.Parameters.AddWithValue("@Ohad_Acc_No", txt_AdvanceAcc.ID.Text);

            if (pictureBox2.Image != null)
            {
                cmd.Parameters.AddWithValue("@Branch_Logo", dal.ConvertImageToBytes(pictureBox2.Image));
                cmd.Parameters.AddWithValue("@Branch_Logo_Small", dal.ConvertImageToBytes(pictureBox2.Image));

            }
            else
            {
                cmd.Parameters.Add("@Branch_Logo", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                cmd.Parameters.Add("@Branch_Logo_Small", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
            }
            if (pictureBox1.Image != null)
            {
                cmd.Parameters.AddWithValue("@Branch_Logo_A4", dal.ConvertImageToBytes(pictureBox1.Image));
            }
            else
            {
                cmd.Parameters.Add("@Branch_Logo_A4", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;

            }
            cmd.Parameters.AddWithValue("@CR", txtCr.Text);
            cmd.Parameters.AddWithValue("@Website", txtWebSite.Text);
            cmd.Parameters.AddWithValue("@downpayment_Acc", downpayment_Acc.ID.Text);
            cmd.Parameters.AddWithValue("@print_mode", Convert.ToString(cmbPrintMode.SelectedValue));
            cmd.Parameters.AddWithValue("@guarantee_Acc", txt_guarantee_Acc.ID.Text);
            cmd.ExecuteNonQuery();
           // MessageBox.Show(rm.GetString("msgSave"));
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            updatestore();

            txt_MBranch.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            
        
        }


        private void PopulateTreeView(string parentId, TreeNode parentNode)
        {
            TreeNode childNode;
            foreach (DataRow dr in _acountsTb.Select("[prev_no]= '" + parentId + "'"))
            {
                TreeNode t = new TreeNode();
                t.Text = dr["Branch_code"].ToString() + " - " + dr["branch_name"].ToString();
                t.Name = dr["Branch_code"].ToString();
                t.Tag = _acountsTb.Rows.IndexOf(dr);
                if (dr["T_final"].ToString() == "0")
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

                    TV1.Nodes.Add(t);
                    childNode = t;
                }
                else
                {

                    parentNode.Nodes.Add(t);

                    childNode = t;

                }

                PopulateTreeView((dr["Branch_code"].ToString()), childNode);
            }
        }

        private void frmStores_Load(object sender, EventArgs e)
        {

            cmbPrintMode.DataSource = dal.getDataTabl_1("SELECT FORM_CODE,FORM_NAME FROM WH_PRINTERS_FORM");
            cmbPrintMode.DisplayMember = "FORM_NAME";
            cmbPrintMode.ValueMember = "FORM_CODE";
            cmbPrintMode.SelectedIndex = -1;
            //rm = new ResourceManager("Products.Resources.message.ar_EG", System.Reflection.Assembly.GetExecutingAssembly());

            _acountsTb = dal.getDataTabl_1("SELECT * FROM wh_BRANCHES");
            
            PopulateTreeView("0", null);
        }

        private void TV1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearTextBoxes();
            _selectedNode = TV1.SelectedNode;
            ShowNodeData(_selectedNode);
            BEdit.Enabled = true;
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



        private void ShowNodeData(TreeNode nod)
        {
            //try
            //{
                DataRow r = _acountsTb.Rows[int.Parse(nod.Tag.ToString())];


               txt_BranchCode.Text = r["Branch_code"].ToString();
              txt_BranchName.Text = r["branch_name"].ToString();
               txt_BrancName_L.Text = r["WH_E_NAME"].ToString();
               txt_ShortName.Text = r["wh_short_name"].ToString();

                if (r["wh_stoped"].ToString()!="1")
                {
                   wh_active.Checked = true;
                }
                else
                {
                   wh_stoped.Checked = true;
                }

               txt_AccBranch.ID.Text = r["ACC_BRANCH"].ToString();
               txt_area.ID.Text= r["Area_code"].ToString();


               txt_SalesAcc.ID.Text = r["SALES_ACC_NO"].ToString();
               txt_PurAcc.ID.Text = r["PUR_ACC_NO"].ToString();
               txt_Tranc_ToAcc.ID.Text = r["TRANS_TO_ACC"].ToString();
               txt_CashAcc.ID.Text = r["Cash_acc_no"].ToString();
               txt_CostmersAcc.ID.Text = r["Costmers_acc_no"].ToString();
               txt_SuppliersAacc.ID.Text = r["Suppliers_acc_no"].ToString();
               txt_OpeningAcc.ID.Text = r["Opininig_balance_acc_no"].ToString();
               txt_CityCode.Text = r["CITY_CODE"].ToString();
             if (r["t_final"].ToString().Equals("0"))
                {
                    radioParent.Checked = true;
                }
                else
                {
                    radioTransaction.Checked = true;
                }

               txt_BranchLevel.Text = r["t_level"].ToString();
               txt_MBranch.Text = r["PREV_NO"].ToString();
               //txt_MBranch.Text = r[27].ToString();
               Sdate.Text=r["G_DATE"].ToString();
               txt_PurFessAcc.ID.Text = r["Pur_Expensive_Acc_No"].ToString();
               txt_CargoAcc.ID.Text = r["Cargo_Expen_No"].ToString();
               txt_conection.ID.Text = r["Com_Code"].ToString();
               txt_InventoryAcc.ID.Text = r["Invintory_Acc_no"].ToString();
               txt_3.ID.Text = r["Invintory_Running_acc_no"].ToString();
               //txt_BoanasAcc.ID.Text = r[71].ToString();
               //c.ID.Text = r[72].ToString();
               //txt_SP_Inventory.ID.Text = r[75].ToString();
               //txt_TR_Inventory.ID.Text = r[76].ToString();
               //txt_OI_Inventory.ID.Text = r[77].ToString();
               //txt_WS_Inventory.ID.Text = r[78].ToString();
               //txt_TO_Inventory.ID.Text = r[79].ToString();
               //txt_OSP_Inventory.ID.Text = r[80].ToString();
               //txt_Petrol_Supp.ID.Text = r[81].ToString();
               //txt_2.ID.Text = r[82].ToString();
               //txt_1.ID.Text = r[83].ToString();
               //txt_4.ID.Text = r[36].ToString();
               //txt_5.ID.Text = r[84].ToString();
               //txt_6.ID.Text = r[85].ToString();
               //txt_7.ID.Text = r[86].ToString();
               txt_KM_Sales.ID.Text = r["K_M_ACC_NO_SALES"].ToString();
               txt_KM_purchase.ID.Text = r["K_M_ACC_NO_PURCH"].ToString();
               txt_KM_No.Text = r["K_M_ACC_NO"].ToString();

                if (r["Branch_Logo_A4"] != System.DBNull.Value)
                {
                    byte[] h_pic = (byte[])(r["Branch_Logo_A4"]);
                    MemoryStream ms = new MemoryStream(h_pic);
                     pictureBox1.Image = Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    // ms.Close();
                }
                else
                {
                    pictureBox1.Image = null;
                }

            pictureBox2.Image = null;
            if (r["Branch_Logo_Small"] != System.DBNull.Value)
            {
                photo_aray = (byte[])r["Branch_Logo_Small"];
                MemoryStream ms = new MemoryStream(photo_aray);
                pictureBox2.Image = Image.FromStream(ms);
            }

            //MessageBox.Show(((byte[])r["Branch_Logo_Small"]).ToString());
            // if ((byte[]) r["Branch_Logo_Small"] != null)
            //    {
            //        byte[] f_pic = (byte[])r["Branch_Logo_Small"];
            //        MemoryStream ms1 = new MemoryStream(f_pic);
            //        pictureBox2.Image = Image.FromStream(ms1);
            //        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //        pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            //        //ms1.Close();
            //    }
                else
                {
                    pictureBox2.Image = null;
                }
            TxtEmail.Text = r["E_MAIL"].ToString();
            TxtTel.Text = r["PHONE_NO"].ToString();
            TxtFax.Text = r["FAX_NO"].ToString();
            TxtAddress.Text= r["LONG_ADESS_A"].ToString();
            TxtAddress_E.Text = r["LONG_ADESS_E"].ToString();
            txtCr.Text = r["CR"].ToString();
            txtWebSite.Text = r["Website"].ToString();
            txt_KM_No.Text = r["COMP_TAX_NO"].ToString();
            cmbPrintMode.SelectedValue = r["print_mode"].ToString();
            txt_AdvanceAcc.ID.Text = r["Ohad_Acc_No"].ToString();
            txt_guarantee_Acc.ID.Text = r["guarantee_Acc"].ToString();
            //}

            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();

            _selectedNode = TV1.SelectedNode;
            AddData(_selectedNode);
            //StoreId.Focus();
        }


        private void AddData(TreeNode nod)
        {
            try
            {
                if (TV1.SelectedNode != null)
                {
                    DataRow r = _acountsTb.Rows[int.Parse(nod.Tag.ToString())];
                    if (r["t_final"].ToString()=="0")
                    {
                        ClearTextBoxes();
                        txt_MBranch.Visible = true;
                        panel1.Visible = true;
                        panel2.Visible = true;
                       // StoreId.Enabled = true;
                        txt_MBranch.Text = r["Branch_code"].ToString();
                        txt_BranchLevel.Text = (Int32.Parse(r["t_level"].ToString()) + 1).ToString();

                        string AccNo = string.Empty;

                    }
                    else
                    {

                        MessageBox.Show("لايمكن الاضافة الي مستودع فرعي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    if (MessageBox.Show("لم تختار حساب رئيسي : هل تريد اضافة مستودع مستوي اول", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        txt_MBranch.Visible = true;
                        panel1.Visible = true;
                        panel2.Visible = true;
                        //StoreId.Enabled = true;
                        txt_MBranch.Text = "";
                        txt_BranchLevel.Text = "1";

                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "c:/pic/";
                f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
                f.FilterIndex = 1;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(f.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;

                    //MemoryStream ms = new MemoryStream();
                    //pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //big_Logo = ms.GetBuffer();
                    //ms.Close();


                }
            }
            catch
            {
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "c:/pic/";
                f.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
                f.FilterIndex = 2;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(f.FileName);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.BorderStyle = BorderStyle.Fixed3D;

                }
            }
            catch
            {
            }
        }

        private void GroupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void BSearch_Click(object sender, EventArgs e)
        {

        }

        private void BAttache_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel5_Click(object sender, EventArgs e)
        {

        }
    }
}
