using System;
using System.Collections.Generic;
using System.Linq;
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
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                while (!IsHandleCreated) await Task.Delay(100);
                var cityGuid = Guid.Parse(clsEconomyUnit.EconomyCity);
                list = await RegionsBussines.GetAllAsync(search, cityGuid);
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
