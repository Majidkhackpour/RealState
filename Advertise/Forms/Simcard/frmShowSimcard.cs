using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Advertise.Classes;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace Advertise.Forms.Simcard
{
    public partial class frmShowSimcard : Form
    {
        private bool _st = true;
        public Guid SelectedGuid { get; set; }
        public async Task<string> GetNumberAsync()
        {
            try
            {
                if (SelectedGuid == Guid.Empty) return "";
                var sim = await SimcardBussines.GetAsync(SelectedGuid);
                return sim == null ? "" : sim.Number.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private bool isShowMode = false;
        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                var list = await SimcardBussines.GetAllAsync(search);
                Invoke(new MethodInvoker(() => simBindingSource.DataSource =
                    list.Where(q => q.Status == status).OrderBy(q => q.Owner).ToSortableBindingList()));
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
                mnuAdd.Enabled = access?.Simcard.Simcard_Insert ?? false;
                mnuEdit.Enabled = access?.Simcard.Simcard_Update ?? false;
                mnuDelete.Enabled = access?.Simcard.Simcard_Delete ?? false;
                mnuStatus.Enabled = access?.Simcard.Simcard_Disable ?? false;
                mnuView.Enabled = access?.Simcard.Simcard_View ?? false;
                mnuLoginDivar.Enabled = access?.Simcard.Simcard_Divar_Token ?? false;
                mnuDelDivarToken.Enabled = access?.Simcard.Simcard_Delete_Token ?? false;
                mnuLoginSheypoor.Enabled = access?.Simcard.Simcard_Shepoor_Token ?? false;
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
        public frmShowSimcard(bool _isShowMode)
        {
            InitializeComponent();
            SetAccess();
            DGrid.Focus();
            isShowMode = _isShowMode;
            if (_isShowMode)
            {
                contextMenu.Enabled = false;
                btnSelect.Visible = true;
            }
            else
            {
                contextMenu.Enabled = true;
                btnSelect.Visible = false;
            }
        }

        private async void frmShowSimcard_Load(object sender, EventArgs e) => await LoadDataAsync(ST);
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
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
        private void frmShowSimcard_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        if (isShowMode)
                        {
                            btnSelect.PerformClick();
                            return;
                        }

                        mnuEdit.PerformClick();
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
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtSearch.Focus();
                txtSearch.Text = e.KeyChar.ToString();
                txtSearch.SelectionStart = 9999;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!isShowMode) return;
                btnSelect.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
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
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await SimcardBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await SimcardBussines.GetAsync(guid);
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
                if (res.HasError) this.ShowError(res, "خطا در تغییر وضعیت سیمکارت");
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private async void mnuDelSheypoorToken_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                    res.AddError("شماره انتخاب شده صحیح نمی باشد");

                if (res.HasError) return;

                if (MessageBox.Show(this, "آیا از حذف توکن ارتباط با شیپور اطمینان دارید؟", "حذف توکن ارتباط شیپور",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

                var token = await AdvTokenBussines.GetTokenAsync(number, AdvertiseType.Sheypoor);
                if (token == null) return;

                res.AddReturnedValue(await token.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در حذف توکن شیپور");
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private async void mnuDelDivarToken_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                    res.AddError("شماره انتخاب شده صحیح نمی باشد");

                if (res.HasError) return;

                if (MessageBox.Show(this, "آیا از حذف توکن ارتباط با دیوار اطمینان دارید؟", "حذف توکن ارتباط دیوار",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

                var token = await AdvTokenBussines.GetTokenAsync(number, AdvertiseType.Divar);
                if (token == null) return;

                res.AddReturnedValue(await token.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در حذف توکن دیوار");
                else await LoadDataAsync(ST, txtSearch.Text);
            }
        }
        private async void mnuLoginSheypoor_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                    res.AddError(
                        "شما مجاز به دریافت توکن داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");


                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                    res.AddError("شماره انتخاب شده صحیح نمی باشد");

                if (res.HasError) return;

                var sheypoor = SheypoorAdv.GetInstance();
                var login = await sheypoor.Login(number, true);
                if (login)
                    await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در لاگین شیپور");
            }
        }
        private async void mnuLoginDivar_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                    res.AddError(
                        "شما مجاز به دریافت توکن داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                    res.AddError("شماره انتخاب شده صحیح نمی باشد");
                if (res.HasError) return;
                var divar = DivarAdv.GetInstance();
                var login = await divar.Login(number, true);
                if (login)
                    await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در لاگین دیوار");
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await SimcardBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmSimcardMain(obj, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuStatus_Click(object sender, EventArgs e) => ST = !ST;
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
                var obj = await SimcardBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmSimcardMain(obj, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
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
                var frm = new frmSimcardMain(new SimcardBussines(), false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
