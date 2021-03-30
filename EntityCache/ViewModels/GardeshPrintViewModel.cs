using System;
using Services;

namespace EntityCache.ViewModels
{
    public class GardeshPrintViewModel
    {
        public string PrintDateSh { get; set; }
        public string TafsilCode { get; set; }
        public string TafsilName { get; set; }
        public string DateSh { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Rem => Math.Abs(Rem_);
        public decimal Rem_ { get; set; }
        public string RemDiag => Rem_.AccountDiagnosisForPrint();
        public decimal SumDebit { get; set; }
        public decimal SumCredit { get; set; }
        public decimal Total => Math.Abs(Total_);
        public decimal Total_ => SumCredit - SumDebit;
        public string TotalDiag => Total_.AccountDiagnosisForPrint();
        public DateTime DateM { get; set; }
    }
}
