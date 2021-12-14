using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Rahn
{
    public partial class UcContractRahn_3 : UserControl
    {
        public event Action<string> OnDischargeChanged;
        public DateTime? FromDate { get => Calendar.ShamsiToMiladi(ucFromDate.DateSh); set => ucFromDate.DateSh = Calendar.MiladiToShamsi(value); }
        public int Term { get => (int)txtTerm.Value; set => txtTerm.Value = value; }
        public string ContractDateSh { get => lblContractDate.Text; set => lblContractDate.Text = value; }
        public DateTime? DischargeDate { get => Calendar.ShamsiToMiladi(ucDischargeDate.DateSh); set => ucDischargeDate.DateSh = Calendar.MiladiToShamsi(value); }
        public UcContractRahn_3()
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
        private void txtTerm_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetMaxDate();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void ucFromDate_OnDateChanged(string obj)
        {
            try
            {
                SetMaxDate();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetMaxDate()
        {
            try
            {
                if (FromDate != null)
                    lblToDate.Text = Calendar.MiladiToShamsi(FromDate.Value.AddMonths((int)txtTerm.Value));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
