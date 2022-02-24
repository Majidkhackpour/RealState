using MetroFramework.Forms;
using Services;
using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace Building.Tools
{
    public partial class frmCommitionCalculator : MetroForm
    {
        public frmCommitionCalculator()
        {
            InitializeComponent();
            ucHeader.Text = "ابزار محاسبه گر کمیسیون";
            rbtnRahn.Checked = true;
        }

        private void rbtnRahn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!rbtnRahn.Checked) return;
                lblPrice1.Text = "مبلغ رهن:";
                lblPrice2.Visible = txtPrice2.Visible = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnSell_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!rbtnSell.Checked) return;
                lblPrice1.Text = "مبلغ فروش:";
                lblPrice2.Visible = txtPrice2.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private Task ucAccept_OnClick(object sender, EventArgs e)
        {
            try
            {
                decimal commition = 0;
                if (rbtnRahn.Checked)
                {
                    var tabdilPercent = SettingsBussines.Setting.SafeBox.Tabdil;
                    commition = Contract.CalculateCommition.CalculateEjare(txtPrice1.TextDecimal, txtPrice2.DeviceDpi, (int)tabdilPercent);
                    ucCommition1.Babat = EnContractBabat.Ejare;
                }
                else if (rbtnSell.Checked)
                {
                    commition = Contract.CalculateCommition.CalculateKharid(txtPrice1.TextDecimal);
                    ucCommition1.Babat = EnContractBabat.Foroush;
                }

                ucCommition1.TotalPrice = commition;

                var arzehPercent = SettingsBussines.Setting.SafeBox.ArzeshAfzoude;
                var arzesh = (commition * (decimal)arzehPercent) / 100;

                ucCommition1.Tax = arzesh;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return Task.CompletedTask;
        }
    }
}
