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
    public partial class frm_AccountsData : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        string languh = Properties.Settings.Default.lungh;
        BindingSource bs = new BindingSource();
        DataTable dt_bs = new DataTable();

        public frm_AccountsData()
        {
            InitializeComponent();
        }


        void createDattable()
        {
            dt_bs.Columns.Add("_AccNo", typeof(string));
            dt_bs.Columns.Add("_Descr", typeof(string));
            dt_bs.Columns.Add("_Descr_E", typeof(string));
            dt_bs.Columns.Add("_CR", typeof(string));
            dt_bs.Columns.Add("_CrDate", typeof(DateTime));
            dt_bs.Columns.Add("_VatID", typeof(string));
            dt_bs.Columns.Add("_Tel", typeof(string));
            dt_bs.Columns.Add("_respon", typeof(string));
            dt_bs.Columns.Add("_Email", typeof(string));
            dt_bs.Columns.Add("_Address", typeof(string));
            dt_bs.Columns.Add("_Address_E", typeof(string));
           

        }

        void resaizeDGV()
        {
            int dgvWidth = dgv1.Width - dgv1.RowHeadersWidth;
            dgv1.Columns[0].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[1].Width = (int)(dgvWidth * 0.15);
            dgv1.Columns[2].Width = (int)(dgvWidth * 0.15);
            dgv1.Columns[3].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[4].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[5].Width = (int)(dgvWidth * 0.06);
            dgv1.Columns[6].Width = (int)(dgvWidth * 0.05);
            dgv1.Columns[7].Width = (int)(dgvWidth * 0.09);
            dgv1.Columns[8].Width = (int)(dgvWidth * 0.09);
            dgv1.Columns[9].Width = (int)(dgvWidth * 0.13);
            dgv1.Columns[10].Width = (int)(dgvWidth * 0.13);
     


            if (languh == "0")
            {
                dgv1.Columns[0].HeaderText = "الرقم";
                dgv1.Columns[1].HeaderText = "الوصف عربي";
                dgv1.Columns[2].HeaderText = "الوصف لاتيني";
                dgv1.Columns[3].HeaderText = "رقم السجل";
                dgv1.Columns[4].HeaderText = "انتهاء السجل";
                dgv1.Columns[5].HeaderText = "الرقم الضريبي";
                dgv1.Columns[6].HeaderText = "الهاتف";
                dgv1.Columns[7].HeaderText = "المسئول";
                dgv1.Columns[8].HeaderText = "الايميل";
                dgv1.Columns[9].HeaderText = "العنوان عربي";
                dgv1.Columns[10].HeaderText = "العنوان انجليزي";
             

            }
            else
            {
                dgv1.Columns[0].HeaderText = "Ser";
                dgv1.Columns[1].HeaderText = "Arabic Description";
                dgv1.Columns[2].HeaderText = "English Description";
                dgv1.Columns[3].HeaderText = "CR";
                dgv1.Columns[4].HeaderText = "CR Date";
                dgv1.Columns[5].HeaderText = "VAT Id";
                dgv1.Columns[6].HeaderText = "Telephon";
                dgv1.Columns[7].HeaderText = "Responsible";
                dgv1.Columns[8].HeaderText = "Email";
                dgv1.Columns[9].HeaderText = "Arabic Address";
                dgv1.Columns[10].HeaderText = "English Address";
           

            }



        }

        private void frm_AccountsData_Load(object sender, EventArgs e)
        {
            createDattable();
            dgv1.DataSource = dt_bs;
            resaizeDGV();
        }
    }
}
