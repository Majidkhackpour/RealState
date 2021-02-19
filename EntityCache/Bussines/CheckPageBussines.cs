using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class CheckPageBussines : ICheckPage
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid CheckGuid { get; set; }
        public DateTime? DatePardakht { get; set; }
        public long Number { get; set; }
        public Guid? ReceptorGuid { get; set; }
        public DateTime? DateSarresid { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EnCheckSh CheckStatus { get; set; }


        public static async Task<List<CheckPageBussines>> GetAllAsync(Guid checkGuid) =>
            await UnitOfWork.CheckPage.GetAllAsync(checkGuid);
    }
}
