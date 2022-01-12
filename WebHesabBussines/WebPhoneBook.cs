using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebPhoneBook : IPhoneBook
    {
        private static string Url = Utilities.WebApi + "/api/BuildingPhoneBook/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Tell { get; set; }
        public string Title { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public Guid ParentGuid { get; set; }


        private async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SaveAsync()
        {
            var ret = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var res = await Extentions.PostToApi<WebPhoneBook, WebPhoneBook>(this, Url, WebCustomer.Customer.Guid);
                ret.value = res?.ResponseStatus??ResponseStatus.ErrorInServer;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }

            return ret;
        }
        public static async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SaveAsync(WebPhoneBook cls)
        {
            var res = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var ret = await cls.SaveAsync();
                res.AddReturnedValue(ret);
                ret.value = res.value;
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
