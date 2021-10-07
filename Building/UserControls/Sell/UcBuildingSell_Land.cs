using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Sell
{
    public partial class UcBuildingSell_Land : UserControl
    {
        private BuildingBussines _bu;

        public BuildingBussines Building
        {
            get
            {
                try
                {
                    _bu.DocumentType = ucDocumentType1.SanadTypeGuid;
                    _bu.Dang = UcDong.Value;
                    _bu.Masahat = ucMasahat.Value;
                    _bu.Hashie = UcWidth.Value;
                    _bu.Lenght = UcHeight.Value;
                    _bu.ReformArea = UcReformArea.Value;
                    _bu.BuildingPermits = chbBuildingPermits.Checked;
                    _bu.Tarakom = ucTarakom1.Tarakom;
                    _bu.WidthOfPassage = UcWitdhOfPassage.Value;
                    _bu.Side = ucSide1.Side;
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
                    ucDocumentType1.SanadTypeGuid = _bu.DocumentType;
                    UcDong.Value = _bu.Dang;
                    ucMasahat.Value = _bu.Masahat;
                    UcWidth.Value = (int)_bu.Hashie;
                    UcHeight.Value = (int)_bu.Lenght;
                    UcReformArea.Value = (int)_bu.ReformArea;
                    if (_bu.BuildingPermits != null)
                        chbBuildingPermits.Checked = _bu.BuildingPermits.Value;
                    ucTarakom1.Tarakom = _bu.Tarakom;
                    UcWitdhOfPassage.Value = (int) _bu.WidthOfPassage;
                    ucSide1.Side = _bu.Side;
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

        public UcBuildingSell_Land() => InitializeComponent();

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
