using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frm_rpt_Po :frm_ReportMaster
    {
      
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string languh = Properties.Settings.Default.lungh;
        DataTable dt = new DataTable();
        DataTable dt_Q;
        BindingSource bs = new BindingSource();
        DataTable dt_bs = new DataTable();

        public frm_rpt_Po()
        {
            InitializeComponent();
                    

        }


        void createDattable()
        {
            dt_bs.Columns.Add("_ser", typeof(string));
            dt_bs.Columns.Add("_branch", typeof(string));
            dt_bs.Columns.Add("_date", typeof(DateTime));
            dt_bs.Columns.Add("_acc", typeof(string));
            dt_bs.Columns.Add("_itemNo", typeof(string));
            dt_bs.Columns.Add("_item", typeof(string));
            dt_bs.Columns.Add("_Weight", typeof(decimal));
            dt_bs.Columns.Add("_unit", typeof(string));
            dt_bs.Columns.Add("_qty", typeof(decimal));
            dt_bs.Columns.Add("_rQty", typeof(decimal));
            dt_bs.Columns.Add("_balance", typeof(decimal));
            dt_bs.Columns.Add("_unitPrice", typeof(decimal));
            dt_bs.Columns.Add("_tonPrice", typeof(decimal));
            dt_bs.Columns.Add("_branchCode", typeof(string));
            dt_bs.Columns.Add("_accNo", typeof(string));
            dt_bs.Columns.Add("_year", typeof(string));

        }

        void resaizeDGV()
        {
            int dgvWidth = dgvPO.Width - dgvPO.RowHeadersWidth;
            dgvPO.Columns[0].Width = (int)(dgvWidth * 0.04);
            dgvPO.Columns[1].Width = (int)(dgvWidth * 0.09);
            dgvPO.Columns[2].Width = (int)(dgvWidth * 0.05);
            dgvPO.Columns[3].Width = (int)(dgvWidth * 0.15);
            dgvPO.Columns[4].Width = (int)(dgvWidth * 0.05);
            dgvPO.Columns[5].Width = (int)(dgvWidth * 0.20);
            dgvPO.Columns[6].Width = (int)(dgvWidth * 0.055);
            dgvPO.Columns[7].Width = (int)(dgvWidth * 0.06);
            dgvPO.Columns[8].Width = (int)(dgvWidth * 0.065);
            dgvPO.Columns[9].Width = (int)(dgvWidth * 0.065);
            dgvPO.Columns[10].Width = (int)(dgvWidth * 0.065);
            dgvPO.Columns[11].Width = (int)(dgvWidth * 0.055);
            dgvPO.Columns[12].Width = (int)(dgvWidth * 0.055);
            dgvPO.Columns[13].Visible = false;
            dgvPO.Columns[14].Visible = false;
            dgvPO.Columns[15].Visible = false;


            if (languh == "0")
            {
                dgvPO.Columns[0].HeaderText = "الرقم";
                dgvPO.Columns[1].HeaderText = "الفرع";
                dgvPO.Columns[2].HeaderText = "التاريخ";
                dgvPO.Columns[3].HeaderText = "المورد";
                dgvPO.Columns[4].HeaderText = "كودالصنف";
                dgvPO.Columns[5].HeaderText = "وصف الصنف";
                dgvPO.Columns[6].HeaderText = "الوزن";
                dgvPO.Columns[7].HeaderText = "الوحدة";
                dgvPO.Columns[8].HeaderText = "الكمية";
                dgvPO.Columns[9].HeaderText = "المستلم";
                dgvPO.Columns[10].HeaderText = "المتبقي";
                dgvPO.Columns[11].HeaderText = "سعر الوحدة";
                dgvPO.Columns[12].HeaderText = "سعر الطن";
                dgvPO.Columns[13].HeaderText = "كود الفرع";
                dgvPO.Columns[14].HeaderText = "رقم الحساب";
                dgvPO.Columns[15].HeaderText = "السنة";

            }
            else
            {
                dgvPO.Columns[0].HeaderText = "Ser";
                dgvPO.Columns[1].HeaderText = "Branch";
                dgvPO.Columns[2].HeaderText = "Date";
                dgvPO.Columns[3].HeaderText = "Vendor";
                dgvPO.Columns[4].HeaderText = "Item Code";
                dgvPO.Columns[5].HeaderText = "Item Description";
                dgvPO.Columns[6].HeaderText = "Weight";
                dgvPO.Columns[7].HeaderText = "Unit";
                dgvPO.Columns[8].HeaderText = "Quantity";
                dgvPO.Columns[9].HeaderText = "Received";
                dgvPO.Columns[10].HeaderText= "Balance";
                dgvPO.Columns[11].HeaderText = "Unit Price";
                dgvPO.Columns[12].HeaderText = "Ton Price";
                dgvPO.Columns[13].HeaderText = "Branch Code";
                dgvPO.Columns[14].HeaderText = "Account No";
                dgvPO.Columns[15].HeaderText = "Year";

            }



        }



        void total_()
        {
            decimal totqty = 0;
            decimal totReceive = 0;
            decimal totBalance = 0;
            for (int s=1;s<dgvPO.Rows.Count;s++ )
            {
                var value1 = dgvPO.Rows[s].Cells[8].Value;
                var value2 = dgvPO.Rows[s].Cells[9].Value;
                var value3 = dgvPO.Rows[s].Cells[10].Value;
                if (value1 != DBNull.Value)
                {
                    totqty += Convert.ToDecimal(value1);
                }
                if (value2 != DBNull.Value)
                {
                    totReceive += Convert.ToDecimal(value2);
                }
                if (value3 != DBNull.Value)
                {
                    totBalance += Convert.ToDecimal(value3);
                }
            }
            //dgvPO.Rows[0].Cells[7].Value = totqty.ToString().ToDecimal().ToString("N0");
            //dgvPO.Rows[0].Cells[8].Value = totReceive.ToString().ToDecimal().ToString("N0");
            //dgvPO.Rows[0].Cells[9].Value = totBalance.ToString().ToDecimal().ToString("N0");


            txtTotalQty.Text /*dgvPO.Rows[0].Cells[7].Value*/ = totqty.ToString().ToDecimal().ToString("N0");
            txtTotalReceived.Text/*dgvPO.Rows[0].Cells[8].Value*/ = totReceive.ToString().ToDecimal().ToString("N0");
            txtTotalBalance.Text /*dgvPO.Rows[0].Cells[9].Value*/ = totBalance.ToString().ToDecimal().ToString("N0");

        }



        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Yellow;
            style.SelectionBackColor = Color.Yellow;
            style.SelectionForeColor = Color.Black;
            band.DefaultCellStyle = style;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // groupControl2.Visible = true;
            dgvPO.Dock = DockStyle.None;
            dgvPO.Rows.Clear();
        }

        public override void Option()
        {

            // dgvPO.Dock = DockStyle.None;
            dgvPO.DataSource = null;
            dgvPO.Rows.Clear();
            dgvPO.Visible = false;
            panel1.Visible = true;

            base.Option();
        }

        public override void Report()
        {

            panel1.Visible = false;
            dgvPO.Visible = true;
            // dgvPO.Dock = DockStyle.Fill;

            getData();
         //   dgvPO.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                dt_bs.Clear();
                int ii = 0;
                DataRow row = null;
                foreach (DataRow r in dt.Rows)
                {

                    row = dt_bs.NewRow();



                    row[0] =  r["ser_no"];
                    if (languh == "0")
                    {
                        row[1] = dt.Rows[ii]["branch_name"];
                        row[3] = dt.Rows[ii]["payer_name"];
                        row[5] = dt.Rows[ii]["descr"];
                    }
                    else
                    {
                        row[1] = dt.Rows[ii]["WH_E_NAME"];
                        row[3] = dt.Rows[ii]["payer_l_name"];
                        row[5] = dt.Rows[ii]["Descr_eng"];
                    }
                    row[2] = Convert.ToDateTime(dt.Rows[ii]["G_Date"]).ToString("yyyy/MM/dd");
                    row[4] =  dt.Rows[ii]["item_no"];
                    row[6] = dt.Rows[ii]["weight"];
                    row[7] =  dt.Rows[ii]["Unit"];
                    row[8] =  dt.Rows[ii]["qty_take"];
                    row[9] =  dt.Rows[ii]["qty_Add"];
                    row[10] =  dt.Rows[ii]["Po_balance"];
                    row[11] = dt.Rows[ii]["Local_Price"];
                    row[12] = dt.Rows[ii]["TonPrice"];
                    row[13] = dt.Rows[ii]["branch_code"];
                    row[14] = dt.Rows[ii]["Acc_no"];
                    row[15] = dt.Rows[ii]["cyear"];

                    dt_bs.Rows.Add(row);
                    ii = ii + 1;
                }
                dgvPO.DataSource = dt_bs;
                bs.DataSource = dgvPO.DataSource;
                dgvPO.DataSource = bs;
                resaizeDGV();
                total_();


            }







            //getData();
            //dgvPO.Rows.Clear();
            //if (dt.Rows.Count > 0)
            //{
                
            //    int B_rowscount = dt.Rows.Count;


            //    dgvPO.Rows.Add(B_rowscount);
            //    for (int i = 0; i <= (B_rowscount-1); i++)
            //    {


            //        dgvPO.Rows[i].Cells[0].Value = dt.Rows[i]["ser_no"];
            //        if (languh == "0")
            //        {
            //            dgvPO.Rows[i].Cells[1].Value = dt.Rows[i]["branch_name"];
            //            dgvPO.Rows[i].Cells[3].Value = dt.Rows[i]["payer_name"];
            //            dgvPO.Rows[i].Cells[5].Value = dt.Rows[i]["descr"];

            //        }
            //        else
            //        {
            //            dgvPO.Rows[i].Cells[1].Value = dt.Rows[i]["WH_E_NAME"];
            //            dgvPO.Rows[i].Cells[3].Value = dt.Rows[i]["payer_l_name"];
            //            dgvPO.Rows[i].Cells[5].Value = dt.Rows[i]["Descr_eng"];
            //        }

            //        dgvPO.Rows[i].Cells[2].Value = Convert.ToDateTime(dt.Rows[i]["G_Date"]).ToString("yyyy/MM/dd");
            //        dgvPO.Rows[i].Cells[4].Value = dt.Rows[i]["item_no"];
            //        dgvPO.Rows[i].Cells[6].Value = dt.Rows[i]["Unit"];
            //        dgvPO.Rows[i].Cells[7].Value = dt.Rows[i]["qty_take"].ToString().ToDecimal();
            //        dgvPO.Rows[i].Cells[8].Value = dt.Rows[i]["qty_Add"].ToString().ToDecimal();
            //        dgvPO.Rows[i].Cells[9].Value = dt.Rows[i]["Po_balance"].ToString().ToDecimal();
            //        dgvPO.Rows[i].Cells[10].Value = dt.Rows[i]["Local_Price"].ToString().ToDecimal();
            //        dgvPO.Rows[i].Cells[11].Value = dt.Rows[i]["TonPrice"].ToString().ToDecimal();

            //        dgvPO.Rows[i].Cells[12].Value = dt.Rows[i]["branch_code"];
            //        dgvPO.Rows[i].Cells[13].Value = dt.Rows[i]["Acc_no"];
            //        dgvPO.Rows[i].Cells[14].Value = dt.Rows[i]["cyear"];

            //    }
            //    //  FreezeBand(dgvPO.Rows[0]);

            //   // bs.DataSource = dgvPO.DataSource;
            //   //dgvPO.DataSource = bs;
            //    total_();

            //}
            Cursor.Current = Cursors.Default;

           

            base.Report();
        }

        private DataTable getData()
        {
            double T1, T2;
            if (txtThick_1.Text == "")
            { T1 = 0; }
            else { T1 = Convert.ToDouble(txtThick_1.Text); }
            if (txtThick_2.Text == "" || txtThick_2.Text == "0")
            { T2 = 100000; }
            else { T2 = Convert.ToDouble(txtThick_2.Text); }

            string stockItem ="";
            if (radioGroup2.EditValue.Equals("0"))
            { stockItem = ""; }
            else if (radioGroup2.EditValue.Equals("1"))
            { stockItem = "0"; }
            else if (radioGroup2.EditValue.Equals("2"))
            { stockItem = "1"; }

            string canceld = "";
            if (chCanceled.Checked)
            { canceld = "C"; }
            else
            {
                canceld = "N";
            }
            string closed = "";
            if (chClosed.Checked)
            { closed = "S"; }
            else
            {
                closed = "N";
            }

            string active = "";
            if (chActive.Checked)
            {
              active = "";
              
            }
            else
            {
              active = "N";
            }


            //  case when '" + radioGroup1.EditValue + "' = 1 then 0


            dt = dal.getDataTabl_1(@"select x.ser_no,X.G_Date,X.Cyear,X.Acc_no,P.payer_name,P.payer_l_name,x.item_no,D.descr,D.Descr_eng ,X.branch_code,C.branch_name,C.WH_E_NAME,D.Unit,D.weight,X.qty_take,Y.qty_Add ,X.qty_take-isnull(Y.qty_Add,0) as Po_balance,D.Weight,X.Local_Price, case when D.Weight>0 then X.Local_Price/D.Weight*1000 else 0 end as TonPrice from 
            (select S2.Acc_no,S1.ser_no,S1.Cyear,S1.G_Date ,S1.branch_code,item_no, qty_take,Local_Price ,S2.CANCELED,S2.Po_Status
            from wh_Po_Cot_MATERIAL_TRANSACTION as S1 
            inner join  wh_Po_Cot_inv_data as S2
            on S1.ser_no = S2.ser_no and S1.branch_code =S2.branch_code and S1.cyear= S2.cyear and S1.transaction_code = S2.transaction_code
            where S1.TRANSACTION_CODE='ps' AND (S2.CANCELED = '"+canceld+"'  or S2.Po_Status = '"+closed+
           "' or (ISNULL(S2.CANCELED,'')='"+active+"' and isnull(S2.Po_Status,'')='"+active+"')) and cast(S1.G_date as date) between '" + txtFromDate.Value.ToString("yyyy-MM-dd") + "' and '" + txtToDate.Value.ToString("yyyy-MM-dd")
            +"' and S1.branch_code like '"+txtBranch.ID.Text+"%') as X " +
            "left join  (select A.item_no,A.Branch_code,A.Cyear,B.po_no,sum(qty_add-qty_take) as qty_Add   from wh_material_transaction as A inner join wh_inv_data As B on "+
            "A.ser_no = B.ser_no and A.branch_code =B.branch_code and A.cyear= B.cyear and A.transaction_code = B.transaction_code where A.transaction_code like 'xp%'   group by A.item_no,A.Branch_code,A.Cyear,B.po_no ) as Y "+
            "on  cast(X.ser_no as varchar)= cast(Y.Po_no as varchar) and X.Cyear=Y.Cyear and X.branch_code = Y.branch_code and X.item_no = Y.item_no "+
            "inner join wh_branches as C on X.branch_code = C.branch_code "+
            "inner join wh_main_master as D on X.item_no = D.item_no "+
            "inner join Payer2 as p on P.acc_no = X.acc_no and C.ACC_BRANCH =  P.branch_code "+
           " where isnull(NonStockItem ,0) Like '" +stockItem+"%' and D.group_code  between(CASE WHEN '" + txtGroup.ID.Text.Length + "' > 3  then  '" + txtGroup.ID.Text + "' else '" + txtGroup.ID.Text + "' + '0' end) and " +
           "(CASE WHEN '" + txtGroup1.ID.Text.Length + "' >3   then  '" + txtGroup1.ID.Text + "' else  '" + txtGroup1.ID.Text + "'+'z' end) " +
           "and x.ser_no like case when '"+txtPO.Text.Trim()+"'!= '' then '"+txtPO.Text+ "' else '" + txtPO.Text + "%' end  "+
           "and X.Acc_no Like '"+txtAcc.ID.Text +"%' and x.item_no like '" + txtItem.ID.Text
           + "%' and ISNULL(D.UnitDepth, '') BETWEEN '" + T1 + "' AND '" + T2 +
           "' and( isnull(Y.qty_Add,0)>0 and  (X.qty_take-isnull(Y.qty_Add,0)) > case when '" + radioGroup1.EditValue + "'=1 then 0  end  " +
          "or (X.qty_take-isnull(Y.qty_Add,0))=case when '" + radioGroup1.EditValue + "'=2 then 0 end " +
          "or isnull(Y.qty_Add,0)= case when '" + radioGroup1.EditValue + "'=3 then 0 end " +
          "or X.qty_take > case when '" + radioGroup1.EditValue + "'=0 then 0 end) " +
          "or (X.qty_take - isnull(Y.qty_Add, 0)) > case when '" + radioGroup1.EditValue + "' = 4 then 0  end "+
          "  order by X.branch_code,x.ser_no");

            return dt;
        }

        private void dgvPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPO.SelectedRows.Count < 1 || dgvPO.CurrentRow.Cells[13].Value.ToString() == null || dgvPO.CurrentRow.Cells[12].Value.ToString() == null || dgvPO.CurrentRow.Cells[0].Value.ToString() == null)
            {
                return;
            }



            if (e.ColumnIndex == 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                //MessageBox.Show("PO");

                string printModel = Properties.Settings.Default.inv_print;
               
                    RPT.rpt_Purchase_Order reportInv = new RPT.rpt_Purchase_Order();
                    RPT.Form1 frminv = new RPT.Form1();
                    DataSet ds = new DataSet();
                    getPO(dgvPO.CurrentRow.Cells[0].Value.ToString(), dgvPO.CurrentRow.Cells[12].Value.ToString(), "PS", txtToDate.Value.ToString("yy"));
                    ds.Tables.Add(dt_Q);
                    ////ds.WriteXmlSchema("schema_rpt.xml");
                    reportInv.SetDataSource(ds);
                    //reportInv.SetDataSource(dal.getDataTabl("get_invDetails", txt_InvNu.Text, txt_transaction_code.Text, txt_InvDate.Value.Year.ToString()));
                    frminv.crystalReportViewer1.ReportSource = reportInv;
                    frminv.ShowDialog();
               

                Cursor.Current = Cursors.Default;
            }
           else if (e.ColumnIndex == 3)
            {
                Cursor.Current = Cursors.WaitCursor;
                // MessageBox.Show("statment");
                               
                    RPT.frm_statment_Rpt frm = new RPT.frm_statment_Rpt();
                    frm.UC_Acc1.ID.Text = dgvPO.CurrentRow.Cells[14].Value.ToString();
                   // frm.UC_Items.ID.Text = dgvPO.CurrentRow.Cells[4].Value.ToString();
                    frm.FromDate.Text = txtFromDate.Text;
                    frm.ToDate.Text = txtToDate.Text;
                   // frm.Report_btn.PerformClick();
                    frm.ShowDialog();

                Cursor.Current = Cursors.Default;

            }
            else if (e.ColumnIndex == 5)
            {
                //MessageBox.Show("item card");

                Cursor.Current = Cursors.WaitCursor;

                    RPT.frm_Item_Transaction frm = new RPT.frm_Item_Transaction();
                    frm.UC_Branch.ID.Text = dgvPO.CurrentRow.Cells[13].Value.ToString();
                    frm.UC_Items.ID.Text = dgvPO.CurrentRow.Cells[4].Value.ToString();
                    frm.FromDate_.Text =  txtFromDate.Text;
                    frm.ToDate_.Text = txtToDate.Text;
                    frm.buttonX1.PerformClick();
                    frm.ShowDialog();
                
                Cursor.Current = Cursors.Default;
            }
            else if (e.ColumnIndex == 9)
            {
                Cursor.Current = Cursors.WaitCursor;
                // MessageBox.Show("received qty");
                if (dgvPO.CurrentRow.Cells[9].Value.ToString().ToDecimal() > 0)
                {
                    RPT.frm_PO_Received frm = new RPT.frm_PO_Received();
                    frm._branch = dgvPO.CurrentRow.Cells[13].Value.ToString();
                    frm._PO = dgvPO.CurrentRow.Cells[0].Value.ToString();
                    frm._year = dgvPO.CurrentRow.Cells[15].Value.ToString();
                    frm.ShowDialog();
                }

               Cursor.Current = Cursors.Default;
            }
        }


        private void getPO(string ser_, string branch_, string transaction_, string cyear_)
        {
            //try
            //{ //, ReportDB.dbo.Tafkeet('+@4+', '''+@5+''')  from wh_Po_Cot_inv_data As A
            dt_Q = dal.getDataTabl_1(@"select A.Ser_no,A.Branch_code,A.Transaction_code,A.Cyear,A.Sanad_no,A.G_date,A.Acc_no,A.Acc_Branch_code
            ,A.Payment_Type,A.Sales_man_Id,A.User_id,A.Po_Status,A.Po_Expire_Date,A.Cash_costomer_name,A.Costomer_adress
            ,A.Costomer_Phone,A.Costmer_fax,A.Ref,A.E_mail,A.TermsOfPayment,A.Validity,A.DelevryE,A.FORIN_TYPE
            ,A.K_M_ACC_NO,A.K_M_Credit_TAX,A.COSTMER_K_M_NO,A.KM_CODE_ACC,A.MAIN_KM_CODE,A.Costomer_Notes,A.VAT_RATIO,A.COMP_TAX_NO
            ,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.Unit,B.total_disc,B.Local_Price,B.TAX_IN,B.TAX_OUT,B.DETAILS,B.Pice_Total_Cost,B.K_M_TYPE_ITEMS

            ,M.descr,M.Descr_eng,m.Weight,m.BALANCE ,K.KM_RATIO,
            SP.Payment_name,SP.Notes,
            DP.DeLEVRY_Name,DP.DELEVER_NAME_E,U.USER_NAME
			,P.PAYER_NAME,P.payer_l_name
            ,(select top 1 vat_ratio from VAT_RATIO_MASTER where cast(A.G_date as date ) between date_of_vat and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by date_of_vat desc) as VatRatio "+
            "from wh_Po_Cot_inv_data As A "+
            "Inner join wh_Po_Cot_MATERIAL_TRANSACTION As B " +
            "on A.Ser_no = B.SER_NO and A.Branch_code = B.Branch_code AND A.Transaction_code = B.TRANSACTION_CODE AND A.Cyear = B.Cyear " +
            "inner join wh_main_master AS M on M.item_no = B.ITEM_NO " +
            "left join KM_MATERIAL_CODE As K on K.KM_CODE = ISNULL(NULLIF(M.KM_CODE, ''), 1) " +
            "left join Sal_Pyment_type As SP on SP.Payment_type = A.termsOfPayment " +
            "left join WH_PO_DELEVRY_CODE As DP on DP.DeLEVRY_CODE = A.DelevryE " +
            "inner join wh_USERS As U on U.USER_ID = A.USER_ID " +
            "inner join wh_BRANCHES as BR on A.Branch_code = BR.Branch_code " +
            "inner join payer2 as P on P.acc_no = A.acc_no and p.BRANCH_code = BR.ACC_BRANCH "+ 
            "where A.Ser_no = '" + ser_ + "'  and A.Branch_code = '" + branch_ + "'  and A.transaction_code = '" + transaction_ + "'  and A.cyear = '" + cyear_ + "'");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frm_rpt_Po_Load(object sender, EventArgs e)
        {
            btn_Report.Visible = true;
            btn_preview.Visible = false;
            btn_exportToExcel.Visible = true;
            createDattable();
            dgvPO.DataSource = dt_bs;
            resaizeDGV();
        }


        public override void exportToExcel()
        {

            Microsoft.Office.Interop.Excel.Application exlApp = new Microsoft.Office.Interop.Excel.Application();
            exlApp.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dgvPO.ColumnCount; i++)
            {
                exlApp.Cells[1, i + 1] = dgvPO.Columns[i].HeaderText.ToString();
            }

            for (int i = 0; i < dgvPO.RowCount; i++)
            {

                for (int j = 0; j < dgvPO.ColumnCount; j++)
                {
                    exlApp.Cells[i + 2, j + 1] = dgvPO.Rows[i].Cells[j].Value;
                }
            }
            exlApp.Columns.AutoFit();
            exlApp.Visible = true;


            base.exportToExcel();
        }
       
        
   
    

        private void gc_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = e.View as GridView;
            view.OptionsView.ShowViewCaption = true;
            view.ViewCaption = "وحدات القياس ";
            view.Columns["UnitName"].Caption = "اسم الوحده";
            view.Columns["Factor"].Caption = "المعامل";
            view.Columns["SellPrice"].Caption = "سعر البيع";
            view.Columns["BuyPrice"].Caption = "سعر الشراء";
            view.Columns["Barcode"].Caption = "الباركود";

        }

        void getTotal()
        {
            txtTotalQty.Text =
                (from DataGridViewRow row in dgvPO.Rows
                 where row.Cells[0].FormattedValue.ToString() != string.Empty
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
               select (row.Cells[8].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");
            txtTotalReceived.Text =
                (from DataGridViewRow row in dgvPO.Rows
                 where row.Cells[0].FormattedValue.ToString() != string.Empty
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[9].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");

            txtTotalBalance.Text =
                (from DataGridViewRow row in dgvPO.Rows
                 where row.Cells[0].FormattedValue.ToString() != string.Empty
                 // select Convert.ToDouble(row.Cells[0].FormattedValue)).Sum().ToString();
                 select (row.Cells[10].FormattedValue).ToString().ToDecimal()).Sum().ToString("N0");

        }


        private void dgvReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( dgvPO.CurrentRow.Cells[14].Value.ToString() == null || dgvPO.CurrentRow.Cells[13].Value.ToString() == null || dgvPO.CurrentRow.Cells[0].Value.ToString() == null)
            {
                return;
            }



            if (e.ColumnIndex == 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                //MessageBox.Show("PO");

                string printModel = Properties.Settings.Default.inv_print;

                RPT.rpt_Purchase_Order reportInv = new RPT.rpt_Purchase_Order();
                RPT.Form1 frminv = new RPT.Form1();
                DataSet ds = new DataSet();
                getPO(dgvPO.CurrentRow.Cells[0].Value.ToString(), dgvPO.CurrentRow.Cells[13].Value.ToString(), "PS", txtToDate.Value.ToString("yy"));
                ds.Tables.Add(dt_Q);
                ////ds.WriteXmlSchema("schema_rpt.xml");
                reportInv.SetDataSource(ds);
                //reportInv.SetDataSource(dal.getDataTabl("get_invDetails", txt_InvNu.Text, txt_transaction_code.Text, txt_InvDate.Value.Year.ToString()));
                frminv.crystalReportViewer1.ReportSource = reportInv;
                frminv.ShowDialog();


                Cursor.Current = Cursors.Default;
            }
            else if (e.ColumnIndex == 3)
            {
                Cursor.Current = Cursors.WaitCursor;
                // MessageBox.Show("statment");

                RPT.frm_statment_Rpt frm = new RPT.frm_statment_Rpt();
                frm.UC_Acc1.ID.Text = dgvPO.CurrentRow.Cells[14].Value.ToString();
                // frm.UC_Items.ID.Text = dgvPO.CurrentRow.Cells[4].Value.ToString();
                frm.FromDate.Text = txtFromDate.Text;
                frm.ToDate.Text = txtToDate.Text;
                // frm.Report_btn.PerformClick();
                frm.ShowDialog();

                Cursor.Current = Cursors.Default;

            }
            else if (e.ColumnIndex == 5)
            {
                //MessageBox.Show("item card");

                Cursor.Current = Cursors.WaitCursor;

                RPT.frm_Item_Transaction frm = new RPT.frm_Item_Transaction();
                frm.UC_Branch.ID.Text = dgvPO.CurrentRow.Cells[13].Value.ToString();
                frm.UC_Items.ID.Text = dgvPO.CurrentRow.Cells[4].Value.ToString();
                frm.FromDate_.Text = txtFromDate.Text;
                frm.ToDate_.Text = txtToDate.Text;
                frm.buttonX1.PerformClick();
                frm.ShowDialog();

                Cursor.Current = Cursors.Default;
            }
            else if (e.ColumnIndex == 9)
            {
                Cursor.Current = Cursors.WaitCursor;
                // MessageBox.Show("received qty");
                if (dgvPO.CurrentRow.Cells[9].Value.ToString().ToDecimal() > 0)
                {
                    RPT.frm_PO_Received frm = new RPT.frm_PO_Received();
                    frm._branch = dgvPO.CurrentRow.Cells[13].Value.ToString();
                    frm._PO = dgvPO.CurrentRow.Cells[0].Value.ToString();
                    frm._year = dgvPO.CurrentRow.Cells[15].Value.ToString();
                    frm.ShowDialog();
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void dgvPO_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgvPO.SortString;
        }

        private void dgvPO_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgvPO.FilterString;
        }

       
    }
}
