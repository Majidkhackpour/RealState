using Services;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebBackUp
    {
        public static async Task UploadFileAsync(string filePath, string fileName, string hddSerial)
        {
            try
            {
                var url = Utilities.WebApi + "/api/BackUpManager";
                Upload(url, filePath, fileName, hddSerial);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void Upload(string url, string filePath, string localFilename, string hardSerial)
        {
            try
            {
                var httpClient = new HttpClient();
                var fileStream = File.Open(filePath, FileMode.Open);
                var fileInfo = new FileInfo(filePath);

                var content = new MultipartFormDataContent();
                content.Headers.Add("hddSerial", hardSerial);
                content.Add(new StreamContent(fileStream), "\"file\"", $"\"{localFilename + $"_{hardSerial}" + fileInfo.Extension}\"");

                var taskUpload = httpClient.PostAsync(url, content).ContinueWith(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        var response = task.Result;
                    }

                    fileStream.Dispose();
                });

                taskUpload.Wait();
                httpClient.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
