using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.FilterObjects;

namespace EntityCache.Bussines.ReportBussines
{
    public class ContractReportBusiness
    {
        public Guid Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateSh => Calendar.MiladiToShamsi(CreateDate);
        public string CodeInArchive { get; set; } = "";
        public string HologramSerial { get; set; } = "";
        public long ContractCode { get; set; }
        public string FirstSideName { get; set; } = "";
        public string SecondSideName { get; set; } = "";
        public EnRequestType Type { get; set; }
        public string TypeName => Type.GetDisplay();

        public static async Task<List<ContractReportBusiness>> GetAllAsync(ContractFilter filters) => await UnitOfWork.Contract.GetAllReportAsync(Cache.ConnectionString, filters);
    }
}
