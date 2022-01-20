using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Bank;
using Accounting.Gardesh;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Peoples;
using Services;

namespace Accounting.Hesab
{
    public partial class frmShowTafsils : MetroForm
    {
        private bool _st = true;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await TafsilBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => TafsilBindingSource.DataSource =
                    list?.OrderBy(q => q.Code)?.Where(q => q.Status == _st)?.ToSortableBindingList()));
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
                mnuAdd.Enabled = access?.Tafsil.Tafsil_Insert ?? false;
                mnuEdit.Enabled = access?.Tafsil.Tafsil_Update ?? false;
                mnuDelete.Enabled = access?.Tafsil.Tafsil_Delete ?? false;
                mnuView.Enabled = access?.Tafsil.Tafsil_View ?? false;
                mnuGardesh.Enabled = access?.Tafsil.Tafsil_Gardesh ?? false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowTafsils(bool status = true)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست حساب های تفصیلی";
            _st = status;
            DGrid.Focus();
            SetAccess();
        }

        private async void frmShowTafsils_Load(object sender, EventArgs e) => await LoadDataAsync();
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private void frmShowTafsils_KeyDown(object sender, KeyEventArgs e)
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
                var frm = new frmTafsilMain();
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
                var tafsil = await TafsilBussines.GetAsync(guid);
                if (tafsil == null)
                {
                    frmNotification.PublicInfo.ShowMessage("حساب انتخاب شده معتبر نمی باشد");
                    return;
                }
                if (tafsil.isSystem)
                {
                    frmNotification.PublicInfo.ShowMessage("شما مجاز به ویرایش حساب های پیش فرض نمی باشید");
                    return;
                }

                if (tafsil.HesabType == HesabType.Customer)
                {
                    var pe = await PeoplesBussines.GetAsync(guid, null);
                    var frm = new frmPeoples(pe, false);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        await LoadDataAsync(txtSearch.Text);
                    return;
                }
                if (tafsil.HesabType == HesabType.Bank)
                {
                    var frm = new frmBankMain(await BankBussines.GetAsync(guid), false);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        await LoadDataAsync(txtSearch.Text);
                    return;
                }
                var obj = await TafsilBussines.GetAsync(guid);
                if (obj == null) return;
                var _frm = new frmTafsilMain(obj, false);
                if (_frm.ShowDialog(this) == DialogResult.OK)
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
                var tafsil = await TafsilBussines.GetAsync(guid);
                if (tafsil == null)
                {
                    res.AddError("حساب انتخاب شده معتبر نمی باشد");
                    return;
                }

                if (_st)
                {
                    if (tafsil.isSystem)
                    {
                        res.AddError("شما مجاز به حذف حساب های پیش فرض نمی باشید");
                        return;
                    }
                    if (tafsil.Account != 0)
                    {
                        res.AddError(
                            $"حساب {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} به علت داشتن گردش، قادر به حذف نمی باشد");
                        return;
                    }
                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    if (tafsil.HesabType == HesabType.Customer)
                    {
                        var cus = await PeoplesBussines.GetAsync(tafsil.Guid,null);
                        if (cus == null) return;
                        res.AddReturnedValue(await cus.ChangeStatusAsync(false));
                        return;
                    }
                    if (tafsil.HesabType == HesabType.Bank)
                    {
                        var bank = await BankBussines.GetAsync(tafsil.Guid);
                        res.AddReturnedValue(await bank.ChangeStatusAsync(false));
                        return;
                    }

                    res.AddReturnedValue(await tafsil.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    if (tafsil.HesabType == HesabType.Customer)
                    {
                        var cus = await PeoplesBussines.GetAsync(tafsil.Guid,null);
                        if (cus.GroupGuid == Guid.Empty)
                        {
                            var frm = new frmChangeGroup(cus);
                            if (frm.ShowDialog(this) != DialogResult.OK) return;
                        }
                        res.AddReturnedValue(await cus.ChangeStatusAsync(true));
                        return;
                    }
                    if (tafsil.HesabType == HesabType.Bank)
                    {
                        var bank = await BankBussines.GetAsync(tafsil.Guid);
                        res.AddReturnedValue(await bank.ChangeStatusAsync(true));
                        return;
                    }

                    res.AddReturnedValue(await tafsil.ChangeStatusAsync(true));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در تغییر وضعیت حساب تفصیلی");
                else await LoadDataAsync(txtSearch.Text);
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var tafsil = await TafsilBussines.GetAsync(guid);
                if (tafsil == null)
                {
                    frmNotification.PublicInfo.ShowMessage("حساب انتخاب شده معتبر نمی باشد");
                    return;
                }
                if (tafsil.HesabType == HesabType.Customer)
                {
                    var pe = await PeoplesBussines.GetAsync(guid, null);
                    var frm = new frmPeoples(pe, true);
                    frm.ShowDialog(this);
                    return;
                }
                if (tafsil.HesabType == HesabType.Bank)
                {
                    var frm = new frmBankMain(await BankBussines.GetAsync(guid), true);
                    frm.ShowDialog(this);
                    return;
                }
                var obj = await TafsilBussines.GetAsync(guid);
                if (obj == null) return;
                var _frm = new frmTafsilMain(obj, true);
                _frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuGardesh_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var tafsilGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmGardeshTafsil(tafsilGuid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
