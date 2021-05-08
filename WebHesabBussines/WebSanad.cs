using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebSanad : ISanad
    {
        private static string Url = Utilities.WebApi + "/api/Sanad/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public long Number { get; set; }
        public EnSanadStatus SanadStatus { get; set; }
        public Guid UserGuid { get; set; }
        public EnSanadType SanadType { get; set; }
        public string HardSerial { get; set; }
        private List<SanadDetailBussines> DetList { get; set; }



        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<SanadBussines, WebSanad>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Sanad
                    };
                    await temp.SaveAsync();
                    return;
                }
                var bu = res.Data;
                if (bu == null) return;
                await TempBussines.UpdateEntityAsync(EnTemp.Sanad, bu.Guid, ServerStatus.Delivered, DateTime.Now);

                await WebSanadDetail.SaveAsync(DetList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(SanadBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebSanad()
                {
                    Guid = cls.Guid,
                    Modified = cls.Modified,
                    UserGuid = cls.UserGuid,
                    HardSerial = cls.HardSerial,
                    ServerStatus = cls.ServerStatus,
                    ServerDeliveryDate = cls.ServerDeliveryDate,
                    Description = cls.Description,
                    DateM = cls.DateM,
                    Number = cls.Number,
                    SanadType = cls.SanadType,
                    SanadStatus = cls.SanadStatus,
                    DetList = cls.Details
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<SanadBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                    res.AddReturnedValue(await SaveAsync(cls));
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
