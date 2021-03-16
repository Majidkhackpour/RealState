using System;
using Services;

namespace EntityCache.ViewModels
{
    public class ReceptionCheckViewModel
    {
        public Guid Guid { get; set; }
        public string BankName { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public DateTime DateSarResid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarResid);
        public Guid MasterGuid { get; set; }
        public string Description { get; set; }
        public string CheckNumber { get; set; }
        public string PoshtNomre { get; set; }
        public decimal Price { get; set; }
        public EnCheckM CheckStatus { get; set; }
        public string StatusName => CheckStatus.GetDisplay();
        public string SandouqTafsilName { get; set; }
        public string Pardazande { get; set; }
    }
}
