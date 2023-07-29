using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;

namespace Report_Pro.MyControls
{
    public partial class UcJor : UserControl
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public UcJor()
        {
            InitializeComponent();
            dGV_Item.Rows.Add(10);
            resizeDG();
        }


        private void GetCat(int _row)
        {
            DataTable dt_CatAcc = dal.getDataTabl_1("SELECT isnull(nullif(CAT_CODE,''),'1') as CAT_CODE  FROM payer2 where ACC_NO = '" + dGV_Item.Rows[_row].Cells[_AccNo.Name].Value.ToString() + "' and BRANCH_code = '"+Properties.Settings.Default.BranchAccID+"'");
            DataTable dt_ = dal.getDataTabl_1("SELECT CAT_NAME,CAT_NAME_E  FROM CATEGORY where CAT_CODE = '" + dGV_Item.Rows[_row].Cells[_CatCode.Name].Value.ToString() + "' and CAT_CODE like '"+dt_CatAcc.Rows[0]["CAT_CODE"].ToString()+"%'");
            if (dt_.Rows.Count > 0)
            {
               
                //dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[_row].Cells[_VatSupp.Name].ColumnIndex, _row];
                if (Properties.Settings.Default.lungh == "0")
                {
                dGV_Item.Rows[_row].Cells[_CatName.Name].Value = dt_.Rows[0]["CAT_NAME"].ToString();
                }
                else
                {
                    dGV_Item.Rows[_row].Cells[_CatName.Name].Value = dt_.Rows[0]["CAT_NAME_E"].ToString();
                }
            }
            else
            {
                dGV_Item.Rows[_row].Cells[_CatCode.Name].Value = "1";
                DataTable dt_CatG = dal.getDataTabl_1("SELECT CAT_NAME,CAT_NAME_E  FROM CATEGORY where CAT_CODE = '" + dGV_Item.Rows[_row].Cells[_CatCode.Name].Value.ToString() + "'");
                if (dt_.Rows.Count > 0)
                {

                    //dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[_row].Cells[_VatSupp.Name].ColumnIndex, _row];
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        dGV_Item.Rows[_row].Cells[_CatName.Name].Value = dt_.Rows[0]["CAT_NAME"].ToString();
                    }
                    else
                    {
                        dGV_Item.Rows[_row].Cells[_CatName.Name].Value = dt_.Rows[0]["CAT_NAME_E"].ToString();
                    }
                }


            }

        }

        private void GetCost(int _row)
        {
            DataTable dt_ = dal.getDataTabl_1("select Cost_name,COST_E_NAME  FROM COST_CENTER where COST_CODE = '" + dGV_Item.Rows[_row].Cells[_CostNo.Name].Value.ToString() + "'");
            if (dt_.Rows.Count > 0)
            {
              //  SendKeys.Send("{up}");
                dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[_row].Cells[_CatCode.Name].ColumnIndex, _row];
                if (Properties.Settings.Default.lungh == "0")
                {
                dGV_Item.Rows[_row].Cells[_CostName.Name].Value = dt_.Rows[0]["Cost_name"].ToString();
                }
                else
                {
                    dGV_Item.Rows[_row].Cells[_CostName.Name].Value = dt_.Rows[0]["COST_E_NAME"].ToString();

                }
            }
        }


        private void dGV_Item_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = dGV_Item.CurrentCell.RowIndex;
                int j = dGV_Item.CurrentCell.ColumnIndex;
                //-------------------------------------------------------------------//
                if (j == dGV_Item.Rows[i].Cells[_AccNo.Name].ColumnIndex)
                {
                    //=============================================================//
                    if (dGV_Item.Rows[i].Cells[_AccNo.Name].Value != null)
                    {
                        DataTable dt = new DataTable();
                        dt = dal.getDataTabl_1(@"select ACC_NO ,PAYER_NAME,payer_l_name
                        FROM payer2
                        where BRANCH_code like '" + Properties.Settings.Default.BranchAccID + "%' and ACC_NO = '" +
                        dGV_Item.Rows[i].Cells[_AccNo.Name].Value.ToString() + "' and(ACC_NO like'%' or ACC_NO like'%') and t_final = 1");
                        if (dt.Rows.Count > 0)
                        {
                            SendKeys.Send("{up}");
                            dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[i].Cells[_Desc.Name].ColumnIndex, i];
                            if (Properties.Settings.Default.lungh == "0")
                            {
                                dGV_Item.Rows[i].Cells[_AccName.Name].Value = dt.Rows[0]["PAYER_NAME"].ToString();
                            }
                            else
                            {
                                dGV_Item.Rows[i].Cells[_AccName.Name].Value = dt.Rows[0]["payer_l_name"].ToString();
                            }

                        }
                        else

                        {
                            dGV_Item.Rows[i].Cells[_AccNo.Name].Value = null;
                            dGV_Item.Rows[i].Cells[_AccName.Name].Value = null;

                            PL.frm_SearchAcc F = new PL.frm_SearchAcc();
                            F.txtbranchCode.Text = Properties.Settings.Default.BranchAccID;
                            F.radioTransaction.Checked = true;
                            
                            F.ShowDialog();
                            SendKeys.Send("{up}");

                            if (F.clos_ == 1)
                            {
                            int ii = F.DGV1.CurrentCell.RowIndex;
                            dGV_Item.Rows[i].Cells[_AccNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                            dGV_Item.Rows[i].Cells[_AccName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                            }


                            //dGV_Item.Rows[i].Cells[9].Value = F.DGV1.Rows[ii].Cells[5].Value;
                            //dGV_Item.Rows[i].Cells[10].Value = F.DGV1.Rows[ii].Cells[6].Value;
                            //dGV_Item.Rows[i].Cells[11].Value = F.DGV1.Rows[ii].Cells[7].Value;
                            //dGV_Item.Rows[i].Cells[12].Value = F.DGV1.Rows[ii].Cells[8].Value;
                        }
                    }
                    else
                    {
                        dGV_Item.Rows[i].Cells[_AccNo.Name].Value = null;
                        dGV_Item.Rows[i].Cells[_AccName.Name].Value = null;
                        PL.frm_SearchAcc F = new PL.frm_SearchAcc();
                        F.txtbranchCode.Text = Properties.Settings.Default.BranchAccID;
                        F.ShowDialog();
                        SendKeys.Send("{up}");
                        if (F.clos_ == 1)
                        {
                        int ii = F.DGV1.CurrentCell.RowIndex;
                        dGV_Item.Rows[i].Cells[_AccNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                        dGV_Item.Rows[i].Cells[_AccName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                        }


                        //dGV_Item.Rows[i].Cells[9].Value = F.DGV1.Rows[ii].Cells[5].Value;
                        //dGV_Item.Rows[i].Cells[10].Value = F.DGV1.Rows[ii].Cells[6].Value;
                        //dGV_Item.Rows[i].Cells[11].Value = F.DGV1.Rows[ii].Cells[7].Value;
                        //dGV_Item.Rows[i].Cells[12].Value = F.DGV1.Rows[ii].Cells[8].Value;




                    }


                }

                else if (j == dGV_Item.Rows[i].Cells[_CostNo.Name].ColumnIndex)
                {
                    GetCost(i);
                    SendKeys.Send("{up}");
                    //DataTable dt_ = dal.getDataTabl_1("select Cost_name  FROM COST_CENTER where COST_CODE = '" + dGV_Item.Rows[i].Cells[_CostNo.Name].Value.ToString() + "'");
                    //if (dt_.Rows.Count > 0)
                    //{
                    //    SendKeys.Send("{up}");
                    //    dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[i].Cells[_CatCode.Name].ColumnIndex, i];
                    //    dGV_Item.Rows[i].Cells[_CostName.Name].Value = dt_.Rows[0]["Cost_name"].ToString();
                    //}


                    ////else
                    ////{
                    ////    dGV_Item.Rows[i].Cells[_CostNo.Name].Value = null;
                    ////    dGV_Item.Rows[i].Cells[_CostName.Name].Value = null;

                    ////    PL.frm_serch_cost F = new PL.frm_serch_cost();
                    ////    F.ShowDialog();
                    ////    SendKeys.Send("{up}");

                    ////    int ii = F.DGV1.CurrentCell.RowIndex;


                    ////    dGV_Item.Rows[i].Cells[_CostNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                    ////    dGV_Item.Rows[i].Cells[_CostName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                    ////}


                }


                else if (j == dGV_Item.Rows[i].Cells[_CatCode.Name].ColumnIndex)
                {

                    GetCat(i);
                    SendKeys.Send("{up}");
                    //DataTable dt_ = dal.getDataTabl_1("SELECT CAT_NAME  FROM CATEGORY where CAT_CODE = '" + dGV_Item.Rows[i].Cells[_CatCode.Name].Value.ToString() + "'");
                    //if (dt_.Rows.Count > 0)
                    //{
                    //    SendKeys.Send("{up}");
                    //    dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[i].Cells[_VatSupp.Name].ColumnIndex, i];
                    //    dGV_Item.Rows[i].Cells[_CatName.Name].Value = dt_.Rows[0]["CAT_NAME"].ToString();
                    //}
                    ////else
                    ////{

                    ////    dGV_Item.Rows[i].Cells[_CatCode.Name].Value = null;
                    ////    dGV_Item.Rows[i].Cells[_CatName.Name].Value = null;

                    ////    PL.frm_search_Cat F = new PL.frm_search_Cat();
                    ////    F.ShowDialog();
                    ////    SendKeys.Send("{up}");

                    ////    int ii = F.DGV1.CurrentCell.RowIndex;


                    ////    dGV_Item.Rows[i].Cells[_CatCode.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                    ////    dGV_Item.Rows[i].Cells[_CatName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                    ////}


                }



                else
                {
                    var iCol = dGV_Item.CurrentCell.ColumnIndex;
                    var iRow = dGV_Item.CurrentCell.RowIndex;
                    if (iCol == dGV_Item.Columns.Count - 1)
                    {
                        if (iRow < dGV_Item.Rows.Count - 1)
                        {
                            dGV_Item.CurrentCell = dGV_Item[0, iRow + 1];

                        }
                        resizeDG();
                    }
                    else
                    {
                        if (iRow < dGV_Item.Rows.Count - 1)
                        {
                            SendKeys.Send("{up}");
                        }

                        dGV_Item.CurrentCell = dGV_Item[iCol + 1, iRow];
                    }
                }


                total_inv();
            }
            catch
            {
            }
        }


        public void clearDGV()
        {

            dGV_Item.Rows.Clear();
            dGV_Item.Rows.Add(10);
            foreach (DataGridViewRow row in dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                dGV_Item.EnableHeadersVisualStyles = false;
            }
            txtTotal.Clear();
        }




        public void total_inv()
        {
            txtTotal.Text =
                (from DataGridViewRow row in dGV_Item.Rows
                 where row.Cells[0].FormattedValue.ToString() != string.Empty
                 select (row.Cells[0].FormattedValue).ToString().ToDecimal()).Sum().ToString();
           
        }

        private void dGV_Item_KeyDown(object sender, KeyEventArgs e)
        {

            var iCol = dGV_Item.CurrentCell.ColumnIndex;
            var iRow = dGV_Item.CurrentCell.RowIndex;

            if ((e.KeyCode == Keys.F3))
            {
                int m = dGV_Item.CurrentRow.Index;

                dGV_Item.Rows.Insert(m + 1, 1);
                dGV_Item.Rows[m + 1].Cells[_Amount.Name].Value = dGV_Item.Rows[m].Cells[_Amount.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_AccNo.Name].Value = dGV_Item.Rows[m].Cells[_AccNo.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_AccName.Name].Value = dGV_Item.Rows[m].Cells[_AccName.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_Desc.Name].Value = dGV_Item.Rows[m].Cells[_Desc.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_CostNo.Name].Value = dGV_Item.Rows[m].Cells[_CostNo.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_CostName.Name].Value = dGV_Item.Rows[m].Cells[_CostName.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_CatCode.Name].Value = dGV_Item.Rows[m].Cells[_CatCode.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_CatName.Name].Value = dGV_Item.Rows[m].Cells[_CatName.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_VatSupp.Name].Value = dGV_Item.Rows[m].Cells[_VatSupp.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_InvAmount.Name].Value = dGV_Item.Rows[m].Cells[_InvAmount.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_invNo.Name].Value = dGV_Item.Rows[m].Cells[_invNo.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_InvDate.Name].Value = dGV_Item.Rows[m].Cells[_InvDate.Name].Value;
                dGV_Item.Rows[m + 1].Cells[_VatID.Name].Value = dGV_Item.Rows[m].Cells[_VatID.Name].Value;
                foreach (DataGridViewRow row in this.dGV_Item.Rows)
                {
                    row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                    dGV_Item.EnableHeadersVisualStyles = false;


                }
            }


            else if (e.KeyCode == Keys.F2 && dGV_Item.CurrentCell.ColumnIndex == 3)
            {
                int m = dGV_Item.CurrentRow.Index;

                dGV_Item.Rows[m].Cells[_Desc.Name].Value = dGV_Item.Rows[m - 1].Cells[_Desc.Name].Value;
            }

            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                
                if (iCol == dGV_Item.Columns.Count - 1)
                {
                    if (iRow < dGV_Item.Rows.Count - 1)
                    {
                        dGV_Item.CurrentCell = dGV_Item[0, iRow + 1];

                    }

                    resizeDG();
                }
                else
                {
                    if (iCol == dGV_Item.Rows[iRow].Cells[_AccNo.Name].ColumnIndex)

                    {
                        if (dGV_Item.Rows[iRow].Cells[_AccNo.Name].Value != null)
                        {
                            dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[iRow].Cells[_Desc.Name].ColumnIndex, iRow];

                        }
                        else
                        {
                            dGV_Item.Rows[iRow].Cells[_AccNo.Name].Value = null;
                            dGV_Item.Rows[iRow].Cells[_AccName.Name].Value = null;
                            PL.frm_SearchAcc F = new PL.frm_SearchAcc();
                            F.txtbranchCode.Text = Properties.Settings.Default.BranchAccID;
                            F.ShowDialog();
                            
                            e.SuppressKeyPress = true;
                            if (F.clos_ == 1)
                            {
                            int ii = F.DGV1.CurrentCell.RowIndex;
                            dGV_Item.Rows[iRow].Cells[_AccNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                            dGV_Item.Rows[iRow].Cells[_AccName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                            dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[iRow].Cells[_Desc.Name].ColumnIndex, iRow];
                            }


                        }
                    }

                    else if (iCol == dGV_Item.Rows[iRow].Cells[_CostNo.Name].ColumnIndex)
                    {
                        if (dGV_Item.Rows[iRow].Cells[_CostNo.Name].Value == null)
                        {
                          dGV_Item.Rows[iRow].Cells[_CostNo.Name].Value = "1";
                            GetCost(iRow);
                        }
                            dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[iRow].Cells[_CatCode.Name].ColumnIndex, iRow];

                        //else
                        //{
                        //    dGV_Item.Rows[iRow].Cells[_CostNo.Name].Value = null;
                        //    dGV_Item.Rows[iRow].Cells[_CostName.Name].Value = null;

                        //    PL.frm_serch_cost F = new PL.frm_serch_cost();
                        //    F.ShowDialog();
                        //    e.SuppressKeyPress = true;
                        //    int ii = F.DGV1.CurrentCell.RowIndex;


                        //    dGV_Item.Rows[iRow].Cells[_CostNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                        //    dGV_Item.Rows[iRow].Cells[_CostName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                        //    dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[iRow].Cells[_CatCode.Name].ColumnIndex, iRow];

                        //}

                    }

                    else if (iCol == dGV_Item.Rows[iRow].Cells[_CatCode.Name].ColumnIndex)
                    {
                       
                        if (dGV_Item.Rows[iRow].Cells[_CatCode.Name].Value == null)
                        {
                           dGV_Item.Rows[iRow].Cells[_CatCode.Name].Value = "1";
                            GetCat(iRow);
                        }
                        if (chRecordVat.Checked == true )
                        {
                            dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[iRow].Cells[_VatSupp.Name].ColumnIndex, iRow];
                        }
                        else
                        {
                            if (iRow < dGV_Item.Rows.Count - 1)
                            {
                                dGV_Item.CurrentCell = dGV_Item[0, iRow + 1];

                            }

                            resizeDG();

                        }
                        
                        //else
                        //{
                        //    dGV_Item.Rows[iRow].Cells[_CatCode.Name].Value = null;
                        //    dGV_Item.Rows[iRow].Cells[_CatName.Name].Value = null;

                        //    //PL.frm_search_Cat F = new PL.frm_search_Cat();
                        //    //F.ShowDialog();
                        //    //e.SuppressKeyPress = true;
                        //    //int ii = F.DGV1.CurrentCell.RowIndex;


                        //    //dGV_Item.Rows[iRow].Cells[_CatCode.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                        //    //dGV_Item.Rows[iRow].Cells[_CatName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                        //    //dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[iRow].Cells[_VatSupp.Name].ColumnIndex, iRow];
                        //    //dGV_Item.CurrentCell.Selected = true;


                        //}

                    }

                    else
                    {
                        dGV_Item.CurrentCell = dGV_Item[iCol + 1, iRow];

                    }

                }




            }
           

            
            
            total_inv();
        }


        void resizeDG()
        {
          

            foreach (DataGridViewRow row in this.dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                dGV_Item.EnableHeadersVisualStyles = false;


            }
        }


        public String TranslateToEn(String word)
        {
            var toLanguage = "en";//English
            var fromLanguage = "ar";//Deutsch
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }

        public String TranslateToAr(String word)
        {
            var toLanguage = "ar";//English
            var fromLanguage = "en";//Deutsch
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }




        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            OnLoad(e);
        }



        private void dGV_Item_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dal.getDgvSer(dGV_Item);
        }

        private void csMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void rptStatment_Click(object sender, EventArgs e)
        {
            var frm = new RPT.frm_statment_Rpt();
            frm.canChangeAcc = false;

          
            frm.UC_Acc1.ID.Text = dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_AccNo.Name].FormattedValue.ToString();
            Forms.frm_Main.OpenForm(frm, true);
        }

        private void chartOfAccount_Click(object sender, EventArgs e)
        {
          
        }

        private void dGV_Item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dGV_Item.CurrentCell.RowIndex;
            int j = dGV_Item.CurrentCell.ColumnIndex;

            if (j == dGV_Item.Rows[i].Cells[_Amount.Name].ColumnIndex)
            {
                OnDoubleClick(e);
            }


            //-------------------------------------------------------------------//
            else if (j == dGV_Item.Rows[i].Cells[_AccNo.Name].ColumnIndex)

            {
                 PL.frm_SearchAcc F = new PL.frm_SearchAcc();
                F.txtbranchCode.Text = Properties.Settings.Default.BranchAccID;
                F.ShowDialog();
                if (F.clos_ == 1)
                {
                int ii = F.DGV1.CurrentCell.RowIndex;
                dGV_Item.Rows[i].Cells[_AccNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                dGV_Item.Rows[i].Cells[_AccName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
               // dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[i].Cells[_Desc.Name].ColumnIndex, i];
                }


            }

            else if (j == dGV_Item.Rows[i].Cells[_CostNo.Name].ColumnIndex)
            {
                PL.frm_serch_cost F = new PL.frm_serch_cost();
                F.ShowDialog();

                int ii = F.DGV1.CurrentCell.RowIndex;
                dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_CostNo.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_CostName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
//                dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_CatCode.Name].ColumnIndex, dGV_Item.CurrentRow.Index];

            }

            else if (j == dGV_Item.Rows[i].Cells[_CatCode.Name].ColumnIndex)
            {
                PL.frm_search_Cat F = new PL.frm_search_Cat();
                F.ShowDialog();
                //   e.SuppressKeyPress = true;
                int ii = F.DGV1.CurrentCell.RowIndex;


                dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_CatCode.Name].Value = F.DGV1.Rows[ii].Cells[0].Value;
                dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_CatName.Name].Value = F.DGV1.Rows[ii].Cells[1].Value;
                dGV_Item.CurrentCell = dGV_Item[dGV_Item.Rows[dGV_Item.CurrentRow.Index].Cells[_CatCode.Name].ColumnIndex, dGV_Item.CurrentRow.Index];
                dGV_Item.CurrentCell.Selected = true;

            }
        }

        private void dGV_Item_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dal.getDgvSer(dGV_Item);
        }

        private void dGV_Item_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dal.getDgvSer(dGV_Item);
        }

        private void dGV_Item_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[_InvAmount.Name].Value = 0;
        }

        private void dGV_Item_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chRecordVat_CheckedChanged(object sender, EventArgs e)
        {
            showVatColumns();
        }

        private void showVatColumns()
        {
            if (chRecordVat.Checked == true)
            {
                dGV_Item.Columns[_VatSupp.Name].Visible = true;
                dGV_Item.Columns[_InvAmount.Name].Visible = true;
                dGV_Item.Columns[_InvDate.Name].Visible = true;
                dGV_Item.Columns[_invNo.Name].Visible = true;
                dGV_Item.Columns[_VatID.Name].Visible = true;
            }

            else
            {
                dGV_Item.Columns[_VatSupp.Name].Visible = false;
                dGV_Item.Columns[_InvAmount.Name].Visible = false;
                dGV_Item.Columns[_InvDate.Name].Visible   = false;
                dGV_Item.Columns[_invNo.Name].Visible     = false;
                dGV_Item.Columns[_VatID.Name].Visible     = false;
            }
        }
    }
}
