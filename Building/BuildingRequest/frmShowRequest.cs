using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.Building;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;

namespace Building.BuildingRequest
{
    public partial class frmShowRequest : MetroForm
    {
        private bool _st = true;
        private List<BuildingRequestBussines> _list;
        private List<string> _columnList;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                _list = await BuildingRequestBussines.GetAllAsync(search, _token.Token);
                Invoke(new MethodInvoker(() => reqBindingSource.DataSource =
                    _list?.Where(q => q.Status == _st).OrderByDescending(q => q.CreateDate).ToSortableBindingList()));
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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetColumns()
        {
            try
            {
                _columnList = Settings.Classes.clsBuildingRequest.ColumnsList;
                if (_columnList == null || _columnList.Count <= 0)
                {
                    _columnList = new List<string> { "متقاضی", "مشاور", "توضیحات" };

                    SaveColumns(_columnList);

                    DGrid.Columns[dgName.Index].Visible = true;
                    DGrid.Columns[dgUserName.Index].Visible = true;
                    DGrid.Columns[dgDesc.Index].Visible = true;

                    mnuName.Checked = true;
                    mnuUserName.Checked = true;
                    mnuDesc.Checked = true;
                }
                else
                {
                    foreach (var item in _columnList.ToList())
                    {
                        switch (item)
                        {
                            case "خرید":
                                DGrid.Columns[dgSell1.Index].Visible = true;
                                DGrid.Columns[dgSell2.Index].Visible = true;
                                mnuSell.Checked = true;
                                break;
                            case "وام":
                                DGrid.Columns[dgVam.Index].Visible = true;
                                mnuVam.Checked = true;
                                break;
                            case "رهن":
                                DGrid.Columns[dgRahn1.Index].Visible = true;
                                DGrid.Columns[dgRahn2.Index].Visible = true;
                                mnuRahn.Checked = true;
                                break;
                            case "اجاره":
                                DGrid.Columns[dgEjare1.Index].Visible = true;
                                DGrid.Columns[dgEjare2.Index].Visible = true;
                                mnuEjare.Checked = true;
                                break;
                            case "مساحت":
                                DGrid.Columns[dgMasahat1.Index].Visible = true;
                                DGrid.Columns[dgMasahat1.Index].Visible = true;
                                mnuMasahat.Checked = true;
                                break;
                            case "اتاق":
                                DGrid.Columns[dgRoomCount.Index].Visible = true;
                                mnuRoomCount.Checked = true;
                                break;
                            case "افراد":
                                DGrid.Columns[dgPeopleCount.Index].Visible = true;
                                mnuPeopleCount.Checked = true;
                                break;
                            case "متقاضی":
                                DGrid.Columns[dgName.Index].Visible = true;
                                mnuName.Checked = true;
                                break;
                            case "مشاور":
                                DGrid.Columns[dgUserName.Index].Visible = true;
                                mnuUserName.Checked = true;
                                break;
                            case "توضیحات":
                                DGrid.Columns[dgDesc.Index].Visible = true;
                                mnuDesc.Checked = true;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveColumns(List<string> listcl)
        {
            try
            {
                listcl = listcl.GroupBy(x => x)
                    .Select(x => x.First()).ToList();
                Settings.Classes.clsBuildingRequest.ColumnsList = listcl;
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
            SetColumns();
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
        private void mnuShowBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var req = BuildingRequestBussines.Get(guid);
                if (req == null) return;

                var type = EnRequestType.Rahn;
                decimal fPrice1 = 0, sPrice1 = 0, fPrice2 = 0, sPrice2 = 0;

                if (req.SellPrice1 > 0) type = EnRequestType.Forush;
                if (req.RahnPrice1 > 0) type = EnRequestType.Rahn;

                if (type == EnRequestType.Forush)
                {
                    fPrice1 = req.SellPrice1;
                    fPrice2 = req.SellPrice2;
                }
                else
                {
                    fPrice1 = req.RahnPrice1;
                    fPrice2 = req.RahnPrice2;
                    sPrice1 = req.EjarePrice1;
                    sPrice2 = req.EjarePrice2;
                }

                var frm = new frmFilterForm(type, req.BuildingTypeGuid, req.BuildingAccountTypeGuid, req.RoomCount,
                    req.Masahat1, req.Masahat2, fPrice1, sPrice1, fPrice2, sPrice2,
                    req.RegionList.Select(q => q.RegionGuid).ToList());
                frm.ShowDialog(this);
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
                var frm = new frmRequestMain(guid, true);
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
                var frm = new frmRequestMain(guid, false);
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
                var frm = new frmRequestMain();
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
        private void mnuVam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuVam.Checked)
                {
                    _columnList.Add("وام");
                    DGrid.Columns[dgVam.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("وام");
                    DGrid.Columns[dgVam.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRahn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRahn.Checked)
                {
                    _columnList.Add("رهن");
                    DGrid.Columns[dgRahn1.Index].Visible = true;
                    DGrid.Columns[dgRahn2.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("رهن");
                    DGrid.Columns[dgRahn1.Index].Visible = false;
                    DGrid.Columns[dgRahn2.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSell_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuSell.Checked)
                {
                    _columnList.Add("خرید");
                    DGrid.Columns[dgSell1.Index].Visible = true;
                    DGrid.Columns[dgSell2.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("خرید");
                    DGrid.Columns[dgSell1.Index].Visible = false;
                    DGrid.Columns[dgSell2.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuName.Checked)
                {
                    _columnList.Add("متقاضی");
                    DGrid.Columns[dgName.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("متقاضی");
                    DGrid.Columns[dgName.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuUserName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuUserName.Checked)
                {
                    _columnList.Add("مشاور");
                    DGrid.Columns[dgUserName.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("مشاور");
                    DGrid.Columns[dgUserName.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuEjare_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuEjare.Checked)
                {
                    _columnList.Add("اجاره");
                    DGrid.Columns[dgEjare1.Index].Visible = true;
                    DGrid.Columns[dgEjare2.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("اجاره");
                    DGrid.Columns[dgEjare1.Index].Visible = false;
                    DGrid.Columns[dgEjare2.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuMasahat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuMasahat.Checked)
                {
                    _columnList.Add("مساحت");
                    DGrid.Columns[dgMasahat1.Index].Visible = true;
                    DGrid.Columns[dgMasahat2.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("مساحت");
                    DGrid.Columns[dgMasahat1.Index].Visible = false;
                    DGrid.Columns[dgMasahat2.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuPeopleCount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuPeopleCount.Checked)
                {
                    _columnList.Add("افراد");
                    DGrid.Columns[dgPeopleCount.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("افراد");
                    DGrid.Columns[dgPeopleCount.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRoomCount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRoomCount.Checked)
                {
                    _columnList.Add("اتاق");
                    DGrid.Columns[dgRoomCount.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("اتاق");
                    DGrid.Columns[dgRoomCount.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDesc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuDesc.Checked)
                {
                    _columnList.Add("توضیحات");
                    DGrid.Columns[dgDesc.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("توضیحات");
                    DGrid.Columns[dgDesc.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
