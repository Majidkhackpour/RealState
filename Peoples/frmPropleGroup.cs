﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Peoples
{
    public partial class frmPropleGroup : MetroForm
    {
        private PeopleGroupBussines cls;

        private async Task SetDataAsync()
        {
            try
            {
                var list = await PeopleGroupBussines.GetAllAsync();
                var a = new PeopleGroupBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[هیچکدام]",
                    ParentGuid = Guid.Empty
                };
                list.Add(a);
                GroupBindingSource.DataSource =
                    list.Where(q => q.ParentGuid == Guid.Empty).OrderBy(q => q.Name).ToList();
                txtName.Text = cls?.Name;
                if (cls?.Guid == Guid.Empty) cmbGroup.SelectedIndex = 0;
                else cmbGroup.SelectedValue = (Guid)cls?.ParentGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPropleGroup(PeopleGroupBussines obj)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (cls.Guid == Guid.Empty)
                    ucHeader.Text = "افزودن گروه اشخاص جدید";
                else
                {
                    ucHeader.Text = $"ویرایش گروه {cls.Name}";
                    ucHeader.IsModified = true;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmPropleGroup_Load(object sender, EventArgs e)
        {
            try
            {
                await SetDataAsync();
                var myCollection = new AutoCompleteStringCollection();
                var list = await PeopleGroupBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.Name);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtCity_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtCity_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmPropleGroup_KeyDown(object sender, KeyEventArgs e)
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
                    res.AddError("عنوان گروه نمی تواند خالی باشد");
                    txtName.Focus();
                }

                if (!await PeopleGroupBussines.CheckNameAsync(txtName.Text, cls.Guid))
                {
                    var pg = await PeopleGroupBussines.GetAsync(txtName.Text);
                    if (pg.Status)
                    {
                        res.AddError("عنوان گروه تکراری است");
                        txtName.Focus();
                    }
                    else
                    {
                        pg.ParentGuid = (Guid)cmbGroup.SelectedValue;
                        pg.Status = true;
                        cls.Modified = DateTime.Now;
                        cls.ServerStatus = ServerStatus.None;
                        var res2 = await cls.SaveAsync();
                        if (!res2.HasError) return;
                        frmNotification.PublicInfo.ShowMessage(res2.ErrorMessage);
                        return;
                    }

                    return;
                }

                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Name = txtName.Text;
                cls.Modified = DateTime.Now;
                cls.ParentGuid = (Guid)cmbGroup.SelectedValue;
                cls.ServerStatus = ServerStatus.None;
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
                    this.ShowError(res, "خطا در ثبت گروه اشخاص");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
