using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Threading.Tasks;
using WindowsSerivces;

namespace Building.Building
{
    public partial class frmShowBuildingDetail : MetroForm
    {
        private BuildingBussines bu;

        private async Task SetDataAsync()
        {
            try
            {
                if (bu == null)
                {
                    this.ShowWarning("ملک موردنظر معتبر نمی باشد");
                    Close();
                    return;
                }

                lblCode.Text = bu.Code;
                lblUserName.Text = bu.UserName;
                lblCreateDate.Text = Calendar.MiladiToShamsi(bu.CreateDate);

                var owner = await PeoplesBussines.GetAsync(bu.OwnerGuid);
                if (owner != null)
                {
                    lblOwnerName.Text = owner.Name;
                    lblOwnerFatherName.Text = owner.FatherName;
                    lblOwnerAddress.Text = owner.Address;
                    lblOwnerNathCode.Text = owner.NationalCode;

                    if (owner?.TellList?.Count >= 1)
                    {
                        var title1 = owner?.TellList[0]?.Title ?? "";
                        var number1 = owner?.TellList[0]?.Tell ?? "";
                        lblOwnerTell1.Text = $@"{title1} {number1}";
                    }
                    if (owner?.TellList?.Count >= 2)
                    {
                        var title2 = owner?.TellList[1]?.Title ?? "";
                        var number2 = owner?.TellList[1]?.Tell ?? "";
                        lblOwnerTell2.Text = $@"{title2} {number2}";
                    }
                    if (owner?.TellList?.Count >= 3)
                    {
                        var title3 = owner?.TellList[2]?.Title ?? "";
                        var number3 = owner?.TellList[2]?.Tell ?? "";
                        lblOwnerTell3.Text = $@"{title3} {number3}";
                    }
                    if (owner?.TellList?.Count >= 4)
                    {
                        var title4 = owner?.TellList[3]?.Title ?? "";
                        var number4 = owner?.TellList[3]?.Tell ?? "";
                        lblOwnerTell4.Text = $@"{title4} {number4}";
                    }
                }

                lblRahn1.Text = bu.RahnPrice1.ToString("N0");
                lblEjare1.Text = bu.EjarePrice1.ToString("N0");
                lblRahn2.Text = bu.RahnPrice2.ToString("N0");
                lblEjare2.Text = bu.EjarePrice2.ToString("N0");
                lblIsOwnerHere.Text = (bu.IsOwnerHere ?? false) ? "بله" : "خیر";
                lblShortTime.Text = (bu.IsShortTime ?? false) ? "بله" : "خیر";

                lblSellPrice.Text = bu.SellPrice.ToString("N0");
                lblVamPrice.Text = bu.VamPrice.ToString("N0");
                lblQestPrice.Text = bu.QestPrice.ToString("N0");
                lblSellDong.Text = bu.Dang.ToString();
                lblSellDocType.Text = bu.DocumentTypeName;
                lblSellTarakom.Text = bu.Tarakom?.GetDisplay();

                lblPishDeliveryDate.Text = Calendar.MiladiToShamsi(bu.DeliveryDate);
                lblPishDesc.Text = bu.PishDesc;
                lblPishDocType.Text = bu.DocumentTypeName;
                lblPishDong.Text = bu.Dang.ToString();
                lblPishPrice.Text = bu.PishPrice.ToString("N0");
                lblPishTotalPrice.Text = bu.PishTotalPrice.ToString("N0");
                lblPishTarakom.Text = bu.Tarakom?.GetDisplay() ?? "";

                lblMoavaezeDesc.Text = bu.MoavezeDesc;
                lblMoavaezeDocType.Text = bu.DocumentTypeName;
                lblMoavaezeDong.Text = bu.Dang.ToString();
                lblMoavaezeTarakom.Text = bu.Tarakom?.GetDisplay() ?? "";

                lblMosharekatDesc.Text = bu.MosharekatDesc;
                lblMosharekatDocType.Text = bu.DocumentTypeName;
                lblMosharekatDong.Text = bu.Dang.ToString();
                lblMosharekatTarakom.Text = bu.Tarakom?.GetDisplay() ?? "";

                lblMasahat.Text = $@"{bu.Masahat} متر";
                lblZirBana.Text = $@"{bu.ZirBana} متر";
                var city = await CitiesBussines.GetAsync(bu.CityGuid);
                if (city != null)
                {
                    lblState.Text = city.StateName;
                    lblCity.Text = city.Name;
                }
                lblRegion.Text = bu.RegionName;
                lblCondition.Text = bu.BuildingConditionName;
                lblSide.Text = bu.Side.GetDisplay();
                lblSaleSakht.Text = bu.SaleSakht;
                lblAddress.Text = bu.Address;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowBuildingDetail(BuildingBussines _bu)
        {
            InitializeComponent();
            bu = _bu;
        }

        private async void frmShowBuildingDetail_Load(object sender, System.EventArgs e) => await SetDataAsync();
    }
}
