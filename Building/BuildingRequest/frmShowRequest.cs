using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.Buildings;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using Services.FilterObjects;

namespace Building.BuildingRequest
{
    public partial class frmShowRequest : MetroForm
    {
        private bool _st = true;
        private List<BuildingRequestBussines> _list;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                _list = await BuildingRequestBussines.GetAllAsync(search, _st, _token.Token);
                Invoke(new MethodInvoker(() => reqBindingSource.DataSource =
                    _list?.OrderByDescending(q => q.CreateDate).ToSortableBindingList()));
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
                mnuAdd.Enabled = access?.BuildingRequest.Building_Request_Insert ?? false;
                mnuEdit.Enabled = access?.BuildingRequest.Building_Request_Update ?? false;
                mnuDelete.Enabled = access?.BuildingRequest.Building_Request_Delete ?? false;
                mnuView.Enabled = access?.BuildingRequest.Building_Request_View ?? false;
                mnuPrint.Enabled = access?.BuildingRequest.Building_Request_Print ?? false;

                mnuSendSms.Visible = VersionAccess.Sms;
                dgServerStatusImage.Visible = VersionAccess.WebService;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowRequest(bool status = true)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست تقاضاها";
            _st = status;
            SetAccess();
            DGrid.Focus();
        }

        private async void frmShowRequest_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync();
        private void frmShowRequest_KeyDown(object sender, KeyEventArgs e)
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
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Building_Request_List, frm._PrintType)
                    { Lst = new List<object>(_list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportRequest(_list, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuShowBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var req = await BuildingRequestBussines.GetAsync(guid);
                if (req == null) return;


                var filter = new BuildingFilter()
                {
                    Status = true,
                    RahnPrice1 = req.RahnPrice1,
                    EjarePrice1 = req.EjarePrice1,
                    RegionList = req.RegionList?.Select(q => q.RegionGuid).ToList(),
                    BuildingAccountTypeGuid = req.BuildingAccountTypeGuid,
                    UserGuid = null,
                    OwnerGuid = null,
                    BuildingTypeGuid = null,
                    AdvertiseType = null,
                    IsArchive = null,
                    SellPrice2 = req.SellPrice2,
                    SellPrice1 = req.SellPrice1,
                    Masahat1 = req.Masahat1,
                    EjarePrice2 = req.EjarePrice2,
                    DocumentTypeGuid = null,
                    IsFullRahn = false,
                    IsPishForoush = false,
                    RahnPrice2 = req.RahnPrice2,
                    Masahat2 = req.Masahat2,
                    IsSell = false,
                    IsRahn = false,
                    IsMosharekat = false,
                    MaxTabaqeNo = 0,
                    RoomCount1 = 0,
                    RoomCount2 = req.RoomCount,
                    ZirBana1 = 0,
                    ZirBana2 = 0
                };
                var frm = new frmShowBuildings(false, filter);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await BuildingRequestBussines.GetAsync(guid);
                if (obj == null) return;
                var pe = await PeoplesBussines.GetAsync(obj.AskerGuid, null);
                var frm = new frmBuildingRequestsMain(obj, pe, true);
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
                if (!_st)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await BuildingRequestBussines.GetAsync(guid);
                if (obj == null) return;
                var pe = await PeoplesBussines.GetAsync(obj.AskerGuid, null);
                var frm = new frmBuildingRequestsMain(obj, pe, false);
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
                var frm = new frmBuildingRequestsMain(new BuildingRequestBussines(), null, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
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
                            $@"آیا از حذف درخواست {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingRequestBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن درخواست {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingRequestBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(true));
                }

                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در تغییر وضعیت تقاضا");
            }
        }
    }
}
