using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmBuilding : MetroForm
    {
        private EnBuildingParent parent;
        private BuildingBussines cls;

        private async Task SetDataAsync()
        {
            try
            {
                lblTitle.Text = parent.GetDisplay();

                UcPeople.Guid = cls.OwnerGuid;

                var city = await CitiesBussines.GetAsync(cls.CityGuid);
                if (city != null)
                    UcCity.StateGuid = city.StateGuid;
                UcCity.CityGuid = cls.CityGuid;
                UcCity.RegionGuid = cls.RegionGuid;
                UcCity.Address = cls.Address;

                UcCode.Code = cls.Code;
                UcCode.CreateDate = cls.CreateDate;
                UcCode.Pirority = cls.Priority;
                UcCode.UserGuid = cls.UserGuid;
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
            cls = new BuildingBussines() { Parent = _parent };
        }

        private async void frmBuilding_Load(object sender, EventArgs e) => await SetDataAsync();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmBuilding_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                        //case Keys.F8:
                        //    if (_orGpicBox != null)
                        //    {
                        //        ShowBigSizePic(_orGpicBox);
                        //        _fakepicBox = _orGpicBox;
                        //        _orGpicBox = null;
                        //    }
                        //    else
                        //    {
                        //        ShowNormalSizePic(_fakepicBox);
                        //        _orGpicBox = _fakepicBox;
                        //    }

                        //    break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
