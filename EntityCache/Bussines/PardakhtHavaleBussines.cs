using Services.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class PardakhtHavaleBussines : IPardakhtHavale
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }
        public Guid BankTafsilGuid { get; set; }
        public Guid BankMoeinGuid { get; set; }
        public Guid MasterGuid { get; set; }
    }
}
