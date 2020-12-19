using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using TMS.Class;
using User;
using Calendar = Services.Calendar;

namespace RealState
{
    public partial class frmMain : MetroForm
    {
        private List<string> sliderImages = new List<string>();
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

                mnuAccountPerformence.Enabled = access?.AccountPerformence.Account_Per_ShowForm ?? false;
                mnuBuilding.Enabled = access?.Building.Building_ShowForm ?? false;
                mnuBuildingAccType.Enabled = access?.BuildingAccountType.Building_Acc_Type_ShowForm ?? false;
                mnuBuildingCondition.Enabled = access?.BuildingCondition.Building_Condition_ShowForm ?? false;
                mnuBuildingOptions.Enabled = access?.BuildingOption.Building_Option_ShowForm ?? false;
                mnuBuildingRequest.Enabled = access?.BuildingRequest.Building_Request_ShowForm ?? false;
                mnuBuildingSearch.Enabled = access?.BuildingSearch.Building_Search_ShowForm ?? false;
                mnuBuildingType.Enabled = access?.BuildingType.Building_Type_ShowForm ?? false;
                mnuBuildingView.Enabled = access?.BuildingView.Building_View_ShowForm ?? false;
                mnuCity.Enabled = access?.Cities.City_ShowForm ?? false;
                mnuContract.Enabled = access?.Contract.Contract_ShowForm ?? false;
                mnuDocumentType.Enabled = access?.DocumentType.Document_Type_ShowForm ?? false;
                mnuFloorCover.Enabled = access?.FloorCover.Floor_Cover_ShowForm ?? false;
                mnuHazine.Enabled = access?.Hazine.Hazine_ShowForm ?? false;
                mnuKitchenService.Enabled = access?.KitchenService.Kitchen_Service_ShowForm ?? false;
                mnuPardakht.Enabled = access?.Pardakht.Pardakht_ShowForm ?? false;
                mnuPeoples.Enabled = access?.Peoples.People_ShowForm ?? false;
                mnuPhoneBook.Enabled = access?.PhoneBook.PhoneBook_ShowForm ?? false;
                mnuReception.Enabled = access?.Reception.Reception_ShowForm ?? false;
                mnuRentalAuthority.Enabled = access?.RentalAuthority.Rental_ShowForm ?? false;
                mnuSanad.Enabled = access?.Sanad.Sanad_Insert ?? false;
                mnuSendSms.Enabled = access?.SendSms.Sms_ShowForm ?? false;
                mnuSimcard.Enabled = access?.Simcard.Simcard_ShowForm ?? false;
                mnuSmsPanels.Enabled = access?.SmsPanel.Panel_ShowForm ?? false;
                mnuUsers.Enabled = access?.User.User_ShowForm ?? false;
                mnuAccessLevel.Enabled = access?.UserAccLevel.User_Acc_ShowForm ?? false;

                mnuAcciuntingInfo.Visible = VersionAccess.Accounting;
                mnuSmsPanels.Visible = VersionAccess.Sms;
                mnuSendSms.Visible = VersionAccess.Sms;
                mnuSimcard.Visible = VersionAccess.Advertise;
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
        private async Task SetNotesAsync()
        {
            try
            {
                var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var allNote = await NoteBussines.GetAllAsync();
                allNote = allNote.Where(q =>
                        q.DateSarresid != null && q.DateSarresid >= now &&
                        q.DateSarresid <= now.AddDays(2))
                    .ToList();

                if (allNote.Count > 0)
                {
                    var frm = new frmReminder(allNote);
                    frm.ShowDialog();
                }
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
        public frmMain()
        {
            InitializeComponent();
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
                await SetNotesAsync();
                _ = Task.Run(() => BackUpAsync(@"C:\", false, EnBackUpType.Auto));
                _ = Task.Run(AutoBackUpAsync);
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

        private void mnuPeoples_Click(object sender, EventArgs e)
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

        private void mnuCity_Click(object sender, EventArgs e)
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

        private void mnuRegion_Click(object sender, EventArgs e)
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

        private void mnuBuildingOptions_Click(object sender, EventArgs e)
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

        private void mnuBuildingAccType_Click(object sender, EventArgs e)
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

        private void mnuFloorCover_Click(object sender, EventArgs e)
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

        private void mnuKitchenService_Click(object sender, EventArgs e)
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

        private void mnuDocumentType_Click(object sender, EventArgs e)
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

        private void mnuRentalAuthority_Click(object sender, EventArgs e)
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

        private void mnuBuildingView_Click(object sender, EventArgs e)
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

        private void mnuBuildingCondition_Click(object sender, EventArgs e)
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

        private void mnuBuildingType_Click(object sender, EventArgs e)
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

        private void mnuBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowBuildings(false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void mnuBuildingSearch_Click(object sender, EventArgs e)
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

        private void mnuBuildingRequest_Click(object sender, EventArgs e)
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

        private void mnuContract_Click(object sender, EventArgs e)
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

        private void mnuUsers_Click(object sender, EventArgs e)
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

        private void mnuHazine_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowHazine(false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void mnuAccountPerformence_Click(object sender, EventArgs e)
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

        private void mnuReception_Click(object sender, EventArgs e)
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

        private void mnuPardakht_Click(object sender, EventArgs e)
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

        private void mnuSanad_Click(object sender, EventArgs e)
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

        private void mnuSimcard_Click(object sender, EventArgs e)
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

        private void mnuSendSms_Click(object sender, EventArgs e)
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

        private void mnuSmsPanels_Click(object sender, EventArgs e)
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

        private void mnuPhoneBook_Click(object sender, EventArgs e)
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

        private async void mnuBazsazi_Click(object sender, EventArgs e)
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

        private void mnuUserPerformence_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmUserLogFilter();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void mnuNote_Click(object sender, EventArgs e)
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

        private void mnuAccessLevel_Click(object sender, EventArgs e)
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

        private void mnuSettings_Click(object sender, EventArgs e)
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

        private async void mnuBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await DataBaseUtilities.DataBase.BackUpStartAsync(this,
                    AppSettings.DefaultConnectionString, ENSource.Building, EnBackUpType.Manual);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                frmNotification.PublicInfo.ShowMessage("پشتیبان گیری با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void mnuRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this,
                        "توجه داشته باشید درصورت بازگردانی اطلاعات، اطلاعات قبلی به کلی از بین خواهد رفت. آیا ادامه میدهید؟",
                        "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var res = await DataBaseUtilities.DataBase.ReStoreStartAsync(this,
                    AppSettings.DefaultConnectionString, ENSource.Building);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                frmNotification.PublicInfo.ShowMessage("بازیابی فایل پشتیبان با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void mnuBackUpLog_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBackUpLog();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


    }
}
