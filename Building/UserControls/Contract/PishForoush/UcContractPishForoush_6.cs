using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.PishForoush
{
    public partial class UcContractPishForoush_6 : UserControl
    {
        public decimal FirstDelay { get => ucFirstDelay.Price; set => ucFirstDelay.Price = value; }
        public decimal SecondDelay { get => ucSecondDelay.Price; set => ucSecondDelay.Price = value; }
        public string ManufacturingLicensePlace { get => txtManuPlace.Text; set => txtManuPlace.Text = value; }
        public DateTime? ManufacturingLicenseDate { get => Calendar.ShamsiToMiladi(ucManuDate.DateSh); set => ucManuDate.DateSh = Calendar.MiladiToShamsi(value); }
        public UcContractPishForoush_6() => InitializeComponent();
    }
}
