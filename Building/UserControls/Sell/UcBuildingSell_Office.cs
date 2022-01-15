﻿using EntityCache.Bussines;
using Services;
using System;
using System.Threading.Tasks;

namespace Building.UserControls.Sell
{
    public partial class UcBuildingSell_Office : clsBuildingColtrols
    {
        private BuildingBussines _bu;

        public override BuildingBussines Building
        {
            get
            {
                try
                {
                    _bu.ZirBana = ucZirBana1.Value;
                    _bu.RoomCount = ucRoomCount1.RoomCount;
                    _bu.DocumentType = ucDocumentType1.SanadTypeGuid;
                    _bu.Dang = UcDong.Value;
                    _bu.SaleSakht = ucSaleSakht1.SaleSakht;
                    _bu.TedadTabaqe = ucTabaqeCount.Value;
                    _bu.TabaqeNo = ucTabaqeNo1.TabaqeNo;
                    _bu.VahedPerTabaqe = ucVahedPertabaqe.Value;
                    _bu.CommericallLicense = ucCommericallLicense1.CommericallLicense;
                    _bu.SuitableFor = UcSuitableFor.Value;
                    _bu.Side = ucSide1.Side;
                    _bu.BuildingViewGuid = ucBuildingView1.BuildingViewGuid;
                    _bu.FloorCoverGuid = ucFloorCover1.FloorCoverGuid;
                    _bu.KitchenServiceGuid = ucKitchenService1.KitchenServiceGuid;
                    _bu.BuildingConditionGuid = ucBuildingCondition1.BuildingConditionGuid;
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
                ucRoomCount1.RoomCount = _bu.RoomCount;
                await ucDocumentType1.SetSanadTypeGuidAsync(_bu.DocumentType);
                UcDong.Value = _bu.Dang;
                ucSaleSakht1.SaleSakht = _bu.SaleSakht;
                ucTabaqeCount.Value = _bu.TedadTabaqe;
                ucTabaqeNo1.TabaqeNo = _bu.TabaqeNo;
                ucVahedPertabaqe.Value = _bu.VahedPerTabaqe;
                ucCommericallLicense1.CommericallLicense = _bu.CommericallLicense;
                UcSuitableFor.Value = _bu.SuitableFor;
                ucSide1.Side = _bu.Side;
                await ucBuildingView1.SetBuildingViewGuidAsync(_bu.BuildingViewGuid);
                await ucFloorCover1.SetFloorCoverGuidAsync(_bu.FloorCoverGuid);
                await ucKitchenService1.SetKitchenServiceGuidAsync(_bu.KitchenServiceGuid);
                await ucBuildingCondition1.SetBuildingConditionGuidAsync(_bu.BuildingConditionGuid);
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
        public UcBuildingSell_Office() => InitializeComponent();

        private void ucPricePerMasahat_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != ucPricePerMasahat.Name) return;

                if (ucZirBana1.Value > 0)
                    ucTotalPrice.Price = ucPricePerMasahat.Price * ucZirBana1.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucTotalPrice_OnTextChanged()
        {
            try
            {
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != ucTotalPrice.Name) return;

                ucPricePerMasahat.Price = 0;

                if (ucZirBana1.Value <= 0) return;
                var m = Math.Truncate(ucTotalPrice.Price / ucZirBana1.Value);
                ucPricePerMasahat.Price = m;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucZirBana1_OnValueChanged()
        {
            try
            {
                ucTotalPrice.Price = ucPricePerMasahat.Price * ucZirBana1.Value;
                if (ucZirBana1.Value <= 0) return;
                ucPricePerMasahat.Price = 0;
                ucPricePerMasahat.Price = ucTotalPrice.Price / ucZirBana1.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
