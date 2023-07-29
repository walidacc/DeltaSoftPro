using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Report_Pro.RPT
{

    public partial class frm_project_materails : frm_ReportMaster
    {
        string db1 = Properties.Settings.Default.Database_1;
        string btn_name;
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_project_materails()
        {
            InitializeComponent();
        }

   

    

        public override void Option()
        {
            groupPanel1.Visible = true;
            base.Option();
        }

        public override void preview()
        {
            if(rdoDetials.Checked == true)
            {
            RPT.CrystalReport4 rpt = new RPT.CrystalReport4();

            rpt.SetDataSource(dal.getDataTabl("Get_opo_Detials_", dTP1.Value.Date, dTP2.Value.Date, UC_Branch.ID.Text, UC_Acc.ID.Text, UC_Items.ID.Text, UC_Cost.ID.Text, db1));
            crystalReportViewer1.ReportSource = rpt;
            rpt.DataDefinition.FormulaFields["Txt_Acc"].Text = "'" + UC_Acc.ID.Text.ToString() + "'+' -  '+'" + UC_Acc.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["Txt_Branch"].Text = "'" + UC_Branch.ID.Text.ToString() + "'+' -  '+'" + UC_Branch.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["txt_cost"].Text = "'" + UC_Cost.ID.Text.ToString() + "'+' -  '+'" + UC_Cost.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["txt_item"].Text = "'" + UC_Items.ID.Text.ToString() + "'+' -  '+'" + UC_Items.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + dTP1.Value.ToString("yyyy/MM/dd") + "'";
            }
            else if ( rdoByProject.Checked ==true)
            {
            RPT.project_matirals_byCost rpt = new RPT.project_matirals_byCost();
            rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + dTP2.Value.ToString("yyyy/MM/dd") + "'";

            rpt.SetDataSource(dal.getDataTabl("Get_opo_Detials_", dTP1.Value.Date, dTP2.Value.Date, UC_Branch.ID.Text.ToString(), UC_Acc.ID.Text.ToString(), UC_Items.ID.Text.ToString(), UC_Cost.ID.Text.ToString(), db1));
            crystalReportViewer1.ReportSource = rpt;
            rpt.DataDefinition.FormulaFields["Txt_Acc"].Text = "'" + UC_Acc.ID.Text.ToString() + "'+' -  '+'" + UC_Acc.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["Txt_Branch"].Text = "'" + UC_Branch.ID.Text.ToString() + "'+' -  '+'" + UC_Branch.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["txt_cost"].Text = "'" + UC_Cost.ID.Text.ToString() + "'+' -  '+'" + UC_Cost.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["txt_item"].Text = "'" + UC_Items.ID.Text.ToString() + "'+' -  '+'" + UC_Items.Desc.Text.ToString() + "'";
            rpt.DataDefinition.FormulaFields["From_date"].Text = "'" + dTP1.Value.ToString("yyyy/MM/dd") + "'";
            rpt.DataDefinition.FormulaFields["To_Date"].Text = "'" + dTP2.Value.ToString("yyyy/MM/dd") + "'";
            }
            groupPanel1.Visible = false;

            base.preview();
        }

        
       
    }
}
