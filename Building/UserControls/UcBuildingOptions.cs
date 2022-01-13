using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class UcBuildingOptions : UserControl
    {
        private List<BuildingRelatedOptionsBussines> _opList;
        public async Task<List<BuildingRelatedOptionsBussines>> GetOptionListAsync()
        {
            var res = new List<BuildingRelatedOptionsBussines>();
            try
            {
                var list = await BuildingOptionsBussines.GetAllAsync();
                if (list.Count <= 0) return null;
                foreach (var item in list)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.Guid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                        {
                            if (!(bool)DGrid[dgChecked.Index, i].Value) continue;
                            res.Add(new BuildingRelatedOptionsBussines()
                            {
                                Guid = Guid.NewGuid(),
                                BuildingOptionGuid = item.Guid,
                                Modified = DateTime.Now
                            });
                        }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task SetOptionListAsync(List<BuildingRelatedOptionsBussines> value)
        {
            try
            {
                if (BuildingOptionBindingSource.Count <= 0)
                    await FillOptionsAsync();
                if (value == null || value.Count <= 0) return;
                _opList = value;
                foreach (var item in value)
                    for (var i = 0; i < DGrid.RowCount; i++)
                        if (item.BuildingOptionGuid == ((Guid?)DGrid[dgOptionGuid.Index, i].Value ?? Guid.Empty))
                            DGrid[dgChecked.Index, i].Value = true;

                HighLightGrid();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcBuildingOptions() => InitializeComponent();
        private async Task FillOptionsAsync(string search = "")
        {
            try
            {
                var list = await BuildingOptionsBussines.GetAllAsync(search, default);
                BuildingOptionBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await FillOptionsAsync(txtSearch.Text);
        private void LoadFullOption()
        {
            try
            {
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    var val = DGrid[dgIsFullOption.Index, i].Value;
                    if (val != null && (bool)val)
                        DGrid[dgChecked.Index, i].Value = true;
                }

                HighLightGrid();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void chbFullOption_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbFullOption.Checked) LoadFullOption();
                else await SetOptionListAsync(_opList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (e.ColumnIndex != dgChecked.Index) return;
                if (DGrid.CurrentRow == null) return;
                DGrid[dgChecked.Index, DGrid.CurrentRow.Index].Value = !(bool)DGrid[dgChecked.Index, DGrid.CurrentRow.Index].Value;
                HighLightGrid();
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private void HighLightGrid()
        {
            try
            {
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    var val = DGrid[dgChecked.Index, i].Value;
                    if (val != null && (bool)val)
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                    else
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
