using AutoMapper;
using EntityCache.Bussines;
using Persistence.Entities;

namespace EntityCache.Assistence
{
    public class SqlProfile : Profile
    {
        public SqlProfile()
        {
            CreateMap<UserBussines, Users>().ReverseMap();
            CreateMap<StatesBussines, States>().ReverseMap();
            CreateMap<CitiesBussines, Cities>().ReverseMap();
            CreateMap<RegionsBussines, Regions>().ReverseMap();
            CreateMap<NaqzBussines, Naqz>().ReverseMap();
            CreateMap<BuildingOptionsBussines, BuildingOptions>().ReverseMap();
            CreateMap<BuildingAccountTypeBussines, BuildingAccountType>().ReverseMap();
            CreateMap<FloorCoverBussines, FloorCover>().ReverseMap();
            CreateMap<KitchenServiceBussines, KitchenService>().ReverseMap();
            CreateMap<DocumentTypeBussines, DocumentType>().ReverseMap();
            CreateMap<RentalAuthorityBussines, RentalAuthority>().ReverseMap();
            CreateMap<BuildingViewBussines, BuildingView>().ReverseMap();
            CreateMap<BuildingConditionBussines, BuildingCondition>().ReverseMap();
            CreateMap<SettingsBussines, Settings>().ReverseMap();
            CreateMap<BuildingTypeBussines, BuildingType>().ReverseMap();
            CreateMap<PeopleGroupBussines, PeopleGroup>().ReverseMap();
            CreateMap<PeoplesBussines, Peoples>().ReverseMap();
            CreateMap<PeoplesBankAccountBussines, PeopleBankAccount>().ReverseMap();
            CreateMap<PhoneBookBussines, PhoneBook>().ReverseMap();
            CreateMap<SmsPanelsBussines, SmsPanels>().ReverseMap();
            CreateMap<SimcardBussines, Simcard>().ReverseMap();
            CreateMap<AdvertiseLogBussines, AdvertiseLog>().ReverseMap();
            CreateMap<BuildingBussines, Building>().ReverseMap();
            CreateMap<BuildingRelatedOptionsBussines, BuildingRelatedOptions>().ReverseMap();
            CreateMap<BuildingGalleryBussines, BuildingGallery>().ReverseMap();
            CreateMap<BuildingRequestBussines, BuildingRequest>().ReverseMap();
            CreateMap<BuildingRequestRegionBussines, BuildingRequestRegion>().ReverseMap();
            CreateMap<ContractBussines, Contract>().ReverseMap();
            CreateMap<UserLogBussines, UserLog>().ReverseMap();
            CreateMap<SmsLogBussines, SmsLog>().ReverseMap();
            CreateMap<NoteBussines, Note>().ReverseMap();
            CreateMap<SerializedDataBussines, SerializedData>().ReverseMap();
            CreateMap<AdvertiseRelatedRegionBussines, AdvertiseRelatedRegion>().ReverseMap();
            CreateMap<AdvTokenBussines, AdvToken>().ReverseMap();
            CreateMap<BackUpLogBussines, BackUpLog>().ReverseMap();
            CreateMap<TempBussines, Temp>().ReverseMap();
            CreateMap<FileInfoBussines, FileInfo>().ReverseMap();
            CreateMap<KolBussines, Kol>().ReverseMap();
            CreateMap<MoeinBussines, Moein>().ReverseMap();
            CreateMap<TafsilBussines, Tafsil>().ReverseMap();
            CreateMap<BankBussines, Bank>().ReverseMap();
            CreateMap<DasteCheckBussines, DasteCheck>().ReverseMap();
            CreateMap<CheckPageBussines, CheckPage>().ReverseMap();
            CreateMap<SanadBussines, Sanad>().ReverseMap();
            CreateMap<SanadDetailBussines, SanadDetail>().ReverseMap();
            CreateMap<ReceptionBussines, Reception>().ReverseMap();
            CreateMap<ReceptionNaqdBussines, ReceptionNaqd>().ReverseMap();
            CreateMap<ReceptionHavaleBussines, ReceptionHavale>().ReverseMap();
            CreateMap<ReceptionCheckBussines, ReceptionCheck>().ReverseMap();
            CreateMap<BankSegestBussines, BankSegest>().ReverseMap();
            CreateMap<PardakhtBussines, Pardakht>().ReverseMap();
            CreateMap<PardakhtNaqdBussines, PardakhtNaqd>().ReverseMap();
            CreateMap<PardakhtHavaleBussines, PardakhtHavale>().ReverseMap();
            CreateMap<PardakhtCheckShakhsiBussines, PardakhtCheckShakhsi>().ReverseMap();
            CreateMap<PardakhtCheckMoshtariBussines, PardakhtCheckMoshtari>().ReverseMap();
            CreateMap<ReceptionCheckAvalDoreBussines, ReceptionCheckAvalDore>().ReverseMap();
            CreateMap<PardakhtCheckAvalDoreBussines, PardakhtCheckAvalDore>().ReverseMap();
        }
    }
}
