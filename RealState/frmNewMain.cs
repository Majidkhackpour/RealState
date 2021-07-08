using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
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
using Building.Building;
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
using MetroFramework.Forms;
using Payamak;
using Payamak.Panel;
using Payamak.PhoneBook;
using Peoples;
using RealState.Advance;
using RealState.BackUpLog;
using RealState.CalendarForms;
using RealState.Note;
using Services;
using Settings;
using Settings.Classes;
using User;
using User.Advisor;

namespace RealState
{
    public partial class frmNewMain : MetroForm
    {
        private ConcurrentDictionary<string, EnForms> _dic = new ConcurrentDictionary<string, EnForms>();

        private void FillDictionary()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnForms)).Cast<EnForms>();
                foreach (var item in values)
                    _dic.TryAdd(item.GetDisplay(), item);
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
                    case EnForms.Peoples: frm = new frmShowPeoples(true); break;
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
                    case EnForms.Building: frm = new frmShowBuildings(true, false); break;
                    case EnForms.BuildingFast: frm = new frmBuildingMainFast(); break;
                    case EnForms.AdvancedSearch: frm = new frmFilterForm(); break;
                    case EnForms.BuildingArchive: frm = new frmShowBuildings(true, true); break;
                    case EnForms.BuildingMatch: frm = new frmStartBuildingMatches(); break;
                    case EnForms.Contract: frm = new frmShowContract(); break;
                    case EnForms.Request: frm = new frmShowRequest(); break;
                    case EnForms.Users: frm = new frmShowUsers(true); break;
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
                    case EnForms.Advance: frm = new frmAdvance(); break;
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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmNewMain()
        {
            InitializeComponent();
            grpBuilding.Height = grpAccounting.Height = grpBaseInfo.Height = 48;
            grpUsers.Height = grpOptions.Height = 48;
            FillDictionary();
        }

        private void lblBaseInfo_Click(object sender, System.EventArgs e) => grpBaseInfo.Height = grpBaseInfo.Height == 48 ? 481 : 48;
        private void lblBuildingMenu_Click(object sender, EventArgs e) => grpBuilding.Height = grpBuilding.Height == 48 ? 304 : 48;
        private void lblUsers_Click(object sender, EventArgs e) => grpUsers.Height = grpUsers.Height == 48 ? 156 : 48;
        private void lblAccounting_Click(object sender, EventArgs e) => grpAccounting.Height = grpAccounting.Height == 48 ? 481 : 48;
        private void lblOptions_Click(object sender, EventArgs e) => grpOptions.Height = grpOptions.Height == 48 ? 481 : 48;
        private void frmNewMain_Load(object sender, EventArgs e)
        {
            try
            {
                var myCollection = new AutoCompleteStringCollection();
                var list = _dic.Keys;
                foreach (var item in list.ToList())
                    myCollection.Add(item);
                txtSearch.AutoCompleteCustomSource = myCollection;

                SetButtomLables();
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
                frm?.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblPeoples_Click(object sender, EventArgs e) => SelectForm(EnForms.Peoples)?.ShowDialog();
        private void lblCities_Click(object sender, EventArgs e) => SelectForm(EnForms.Cities)?.ShowDialog();
        private void lblRegions_Click(object sender, EventArgs e) => SelectForm(EnForms.Regions)?.ShowDialog();
        private void lblBuildingOptions_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingOptions)?.ShowDialog();
        private void lblBuildingAccountType_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingAccountType)?.ShowDialog();
        private void lblFloorCover_Click(object sender, EventArgs e) => SelectForm(EnForms.FloorCover)?.ShowDialog();
        private void lblKitchenService_Click(object sender, EventArgs e) => SelectForm(EnForms.KitchenService)?.ShowDialog();
        private void lblDocumentType_Click(object sender, EventArgs e) => SelectForm(EnForms.DocumentType)?.ShowDialog();
        private void lblRental_Click(object sender, EventArgs e) => SelectForm(EnForms.RentalAouthority)?.ShowDialog();
        private void lblBuildingView_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingView)?.ShowDialog();
        private void lblBuildingCondition_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingCondition)?.ShowDialog();
        private void lblBuildingType_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingType)?.ShowDialog();
        private void lblBuilding_Click(object sender, EventArgs e) => SelectForm(EnForms.Building)?.ShowDialog();
        private void lblBuildingFast_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingFast)?.ShowDialog();
        private void lblBuildingSearch_Click(object sender, EventArgs e) => SelectForm(EnForms.AdvancedSearch)?.ShowDialog();
        private void lblBuildingArchive_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingArchive)?.ShowDialog();
        private void lblBuildingMatches_Click(object sender, EventArgs e) => SelectForm(EnForms.BuildingMatch)?.ShowDialog();
        private void lblContract_Click(object sender, EventArgs e) => SelectForm(EnForms.Contract)?.ShowDialog();
        private void lblRequest_Click(object sender, EventArgs e) => SelectForm(EnForms.Request)?.ShowDialog();
        private void lblHazine_Click(object sender, EventArgs e) => SelectForm(EnForms.Hazine)?.ShowDialog();
        private void lblReception_Click(object sender, EventArgs e) => SelectForm(EnForms.Daryaft)?.ShowDialog();
        private void lblPardakht_Click(object sender, EventArgs e) => SelectForm(EnForms.Pardakht)?.ShowDialog();
        private void lblSanad_Click(object sender, EventArgs e) => SelectForm(EnForms.Sanad)?.ShowDialog();
        private void lblAccountingReport_Click(object sender, EventArgs e) => SelectForm(EnForms.AccountingReport)?.ShowDialog();
        private void lblKolMoein_Click(object sender, EventArgs e) => SelectForm(EnForms.KolMoein)?.ShowDialog();
        private void lblTafsil_Click(object sender, EventArgs e) => SelectForm(EnForms.Tafsil)?.ShowDialog();
        private void lblSandouq_Click(object sender, EventArgs e) => SelectForm(EnForms.Sandouq)?.ShowDialog();
        private void lblBank_Click(object sender, EventArgs e) => SelectForm(EnForms.Bank)?.ShowDialog();
        private void lblCheckBook_Click(object sender, EventArgs e) => SelectForm(EnForms.CheckBook)?.ShowDialog();
        private void lblReceptionCheck_Click(object sender, EventArgs e) => SelectForm(EnForms.ReceptionCheck)?.ShowDialog();
        private void lblPardakhtCheck_Click(object sender, EventArgs e) => SelectForm(EnForms.PardakhtCheck)?.ShowDialog();
        private void lblSetting_Click(object sender, EventArgs e) => SelectForm(EnForms.Setting)?.ShowDialog();
        private void lblPhoneBook_Click(object sender, EventArgs e) => SelectForm(EnForms.Phonebook)?.ShowDialog();
        private void lblNote_Click(object sender, EventArgs e) => SelectForm(EnForms.Note)?.ShowDialog();
        private void lblSmsPanel_Click(object sender, EventArgs e) => SelectForm(EnForms.SmsPanel)?.ShowDialog();
        private void lblSendSms_Click(object sender, EventArgs e) => SelectForm(EnForms.SendSms)?.ShowDialog();
        private void lblAdvertise_Click(object sender, EventArgs e) => SelectForm(EnForms.Advertise)?.ShowDialog();
        private void lblBackUp_Click(object sender, EventArgs e) => SelectForm(EnForms.BackUp)?.ShowDialog();
        private void lblRestore_Click(object sender, EventArgs e) => SelectForm(EnForms.Restore)?.ShowDialog();
        private void lblBazsazi_Click(object sender, EventArgs e) { }
        private void lblAdvance_Click(object sender, EventArgs e) => SelectForm(EnForms.Advance)?.ShowDialog();
        private void lblTaqvim_Click(object sender, EventArgs e) => SelectForm(EnForms.Taqvim)?.ShowDialog();
        private void lblUserManage_Click(object sender, EventArgs e) => SelectForm(EnForms.Users)?.ShowDialog();
        private void lblAdvisor_Click(object sender, EventArgs e) => SelectForm(EnForms.Advisor)?.ShowDialog();
        private void lblUserAccess_Click(object sender, EventArgs e) => SelectForm(EnForms.UserAccess)?.ShowDialog();
    }
}
