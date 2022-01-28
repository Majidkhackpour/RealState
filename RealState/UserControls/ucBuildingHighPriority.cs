using System;
using System.Windows.Forms;
using Building.Buildings;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using Services;

namespace RealState.UserControls
{
    public partial class ucBuildingHighPriority : UserControl
    {
        private BuildingReportBussines _bu;
        public BuildingReportBussines Building
        {
            get => _bu;
            set
            {
                _bu = value;
                lblCode.Text = $@"کد: {_bu.Code}";
                lblOwner.Text = $@"مالک: {_bu.OwnerName}";
                lblCreateDate.Text = $@"تاریخ تبت: {_bu.DateSh}";
                lblRegion.Text = $@"محدوده: {_bu.RegionName}";
                lblMasahat.Text = $@"مساحت: {_bu.Masahat}";
                lblType.Text = $@"نوع: {_bu.BuildingTypeName}";
            }
        }
        public ucBuildingHighPriority() => InitializeComponent();
        private void lblCode_Click(object sender, System.EventArgs e)
        {
            try
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuEditMode_Click(object sender, EventArgs e)
        {
            try
            {
                var bu = await BuildingBussines.GetAsync(_bu.Guid);
                var frm = new frmBuilding(bu);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuViewMode_Click(object sender, EventArgs e)
        {
            try
            {
                var bu = await BuildingBussines.GetAsync(_bu.Guid);
                var frm = new frmBuildingDetail(bu,false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
