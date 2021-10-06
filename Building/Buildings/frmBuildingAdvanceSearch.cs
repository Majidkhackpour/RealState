using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;

namespace Building.Buildings
{
    public partial class frmBuildingAdvanceSearch : MetroForm
    {
        public frmBuildingAdvanceSearch(List<BuildingViewModel> list)
        {
            InitializeComponent();
            ucHeader.Text = "نمایش لیست املاک جستجو شده";
            _ = Task.Run(() => SetFilesAsync(list));
        }
        private async Task SetFilesAsync(List<BuildingViewModel> list)
        {
            try
            {
                while (!IsHandleCreated)
                    await Task.Delay(100);

                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => SetFilesAsync(list)));
                    return;
                }
                foreach (var item in list)
                {
                    var control = new UcBuildingSearch.ucBuildingSearch(item);
                    fPnel.Controls.Add(control);
                    await Task.Delay(100);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmBuildingAdvanceSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
