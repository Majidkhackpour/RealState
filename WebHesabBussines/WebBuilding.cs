using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Services.AndroidViewModels;

namespace WebHesabBussines
{
    public class WebBuilding : IBuilding
    {
        private static string Url = Utilities.WebApi + "/api/Building/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;

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
        public decimal EjarePrice1 { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public bool? Tabdil { get; set; }
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
        public Guid? BuildingConditionGuid { get; set; }
        public EnBuildingSide? Side { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid? BuildingViewGuid { get; set; }
        public Guid? FloorCoverGuid { get; set; }
        public Guid? KitchenServiceGuid { get; set; }
        public EnKhadamati? Water { get; set; }
        public EnKhadamati? Barq { get; set; }
        public EnKhadamati? Gas { get; set; }
        public EnKhadamati? Tell { get; set; }
        public int TedadTabaqe { get; set; }
        public int TabaqeNo { get; set; }
        public int VahedPerTabaqe { get; set; }
        public float MetrazhKouche { get; set; }
        public float ErtefaSaqf { get; set; }
        public float Hashie { get; set; }
        public float Lenght { get; set; }
        public float ReformArea { get; set; }
        public bool? BuildingPermits { get; set; }
        public float WidthOfPassage { get; set; }
        public string SaleSakht { get; set; }
        public string DateParvane { get; set; }
        public string ParvaneSerial { get; set; }
        public bool BonBast { get; set; }
        public bool MamarJoda { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public string Image { get; set; }
        public int TelegramCount { get; set; }
        public int WhatsAppCount { get; set; }
        public int DivarCount { get; set; }
        public int SheypoorCount { get; set; }
        public AdvertiseType? AdvertiseType { get; set; }
        public string DivarTitle { get; set; }
        public string Hiting { get; set; }
        public string Colling { get; set; }
        public EnVillaType? VillaType { get; set; }
        public EnCommericallLicense? CommericallLicense { get; set; }
        public string SuitableFor { get; set; }
        public string WallCovering { get; set; }
        public int TreeCount { get; set; }
        public EnConstructionStage? ConstructionStage { get; set; }
        public EnBuildingParent? Parent { get; set; }
        public List<WebBuildingRelatedOptions> OptionList { get; set; }
        public List<WebBuildingNote> NoteList { get; set; }


        private static void RaiseEvent(Guid objGuid, ServerStatus st, DateTime dateM)
        {
            try
            {
                var handler = OnSaveResult;
                if (handler != null)
                    OnSaveResult?.Invoke(objGuid, st, dateM);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<WebBuilding, WebBuilding>(this, Url, WebCustomer.Customer.Guid);
                if (res == null || res.ResponseStatus != ResponseStatus.Success)
                {
                    RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                    return;
                }

                if (OptionList != null && OptionList.Count > 0)
                {
                    foreach (var item in OptionList)
                    {
                        var ret = await WebBuildingRelatedOptions.SendAsync(item);
                        if (ret.HasError || ret.value == null || ret.value != ResponseStatus.Success)
                        {
                            RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                            return;
                        }
                    }
                }

                if (NoteList != null && NoteList.Count > 0)
                {
                    foreach (var item in NoteList)
                    {
                        var ret = await WebBuildingNote.SendAsync(item);
                        if (ret.HasError || ret.value == null || ret.value != ResponseStatus.Success)
                        {
                            RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                            return;
                        }
                    }
                }

                var bu = res?.Data;
                if (bu == null)
                {
                    RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                    return;
                }

                RaiseEvent(Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SendAsync(WebBuilding cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                await cls.SendAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendAsync(List<WebBuilding> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                    res.AddReturnedValue(await SendAsync(cls));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<List<BuildingListViewModel>> GetListAsync(EnRequestType _type)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("cusGuid", WebCustomer.Customer.Guid.ToString());
                    var res = await client.GetStringAsync(Utilities.WebApi + "/Buildings_GetLastList/" + _type);
                    var user = res.FromJson<List<BuildingListViewModel>>();
                    return user;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        //public static List<BuildingListViewModel> GetList(EnRequestType _type) => AsyncContext.Run(() => GetListAsync(_type));
    }
}
