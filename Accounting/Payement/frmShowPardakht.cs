using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace Accounting.Payement
{
    public partial class frmShowPardakht : MetroForm
    {
        private Guid _receptorGuid;
        private EnAccountingType type;
        private bool _st = true;
        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                var list = await PardakhtBussines.GetAllAsync(search, _receptorGuid);
                Invoke(new MethodInvoker(() =>
                    pardakhtBindingSource.DataSource = list.Where(q => q.Status == status).ToSortableBindingList()));
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
                btnInsert.Enabled = access?.Pardakht.Pardakht_Insert ?? false;
                btnEdit.Enabled = access?.Pardakht.Pardakht_Update ?? false;
                btnDelete.Enabled = access?.Pardakht.Pardakht_Delete ?? false;
                btnChangeStatus.Enabled = access?.Pardakht.Pardakht_Disable ?? false;
                btnView.Enabled = access?.Pardakht.Pardakht_View ?? false;
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
        public frmShowPardakht(Guid receptorGuid, EnAccountingType _type)
        {
            InitializeComponent();
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
                else if (type == EnAccountingType.Hazine)
                {
                    var hazine = HazineBussines.Get(_receptorGuid);
                    if (hazine == null) return;
                    lblName.Text = hazine.Name;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmShowPardakht_Load(object sender, EventArgs e) => await LoadDataAsync(ST);

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

        private void frmShowPardakht_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtMain(_receptorGuid, type);
                if (frm.ShowDialog(this) == DialogResult.OK)
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
                var frm = new frmPardakhtMain(guid, false, type);
                if (frm.ShowDialog(this) == DialogResult.OK)
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
                var frm = new frmPardakhtMain(guid, true, type);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
                    if (MessageBox.Show(this,
                            $@"آیا از حذف سند پرداخت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PardakhtBussines.GetAsync(guid);


                    if (type == EnAccountingType.Peoples)
                    {
                        var pe = await PeoplesBussines.GetAsync(_receptorGuid);
                        if (pe != null)
                        {
                            pe.Account -= prd.TotalPrice;
                            await pe.SaveAsync();
                        }
                    }
                    else if (type == EnAccountingType.Users)
                    {
                        var user = await UserBussines.GetAsync(_receptorGuid);
                        if (user != null)
                        {
                            user.Account -= prd.TotalPrice;
                            await user.SaveAsync(false);
                        }
                    }
                    else if (type == EnAccountingType.Hazine)
                    {
                        var hazine = await HazineBussines.GetAsync(_receptorGuid);
                        if (hazine != null)
                        {
                            hazine.Account -= prd.TotalPrice;
                            await hazine.SaveAsync(false);
                        }
                    }




                    var res = await prd.ChangeStatusAsync(false);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }


                    User.UserLog.Save(EnLogAction.Delete, EnLogPart.Pardakht);
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن سند پرداخت اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PardakhtBussines.GetAsync(guid);
                    if (type == EnAccountingType.Peoples)
                    {
                        var pe = await PeoplesBussines.GetAsync(_receptorGuid);
                        if (pe != null)
                        {
                            pe.Account += prd.TotalPrice;
                            await pe.SaveAsync();
                        }
                    }
                    else if (type == EnAccountingType.Users)
                    {
                        var user = await UserBussines.GetAsync(_receptorGuid);
                        if (user != null)
                        {
                            user.Account += prd.TotalPrice;
                            await user.SaveAsync(false);
                        }
                    }
                    else if (type == EnAccountingType.Hazine)
                    {
                        var hazine = await HazineBussines.GetAsync(_receptorGuid);
                        if (hazine != null)
                        {
                            hazine.Account += prd.TotalPrice;
                            await hazine.SaveAsync(false);
                        }
                    }
                    var res = await prd.ChangeStatusAsync(true);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    User.UserLog.Save(EnLogAction.Enable, EnLogPart.Pardakht);

                }

                await LoadDataAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
