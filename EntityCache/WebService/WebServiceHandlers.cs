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
                WebBuilding.OnSaveResult += WebBuildingOnOnSaveResult;
                WebBuildingAccountType.OnSaveResult += WebBuildingAccountTypeOnOnSaveResult;
                WebBuildingCondition.OnSaveResult += WebBuildingConditionOnOnSaveResult;
                WebBuildingOptions.OnSaveResult += WebBuildingOptionsOnOnSaveResult;
                WebBuildingRequest.OnSaveResult += WebBuildingRequestOnOnSaveResult;
                WebBuildingType.OnSaveResult += WebBuildingTypeOnOnSaveResult;
                WebBuildingView.OnSaveResult += WebBuildingViewOnOnSaveResult;
                WebCity.OnSaveResult += WebCityOnOnSaveResult;
                WebDocumentType.OnSaveResult += WebDocumentTypeOnOnSaveResult;
                WebFloorCover.OnSaveResult += WebFloorCoverOnOnSaveResult;
                WebKitchenService.OnSaveResult += WebKitchenServiceOnOnSaveResult;
                WebPeople.OnSaveResult += WebPeopleOnOnSaveResult;
                WebPeopleGroup.OnSaveResult += WebPeopleGroupOnOnSaveResult;
                WebRegion.OnSaveResult += WebRegionOnOnSaveResult;
                WebRental.OnSaveResult += WebRentalOnOnSaveResult;
                WebStates.OnSaveResult += WebStatesOnOnSaveResult;
                WebUser.OnSaveResult += WebUserOnOnSaveResult;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task WebUserOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await UserBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebStatesOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await StatesBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebRentalOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await RentalAuthorityBussines.SetSaveResultAsync(objGuid,st);
        private async Task WebRegionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await RegionsBussines.SetSaveResultAsync(objGuid,st);
        private async Task WebPeopleGroupOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await PeopleGroupBussines.SetSaveResultAsync(objGuid,st);
        private async Task WebPeopleOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await PeoplesBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebKitchenServiceOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await KitchenServiceBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebFloorCoverOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await FloorCoverBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebDocumentTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await DocumentTypeBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebCityOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await CitiesBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingViewOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingViewBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingTypeBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingRequestOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingRequestBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingOptionsOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingOptionsBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingConditionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingConditionBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingAccountTypeOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingAccountTypeBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
        {
            try
            {
                await BuildingBussines.SetSaveResultAsync(objGuid, st);
                if (st == ServerStatus.Delivered)
                {
                    var bu = await BuildingBussines.GetAsync(objGuid);
                    if (bu == null) return;
                    if (string.IsNullOrEmpty(bu.Image)) return;
                    var file = await FileInfoBussines.GetAsync(bu.Image);
                    if (file != null)
                        if (file.FileName == bu.Image) return;

                    var img = Path.Combine(_appStart, "Images");
                    if (!Directory.Exists(img)) return;
                    if (!bu.Image.EndsWith(".jpg") && !bu.Image.EndsWith(".png")) return;
                    var path = Path.Combine(img, bu.Image);
                    var imageByte = File.ReadAllBytes(path);
                    var res = await WebFileInfo.UploadBitmapAsync(imageByte, bu.Image);
                    if (!res.HasError)
                    {
                        var file_ = new FileInfoBussines() { FileName = bu.Image };
                        await file_.SaveAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task StartSendToServerAsync()
        {
            try
            {
                var res = new ReturnedSaveFuncInfo();
                while (true)
                {
                    var ping = await Utilities.PingHostAsync();
                    if (ping.HasError)
                    {
                        await Task.Delay(2000);
                        continue;
                    }

                    res.AddReturnedValue(await UserBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    res.AddReturnedValue(await StatesBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    res.AddReturnedValue(await CitiesBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    res.AddReturnedValue(await RegionsBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    res.AddReturnedValue(await PeopleGroupBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    res.AddReturnedValue(await PeoplesBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    //switch (item.Type)
                    //{
                    //    case EnTemp.BuildingAccountType:
                    //        var acc = await BuildingAccountTypeBussines.GetAsync(item.ObjectGuid);
                    //        if (acc != null)
                    //            await WebBuildingAccountType.SaveAsync(BuildingAccountTypeMapper.Instance.Map(acc));
                    //        break;
                    //    case EnTemp.BuildingCondition:
                    //        var co = await BuildingConditionBussines.GetAsync(item.ObjectGuid);
                    //        if (co != null)
                    //            await WebBuildingCondition.SaveAsync(BuildingConditionMapper.Instance.Map(co));
                    //        break;
                    //    case EnTemp.BuildingType:
                    //        var type = await BuildingTypeBussines.GetAsync(item.ObjectGuid);
                    //        if (type != null)
                    //            await WebBuildingType.SaveAsync(BuildingTypeMapper.Instance.Map(type));
                    //        break;
                    //    case EnTemp.BuildingView:
                    //        var view = await BuildingViewBussines.GetAsync(item.ObjectGuid);
                    //        if (view != null)
                    //            await WebBuildingView.SaveAsync(BuildingViewMapper.Instance.Map(view));
                    //        break;
                    //    case EnTemp.DocumentType:
                    //        var doc = await DocumentTypeBussines.GetAsync(item.ObjectGuid);
                    //        if (doc != null)
                    //            await WebDocumentType.SaveAsync(DocumentTypeMapper.Instance.Map(doc));
                    //        break;
                    //    case EnTemp.FloorCover:
                    //        var fc = await FloorCoverBussines.GetAsync(item.ObjectGuid);
                    //        if (fc != null)
                    //            await WebFloorCover.SaveAsync(FloorCoverMapper.Instance.Map(fc));
                    //        break;
                    //    case EnTemp.KitchenService:
                    //        var ks = await KitchenServiceBussines.GetAsync(item.ObjectGuid);
                    //        if (ks != null)
                    //            await WebKitchenService.SaveAsync(KitchenServiceMapper.Instance.Map(ks));
                    //        break;
                    //    case EnTemp.RentalAuthority:
                    //        var ra = await RentalAuthorityBussines.GetAsync(item.ObjectGuid);
                    //        if (ra != null)
                    //            await WebRental.SaveAsync(RentalAuthorityMapper.Instance.Map(ra));
                    //        break;
                    //    case EnTemp.BuildingOptions:
                    //        var o = await BuildingOptionsBussines.GetAsync(item.ObjectGuid);
                    //        if (o != null)
                    //            await WebBuildingOptions.SaveAsync(BuildingOptionsMapper.Instance.Map(o));
                    //        break;
                    //    case EnTemp.Building:
                    //        var bu = await BuildingBussines.GetAsync(item.ObjectGuid);
                    //        if (bu != null)
                    //            await WebBuilding.SaveAsync(BuildingMapper.Instance.Map(bu));
                    //        break;
                    //    case EnTemp.Requests:
                    //        var req = await BuildingRequestBussines.GetAsync(item.ObjectGuid);
                    //        if (req != null)
                    //            await WebBuildingRequest.SaveAsync(BuildingRequestMapper.Instance.Map(req));
                    //        break;
                    //}

                    await Task.Delay(2000);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                await Task.Delay(2000);
                _ = Task.Run(StartSendToServerAsync);
            }
        }
    }
}
