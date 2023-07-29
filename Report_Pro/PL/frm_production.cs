using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frm_production : frm_Master
    {

        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_production()
        {
            InitializeComponent();
            txtItemType.DataSource = dal.getDataTabl_1(@"SELECT Prod_code,Prod_name,Prod_name_E FROM wh_fa_production_type");
            txtProductionLine.DataSource = dal.getDataTabl_1(@"SELECT Machine_no,Machine_Name,Machine_Name_E FROM Fac_Machine");
            txtShift.DataSource = dal.getDataTabl_1(@"SELECT wardia_no,wardia_name,wardia_name_E FROM wh_fa_wardia");
            txtShiftMan.DataSource = dal.getDataTabl_1(@"SELECT Empl_no,Empl_Name,Empl_Name_E FROM Fac_Empl");
            txtShiftEng.DataSource = dal.getDataTabl_1(@"SELECT Empl_no,Empl_Name,Empl_Name_E FROM Fac_Empl");

            txtItemType.ValueMember = "Prod_code";
            txtProductionLine.ValueMember = "Machine_no";
            txtShift.ValueMember = "wardia_no";
            txtShiftMan.ValueMember = "Empl_no";
            txtShiftEng.ValueMember = "Empl_no";




            if (dal.languh_ == "0")
            {
                txtItemType.DisplayMember = "Prod_name";
                txtProductionLine.DisplayMember = "Machine_Name";
                txtShift.DisplayMember = "wardia_name";
                txtShiftMan.DisplayMember = "Empl_Name";
                txtShiftEng.DisplayMember = "Empl_Name";

            }
            else
            {
                txtItemType.DisplayMember = "Prod_name_E";
                txtProductionLine.DisplayMember = "Machine_Name_E";
                txtShift.DisplayMember = "wardia_name_E";
                txtShiftMan.DisplayMember = "Empl_Name_E";
                txtShiftEng.DisplayMember = "Empl_Name_E";

            }


            txtItemType.SelectedIndex = -1;
            txtProductionLine.SelectedIndex = -1;
            txtShift.SelectedIndex = -1;
            txtShiftMan.SelectedIndex = -1;
            txtShiftEng.SelectedIndex = -1;

            New();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dateTimeInput2_Click(object sender, EventArgs e)
        {

        }


        private void Go_frist(string _trans)
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "'  order by ser_no");
            Bnd1.DataSource = dtNaf;
            MyResult = dtNaf.Rows[0]["ser_no"].ToString();
            showInvoice(MyResult, _trans);
            IsNew = false;


        }

        private void go_previous(string _trans)
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "'  order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txtSer.Text);
            if (RowNo == -1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            }

            else
            { //RowNo is that Row
                if (RowNo != 0)
                {
                    //RowNo is that Row
                    MyResult = dtNaf.Rows[RowNo - 1]["ser_no"].ToString();
                }
                else
                {
                    MyResult = dtNaf.Rows[0]["ser_no"].ToString();

                }

            }
            showInvoice(MyResult, _trans);
            IsNew = false;

        }

        private void go_next(string _trans)
        {
            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "'  order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txtSer.Text);
            if (RowNo < dtNaf.Rows.Count - 1 && RowNo != -1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[RowNo + 1]["ser_no"].ToString();
                showInvoice(MyResult, _trans);
            }


            IsNew = false;
        }

        private void go_last(string _trans)
        {

            DataTable dtNaf = new DataTable();
            BindingSource Bnd1 = new BindingSource();
            string MyResult = "";
            dtNaf = dal.getDataTabl_1(@"SELECT DISTINCT ser_no  FROM wh_inv_data
            where BRANCH_code = '" + Properties.Settings.Default.BranchAccID + "' and transaction_code ='" + _trans + "' order by ser_no");

            Bnd1.DataSource = dtNaf;
            int RowNo = Bnd1.Find("ser_no", txtSer.Text);
            if (RowNo != dtNaf.Rows.Count - 1)
            {
                //RowNo is that Row
                MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            }
            //else
            //{ //RowNo is that Row
            //    MyResult = dtNaf.Rows[dtNaf.Rows.Count - 1]["ser_no"].ToString();
            //}

            showInvoice(MyResult, _trans);
            IsNew = false;
        }



        public override void Search()
        {



            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            showInvoice(frm.txtSearch.t.Text, txtDocType.Text);
            base.Search();
        }

        public override void GoFrist()
        {
            Go_frist(txtDocType.Text);
            base.GoFrist();
        }

        public override void GoPrevious()
        {
            go_previous(txtDocType.Text);
            base.GoPrevious();
        }

        public override void GoNext()
        {
            go_next(txtDocType.Text);
            base.GoNext();
        }

        public override void GoLast()
        {
            go_last(txtDocType.Text);
            base.GoLast();
        }

        private void showInvoice(string Sh_ser, string sh_transaction)
        {
          dal.ClearTextBoxes(this);
        pIN.dgv1.Rows.Clear();
            pOUT.dgv1.Rows.Clear();
            pIN.total_inv();
            pOUT.total_inv();

            DataTable dt_in = dal.getDataTabl_1(@"select * from VIEW_PRODUCTION where IN_OUT_TYPE = 'I' and ser_no = '" + Sh_ser + "'");
        int db_rowscount = dt_in.Rows.Count;

            if (db_rowscount > 0)
            {
                txtSer.Text = dt_in.Rows[0]["Ser_no"].ToString();
        txtGenralSer.Text = dt_in.Rows[0]["Sanad_no"].ToString();
        txtDate.Text = dt_in.Rows[0]["G_date"].ToString();
        txtBranch.ID.Text = dt_in.Rows[0]["Branch_code"].ToString();
        txtCost.ID.Text = dt_in.Rows[0]["Sales_man_Id"].ToString();
        txtProductionLine.SelectedValue = dt_in.Rows[0]["Machin_No"].ToString();
        txtItemType.SelectedValue = dt_in.Rows[0]["Prod_code"].ToString();
        txtShift.SelectedValue = dt_in.Rows[0]["wardia_no"].ToString();
        txtShiftMan.SelectedValue = dt_in.Rows[0]["Supervisor_id"].ToString();
        txtShiftEng.SelectedValue = dt_in.Rows[0]["Enginreer_id"].ToString();
        txtDocSer.Text = dt_in.Rows[0]["Inv_no"].ToString();
        txtProductionDate.Text = dt_in.Rows[0]["Inv_date"].ToString();

        pIN.dgv1.Rows.Add(db_rowscount);
                for (int i = 0; i <= (db_rowscount - 1); i++)
                {
                    pIN.dgv1.Rows[i].Cells["_code"].Value = dt_in.Rows[i]["item_no"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                    pIN.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_in.Rows[i]["Descr"].ToString();
    }
                    else
                    {
                    pIN.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_in.Rows[i]["Descr_eng"].ToString();
}
pIN.dgv1.Rows[i].Cells["_barcodeNo"].Value = dt_in.Rows[i]["Material_id"].ToString();
pIN.dgv1.Rows[i].Cells["_unit"].Value = dt_in.Rows[i]["unit"].ToString();
pIN.dgv1.Rows[i].Cells["_weight"].Value = dt_in.Rows[i]["weight"].ToString();
pIN.dgv1.Rows[i].Cells["_qty"].Value = dt_in.Rows[i]["qty_take"].ToString();
pIN.dgv1.Rows[i].Cells["_cost"].Value = dt_in.Rows[i]["Local_Price"].ToString();
pIN.dgv1.Rows[i].Cells["_itemType"].Value = dt_in.Rows[i]["matrial_Type"].ToString();

pIN.clculat_amount(i);

                }
                pIN.total_inv();
            }

            DataTable dt_out = dal.getDataTabl_1(@"select * from VIEW_PRODUCTION where IN_OUT_TYPE = 'O' and ser_no = '" + Sh_ser + "'");
int cr_rowscount = dt_out.Rows.Count;

            if (cr_rowscount > 0)
            {
                pOUT.dgv1.Rows.Add(cr_rowscount);
                for (int i = 0; i <= (cr_rowscount - 1); i++)
                {
                    pOUT.dgv1.Rows[i].Cells["_code"].Value = dt_out.Rows[i]["item_no"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        pOUT.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_out.Rows[i]["Descr"].ToString();
                    }
                    else
                    {
                        pOUT.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_out.Rows[i]["Descr_eng"].ToString();
                    }
                    pOUT.dgv1.Rows[i].Cells["_barcodeNo"].Value = dt_out.Rows[i]["Material_id"].ToString();
pOUT.dgv1.Rows[i].Cells["_unit"].Value = dt_out.Rows[i]["unit"].ToString();
pOUT.dgv1.Rows[i].Cells["_weight"].Value = dt_out.Rows[i]["weight"].ToString();
pOUT.dgv1.Rows[i].Cells["_qty"].Value = dt_out.Rows[i]["qty_Add"].ToString();
pOUT.dgv1.Rows[i].Cells["_cost"].Value = dt_out.Rows[i]["Local_Price"].ToString();
pOUT.dgv1.Rows[i].Cells["_itemType"].Value = dt_out.Rows[i]["matrial_Type"].ToString();

pOUT.clculat_amount(i);

                }
                pOUT.total_inv();
            }

            IsNew = false;

        }



        private void showInvoice_1(string Sh_ser, string sh_transaction)
        {
            dal.ClearTextBoxes(this);
            pIN.dgv1.Rows.Clear();
            pOUT.dgv1.Rows.Clear();
            pIN.total_inv();
            pOUT.total_inv();

            DataTable dt_in = dal.getDataTabl_1(@"select * from VIEW_PRODUCTION where IN_OUT_TYPE = 'I' and  isnull(Inv_no,'')='" + Sh_ser + "'");
            int db_rowscount = dt_in.Rows.Count;

            if (db_rowscount > 0)
            {
                txtSer.Text = dt_in.Rows[0]["Ser_no"].ToString();
                txtGenralSer.Text = dt_in.Rows[0]["Sanad_no"].ToString();
                txtDate.Text = dt_in.Rows[0]["G_date"].ToString();
                txtBranch.ID.Text = dt_in.Rows[0]["Branch_code"].ToString();
                txtCost.ID.Text = dt_in.Rows[0]["Sales_man_Id"].ToString();
                txtProductionLine.SelectedValue = dt_in.Rows[0]["Machin_No"].ToString();
                txtItemType.SelectedValue = dt_in.Rows[0]["Prod_code"].ToString();
                txtShift.SelectedValue = dt_in.Rows[0]["wardia_no"].ToString();
                txtShiftMan.SelectedValue = dt_in.Rows[0]["Supervisor_id"].ToString();
                txtShiftEng.SelectedValue = dt_in.Rows[0]["Enginreer_id"].ToString();
                txtDocSer.Text = dt_in.Rows[0]["Inv_no"].ToString();
                txtProductionDate.Text = dt_in.Rows[0]["Inv_date"].ToString();

                pIN.dgv1.Rows.Add(db_rowscount);
                for (int i = 0; i <= (db_rowscount - 1); i++)
                {
                    pIN.dgv1.Rows[i].Cells["_code"].Value = dt_in.Rows[i]["item_no"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        pIN.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_in.Rows[i]["Descr"].ToString();
                    }
                    else
                    {
                        pIN.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_in.Rows[i]["Descr_eng"].ToString();
                    }
                    pIN.dgv1.Rows[i].Cells["_barcodeNo"].Value = dt_in.Rows[i]["Material_id"].ToString();
                    pIN.dgv1.Rows[i].Cells["_unit"].Value = dt_in.Rows[i]["unit"].ToString();
                    pIN.dgv1.Rows[i].Cells["_weight"].Value = dt_in.Rows[i]["weight"].ToString();
                    pIN.dgv1.Rows[i].Cells["_qty"].Value = dt_in.Rows[i]["qty_take"].ToString();
                    pIN.dgv1.Rows[i].Cells["_cost"].Value = dt_in.Rows[i]["Local_Price"].ToString();
                    pIN.dgv1.Rows[i].Cells["_itemType"].Value = dt_in.Rows[i]["matrial_Type"].ToString();

                    pIN.clculat_amount(i);

                }
                pIN.total_inv();
            }

            DataTable dt_out = dal.getDataTabl_1(@"select * from VIEW_PRODUCTION where IN_OUT_TYPE = 'O' and   isnull(Inv_no,'')='" + Sh_ser + "'");
            int cr_rowscount = dt_out.Rows.Count;

            if (cr_rowscount > 0)
            {
                pOUT.dgv1.Rows.Add(cr_rowscount);
                for (int i = 0; i <= (cr_rowscount - 1); i++)
                {
                    pOUT.dgv1.Rows[i].Cells["_code"].Value = dt_out.Rows[i]["item_no"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        pOUT.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_out.Rows[i]["Descr"].ToString();
                    }
                    else
                    {
                        pOUT.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_out.Rows[i]["Descr_eng"].ToString();
                    }
                    pOUT.dgv1.Rows[i].Cells["_barcodeNo"].Value = dt_out.Rows[i]["Material_id"].ToString();
                    pOUT.dgv1.Rows[i].Cells["_unit"].Value = dt_out.Rows[i]["unit"].ToString();
                    pOUT.dgv1.Rows[i].Cells["_weight"].Value = dt_out.Rows[i]["weight"].ToString();
                    pOUT.dgv1.Rows[i].Cells["_qty"].Value = dt_out.Rows[i]["qty_Add"].ToString();
                    pOUT.dgv1.Rows[i].Cells["_cost"].Value = dt_out.Rows[i]["Local_Price"].ToString();
                    pOUT.dgv1.Rows[i].Cells["_itemType"].Value = dt_out.Rows[i]["matrial_Type"].ToString();

                    pOUT.clculat_amount(i);

                }
                pOUT.total_inv();
            }

            IsNew = false;

        }




        private void frm_production_Load(object sender, EventArgs e)
        {
            txtBranch.txtTfinal.Text = "1";
            txtCost.txt_Tfinl.Text = "1";


        }

        private void pIN_Load(object sender, EventArgs e)
        {
            pOUT.txtRawKGCost.Text = pIN.txtKGCost.Text;

            foreach (DataGridViewRow dvRow in pOUT.dgv1.Rows)
            {
                dvRow.Cells["_cost"].Value = (pOUT.txtRawKGCost.Text.ToDecimal()* dvRow.Cells["_weight"].FormattedValue.ToString().ToDecimal()).ToString("N3");

                pOUT.clculat_amount(dvRow.Index);
            }
            pOUT.total_inv();


        }



        bool IsGridValid()
        {

            int countIN = 0;
            int countOUt = 0;

            foreach (DataGridViewRow r in pIN.dgv1.Rows)
            {
                if (r.Cells["_code"].FormattedValue.ToString() != string.Empty && r.Cells["_qty"].FormattedValue.ToString().ToDecimal() > 0 )
                {
                    countIN++;
                }

            }
            foreach (DataGridViewRow r in pOUT.dgv1.Rows)
            {
                if (r.Cells["_code"].FormattedValue.ToString() != string.Empty && r.Cells["_qty"].FormattedValue.ToString().ToDecimal() > 0)
                {
                    countOUt++;
                }

            }

            if (countIN >0 || countOUt > 0)
            {
                return true;
            }
            else
            {
                //MessageBox.Show(dal.rm.GetString("msgNoItems") , dal.rm.GetString("msgNoItems_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }


        //bool IsGridValid_out()
        //{

        //    int countR = 0;

        //    foreach (DataGridViewRow r in pOUT.dgv1.Rows)
        //    {
        //        if (r.Cells["_code"].FormattedValue.ToString() != string.Empty && r.Cells["_qty"].FormattedValue.ToString().ToDecimal() > 0)
        //        {
        //            countR++;
        //        }

        //    }
        //    if (countR > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show(dal.rm.GetString("msgError") + " No Out Items", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return false;
        //    }
        //}




        public override bool IsDataVailde()
        {
            if (txtBranch.ID.Text.Trim() == string.Empty || txtCost.ID.Text.Trim() == string.Empty || !dal.IsDateTime(txtDate.Text) 
                || !dal.IsDateTime(txtProductionDate.Text) || txtItemType.SelectedIndex == -1 || txtProductionLine.SelectedIndex == -1 ||
                txtShift.SelectedIndex == -1 || txtShiftMan.SelectedIndex == -1|| txtShiftEng.SelectedIndex == -1 || txtDocSer.Text.Trim()==String.Empty || IsGridValid().Equals(false))
            {
                MessageBox.Show(dal.rm.GetString("msgError") , dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return base.IsDataVailde();
        }



        public override void Attachment()
        {
            DataTable dt_ = dal.getDataTabl_1(@"select ser_no,Transaction_code from wh_inv_data where Ser_no= '"+txtSer.Text+"' and Cyear ='"+txt_cyear.Text+"' and Transaction_code = '"+txtDocType.Text+"' and Branch_code = '" + txtBranch_Id.Text + "'");
            if (dt_.Rows.Count > 0)
            {
                PL.Frm_uploadImage frmUpload = new PL.Frm_uploadImage();
                frmUpload.p_id = txtSer.Text;
                frmUpload.docType = txtDocType.Text;
                frmUpload.branchID = Properties.Settings.Default.BranchId;
                frmUpload.ShowDialog();
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgSureSave"), dal.rm.GetString("msgSureSave_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            base.Attachment();
        }

        public override void Save()
        {

           
            if(pIN.totalWeight.Text.ToDecimal()!= pOUT.totalWeight.Text.ToDecimal())
            {
                MessageBox.Show(dal.rm.GetString("msgBlanced"), dal.rm.GetString("msgBlanced_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsDataVailde();
           // IsGridValid();


            foreach (DataGridViewRow dvRow in pOUT.dgv1.Rows)
            {
                if (dvRow.Cells["_code"].FormattedValue.ToString() != "")
                {
                    dvRow.Cells["_cost"].Value = (pOUT.txtRawKGCost.Text.ToDecimal() * dvRow.Cells["_weight"].FormattedValue.ToString().ToDecimal()).ToString("N3");
                    int newHeatNo = dal.GetCell_1(@"SELECT max(SUBSTRING(Material_Id,2,LEN(Material_Id)))+1 FROM WH_FA_HEAT_NO_MASTER where Material_Id like '" + txtItemType.SelectedValue + "%'").ToString().ParseInt(0);
                    dvRow.Cells["_barcodeNo"].Value = txtItemType.SelectedValue + (newHeatNo + dvRow.Index).ToString().PadLeft(7, '0');
                }


            }

            add_Production_inv_data();



            base.Save();
        }


        public override void New()
        {

           dal.ClearTextBoxes(this);
            pIN.dgv1.Rows.Clear();
            pOUT.dgv1.Rows.Clear();
            pIN.total_inv();
            pOUT.total_inv();

            txtStore_ID.Text = Properties.Settings.Default.BranchId;
            txtBranch_Id.Text = Properties.Settings.Default.BranchAccID;
            AccType.Text = "C";
            txt_InvSM.Text = Program.salesman;
            userID.Text = Program.userID;
            txtCost.txt_Tfinl.Text = "1";
            txtCost.ID.Text = Program.userCostCode;
            txt_cyear.Text = Properties.Settings.Default.C_year;
            txtDate.Value = DateTime.Today;

            // txt_Acc.branchID.Text = txtBranch_Id.Text;
            // txt_Acc.txtFinal.Text = "1";
            //txt_Acc.txtMainAcc.Text = dal.GetCell_1("SELECT Suppliers_acc_no FROM wh_BRANCHES  where BRANCH_code='" + txtStore_ID.Text + "'").ToString();

            
            //get_data();
            get_invSer();


            base.New();
        }



        public override void Print()
        {
            DataTable dt_Print = dal.getDataTabl_1(@"select A.ser_no,A.Transaction_code,A.Cyear,A.Branch_code,A.G_date,A.wardia_no,A.Machin_No,A.Prod_code,A.Inv_no,A.Inv_date,A.JOP_ORDER_NO,A.Acc_no
                ,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.Unit,B.Material_id
                ,C.descr,C.Descr_eng,C.Weight
                ,D.Prod_name,D.Prod_name_E
                ,E.Machine_Name,E.Machine_Name_E
                ,F.wardia_name,F.wardia_name_E
                ,H.branch_name,H.WH_E_NAME
                from wh_inv_data as A
                inner join wh_material_transaction as B  
                on A.ser_no=b.SER_NO and  A.Transaction_code= B.TRANSACTION_CODE and A.Cyear= b.Cyear and A.Branch_code= a.Branch_code
                inner join wh_main_master as C on B.ITEM_NO =C.item_no
                inner join wh_fa_production_type as D on D.Prod_code = A.Prod_code
                inner join Fac_Machine as E on E.Machine_no = A.Machin_No
                inner join wh_fa_wardia as F on F.wardia_no = A.wardia_no
                inner join wh_BRANCHES as H on H.Branch_code = A.Branch_code
                where A.Ser_no='"+txtSer.Text+"' and A.Cyear ='"+txt_cyear.Text+"' and A.Transaction_code = '"+txtDocType.Text+"' and A.Branch_code = '"+txtBranch_Id.Text+"'");

            DataSet ds = new DataSet();
            ds.Tables.Add(dt_Print);
          //  ds.Tables.Add(dt_cr);

            ds.WriteXmlSchema("schema_rpt.xml");
            RPT.Form1 frm = new RPT.Form1();
            if (Properties.Settings.Default.lungh == "0")
            {
                RPT.rpt_Print_Production rpt= new RPT.rpt_Print_Production();
                rpt.SetDataSource(ds);
                frm.crystalReportViewer1.ReportSource = rpt;
            }
            else
            {
                RPT.rpt_Print_Production rpt = new RPT.rpt_Print_Production();
                rpt.SetDataSource(ds);
                frm.crystalReportViewer1.ReportSource = rpt;
            }
            frm.ShowDialog();


            base.Print();
        }


        private void get_invSer()
        {
            try
            {


                txtGenralSer.Text = dal.getDataTabl_1(@"select isnull(XT+1,1) from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txt_cyear.Text + "'").Rows[0][0].ToString();
                txtSer.Text = dal.getDataTabl_1(@"select isnull(XTP+1,1) from wh_Serial where Branch_code= '" + txtStore_ID.Text + "' and Cyear='" + txt_cyear.Text + "'").Rows[0][0].ToString();

               }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void add_Production_inv_data()
        {
            if (IsNew == true)
            {

                get_invSer();
                // getAccSer();
                dal.open_1();
                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;
                try
                {
            cmd.CommandText = @"INSERT INTO wh_inv_data (Ser_no, Branch_code, Transaction_code, Cyear,Sanad_no, G_date, ACC_TYPE,
            Acc_no, Acc_Branch_code,Other_branch_code, Payment_Type, Sales_man_Id, User_id,Inv_no,Inv_date,Machin_No,Enginreer_id,
            Supervisor_id,wardia_no,Prod_code,JOP_ORDER_NO)

            values('" + txtSer.Text +
                    "', '" + txtStore_ID.Text +
                    "', '" + txtDocType.Text +
                    "', '" + txt_cyear.Text +
                    "', '" + txtGenralSer.Text +
                    "','" + txtDate.Value.ToString("yyyy-MM-dd HH: mm:ss") +
                    "', '" + AccType.Text +
                    "', '" + txtBranch_Id.Text +
                    "', '" + AccType.Text +
                    "', '" + txtBranch.ID.Text +
                    "', '" + 0 +
                    "', '" + txtCost.ID.Text +
                    "',  '" + userID.Text +
                    "','" + txtDocSer.Text +
                    "','" + (dal.IsDateTime(txtProductionDate.Text) ? txtProductionDate.Value.ToString("yyyy-MM-dd") : "") +
                    "', '" + Convert.ToString(txtProductionLine.SelectedValue) +
                    "', '" + Convert.ToString(txtShiftEng.SelectedValue) +
                    "', '" + Convert.ToString(txtShiftMan.SelectedValue) +
                    "', '" + Convert.ToString(txtShift.SelectedValue) +
                    "', '" + Convert.ToString(txtItemType.SelectedValue) +
                    "', '" + txtJopOrder.Text.ParseInt(0) +
                    "')";
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i <= pIN.dgv1.Rows.Count - 1; i++)
                    {
                        if (pIN.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                           && pIN.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                           && pIN.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() != string.Empty
                            )
                        {
                            cmd.CommandText = @" INSERT INTO wh_MATERIAL_TRANSACTION (SER_NO, Branch_code, TRANSACTION_CODE, Cyear,SANAD_NO, ITEM_NO,QTY_ADD, QTY_TAKE,
                    Qty_Sales_Holding_balance,Qry_Purch_holding_balance,Return_Qty,COST_PRICE ,total_disc,DISC_R,DISC_R2,DISC_R3,G_DATE, Unit, Local_Price, USER_ID,
                    main_counter, balance, Backege, Pice_Total_Cost,TAX_IN,TAX_OUT,IN_OUT_TYPE,Weight,Material_id,matrial_Type)
                    values ('" + txtSer.Text +
                                  "', '" + txtStore_ID.Text +
                                  "', '" + txtDocType.Text +
                                  "', '" + txt_cyear.Text +
                                  "', '" + 0 +
                                  "', '" + pIN.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                                  "', '" + 0 +
                                  "', '" + pIN.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                                   "','" + 0 + "' ,'" + 0 + "','" + 0 +
                                   "', '" + pIN.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +

                                 "','0' ,'0' ,'0','0', '" + txtDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                                  "', '" + pIN.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                                  "', '" + pIN.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +
                                  "', '" + userID.Text +
                                  "', '" + pIN.dgv1.Rows[i].Index +
                                  "', '" + pIN.dgv1.Rows[i].Cells["_balance"].FormattedValue.ToString() +
                                  "', '" + 1 +
                                  "', '" + pIN.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +
                                  "', '0', '0','I', '" + pIN.dgv1.Rows[i].Cells["_weight"].FormattedValue.ToString() +
                                  "','" + pIN.dgv1.Rows[i].Cells["_barcodeNo"].FormattedValue.ToString() +
                                  "','" + pIN.dgv1.Rows[0].Cells["_itemType"].Value.ToString() + "') ";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = @"update wh_fa_heat_no_master set qty_out = qty_out+ '" + pIN.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString().ToDecimal() + "' where material_id = '" + pIN.dgv1.Rows[i].Cells["_barcodeNo"].FormattedValue.ToString() + "'";
                            cmd.ExecuteNonQuery();

                            //cmd.CommandText = @"Update wh_main_master set local_cost = '" + invGrid1.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() + "' where item_no = '" + invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() + "' ";
                            //cmd.ExecuteNonQuery();
                        }
                    }


                    int countIN = 0;
                    foreach (DataGridViewRow r in pIN.dgv1.Rows)
                    {
                        if (r.Cells["_code"].FormattedValue.ToString() != string.Empty && r.Cells["_qty"].FormattedValue.ToString().ToDecimal() > 0)
                        {
                            countIN++;
                        }

                    }

                    for (int i = 0; i <= pOUT.dgv1.Rows.Count - 1; i++)
                    {
                        if (pOUT.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                           && pOUT.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                           && pOUT.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() != string.Empty
                           && pOUT.dgv1.Rows[i].Cells["_newCost"].FormattedValue.ToString() != string.Empty
                            )
                        {
                            cmd.CommandText = @" INSERT INTO wh_MATERIAL_TRANSACTION   (SER_NO, Branch_code, TRANSACTION_CODE, Cyear,SANAD_NO, ITEM_NO,QTY_ADD, QTY_TAKE,
                    Qty_Sales_Holding_balance,Qry_Purch_holding_balance,Return_Qty,COST_PRICE ,total_disc,DISC_R,DISC_R2,DISC_R3,G_DATE, Unit, Local_Price, USER_ID,
                    main_counter, balance, Backege, Pice_Total_Cost,TAX_IN,TAX_OUT,IN_OUT_TYPE,Weight,Material_id,Master_Material_id,matrial_Type)
                    values ('" + txtSer.Text +
                                  "', '" + txtStore_ID.Text +
                                  "', '" + txtDocType.Text +
                                  "', '" + txt_cyear.Text +
                                  "', '" + 0 +
                                  "', '" + pOUT.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                                  "', '" + pOUT.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                                  "', '0','0' ,'0','0', '" + pOUT.dgv1.Rows[i].Cells["_newCost"].FormattedValue.ToString() +

                                 "','0' ,'0' ,'0','0', '" + txtDate.Value.ToString("yyyy-MM-dd HH:mm:ss") +
                                  "', '" + pOUT.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                                  "', '" + pOUT.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +
                                  "', '" + userID.Text +
                                  "', '" + countIN + pOUT.dgv1.Rows[i].Index +
                                  "', '" + pOUT.dgv1.Rows[i].Cells["_balance"].FormattedValue.ToString() +
                                  "', '" + 1 +
                                  "', '" + pOUT.dgv1.Rows[i].Cells["_cost"].FormattedValue.ToString() +
                                  "', '0', '0','O', '" + pOUT.dgv1.Rows[i].Cells["_weight"].FormattedValue.ToString() +
                                  "','" + pOUT.dgv1.Rows[i].Cells["_barcodeNo"].FormattedValue.ToString() +
                                  "','" + pIN.dgv1.Rows[0].Cells["_barcodeNo"].FormattedValue.ToString() +
                                  "','" + pOUT.dgv1.Rows[0].Cells["_itemType"].Value.ToString() + "') ";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = @"Update wh_main_master set local_cost = '" + pOUT.dgv1.Rows[i].Cells["_newCost"].FormattedValue.ToString() + "' where item_no = '" + pOUT.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() + "' ";
                            cmd.ExecuteNonQuery();
                        }
                    }


                    cmd.CommandText = @"Update wh_Serial set XTP ='" + txtSer.Text + "',XT='" + txtGenralSer.Text + "'  where Branch_code='" + txtStore_ID.Text
                         + "' and Cyear= '" + txt_cyear.Text + "' ";
                    cmd.ExecuteNonQuery();



                    trans.Commit();
                    IsNew = false;
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dal.close_1();
                }

            }
        }

        private void btn_FillData_Click(object sender, EventArgs e)
        {
            txtBranch.ID.Text =Properties.Settings.Default.BranchId;
            txtCost.ID.Text = "3103";
            txtProductionLine.SelectedValue = "001";
            txtItemType.SelectedValue = "F";
            txtShift.SelectedValue = "1";
            txtShiftMan.SelectedValue = "01";
            txtShiftEng.SelectedValue = "01";
            txtDocSer.Focus();

        }

        private void btn_searchProdction_Click(object sender, EventArgs e)
        {
            PL.frmSerch frm = new PL.frmSerch();
            frm.ShowDialog();
            showInvoice_1(frm.txtSearch.t.Text, txtDocType.Text);
        }
    }
}
