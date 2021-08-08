using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingMapper
    {
        public static BuildingMapper Instance { get; private set; } = new BuildingMapper();
        public WebBuilding Map(BuildingBussines cls)
        {
            return new WebBuilding()
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
                Priority = cls.Priority,
                IsArchive = cls.IsArchive,
                GalleryList = cls.GalleryList,
                ZirBana = cls.ZirBana,
                BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                OptionList = cls.OptionList,
                UserGuid = cls.UserGuid,
                Address = cls.Address,
                BuildingTypeGuid = cls.BuildingTypeGuid,
                SaleSakht = cls.SaleSakht,
                OwnerGuid = cls.OwnerGuid,
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
                DateParvane = cls.DateParvane,
                HardSerial = cls.HardSerial,
                Image = cls.Image,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
