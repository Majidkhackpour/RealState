using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;
using User;

namespace Cities.Region
{
    public partial class frmShowRegions : MetroForm
    {
        private bool _st = true;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                while (!IsHandleCreated) await Task.Delay(100);
                var list = new List<RegionsBussines>();
                _token?.Cancel();
                _token = new CancellationTokenSource();
                if (rbtnMyRegion.Checked)
                {
                    var cityGuid = SettingsBussines.Setting.CompanyInfo.EconomyCity;
                    list = await RegionsBussines.GetAllAsync(search, cityGuid, _token.Token);
                }
                else if (rbtnAll.Checked)
                    list = await RegionsBussines.GetAllAsync(search, Guid.Empty, _token.Token);

                Invoke(new MethodInvoker(() => RegionBindingSource.DataSource =
                    list?.Where(q => q.Status == _st).OrderBy(q => q.Name).ToSortableBindingList()));

                await LoadWorkingRangeAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadWorkingRangeAsync()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => LoadWorkingRangeAsync()));
                    return;
                }
                var list = await WorkingRangeBussines.GetAllAsync();
                if (list == null || list.Count < 0) return;

                for (var i = 0; i < DGrid.RowCount; i++)
                    foreach (var item in list)
                        if (item.RegionGuid == (Guid) DGrid[dgGuid.Index, i].Value)
                        {
                            DGrid[dgWorkingRange.Index, i].Value = true;
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
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
                mnuAdd.Enabled = access?.Regions.Region_Insert ?? false;
                mnuEdit.Enabled = access?.Regions.Region_Update ?? false;
                mnuDelete.Enabled = access?.Regions.Region_Delete ?? false;
                mnuView.Enabled = access?.Regions.Region_View ?? false;
                dgServerStatusImage.Visible = VersionAccess.WebService;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowRegions(bool status = true)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست مناطق";
            _st = status;
            rbtnMyRegion.Checked = true;
            SetAccess();
            DGrid.Focus();
        }

        private async void frmShowRegions_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private void frmShowRegions_KeyDown(object sender, KeyEventArgs e)
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
        private async void rbtnAll_CheckedChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private async void rbtnMyRegion_CheckedChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await RegionsBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmRegionMain(obj, true);
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
                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await RegionsBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await RegionsBussines.GetAsync(guid);
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
                if (res.HasError)
                    this.ShowError(res, "خطا در تغییر وضعیت منطقه");
                else await LoadDataAsync(txtSearch.Text);
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
                var obj = await RegionsBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmRegionMain(obj, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
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
                var frm = new frmRegionMain(new RegionsBussines(), false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuWorkingRange_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            var list = new List<WorkingRangeBussines>();
            try
            {
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    if (DGrid[dgWorkingRange.Index, i].Value == null ||
                        !(bool)DGrid[dgWorkingRange.Index, i].Value)
                        continue;
                    list.Add(new WorkingRangeBussines()
                    {
                        Guid = Guid.NewGuid(),
                        RegionGuid = (Guid)DGrid[dgGuid.Index, i].Value
                    });
                }

                if (list.Count <= 0) return;
                res.AddReturnedValue(await WorkingRangeBussines.SaveRangeAsync(list));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res);
                else
                {
                    this.ShowMessage($"{list.Count} منطقه به عنوان محدوده کاری انتخاب شد");
                    await LoadWorkingRangeAsync();
                }
            }
        }
    }
}
