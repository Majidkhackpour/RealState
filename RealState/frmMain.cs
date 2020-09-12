using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Accounting;
using Accounting.Hazine;
using Accounting.Payement;
using Accounting.Reception;
using Advertise.Forms.Simcard;
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

        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, System.EventArgs e)
        {
            UnsetGroupBox();
            lblSecond.Visible = true;
            SetClock();
            SetCalendar();
            SetButtomLables();
            var tt = new ToolTip();
            tt.SetToolTip(picSetting, "تنظیمات برنامه");
            var naqz = await NaqzBussines.SetNaqz();
            new frmNaqz(naqz).ShowDialog();
        }
        private void timerSecond_Tick(object sender, EventArgs e)
        {
            SetClock();
            if (lblSecond.Visible)
                lblSecond.Visible = false;
            else if (!lblSecond.Visible)
                lblSecond.Visible = true;
        }
        private void UnsetGroupBox()
        {
            try
            {
                grpBaseInfo.Visible = false;
                grpUsers.Visible = false;
                grpBuilding.Visible = false;
                grpAccounting.Visible = false;
                grpInformation.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void BaseInfo()
        {
            try
            {
                UnsetGroupBox();
                grpBaseInfo.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Building()
        {
            try
            {
                UnsetGroupBox();
                grpBuilding.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Users()
        {
            try
            {
                UnsetGroupBox();
                grpUsers.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Accounting()
        {
            try
            {
                UnsetGroupBox();
                grpAccounting.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Information()
        {
            try
            {
                UnsetGroupBox();
                grpInformation.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBaseInfo_MouseEnter(object sender, EventArgs e)
        {
            lblBaseInfo.ForeColor = Color.Red;
            BaseInfo();
        }

        private void lblBuildingInfo_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingInfo.ForeColor = Color.Red;
            Building();
        }

        private void lblUsers_MouseEnter(object sender, EventArgs e)
        {
            lblUsers.ForeColor = Color.Red;
            Users();
        }

        private void lblAccountiong_MouseEnter(object sender, EventArgs e)
        {
            lblAccountiong.ForeColor = Color.Red;
            Accounting();
        }

        private void lblInfornation_MouseEnter(object sender, EventArgs e)
        {
            lblInfornation.ForeColor = Color.Red;
            Information();
        }

        private void lblInfornation_MouseLeave(object sender, EventArgs e)
        {
            lblInfornation.ForeColor = Color.Black;
        }

        private void lblAccountiong_MouseLeave(object sender, EventArgs e)
        {
            lblAccountiong.ForeColor = Color.Black;
        }

        private void lblUsers_MouseLeave(object sender, EventArgs e)
        {
            lblUsers.ForeColor = Color.Black;
        }

        private void lblBuildingInfo_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingInfo.ForeColor = Color.Black;
        }

        private void lblBaseInfo_MouseLeave(object sender, EventArgs e)
        {
            lblBaseInfo.ForeColor = Color.Black;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) UnsetGroupBox();
        }

        private void picBaseInfo_MouseEnter(object sender, EventArgs e)
        {
            BaseInfo();
        }

        private void lblPeoples_MouseEnter(object sender, EventArgs e)
        {
            lblPeoples.ForeColor = Color.Red;
        }

        private void lblPeoples_MouseLeave(object sender, EventArgs e)
        {
            lblPeoples.ForeColor = Color.Black;
        }

        private void lblCities_MouseEnter(object sender, EventArgs e)
        {
            lblCities.ForeColor = Color.Red;
        }

        private void lblCities_MouseLeave(object sender, EventArgs e)
        {
            lblCities.ForeColor = Color.Black;
        }

        private void lblRegions_MouseEnter(object sender, EventArgs e)
        {
            lblRegions.ForeColor = Color.Red;
        }

        private void lblRegions_MouseLeave(object sender, EventArgs e)
        {
            lblRegions.ForeColor = Color.Black;
        }

        private void lblBuildingOptions_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingOptions.ForeColor = Color.Red;
        }

        private void lblBuildingOptions_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingOptions.ForeColor = Color.Black;
        }

        private void lblBuildingAccType_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingAccType.ForeColor = Color.Red;
        }

        private void lblBuildingAccType_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingAccType.ForeColor = Color.Black;
        }

        private void lblFloorCover_MouseEnter(object sender, EventArgs e)
        {
            lblFloorCover.ForeColor = Color.Red;
        }

        private void lblFloorCover_MouseLeave(object sender, EventArgs e)
        {
            lblFloorCover.ForeColor = Color.Black;
        }

        private void lblKitchenService_MouseEnter(object sender, EventArgs e)
        {
            lblKitchenService.ForeColor = Color.Red;
        }

        private void lblKitchenService_MouseLeave(object sender, EventArgs e)
        {
            lblKitchenService.ForeColor = Color.Black;
        }

        private void lblDocumentType_MouseEnter(object sender, EventArgs e)
        {
            lblDocumentType.ForeColor = Color.Red;
        }

        private void lblDocumentType_MouseLeave(object sender, EventArgs e)
        {
            lblDocumentType.ForeColor = Color.Black;
        }

        private void lblRental_MouseEnter(object sender, EventArgs e)
        {
            lblRental.ForeColor = Color.Red;
        }

        private void lblRental_MouseLeave(object sender, EventArgs e)
        {
            lblRental.ForeColor = Color.Black;
        }

        private void lblBuildingView_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingView.ForeColor = Color.Red;
        }

        private void lblBuildingView_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingView.ForeColor = Color.Black;
        }

        private void lblBuildingCondition_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingCondition.ForeColor = Color.Red;
        }

        private void lblBuildingCondition_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingCondition.ForeColor = Color.Black;
        }

        private void lblBuildingType_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingType.ForeColor = Color.Red;
        }

        private void lblBuildingType_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingType.ForeColor = Color.Black;
        }

        private void lblPeoples_Click(object sender, EventArgs e)
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

        private void lblCities_Click(object sender, EventArgs e)
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

        private void lblRegions_Click(object sender, EventArgs e)
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

        private void lblBuildingOptions_Click(object sender, EventArgs e)
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

        private void lblBuildingAccType_Click(object sender, EventArgs e)
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

        private void lblFloorCover_Click(object sender, EventArgs e)
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

        private void lblKitchenService_Click(object sender, EventArgs e)
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

        private void lblDocumentType_Click(object sender, EventArgs e)
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

        private void lblRental_Click(object sender, EventArgs e)
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

        private void lblBuildingView_Click(object sender, EventArgs e)
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

        private void lblBuildingCondition_Click(object sender, EventArgs e)
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

        private void lblBuildingType_Click(object sender, EventArgs e)
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

        private void picBuilding_MouseEnter(object sender, EventArgs e)
        {
            Building();
        }

        private void picUsers_MouseEnter(object sender, EventArgs e)
        {
            Users();
        }

        private void picAccounting_MouseEnter(object sender, EventArgs e)
        {
            Accounting();
        }

        private void lblSanad_MouseEnter(object sender, EventArgs e)
        {
            lblSanad.ForeColor = Color.Red;
        }

        private void lblSanad_MouseLeave(object sender, EventArgs e)
        {
            lblSanad.ForeColor = Color.Black;
        }

        private void lblPardakht_MouseEnter(object sender, EventArgs e)
        {
            lblPardakht.ForeColor = Color.Red;
        }

        private void lblPardakht_MouseLeave(object sender, EventArgs e)
        {
            lblPardakht.ForeColor = Color.Black;
        }

        private void lblReception_MouseEnter(object sender, EventArgs e)
        {
            lblReception.ForeColor = Color.Red;
        }

        private void lblReception_MouseLeave(object sender, EventArgs e)
        {
            lblReception.ForeColor = Color.Black;
        }

        private void lblAccountPerformence_MouseEnter(object sender, EventArgs e)
        {
            lblAccountPerformence.ForeColor = Color.Red;
        }

        private void lblAccountPerformence_MouseLeave(object sender, EventArgs e)
        {
            lblAccountPerformence.ForeColor = Color.Black;
        }

        private void lblHazine_MouseEnter(object sender, EventArgs e)
        {
            lblHazine.ForeColor = Color.Red;
        }

        private void lblHazine_MouseLeave(object sender, EventArgs e)
        {
            lblHazine.ForeColor = Color.Black;
        }

        private void lblUserReport_MouseEnter(object sender, EventArgs e)
        {
            lblUserReport.ForeColor = Color.Red;
        }

        private void lblUserReport_MouseLeave(object sender, EventArgs e)
        {
            lblUserReport.ForeColor = Color.Black;
        }

        private void lblAccessLevel_MouseEnter(object sender, EventArgs e)
        {
            lblAccessLevel.ForeColor = Color.Red;
        }

        private void lblAccessLevel_MouseLeave(object sender, EventArgs e)
        {
            lblAccessLevel.ForeColor = Color.Black;
        }

        private void lblUserMng_MouseEnter(object sender, EventArgs e)
        {
            lblUserMng.ForeColor = Color.Red;
        }

        private void lblUserMng_MouseLeave(object sender, EventArgs e)
        {
            lblUserMng.ForeColor = Color.Black;
        }

        private void lblBuildingRequest_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingRequest.ForeColor = Color.Red;
        }

        private void lblBuildingRequest_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingRequest.ForeColor = Color.Black;
        }

        private void lblBuildingSearch_MouseEnter(object sender, EventArgs e)
        {
            lblBuildingSearch.ForeColor = Color.Red;
        }

        private void lblBuildingSearch_MouseLeave(object sender, EventArgs e)
        {
            lblBuildingSearch.ForeColor = Color.Black;
        }

        private void lblBuilding_MouseEnter(object sender, EventArgs e)
        {
            lblBuilding.ForeColor = Color.Red;
        }

        private void lblBuilding_MouseLeave(object sender, EventArgs e)
        {
            lblBuilding.ForeColor = Color.Black;
        }

        private void lblBuilding_Click(object sender, EventArgs e)
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

        private void lblBuildingSearch_Click(object sender, EventArgs e)
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

        private void lblBuildingRequest_Click(object sender, EventArgs e)
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

        private void lblUserMng_Click(object sender, EventArgs e)
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

        private void lblAccessLevel_Click(object sender, EventArgs e)
        {

        }

        private void lblUserReport_Click(object sender, EventArgs e)
        {

        }

        private void lblHazine_Click(object sender, EventArgs e)
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

        private void lblAccountPerformence_Click(object sender, EventArgs e)
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

        private void lblReception_Click(object sender, EventArgs e)
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

        private void lblPardakht_Click(object sender, EventArgs e)
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

        private void lblSanad_Click(object sender, EventArgs e)
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

        private void picInformation_MouseEnter(object sender, EventArgs e)
        {
            Information();
        }

        private void lblBazsazi_MouseEnter(object sender, EventArgs e)
        {
            lblBazsazi.ForeColor = Color.Red;
        }

        private void lblBazsazi_MouseLeave(object sender, EventArgs e)
        {
            lblBazsazi.ForeColor = Color.Black;
        }

        private void lblPhoneBook_MouseEnter(object sender, EventArgs e)
        {
            lblPhoneBook.ForeColor = Color.Red;
        }

        private void lblPhoneBook_MouseLeave(object sender, EventArgs e)
        {
            lblPhoneBook.ForeColor = Color.Black;
        }

        private void lblSmsPanel_MouseEnter(object sender, EventArgs e)
        {
            lblSmsPanel.ForeColor = Color.Red;
        }

        private void lblSmsPanel_MouseLeave(object sender, EventArgs e)
        {
            lblSmsPanel.ForeColor = Color.Black;
        }

        private void lblSendSms_MouseEnter(object sender, EventArgs e)
        {
            lblSendSms.ForeColor = Color.Red;
        }

        private void lblSendSms_MouseLeave(object sender, EventArgs e)
        {
            lblSendSms.ForeColor = Color.Black;
        }

        private void lblSmsReport_MouseEnter(object sender, EventArgs e)
        {
            lblSmsReport.ForeColor = Color.Red;
        }

        private void lblSmsReport_MouseLeave(object sender, EventArgs e)
        {
            lblSmsReport.ForeColor = Color.Black;
        }

        private void lblSimcard_MouseEnter(object sender, EventArgs e)
        {
            lblSimcard.ForeColor = Color.Red;
        }

        private void lblSimcard_MouseLeave(object sender, EventArgs e)
        {
            lblSimcard.ForeColor = Color.Black;
        }

        private void lblAdvertiseReport_MouseEnter(object sender, EventArgs e)
        {
            lblAdvertiseReport.ForeColor = Color.Red;
        }

        private void lblAdvertiseReport_MouseLeave(object sender, EventArgs e)
        {
            lblAdvertiseReport.ForeColor = Color.Black;
        }

        private void lblAdvertiseReport_Click(object sender, EventArgs e)
        {

        }

        private void lblSimcard_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowSimcard();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblSmsReport_Click(object sender, EventArgs e)
        {

        }

        private void lblSendSms_Click(object sender, EventArgs e)
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

        private void lblSmsPanel_Click(object sender, EventArgs e)
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

        private void lblPhoneBook_Click(object sender, EventArgs e)
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

        private async void lblBazsazi_Click(object sender, EventArgs e)
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

        private void lblContract_MouseEnter(object sender, EventArgs e)
        {
            lblContract.ForeColor = Color.Red;
        }

        private void lblContract_MouseLeave(object sender, EventArgs e)
        {
            lblContract.ForeColor = Color.Black;
        }

        private void lblContract_Click(object sender, EventArgs e)
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
    }
}
