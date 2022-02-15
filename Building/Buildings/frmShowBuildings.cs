using Advertise.Classes;
using Advertise.Forms;
using Advertise.Forms.Simcard;
using Building.BuildingMatchesItem;
using Building.Buildings.Selector;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using Services.FilterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebHesabBussines;
using WindowsSerivces;
using WindowsSerivces.Waiter;
using Building.Zoncan;
using DataBaseUtilities;
using Persistence;

namespace Building.Buildings
{
    public partial class frmShowBuildings : MetroForm
    {
        private bool _st = true, isShowMode = false, _isLoad = false;
        private CancellationTokenSource _token = new CancellationTokenSource();
        public Guid SelectedGuid { get; set; }
        private IEnumerable<BuildingReportBussines> _list, _filteredList;
        private BuildingFilter filter;
        private CancellationTokenSource _detailToken = new CancellationTokenSource();
        private List<Guid> SelectedList
        {
            get
            {
                var list = new List<Guid>();
                try
                {
                    if (!(_filteredList?.Any() ?? false)) return list;
                    var lst = _filteredList?.Where(q => q.IsChecked)?.Select(q => q.Guid);
                    if (lst?.Any() ?? false) return lst?.ToList();
                    if (DGrid.CurrentRow == null) return list;
                    var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                    list.Add(guid);
                    return list;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return list;
            }
        }


        private void LoadData(string search = "")
        {
            try
            {
                _ = new Waiter("درحال خواندن اطلاعات ...", this, Task.Run(() => LoadDataAsync(search)));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                if (!_isLoad) return;
                if (filter == null) filter = new BuildingFilter() { Status = _st };
                _list = await BuildingReportBussines.GetAllAsync(filter);
                await SearchAsync(search);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Search(string search = "") => _ = new Waiter("درحال جستجو ...", this, Task.Run(() => SearchAsync(search)));
        private async Task SearchAsync(string srach = "")
        {
            try
            {
                if (!_isLoad) return;
                _filteredList = _list;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var t = _token.Token;
                if (string.IsNullOrEmpty(srach)) srach = "";
                var searchItems = srach.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (t.IsCancellationRequested) return;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            _filteredList = _filteredList?.Where(x => x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.OwnerName.ToLower().Contains(item.ToLower()) ||
                                                 x.Address.ToLower().Contains(item.ToLower()) ||
                                                 x.ParentName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                if (!(_filteredList?.Any() ?? false))
                {
                    BeginInvoke(new MethodInvoker(() => this.ShowMessage("داده ای جهت نمایش وجود ندارد")));
                    return;
                }

                BeginInvoke(new MethodInvoker(() =>
                {
                    BuildingBindingSource.DataSource = _filteredList?.OrderBy(q => q.IsArchive)
                        ?.ThenByDescending(q => q.CreateDate)?.ThenByDescending(q => q.Code)?.ToSortableBindingList();
                    SetGridColor();
                    lblCounter.Text = (_filteredList?.Count() ?? 0).ToString();
                }));
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
                menuAdd.Enabled = access?.Building.Building_Insert ?? false;
                menuEdit.Enabled = access?.Building.Building_Update ?? false;
                menuDelete.Enabled = access?.Building.Building_Delete ?? false;
                menuView.Enabled = access?.Building.Building_View ?? false;
                menuMatch.Enabled = access?.Building.Building_Show_request ?? false;
                menuSedSmsToOwner.Enabled = access?.Building.Building_Send_Sms ?? false;
                menuTelegram.Enabled = access?.Building.Building_Send_Telegram ?? false;
                menuPrint.Enabled = access?.Building.Building_Print ?? false;

                menuSedSmsToOwner.Visible = VersionAccess.Sms;
                menuTelegram.Visible = VersionAccess.Telegram;
                menuAddPersonal.Visible = VersionAccess.Advertise;
                mnuExcel.Visible = VersionAccess.Excel;
                dgServerStatusImage.Visible = VersionAccess.WebService;
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
                    if (DGrid[dgIsArchive.Index, i].Value != null && (bool)DGrid[dgIsArchive.Index, i].Value)
                    {
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                        continue;
                    }
                    if (DGrid[dgAdvertiseType.Index, i].Value != null)
                    {
                        var color = Color.FromArgb(255, 192, 255);
                        DGrid.Rows[i].DefaultCellStyle.BackColor = color;
                        continue;
                    }
                    if (DGrid[dgPriority.Index, i].Value != null)
                    {
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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendToTelegramCustomerChannelAsync(BuildingReportBussines bu)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.Token) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.Channel))
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا به تنظیمات برنامه، سربرگ تلگرام رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }

                var text = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Telegram.Text);
                text = text.Trim();
                var frm = new frmBuildingTelegramText(text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    text = frm.TelegramText;
                    var telegram = new WebTelegramBuilding
                    {
                        Content = text,
                        BotApi = SettingsBussines.Setting.Telegram.Token,
                        BuildingGuid = bu.Guid,
                        Channel = SettingsBussines.Setting.Telegram.Channel
                    };
                    await telegram.SaveAsync();
                    //bu.TelegramCount += 1;
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToTelegram, bu.Guid, text);
                    //await bu.SaveAsync(false);
                    this.ShowMessage("فایل مورد نظر به تلگرام ارسال شد");
                    if (WebCustomer.CheckCustomer())
                    {
                        var msg = $"ارسال ملک به کانال مشتریان \r\n {text}";
                        _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                    }
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendToTelegramManagerChannelAsync(BuildingReportBussines bu)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.Token) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.ManagerChannel))
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا به تنظیمات برنامه، سربرگ تلگرام رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }

                var text = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Telegram.ManagetText);
                text = text.Trim();
                var frm = new frmBuildingTelegramText(text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    text = frm.TelegramText;
                    var telegram = new WebTelegramBuilding
                    {
                        Content = text,
                        BotApi = SettingsBussines.Setting.Telegram.Token,
                        BuildingGuid = bu.Guid,
                        Channel = SettingsBussines.Setting.Telegram.ManagerChannel
                    };
                    await telegram.SaveAsync();
                    //bu.TelegramCount += 1;
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToTelegram, bu.Guid, text);
                    //await bu.SaveAsync(false);
                    this.ShowMessage("فایل مورد نظر به تلگرام ارسال شد");
                    if (WebCustomer.CheckCustomer())
                    {
                        var msg = $"ارسال ملک به کانال ادمین \r\n {text}";
                        _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                    }
                }

                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendToTelegramBothChannelAsync(BuildingReportBussines bu)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.Token) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.ManagerChannel) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Telegram.Channel))
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا به تنظیمات برنامه، سربرگ تلگرام رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }

                //Send2ManagerChannel
                var text = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Telegram.ManagetText);
                text = text.Trim();
                var telegram = new WebTelegramBuilding
                {
                    Content = text,
                    BotApi = SettingsBussines.Setting.Telegram.Token,
                    BuildingGuid = bu.Guid,
                    Channel = SettingsBussines.Setting.Telegram.ManagerChannel
                };
                _ = Task.Run(() => telegram.SaveAsync());

                //Send2CustomerChannel
                var text_ = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Telegram.Text);
                text_ = text_.Trim();
                var telegram_ = new WebTelegramBuilding
                {
                    Content = text_,
                    BotApi = SettingsBussines.Setting.Telegram.Token,
                    BuildingGuid = bu.Guid,
                    Channel = SettingsBussines.Setting.Telegram.Channel
                };
                _ = Task.Run(() => telegram_.SaveAsync());

                //bu.TelegramCount += 1;
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToTelegram, bu.Guid, text);
                //await bu.SaveAsync(false);
                this.ShowMessage("فایل مورد نظر به تلگرام ارسال شد");

                if (WebCustomer.CheckCustomer())
                {
                    var msg = $"ارسال ملک به کانال \r\n {text}";
                    _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendToWhatsAppCustomerChannelAsync(BuildingReportBussines bu)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Whatsapp.ApiCode) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Whatsapp.Number))
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا به تنظیمات برنامه، سربرگ واتساپ رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }

                var text = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Whatsapp.CustomerMessage);
                text = text.Trim();
                var frm = new frmBuildingTelegramText(text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    text = frm.TelegramText;
                    var telegram = new WebWhatsappBuilding()
                    {
                        Message = text,
                        ApiCode = SettingsBussines.Setting.Whatsapp.ApiCode,
                        Number = SettingsBussines.Setting.Whatsapp.Number
                    };
                    await telegram.SaveAsync();
                    //bu.WhatsAppCount += 1;
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToWhatsApp, bu.Guid, text);
                    //await bu.SaveAsync(false);
                    this.ShowMessage("فایل مورد نظر به واتساپ ارسال شد");
                    if (WebCustomer.CheckCustomer())
                    {
                        var msg = $"ارسال ملک به واتساپ \r\n {text}";
                        _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                    }
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendToWhatsAppManagerChannelAsync(BuildingReportBussines bu)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Whatsapp.ApiCode) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Whatsapp.Number))
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا به تنظیمات برنامه، سربرگ واتساپ رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }

                var text = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Whatsapp.ManagerMessage);
                text = text.Trim();
                var frm = new frmBuildingTelegramText(text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    text = frm.TelegramText;
                    var telegram = new WebWhatsappBuilding()
                    {
                        Message = text,
                        ApiCode = SettingsBussines.Setting.Whatsapp.ApiCode,
                        Number = SettingsBussines.Setting.Whatsapp.Number
                    };
                    await telegram.SaveAsync();
                    //bu.WhatsAppCount += 1;
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToWhatsApp, bu.Guid, text);
                    //await bu.SaveAsync(false);
                    this.ShowMessage("فایل مورد نظر به واتساپ ارسال شد");
                    if (WebCustomer.CheckCustomer())
                    {
                        var msg = $"ارسال ملک به واتساپ \r\n {text}";
                        _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                    }
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendToWhatsAppBothChannelAsync(BuildingReportBussines bu)
        {
            try
            {
                if (string.IsNullOrEmpty(SettingsBussines.Setting.Whatsapp.ApiCode) ||
                    string.IsNullOrEmpty(SettingsBussines.Setting.Whatsapp.Number))
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا به تنظیمات برنامه، سربرگ واتساپ رفته و موارد خواسته شده را وارد نمایید");
                    return;
                }

                //Send2ManagerChannel
                var text = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Whatsapp.ManagerMessage);
                text = text.Trim();
                var telegram = new WebWhatsappBuilding()
                {
                    Message = text,
                    ApiCode = SettingsBussines.Setting.Whatsapp.ApiCode,
                    Number = SettingsBussines.Setting.Whatsapp.Number
                };
                _ = Task.Run(() => telegram.SaveAsync());
                await Task.Delay(5000);
                //Send2CustomerChannel
                var text_ = await clsTelegramManager.GetTelegramTextAsync(bu, SettingsBussines.Setting.Whatsapp.CustomerMessage);
                text_ = text_.Trim();
                var telegram_ = new WebWhatsappBuilding()
                {
                    Message = text_,
                    ApiCode = SettingsBussines.Setting.Whatsapp.ApiCode,
                    Number = SettingsBussines.Setting.Whatsapp.Number
                };
                _ = Task.Run(() => telegram_.SaveAsync());

                //bu.WhatsAppCount += 1;
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToWhatsApp, bu.Guid, text);
                //await bu.SaveAsync(false);
                this.ShowMessage("فایل مورد نظر به واتساپ ارسال شد");
                if (WebCustomer.CheckCustomer())
                {
                    var msg = $"ارسال ملک به واتساپ \r\n {text}";
                    _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ShowBuildingDetailFormAsync(bool loadForCustomer)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                var frm = new frmBuilding(bu, true, loadForCustomer);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ShowDetailAsync(Guid guid, CancellationToken token)
        {
            try
            {
                await Task.Delay(3000);
                if (token.IsCancellationRequested) return;
                var bu = await BuildingReportBussines.GetAsync(guid);
                if (token.IsCancellationRequested || bu == null) return;
                while (!IsHandleCreated)
                {
                    await Task.Delay(100);
                    if (IsDisposed || token.IsCancellationRequested) return;
                }
                BeginInvoke(new MethodInvoker(() => ucBuildingDetail1.Building = bu));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, bool stats)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var prd = await BuildingBussines.GetAsync(guid);
                res.AddReturnedValue(await prd.ChangeStatusAsync(stats));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private async Task<ReturnedSaveFuncInfo> ChangeZoncanAsync(List<Guid> lstGuid, Guid zoncanGuid)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var guid in lstGuid)
                {
                    var cls = await BuildingBussines.GetAsync(guid);
                    if (cls == null) continue;
                    cls.ZoncanGuid = zoncanGuid;
                    cls.ServerStatus = ServerStatus.None;
                    var desc = $"کد ملک:( {cls.Code} ) ** آدرس:( {cls.Address} )";
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.ChangeZoncan, cls.Guid, desc);
                    res.AddReturnedValue(await cls.SaveAsync(false, isRaiseEvent: false));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private async Task<ReturnedSaveFuncInfo> ChangeArchiveAsync(List<Guid> lstGuid, bool isArchive)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var guid in lstGuid)
                {
                    var cls = await BuildingBussines.GetAsync(guid);
                    if (cls == null) continue;
                    if (isArchive && cls.IsArchive)
                    {
                        res.AddWarning($"ملک {cls.Code} درحال حاظر بایگانی شده است");
                        continue;
                    }
                    if (!isArchive && !cls.IsArchive)
                    {
                        res.AddWarning($"ملک {cls.Code} درحال حاظر خارج از بایگانی می باشد");
                        continue;
                    }
                    cls.IsArchive = isArchive;
                    cls.ServerStatus = ServerStatus.None;
                    var desc = $"کد ملک:( {cls.Code} ) ** آدرس:( {cls.Address} )";
                    var log = EnLogAction.AddToArchive;
                    if (!isArchive) log = EnLogAction.RemoveFromArchive;
                    await UserLogBussines.SaveBuildingLogAsync(log, cls.Guid, desc);
                    res.AddReturnedValue(await cls.SaveAsync(false, isRaiseEvent: false));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }

        public frmShowBuildings(bool _isShowMode, BuildingFilter _filter)
        {
            try
            {
                InitializeComponent();
                filter = _filter;
                ucHeader.Text = "نمایش لیست املاک";
                _st = filter.Status;
                isShowMode = _isShowMode;
                SetAccess();
                if (_isShowMode || (filter.IsArchive != null && filter.IsArchive.Value)) menu.Enabled = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowBuildings_Load(object sender, EventArgs e)
        {
            try
            {
                _isLoad = true;
                var t = new ToolTip();
                t.SetToolTip(picFilter, "فیلتر");
                LoadData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) => Search(txtSearch.Text);
        private void frmShowBuildings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        menuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        menuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        menuDelete.PerformClick();
                        break;
                    case Keys.F12:
                        menuView.PerformClick();
                        break;
                    case Keys.F11:
                        menuLimitedView.PerformClick();
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
                        else if (e.Alt) picFilter_Click(null, null);
                        break;
                    case Keys.Enter:
                        if (!isShowMode) menuEdit.PerformClick();
                        else Select();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                    case Keys.F5:
                        LoadData(txtSearch.Text);
                        break;
                }
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

                //res.AddReturnedValue(await Utility.ManageAdvSend(buList, simList, AdvertiseType.Sheypoor,
                //    clsAdvertise.IsGiveChat, clsAdvertise.Sender, clsAdvertise.Sheypoor_PicCountInPerAdv));
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
                string title, content;
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var sim = await SimcardBussines.GetAsync(frm.SelectedGuid);
                if (sim == null) return;

                var tc = new frmTitle(bu);
                if (tc.ShowDialog(this) != DialogResult.OK) return;
                title = tc.AdvTitle;
                content = tc.AdvContent;

                res.AddReturnedValue(await Utility.ManageAdvSend(bu, sim, AdvertiseType.Divar,
                    SettingsBussines.AdvertiseSetting.IsGiveChat, SettingsBussines.AdvertiseSetting.Sender, SettingsBussines.AdvertiseSetting.Divar_PicCountInPerAdv, title, content));

                if (res.HasError) return;
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.SendToDivar, bu.Guid, content);
                this.ShowMessage("آگهی شما باموفقیت در دیوار ثبت شد");
                if (!WebCustomer.CheckCustomer()) return;
                var msg = $"ارسال ملک به دیوار \r\n کدملک: {bu.Code} \r\n عنوان آگهی: {title} \r\n شرح آگهی: {content}";
                _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
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
            }
        }
        private void picFilter_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingFilter { Filter = filter };
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                filter = frm.Filter;
                filter.Status = _st;
                LoadData(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_Sorted(object sender, EventArgs e) => SetGridColor();
        private void DGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ucBuildingDetail1.Building = null;
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                _detailToken?.Cancel();
                _detailToken = new CancellationTokenSource();
                var token = _detailToken.Token;
                _ = new Waiter("اطلاعات تکمیلی", ucBuildingDetail1, Task.Run(() => ShowDetailAsync(guid, token)));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void menuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSelectBuildingType(this, new BuildingBussines());
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuEdit_Click(object sender, EventArgs e)
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
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;

                if (bu.Parent != null && bu.Parent != EnBuildingParent.None)
                {
                    var frm = new frmBuilding(bu, false);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        LoadData(txtSearch.Text);
                }
                else
                {
                    var frm = new frmSelectBuildingType(this, bu);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        LoadData(txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (_st)
                {
                    if (MessageBox.Show(this, $@"آیا از حذف فایل (های) انتخاب شده اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    foreach (var item in SelectedList)
                    {
                        res.AddReturnedValue(await RemoveAsync(item, false));
                        if (res.HasError) return;
                    }
                }
                else
                {
                    if (MessageBox.Show(this, $@"آیا از فعال کردن فایل (های) انتخاب شده اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    foreach (var item in SelectedList)
                    {
                        res.AddReturnedValue(await RemoveAsync(item, true));
                        if (res.HasError) return;
                    }
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
        private async void menuView_Click(object sender, EventArgs e) => await ShowBuildingDetailFormAsync(false);
        private async void menuLimitedView_Click(object sender, EventArgs e) => await ShowBuildingDetailFormAsync(true);
        private void menuLogView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                var frm = new frmBuildingLog(guid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuAddArchive_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                var lstGuid = SelectedList;
                var t = Task.Run(() => ChangeArchiveAsync(lstGuid, true));
                _ = new Waiter("درحال پردازش", this, t);
                await t;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError || res.HasWarning) this.ShowError(res);
                else
                {
                    this.ShowMessage("ملک (های) مورد نظر به بایگانی اضافه شد");
                    LoadData(txtSearch.Text);
                }
            }
        }
        private async void menuRemoveArchive_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                var lstGuid = SelectedList;
                var t = Task.Run(() => ChangeArchiveAsync(lstGuid, false));
                _ = new Waiter("درحال پردازش", this, t);
                await t;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError || res.HasWarning) this.ShowError(res);
                else
                {
                    this.ShowMessage("ملک (های) مورد نظر از بایگانی خارج شد");
                    LoadData(txtSearch.Text);
                }
            }
        }
        private async void menuAddPersonal_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                foreach (var guid in SelectedList)
                {
                    var cls = await BuildingBussines.GetAsync(guid);
                    if (cls == null) continue;

                    if (cls.AdvertiseType == null || cls.AdvertiseType == AdvertiseType.None)
                    {
                        res.AddWarning($"فایل {cls.Code} جزو فایل های شخصی می باشد");
                        continue;
                    }

                    cls.AdvertiseType = null;
                    cls.ServerStatus = ServerStatus.None;
                    var desc = $"کد ملک:( {cls.Code} ) ** آدرس:( {cls.Address} )";
                    await UserLogBussines.SaveBuildingLogAsync(EnLogAction.AddToPersonalFiles, cls.Guid, desc);
                    res.AddReturnedValue(await cls.SaveAsync(false, isRaiseEvent: false));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError || res.HasWarning) this.ShowError(res);
                else
                {
                    this.ShowMessage("فایل (های) موردنظر به فایل های شخصی اضافه شد");
                    LoadData(txtSearch.Text);
                }
            }
        }
        private async void menuSlideShow_Click(object sender, EventArgs e)
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
                var desc = $"کد ملک:( {bu.Code} ) ** آدرس:( {bu.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.ShowSlideShow, bu.Guid, desc);
                var frm = new frmSlideShow(bu.GalleryList);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuMedia_Click(object sender, EventArgs e)
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
                var desc = $"کد ملک:( {bu.Code} ) ** آدرس:( {bu.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.ShowMedia, bu.Guid, desc);
                var frm = new frmShowMedia(bu);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuTelegramCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await Utilities.PingHostAsync();
                if (res.HasError)
                {
                    this.ShowError(res);
                    return;
                }
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingReportBussines.GetAsync(guid);
                if (bu == null) return;
                await SendToTelegramCustomerChannelAsync(bu);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuTelegramManager_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await Utilities.PingHostAsync();
                if (res.HasError)
                {
                    this.ShowError(res);
                    return;
                }
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingReportBussines.GetAsync(guid);
                if (bu == null) return;
                await SendToTelegramManagerChannelAsync(bu);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuTelegramBoth_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await Utilities.PingHostAsync();
                if (res.HasError)
                {
                    this.ShowError(res);
                    return;
                }
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingReportBussines.GetAsync(guid);
                if (bu == null) return;
                await SendToTelegramBothChannelAsync(bu);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuMatch_Click(object sender, EventArgs e)
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
        private async void menuPrintFull_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var cls = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A5)
                {
                    CompanyInfo = SettingsBussines.Setting.CompanyInfo,
                    SanadGuid = guid,
                    IsLimited = false
                };
                cls.PrintNew();

                var bu = await BuildingBussines.GetAsync(guid);
                var desc = $"کد ملک:( {bu.Code} ) ** آدرس:( {bu.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.FullPrint, bu.Guid, desc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void menuZoncan_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowZoncans();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_DataError(object sender, DataGridViewDataErrorEventArgs e) { }
        private async void menuChangeZoncan_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                var frm = new frmSelectZoncan();
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;
                var zoncanGuid = frm.ZoncanGuid;
                frm.Dispose();
                if (zoncanGuid == Guid.Empty) return;
                var lstGuid = SelectedList;
                var t = Task.Run(() => ChangeZoncanAsync(lstGuid, zoncanGuid));
                _ = new Waiter("درحال پردازش", this, t);
                await t;
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
                    this.ShowMessage("ملک (های) مورد نظر به زونکن اضافه شد");
                    LoadData(txtSearch.Text);
                }
            }
        }
        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(_filteredList?.Any() ?? false)) return;
                foreach (var item in _filteredList)
                    item.IsChecked = true;
                DGrid.ResetBindings();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void menuSelectNone_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(_filteredList?.Any() ?? false)) return;
                foreach (var item in _filteredList)
                    item.IsChecked = false;
                DGrid.ResetBindings();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void menuSelectReverse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(_filteredList?.Any() ?? false)) return;
                foreach (var item in _filteredList)
                    item.IsChecked = !item.IsChecked;
                DGrid.ResetBindings();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                ExportToExcel.ExportBuilding(_filteredList, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGrid.CurrentCell.ColumnIndex != dgIsChecked.Index) return;
                var current = (BuildingReportBussines)BuildingBindingSource.Current;
                if (current == null) return;
                current.IsChecked = !current.IsChecked;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuLimitedPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var cls = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A5)
                {
                    CompanyInfo = SettingsBussines.Setting.CompanyInfo,
                    SanadGuid = guid,
                    IsLimited = true
                };
                cls.PrintNew();

                var bu = await BuildingBussines.GetAsync(guid);
                var desc = $"کد ملک:( {bu.Code} ) ** آدرس:( {bu.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.CustomPrint, bu.Guid, desc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void menuPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                var stimulQuery = await StimulQuery.SaveAsync(SelectedList, Cache.ConnectionString);
                if (stimulQuery.HasError)
                {
                    this.ShowError(stimulQuery);
                    return;
                }
                var cls = new ReportGenerator(StiType.Building_List, EnPrintType.Pdf_A4)
                {
                    CompanyInfo = SettingsBussines.Setting.CompanyInfo,
                    RefrenceId = stimulQuery.value
                };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
