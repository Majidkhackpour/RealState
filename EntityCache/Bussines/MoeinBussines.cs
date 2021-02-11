using System;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class MoeinBussines : IMoein
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid KolGuid { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public decimal Account { get; set; }
    }
}
