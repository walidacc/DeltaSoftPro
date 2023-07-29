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
    public partial class frm_Rpt_Coils : frm_ReportMaster
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string choseRaw, ChoseBalance;
        public frm_Rpt_Coils()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void rdoBalanceUsed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void choises()
        {
            if (rdoBalanceAll.Checked)
            {
                ChoseBalance = "1";
            }
            else if (rdoBalanceNotUsed.Checked)
            {
                ChoseBalance = "2";
            }
            else if (rdoBalanceUsed.Checked)
            {
                ChoseBalance = "3";
            }
            else if (rdoBalanceZero.Checked)
            {
                ChoseBalance = "4";
            }

            if (rdoAll_1.Checked)
            {
                choseRaw = "";
            }
            else if (rdoRaw.Checked)
            {
                choseRaw = "H";
            }
            else if (rdoWIP.Checked)
            {
                choseRaw = "S";
            }
            else if (rdoFinshed.Checked)
            {
                choseRaw = "F";
            }
        }

        public override void Option()
        {
            groupBox1.Visible = true;

            base.Option();
        }

        private void frm_Rpt_Coils_Load(object sender, EventArgs e)
        {
            fromDatePurchase.Value = new DateTime(DateTime.Now.Year, 1, 1);
            ToDatePurchase.Value = DateTime.Today;
            fromDateProduction.Value = new DateTime(DateTime.Now.Year, 1, 1);
            ToDateProduction.Value = DateTime.Today;
        }

        public override void preview()
        {
            groupBox1.Visible = false;
            choises();
            DataTable dt_ = dal.getDataTabl_1(@"SELECT Item_no,descr,Descr_eng,Material_Id,Heat_no,Weight,QTY_OUT,Acc_no,PAYER_NAME,USER_ID,G_DATE
                    ,Source_Material_id,Ser_no,qty_take,PRODUCTION_DATE,UnitDepth,UnitWidth,group_code,BRANCH_CODE  FROM VIEW_heat_no
where BRANCH_CODE like '"+txtBranch.ID.Text+"%' and Item_no like '" + txtItem.ID.Text+ "%' and group_code like '"+txtGroup.ID.Text+ 
"%' and Material_Id like '"+txtMaterialID.Text+"%' and Heat_no like '"+txtHeatNo.Text + "%' and isnull(Source_Material_id,'') like '"+txtSourceID.Text+
"%' and cast (G_DATE as date ) between '"+fromDatePurchase.Value.ToString("yyyy-MM-dd")+ "' and '" +  ToDatePurchase.Value.ToString("yyyy-MM-dd") +
"' and (nullif(PRODUCTION_DATE,'') is null or cast(PRODUCTION_DATE as date) between '" + fromDateProduction.Value.ToString("yyyy-MM-dd") + 
"' and '" + ToDateProduction.Value.ToString("yyyy-MM-dd") + "')  " +
"and (Weight = case when '"+ChoseBalance+ "'=2 then Weight-QTY_OUT  when '" + ChoseBalance + "'=4 then QTY_OUT end or Weight-QTY_OUT > case when '" + ChoseBalance + "'=3 then 0  when '" + ChoseBalance + "'=1 then -1000000000 end) " +
" and Material_Id like '"+choseRaw+"%' ");
            RPT.rpt_coilsReport rpt = new RPT.rpt_coilsReport();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt_);
            //ds.WriteXmlSchema("schema_rpt.xml");
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            base.preview();
        }
    }
}
