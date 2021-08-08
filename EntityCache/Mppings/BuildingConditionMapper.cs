using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingConditionMapper
    {
        public static BuildingConditionMapper Instance { get; private set; } = new BuildingConditionMapper();
        public WebBuildingCondition Map(BuildingConditionBussines cls)
        {
            return new WebBuildingCondition()
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
