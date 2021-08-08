using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.WebService
{
    public class WebServiceRepository
    {
        public WebServiceRepository()
        {
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

        private Task WebUserOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebTafsilOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebStatesOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebSanadDetailOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebSanadOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebRentalOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebRegionOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebReceptionOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebPhoneBookOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebPeopleGroupOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebPeopleOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebPardakhtOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebMoeinOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebKolOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebKitchenServiceOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebFloorCoverOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebDocumentTypeOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebContractOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebCityOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingViewOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingTypeOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingRequestRegionOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingRequestOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingRelatedOptionsOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingOptionsOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingConditionOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private Task WebBuildingAccountTypeOnOnSaveResult(Guid arg1, ServerStatus arg2, DateTime arg3)
        {
            throw new NotImplementedException();
        }

        private async Task WebBuildingOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Building, objGuid, st, dateM);
        private async Task WebBankOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Bank, objGuid, st, dateM);
        private async Task WebAdvisorOnOnSaveResult(Guid objGuid, ServerStatus st, DateTime dateM)
            => await TempBussines.UpdateEntityAsync(EnTemp.Advisor, objGuid, st, dateM);
    }
}
