using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace Accounting.Check.DasteCheck
{
    public partial class frmShowDasteCheck : MetroForm
    {
        private bool _st = true;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await DasteCheckBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => DasteCheckBindingSource.DataSource =
                    list.Where(q => q.Status == status).ToSortableBindingList()));
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

        public frmShowDasteCheck()
        {
            InitializeComponent();
            DGrid.Focus();
        }

        private async void frmShowDasteCheck_Load(object sender, EventArgs e) => await LoadDataAsync(ST);
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
        private void frmShowDasteCheck_KeyDown(object sender, KeyEventArgs e)
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
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) =>
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmDasteCheckMain();
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
                var dasteChek = await DasteCheckBussines.GetAsync(guid);
                if (dasteChek == null)
                {
                    frmNotification.PublicInfo.ShowMessage("دسته چک انتخابی معتبر نمی باشد");
                    return;
                }

                var masraf = dasteChek.CheckPages.Any(q => q.CheckStatus != EnCheckSh.Mojoud);
                if (masraf)
                {
                    frmNotification.PublicInfo.ShowMessage("به علت کشیدن چک از این دسته چک، شما مجاز به ویرایش آن نمی باشید");
                    return;
                }
                var frm = new frmDasteCheckMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
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
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmDasteCheckMain(guid, true);
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
                var dasteChek = await DasteCheckBussines.GetAsync(guid);
                if (ST)
                {
                    if (dasteChek == null)
                    {
                        frmNotification.PublicInfo.ShowMessage("دسته چک انتخابی معتبر نمی باشد");
                        return;
                    }
                    var masraf = dasteChek.CheckPages.Any(q => q.CheckStatus != EnCheckSh.Mojoud);
                    if (masraf)
                    {
                        frmNotification.PublicInfo.ShowMessage("به علت کشیدن چک از این دسته چک، شما مجاز به ویرایش آن نمی باشید");
                        return;
                    }
                    if (MessageBox.Show(this,
                            $@"آیا از حذف دسته چک {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    res.AddReturnedValue(await dasteChek.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن دسته چک {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    res.AddReturnedValue(await dasteChek.ChangeStatusAsync(true));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در تغییر وضعیت حساب بانکی");
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private async void mnuShowPages_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var dasteChek = await DasteCheckBussines.GetAsync(guid);
                if (dasteChek == null)
                {
                    frmNotification.PublicInfo.ShowMessage("دسته چک انتخابی معتبر نمی باشد");
                    return;
                }
                var frm = new frmShowCheckPages(dasteChek);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
