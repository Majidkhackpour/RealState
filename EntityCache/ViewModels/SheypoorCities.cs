using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketParser.Interfaces;

namespace EntityCache.ViewModels
{
    class SheypoorCities : IHasGuid
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        private string Name { get; set; }
    }
}
