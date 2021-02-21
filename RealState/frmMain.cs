using Accounting;
using Accounting.Hazine;
using Accounting.Payement;
using Accounting.Reception;
using Advertise.Forms;
using Building.Building;
using Building.BuildingAccountType;
using Building.BuildingCondition;
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
using Ertegha;
using MetroFramework.Forms;
using Notification;
using Payamak;
using Payamak.Panel;
using Payamak.PhoneBook;
using Peoples;
using RealState.BackUpLog;
using RealState.Note;
using Services;
using Settings;
using Settings.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Bank;
using Accounting.Check.DasteCheck;
using Accounting.Hesab;
using Accounting.Sandouq;
using Accounting.Sood_Zian;
using Advertise.Classes;
using Advertise.Forms.Simcard;
using Building;
using Building.BuildingMatchesItem;
using TMS.Class;
using User;
using Calendar = Services.Calendar;

namespace RealState
{
    public partial class frmMain : MetroForm
    {
        private List<PeoplesBussines> BirthdayList;
        private List<NoteBussines> allNote;

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
        private void SetCalendar()
        {
            try
            {
                var prd = new MaftooxCalendar.MaftooxPersianCalendar.DateWork();
                lblDay.Text = prd.GetNumberDayInMonth().ToString();
                lblMounth.Text = prd.GetNameMonth();
                lblYear.Text = prd.GetNumberYear().ToString();
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
                var access = clsUser.CurrentUser.UserAccess;

                btnAccountPerfomence.Enabled = access?.AccountPerformence.Account_Per_ShowForm ?? false;
                btnBuilding.Enabled = access?.Building.Building_ShowForm ?? false;
                btnBuildingArchive.Enabled = access?.Building.Building_ShowForm ?? false;
                btnBuildingAccountType.Enabled = access?.BuildingAccountType.Building_Acc_Type_ShowForm ?? false;
                btnBuildingCondition.Enabled = access?.BuildingCondition.Building_Condition_ShowForm ?? false;
                btnBuildingOptions.Enabled = access?.BuildingOption.Building_Option_ShowForm ?? false;
                btnBuildingRequest.Enabled = access?.BuildingRequest.Building_Request_ShowForm ?? false;
                btnBuildingAdvanceSearch.Enabled = access?.BuildingSearch.Building_Search_ShowForm ?? false;
                btnBuildingType.Enabled = access?.BuildingType.Building_Type_ShowForm ?? false;
                btnBuildingView.Enabled = access?.BuildingView.Building_View_ShowForm ?? false;
                btnCity.Enabled = access?.Cities.City_ShowForm ?? false;
                btnContract.Enabled = access?.Contract.Contract_ShowForm ?? false;
                btnDocType.Enabled = access?.DocumentType.Document_Type_ShowForm ?? false;
                btnFloorCover.Enabled = access?.FloorCover.Floor_Cover_ShowForm ?? false;
                btnHazine.Enabled = access?.Hazine.Hazine_ShowForm ?? false;
                btnKitchenService.Enabled = access?.KitchenService.Kitchen_Service_ShowForm ?? false;
                btnPardakht.Enabled = access?.Pardakht.Pardakht_ShowForm ?? false;
                btnPeoples.Enabled = access?.Peoples.People_ShowForm ?? false;
                btnPhoneBook.Enabled = access?.PhoneBook.PhoneBook_ShowForm ?? false;
                btnReception.Enabled = access?.Reception.Reception_ShowForm ?? false;
                btnRental.Enabled = access?.RentalAuthority.Rental_ShowForm ?? false;
                btnSanad.Enabled = access?.Sanad.Sanad_Insert ?? false;
                btnSendSms.Enabled = access?.SendSms.Sms_ShowForm ?? false;
                btnRobotPanel.Enabled = access?.Simcard.Simcard_ShowForm ?? false;
                btnSmsPanel.Enabled = access?.SmsPanel.Panel_ShowForm ?? false;
                btnUsers.Enabled = access?.User.User_ShowForm ?? false;
                btnAccessLevel.Enabled = access?.UserAccLevel.User_Acc_ShowForm ?? false;
                btnTarazName.Enabled = access?.Sanad.Sanad_Taraz ?? false;

                btnAccountingInfo.Visible = VersionAccess.Accounting;
                btnSmsPanel.Visible = VersionAccess.Sms;
                btnSendSms.Visible = VersionAccess.Sms;
                btnRobotPanel.Visible = VersionAccess.Advertise;
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
                lblEconomyName.Text = clsEconomyUnit.EconomyName;
                var cn = new SqlConnection(Settings.AppSettings.DefaultConnectionString);
                lblDbName.Text = cn?.Database ?? "";
                lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                lblSerial.Text = clsRegistery.GetRegistery("U1001ML");
                var exDate = clsRegistery.GetRegistery("U1001MD").ParseToDate();
                lblExDate.Text = Calendar.MiladiToShamsi(exDate);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task BackUpAsync(string path, bool isAuto, EnBackUpType type)
        {
            try
            {
                if (!isAuto)
                {
                    if (string.IsNullOrEmpty(clsBackUp.BackUpOpen) || !clsBackUp.BackUpOpen.ParseToBoolean()) return;
                    path = Path.Combine(path, "AradBackUp");
                }

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                var file = Path.GetFileName(Assembly.GetEntryAssembly()?.Location)
                    ?.Replace(".exe", "__");
                var d = Calendar.MiladiToShamsi(DateTime.Now).Replace("/", "_");
                d += "__" + DateTime.Now.Hour + " - " + DateTime.Now.Minute;
                file += d;
                file = file.Replace(" ", "");
                var newPath = Path.Combine(path, file + ".NPZ2");
                await DataBaseUtilities.DataBase.BackUpStartAsync(this, AppSettings.DefaultConnectionString,
                    ENSource.Building, type,
                    newPath);
                if (isAuto)
                {
                    if (!string.IsNullOrEmpty(clsBackUp.BackUpSms) && clsBackUp.BackUpSms.ParseToBoolean() &&
                        VersionAccess.Sms)
                    {
                        if (string.IsNullOrEmpty(Settings.Classes.Payamak.DefaultPanelGuid))
                            return;
                        var text = $"مدیریت محترم مجموعه {clsEconomyUnit.EconomyName ?? ""} \r\n" +
                                   $"{clsEconomyUnit.ManagerName ?? ""} عزیز \r\n" +
                                   $"در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} \r\n" +
                                   $"و در ساعت {DateTime.Now.ToShortTimeString()} \r\n" +
                                   $"پشتیبان گیری خودکار از داده ها انجام شد \r\n" +
                                   $"باتشکر \r\n" +
                                   $"گروه مهندسی آراد";

                        var panel = SmsPanelsBussines.Get(Guid.Parse(Settings.Classes.Payamak.DefaultPanelGuid));
                        if (panel == null)
                            return;

                        var sApi = new Sms.Api(panel.API.Trim());


                        var result = sApi.Send(panel.Sender, clsEconomyUnit.ManagerMobile ?? "", text);

                        var smsLog = new SmsLogBussines()
                        {
                            Guid = Guid.NewGuid(),
                            UserGuid = clsUser.CurrentUser?.Guid ?? Guid.Empty,
                            Cost = result.Cost,
                            Message = result.Message,
                            MessageId = result.Messageid,
                            Reciver = result.Receptor,
                            Sender = result.Sender,
                            StatusText = result.StatusText
                        };

                        await smsLog.SaveAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task AutoBackUpAsync()
        {
            try
            {
                await Task.Delay(2000);
                if (string.IsNullOrEmpty(clsBackUp.IsAutoBackUp) || !clsBackUp.IsAutoBackUp.ParseToBoolean() ||
                    clsBackUp.BackUpDuration.ParseToInt() <= 0) return;
                var duration = clsBackUp.BackUpDuration.ParseToInt();
                while (true)
                {
                    var list = await BackUpLogBussines.GetAllAsync();
                    var lastAutoBackUp = list.Where(q => q.Type == EnBackUpType.Auto).OrderBy(q => q.InsertedDate)
                        ?.FirstOrDefault();
                    var path = clsBackUp.BackUpPath;
                    if (lastAutoBackUp == null)
                    {
                        await BackUpAsync(path, true, EnBackUpType.Auto);
                        await Task.Delay(60000);
                        continue;
                    }
                    var du = (DateTime.Now - lastAutoBackUp.InsertedDate).Minutes;
                    if (du < duration)
                    {
                        await Task.Delay(60000);
                        continue;
                    }
                    await BackUpAsync(path, true, EnBackUpType.Auto);
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task RefreshLables()
        {
            try
            {
                var allBuilding = await BuildingBussines.DbCount(Guid.Empty, 0);
                var myBuilding = await BuildingBussines.DbCount(clsUser.CurrentUser.Guid, 0);
                var rahn = await BuildingBussines.DbCount(Guid.Empty, 1);
                var foroush = await BuildingBussines.DbCount(Guid.Empty, 2);
                var allReq = await BuildingRequestBussines.DbCount(Guid.Empty);
                var myReq = await BuildingRequestBussines.DbCount(clsUser.CurrentUser.Guid);
                var myCon = await ContractBussines.DbCount(clsUser.CurrentUser.Guid);
                var receptionCheck = await ReceptionBussines.DbCheckCount(Calendar.MiladiToShamsi(DateTime.Now));
                var pardakhtCheck = await PardakhtBussines.DbCheckCount(Calendar.MiladiToShamsi(DateTime.Now));
                var disCharge = await ContractBussines.DischargeDbCount();

                BirthdayList = await PeoplesBussines.GetAllBirthDayAsync(Calendar.MiladiToShamsi(DateTime.Now));

                var minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                allNote = await NoteBussines.GetAllAsync();
                allNote = allNote.Where(q =>
                        q.DateSarresid != null && q.DateSarresid >= minDate &&
                        q.DateSarresid <= maxDate)
                    .ToList();

                Invoke(new MethodInvoker(() =>
                {
                    lblAllBiulding.Text = allBuilding.ToString();
                    lblMyBuilding.Text = myBuilding.ToString();
                    lblAllRahn.Text = rahn.ToString();
                    lblAllForoush.Text = foroush.ToString();
                    lblAllRequest.Text = allReq.ToString();
                    lblMyRequest.Text = myReq.ToString();
                    lblMyContract.Text = myCon.ToString();
                    lblBirthday.Text = BirthdayList.Count.ToString();
                    lblNotes.Text = allNote.Count.ToString();
                    lblReceptionCheck.Text = receptionCheck.ToString();
                    lblPardakhtCheck.Text = pardakhtCheck.ToString();
                    lblSarresidEjare.Text = disCharge.ToString();
                    btnBirthday.Enabled = BirthdayList.Count != 0;
                    btnReminderNotes.Enabled = allNote.Count != 0;
                    btnReceptionCheck.Enabled = receptionCheck != 0;
                    btnPardakhtCheck.Enabled = pardakhtCheck != 0;
                    btnDischarge.Enabled = disCharge != 0;
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmMain()
        {
            InitializeComponent();
            ribbonControl1.SelectedRibbonTabItem = ribbonTabItem1;
            ExPanel.Expanded = false;
        }

        private async void frmMain_Load(object sender, System.EventArgs e)
        {
            try
            {
                lblSecond.Visible = true;
                SetClock();
                SetCalendar();
                SetButtomLables();
                var naqz = await NaqzBussines.SetNaqzAsync();
                var frm = new frmNaqz(naqz);
                frm.ShowDialog(this);
                SetAccess();
                _ = Task.Run(() => BackUpAsync(@"C:\", false, EnBackUpType.Auto));
                _ = Task.Run(AutoBackUpAsync);
                _ = Task.Run(RefreshLables);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void timerSecond_Tick(object sender, EventArgs e)
        {
            SetClock();
            if (lblSecond.Visible)
                lblSecond.Visible = false;
            else if (!lblSecond.Visible)
                lblSecond.Visible = true;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserLog.Save(EnLogAction.Logout, EnLogPart.Logout);
        }
        private void btnPeoples_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCity_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowCities();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnRegion_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowRegions();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingOptions_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildingOption();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingAccountType_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildingAccountType();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnFloorCover_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowFloorCover();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnKitchenService_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowKitchenService();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDocType_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowDocumentType();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnRental_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowRentalAuthority();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingView_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildingView();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingCondition_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildingCondition();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingType_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildingType();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildings(false, false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingAdvanceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmFilterForm();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowRequest();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnContract_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowContract();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowUsers(false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnAccessLevel_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmAccessLevel();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnHazine_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowHazine();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnAccountPerfomence_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowAccounts();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnReception_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptionFilter(EnSanadType.Auto);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnPardakht_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPayeMentFilter(EnSanadType.Auto);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSanad_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSanad();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSettings();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnPhoneBook_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPhoneBook();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnNote_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowNotes();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSmsPanel_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPanels();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSendSms_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSendSms();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnRobotPanel_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmRobotPanel();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBackUpLog();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBackUpLog();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnBazsazi_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await clsErtegha.StartErteghaAsync(AppSettings.DefaultConnectionString, this);
                if (!res.HasError)
                {
                    MessageBox.Show(this, "بازسازی اطلاعات با موفقیت انجام شد", "پیغام سیستم", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show(this, "خطا در بازسازی اطلاعات", "پیغام سیستم", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnErtegha_Click(object sender, EventArgs e)
        {

        }
        private void btnAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmManagementPass();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    new frmAdvance().ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBuildingFast_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingMainFast();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ExPanel_ExpandedChanging(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e) =>
            ExPanel.Width = Width;
        private void btnBirthday_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBirthDay(BirthdayList);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnReminderNotes_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReminder(allNote);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnReceptionCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmReceptopnCheckToday();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnPardakhtCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPardakhtCheckToday();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDischarge_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmDischargeList();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ExPanel_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        => ExPanel.Width = Width;
        private void btnBuildingArchive_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildings(false, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnTarazName_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmFilterSood_Zian();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnMatchesBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmStartBuildingMatches();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnKolMoein_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmKolMoein();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnTafsil_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowTafsils();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSandouq_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowSandouq();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnBanks_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBanks();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDasteCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowDasteCheck();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
