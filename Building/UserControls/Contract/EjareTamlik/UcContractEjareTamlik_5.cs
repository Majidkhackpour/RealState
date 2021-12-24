using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.EjareTamlik
{
    public partial class UcContractEjareTamlik_5 : UserControl
    {
        public DateTime? SetDocDate { get => Calendar.ShamsiToMiladi(ucSetDocDate.DateSh); set => ucSetDocDate.DateSh = Calendar.MiladiToShamsi(value); }
        public int SetDocNo { get => (int)txtSetDocNo.Value; set => txtSetDocNo.Value = value; }
        public string SetDocPlace { get => txtSetDocPlace.Text; set => txtSetDocPlace.Text = value; }
        public string DocumentAsjust { get => txtDocAdjust.Text; set => txtDocAdjust.Value = value.ParseToDecimal(); }
        public decimal Delay { get => txtDelay.TextDecimal; set => txtDelay.TextDecimal = value; }
        public UcContractEjareTamlik_5() => InitializeComponent();
    }
}
