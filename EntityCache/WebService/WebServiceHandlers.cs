using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.WebService
{
    public class WebServiceHandlers
    {
        public void Init(string appStart)
        {
            try
            {
                if (!VersionAccess.WebService) return;
                AddHandlers();
                _ = Task.Run(() => StartSendToServerAsync(appStart));
                _ = Task.Run(StartFillTempAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void AddHandlers()
        {
            try
            {
                WebAdvisor.OnSaveResult -= WebAdvisorOnOnSaveResult;
                WebBank.OnSaveResult -= WebBankOnOnSaveResult;
                WebBuilding.OnSaveResult -= WebBuildingOnOnSaveResult;
                WebBuildingAccountType.OnSaveResult -= WebBuildingAccountTypeOnOnSaveResult;
                WebBuildingCondition.OnSaveResult -= WebBuildingConditionOnOnSaveResult;
                WebBuildingOptions.OnSaveResult -= WebBuildingOptionsOnOnSaveResult;
                WebBuildingRelatedOptions.OnSaveResult -= WebBuildingRelatedOptionsOnOnSaveResult;
                WebBuildingRequest.OnSaveResult -= WebBuildingRequestOnOnSaveResult;
                WebBuildingRequestRegion.OnSaveResult -= WebBuildingRequestRegionOnOnSaveResult;
                WebBuildingType.OnSaveResult -= WebBuildingTypeOnOnSaveResult;
                WebBuildingView.OnSaveResult -= WebBuildingViewOnOnSaveResult;
                WebCity.OnSaveResult -= WebCityOnOnSaveResult;
                WebContract.OnSaveResult -= WebContractOnOnSaveResult;
                WebDocumentType.OnSaveResult -= WebDocumentTypeOnOnSaveResult;
                WebFloorCover.OnSaveResult -= WebFloorCoverOnOnSaveResult;
                WebKitchenService.OnSaveResult -= WebKitchenServiceOnOnSaveResult;
                WebKol.OnSaveResult -= WebKolOnOnSaveResult;
                WebMoein.OnSaveResult -= WebMoeinOnOnSaveResult;
                WebPardakht.OnSaveResult -= WebPardakhtOnOnSaveResult;
                WebPeople.OnSaveResult -= WebPeopleOnOnSaveResult;
                WebPeopleGroup.OnSaveResult -= WebPeopleGroupOnOnSaveResult;
                WebPhoneBook.OnSaveResult -= WebPhoneBookOnOnSaveResult;
                WebReception.OnSaveResult -= WebReceptionOnOnSaveResult;
                WebRegion.OnSaveResult -= WebRegionOnOnSaveResult;
                WebRental.OnSaveResult -= WebRentalOnOnSaveResult;
                WebSanad.OnSaveResult -= WebSanadOnOnSaveResult;
                WebSanadDetail.OnSaveResult -= WebSanadDetailOnOnSaveResult;
                WebStates.OnSaveResult -= WebStatesOnOnSaveResult;
                WebTafsil.OnSaveResult -= WebTafsilOnOnSaveResult;
                WebUser.OnSaveResult -= WebUserOnOnSaveResult;


                WebAdvisor.OnSaveResult += WebAdvisorOnOnSaveResult;
                WebBank.OnSaveResult += WebBankOnOnSaveResult;
                WebBuilding.OnSaveResult += WebBuildingOnOnSaveResult;
                WebBuildingAccountType.OnSaveResult += WebBuildingAccountTypeOnOnSaveResult;
                WebBuildingCondition.OnSaveResult += WebBuildingConditionOnOnSaveResult;
                WebBuildingOptions.OnSaveResult += WebBuildingOptionsOnOnSaveResult;
                WebBuildingRelatedOptions.OnSaveResult += WebBuildingRelatedOptionsOnOnSaveResult;
                WebBuildingRequest.OnSaveResult += WebBuildingRequestOnOnSaveResult;
                WebBuildingRequestRegion.OnSaveResult += WebBuildingRequestRegionOnOnSaveResult;
                WebBuildingType.OnSaveResult += WebBuildingTypeOnOnSaveResult;
                WebBuildingView.OnSaveResult += WebBuildingViewOnOnSaveResult;
                WebCity.OnSaveResult += WebCityOnOnSaveResult;
                WebContract.OnSaveResult += WebContractOnOnSaveResult;
                WebDocumentType.OnSaveResult += WebDocumentTypeOnOnSaveResult;
                WebFloorCover.OnSaveResult += WebFloorCoverOnOnSaveResult;
                WebKitchenService.OnSaveResult += WebKitchenServiceOnOnSaveResult;
                WebKol.OnSaveResult += WebKolOnOnSaveResult;
                WebMoein.OnSaveResult += WebMoeinOnOnSaveResult;
                WebPardakht.OnSaveResult += WebPardakhtOnOnSaveResult;
                WebPeople.OnSaveResult += WebPeopleOnOnSaveResult;
                WebPeopleGroup.OnSaveResult += WebPeopleGroupOnOnSaveResult;
                WebPhoneBook.OnSaveResult += WebPhoneBookOnOnSaveResult;
                WebReception.OnSaveResult += WebReceptionOnOnSaveResult;
                WebRegion.OnSaveResult += WebRegionOnOnSaveResult;
                WebRental.OnSaveResult += WebRentalOnOnSaveResult;
                WebSanad.OnSaveResult += WebSanadOnOnSaveResult;
                WebSanadDetail.OnSaveResult += WebSanadDetailOnOnSaveResult;
                WebStates.OnSaveResult += WebStatesOnOnSaveResult;
                WebTafsil.OnSaveResult += WebTafsilOnOnSaveResult;
                WebUser.OnSaveResult += WebUserOnOnSaveResult;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task WebUserOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Users, objGuid, st, dateM);
        private async Task WebTafsilOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Tafsil, objGuid, st, dateM);
        private async Task WebStatesOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.States, objGuid, st, dateM);
        private async Task WebSanadDetailOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.SanadDetail, objGuid, st, dateM);
        private async Task WebSanadOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Sanad, objGuid, st, dateM);
        private async Task WebRentalOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.RentalAuthority, objGuid, st, dateM);
        private async Task WebRegionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Region, objGuid, st, dateM);
        private async Task WebReceptionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Reception, objGuid, st, dateM);
        private async Task WebPhoneBookOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.PhoneBook, objGuid, st, dateM);
        private async Task WebPeopleGroupOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.PeopleGroups, objGuid, st, dateM);
        private async Task WebPeopleOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Peoples, objGuid, st, dateM);
        private async Task WebPardakhtOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Pardakht, objGuid, st, dateM);
        private async Task WebMoeinOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Moein, objGuid, st, dateM);
        private async Task WebKolOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Kol, objGuid, st, dateM);
        private async Task WebKitchenServiceOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.KitchenService, objGuid, st, dateM);
        private async Task WebFloorCoverOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.FloorCover, objGuid, st, dateM);
        private async Task WebDocumentTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.DocumentType, objGuid, st, dateM);
        private async Task WebContractOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Contract, objGuid, st, dateM);
        private async Task WebCityOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Cities, objGuid, st, dateM);
        private async Task WebBuildingViewOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.BuildingView, objGuid, st, dateM);
        private async Task WebBuildingTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.BuildingType, objGuid, st, dateM);
        private async Task WebBuildingRequestRegionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.RequestRegions, objGuid, st, dateM);
        private async Task WebBuildingRequestOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Requests, objGuid, st, dateM);
        private async Task WebBuildingRelatedOptionsOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.BuildingRelatedOptions, objGuid, st, dateM);
        private async Task WebBuildingOptionsOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.BuildingOptions, objGuid, st, dateM);
        private async Task WebBuildingConditionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.BuildingCondition, objGuid, st, dateM);
        private async Task WebBuildingAccountTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.BuildingAccountType, objGuid, st, dateM);
        private async Task WebBuildingOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Building, objGuid, st, dateM);
        private async Task WebBankOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Bank, objGuid, st, dateM);
        private async Task WebAdvisorOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Advisor, objGuid, st, dateM);
        private async Task StartSendToServerAsync(string appStart)
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
                                    await WebBuilding.SaveAsync(bu, appStart);
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
        private async Task StartFillTempAsync()
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
