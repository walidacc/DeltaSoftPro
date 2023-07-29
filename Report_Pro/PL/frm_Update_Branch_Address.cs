using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Report_Pro.PL
{
    public partial class frm_Update_Branch_Address : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_Update_Branch_Address()
        {
            InitializeComponent();
        }

        private void frm_Update_Branch_Address_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dal.Execute_1(@"update wh_BRANCHES set LONG_ADESS_A= '" + txtAddress.Text
                + "',LONG_ADESS_E='" + txtAddress_E.Text
                + "',PHONE_NO = '"+txtPhone.Text
                + "' where Branch_code = '" + txtStore.ID.Text + "'");

            MessageBox.Show("تم تحديث البيانات", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
       

 
    }
}
