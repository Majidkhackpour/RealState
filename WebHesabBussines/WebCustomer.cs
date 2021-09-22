using System;
using System.Net.Http;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Department;

namespace WebHesabBussines
{
    public class WebCustomer : ICustomers
    {
        private static WebCustomer _cus = null;
        public Guid Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string NationalCode { get; set; }
        public string AppSerial { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Tell1 { get; set; }
        public string Tell2 { get; set; }
        public string Tell3 { get; set; }
        public string Tell4 { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid UserGuid { get; set; }
        public decimal Account { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SiteUrl { get; set; }
        public string HardSerial { get; set; }
        public string LkSerial { get; set; }
        public bool isBlock { get; set; }
        public bool isWebServiceBlock { get; set; }
        public static WebCustomer Customer { get => _cus; set => _cus = value; }



        public static async Task<WebCustomer> GetByHardSerialAsync(string hSerial)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 10);
                    var res = await client.GetStringAsync(Utilities.WebApi + "/Customer_GetByHardSerial/" + hSerial);
                    var user = res.FromJson<WebCustomer>();
                    return user;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static async Task<WebCustomer> GetByImeiAsync(string imei)
        {
            try
            {
                await Task.Delay(2000);
                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 10);
                    var res = await client.GetStringAsync(Utilities.WebApi + "/Customer_GetByImie/" + imei);
                    var user = res.FromJson<WebCustomer>();
                    return user;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static WebCustomer GetByImei(string imei) => AsyncContext.Run(() => GetByImeiAsync(imei));
        public static WebCustomer GetByHardSerial(string hSerial) => AsyncContext.Run(() => GetByHardSerialAsync(hSerial));
        public static bool CheckCustomer() => Customer != null && Customer.Guid != Guid.Empty;
    }
}
