using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class ContractMapper
    {
        public static ContractMapper Instance { get; private set; } = new ContractMapper();
        public WebContract Map(ContractBussines cls)
        {
            return new WebContract()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                Status = cls.Status,
                Code = cls.Code,
                MinorPrice = cls.MinorPrice,
                UserGuid = cls.UserGuid,
                TotalPrice = cls.TotalPrice,
                Description = cls.Description,
                Type = cls.Type,
                Term = cls.Term,
                SecondSideGuid = cls.SecondSideGuid,
                Delay = cls.Delay,
                SarQofli = cls.SarQofli,
                BankName = cls.BankName,
                IsTemp = cls.IsTemp,
                FirstSideGuid = cls.FirstSideGuid,
                Shobe = cls.Shobe,
                CheckNo = cls.CheckNo,
                FromDate = cls.FromDate,
                DischargeDate = cls.DischargeDate,
                SarResid = cls.SarResid,
                BuildingGuid = cls.BuildingGuid,
                SetDocDate = cls.SetDocDate,
                SetDocPlace = cls.SetDocPlace,
                DateM = cls.DateM,
                HardSerial = cls.HardSerial,
                BazaryabGuid = cls.BazaryabGuid,
                BazaryabPrice = cls.BazaryabPrice,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                FirstDiscount = cls.FirstDiscount,
                FirstTotalPrice = cls.FirstTotalPrice,
                FirstTax = cls.FirstTax,
                SecondTax = cls.SecondTax,
                SecondDiscount = cls.SecondDiscount,
                SanadNumber = cls.SanadNumber,
                FirstAvarez = cls.FirstAvarez,
                SecondAvarez = cls.SecondAvarez,
                SecondTotalPrice = cls.SecondTotalPrice,
                fBabat = cls.fBabat,
                sBabat = cls.sBabat,
                CodeInArchive = cls.CodeInArchive
            };
        }
    }
}
