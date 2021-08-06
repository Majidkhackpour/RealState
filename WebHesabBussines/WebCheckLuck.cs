using System;
using System.Net.Http;
using System.Threading.Tasks;
using Services;

namespace WebHesabBussines
{
    public class WebCheckLuck
    {
        public static bool CheckHardSerial(string hSerial)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var res = client.GetStringAsync(Utilities.WebApi + "/Customer_GetByHardSerial/" + hSerial).Result;
                    return !string.IsNullOrEmpty(res);
                }
            }
            catch
            {
                return true;
            }
        }
    }
}
