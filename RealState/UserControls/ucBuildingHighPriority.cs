using System;
using System.Windows.Forms;
using Building.Building;
using EntityCache.Bussines;
using Services;

namespace RealState.UserControls
{
    public partial class ucBuildingHighPriority : UserControl
    {
        private BuildingBussines _bu;
        public BuildingBussines Building
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
        private void mnuEditMode_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingMain(_bu.Guid, false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuViewMode_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingDetail(_bu,false);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
