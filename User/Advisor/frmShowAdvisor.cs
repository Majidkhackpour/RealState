﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Bank;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings;

namespace User.Advisor
{
    public partial class frmShowAdvisor : MetroForm
    {
        private bool _st = true;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await AdvisorBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => BankBindingSource.DataSource =
                    list.OrderBy(q => q.Name).Where(q => q.Status == _st).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowAdvisor(bool status = true)
        {
            try
            {
                InitializeComponent();
                ucHeader.Text = "نمایش لیست مشاوران";
                _st = status;
                DGrid.Focus();
                if (VersionAccess.Accounting) return;
                DGrid.Columns[dgAccount.Index].Visible = false;
                DGrid.Columns[dgAccount_.Index].Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        private async void frmShowAdvisor_Load(object sender, EventArgs e) => await LoadDataAsync();
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private void frmShowAdvisor_KeyDown(object sender, KeyEventArgs e)
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
                var frm = new frmAdvisorMain(new AdvisorBussines(), false);
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
                if (!_st)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var tafsil = await AdvisorBussines.GetAsync(guid);
                if (tafsil == null)
                {
                    frmNotification.PublicInfo.ShowMessage("حساب انتخاب شده معتبر نمی باشد");
                    return;
                }

                var obj = await AdvisorBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmAdvisorMain(obj, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await AdvisorBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmAdvisorMain(obj, true);
                frm.ShowDialog(this);
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
                    var hazine = await AdvisorBussines.GetAsync(guid);
                    if (hazine == null) return;
                    if (hazine.Account != 0)
                    {
                        res.AddError("به دلیل داشتن گردش حساب، شما مجاز به حذف مشاور نمی باشید");
                        return;
                    }

                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    res.AddReturnedValue(await hazine.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await AdvisorBussines.GetAsync(guid);
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
                if (res.HasError) this.ShowError(res, "خطا در تغییر وضعیت حساب مشاور");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
    }
}
