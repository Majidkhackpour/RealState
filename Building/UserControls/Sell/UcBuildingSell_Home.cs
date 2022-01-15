﻿using Services;
using System;
using System.Threading.Tasks;
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
        }

        public override async Task SetBuildingAsync(BuildingBussines value)
        {
            try
            {
                if (value == null) return;
                _bu = value;
                ucZirBana1.Value = _bu.ZirBana;
                UcTejari.Value = (int)_bu.MetrazhTejari;
                ucRoomCount1.RoomCount = _bu.RoomCount;
                await ucDocumentType1.SetSanadTypeGuidAsync(_bu.DocumentType);
                UcDong.Value = _bu.Dang;
                ucSaleSakht1.SaleSakht = _bu.SaleSakht;
                ucMasahat.Value = _bu.Masahat;
                ucTabaqeCount.Value = _bu.TedadTabaqe;
                UcWidth.Value = (int)_bu.Hashie;
                ucTarakom1.Tarakom = _bu.Tarakom;
                ucSide1.Side = _bu.Side;
                await ucBuildingView1.SetBuildingViewGuidAsync(_bu.BuildingViewGuid);
                await ucFloorCover1.SetFloorCoverGuidAsync(_bu.FloorCoverGuid);
                await ucKitchenService1.SetKitchenServiceGuidAsync(_bu.KitchenServiceGuid);
                ucTotalPrice.Price = _bu.SellPrice;
                ucVam.Price = _bu.VamPrice;
                ucQest.Price = _bu.QestPrice;
                if (_bu.Dang <= 0) UcDong.DefaultValue = 6;
                if (_bu.Masahat > 0)
                {
                    var m = Math.Truncate(_bu.SellPrice / _bu.Masahat);
                    ucPricePerMasahat.Price = m;
                }
                if (_bu.ZirBana > 0)
                {
                    var m = Math.Truncate(_bu.SellPrice / _bu.ZirBana);
                    ucPricePerZirBana.Price = m;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
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

                ucPricePerMasahat.Price = ucPricePerZirBana.Price = 0;

                if (ucMasahat.Value > 0)
                {
                    var m = Math.Truncate(ucTotalPrice.Price / ucMasahat.Value);
                    ucPricePerMasahat.Price = m;
                }

                if (ucZirBana1.Value > 0)
                {
                    var m = Math.Truncate(ucTotalPrice.Price / ucZirBana1.Value);
                    ucPricePerZirBana.Price = m;
                }
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
                if (ucZirBana1.Value <= 0) return;
                ucPricePerZirBana.Price = 0;
                var m = Math.Truncate(ucTotalPrice.Price / ucZirBana1.Value);
                ucPricePerZirBana.Price = m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucMasahat_OnValueChanged() => CalculateSellPrice(0);
        private void ucPricePerZirBana_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != ucPricePerZirBana.Name) return;

                if (ucZirBana1.Value > 0)
                    ucTotalPrice.Price = ucPricePerZirBana.Price * ucZirBana1.Value;
                if (ucMasahat.Value <= 0) return;
                ucPricePerMasahat.Price = 0;
                var m = Math.Truncate(ucTotalPrice.Price / ucMasahat.Value);
                ucPricePerMasahat.Price = m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucZirBana1_OnValueChanged() => CalculateSellPrice(1);
        private void CalculateSellPrice(short type)
        {
            try
            {
                if (type == 0)
                    ucTotalPrice.Price = ucPricePerMasahat.Price * ucMasahat.Value;
                else if (type == 1)
                    ucTotalPrice.Price = ucPricePerZirBana.Price * ucZirBana1.Value;

                if (ucMasahat.Value > 0)
                {
                    ucPricePerMasahat.Price = 0;
                    ucPricePerMasahat.Price = ucTotalPrice.Price / ucMasahat.Value;
                }
                if (ucZirBana1.Value > 0)
                {
                    ucPricePerZirBana.Price = 0;
                    ucPricePerZirBana.Price = ucTotalPrice.Price / ucZirBana1.Value;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
