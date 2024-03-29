﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace Payamak.PhoneBook
{
    public partial class frmShowPhoneBook : MetroForm
    {
        public Guid ParentGuid { get; set; }
        private bool _st = true, _isLoadData = true;

        private void SetAccess()
        {
            try
            {
                var access = UserBussines.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.PhoneBook.PhoneBook_Insert ?? false;
                mnuEdit.Enabled = access?.PhoneBook.PhoneBook_Update ?? false;
                mnuDelete.Enabled = access?.PhoneBook.PhoneBook_Delete ?? false;
                mnuView.Enabled = access?.PhoneBook.PhoneBook_View ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task LoadDataAsync(string search = "")
        {
            try
            {
                if (!_isLoadData) return Task.CompletedTask;
                Invoke(new MethodInvoker(async () =>
                {
                    var list = await PhoneBookBussines.GetAllAsync(ParentGuid, search, (EnPhoneBookGroup)cmbGroup.SelectedIndex);
                    phoneBookBindingSource.DataSource = list?.Where(q => q.Status == _st)?.OrderBy(q => q.Name)?.ToSortableBindingList();
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private void LoadGroups()
        {
            try
            {
                cmbGroup.Items.Add(EnPhoneBookGroup.All.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Peoples.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Users.GetDisplay());
                cmbGroup.Items.Add(EnPhoneBookGroup.Divar.GetDisplay());
                cmbGroup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowPhoneBook(Guid guid, bool status = true)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش شماره های دفترچه تلفن";
            _st = status;
            ParentGuid = guid;
            contextMenu.Enabled = false;
            cmbGroup.Enabled = false;
            SetAccess();
        }
        public frmShowPhoneBook(bool status = true)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش شماره های دفترچه تلفن";
            _st = status;
            ParentGuid = Guid.Empty;
            SetAccess();
        }
        public frmShowPhoneBook(List<PhoneBookBussines> lst)
        {
            try
            {
                InitializeComponent();
                ucHeader.Text = "نمایش شماره های دفترچه تلفن";
                phoneBookBindingSource.DataSource = lst?.Where(q => q.Status == _st)?.OrderBy(q => q.Name)?.ToSortableBindingList();
                _isLoadData = false;
                txtSearch.Enabled = cmbGroup.Enabled = contextMenu.Enabled = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmShowPhoneBook_Load(object sender, EventArgs e)
        {
            LoadGroups();
            await LoadDataAsync();
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private void frmShowPhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        mnuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F12:
                        mnuView.PerformClick();
                        break;
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        mnuEdit.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbGroup_SelectedIndexChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await PhoneBookBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmPhoneBookMain(obj, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!_st)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await PhoneBookBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmPhoneBookMain(obj, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPhoneBookMain(new PhoneBookBussines(), false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (_st)
                {
                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PhoneBookBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PhoneBookBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(true));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در تغییر وضعیت مخاطب");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
    }
}
