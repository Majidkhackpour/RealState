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
using Building.BuildingAccountType;
using Building.BuildingCondition;
using Building.BuildingMatchesItem;
using Building.BuildingOptions;
using Building.BuildingRequest;
using Building.Buildings;
using Building.Buildings.Selector;
using Building.BuildingType;
using Building.BuildingView;
using Building.Contract;
using Building.DocumentType;
using Building.FloorCover;
using Building.KitchenService;
using Building.RentalAuthority;
using Building.Window;
using Cities.City;
using Cities.Region;
using EntityCache.Bussines;
using Ertegha;
using MetroFramework.Forms;
using Notification;
using Payamak;
using Payamak.Panel;
using Payamak.PhoneBook;
using Peoples;
using Persistence;
using RealState.Advance;
using RealState.BackUpLog;
using RealState.Note;
using Services;
using Services.FilterObjects;
using Settings;
using Settings.Classes;
using Settings.Forms;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using User;
using User.Advisor;
using WebHesabBussines;
using WindowsSerivces;
using WindowsSerivces.Waiter;

namespace RealState
{
    public partial class frmNewMain : MetroForm
    {
        private Color foreColor = Color.FromArgb(228, 237, 255);
        private bool _showDialog = false;

        private void SetAccess()
        {
            try
            {
                //var access = UserBussines.CurrentUser.UserAccess;

                //lblBuilding.Enabled = access?.Building.Building_ShowForm ?? false;
                //lblBuildingArchive.Enabled = access?.Building.Building_ShowForm ?? false;
                //lblBuildingAccountType.Enabled = access?.BuildingAccountType.Building_Acc_Type_ShowForm ?? false;
                //lblBuildingCondition.Enabled = access?.BuildingCondition.Building_Condition_ShowForm ?? false;
                //lblBuildingOptions.Enabled = access?.BuildingOption.Building_Option_ShowForm ?? false;
                //lblRequest.Enabled = access?.BuildingRequest.Building_Request_ShowForm ?? false;
                //lblBuildingType.Enabled = access?.BuildingType.Building_Type_ShowForm ?? false;
                //lblBuildingView.Enabled = access?.BuildingView.Building_View_ShowForm ?? false;
                //lblCities.Enabled = access?.Cities.City_ShowForm ?? false;
                //lblContract.Enabled = access?.Contract.Contract_ShowForm ?? false;
                //lblDocumentType.Enabled = access?.DocumentType.Document_Type_ShowForm ?? false;
                //lblFloorCover.Enabled = access?.FloorCover.Floor_Cover_ShowForm ?? false;
                //lblHazine.Enabled = access?.Hazine.Hazine_ShowForm ?? false;
                //lblKitchenService.Enabled = access?.KitchenService.Kitchen_Service_ShowForm ?? false;
                //lblPardakht.Enabled = access?.Pardakht.Pardakht_ShowForm ?? false;
                //lblPeoples.Enabled = access?.Peoples.People_ShowForm ?? false;
                //lblPhoneBook.Enabled = access?.PhoneBook.PhoneBook_ShowForm ?? false;
                //lblReception.Enabled = access?.Reception.Reception_ShowForm ?? false;
                //lblRental.Enabled = access?.RentalAuthority.Rental_ShowForm ?? false;
                //lblSanad.Enabled = access?.Sanad.Sanad_Insert ?? false;
                //lblSendSms.Enabled = access?.SendSms.Sms_ShowForm ?? false;
                //lblSmsPanel.Enabled = access?.SmsPanel.Panel_ShowForm ?? false;
                //lblUsers.Enabled = access?.User.User_ShowForm ?? false;
                //lblUserAccess.Enabled = access?.UserAccLevel.User_Acc_ShowForm ?? false;
                //lblBuildingFast.Enabled = access?.Building.Building_Insert ?? false;
                //lblBuildingArchive.Enabled = access?.Building.Building_ShowForm ?? false;
                //lblBuildingMatches.Enabled = access?.Building.Building_Show_request ?? false;
                //lblBank.Enabled = access?.Bank.Bank_ShowForm ?? false;
                //lblReceptionCheck.Enabled = access?.CheckM.CheckM_ShowForm ?? false;
                //lblPardakhtCheck.Enabled = access?.CheckSh.CheckSh_ShowForm ?? false;
                //lblCheckBook.Enabled = access?.DasteCheck.DasteCheck_ShowForm ?? false;
                //lblTafsil.Enabled = access?.Tafsil.Tafsil_ShowForm ?? false;
                //lblSandouq.Enabled = access?.Sandouq.Sandouq_ShowForm ?? false;
                //lblAdvisor.Enabled = access?.Advisor.Advisor_ShowForm ?? false;

                //lblAccounting.Visible = VersionAccess.Accounting;
                //groupPanel7.Visible = VersionAccess.Accounting;
                //lblSmsPanel.Visible = VersionAccess.Sms;
                //lblSendSms.Visible = VersionAccess.Sms;
                //lblAdvertise.Visible = VersionAccess.Advertise;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void SetButtomLables()
        {
            try
            {
                lblEconomyName.Text = SettingsBussines.Setting.CompanyInfo.EconomyName;
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

        private void DisplayFrm(Form frm, bool autoDispose = true)
        {
            try
            {
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
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
                PeoplesBussines.OnSaved += PeoplesBussines_OnSaved;
                BuildingBussines.OnSaved += BuildingBussines_OnSaved;
                BuildingRequestBussines.OnSaved += BuildingRequestBussines_OnSaved;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private Task BuildingRequestBussines_OnSaved()
        {
            _ = new Waiter("درحال ایجاد گزارش", ucReport1, Task.Run(ucReport1.InitAsync));
            return Task.CompletedTask;
        }
        private Task BuildingBussines_OnSaved()
        {
            try
            {
                _ = new Waiter("درحال ایجاد گزارش", ucReport1, Task.Run(ucReport1.InitAsync));
                FileFormatter.Init();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task PeoplesBussines_OnSaved()
        {
            _ = new Waiter("درحال ایجاد گزارش", ucReport1, Task.Run(ucReport1.InitAsync));
            return Task.CompletedTask;
        }
        private void lblBaseInfo_Click(object sender, System.EventArgs e) => grpBaseInfo.Height = grpBaseInfo.Height == 48 ? 570 : 48;
        private void lblBuildingMenu_Click(object sender, EventArgs e) => grpBuilding.Height = grpBuilding.Height == 48 ? 293 : 48;
        private void lblUsers_Click(object sender, EventArgs e) => grpUsers.Height = grpUsers.Height == 48 ? 171 : 48;
        private void lblAccounting_Click(object sender, EventArgs e) => grpAccounting.Height = grpAccounting.Height == 48 ? 528 : 48;
        private void lblOptions_Click(object sender, EventArgs e) => grpOptions.Height = grpOptions.Height == 48 ? 448 : 48;
        private async void frmNewMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetAccess();
                lblDate.Text = Calendar.GetFullCalendar();
                lblSerial.Text = $@"شناسه فنی: {await clsGlobalSetting.GetHardDriveSerialAsync()}";
                SetClock();
                _showDialog = SettingsBussines.Setting.Global.ShowDialog;
                _ = Task.Run(() => AutoBackUp.BackUpAsync(@"C:\", false, EnBackUpType.Auto));
                _ = new Waiter("درحال ایجاد گزارش", ucReport1, Task.Run(ucReport1.InitAsync));
                SetButtomLables();
                _ = Task.Run(ShowTodayNotesAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmNewMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    _ = new Waiter("درحال ایجاد گزارش", ucReport1, Task.Run(ucReport1.InitAsync));
                    return;
                }
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
        private void lblExit_MouseEnter(object sender, EventArgs e) => lblExit.ForeColor = Color.Red;
        private void lblExit_MouseLeave(object sender, EventArgs e) => lblExit.ForeColor = foreColor;
        private async void lblExit_Click(object sender, EventArgs e)
        {
            try
            {
                await UserLogBussines.SaveAsync(EnLogAction.Logout, EnLogPart.Logout, null, "", null);
                Application.Exit();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void timerCheckInternet_Tick(object sender, EventArgs e) => _ = Task.Run(CheckInternetAsync);
        private Task ucBuildinhWindows_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowWindow();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucBuildingType_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBuildingType();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucCondition_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBuildingCondition();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucBuildingView_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBuildingView();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucRental_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowRentalAuthority(false);
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucDocType_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowDocumentType();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucKitchen_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowKitchenService();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucFloorCover_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowFloorCover();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucAccountType_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBuildingAccountType();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucBuildingOptions_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBuildingOption();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucRegions_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowRegions();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucCities_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowCities();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucPeoples_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowPeoples(false);
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucMatch_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmStartBuildingMatches();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucRequest_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowRequest();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucContract_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmContractFilter();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucArchive_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBuildings(true, new BuildingFilter() { Status = true, IsArchive = true });
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucShowBuilding_OnClick(UcButton arg)
        {
            try
            {
                var filter = new BuildingFilter();
                if (Cache.IsClient)
                {
                    var frmFilter = new frmBuildingFilter { Filter = filter };
                    if (frmFilter.ShowDialog(this) != DialogResult.OK)
                        return Task.CompletedTask;
                    filter = frmFilter.Filter;
                }

                filter.Status = true;
                var frm = new frmShowBuildings(false, filter);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucAddBuilding_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmSelectBuildingType(this, new BuildingBussines());
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucAdvisors_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowAdvisor();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucAccess_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmAccessLevel();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucUsers_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowUsers(false);
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucManagerPanel_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmManagementPass();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    new frmAdvance().ShowDialog(this);
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucErtegha_OnClick(UcButton arg)
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
            return Task.CompletedTask;
        }
        private async Task ucBazsazi_OnClick(UcButton arg)
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
        private Task ucRestore_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmBackUpLog();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucBackUp_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmBackUpLog();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucSendSms_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmSendSms();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucPanels_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowPanels();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucNoteBook_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowNotes();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucPhoneBook_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowPhoneBook();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucSetting_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmSetting();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucSanad_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowSanad();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucReception_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowReception();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucPardakht_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowPardakht();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucKolMoein_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmKolMoein(false);
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucTafsil_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowTafsils();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucHazine_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowHazine();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucSandouq_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowSandouq();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucBank_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowBanks();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucDasteCheck_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowDasteCheck();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucPardakhtCheck_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowCheckSh();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucRecieveCheck_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmShowCheckM(false);
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucReports_OnClick(UcButton arg)
        {
            try
            {
                var frm = new frmSelectReport();
                DisplayFrm(frm);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private void lblTitle_Click(object sender, EventArgs e) => pnlInfo.Visible = !pnlInfo.Visible;
    }
}
