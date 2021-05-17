using System;

namespace EntityCache.ViewModels
{
    public class TarazHesabViewModel
    {
        public Guid KolGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        public Guid TafsilGuid { get; set; }
        public long Code { get; set; }
        public decimal Account { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal SD_Debit { get; set; }
        public decimal SD_Credit { get; set; }
        public decimal DD_Debit { get; set; }
        public decimal DD_Credit { get; set; }
        public decimal ED_Debit { get; set; }
        public decimal ED_Credit { get; set; }
        public decimal RemPayan2ReDebit { get; set; }
        public decimal RemPayan2ReCredit { get; set; }
        public string TafsilName { get; set; }
        public long TafsilCode { get; set; }
        public string MoeinName { get; set; }
        public long MoeinCode { get; set; }
    }
}
