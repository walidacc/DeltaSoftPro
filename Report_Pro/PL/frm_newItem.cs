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
    public partial class frm_newItem : Form
    {
        public int Close_Type = 0;

        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_newItem()
        {
            InitializeComponent();
        }

        private void frm_newItem_Load(object sender, EventArgs e)
        {
            searchGroup(txtSearchCode.Text, txtSearchName.Text);
        }

        private void searchGroup(string strCode, string strName)
        {
            DataTable dtGroup = dal.getDataTabl_1(@"SELECT group_code,group_name,isnull(NULLIF(group_e_name,''),group_name) as group_e_name FROM wh_Groups 
           where group_code like '" + strCode + "%' and ( group_name like '%" + strName + "%' or isnull(group_e_name,'') like '%" + strName + "%') and t_level = 1");
            if (dtGroup.Rows.Count > 0)
            {
                dgv1.Rows.Clear();


                int rowscount = dtGroup.Rows.Count;


                dgv1.Rows.Add(rowscount);
                for (int i = 0; i <= (rowscount - 1); i++)

                {
                    dgv1.Rows[i].Cells[col_GroupCode.Name].Value = dtGroup.Rows[i]["group_code"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        dgv1.Rows[i].Cells[col_GroupDescr.Name].Value = dtGroup.Rows[i]["group_name"].ToString();
                    }
                    else
                    {
                        dgv1.Rows[i].Cells[col_GroupDescr.Name].Value = dtGroup.Rows[i]["group_name"].ToString();
                    }
                    //dgv1.Rows[i].Cells[col_itemDescAr.Name].Value = dtGroup.Rows[i]["items_Name_ar"].ToString();
                    //dgv1.Rows[i].Cells[col_itemDescEn.Name].Value = dtGroup.Rows[i]["items_Name_en"].ToString();

                }
            }


        }

        private void txtSearchCode_KeyUp(object sender, KeyEventArgs e)
        {
            searchGroup(txtSearchCode.Text,txtSearchName.Text);
        }

        private void txtSearchName_KeyUp(object sender, KeyEventArgs e)
        {
            searchGroup(txtSearchCode.Text, txtSearchName.Text);
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                int i = dgv1.CurrentRow.Index;

                string lg = dgv1.Rows[i].Cells[col_GroupCode.Name].Value.ToString();
                string fi = (lg + "001").PadLeft(lg.Length + 3, '0');
                lblGroupCode.Text = lg;
                string max_id = dal.GetCell_1(@"select MAX(item_no) FROM wh_main_master
                     where item_no like '" + lg + "%'").ToString();
                string new_id = "";
                if (max_id.Trim() == string.Empty)
                {
                    new_id = "001";
                }
                else
                {
                    new_id = (Convert.ToInt32(max_id.Substring(lg.Length, max_id.Length - lg.Length)) + 1).ToString().PadLeft(max_id.Length - lg.Length, '0');
                }

                lblItemCode.Text = lg + new_id;
                //lblItemDesAr.Text = dgv1.Rows[i].Cells[col_itemDescAr.Name].Value.ToString();
                //lblItemDesEn.Text = dgv1.Rows[i].Cells[col_itemDescEn.Name].Value.ToString();
            }

        }

        private void btn_AddItem_Click(object sender, EventArgs e)
        {
            if(lblItemCode.Text.Trim()!= string.Empty)
            {
                Close_Type = 1;
                this.Close();
            }
        }
    }
}

