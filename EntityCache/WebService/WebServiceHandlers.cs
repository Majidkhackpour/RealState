using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WebHesabBussines;

namespace EntityCache.WebService
{
    public class WebServiceHandlers
    {
        private string _appStart;
        private CancellationTokenSource _token = new CancellationTokenSource();
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
                WebBuildingZoncan.OnSaveResult += WebBuildingZoncan_OnSaveResult;
                WebBuildingWindow.OnSaveResult += WebBuildingWindow_OnSaveResult;
                WebBuildingReview.OnSaveResult += WebBuildingReview_OnSaveResult;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task WebBuildingReview_OnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingReviewBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingWindow_OnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingWindowBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebBuildingZoncan_OnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await BuildingZoncanBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebUserOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await UserBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebStatesOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await StatesBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebRentalOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await RentalAuthorityBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebRegionOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await RegionsBussines.SetSaveResultAsync(objGuid, st);
        private async Task WebPeopleGroupOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await PeopleGroupBussines.SetSaveResultAsync(objGuid, st);
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
        public async Task StartSendToServerAsync()
        {
            try
            {
                var res = new ReturnedSaveFuncInfo();
                while (true)
                {
                    _token?.Cancel();
                    _token = new CancellationTokenSource();
                    var ping = await Utilities.PingHostAsync();
                    if (ping.HasError) return;
                    if (_token.IsCancellationRequested) return;
                    res.AddReturnedValue(await UserBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    if (_token.IsCancellationRequested) return;
                    res.AddReturnedValue(await StatesBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    if (_token.IsCancellationRequested) return;
                    res.AddReturnedValue(await CitiesBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    if (_token.IsCancellationRequested) return;
                    res.AddReturnedValue(await PeopleGroupBussines.ResendNotSentAsync());
                    if (res.HasError) continue;
                    if (_token.IsCancellationRequested) return;
                    var list = new List<Task<ReturnedSaveFuncInfo>>
                    {
                        Task.Run(BuildingAccountTypeBussines.ResendNotSentAsync),
                        Task.Run(BuildingConditionBussines.ResendNotSentAsync),
                        Task.Run(BuildingTypeBussines.ResendNotSentAsync),
                        Task.Run(BuildingViewBussines.ResendNotSentAsync),
                        Task.Run(DocumentTypeBussines.ResendNotSentAsync),
                        Task.Run(FloorCoverBussines.ResendNotSentAsync),
                        Task.Run(KitchenServiceBussines.ResendNotSentAsync),
                        Task.Run(RentalAuthorityBussines.ResendNotSentAsync),
                        Task.Run(BuildingOptionsBussines.ResendNotSentAsync),
                        Task.Run(BuildingWindowBussines.ResendNotSentAsync),
                        Task.Run(BuildingZoncanBussines.ResendNotSentAsync),
                        Task.Run(RegionsBussines.ResendNotSentAsync),
                        Task.Run(PeoplesBussines.ResendNotSentAsync)
                    };
                    var ret = await Task.WhenAll(list);
                    res.AddReturnedValue(ret);
                    if (_token.IsCancellationRequested) return;
                    if (res.HasError) continue;
                    res.AddReturnedValue(await BuildingBussines.ResendNotSentAsync());
                    if (_token.IsCancellationRequested) return;
                    res.AddReturnedValue(await BuildingRequestBussines.ResendNotSentAsync());
                    if (_token.IsCancellationRequested) return;
                    res.AddReturnedValue(await BuildingReviewBussines.ResendNotSentAsync());

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
