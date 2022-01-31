﻿using Advertise.Classes;
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

namespace Building.Buildings
{
    public partial class frmShowBuildings : MetroForm
    {
        private bool _st = true, isShowMode = false, _isLoad = false;
        private CancellationTokenSource _token = new CancellationTokenSource();
        public Guid SelectedGuid { get; set; }
        private IEnumerable<BuildingReportBussines> _list;
        private BuildingFilter filter;
        private CancellationTokenSource _detailToken = new CancellationTokenSource();


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
                var lst = _list;
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
                            lst = lst?.Where(x => x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.OwnerName.ToLower().Contains(item.ToLower()) ||
                                                 x.BuildingTypeName.ToLower().Contains(item.ToLower()) ||
                                                 x.Masahat.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.ZirBana.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.Address.ToLower().Contains(item.ToLower()) ||
                                                 x.RegionName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                if (!(lst?.Any() ?? false))
                {
                    BeginInvoke(new MethodInvoker(() => this.ShowMessage("داده ای جهت نمایش وجود ندارد")));
                    return;
                }

                BeginInvoke(new MethodInvoker(() =>
                {
                    BuildingBindingSource.DataSource = lst?.OrderBy(q => q.IsArchive)
                        ?.ThenByDescending(q => q.CreateDate)?.ThenByDescending(q => q.Code)?.ToSortableBindingList();
                    SetGridColor();
                    lblCounter.Text = (lst?.Count() ?? 0).ToString();
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
                BeginInvoke(new MethodInvoker(() => ucBuildingDetail1.Building = bu));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
                cls.ServerStatus = ServerStatus.None;
                var desc = $"کد ملک:( {cls.Code} ) ** آدرس:( {cls.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.AddToArchive, cls.Guid, desc);
                res.AddReturnedValue(await cls.SaveAsync(false));
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
        private async void menuRemoveArchive_Click(object sender, EventArgs e)
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
                cls.ServerStatus = ServerStatus.None;
                var desc = $"کد ملک:( {cls.Code} ) ** آدرس:( {cls.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.RemoveFromArchive, cls.Guid, desc);
                res.AddReturnedValue(await cls.SaveAsync(false));
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
        private async void menuAddPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cls = await BuildingBussines.GetAsync(guid);
                if (cls == null) return;

                if (cls.AdvertiseType == null || cls.AdvertiseType == AdvertiseType.None)
                {
                    this.ShowMessage("فایل موردنظر جزو فایل های شخصی می باشد");
                    return;
                }

                cls.AdvertiseType = null;
                cls.ServerStatus = ServerStatus.None;
                var desc = $"کد ملک:( {cls.Code} ) ** آدرس:( {cls.Address} )";
                await UserLogBussines.SaveBuildingLogAsync(EnLogAction.AddToPersonalFiles, cls.Guid, desc);
                var res = await cls.SaveAsync(false);
                if (res.HasError) this.ShowError(res);
                else
                {
                    this.ShowMessage("فایل موردنظر به فایل های شخصی اضافه شد");
                    LoadData(txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
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
        private void menuPrintFull_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                //var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                //var cls = await BuildingBussines.GetAsync(guid);
                //if (cls == null) return;
                //var rpt = new BuildingReportViewModel()
                //{
                //    Masahat = cls.Masahat,
                //    SellPrice = cls.SellPrice,
                //    RahnPrice1 = cls.RahnPrice1,
                //    EjarePrice1 = cls.EjarePrice1,
                //    Code = cls.Code,
                //    RoomCount = cls.RoomCount,
                //    TabaqeNo = cls.TabaqeNo,
                //    SaleSakht = cls.SaleSakht,
                //    ZirBana = cls.ZirBana,
                //    Address = cls.Address,
                //    TedadTabaqe = cls.TedadTabaqe,
                //    ShortDesc = cls.ShortDesc,
                //    VahedPerTabaqe = cls.VahedPerTabaqe,
                //    PishTotalPrice = cls.PishTotalPrice,
                //    PishPrice = cls.PishPrice,
                //    VamPrice = cls.VamPrice,
                //    Hashie = cls.Hashie,
                //    BarqName = cls.BarqName,
                //    GasName = cls.GasName,
                //    WaterName = cls.WaterName,
                //    OwnerName = cls.OwnerName,
                //    BuildingTypeName = cls.BuildingTypeName,
                //    BuildingConditionName = cls.BuildingConditionName,
                //    BuildingViewName = cls.BuildingViewName,
                //    DocumentTypeName = cls.DocumentTypeName,
                //    FloorCoverName = cls.FloorCoverName,
                //    KitchenServiceName = cls.KitchenServiceName,
                //    SideName = cls.SideName,
                //    UserName = cls.UserName,
                //    TellName = cls.TellName,
                //    //Options = string.Join(", ", cls.OptionList?.Select(q => q.OptionName)),
                //    DeliveryDateSh = Calendar.MiladiToShamsi(cls.DeliveryDate),
                //    RegionName = (await RegionsBussines.GetAsync(cls.RegionGuid))?.Name ?? ""
                //};
                //if (cls.SellPrice > 0 && cls.Masahat > 0)
                //    rpt.SellPricePerMetr = cls.SellPrice / cls.Masahat;
                //var people = await PeoplesBussines.GetAsync(cls.OwnerGuid, cls.Guid);
                //if (people.TellList != null && people.TellList.Count > 0)
                //{
                //    if (people.TellList.Count >= 2)
                //    {
                //        rpt.OwnerTell1 = people.TellList[0].Tell;
                //        rpt.OwnerTell2 = people.TellList[1].Tell;
                //    }
                //    else
                //    {
                //        rpt.OwnerTell1 = people.TellList[0].Tell;
                //        rpt.OwnerTell2 = "";
                //    }
                //}
                //else
                //{
                //    rpt.OwnerTell1 = "";
                //    rpt.OwnerTell2 = "";
                //}

                //var cls_ = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A4)
                //{ Lst = new List<object>() { rpt } };
                //cls_.PrintNew();
                //var desc = $"کد ملک:( {cls.Code} ) ** محدوده:( {cls.RegionName} ) ** آدرس:( {cls.Address} )";
                //await UserLogBussines.SaveBuildingLogAsync(EnLogAction.FullPrint, cls.Guid, desc);
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
        private void menuLimitedPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                //var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                //var cls = await BuildingBussines.GetAsync(guid);
                //if (cls == null) return;
                //var rpt = new BuildingReportViewModel()
                //{
                //    Masahat = cls.Masahat,
                //    SellPrice = cls.SellPrice,
                //    RahnPrice1 = cls.RahnPrice1,
                //    EjarePrice1 = cls.EjarePrice1,
                //    Code = cls.Code,
                //    RoomCount = cls.RoomCount,
                //    TabaqeNo = cls.TabaqeNo,
                //    SaleSakht = cls.SaleSakht,
                //    ZirBana = cls.ZirBana,
                //    Address = cls.Address,
                //    TedadTabaqe = cls.TedadTabaqe,
                //    ShortDesc = cls.ShortDesc,
                //    VahedPerTabaqe = cls.VahedPerTabaqe,
                //    PishTotalPrice = cls.PishTotalPrice,
                //    PishPrice = cls.PishPrice,
                //    VamPrice = cls.VamPrice,
                //    Hashie = cls.Hashie,
                //    BarqName = cls.BarqName,
                //    GasName = cls.GasName,
                //    WaterName = cls.WaterName,
                //    OwnerName = cls.OwnerName,
                //    BuildingTypeName = cls.BuildingTypeName,
                //    BuildingConditionName = cls.BuildingConditionName,
                //    BuildingViewName = cls.BuildingViewName,
                //    DocumentTypeName = cls.DocumentTypeName,
                //    FloorCoverName = cls.FloorCoverName,
                //    KitchenServiceName = cls.KitchenServiceName,
                //    SideName = cls.SideName,
                //    UserName = cls.UserName,
                //    TellName = cls.TellName,
                //    //Options = string.Join(", ", cls.OptionList?.Select(q => q.OptionName)),
                //    DeliveryDateSh = Calendar.MiladiToShamsi(cls.DeliveryDate),
                //    RegionName = (await RegionsBussines.GetAsync(cls.RegionGuid))?.Name ?? ""
                //};
                //if (cls.SellPrice > 0 && cls.Masahat > 0)
                //    rpt.SellPricePerMetr = cls.SellPrice / cls.Masahat;

                //var cls_ = new ReportGenerator(StiType.Building_One, EnPrintType.Pdf_A5)
                //{ Lst = new List<object>() { rpt } };
                //cls_.PrintNew();
                //var desc = $"کد ملک:( {cls.Code} ) ** محدوده:( {cls.RegionName} ) ** آدرس:( {cls.Address} )";
                //await UserLogBussines.SaveBuildingLogAsync(EnLogAction.CustomPrint, cls.Guid, desc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void menuPrintList_Click(object sender, EventArgs e)
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
    }
}
