using System;
using System.Collections.Generic;
using System.Linq;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SanadBussines : ISanad
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public long Number { get; set; }
        public EnSanadStatus SanadStatus { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SumDebit
        {
            get
            {
                if (Details == null || Details.Count <= 0) return 0;
                return Details.Sum(q => q.Debit);
            }
        }
        public decimal SumCredit
        {
            get
            {
                if (Details == null || Details.Count <= 0) return 0;
                return Details.Sum(q => q.Credit);
            }
        }
        public EnSanadType SanadType { get; set; }
        public List<SanadDetailBussines> Details { get; set; }
    }
}
