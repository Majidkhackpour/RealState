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
        }
    }
}
