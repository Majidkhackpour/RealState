﻿using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Building.FloorCover
{
    public partial class frmFloorCoverMain : MetroForm
    {
        private FloorCoverBussines cls;
        private EnLogAction action;
        private void SetData()
        {
            try
            {
                txtName.Text = cls?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmFloorCoverMain()
        {
            InitializeComponent();
            cls = new FloorCoverBussines();
            action = EnLogAction.Insert;
        }
        public frmFloorCoverMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = FloorCoverBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtName);
        }

        private async void frmFloorCoverMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                var list = await FloorCoverBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmFloorCoverMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    res.AddError("عنوان نمی تواند خالی باشد");
                    txtName.Focus();
                }

                if (!await FloorCoverBussines.CheckNameAsync(txtName.Text.Trim(), cls.Guid))
                {
                    res.AddError("عنوان وارد شده تکراری است");
                    txtName.Focus();
                }

                if (res.HasError) return;
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtName.Text.Trim();

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت نوع کفپوش");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    User.UserLog.Save(action, EnLogPart.FloorCover);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
