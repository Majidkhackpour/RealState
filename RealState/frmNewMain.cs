using Accounting.Bank;
using Accounting.Check.CheckMoshtari;
using Accounting.Check.CheckShakhsi;
using Accounting.Check.DasteCheck;
using Accounting.Hazine;
using Accounting.Hesab;
using Accounting.Pardakht;
using Accounting.Reception;
using Accounting.Report;
using Accounting.Sanad;
using Accounting.Sandouq;
using Advertise.Forms;
using Building.Buildings;
using Building.BuildingAccountType;
using Building.BuildingCondition;
using Building.BuildingMatchesItem;
using Building.BuildingOptions;
using Building.BuildingRequest;
using Building.BuildingType;
using Building.BuildingView;
using Building.Contract;
using Building.DocumentType;
using Building.FloorCover;
using Building.KitchenService;
using Building.RentalAuthority;
using Cities.City;
using Cities.Region;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Ertegha;
using MetroFramework.Forms;
using Notification;
using Payamak;
using Payamak.Panel;
using Payamak.PhoneBook;
using Peoples;
using RealState.Advance;
using RealState.BackUpLog;
using RealState.CalendarForms;
using RealState.Note;
using RealState.UserControls;
using Services;
using Settings;
using Settings.Classes;
using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using User;
using User.Advisor;
using WindowsSerivces;
using Building.Buildings.Selector;
using Persistence;
using Services.FilterObjects;
using WebHesabBussines;

namespace RealState
{
    public partial class frmNewMain : MetroForm
    {
        private ConcurrentDictionary<string, EnForms> _dic = new ConcurrentDictionary<string, EnForms>();
        private Color foreColor = Color.FromArgb(228, 237, 255);
        private bool _showDialog = false;

        private void FillDictionary()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnForms)).Cast<EnForms>();
                foreach (var item in values)
                    _dic.TryAdd(item.GetDisplay(), item);

                EnForms x;
                if (!VersionAccess.Accounting)
                {
                    _dic.TryRemove(EnForms.Hazine.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.Daryaft.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.Pardakht.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.Sanad.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.AccountingReport.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.KolMoein.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.Tafsil.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.Sandouq.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.Bank.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.CheckBook.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.PardakhtCheck.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.ReceptionCheck.GetDisplay(), out x);
                }

                if (!VersionAccess.Sms)
                {
                    _dic.TryRemove(EnForms.SmsPanel.GetDisplay(), out x);
                    _dic.TryRemove(EnForms.SendSms.GetDisplay(), out x);
                }
                if (!VersionAccess.Advertise)
                    _dic.TryRemove(EnForms.Advertise.GetDisplay(), out x);
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

                lblBuilding.Enabled = access?.Building.Building_ShowForm ?? false;
                lblBuildingArchive.Enabled = access?.Building.Building_ShowForm ?? false;
                lblBuildingAccountType.Enabled = access?.BuildingAccountType.Building_Acc_Type_ShowForm ?? false;
                lblBuildingCondition.Enabled = access?.BuildingCondition.Building_Condition_ShowForm ?? false;
                lblBuildingOptions.Enabled = access?.BuildingOption.Building_Option_ShowForm ?? false;
                lblRequest.Enabled = access?.BuildingRequest.Building_Request_ShowForm ?? false;
                lblBuildingType.Enabled = access?.BuildingType.Building_Type_ShowForm ?? false;
                lblBuildingView.Enabled = access?.BuildingView.Building_View_ShowForm ?? false;
                lblCities.Enabled = access?.Cities.City_ShowForm ?? false;
                lblContract.Enabled = access?.Contract.Contract_ShowForm ?? false;
                lblDocumentType.Enabled = access?.DocumentType.Document_Type_ShowForm ?? false;
                lblFloorCover.Enabled = access?.FloorCover.Floor_Cover_ShowForm ?? false;
                lblHazine.Enabled = access?.Hazine.Hazine_ShowForm ?? false;
                lblKitchenService.Enabled = access?.KitchenService.Kitchen_Service_ShowForm ?? false;
                lblPardakht.Enabled = access?.Pardakht.Pardakht_ShowForm ?? false;
                lblPeoples.Enabled = access?.Peoples.People_ShowForm ?? false;
                lblPhoneBook.Enabled = access?.PhoneBook.PhoneBook_ShowForm ?? false;
                lblReception.Enabled = access?.Reception.Reception_ShowForm ?? false;
                lblRental.Enabled = access?.RentalAuthority.Rental_ShowForm ?? false;
                lblSanad.Enabled = access?.Sanad.Sanad_Insert ?? false;
                lblSendSms.Enabled = access?.SendSms.Sms_ShowForm ?? false;
                lblSmsPanel.Enabled = access?.SmsPanel.Panel_ShowForm ?? false;
                lblUsers.Enabled = access?.User.User_ShowForm ?? false;
                lblUserAccess.Enabled = access?.UserAccLevel.User_Acc_ShowForm ?? false;
                lblBuildingFast.Enabled = access?.Building.Building_Insert ?? false;
                lblBuildingArchive.Enabled = access?.Building.Building_ShowForm ?? false;
                lblBuildingMatches.Enabled = access?.Building.Building_Show_request ?? false;
                lblBank.Enabled = access?.Bank.Bank_ShowForm ?? false;
                lblReceptionCheck.Enabled = access?.CheckM.CheckM_ShowForm ?? false;
                lblPardakhtCheck.Enabled = access?.CheckSh.CheckSh_ShowForm ?? false;
                lblCheckBook.Enabled = access?.DasteCheck.DasteCheck_ShowForm ?? false;
                lblTafsil.Enabled = access?.Tafsil.Tafsil_ShowForm ?? false;
                lblSandouq.Enabled = access?.Sandouq.Sandouq_ShowForm ?? false;
                lblAdvisor.Enabled = access?.Advisor.Advisor_ShowForm ?? false;

                lblAccounting.Visible = VersionAccess.Accounting;
                groupPanel7.Visible = VersionAccess.Accounting;
                lblSmsPanel.Visible = VersionAccess.Sms;
                lblSendSms.Visible = VersionAccess.Sms;
                lblAdvertise.Visible = VersionAccess.Advertise;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Form SelectForm(EnForms _form)
        {
            Form frm = null;
            try
            {
                switch (_form)
                {
                    case EnForms.Peoples: frm = new frmShowPeoples(false); break;
                    case EnForms.Cities: frm = new frmShowCities(); break;
                    case EnForms.Regions: frm = new frmShowRegions(); break;
                    case EnForms.BuildingOptions: frm = new frmShowBuildingOption(); break;
                    case EnForms.BuildingAccountType: frm = new frmShowBuildingAccountType(); break;
                    case EnForms.FloorCover: frm = new frmShowFloorCover(); break;
                    case EnForms.KitchenService: frm = new frmShowKitchenService(); break;
                    case EnForms.DocumentType: frm = new frmShowDocumentType(); break;
                    case EnForms.RentalAouthority: frm = new frmShowRentalAuthority(); break;
                    case EnForms.BuildingView: frm = new frmShowBuildingView(); break;
                    case EnForms.BuildingCondition: frm = new frmShowBuildingCondition(); break;
                    case EnForms.BuildingType: frm = new frmShowBuildingType(); break;
                    case EnForms.Building: frm = new frmShowBuildings(false, new BuildingFilter() { Status = true }); break;
                    case EnForms.BuildingFast: frm = new frmSelectBuildingType(this, new BuildingBussines()); break;
                    case EnForms.AdvancedSearch: frm = new frmFilterForm(); break;
                    case EnForms.BuildingArchive: frm = new frmShowBuildings(true, new BuildingFilter() { Status = true, IsArchive = true }); break;
                    case EnForms.BuildingMatch: frm = new frmStartBuildingMatches(); break;
                    case EnForms.Contract: frm = new frmShowContract(); break;
                    case EnForms.Request: frm = new frmShowRequest(); break;
                    case EnForms.Users: frm = new frmShowUsers(false); break;
                    case EnForms.UserAccess: frm = new frmAccessLevel(); break;
                    case EnForms.Advisor: frm = new frmShowAdvisor(); break;
                    case EnForms.Hazine: frm = new frmShowHazine(); break;
                    case EnForms.Daryaft: frm = new frmShowReception(); break;
                    case EnForms.Pardakht: frm = new frmShowPardakht(); break;
                    case EnForms.Sanad: frm = new frmShowSanad(); break;
                    case EnForms.AccountingReport: frm = new frmSelectReport(); break;
                    case EnForms.KolMoein: frm = new frmKolMoein(false); break;
                    case EnForms.Tafsil: frm = new frmShowTafsils(); break;
                    case EnForms.Sandouq: frm = new frmShowSandouq(); break;
                    case EnForms.Bank: frm = new frmShowBanks(); break;
                    case EnForms.CheckBook: frm = new frmShowDasteCheck(); break;
                    case EnForms.ReceptionCheck: frm = new frmShowCheckM(false); break;
                    case EnForms.PardakhtCheck: frm = new frmShowCheckSh(); break;
                    case EnForms.Setting: frm = new frmSettings(); break;
                    case EnForms.Phonebook: frm = new frmShowPhoneBook(); break;
                    case EnForms.Note: frm = new frmShowNotes(); break;
                    case EnForms.SmsPanel: frm = new frmShowPanels(); break;
                    case EnForms.SendSms: frm = new frmSendSms(); break;
                    case EnForms.Advertise: frm = new frmRobotPanel(); break;
                    case EnForms.BackUp: frm = new frmBackUpLog(); break;
                    case EnForms.Restore: frm = new frmBackUpLog(); break;
                    case EnForms.Advance:
                        {
                            frm = new frmManagementPass();
                            if (frm.ShowDialog(this) == DialogResult.OK)
                                new frmAdvance().ShowDialog(this);
                            break;
                        }
                    case EnForms.Taqvim: frm = new frmCalendar(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return frm;
        }
        private void SetButtomLables()
        {
            try
            {
                lblEconomyName.Text = clsEconomyUnit.EconomyName;
                var cn = new SqlConnection(AppSettings.DefaultConnectionString);
                lblDbName.Text = cn?.Database ?? "";
                lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                lblUserName.Text = UserBussines.CurrentUser?.Name ?? "";
                _ = Task.Run(CheckInternetAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task CheckInternetAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await Utilities.PingHostAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            Invoke(res.HasError
                ? new MethodInvoker(() => lblInternet.Text = "وضعیت اتصال سیستم به اینترنت: عدم اتصال")
                : new MethodInvoker(() => lblInternet.Text = "وضعیت اتصال سیستم به اینترنت: متصل"));
        }
        private void ClearFlowPanels()
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    fPanelCustomerBirthDay.Controls?.Clear();
                    fPanelSarresidEjare.Controls?.Clear();
                    fPanelBuildingRegion.Controls?.Clear();
                    fPanelRequestRegion.Controls?.Clear();
                    fPanelMath.Controls?.Clear();
                    fPanelPirority.Controls?.Clear();
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadDashboard()
        {
            try
            {
                ClearFlowPanels();
                _ = Task.Run(LoadCustomerBirthdayAsync);
                _ = Task.Run(LoadSarresidAsync);
                _ = Task.Run(LoadSchemaAsync);
                _ = Task.Run(LoadBuildingRegionAsync);
                _ = Task.Run(LoadRequestRegionAsync);
                _ = Task.Run(LoadMatchAsync);
                _ = Task.Run(LoadBuildingHighPriorityAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadCustomerBirthdayAsync()
        {
            try
            {
                var dateSh = Calendar.MiladiToShamsi(DateTime.Now);
                var day = Calendar.GetDayOfDateSh(dateSh);
                var dayStr = day.ToString();
                if (day < 10) dayStr = $"0{day}";
                var mounth = Calendar.GetMonthOfDateSh(dateSh);
                var mounthStr = mounth.ToString();
                if (mounth < 10) mounthStr = $"0{mounth}";
                var newDate = $"/{mounthStr}/{dayStr}";
                var birthdayList = await PeoplesBussines.GetAllBirthDayAsync(newDate);
                if (birthdayList != null && birthdayList.Count > 0)
                {
                    foreach (var item in birthdayList)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            var c = new ucCustomerBirthday { People = item, Width = fPanelCustomerBirthDay.Width - 30 };
                            fPanelCustomerBirthDay.Controls.Add(c);
                        }));
                    }
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fPanelCustomerBirthDay.Visible = false;
                        lblBirthDayNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadSarresidAsync()
        {
            try
            {
                var list = await ContractBussines.DischargeListAsync();
                if (list != null && list.Count > 0)
                {
                    list = list?.OrderBy(q => q.ToDate)?.Take(10)?.ToList();
                    foreach (var item in list)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            var c = new ucDischargeList() { Model = item, Width = fPanelSarresidEjare.Width - 30 };
                            fPanelSarresidEjare.Controls.Add(c);
                        }));
                    }
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fPanelSarresidEjare.Visible = false;
                        lblSarresidNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadSchemaAsync()
        {
            try
            {
                var allBuilding = await BuildingBussines.DbCount(Guid.Empty, 0);
                var myBuilding = await BuildingBussines.DbCount(UserBussines.CurrentUser.Guid, 0);
                var rahn = await BuildingBussines.DbCount(Guid.Empty, 1);
                var foroush = await BuildingBussines.DbCount(Guid.Empty, 2);
                var allReq = await BuildingRequestBussines.DbCount(Guid.Empty);
                var myReq = await BuildingRequestBussines.DbCount(UserBussines.CurrentUser.Guid);
                Invoke(new MethodInvoker(() =>
                {
                    lblAllBuilding.Text = allBuilding.ToString();
                    lblMyBuilding.Text = myBuilding.ToString();
                    lblAllRahn.Text = rahn.ToString();
                    lblAllForoosh.Text = foroush.ToString();
                    lblAllRequest.Text = allReq.ToString();
                    lblMyRequest.Text = myReq.ToString();
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadBuildingRegionAsync()
        {
            try
            {
                var list = await RegionsBussines.GetAllBuildingReportAsync(new CancellationToken());
                if (list != null && list.Count > 0)
                {
                    list = list?.OrderByDescending(q => q.Count)?.Take(10)?.ToList();
                    foreach (var item in list)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            var c = new ucRegionReport() { Report = item, Width = fPanelBuildingRegion.Width - 30 };
                            fPanelBuildingRegion.Controls.Add(c);
                        }));
                    }
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fPanelBuildingRegion.Visible = false;
                        lblRegionBuildingNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadRequestRegionAsync()
        {
            try
            {
                var list = await RegionsBussines.GetAllRequestReportAsync(new CancellationToken());
                if (list != null && list.Count > 0)
                {
                    list = list?.OrderByDescending(q => q.Count)?.Take(10)?.ToList();
                    foreach (var item in list)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            var c = new ucRegionReport() { Report = item, Width = fPanelRequestRegion.Width - 30 };
                            fPanelRequestRegion.Controls.Add(c);
                        }));
                    }
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fPanelRequestRegion.Visible = false;
                        lblRegionRequestNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadMatchAsync()
        {
            try
            {
                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(new CancellationToken());
                if (list != null && list.Count > 0)
                {
                    list = list.OrderByDescending(q => q.RequestCount)?.Take(10)?.ToList();
                    foreach (var item in list)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            var c = new ucBuildingMatch() { Model = item, Width = fPanelMath.Width - 30 };
                            fPanelMath.Controls.Add(c);
                        }));
                    }
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fPanelMath.Visible = false;
                        lblMatchNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadBuildingHighPriorityAsync()
        {
            try
            {
                var list = await BuildingBussines.GetAllHighPriorityAsync(new CancellationToken());
                list = list?.Where(q => q.Priority == EnBuildingPriority.SoHigh && !q.IsArchive)?.Take(10)?.ToList();
                if (list != null && list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            var c = new ucBuildingHighPriority() { Building = item, Width = fPanelPirority.Width - 30 };
                            fPanelPirority.Controls.Add(c);
                        }));
                    }
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        fPanelPirority.Visible = false;
                        lblBuildingNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ShowTodayNotesAsync()
        {
            try
            {
                var list = await NoteBussines.GetAllTodayNotesAsync(UserBussines.CurrentUser.Guid);
                if (list != null && list.Count > 0)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        var frm = new frmNaqz(list);
                        frm.ShowDialog();
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetClock()
        {
            try
            {
                lblHour.Text = DateTime.Now.Hour.ToString();
                if (lblHour.Text.Length == 1) lblHour.Text = "0" + DateTime.Now.Hour;
                lblMinute.Text = DateTime.Now.Minute.ToString();
                if (lblMinute.Text.Length == 1) lblMinute.Text = "0" + DateTime.Now.Minute;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DisplayFrm(EnForms frm) => DisplayFrm(frm, true);
        private void DisplayFrm(EnForms enfrm, bool autoDispose)
        {
            try
            {
                var frm = SelectForm(enfrm);
                frm.ShowInTaskbar = true;
                if (!_showDialog)
                {
                    frm?.ShowDialog(this);
                    if (autoDispose)
                        frm?.Dispose();
                }
                else
                    frm?.Show(this);
            }
            catch (Exception ex) { WebErrorLog.ErrorInstence.StartErrorLog(ex); }
        }

        public frmNewMain()
        {
            try
            {
                InitializeComponent();
                ShowInTaskbar = true;
                pnlInfo.Visible = false;
                grpBuilding.Height = grpAccounting.Height = grpBaseInfo.Height = 48;
                grpUsers.Height = grpOptions.Height = 48;
                FillDictionary();
                PeoplesBussines.OnSaved += PeoplesBussines_OnSaved;
                BuildingBussines.OnSaved += BuildingBussines_OnSaved;
                BuildingRequestBussines.OnSaved += BuildingRequestBussines_OnSaved;
                if (Cache.IsClient || !VersionAccess.Advertise) return;
                DivarFiles.OnSavedStarted += DivarFilesOnOnSavedStarted;
                DivarFiles.OnSavedFinished += DivarFilesOnOnSavedFinished;
                DivarFiles.OnDataRecieved += DivarFilesOnOnDataRecieved;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task DivarFilesOnOnDataRecieved(int count)
        {
            try
            {
                Invoke(new MethodInvoker(() => lblDivar.Text = $"درحال دریافت فایل از سرور ... ({count})"));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task DivarFilesOnOnSavedFinished(int count)
        {
            try
            {
                if (WebCustomer.CheckCustomer())
                {
                    var msg = "اتمام دریافت فایل از سرور \r\n" +
                              $"تعداد فایل ذخیره شده: {count}";
                    _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                }
                Invoke(new MethodInvoker(() => lblDivar.Text = "اتمام دریافت فایل از سرور ..."));
                await Task.Delay(10 * 6000);
                Invoke(new MethodInvoker(() =>
                {
                    lblDivar.Text = "";
                    lblDivar.Visible = false;
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task DivarFilesOnOnSavedStarted(int count)
        {
            try
            {
                if (WebCustomer.CheckCustomer())
                {
                    var msg = "آغاز دریافت فایل از سرور \r\n" +
                              $"تعداد فایل دریافت شده: {count}";
                    _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, msg));
                }
                Invoke(new MethodInvoker(() => lblDivar.Text = "درحال دریافت فایل از سرور ..."));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task BuildingRequestBussines_OnSaved() => _ = Task.Run(LoadDashboard);
        private async Task BuildingBussines_OnSaved()
        {
            try
            {
                _ = Task.Run(LoadDashboard);
                FileFormatter.Init();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task PeoplesBussines_OnSaved() => _ = Task.Run(LoadDashboard);
        private void lblBaseInfo_Click(object sender, System.EventArgs e) => grpBaseInfo.Height = grpBaseInfo.Height == 48 ? 481 : 48;
        private void lblBuildingMenu_Click(object sender, EventArgs e) => grpBuilding.Height = grpBuilding.Height == 48 ? 266 : 48;
        private void lblUsers_Click(object sender, EventArgs e) => grpUsers.Height = grpUsers.Height == 48 ? 156 : 48;
        private void lblAccounting_Click(object sender, EventArgs e) => grpAccounting.Height = grpAccounting.Height == 48 ? 481 : 48;
        private void lblOptions_Click(object sender, EventArgs e) => grpOptions.Height = grpOptions.Height == 48 ? 481 : 48;
        private void frmNewMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetAccess();
                FileFormatter.Init();
                if (!Cache.IsClient)
                {
                    DivarFiles.Init();
                    AutoBackUp.Init(this);
                    if (WebCustomer.CheckCustomer() && WebCustomer.Customer.HardSerial != "265155255")
                        _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, "ورود به نرم افزار"));
                }
                var myCollection = new AutoCompleteStringCollection();
                var list = _dic.Keys;
                foreach (var item in list.ToList())
                    myCollection.Add(item);
                txtSearch.AutoCompleteCustomSource = myCollection;
                lblDate.Text = Calendar.GetFullCalendar();
                lblSerial.Text = $@"شناسه فنی: {clsGlobalSetting.HardDriveSerial}";
                SetClock();
                _showDialog = clsGlobal.ShowDialog;
                _ = Task.Run(() => AutoBackUp.BackUpAsync(@"C:\", false, EnBackUpType.Auto));
                LoadDashboard();
                SetButtomLables();
                _ = Task.Run(ShowTodayNotesAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter) return;
                _dic.TryGetValue(txtSearch.Text, out var type);
                var frm = SelectForm(type);
                frm?.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblPeoples_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Peoples);
        private void lblCities_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Cities);
        private void lblRegions_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Regions);
        private void lblBuildingOptions_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingOptions);
        private void lblBuildingAccountType_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingAccountType);
        private void lblFloorCover_Click(object sender, EventArgs e) => DisplayFrm(EnForms.FloorCover);
        private void lblKitchenService_Click(object sender, EventArgs e) => DisplayFrm(EnForms.KitchenService);
        private void lblDocumentType_Click(object sender, EventArgs e) => DisplayFrm(EnForms.DocumentType);
        private void lblRental_Click(object sender, EventArgs e) => DisplayFrm(EnForms.RentalAouthority);
        private void lblBuildingView_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingView);
        private void lblBuildingCondition_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingCondition);
        private void lblBuildingType_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingType);
        private void lblBuilding_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Building);
        private void lblBuildingFast_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingFast);
        private void lblBuildingSearch_Click(object sender, EventArgs e) => DisplayFrm(EnForms.AdvancedSearch);
        private void lblBuildingArchive_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingArchive);
        private void lblBuildingMatches_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BuildingMatch);
        private void lblContract_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Contract);
        private void lblRequest_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Request);
        private void lblHazine_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Hazine);
        private void lblReception_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Daryaft);
        private void lblPardakht_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Pardakht);
        private void lblSanad_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Sanad);
        private void lblAccountingReport_Click(object sender, EventArgs e) => DisplayFrm(EnForms.AccountingReport);
        private void lblKolMoein_Click(object sender, EventArgs e) => DisplayFrm(EnForms.KolMoein);
        private void lblTafsil_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Tafsil);
        private void lblSandouq_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Sandouq);
        private void lblBank_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Bank);
        private void lblCheckBook_Click(object sender, EventArgs e) => DisplayFrm(EnForms.CheckBook);
        private void lblReceptionCheck_Click(object sender, EventArgs e) => DisplayFrm(EnForms.ReceptionCheck);
        private void lblPardakhtCheck_Click(object sender, EventArgs e) => DisplayFrm(EnForms.PardakhtCheck);
        private void lblSetting_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Setting);
        private void lblPhoneBook_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Phonebook);
        private void lblNote_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Note);
        private void lblSmsPanel_Click(object sender, EventArgs e) => DisplayFrm(EnForms.SmsPanel);
        private void lblSendSms_Click(object sender, EventArgs e) => DisplayFrm(EnForms.SendSms);
        private void lblAdvertise_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Advertise);
        private void lblBackUp_Click(object sender, EventArgs e) => DisplayFrm(EnForms.BackUp);
        private void lblRestore_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Restore);
        private async void lblBazsazi_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await clsErtegha.StartErteghaAsync(AppSettings.DefaultConnectionString, this, true, !Cache.IsClient);
                if (!res.HasError)
                {
                    this.ShowMessage("بازسازی اطلاعات با موفقیت انجام شد");
                    return;
                }

                this.ShowWarning("خطا در بازسازی اطلاعات");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblAdvance_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Advance);
        private void lblTaqvim_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Taqvim);
        private void lblUserManage_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Users);
        private void lblAdvisor_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Advisor);
        private void lblUserAccess_Click(object sender, EventArgs e) => DisplayFrm(EnForms.UserAccess);
        private void frmNewMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    LoadDashboard();
                    return;
                }
                if (e.KeyCode == Keys.Escape && !string.IsNullOrEmpty(txtSearch.Text))
                    txtSearch.Text = "";
                if (pnlInfo.Visible) pnlInfo.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void timerSecond_Tick(object sender, EventArgs e)
        {
            try
            {
                SetClock();
                if (lblSecond.Visible)
                    lblSecond.Visible = false;
                else if (!lblSecond.Visible)
                    lblSecond.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void picSetting_Click(object sender, EventArgs e) => DisplayFrm(EnForms.Setting);
        private void picInfo_Click(object sender, EventArgs e) => pnlInfo.Visible = !pnlInfo.Visible;
        private void lblExit_MouseEnter(object sender, EventArgs e) => lblExit.ForeColor = Color.Red;
        private void lblExit_MouseLeave(object sender, EventArgs e) => lblExit.ForeColor = foreColor;
        private async void lblExit_Click(object sender, EventArgs e)
        {
            try
            {
                await UserLogBussines.SaveAsync(EnLogAction.Logout, EnLogPart.Logout, null);
                Application.Exit();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblErtegha_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var frm = new SoftwareLock.frmClient("", false);
                if (frm.ShowDialog(this) != DialogResult.OK)
                    res.AddError("خطا در تایید شناسه فنی ");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            if (res.HasError) this.ShowError(res);
            else
            {
                this.ShowMessage("ارتقای نسخه نرم افزار با موفقیت انجام شد. جهت اعمال دسترسی، برنامه مجددا اجرا خواهد شد");
                Application.Restart();
            }
        }
        private void timerCheckInternet_Tick(object sender, EventArgs e) => _ = Task.Run(CheckInternetAsync);
    }
}
