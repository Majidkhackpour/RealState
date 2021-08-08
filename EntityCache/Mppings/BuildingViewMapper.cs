using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingViewMapper
    {
        public static BuildingViewMapper Instance { get; private set; } = new BuildingViewMapper();
        public WebBuildingView Map(BuildingViewBussines cls)
        {
            return new WebBuildingView()
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
