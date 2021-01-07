using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebPhoneBook : IPhoneBook
    {
        private static string Url = Utilities.WebApi + "/api/BuildingPhoneBook/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Tell { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public Guid ParentGuid { get; set; }
        public string HardSerial { get; set; }



        public async Task SaveAsync()
        {
            try
            {
                await Extentions.PostToApi<PhoneBookBussines, WebPhoneBook>(this, Url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(PhoneBookBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebPhoneBook()
                {
                    Guid = cls.Guid,
                    Name = cls.Name,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    HardSerial = cls.HardSerial,
                    ParentGuid = cls.ParentGuid,
                    Tell = cls.Tell,
                    Group = cls.Group
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<PhoneBookBussines> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                {
                    var obj = new WebPhoneBook()
                    {
                        Guid = item.Guid,
                        Name = item.Name,
                        Modified = item.Modified,
                        Status = item.Status,
                        HardSerial = item.HardSerial,
                        ParentGuid = item.ParentGuid,
                        Tell = item.Tell,
                        Group = item.Group
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
