namespace EntityCache.ViewModels
{
    public class ContractOrderViewModel
    {
        public long Code { get; set; }
        public string DateSh { get; set; }
        public string Description { get; set; }
        public string SellerName { get; set; }
        public string SellerNationalCode { get; set; }
        public string SellerTell { get; set; }
        public string SellerAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEconomyCode { get; set; }
        public string CustomerNationalCode { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerZip { get; set; }
        public string CustomerTell { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal SumAfterDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal Avarez { get; set; }
        public decimal TotalSum { get; set; }
    }
}
