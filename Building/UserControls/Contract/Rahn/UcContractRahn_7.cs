﻿using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Contract.Rahn
{
    public partial class UcContractRahn_7 : UserControl
    {
        private void LoadCity()
        {
            try
            {
                lblCity.Text = "";
                var cityGuid = Settings.Classes.clsEconomyUnit.EconomyCity;
                if (string.IsNullOrEmpty(cityGuid)) return;
                var cGuid = Guid.Parse(cityGuid);
                if (cGuid == Guid.Empty) return;
                var city = CitiesBussines.Get(cGuid);
                if (city == null) return;
                lblCity.Text = city.Name;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcContractRahn_7()
        {
            InitializeComponent();
            LoadCity();
        }
    }
}