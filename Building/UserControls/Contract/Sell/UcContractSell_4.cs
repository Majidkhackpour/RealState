using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Sell
{
    public partial class UcContractSell_4 : UserControl
    {
        public event Action<string> OnDischargeChanged;
        public DateTime? SetDocDate { get => Calendar.ShamsiToMiladi(ucSetDocDate.DateSh); set => ucSetDocDate.DateSh = Calendar.MiladiToShamsi(value); }
        public int SetDocNo { get => (int)txtSetDocNo.Value; set => txtSetDocNo.Value = value; }
        public string SetDocPlace { get => txtSetDocPlace.Text; set => txtSetDocPlace.Text = value; }
        public string ContractDateSh { get => lblContractDate.Text; set => lblContractDate.Text = value; }
        public DateTime? DischargeDate { get => Calendar.ShamsiToMiladi(ucDischargeDate.DateSh); set => ucDischargeDate.DateSh = Calendar.MiladiToShamsi(value); }
        public UcContractSell_4()
        {
            InitializeComponent();
            ucDischargeDate.OnDateChanged += UcDischargeDate_OnDateChanged;
        }
        private void UcDischargeDate_OnDateChanged(string date) => RaiseDischargeChanged(date);
        private void RaiseDischargeChanged(string date)
        {
            try
            {
                var handler = OnDischargeChanged;
                if (handler != null) OnDischargeChanged?.Invoke(date);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
