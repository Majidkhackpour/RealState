using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Sarqofli
{
    public partial class UcContractSarqofli_5 : UserControl
    {
        public DateTime? DischargeDate { get => Calendar.ShamsiToMiladi(ucDischargeDate.DateSh); set => ucDischargeDate.DateSh = Calendar.MiladiToShamsi(value); }
        public decimal AmountOfRent { get => txtAmountOfRent.TextDecimal; set => txtAmountOfRent.TextDecimal = value; }
        public UcContractSarqofli_5() => InitializeComponent();
    }
}
