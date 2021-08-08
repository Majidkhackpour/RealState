using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingTypeMapper
    {
        public static BuildingTypeMapper Instance { get; private set; } = new BuildingTypeMapper();
        public WebBuildingType Map(BuildingTypeBussines cls)
        {
            return new WebBuildingType()
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
