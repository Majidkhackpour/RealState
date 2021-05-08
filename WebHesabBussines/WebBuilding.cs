using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuilding : IBuilding
    {
        private static string Url = Utilities.WebApi + "/api/Building/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
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
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public string Image { get; set; }
        public string HardSerial { get; set; }
        public List<BuildingRelatedOptionsBussines> OptionList { get; set; }
        public List<BuildingGalleryBussines> GalleryList { get; set; }


        public async Task SaveAsync(string p)
        {
            try
            {
                var res = await Extentions.PostToApi<BuildingBussines, WebBuilding>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Building
                    };
                    await temp.SaveAsync();
                    return;
                }

                var bu = res.Data;
                if (bu == null) return;

                await TempBussines.UpdateEntityAsync(EnTemp.Building, bu.Guid, ServerStatus.Delivered, DateTime.Now);

                await WebBuildingRelatedOptions.SaveAsync(OptionList);
                if (string.IsNullOrEmpty(Image)) return;

                var file = await FileInfoBussines.GetAsync(Image);
                if (file != null)
                    if (file.FileName == Image) return;

                var img = Path.Combine(p, "Images");
                if (!Directory.Exists(img)) return;
                if (!Image.EndsWith(".jpg") && !Image.EndsWith(".png")) return;
                var path = Path.Combine(img, Image);
                var imageByte = File.ReadAllBytes(path);
                await UploadBitmapAsync(imageByte, Image);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBussines cls, string path)
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
                await obj.SaveAsync(path);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<BuildingBussines> item, string path)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                    res.AddReturnedValue(await SaveAsync(cls, path));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task UploadBitmapAsync(byte[] img, string imageName)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var form = new MultipartFormDataContent
                    {
                        {new ByteArrayContent(img, 0, img.Count()), "picture", imageName}
                    };
                    var response = await httpClient.PostAsync(Utilities.WebApi + "/PostImage", form);
                    response.EnsureSuccessStatusCode();
                    var responseBody = response.Content.ReadAsStringAsync();
                    var file = new FileInfoBussines() { FileName = imageName };
                    await file.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
