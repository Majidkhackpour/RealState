using System;
using Services.Interfaces.Department;

namespace WebHesabBussines
{
    public class WebScrapper : IScrapper
    {
        public Guid Guid { get; set; }
        public string Title { get; set; } = "";
        public string State { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string Number { get; set; } = "";
        public string BuildingType { get; set; } = "";
        public int Masahat { get; set; } = 0;
        public string SaleSakht { get; set; } = "";
        public int RoomCount { get; set; } = 0;
        public bool Evelator { get; set; } = false;
        public bool Parking { get; set; } = false;
        public bool Store { get; set; } = false;
        public bool Balcony { get; set; } = false;
        public decimal RahnPrice { get; set; } = 0;
        public decimal EjarePrice { get; set; } = 0;
        public decimal SellPrice { get; set; } = 0;
        public string RentalAuthority { get; set; } = "";
        public int TabaqeCount { get; set; } = 0;
        public int TabaqeNo { get; set; } = 0;
        public string Description { get; set; } = "";
        public int VahedPerTabaqe { get; set; } = 0;
        public string BuildingSide { get; set; } = "";
        public string ImagesList { get; set; } = "";
    }
}
