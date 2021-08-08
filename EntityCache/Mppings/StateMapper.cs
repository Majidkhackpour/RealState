using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class StateMapper
    {
        public static StateMapper Instance { get; private set; } = new StateMapper();
        public WebStates Map(StatesBussines cls)
        {
            return new WebStates()
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
