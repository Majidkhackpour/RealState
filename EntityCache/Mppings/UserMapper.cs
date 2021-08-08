using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class UserMapper
    {
        public static UserMapper Instance { get; private set; } = new UserMapper();
        public WebUser Map(UserBussines cls)
        {
            return new WebUser()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                Access = cls.Access,
                Email = cls.Email,
                Mobile = cls.Mobile,
                UserName = cls.UserName,
                AnswerQuestion = cls.AnswerQuestion,
                SecurityQuestion = cls.SecurityQuestion,
                Password = cls.Password,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
