﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report_Pro.RPT
{
    public partial class frm_Daliy_rpt :frm_ReportMaster
    {
        string db1 = Properties.Settings.Default.Database_1;
        string btn_name;
                List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        int currencyNo = 2;
        DAL.DataAccesslayer1 dal=new DAL.DataAccesslayer1();
        public frm_Daliy_rpt()
        {
            InitializeComponent();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            groupPanel1.Visible = true;
        }

        public override void Option()
        {
            groupPanel1.Visible = true;
            base.Option();
        }

        public override void preview()
        {
            reportPreveiw();
            base.preview();
        }



        private void reportPreveiw()        {
            RPT.rpt_Daily_Entry rpt = new RPT.rpt_Daily_Entry();
            DataSet1 ds = new DataSet1();
            DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();



            dt1 = dal.getDataTabl_1(@"SELECT D.ACC_NO,P.PAYER_NAME,D.BRANCH_code,B.BRANCH_name,D.ser_no,D.sorting_ser,D.COST_CENTER
            ,D.meno,D.loh,D.g_date,D.sanad_no,D.SANAD_TYPE,D.sp_ser_no,D.user_name,desc2,D.SOURCE_CODE
            FROM daily_transaction as D 
            inner join payer2 as P on p.ACC_NO=D.ACC_NO and D.BRANCH_code = p.BRANCH_code 
            inner join BRANCHS as B on B.BRANCH_code=D.BRANCH_code 
            where CAST(D.G_date as Date ) between '" + FromDate.Value.ToString("yyyy/MM/dd") +
            "'  and '" + ToDate.Value.ToString("yyyy/MM/dd") + "' and  D.ACC_NO like '" + UC_Acc1.ID.Text + 
            "%' and ISNULL(D.CAT_CODE, '')  like '" + UC_Catogry1.ID.Text + 
            "%' and  D.BRANCH_code like '" + UC_Branch.ID.Text + "%'");

            ds.Tables.Add(dt1);
            ////ds.WriteXmlSchema("schema1.xml");

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            this.Cursor = Cursors.Default;
            rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + FromDate.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + ToDate.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["Acc_No"].Text = " '" + UC_Acc1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Acc_name"].Text = " '" + UC_Acc1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_No"].Text = "'" + UC_cost1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cost_name"].Text = "'" + UC_cost1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_NO"].Text = "'" + UC_Catogry1.ID.Text + "'";
            rpt.DataDefinition.FormulaFields["Cat_Name"].Text = "'" + UC_Catogry1.Desc.Text + "'";
            rpt.DataDefinition.FormulaFields["company_name"].Text = "'" + Properties.Settings.Default.head_txt + "'";
            rpt.DataDefinition.FormulaFields["branch_name"].Text = "'" + Properties.Settings.Default.Branch_txt + "'";
            rpt.DataDefinition.FormulaFields["dgits_"].Text = "'" + dal.digits_ + "'";


            groupPanel1.Visible = false;


        }

        private void frm_Daliy_rpt_Load(object sender, EventArgs e)
        {

        }

        private void UC_Branch_Load(object sender, EventArgs e)
        {

        }
    }
}
