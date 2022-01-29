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

                    if (!string.IsNullOrEmpty(value.BuildingTypeName) && value.BuildingTypeName != "تعیین نشده")
                    {
                        ucBuildingType.Visible = true;
                        ucBuildingType.Value = value.BuildingTypeName;
                    }
                    else ucBuildingType.Visible = false;

                    if (value.Masahat > 0)
                    {
                        ucMasahat.Visible = true;
                        ucMasahat.Value = value.Masahat.ToString();
                    }
                    else ucMasahat.Visible = false;

                    if (value.ZirBana > 0)
                    {
                        ucZirbana.Visible = true;
                        ucZirbana.Value = value.ZirBana.ToString();
                    }
                    else ucZirbana.Visible = false;

                    if (value.RahnPrice1 > 0)
                    {
                        ucRahn.Visible = true;
                        ucRahn.Value = value.RahnPrice1.ToString("N0");
                    }
                    else ucRahn.Visible = false;

                    if (value.EjarePrice1 > 0)
                    {
                        ucEjare.Visible = true;
                        ucEjare.Value = value.EjarePrice1.ToString("N0");
                    }
                    else ucEjare.Visible = false;

                    if (value.SellPrice > 0)
                    {
                        ucSell.Visible = true;
                        ucSell.Value = value.SellPrice.ToString("N0");
                    }
                    else ucSell.Visible = false;

                    if (value.VamPrice > 0)
                    {
                        ucVam.Visible = true;
                        ucVam.Value = value.VamPrice.ToString("N0");
                    }
                    else ucVam.Visible = false;

                    if (value.QestPrice > 0)
                    {
                        ucQest.Visible = true;
                        ucQest.Value = value.QestPrice.ToString("N0");
                    }
                    else ucQest.Visible = false;

                    if (!string.IsNullOrEmpty(value.DocumentTypeName) && value.DocumentTypeName != "تعیین نشده")
                    {
                        ucDocumentType.Visible = true;
                        ucDocumentType.Value = value.DocumentTypeName;
                    }
                    else ucDocumentType.Visible = false;

                    if (!string.IsNullOrEmpty(value.RegionName))
                    {
                        ucRegion.Visible = true;
                        ucRegion.Value = value.RegionName;
                    }
                    else ucRegion.Visible = false;

                    if (!string.IsNullOrEmpty(value.SaleSakht))
                    {
                        ucSaleSakht.Visible = true;
                        ucSaleSakht.Value = value.SaleSakht;
                    }
                    else ucSaleSakht.Visible = false;

                    if (!string.IsNullOrEmpty(value.UserName))
                    {
                        ucUser.Visible = true;
                        ucUser.Value = value.UserName;
                    }
                    else ucUser.Visible = false;

                    if (!string.IsNullOrEmpty(value.BuildingAccountTypeName) && value.BuildingAccountTypeName != "تعیین نشده")
                    {
                        ucAccountType.Visible = true;
                        ucAccountType.Value = value.BuildingAccountTypeName;
                    }
                    else ucAccountType.Visible = false;

                    if (!string.IsNullOrEmpty(value.BuildingConditionName) && value.BuildingConditionName != "تعیین نشده")
                    {
                        ucCondition.Visible = true;
                        ucCondition.Value = value.BuildingConditionName;
                    }
                    else ucCondition.Visible = false;

                    if (!string.IsNullOrEmpty(value.BuildingViewName) && value.BuildingViewName != "تعیین نشده")
                    {
                        ucView.Visible = true;
                        ucView.Value = value.BuildingViewName;
                    }
                    else ucView.Visible = false;

                    if (!string.IsNullOrEmpty(value.FloorCoverName) && value.FloorCoverName != "تعیین نشده")
                    {
                        ucFloor.Visible = true;
                        ucFloor.Value = value.FloorCoverName;
                    }
                    else ucFloor.Visible = false;

                    if (!string.IsNullOrEmpty(value.KitchenServiceName) && value.KitchenServiceName != "تعیین نشده")
                    {
                        ucKitchen.Visible = true;
                        ucKitchen.Value = value.KitchenServiceName;
                    }
                    else ucKitchen.Visible = false;

                    if (!string.IsNullOrEmpty(value.WindowName) && value.WindowName != "تعیین نشده")
                    {
                        ucWindow.Visible = true;
                        ucWindow.Value = value.WindowName;
                    }
                    else ucWindow.Visible = false;

                    if (!string.IsNullOrEmpty(value.SideName) && value.SideName != "تعیین نشده")
                    {
                        ucSide.Visible = true;
                        ucSide.Value = value.SideName;
                    }
                    else ucSide.Visible = false;

                    if (!string.IsNullOrEmpty(value.Hitting))
                    {
                        ucHitting.Visible = true;
                        ucHitting.Value = value.Hitting;
                    }
                    else ucHitting.Visible = false;

                    if (!string.IsNullOrEmpty(value.Colling))
                    {
                        ucColling.Visible = true;
                        ucColling.Value = value.Colling;
                    }
                    else ucColling.Visible = false;

                    if (value.TabaqeCount == 0 && value.TabaqeNo != 0)
                    {
                        ucTabaqe.Visible = true;
                        ucTabaqe.Value = value.TabaqeNo.ToString();
                    }
                    else if (value.TabaqeCount != 0 && value.TabaqeNo != 0)
                    {
                        ucTabaqe.Visible = true;
                        ucTabaqe.Value = $"{value.TabaqeNo} از {value.TabaqeCount}";
                    }
                    else ucTabaqe.Visible = false;

                    decimal m = 0;
                    if (value.Masahat > 0)
                        m = Math.Truncate(value.SellPrice / value.Masahat);
                    else if (value.ZirBana > 0)
                        m = Math.Truncate(value.SellPrice / value.ZirBana);
                    if (m > 0)
                    {
                        ucPricePerMeter.Visible = true;
                        ucPricePerMeter.Value = m.ToString("N0");
                    }
                    else ucPricePerMeter.Visible = false;
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
