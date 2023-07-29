using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.Data;

using System.Drawing; using System.Linq;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


using Microsoft.VisualBasic;
//using TwainLib;
using WIA;
using System.Runtime.InteropServices;
using EZTwainLibrary;
//using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using ALquhaliLibrary;
using System.Windows.Media.Imaging;
using ceTe.DynamicPDF.Viewer;
using System.Drawing.Imaging;

namespace Report_Pro.PL
{
    public partial class Frm_uploadImage : Form
    {
        AlquhaliClass cls = new AlquhaliClass();
  
        OpenFileDialog OFD = new OpenFileDialog();
        DAL.DataAccesslayer1 dal = new DAL.DataAccesslayer1();
        SqlConnection connection = new SqlConnection(@"server=" + Properties.Settings.Default.Server + " ;database= " + Properties.Settings.Default.Database_1 + " ;integrated security=false; user id = " + Properties.Settings.Default.Id + "; password = " + Properties.Settings.Default.Password + "");
        public string p_id,docType,branchID;
      
        List<string> devices;

        int pages;
        int currentPage = 0;

        public Frm_uploadImage()
        {
            InitializeComponent();
          
        }

        List<Image> images;


        void resaizeDG()
        {
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
          

        }



        void allfiles()
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("SELECT ser_no,FilePath,FileName,FileType,DeviceID,docType FROM FileTbl where docType='"+docType+"' and DeviceID='" + p_id + "' and isnull(branch_code,'') like (case when isnull(branch_code,'')='' then '%' else '" + Properties.Settings.Default.BranchAccID+ "'end) ");
                dataGridView1.DataSource = dt_;
            }
            catch { }
        }

       


        byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            br.Close();
            fStream.Close();
            return data;
        }




        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabItem1;
            allfiles();
            resaizeDG();
        }

        private void Frm_uploadImage_Load(object sender, EventArgs e)
        {
            ListScanners();
            allfiles();
            resaizeDG();
        }

        private void ListScanners()
        {
            //var deviceManager = new DeviceManager();
            //for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            //{
            //    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
            //    {
            //        continue;
            //    }
            //  //  cmb_Scanars.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
            //    lbDevices.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());

            //}

            devices = WAIScanner.GetDevices();

            foreach (string device in devices)
            {
                lbDevices.Items.Add(device);
            }
            //check if device is not available
            if (lbDevices.Items.Count != 0)
            {
                lbDevices.SelectedIndex = 0;

            }


        }






        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_chosescaner_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_deletAtt_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_showAtt_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_ = dal.getDataTabl_1("SELECT FileData,FileType FROM FileTbl where  ID='" + dataGridView1.CurrentRow.Cells[0].Value + "'");


                byte[] buffer = (byte[])dt_.Rows[0][0];
                string fpath = Application.StartupPath + "\\test" + dt_.Rows[0][1];

                FileStream fs = new FileStream(fpath, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                System.Diagnostics.Process.Start(fpath);

               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

      

      
     

        private void showFile()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DataTable dt_ = dal.getDataTabl_1("SELECT FileData,FileType FROM FileTbl where  ser_no='" + dataGridView1.CurrentRow.Cells[0].Value + "'");



                if (dt_.Rows[0][1].ToString().ToLower() != ".pdf")
                {

                    axAcroPDF1.Visible = false;
                    pb.Visible = true;
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dt_.Rows[0]["FileData"]);
                    MemoryStream mem = new MemoryStream(data);
                    pb.Image = Image.FromStream(mem);

                }
                else
                {
                    pb.Visible = false;
                    //   pdfViewer1.Visible = true;
                    axAcroPDF1.Visible = true;

                    byte[] ap = (byte[])dt_.Rows[0]["FileData"];
                    string fpath = Application.StartupPath + "\\test" + dt_.Rows[0][1];

                    FileStream fs = new FileStream(fpath, FileMode.Create);
                    fs.Write(ap, 0, ap.Length);
                    fs.Close();
                   
                    axAcroPDF1.src = fpath;
                    axAcroPDF1.setShowToolbar(true);
                    axAcroPDF1.setZoom(100);
                

                }

            }

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showFile();
        }

       
     

      
        private void btnAddFromScan_Click(object sender, EventArgs e)
        {
            PL.scanFrm frm = new PL.scanFrm();
            frm.ShowDialog();

            if (System.IO.File.Exists(Application.StartupPath + "\\MyImage.Bmp") == true)
            {
                System.IO.File.Delete(Application.StartupPath + "\\MyImage.Bmp");// في حال وجودها سيتم حذفها حتى يتمكن من حفظ الصورة الجديده
            }

            EZTwain.AcquireToFileName(0, Application.StartupPath + "\\MyImage.Bmp"); // يقوم باستخراج الصورة من الماسح الضوئي وحفظها في الهاردسك
            OFD.FileName = Application.StartupPath + "\\MyImage.Bmp"; // لجلب موقع الصوره ووضعها في متغير
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgv2, OFD.FileName.ToString(), Path.GetFileNameWithoutExtension(OFD.FileName), Path.GetExtension(OFD.FileName), p_id);
            dgv2.Rows.Add(row);
            tabControl1.SelectedTab = tabItem3;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

             EZTwain.SelectTwainsource(0);
        }

        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            showFile();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            OpenFileDialog opnFile = new OpenFileDialog();
            opnFile.Filter = "All Files|*.*|pdf|*.pdf|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
            opnFile.FilterIndex = 2;
            opnFile.Multiselect = true;
            if (opnFile.ShowDialog() == DialogResult.OK)
            {
                ListBox ls = new ListBox();
                foreach (string p in opnFile.FileNames)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv2, p.ToString(), Path.GetFileNameWithoutExtension(p), Path.GetExtension(p), p_id, docType);
                    dgv2.Rows.Add(row);
                    tabControl1.SelectedTab = tabItem3;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                if (dgv2.Rows[i].Cells[0].Value != null)
                {

                    SqlCommand cmd = new SqlCommand("insert into filetbl(FilePath,filename,filetype,DeviceID,FileData,docType,branch_code)values(@fd,@fn,@ft,@po,@cp,@do,@bc)", connection);
                    cmd.Parameters.AddWithValue("@fd", dgv2.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@fn", dgv2.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@ft", dgv2.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@po", dgv2.Rows[i].Cells[3].Value);
                    byte[] fileData = ReadFile(dgv2.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@cp", fileData);
                    cmd.Parameters.AddWithValue("@do", dgv2.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@bc", branchID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            //  MessageBox.Show("تم حفظ اابيات بنجاح");
            MessageBox.Show(dal.rm.GetString("msgSave", dal.cul), dal.rm.GetString("msgSave_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv2.Rows.Clear();
            button3_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // if (MessageBox.Show("هل تريد فعلا حذف المرفق المحدد", "تحذير !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            if (MessageBox.Show(dal.rm.GetString("msgConfirmDelete", dal.cul), dal.rm.GetString("msgConfirmDelete_H!", dal.cul), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)

            {
                dal.Execute_1("delete from filetbl where ser_no='" + dataGridView1.CurrentRow.Cells[0].Value + "' ");
                //connection.Open();
                //cmd.ExecuteNonQuery();
                //connection.Close();
                // MessageBox.Show("تم حذف المرفق ", "رسالة تاكيد !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(dal.rm.GetString("msgDelete", dal.cul), dal.rm.GetString("msgDelete_H", dal.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);


                button3_Click(sender, e);
            }
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MaxForm(this);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }


        private void CloseForm(Form frm)
        {
            frm.Close();
        }
        private void MaxForm(Form frm)
        {
            if (frm.WindowState == FormWindowState.Normal)
            {
                frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm(this);
        }

        private void xToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MinForm(this);
    }

        private void btn_SelectScanner_Click(object sender, EventArgs e)
        {
            EZTwain.SelectTwainsource(0);

        }

        private void btn_UploadFromScanner_Click(object sender, EventArgs e)
        {
           
            if (lbDevices.Items.Count == 0)
            {
                MessageBox.Show("You do not have any WIA devices.");
                this.Close();
            }
            else
            {
                lbDevices.SelectedIndex = 0;
            }

            

            //get images from scanner
            List<Image> images = WAIScanner.Scan((string)lbDevices.SelectedItem, pages);


            foreach (Image image in images)
            {
                pb.Image = image;
                pb.Visible = true;
                axAcroPDF1.Visible = false;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
               // save scanned image into specific folder
                 image.Save(@"C:\SCAN_FOLDER\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);
            }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
        }

        private void MinForm(Form frm)
        {
            frm.WindowState = FormWindowState.Minimized;
        }
    }
}
