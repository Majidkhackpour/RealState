using Services;
using System;
using System.Windows.Forms;
using EntityCache.Bussines;

namespace Building.UserControls.Sell
{
    public partial class UcBuildingSell_Home : clsBuildingColtrols
    {
        private BuildingBussines _bu;

        public override BuildingBussines Building
        {
            get
            {
                try
                {
                    _bu.ZirBana = ucZirBana1.Value;
                    _bu.MetrazhTejari = UcTejari.Value;
                    _bu.RoomCount = ucRoomCount1.RoomCount;
                    _bu.DocumentType = ucDocumentType1.SanadTypeGuid;
                    _bu.Dang = UcDong.Value;
                    _bu.SaleSakht = ucSaleSakht1.SaleSakht;
                    _bu.Masahat = ucMasahat.Value;
                    _bu.TedadTabaqe = ucTabaqeCount.Value;
                    _bu.Hashie = UcWidth.Value;
                    _bu.Tarakom = ucTarakom1.Tarakom;
                    _bu.Side = ucSide1.Side;
                    _bu.BuildingViewGuid = ucBuildingView1.BuildingViewGuid;
                    _bu.FloorCoverGuid = ucFloorCover1.FloorCoverGuid;
                    _bu.KitchenServiceGuid = ucKitchenService1.KitchenServiceGuid;
                    _bu.SellPrice = ucTotalPrice.Price;
                    _bu.VamPrice = ucVam.Price;
                    _bu.QestPrice = ucQest.Price;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return _bu;
            }
            set
            {
                try
                {
                    if (value == null) return;
                    _bu = value;
                    ucZirBana1.Value = _bu.ZirBana;
                    UcTejari.Value = (int) _bu.MetrazhTejari;
                    ucRoomCount1.RoomCount = _bu.RoomCount;
                    ucDocumentType1.SanadTypeGuid = _bu.DocumentType;
                    UcDong.Value = _bu.Dang;
                    ucSaleSakht1.SaleSakht = _bu.SaleSakht;
                    ucMasahat.Value = _bu.Masahat;
                    ucTabaqeCount.Value = _bu.TedadTabaqe;
                    UcWidth.Value = (int) _bu.Hashie;
                    ucTarakom1.Tarakom = _bu.Tarakom;
                    ucSide1.Side = _bu.Side;
                    ucBuildingView1.BuildingViewGuid = _bu.BuildingViewGuid;
                    ucFloorCover1.FloorCoverGuid = _bu.FloorCoverGuid;
                    ucKitchenService1.KitchenServiceGuid = _bu.KitchenServiceGuid;
                    ucTotalPrice.Price = _bu.SellPrice;
                    ucVam.Price = _bu.VamPrice;
                    ucQest.Price = _bu.QestPrice;
                    if (_bu.Dang <= 0) UcDong.DefaultValue = 6;
                    if (_bu.Masahat <= 0) return;
                    var m = Math.Truncate(_bu.SellPrice / _bu.Masahat);
                    ucPricePerMasahat.Price = m;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }

        public UcBuildingSell_Home() => InitializeComponent();

        private void ucTotalPrice_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != ucTotalPrice.Name) return;

                ucPricePerMasahat.Price = 0;

                if (ucMasahat.Value <= 0) return;
                var m = Math.Truncate(ucTotalPrice.Price / ucMasahat.Value);
                ucPricePerMasahat.Price = m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucPricePerMasahat_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != ucPricePerMasahat.Name) return;

                if (ucMasahat.Value > 0)
                    ucTotalPrice.Price = ucPricePerMasahat.Price * ucMasahat.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucMasahat_OnValueChanged()
        {
            try
            {
                ucTotalPrice.Price = ucPricePerMasahat.Price * ucMasahat.Value;
                if (ucMasahat.Value <= 0) return;
                ucPricePerMasahat.Price = 0;
                ucPricePerMasahat.Price = ucTotalPrice.Price / ucMasahat.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
