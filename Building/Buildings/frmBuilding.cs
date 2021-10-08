using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.UserControls.Other;
using Building.UserControls.Rahn;
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
        private UserControl uc;


        private async Task SetDataAsync()
        {
            try
            {
                Width = 930;
                Height = Screen.FromControl(this).Bounds.Height - 80;

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
                switch (parent)
                {
                    case EnBuildingParent.SellAprtment:
                        uc = new UcBuildingSell_Appartment() { Building = cls };
                        break;
                    case EnBuildingParent.SellHome:
                        uc = new UcBuildingSell_Home() { Building = cls };
                        break;
                    case EnBuildingParent.SellLand:
                        uc = new UcBuildingSell_Land() { Building = cls };
                        break;
                    case EnBuildingParent.SellVilla:
                        uc = new UcBuildingSell_Villa() { Building = cls };
                        break;
                    case EnBuildingParent.SellStore:
                        uc = new UcBuildingSell_Store() { Building = cls };
                        break;
                    case EnBuildingParent.SellOffice:
                        uc = new UcBuildingSell_Office() { Building = cls };
                        break;
                    case EnBuildingParent.SellGarden:
                        uc = new UcBuildingSell_Garden() { Building = cls };
                        break;
                    case EnBuildingParent.SellOldHouse:
                        uc = new UcBuildingSell_OldHouse() { Building = cls };
                        break;
                    case EnBuildingParent.RentAprtment:
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.RentHome:
                        uc = new UcBuildingRahn_Home() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.RentStore:
                        uc = new UcBuildingRahn_Store() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.RentOffice:
                        uc = new UcBuildingRahn_Office() { IsFullRahn = false, Building = cls };
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        uc = new UcBuildingRahn_Appartment() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.FullRentHome:
                        uc = new UcBuildingRahn_Home() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.FullRentStore:
                        uc = new UcBuildingRahn_Store() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.FullRentOffice:
                        uc = new UcBuildingRahn_Office() { IsFullRahn = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellStore:
                        uc = new UcBuildingOther_Store() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.PreSellOffice:
                        uc = new UcBuildingOther_Office() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeStore:
                        uc = new UcBuildingOther_Store() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        uc = new UcBuildingOther_Office() { IsPishForoush = true, Building = cls };
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        uc = new UcBuildingOther_Appartment() { IsPishForoush = false, Building = cls };
                        break;
                    case EnBuildingParent.MosharekatHome:
                        uc = new UcBuildingOther_Home() { IsPishForoush = false, Building = cls };
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (uc != null) LoadContent();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadContent()
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
        private BuildingBussines GetObject()
        {
            BuildingBussines bu = null;
            try
            {
                
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return bu;
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
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res);
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
