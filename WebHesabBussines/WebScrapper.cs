using Services;
using Services.Interfaces.Department;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebScrapper : IScrapper
    {
        public Guid Guid { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
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
        public AdvertiseType Type { get; set; }
        public string FloorCover { get; set; } = "";
        public string Colling { get; set; } = "";
        public string Hitting { get; set; } = "";


        public static async Task<ReturnedSaveFuncInfo> Send2ServerAsync(List<WebScrapper> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var url = Utilities.WebApi + "/api/Scrapper/SaveAsync";
                foreach (var item in list)
                {
                    var t = await Extentions.PostToApi<WebScrapper, WebScrapper>(item, url);
                    if (t.ResponseStatus != ResponseStatus.Success)
                        res.AddError("Error in Send To Server");
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<List<WebScrapper>> GetAllAsync(DateTime insertedDate)
        {
            var list = new List<WebScrapper>();
            try
            {
                var today = $"{insertedDate:ddd,' 'dd' 'MMM' 'yyyy' 'HH':'mm':'ss' 'K}";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("cusGuid", WebCustomer.Customer.Guid.ToString());
                    client.DefaultRequestHeaders.Add("date", today);
                    var res = await client.GetStringAsync(Utilities.WebApi + "/Scrapper_GetAll");
                    list = res.FromJson<List<WebScrapper>>();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
