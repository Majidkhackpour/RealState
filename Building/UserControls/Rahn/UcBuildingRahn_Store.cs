using EntityCache.Bussines;
using Services;
using System;

namespace Building.UserControls.Rahn
{
    public partial class UcBuildingRahn_Store : clsBuildingColtrols
    {
        private BuildingBussines _bu;
        public bool IsFullRahn { get => !ucEjare.Visible; set => ucEjare.Visible = !value; }
        public override BuildingBussines Building
        {
            get
            {
                try
                {
                    _bu.ZirBana = ucZirBana1.Value;
                    _bu.CommericallLicense = ucCommericallLicense1.CommericallLicense;
                    _bu.SuitableFor = UcSuitableFor.Value;
                    _bu.Hashie = UcWidth.Value;
                    _bu.ErtefaSaqf = UcErtefa.Value;
                    _bu.WallCovering = UcWallCovering.Value;
                    _bu.BuildingViewGuid = ucBuildingView1.BuildingViewGuid;
                    _bu.FloorCoverGuid = ucFloorCover1.FloorCoverGuid;
                    _bu.RahnPrice1 = ucRahn.Price;
                    if (!IsFullRahn) _bu.EjarePrice1 = ucEjare.Price;
                    _bu.Tabdil = chbTabdil.Checked;
                    _bu.IsOwnerHere = chbIsOwnerHere.Checked;
                    _bu.IsShortTime = chbShortTime.Checked;
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
                    ucCommericallLicense1.CommericallLicense = _bu.CommericallLicense;
                    UcSuitableFor.Value = _bu.SuitableFor;
                    UcWidth.Value = (int)_bu.Hashie;
                    UcErtefa.Value = (int)_bu.ErtefaSaqf;
                    UcWallCovering.Value = _bu.WallCovering;
                    ucBuildingView1.BuildingViewGuid = _bu.BuildingViewGuid;
                    ucFloorCover1.FloorCoverGuid = _bu.FloorCoverGuid;
                    ucRahn.Price = _bu.RahnPrice1;
                    if (!IsFullRahn) ucEjare.Price = _bu.EjarePrice1;
                    if (_bu.Tabdil != null) chbTabdil.Checked = _bu.Tabdil.Value;
                    if (_bu.IsOwnerHere != null) chbIsOwnerHere.Checked = _bu.IsOwnerHere.Value;
                    if (_bu.IsShortTime != null) chbShortTime.Checked = _bu.IsShortTime.Value;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcBuildingRahn_Store() => InitializeComponent();
    }
}
