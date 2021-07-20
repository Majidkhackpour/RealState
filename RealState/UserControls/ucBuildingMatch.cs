using System;
using System.Windows.Forms;
using Building.BuildingMatchesItem;
using EntityCache.ViewModels;
using Services;

namespace RealState.UserControls
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
                lblCode.Text = $@"کد: {_model.BuildingCode}";
                lblSell.Text = $@"فروش: {_model.SellPrice:N0}";
                lblRahn.Text = $@"رهن: {_model.RahnPrice:N0}";
                lblEjare.Text = $@"اجاره: {_model.EjarePrice:N0}";
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
    }
}
