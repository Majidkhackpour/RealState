using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuilding : IBuilding
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string Code { get; set; }
        public Guid OwnerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SellPrice { get; set; }
        public decimal VamPrice { get; set; }
        public decimal QestPrice { get; set; }
        public int Dang { get; set; }
        public Guid? DocumentType { get; set; }
        public EnTarakom? Tarakom { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public bool? IsShortTime { get; set; }
        public bool? IsOwnerHere { get; set; }
        public decimal PishTotalPrice { get; set; }
        public decimal PishPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string PishDesc { get; set; }
        public string MoavezeDesc { get; set; }
        public string MosharekatDesc { get; set; }
        public int Masahat { get; set; }
        public int ZirBana { get; set; }
        public Guid CityGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string Address { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public EnBuildingSide Side { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid BuildingViewGuid { get; set; }
        public Guid FloorCoverGuid { get; set; }
        public Guid KitchenServiceGuid { get; set; }
        public EnKhadamati Water { get; set; }
        public EnKhadamati Barq { get; set; }
        public EnKhadamati Gas { get; set; }
        public EnKhadamati Tell { get; set; }
        public int TedadTabaqe { get; set; }
        public int TabaqeNo { get; set; }
        public int VahedPerTabaqe { get; set; }
        public float MetrazhKouche { get; set; }
        public float ErtefaSaqf { get; set; }
        public float Hashie { get; set; }
        public string SaleSakht { get; set; }
        public string DateParvane { get; set; }
        public string ParvaneSerial { get; set; }
        public bool BonBast { get; set; }
        public bool MamarJoda { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingStatus BuildingStatus { get; set; }
        public string Image { get; set; }


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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebBuilding()
                {
                    Guid = cls.Guid,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    Masahat = cls.Masahat,
                    RegionGuid = cls.RegionGuid,
                    Code = cls.Code,
                    EjarePrice1 = cls.EjarePrice1,
                    RahnPrice1 = cls.RahnPrice1,
                    SellPrice = cls.SellPrice,
                    RoomCount = cls.RoomCount,
                    BuildingStatus = cls.BuildingStatus,
                    //GalleryList = cls.GalleryList,
                    ZirBana = cls.ZirBana,
                    BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                    //OptionList = cls.OptionList,
                    UserGuid = cls.UserGuid,
                    Address = cls.Address,
                    BuildingTypeGuid = cls.BuildingTypeGuid,
                    SaleSakht = cls.SaleSakht,
                    OwnerGuid = cls.OwnerGuid,
                    //RegionName = cls.RegionName,
                    EjarePrice2 = cls.EjarePrice2,
                    RentalAutorityGuid = cls.RentalAutorityGuid,
                    Tell = cls.Tell,
                    TedadTabaqe = cls.TedadTabaqe,
                    CityGuid = cls.CityGuid,
                    TabaqeNo = cls.TabaqeNo,
                    ShortDesc = cls.ShortDesc,
                    CreateDate = cls.CreateDate,
                    RahnPrice2 = cls.RahnPrice2,
                    VahedPerTabaqe = cls.VahedPerTabaqe,
                    DocumentType = cls.DocumentType,
                    Dang = cls.Dang,
                    FloorCoverGuid = cls.FloorCoverGuid,
                    KitchenServiceGuid = cls.KitchenServiceGuid,
                    PishTotalPrice = cls.PishTotalPrice,
                    PishPrice = cls.PishPrice,
                    Water = cls.Water,
                    MosharekatDesc = cls.MosharekatDesc,
                    ParvaneSerial = cls.ParvaneSerial,
                    MoavezeDesc = cls.MoavezeDesc,
                    MamarJoda = cls.MamarJoda,
                    QestPrice = cls.QestPrice,
                    PishDesc = cls.PishDesc,
                    IsOwnerHere = cls.IsOwnerHere,
                    DeliveryDate = cls.DeliveryDate,
                    BuildingConditionGuid = cls.BuildingConditionGuid,
                    Side = cls.Side,
                    Hashie = cls.Hashie,
                    VamPrice = cls.VamPrice,
                    ErtefaSaqf = cls.ErtefaSaqf,
                    MetrazhKouche = cls.MetrazhKouche,
                    BonBast = cls.BonBast,
                    MetrazhTejari = cls.MetrazhTejari,
                    IsShortTime = cls.IsShortTime,
                    Tarakom = cls.Tarakom,
                    BuildingViewGuid = cls.BuildingViewGuid,
                    Barq = cls.Barq,
                    Gas = cls.Gas,
                    DateParvane = cls.DateParvane
                    //UserName = cls.UserName,
                    //BuildingAccountTypeName = cls.BuildingAccountTypeName,
                    //RentalAuthorityName = cls.RentalAuthorityName,
                    //OwnerName = cls.OwnerName,
                    //BuildingTypeName = cls.BuildingTypeName
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<BuildingBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                {
                    var obj = new WebBuilding()
                    {
                        Guid = cls.Guid,
                        Modified = cls.Modified,
                        Status = cls.Status,
                        Masahat = cls.Masahat,
                        RegionGuid = cls.RegionGuid,
                        Code = cls.Code,
                        EjarePrice1 = cls.EjarePrice1,
                        RahnPrice1 = cls.RahnPrice1,
                        SellPrice = cls.SellPrice,
                        RoomCount = cls.RoomCount,
                        BuildingStatus = cls.BuildingStatus,
                        //GalleryList = cls.GalleryList,
                        ZirBana = cls.ZirBana,
                        BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                        //OptionList = cls.OptionList,
                        UserGuid = cls.UserGuid,
                        Address = cls.Address,
                        BuildingTypeGuid = cls.BuildingTypeGuid,
                        SaleSakht = cls.SaleSakht,
                        OwnerGuid = cls.OwnerGuid,
                        //RegionName = cls.RegionName,
                        EjarePrice2 = cls.EjarePrice2,
                        RentalAutorityGuid = cls.RentalAutorityGuid,
                        Tell = cls.Tell,
                        TedadTabaqe = cls.TedadTabaqe,
                        CityGuid = cls.CityGuid,
                        TabaqeNo = cls.TabaqeNo,
                        ShortDesc = cls.ShortDesc,
                        CreateDate = cls.CreateDate,
                        RahnPrice2 = cls.RahnPrice2,
                        VahedPerTabaqe = cls.VahedPerTabaqe,
                        DocumentType = cls.DocumentType,
                        Dang = cls.Dang,
                        FloorCoverGuid = cls.FloorCoverGuid,
                        KitchenServiceGuid = cls.KitchenServiceGuid,
                        PishTotalPrice = cls.PishTotalPrice,
                        PishPrice = cls.PishPrice,
                        Water = cls.Water,
                        MosharekatDesc = cls.MosharekatDesc,
                        ParvaneSerial = cls.ParvaneSerial,
                        MoavezeDesc = cls.MoavezeDesc,
                        MamarJoda = cls.MamarJoda,
                        QestPrice = cls.QestPrice,
                        PishDesc = cls.PishDesc,
                        IsOwnerHere = cls.IsOwnerHere,
                        DeliveryDate = cls.DeliveryDate,
                        BuildingConditionGuid = cls.BuildingConditionGuid,
                        Side = cls.Side,
                        Hashie = cls.Hashie,
                        VamPrice = cls.VamPrice,
                        ErtefaSaqf = cls.ErtefaSaqf,
                        MetrazhKouche = cls.MetrazhKouche,
                        BonBast = cls.BonBast,
                        MetrazhTejari = cls.MetrazhTejari,
                        IsShortTime = cls.IsShortTime,
                        Tarakom = cls.Tarakom,
                        BuildingViewGuid = cls.BuildingViewGuid,
                        Barq = cls.Barq,
                        Gas = cls.Gas,
                        DateParvane = cls.DateParvane
                        //UserName = cls.UserName,
                        //BuildingAccountTypeName = cls.BuildingAccountTypeName,
                        //RentalAuthorityName = cls.RentalAuthorityName,
                        //OwnerName = cls.OwnerName,
                        //BuildingTypeName = cls.BuildingTypeName
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
