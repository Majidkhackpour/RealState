using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public  class BuildingRelatedOptionMapper
    {
        public static BuildingRelatedOptionMapper Instance { get; private set; } = new BuildingRelatedOptionMapper();
        public WebBuildingRelatedOptions Map(BuildingRelatedOptionsBussines cls)
        {
            return new WebBuildingRelatedOptions()
            {
                Guid = cls.Guid,
                HardSerial = cls.HardSerial,
                BuildingOptionGuid = cls.BuildingOptionGuid,
                BuildinGuid = cls.BuildinGuid,
                Modified = cls.Modified,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
