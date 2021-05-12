using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;

namespace Building.BuildingMatchesItem
{
    public partial class frmStartBuildingMatches : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task SetDataAsync()
        {
            try
            {
                var bu = await BuildingBussines.DbCount(Guid.Empty, 0);
                var req = await BuildingRequestBussines.DbCount(Guid.Empty);
                lblBuildingCount.Text = bu.ToString();
                lblRequestCount.Text = req.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmStartBuildingMatches() => InitializeComponent();

        private async void frmStartBuildingMatches_Load(object sender, System.EventArgs e) => await SetDataAsync();
        private void frmStartBuildingMatches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private async void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(await BuildingBussines.GetAllAsync(_token.Token), _token.Token);
                if (list.Count <= 0)
                {
                    MessageBox.Show("فایل مطابقی جهت نمایش وجود ندارد");
                    return;
                }

                new frmShowRequestMatches(list).ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                btnSelect.Enabled = true;
            }
        }
    }
}
