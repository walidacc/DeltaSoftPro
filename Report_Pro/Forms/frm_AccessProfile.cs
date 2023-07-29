﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.LookAndFeel;

namespace Report_Pro.Forms
{
    public partial class frm_AccessProfile : frm_Master
    {
        DAL.UserAccessProfile profile;
        public frm_AccessProfile()
        {
            InitializeComponent();
            New();
            GetData();
        }
        public frm_AccessProfile(int id)
        {
            InitializeComponent();
            using (var db = new DAL.dbDataContext())
            {
                profile = db.UserAccessProfiles.SingleOrDefault(x => x.ID == id);

            }
            textEdit1.Text = profile.Name;
            GetData();
        }
        public override void New()
        {
            profile = new DAL.UserAccessProfile();
           
        }

        public override void CloseForm(Form frm)
        {
            base.CloseForm(frm);
        }
        

        private void TreeList1_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if(e.Node.Id >=0)
            { 
                var row = treeList1.GetRow(e.Node.Id) as Classes.ScreensAccessProfile;
                if(row != null)
                {
                    if(e.Column.FieldName == nameof(ins.CanAdd) &&
                        row.Actions.Contains(Classes.Master.Actions.Add ) == false )
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else  if (e.Column.FieldName == nameof(ins.CanDelete ) &&
                        row.Actions.Contains(Classes.Master.Actions.Delete ) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanEdit ) &&
                     row.Actions.Contains(Classes.Master.Actions.Edit ) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanOpen ) &&
                     row.Actions.Contains(Classes.Master.Actions.Open ) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanPrint ) &&
                     row.Actions.Contains(Classes.Master.Actions.Print ) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanShow ) &&
                     row.Actions.Contains(Classes.Master.Actions.Show ) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }


                }
            }
        }
        Classes.ScreensAccessProfile ins;
        public  override  void GetData()
        {
            List<Classes.ScreensAccessProfile> data;
            using (DAL.dbDataContext db = new DAL.dbDataContext()) 
            {
                 data = (from s in Classes.Screens.GetScreens
                            from d in db.UserAccessProfileDetails
                            .Where(x => x.ProfileID == profile.ID && x.ScreeanID == s.ScreenID).DefaultIfEmpty()
                            select new Classes.ScreensAccessProfile(s.ScreenName)
                            {
                                CanAdd =(d==null )? false : d.CanAdd,
                                CanDelete = (d == null) ? false : d.CanDelete,
                                CanEdit = (d == null) ? false : d.CanEdit,
                                CanOpen = (d == null) ? false : d.CanOpen,
                                CanPrint = (d == null) ? false : d.CanPrint,
                                CanShow = (d == null) ? false : d.CanShow,
                                Actions = s.Actions,
                                ScreenName = s.ScreenName,
                                ScreenCaption = s.ScreenCaption,
                                ScreenCaption_E = s.ScreenCaption_E,
                                ScreenID = s.ScreenID,
                                ParentScreenID = s.ParentScreenID,
                            }).ToList(); 
            }
 
            treeList1.DataSource = data;
           
        }
        public override bool IsDataVailde()
        {
            int flag = 0;
            if (textEdit1.Text.Trim() == string.Empty)
            {
                flag++;
                textEdit1.ErrorText = ErrorText;

            } 
           
            return (flag == 0);
        }
        public override void Save()
        {
            var db = new DAL.dbDataContext();
            if (profile.ID == 0)
            {
                db.UserAccessProfiles .InsertOnSubmit(profile);
            }
            else
            {
                db.UserAccessProfiles.Attach(profile);
            }
            profile.Name = textEdit1.Text;
            db.SubmitChanges();

            db.UserAccessProfileDetails .DeleteAllOnSubmit(
            db.UserAccessProfileDetails.Where(x => x.ProfileID == profile.ID)); 
            db.SubmitChanges();
            

            var data = treeList1.DataSource as List<Classes.ScreensAccessProfile>;
            var dbData = data.Select(s => new DAL.UserAccessProfileDetail
            {
                CanAdd = s.CanAdd,
                CanDelete = s.CanDelete,
                CanEdit = s.CanEdit,
                CanOpen = s.CanOpen,
                CanPrint = s.CanPrint,
                CanShow = s.CanShow,
                ProfileID = profile.ID,
                ScreeanID = s.ScreenID , 

            }).ToList();
            db.UserAccessProfileDetails.InsertAllOnSubmit(dbData);
            db.SubmitChanges();
            IsNew = false;
            base.Save();
        }
        RepositoryItemCheckEdit repoCheck;
        private void frm_AccessProfile_Load(object sender, EventArgs e)
        {
             btnPrint.Visible = true;

            textEdit1.Text = profile.Name;
            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;
            treeList1.KeyFieldName = nameof(ins.ScreenID);
            treeList1.ParentFieldName = nameof(ins.ParentScreenID);
            treeList1.Columns[nameof(ins.ScreenName)].Visible = false;
            treeList1.Columns[nameof(ins.ScreenName)].OptionsColumn.AllowEdit = false;
            treeList1.Columns[nameof(ins.ScreenCaption)].OptionsColumn.AllowEdit = false;
            if (Properties.Settings.Default.lungh == "0")
            {
                treeList1.Columns[nameof(ins.CanAdd)].Caption = "اضافه";
                treeList1.Columns[nameof(ins.CanDelete)].Caption = "حذف";
                treeList1.Columns[nameof(ins.CanEdit)].Caption = "تعديل";
                treeList1.Columns[nameof(ins.CanOpen)].Caption = "فتح";
                treeList1.Columns[nameof(ins.CanPrint)].Caption = "طباعه";
                treeList1.Columns[nameof(ins.CanShow)].Caption = "اظهار";
            }
            else
            {
                treeList1.Columns[nameof(ins.CanAdd)].Caption = "Add";
                treeList1.Columns[nameof(ins.CanDelete)].Caption = "Delete";
                treeList1.Columns[nameof(ins.CanEdit)].Caption = "Update";
                treeList1.Columns[nameof(ins.CanOpen)].Caption = "Open";
                treeList1.Columns[nameof(ins.CanPrint)].Caption = "Print";
                treeList1.Columns[nameof(ins.CanShow)].Caption = "Show";

            }

            treeList1.BestFitColumns();

            repoCheck = new RepositoryItemCheckEdit();
            repoCheck.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio2;
            repoCheck.CheckBoxOptions.SvgColorChecked = DXSkinColors.ForeColors.Information;
            repoCheck.CheckBoxOptions.SvgColorUnchecked = DXSkinColors.ForeColors.Warning ;

            treeList1.Columns[nameof(ins.CanAdd)].ColumnEdit =
             treeList1.Columns[nameof(ins.CanDelete)].ColumnEdit = 
            treeList1.Columns[nameof(ins.CanEdit)].ColumnEdit = 
            treeList1.Columns[nameof(ins.CanOpen)].ColumnEdit = 
            treeList1.Columns[nameof(ins.CanPrint)].ColumnEdit = 
            treeList1.Columns[nameof(ins.CanShow)].ColumnEdit = repoCheck;

          treeList1.Columns[nameof(ins.CanAdd)].Width =
       treeList1.Columns[nameof(ins.CanDelete)].Width =
         treeList1.Columns[nameof(ins.CanEdit)].Width =
         treeList1.Columns[nameof(ins.CanOpen)].Width =
        treeList1.Columns[nameof(ins.CanPrint)].Width =
         treeList1.Columns[nameof(ins.CanShow)].Width = 25;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}