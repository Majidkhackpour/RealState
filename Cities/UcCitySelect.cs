using EntityCache.Bussines;
using Services;
using Settings.Classes;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cities
{
    public partial class UcCitySelect : UserControl
    {
        private Guid _stateGuid, _cityGuid, _regionGuid;
        public bool IsShowAddress { set => label37.Visible = txtAddress.Visible = value; }
        public Guid StateGuid => _stateGuid;
        public async Task SetStateGuidAsync(Guid value)
        {
            try
            {
                if (StateBindingSource.Count <= 0)
                    await FillStateAsync();
                if (value == Guid.Empty)
                {
                    if (SettingsBussines.Setting.CompanyInfo.EconomyState == Guid.Empty)
                        cmbState.SelectedIndex = 0;
                    else
                        cmbState.SelectedValue = SettingsBussines.Setting.CompanyInfo.EconomyState;
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
                        if (SettingsBussines.Setting.CompanyInfo.EconomyCity != Guid.Empty)
                            cmbCity.SelectedValue = SettingsBussines.Setting.CompanyInfo.EconomyCity;
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
                        if (SettingsBussines.Setting.CompanyInfo.ManagerRegion != Guid.Empty)
                            cmbRegion.SelectedValue = SettingsBussines.Setting.CompanyInfo.ManagerRegion;
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
        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue, default);
                CityBindingSource.DataSource = list?.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (SettingsBussines.Setting.CompanyInfo.EconomyCity != Guid.Empty)
                    cmbCity.SelectedValue = SettingsBussines.Setting.CompanyInfo.EconomyCity;

                _stateGuid = (Guid)cmbState.SelectedValue;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedValue == null) return;
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue);
                RegionBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                if (SettingsBussines.Setting.CompanyInfo.ManagerRegion != Guid.Empty)
                    cmbRegion.SelectedValue = SettingsBussines.Setting.CompanyInfo.ManagerRegion;

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
        private async Task FillStateAsync()
        {
            try
            {
                var list = await StatesBussines.GetAllAsync();
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcCitySelect() => InitializeComponent();
    }
}
