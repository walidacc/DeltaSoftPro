using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Report_Pro.Reports
{
    public partial class rpt_Confirmation_Bahrain : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_Confirmation_Bahrain()
        {
            InitializeComponent();
        }

        private void rpt_Confirmation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void B_Balance_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageIndex > 1)
            {

                B_Balance.Visible = false;
            }

        }

        private void xrLabel94_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageIndex > 1)
            {
                xrLabel94.Visible = false;
            }
        }
       
       
    }
}
