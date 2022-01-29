using System;
using System.Windows.Forms;
using EntityCache.Bussines.ReportBussines;
using Services;

namespace Building.UserControls
{
    public partial class UcBuildingDetail : UserControl
    {
        public BuildingReportBussines Building
        {
            set
            {
                try
                {
                    if (value == null)
                    {
                        Clean();
                        return;
                    }
                    if (!string.IsNullOrEmpty(value.BuildingTypeName))
                        ucBuildingType.Value = value.BuildingTypeName;
                    ucMasahat.Value = value.Masahat.ToString();
                    ucZirbana.Value = value.ZirBana.ToString();
                    ucRahn.Value = value.RahnPrice1.ToString("N0");
                    ucEjare.Value = value.EjarePrice1.ToString("N0");
                    ucSell.Value = value.SellPrice.ToString("N0");
                    ucVam.Value = value.VamPrice.ToString("N0");
                    ucQest.Value = value.QestPrice.ToString("N0");
                    if (!string.IsNullOrEmpty(value.DocumentTypeName))
                        ucDocumentType.Value = value.DocumentTypeName;
                    if (!string.IsNullOrEmpty(value.RegionName))
                        ucRegion.Value = value.RegionName;
                    if (!string.IsNullOrEmpty(value.SaleSakht))
                        ucSaleSakht.Value = value.SaleSakht;
                    if (!string.IsNullOrEmpty(value.UserName))
                        ucUser.Value = value.UserName;
                    if (!string.IsNullOrEmpty(value.BuildingAccountTypeName))
                        ucAccountType.Value = value.BuildingAccountTypeName;
                    if (!string.IsNullOrEmpty(value.BuildingConditionName))
                        ucCondition.Value = value.BuildingConditionName;
                    if (!string.IsNullOrEmpty(value.BuildingViewName))
                        ucView.Value = value.BuildingViewName;
                    if (!string.IsNullOrEmpty(value.FloorCoverName))
                        ucFloor.Value = value.FloorCoverName;
                    if (!string.IsNullOrEmpty(value.KitchenServiceName))
                        ucKitchen.Value = value.KitchenServiceName;
                    if (!string.IsNullOrEmpty(value.WindowName))
                        ucWindow.Value = value.WindowName;
                    if (!string.IsNullOrEmpty(value.SideName))
                        ucSide.Value = value.SideName;
                    if (!string.IsNullOrEmpty(value.Hitting))
                        ucHitting.Value = value.Hitting;
                    if (!string.IsNullOrEmpty(value.Colling))
                        ucColling.Value = value.Colling;
                    if (value.TabaqeCount == 0 && value.TabaqeNo != 0)
                        ucTabaqe.Value = value.TabaqeNo.ToString();
                    else if (value.TabaqeCount != 0 && value.TabaqeNo != 0)
                        ucTabaqe.Value = $"{value.TabaqeNo} از {value.TabaqeCount}";
                    decimal m = 0;
                    if (value.Masahat > 0)
                        m = Math.Truncate(value.SellPrice / value.Masahat);
                    else if (value.ZirBana > 0)
                        m = Math.Truncate(value.SellPrice / value.ZirBana);
                    ucPricePerMeter.Value = m.ToString("N0");

                    if (value.Parent == EnBuildingParent.FullRentAprtment ||
                        value.Parent == EnBuildingParent.FullRentHome ||
                        value.Parent == EnBuildingParent.FullRentStore ||
                        value.Parent == EnBuildingParent.FullRentOffice ||
                        value.Parent == EnBuildingParent.RentAprtment ||
                        value.Parent == EnBuildingParent.RentHome ||
                        value.Parent == EnBuildingParent.RentStore ||
                        value.Parent == EnBuildingParent.RentOffice)
                    {
                        ucSell.Visible = ucQest.Visible = ucVam.Visible = false;
                        ucPricePerMeter.Visible = ucDocumentType.Visible = false;
                    }
                    else
                        ucRahn.Visible = ucEjare.Visible = false;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        private void Clean()
        {
            try
            {
                ucBuildingType.Value = "---";
                ucMasahat.Value = "---";
                ucZirbana.Value = "---";
                ucRahn.Value = "---";
                ucEjare.Value = "---";
                ucSell.Value = "---";
                ucVam.Value = "---";
                ucQest.Value = "---";
                ucDocumentType.Value = "---";
                ucRegion.Value = "---";
                ucSaleSakht.Value = "---";
                ucUser.Value = "---";
                ucAccountType.Value = "---";
                ucCondition.Value = "---";
                ucView.Value = "---";
                ucFloor.Value = "---";
                ucKitchen.Value = "---";
                ucWindow.Value = "---";
                ucSide.Value = "---";
                ucHitting.Value = "---";
                ucColling.Value = "---";
                ucTabaqe.Value = "---";
                ucPricePerMeter.Value = "---";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcBuildingDetail() => InitializeComponent();
    }
}
