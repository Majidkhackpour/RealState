using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.UserControls.Sell;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Buildings
{
    public partial class frmBuilding : MetroForm
    {
        private EnBuildingParent parent;
        private BuildingBussines cls;

        private async Task SetDataAsync()
        {
            try
            {
                Width = 800;
                Height = Screen.FromControl(this).Bounds.Height;

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

                UcHitting_Colling.Barq = cls.Barq;
                UcHitting_Colling.Water = cls.Water;
                UcHitting_Colling.Gas = cls.Gas;
                UcHitting_Colling.Tell = cls.Tell;
                UcHitting_Colling.Hitting = cls.Hiting;
                UcHitting_Colling.Colling = cls.Colling;

                UcOptions.OptionList = cls.OptionList;

                txtShortDesc.Text = cls.ShortDesc;

                GetContent();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void GetContent()
        {
            try
            {
                UserControl uc = null;
                switch (parent)
                {
                    case EnBuildingParent.SellAprtment:
                        uc = new UcBuildingSell_Appartment() { Building = cls };
                        break;
                    case EnBuildingParent.SellHome:
                        break;
                    case EnBuildingParent.SellLand:
                        break;
                    case EnBuildingParent.SellVilla:
                        break;
                    case EnBuildingParent.SellStore:
                        break;
                    case EnBuildingParent.SellOffice:
                        break;
                    case EnBuildingParent.SellGarden:
                        break;
                    case EnBuildingParent.SellOldHouse:
                        break;
                    case EnBuildingParent.RentAprtment:
                        break;
                    case EnBuildingParent.RentHome:
                        break;
                    case EnBuildingParent.RentStore:
                        break;
                    case EnBuildingParent.RentOffice:
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        break;
                    case EnBuildingParent.FullRentHome:
                        break;
                    case EnBuildingParent.FullRentStore:
                        break;
                    case EnBuildingParent.FullRentOffice:
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        break;
                    case EnBuildingParent.PreSellHome:
                        break;
                    case EnBuildingParent.PreSellStore:
                        break;
                    case EnBuildingParent.PreSellOffice:
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        break;
                    case EnBuildingParent.MoavezeHome:
                        break;
                    case EnBuildingParent.MoavezeStore:
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        break;
                    case EnBuildingParent.MosharekatHome:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (uc != null)
                    LoadContent(uc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadContent(UserControl uc)
        {
            try
            {
                pnlContent.AutoScroll = true;
                for (var i = pnlContent.Controls.Count - 1; i >= 0; i--)
                    pnlContent.Controls[i].Dispose();

                Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(uc);
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
                        if (!btnFinish.Focused && !btnCancel.Focused && !txtShortDesc.Focused)
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
