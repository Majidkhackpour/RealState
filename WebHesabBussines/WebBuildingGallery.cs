using Servicess.Interfaces.Building;
using System;

namespace WebHesabBussines
{
    public class WebBuildingGallery : IBuildingGallery
    {
        public Guid BuildingGuid { get; set; }
        public string ImageName { get; set; }
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
    }
}
