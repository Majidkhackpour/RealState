using Building.Buildings;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using Services.FilterObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Peoples;

namespace Building.BuildingReview
{
    public partial class frmReviewMain : MetroForm
    {
        private BuildingReviewBussines cls;
        private async Task SetDataAsync()
        {
            try
            {
                await LoadUserAsync();

                var bu = await BuildingBussines.GetAsync(cls.BuildingGuid);
                var cus = await PeoplesBussines.GetAsync(cls.CustometGuid, null);

                txtBuildingCode.Text = bu?.Code;
                txtCustomerName.Text = cus?.Name;
                ucDate.DateM = cls.Date;
                cmbUser.SelectedValue = cls.UserGuid;
                txtReport.Text = cls.Report;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadUserAsync()
        {
            try
            {
                var list = await UserBussines.GetAllAsync();
                UserBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmReviewMain(BuildingReviewBussines obj, bool isShowMode = false)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (!cls.IsModified)
                    ucHeader.Text = "افزودن گزارش بازدید جدید";
                else
                    ucHeader.Text = !isShowMode ? "ویرایش گزارش بازدید" : "مشاهده گزارش بازدید";
                ucHeader.IsModified = cls.IsModified;
                grp.Enabled = !isShowMode;
                ucAccept.Enabled = !isShowMode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmReviewMain_Load(object sender, EventArgs e) => await SetDataAsync();
        private void frmReviewMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!ucAccept.Focused && !ucCancel.Focused && !txtReport.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        ucAccept.PerformClick();
                        break;
                    case Keys.Escape:
                        ucCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async Task ucCancel_OnClick(object arg1, EventArgs arg2)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private async Task ucAccept_OnClick(object arg1, EventArgs arg2)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Modified = DateTime.Now;
                cls.ServerStatus = ServerStatus.None;
                cls.Date = ucDate.DateM;
                cls.Report = txtReport.Text;
                cls.UserGuid = (Guid)cmbUser.SelectedValue;
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت گزارش بازدید");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private async void btnSearchBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = new BuildingFilter() { Status = true };
                var frm = new frmShowBuildings(true, filter);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var bu = await BuildingBussines.GetAsync(frm.SelectedGuid);
                if (bu == null) return;
                cls.BuildingGuid = bu.Guid;
                txtBuildingCode.Text = bu.Code;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowPeoples(true);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var cus = await PeoplesBussines.GetAsync(frm.SelectedGuid, null);
                if (cus == null) return;
                cls.CustometGuid = cus.Guid;
                txtCustomerName.Text = cus.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
