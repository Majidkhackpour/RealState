using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Bank;
using Accounting.Hesab;
using Accounting.Pardakht;
using Accounting.Reception;
using Accounting.Sanad;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Peoples;
using Services;

namespace Accounting.Check.CheckMoshtari
{
    public partial class frmShowCheckM : MetroForm
    {
        private bool isSelectMode = false;
        public Guid SelectedGuid { get; set; }
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                var list = await ReceptionCheckBussines.GetAllViewModeAsync(search);
                Invoke(new MethodInvoker(() => CheckBindingSource.DataSource = list.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SelectCheck()
        {
            try
            {
                if (!isSelectMode) return;
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowCheckM(bool _isSelectMode)
        {
            InitializeComponent();
            isSelectMode = _isSelectMode;
            contextMenu.Enabled = !_isSelectMode;
        }

        private async void frmShowCheckM_Load(object sender, EventArgs e) => await LoadDataAsync();
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
        private void frmShowCheckM_KeyDown(object sender, KeyEventArgs e)
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
                        if (isSelectMode) SelectCheck();
                        else mnuEdit.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_DoubleClick(object sender, EventArgs e) => SelectCheck();
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionMain(EnOperation.CheckM);
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
                var frm = new frmCheckM_AvalDore();
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

                var frm = new frmCheckM_AvalDore(guid, false);
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
                    var frm_ = new frmReceptionCheck(guid);
                    frm_.ShowDialog();
                    return;
                }

                var frm = new frmCheckM_AvalDore(guid, true);
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
                    var str = await ReceptionCheckBussines.GetAsync(guid);
                    var rec = await ReceptionBussines.GetAsync(str.MasterGuid.Value);
                    var sanad = await SanadBussines.GetAsync(rec.SanadNumber);
                    var frm_ = new frmSanadMain(sanad.Guid, true);
                    frm_.ShowDialog();
                    return;
                }

                var frm = new frmCheckM_AvalDore(guid, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuViewPardazande_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[DgPardazandeGuid.Index, DGrid.CurrentRow.Index].Value;

                var tafsil = await TafsilBussines.GetAsync(guid);
                if (tafsil == null) return;

                if (tafsil.HesabType == HesabType.Bank)
                {
                    var frm = new frmBankMain(guid, true);
                    frm.ShowDialog();
                    return;
                }

                if (tafsil.HesabType == HesabType.Customer)
                {
                    var frm = new frmPeoples(guid, true);
                    frm.ShowDialog();
                    return;
                }

                var _frm = new frmTafsilMain(guid, true);
                _frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuKharj_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var st = (EnCheckM)DGrid[dgStatus.Index, DGrid.CurrentRow.Index].Value;
                if (st == EnCheckM.Kharj || st == EnCheckM.Naqd)
                {
                    frmNotification.PublicInfo.ShowMessage($"شما مجاز به خرج چک {st.GetDisplay()} نمی باشید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var price = (decimal)DGrid[dgPrice.Index, DGrid.CurrentRow.Index].Value;
                var bankName = DGrid[dgBankName.Index, DGrid.CurrentRow.Index].Value.ToString();
                var checkNumber = DGrid[dgCheckNumber.Index, DGrid.CurrentRow.Index].Value.ToString();
                var sarresid = DGrid[dgSarresid.Index, DGrid.CurrentRow.Index].Value.ToString();

                var cls = new PardakhtBussines();
                var pardakhtcheck = new PardakhtCheckMoshtariBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Description = $"خرج چک {checkNumber} {bankName} به سررسید {sarresid}",
                    Price = price,
                    CheckGuid = guid,
                    MasterGuid = cls.Guid
                };
                cls.AddToDetList(pardakhtcheck);
                var frm = new frmPardakhtMain(cls);
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync();
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
                var st = (EnCheckM)DGrid[dgStatus.Index, DGrid.CurrentRow.Index].Value;
                if (st == EnCheckM.Bargashti || st == EnCheckM.Naqd)
                {
                    frmNotification.PublicInfo.ShowMessage($"شما مجاز به ابطال چک {st.GetDisplay()} نمی باشید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از ابطال چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await ReceptionCheckBussines.GetAsync(guid);
                    var rec = await ReceptionBussines.GetAsync(str.MasterGuid.Value);
                    rec.RemoveFromDetList(str);
                    res.AddReturnedValue(await rec.SaveAsync());
                    return;
                }

                var cls = await ReceptionCheckAvalDoreBussines.GetAsync(guid);
                res.AddReturnedValue(await cls.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ابطال چک دریافتنی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuNaqd_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var st = (EnCheckM)DGrid[dgStatus.Index, DGrid.CurrentRow.Index].Value;
                if (st == EnCheckM.Naqd)
                {
                    frmNotification.PublicInfo.ShowMessage($"شما مجاز به نقد چک {st.GetDisplay()} نمی باشید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از نقدکردن چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await ReceptionCheckBussines.GetAsync(guid);
                    res.AddReturnedValue(await clsCheckM.NaqdAsync(str));
                    return;
                }

                var cls = await ReceptionCheckAvalDoreBussines.GetAsync(guid);
                res.AddReturnedValue(await clsCheckM.NaqdAvalDoreAsync(cls));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در نقد کردن چک دریافتنی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuVagozarSandouq_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var st = (EnCheckM)DGrid[dgStatus.Index, DGrid.CurrentRow.Index].Value;
                if (st == EnCheckM.Kharj || st == EnCheckM.Naqd)
                {
                    frmNotification.PublicInfo.ShowMessage($"شما مجاز به واگذارکردن چک {st.GetDisplay()} نمی باشید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از واگذارکردن چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await ReceptionCheckBussines.GetAsync(guid);
                    var frm = new frmCheckM_Vagozar(str, HesabType.Sandouq);
                    if (frm.ShowDialog() == DialogResult.OK) await LoadDataAsync(txtSearch.Text);
                    return;
                }

                var cls = await ReceptionCheckAvalDoreBussines.GetAsync(guid);
                var frm_ = new frmCheckM_Vagozar(cls, HesabType.Sandouq);
                if (frm_.ShowDialog() == DialogResult.OK) await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuVagozarBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var st = (EnCheckM)DGrid[dgStatus.Index, DGrid.CurrentRow.Index].Value;
                if (st == EnCheckM.Kharj || st == EnCheckM.Naqd)
                {
                    frmNotification.PublicInfo.ShowMessage($"شما مجاز به واگذارکردن چک {st.GetDisplay()} نمی باشید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از واگذارکردن چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await ReceptionCheckBussines.GetAsync(guid);
                    var frm = new frmCheckM_Vagozar(str, HesabType.Bank);
                    if (frm.ShowDialog() == DialogResult.OK) await LoadDataAsync(txtSearch.Text);
                    return;
                }

                var cls = await ReceptionCheckAvalDoreBussines.GetAsync(guid);
                var frm_ = new frmCheckM_Vagozar(cls, HesabType.Bank);
                if (frm_.ShowDialog() == DialogResult.OK) await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuBargasht_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var st = (EnCheckM)DGrid[dgStatus.Index, DGrid.CurrentRow.Index].Value;
                if (st == EnCheckM.Naqd)
                {
                    frmNotification.PublicInfo.ShowMessage($"شما مجاز به برگشت چک {st.GetDisplay()} نمی باشید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var avalDore = (bool)DGrid[dgAvalDore.Index, DGrid.CurrentRow.Index].Value;

                if (MessageBox.Show("آیا از برگشت زدن چک اطمینان دارید؟", "پیغام سیستم", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.No) return;

                if (!avalDore)
                {
                    var str = await ReceptionCheckBussines.GetAsync(guid);
                    res.AddReturnedValue(await clsCheckM.BargashtAsync(str));
                    return;
                }

                var cls = await ReceptionCheckAvalDoreBussines.GetAsync(guid);
                res.AddReturnedValue(await clsCheckM.BargashtAvalDoreAsync(cls));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در برگشت زدن چک دریافتنی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
    }
}
