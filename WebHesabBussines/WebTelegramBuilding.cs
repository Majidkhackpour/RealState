using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.Interfaces;

namespace WebHesabBussines
{
    public class WebTelegramBuilding : ITelegramBuilding
    {
        private static string Url = Utilities.WebApi + "/api/TelegramBuilding/SendAsync";


        public Guid BuildingGuid { get; set; }
        public string BotApi { get; set; }
        public string Channel { get; set; }
        public string Content { get; set; }


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
