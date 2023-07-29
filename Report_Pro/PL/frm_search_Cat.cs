using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_search_Cat : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_search_Cat()
        {
            
            InitializeComponent();

                  }

        private void frm_serch_cost_Load(object sender, EventArgs e)
        {

        }

        private void searchCost(string _descrption, string _code, int _tfinal)
        {
            DataTable dt_ = dal.getDataTabl_1(@"SELECT CAT_CODE,CAT_NAME,ISNULL(NULLIF(CAT_NAME_E,''),CAT_NAME) as CAT_NAME_E
                                                FROM CATEGORY
                                                where(CAT_NAME like '%" + _descrption + "%'  or CAT_NAME_E like '%" + _descrption + "%')and CAT_CODE like '" + _code + "%' and t_final = '" + _tfinal + "'");
            
                DGV1.Rows.Clear();
                if (dt_.Rows.Count > 0)
                {

                    int B_rowscount = dt_.Rows.Count;


                    DGV1.Rows.Add(B_rowscount);
                    for (int i = 0; i <= (B_rowscount-1); i++)
                    {


                        DGV1.Rows[i].Cells[0].Value = dt_.Rows[i]["CAT_CODE"];
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            DGV1.Rows[i].Cells[1].Value = dt_.Rows[i]["CAT_NAME"];

                        }
                        else
                        {
                            DGV1.Rows[i].Cells[1].Value = dt_.Rows[i]["CAT_NAME_E"];

                        }

                    }
                }
                
            
        }

        private void DGV1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSerch_1_KeyUp(object sender, KeyEventArgs e)
        {
            searchCost(txtSerch.Text, txtSerch_1.Text,1);
        }

        private void txtSerch_KeyUp(object sender, KeyEventArgs e)
        {
            searchCost(txtSerch.Text, txtSerch_1.Text, 1);
        }
    }
}
