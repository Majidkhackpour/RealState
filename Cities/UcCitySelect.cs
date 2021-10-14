using EntityCache.Bussines;
using Services;
using Settings.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Cities
{
    public partial class UcCitySelect : UserControl
    {
        private Guid _stateGuid, _cityGuid, _regionGuid;

        public Guid StateGuid
        {
            get => _stateGuid;
            set
            {
                try
                {
                    if (value == Guid.Empty)
                    {
                        if (string.IsNullOrEmpty(clsEconomyUnit.EconomyState))
                            cmbState.SelectedIndex = 0;
                        else
                            cmbState.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyState);
                        _stateGuid = (Guid)cmbState.SelectedValue;
                        return;
                    }

                    _stateGuid = value;
                    cmbState.SelectedValue = _stateGuid;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public Guid CityGuid
        {
            get => _cityGuid;
            set
            {
                try
                {
                    if (CityBindingSource.Count <= 0) return;
                    if (value == Guid.Empty)
                    {
                        if (!string.IsNullOrEmpty(clsEconomyUnit.EconomyCity))
                            cmbCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);
                        _cityGuid = (Guid)cmbCity.SelectedValue;
                        return;
                    }

                    _cityGuid = value;
                    cmbCity.SelectedValue = _cityGuid;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public Guid RegionGuid
        {
            get => _regionGuid;
            set
            {
                try
                {
                    if (RegionBindingSource.Count <= 0) return;
                    if (value == Guid.Empty)
                    {
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerRegion))
                            cmbRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);
                        _regionGuid = (Guid)cmbRegion.SelectedValue;
                        return;
                    }

                    _regionGuid = value;
                    cmbRegion.SelectedValue = _regionGuid;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public string Address { get => txtAddress.Text.FixString(); set => txtAddress.Text = value; }
        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                var list = CitiesBussines.GetAll((Guid)cmbState.SelectedValue);
                CityBindingSource.DataSource = list?.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (!string.IsNullOrEmpty(clsEconomyUnit.EconomyCity))
                    cmbCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);

                _stateGuid = (Guid)cmbState.SelectedValue;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedValue == null) return;
                var list = RegionsBussines.GetAll((Guid)cmbCity.SelectedValue);
                RegionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerRegion))
                    cmbRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);

                _cityGuid = (Guid)cmbCity.SelectedValue;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRegion.SelectedValue != null)
                    _regionGuid = (Guid)cmbRegion.SelectedValue;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillState()
        {
            try
            {
                var list = StatesBussines.GetAll();
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcCitySelect()
        {
            InitializeComponent();
            FillState();
        }
    }
}
