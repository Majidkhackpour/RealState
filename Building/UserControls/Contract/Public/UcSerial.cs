using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Contract.Public
{
    public partial class UcSerial : UserControl
    {
        public event Action<string> OnDateChanged;
        public long ContractCode => txtCode.Text.ParseToLong();
        public async Task SetContractCodeAsync(long value)
        {
            try
            {
                var code = await ContractBussines.NextCodeAsync();
                txtCode.Text = value <= 0 ? code : value.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public string CodeInArchive { get => txtCodeInArchive.Text; set => txtCodeInArchive.Text = value; }
        public string RealStateCode { get => txtRealStateCode.Text; set => txtRealStateCode.Text = value; }
        public string HologramCode { get => txtHologramCode.Text; set => txtHologramCode.Text = value; }
        public DateTime ContractDate { get => Calendar.ShamsiToMiladi(ucDate1.DateSh); set => ucDate1.DateSh = Calendar.MiladiToShamsi(value); }
        public UcSerial()
        {
            InitializeComponent();
            ucDate1.OnDateChanged += UcDate1OnOnDateChanged;
        }
        private void UcDate1OnOnDateChanged(string date) => RaiseDateChange(date);
        private void RaiseDateChange(string date)
        {
            try
            {
                var handler = OnDateChanged;
                if (handler != null) OnDateChanged?.Invoke(date);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
