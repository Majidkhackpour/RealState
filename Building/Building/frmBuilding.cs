using System;
using System.Threading.Tasks;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmBuilding : MetroForm
    {
        private EnBuildingParent parent;

        private async Task SetDataAsync()
        {
            try
            {
                lblTitle.Text = parent.GetDisplay();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmBuilding(EnBuildingParent _parent)
        {
            InitializeComponent();
            parent = _parent;
        }

        private async void frmBuilding_Load(object sender, EventArgs e) => await SetDataAsync();
    }
}
