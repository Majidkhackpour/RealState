using System;
using System.Collections.Generic;
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
        public List<Guid> Guids { get; set; }
        private List<RegionsBussines> list;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                while (!IsHandleCreated) await Task.Delay(100);
                var cityGuid = Guid.Parse(clsEconomyUnit.EconomyCity);
                _token?.Cancel();
                _token = new CancellationTokenSource();
                list = await RegionsBussines.GetAllAsync(search, cityGuid, _token.Token);
                Invoke(new MethodInvoker(() => RegionBindingSource.DataSource =
                    list.Where(q => q.Status).OrderBy(q => q.Name).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSelectRegion()
        {
            InitializeComponent();
            ucHeader.Text = "انتخاب منطقه";
        }

        private async void frmSelectRegion_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Guids == null) Guids = new List<Guid>();
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    if ((bool)DGrid[dgIsChecked.Index, i].Value)
                        Guids.Add((Guid)DGrid[dgGuid.Index, i].Value);
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
