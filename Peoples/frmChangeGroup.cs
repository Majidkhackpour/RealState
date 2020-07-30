﻿using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using PacketParser.Services;

namespace Peoples
{
    public partial class frmChangeGroup : MetroForm
    {
        private PeoplesBussines cls;
        private void LoadGroups()
        {
            try
            {
                var list = PeopleGroupBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name);
                groupBundingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmChangeGroup(PeoplesBussines _cls)
        {
            InitializeComponent();
            cls = _cls;
        }

        private void frmChangeGroup_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmChangeGroup_KeyDown(object sender, KeyEventArgs e)
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
                if (groupBundingSource.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("گروه نمی تواند خالی باشد");
                    cmbGroup.Focus();
                    return;
                }

                cls.GroupGuid = (Guid) cmbGroup.SelectedValue;


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
