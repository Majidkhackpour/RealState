using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Advertise.Forms.MatchRegions
{
    public partial class frmShowMatchRegion : Form
    {
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await SerializedDataBussines.GetDivarRegionAsync();
               
                if (cmbState.SelectedValue != null && (Guid)cmbState.SelectedValue != Guid.Empty)
                    list = list.Where(q => q.CityGuid == (Guid)cmbState.SelectedValue).ToList();
                regBindingSource.DataSource = list.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadCitiesAsync()
        {
            try
            {
                var list = await SerializedDataBussines.GetDivarCityAsync();
                var dc = list?.Where(q =>
                    q.Name.Contains("مشهد") || q.Name.Contains("اصفهان") || q.Name.Contains("تهران") ||
                    q.Name.Contains("کرج") || q.Name.Contains("اهواز") || q.Name.Contains("شیراز") ||
                    q.Name.Contains("قم")).ToList();
                cityBindingSource.DataSource = dc?.ToList();
                if (cityBindingSource.Count > 0)
                {
                    var cityLocal = await CitiesBussines.GetAsync(SettingsBussines.Setting.CompanyInfo.EconomyCity);
                    if (cityLocal != null) cmbState.Text = cityLocal.Name;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmShowMatchRegion()
        {
            InitializeComponent();
        }
        private async void frmShowMatchRegion_Load(object sender, EventArgs e)
        {
            await LoadCitiesAsync();
            await LoadDataAsync();
        }
        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private void frmShowMatchRegion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        btnInsert.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var list = await SerializedDataBussines.GetDivarRegionAsync();
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var reg = list.FirstOrDefault(q => q.Guid == guid);
                if (reg == null) return;
                var frm = new frmMatchRegionMain(reg);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
