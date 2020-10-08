using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
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
using RealState.Note;
using Services;
using Settings;
using Settings.Classes;
using TMS.Class;
using User;

namespace RealState
{
    public partial class frmMain : MetroForm
    {
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
        private void SetTaghvim()
        {
            try
            {
                var mounth = Calendar.GetMonthOfDateSh(Calendar.MiladiToShamsi(DateTime.Now));

                var path = Path.Combine(Application.StartupPath, "Taghvim");
                if (!Directory.Exists(path)) return;

                var taghvimPath = Path.Combine(path, mounth + ".png");
                if (!File.Exists(taghvimPath)) return;

                picTaghvim.Load(taghvimPath);
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
            lblSecond.Visible = true;
            SetClock();
            SetCalendar();
            SetButtomLables();
            SetTaghvim();
            var naqz = await NaqzBussines.SetNaqzAsync();
            new frmNaqz(naqz).ShowDialog();

            SetAccess();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                var res = await clsErtegha.StartErteghaAsync();
                if (!res.HasError)
                {
                    MessageBox.Show("بازسازی اطلاعات با موفقیت انجام شد", "پیغام سیستم", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("خطا در بازسازی اطلاعات", "پیغام سیستم", MessageBoxButtons.OK,
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
