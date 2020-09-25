using Services;

namespace EntityCache.ViewModels
{
    public class ForoshViewModel
    {
        public string fName { get; set; }
        public string fFatherName { get; set; }
        public string fIdCode { get; set; }
        public string fIssuedFrom { get; set; }
        public string fDateBirth { get; set; }
        public string fNationalCode { get; set; }
        public string fAddress { get; set; }
        public string sName { get; set; }
        public string sFatherName { get; set; }
        public string sIdCode { get; set; }
        public string sIssuedFrom { get; set; }
        public string sDateBirth { get; set; }
        public string sNationalCode { get; set; }
        public string sAddress { get; set; }
        public string ContractDesc { get; set; }
        public int DongCount { get; set; }
        public string BuildingAddress { get; set; }
        public int Masahat { get; set; }
        public decimal TotalPrice { get; set; }
        public string strTotal => NumberToString.Num2Str(TotalPrice.ToString());
        public decimal MinorPrice { get; set; }
        public decimal Beyane { get; set; }
        public string strBeyane => NumberToString.Num2Str(Beyane.ToString());
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Shobe { get; set; }
        public string Sarresid { get; set; }
        public string DischargeDate { get; set; }
        public string BuildingAccountType { get; set; }
        public decimal Delay { get; set; }
        public string UnitName { get; set; }
        public string UnitCity { get; set; }
        public string UnitAddress { get; set; }
        public decimal Commition { get; set; }
        public string ContractDate { get; set; }
        public string ContractTime { get; set; }
    }
}
