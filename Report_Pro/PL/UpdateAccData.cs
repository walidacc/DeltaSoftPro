using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class UpdateAccData : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();
        string languh = Properties.Settings.Default.lungh;
        BindingSource bs = new BindingSource();
        DataTable dt_bs = new DataTable();



        public UpdateAccData()
        {
            InitializeComponent();
        }

        private void UpdateAccData_Load(object sender, EventArgs e)
        {
            createDattable();
            dgv1.DataSource = dt_bs;
            resaizeDGV();

            
        }

        void createDattable()
        {
            dt_bs.Columns.Add("_AccNo", typeof(string));
            dt_bs.Columns.Add("_Descr", typeof(string));
            dt_bs.Columns.Add("_Descr_E", typeof(string));
            dt_bs.Columns.Add("_CR", typeof(string));
            dt_bs.Columns.Add("_CrDate", typeof(string));
            dt_bs.Columns.Add("_VatID", typeof(string));
            dt_bs.Columns.Add("_Tel", typeof(string));
            dt_bs.Columns.Add("_respon", typeof(string));
            dt_bs.Columns.Add("_respon_E", typeof(string));
            dt_bs.Columns.Add("_Email", typeof(string));
            dt_bs.Columns.Add("_Address", typeof(string));
            dt_bs.Columns.Add("_Address_E", typeof(string));


        }

        void resaizeDGV()
        {
            int dgvWidth = dgv1.Width - dgv1.RowHeadersWidth;
            dgv1.Columns[0].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[1].Width = (int)(dgvWidth * 0.15);
            dgv1.Columns[2].Width = (int)(dgvWidth * 0.15);
            dgv1.Columns[3].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[4].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[5].Width = (int)(dgvWidth * 0.06);
            dgv1.Columns[6].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[7].Width = (int)(dgvWidth * 0.08);
            dgv1.Columns[8].Width = (int)(dgvWidth * 0.08);
            dgv1.Columns[9].Width = (int)(dgvWidth * 0.08);
            dgv1.Columns[10].Width = (int)(dgvWidth * 0.10);
            dgv1.Columns[11].Width = (int)(dgvWidth * 0.10);



            if (languh == "0")
            {
                dgv1.Columns[0].HeaderText = "الرقم";
                dgv1.Columns[1].HeaderText = "الوصف عربي";
                dgv1.Columns[2].HeaderText = "الوصف لاتيني";
                dgv1.Columns[3].HeaderText = "رقم السجل";
                dgv1.Columns[4].HeaderText = "انتهاء السجل";
                dgv1.Columns[5].HeaderText = "الرقم الضريبي";
                dgv1.Columns[6].HeaderText = "الهاتف";
                dgv1.Columns[7].HeaderText = "المسئول";
                dgv1.Columns[8].HeaderText = "المسئول لاتيني";
                dgv1.Columns[9].HeaderText = "الايميل";
                dgv1.Columns[10].HeaderText = "العنوان عربي";
                dgv1.Columns[11].HeaderText = "العنوان انجليزي";


            }
            else
            {
                dgv1.Columns[0].HeaderText = "Ser";
                dgv1.Columns[1].HeaderText = "Arabic Description";
                dgv1.Columns[2].HeaderText = "English Description";
                dgv1.Columns[3].HeaderText = "CR";
                dgv1.Columns[4].HeaderText = "CR Date";
                dgv1.Columns[5].HeaderText = "VAT Id";
                dgv1.Columns[6].HeaderText = "Telephon";
                dgv1.Columns[7].HeaderText = "Responsible";
                dgv1.Columns[8].HeaderText = "English Responsible";
                dgv1.Columns[9].HeaderText = "Email";
                dgv1.Columns[10].HeaderText = "Arabic Address";
                dgv1.Columns[11].HeaderText = "English Address";


            }



        }





        private void buttonX1_Click(object sender, EventArgs e)
        {
            try

            {
            //    if (txt_VatNo.Text.Replace(" ", "").Length < 15 && txt_VatNo.Text.Trim() != string.Empty)
            //    {
            //        MessageBox.Show("تأكد من الرقم الضريبي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txt_VatNo.Focus();
            //        return;

            //    }
                string facility_;
                if (ch_facility.Checked == true)
                {
                    facility_ = "YES";
                }
                else
                {
                    facility_ = "NO";
                }

                dal.Execute_1("update payer2 set PAYER_NAME='" + Desc.Text + "',payer_l_name='" + Desc_L.Text + "', adress='" + adress.Text + "', adress_E='" + adress_E.Text + "' ,SEGEL_NO='" + txtCr.Text + "',SEGEL_Expiry='" + txtCrExpiry.Text + "', COSTMER_K_M_NO='" + txt_VatNo.Text + "',notes='" + facility_ + "' ,E_MAIL='" + txtEmail.Text + "',phone_no='" + txtTel.Text + "',resp_name='"+txtResponsaple.Text+ "',resp_name_E='"+txtResponsaple_E.Text+
                    "',KM_CODE_Sales= '"+uC_KM_Sales1.ID.Text+"',KM_CODE_Purch='"+uC_KM_Purch1.ID.Text+"' where acc_no= '" + UC_Acc.ID.Text + "'");
                       
                dal.Execute_1("update wh_inv_data set adress='" + adress.Text + "', COSTMER_K_M_NO='" + txt_VatNo.Text + "' where acc_no= '" + UC_Acc.ID.Text + "'");
                MessageBox.Show("تمت عملية التعديل بنجاح", "تأكيد التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch  (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }

      
        private void update_Acc1_Load(object sender, EventArgs e)
        {




        }


        private DataTable getData(string _acc)
        {
            dt = dal.getDataTabl_1(@"select * from( select acc_no,PAYER_NAME,payer_l_name,adress,COSTMER_K_M_NO,notes,E_Mail,phone_no,resp_name
                                ,adress_E,resp_name_E,SEGEL_NO,SEGEL_Expiry,KM_CODE_Sales,KM_CODE_Purch,ROW_NUMBER() OVER(PARTITION BY Acc_no ORDER BY acc_no) AS DuplicateCount from payer2 where acc_no Like '" + _acc + "%' and t_final = 1) as A where DuplicateCount=1");
            return dt;
        }

            private void get_desc()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1(@"select PAYER_NAME,payer_l_name,adress,COSTMER_K_M_NO,notes,E_Mail,phone_no,resp_name
                                ,adress_E,resp_name_E,SEGEL_NO,SEGEL_Expiry,KM_CODE_Sales,KM_CODE_Purch from payer2 where ACC_NO= '" + UC_Acc.ID.Text + "'   ");
                if (dt_.Rows.Count > 0)
                {
                    Desc.Text = dt_.Rows[0]["PAYER_NAME"].ToString();
                    Desc_L.Text = dt_.Rows[0]["payer_l_name"].ToString();
                    adress.Text = dt_.Rows[0]["adress"].ToString();
                    txtEmail.Text = dt_.Rows[0]["E_MAIL"].ToString();
                    txt_VatNo.Text = dt_.Rows[0]["COSTMER_K_M_NO"].ToString();
                     txtTel.Text = dt_.Rows[0]["phone_no"].ToString();
                     txtResponsaple.Text = dt_.Rows[0]["resp_name"].ToString();
                     adress.Text = dt_.Rows[0]["adress"].ToString();
                    txtResponsaple_E.Text = dt_.Rows[0]["resp_name_E"].ToString();
                    adress_E.Text = dt_.Rows[0]["adress_E"].ToString();
                    txtCr.Text = dt_.Rows[0]["SEGEL_NO"].ToString();
                    txtCrExpiry.Text = dt_.Rows[0]["SEGEL_Expiry"].ToString();
                    uC_KM_Sales1.ID.Text = dt_.Rows[0]["KM_CODE_Sales"].ToString();
                    uC_KM_Purch1.ID.Text = dt_.Rows[0]["KM_CODE_Purch"].ToString();
                    //if (Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ').Length > 1)
                    //{
                    //    txt_Building.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[1];
                    //}
                    //else if (Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ').Length > 3)
                    //{
                    //    txt_Building.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[1];
                    //    txt_Road.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[3];
                    //}
                    //else if (Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ').Length > 5)
                    //{
                    //    txt_Building.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[1];
                    //    txt_Road.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[3];
                    //    txt_Block.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[5];
                    //}
                    //    else if (Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ').Length  > 7)
                    //    {
                    //    txt_Building.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[1];
                    //    txt_Road.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[3];
                    //    txt_Block.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[5];
                    //    txt_Area.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[6] + " " + Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[7];
                    //    }
                    //    else if (Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ').Length == 7)
                    //{
                    //    txt_Building.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[1];
                    //    txt_Road.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[3];
                    //    txt_Block.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[5];
                    //    txt_Area.Text = Regex.Replace(dt_.Rows[0][2].ToString(), " {2,}", " ").Split(' ')[6]; }


                    if (dt_.Rows[0][4].ToString().ToUpper() == "YES")
                    {
                        ch_facility.Checked = true;
                    }
                    else
                    {
                        {
                            ch_facility.Checked = false;
                        }
                    }

                  

                   
                }
                else
                {

                    Desc.Clear();
                    adress.Clear();
                    Desc_L.Clear();
                    txt_VatNo.Clear();
                    txt_Building.Clear();
                    txt_Road.Clear();
                    txt_Block.Clear();
                    txt_Area.Clear();
                    txtEmail.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     



       


        private void ID_KeyUp(object sender, KeyEventArgs e)
        {
            get_desc();
        }

        private void UC_Acc_Load(object sender, EventArgs e)
        {
            get_desc();
        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txt_Building.Text = adress.Text.Split(' ')[1];
            txt_Road.Text = adress.Text.Split(' ')[3];
            txt_Block.Text = adress.Text.Split(' ')[5];
            txt_Area.Text = adress.Text.Split(' ')[6];
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
            else { Block = "";
                Block_E = "";
            }

            adress.Text = Building + Road + Block;
            adress_E.Text = Building_E + Road_E + Block_E;

        }

        private void txt_Building_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
        }

        private void txt_Road_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
            //adress.Text = lbl_Building.Text + " " + txt_Building.Text + " " + lbl_Road.Text + " " + txt_Road.Text + " " + lbl_Block.Text + " " + txt_Block.Text + " " + txt_Area.Text;
        }

        private void txt_Block_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
            //adress.Text = lbl_Building.Text + " " + txt_Building.Text + " " + lbl_Road.Text + " " + txt_Road.Text + " " + lbl_Block.Text + " " + txt_Block.Text + " " + txt_Area.Text;
        }

        private void txt_Area_KeyUp(object sender, KeyEventArgs e)
        {
            setAddress();
            //adress.Text = lbl_Building.Text + " " + txt_Building.Text + " " + lbl_Road.Text + " " + txt_Road.Text + " " + lbl_Block.Text + " " + txt_Block.Text + " " + txt_Area.Text;
        }

        private void txt_Road_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void txt_Block_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void adress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            getData(txtAccount.ID.Text);
            //   dgvPO.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                dt_bs.Clear();
                int i = 0;
                DataRow row = null;
                foreach (DataRow r in dt.Rows)
                {

                    row = dt_bs.NewRow();

                    row[0] = r["Acc_no"];
                    row[1] = dt.Rows[i]["PAYER_NAME"];
                    row[2] = dt.Rows[i]["payer_l_name"];
                    row[3] = dt.Rows[i]["SEGEL_NO"];
                    row[4] = dt.Rows[i]["SEGEL_Expiry"];
                    row[5] = dt.Rows[i]["COSTMER_K_M_NO"];
                    row[6] = dt.Rows[i]["phone_no"];
                    row[7] = dt.Rows[i]["resp_name"];
                    row[8] = dt.Rows[i]["resp_name_E"];
                    row[9] = dt.Rows[i]["E_Mail"];
                    row[10] = dt.Rows[i]["adress"];
                    row[11] = dt.Rows[i]["adress_E"];

                    dt_bs.Rows.Add(row);
                    i = i + 1;
                }
                dgv1.DataSource = dt_bs;
                bs.DataSource = dgv1.DataSource;
                dgv1.DataSource = bs;
                resaizeDGV();




            }
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            UC_Acc.ID.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            Desc.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            Desc_L.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            txtCr.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
            txtCrExpiry.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
            txt_VatNo.Text = dgv1.CurrentRow.Cells[5].Value.ToString();
            txtTel.Text = dgv1.CurrentRow.Cells[6].Value.ToString();
            txtResponsaple.Text = dgv1.CurrentRow.Cells[7].Value.ToString();
            txtResponsaple_E.Text = dgv1.CurrentRow.Cells[8].Value.ToString();
            txtEmail.Text = dgv1.CurrentRow.Cells[9].Value.ToString();
            adress.Text = dgv1.CurrentRow.Cells[10].Value.ToString();
            adress_E.Text = dgv1.CurrentRow.Cells[11].Value.ToString();
        }
    }


}
