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
        }
    }
}
