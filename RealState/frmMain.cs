using System;
using System.Reflection;
using System.Windows.Forms;
using Advertise.Forms.Simcard;
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
using Payamak.Panel;
using Payamak.PhoneBook;
using Peoples;
using Services;
using Settings.Classes;
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
                lblEconomyName.Text = clsEconomyUnit.EconomyName;
                lblCurrentUser.Text = clsUser.CurrentUser?.Name ?? "";
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
            var tt = new ToolTip();
            tt.SetToolTip(picExit, "خروج");
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
        private void trvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var node = trvGroup.SelectedNode;
                Form frm = null;
                switch (node.Name)
                {
                    case "nCity":
                        frm = new frmShowCities();
                        break;
                    case "nRegion":
                        frm = new frmShowRegions();
                        break;
                    case "nUsers":
                        frm = new frmShowUsers();
                        break;
                    case "nPeoples":
                        frm = new frmShowPeoples();
                        break;
                    case "nBuildingOption":
                        frm = new frmShowBuildingOption();
                        break;
                    case "nFloorCover":
                        frm = new frmShowFloorCover();
                        break;
                    case "nBuildingAccountType":
                        frm = new frmShowBuildingAccountType();
                        break;
                    case "nKitchenService":
                        frm = new frmShowKitchenService();
                        break;
                    case "nDocumentType":
                        frm = new frmShowDocumentType();
                        break;
                    case "nRentalAuthority":
                        frm = new frmShowRentalAuthority();
                        break;
                    case "nBuildingView":
                        frm = new frmShowBuildingView();
                        break;
                    case "nBuildingCondition":
                        frm = new frmShowBuildingCondition();
                        break;
                    case "nBuildingType":
                        frm = new frmShowBuildingType();
                        break;
                    case "nPhoneBook":
                        frm = new frmShowPhoneBook();
                        break;
                    case "nPanels":
                        frm = new frmShowPanels();
                        break;
                    case "nSimcard":
                        frm = new frmShowSimcard();
                        break;
                }

                frm?.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
