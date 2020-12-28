using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuildingRequest : IBuildingRequest
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid AskerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SellPrice1 { get; set; }
        public decimal SellPrice2 { get; set; }
        public bool? HasVam { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public short? PeopleCount { get; set; }
        public bool? HasOwner { get; set; }
        public bool? ShortDate { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public Guid CityGuid { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public int Masahat1 { get; set; }
        public int Masahat2 { get; set; }
        public int RoomCount { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public string ShortDesc { get; set; }

        public async Task<ReturnedSaveFuncInfo> SaveAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                //using (var client = new HttpClient())
                //{
                //    var json = Json.ToStringJson(cls);
                //    var content = new StringContent(json, Encoding.UTF8, "application/json");
                //    var result = await client.PostAsync(Utilities.WebApi + "/api/Order/SaveAsync", content);
                //}
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRequestBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebBuildingRequest()
                {
                    Guid = cls.Guid,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    EjarePrice1 = cls.EjarePrice1,
                    RahnPrice1 = cls.RahnPrice1,
                    RoomCount = cls.RoomCount,
                    BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                    UserGuid = cls.UserGuid,
                    BuildingTypeGuid = cls.BuildingTypeGuid,
                    EjarePrice2 = cls.EjarePrice2,
                    RentalAutorityGuid = cls.RentalAutorityGuid,
                    ShortDesc = cls.ShortDesc,
                    CityGuid = cls.CityGuid,
                    CreateDate = cls.CreateDate,
                    RahnPrice2 = cls.RahnPrice2,
                    SellPrice2 = cls.SellPrice2,
                    BuildingConditionGuid = cls.BuildingConditionGuid,
                    AskerGuid = cls.AskerGuid,
                    SellPrice1 = cls.SellPrice1,
                    Masahat1 = cls.Masahat1,
                    Masahat2 = cls.Masahat2,
                    PeopleCount = cls.PeopleCount,
                    ShortDate = cls.ShortDate,
                    HasVam = cls.HasVam,
                    HasOwner = cls.HasOwner
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<BuildingRequestBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                {
                    var obj = new WebBuildingRequest()
                    {
                        Guid = cls.Guid,
                        Modified = cls.Modified,
                        Status = cls.Status,
                        EjarePrice1 = cls.EjarePrice1,
                        RahnPrice1 = cls.RahnPrice1,
                        RoomCount = cls.RoomCount,
                        BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                        UserGuid = cls.UserGuid,
                        BuildingTypeGuid = cls.BuildingTypeGuid,
                        EjarePrice2 = cls.EjarePrice2,
                        RentalAutorityGuid = cls.RentalAutorityGuid,
                        ShortDesc = cls.ShortDesc,
                        CityGuid = cls.CityGuid,
                        CreateDate = cls.CreateDate,
                        RahnPrice2 = cls.RahnPrice2,
                        SellPrice2 = cls.SellPrice2,
                        BuildingConditionGuid = cls.BuildingConditionGuid,
                        AskerGuid = cls.AskerGuid,
                        SellPrice1 = cls.SellPrice1,
                        Masahat1 = cls.Masahat1,
                        Masahat2 = cls.Masahat2,
                        PeopleCount = cls.PeopleCount,
                        ShortDate = cls.ShortDate,
                        HasVam = cls.HasVam,
                        HasOwner = cls.HasOwner
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
