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
        }
    }
}
