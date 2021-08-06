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
using Building.UserControls;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Payamak;
using Print;
using Services;
using Settings.Classes;
using WebHesabBussines;

namespace Building.Building
{
    public partial class frmShowBuildings : MetroForm
    {
        private bool _st = true;
        private CancellationTokenSource _token = new CancellationTokenSource();
        public Guid SelectedGuid { get; set; }
        private bool isShowMode = false;
        private IEnumerable<BuildingBussines> list;
        private List<string> ColumnList;
        private Guid ownerGuid = Guid.Empty;
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
                _token?.Cancel();
                _token = new CancellationTokenSource();
                list = BuildingBussines
                    .GetAll(search, false, _token.Token, _isArchive, _st,
                        (Guid)cmbBuildingType.SelectedValue,
                        (Guid)cmbUser.SelectedValue,
                        (Guid)cmbDocType.SelectedValue,
                        (Guid)cmbAccType.SelectedValue);
                if (ownerGuid == Guid.Empty)
                {
                    Task.Run(() => ucPagger.PagingAsync(new CancellationToken(),
                        list?.OrderBy(q => q.IsArchive)?.ThenByDescending(q => q.CreateDate), 100,
                        PagingPosition.GotoStartPage));
                }
                else
                {
                    Task.Run(() => ucPagger.PagingAsync(new CancellationToken(),
                        list?.Where(q => q.OwnerGuid == ownerGuid)
                            ?.OrderBy(q => q.IsArchive)?.ThenByDescending(q => q.CreateDate), 100,
                        PagingPosition.GotoStartPage));
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
                ColumnList = Settings.Classes.clsBuilding.ColumnsList;
                if (ColumnList == null || ColumnList.Count <= 0)
                {
                    ColumnList = new List<string> { "کد", "تاریخ ثبت", "مالک", "اتاق", "آدرس", "محدوده" };

                    SaveColumns(ColumnList);

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
                    foreach (var item in ColumnList.ToList())
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
                        var loc = DGrid.GetCellDisplayRectangle(dgCode.Index, DGrid.CurrentRow.Index, false);
                        if (token.IsCancellationRequested) return;
                        var cont = new ucBuildingFeatures();
                        var wid = dgCode.Width;
                        var p = new Point(loc.X + wid, loc.Y - cont.Height);
                        if (token.IsCancellationRequested) return;
                        if (p.Y < DGrid.Top) p.Y += cont.Height + 30;
                        cont.Location = p;
                        if (token.IsCancellationRequested) return;
                        cont.Building = bu;
                        cont.Show();
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
            InitializeComponent();
            ucHeader.Text = "نمایش لیست املاک";
            _st = status;
            isShowMode = _isShowMode;
            this.ownerGuid = ownerGuid;
            _isArchive = isArchive;
            ucPagger.OnBindDataReady += UcPagger_OnBindDataReady;
            SetAccess();
            SetColumns();
            if (_isShowMode || (_isArchive != null && _isArchive.Value)) contextMenu.Enabled = false;
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
                    var cls = new ReportGenerator(StiType.Building_List, frm._PrintType) { Lst = new List<object>(list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportBuilding(list, this);
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
                var frm = new frmBuildingMain(guid, true);
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
                    ColumnList.Add("کد");
                    DGrid.Columns[dgCode.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("کد");
                    DGrid.Columns[dgCode.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("تاریخ");
                    DGrid.Columns[dgDateSh.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("تاریخ");
                    DGrid.Columns[dgDateSh.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("مالک");
                    DGrid.Columns[dgOwnerName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مالک");
                    DGrid.Columns[dgOwnerName.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("نوع ملک");
                    DGrid.Columns[dgType.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("نوع ملک");
                    DGrid.Columns[dgType.Index].Visible = false;
                    SaveColumns(ColumnList);
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
        private void mnuMasahat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuMasahat.Checked)
                {
                    ColumnList.Add("مساحت");
                    DGrid.Columns[dgMasahat.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مساحت");
                    DGrid.Columns[dgMasahat.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("زیربنا");
                    DGrid.Columns[dgZirBana.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("زیربنا");
                    DGrid.Columns[dgZirBana.Index].Visible = false;
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
                    DGrid.Columns[dgRahn.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("رهن");
                    DGrid.Columns[dgRahn.Index].Visible = false;
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
                    DGrid.Columns[dgEjare.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("اجاره");
                    DGrid.Columns[dgEjare.Index].Visible = false;
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
                    ColumnList.Add("فروش");
                    DGrid.Columns[dgSellPrice.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("فروش");
                    DGrid.Columns[dgSellPrice.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("محدوده");
                    DGrid.Columns[dgRegionName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("محدوده");
                    DGrid.Columns[dgRegionName.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("وضعیت");
                    DGrid.Columns[dgBuildingStatus.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("وضعیت");
                    DGrid.Columns[dgBuildingStatus.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("آدرس");
                    DGrid.Columns[dgAddress.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("آدرس");
                    DGrid.Columns[dgAddress.Index].Visible = false;
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
        private void mnuQest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuQest.Checked)
                {
                    ColumnList.Add("قسط");
                    DGrid.Columns[dgQest.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("قسط");
                    DGrid.Columns[dgQest.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("تجاری");
                    DGrid.Columns[dgTejari.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("تجاری");
                    DGrid.Columns[dgTejari.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("سال");
                    DGrid.Columns[dgSaleSakht.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("سال");
                    DGrid.Columns[dgSaleSakht.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("جهت");
                    DGrid.Columns[dgSide.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("جهت");
                    DGrid.Columns[dgSide.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("سند");
                    DGrid.Columns[dgDocType.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("سند");
                    DGrid.Columns[dgDocType.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("ارجحیت");
                    DGrid.Columns[dgRentalAuthorityName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("ارجحیت");
                    DGrid.Columns[dgRentalAuthorityName.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("کاربری");
                    DGrid.Columns[dgAccountType.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("کاربری");
                    DGrid.Columns[dgAccountType.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("وضعیت ملک");
                    DGrid.Columns[dgCondition.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("وضعیت ملک");
                    DGrid.Columns[dgCondition.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("نما");
                    DGrid.Columns[dgView.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("نما");
                    DGrid.Columns[dgView.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("کفپوش");
                    DGrid.Columns[dgFloorCover.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("کفپوش");
                    DGrid.Columns[dgFloorCover.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("آشپزخانه");
                    DGrid.Columns[dgKitchenService.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("آشپزخانه");
                    DGrid.Columns[dgKitchenService.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("آب");
                    DGrid.Columns[dgWater.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("آب");
                    DGrid.Columns[dgWater.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("برق");
                    DGrid.Columns[dgBarq.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("برق");
                    DGrid.Columns[dgBarq.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("گاز");
                    DGrid.Columns[dgGas.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("گاز");
                    DGrid.Columns[dgGas.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                    ColumnList.Add("تلفن");
                    DGrid.Columns[dgTell.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("تلفن");
                    DGrid.Columns[dgTell.Index].Visible = false;
                    SaveColumns(ColumnList);
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
                PicBox.Image = null;
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (string.IsNullOrEmpty(bu.Image)) return;
                var path = Path.Combine(Application.StartupPath + "\\Images", bu.Image);
                PicBox.ImageLocation = path;
                //await Task.Delay(3000);
                //_token?.Cancel();
                //_token = new CancellationTokenSource();
                //_ = Task.Run(() => ShowDescAsync(_token.Token));
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
                var telegram = new WebTelegramBuilding
                {
                    Content = await TelegramTextAsync(bu),
                    BotApi = Settings.Classes.clsTelegram.Token,
                    BuildingGuid = bu.Guid,
                    Channel = Settings.Classes.clsTelegram.Channel
                };
                await telegram.SaveAsync();
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

                if (res.Contains(Replacor.TelegramBuilding.Code)) res = res.Replace(Replacor.TelegramBuilding.Code, bu.Code);
                if (res.Contains(Replacor.TelegramBuilding.Type))
                {
                    var type = await BuildingTypeBussines.GetAsync(bu.BuildingTypeGuid);
                    res = res.Replace(Replacor.TelegramBuilding.Type, type?.Name ?? "");
                }
                if (res.Contains(Replacor.TelegramBuilding.Contract))
                {
                    var contract = bu.SellPrice > 0 ? "فروش" : "رهن و اجاره";
                    res = res.Replace(Replacor.TelegramBuilding.Contract, contract);
                }
                if (res.Contains(Replacor.TelegramBuilding.AccountType))
                {
                    var type = await BuildingTypeBussines.GetAsync(bu.BuildingAccountTypeGuid);
                    res = res.Replace(Replacor.TelegramBuilding.AccountType, type?.Name ?? "");
                }
                if (res.Contains(Replacor.TelegramBuilding.Region))
                {
                    var reg = RegionsBussines.Get(bu.RegionGuid);
                    res = res.Replace(Replacor.TelegramBuilding.Region, reg?.Name);
                }

                if (res.Contains(Replacor.TelegramBuilding.SellPrice))
                    res = res.Replace(Replacor.TelegramBuilding.SellPrice, bu.SellPrice.ToString("N0"));

                if (res.Contains(Replacor.TelegramBuilding.RahnPrice))
                    res = res.Replace(Replacor.TelegramBuilding.RahnPrice, bu.RahnPrice1.ToString("N0"));

                if (res.Contains(Replacor.TelegramBuilding.EjarePrice))
                    res = res.Replace(Replacor.TelegramBuilding.EjarePrice, bu.EjarePrice1.ToString("N0"));

                if (res.Contains(Replacor.TelegramBuilding.Masahat))
                    res = res.Replace(Replacor.TelegramBuilding.Masahat, bu.Masahat.ToString());

                if (res.Contains(Replacor.TelegramBuilding.ZirBana))
                    res = res.Replace(Replacor.TelegramBuilding.ZirBana, bu.ZirBana.ToString());

                if (res.Contains(Replacor.TelegramBuilding.DocumentType))
                {
                    var doc = await DocumentTypeBussines.GetAsync(bu.DocumentType ?? Guid.Empty);
                    res = res.Replace(Replacor.TelegramBuilding.DocumentType, doc?.Name ?? "");
                }

                if (res.Contains(Replacor.TelegramBuilding.Side))
                    res = res.Replace(Replacor.TelegramBuilding.Side, bu.SideName);

                if (res.Contains(Replacor.TelegramBuilding.Tarakom))
                    res = res.Replace(Replacor.TelegramBuilding.Tarakom, (bu.Tarakom?.GetDisplay() ?? ""));

                if (res.Contains(Replacor.TelegramBuilding.TabaqeNo))
                    res = res.Replace(Replacor.TelegramBuilding.TabaqeNo, bu.TabaqeNo.ToString());

                if (res.Contains(Replacor.TelegramBuilding.TabaqeCount))
                    res = res.Replace(Replacor.TelegramBuilding.TabaqeCount, bu.TedadTabaqe.ToString());

                if (res.Contains(Replacor.TelegramBuilding.RoomCount))
                    res = res.Replace(Replacor.TelegramBuilding.RoomCount, bu.RoomCount.ToString());

                if (res.Contains(Replacor.TelegramBuilding.SaleSakht))
                    res = res.Replace(Replacor.TelegramBuilding.SaleSakht, bu.SaleSakht);

                if (res.Contains(Replacor.TelegramBuilding.Tejari))
                    res = res.Replace(Replacor.TelegramBuilding.Tejari, bu.MetrazhTejari.ToString());

                if (res.Contains(Replacor.TelegramBuilding.Channel))
                    res = res.Replace(Replacor.TelegramBuilding.Channel, Settings.Classes.clsTelegram.Channel);
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
                await cls.SaveAsync();
                LoadData(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuRemoveFromArchive_Click(object sender, EventArgs e)
        {
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
                LoadData(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
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
