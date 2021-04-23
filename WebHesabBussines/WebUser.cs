using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebUser : IUsers
    {
        private static string Url = Utilities.WebApi + "/api/BuildingUser/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
        public EnSecurityQuestion SecurityQuestion { get; set; }
        public string AnswerQuestion { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string HardSerial { get; set; }


        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<UserBussines, WebUser>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Users
                    };
                    await temp.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(UserBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebUser()
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
                    HardSerial = cls.HardSerial
                };
                await obj.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<UserBussines> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                {
                    var obj = new WebUser()
                    {
                        Guid = item.Guid,
                        Name = item.Name,
                        Modified = item.Modified,
                        Status = item.Status,
                        Access = item.Access,
                        Email = item.Email,
                        Mobile = item.Mobile,
                        UserName = item.UserName,
                        AnswerQuestion = item.AnswerQuestion,
                        SecurityQuestion = item.SecurityQuestion,
                        Password = item.Password,
                        HardSerial = item.HardSerial
                    };
                    await obj.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
