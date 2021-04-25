using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.Building;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using User;

namespace Building.BuildingRequest
{
    public partial class frmShowRequest : MetroForm
    {
        private bool _st = true;
        private List<BuildingRequestBussines> list;
        private List<string> ColumnList;
        private async Task LoadDataAsync(bool status, string search = "")
        {
            try
            {
                list = await BuildingRequestBussines.GetAllAsync(search);
                Invoke(new MethodInvoker(() => reqBindingSource.DataSource =
                    list.Where(q => q.Status == status).OrderByDescending(q => q.CreateDate).ToSortableBindingList()));
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
                mnuStatus.Enabled = access?.BuildingRequest.Building_Request_Disable ?? false;
                mnuView.Enabled = access?.BuildingRequest.Building_Request_View ?? false;
                mnuPrint.Enabled = access?.BuildingRequest.Building_Request_Print ?? false;

                mnuSendSms.Visible = Settings.VersionAccess.Sms;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private bool ST
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
        private void SetColumns()
        {
            try
            {
                ColumnList = Settings.Classes.clsBuildingRequest.ColumnsList;
                if (ColumnList == null || ColumnList.Count <= 0)
                {
                    ColumnList = new List<string> { "متقاضی", "مشاور", "توضیحات" };

                    SaveColumns(ColumnList);

                    DGrid.Columns[dgName.Index].Visible = true;
                    DGrid.Columns[dgUserName.Index].Visible = true;
                    DGrid.Columns[dgDesc.Index].Visible = true;

                    mnuName.Checked = true;
                    mnuUserName.Checked = true;
                    mnuDesc.Checked = true;
                }
                else
                {
                    foreach (var item in ColumnList.ToList())
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

        public frmShowRequest()
        {
            InitializeComponent();
            SetAccess();
            DGrid.Focus();
            SetColumns();
        }

        private async void frmShowRequest_Load(object sender, EventArgs e)
        {
            await LoadDataAsync(ST);
        }
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
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Building_Request_List, frm._PrintType)
                    { Lst = new List<object>(list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportRequest(list, this);
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
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmRequestMain(guid, false);
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
                var frm = new frmRequestMain();
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
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
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
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در تغییر وضعیت تقاضا");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }

            }
        }
        private void mnuVam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuVam.Checked)
                {
                    ColumnList.Add("وام");
                    DGrid.Columns[dgVam.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("وام");
                    DGrid.Columns[dgVam.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("رهن");
                    DGrid.Columns[dgRahn1.Index].Visible = true;
                    DGrid.Columns[dgRahn2.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("رهن");
                    DGrid.Columns[dgRahn1.Index].Visible = false;
                    DGrid.Columns[dgRahn2.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("خرید");
                    DGrid.Columns[dgSell1.Index].Visible = true;
                    DGrid.Columns[dgSell2.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("خرید");
                    DGrid.Columns[dgSell1.Index].Visible = false;
                    DGrid.Columns[dgSell2.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("متقاضی");
                    DGrid.Columns[dgName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("متقاضی");
                    DGrid.Columns[dgName.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("مشاور");
                    DGrid.Columns[dgUserName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مشاور");
                    DGrid.Columns[dgUserName.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("اجاره");
                    DGrid.Columns[dgEjare1.Index].Visible = true;
                    DGrid.Columns[dgEjare2.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("اجاره");
                    DGrid.Columns[dgEjare1.Index].Visible = false;
                    DGrid.Columns[dgEjare2.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("مساحت");
                    DGrid.Columns[dgMasahat1.Index].Visible = true;
                    DGrid.Columns[dgMasahat2.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مساحت");
                    DGrid.Columns[dgMasahat1.Index].Visible = false;
                    DGrid.Columns[dgMasahat2.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("افراد");
                    DGrid.Columns[dgPeopleCount.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("افراد");
                    DGrid.Columns[dgPeopleCount.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("اتاق");
                    DGrid.Columns[dgRoomCount.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("اتاق");
                    DGrid.Columns[dgRoomCount.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("توضیحات");
                    DGrid.Columns[dgDesc.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("توضیحات");
                    DGrid.Columns[dgDesc.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
