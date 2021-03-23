using System;
using Services;

namespace EntityCache.ViewModels
{
    public class PardakhtCheckViewModel
    {
        public Guid Guid { get; set; }
        public string BankName { get; set; }
        public Guid BankGuid { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public DateTime DateSarResid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarResid);
        public string Description { get; set; }
        public string CheckNumber { get; set; }
        public decimal Price { get; set; }
        public EnCheckSh CheckStatus { get; set; }
        public string StatusName => CheckStatus.GetDisplay();
        public string Girande { get; set; }
        public Guid GirandeGuid { get; set; }
        public bool IsAvalDore { get; set; }
    }
}
