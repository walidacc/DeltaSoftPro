using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Pro.MyControls
{
    public class cmboYear :ComboBox
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        
   
        public cmboYear()
        {
            this.DataSource = dal.getDataTabl_1(@" SELECT DISTINCT Cyear FROM wh_Serial");
            this.ValueMember = "Cyear";
            this.DisplayMember = "Cyear";
            this.SelectedItem = Properties.Settings.Default.C_year;

           
        }

    
    }
}
