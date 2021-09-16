using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Advertise.Classes;
using Advertise.Forms.Simcard;
using Building.BuildingMatchesItem;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Payamak;
using Print;
using Services;
using Services.FilterObjects;
using Settings.Classes;
using WebHesabBussines;

namespace Building.Building
{
    public partial class frmShowBuildings : MetroForm
    {
        private bool _st = true, isShowMode = false, _isLoad = false;
        private CancellationTokenSource _token = new CancellationTokenSource();
        public Guid SelectedGuid { get; set; }
        private IEnumerable<BuildingBussines> _list;
        private List<string> _columnList;
        private Guid _ownerGuid = Guid.Empty;
        private bool? _isArchive;


        private async Task FillCmbAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingTypeBussines.GetAllAsync(_token.Token);
                list.Add(new BuildingTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                btBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();

                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list2 = await UserBussines.GetAllAsync(_token.Token);
                list2.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                userBindingSource.DataSource = list2.OrderBy(q => q.Name).ToList();

                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list3 = await DocumentTypeBussines.GetAllAsync(_token.Token);
                list3.Add(new DocumentTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                docTypeBindingSource.DataSource = list3.OrderBy(q => q.Name).ToList();

                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list4 = await BuildingAccountTypeBussines.GetAllAsync(_token.Token);
                list4.Add(new BuildingAccountTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                AccTypeBindingSource.DataSource = list4.OrderBy(q => q.Name).ToList();

                cmbBuildingType.SelectedIndex = 0;
                cmbUser.SelectedValue = UserBussines.CurrentUser.Guid;
                cmbDocType.SelectedIndex = 0;
                cmbAccType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadData(string search = "")
        {
            try
            {
                if (!_isLoad) return;
                if (cmbDocType.SelectedValue == null) return;
                var filter = new BuildingFilter()
                {
                    Status = _st,
                    UserGuid = (Guid)cmbUser.SelectedValue,
                    BuildingAccountTypeGuid = (Guid)cmbAccType.SelectedValue,
                    IsArchive = _isArchive,
                    BuildingTypeGuid = (Guid)cmbBuildingType.SelectedValue,
                    Search = search,
                    IsFromDivar = chbDivar.Checked,
                    IsSell = chbForoush.Checked,
                    DocumentTypeGuid = (Guid)cmbDocType.SelectedValue,
                    IsRahn = chbRahn.Checked,
                    IsFromSheypoor = chbSheypoor.Checked,
                    OwnerGuid = _ownerGuid
                };
                _token?.Cancel();
                _token = new CancellationTokenSource();
                _list = BuildingBussines.GetAll(filter, false, _token.Token);
                Task.Run(() => ucPagger.PagingAsync(new CancellationToken(),
                    _list?.OrderBy(q => q.IsArchive)?.ThenByDescending(q => q.CreateDate), 100,
                    PagingPosition.GotoStartPage));
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
                mnuAdd.Enabled = access?.Building.Building_Insert ?? false;
                mnuEdit.Enabled = access?.Building.Building_Update ?? false;
                mnuDelete.Enabled = access?.Building.Building_Delete ?? false;
                mnuView.Enabled = access?.Building.Building_View ?? false;
                mnuMatchRequest.Enabled = access?.Building.Building_Show_request ?? false;
                mnuSendSms.Enabled = access?.Building.Building_Send_Sms ?? false;
                mnuSendToDivar.Enabled = access?.Building.Building_Send_Divar ?? false;
                mnuSendToSheypoor.Enabled = access?.Building.Building_Send_Sheypoor ?? false;
                mnuSendToTelegram.Enabled = access?.Building.Building_Send_Telegram ?? false;
                mnuPrint.Enabled = access?.Building.Building_Print ?? false;

                mnuSendSms.Visible = VersionAccess.Sms;
                mnuSendToDivar.Visible = VersionAccess.Advertise;
                mnuSendToSheypoor.Visible = VersionAccess.Advertise;
                mnuSendToTelegram.Visible = VersionAccess.Telegram;
                chbDivar.Visible = chbSheypoor.Visible = VersionAccess.Advertise;
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
                _columnList = Settings.Classes.clsBuilding.ColumnsList;
                if (_columnList == null || _columnList.Count <= 0)
                {
                    _columnList = new List<string> { "کد", "تاریخ ثبت", "مالک", "اتاق", "آدرس", "محدوده" };

                    SaveColumns(_columnList);

                    DGrid.Columns[dgCode.Index].Visible = true;
                    DGrid.Columns[dgDateSh.Index].Visible = true;
                    DGrid.Columns[dgOwnerName.Index].Visible = true;
                    DGrid.Columns[dgRoomCount.Index].Visible = true;
                    DGrid.Columns[dgAddress.Index].Visible = true;
                    DGrid.Columns[dgRegionName.Index].Visible = true;

                    mnuCode.Checked = true;
                    mnuDate.Checked = true;
                    mnuOwner.Checked = true;
                    mnuRoom.Checked = true;
                    mnuAddress.Checked = true;
                    mnuRegion.Checked = true;
                }
                else
                {
                    foreach (var item in _columnList.ToList())
                    {
                        switch (item)
                        {
                            case "کد":
                                DGrid.Columns[dgCode.Index].Visible = true;
                                mnuCode.Checked = true;
                                break;
                            case "تاریخ":
                                DGrid.Columns[dgDateSh.Index].Visible = true;
                                mnuDate.Checked = true;
                                break;
                            case "مالک":
                                DGrid.Columns[dgOwnerName.Index].Visible = true;
                                mnuOwner.Checked = true;
                                break;
                            case "نوع ملک":
                                DGrid.Columns[dgType.Index].Visible = true;
                                mnuType.Checked = true;
                                break;
                            case "اتاق":
                                DGrid.Columns[dgRoomCount.Index].Visible = true;
                                mnuRoom.Checked = true;
                                break;
                            case "مساحت":
                                DGrid.Columns[dgMasahat.Index].Visible = true;
                                mnuMasahat.Checked = true;
                                break;
                            case "زیربنا":
                                DGrid.Columns[dgZirBana.Index].Visible = true;
                                mnuZirBana.Checked = true;
                                break;
                            case "رهن":
                                DGrid.Columns[dgRahn.Index].Visible = true;
                                mnuRahn.Checked = true;
                                break;
                            case "اجاره":
                                DGrid.Columns[dgEjare.Index].Visible = true;
                                mnuEjare.Checked = true;
                                break;
                            case "فروش":
                                DGrid.Columns[dgSellPrice.Index].Visible = true;
                                mnuSell.Checked = true;
                                break;
                            case "محدوده":
                                DGrid.Columns[dgRegionName.Index].Visible = true;
                                mnuRegion.Checked = true;
                                break;
                            case "وضعیت":
                                DGrid.Columns[dgBuildingStatus.Index].Visible = true;
                                mnuBStatus.Checked = true;
                                break;
                            case "آدرس":
                                DGrid.Columns[dgAddress.Index].Visible = true;
                                mnuAddress.Checked = true;
                                break;
                            case "مشاور":
                                DGrid.Columns[dgUserName.Index].Visible = true;
                                mnuUserName.Checked = true;
                                break;
                            case "وام":
                                DGrid.Columns[dgVam.Index].Visible = true;
                                mnuVam.Checked = true;
                                break;
                            case "قسط":
                                DGrid.Columns[dgQest.Index].Visible = true;
                                mnuQest.Checked = true;
                                break;
                            case "تجاری":
                                DGrid.Columns[dgTejari.Index].Visible = true;
                                mnuTejari.Checked = true;
                                break;
                            case "سال":
                                DGrid.Columns[dgSaleSakht.Index].Visible = true;
                                mnuSaleSakht.Checked = true;
                                break;
                            case "جهت":
                                DGrid.Columns[dgSide.Index].Visible = true;
                                mnuSide.Checked = true;
                                break;
                            case "سند":
                                DGrid.Columns[dgDocType.Index].Visible = true;
                                mnuDocType.Checked = true;
                                break;
                            case "ارجحیت":
                                DGrid.Columns[dgRentalAuthorityName.Index].Visible = true;
                                mnuRental.Checked = true;
                                break;
                            case "کاربری":
                                DGrid.Columns[dgAccountType.Index].Visible = true;
                                mnuAccountType.Checked = true;
                                break;
                            case "وضعیت ملک":
                                DGrid.Columns[dgCondition.Index].Visible = true;
                                mnuCondition.Checked = true;
                                break;
                            case "نما":
                                DGrid.Columns[dgView.Index].Visible = true;
                                mnuBView.Checked = true;
                                break;
                            case "کفپوش":
                                DGrid.Columns[dgFloorCover.Index].Visible = true;
                                mnuFloor.Checked = true;
                                break;
                            case "آشپزخانه":
                                DGrid.Columns[dgKitchenService.Index].Visible = true;
                                mnuKitchen.Checked = true;
                                break;
                            case "آب":
                                DGrid.Columns[dgWater.Index].Visible = true;
                                mnuWater.Checked = true;
                                break;
                            case "برق":
                                DGrid.Columns[dgBarq.Index].Visible = true;
                                mnuBarq.Checked = true;
                                break;
                            case "گاز":
                                DGrid.Columns[dgGas.Index].Visible = true;
                                mnuGas.Checked = true;
                                break;
                            case "تلفن":
                                DGrid.Columns[dgTell.Index].Visible = true;
                                mnuTell.Checked = true;
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
                Settings.Classes.clsBuilding.ColumnsList = listcl;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Select()
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
        private void SetGridColor()
        {
            try
            {
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    if ((bool)DGrid[dgIsArchive.Index, i].Value)
                    {
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                        continue;
                    }
                    var priority = (EnBuildingPriority)DGrid[dgPriority.Index, i].Value;
                    switch (priority)
                    {
                        case EnBuildingPriority.SoHigh:
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                            break;
                        case EnBuildingPriority.High:
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                            break;
                        case EnBuildingPriority.Medium:
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                            break;
                        case EnBuildingPriority.Low:
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ShowDescAsync(CancellationToken token)
        {
            try
            {
                if (token.IsCancellationRequested) return;
                if (!IsHandleCreated) return;
                Invoke(new MethodInvoker(() =>
                {
                    try
                    {
                        if (token.IsCancellationRequested) return;
                        if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                        var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                        var bu = BuildingBussines.Get(guid);
                        if (bu == null) return;
                        if (token.IsCancellationRequested) return;
                        var loc = DGrid.GetCellDisplayRectangle(dgRoomCount.Index, DGrid.CurrentRow.Index, false);
                        if (token.IsCancellationRequested) return;
                        var wid = dgCode.Width;
                        ucFeatures.Size = new Size(469, 258);
                        var p = new Point(loc.X + wid, loc.Y - ucFeatures.Height);
                        if (token.IsCancellationRequested) return;
                        if (p.Y < DGrid.Top) p.Y += ucFeatures.Height + 120;
                        else p.Y += 95;
                        ucFeatures.Location = p;
                        if (token.IsCancellationRequested) return;
                        ucFeatures.Building = bu;
                        ucFeatures.BackColor = Color.Transparent;
                        ucFeatures.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowBuildings(bool _isShowMode, bool? isArchive, bool status = true, Guid ownerGuid = default)
        {
            try
            {
                InitializeComponent();
                ucFeatures.Visible = false;
                ucHeader.Text = "نمایش لیست املاک";
                _st = status;
                isShowMode = _isShowMode;
                _ownerGuid = ownerGuid;
                _isArchive = isArchive;
                ucPagger.OnBindDataReady += UcPagger_OnBindDataReady;
                SetAccess();
                SetColumns();
                if (_isShowMode || (_isArchive != null && _isArchive.Value)) contextMenu.Enabled = false;

                chbDivar.Visible = chbSheypoor.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void UcPagger_OnBindDataReady(object sender, WindowsSerivces.Pagging.FooterBindingDataReadyEventArg e)
        {
            try
            {
                while (!IsHandleCreated)
                {
                    await Task.Delay(100);
                    if (e.Token.IsCancellationRequested) return;
                }
                var count = e?.ListData?.Count ?? 0;
                if (count <= 0) count = 50;
                Invoke(new MethodInvoker(() =>
                {
                    BuildingBindingSource.DataSource = e?.ListData?.Take(count)?.ToSortableBindingList();
                    SetGridColor();
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmShowBuildings_Load(object sender, EventArgs e)
        {
            await FillCmbAsync();
            chbAll.Checked = true;
            _isLoad = true;
            LoadData();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void frmShowBuildings_KeyDown(object sender, KeyEventArgs e)
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
                        if (ucFeatures.Visible)
                        {
                            ucFeatures.Visible = false;
                            return;
                        }
                        Close();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        if (!isShowMode) mnuEdit.PerformClick();
                        else Select();
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
        private void cmbBuildingType_SelectedIndexChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!isShowMode) return;
                Select();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuSendToSheypoor_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                return;
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var simList = new List<SimcardBussines>();
                var buList = new List<BuildingBussines>();

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;
                buList.Add(bu);

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    simList.Add(await SimcardBussines.GetAsync(frm.SelectedGuid));

                res.AddReturnedValue(await Utility.ManageAdvSend(buList, simList, AdvertiseType.Sheypoor,
                    clsAdvertise.IsGiveChat, clsAdvertise.Sender, clsAdvertise.Sheypoor_PicCountInPerAdv));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ارسال ملک به شیپور");
                else
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "آگهی شما باموفقیت در شیپور ثبت شد");
                }
            }
        }
        private async void mnuSendToDivar_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                return;
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var simList = new List<SimcardBussines>();
                var buList = new List<BuildingBussines>();

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;
                buList.Add(bu);

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    simList.Add(await SimcardBussines.GetAsync(frm.SelectedGuid));

                res.AddReturnedValue(await Utility.ManageAdvSend(buList, simList, AdvertiseType.Divar,
                    clsAdvertise.IsGiveChat, clsAdvertise.Sender, clsAdvertise.Divar_PicCountInPerAdv));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ارسال ملک به دیوار");
                else
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "آگهی شما باموفقیت در دیوار ثبت شد");
                }
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
                    var cls = new ReportGenerator(StiType.Building_List, frm._PrintType) { Lst = new List<object>(_list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportBuilding(_list, this);
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
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                var frm = new frmBuildingDetail(bu);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuEdit_Click(object sender, EventArgs e)
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
                var frm = new frmBuildingMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(txtSearch.Text);
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
                            $@" آیا از حذف ملک{DGrid[dgCode.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن ملک{DGrid[dgCode.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingBussines.GetAsync(guid);
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
                    this.ShowError(res, "خطا در تغییر وضعیت ملک");
                else LoadData(txtSearch.Text);
            }
        }
        private void mnuCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuCode.Checked)
                {
                    _columnList.Add("کد");
                    DGrid.Columns[dgCode.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("کد");
                    DGrid.Columns[dgCode.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuDate.Checked)
                {
                    _columnList.Add("تاریخ");
                    DGrid.Columns[dgDateSh.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("تاریخ");
                    DGrid.Columns[dgDateSh.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuOwner_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuOwner.Checked)
                {
                    _columnList.Add("مالک");
                    DGrid.Columns[dgOwnerName.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("مالک");
                    DGrid.Columns[dgOwnerName.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuType.Checked)
                {
                    _columnList.Add("نوع ملک");
                    DGrid.Columns[dgType.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("نوع ملک");
                    DGrid.Columns[dgType.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRoom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRoom.Checked)
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
        private void mnuMasahat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuMasahat.Checked)
                {
                    _columnList.Add("مساحت");
                    DGrid.Columns[dgMasahat.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("مساحت");
                    DGrid.Columns[dgMasahat.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuZirBana_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuZirBana.Checked)
                {
                    _columnList.Add("زیربنا");
                    DGrid.Columns[dgZirBana.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("زیربنا");
                    DGrid.Columns[dgZirBana.Index].Visible = false;
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
                    DGrid.Columns[dgRahn.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("رهن");
                    DGrid.Columns[dgRahn.Index].Visible = false;
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
                    DGrid.Columns[dgEjare.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("اجاره");
                    DGrid.Columns[dgEjare.Index].Visible = false;
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
                    _columnList.Add("فروش");
                    DGrid.Columns[dgSellPrice.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("فروش");
                    DGrid.Columns[dgSellPrice.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRegion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRegion.Checked)
                {
                    _columnList.Add("محدوده");
                    DGrid.Columns[dgRegionName.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("محدوده");
                    DGrid.Columns[dgRegionName.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuBStatus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuBStatus.Checked)
                {
                    _columnList.Add("وضعیت");
                    DGrid.Columns[dgBuildingStatus.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("وضعیت");
                    DGrid.Columns[dgBuildingStatus.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuAddress.Checked)
                {
                    _columnList.Add("آدرس");
                    DGrid.Columns[dgAddress.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("آدرس");
                    DGrid.Columns[dgAddress.Index].Visible = false;
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
        private void mnuQest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuQest.Checked)
                {
                    _columnList.Add("قسط");
                    DGrid.Columns[dgQest.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("قسط");
                    DGrid.Columns[dgQest.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuTejari_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuTejari.Checked)
                {
                    _columnList.Add("تجاری");
                    DGrid.Columns[dgTejari.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("تجاری");
                    DGrid.Columns[dgTejari.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSaleSakht_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuSaleSakht.Checked)
                {
                    _columnList.Add("سال");
                    DGrid.Columns[dgSaleSakht.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("سال");
                    DGrid.Columns[dgSaleSakht.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSide_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuSide.Checked)
                {
                    _columnList.Add("جهت");
                    DGrid.Columns[dgSide.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("جهت");
                    DGrid.Columns[dgSide.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDocType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuDocType.Checked)
                {
                    _columnList.Add("سند");
                    DGrid.Columns[dgDocType.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("سند");
                    DGrid.Columns[dgDocType.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRental_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRental.Checked)
                {
                    _columnList.Add("ارجحیت");
                    DGrid.Columns[dgRentalAuthorityName.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("ارجحیت");
                    DGrid.Columns[dgRentalAuthorityName.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAccountType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuAccountType.Checked)
                {
                    _columnList.Add("کاربری");
                    DGrid.Columns[dgAccountType.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("کاربری");
                    DGrid.Columns[dgAccountType.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuCondition_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuCondition.Checked)
                {
                    _columnList.Add("وضعیت ملک");
                    DGrid.Columns[dgCondition.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("وضعیت ملک");
                    DGrid.Columns[dgCondition.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuBView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuBView.Checked)
                {
                    _columnList.Add("نما");
                    DGrid.Columns[dgView.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("نما");
                    DGrid.Columns[dgView.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuFloor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuFloor.Checked)
                {
                    _columnList.Add("کفپوش");
                    DGrid.Columns[dgFloorCover.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("کفپوش");
                    DGrid.Columns[dgFloorCover.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuKitchen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuKitchen.Checked)
                {
                    _columnList.Add("آشپزخانه");
                    DGrid.Columns[dgKitchenService.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("آشپزخانه");
                    DGrid.Columns[dgKitchenService.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuWater_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuWater.Checked)
                {
                    _columnList.Add("آب");
                    DGrid.Columns[dgWater.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("آب");
                    DGrid.Columns[dgWater.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuBarq_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuBarq.Checked)
                {
                    _columnList.Add("برق");
                    DGrid.Columns[dgBarq.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("برق");
                    DGrid.Columns[dgBarq.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuGas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuGas.Checked)
                {
                    _columnList.Add("گاز");
                    DGrid.Columns[dgGas.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("گاز");
                    DGrid.Columns[dgGas.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuTell_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuTell.Checked)
                {
                    _columnList.Add("تلفن");
                    DGrid.Columns[dgTell.Index].Visible = true;
                    SaveColumns(_columnList);
                }
                else
                {
                    _columnList = _columnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    _columnList.Remove("تلفن");
                    DGrid.Columns[dgTell.Index].Visible = false;
                    SaveColumns(_columnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void DGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (BuildingBindingSource.Count <= 0 || BuildingBindingSource.Count == ucPagger.list.Count)
                    return;
                var addedItem = 0;
                var percent = 100 * (double)e.NewValue / BuildingBindingSource.Count;
                if (percent <= 70) return;
                foreach (var item in ucPagger.NextItemsInPage(BuildingBindingSource.Count, 50))
                {
                    BuildingBindingSource.Add(item);
                    addedItem++;
                }

                SetGridColor();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void DGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ucFeatures.Visible = false;
                PicBox.Image = null;
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (!string.IsNullOrEmpty(bu.Image))
                {
                    var path = Path.Combine(Application.StartupPath + "\\Images", bu.Image);
                    PicBox.ImageLocation = path;
                }

                await Task.Delay(3000);
                _token?.Cancel();
                _token = new CancellationTokenSource();
                _ = Task.Run(() => ShowDescAsync(_token.Token));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuSendToTelegram_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(clsTelegram.Token) ||
                    string.IsNullOrEmpty(clsTelegram.Channel))
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "لطفا ابتدا به تنظیمات برنامه، سربرگ تلگرام رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                var text = await TelegramTextAsync(bu);
                text = text.Trim();
                var frm = new frmBuildingTelegramText(text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    text = frm.TelegramText;
                    var telegram = new WebTelegramBuilding
                    {
                        Content = text,
                        BotApi = clsTelegram.Token,
                        BuildingGuid = bu.Guid,
                        Channel = clsTelegram.Channel
                    };
                    await telegram.SaveAsync();
                    bu.TelegramCount += 1;
                    await bu.SaveAsync();
                    this.ShowMessage("فایل مورد نظر به تلگرام ارسال شد");
                }

                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<string> TelegramTextAsync(BuildingBussines bu)
        {
            var res = "";
            try
            {
                res = clsTelegram.Text;
                var list = res.Split('\n').ToList();

                if (res.Contains(Replacor.TelegramBuilding.Code))
                {
                    var code = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Code));
                    if (!string.IsNullOrEmpty(code))
                    {
                        var index = list.IndexOf(code);
                        code = code.Replace("\r", "");
                        code = code.Replace(Replacor.TelegramBuilding.Code, bu.Code);
                        list[index] = code;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Type))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Type));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Type, bu.BuildingTypeName);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Contract))
                {
                    var contract = bu.SellPrice > 0 ? "فروش" : "رهن و اجاره";
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Contract));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Contract, contract);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.AccountType))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.AccountType));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.AccountType, bu.BuildingAccountTypeName);
                        if (!string.IsNullOrEmpty(bu.BuildingAccountTypeName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Region))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Region));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Region, bu.RegionName);
                        if (!string.IsNullOrEmpty(bu.RegionName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.SellPrice))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.SellPrice));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.SellPrice, bu.SellPrice.ToString("N0"));
                        if (bu.SellPrice > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.RahnPrice))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.RahnPrice));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.RahnPrice, bu.RahnPrice1.ToString("N0"));
                        if (bu.RahnPrice1 > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.EjarePrice))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.EjarePrice));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.EjarePrice, bu.EjarePrice1.ToString("N0"));
                        if (bu.EjarePrice1 > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Masahat))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Masahat));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Masahat, bu.Masahat.ToString());
                        if (bu.Masahat > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.ZirBana))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.ZirBana));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.ZirBana, bu.ZirBana.ToString());
                        if (bu.ZirBana > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.DocumentType))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.DocumentType));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.DocumentType, bu.DocumentTypeName);
                        if (!string.IsNullOrEmpty(bu.DocumentTypeName) && bu.SellPrice > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Side))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Side));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Side, bu.SideName);
                        if (!string.IsNullOrEmpty(bu.SideName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Tarakom))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Tarakom));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Tarakom, bu.Tarakom?.GetDisplay());
                        if (bu.RahnPrice1 <= 0 || bu.EjarePrice1 <= 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.TabaqeNo))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.TabaqeNo));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.TabaqeNo, bu.TabaqeNo.ToString());
                        if (bu.TabaqeNo == 0)
                            list[index] = type.Replace("0", "همکف");
                        else
                            list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.TabaqeCount))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.TabaqeCount));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.TabaqeCount, bu.TedadTabaqe.ToString());
                        if (bu.TedadTabaqe > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.RoomCount))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.RoomCount));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.RoomCount, bu.RoomCount.ToString());
                        if (bu.RoomCount > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.SaleSakht))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.SaleSakht));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.SaleSakht, bu.SaleSakht);
                        if (!string.IsNullOrEmpty(bu.SaleSakht))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Tejari))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Tejari));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Tejari, bu.MetrazhTejari.ToString());
                        if (bu.MetrazhTejari > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Channel))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Channel));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Channel, clsTelegram.Channel);
                        if (!string.IsNullOrEmpty(clsTelegram.Channel))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Address))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Address));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Address, clsEconomyUnit.ManagerAddress);
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerAddress))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Tell))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Tell));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Tell, clsEconomyUnit.ManagerTell);
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerTell))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Mobile))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Mobile));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Mobile, clsEconomyUnit.ManagerMobile);
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerMobile))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.KitchenService))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.KitchenService));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.KitchenService, bu.KitchenServiceName);
                        if (!string.IsNullOrEmpty(bu.KitchenServiceName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.FloorCover))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.FloorCover));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.FloorCover, bu.FloorCoverName);
                        if (!string.IsNullOrEmpty(bu.FloorCoverName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.View))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.View));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.View, bu.BuildingViewName);
                        if (!string.IsNullOrEmpty(bu.BuildingViewName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.PricePerMetr))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.PricePerMetr));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        if (bu.SellPrice > 0 && bu.Masahat > 0)
                        {
                            type = type.Replace("\r", "");
                            var p = bu.SellPrice / bu.Masahat;
                            type = type.Replace(Replacor.TelegramBuilding.PricePerMetr, p.ToString("N0"));
                            list[index] = type;
                        }
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.VahedPerTabaqe))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.VahedPerTabaqe));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.VahedPerTabaqe, bu.VahedPerTabaqe.ToString());
                        if (bu.VahedPerTabaqe > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Hitting))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Hitting));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Hitting, bu.Hiting);
                        if (!string.IsNullOrEmpty(bu.Hiting))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Colling))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Colling));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Colling, bu.Colling);
                        if (!string.IsNullOrEmpty(bu.Colling))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Dong))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Dong));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Dong, bu.Dang.ToString());
                        if (bu.SellPrice > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Parking))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Parking));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("پارکینگ"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Parking, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Elevator))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Elevator));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("سانسور"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Elevator, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Store))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Store));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("انبار"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Store, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Balcony))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Balcony));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("تراس") || q.OptionName.Contains("بالکن"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Balcony, text);
                        list[index] = type;
                    }
                }

                list = list.Where(q => !string.IsNullOrEmpty(q)).ToList();
                res = string.Join(Environment.NewLine, list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        private async void mnuSlideShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu?.GalleryList == null || bu?.GalleryList?.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("داده ای جهت نمایش وجود ندارد");
                    return;
                }

                var frm = new frmSlideShow(bu.GalleryList);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAddToArchive_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cls = await BuildingBussines.GetAsync(guid);
                if (cls == null) return;
                if (cls.IsArchive)
                {
                    frmNotification.PublicInfo.ShowMessage("ملک موردنظر درحال حاظر بایگانی شده است");
                    return;
                }

                cls.IsArchive = true;
                res.AddReturnedValue(await cls.SaveAsync());
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
                    this.ShowMessage("ملک مورد نظر به بایگانی اضافه شد");
                    LoadData(txtSearch.Text);
                }
            }
        }
        private async void mnuRemoveFromArchive_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cls = await BuildingBussines.GetAsync(guid);
                if (cls == null) return;
                if (!cls.IsArchive)
                {
                    frmNotification.PublicInfo.ShowMessage("ملک موردنظر درحال حاظر خارج از بایگانی می باشد");
                    return;
                }

                cls.IsArchive = false;
                await cls.SaveAsync();
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res);
                else
                {
                    this.ShowMessage("ملک مورد نظر از بایگانی خارج شد");
                    LoadData(txtSearch.Text);
                }
            }
        }
        private async void mnuMatchRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cls = await BuildingBussines.GetAsync(guid);
                if (cls == null) return;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(cls, _token.Token);
                if (list.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("فایل مطابقی جهت نمایش وجود ندارد");
                    return;
                }

                new frmShowRequestMatches(list).ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuPrintFull_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cls = await BuildingBussines.GetAsync(guid);
                if (cls == null) return;
                var rpt = new BuildingReportViewModel()
                {
                    Masahat = cls.Masahat,
                    SellPrice = cls.SellPrice,
                    RahnPrice1 = cls.RahnPrice1,
                    EjarePrice1 = cls.EjarePrice1,
                    Code = cls.Code,
                    RoomCount = cls.RoomCount,
                    TabaqeNo = cls.TabaqeNo,
                    SaleSakht = cls.SaleSakht,
                    ZirBana = cls.ZirBana,
                    Address = cls.Address,
                    TedadTabaqe = cls.TedadTabaqe,
                    ShortDesc = cls.ShortDesc,
                    VahedPerTabaqe = cls.VahedPerTabaqe,
                    PishTotalPrice = cls.PishTotalPrice,
                    PishPrice = cls.PishPrice,
                    VamPrice = cls.VamPrice,
                    Hashie = cls.Hashie,
                    BarqName = cls.BarqName,
                    GasName = cls.GasName,
                    WaterName = cls.WaterName,
                    OwnerName = cls.OwnerName,
                    BuildingTypeName = cls.BuildingTypeName,
                    BuildingConditionName = cls.BuildingConditionName,
                    BuildingViewName = cls.BuildingViewName,
                    DocumentTypeName = cls.DocumentTypeName,
                    FloorCoverName = cls.FloorCoverName,
                    KitchenServiceName = cls.KitchenServiceName,
                    SideName = cls.SideName,
                    UserName = cmbUser.Text,
                    TellName = cls.TellName,
                    Options = string.Join(", ", cls.OptionList?.Select(q => q.OptionName)),
                    DeliveryDateSh = Calendar.MiladiToShamsi(cls.DeliveryDate),
                    RegionName = RegionsBussines.Get(cls.RegionGuid)?.Name ?? ""
                };
                if (cls.SellPrice > 0 && cls.Masahat > 0)
                    rpt.SellPricePerMetr = cls.SellPrice / cls.Masahat;
                var people = PeoplesBussines.Get(cls.OwnerGuid);
                if (people.TellList != null && people.TellList.Count > 0)
                {
                    if (people.TellList.Count >= 2)
                    {
                        rpt.OwnerTell1 = people.TellList[0].Tell;
                        rpt.OwnerTell2 = people.TellList[1].Tell;
                    }
                    else
                    {
                        rpt.OwnerTell1 = people.TellList[0].Tell;
                        rpt.OwnerTell2 = "";
                    }
                }
                else
                {
                    rpt.OwnerTell1 = "";
                    rpt.OwnerTell2 = "";
                }

                var cls_ = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A4)
                { Lst = new List<object>() { rpt } };
                cls_.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void chbRahn_CheckedChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void chbForoush_CheckedChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void chbDivar_CheckedChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void chbSheypoor_CheckedChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private void chbAll_CheckedChanged(object sender, EventArgs e) => LoadData(txtSearch.Text);
        private async void mnuPrintInherit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cls = await BuildingBussines.GetAsync(guid);
                if (cls == null) return;
                var rpt = new BuildingReportViewModel()
                {
                    Masahat = cls.Masahat,
                    SellPrice = cls.SellPrice,
                    RahnPrice1 = cls.RahnPrice1,
                    EjarePrice1 = cls.EjarePrice1,
                    Code = cls.Code,
                    RoomCount = cls.RoomCount,
                    TabaqeNo = cls.TabaqeNo,
                    SaleSakht = cls.SaleSakht,
                    ZirBana = cls.ZirBana,
                    Address = cls.Address,
                    TedadTabaqe = cls.TedadTabaqe,
                    ShortDesc = cls.ShortDesc,
                    VahedPerTabaqe = cls.VahedPerTabaqe,
                    PishTotalPrice = cls.PishTotalPrice,
                    PishPrice = cls.PishPrice,
                    VamPrice = cls.VamPrice,
                    Hashie = cls.Hashie,
                    BarqName = cls.BarqName,
                    GasName = cls.GasName,
                    WaterName = cls.WaterName,
                    OwnerName = cls.OwnerName,
                    BuildingTypeName = cls.BuildingTypeName,
                    BuildingConditionName = cls.BuildingConditionName,
                    BuildingViewName = cls.BuildingViewName,
                    DocumentTypeName = cls.DocumentTypeName,
                    FloorCoverName = cls.FloorCoverName,
                    KitchenServiceName = cls.KitchenServiceName,
                    SideName = cls.SideName,
                    UserName = cmbUser.Text,
                    TellName = cls.TellName,
                    Options = string.Join(", ", cls.OptionList?.Select(q => q.OptionName)),
                    DeliveryDateSh = Calendar.MiladiToShamsi(cls.DeliveryDate),
                    RegionName = RegionsBussines.Get(cls.RegionGuid)?.Name ?? ""
                };
                if (cls.SellPrice > 0 && cls.Masahat > 0)
                    rpt.SellPricePerMetr = cls.SellPrice / cls.Masahat;

                var cls_ = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A5)
                { Lst = new List<object>() { rpt } };
                cls_.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuMedia_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu?.MediaList == null || bu?.MediaList?.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("داده ای جهت نمایش وجود ندارد");
                    return;
                }

                var frm = new frmShowMedia(bu);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
