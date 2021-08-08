using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.Interfaces.Building;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebPardakht :IPardakht
    {
        private static string Url = Utilities.WebApi + "/api/BuildingPardakht/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public Guid TafsilGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public Guid UserGuid { get; set; }
        public long Number { get; set; }
        public long SanadNumber { get; set; }
        public decimal SumCheckMoshtari { get; set; }
        public decimal SumCheckShakhsi { get; set; }
        public decimal SumHavale { get; set; }
        public decimal SumNaqd { get; set; }
        public decimal Sum { get; set; }
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
                var res = await Extentions.PostToApi<PardakhtBussines, WebPardakht>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Pardakht
                    };
                    await temp.SaveAsync();
                    return;
                }
                var bu = res.Data;
                if (bu == null) return;
                await TempBussines.UpdateEntityAsync(EnTemp.Pardakht, bu.Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebPardakht()
                {
                    Guid = cls.Guid,
                    Modified = cls.Modified,
                    HardSerial = cls.HardSerial,
                    ServerStatus = cls.ServerStatus,
                    ServerDeliveryDate = cls.ServerDeliveryDate,
                    Description = cls.Description,
                    DateM = cls.DateM,
                    Number = cls.Number,
                    UserGuid = cls.UserGuid,
                    SanadNumber = cls.SanadNumber,
                    TafsilGuid = cls.TafsilGuid,
                    MoeinGuid = cls.MoeinGuid,
                    SumHavale = cls.SumHavale,
                    SumNaqd = cls.SumNaqd,
                    SumCheckMoshtari = cls.SumCheckMoshtari,
                    Sum = cls.Sum,
                    SumCheckShakhsi = cls.SumCheckShakhsi
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<PardakhtBussines> cls)
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
