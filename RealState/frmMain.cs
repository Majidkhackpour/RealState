using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Building.BuildingAccountType;
using Building.BuildingCondition;
using Building.BuildingOptions;
using Building.BuildingType;
using Building.BuildingView;
using Building.DocumentType;
using Building.FloorCover;
using Building.KitchenService;
using Building.RentalAuthority;
using Cities.City;
using Cities.Region;
using EntityCache.Bussines;
using Ertegha;
using MetroFramework.Forms;
using PacketParser.Services;
using TMS.Class;
using User;

namespace RealState
{
    public partial class frmMain : MetroForm
    {
        private bool _baseInfoSetter = false;
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
                lblEconomyName.Text = SettingsBussines.EconomyName;
                lblCurrentUser.Text = UserBussines.CurrentUser?.Name??"";
                lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
            pnlSubMenuBase.Visible = false;
            pnlSubMenuBase2.Visible = false;
            var tt = new ToolTip();
            tt.SetToolTip(picExit, "خروج");
            tt.SetToolTip(picMore, "ادامه لیست");
            tt.SetToolTip(picReverse, "بازگشت به صفحه قبل");
            SetClock();
            SetCalendar();
            var naqz = await NaqzBussines.SetNaqz();
            lblNaqz.Text = naqz;
            SetButtomLables();
        }

        private void picExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            SetClock();
            if (lblSecond.Visible)
                lblSecond.Visible = false;
            else if (!lblSecond.Visible)
                lblSecond.Visible = true;
        }

        private void picBaseInfo_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picBaseInfo.Image = Properties.Resources.menu_;
                txtSetter.Focus(lblBaseInfo);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBaseInfo_MouseEnter(object sender, EventArgs e)
        {
            picBaseInfo_MouseEnter(null, null);
        }

        private void picBaseInfo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picBaseInfo.Image = Properties.Resources.menu;
                txtSetter.Follow(lblBaseInfo);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBaseInfo_MouseLeave(object sender, EventArgs e)
        {
            picBaseInfo_MouseLeave(null, null);
        }

        private void picUsers_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picUsers.Image = Properties.Resources.notification_user_;
                txtSetter.Focus(lblUsers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picUsers_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picUsers.Image = Properties.Resources.notification_user;
                txtSetter.Follow(lblUsers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblUsers_MouseEnter(object sender, EventArgs e)
        {
            picUsers_MouseEnter(null, null);
        }

        private void lblUsers_MouseLeave(object sender, EventArgs e)
        {
            picUsers_MouseLeave(null, null);
        }

        private void picUsers_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowUsers().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            picUsers_Click(null, null);
        }

        private void picBaseInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_baseInfoSetter)
                {
                    pnlSubMenuBase.Visible = true;
                    _baseInfoSetter = true;
                }
                else
                {
                    pnlSubMenuBase.Visible = false;
                    pnlSubMenuBase2.Visible = false;
                    _baseInfoSetter = false;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBaseInfo_Click(object sender, EventArgs e)
        {
            picBaseInfo_Click(null, null);
        }

        private void picCities_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picCities.Image = Properties.Resources.map_;
                txtSetter.Focus(lblCities);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picCities_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picCities.Image = Properties.Resources.map;
                txtSetter.Follow(lblCities);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblCities_MouseEnter(object sender, EventArgs e)
        {
            picCities_MouseEnter(null, null);
        }

        private void lblCities_MouseLeave(object sender, EventArgs e)
        {
            picCities_MouseLeave(null, null);
        }

        private void picRegion_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picRegion.Image = Properties.Resources.navigation_;
                txtSetter.Focus(lblRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picRegion_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picRegion.Image = Properties.Resources.navigation;
                txtSetter.Follow(lblRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblRegion_MouseEnter(object sender, EventArgs e)
        {
            picRegion_MouseEnter(null, null);
        }

        private void lblRegion_MouseLeave(object sender, EventArgs e)
        {
            picRegion_MouseLeave(null, null);
        }

        private void picCities_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowCities().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblCities_Click(object sender, EventArgs e)
        {
            picCities_Click(null, null);
        }

        private void picRegion_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowRegions().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblRegion_Click(object sender, EventArgs e)
        {
            picRegion_Click(null, null);
        }

        private void picBuildingOptions_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picBuildingOptions.Image = Properties.Resources.house_;
                txtSetter.Focus(lblBuildingOptions);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingOptions_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picBuildingOptions.Image = Properties.Resources.house;
                txtSetter.Follow(lblBuildingOptions);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingOptions_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowBuildingOption().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBuildingOptions_Click(object sender, EventArgs e)
        {
            picBuildingOptions_Click(null, null);
        }

        private void lblBuildingOptions_MouseEnter(object sender, EventArgs e)
        {
            picBuildingOptions_MouseEnter(null, null);
        }

        private void lblBuildingOptions_MouseLeave(object sender, EventArgs e)
        {
            picBuildingOptions_MouseLeave(null, null);
        }

        private void picAccountType_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picAccountType.Image = Properties.Resources.company_;
                txtSetter.Focus(lblAccountType);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picAccountType_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picAccountType.Image = Properties.Resources.company;
                txtSetter.Follow(lblAccountType);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picAccountType_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowBuildingAccountType().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblAccountType_Click(object sender, EventArgs e)
        {
            picAccountType_Click(null, null);
        }

        private void lblAccountType_MouseEnter(object sender, EventArgs e)
        {
            picAccountType_MouseEnter(null, null);
        }

        private void lblAccountType_MouseLeave(object sender, EventArgs e)
        {
            picAccountType_MouseLeave(null, null);
        }

        private void picFloor_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picFloor.Image = Properties.Resources.floor_;
                txtSetter.Focus(lblFloor);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picFloor_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picFloor.Image = Properties.Resources.floor;
                txtSetter.Follow(lblFloor);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picFloor_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowFloorCover().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblFloor_Click(object sender, EventArgs e)
        {
            picFloor_Click(null, null);
        }

        private void lblFloor_MouseEnter(object sender, EventArgs e)
        {
            picFloor_MouseEnter(null, null);
        }

        private void lblFloor_MouseLeave(object sender, EventArgs e)
        {
            picFloor_MouseLeave(null, null);
        }

        private void picKitchen_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picKitchen.Image = Properties.Resources.kitchen_1__;
                txtSetter.Focus(lblKitchen);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picKitchen_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picKitchen.Image = Properties.Resources.kitchen_1_;
                txtSetter.Follow(lblKitchen);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picKitchen_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowKitchenService().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblKitchen_MouseEnter(object sender, EventArgs e)
        {
            picKitchen_MouseEnter(null, null);
        }

        private void lblKitchen_MouseLeave(object sender, EventArgs e)
        {
            picKitchen_MouseLeave(null, null);
        }

        private void lblKitchen_Click(object sender, EventArgs e)
        {
            picKitchen_Click(null, null);
        }

        private void picMore_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picMore.Image = Properties.Resources.down_arrow_;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picMore_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picMore.Image = Properties.Resources.down_arrow;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picReverse_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picReverse.Image = Properties.Resources.upload_;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picReverse_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picReverse.Image = Properties.Resources.upload;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picMore_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSubMenuBase.Visible = false;
                pnlSubMenuBase2.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picReverse_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSubMenuBase.Visible = true;
                pnlSubMenuBase2.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picDocType_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picDocType.Image = Properties.Resources.archived_;
                txtSetter.Focus(lblDocType);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picDocType_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picDocType.Image = Properties.Resources.archived;
                txtSetter.Follow(lblDocType);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picDocType_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowDocumentType().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblDocType_MouseEnter(object sender, EventArgs e)
        {
            picDocType_MouseEnter(null, null);
        }

        private void lblDocType_MouseLeave(object sender, EventArgs e)
        {
            picDocType_MouseLeave(null, null);
        }

        private void lblDocType_Click(object sender, EventArgs e)
        {
            picDocType_Click(null, null);
        }

        private async void mnuRunScript_Click(object sender, EventArgs e)
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

        private void picRental_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picRental.Image = Properties.Resources.tourism_;
                txtSetter.Focus(lblRental);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picRental_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picRental.Image = Properties.Resources.tourism;
                txtSetter.Follow(lblRental);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picRental_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowRentalAuthority().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblRental_MouseEnter(object sender, EventArgs e)
        {
            picRental_MouseEnter(null, null);
        }

        private void lblRental_MouseLeave(object sender, EventArgs e)
        {
            picRental_MouseLeave(null, null);
        }

        private void lblRental_Click(object sender, EventArgs e)
        {
            picRental_Click(null, null);
        }

        private void picBuildingView_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picBuildingView.Image = Properties.Resources.villa_;
                txtSetter.Focus(lblBuildingView);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingView_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picBuildingView.Image = Properties.Resources.villa;
                txtSetter.Follow(lblBuildingView);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingView_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowBuildingView().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBuildingView_Click(object sender, EventArgs e)
        {
            picBuildingView_Click(null, null);
        }

        private void lblBuildingView_MouseEnter(object sender, EventArgs e)
        {
            picBuildingView_MouseEnter(null, null);
        }

        private void lblBuildingView_MouseLeave(object sender, EventArgs e)
        {
            picBuildingView_MouseLeave(null, null);
        }

        private void picBuildingCondition_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picBuildingCondition.Image = Properties.Resources.crane_;
                txtSetter.Focus(lblBuildingCondition);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingCondition_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picBuildingCondition.Image = Properties.Resources.crane;
                txtSetter.Follow(lblBuildingCondition);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingCondition_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowBuildingCondition().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBuildingCondition_MouseEnter(object sender, EventArgs e)
        {
            picBuildingCondition_MouseEnter(null, null);
        }

        private void lblBuildingCondition_MouseLeave(object sender, EventArgs e)
        {
            picBuildingCondition_MouseLeave(null, null);
        }

        private void lblBuildingCondition_Click(object sender, EventArgs e)
        {
            picBuildingCondition_Click(null, null);
        }

        private void picBuildingType_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                picBuildingType.Image = Properties.Resources.lego_;
                txtSetter.Focus(lblBuildingType);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingType_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                picBuildingType.Image = Properties.Resources.lego;
                txtSetter.Follow(lblBuildingType);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void picBuildingType_Click(object sender, EventArgs e)
        {
            try
            {
                new frmShowBuildingType().ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBuildingType_MouseEnter(object sender, EventArgs e)
        {
            picBuildingType_MouseEnter(null, null);
        }

        private void lblBuildingType_MouseLeave(object sender, EventArgs e)
        {
            picBuildingType_MouseLeave(null, null);
        }

        private void lblBuildingType_Click(object sender, EventArgs e)
        {
            picBuildingType_Click(null, null);
        }

        private async void TimerNaqz_Tick(object sender, EventArgs e)
        {
            try
            {
                var nqz = await NaqzBussines.SetNaqz();
                lblNaqz.Text = nqz;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
