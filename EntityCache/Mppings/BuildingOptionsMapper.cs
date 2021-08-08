using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingOptionsMapper
    {
        public static BuildingOptionsMapper Instance { get; private set; } = new BuildingOptionsMapper();
        public WebBuildingOptions Map(BuildingOptionsBussines cls)
        {
            return new WebBuildingOptions()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
