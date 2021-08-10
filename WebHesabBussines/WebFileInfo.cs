using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Services;

namespace WebHesabBussines
{
    public class WebFileInfo
    {
        public static async Task<ReturnedSaveFuncInfo> UploadBitmapAsync(byte[] img, string imageName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var form = new MultipartFormDataContent
                    {
                        {new ByteArrayContent(img, 0, img.Count()), "picture", imageName}
                    };
                    var response = await httpClient.PostAsync(Utilities.WebApi + "/PostImage", form);
                    response.EnsureSuccessStatusCode();
                    var responseBody = response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
