using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.FilterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class BuildingReportBussines
    {
        public Guid Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(CreateDate);
        public string Code { get; set; }
        public string OwnerName { get; set; }
        public string UserName { get; set; }
        public decimal SellPrice { get; set; }
        public decimal VamPrice { get; set; }
        public decimal QestPrice { get; set; }
        public string DocumentTypeName { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public int Masahat { get; set; }
        public int ZirBana { get; set; }
        public string RegionName { get; set; }
        public string Address { get; set; }
        public string BuildingConditionName { get; set; }
        public string BuildingTypeName { get; set; }
        public string BuildingAccountTypeName { get; set; }
        public string BuildingViewName { get; set; }
        public string FloorCoverName { get; set; }
        public string KitchenServiceName { get; set; }
        public string SaleSakht { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public AdvertiseType? AdvertiseType { get; set; }
        public string RentalAuthorityName { get; set; }
        public EnBuildingParent Parent { get; set; }
        public Guid RegionGuid { get; set; }


        public static async Task<List<BuildingReportBussines>> GetAllAsync(BuildingFilter filters) => await UnitOfWork.Building.SearchAsync(Cache.ConnectionString, filters);
        public static List<BuildingReportBussines> GetAll(BuildingFilter filters) => AsyncContext.Run(() => GetAllAsync(filters));
    }
}
