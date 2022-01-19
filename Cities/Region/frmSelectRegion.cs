using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using Settings.Classes;

namespace Cities.Region
{
    public partial class frmSelectRegion : MetroForm
    {
        private List<Guid> _lst = new List<Guid>();

        public List<Guid> Guids => _lst;
        public async Task SetGuidAsync(List<Guid>value)
        {
            try
            {
                _lst = value;
                await SetGridAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private List<RegionsBussines> list;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                while (!IsHandleCreated) await Task.Delay(100);
                var cityGuid = SettingsBussines.Setting.CompanyInfo.EconomyCity;
                _token?.Cancel();
                _token = new CancellationTokenSource();
                list = await RegionsBussines.GetAllAsync(search, cityGuid, _token.Token);
                Invoke(new MethodInvoker(() => RegionBindingSource.DataSource =
                    list.Where(q => q.Status).OrderBy(q => q.Name).ToSortableBindingList()));

                await SetGridAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SetGridAsync()
        {
            try
            {
                var _list = await WorkingRangeBussines.GetAllAsync();
                if (_list != null && _list.Count > 0) 
                    _lst.AddRange(_list.Select(q => q.RegionGuid));
                if (Guids.Count <= 0) return;
                for (var i = 0; i < DGrid.RowCount; i++)
                    foreach (var item in Guids)
                        if (item == (Guid)DGrid[dgGuid.Index, i].Value)
                        {
                            DGrid[dgIsChecked.Index, i].Value = true;
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSelectRegion() => InitializeComponent();

        private async void frmSelectRegion_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lst == null) _lst = new List<Guid>();
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    if ((bool)DGrid[dgIsChecked.Index, i].Value)
                        _lst.Add((Guid)DGrid[dgGuid.Index, i].Value);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmSelectRegion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
