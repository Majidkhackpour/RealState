﻿using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.ViewModels;
using Print;

namespace Accounting.Sanad
{
    public partial class frmShowSanad : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await SanadBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => SanadBindingSource.DataSource = list.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetAccess()
        {
            try
            {
                var access = UserBussines.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.Sanad.Sanad_Insert ?? false;
                mnuEdit.Enabled = access?.Sanad.Sanad_Edit ?? false;
                mnuDelete.Enabled = access?.Sanad.Sanad_Delete ?? false;
                mnuView.Enabled = access?.Sanad.Sanad_View ?? false;
                mnuPrint.Enabled = access?.Sanad.Sanad_Print ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowSanad()
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست اسناد حسابداری";
            SetAccess();
        }

        private async void frmShowSanad_Load(object sender, EventArgs e) => await LoadDataAsync();
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmShowSanad_KeyDown(object sender, KeyEventArgs e)
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
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSanadMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
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
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var sanad = await SanadBussines.GetAsync(guid);
                if (sanad.SanadStatus == EnSanadStatus.Permament)
                {
                    frmNotification.PublicInfo.ShowMessage("شما مجاز به ویرایش سند دائمی نمی باشید ");
                    return;
                }
                if (sanad.SanadType == EnSanadType.Auto)
                {
                    frmNotification.PublicInfo.ShowMessage("شما مجاز به ویرایش سند اتومات نمی باشید ");
                    return;
                }

                var frm = new frmSanadMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
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

                var sanad = await SanadBussines.GetAsync(guid);
                if (sanad.SanadStatus == EnSanadStatus.Permament)
                {
                    res.AddError("شما مجاز به حذف سند دائمی نمی باشید");
                    return;
                }
                if (sanad.SanadType == EnSanadType.Auto)
                {
                    res.AddError("شما مجاز به حذف سند اتومات نمی باشید");
                    return;
                }

                if (MessageBox.Show(this,
                        $@"آیا از حذف سند به شماره{DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                        "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                res.AddReturnedValue(await sanad.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در حذف سند حسابداری");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmSanadMain(guid, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                var frm = new frmSetPrintSize(false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var sanad = await SanadBussines.GetAsync(guid);
                var list = new List<SanadPrintViewModel>();
                foreach (var item in sanad.Details)
                {
                    list.Add(new SanadPrintViewModel()
                    {
                        Debit = item.Debit,
                        Credit = item.Credit,
                        SanadNumber = sanad.Number,
                        DetailDesc = $"{item.MoeinName} * {item.TafsilCode} {item.TafsilName} * {item.Description}",
                        PrintDateSh = Calendar.MiladiToShamsi(DateTime.Now),
                        PrintTime = DateTime.Now.ToShortTimeString(),
                        SanadDateSh = sanad.DateSh,
                        SanadDesc = sanad.Description,
                        SanadTime = sanad.DateM.ToShortTimeString(),
                        UserName = sanad.UserName,
                        SumCredit = sanad.SumCredit,
                        SumDebit = sanad.SumDebit
                    });
                }

                list = list?.OrderBy(q => q.Credit)?.ToList();

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.Sanad, frm._PrintType) { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
