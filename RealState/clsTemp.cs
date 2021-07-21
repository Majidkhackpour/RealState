using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;
using Settings;
using WebHesabBussines;

namespace RealState
{
    public class clsTemp
    {
        public static void Init()
        {
            try
            {
                if (!VersionAccess.WebService) return;
                _ = Task.Run(StartSendToServerAsync);
                _ = Task.Run(StartFillTempAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task StartSendToServerAsync()
        {
            try
            {
                var list = await TempBussines.GetAllAsync();
                while (true)
                {
                    if (list == null || list.Count <= 0)
                    {
                        await Task.Delay(2000);
                        continue;
                    }
                    foreach (var item in list)
                    {
                        switch (item.Type)
                        {
                            case EnTemp.States:
                                var states = await StatesBussines.GetAsync(item.ObjectGuid);
                                if (states != null)
                                    await WebStates.SaveAsync(states);
                                break;
                            case EnTemp.Cities:
                                var city = await CitiesBussines.GetAsync(item.ObjectGuid);
                                if (city != null)
                                    await WebCity.SaveAsync(city);
                                break;
                            case EnTemp.Region:
                                var region = await RegionsBussines.GetAsync(item.ObjectGuid);
                                if (region != null)
                                    await WebRegion.SaveAsync(region);
                                break;
                            case EnTemp.Users:
                                var user = await UserBussines.GetAsync(item.ObjectGuid);
                                if (user != null)
                                    await WebUser.SaveAsync(user);
                                break;
                            case EnTemp.PeopleGroups:
                                var pg = await PeopleGroupBussines.GetAsync(item.ObjectGuid);
                                if (pg != null)
                                    await WebPeopleGroup.SaveAsync(pg);
                                break;
                            case EnTemp.Peoples:
                                var p = await PeoplesBussines.GetAsync(item.ObjectGuid);
                                if (p != null)
                                    await WebPeople.SaveAsync(p);
                                break;
                            case EnTemp.BuildingAccountType:
                                var acc = await BuildingAccountTypeBussines.GetAsync(item.ObjectGuid);
                                if (acc != null)
                                    await WebBuildingAccountType.SaveAsync(acc);
                                break;
                            case EnTemp.BuildingCondition:
                                var co = await BuildingConditionBussines.GetAsync(item.ObjectGuid);
                                if (co != null)
                                    await WebBuildingCondition.SaveAsync(co);
                                break;
                            case EnTemp.BuildingType:
                                var type = await BuildingTypeBussines.GetAsync(item.ObjectGuid);
                                if (type != null)
                                    await WebBuildingType.SaveAsync(type);
                                break;
                            case EnTemp.BuildingView:
                                var view = await BuildingViewBussines.GetAsync(item.ObjectGuid);
                                if (view != null)
                                    await WebBuildingView.SaveAsync(view);
                                break;
                            case EnTemp.DocumentType:
                                var doc = await DocumentTypeBussines.GetAsync(item.ObjectGuid);
                                if (doc != null)
                                    await WebDocumentType.SaveAsync(doc);
                                break;
                            case EnTemp.FloorCover:
                                var fc = await FloorCoverBussines.GetAsync(item.ObjectGuid);
                                if (fc != null)
                                    await WebFloorCover.SaveAsync(fc);
                                break;
                            case EnTemp.KitchenService:
                                var ks = await KitchenServiceBussines.GetAsync(item.ObjectGuid);
                                if (ks != null)
                                    await WebKitchenService.SaveAsync(ks);
                                break;
                            case EnTemp.RentalAuthority:
                                var ra = await RentalAuthorityBussines.GetAsync(item.ObjectGuid);
                                if (ra != null)
                                    await WebRental.SaveAsync(ra);
                                break;
                            case EnTemp.BuildingOptions:
                                var o = await BuildingOptionsBussines.GetAsync(item.ObjectGuid);
                                if (o != null)
                                    await WebBuildingOptions.SaveAsync(o);
                                break;
                            case EnTemp.Building:
                                var bu = await BuildingBussines.GetAsync(item.ObjectGuid);
                                if (bu != null)
                                    await WebBuilding.SaveAsync(bu, Application.StartupPath);
                                break;
                            case EnTemp.Contract:
                                var con = await ContractBussines.GetAsync(item.ObjectGuid);
                                if (con != null)
                                    await WebContract.SaveAsync(con);
                                break;
                            case EnTemp.Requests:
                                var req = await BuildingRequestBussines.GetAsync(item.ObjectGuid);
                                if (req != null)
                                    await WebBuildingRequest.SaveAsync(req);
                                break;
                            case EnTemp.Reception:
                                var rec = await ReceptionBussines.GetAsync(item.ObjectGuid);
                                if (rec != null)
                                    await WebReception.SaveAsync(rec);
                                break;
                            case EnTemp.Pardakht:
                                var pa = await PardakhtBussines.GetAsync(item.ObjectGuid);
                                if (pa != null)
                                    await WebPardakht.SaveAsync(pa);
                                break;
                            case EnTemp.BuildingRelatedOptions:
                                var re = await BuildingRelatedOptionsBussines.GetAsync(item.ObjectGuid);
                                if (re != null)
                                    await WebBuildingRelatedOptions.SaveAsync(re);
                                break;
                            case EnTemp.RequestRegions:
                                var rr = await BuildingRequestRegionBussines.GetAsync(item.ObjectGuid);
                                if (rr != null)
                                    await WebBuildingRequestRegion.SaveAsync(rr);
                                break;
                            case EnTemp.PhoneBook:
                                var ph = await PhoneBookBussines.GetAsync(item.ObjectGuid);
                                if (ph != null)
                                    await WebPhoneBook.SaveAsync(ph);
                                break;
                            case EnTemp.Advisor:
                                var ad = await AdvisorBussines.GetAsync(item.ObjectGuid);
                                if (ad != null)
                                    await WebAdvisor.SaveAsync(ad);
                                break;
                            case EnTemp.Bank:
                                var ba = await BankBussines.GetAsync(item.ObjectGuid);
                                if (ba != null)
                                    await WebBank.SaveAsync(ba);
                                break;
                            case EnTemp.Kol:
                                var kol = await KolBussines.GetAsync(item.ObjectGuid);
                                if (kol != null)
                                    await WebKol.SaveAsync(kol);
                                break;
                            case EnTemp.Moein:
                                var moein = await MoeinBussines.GetAsync(item.ObjectGuid);
                                if (moein != null)
                                    await WebMoein.SaveAsync(moein);
                                break;
                            case EnTemp.Tafsil:
                                var tafsil = await TafsilBussines.GetAsync(item.ObjectGuid);
                                if (tafsil != null)
                                    await WebTafsil.SaveAsync(tafsil);
                                break;
                            case EnTemp.Sanad:
                                var sa = await SanadBussines.GetAsync(item.ObjectGuid);
                                if (sa != null)
                                    await WebSanad.SaveAsync(sa);
                                break;
                            case EnTemp.SanadDetail:
                                var saD = await SanadDetailBussines.GetAsync(item.ObjectGuid);
                                if (saD != null)
                                    await WebSanadDetail.SaveAsync(saD);
                                break;
                        }

                        await item.RemoveAsync();
                    }

                    await Task.Delay(2000);
                    list = await TempBussines.GetAllAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task StartFillTempAsync()
        {
            try
            {
                var date = DateTime.Now.AddHours(-1);
                while (true)
                {
                    var res = await TempBussines.SaveOnModifiedAsync(date);
                    if (res.HasError) continue;
                    date = DateTime.Now;
                    await Task.Delay(20000);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
