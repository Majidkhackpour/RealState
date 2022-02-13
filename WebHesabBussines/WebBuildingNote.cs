using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using Services.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuildingNote : IBuildingNote
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingGuid { get; set; }
        public string Note { get; set; }
    }
}
