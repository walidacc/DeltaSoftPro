using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Report_Pro.PL
{
   
    public partial class frm_Group : Form
    {
        int position;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        //BL.Cls_product prd = new BL.Cls_product();
        //BL.Cls_PO po = new BL.Cls_PO();

        public frm_Group()
        {
            InitializeComponent();


            cmb_cat.DataSource = dal.getDataTabl_1("select * from wh_Groups");
            cmb_cat.DisplayMember = "group_name";
            cmb_cat.ValueMember = "group_code";

            //cmb_co.DataSource = dal.getDataTabl("get_co_data");
            //cmb_co.DisplayMember = "Co_Name";
            //cmb_co.ValueMember = "Co_ID";
            //cmb_co.SelectedValue = Properties.Settings.Default.CoId;

            dGlist.DataSource = dal.getDataTabl_1("select * from wh_Groups");

         
        }

     

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Close();

        }


        void navigate(int index)
        {
            //try
            //{

           
            DataTable dt = dal.getDataTabl_1("select * from wh_Groups");
            TxtId.Text = dt.Rows[index][0].ToString();
            TxtDesc.Text = dt.Rows[index][1].ToString();
            TxtDesc_En.Text = dt.Rows[index][2].ToString();
            cmb_cat.SelectedValue = dt.Rows[index][4].ToString();
            cmb_co.SelectedValue = dt.Rows[index][4].ToString();
          
            //}
            //catch
            //{
            //    return;
            //}
        }
        private void Btn_Frist_Click(object sender, EventArgs e)
        {
            navigate(0);
            Lbl_position.Text = 1 + "/" +dal.getDataTabl_1("select * from wh_Groups").Rows.Count;
        }

        private void Btn_Prev_Click(object sender, EventArgs e)
        {
            if (position == 0)
            {
                MessageBox.Show("هذا هو السجل الاول", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position -= 1;
            navigate(position);
            Lbl_position.Text = (position + 1).ToString() + "/" + dal.getDataTabl_1("select * from wh_Groups").Rows.Count;
        
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            if (position ==dal.getDataTabl_1("select * from wh_Groups").Rows.Count - 1)
            {
                MessageBox.Show("هذا هو السجل الاخير", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position += 1;
            navigate(position);
            Lbl_position.Text = (position + 1).ToString() + "/" + dal.getDataTabl_1("select * from wh_Groups").Rows.Count;
        }

        private void Btn_Last_Click(object sender, EventArgs e)
        {
            position = dal.getDataTabl_1("select * from wh_Groups").Rows.Count - 1;
            navigate(position);
            Lbl_position.Text = (position + 1).ToString() + "/" + dal.getDataTabl_1("select * from wh_Groups").Rows.Count;
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            TxtId.Enabled = true;
            Btn_add.Enabled = false;
            Btn_sav.Enabled = true;
            ClearAllText(this);
            cmb_cat.SelectedIndex = -1;
             cmb_cat.Focus();
             cmb_co.SelectedValue = Properties.Settings.Default.CoId;
            //int new_Id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            //TxtId.Text = new_Id.ToString("00");
        }

        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else
                {
                    ClearAllText(c);
                }
            }
        }


        private void Btn_sav_Click(object sender, EventArgs e)
        {
            if (TxtId.Text != "")
            {
                try
                {
                    dal.Execute_1("INSERT INTO wh_Groups (group_code,group_name,group_e_name,prev_no,main_no,company_code) VALUES ('" + TxtId.Text + "','" + TxtDesc.Text + "', '" + TxtDesc_En.Text + "', '" + cmb_cat.SelectedValue + "', '" + cmb_cat.SelectedValue + "', '" + cmb_co.SelectedValue + "')");
                   //dal.Execute("add_cat",TxtId.Text, TxtDesc.Text, TxtDesc_En.Text, Convert.ToString(cmb_cat.SelectedValue), Convert.ToString(cmb_co.SelectedValue));
                    
                    MessageBox.Show("تم الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    position = dGlist.CurrentRow.Index;
                    Lbl_position.Text = (position + 1).ToString() + "/" + dal.getDataTabl_1("select * from wh_Groups").Rows.Count;
                    dGlist.DataSource =dal.getDataTabl_1("select * from wh_Groups"); 
                    Btn_sav.Enabled = false;
                    Btn_add.Enabled = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("يرجي التاكد من البيانات", "عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        //private void Btn_del_Click(object sender, EventArgs e)
        //{
        //    bmb.RemoveAt(bmb.Position);
        //    bmb.EndCurrentEdit();
        //    Cmdb = new SqlCommandBuilder(da);
        //    da.Update(dt);
        //    MessageBox.Show("تم الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    Btn_sav.Enabled = false;
        //    Btn_add.Enabled = true;
        //    Lbl_position.Text = (bmb.Position + 1) + "/" + bmb.Count;
        //}

      

        private void dGlist_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.TxtId.Text = dGlist.CurrentRow.Cells[0].Value.ToString();
                this.TxtId.Enabled = false;
                this.TxtDesc.Text = dGlist.CurrentRow.Cells[1].Value.ToString();
                this.TxtDesc_En.Text = dGlist.CurrentRow.Cells[2].Value.ToString();
                this.cmb_cat.SelectedValue = dGlist.CurrentRow.Cells[3].Value.ToString();
                this.cmb_co.SelectedValue = dGlist.CurrentRow.Cells[4].Value.ToString();
                position = dGlist.CurrentRow.Index;
                Lbl_position.Text = (position + 1).ToString() + "/" + dal.getDataTabl_1("select * from cat_tbl").Rows.Count;
               
            }
            catch
            {
                return;
            }
          
        }


        private void Btn_updt_Click(object sender, EventArgs e)
        {

            try
            {
                dal.Execute_1("update wh_Groups  set group_code ='" + TxtId.Text + "' ,group_name ='" + TxtDesc.Text + "' ,group_e_name ='" + TxtDesc_En.Text + "' ,main_no =  '" + Convert.ToString(cmb_cat.SelectedValue) + "',prev_no =  '" + Convert.ToString(cmb_cat.SelectedValue) + "' ,company_code =  '" + Convert.ToString(cmb_co.SelectedValue) + "' where group_code ='" + TxtId.Text + "' ");

               //dal.Execute("update_cat",TxtId.Text, TxtDesc.Text, TxtDesc_En.Text, Convert.ToString(cmb_cat.SelectedValue), Convert.ToString(cmb_co.SelectedValue));
                MessageBox.Show("تم التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                position = dGlist.CurrentRow.Index;
                Lbl_position.Text = (position + 1).ToString() + "/" + dal.getDataTabl_1("select * from wh_Groups").Rows.Count;
                dGlist.DataSource = dal.getDataTabl_1("select * from wh_Groups");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        
        }

        private void Btn_print_all_Click(object sender, EventArgs e)
        {
            RPT.rpt_cat_all rpt = new RPT.rpt_cat_all();
            RPT.Rpt_Pro_Frm frm = new RPT.Rpt_Pro_Frm();
            rpt.SetDataSource(dal.getDataTabl_1("select * from wh_Groups where group_code"));
            //frm.MdiParent = BL.Main_frm();
            rpt.Refresh();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.Show();
           

        }

        private void Btn_print_S_Click(object sender, EventArgs e)
        {
            RPT.rpt_cat_all rpt = new RPT.rpt_cat_all();
            RPT.Rpt_Pro_Frm frm = new RPT.Rpt_Pro_Frm();
          rpt.SetDataSource(dal.getDataTabl_1("select * from wh_Groups where group_code ='" + TxtId.Text + "'"));
           //DataTable dt = (dal.getDataTabl_1("select * from cat_tbl where id_cat='" + TxtId.Text + "'"));
           //DataSet ds = new DataSet();
           //ds.Tables.Add(dt);


           //ds.WriteXmlSchema(@"F:\Programs\transportation\transportation\bin\Debug\ds_1.xsd"); 
            
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void Btn_export_all_Click(object sender, EventArgs e)
        {

        }

        private void Btn_exprt_S_Click(object sender, EventArgs e)
        {

        }

        private void Cat_Frm_Load(object sender, EventArgs e)
        {

        }

        private void cmb_cat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        }

    
}
