using System.Runtime.InteropServices;

namespace EntityCache.ViewModels
{
    public class SanadPrintViewModel
    {
        public string SanadDateSh { get; set; }
        public string SanadTime { get; set; }
        public string PrintDateSh { get; set; }
        public string PrintTime { get; set; }
        public long SanadNumber { get; set; }
        public string SanadDesc { get; set; }
        public string DetailDesc { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string UserName { get; set; }
        public decimal SumDebit { get; set; }
        public decimal SumCredit { get; set; }
    }
}
