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

        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await TafsilBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => TafsilBindingSource.DataSource =
                    list.OrderBy(q => q.Code).Where(q => q.Status == status).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public bool ST
        {
            get => _st;
            set
            {
                _st = value;
                if (_st)
                {
                    mnuStatus.Text = "غیرفعال (Ctrl+S)";
                    Task.Run(() => LoadDataAsync(ST, txtSearch.Text));
                    mnuDelete.Text = "حذف (Del)";
                }
                else
                {
                    mnuStatus.Text = "فعال (Ctrl+S)";
                    Task.Run(() => LoadDataAsync(ST, txtSearch.Text));
                    mnuDelete.Text = "فعال کردن";
                }
            }
        }

        public frmShowTafsils()
        {
            InitializeComponent();
            DGrid.Focus();
        }

        private async void frmShowTafsils_Load(object sender, EventArgs e) => await LoadDataAsync(ST);
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
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
                    case Keys.S:
                        if (e.Control) ST = !ST;
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
        private void mnuStatus_Click(object sender, EventArgs e) => ST = !ST;
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmTafsilMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST);
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
                if (!ST)
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
                    var frm = new frmPeoples(guid, false);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        await LoadDataAsync(ST, txtSearch.Text);
                    return;
                }
                if (tafsil.HesabType == HesabType.Bank)
                {
                    var frm = new frmBankMain(guid, false);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        await LoadDataAsync(ST, txtSearch.Text);
                    return;
                }

                var _frm = new frmTafsilMain(guid, false);
                if (_frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
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

                if (ST)
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
                        var cus = await PeoplesBussines.GetAsync(tafsil.Guid);
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
                        var cus = await PeoplesBussines.GetAsync(tafsil.Guid);
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
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var tafsil = TafsilBussines.Get(guid);
                if (tafsil == null)
                {
                    frmNotification.PublicInfo.ShowMessage("حساب انتخاب شده معتبر نمی باشد");
                    return;
                }
                if (tafsil.HesabType == HesabType.Customer)
                {
                    var frm = new frmPeoples(guid, true);
                    frm.ShowDialog();
                    return;
                }
                if (tafsil.HesabType == HesabType.Bank)
                {
                    var frm = new frmBankMain(guid, true);
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
        private void mnuGardesh_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var tafsilGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmGardeshTafsil(tafsilGuid);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
