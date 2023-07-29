

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using Report_Pro.DAL;
using Report_Pro.MyControls;
using Report_Pro.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing; using System.Linq;
using System.Windows.Forms;

namespace Report_Pro.PL
{
    public partial class frmAssetAdditions : frm_Master
  {
       DataAccesslayer1 dal = new DataAccesslayer1();
      

        public frmAssetAdditions()
    {
      InitializeComponent();
      cobLocation.DataSource = dal.getDataTabl_1("SELECT * FROM FAS_LOCATION where BRANCH_CODE like '" + AccBranch.ID.Text + "%'");
      cobLocation.ValueMember = "LOCATION_CODE";
      cobLocation.DisplayMember = "LOCATION_NAME";
      cobLocation.SelectedIndex = -1;
      cmbGroup.DataSource = dal.getDataTabl_1("SELECT * FROM AssetsGroup where isFinal = '1'");
      cmbGroup.ValueMember = "code";
      cmbGroup.DisplayMember = "Name";
      cmbGroup.SelectedIndex = -1;
      //this.txtTransaction.ID.Text = "PUA";
    }

    private void groupPanel7_Click(object sender, EventArgs e)
    {
    }

    private void groupPanel1_Click(object sender, EventArgs e)
    {
    }

    private void showAssetData(int Id_)
    {
      DataTable dataTabl1 = this.dal.getDataTabl_1("SELECT *  FROM AssetsTbl where id='"+Id_+"'");
      if (dataTabl1.Rows.Count <= 0)
        return;
      foreach (DataRow row in (InternalDataCollectionBase) dataTabl1.Rows)
      {
        txtId.Text = row[0].ToString();
        txtCode.Text = row[1].ToString();
        txtName.Text = row[2].ToString();
        txtName_L.Text = row[3].ToString();
        cmbGroup.SelectedValue = (object) row[4].ToString();
        lastDepDat.Text = row[5].ToString();
        txtNote.Text = row[6].ToString();
        cobLocation.SelectedValue = (object) row[14].ToString();
        txtAge.Value = Convert.ToDouble(row[32].ToString());
        txtEndValue.Value = Convert.ToDouble(row[33].ToString());
        txtPurchaseValue.Value = Convert.ToDouble(row[34].ToString());
        StartDate.Text = row[35].ToString();
        txtAddValue.Value = Convert.ToDouble(row[36].ToString());
        txtReductionValue.Value = Convert.ToDouble(row[37].ToString());
        txtGReevaluation.Value = Convert.ToDouble(row[38].ToString());
        txtLReevaluation.Value = Convert.ToDouble(row[39].ToString());
        A_Deprecition.Value = Convert.ToDouble(row[40].ToString());
        netValue.Value = Convert.ToDouble(row[41].ToString());
        txtAssAcc.ID.Text = row[42].ToString();
        txtDepAcc.ID.Text = row[43].ToString();
        txtADepAcc.ID.Text = row[44].ToString();
        txtGSAcc.ID.Text = row[45].ToString();
        txtLSAcc.ID.Text = row[46].ToString();
        txtRGAcc.ID.Text = row[47].ToString();
        txtRLAcc.ID.Text = row[48].ToString();
        AccBranch.ID.Text = row["BranchCode"].ToString();
      }
    }

    private void frmAssetAdditions_Load(object sender, EventArgs e)
    {
      AccBranch.ID.Text = Settings.Default.BranchAccID;
      txtSer.Text = this.dal.GetCell_1("select isnull(Fas_Transaction_Serial+1,1) from serial_no where BRANCH_CODE='" + AccBranch.ID.Text + "' and ACC_YEAR='cy'").ToString();
    }

    private void txtId_TextChanged(object sender, EventArgs e)
    {
      try
      {
        showAssetData(Convert.ToInt32(txtId.Text));
        txtSer.Text = dal.GetCell_1("select isnull(Fas_Transaction_Serial+1,1) from serial_no where BRANCH_CODE='" + AccBranch.ID.Text + "' and ACC_YEAR='cy'").ToString();
      }
      catch
      {
      }
    }

    private void AccBranch_Load(object sender, EventArgs e)
    {
    }
        public override void Save()
        {
            if (txtDate.Value != lastDepDat.Value)
            {
                MessageBox.Show("يجب ان يكون اخر اهلاك في نفس تاريخ الاضافة");
                return;
            }
            else
            {
                addTransaction();
            }

            base.Save();
        }



     

        private void addTransaction()
        {
            dal.Execute_1("insert into Fas_Transaction(Ser_no, Tr_Code, Fa_No, Branch_code, Acc_Year, Cost_Code, G_Date, Meno, Loh, DESC2," +
                "Sp_ser_no, Notes, User_id, Daily_Ser_No, Prev_Depr_Date, Last_Depr_Date, First_Acc_No, Second_Acc_No, VAT) " +
                "Values('" + txtSer.Text + "','" + txtTransaction.ID.Text + "','" + txtId.Text + "','" + AccBranch.ID.Text + "','cy','','" + 
                txtDate.Value.ToString("yyyy-MM-dd") + "','" + txtValue.Value + "','0','" + txtDescription.Text + "','','" + txtNotes.Text + "','','','" + 
                lastDepDat.Value.ToString("yyyy-MM-dd") + "','" + lastDepDat.Value.ToString("yyyy-MM-dd") + "','" + txtAssAcc.ID.Text + "','" + txtAcc.ID.Text + "','0')");
        }

        private void btnSaveTransaction_Jor_Click(object sender, EventArgs e)
        {

        }

        public override void New()
        {
            dal.ClearTextBoxes(this);
            base.New();
        }
    }
}
