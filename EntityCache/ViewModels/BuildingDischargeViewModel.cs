using System;
using Services;

namespace EntityCache.ViewModels
{
    public class BuildingDischargeViewModel
    {
        public long Code { get; set; }
        public Guid FSideGuid { get; set; }
        public string FSideName { get; set; }
        public Guid SSideGuid { get; set; }
        public string SSideName { get; set; }
        public int Term { get; set; }
        public DateTime FromDate { get; set; }
        public string FromDateSh => Calendar.MiladiToShamsi(FromDate);
        public DateTime ToDate { get; set; }
        public string ToDateSh => Calendar.MiladiToShamsi(ToDate);
        public string BuildingCode { get; set; }
        public Guid BuildingGuid { get; set; }
    }
}
