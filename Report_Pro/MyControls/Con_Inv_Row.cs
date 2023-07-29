using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; using System.Linq;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class Con_Inv_Row : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public string ProjectNo;
        public Con_Inv_Row()
        {
            InitializeComponent();
            txtUnit.DataSource = dal.getDataTabl_1(@"SELECT Wh_Unit,unit_Description,unit_Description_E FROM Wh_Unit");
            txtUnit.ValueMember = "Wh_Unit";
            if (Properties.Settings.Default.lungh == "0")
            {
                txtUnit.DisplayMember = "unit_Description";
            }
            else
            {
                txtUnit.DisplayMember = "unit_Description_E";

            }
            txtUnit.SelectedIndex = -1;

        }

        private void ID_KeyUp(object sender, KeyEventArgs e)
        {
           // get_desc();
        }

        private void get_desc()
        {
            try
            {
                txtUnit.Text = "";
                DataTable dt_ = dal.getDataTabl_1("SELECT item_no,descr,Descr_eng,Unit,isnull(sale_price,0) as sale_price FROM wh_main_master where item_no = '" +txt_Code.Text + "' or factory_no= '" + txt_Code.Text + "' ");
                if (txt_Code.Text!="" && dt_.Rows.Count > 0)
                {
                    

                  txt_Code.Text= dt_.Rows[0]["item_no"].ToString();
                  //  Weight_.Value = Convert.ToDouble(dt_.Rows[0]["Weight"].ToString());

                    txtUnit.SelectedText = dt_.Rows[0]["Unit"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        TxtDesc.Text = dt_.Rows[0]["descr"].ToString();
                    }
                    else
                    {
                        TxtDesc.Text = dt_.Rows[0]["Descr_eng"].ToString();
                    }
                    txtNote.Focus();
                }
                else
                {

                    TxtDesc.Clear();
                     txtUnit.SelectedIndex=-1;
                   
                }
                clculat_amount();
        }

            catch { }
        }

    
      

        private void ID_TextChanged(object sender, EventArgs e)
        {
            //get_desc();
            //OnLoad(e);

        }

     

       

        private void ID_KeyDown(object sender, KeyEventArgs e)
        {

        }

      

       

        private void ID_Leave(object sender, EventArgs e)
        {
            get_desc();
        }

       public void clculat_amount()
        {
            
            txt_subTOt.Text = (qty.Text.ToDecimal() * TxtPrice.Text.ToDecimal()).ToString("N3");
           
            TxtDisc.Text = (txt_DP_Ratio.Text.ToDecimal()/100 * txt_subTOt.Text.ToDecimal()).ToString("N" + dal.digits_);
            Txtvalue.Text = (txt_subTOt.Text.ToDecimal() - TxtDisc.Text.ToDecimal()).ToString("N3");

            VatValue.Text = ((VatRate.Value <= VatAccRate.Value ? VatRate.Value : VatAccRate.Value) * Txtvalue.Value).ToString("N3");
        }

        private void Qty_KeyUp(object sender, KeyEventArgs e)
        {
            clculat_amount();
            OnKeyUp(e);
        }

       

        private void txtNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                qty.Focus();

            }
        }

        private void Qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && qty.Value>0)
            {
                TxtPrice.Focus();

            }
        }

        private void txt_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_Code.Text != "")
            {

                get_ItemData(txt_Code.Text);

            }
            else if (e.KeyCode == Keys.Enter && txt_Code.Text == "")
            {
                
                PL.frm_search_items frm = new PL.frm_search_items();
               // frm.projectNo.Text = ProjectNo;
                frm.ShowDialog();

                if (frm.dGV_pro_list.SelectedRows.Count > 0)
                {
                    if (frm.clos_ == 1)
                    {
                        get_ItemData_search(frm.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());
                    }
                }
               
            }

        }

        private void get_ItemData_search(string item_No)
        {
            DataTable dt = dal.getDataTabl_1(@"SELECT M.item_no,M.descr,M.Descr_eng,M.Unit
        FROM wh_main_master as M 
            where  M.Item_no = '" + item_No + "'  ");
            if (dt.Rows.Count > 0 && dt.Rows.Count <= 1)
            {
                txt_Code.Text = dt.Rows[0]["Item_No"].ToString();
                
               // txtNote.Text = dt.Rows[0]["P_Description"].ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    TxtDesc.Text = dt.Rows[0]["descr"].ToString();
                  //  txtUnit.Text = dt.Rows[0]["unit_Description"].ToString();
                }
                else
                {
                    TxtDesc.Text = dt.Rows[0]["Descr_eng"].ToString();
                   // txtUnit.Text = dt.Rows[0]["unit_Description_E"].ToString();
                }
                txtUnit.SelectedValue = dt.Rows[0]["unit"].ToString();
                VatRate.Value = 0.15;
                txtNote.Focus();


            }
            
        }






        private void get_ItemData(string item_No)
        {
            DataTable dt = dal.getDataTabl_1(@"SELECT A.item_no,factory_no,A.descr,isnull(NULLIF(Descr_eng,''),A.descr) as Descr_eng ,Weight,unit,A.local_cost,A.NonStockItem
            ,sum(V.QTY_Balance) as BALANCE  
            , (select top 1 vat_ratio from VAT_RATIO_MASTER where  date_of_vat <= '2022-01-01'  order by date_of_vat desc) as VatRatio " +
            ",K.KM_Code " +
           " FROM wh_main_master as A  " +
            " inner join wh_Groups As B on A.group_code = B.group_code  " +
            " left join KM_MATERIAL_CODE As K on  ISNULL(NULLIF(a.KM_CODE, ''), 1) = K.KM_CODE " +
            " inner join VIEW_balance as V on A.item_no = V.item_no " +
             " where  A.item_no = '" + item_No + "' or (factory_no = '" + item_No + "' and factory_no<>'') " +
             "group by A.item_no,factory_no,A.descr,Descr_eng,Weight,unit,A.local_cost,A.NonStockItem,K.KM_Code");
            if (dt.Rows.Count > 0 && dt.Rows.Count <=1)
            {
                txt_Code.Text = dt.Rows[0]["Item_No"].ToString();
                TxtDesc.Text = dt.Rows[0]["descr"].ToString();
               // txtNote.Text = dt.Rows[0]["Notes"].ToString();
               txtUnit.SelectedValue = dt.Rows[0]["unit"].ToString();
               VatRate.Text = dt.Rows[0]["VatRatio"].ToString().ToDecimal().ToString("N2");
                         txtNote.Focus();


            }
            else
            {

                PL.frm_search_items frm = new PL.frm_search_items();
               // frm.projectNo.Text = ProjectNo;
                frm.ShowDialog();
                
                if (frm.dGV_pro_list.SelectedRows.Count > 0)
                {
                    get_ItemData_search(frm.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());
                }
            }

        }



        private void TxtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

       

        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtPrice.Value > 0)
            {
                TxtDisc.Focus();

            }
        }

        private void TxtPrice_KeyUp(object sender, KeyEventArgs e)
        {
           
            clculat_amount();
            OnKeyUp(e);
        }

        private void totWeight_KeyUp(object sender, KeyEventArgs e)
        {
          //  clculat_Peaces();
            clculat_amount();
            OnKeyUp(e);
        }

        private void txt_Code_DoubleClick(object sender, EventArgs e)
        {
          
                PL.frm_search_items frm = new PL.frm_search_items();
                //frm.projectNo.Text = ProjectNo;
                frm.ShowDialog();
            if (frm.clos_ == 1)
            {
                get_ItemData_search(frm.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());
             }
          

        }

        private void Inv_Row_Enter(object sender, EventArgs e)
        {
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          OnClick(e);
           this.Dispose();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void txt_Code_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Code_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
