using System;

namespace EntityCache.ViewModels
{
    public class OperationListPrintViewModel
    {
        public string PrintDateSh { get; set; }
        public string PrintTime { get; set; }
        public long Number { get; set; }
        public string DateSh { get; set; }
        public DateTime DateM { get; set; }
        public string TafsilName { get; set; }
        public string Description { get; set; }
        public decimal Naqd { get; set; }
        public decimal Check { get; set; }
        public decimal Havale { get; set; }
        public decimal TotalSum { get; set; }
        public int Count { get; set; }
        public decimal TotalRow { get; set; }
        public string TotalHorouf { get; set; }
    }
}
