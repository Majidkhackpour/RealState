using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingRequestRegionMapper
    {
        public static BuildingRequestRegionMapper Instance { get; private set; } = new BuildingRequestRegionMapper();
        public WebBuildingRequestRegion Map(BuildingRequestRegionBussines cls)
        {
            return new WebBuildingRequestRegion()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                HardSerial = cls.HardSerial,
                RegionGuid = cls.RegionGuid,
                RequestGuid = cls.RequestGuid,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
