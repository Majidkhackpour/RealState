using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace Accounting.Reception
{
    public partial class frmShowReception : MetroForm
    {
        private Guid _receptorGuid;
        private EnAccountingType type;
        private bool _st = true;
        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                var list = await ReceptionBussines.GetAllAsync(search, _receptorGuid);
                Invoke(new MethodInvoker(() =>
                    receptionBindingSource.DataSource = list.Where(q => q.Status == status).ToSortableBindingList()));
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
                mnuAdd.Enabled = access?.Reception.Reception_Insert ?? false;
                mnuEdit.Enabled = access?.Reception.Reception_Update ?? false;
                mnuDelete.Enabled = access?.Reception.Reception_Delete ?? false;
                mnuStatus.Enabled = access?.Reception.Reception_Disable ?? false;
                mnuView.Enabled = access?.Reception.Reception_View ?? false;
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
                    mnuStatus.Text = "فعال کردن";
                }
            }
        }
        public frmShowReception(Guid receptorGuid, EnAccountingType _type)
        {
            InitializeComponent();
            DGrid.Focus();
            _receptorGuid = receptorGuid;
            type = _type;
            SetLabels();
            SetAccess();
        }

        private void SetLabels()
        {
            try
            {
                if (type == EnAccountingType.Peoples)
                {
                    var hesab = PeoplesBussines.Get(_receptorGuid);
                    if (hesab == null) return;
                    lblName.Text = hesab.Name;
                }
                else if (type == EnAccountingType.Users)
                {
                    var hesab = UserBussines.Get(_receptorGuid);
                    if (hesab == null) return;
                    lblName.Text = hesab.Name;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmShowReception_Load(object sender, EventArgs e) => await LoadDataAsync(ST);
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
        private void frmShowReception_KeyDown(object sender, KeyEventArgs e)
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
                        Close();
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
                var frm = new frmReceptionMain(_receptorGuid, type);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST);
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
                var guid = (Guid) DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    if (MessageBox.Show(this,
                            $@"آیا از حذف سند دریافت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ReceptionBussines.GetAsync(guid);

                    res.AddReturnedValue(await prd.ChangeStatusAsync(false, true));
                    if (res.HasError) return;

                    UserLog.Save(EnLogAction.Delete, EnLogPart.Reception);
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن سند دریافت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await ReceptionBussines.GetAsync(guid);

                    res.AddReturnedValue(await prd.ChangeStatusAsync(true, true));
                    if (res.HasError) return;

                    UserLog.Save(EnLogAction.Enable, EnLogPart.Reception);
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
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در تغییر وضعیت دریافت");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
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
                var frm = new frmReceptionMain(guid, true, type);
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
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmReceptionMain(guid, false, type);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuStatus_Click(object sender, EventArgs e) => ST = !ST;
    }
}
