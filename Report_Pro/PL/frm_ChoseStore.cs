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
    public partial class frm_ChoseStore : Form
    {
        DataTable _acountsTb = null;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public int clos_;
        TreeNode _selectedStore = null;
        TreeNode node1 = new TreeNode("Branches");
        public frm_ChoseStore()
        {
            InitializeComponent();
        }

        private void frm_ChoseStore_Load(object sender, EventArgs e)
        {
            tvStore.Nodes.Clear();
            DataTable dt = dal.getDataTabl_1(@"SELECT *  FROM wh_USERS  where USER_ID='" + Program.userID + "'");

            if (dt.Rows[0]["CAN_GIVE_PERM"].ToString() == "1")
            {
                _acountsTb = dal.getDataTabl_1("select * from  wh_BRANCHES where t_final='1' ");
            }
            else
            {
            _acountsTb = dal.getDataTabl_1("select A.* from  wh_BRANCHES As A inner join Wh_users_branch As B on A.Branch_code =B.branch_code  where b.User_id = '" + Program.userID + "' and t_final=1 ");
            }
            
            //tvStore.Nodes.Add(node1);

            //_acountsTb = dal.getDataTabl_1("SELECT * FROM wh_BRANCHES");
            PopulateTreeView_store();
            tvStore.SelectedNode = GetNodeByName(tvStore.Nodes, Properties.Settings.Default.BranchId);
        }

        private TreeNode GetNodeByName(TreeNodeCollection nodes, string searchtext)
        {
            TreeNode n_found_node = null;
            bool b_node_found = false;

            foreach (TreeNode node in nodes)
            {

                if (node.Name == searchtext)
                {
                    b_node_found = true;
                    n_found_node = node;

                    return n_found_node;
                }

                if (!b_node_found)
                {
                    n_found_node = GetNodeByName(node.Nodes, searchtext);

                    if (n_found_node != null)
                    {
                        return n_found_node;
                    }
                }
            }
            return null;
        }


        private void PopulateTreeView_store()
        {

            TreeNode root;
            
            if (Properties.Settings.Default.lungh == "0")
            {
                root = tvStore.Nodes.Add("الفروع");
            }
            else
            {
                root = tvStore.Nodes.Add("Branches");
            }


             
            foreach (DataRow row in _acountsTb.Rows)
            {
                TreeNode node = new TreeNode();
                if (Properties.Settings.Default.lungh == "0")
                {
                    node.Text = row["branch_code"].ToString() + " - " + row["branch_name"].ToString();
                }
                else
                {
                    node.Text = row["branch_code"].ToString() + " - " + row["WH_E_NAME"].ToString();

                }
                
                node.Name = row["branch_code"].ToString();
                node.Tag = _acountsTb.Rows.IndexOf(row);
                root.Nodes.Add(node);

            }
        }
        private void tvStore_DoubleClick(object sender, EventArgs e)
        {
            clos_ = 1;
            this.Close();
        }

        private void tvStore_AfterSelect(object sender, TreeViewEventArgs e)
        {

            _selectedStore = tvStore.SelectedNode;
            GetStoreData(_selectedStore);
        }

        private void GetStoreData(TreeNode nod)
        {
            DataRow r = _acountsTb.Rows[int.Parse(nod.Tag.ToString())];
            Properties.Settings.Default.BranchId = r[0].ToString();
            Properties.Settings.Default.BranchAccID = r[5].ToString();
            Properties.Settings.Default.TRANS_TO_ACC = r[13].ToString();
            Properties.Settings.Default.Save();
        }
    }
}
