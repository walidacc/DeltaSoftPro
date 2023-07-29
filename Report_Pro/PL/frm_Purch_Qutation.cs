﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;

using Outlook = Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

namespace Report_Pro.PL
{
    public partial class frm_Purch_Qutation : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();
        Int32 m;

        public string clos_type;
        string btntype = "0";
        string frmType="ADD";

        public frm_Purch_Qutation()
        {
            InitializeComponent();


            FillComboCurrency();


            creatDattable();
            //resizeDG();
            getJorSer();
        }

        private void tabControlPanel2_Click(object sender, EventArgs e)
        {

        }

        private void FillComboCurrency()
        {
            DataTable dt_currency = dal.getDataTabl_1("select * from Wh_Currency");
            txtCurrency.DataSource = dt_currency;
            txtCurrency.ValueMember = "Currency_Code";
            txtCurrency.DisplayMember = "Currency_Name";
            txtCurrency.SelectedIndex = -1;
        }

        private void dGV_Item_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_braws_Click(object sender, EventArgs e)
        {
            try
            {
                clear_txtBoxs();
                PL.frm_search_items frm = new PL.frm_search_items();
                frm.ShowDialog();
                this.TxtId.Text = frm.dGV_pro_list.CurrentRow.Cells[0].Value.ToString();
                if (Properties.Settings.Default.lungh == "0")
                {
                    this.TxtDesc.Text = frm.dGV_pro_list.CurrentRow.Cells[2].Value.ToString();
                }
                else
                {
                    this.TxtDesc.Text = frm.dGV_pro_list.CurrentRow.Cells[3].Value.ToString();
                }
                this.txtUnit.Text = frm.dGV_pro_list.CurrentRow.Cells[6].Value.ToString();
                this.txtUnitWeight.Text = frm.dGV_pro_list.CurrentRow.Cells[4].Value.ToString().ToDecimal().ToString("n3");
                this.txtBalance.Text = frm.dGV_pro_list.CurrentRow.Cells[5].Value.ToString().ToDecimal().ToString("n1");
                //this.txtBalance.Text = (dal.getDataTabl("get_item_balance_", TxtId.Text, "", "0", dal.db1)).Rows[0][0].ToString().ToDecimal().ToString("n2");

                txtNote.Focus();
            }
            catch
            {
                return;
            }
        }

      

        void clear_texts()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedIndex = -1;
                    else if (control is DateTimePicker)
                        (control as DateTimePicker).Value = DateTime.Now;
                    else if (control is DevComponents.Editors.DoubleInput)
                        (control as DevComponents.Editors.DoubleInput).Value = 0;

                    else
                        func(control.Controls);
            };

            func(Controls);
            dt.Clear();
            dGV_Item.DataSource = null;
            dGV_Item.Columns.Clear();

        }

        void clear_txtBoxs()
        {
            TxtId.Clear();
            TxtDesc.Clear();
            txtNote.Clear();
            txtUnit.Clear();
            txtUnitWeight.Clear();
            TxtQty.Value = 0;
            txtBalance.Clear();
            txt_TotWeight.Clear();
            txtPrice.Value = 0;
            Tot_Price.Value = 0;
        }

            private void get_B_C()
        {
          
          
                DataTable dt_B_c = new DataTable();
                dt_B_c = dal.getDataTabl("getBalnceAndCost_", TxtId.Text, Uc_Branch.ID.Text,dal.db1);
            if (dt_B_c.Rows.Count > 0)
            {
                txtBalance.Text = dt_B_c.Rows[0][0].ToString().ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
            }
           else
            {
                txtBalance.Text = "0".ToDecimal().ToString("N" + Properties.Settings.Default.digitNo_);
            }                
                    
             
          
        }

        void clculat_amount()
        {
            try
            {
              txt_TotWeight.Text = (TxtQty.Text.ToDecimal() * txtUnitWeight.Text.ToDecimal()).ToString("N3");
              Tot_Price.Text= (TxtQty.Text.ToDecimal() * txtPrice.Text.ToDecimal()).ToString("N3");
            }
            catch
            {
                return;
            }
        }


        void resizeDG()
        {

            this.dGV_Item.Columns[0].Width = this.TxtId.Width;
            this.dGV_Item.Columns[1].Width = this.TxtDesc.Width;
            this.dGV_Item.Columns[2].Width = this.txtNote.Width;
            this.dGV_Item.Columns[3].Width = this.txtUnit.Width;
            this.dGV_Item.Columns[4].Width = this.txtUnitWeight.Width;
            this.dGV_Item.Columns[5].Width = this.TxtQty.Width;
            this.dGV_Item.Columns[6].Width = this.txtBalance.Width;
            this.dGV_Item.Columns[7].Width = this.txt_TotWeight.Width;
            this.dGV_Item.Columns[8].Width = this.txtPrice.Width;
            this.dGV_Item.Columns[9].Width = this.Tot_Price.Width;
            this.dGV_Item.Columns[10].Width = 50;
            for (int i = 0; i <= dGV_Item.Columns.Count - 1; i++)
                if (i != 8)
                { dGV_Item.Columns[i].ReadOnly = true; }
                foreach (DataGridViewRow row in this.dGV_Item.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                dGV_Item.EnableHeadersVisualStyles = false;
             
            }
           
        }
            void addrow_new()
        {
            DataRow r = dt.NewRow();
            r[0] = TxtId.Text;
            r[1] = TxtDesc.Text;
            r[2] = txtNote.Text;
            r[3] = txtUnit.Text;
            r[4] = txtUnitWeight.Text.ToDecimal().ToString("N3");
            r[5] = TxtQty.Text.ToDecimal().ToString("N0");
            r[6] = txtBalance.Text.ToDecimal().ToString("N1");
            r[7] = txt_TotWeight.Text.ToDecimal().ToString("N3");
            r[8] = txtPrice.Text.ToDecimal().ToString("N3");
            r[9] = Tot_Price.Text.ToDecimal().ToString("N3");


            dt.Rows.Add(r);
            dGV_Item.DataSource = dt;
            clear_txtBoxs();
            TxtId.Focus();
            total_inv();
            resizeDG();
        }

        void editrow()
        {
            dGV_Item.Rows[m].Cells[0].Value = TxtId.Text;
            dGV_Item.Rows[m].Cells[1].Value = TxtDesc.Text;
            dGV_Item.Rows[m].Cells[2].Value = txtNote.Text;
            dGV_Item.Rows[m].Cells[3].Value = txtUnit.Text;
            dGV_Item.Rows[m].Cells[4].Value = txtUnitWeight.Text.ToDecimal().ToString("N3");
            dGV_Item.Rows[m].Cells[5].Value = TxtQty.Text.ToDecimal().ToString("N0");
            dGV_Item.Rows[m].Cells[6].Value = txtBalance.Text.ToDecimal().ToString("N1");
            dGV_Item.Rows[m].Cells[7].Value = txt_TotWeight.Text.ToDecimal().ToString("N3");
            dGV_Item.Rows[m].Cells[8].Value = txtPrice.Text.ToDecimal().ToString("N3");
            dGV_Item.Rows[m].Cells[9].Value = Tot_Price.Text.ToDecimal().ToString("N3");


            total_inv();
            clear_txtBoxs();
            TxtId.Focus();
            resizeDG();

        }


        void creatDattable()
        {
           
                dt.Columns.Add("رقم الصنف");
                dt.Columns.Add(" اسم الصنف");
                dt.Columns.Add(" الوصف");
                dt.Columns.Add("الوحدة");
                dt.Columns.Add(" الوزن");
                dt.Columns.Add("الكمية");
                dt.Columns.Add("الرصيد");
                dt.Columns.Add("اجمالي الوزن");
                dt.Columns.Add("السعر");
                dt.Columns.Add("اجمالي السعر");

            dGV_Item.DataSource = dt;
          
        }

        private void total_inv()
        {

            totalQty.Text =
                (from DataGridViewRow row in dGV_Item.Rows
                 where row.Cells[5].FormattedValue.ToString() != string.Empty
                 select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString().ToDecimal().ToString("N0");
            totalWeight.Text =
                  (from DataGridViewRow row in dGV_Item.Rows
                   where row.Cells[7].FormattedValue.ToString() != string.Empty
                   select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum().ToString().ToDecimal().ToString("N3");
         TotalPrice.Text =
               (from DataGridViewRow row in dGV_Item.Rows
                where row.Cells[9].FormattedValue.ToString() != string.Empty
                select Convert.ToDouble(row.Cells[9].FormattedValue)).Sum().ToString().ToDecimal().ToString("N3");
        }

        private void TxtQty_KeyUp(object sender, KeyEventArgs e)
        {
            clculat_amount();
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtQty.Value!=0)
            {
                txtPrice.Focus();
            }
        }

        private void dGV_Item_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void TxtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtId.Text!="")
            {
                DataTable dt = dal.getDataTabl("get_product_name_", TxtId.Text,dal.db1);
                if (dt.Rows.Count > 0)
                {
                    TxtId.Text = dt.Rows[0][0].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        TxtDesc.Text = dt.Rows[0][2].ToString();
                    }
                    else
                    {
                        TxtDesc.Text = dt.Rows[0][3].ToString();
                    }
                    txtUnitWeight.Text = dt.Rows[0][4].ToString().ToDecimal().ToString("N3");
                    txtUnit.Text = dt.Rows[0][5].ToString();
                    txtBalance.Text = dt.Rows[0][6].ToString().ToDecimal().ToString("N1");
                   
                   
                    txtNote.Focus();


                }
                else
                {
                    btn_braws.PerformClick();
                }


            }
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtQty.Focus();
            }
        }

        private void groupPanel7_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel6_Click(object sender, EventArgs e)
        {

        }

        private void Uc_Branch_Load(object sender, EventArgs e)
        {
           
            //MessageBox.Show(Uc_Branch.ID.Text);
            if (frmType == "ADD")
            {
                DataTable dt_br = dal.getDataTabl_1("SELECT * FROM wh_BRANCHES  where Branch_code='"+ Uc_Branch.ID.Text + "'");

                if (dt_br.Rows.Count > 0)
                {
                    txt_Tel.Text = dt_br.Rows[0][21].ToString();
                    txt_Fax.Text = dt_br.Rows[0][22].ToString();
                    txtMobile.Text = "";
                    txtE_Fax.Text = "";
                    txt_Email.Text = dt_br.Rows[0][23].ToString();
                    txt_address.Text = dt_br.Rows[0][6].ToString();
                    txt_MainNote.Text = dt_br.Rows[0][28].ToString();
                   
                }

            }
            uC_Acc1.branchID.Text = Uc_Branch.ID.Text;
            txtMobile.Text = Uc_Branch.ID.Text;
        }

        private void getJorSer()
        {
            string serNo = dal.getDataTabl_1("select isnull(max(ser_no)+1,1) FROM Purchase_Qutation where Transaction_code='" + txt_transaction_code.Text+ "' and Branch_code ='"+ Uc_Branch.ID.Text+"' ").Rows[0][0].ToString();
            txt_serNo.Text = serNo;


        }

        private void BNew_Click(object sender, EventArgs e)
        {
            clear_texts();
            getJorSer();
           
            //BSave.Enabled = true;
            //BEdit.Enabled = false;
        }

        private void Btn_DelRow_Click(object sender, EventArgs e)
        {
            if (this.dGV_Item.SelectedRows.Count > 0)
            {
                dGV_Item.Rows.RemoveAt(this.dGV_Item.SelectedRows[0].Index);
                total_inv();
                foreach (DataGridViewRow row in this.dGV_Item.Rows)
                {
                    row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
                }
            }
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            Assembly a = Assembly.Load("Report_Pro");
            ResourceManager rm = new ResourceManager("Report_Pro.RPT.login_frm", a);

            if (Uc_Branch.ID.Text == string.Empty)
            {
                MessageBox.Show(rm.GetString("txtMes"), "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCurrency.SelectedIndex < 0)
            {
                MessageBox.Show("تأكد من العملة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt_acc = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no FROM wh_BRANCHES where BRANCH_code like '"+Properties.Settings.Default.BranchId+"%'");
            string Acc_main = dt_acc.Rows[0][1].ToString();
            string Acc_cash = dt_acc.Rows[0][2].ToString();

            DataTable dt_ = dal.getDataTabl_1(@"select P.*,A.MAIN_KM_CODE,a.MAIN_KM_DESC,b.KM_RATIO,b.KM_CODE FROM payer2 As P 
left join KM_MAIN_ACC_CODE as A on  ISNULL(NULLIF(P.KM_CODE_Sales, ''), 11) = A.MAIN_KM_CODE
left join  KM_ACC_CODE as b on b.KM_CODE = a.KM_CODE
where P.BRANCH_code like '" + uC_Acc1.branchID.Text.ToString() + "%' and P.ACC_NO = '" + uC_Acc1.ID.Text +
"' and(P.ACC_NO like '" + Acc_main + "%' or P.ACC_NO like'" + Acc_cash + "%') and P.t_final = '1'");

            if (dt_.Rows.Count < 1)
               
            {
                uC_Acc1.ID.Clear();
                MessageBox.Show("تأكد من المورد", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dGV_Item.Rows.Count < 1)
            {
                MessageBox.Show("تأكد من الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            test_Add_P_Qutation_Transaction();
            test_Add_P_Qutation();
            Add_P_Qutation();
            Add_P_Qutation_Transaction();
            MessageBox.Show("تم الحفظ بنجاح", "حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BSave.Enabled = false;
        }

        private void Add_P_Qutation()
        {
            dal.Execute("Add_P_Qutation_",txt_serNo.Text,Uc_Branch.ID.Text,txt_transaction_code.Text,
            txt_InvDate.Value.ToString("yy"), txt_InvDate.Value.Date,txt_Tel.Text,txt_Fax.Text,
            txt_Email.Text,txtMobile.Text,txtE_Fax.Text,txt_address.Text,txt_MainNote.Text,txt_RQ_ser.Text
            ,uC_Acc1.ID.Text,Convert.ToString(txtCurrency.SelectedValue),RQ_Date.Value.Date,dal.db1);
        }

        private void test_Add_P_Qutation()
        {
            dal.Execute_test("Add_P_Qutation_", txt_serNo.Text, Uc_Branch.ID.Text, txt_transaction_code.Text,
            txt_InvDate.Value.ToString("yy"), txt_InvDate.Value.Date, txt_Tel.Text, txt_Fax.Text,
            txt_Email.Text, txtMobile.Text, txtE_Fax.Text, txt_address.Text, txt_MainNote.Text, txt_RQ_ser.Text
            , uC_Acc1.ID.Text, Convert.ToString(txtCurrency.SelectedValue), RQ_Date.Value.Date, dal.db1);
        }


        private void Add_P_Qutation_Transaction()
        {
            for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
            {
                if (dGV_Item.Rows[i].Cells[0].Value != null && dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0 && dGV_Item.Rows[i].Cells[8].Value.ToString().ToDecimal() > 0)
                    dal.Execute("Add_P_Qutation_Transaction_", txt_serNo.Text, Uc_Branch.ID.Text, txt_transaction_code.Text,
                    txt_InvDate.Value.ToString("yy"), txt_InvDate.Value.Date, dGV_Item.Rows[i].Cells[0].Value, 
                    dGV_Item.Rows[i].Cells[2].Value, dGV_Item.Rows[i].Cells[3].Value, dGV_Item.Rows[i].Cells[4].Value, 
                    dGV_Item.Rows[i].Cells[5].Value, dGV_Item.Rows[i].Cells[6].Value, dGV_Item.Rows[i].Cells[7].Value,
                    dGV_Item.Rows[i].Cells[8].Value, dal.db1);
            }
        }

        private void test_Add_P_Qutation_Transaction()
        {
            for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
            {
                if (dGV_Item.Rows[i].Cells[0].Value != null && dGV_Item.Rows[i].Cells[5].Value.ToString().ToDecimal() > 0)
                    dal.Execute_test("Add_P_Qutation_Transaction_", txt_serNo.Text, Uc_Branch.ID.Text, txt_transaction_code.Text,
                    txt_InvDate.Value.ToString("yy"), txt_InvDate.Value.Date, dGV_Item.Rows[i].Cells[0].Value,
                    dGV_Item.Rows[i].Cells[2].Value, dGV_Item.Rows[i].Cells[3].Value, dGV_Item.Rows[i].Cells[4].Value,
                    dGV_Item.Rows[i].Cells[5].Value, dGV_Item.Rows[i].Cells[6].Value, dGV_Item.Rows[i].Cells[7].Value,
                    dGV_Item.Rows[i].Cells[8].Value, dal.db1);
            }
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            groupPanel2.BringToFront();
            groupPanel2.Visible = true;
            txtsearh_2.Focus();
          
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
          
            DataTable dt_RQ = dal.getDataTabl_1(@"SELECT A.*,b.*,m.descr,m.Descr_eng,m.Weight,m.Unit,Br.branch_name,Br.WH_E_NAME
            FROM Purchase_Qutation As A
            inner join Purchase_Qutation_Transaction As B
            on a.Branch_code = b.Branch_code and a.Transaction_code = b.TRANSACTION_CODE and a.Cyear = b.Cyear and a.Ser_no = b.SER_NO
            inner join wh_main_master as M on m.item_no = b.ITEM_NO
            inner join wh_BRANCHES as Br on Br.Branch_code = a.Branch_code
            inner Join payer2 As P on A.SupplierID = P.acc_no and A.Branch_code = P.Branch_code
            where A.ser_no = '"+ txtsearh_2.Text + "' ");
        if (dt_RQ.Rows.Count > 0)
            {
                frmType = "EDIT";
                clear_texts();
                txt_serNo.Text= dt_RQ.Rows[0][0].ToString();
                Uc_Branch.ID.Text = dt_RQ.Rows[0][1].ToString();
                txt_InvDate.Text = dt_RQ.Rows[0][4].ToString();
                txt_Tel.Text = dt_RQ.Rows[0][5].ToString();
                txt_Fax.Text= dt_RQ.Rows[0][6].ToString();
                txt_Email.Text = dt_RQ.Rows[0][7].ToString();
                txtMobile.Text = dt_RQ.Rows[0][8].ToString();
                txtE_Fax.Text = dt_RQ.Rows[0][9].ToString();
                txt_address.Text = dt_RQ.Rows[0][10].ToString();
                txt_RQ_ser.Text = dt_RQ.Rows[0][12].ToString();
                uC_Acc1.ID.Text= dt_RQ.Rows[0][13].ToString();
                txtCurrency.SelectedValue= dt_RQ.Rows[0][14].ToString();
                RQ_Date.Text = dt_RQ.Rows[0][15].ToString();

                dt.Clear();
                int i = 0;
                DataRow row = null;
               
                foreach (DataRow r in dt_RQ.Rows)
                {

                    row = dt.NewRow();
                    row[0] = dt_RQ.Rows[i][21].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        row[1] = dt_RQ.Rows[i][30].ToString();
                    }
                    else
                    {
                        row[1] = dt_RQ.Rows[i][31].ToString();
                    }
                    row[2] = dt_RQ.Rows[i][22].ToString();
                    row[3] = dt_RQ.Rows[i][23].ToString();
                    row[4] = dt_RQ.Rows[i][24].ToString().ToDecimal().ToString("N3");
                    row[5] = dt_RQ.Rows[i][25].ToString().ToDecimal().ToString("N0");
                    row[6] = dt_RQ.Rows[i][26].ToString().ToDecimal().ToString("N1");
                    row[7] = dt_RQ.Rows[i][27].ToString().ToDecimal().ToString("N3");
                    row[8] = dt_RQ.Rows[i][28].ToString().ToDecimal().ToString("N3");
                  //  row[9] = dt_RQ.Rows[i][28].ToString().ToDecimal().ToString("N3");
                    row[9] = (dt_RQ.Rows[i][25].ToString().ToDecimal() * dt_RQ.Rows[i][28].ToString().ToDecimal()).ToString("n3");
                    dt.Rows.Add(row);
                    i = i + 1;
                }

                dGV_Item.DataSource = dt;
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Edit";
                col.Name = "MyButton";
                dGV_Item.Columns.Add(col);
               

                resizeDG();
                total_inv();
                txtsearh_2.Text = "";
                groupPanel2.Visible = false;
                BSave.Enabled = false;
                BEdit.Enabled = true;

            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            groupPanel1.Visible = false;
        }

        private void Uc_Branch_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt_br = dal.getDataTabl_1("SELECT * FROM wh_BRANCHES  where Branch_code='" + Uc_Branch.ID.Text + "'");

            if (dt_br.Rows.Count > 0)
            {
                txt_Tel.Text = dt_br.Rows[0][21].ToString();
                txt_Fax.Text = dt_br.Rows[0][22].ToString();
                txtMobile.Text = "";
                txtE_Fax.Text = "";
                txt_Email.Text = dt_br.Rows[0][23].ToString();
                txt_address.Text = dt_br.Rows[0][6].ToString();
                txt_MainNote.Text = dt_br.Rows[0][28].ToString();
               
            }
            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSearch.Text !="")
            {
                btnOk.Focus();
            }
        }

      
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            RPT.Form1 frm = new RPT.Form1();

            RPT.rpt_R_Qutation rpt = new RPT.rpt_R_Qutation();
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();

            dt1 = dal.getDataTabl("get_P_Qutation_",txt_serNo.Text,Properties.Settings.Default.BranchId, dal.db1);
            ds.Tables.Add(dt1);
            ////ds.WriteXmlSchema("schema_rpt.xml");
            rpt.SetDataSource(ds);
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.WindowState = FormWindowState.Maximized;

            frm.ShowDialog();

        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            RPT.Form1 frm = new RPT.Form1();

            RPT.rpt_R_Qutation rpt = new RPT.rpt_R_Qutation();
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();

            dt1 = dal.getDataTabl("get_P_Qutation_", txt_serNo.Text,Properties.Settings.Default.BranchId, dal.db1);
            ds.Tables.Add(dt1);
            //////ds.WriteXmlSchema("schema_rpt.xml");
            rpt.SetDataSource(ds);
            frm.crystalReportViewer1.ReportSource = rpt;
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, (Application.StartupPath + "\\attachment.pdf"));
            Outlook.Application oApp = new Outlook.Application();
            Outlook.MailItem email = (Outlook.MailItem)(oApp.CreateItem(Outlook.OlItemType.olMailItem));
            email.To = "";
            //email.Attachments.Add(Application.StartupPath + "\\attachment.pdf");
            email.Subject = "Quotation Request : " + this.txt_serNo.Text;
            email.Display(true);

          
        }


        private void BEdit_Click(object sender, EventArgs e)
        {
            Assembly a = Assembly.Load("Report_Pro");
            ResourceManager rm = new ResourceManager("Report_Pro.RPT.login_frm", a);

            if (Uc_Branch.ID.Text == string.Empty)
            {
                MessageBox.Show(rm.GetString("txtMes"), "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCurrency.SelectedIndex < 0)
            {
                MessageBox.Show("تأكد من العملة", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt_acc = dal.getDataTabl_1(@"select Costmers_acc_no,Suppliers_acc_no,Cash_acc_no FROM wh_BRANCHES where BRANCH_code like '" + Properties.Settings.Default.BranchId + "%'");
            string Acc_main = dt_acc.Rows[0][1].ToString();
            string Acc_cash = dt_acc.Rows[0][2].ToString();

            DataTable dt_ = dal.getDataTabl_1(@"select P.*,A.MAIN_KM_CODE,a.MAIN_KM_DESC,b.KM_RATIO,b.KM_CODE FROM payer2 As P 
left join KM_MAIN_ACC_CODE as A on  ISNULL(NULLIF(P.KM_CODE_Sales, ''), 11) = A.MAIN_KM_CODE
left join  KM_ACC_CODE as b on b.KM_CODE = a.KM_CODE
where P.BRANCH_code like '" + uC_Acc1.branchID.Text.ToString() + "%' and P.ACC_NO = '" + uC_Acc1.ID.Text +
"' and(P.ACC_NO like '" + Acc_main + "%' or P.ACC_NO like'" + Acc_cash + "%') and P.t_final = '1'");
            if (dt_.Rows.Count < 1)

            {
                uC_Acc1.ID.Clear();
                MessageBox.Show("تأكد من المورد", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dGV_Item.Rows.Count < 1)
            {
                MessageBox.Show("تأكد من الاصناف", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            dal.Execute("Delet_P_Qutation_", txt_serNo.Text, Uc_Branch.ID.Text, txt_transaction_code.Text, dal.db1);
            Add_P_Qutation();
            Add_P_Qutation_Transaction();
            MessageBox.Show("تم تعديل البيانات بنجاح", "تعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_MainNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Fax_TextChanged(object sender, EventArgs e)
        {

        }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_R_Qutaion_Load(object sender, EventArgs e)
        {
           
        }

        private void dGV_Item_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           
            groupPanel1.BringToFront();
            groupPanel1.Visible = true;
            
            txtSearch.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtQty.Value>0 && TxtId.Text.Trim()!=""&&TxtDesc.Text.Trim()!="")
            {

                clculat_amount();

                if (btntype == "0")
                {
                    for (int i = 0; i <= dGV_Item.Rows.Count - 1; i++)
                    {
                        if (dGV_Item.Rows[i].Cells[0].Value.ToString() == TxtId.Text)
                        {
                            MessageBox.Show("هذا الصنف مضاف من قبل", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    addrow_new();
                    btntype = "0";

                }
                else if (btntype == "1")
                {
                    editrow();
                    btntype = "0";

                }

            }

        }

        private void dGV_Item_Click(object sender, EventArgs e)
        {
            int j = dGV_Item.CurrentCell.ColumnIndex;
            //-------------------------------------------------------------------//
            if (j == 10)
            {
                btntype = "1";
                m = dGV_Item.CurrentRow.Index;
                try
                {
                    TxtId.Text = dGV_Item.CurrentRow.Cells[0].Value.ToString();
                    TxtDesc.Text = dGV_Item.CurrentRow.Cells[1].Value.ToString();
                    txtNote.Text = dGV_Item.CurrentRow.Cells[2].Value.ToString();
                    txtUnit.Text = dGV_Item.CurrentRow.Cells[3].Value.ToString();
                    txtUnitWeight.Text = dGV_Item.CurrentRow.Cells[4].Value.ToString();
                    TxtQty.Text = dGV_Item.CurrentRow.Cells[5].Value.ToString();
                    txtBalance.Text = dGV_Item.CurrentRow.Cells[6].Value.ToString();
                    txt_TotWeight.Text = dGV_Item.CurrentRow.Cells[7].Value.ToString();
                    txtPrice.Text = dGV_Item.CurrentRow.Cells[8].Value.ToString().ToDecimal().ToString("N3");
                    TotalPrice.Text = dGV_Item.CurrentRow.Cells[9].Value.ToString().ToDecimal().ToString("N3");
                    TxtId.Focus();

                }

                catch
                {
                    return;
                }
            }
        }

        private void txtCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void txtCurrency_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_vactor = dal.getDataTabl_1("select * from Wh_Currency  where Currency_Code='" + txtCurrency.SelectedValue + "'");
                txt_Rate.Text = dt_vactor.Rows[0][2].ToString();

            }
            catch
            { txt_Rate.Text = "0"; }
         
        }

        private void txtCurrency_KeyUp(object sender, KeyEventArgs e)
        {
        
        }

        private void Uc_Acc_Load(object sender, EventArgs e)
        {

        }

        private void labelX11_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void txtsearh_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX16_Click(object sender, EventArgs e)
        {

        }

        private void labelX10_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            //frmType = "EDIT";

            DataTable dt_RQ = dal.getDataTabl_1(@"SELECT A.*,b.*,m.descr,m.Descr_eng,m.Weight,m.Unit,Br.branch_name,Br.WH_E_NAME
            FROM R_Qutation As A  inner join R_Qutation_Transaction As B  on a.Branch_code = b.Branch_code and a.Transaction_code = b.TRANSACTION_CODE and 
            a.Cyear = b.Cyear and a.Ser_no = b.SER_NO inner join wh_main_master as M on m.item_no = b.ITEM_NO inner join
            wh_BRANCHES as Br on Br.Branch_code = a.Branch_code 
            where A.ser_no = '" + txtSearch.Text + "' and a.Transaction_code = 'RQT'");
            if (dt_RQ.Rows.Count > 0)
            {
                clear_texts();
                txt_RQ_ser.Text = dt_RQ.Rows[0][0].ToString();
                Uc_Branch.ID.Text = dt_RQ.Rows[0][1].ToString();
                RQ_Date.Text = dt_RQ.Rows[0][4].ToString();
                txt_Tel.Text = dt_RQ.Rows[0][5].ToString();
                txt_Fax.Text = dt_RQ.Rows[0][6].ToString();
                txt_Email.Text = dt_RQ.Rows[0][7].ToString();
                txtMobile.Text = dt_RQ.Rows[0][8].ToString();
                txtE_Fax.Text = dt_RQ.Rows[0][9].ToString();
                txt_address.Text = dt_RQ.Rows[0][10].ToString();

                dt.Clear();
                int i = 0;
                DataRow row = null;
                foreach (DataRow r in dt_RQ.Rows)
                {

                    row = dt.NewRow();
                    row[0] = dt_RQ.Rows[i]["Item_no"].ToString();
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        row[1] = dt_RQ.Rows[i]["descr"].ToString();
                    }
                    else
                    {
                        row[1] = dt_RQ.Rows[i]["descr_eng"].ToString();
                    }
                    //row[2] = dt_RQ.Rows[i][18].ToString();
                    //row[3] = dt_RQ.Rows[i][19].ToString();
                    //row[4] = dt_RQ.Rows[i][20].ToString().ToDecimal().ToString("N3");
                    //row[5] = dt_RQ.Rows[i][21].ToString().ToDecimal().ToString("N0");
                    //row[6] = dt_RQ.Rows[i][22].ToString().ToDecimal().ToString("N1");
                    //row[7] = dt_RQ.Rows[i][23].ToString().ToDecimal().ToString("N3");

                    row[2] = dt_RQ.Rows[i]["item_description"].ToString();
                    row[3] = dt_RQ.Rows[i]["R_Unit"].ToString();
                    row[4] = dt_RQ.Rows[i]["R_weight"].ToString().ToDecimal().ToString("N3");
                    row[5] = dt_RQ.Rows[i]["R_Qty"].ToString().ToDecimal().ToString("N0");
                    row[6] = dt_RQ.Rows[i]["R_balance"].ToString().ToDecimal().ToString("N1");
                    row[7] = dt_RQ.Rows[i]["R_totalWeight"].ToString().ToDecimal().ToString("N3");


                    dt.Rows.Add(row);
                    i = i + 1;
                }

            
                 dGV_Item.DataSource = dt;
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Edit";
                col.Name = "MyButton";
                dGV_Item.Columns.Add(col);
                this.dGV_Item.Columns[9].Width = 50;

                resizeDG();
                total_inv();
                txtSearch.Text = "";
                groupPanel1.Visible = false;
                BSave.Enabled = true;
                BEdit.Enabled = false;
                getJorSer();

            }
            else
            {
                MessageBox.Show("تاكد من الرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtsearh_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtsearh_2.Text != "")
            {
                btnOk_2.Focus();
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            clculat_amount();
        }

        private void dGV_Item_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = dGV_Item.CurrentCell.RowIndex;
            int col = dGV_Item.CurrentCell.ColumnIndex;
            //-------------------------------------------------------------------//
            if (col == 8)
            {
                try
                {
                    dGV_Item.Rows[row].Cells[9].Value = (dGV_Item.Rows[row].Cells[8].Value.ToString().ToDecimal() * dGV_Item.Rows[row].Cells[5].Value.ToString().ToDecimal()).ToString("n3") ;

                    total_inv();

                }

                catch
                {
                    return;
                }
            }
        }

        private void btnCancel_2_Click(object sender, EventArgs e)
        {
            txtsearh_2.Text = "";
            groupPanel2.Visible = false;
        }

        private void labelX19_Click(object sender, EventArgs e)
        {

        }

        private void labelX21_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete it?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txt_serNo.Text != "")
                {
                    dal.Execute_1(@"delete from  Purchase_Qutation_Transaction where ser_no='" + txt_serNo.Text + "'");
                    dal.Execute_1(@"delete from  Purchase_Qutation where ser_no='" + txt_serNo.Text + "'");
                    MessageBox.Show("The quotation has been deleted successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void totalWeight_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
