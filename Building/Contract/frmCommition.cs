using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Building.UserControls.Contract.Public;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Contract
{
    public partial class frmCommition : MetroForm
    {
        private ContractBussines _con;
        private async Task SetDataAsync()
        {
            try
            {
                ucTotalCommition1.FirstTitle = "کمیسیون طرف اول";
                ucTotalCommition1.SecondTitle = "کمیسیون طرف دوم";
                if (_con.IsModified && (_con.FirstTotalPrice != 0 || _con.SecondTotalPrice != 0))
                {
                    ucTotalCommition1.FirstTotalPrice = _con.FirstTotalPrice;
                    ucTotalCommition1.FirstBabat = _con.fBabat;
                    ucTotalCommition1.FirstDiscount = _con.FirstDiscount;
                    ucTotalCommition1.FirstTax = _con.FirstTax;
                    ucTotalCommition1.FirstAvarez = _con.FirstAvarez;

                    ucTotalCommition1.SecondTotalPrice = _con.SecondTotalPrice;
                    ucTotalCommition1.SecondBabat = _con.sBabat;
                    ucTotalCommition1.SecondDiscount = _con.SecondDiscount;
                    ucTotalCommition1.SecondTax = _con.SecondTax;
                    ucTotalCommition1.SecondAvarez = _con.SecondAvarez;
                }
                else CalculateCommition();

                await UcV1.SetBazaryabGuidAsync(_con.BazaryabGuid);
                await UcV2.SetBazaryabGuidAsync(_con.Bazaryab2Guid);
                UcV1.Price = _con.BazaryabPrice;
                UcV2.Price = _con.Bazaryab2Price;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void CalculateCommition()
        {
            try
            {
                decimal commition = 0;
                if (_con.Type == EnRequestType.Rahn)
                {
                    var tabdilPercent = SettingsBussines.Setting.SafeBox.Tabdil;
                    commition = Contract.CalculateCommition.CalculateEjare(_con.TotalPrice, _con.MinorPrice, (int) tabdilPercent);
                    ucTotalCommition1.FirstBabat = EnContractBabat.Ejare;
                    ucTotalCommition1.SecondBabat = EnContractBabat.Ejare;
                }
                else if (_con.Type == EnRequestType.Forush)
                {
                    commition = Contract.CalculateCommition.CalculateKharid(_con.TotalPrice);
                    ucTotalCommition1.FirstBabat = EnContractBabat.Foroush;
                    ucTotalCommition1.SecondBabat = EnContractBabat.Foroush;
                }

                ucTotalCommition1.FirstTotalPrice = commition;
                ucTotalCommition1.SecondTotalPrice = commition;

                var arzehPercent = SettingsBussines.Setting.SafeBox.ArzeshAfzoude;
                var arzesh = (commition * (decimal) arzehPercent) / 100;

                ucTotalCommition1.FirstTax = arzesh;
                ucTotalCommition1.SecondTax = arzesh;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmCommition(ContractBussines contract, bool isShow)
        {
            try
            {
                InitializeComponent();
                _con = contract;
                if (!isShow)
                    ucTotalCommition1.OnSumChanged += UcTotalCommition1_OnSumChanged;
                else
                {
                    ucContractVisitor1.Enabled = false;
                    ucTotalCommition1.Enabled = false;
                    UcV1.Enabled = UcV2.Enabled = false;
                    ucAccept.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        private void UcTotalCommition1_OnSumChanged(decimal sum)
        {
            try
            {
                UcV1.TotalPrice = sum;
                UcV2.TotalPrice = sum;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmCommition_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (_con == null)
                {
                    this.ShowWarning("قرارداد مورد نظر یافت نشد");
                    return;
                }

                await SetDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmCommition_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5: ucAccept.PerformClick(); break;
                    case Keys.Escape: ucCancel.PerformClick(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task ucCancel_OnClick(object arg1, EventArgs arg2)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return Task.CompletedTask;
        }
        private Task ucAccept_OnClick(object arg1, EventArgs arg2)
        {
            try
            {
                _con.FirstTotalPrice = ucTotalCommition1.FirstTotalPrice;
                _con.fBabat = ucTotalCommition1.FirstBabat;
                _con.FirstDiscount = ucTotalCommition1.FirstDiscount;
                _con.FirstTax = ucTotalCommition1.FirstTax;
                _con.FirstAvarez = ucTotalCommition1.FirstAvarez;

                _con.SecondTotalPrice = ucTotalCommition1.SecondTotalPrice;
                _con.sBabat = ucTotalCommition1.SecondBabat;
                _con.SecondDiscount = ucTotalCommition1.SecondDiscount;
                _con.SecondTax = ucTotalCommition1.SecondTax;
                _con.SecondAvarez = ucTotalCommition1.SecondAvarez;

                if (UcV1.BazatyabGuid != null && UcV1.BazatyabGuid != Guid.Empty)
                {
                    _con.BazaryabGuid = UcV1.BazatyabGuid;
                    _con.BazaryabPrice = UcV1.Price;
                }
                if (UcV2.BazatyabGuid != null && UcV2.BazatyabGuid != Guid.Empty)
                {
                    _con.Bazaryab2Guid = UcV2.BazatyabGuid;
                    _con.Bazaryab2Price = UcV2.Price;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
        private Task ucHelp_OnClick(object arg1, EventArgs arg2)
        {
            try
            {
                var frm=new frmHelpCalculateCommition();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
    }
}
