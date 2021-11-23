using System;
using System.Windows.Forms;

namespace Building.UserControls.Contract.Public
{
    public partial class UcContractHeader : UserControl
    {
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public long ContractCode { get => ucSerial1.ContractCode; set => ucSerial1.ContractCode = value; }
        public string CodeInArchive { get => ucSerial1.CodeInArchive; set => ucSerial1.CodeInArchive = value; }
        public string RealStateCode { get => ucSerial1.RealStateCode; set => ucSerial1.RealStateCode = value; }
        public string HologramCode { get => ucSerial1.HologramCode; set => ucSerial1.HologramCode = value; }
        public DateTime ContractDate { get => ucSerial1.ContractDate; set => ucSerial1.ContractDate = value; }
        public UcContractHeader() => InitializeComponent();
    }
}
