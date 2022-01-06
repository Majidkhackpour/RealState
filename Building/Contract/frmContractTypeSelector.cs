using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.Contract
{
    public partial class frmContractTypeSelector : MetroForm
    {
        private void SetIsSelect(EnRequestType type)
        {
            try
            {
                if (type == EnRequestType.Forush)
                {
                    ucForoush.IsSelect = true;
                    ucRahnEjare.IsSelect = false;
                    ucPishForosh.IsSelect = false;
                    ucSarQofli.IsSelect = false;
                    ucTamlic.IsSelect = false;
                }
                else if (type == EnRequestType.Rahn)
                {
                    ucForoush.IsSelect = false;
                    ucRahnEjare.IsSelect = true;
                    ucPishForosh.IsSelect = false;
                    ucSarQofli.IsSelect = false;
                    ucTamlic.IsSelect = false;
                }
                else if (type == EnRequestType.EjareTamlik)
                {
                    ucForoush.IsSelect = false;
                    ucRahnEjare.IsSelect = false;
                    ucPishForosh.IsSelect = false;
                    ucSarQofli.IsSelect = false;
                    ucTamlic.IsSelect = true;
                }
                else if (type == EnRequestType.Sarqofli)
                {
                    ucForoush.IsSelect = false;
                    ucRahnEjare.IsSelect = false;
                    ucPishForosh.IsSelect = false;
                    ucSarQofli.IsSelect = true;
                    ucTamlic.IsSelect = false;
                }
                else if (type == EnRequestType.PishForush)
                {
                    ucForoush.IsSelect = false;
                    ucRahnEjare.IsSelect = false;
                    ucPishForosh.IsSelect = true;
                    ucSarQofli.IsSelect = false;
                    ucTamlic.IsSelect = false;
                }
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
                SetIsSelect(EnRequestType.Forush);
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
        private async void frmContractTypeSelector_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        DialogResult = DialogResult.Cancel;
                        Close();
                        break;
                    case Keys.F1: await ucForoush_OnClick(ucForoush); break;
                    case Keys.F2: await ucRahnEjare_OnClick(ucRahnEjare); break;
                    case Keys.F3: await ucTamlic_OnClick(ucTamlic); break;
                    case Keys.F4: await ucSarQofli_OnClick(ucSarQofli); break;
                    case Keys.F5: await ucPishForosh_OnClick(ucPishForosh); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ucRahnEjare_OnClick(WindowsSerivces.UcButton arg)
        {
            try
            {
                SetIsSelect(EnRequestType.Rahn);
                await Task.Delay(100);
                var frm = new frmContractMain_Rahn(new ContractBussines());
                DialogResult = frm.ShowDialog(this);
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ucTamlic_OnClick(WindowsSerivces.UcButton arg)
        {
            try
            {
                SetIsSelect(EnRequestType.EjareTamlik);
                await Task.Delay(100);
                var frm = new frmContractMain_EjareTamlik(new ContractBussines());
                DialogResult = frm.ShowDialog(this);
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ucSarQofli_OnClick(WindowsSerivces.UcButton arg)
        {
            try
            {
                SetIsSelect(EnRequestType.Sarqofli);
                await Task.Delay(100);
                var frm = new frmContractMain_Sarqofli(new ContractBussines());
                DialogResult = frm.ShowDialog(this);
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task ucPishForosh_OnClick(WindowsSerivces.UcButton arg)
        {
            try
            {
                SetIsSelect(EnRequestType.PishForush);
                await Task.Delay(100);
                var frm = new frmContractMain_PishForoush(new ContractBussines());
                DialogResult = frm.ShowDialog(this);
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
