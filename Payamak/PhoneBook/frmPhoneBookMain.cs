﻿using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Payamak.PhoneBook
{
    public partial class frmPhoneBookMain : MetroForm
    {
        private PhoneBookBussines cls;

        private void SetData()
        {
            try
            {
                FillCmb();
                txtName.Text = cls?.Name;
                txtTell.Text = cls?.Tell;
                if (cls?.Guid == Guid.Empty) cmbGroup.SelectedIndex = 0;
                else cmbGroup.SelectedIndex = (int) cls?.Group - 1;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmb()
        {
            try
            {
                cmbGroup.Items.Add(EnPhoneBookGroup.Peoples.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Users.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPhoneBookMain()
        {
            InitializeComponent();
            cls = new PhoneBookBussines();
            ucHeader.Text = "افزودن مخاطب جدید";
        }
        public frmPhoneBookMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = PhoneBookBussines.Get(guid);
            ucHeader.Text = !isShowMode ? $"ویرایش {cls.Name}" : $"مشاهده {cls.Name}";
            ucHeader.IsModified = true;
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void txtName_Enter(object sender, EventArgs e)=>txtSetter.Focus(txtName);
        private void txtName_Leave(object sender, EventArgs e)=>txtSetter.Follow(txtName);
        private void txtTell_Enter(object sender, EventArgs e)=>txtSetter.Focus(txtTell);
        private void txtTell_Leave(object sender, EventArgs e)=>txtSetter.Follow(txtTell);
        private async void frmPhoneBookMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                var list = await PhoneBookBussines.GetAllAsync();
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
        private void frmPhoneBookMain_KeyDown(object sender, KeyEventArgs e)
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
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();

                cls.Name = txtName.Text.Trim();
                cls.Tell = txtTell.Text.Trim();
                cls.Group = (EnPhoneBookGroup) cmbGroup.SelectedIndex + 1;
                cls.ParentGuid = Guid.Empty;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت مخاطب");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
