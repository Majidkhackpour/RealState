using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace RealState
{
    public class clsTemp
    {
        public static void Init()
        {
            try
            {
                _ = Task.Run(StartSendToServerAsync);
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
                    list = list?.OrderBy(q => q.Modified).ToList();
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
                                //var rec = await ReceptionBussines.GetAsync(item.ObjectGuid);
                                //if (rec != null)
                                //    await WebReception.SaveAsync(rec);
                                break;
                            case EnTemp.Pardakht:
                                var pa = await PardakhtBussines.GetAsync(item.ObjectGuid);
                                if (pa != null)
                                    await WebPardakht.SaveAsync(pa);
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
    }
}
