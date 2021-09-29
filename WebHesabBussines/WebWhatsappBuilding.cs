using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Services;
using Services.Interfaces;

namespace WebHesabBussines
{
    public class WebWhatsappBuilding : IWhatsappBuilding
    {
        private static string Url = Utilities.WebApi + "/api/WhatsappBuilding/SendAsync";

        public string Number { get; set; }
        public string ApiCode { get; set; }
        public string Message { get; set; }


        public async Task SaveAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = Json.ToStringJson(this);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Url, content);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
