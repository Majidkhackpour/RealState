using Services.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class PardakhtNaqdBussines : IPardakhtNaqd
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid SandouqTafsilGuid { get; set; }
        public Guid SandouqMoeinGuid { get; set; }
        public Guid MasterGuid { get; set; }
    }
}
