using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Other
{
    public partial class UcBuildingOther_Store : UserControl
    {
        private BuildingBussines _bu;
        public bool IsPishForoush
        {
            get => ucConstructionStage1.Visible;
            set
            {
                ucConstructionStage1.Visible = value;
                txtDeliveryDate.Visible = value;
                label1.Visible = value;
            }
        }
        public BuildingBussines Building
        {
            get
            {
                try
                {
                    _bu.ZirBana = ucZirBana1.Value;
                    _bu.DocumentType = ucDocumentType1.SanadTypeGuid;
                    _bu.Dang = UcDong.Value;
                    _bu.CommericallLicense = ucCommericallLicense1.CommericallLicense;
                    _bu.Hashie = UcWidth.Value;
                    _bu.ErtefaSaqf = UcErtefa.Value;
                    _bu.WallCovering = UcWallCovering.Value;
                    _bu.BuildingViewGuid = ucBuildingView1.BuildingViewGuid;
                    _bu.FloorCoverGuid = ucFloorCover1.FloorCoverGuid;
                    _bu.SellPrice = ucTotalPrice.Price;
                    _bu.VamPrice = ucVam.Price;
                    _bu.QestPrice = ucQest.Price;
                    if (IsPishForoush)
                    {
                        _bu.ConstructionStage = ucConstructionStage1.Stage;
                        _bu.DeliveryDate = Calendar.ShamsiToMiladi(txtDeliveryDate.Text);
                    }
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
                    ucDocumentType1.SanadTypeGuid = _bu.DocumentType;
                    UcDong.Value = _bu.Dang;
                    ucCommericallLicense1.CommericallLicense = _bu.CommericallLicense;
                    UcWidth.Value = (int)_bu.Hashie;
                    UcErtefa.Value = (int)_bu.ErtefaSaqf;
                    UcWallCovering.Value = _bu.WallCovering;
                    ucBuildingView1.BuildingViewGuid = _bu.BuildingViewGuid;
                    ucFloorCover1.FloorCoverGuid = _bu.FloorCoverGuid;
                    ucTotalPrice.Price = _bu.SellPrice;
                    ucVam.Price = _bu.VamPrice;
                    ucQest.Price = _bu.QestPrice;
                    if (_bu.Dang <= 0) UcDong.DefaultValue = 6;
                    if (IsPishForoush)
                    {
                        ucConstructionStage1.Stage = _bu.ConstructionStage;
                        txtDeliveryDate.Text = Calendar.MiladiToShamsi(_bu.DeliveryDate);
                    }
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

        public UcBuildingOther_Store()=>InitializeComponent();

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
