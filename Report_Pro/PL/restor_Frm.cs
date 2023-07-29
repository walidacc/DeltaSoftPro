using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
//using Microsoft.SqlServer.Management.Smo;

namespace Report_Pro.PL
{
    public partial class restor_Frm : Form
    {

        SqlConnection sqlcon = new SqlConnection(@"server=.\SQLEXPRESS;database=master;integrated security=true");
        SqlCommand cmd;

        BackgroundWorker m_oWorker;
        public restor_Frm()
        {
            InitializeComponent();
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        //{
        //    label2.Text = e.Percent.ToString() + "% restored";
        //    progressBar1.Value = e.Percent;
        //}


        //void CompleteEventHandler(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        //{
        //    label3.Text = e.ToString().Substring(e.ToString().IndexOf(":") + 1);
        //}


        private void BackupBeforrestor()
        {

            Cursor.Current = Cursors.WaitCursor;

            m_oWorker.RunWorkerAsync();
            string filename = @"C:\Backup_data\\" + Properties.Settings.Default.Database_1 + "" + DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongTimeString().Replace(':', '-');
            string strquery = "backup database" + " " + Properties.Settings.Default.Database_1 + " " + "to disk='" + filename + ".bak'";
            cmd = new SqlCommand(strquery, sqlcon);
            cmd.CommandTimeout = 100;

            sqlcon.Open();

            cmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("تم انشاء النسخة الاحتاطية بنجاح", "النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If it was cancelled midway
            //if (e.Cancelled)
            //{
            //    lblStatus.Text = "Task Cancelled.";
            //}
            //else if (e.Error != null)
            //{
            //    lblStatus.Text = "Error while performing background operation.";
            //}
            //else
            //{
            //    lblStatus.Text = "Task Completed...";
            //}
            button2.Enabled = true;
            button3.Enabled = false;
        }

        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            //    progressBar1.Value = e.ProgressPercentage;
            //    lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
        }


        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //NOTE : Never play with the UI thread here...

            //time consuming operation
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                m_oWorker.ReportProgress(i);

                //If cancel button was pressed while the execution is in progress
                //Change the state from cancellation ---> cancel'ed
                if (m_oWorker.CancellationPending)
                {
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }

            }

            //Report 100% completion on operation completed
            m_oWorker.ReportProgress(100);
        }




        private void button2_Click(object sender, EventArgs e)
        {

           
            Cursor.Current = Cursors.WaitCursor;
          
            if (MessageBox.Show("Are you sure you restore?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               // BackupBeforrestor();

                SqlConnection connect = new SqlConnection(@"server=" + Properties.Settings.Default.Server + " ;database= " + Properties.Settings.Default.Database_1 + " ;integrated security=false; user id = " + Properties.Settings.Default.Id + "; password = " + Properties.Settings.Default.Password + "");

                try
                {
                connect.Open();
                string sql1 = string.Format("ALTER DATABASE " + Properties.Settings.Default.Database_1 + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(sql1, connect);
                cmd1.ExecuteNonQuery();
                string sql2 = string.Format("USE MASTER RESTORE DATABASE " + Properties.Settings.Default.Database_1 + " FROM DISK='" + textBox1.Text + "' WITH REPLACE;");
                SqlCommand cmd2 = new SqlCommand(sql2, connect);
                cmd2.CommandTimeout = 1000;
                cmd2.ExecuteNonQuery();
                string sql3 = string.Format("ALTER DATABASE " + Properties.Settings.Default.Database_1 + " SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(sql3, connect);
                cmd3.CommandTimeout = 1000;
                cmd3.ExecuteNonQuery();
                connect.Close();
                connect.Dispose();


                MessageBox.Show("Has been restored database", "Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
            else
                MessageBox.Show(@"Do not make any endorsement above (or is not in the correct path)", "Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void restor_Frm_Load(object sender, EventArgs e)
        {

        }
    }
}
