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
    public partial class InvGrid_Con : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        int _dg;
       public bool qtyOnly;
        public bool checkBalance;
        public string ClientCode;
        public string docType;
        public InvGrid_Con()
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
                if (r.Cells[_qty.Name].FormattedValue.ToString().ToDecimal() > r.Cells[_mainBalance.Name].FormattedValue.ToString().ToDecimal())
                {
                    return false;
                }
                else if (checkBalance ==true && r.Cells[_stockType.Name].FormattedValue.ToString() == "False" && r.Cells[_balance.Name].FormattedValue.ToString().ToDecimal() < 0)
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

        public void totalPrevew(int _Index)
        {
           
               dgv1.Rows[_Index].Cells[_oldBalance.Name].Value = (from DataGridViewRow row in dgv1.Rows
                                             where row.Cells["_qty"].FormattedValue.ToString() != string.Empty && row.Index<=_Index&& row.Cells["_code"].FormattedValue.ToString() == dgv1.Rows[_Index].Cells["_code"].FormattedValue.ToString()
                                                  select (row.Cells["_qty"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");

            
        }
        public void total_inv()
        {
            foreach(DataGridViewRow r in dgv1.Rows)
            {
                if (r.Cells["_documentNo"].FormattedValue.ToString() == string.Empty)
                {
                    r.ReadOnly = false;
                }
                else
                {
                    r.ReadOnly = true;
                }
            }
            
            totalQty.Text =
            (from DataGridViewRow row in dgv1.Rows
            where row.Cells["_qty"].FormattedValue.ToString() != string.Empty
            select (row.Cells["_qty"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");

            txt_SubTot.Text =
                  (from DataGridViewRow row in dgv1.Rows
                   where row.Cells["_total"].FormattedValue.ToString() != string.Empty
                   select (row.Cells["_total"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N"+ dal.digits_);


             txt_TotDisc.Text =
            (from DataGridViewRow row in dgv1.Rows
             where row.Cells["_discount"].FormattedValue.ToString() != string.Empty
             select (row.Cells["_discount"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);

            txtNetTotal.Text =
            (from DataGridViewRow row in dgv1.Rows
             where row.Cells["_netValue"].FormattedValue.ToString() != string.Empty
             select (row.Cells["_netValue"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);

             totalWeight.Text =
            (from DataGridViewRow row in dgv1.Rows
             where row.Cells["_totalWeight"].FormattedValue.ToString() != string.Empty
             select (row.Cells["_totalWeight"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);

             txtTotalVAT.Text =
            (from DataGridViewRow row in dgv1.Rows
             where row.Cells["_vat"].FormattedValue.ToString() != string.Empty
             select (row.Cells["_Vat"].FormattedValue).ToString().ToDecimal()).Sum().ToString("N" + dal.digits_);

             txtNetValue.Text = (txtNetTotal.Text.ToDecimal() + txtTotalVAT.Text.ToDecimal()).ToString("n" + dal.digits_);

            txtTotalCost.Text =
           (from DataGridViewRow row in dgv1.Rows
            where row.Cells["_cost"].FormattedValue.ToString() != string.Empty
            select ((row.Cells["_cost"].FormattedValue).ToString().ToDecimal() * (row.Cells["_qty"].FormattedValue).ToString().ToDecimal())).Sum().ToString("N" + dal.digits_);



            txt_downPayment.Text = (txtNetTotal.Text.ToDecimal() * txt_downPayment_Ratio.Text.ToDecimal()/100).ToString("n" + dal.digits_);
            txt_downPaymentVAT.Text = (txtTotalVAT.Text.ToDecimal()* txt_downPayment_Ratio.Text.ToDecimal()/100).ToString("n" + dal.digits_);

            txtNetVat.Text = (txtTotalVAT.Text.ToDecimal() - txt_downPaymentVAT.Text.ToDecimal()).ToString("n" + dal.digits_);
            txtNetDueBeforVAT.Text = (txtNetTotal.Text.ToDecimal() - txt_downPayment.Text.ToDecimal()).ToString("n" + dal.digits_);
            txtNetValue.Text = (txtNetDueBeforVAT.Text.ToDecimal() + txtNetVat.Text.ToDecimal()).ToString("n" + dal.digits_);


        }

        //private void Inv_Grid_Click(object sender, EventArgs e)
        //{
        //    txtAccVat_Rate.Text = "1";

        //}

        private void get_ItemData(int _rowIndex,string item_No)
        {

            DataTable dt = dal.getDataTabl_1(@"SELECT A.item_no,factory_no,A.descr,isnull(NULLIF(Descr_eng,''),A.descr) as Descr_eng ,Weight,unit,A.local_cost,A.NonStockItem
            ,sum(V.QTY_Balance) as BALANCE  
            , (select top 1 vat_ratio from VAT_RATIO_MASTER where  date_of_vat <= '" + invVAtDate.Value.ToString("yyyy-MM-dd") + "'  order by date_of_vat desc) as VatRatio " +
            ",K.KM_Code " +
           " FROM wh_main_master as A  " +
            " inner join wh_Groups As B on A.group_code = B.group_code  " +
            " left join KM_MATERIAL_CODE As K on  ISNULL(NULLIF(a.KM_CODE, ''), 1) = K.KM_CODE " +
            " inner join VIEW_balance as V on A.item_no = V.item_no "+
             " where  A.item_no = '" + item_No + "' or (factory_no = '" + item_No + "' and factory_no<>'') " +
             "group by A.item_no,factory_no,A.descr,Descr_eng,Weight,unit,A.local_cost,A.NonStockItem,K.KM_Code ");
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
                dgv1.Rows[_rowIndex].Cells["_vatRatio"].Value = dt.Rows[0]["VatRatio"].ToString().ToDecimal().ToString("N0");
                dgv1.Rows[_rowIndex].Cells["_KmCode"].Value = dt.Rows[0]["KM_Code"].ToString();
                dgv1.Rows[_rowIndex].Cells["_balance"].Value = dt.Rows[0]["BALANCE"].ToString();
                dgv1.Rows[_rowIndex].Cells["_oldBalance"].Value = dt.Rows[0]["BALANCE"].ToString();
                dgv1.Rows[_rowIndex].Cells["_oldCost"].Value = (dt.Rows[0]["local_cost"].ToString().ToDecimal()).ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_stockType"].Value = dt.Rows[0]["NonStockItem"].ToString();

                //dgv1.Rows[_rowIndex].Cells["_qty"].Value         = 0;
                //dgv1.Rows[_rowIndex].Cells["_totalWeight"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_price"].Value       = 0;
                //dgv1.Rows[_rowIndex].Cells["_tonPrice"].Value    = 0;
                //dgv1.Rows[_rowIndex].Cells["_total"].Value       = 0;
                //dgv1.Rows[_rowIndex].Cells["_discount"].Value   = 0;
                //dgv1.Rows[_rowIndex].Cells["_netValue"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_vat"].Value = 0;

                //txtNote.Focus();
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


        private void get_ItemData_2(int _rowIndex, string item_No)
        {

            DataTable dt = dal.getDataTabl_1(@"SELECT A.item_no,factory_no,A.descr,isnull(NULLIF(Descr_eng,''),A.descr) as Descr_eng ,Weight,unit,A.local_cost,A.NonStockItem
            ,sum(V.QTY_Balance) as BALANCE 
            , (select top 1 vat_ratio from VAT_RATIO_MASTER where  date_of_vat <= '" + invVAtDate.Value.ToString("yyyy-MM-dd") + "'  order by date_of_vat desc) as VatRatio " +
            ",K.KM_Code " +
           " FROM wh_main_master as A  " +
            " inner join wh_Groups As B on A.group_code = B.group_code  " +
            " left join KM_MATERIAL_CODE As K on  ISNULL(NULLIF(a.KM_CODE, ''), 1) = K.KM_CODE " +
            " inner join VIEW_balance as V on A.item_no = V.item_no "+
             " where A.item_no = '" + item_No + "' or (factory_no = '" + item_No + "' and factory_no<>'')" +
             "group by A.item_no,factory_no,A.descr,Descr_eng,Weight,unit,A.local_cost,A.NonStockItem,K.KM_Code");
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
                dgv1.Rows[_rowIndex].Cells["_balance"].Value = dt.Rows[0]["BALANCE"].ToString().ToDecimal().ToString("N0");
                dgv1.Rows[_rowIndex].Cells["_cost"].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_vatRatio"].Value = dt.Rows[0]["VatRatio"].ToString().ToDecimal().ToString("N0");
                dgv1.Rows[_rowIndex].Cells["_KmCode"].Value = dt.Rows[0]["KM_Code"].ToString();
                dgv1.Rows[_rowIndex].Cells["_oldBalance"].Value = dt.Rows[0]["BALANCE"].ToString().ToDecimal().ToString("N0");
                dgv1.Rows[_rowIndex].Cells["_oldCost"].Value = dt.Rows[0]["local_cost"].ToString().ToDecimal().ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_stockType"].Value = dt.Rows[0]["NonStockItem"].ToString();

                clculat_amount(_rowIndex);
                //dgv1.Rows[_rowIndex].Cells["_qty"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_totalWeight"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_price"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_tonPrice"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_total"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_discount"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_netValue"].Value = 0;
                //dgv1.Rows[_rowIndex].Cells["_vat"].Value = 0;

                //txtNote.Focus();


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


        public void clculat_amount(int _rowIndex)
        {
            try
            {

                double qty_, pric_, _disc, _unitWeight, _old_balance, _main_Balance, _old_cost;

            if (dgv1.Rows[_rowIndex].Cells["_qty"].Value != null)
            {
                qty_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_qty"].Value);
            }
            else
            {
                qty_ = 0;
            }

            if (dgv1.Rows[_rowIndex].Cells["_price"].Value != null)
            {
                pric_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_price"].Value);
            }
            else
            {
                pric_ = 0;
            }

            if (dgv1.Rows[_rowIndex].Cells["_discount"].Value != null)
            {
                _disc = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_discount"].Value);
            }
            else
            {
                _disc = 0;
            }

                if (dgv1.Rows[_rowIndex].Cells["_weight"].Value != null)
                {
                    _unitWeight = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_weight"].Value);
                }
                else
                {
                    _unitWeight = 0;
                }
               // totalPrevew(_rowIndex);

                if (dgv1.Rows[_rowIndex].Cells["_oldBalance"].Value != null)
                {
                    _old_balance = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_oldBalance"].Value);
                }
                else
                {
                    _old_balance = 0;
                }

                if (dgv1.Rows[_rowIndex].Cells["_oldCost"].Value != null)
                {
                    _old_cost = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_oldCost"].Value);
                }
                else
                {
                    _old_cost = 0;
                }


                if (dgv1.Rows[_rowIndex].Cells["_mainBalance"].Value != null)
                {
                    _main_Balance = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_mainBalance"].Value);
                }
                else
                {
                    _main_Balance = 0;
                }


                dgv1.Rows[_rowIndex].Cells["_total"].Value = (qty_ * pric_).ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_netValue"].Value = (Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_total"].Value) - _disc).ToString("N3");
                dgv1.Rows[_rowIndex].Cells["_vat"].Value = ((dgv1.Rows[_rowIndex].Cells["_vatRatio"].Value.ToString().ToDecimal() <= txtAccVat_Rate.Text.ToDecimal() ? dgv1.Rows[_rowIndex].Cells["_vatRatio"].Value.ToString().ToDecimal() : txtAccVat_Rate.Text.ToDecimal()) * (dgv1.Rows[_rowIndex].Cells["_netValue"].Value.ToString().ToDecimal()) / 100).ToString("N3");
                if(docType == "IN")
                {
                    double itemTotalQty = (from DataGridViewRow row in dgv1.Rows
                                                                       where row.Cells["_qty"].FormattedValue.ToString() != string.Empty && row.Index <= _rowIndex && row.Cells["_code"].FormattedValue.ToString() == dgv1.Rows[_rowIndex].Cells["_code"].FormattedValue.ToString()
                                                                       select Convert.ToDouble(row.Cells["_qty"].FormattedValue)).Sum();

                    double itemTotalAmount = (from DataGridViewRow row in dgv1.Rows
                                           where row.Cells["_netValue"].FormattedValue.ToString() != string.Empty && row.Index <= _rowIndex && row.Cells["_code"].FormattedValue.ToString() == dgv1.Rows[_rowIndex].Cells["_code"].FormattedValue.ToString()
                                           select Convert.ToDouble(row.Cells["_netValue"].FormattedValue)).Sum();



                    dgv1.Rows[_rowIndex].Cells["_balance"].Value = dgv1.Rows[_rowIndex].Cells[_stockType.Name].Value.ToString()=="0"?(_old_balance + itemTotalQty).ToString("N0"):"0";




                    dgv1.Rows[_rowIndex].Cells["_cost"].Value = Math.Round(((_old_balance * _old_cost) + itemTotalAmount) / (_old_balance + itemTotalQty),4) ;
                }
                else
                {
                dgv1.Rows[_rowIndex].Cells["_balance"].Value = dgv1.Rows[_rowIndex].Cells[_stockType.Name].Value.ToString() == "False" ? (_old_balance - qty_).ToString("N0"):"0";
                }

                if (checkBalance == true)
                {
                    if(dgv1.Rows[_rowIndex].Cells[_stockType.Name].Value.ToString()== "False" && (dgv1.Rows[_rowIndex].Cells["_balance"].Value.ToString().ToDecimal()<0|| _main_Balance < 0))
                    {
                        dgv1.Rows[_rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        dgv1.Rows[_rowIndex].DefaultCellStyle.BackColor = dgv1.RowsDefaultCellStyle.BackColor;
                    }
                }
                // dgv1.Rows[_rowIndex].Cells["_totalWeight"].Value =(_unitWeight*qty_).ToString().ToDecimal().ToString("N3");
                //if (_unitWeight > 0)
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


                if (j == 0)
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
                    dgv1.CurrentCell = dgv1[2, i];


                    //}
                }

                else if (j == 2)
                {
                    SendKeys.Send("{up}");
                    dgv1.CurrentCell = dgv1[5, i];
                }

                else if (j == 5)
                {
                    if (isCellNotNull(j, i) == true && qtyOnly != true)
                    {
                        clculat_amount(i);
                        clculatTotalWeight(i);
                        SendKeys.Send("{up}");
                        dgv1.CurrentCell = dgv1[7, i];
                    }
                    else if ( qtyOnly == true)
                    {
                        clculat_amount(i);
                        clculatTotalWeight(i);
                       
                    }
                            else
                    {
                        SendKeys.Send("{up}");
                    }
                }

                else if (j == 6)
                {
                    clculatPeace();
                    clculat_amount(i);
                    SendKeys.Send("{up}");
                    dgv1.CurrentCell = dgv1[7, i];
                }

                else if (j == 7)
                {
                 

                    if (isCellNotNull(j, i) == true)
                    {
                        clculatTonPrice(i);
                        clculat_amount(i);
                        SendKeys.Send("{up}");
                        dgv1.CurrentCell = dgv1[10, i];
                    }
                    else
                    {
                        SendKeys.Send("{up}");
                    }
                }

                else if (j == 8)
                {
                    clculatPeacePrice();
                    clculat_amount(i);
                    SendKeys.Send("{up}");
                    dgv1.CurrentCell = dgv1[10, i];
                }

                else if (j == 10)
                {
                    clculat_amount(i);
                    if (isCellNotNullSrting(0, i) == true && isCellNotNull(5, i) == true && isCellNotNull(7, i) == true)
                    {
                        if (i < dgv1.Rows.Count - 1)
                        {
                            dgv1.CurrentCell = dgv1[0, i + 1];

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


                if (iCol == 0)

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

                    dgv1.CurrentCell = dgv1[2, iRow];
                  
                }

                else if (iCol == 2)
                {
                    dgv1.CurrentCell = dgv1[5, iRow];
                }

                else if (iCol == 5 && isCellNotNull(iCol, iRow) == true)
                {

                   

                    if (isCellNotNullSrting(0, iRow) == true && isCellNotNull(5, iRow) == true && qtyOnly == true)
                    {
                        if (iRow < dgv1.Rows.Count - 1)
                        {
                            dgv1.CurrentCell = dgv1[0, iRow + 1];
                        }
                    }
                    else
                    {
                        dgv1.CurrentCell = dgv1[7, iRow];
                    }
                }


                else if (iCol == 6)
                {

                    dgv1.CurrentCell = dgv1[7, iRow];
                }


                else if (iCol == 7 && isCellNotNull(iCol, iRow) == true)
                {
                    dgv1.CurrentCell = dgv1[10, iRow];
                }
                   
                else if (iCol == 8)
                {
                    dgv1.CurrentCell = dgv1[10, iRow];
                }

                else if (iCol == 10 )
                {
                    if (isCellNotNullSrting(0, iRow) == true && isCellNotNull(5, iRow) == true && isCellNotNull(7, iRow) == true)
                    {
                        if (iRow < dgv1.Rows.Count - 1)
                        {
                            dgv1.CurrentCell = dgv1[0, iRow + 1];
                        }
                    }
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
            //if (e.KeyChar == (char)Keys.F5)
            //{
            //    PL.list_H_price frm = new PL.list_H_price();
            //    frm.txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            //    frm.txtItem.ID.Text = dgv1[0, iRow].Value.ToString();
            //    frm.txtItem.get_desc();
            //    frm.txtAcc.ID.Text = ClientCode;

            //    frm.ShowDialog();

            //}
            //else if (e.KeyChar == (char)Keys.F6)
            //{
            //    PL.list_H_price frm = new PL.list_H_price();
            //    frm.txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            //    frm.txtItem.ID.Text = dgv1[0, iRow].Value.ToString();
            //    frm.txtItem.get_desc();
               

            //    frm.ShowDialog();

            //}


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


        public void clculatTonPrice(int _rowIndex)
        {
            double   unitWeight_, pric_;


            if (dgv1.Rows[_rowIndex].Cells["_price"].Value != null)
            {
                pric_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_price"].Value);
            }
            else
            {
                pric_ = 0;
            }

            if (dgv1.Rows[_rowIndex].Cells["_weight"].Value != null)
            {
                unitWeight_ = Convert.ToDouble(dgv1.Rows[_rowIndex].Cells["_weight"].Value);
            }
            else
            {
                unitWeight_ = 0;
            }
            if (unitWeight_ > 0)
            {
                dgv1.Rows[_rowIndex].Cells["_tonPrice"].Value = (pric_ / unitWeight_ * 1000).ToString("N0");
            }
            else
            {
                dgv1.Rows[_rowIndex].Cells["_tonPrice"].Value = "0";
            }
        }

        public void clculatPeacePrice()
        {
            double tonPrice_, unitWeight_;

            if (dgv1.CurrentRow.Cells["_tonPrice"].Value != null)
            {
                tonPrice_ = Convert.ToDouble(dgv1.CurrentRow.Cells["_tonPrice"].Value);
            }
            else
            {
                tonPrice_ = 0;
            }

         
            if (dgv1.CurrentRow.Cells["_weight"].Value != null)
            {
                unitWeight_ = Convert.ToDouble(dgv1.CurrentRow.Cells["_weight"].Value);
            }
            else
            {
                unitWeight_ = 0;
            }
               dgv1.CurrentRow.Cells["_price"].Value = (tonPrice_ * unitWeight_ / 1000).ToString("N"+dal.digits_);
           
        }

        private void chVisibalVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chVisibalVat.Checked == true)
            {
                dgv1.Columns["_vat"].Visible = false;
                dgv1.Columns["_vatRatio"].Visible = false;
            }
            else
            {
                dgv1.Columns["_vat"].Visible = true;
                dgv1.Columns["_vatRatio"].Visible = true;
            }
        }

       

        private void dgv1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dal.getDgvSer(dgv1);
            
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dal.getDgvSer(dgv1);
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

        private void dgv1_Paint(object sender, PaintEventArgs e)
        {
           

            if (qtyOnly == true)
            {

                dgv1.AllowUserToAddRows = false;
                dgv1.AllowUserToDeleteRows = false;
                
                dgv1.Columns[_price.Name].DefaultCellStyle.BackColor = Color.Gray;
                dgv1.Columns[_tonPrice.Name].DefaultCellStyle.BackColor = Color.Gray;
                dgv1.Columns[_total.Name].DefaultCellStyle.BackColor = Color.Gray;
                dgv1.Columns[_netValue.Name].DefaultCellStyle.BackColor = Color.Gray;
                dgv1.Columns[_discount.Name].DefaultCellStyle.BackColor = Color.Gray;
                dgv1.Columns[_cost.Name].DefaultCellStyle.BackColor = Color.Gray;
               // dgv1.Columns["_balance"].DefaultCellStyle.BackColor = Color.Gray;


                dgv1.Columns[_price.Name].DefaultCellStyle.ForeColor = Color.Gray;
                dgv1.Columns[_tonPrice.Name].DefaultCellStyle.ForeColor = Color.Gray;
                dgv1.Columns[_total.Name].DefaultCellStyle.ForeColor = Color.Gray;
                dgv1.Columns[_netValue.Name].DefaultCellStyle.ForeColor = Color.Gray;
                dgv1.Columns[_cost.Name].DefaultCellStyle.ForeColor = Color.Gray;
                dgv1.Columns[_discount.Name].DefaultCellStyle.ForeColor = Color.Gray;
               // dgv1.Columns["_balance"].DefaultCellStyle.ForeColor = Color.Gray;

                dgv1.Columns[_code.Name].ReadOnly = true;
                dgv1.Columns[_addDescription.Name].ReadOnly = true;
                dgv1.Columns[_price.Name].ReadOnly = true;
                dgv1.Columns[_tonPrice.Name].ReadOnly = true;
                dgv1.Columns[_total.Name].ReadOnly = true;
                dgv1.Columns[_netValue.Name].ReadOnly = true;
                dgv1.Columns[_discount.Name].ReadOnly = true;
                dgv1.Columns[_cost.Name].ReadOnly = true;
                dgv1.Columns[_balance.Name].ReadOnly = true;
                dgv1.Columns[_totalWeight.Name].ReadOnly = true;
                dgv1.Columns[_mainBalance.Name].ReadOnly = true;

                dgv1.Columns[_price.Name]   .Visible = false;
                dgv1.Columns[_tonPrice.Name].Visible = false;
                dgv1.Columns[_total.Name].Visible = false;
                dgv1.Columns[_netValue.Name].Visible = false;
                dgv1.Columns[_discount.Name].Visible = false;
                dgv1.Columns[_cost.Name].Visible = false;
                dgv1.Columns[_mainBalance.Name].Visible = true;
                groupTotal.Visible = false;
                chVisibalVat.Visible = false;
                // dgv1.Columns["_balance"].Visible = false;

            }

        }

        private void dgv1_Leave(object sender, EventArgs e)
        {

        }

        private void txt_s1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void paied_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void balance_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
