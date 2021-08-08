using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebTafsil : ITafsil
    {
        private static string Url = Utilities.WebApi + "/api/Tafsil/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;


        public Guid Guid { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public DateTime DateM { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public bool isSystem { get; set; }
        public string HardSerial { get; set; }



        private static void RaiseEvent(Guid objGuid, ServerStatus st, DateTime dateM)
        {
            var handler = OnSaveResult;
            if (handler != null)
                OnSaveResult(objGuid, st, dateM);
        }
        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<TafsilBussines, WebTafsil>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Tafsil
                    };
                    await temp.SaveAsync();
                    return;
                }
                var bu = res.Data;
                if (bu == null) return;
                await TempBussines.UpdateEntityAsync(EnTemp.Tafsil, bu.Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(TafsilBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebTafsil()
                {
                    Guid = cls.Guid,
                    Name = cls.Name,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    HardSerial = cls.HardSerial,
                    ServerStatus = cls.ServerStatus,
                    ServerDeliveryDate = cls.ServerDeliveryDate,
                    Description = cls.Description,
                    HesabType = cls.HesabType,
                    AccountFirst = cls.AccountFirst,
                    Code = cls.Code,
                    Account = cls.Account,
                    DateM = cls.DateM,
                    isSystem = cls.isSystem
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<TafsilBussines> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                    res.AddReturnedValue(await SaveAsync(item));
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
