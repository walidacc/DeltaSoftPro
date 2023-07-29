using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public partial class ProductinGridIN : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        int _dg;
       public bool qtyOnly;
        public bool checkBalance;
        public string ClientCode;
        public ProductinGridIN()
        {
            InitializeComponent();
         
           
        }



        private void Inv_Grid_KeyDown(object sender, KeyEventArgs e)
        {


            

            if (e.KeyCode == Keys.Enter)
            {
               

                total_inv();

            }
        }

        public bool checkValidBalance()
        {

            foreach (DataGridViewRow r in dgv1.Rows)
            {
                if (r.Cells[_qty.Name].FormattedValue.ToString().ToDecimal() > r.Cells[_oldBalance.Name].FormattedValue.ToString().ToDecimal())
                {
                    return false;
                }
                else if (checkBalance == true && r.Cells[_balance.Name].FormattedValue.ToString().ToDecimal() < 0)
                {
                    return false;
                }
               
            }

            return true;



        }




        public bool IsGridValid()
        {

            int countR = 0;

            foreach (DataGridViewRow r in dgv1.Rows)
            {
                if (r.Cells["_code"].FormattedValue.ToString() != string.Empty && r.Cells["_qty"].FormattedValue.ToString().ToDecimal() > 0 && r.Cells["_price"].FormattedValue.ToString().ToDecimal() > 0)
                {
                    countR++;
                }

            }
            if (countR > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgError") + " No Items", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }



        private void r_Enter(object sender, EventArgs e)
        {
            base.OnEnter(e);
        }

       

        private void Inv_Grid_Load(object sender, EventArgs e)
        {
            bindItemType();
           

        }

        private void bindItemType()
        {
            DataTable dt_type = dal.getDataTabl_1("SELECT Item_Type,type_desc,type_desc_E  FROM Material_Type");
            var _cmbType = (DataGridViewComboBoxColumn)dgv1.Columns[_itemType.Name];
            _cmbType.DataSource = dt_type;
            if (dal.languh_ == "0")
            {
            _cmbType.DisplayMember = "type_desc";
            }
            else
            {
                _cmbType.DisplayMember = "type_desc_E";
            }
            _cmbType.ValueMember = "Item_Type";

            

        }

        //public void r_KeyUP(object sender, System.Windows.Forms.KeyEventArgs e)
        //{

        //    base.OnKeyUp(e);
        //}

        //public void r_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{

        //    base.OnKeyDown(e);
        //}

        //public void r_DoubleClick(object sender, EventArgs e)
        //{

        //    base.OnDoubleClick(e);
        //}

        //public void r_Click(object sender, EventArgs e)
        //{

        //    base.OnClick(e);
        //}

        private void Acc_Vat_Rate_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgv1.Rows.Count - 1; i++)
            {
                clculat_amount(i);
                total_inv();

            }
        }

        public void total_inv()
        {
            
            
            totalQty.Text =
            (from DataGridViewRow row in dgv1.Rows
            where row.Cells["_qty"].FormattedValue.ToString() != string.Empty
            select (row.Cells["_qty"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");

            txt_SubTot.Text =
                  (from DataGridViewRow row in dgv1.Rows
                   where row.Cells["_total"].FormattedValue.ToString() != string.Empty
                   select (row.Cells["_total"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N"+ dal.digits_);


            totalWeight.Text =
            (from DataGridViewRow row in dgv1.Rows
             where row.Cells["_totalWeight"].FormattedValue.ToString() != string.Empty
             select (row.Cells["_totalWeight"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);
          if(totalWeight.Text.ToDecimal()> 0)
            {
                txtKGCost.Text = (txt_SubTot.Text.ToDecimal() / totalWeight.Text.ToDecimal()).ToString();
            }
            else
            {
                txtKGCost.Text = "0";
            }


            

        }



        //public void total_inv_2()
        //{


        //    totalQty.Text =
        //    (from DataGridViewRow row in dgv1.Rows
        //     where row.Cells["_qty"].FormattedValue.ToString() != string.Empty
        //     select (row.Cells["_qty"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");

        //    txt_SubTot.Text =
        //          (from DataGridViewRow row in dgv1.Rows
        //           where row.Cells["_total"].FormattedValue.ToString() != string.Empty
        //           select (row.Cells["_total"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);


        //    totalWeight.Text =
        //    (from DataGridViewRow row in dgv1.Rows
        //     where row.Cells["_totalWeight"].FormattedValue.ToString() != string.Empty
        //     select (row.Cells["_totalWeight"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);
        //    if (totalWeight.Text.ToDecimal() > 0)
        //    {
        //        txtKGCost.Text = (txt_SubTot.Text.ToDecimal() / totalWeight.Text.ToDecimal()).ToString();
        //    }
        //    else
        //    {
        //        txtKGCost.Text = "0";
        //    }




        //}

        //private void Inv_Grid_Click(object sender, EventArgs e)
        //{
        //    txtAccVat_Rate.Text = "1";

        //}

        private void get_ItemData(int _rowIndex,string item_No)
        {

            DataTable dt = dal.getDataTabl_1(@"SELECT item_no,factory_no,descr,isnull(NULLIF(Descr_eng,''),descr) as Descr_eng ,Weight,unit,
             local_cost
            ,isnull((select sum(QTY_Balance) as baance from VIEW_balance as V  where  V.item_no = A.item_no and branch_code like '" + Properties.Settings.Default.BranchId+"%' ),0) as BALANCE "+
            " FROM wh_main_master as A  " +
            " inner join wh_Groups As B on A.group_code = B.group_code  " +
            " where  item_no = '" + item_No + "' or (factory_no = '" + item_No + "' and factory_no<>'')");
            if (dt.Rows.Count > 0)
            {

                dgv1.Rows[_rowIndex].Cells[_code.Name].Value = dt.Rows[0]["item_no"].ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    dgv1.Rows[_rowIndex].Cells[_itemDesription.Name].Value = dt.Rows[0]["descr"].ToString();
                }
                else
                {
                    dgv1.Rows[_rowIndex].Cells[_itemDesription.Name].Value = dt.Rows[0]["Descr_eng"].ToString();
                }
                dgv1.Rows[_rowIndex].Cells[_weight.Name].Value = dt.Rows[0]["Weight"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_unit.Name].Value = dt.Rows[0]["unit"].ToString();
                dgv1.Rows[_rowIndex].Cells[_cost.Name].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_oldCost.Name].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_oldBalance.Name].Value = dt.Rows[0]["BALANCE"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_balance.Name].Value = (dt.Rows[0]["BALANCE"].ToString().ToDecimal()).ToString("N3");

                dgv1.Rows[_rowIndex].Cells[_barcodeNo.Name].Value = "";
                dgv1.Rows[_rowIndex].Cells[_itemType.Name].Value = "01";
                dgv1.Rows[_rowIndex].Cells[_qty.Name].Value = 0;
                dgv1.Rows[_rowIndex].Cells[_totalWeight.Name].Value = 0;
                clculat_amount(_rowIndex);


            }
            else
            {
                dgv1.Rows[_rowIndex].Cells[_barcodeNo.Name].Value = dgv1.Rows[_rowIndex].Cells[_code.Name].Value;
                string _barcode;
                if (dgv1.Rows[_rowIndex].Cells["_barcodeNo"].Value == null)
                {
                    _barcode = "";
                }
                else
                {
                    _barcode = dgv1.Rows[_rowIndex].Cells["_barcodeNo"].Value.ToString();

                }

                get_ItemData_Barcode(_rowIndex, _barcode); }

            //else
            //{

            //    PL.frmSerachItem frm = new PL.frmSerachItem();

            //    frm.uc_SearchItem1.txtSrch.Text = txt_s1.Text;
            //    frm.uc_SearchItem1.txtsrch_1.Text = txt_s2.Text;
            //    frm.uc_SearchItem1.txtserch_2.Text = txt_s3.Text;
            //    frm.uc_SearchItem1.txtSrch_3.Text = txt_s4.Text;
            //    frm.uc_SearchItem1.txtserch_4.Text = txt_s5.Text;
            //    if (txtsearchChBox.Text == "1")
            //    {
            //        frm.uc_SearchItem1.ch_SaveSearch.Checked = true;
            //    }
            //    else
            //    {
            //        frm.uc_SearchItem1.ch_SaveSearch.Checked = false;
            //    }

            //    frm.ShowDialog();
            //    if (frm.clos_ == 1)
            //    {
            //        if (frm.uc_SearchItem1.dGV_pro_list.SelectedRows.Count > 0)
            //        {
            //            get_ItemData(_rowIndex, frm.uc_SearchItem1.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());

            //            if (frm.uc_SearchItem1.ch_SaveSearch.Checked)
            //            {
            //                txt_s1.Text = frm.uc_SearchItem1.txtSrch.Text;
            //                txt_s2.Text = frm.uc_SearchItem1.txtsrch_1.Text;
            //                txt_s3.Text = frm.uc_SearchItem1.txtserch_2.Text;
            //                txt_s4.Text = frm.uc_SearchItem1.txtSrch_3.Text;
            //                txt_s5.Text = frm.uc_SearchItem1.txtserch_4.Text;
            //                txtsearchChBox.Text = "1";
            //            }
            //            else
            //            {
            //                txt_s1.Clear();
            //                txt_s2.Clear();
            //                txt_s3.Clear();
            //                txt_s4.Clear();
            //                txt_s5.Clear();
            //                txtsearchChBox.Clear();
            //            }


            //        }
            //    }
            //}

        }




        private void get_ItemData_Barcode(int _rowIndex, string _barcode)
        {
            DataTable dt_coil = dal.getDataTabl_1(@"select item_no, Material_Id, (Weight - QTY_OUT) as coile_balance  from WH_FA_HEAT_NO_MASTER where Material_Id ='" + _barcode + "'");
            if (dt_coil.Rows.Count > 0)
            {

            
            DataTable dt = dal.getDataTabl_1(@"SELECT item_no,factory_no,descr,isnull(NULLIF(Descr_eng,''),descr) as Descr_eng ,Weight,unit,
             local_cost
            ,isnull((select sum(QTY_Balance) as baance from VIEW_balance as V  where  V.item_no = A.item_no and branch_code like '" + Properties.Settings.Default.BranchId + "%' ),0) as BALANCE " +
            ",K.KM_Code " +
            " FROM wh_main_master as A  " +
            " inner join wh_Groups As B on A.group_code = B.group_code  " +
            " left join KM_MATERIAL_CODE As K on  ISNULL(NULLIF(a.KM_CODE, ''), 1) = K.KM_CODE " +
            " where  item_no  = '" + dt_coil.Rows[0]["item_no"] + "'");
            if (dt.Rows.Count > 0)
            {

                dgv1.Rows[_rowIndex].Cells["_code"].Value = dt.Rows[0]["item_no"].ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    dgv1.Rows[_rowIndex].Cells["_itemDesription"].Value = dt.Rows[0]["descr"].ToString();
                }
                else
                {
                    dgv1.Rows[_rowIndex].Cells["_itemDesription"].Value = dt.Rows[0]["Descr_eng"].ToString();
                }
                dgv1.Rows[_rowIndex].Cells["_weight"].Value = dt.Rows[0]["Weight"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_unit"].Value = dt.Rows[0]["unit"].ToString();
                dgv1.Rows[_rowIndex].Cells["_cost"].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_oldCost.Name].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_oldBalance.Name].Value = (dt_coil.Rows[0]["coile_balance"].ToString().ToDecimal()).ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_balance.Name].Value = (dt_coil.Rows[0]["coile_balance"].ToString().ToDecimal()).ToString("N3");
                clculat_amount(_rowIndex);


            }
            else
            {

                PL.frmSerachItem frm = new PL.frmSerachItem();

                frm.uc_SearchItem1.txtSrch.Text = txt_s1.Text;
                frm.uc_SearchItem1.txtsrch_1.Text = txt_s2.Text;
                frm.uc_SearchItem1.txtserch_2.Text = txt_s3.Text;
                frm.uc_SearchItem1.txtSrch_3.Text = txt_s4.Text;
                frm.uc_SearchItem1.txtserch_4.Text = txt_s5.Text;
                if (txtsearchChBox.Text == "1")
                {
                    frm.uc_SearchItem1.ch_SaveSearch.Checked = true;
                }
                else
                {
                    frm.uc_SearchItem1.ch_SaveSearch.Checked = false;
                }

                frm.ShowDialog();
                if (frm.clos_ == 1)
                {
                    if (frm.uc_SearchItem1.dGV_pro_list.SelectedRows.Count > 0)
                    {
                        get_ItemData(_rowIndex, frm.uc_SearchItem1.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());

                        if (frm.uc_SearchItem1.ch_SaveSearch.Checked)
                        {
                            txt_s1.Text = frm.uc_SearchItem1.txtSrch.Text;
                            txt_s2.Text = frm.uc_SearchItem1.txtsrch_1.Text;
                            txt_s3.Text = frm.uc_SearchItem1.txtserch_2.Text;
                            txt_s4.Text = frm.uc_SearchItem1.txtSrch_3.Text;
                            txt_s5.Text = frm.uc_SearchItem1.txtserch_4.Text;
                            txtsearchChBox.Text = "1";
                        }
                        else
                        {
                            txt_s1.Clear();
                            txt_s2.Clear();
                            txt_s3.Clear();
                            txt_s4.Clear();
                            txt_s5.Clear();
                            txtsearchChBox.Clear();
                        }


                    }
                }
            }
        }

        }






        private void get_ItemData_2(int _rowIndex, string item_No)
        {

            DataTable dt = dal.getDataTabl_1(@"SELECT item_no,factory_no,descr,isnull(NULLIF(Descr_eng,''),descr) as Descr_eng ,Weight,unit,local_cost
            ,isnull((select sum(QTY_Balance) as baance from VIEW_balance as V  where  V.item_no = A.item_no and branch_code like '" + Properties.Settings.Default.BranchId + "%' ),0) as BALANCE " +
            " FROM wh_main_master as A  " +
            " inner join wh_Groups As B on A.group_code = B.group_code  " +
            " left join KM_MATERIAL_CODE As K on  ISNULL(NULLIF(a.KM_CODE, ''), 1) = K.KM_CODE " +
             " where item_no = '" + item_No + "' or (factory_no = '" + item_No + "' and factory_no<>'')");
            if (dt.Rows.Count > 0)
            {

                dgv1.Rows[_rowIndex].Cells["_code"].Value = dt.Rows[0]["item_no"].ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    dgv1.Rows[_rowIndex].Cells["_itemDesription"].Value = dt.Rows[0]["descr"].ToString();
                }
                else
                {
                    dgv1.Rows[_rowIndex].Cells["_itemDesription"].Value = dt.Rows[0]["Descr_eng"].ToString();
                }
                dgv1.Rows[_rowIndex].Cells["_weight"].Value = dt.Rows[0]["Weight"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_unit"].Value = dt.Rows[0]["unit"].ToString();
                dgv1.Rows[_rowIndex].Cells["_balance"].Value = dt.Rows[0]["BALANCE"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_oldBalance.Name].Value = dt.Rows[0]["BALANCE"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_cost"].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells[_oldCost.Name].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
               // dgv1.Rows[_rowIndex].Cells[_itemType.Name].Value = dt.Rows[0]["item_type"].ToString();
            }
            else
            {
                dgv1.Rows[_rowIndex].Cells[_barcodeNo.Name].Value = dgv1.Rows[_rowIndex].Cells[_code.Name].Value;
                string _barcode;
                if (dgv1.Rows[_rowIndex].Cells["_barcodeNo"].Value == null)
                {
                    _barcode = "";
                }
                else
                {
                    _barcode = dgv1.Rows[_rowIndex].Cells["_barcodeNo"].Value.ToString();

                }

                get_ItemData_Barcode(_rowIndex, _barcode);
                //    PL.frmSerachItem frm = new PL.frmSerachItem();

                //    frm.uc_SearchItem1.txtSrch.Text = txt_s1.Text;
                //    frm.uc_SearchItem1.txtsrch_1.Text = txt_s2.Text;
                //    frm.uc_SearchItem1.txtserch_2.Text = txt_s3.Text;
                //    frm.uc_SearchItem1.txtSrch_3.Text = txt_s4.Text;
                //    frm.uc_SearchItem1.txtserch_4.Text = txt_s5.Text;
                //    if (txtsearchChBox.Text == "1")
                //    {
                //        frm.uc_SearchItem1.ch_SaveSearch.Checked = true;
                //    }
                //    else
                //    {
                //        frm.uc_SearchItem1.ch_SaveSearch.Checked = false;
                //    }



                //    frm.ShowDialog();
                //    if (frm.clos_ == 1)
                //    {
                //        if (frm.uc_SearchItem1.dGV_pro_list.SelectedRows.Count > 0)
                //        {
                //            get_ItemData(_rowIndex, frm.uc_SearchItem1.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());

                //            if (frm.uc_SearchItem1.ch_SaveSearch.Checked)
                //            {
                //                txt_s1.Text = frm.uc_SearchItem1.txtSrch.Text;
                //                txt_s2.Text = frm.uc_SearchItem1.txtsrch_1.Text;
                //                txt_s3.Text = frm.uc_SearchItem1.txtserch_2.Text;
                //                txt_s4.Text = frm.uc_SearchItem1.txtSrch_3.Text;
                //                txt_s5.Text = frm.uc_SearchItem1.txtserch_4.Text;
                //                txtsearchChBox.Text = "1";
                //            }
                //            else
                //            {
                //                txt_s1.Clear();
                //                txt_s2.Clear();
                //                txt_s3.Clear();
                //                txt_s4.Clear();
                //                txt_s5.Clear();
                //                txtsearchChBox.Clear();
                //            }
                //        }
                //    }
            }

        }


        public void clculat_amount(int _rowIndex)
        {
            try
            {
            
                double qty_, cost_,_disc, _unitWeight,_old_balance, _main_Balance;

            if (dgv1.Rows[_rowIndex].Cells["_qty"].Value != null)
            {
                qty_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_qty"].Value);
            }
            else
            {
                qty_ = 0;
            }

            if (dgv1.Rows[_rowIndex].Cells["_cost"].Value != null)
            {
                cost_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_cost"].Value);
            }
            else
            {
                    cost_ = 0;
            }

           

                if (dgv1.Rows[_rowIndex].Cells["_weight"].Value != null)
                {
                    _unitWeight = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_weight"].Value);
                }
                else
                {
                    _unitWeight = 0;
                }

                if (dgv1.Rows[_rowIndex].Cells["_oldBalance"].Value != null)
                {
                    _old_balance = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_oldBalance"].Value);
                }
                else
                {
                    _old_balance = 0;
                }


                dgv1.Rows[_rowIndex].Cells["_total"].Value = (qty_ * cost_).ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_balance"].Value = (_old_balance - qty_).ToString("N0");
                if (checkBalance == true)
                {
                    if(dgv1.Rows[_rowIndex].Cells["_balance"].Value.ToString().ToDecimal()<0)
                    {
                        dgv1.Rows[_rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        dgv1.Rows[_rowIndex].DefaultCellStyle.BackColor = dgv1.RowsDefaultCellStyle.BackColor;
                    }
                }
                 dgv1.Rows[_rowIndex].Cells["_totalWeight"].Value =(_unitWeight*qty_).ToString().ToDecimal().ToString("N3");
               // if (_unitWeight > 0)
                //{
                //    dgv1.Rows[_rowIndex].Cells["_tonPrice"].Value = (pric_ / _unitWeight*1000).ToString("N0");
                //}

            }
            catch 
            {

                
            }

        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int i = dgv1.CurrentCell.RowIndex;
                int j = dgv1.CurrentCell.ColumnIndex;
                //-------------------------------------------------------------------//


                if (j == dgv1.Columns[_code.Name].Index)
                {

                    string _itemNo;
                    //=============================================================//
                    if (dgv1.Rows[i].Cells["_code"].Value == null)
                    {
                        _itemNo = "";
                    }
                    else
                    {
                        _itemNo = dgv1.Rows[i].Cells["_code"].Value.ToString();

                    }
                    get_ItemData(i, _itemNo);
                    SendKeys.Send("{up}");
                    dgv1.CurrentCell = dgv1[dgv1.Columns["_barcodeNo"].Index, i];


                    //}
                }

                else if (j == dgv1.Columns[_barcodeNo.Name].Index)
                {

                  
                        string _barcode;
                    //=============================================================//
                    if (dgv1.Rows[i].Cells["_barcodeNo"].Value == null)
                    {
                        _barcode = "";
                    }
                    else
                    {
                        _barcode = dgv1.Rows[i].Cells["_barcodeNo"].Value.ToString();

                    }
                    DataTable dt_coil = dal.getDataTabl_1(@"select item_no, Material_Id, (Weight - QTY_OUT) as coile_balance  from WH_FA_HEAT_NO_MASTER where( Material_Id ='" + _barcode + "'or( Heat_no ='" + _barcode + "' and Material_Id Like 'H%'))");
                    if (dt_coil.Rows.Count > 0)
                    {
                        dgv1.Rows[i].Cells[_barcodeNo.Name].Value = dt_coil.Rows[0]["Material_Id"].ToString();

                        get_ItemData_Barcode(i, dt_coil.Rows[0]["Material_Id"].ToString());

                        SendKeys.Send("{up}");
                        dgv1.CurrentCell = dgv1[dgv1.Columns["_qty"].Index, i];
                    }
                }

                else if (j == dgv1.Columns[_qty.Name].Index)
                {
                   
                        clculat_amount(i);
                        clculatTotalWeight(i);

                    if (isCellNotNullSrting(dgv1.Columns["_code"].Index, i) == true && isCellNotNull(dgv1.Columns["_qty"].Index, i) == true )
                    {
                        if (i < dgv1.Rows.Count - 1)
                        {
                            dgv1.CurrentCell = dgv1[dgv1.Columns["_code"].Index, i + 1];

                        }

                    }

                
                else
                {
                    SendKeys.Send("{up}");
                }
            }

              
                

                total_inv();
            }

            catch
            {
            }
        }

        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            var iCol = dgv1.CurrentCell.ColumnIndex;
            var iRow = dgv1.CurrentCell.RowIndex;
            if (e.KeyCode == Keys.Enter)
            {
                
                e.SuppressKeyPress = true;
              

                //DataGridViewCellEventArgs a = new DataGridViewCellEventArgs(iCol, iRow);
                //Dgv1_CellEndEdit(dgv1, a);


                if (iCol == dgv1.Columns[_code.Name].Index)

                {
                    string _itemNo;
                    if (dgv1.Rows[iRow].Cells["_code"].Value == null)
                    {
                        _itemNo = "";
                    }
                    else
                    {
                        _itemNo = dgv1.Rows[iRow].Cells["_code"].Value.ToString();
                    }
                    get_ItemData_2(iRow, _itemNo);

                    dgv1.CurrentCell = dgv1[dgv1.Columns[_barcodeNo.Name].Index, iRow];
                  
                }

                else if (iCol == dgv1.Columns[_barcodeNo.Name].Index)
                {
                    string _barcode;
                    if (dgv1.Rows[iRow].Cells["_barcodeNo"].Value == null)
                    {
                        _barcode = "";
                    }
                    else
                    {
                        _barcode = dgv1.Rows[iRow].Cells["_barcodeNo"].Value.ToString();
                    }


                    DataTable dt_coil =  dal.getDataTabl_1(@"select item_no, Material_Id, (Weight - QTY_OUT) as coile_balance  from WH_FA_HEAT_NO_MASTER where (Material_Id ='"+_barcode+ "' or( Heat_no ='"+_barcode+ "' and Material_Id Like 'H%'))");
                    if (dt_coil.Rows.Count > 0)
                    {
                        dgv1.Rows[iRow].Cells[_barcodeNo.Name].Value = dt_coil.Rows[0]["Material_Id"].ToString(); 
                     //   get_ItemData_2(iRow, dt_coil.Rows[0]["item_no"].ToString());
                        get_ItemData_Barcode(iRow, dt_coil.Rows[0]["Material_Id"].ToString());
                        dgv1.CurrentCell = dgv1[dgv1.Columns[_qty.Name].Index, iRow];
                    }

                }

                else if (iCol == dgv1.Columns[_qty.Name].Index && isCellNotNull(iCol, iRow) == true)
                {

                   

                    if (isCellNotNullSrting(0, iRow) == true && isCellNotNull(dgv1.Columns[_qty.Name].Index, iRow) == true)
                    {
                        if (iRow < dgv1.Rows.Count - 1)
                        {
                            dgv1.CurrentCell = dgv1[dgv1.Columns[_code.Name].Index, iRow + 1];
                        }
                    }
                    //else
                    //{
                    //    dgv1.CurrentCell = dgv1[7, iRow];
                    //}
                }


                



                total_inv();
            }
           else if (e.KeyCode == Keys.F5 && iCol == 7)
            {
                
                PL.list_H_price frm = new PL.list_H_price();
                frm.txtBranch.ID.Text = Properties.Settings.Default.BranchId;
                frm.txtItem.ID.Text = dgv1[0, iRow].Value.ToString();
                frm.txtItem.get_desc();
                frm.txtAcc.ID.Text = ClientCode;

                frm.ShowDialog();


            }

            else if (e.KeyCode == Keys.F6 && iCol == 7)
            {
               

                PL.list_H_price frm = new PL.list_H_price();
                frm.txtBranch.ID.Text = Properties.Settings.Default.BranchId;
                frm.txtItem.ID.Text = dgv1[0, iRow].Value.ToString();
                frm.txtItem.get_desc();
                frm.ShowDialog();
            }


            else
            {
                dgv1.CancelEdit();
            }
        }



        bool isCellNotNullSrting(int _col ,int _row )
        {
            if (dgv1[_col, _row].Value == null || dgv1[_col, _row].Value == DBNull.Value || String.IsNullOrEmpty(dgv1[_col, _row].Value.ToString()))
                {
                    return false;
                }
            else
            {
                    return true;
            }
        }




        bool isCellNotNull(int _col, int _row)
        {
            if (dgv1[_col, _row].Value != null)
            {
                if (dgv1[_col, _row].Value.ToString().ToDecimal() <= 0)
                {
                    return false;
                }
            }
            else if (dgv1[_col, _row].Value == null || dgv1[_col, _row].Value == DBNull.Value || String.IsNullOrEmpty(dgv1[_col, _row].Value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }

            return true;
        }

        private void cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            string senderText = (sender as TextBox).Text;
            string senderName = (sender as TextBox).Name;
            string[] splitByDecimal = senderText.Split('.');
            int cursorPosition = (sender as TextBox).SelectionStart;


            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (senderText.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar)
            && (senderText.IndexOf('.') < cursorPosition
             && splitByDecimal.Length > 1
            && splitByDecimal[1].Length == _dg))
            {
                e.Handled = true;
            }
        }

        //private void getDgvSer( DataGridView dv)
        //{
        //    foreach (DataGridViewRow dvRow in dv.Rows)
        //    {
        //        dvRow.HeaderCell.Value = (dvRow.Index + 1).ToString();

        //    }
        //}

        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv1.CurrentCell.ColumnIndex == 5 )
            {
                _dg = 2;
                e.Control.KeyPress += cell_KeyPress;

            }
            else if (dgv1.CurrentCell.ColumnIndex == 6)
            {
                _dg = 3;
                e.Control.KeyPress += cell_KeyPress;

            }
          else if (dgv1.CurrentCell.ColumnIndex == 7)
            {
                _dg = 4;
                e.Control.KeyPress += cell_KeyPress;

            }
            else if (dgv1.CurrentCell.ColumnIndex == 8)
            {
                _dg = 2;
                e.Control.KeyPress += cell_KeyPress;

            }
            else if (dgv1.CurrentCell.ColumnIndex == 9 || dgv1.CurrentCell.ColumnIndex == 10 || dgv1.CurrentCell.ColumnIndex == 11)
            {
                _dg = dal.digits_;
                e.Control.KeyPress += cell_KeyPress;

            }
            else
            {
                e.Control.KeyPress += default__KeyPress;
            }
           
        }

        private void default__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        
        public void clculatPeace()
        {
            double  totalWeight_, unitWeight_;
         
      

            if (dgv1.CurrentRow.Cells["_totalWeight"].Value != null)
            {
                totalWeight_ = Convert.ToDouble(dgv1.CurrentRow.Cells["_totalWeight"].Value);
            }
            else
            {
                totalWeight_ = 0;
            }

            if (dgv1.CurrentRow.Cells["_weight"].Value != null)
            {
                unitWeight_ = Convert.ToDouble(dgv1.CurrentRow.Cells["_weight"].Value);
            }
            else
            {
                unitWeight_ = 0;
            }
            if (unitWeight_ > 0)
            {
                dgv1.CurrentRow.Cells["_qty"].Value = (totalWeight_ / unitWeight_).ToString("N2");
            }
            else
            {
                dgv1.CurrentRow.Cells["_qty"].Value = "";
            }
        }

        public void clculatTotalWeight(int _rowIndex)
        {
            double qty_, unitWeight_;

            if (dgv1.Rows[_rowIndex].Cells["_qty"].Value != null)
            {
                qty_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_qty"].Value);
            }
            else
            {
                qty_ = 0;
            }
           
            if (dgv1.Rows[_rowIndex].Cells["_weight"].Value != null)
            {
                unitWeight_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_weight"].Value);
            }
            else
            {
                unitWeight_ = 0;
            }

            dgv1.Rows[_rowIndex].Cells["_totalWeight"].Value = (unitWeight_ * qty_).ToString("N3");

        }


      
       

        private void dgv1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dal.getDgvSer(dgv1);
            total_inv();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dal.getDgvSer(dgv1);
            total_inv();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgv1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    dgv1.Rows.RemoveAt(dgv1.SelectedRows[0].Index);
                }
            }
        }

        private void totalQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // Image someImage = Properties.Resources.search_16;
            if (e.ColumnIndex == (dgv1.Columns[_search.Name]).Index)
            {
                e.Value = "....";
            }

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var iCol = dgv1.CurrentCell.ColumnIndex;
            var iRow = dgv1.CurrentCell.RowIndex;
            if (iCol == dgv1.Columns[_search.Name].Index)
            {
                PL.frmSerachItem frm = new PL.frmSerachItem();

                frm.uc_SearchItem1.txtSrch.Text = txt_s1.Text;
                frm.uc_SearchItem1.txtsrch_1.Text = txt_s2.Text;
                frm.uc_SearchItem1.txtserch_2.Text = txt_s3.Text;
                frm.uc_SearchItem1.txtSrch_3.Text = txt_s4.Text;
                frm.uc_SearchItem1.txtserch_4.Text = txt_s5.Text;
                if (txtsearchChBox.Text == "1")
                {
                    frm.uc_SearchItem1.ch_SaveSearch.Checked = true;
                }
                else
                {
                    frm.uc_SearchItem1.ch_SaveSearch.Checked = false;
                }



                frm.ShowDialog();
                if (frm.clos_ == 1)
                {
                    if (frm.uc_SearchItem1.dGV_pro_list.SelectedRows.Count > 0)
                    {

                        get_ItemData(iRow, frm.uc_SearchItem1.dGV_pro_list.CurrentRow.Cells[0].Value.ToString());

                        dgv1.CurrentCell= dgv1[dgv1.Columns["_barcodeNo"].Index, iRow];
                        if (frm.uc_SearchItem1.ch_SaveSearch.Checked)
                        {
                            txt_s1.Text = frm.uc_SearchItem1.txtSrch.Text;
                            txt_s2.Text = frm.uc_SearchItem1.txtsrch_1.Text;
                            txt_s3.Text = frm.uc_SearchItem1.txtserch_2.Text;
                            txt_s4.Text = frm.uc_SearchItem1.txtSrch_3.Text;
                            txt_s5.Text = frm.uc_SearchItem1.txtserch_4.Text;
                            txtsearchChBox.Text = "1";
                        }
                        else
                        {
                            txt_s1.Clear();
                            txt_s2.Clear();
                            txt_s3.Clear();
                            txt_s4.Clear();
                            txt_s5.Clear();
                            txtsearchChBox.Clear();
                        }
                    }
                }
            }
        }

        private void txtKGCost_TextChanged(object sender, EventArgs e)
        {
            OnLoad(e);
        }
    }
    
}
