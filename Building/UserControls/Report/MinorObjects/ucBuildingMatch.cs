using System;
using System.Windows.Forms;
using Building.BuildingMatchesItem;
using Building.Buildings;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Peoples;
using Services;

namespace Building.UserControls.Report.MinorObjects
{
    public partial class ucBuildingMatch : UserControl
    {
        private BuildingRequestViewModel _model;
        public BuildingRequestViewModel Model
        {
            get => _model;
            set
            {
                _model = value;
                if (_model == null) return;
                lblCode.Text = $@"کد ملک: {_model.BuildingCode}";
                lblOwner.Text = $@"مالک: {_model.OwnerName}";
                lblCount.Text = _model.RequestCount.ToString();
            }
        }
        public ucBuildingMatch() => InitializeComponent();
        private void lblCount_Click(object sender, System.EventArgs e)
        {
            try
            {
                var reqList = Model.RequestList;
                if (reqList == null || reqList.Count <= 0) return;
                new frmShowMatchesRequester(reqList).ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblCode_Click(object sender, EventArgs e)
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
                var bu = await BuildingBussines.GetAsync(_model.BuildingGuid);
                var frm = new frmBuilding(bu, false);
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
                var bu = await BuildingBussines.GetAsync(_model.BuildingGuid);
                var frm = new frmBuilding(bu, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void lblOwner_Click(object sender, EventArgs e)
        {
            try
            {
                var pe = await PeoplesBussines.GetAsync(_model.OwnerGuid, null);
                if (pe == null) return;
                var frm = new frmPeopleMain(pe, true);
                frm.ShowDialog(FindForm());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
