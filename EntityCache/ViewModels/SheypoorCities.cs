using System;
using Servicess.Interfaces;

namespace EntityCache.ViewModels
{
    public class SheypoorCities : IHasGuid
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
    }
}
