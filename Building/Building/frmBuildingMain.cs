using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Peoples;
using Services;
using User;

namespace Building.Building
{
    public partial class frmBuildingMain : MetroForm
    {
        private BuildingBussines cls;
        private PeoplesBussines owner;
        private void SetData()
        {
            try
            {
                LoadUsers();
                LoadOwner();
                lblDateNow.Text = cls?.DateSh;
                txtCode.Text = cls?.Code;
                cmbUser.SelectedValue = cls?.UserGuid;

                if (cls?.Guid == Guid.Empty)
                {
                    NextCode();
                    cmbUser.SelectedValue = clsUser.CurrentUser?.Guid;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void NextCode()
        {
            try
            {
                txtCode.Text = BuildingBussines.NextCode() ?? "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void LoadOwner()
        {
            try
            {
                txttxtOwnerCode.Text = owner?.Code;
                lblOwnerAddress.Text = owner?.Address;
                lblOwnerDateBirth.Text = owner?.DateBirth;
                lblOwnerFatherName.Text = owner?.FatherName;
                lblOwnerNCode.Text = owner?.NationalCode;
                lblOwnerName.Text = owner?.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadUsers()
        {
            try
            {
                var list = UserBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                userBindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmBuildingMain()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = new BuildingBussines();
            superTabControl1.SelectedTab = superTabItem1;
            superTabControl2.SelectedTab = superTabItem8;
        }
        public frmBuildingMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cls = BuildingBussines.Get(guid);
            superTabControl1.SelectedTab = superTabItem1;
            superTabControl2.SelectedTab = superTabItem8;
            //grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void frmBuildingMain_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog() != DialogResult.OK) return;
                owner = PeoplesBussines.Get(frm.SelectedGuid);
                LoadOwner();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnCreateOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples();
                if (frm.ShowDialog() != DialogResult.OK) return;
                owner = PeoplesBussines.Get(frm.SelectedGuid);
                LoadOwner();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
