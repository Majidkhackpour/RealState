using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace Advertise.Forms.Simcard
{
    public partial class frmShowSimcard : MetroForm
    {
        private bool _st = true;
        public Guid SelectedGuid { get; set; }
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
                var access = clsUser.CurrentUser.UserAccess;
                btnInsert.Enabled = access?.Simcard.Simcard_Insert ?? false;
                btnEdit.Enabled = access?.Simcard.Simcard_Update ?? false;
                btnDelete.Enabled = access?.Simcard.Simcard_Delete ?? false;
                btnChangeStatus.Enabled = access?.Simcard.Simcard_Disable ?? false;
                btnView.Enabled = access?.Simcard.Simcard_View ?? false;
                btnLoginDivar.Enabled = access?.Simcard.Simcard_Divar_Token ?? false;
                btnDelDivarToken.Enabled = access?.Simcard.Simcard_Delete_Token ?? false;
                btnLoginSheypoor.Enabled = access?.Simcard.Simcard_Shepoor_Token ?? false;
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
                    btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
                    Task.Run(() => LoadDataAsync(ST, txtSearch.Text));
                    btnDelete.Text = "حذف (Del)";
                }
                else
                {
                    btnChangeStatus.Text = "فعال (Ctrl+S)";
                    Task.Run(() => LoadDataAsync(ST, txtSearch.Text));
                    btnDelete.Text = "فعال کردن";
                }
            }
        }
        public frmShowSimcard(bool _isShowMode)
        {
            InitializeComponent();
            SetAccess();

            isShowMode = _isShowMode;
            if (isShowMode)
            {
                btnDelete.Visible = false;
                btnInsert.Visible = false;
                btnEdit.Visible = false;
                btnView.Visible = false;
                btnChangeStatus.Visible = false;
                btnSelect.Visible = true;
                btnOther.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnInsert.Visible = true;
                btnEdit.Visible = true;
                btnView.Visible = true;
                btnChangeStatus.Visible = true;
                btnSelect.Visible = false;
                btnOther.Visible = true;
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
                        btnInsert.PerformClick();
                        break;
                    case Keys.F7:
                        btnEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        btnDelete.PerformClick();
                        break;
                    case Keys.F12:
                        btnView.PerformClick();
                        break;
                    case Keys.S:
                        if (e.Control) ST = !ST;
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ST = !ST;
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    if (MessageBox.Show(
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await SimcardBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(false);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show(
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await SimcardBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(true);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }
                }

                await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSimcardMain();
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync(ST);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
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
                var frm = new frmSimcardMain(guid, false);
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmSimcardMain(guid, true);
                frm.ShowDialog();
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
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به دریافت توکن داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شماره انتخاب شده صحیح نمی باشد");
                    return;
                }
                var divar = DivarAdv.GetInstance();
                await divar.Login(number, true);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnLoginSheypoor_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به دریافت توکن داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شماره انتخاب شده صحیح نمی باشد");
                    return;
                }
                var sheypoor = SheypoorAdv.GetInstance();
                await sheypoor.Login(number, true);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnDelDivarToken_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شماره انتخاب شده صحیح نمی باشد");
                    return;
                }

                if (MessageBox.Show("آیا از حذف توکن ارتباط با دیوار اطمینان دارید؟", "حذف توکن ارتباط دیوار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

                var token = await AdvTokenBussines.GetTokenAsync(number, AdvertiseType.Divar);
                if (token == null) return;

                var res = await token.RemoveAsync();

                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnDeleteSheypoorToken_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var number = DGrid[dgNumber.Index, DGrid.CurrentRow.Index].Value.ToString().ParseToLong();
                if (number == 0)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شماره انتخاب شده صحیح نمی باشد");
                    return;
                }

                if (MessageBox.Show("آیا از حذف توکن ارتباط با شیپور اطمینان دارید؟", "حذف توکن ارتباط شیپور", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

                var token = await AdvTokenBussines.GetTokenAsync(number, AdvertiseType.Sheypoor);
                if (token == null) return;

                var res = await token.RemoveAsync();

                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                await LoadDataAsync(ST, txtSearch.Text);
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
    }
}
