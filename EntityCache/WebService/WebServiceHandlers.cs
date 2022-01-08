using System;
using System.IO;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Mppings;
using Services;
using WebHesabBussines;

namespace EntityCache.WebService
{
    public class WebServiceHandlers
    {
        private string _appStart;
        private static WebServiceHandlers _instance = null;
        public static WebServiceHandlers Instance => _instance ?? (_instance = new WebServiceHandlers());
        public void Init(string appStart)
        {
            try
            {
                _appStart = appStart;
                if (!VersionAccess.WebService) return;
                AddHandlers();
                _ = Task.Run(StartSendToServerAsync);
                _ = Task.Run(StartFillTempAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void AddHandlers()
        {
            //try
            //{
            //    WebBuilding.OnSaveResult += WebBuildingOnOnSaveResult;
            //    WebBuildingAccountType.OnSaveResult += WebBuildingAccountTypeOnOnSaveResult;
            //    WebBuildingCondition.OnSaveResult += WebBuildingConditionOnOnSaveResult;
            //    WebBuildingOptions.OnSaveResult += WebBuildingOptionsOnOnSaveResult;
            //    WebBuildingRelatedOptions.OnSaveResult += WebBuildingRelatedOptionsOnOnSaveResult;
            //    WebBuildingRequest.OnSaveResult += WebBuildingRequestOnOnSaveResult;
            //    WebBuildingRequestRegion.OnSaveResult += WebBuildingRequestRegionOnOnSaveResult;
            //    WebBuildingType.OnSaveResult += WebBuildingTypeOnOnSaveResult;
            //    WebBuildingView.OnSaveResult += WebBuildingViewOnOnSaveResult;
            //    WebCity.OnSaveResult += WebCityOnOnSaveResult;
            //    WebDocumentType.OnSaveResult += WebDocumentTypeOnOnSaveResult;
            //    WebFloorCover.OnSaveResult += WebFloorCoverOnOnSaveResult;
            //    WebKitchenService.OnSaveResult += WebKitchenServiceOnOnSaveResult;
            //    WebPeople.OnSaveResult += WebPeopleOnOnSaveResult;
            //    WebPeopleGroup.OnSaveResult += WebPeopleGroupOnOnSaveResult;
            //    WebPhoneBook.OnSaveResult += WebPhoneBookOnOnSaveResult;
            //    WebRegion.OnSaveResult += WebRegionOnOnSaveResult;
            //    WebRental.OnSaveResult += WebRentalOnOnSaveResult;
            //    WebStates.OnSaveResult += WebStatesOnOnSaveResult;
            //    WebUser.OnSaveResult += WebUserOnOnSaveResult;
            //    WebBuildingNote.OnSaveResult += WebBuildingNoteOnOnSaveResult;
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //}
        }

        //private async Task WebBuildingNoteOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingNote, objGuid, st, dateM);
        //private async Task WebUserOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.Users, objGuid, st, dateM);
        //private async Task WebStatesOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.States, objGuid, st, dateM);
        //private async Task WebRentalOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.RentalAuthority, objGuid, st, dateM);
        //private async Task WebRegionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.Region, objGuid, st, dateM);
        //private async Task WebPhoneBookOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.PhoneBook, objGuid, st, dateM);
        //private async Task WebPeopleGroupOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.PeopleGroups, objGuid, st, dateM);
        //private async Task WebPeopleOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.Peoples, objGuid, st, dateM);
        //private async Task WebKitchenServiceOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.KitchenService, objGuid, st, dateM);
        //private async Task WebFloorCoverOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.FloorCover, objGuid, st, dateM);
        //private async Task WebDocumentTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.DocumentType, objGuid, st, dateM);
        //private async Task WebCityOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.Cities, objGuid, st, dateM);
        //private async Task WebBuildingViewOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingView, objGuid, st, dateM);
        //private async Task WebBuildingTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingType, objGuid, st, dateM);
        //private async Task WebBuildingRequestRegionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.RequestRegions, objGuid, st, dateM);
        //private async Task WebBuildingRequestOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.Requests, objGuid, st, dateM);
        //private async Task WebBuildingRelatedOptionsOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingRelatedOptions, objGuid, st, dateM);
        //private async Task WebBuildingOptionsOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingOptions, objGuid, st, dateM);
        //private async Task WebBuildingConditionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingCondition, objGuid, st, dateM);
        //private async Task WebBuildingAccountTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //    => await TempBussines.UpdateEntityAsync(EnTemp.BuildingAccountType, objGuid, st, dateM);
        //private async Task WebBuildingOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        //{
        //    try
        //    {
        //        await TempBussines.UpdateEntityAsync(EnTemp.Building, objGuid, st, dateM);
        //        if (st == ServerStatus.Delivered)
        //        {
        //            var bu = await BuildingBussines.GetAsync(objGuid);
        //            if (bu == null) return;

        //            if (bu.OptionList != null && bu.OptionList.Count > 0)
        //            {
        //                var options = BuildingRelatedOptionMapper.Instance.MapList(bu.OptionList);
        //                await WebBuildingRelatedOptions.SaveAsync(options);
        //            }

        //            if (bu.NoteList != null && bu.NoteList.Count > 0)
        //            {
        //                var notes = BuildingNoteMapper.Instance.MapList(bu.NoteList);
        //                await WebBuildingNote.SaveAsync(notes);
        //            }

        //            if (string.IsNullOrEmpty(bu.Image)) return;
        //            var file = await FileInfoBussines.GetAsync(bu.Image);
        //            if (file != null)
        //                if (file.FileName == bu.Image) return;

        //            var img = Path.Combine(_appStart, "Images");
        //            if (!Directory.Exists(img)) return;
        //            if (!bu.Image.EndsWith(".jpg") && !bu.Image.EndsWith(".png")) return;
        //            var path = Path.Combine(img, bu.Image);
        //            var imageByte = File.ReadAllBytes(path);
        //            var res = await WebFileInfo.UploadBitmapAsync(imageByte, bu.Image);
        //            if (!res.HasError)
        //            {
        //                var file_ = new FileInfoBussines() { FileName = bu.Image };
        //                await file_.SaveAsync();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //    }
        //}
        private async Task StartSendToServerAsync()
        {
            //try
            //{
            //    var list = await TempBussines.GetAllAsync();
            //    while (true)
            //    {
            //        var ping = await Utilities.PingHostAsync();
            //        if (ping.HasError)
            //        {
            //            await Task.Delay(2000);
            //            continue;
            //        }
            //        if (list == null || list.Count <= 0)
            //        {
            //            await Task.Delay(2000);
            //            continue;
            //        }
            //        foreach (var item in list)
            //        {
            //            switch (item.Type)
            //            {
            //                case EnTemp.States:
            //                    var states = await StatesBussines.GetAsync(item.ObjectGuid);
            //                    if (states != null)
            //                        await WebStates.SaveAsync(StateMapper.Instance.Map(states));
            //                    break;
            //                case EnTemp.Cities:
            //                    var city = await CitiesBussines.GetAsync(item.ObjectGuid);
            //                    if (city != null)
            //                        await WebCity.SaveAsync(CityMapper.Instance.Map(city));
            //                    break;
            //                case EnTemp.Region:
            //                    var region = await RegionsBussines.GetAsync(item.ObjectGuid);
            //                    if (region != null)
            //                        await WebRegion.SaveAsync(RegionMapper.Instance.Map(region));
            //                    break;
            //                case EnTemp.Users:
            //                    var user = await UserBussines.GetAsync(item.ObjectGuid);
            //                    if (user != null)
            //                        await WebUser.SaveAsync(UserMapper.Instance.Map(user));
            //                    break;
            //                case EnTemp.PeopleGroups:
            //                    var pg = await PeopleGroupBussines.GetAsync(item.ObjectGuid);
            //                    if (pg != null)
            //                        await WebPeopleGroup.SaveAsync(PeopleGroupMapper.Instance.Map(pg));
            //                    break;
            //                case EnTemp.Peoples:
            //                    var p = await PeoplesBussines.GetAsync(item.ObjectGuid, null);
            //                    if (p != null)
            //                        await WebPeople.SaveAsync(PeopleMapper.Instance.Map(p));
            //                    break;
            //                case EnTemp.BuildingAccountType:
            //                    var acc = await BuildingAccountTypeBussines.GetAsync(item.ObjectGuid);
            //                    if (acc != null)
            //                        await WebBuildingAccountType.SaveAsync(BuildingAccountTypeMapper.Instance.Map(acc));
            //                    break;
            //                case EnTemp.BuildingCondition:
            //                    var co = await BuildingConditionBussines.GetAsync(item.ObjectGuid);
            //                    if (co != null)
            //                        await WebBuildingCondition.SaveAsync(BuildingConditionMapper.Instance.Map(co));
            //                    break;
            //                case EnTemp.BuildingType:
            //                    var type = await BuildingTypeBussines.GetAsync(item.ObjectGuid);
            //                    if (type != null)
            //                        await WebBuildingType.SaveAsync(BuildingTypeMapper.Instance.Map(type));
            //                    break;
            //                case EnTemp.BuildingView:
            //                    var view = await BuildingViewBussines.GetAsync(item.ObjectGuid);
            //                    if (view != null)
            //                        await WebBuildingView.SaveAsync(BuildingViewMapper.Instance.Map(view));
            //                    break;
            //                case EnTemp.DocumentType:
            //                    var doc = await DocumentTypeBussines.GetAsync(item.ObjectGuid);
            //                    if (doc != null)
            //                        await WebDocumentType.SaveAsync(DocumentTypeMapper.Instance.Map(doc));
            //                    break;
            //                case EnTemp.FloorCover:
            //                    var fc = await FloorCoverBussines.GetAsync(item.ObjectGuid);
            //                    if (fc != null)
            //                        await WebFloorCover.SaveAsync(FloorCoverMapper.Instance.Map(fc));
            //                    break;
            //                case EnTemp.KitchenService:
            //                    var ks = await KitchenServiceBussines.GetAsync(item.ObjectGuid);
            //                    if (ks != null)
            //                        await WebKitchenService.SaveAsync(KitchenServiceMapper.Instance.Map(ks));
            //                    break;
            //                case EnTemp.RentalAuthority:
            //                    var ra = await RentalAuthorityBussines.GetAsync(item.ObjectGuid);
            //                    if (ra != null)
            //                        await WebRental.SaveAsync(RentalAuthorityMapper.Instance.Map(ra));
            //                    break;
            //                case EnTemp.BuildingOptions:
            //                    var o = await BuildingOptionsBussines.GetAsync(item.ObjectGuid);
            //                    if (o != null)
            //                        await WebBuildingOptions.SaveAsync(BuildingOptionsMapper.Instance.Map(o));
            //                    break;
            //                case EnTemp.Building:
            //                    var bu = await BuildingBussines.GetAsync(item.ObjectGuid);
            //                    if (bu != null)
            //                        await WebBuilding.SaveAsync(BuildingMapper.Instance.Map(bu));
            //                    break;
            //                case EnTemp.Contract:
            //                    var con = await ContractBussines.GetAsync(item.ObjectGuid);
            //                    if (con != null)
            //                        await WebContract.SaveAsync(ContractMapper.Instance.Map(con));
            //                    break;
            //                case EnTemp.Requests:
            //                    var req = await BuildingRequestBussines.GetAsync(item.ObjectGuid);
            //                    if (req != null)
            //                        await WebBuildingRequest.SaveAsync(BuildingRequestMapper.Instance.Map(req));
            //                    break;
            //                case EnTemp.Reception:
            //                    var rec = await ReceptionBussines.GetAsync(item.ObjectGuid);
            //                    if (rec != null)
            //                        await WebReception.SaveAsync(ReceptionMapper.Instance.Map(rec));
            //                    break;
            //                case EnTemp.Pardakht:
            //                    var pa = await PardakhtBussines.GetAsync(item.ObjectGuid);
            //                    if (pa != null)
            //                        await WebPardakht.SaveAsync(PardakhtMapper.Instance.Map(pa));
            //                    break;
            //                case EnTemp.BuildingRelatedOptions:
            //                    var re = await BuildingRelatedOptionsBussines.GetAsync(item.ObjectGuid);
            //                    if (re != null)
            //                        await WebBuildingRelatedOptions.SaveAsync(BuildingRelatedOptionMapper.Instance.Map(re));
            //                    break;
            //                case EnTemp.RequestRegions:
            //                    var rr = await BuildingRequestRegionBussines.GetAsync(item.ObjectGuid);
            //                    if (rr != null)
            //                        await WebBuildingRequestRegion.SaveAsync(BuildingRequestRegionMapper.Instance.Map(rr));
            //                    break;
            //                case EnTemp.PhoneBook:
            //                    var ph = await PhoneBookBussines.GetAsync(item.ObjectGuid);
            //                    if (ph != null)
            //                        await WebPhoneBook.SaveAsync(PhoneBookMapper.Instance.Map(ph));
            //                    break;
            //                case EnTemp.Advisor:
            //                    var ad = await AdvisorBussines.GetAsync(item.ObjectGuid);
            //                    if (ad != null)
            //                        await WebAdvisor.SaveAsync(AdvisorMapper.Instance.Map(ad));
            //                    break;
            //                case EnTemp.Bank:
            //                    var ba = await BankBussines.GetAsync(item.ObjectGuid);
            //                    if (ba != null)
            //                        await WebBank.SaveAsync(BankMapper.Instance.Map(ba));
            //                    break;
            //                case EnTemp.Kol:
            //                    var kol = await KolBussines.GetAsync(item.ObjectGuid);
            //                    if (kol != null)
            //                        await WebKol.SaveAsync(KolMapper.Instance.Map(kol));
            //                    break;
            //                case EnTemp.Moein:
            //                    var moein = await MoeinBussines.GetAsync(item.ObjectGuid);
            //                    if (moein != null)
            //                        await WebMoein.SaveAsync(MoeinMapper.Instance.Map(moein));
            //                    break;
            //                case EnTemp.Tafsil:
            //                    var tafsil = await TafsilBussines.GetAsync(item.ObjectGuid);
            //                    if (tafsil != null)
            //                        await WebTafsil.SaveAsync(TafsilMapper.Instance.Map(tafsil));
            //                    break;
            //                case EnTemp.Sanad:
            //                    var sa = await SanadBussines.GetAsync(item.ObjectGuid);
            //                    if (sa != null)
            //                        await WebSanad.SaveAsync(SanadMapper.Instance.Map(sa));
            //                    break;
            //                case EnTemp.SanadDetail:
            //                    var saD = await SanadDetailBussines.GetAsync(item.ObjectGuid);
            //                    if (saD != null)
            //                        await WebSanadDetail.SaveAsync(SanadDetailMapper.Instance.Map(saD));
            //                    break;
            //            }

            //            await item.RemoveAsync();
            //        }

            //        await Task.Delay(2000);
            //        list = await TempBussines.GetAllAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //}
        }
        private async Task StartFillTempAsync()
        {
            //try
            //{
            //    var date = DateTime.Now.AddHours(-1);
            //    while (true)
            //    {
            //        var res = await TempBussines.SaveOnModifiedAsync(date);
            //        if (res.HasError) continue;
            //        date = DateTime.Now;
            //        await Task.Delay(20000);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //}
        }
    }
}
