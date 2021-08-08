using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingAccountTypeMapper
    {
        public static BuildingAccountTypeMapper Instance { get; private set; } = new BuildingAccountTypeMapper();
        public WebBuildingAccountType Map(BuildingAccountTypeBussines cls)
        {
            return new WebBuildingAccountType()
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
