﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Check.CheckMoshtari;
using Accounting.Pardakht;
using Accounting.Sanad;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Accounting.Check.CheckShakhsi
{
    public partial class frmShowCheckSh : MetroForm
    {
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                var list = await PardakhtCheckShakhsiBussines.GetAllViewModeAsync(search);
                Invoke(new MethodInvoker(() => CheckBindingSource.DataSource = list.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowCheckSh() => InitializeComponent();

        private async void frmShowCheckSh_Load(object sender, EventArgs e) => await LoadDataAsync();
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
        private void frmShowCheckSh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
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
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtMain(EnOperation.CheckSh);
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuInsAvalDore_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtCheckAvalDore();
                if (frm.ShowDialog() == DialogResult.OK)
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
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;
                if (!avalDore)
                {
                    frmNotification.PublicInfo.ShowMessage("جهت ویرایش چک طی دوره، لطفا از سند دریافت اقدام نمایید");
                    return;
                }

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                var frm = new frmPardakhtCheckAvalDore(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;
                if (!avalDore)
                {
                    var frm_ = new frmPardakhtCheckSh(guid);
                    frm_.ShowDialog();
                    return;
                }

                var frm = new frmPardakhtCheckAvalDore(guid, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuViewSanad_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;
                if (!avalDore)
                {
                    var str = await PardakhtCheckShakhsiBussines.GetAsync(guid);
                    var rec = await PardakhtBussines.GetAsync(str.MasterGuid);
                    var sanad = await SanadBussines.GetAsync(rec.SanadNumber);
                    var frm_ = new frmSanadMain(sanad.Guid, true);
                    frm_.ShowDialog();
                    return;
                }

                var frm = new frmPardakhtCheckAvalDore(guid, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuBatel_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از ابطال چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await PardakhtCheckShakhsiBussines.GetAsync(guid);
                    var rec = await PardakhtBussines.GetAsync(str.MasterGuid);
                    rec.RemoveFromDetList(str);
                    res.AddReturnedValue(await rec.SaveAsync());
                    return;
                }

                var cls = await PardakhtCheckAvalDoreBussines.GetAsync(guid);
                res.AddReturnedValue(await cls.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ابطال چک پرداختنی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuKharj_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از نقدکردن چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await PardakhtCheckShakhsiBussines.GetAsync(guid);
                    res.AddReturnedValue(await clsCheckSh.NaqdAsync(str));
                    return;
                }

                var cls = await PardakhtCheckAvalDoreBussines.GetAsync(guid);
                res.AddReturnedValue(await clsCheckSh.NaqdAvalDoreAsync(cls));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در نقد کردن چک پرداختنی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuBargasht_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از برگشت زدن چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await PardakhtCheckShakhsiBussines.GetAsync(guid);
                    res.AddReturnedValue(await clsCheckSh.BargashtAsync(str));
                    return;
                }

                var cls = await PardakhtCheckAvalDoreBussines.GetAsync(guid);
                res.AddReturnedValue(await clsCheckSh.BargashtAvalDoreAsync(cls));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در برگشت زدن چک پرداختنی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
    }
}
