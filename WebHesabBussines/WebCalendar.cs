using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;

namespace WebHesabBussines
{
    public class WebCalendar
    {
        private const string Url = "https://Novinrank.ir/Attendance/Calendar/";
        public DateTime DateM { get; set; }
        public string Monasebat { get; set; }
        public string Description { get; set; }
        public bool STRasmi { get; set; }
        public DateTime Modified { get; set; }
        public Guid Guid { get; set; }
        public static async Task<ReturnedSaveFuncInfoWithValue<List<WebCalendar>>> GetAllAsync()
        {
            var ret = new ReturnedSaveFuncInfoWithValue<List<WebCalendar>>() { value = new List<WebCalendar>() };
            try
            {
                var response = await (Url + "WebTaghvim").GetFromApi<List<WebCalendar>>();
                if (response.ResponseStatus == ResponseStatus.Success)
                    ret.value = response.Data;
                else
                    ret.AddError(response.ResponseStatus.ToString());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return ret;
        }
    }
}
