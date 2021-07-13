using System.Windows.Forms;
using EntityCache.ViewModels;

namespace RealState.UserControls
{
    public partial class ucRegionReport : UserControl
    {
        private RegionReportViewModel _report;
        public RegionReportViewModel Report
        {
            get => _report;
            set
            {
                _report = value;
                lblName.Text = _report.Name;
                lblCount.Text = _report.Count.ToString();
            }
        }
        public ucRegionReport() => InitializeComponent();
    }
}
