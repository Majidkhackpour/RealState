using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Sarqofli
{
    public partial class UcContractSarqofli_4 : UserControl
    {
        public DateTime? SetDocDate { get => Calendar.ShamsiToMiladi(ucSetDocDate.DateSh); set => ucSetDocDate.DateSh = Calendar.MiladiToShamsi(value); }
        public int SetDocNo { get => (int)txtSetDocNo.Value; set => txtSetDocNo.Value = value; }
        public string SetDocPlace { get => txtSetDocPlace.Text; set => txtSetDocPlace.Text = value; }
        public UcContractSarqofli_4() => InitializeComponent();
    }
}
