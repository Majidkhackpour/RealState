using Services.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class PardakhtCheckMoshtariBussines : IPardakhtCheckMoshtari
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public Guid CheckGuid { get; set; }
        public Guid MasterGuid { get; set; }
        public decimal Price { get; set; }
    }
}
