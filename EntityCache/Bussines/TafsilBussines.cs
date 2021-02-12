using System;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class TafsilBussines : ITafsil
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public DateTime DateM { get; set; }
        public decimal Account { get; set; }
        public bool isSystem { get; set; }
    }
}
