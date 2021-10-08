﻿using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Rahn
{
    public partial class UcBuildingRahn_Home : UserControl
    {
        private BuildingBussines _bu;
        public bool IsFullRahn { get => !ucEjare.Visible; set => ucEjare.Visible = !value; }
        public BuildingBussines Building
        {
            get
            {
                try
                {
                    _bu.ZirBana = ucZirBana1.Value;
                    _bu.MetrazhTejari = UcTejari.Value;
                    _bu.RoomCount = ucRoomCount1.RoomCount;
                    _bu.SaleSakht = ucSaleSakht1.SaleSakht;
                    _bu.TedadTabaqe = ucTabaqeCount.Value;
                    _bu.Masahat = ucMasahat.Value;
                    _bu.Side = ucSide1.Side;
                    _bu.BuildingViewGuid = ucBuildingView1.BuildingViewGuid;
                    _bu.FloorCoverGuid = ucFloorCover1.FloorCoverGuid;
                    _bu.KitchenServiceGuid = ucKitchenService1.KitchenServiceGuid;
                    _bu.RahnPrice1 = ucRahn.Price;
                    if (!IsFullRahn) _bu.EjarePrice1 = ucEjare.Price;
                    _bu.Tabdil = chbTabdil.Checked;
                    _bu.IsOwnerHere = chbIsOwnerHere.Checked;
                    _bu.IsShortTime = chbShortTime.Checked;
                    _bu.RentalAutorityGuid = ucRentalAuthority1.RentalAuthorityGuid;
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
                    UcTejari.Value = (int)_bu.MetrazhTejari;
                    ucRoomCount1.RoomCount = _bu.RoomCount;
                    ucSaleSakht1.SaleSakht = _bu.SaleSakht;
                    ucMasahat.Value = _bu.Masahat;
                    ucTabaqeCount.Value = _bu.TedadTabaqe;
                    ucSide1.Side = _bu.Side;
                    ucBuildingView1.BuildingViewGuid = _bu.BuildingViewGuid;
                    ucFloorCover1.FloorCoverGuid = _bu.FloorCoverGuid;
                    ucKitchenService1.KitchenServiceGuid = _bu.KitchenServiceGuid;
                    ucRahn.Price = _bu.RahnPrice1;
                    if (!IsFullRahn) ucEjare.Price = _bu.EjarePrice1;
                    if (_bu.Tabdil != null) chbTabdil.Checked = _bu.Tabdil.Value;
                    if (_bu.IsOwnerHere != null) chbIsOwnerHere.Checked = _bu.IsOwnerHere.Value;
                    if (_bu.IsShortTime != null) chbShortTime.Checked = _bu.IsShortTime.Value;
                    ucRentalAuthority1.RentalAuthorityGuid = _bu.RentalAutorityGuid;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcBuildingRahn_Home() => InitializeComponent();
    }
}
