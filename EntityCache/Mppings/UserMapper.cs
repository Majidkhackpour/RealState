using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
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
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebUser> MapList(List<UserBussines> cls)
        {
            var list = new List<WebUser>();
            try
            {
                foreach (var item in cls)
                    list.Add(Map(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
