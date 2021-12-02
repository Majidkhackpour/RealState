using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Public
{
    public partial class UcContractHeader : UserControl
    {
        public event Action<string> OnDateChanged;
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public long ContractCode { get => ucSerial1.ContractCode; set => ucSerial1.ContractCode = value; }
        public string CodeInArchive { get => ucSerial1.CodeInArchive; set => ucSerial1.CodeInArchive = value; }
        public string RealStateCode { get => ucSerial1.RealStateCode; set => ucSerial1.RealStateCode = value; }
        public string HologramCode { get => ucSerial1.HologramCode; set => ucSerial1.HologramCode = value; }
        public DateTime ContractDate { get => ucSerial1.ContractDate; set => ucSerial1.ContractDate = value; }
        public UcContractHeader()
        {
            InitializeComponent();
            ucSerial1.OnDateChanged+=UcSerial1OnOnDateChanged;
        }
        private void UcSerial1OnOnDateChanged(string date) => RaiseDateChange(date);
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
