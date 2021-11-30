﻿using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
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
                CodeInArchive = cls.CodeInArchive,
                PishPrice = cls.PishPrice,
                Office = cls.Office,
                PeopleCount = cls.PeopleCount,
                PayankarNo = cls.PayankarNo,
                Page = cls.Page,
                PartNo = cls.PartNo,
                PayankarDate = cls.PayankarDate,
                RealStateCode = cls.RealStateCode,
                BuildingZip = cls.BuildingZip,
                BuildingRegistrationNo = cls.BuildingRegistrationNo,
                ParkingNo = cls.ParkingNo,
                CheckNoTo = cls.CheckNoTo,
                HologramCode = cls.HologramCode,
                ParkingMasahat = cls.ParkingMasahat,
                SetDocNo = cls.SetDocNo,
                StoreNo = cls.StoreNo,
                SecondSideDelay = cls.SecondSideDelay,
                SettlementDate = cls.SettlementDate,
                BuildingPhoneNumber = cls.BuildingPhoneNumber,
                FirstSideDelay = cls.FirstSideDelay,
                PhoneLineCount = cls.PhoneLineCount,
                BuildingRegistrationNoSub = cls.BuildingRegistrationNoSub,
                BankNameEjare = cls.BankNameEjare,
                BuildingPlack = cls.BuildingPlack,
                ManufacturingLicenseDate = cls.ManufacturingLicenseDate,
                SarResidTo = cls.SarResidTo,
                AmountOfRent = cls.AmountOfRent,
                SanadSerial = cls.SanadSerial,
                BuildingNumber = cls.BuildingNumber,
                ManufacturingLicensePlace = cls.ManufacturingLicensePlace,
                DocumentAdjust = cls.DocumentAdjust,
                BuildingCosumable = cls.BuildingCosumable,
                StoreMasahat = cls.StoreMasahat,
                ShobeEjare = cls.ShobeEjare,
                BuildingRegistrationNoOrigin = cls.BuildingRegistrationNoOrigin,
                GulidType = cls.GulidType,
                Witness1 = cls.Witness1,
                Witness2 = cls.Witness2,
                CheckPrice1 = cls.CheckPrice1,
                CheckPrice2 = cls.CheckPrice2
            };
        }
        public List<WebContract> MapList(List<ContractBussines> cls)
        {
            var list = new List<WebContract>();
            try
            {
                foreach (var item in cls)
                    list.Add(Map(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
