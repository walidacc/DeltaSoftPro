using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing; using System.Linq;
using System.Globalization;

using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;


//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Graphics;
//using Syncfusion.Pdf.Parsing;
//using Syncfusion.Pdf.Security;


namespace Report_Pro.PL
{
    public partial class frm_Preforma : frm_Master
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        DataTable dt = new DataTable();
        DataTable dt_P = new DataTable();
        string _branchCode = Properties.Settings.Default.BranchId;
        Assembly a = Assembly.Load("Report_Pro");
        CultureInfo cul;

        public frm_Preforma()
        {


            InitializeComponent();


            comboBox1.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            comboBox1.SelectedItem = DateTime.Now.Year;





            creatDattable();
            //resizeDG();




            if (Properties.Settings.Default.lungh == "0")
            {
                cul = new CultureInfo("ar");
            }
            else
            {
                cul = new CultureInfo("en");
            }


            txtCurrency.DataSource = dal.getDataTabl_1("SELECT * FROM " + dal.db1 + ".dbo.Wh_Currency");

            txtCurrency.ValueMember = "Currency_Code";
            if (Properties.Settings.Default.lungh == "ar")
            {
                txtCurrency.DisplayMember = "Currency_Name";
            }
            else
            {
                txtCurrency.DisplayMember = "Currency_Name";

            }
            txtCurrency.SelectedIndex = -1;

            txtCrago_Method.DataSource = dal.getDataTabl_1("SELECT DeLEVRY_CODE,DeLEVRY_Name,DELEVER_NAME_E FROM WH_PO_DELEVRY_CODE");
            txtCrago_Method.ValueMember = "DeLEVRY_CODE";
            if (Properties.Settings.Default.lungh == "ar")
            {
                txtCrago_Method.DisplayMember = "DeLEVRY_Name";
            }
            else
            {
                txtCrago_Method.DisplayMember = "DELEVER_NAME_E";

            }
            txtCrago_Method.SelectedIndex = -1;



            txtRegion.DataSource = dal.getDataTabl_1("SELECT * FROM REGIONS");

            txtRegion.ValueMember = "REGION_code";
            if (Properties.Settings.Default.lungh == "0")
            {
                txtRegion.DisplayMember = "REGION_name";
            }
            else
            {
                txtRegion.DisplayMember = "REGION_E_NAME";

            }
            txtRegion.SelectedIndex = -1;


            txtArivePort.DataSource = dal.getDataTabl_1("SELECT * FROM Cus_Ports");

            txtArivePort.ValueMember = "Port_code";
            if (Properties.Settings.Default.lungh == "0")
            {
                txtArivePort.DisplayMember = "Port_name";
            }
            else
            {
                txtArivePort.DisplayMember = "Port_E_name";

            }
            txtArivePort.SelectedIndex = -1;

            txtFactory.DataSource = dal.getDataTabl_1("SELECT id,Name,NameE FROM SuppFactoreis");
            txtFactory.ValueMember = "id";
            if (Properties.Settings.Default.lungh == "0")
            {
                txtFactory.DisplayMember = "Name";
            }
            else
            {
                txtFactory.DisplayMember = "NameE";

            }
            txtFactory.SelectedIndex = -1;

            txt_InvSM.Text = Program.salesman;
            userID.Text = Program.userID;

        }

        public override void New()
        {

            addNew();
            base.New();
        }

        public override void Save()
        {


            if (IsDataValid() == false)
            {
                return;
            }
            if (IsGridValid() == false)
            {
                return;
            }



            DataTable dt_ = dal.getDataTabl_1(@"select * from wh_inv_data_Ext_Perform where ser_no='" + txtId.Text + "' and Transaction_code='" + Doc_Type.Text + "' and Branch_code='" + txtBranch.ID.Text + "' and Cyear='" + txtcyear.Text + "' ");
            if (dt_.Rows.Count > 0)
            {
                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;
                try
                {

                    cmd.CommandText = @"UPDATE wh_inv_data_Ext_Perform set 
                    Ser_no                  = '" + txtId.Text +
                    "',Branch_code          = '" + txtBranch.ID.Text +
                    "',Transaction_code     = '" + Doc_Type.Text +
                    "',Cyear                = '" + txtcyear.Text +
                    "',Sanad_no             = '0'" +
                    ",G_date                = '" + txtDate.Value.ToString("yyyy-MM-dd") +
                    "',ACC_TYPE             = 'A'" +
                    ",Acc_no                = '" + txtSupplier.ID.Text +
                    "',Acc_Branch_code      = '" + txtBranch.txtAccBranch.Text +
                    "',Payment_Type         = '2' " +
                    ",Sales_man_Id          = '" + Cost_.ID.Text +
                    "',User_id              = '" + userID.Text +
                    "',NetAmount            = '" + txtAmount.Text.ToDecimal() +
                     "',Preforma_Qty        = '" + txtQty.Text.ToDecimal() +
                    "', Inv_Notes           = '" + txtMatrails.Text +
                    "',LC_NO                = '" + txtLcNo.Text +
                    "',LC_ACC_NO            = '" + txtLcAcc.ID.Text +
                    "',Perform_invoice      = '" + txtProforma.Text +
                    "',Perform_invoice_date = '" + txtProformaDate.Value.ToString("yyyy-MM-dd") +
                    "',Cargo_date           = '" + LShipDate.Value.ToString("yyyy-MM-dd") +
                    "',Cargo_port           = '" + txtCrago_Port.Text +
                    "',Arrival_port         = '" + Convert.ToString(txtArivePort.SelectedValue) +
                    "',Catgo_Media          = '" + txtCrago_Media.Text +
                    "',cargo_method         = '" + Convert.ToString(txtCrago_Method.SelectedValue) +
                    "',Cargo_notes1         = '" + txtCragoNote1.Text +
                    "',Cargo_notes2         = '" + txtCragoNote2.Text +
                    "',Estihkak_Dayes       = '" + AcceptDays.Value +
                    "',Lc_Date              = '" + OpenDate.Value.ToString("yyyy-MM-dd") +
                    "',Paper_Arival_Notes   = ''" +
                    ",Country               = '" + txtFactory.Text +
                    "',Factory_code          = '" + Convert.ToString(txtFactory.SelectedValue) +
                    "',Factory              = '" + Convert.ToString(txtRegion.SelectedValue) +
                    "',LC_EXPIRE_DATE       =  '" + ExpiryDate.Value.ToString("yyyy-MM-dd") +
                    "',LC_STOPED            = '" + (ch_Close.Checked ? "1" : "0") +
                    "',Costmer_No            = '" + Bank_.ID.Text +
                    "', RequstedBy =   '"+Requst_Persson.ID.Text+
                    "', ReviewBy =     '"+Confirm_Persson.ID.Text+
                    "', ApprovedBy =   '"+Authorized_Persson.ID.Text+
                    "',Inv_no = '' " +
                    "where Ser_no =  '" + txtId.Text + "' and Branch_code = '" + txtBranch.ID.Text + "' and  Transaction_code = '" + Doc_Type.Text + "' and Cyear = '" + txtcyear.Text + "' ";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"Delete from wh_MATERIAL_TRANSACTION_Ext_Perform where Ser_no = '" + txtId.Text + "' and Branch_code = '" + txtBranch.ID.Text + "' and  Transaction_code = '" + Doc_Type.Text + "' and Cyear = '" + txtcyear.Text + "' ";
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                    {
                        if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                           && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                           && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                            )
                        {

                            cmd.CommandText = @"INSERT INTO wh_MATERIAL_TRANSACTION_Ext_Perform        
                                (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO,ITEM_NO,QTY_ADD,QTY_TAKE,
                                total_disc,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Forign_price,Local_Price,FORIN_TYPE,
                                USER_ID,main_counter,balance,Currancy_Change_Factor,Backege,GAMAREK,Notes, K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,QTY_ADD_Ton,QTY_TAKE_Ton)
                                values ( '" + txtId.Text + "', '" + txtBranch.ID.Text + "', '" + Doc_Type.Text + "', '" + txtcyear.Text + "' ,'0','" +
                           invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                           "','" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                           "','0','0','0','0','0','" +
                            txtDate.Value.ToString("yyyy/MM/dd HH: mm:ss") +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString().ToDecimal() * txtRate.Text.ToDecimal() +
                            "','" + Convert.ToString(txtCurrency.SelectedValue) +
                            "','" + userID.Text +
                            "','" + invGrid1.dgv1.Rows[i].Index +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_balance"].FormattedValue.ToString() +
                            "','" + txtRate.Text.ToDecimal() +
                            "','1','0','" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_vat"].FormattedValue.ToString().ToDecimal() + 
                            "','0','" + invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value.ToString().ToDecimal() + "','0')";

                            cmd.ExecuteNonQuery();

                        }

                    }

                    trans.Commit();
                    MessageBox.Show(dal.rm.GetString("msgEdit", dal.cul), dal.rm.GetString("msgEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dal.sqlconn_1.Close();
                }

            }

            else
            {
                SqlCommand cmd = dal.sqlconn_1.CreateCommand();
                SqlTransaction trans;
                trans = dal.sqlconn_1.BeginTransaction();
                cmd.Connection = dal.sqlconn_1;
                cmd.Transaction = trans;

                try
                {
                    cmd.CommandText = @"insert into wh_inv_data_Ext_Perform (Ser_no,Branch_code,Transaction_code,Cyear,Sanad_no
                ,G_date,ACC_TYPE,Acc_no,Acc_Branch_code,Payment_Type
                ,Sales_man_Id,User_id,LC_NO,LC_ACC_NO,Perform_invoice
                ,Perform_invoice_date,Cargo_date,Cargo_port,Arrival_port,Catgo_Media
                ,cargo_method,Cargo_notes1,Cargo_notes2,Estihkak_Dayes,Lc_Date
                ,Paper_Arival_Notes,Country,Factory_code,Factory,LC_EXPIRE_DATE,LC_STOPED,Costmer_No,RequstedBy,ReviewBy,ApprovedBy,Preforma_Qty,Inv_no)
                values('" + txtId.Text + "', '" + txtBranch.ID.Text + "', '" + Doc_Type.Text + "','" + txtcyear.Text +
                "','0','" + txtDate.Value.ToString("yyyy-MM-dd") + "', 'A','" + txtSupplier.ID.Text +
                "','" + txtBranch.txtAccBranch.Text + "', '2','" + Cost_.ID.Text + "', '" + userID.Text +
                "','" + txtLcNo.Text + "', '" + txtLcAcc.ID.Text + "', '" + txtProforma.Text +
                "', '" + txtProformaDate.Value.ToString("yyyy-MM-dd") + "', '" + LShipDate.Value.ToString("yyyy-MM-dd") +
                "', '" + txtCrago_Port.Text + "','" + Convert.ToString(txtArivePort.SelectedValue) + "', '" + txtCrago_Media.Text +
                "', '" + Convert.ToString(txtCrago_Method.SelectedValue) + "', '" + txtCragoNote1.Text + "', '" + txtCragoNote2.Text +
                "', '" + AcceptDays.Value + "', '" + OpenDate.Value.ToString("yyyy-MM-dd") + "', '','" + txtFactory.Text + "' ,'" + Convert.ToString(txtFactory.SelectedValue) + "' , '" + Convert.ToString(txtRegion.SelectedValue) + "','" + ExpiryDate.Value.ToString("yyyy-MM-dd") + "','" +
                (ch_Close.Checked ? "1" : "0") + "','" + Bank_.ID.Text + "','" + Requst_Persson.ID.Text + "','" + Confirm_Persson.ID.Text + 
                "','" + Authorized_Persson.ID.Text +"','"+txtQty.Text.ToDecimal()+"','')";
                                                                            
                    cmd.ExecuteNonQuery();


                    for (int i = 0; i <= invGrid1.dgv1.Rows.Count - 1; i++)
                    {
                        if (invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() != string.Empty
                           && invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() != string.Empty
                           && invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() != string.Empty
                            )
                        {

                            cmd.CommandText = @"INSERT INTO wh_MATERIAL_TRANSACTION_Ext_Perform        
                                (SER_NO,Branch_code,TRANSACTION_CODE,Cyear,SANAD_NO,ITEM_NO,QTY_ADD,QTY_TAKE,
                                total_disc,DISC_R,DISC_R2,DISC_R3,G_DATE,Unit,Forign_price,Local_Price,FORIN_TYPE,
                                USER_ID,main_counter,balance,Currancy_Change_Factor,Backege,GAMAREK,Notes, K_M_TYPE_ITEMS,TAX_IN,TAX_OUT,QTY_ADD_Ton,QTY_TAKE_Ton)
                                values ( '" + txtId.Text + "', '" + txtBranch.ID.Text + "', '" + Doc_Type.Text + "', '" + txtcyear.Text + "' ,'0','" +
                           invGrid1.dgv1.Rows[i].Cells["_code"].FormattedValue.ToString() +
                           "','" + invGrid1.dgv1.Rows[i].Cells["_qty"].FormattedValue.ToString() +
                           "','0','0','0','0','0','" +
                            txtDate.Value.ToString("yyyy/MM/dd HH: mm:ss") +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_unit"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_price"].FormattedValue.ToString().ToDecimal() * txtRate.Text.ToDecimal() +
                            "','" + Convert.ToString(txtCurrency.SelectedValue) +
                            "','" + userID.Text +
                            "','" + invGrid1.dgv1.Rows[i].Index +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_balance"].FormattedValue.ToString() +
                            "','" + txtRate.Text.ToDecimal() +
                            "','1','0','" + invGrid1.dgv1.Rows[i].Cells["_addDescription"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_KmCode"].FormattedValue.ToString() +
                            "','" + invGrid1.dgv1.Rows[i].Cells["_vat"].FormattedValue.ToString().ToDecimal() +
                            "','0','" + invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value.ToString().ToDecimal() + "','0')";

                            cmd.ExecuteNonQuery();
                        }

                    }




                    cmd.CommandText = @"UPDATE  wh_Serial SET  PER= '" + txtId.Text + "' WHERE Branch_code = '" + txtBranch.ID.Text + "' and Cyear='" + txtDate.Value.ToString("yy") + "' ";
                    cmd.ExecuteNonQuery();


                    trans.Commit();
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dal.sqlconn_1.Close();
                }


            }





            base.Save();
        }

        public override void Search()
        {
            groupBox1.Visible = true;
            txtsearch.Focus();
            base.Search();
        }

        public override void Attachment()
        {
            Frm_uploadImage frmUpload = new Frm_uploadImage();
            frmUpload.p_id = txtLcNo.Text;
            frmUpload.branchID = Properties.Settings.Default.BranchId;
            frmUpload.ShowDialog();
            base.Attachment();
        }

        public override void Report()
        {
            RPT.frm_statment_Rpt frm = new RPT.frm_statment_Rpt();
            frm.UC_Acc1.ID.Text = txtLcAcc.ID.Text;
            frm.ShowDialog();
            base.Report();
        }

        public override void Print()
        {
            groupPrint.Visible = true;
            base.Print();
        }

        private void printTons()
        {
            DataSet ds = new DataSet();

            get_data(txtId.Text, txtBranch.ID.Text, comboBox1.Text.Substring(comboBox1.Text.Length - 2), "PER");

            ds.Tables.Add(dt_P);
            //ds.WriteXmlSchema("schema_rpt.xml");
            RPT.Form1 frm = new RPT.Form1();
            //RPT.rpt_Preform_Print_Ton rpt_P = new RPT.rpt_Preform_Print_Ton();
            RPT.rpt_Purchase_Order_EX__Ton rpt_P = new RPT.rpt_Purchase_Order_EX__Ton();

            rpt_P.SetDataSource(ds);
            //if (Properties.Settings.Default.lungh == "0")
            //{
            //    rpt_P.DataDefinition.FormulaFields["doc_title"].Text = "'عقد مشتريات";
            //}
            //else
            //{
                rpt_P.DataDefinition.FormulaFields["doc_title"].Text = "'Purchase Contract'";
            //}

            rpt_P.DataDefinition.FormulaFields["Currency_"].Text = "'" + dt_P.Rows[0]["FORIN_TYPE"] + "'";
            rpt_P.DataDefinition.FormulaFields["PrintUser"].Text = "'" + Program.salesman + "'";
            frm.crystalReportViewer1.ReportSource = rpt_P;
            frm.ShowDialog();
            ////ToWord toWord = new ToWord(Math.Abs(Math.Round(dt_P.Rows[0][1].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
            ////rpt_P.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";

        }

        private void printPeaces()
        {
            DataSet ds = new DataSet();

            get_data(txtId.Text, txtBranch.ID.Text, comboBox1.Text.Substring(comboBox1.Text.Length - 2), "PER");

            ds.Tables.Add(dt_P);
            //ds.WriteXmlSchema("schema_rpt.xml");
            RPT.Form1 frm = new RPT.Form1();
            RPT.rpt_Purchase_Order_EX__Peces rpt_P = new RPT.rpt_Purchase_Order_EX__Peces();
            
            rpt_P.SetDataSource(ds);
            ////rpt_P.SetDataSource(dal.getDataTabl("get_invDetails", txt_InvNu.Text, txt_transaction_code.Text, txt_InvDate.Value.Year.ToString()));
            //rpt_P.SetParameterValue("h_pic", Convert.ToInt32(Factory_Paper.Checked));
            //if (Properties.Settings.Default.lungh == "0")
            //{
            //    rpt_P.DataDefinition.FormulaFields["doc_title"].Text = "'عقد مشتريات'";
            //}
            //else
            //{
                rpt_P.DataDefinition.FormulaFields["doc_title"].Text = "'Purchase Contract'";
            //}

            rpt_P.DataDefinition.FormulaFields["Currency_"].Text = "'" + dt_P.Rows[0]["FORIN_TYPE"] + "'";
            rpt_P.DataDefinition.FormulaFields["PrintUser"].Text = "'" +Program.salesman + "'";

            frm.crystalReportViewer1.ReportSource = rpt_P;
            frm.ShowDialog();
            //ToWord toWord = new ToWord(Math.Abs(Math.Round(dt_P.Rows[0][1].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
            //rpt_P.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";


        }

        private void currencyRate(DevComponents.Editors.DoubleInput txt1, string currencyId)
        {
            //try
            //{
            DataTable dtReate = dal.getDataTabl_1("SELECT Change_Factor  FROM Wh_Currency where Currency_Code ='" + currencyId + "'");
            if (dtReate.Rows.Count > 0)
            {
                txt1.Value = Convert.ToDouble(dtReate.Rows[0][0].ToString());
            }
            else
            {
                txt1.Value = 0;
            }
            //}
            //catch
            //{

            //}

        }

        private void get_invSer()
        {
            //try
            //{
            DataTable dtSer = dal.getDataTabl_1(@"select isnull(PER+1,1) from wh_Serial where Branch_code= '" + txtBranch.ID.Text + "' and Cyear='" + txtcyear.Text + "'");
            if (dtSer.Rows.Count > 0)
            {
                txtId.Text = dtSer.Rows[0][0].ToString();
            }
            else
            {
                txtId.Text = "1";
            }

            //}
            //catch { }


        }

        private void updateSer()
        {
            //try
            //{
            DataTable dtSer = dal.getDataTabl_1(@"select isnull(per+1,1) from wh_Serial where Branch_code= '" + txtBranch.ID.Text + "' and Cyear='" + txtcyear.Text + "'");
            if (dtSer.Rows.Count > 0)
            {
                dal.Execute_1(@"UPDATE  wh_Serial SET  PER= '" + txtId.Text + "' WHERE Branch_code = '" + txtBranch.ID.Text + "' and Cyear='" + txtDate.Value.ToString("yy") + "' ");

            }
            else
            {
                dal.Execute_1(@"INSERT INTO wh_Serial (Branch_code,Cyear,PER) Values('" + txtBranch.ID.Text + "' ,'" + txtDate.Value.ToString("yy") + "','" + txtId.Text + "')");

                //}
                //catch { }


            }

        }

        void creatDattable()
        {
            dt.Columns.Add("رقم الصنف");
            dt.Columns.Add(" اسم الصنف");
            dt.Columns.Add(" الوصف");
            dt.Columns.Add(" الوحدة");
            dt.Columns.Add("الوزن");
            dt.Columns.Add(" الكمية");
            dt.Columns.Add("السعر");
            dt.Columns.Add("سعر الطن");
            dt.Columns.Add(" الاجمالي");
            dt.Columns.Add("الخصم");
            dt.Columns.Add("الصافي");
            dt.Columns.Add("نسبة الضريبة");
            dt.Columns.Add("مبلغ الضريبة");
            dt.Columns.Add("اجمالي الوزن");
            dt.Columns.Add("الرصيد");
            dt.Columns.Add("التكلفة");
            dt.Columns.Add("كود القيمة المضافة");
            // dGV_Item.DataSource = dt;
        }


        private void ClearTextBoxes()
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
                    else if (control is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                        (control as DevComponents.Editors.DateTimeAdv.DateTimeInput).Text = "";
                    else if (control is DataGridView)
                        (control as DataGridView).DataSource = null;
                    else if (control is FlowLayoutPanel)
                        (control as FlowLayoutPanel).Controls.Clear();
                    else if (control is DevComponents.DotNetBar.Controls.CheckBoxX)
                        (control as DevComponents.DotNetBar.Controls.CheckBoxX).Checked = false;

                    else
                        func(control.Controls);
            };

            func(Controls);


            // inv_Grid1.flowLayoutPanel1.Controls.Clear();

        }

        private void addNew()
        {
            ClearTextBoxes();

            txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            txtSupplier.txtMainAcc.Text = "234";
            txtSupplier.txtFinal.Text = "1";
            //txtLcAcc.txtMainAcc.Text = "";
            txtLcAcc.txtFinal.Text = "1";
            Bank_.txtMainAcc.Text = "1221";
            Bank_.txtFinal.Text = "1";
            txtBranch.txtTfinal.Text = "1";
            Doc_Type.Text = "PER";
            txtDate.Value = DateTime.Today;
            txtcyear.Text = Properties.Settings.Default.C_year;
            invGrid1.dgv1.Rows.Clear();
            get_invSer();
            
            txtBranch.Enabled = true;

        }
        private void txtSupplier_Load(object sender, EventArgs e)
        {

            DataTable dtSupp = dal.getDataTabl_1("select adress,resp_name,COSTMER_K_M_NO,phone_no,E_MAIL from payer2 where acc_no='" + txtSupplier.ID.Text + "' and BRANCH_code='" + txtSupplier.branchID.Text + "'");
            if (dtSupp.Rows.Count > 0)
            {
                txtAddress.Text = dtSupp.Rows[0]["adress"].ToString();
                txtSuppContact.Text = dtSupp.Rows[0]["resp_name"].ToString();
                txtSuppVAT.Text = dtSupp.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtSuppPhone.Text = dtSupp.Rows[0]["phone_no"].ToString();
                txtSuppEmail.Text = dtSupp.Rows[0]["E_MAIL"].ToString();
                Vat_Class.Text = txtSupplier.KM_Code_Purch.Text;
                Vat_Class_Desc.Text = txtSupplier.KM_Desc_Purch.Text;
                Acc_Vat_Rate.Text = txtSupplier.KM_Ratio_Purch.Text;
                invGrid1.txtAccVat_Rate.Text = txtSupplier.KM_Ratio_Purch.Text;

            }
            else
            {
                txtAddress.Clear();
                txtSuppContact.Clear();
                txtSuppVAT.Clear();
                txtSuppPhone.Clear();
                txtSuppEmail.Clear();
                Vat_Class.Clear();
                Vat_Class_Desc.Clear();
                Acc_Vat_Rate.Clear();
                invGrid1.txtAccVat_Rate.Clear();
            }
            //foreach (MyControls.Inv_Row r in inv_Grid1.flowLayoutPanel1.Controls)
            //{
            //    if (Doc_Type.Text == "PER")
            //    {
            //        r.VatAccRate.Text = "0";
            //    }
            //    else
            //    {
            //        r.VatAccRate.Text = Acc_Vat_Rate.Text;
            //    }
            //    r.VatValue.Text = ((r.VatRate.Text.ToDecimal() <= r.VatAccRate.Text.ToDecimal() ? r.VatRate.Text : r.VatAccRate.Text).ToDecimal() * r.Txtvalue.Text.ToDecimal()).ToString("N" + dal.digits_);

            //}
            //inv_Grid1.total_inv();
        }


        private void Currency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCurrency.Text != string.Empty)
            {
                txtAmount.Focus();
            }

        }

        private void AcceptDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && AcceptDays.Text != string.Empty)
            {
                OpenDate.Focus();

            }
        }

        private void Amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAmount.Text != string.Empty)
            {
                AcceptDays.Focus();

            }
        }

        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                e.Handled = true;
            }
        }

        private void AcceptDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                e.Handled = true;
            }
        }

        private void OpenDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                ExpiryDate.Focus();
            }
        }

        private void ExpiryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                LShipDate.Focus();
            }
        }

        private void frmLcs_Load(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
             btnPrint.Visible = true;
            btnStatment.Visible = true;

            txtBranch.ID.Text = Properties.Settings.Default.BranchId;
            txtLcAcc.branchID.Text = txtBranch.txtAccBranch.Text;
            Bank_.branchID.Text = txtBranch.txtAccBranch.Text;
            txtSupplier.branchID.Text = txtBranch.txtAccBranch.Text;
            txtSupplier.txtMainAcc.Text = "234";
            txtSupplier.txtFinal.Text = "1";
            //txtLcAcc.txtMainAcc.Text = "";
            txtLcAcc.txtFinal.Text = "1";
            Bank_.txtMainAcc.Text = "1221";
            Bank_.txtFinal.Text = "1";
            txtBranch.txtTfinal.Text = "1";
            txtDate.Value = DateTime.Today;
            txtcyear.Text = Properties.Settings.Default.C_year;
            get_invSer();

        }

        private void txtBranch_Load(object sender, EventArgs e)
        {
            txtLcAcc.branchID.Text = txtBranch.txtAccBranch.Text;
            Bank_.branchID.Text = txtBranch.txtAccBranch.Text;
            txtSupplier.branchID.Text = txtBranch.txtAccBranch.Text;
            get_invSer();
            if (txtBranch.ID.Text == "A1011" || txtBranch.ID.Text == "A1021")
            {
                Factory_Paper.Checked = true;
            }
            else
            {
                Company_Paper.Checked = true;
            }
        }

        bool IsDataValid()
        {

            if (txtBranch.ID.Text.Trim() == string.Empty)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Branch", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBranch.ID.Focus();
                return false;

            }
            else if (txtSupplier.ID.Text.Trim() == string.Empty)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Account", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSupplier.ID.Focus();
                return false;
            }
            //else if (txtLcAcc.ID.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show(dal.rm.GetString("msgError") + "Lc Account", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtLcAcc.ID.Focus();
            //    return false;
            //}

            else if (Cost_.ID.Text.Trim() == string.Empty)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "User", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cost_.ID.Focus();
                return false;
            }

            else if (txtRegion.SelectedIndex < 0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Region", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegion.Focus();
                return false;
            }

            else if (txtFactory.SelectedIndex<0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Factory", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFactory.Focus();
                return false;
            }

            else if (txtProforma.Text.Trim() == string.Empty)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Proforma No.", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProforma.Focus();
                return false;
            }
            else if (txtCurrency.SelectedIndex < 0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Currency", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrency.Focus();
                return false;
            }


            else if (txtRate.Value <= 0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Currency Rate", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate.Focus();
                return false;
            }
            else if (AcceptDays.Value < 0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Accept Days", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                AcceptDays.Focus();
                return false;
            }

            else if (dal.IsDateTime(OpenDate.Text) == false)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Isue Date", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenDate.Focus();
                return false;
            }

            else if (dal.IsDateTime(LShipDate.Text) == false)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "ShipDate", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                LShipDate.Focus();
                return false;
            }

            else if (dal.IsDateTime(ExpiryDate.Text) == false)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Expiry Date", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExpiryDate.Focus();
                return false;
            }

            else if (dal.IsDateTime(txtProformaDate.Text) == false)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Proforma Date", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProformaDate.Focus();
                return false;
            }

            else if (txtCrago_Method.SelectedIndex < 0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Shipping Tearms", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabcontrol1.SelectedTab = tabDelevery;
                txtCrago_Method.Focus();
                return false;
            }

            else if (txtArivePort.SelectedIndex < 0)
            {
                MessageBox.Show(dal.rm.GetString("msgError") + "Shipp To ", dal.rm.GetString("msgError_H"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabcontrol1.SelectedTab = tabDelevery;
                txtArivePort.Focus();
                return false;

            }

            else
            {
                return true;
            }

        }

        bool IsGridValid()
        {

            int countR = 0;

            foreach (DataGridViewRow r in invGrid1.dgv1.Rows)
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

        private void btn_Cancl_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void get_data(string ser_, string branch_, string year_, string transaction_)
        {
            
                dt_P = dal.getDataTabl_1(@"SELECT A.Ser_no,A.Branch_code,A.Transaction_code,A.Cyear,A.G_date,A.ACC_TYPE,A.Acc_no,A.Acc_Branch_code
            ,A.Payment_Type,A.Sales_man_Id,A.User_id,A.LC_NO,A.LC_ACC_NO,A.Perform_invoice,A.Perform_invoice_date
            ,A.Cargo_date,A.Cargo_port,A.Arrival_port,A.cargo_method,A.Cargo_notes1,A.Cargo_notes2,A.Catgo_Media,A.Estihkak_Dayes
            ,A.Lc_Date,A.Paper_Arival_Notes,A.Country,A.Factory,A.LC_EXPIRE_DATE,A.LC_STOPED,A.Costmer_No,A.NetAmount,a.Preforma_Qty ,A.Inv_Notes,A.RequstedBy,A.ReviewBy,A.ApprovedBy,isnull(nullif(A.Factory_code,''),0) as Factory_code
            ,B.ITEM_NO,B.QTY_ADD,B.QTY_TAKE,B.total_disc,B.Unit,B.Forign_price,B.Local_Price,B.FORIN_TYPE,B.Currancy_Change_Factor,B.Notes,B.main_counter,B.K_M_TYPE_ITEMS,B.balance,B.COST_PRICE,B.QTY_ADD_Ton,B.QTY_TAKE_Ton,B.TAX_IN,B.TAX_OUT
			,C.PAYER_NAME,C.payer_l_name,C.adress,C.resp_name,C.COSTMER_K_M_NO,C.phone_no,c.fax_no,C.E_MAIL,c.adress_E,C.adress2,c.resp_name_E
            ,D.branch_name,D.WH_E_NAME,E.descr
            ,E.Descr_eng,E.Weight,F.USER_NAME,H.Currency_Name,K.Payment_name
			,C_1.CAT_NAME as Requst_Preson ,C_1.CAT_NAME_E as Requst_Preson_E,C_1.Mobile as Requst_Mobile,C_1.Email as Requst_Email
			,C_2.CAT_NAME as Reviw_Preson ,C_2.CAT_NAME_E as Reviw_Preson_E
			,C_3.CAT_NAME as Approved_Preson ,C_3.CAT_NAME_E as Approved_Preson_E
            ,(select top 1 vat_ratio from VAT_RATIO_MASTER where  date_of_vat <= A.G_date  order by date_of_vat desc) as VatRatio 
			,SF.name,SF.NameE,P.payer_Name as bank,P.payer_l_Name as bankE
            FROM wh_inv_data_Ext_Perform As A 
			inner join wh_MATERIAL_TRANSACTION_Ext_Perform As B
            on  A.SER_NO=B.SER_NO and A.Branch_code=B.Branch_code and A.TRANSACTION_CODE=B.TRANSACTION_CODE and A.Cyear=B.Cyear
			inner join payer2 as C on A.Acc_no = C.ACC_NO and A.Acc_Branch_code=C.BRANCH_code
			inner join wh_BRANCHES as D on  A.Branch_code = D.Branch_code
		    inner join wh_main_master as E on E.item_no = B.ITEM_NO
            inner join wh_USERS As F on F.USER_ID=A.User_id
            inner join Wh_Currency as H on H.Currency_Code=B.FORIN_TYPE
			inner join wh_Payment_type as K on K.Payment_type =A.Payment_Type
			left Join CATEGORY as C_1 on C_1 .CAT_CODE = A.RequstedBy 
			left Join CATEGORY as C_2 on C_2 .CAT_CODE = A.ReviewBy
			left Join CATEGORY as C_3 on C_3 .CAT_CODE = A.ApprovedBy
			left join SuppFactoreis as SF on SF.id = A.Factory_code
			left join payer2 as P on P.acc_no = A.Costmer_No and P.branch_code = A.Acc_Branch_code
             where A.Ser_no='" + ser_ + "' and A.Branch_code='" + branch_ + "' and A.Cyear = '" + year_ + "' and A.Transaction_code='" + transaction_ + "' order by B.main_counter");

        }

        private void btn_Srearch_Click(object sender, EventArgs e)
        {

            get_data(txtsearch.Text, _branchCode, comboBox1.Text.Substring(comboBox1.Text.Length - 2), "PER");

            if (dt_P.Rows.Count > 0)
            {
                txtBranch.Enabled = false;

                txtcyear.Text = comboBox1.Text.Substring(comboBox1.Text.Length - 2);
                txtId.Text = dt_P.Rows[0]["Ser_no"].ToString();
                txtDate.Text = dt_P.Rows[0]["G_date"].ToString();
                txtBranch.ID.Text = dt_P.Rows[0]["Branch_code"].ToString();
                txtLcAcc.ID.Text = dt_P.Rows[0]["LC_ACC_NO"].ToString();
                txtSupplier.ID.Text = dt_P.Rows[0]["Acc_no"].ToString();
                txtSuppContact.Text = dt_P.Rows[0]["resp_name"].ToString();
                txtSuppPhone.Text = dt_P.Rows[0]["phone_no"].ToString();
                txtSuppVAT.Text = dt_P.Rows[0]["COSTMER_K_M_NO"].ToString();
                txtAddress.Text = dt_P.Rows[0]["adress"].ToString();
                txtSuppEmail.Text = dt_P.Rows[0]["E_MAIL"].ToString();
                txtRate.Text = dt_P.Rows[0]["Currancy_Change_Factor"].ToString();
                AcceptDays.Text = dt_P.Rows[0]["Estihkak_Dayes"].ToString();
                txtCurrency.SelectedValue = dt_P.Rows[0]["FORIN_TYPE"].ToString();
                OpenDate.Text = dt_P.Rows[0]["Lc_Date"].ToString();
                ExpiryDate.Text = dt_P.Rows[0]["LC_EXPIRE_DATE"].ToString();
                LShipDate.Text = dt_P.Rows[0]["Cargo_date"].ToString();
                txtProforma.Text = dt_P.Rows[0]["Perform_invoice"].ToString();
                txtProformaDate.Text = dt_P.Rows[0]["Perform_invoice_date"].ToString();
                txtLcNo.Text = dt_P.Rows[0]["LC_NO"].ToString();
                Cost_.ID.Text = dt_P.Rows[0]["Sales_man_Id"].ToString();
                txtCragoNote1.Text = dt_P.Rows[0]["Cargo_notes1"].ToString();
                txtCragoNote2.Text = dt_P.Rows[0]["Cargo_notes2"].ToString();
                txtCrago_Method.SelectedValue = dt_P.Rows[0]["cargo_method"].ToString();
                txtCrago_Media.Text = dt_P.Rows[0]["Catgo_Media"].ToString();
                txtCrago_Port.Text = dt_P.Rows[0]["Cargo_port"].ToString();
                txtArivePort.SelectedValue = dt_P.Rows[0]["Arrival_port"].ToString();
                txtFactory.SelectedValue = dt_P.Rows[0]["Factory_code"];
                txtRegion.SelectedValue = dt_P.Rows[0]["Factory"].ToString();
                Bank_.ID.Text = dt_P.Rows[0]["Costmer_No"].ToString();
                ch_Close.Checked = Convert.ToBoolean(dt_P.Rows[0]["LC_STOPED"].ToString());
                txtQty.Text = dt_P.Rows[0]["Preforma_Qty"].ToString().ToDecimal().ToString("N0");
                txtAmount.Text= dt_P.Rows[0]["NetAmount"].ToString().ToDecimal().ToString("N0");
                txtMatrails.Text = dt_P.Rows[0]["Inv_Notes"].ToString();
                Requst_Persson.ID.Text = dt_P.Rows[0]["RequstedBy"].ToString();
                Confirm_Persson.ID.Text = dt_P.Rows[0]["ReviewBy"].ToString();
                Authorized_Persson.ID.Text = dt_P.Rows[0]["ApprovedBy"].ToString();

                invGrid1.dgv1.Rows.Clear();

                 
                int rowscount = dt_P.Rows.Count;


                if (rowscount > 0)
                {
                    invGrid1.dgv1.Rows.Add(rowscount);
                    for (int i = 0; i <= (rowscount - 1); i++)
                    {
                        invGrid1.dgv1.Rows[i].HeaderCell.Value = (dt_P.Rows[i]["main_counter"].ToString().ParseInt(0) + 1).ToString();
                        invGrid1.dgv1.Rows[i].Cells["_code"].Value = dt_P.Rows[i]["ITEM_NO"].ToString();
                        if (Properties.Settings.Default.lungh == "0")
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_P.Rows[i]["descr"].ToString();
                        }
                        else
                        {
                            invGrid1.dgv1.Rows[i].Cells["_itemDesription"].Value = dt_P.Rows[i]["descr_eng"].ToString();
                        }
                        invGrid1.dgv1.Rows[i].Cells["_addDescription"].Value = dt_P.Rows[i]["Notes"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_unit"].Value = dt_P.Rows[i]["Unit"].ToString();

                        invGrid1.dgv1.Rows[i].Cells["_weight"].Value = dt_P.Rows[i]["Weight"].ToString().ToDecimal().ToString("N3");

                        invGrid1.dgv1.Rows[i].Cells["_qty"].Value = dt_P.Rows[i]["QTY_ADD"].ToString().ToDecimal().ToString("N2");
                        invGrid1.dgv1.Rows[i].Cells["_price"].Value = dt_P.Rows[i]["Forign_price"].ToString().ToDecimal().ToString("N" + dal.digits_);
                        invGrid1.dgv1.Rows[i].Cells["_vatRatio"].Value = dt_P.Rows[i]["VatRatio"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_KmCode"].Value = dt_P.Rows[i]["K_M_TYPE_ITEMS"].ToString();
                        invGrid1.dgv1.Rows[i].Cells["_balance"].Value = dt_P.Rows[i]["balance"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_cost"].Value = dt_P.Rows[i]["COST_PRICE"].ToString().ToDecimal().ToString("N0");
                        invGrid1.dgv1.Rows[i].Cells["_totalWeight"].Value = dt_P.Rows[i]["QTY_ADD_Ton"].ToString().ToDecimal().ToString("N3");

                        invGrid1.clculat_amount(i);
                       // invGrid1.clculatTotalWeight();
                        invGrid1.clculatTonPrice(i);
                    }
                }

                invGrid1.total_inv();
                groupBox1.Visible = false;

       
            }
            else
            {
                addNew();
            }

        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtsearch.Text != string.Empty)
            {
                btn_Srearch.Focus();
            }
        }

        private void ch_Close_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_Close.Checked == true)
            {
                ch_Close.BackColor = Color.OrangeRed;
                ch_Close.Text = "Closed";
            }
            else
            {
                ch_Close.BackColor = Color.GreenYellow;
                ch_Close.Text = "Opened";
            }
        }

        private void txtCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            currencyRate(txtRate, Convert.ToString(txtCurrency.SelectedValue));
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            PL.frmAddDelevryTearms frm = new frmAddDelevryTearms();
            frm.ShowDialog();
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
             PL.frmAddArrivalPort frm = new frmAddArrivalPort();
            frm.ShowDialog();
        }

    
        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            get_data(txtId.Text, txtBranch.ID.Text, comboBox1.Text.Substring(comboBox1.Text.Length - 2), "PER");

            ds.Tables.Add(dt_P);
            ////ds.WriteXmlSchema("schema_rpt.xml");
            RPT.Form1 frm = new RPT.Form1();
            RPT.rpt_Preform_Print_Ton rpt_P = new RPT.rpt_Preform_Print_Ton();
            rpt_P.SetDataSource(ds);
            rpt_P.SetParameterValue("h_pic", Convert.ToInt32(Factory_Paper.Checked));
            rpt_P.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "Crystal.pdf");

            //frm.crystalReportViewer1.ReportSource = rpt_P;
            frm.ShowDialog();
            //ToWord toWord = new ToWord(Math.Abs(Math.Round(dt_P.Rows[0][1].ToString().ToDecimal(), dal.digits_)), currencies[currencyNo]);
            //rpt_P.DataDefinition.FormulaFields["NuToText_A"].Text = "'" + toWord.ConvertToEnglish().ToString() + "'";


        }
    
        private void showData(string Id_)
        {
            DataTable dtLc = dal.getDataTabl_1(@"select * from LcsTbl where id='" + Id_ + "'");
            if (dtLc.Rows.Count > 0)
            {
                //get_invSer();
                txtLcNo.Text = dtLc.Rows[0]["LcNo"].ToString();
                Bank_.ID.Text = dtLc.Rows[0]["BID"].ToString();
                txtCurrency.SelectedValue = dtLc.Rows[0]["Currency"].ToString();
                txtAmount.Text = dtLc.Rows[0]["Amount"].ToString().ToDecimal().ToString();
                txtQty.Text = dtLc.Rows[0]["Qty"].ToString().ToDecimal().ToString();
                txtMatrails.Text = dtLc.Rows[0]["Materials"].ToString();
                txtSupplier.ID.Text = dtLc.Rows[0]["Supplier"].ToString();
                AcceptDays.Text = (Convert.ToInt32(dtLc.Rows[0]["AcceptDays"].ToString())).ToString();
                DateTime Op_Date;
                DateTime.TryParse(dtLc.Rows[0]["OpenDate"].ToString(), out Op_Date);
                OpenDate.Text = Op_Date.ToString("d");
                DateTime Ex_Date;
                DateTime.TryParse(dtLc.Rows[0]["ExpiryDate"].ToString(), out Ex_Date);
                ExpiryDate.Text = Ex_Date.ToString("d");
                DateTime Sh_Date;
                DateTime.TryParse(dtLc.Rows[0]["LShipDate"].ToString(), out Sh_Date);
                LShipDate.Text = Sh_Date.ToString("d");
                txtAddValue.Text = dtLc.Rows[0]["plusValue"].ToString().ToDecimal().ToString("N0");
                txtRate.Text = dtLc.Rows[0]["CurrencyRate"].ToString().ToDecimal().ToString("N4");
                txtArivePort.SelectedValue = dtLc.Rows[0]["ArrivePort"].ToString();
                txtRegion.SelectedValue = dtLc.Rows[0]["Region"].ToString();
                //txtIssuSAMA.Text = dtLc.Rows[0]["OpenFees_SAMA"].ToString().ToDecimal().ToString("N2");
                //txtAddFees.Text = dtLc.Rows[0]["AddOpenFees"].ToString().ToDecimal().ToString("N2");
                //txtopenFess.Text = dtLc.Rows[0]["OpenFees"].ToString().ToDecimal().ToString("N2");
                //txtComnication.Text = dtLc.Rows[0]["OpenComnication"].ToString().ToDecimal().ToString("N2");
                //txtotharFess.Text = dtLc.Rows[0]["OtherFees"].ToString().ToDecimal().ToString("N2");
                //ratioAccept.Text = dtLc.Rows[0]["AcceptRatio"].ToString().ToDecimal().ToString("N2");
                //txtAcceptance.Text = dtLc.Rows[0]["AcceptFees"].ToString().ToDecimal().ToString("N2");
                //txtVat.Text = dtLc.Rows[0]["VAT"].ToString().ToDecimal().ToString("N2");
                //marginRatio.Text = dtLc.Rows[0]["MarginRatio"].ToString().ToDecimal().ToString("N0");
                //txtMargin.Text = dtLc.Rows[0]["Margin"].ToString().ToDecimal().ToString("N2");
                txtBranch.ID.Text = dtLc.Rows[0]["Branch_Code"].ToString();
                txtLcAcc.ID.Text = dtLc.Rows[0]["LcAccNo"].ToString();
                txtFactory.Text = dtLc.Rows[0]["Factory"].ToString();
                txtProforma.Text = dtLc.Rows[0]["Proforma"].ToString();
                txtProformaDate.Text = dtLc.Rows[0]["ProformaDate"].ToString();
                //txtMuskDownP.Text = dtLc.Rows[0]["MushaarkaFees"].ToString().ToDecimal().ToString("N2");
                //TotalFess.Value = txtopenFess.Value + txtComnication.Value + txtotharFess.Value + txtAcceptance.Value + txtMuskDownP.Value;
                //txtTotal.Value = TotalFess.Value + txtVat.Value;


            }
        }

        private void btn_ImportLcData_Click(object sender, EventArgs e)
        {

            PL.FrmSerchLcs frm = new FrmSerchLcs();
            frm.ShowDialog();
            if (frm.clos_ == 1)
            {
                showData(frm.DGV1.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void b_print_Click(object sender, EventArgs e)
        {
            if (rdoPrintTon.Checked == true)
            {
                printTons();
                groupPrint.Visible = false;
            }
            else if (rdoPrintPeaces.Checked == true)
            {
                printPeaces();
                groupPrint.Visible = false;
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            groupPrint.Visible = false;
        }

        private void btnAddFactory_Click(object sender, EventArgs e)
        {
            PL.frmAddSupplierFactory frm = new frmAddSupplierFactory();
            frm.ShowDialog();
        }

        private void txtFactory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
