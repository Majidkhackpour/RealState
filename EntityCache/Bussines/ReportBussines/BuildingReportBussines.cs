﻿using EntityCache.Assistence;
using Persistence;
using Services;
using Services.FilterObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EntityCache.Bussines.ReportBussines
{
    public class BuildingReportBussines : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isChecked = false;

        public Guid Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(CreateDate);
        public string Code { get; set; }
        public Guid OwnerGuid { get; set; }
        public string OwnerName { get; set; }
        public string UserName { get; set; }
        public decimal SellPrice { get; set; }
        public string SellPriceForDisplay => SellPrice.ToString("N0");
        public decimal VamPrice { get; set; }
        public string VamPriceForDisplay => VamPrice.ToString("N0");
        public decimal QestPrice { get; set; }
        public string QestPriceForDisplay => QestPrice.ToString("N0");
        public string DocumentTypeName { get; set; }
        public decimal RahnPrice1 { get; set; }
        public string RahnForDisplay => RahnPrice1.ToString("N0");
        public decimal EjarePrice1 { get; set; }
        public string EjareForDisplay => EjarePrice1.ToString("N0");
        public int Masahat { get; set; }
        public string MasahatForDisplay => $"{Masahat} مترمربع";
        public int ZirBana { get; set; }
        public string ZirBanaForDisplay => $"{ZirBana} مترمربع";
        public string RegionName { get; set; }
        public string Address { get; set; }
        public string BuildingConditionName { get; set; }
        public string BuildingTypeName { get; set; }
        public Guid? BuildingAccountTypeGuid { get; set; } = null;
        public string BuildingAccountTypeName { get; set; }
        public string BuildingViewName { get; set; }
        public string FloorCoverName { get; set; }
        public string KitchenServiceName { get; set; }
        public string SaleSakht { get; set; }
        public int RoomCount { get; set; }
        public string RoomCountForDisplay => RoomCount <= 0 ? "بدون خواب" : $"{RoomCount} خواب";
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public AdvertiseType? AdvertiseType { get; set; }
        public string RentalAuthorityName { get; set; }
        public EnBuildingParent Parent { get; set; } = EnBuildingParent.None;
        public string ParentName => Parent.GetDisplay();
        public Guid RegionGuid { get; set; }
        public string WindowName { get; set; }
        public string ZoncanName { get; set; }
        public double TabaqeCount { get; set; }
        public double TabaqeNo { get; set; }
        public EnBuildingSide Side { get; set; } = EnBuildingSide.None;
        public string SideName => Side.GetDisplay();
        public string Hitting { get; set; }
        public string Colling { get; set; }
        public EnKhadamati? Water { get; set; }
        public EnKhadamati? Gas { get; set; }
        public EnKhadamati? Barq { get; set; }
        public double Dang { get; set; }
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
            }
        }
        public ServerStatus ServerStatus { get; set; }
        public byte[] ServerStatusImage
        {
            get
            {
                if (ServerStatus == ServerStatus.Delivered || ServerStatus == ServerStatus.DirectDelivery)
                    return ImageResourceManager.ServerStatusDelivered;
                if (ServerStatus == ServerStatus.DeliveryError)
                    return ImageResourceManager.ServerStatusDeliveryFailed;
                if (ServerStatus == ServerStatus.Sent)
                    return ImageResourceManager.ServerStatusSent;
                if (ServerStatus == ServerStatus.SendError)
                    return ImageResourceManager.ServerStatusSentError;
                return ImageResourceManager.ServerStatusNone;
            }
        }


        public static async Task<List<BuildingReportBussines>> GetAllAsync(BuildingFilter filters) => await UnitOfWork.Building.SearchAsync(Cache.ConnectionString, filters);
        public static async Task<BuildingReportBussines> GetAsync(Guid guid) => await UnitOfWork.Building.GetFromReportAsync(Cache.ConnectionString, guid);
    }
}
