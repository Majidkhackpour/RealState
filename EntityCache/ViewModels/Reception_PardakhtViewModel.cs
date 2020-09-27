using Services;

namespace EntityCache.ViewModels
{
    public class Reception_PardakhtViewModel
    {
        public string DateSh { get; set; }
        public string Time { get; set; }
        public string SideName { get; set; }
        public decimal NaqdPrice { get; set; }
        public string strNaqd => NumberToString.Num2Str(NaqdPrice.ToString()) + "ریال";
        public decimal BankPrice { get; set; }
        public string strBank => NumberToString.Num2Str(BankPrice.ToString()) + "ریال";
        public string ResidNo { get; set; }
        public decimal CheckPrice { get; set; }
        public string strCheck => NumberToString.Num2Str(CheckPrice.ToString()) + "ریال";
        public string CheckNo { get; set; }
        public string Sarresid { get; set; }
        public string BankName { get; set; }
        public decimal TotalPrice { get; set; }
        public string strTotal => NumberToString.Num2Str(TotalPrice.ToString()) + "ریال";
    }
}
