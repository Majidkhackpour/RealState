using System;
using EntityCache.Bussines.ReportBussines;
using System.Windows.Forms;
using Building.BuildingReview;
using EntityCache.Bussines;
using Peoples;
using Services;

namespace Building.UserControls.Report.MinorObjects
{
    public partial class ucRegionReport : UserControl
    {
        private BuildingReviewReportBussines _report;
        public BuildingReviewReportBussines Report
        {
            get => _report;
            set
            {
                _report = value;
                lblName.Text = _report.CustomerName;
                lblDate.Text = _report.DateSh;
            }
        }
        public ucRegionReport() => InitializeComponent();
        private async void lblName_Click(object sender, System.EventArgs e)
        {
            try
            {
                var pe = await PeoplesBussines.GetAsync(Report.CustomerGuid, null);
                if (pe == null) return;
                var frm = new frmPeopleMain(pe, true);
                frm.ShowDialog(FindForm());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void lblDate_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = await BuildingReviewBussines.GetAsync(Report.Guid);
                if (obj == null) return;
                var frm = new frmReviewMain(obj, true);
                frm.ShowDialog(FindForm());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
