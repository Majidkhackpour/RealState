using System.Windows.Forms;
using EntityCache.ViewModels;

namespace RealState.UserControls
{
    public partial class ucDischargeList : UserControl
    {
        private BuildingDischargeViewModel _model;
        public BuildingDischargeViewModel Model
        {
            get => _model;
            set
            {
                _model = value;
                if (_model == null) return;
                lblCode.Text = $@"کدقرارداد: {_model.Code}";
                lblDate.Text = $@"تاریخ تخلیه: {_model.ToDateSh}";
                lblOwner.Text = $@"مالک: {_model.FSideName}";
                lblMostajer.Text = $@"مستاجر:{_model.SSideName}";
            }
        }
        public ucDischargeList() => InitializeComponent();
    }
}
