using Advertise.Classes;
using EntityCache.Bussines;
using Notification;
using Services;
using Settings.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHesabBussines;

namespace RealState
{
    public class DivarFiles
    {
        public static void Init() => _ = Task.Run(GetFilesFromDivarAsync);
        private static async Task GetFilesFromDivarAsync()
        {
            try
            {
                return;
                if (!VersionAccess.Advertise) return;
                //if (!clsAdvertise.IsGiveFile) return;
                if (WebCustomer.Customer == null ||
                    WebCustomer.Customer.isBlock ||
                    WebCustomer.Customer.isWebServiceBlock)
                    return;

                var getDate = clsAdvertise.GetFileDate ?? DateTime.Now.AddDays(-7);
                var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                if (getDate != null && getDate > newDate) return;

                var insertedDate = new DateTime(getDate.Year, getDate.Month, getDate.Day, 0, 0, 0);
                var list = await WebScrapper.GetAllAsync(insertedDate);
                if (list == null || list.Count <= 0) return;
                var state = await StatesBussines.GetAsync("خراسان رضوی");
                if (state == null) return;
                var city = await CitiesBussines.GetDefualtAsync("مشهد", state.Guid);
                foreach (var item in list)
                {
                    try
                    {
                        var region = await RegionsBussines.GetDefualtAsync(item.Region, city.Guid);
                        //var bu = new BuildingBussines()
                        //{
                        //    Guid = Guid.NewGuid(),
                        //    Modified = DateTime.Now,
                        //    Status = true,
                        //    Masahat = item.Masahat,
                        //    SellPrice = item.SellPrice,
                        //    ServerStatus = ServerStatus.None,
                        //    Code = BuildingBussines.NextCode(),
                        //    RahnPrice1 = item.RahnPrice,
                        //    ServerDeliveryDate = DateTime.Now,
                        //    EjarePrice1 = item.EjarePrice,
                        //    RegionGuid = region.Guid,
                        //    Tell = EnKhadamati.Mostaqel,
                        //    RoomCount = item.RoomCount,
                        //    Address = $"{item.State} {item.City} {item.Region}",
                        //    AdvertiseType = item.Type,
                        //    Barq = EnKhadamati.Mostaqel,
                        //    BonBast = false,
                        //    BuildingAccountTypeGuid = ,
                        //    BuildingConditionGuid = ,
                        //    BuildingTypeGuid = ,
                        //    BuildingViewGuid = ,
                        //    CityGuid = ,
                        //    CreateDate = DateTime.Now,
                        //    Dang = 6,
                        //    DeliveryDate = DateTime.Now,
                        //    DivarCount = 0,
                        //    DocumentType = null,
                        //    EjarePrice2 = 0,
                        //    DateParvane = "",
                        //    ErtefaSaqf = 3,
                        //    FloorCoverGuid = ,
                        //    Gas = EnKhadamati.Mostaqel,
                        //    Hashie = 0,
                        //    IsArchive = false,
                        //    IsOwnerHere = false,
                        //    IsShortTime = false,
                        //    DivarTitle = item.Title,
                        //    Image = "",
                        //    KitchenServiceGuid = ,
                        //    Lenght = 0,
                        //    MamarJoda = true,
                        //    MetrazhKouche = 0,
                        //    MetrazhTejari = 0,
                        //    MoavezeDesc = "",
                        //    MosharekatDesc = "",
                        //    OwnerGuid = await PeoplesBussines.GetDefaultPeopleAsync(),
                        //    ParvaneSerial = "",
                        //    Water = EnKhadamati.Mostaqel,
                        //    ZirBana = item.Masahat,
                        //    VamPrice = 0,
                        //    VahedPerTabaqe = item.VahedPerTabaqe,
                        //    UserGuid = UserBussines.CurrentUser.Guid,
                        //    TelegramCount = 0,
                        //    TedadTabaqe = item.TabaqeCount,
                        //    Tarakom = EnTarakom.Min,
                        //    TabaqeNo = item.TabaqeNo,
                        //    Side = ,
                        //    ShortDesc = item.Description,
                        //    SheypoorCount = 0,
                        //    SaleSakht = item.SaleSakht,
                        //    RentalAutorityGuid = ,
                        //    RahnPrice2 = 0,
                        //    QestPrice = 0,
                        //    PishTotalPrice = 0,
                        //    PishPrice = 0,
                        //    Priority = EnBuildingPriority.Low,
                        //    PishDesc = ""
                        //};
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                //clsAdvertise.GetFileDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                clsAdvertise.GetFileDate = DateTime.Now.AddDays(-1);
            }
        }
    }
}
