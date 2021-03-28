using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;

namespace EntityCache.Bussines
{
    public class GardeshBussines
    {
        public Guid Guid { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public bool Status { get; set; }
        public Guid MoeinGuid { get; set; }
        public string MoeinCode { get; set; }
        public string MoeinName { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilCode { get; set; }
        public string TafsilName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Rem { get; set; }
        public decimal Rem_ => Math.Abs(Rem);
        public string RemDiagnosis => Rem.AccountDiagnosis();
        public string Description { get; set; }


        public static async Task<List<GardeshBussines>> GetAllGardeshAsync(Guid tafsilGuid)
        {
            IEnumerable<GardeshBussines> list = null;
            try
            {
                list = await UnitOfWork.SanadDetail.GetAllGardeshAsync(tafsilGuid);
                list = list?.OrderBy(q => q.DateM);
                decimal rem = 0;
                foreach (var item in list ?? new List<GardeshBussines>())
                {
                    item.Rem = rem + item.Credit - item.Debit;
                    rem = item.Rem;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list?.ToList();
        }
    }
}
