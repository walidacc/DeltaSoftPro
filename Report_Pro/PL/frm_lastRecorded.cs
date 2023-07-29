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
    public partial class frm_lastRecorded : Form
    {
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        public frm_lastRecorded()
        {
            InitializeComponent();
        }

        private void frm_lastRecorded_Load(object sender, EventArgs e)
        {
            txtUserID.Text = Program.userID;
            txtUserName.Text = Program.salesman;
            txtName.txtuser.Text = txtUserID.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dal.IsDateTime(txtLastRecordDate.Text) && txtName.ID.Text.Trim() != string.Empty)
            {
                DataTable dt_ch = dal.getDataTabl_1(@"select * from lastRecord_tbl where code= '" + txtName.ID.Text + "' and LastDate ='" + txtLastRecordDate.Value.ToString("yyyy-MM-dd") + "' ");
                if (dt_ch.Rows.Count > 0)
                {
                    MessageBox.Show(dal.rm.GetString("msgNoEdit", dal.cul), dal.rm.GetString("msgNoEdit_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    dal.Execute_1(@"INSERT INTO lastRecord_tbl(code, g_date, userId, LastDate)
                VALUES('" + txtName.ID.Text + "','" + txtDate.Value.ToString("yyyy-MM-dd") + "','" + txtUserID.Text + "','" + txtLastRecordDate.Value.ToString("yyyy-MM-dd") + "')");
                    MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(dal.rm.GetString("msgError", dal.cul), dal.rm.GetString("msgError_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void getRecorded(string code_)
        {
            DataTable dt_r = dal.getDataTabl_1(@" SELECT X.code,descr,descr_E,user_id,Y.code,Y.g_date,Y.userId,Y.LastDate FROM RecordedBranches_tbl as X
				 left join lastRecord_tbl as Y on X.code = Y.code 
                where Y.code = '" + code_ + "' order by Y.LastDate desc ");
            if (dt_r.Rows.Count > 0)
            {

                int _rowscount = dt_r.Rows.Count;
                dataGridView1.Rows.Add(_rowscount);
                for (int i = 0; i <= (_rowscount - 1); i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Convert.ToDateTime(dt_r.Rows[i]["g_date"]).ToString("yyyy-MM-dd");
                    if (Properties.Settings.Default.lungh == "0")
                    {
                        dataGridView1.Rows[i].Cells[1].Value = dt_r.Rows[i]["descr"].ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[1].Value = dt_r.Rows[i]["descr_E"].ToString();
                    }
                    dataGridView1.Rows[i].Cells[2].Value = dt_r.Rows[i]["userId"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToDateTime(dt_r.Rows[i]["LastDate"]).ToString("yyyy-MM-dd");
                }
            }

        }

        private void txtName_Load(object sender, EventArgs e)
        {
            getRecorded(txtName.ID.Text);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
                   }
    }
}
