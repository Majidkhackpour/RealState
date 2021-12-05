﻿using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.Contract
{
    public partial class frmContractTypeSelector : MetroForm
    {
        private void SetIsSelect()
        {
            try
            {
                ucForoush.IsSelect = true;
                ucRahnEjare.IsSelect = false;
                ucPishForosh.IsSelect = false;
                ucSarQofli.IsSelect = false;
                ucTamlic.IsSelect = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmContractTypeSelector() => InitializeComponent();
        private async Task ucForoush_OnClick(WindowsSerivces.UcButton arg)
        {
            try
            {
                SetIsSelect();
                await Task.Delay(100);
                var frm = new frmContractMain_Sell(new ContractBussines());
                DialogResult = frm.ShowDialog(this);
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmContractTypeSelector_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
