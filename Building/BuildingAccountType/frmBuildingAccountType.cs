﻿using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using PacketParser.Services;

namespace Building.BuildingAccountType
{
    public partial class frmBuildingAccountType : MetroForm
    {
        private BuildingAccountTypeBussines cls;
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
        public frmBuildingAccountType()
        {
            InitializeComponent();
            cls = new BuildingAccountTypeBussines();
        }
        public frmBuildingAccountType(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = BuildingAccountTypeBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtName);
        }

        private void frmBuildingAccountType_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmBuildingAccountType_KeyDown(object sender, KeyEventArgs e)
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان نمی تواند خالی باشد");
                    txtName.Focus();
                    return;
                }

                if (!await BuildingAccountTypeBussines.CheckNameAsync(txtName.Text.Trim(), cls.Guid))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان وارد شده تکراری است");
                    txtName.Focus();
                    return;
                }

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtName.Text.Trim();

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}