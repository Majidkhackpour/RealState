using EntityCache.Bussines;
using MetroFramework.Forms;
using Peoples;
using Services;
using Services.FilterObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.BuildingReview
{
    public partial class frmBuildingReviewFilter : MetroForm
    {
        public BuildingReviewFilter Filter { get; private set; }

        private async Task LoadUserAsync()
        {
            try
            {
                var list = await UserBussines.GetAllAsync();
                UserBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
                cmbUser.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmBuildingReviewFilter()
        {
            InitializeComponent();
            ucHeader.Text = "فیلتر گزارشات بازدید";
            ucFilterDate1.Today = true;
            Filter = new BuildingReviewFilter();
        }

        private async void frmBuildingReviewFilter_Load(object sender, EventArgs e) => await LoadUserAsync();
        private async void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var cus = await PeoplesBussines.GetAsync(frm.SelectedGuid, null);
                if (cus == null) return;
                Filter.CustomerGuid = cus.Guid;
                txtCustomerName.Text = cus.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task ucAccept_OnClick(object sender, EventArgs e)
        {
            try
            {
                Filter.Date1 = ucFilterDate1.Date1;
                Filter.Date2 = ucFilterDate1.Date2;
                if (cmbUser.SelectedValue != null)
                    Filter.UserGuid = (Guid)cmbUser.SelectedValue;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucCancel_OnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return Task.CompletedTask;
        }
        private void frmBuildingReviewFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: ucCancel.PerformClick(); break;
                    case Keys.F5: ucAccept.PerformClick(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
