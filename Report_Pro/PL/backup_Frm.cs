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

namespace Report_Pro.PL
{
    public partial class backup_Frm : Form
       
    {
        SqlConnection sqlcon = new SqlConnection(@"server=" + Properties.Settings.Default.Server + " ;database= " + Properties.Settings.Default.Database_1+ " ;integrated security=false; user id = " + Properties.Settings.Default.Id + "; password = " + Properties.Settings.Default.Password + "");

//        SqlConnection sqlcon = new SqlConnection(@"server=.\SQLEXPRESS;database=product_DB;integrated security=true");
        SqlCommand cmd;


        BackgroundWorker m_oWorker;
        public backup_Frm()
        {
            InitializeComponent();

            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler(m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;

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


        //==================================================================////
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Cursor.Current = Cursors.WaitCursor;

            m_oWorker.RunWorkerAsync();           
            string filename = textBox1.Text + "\\"+Properties.Settings.Default.Database_1+"" + DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongTimeString().Replace(':', '-');
            string strquery = "backup database" +" " + Properties.Settings.Default.Database + " " +"to disk='" + filename + ".bak'";
            cmd = new SqlCommand(strquery, sqlcon);
            cmd.CommandTimeout = 100;
            
            sqlcon.Open();
            
            cmd.ExecuteNonQuery();
            sqlcon.Close();
             MessageBox.Show("تم انشاء النسخة الاحتاطية بنجاح", "النسخ الاحتياطي", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

 
      
    

    }
}
