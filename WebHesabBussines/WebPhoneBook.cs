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
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Tell { get; set; }
        public string Title { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public Guid ParentGuid { get; set; }


        private async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<WebPhoneBook, WebPhoneBook>(this, Url, WebCustomer.Customer.Guid);
                if (res.ResponseStatus != ResponseStatus.Success)
                    return;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebPhoneBook cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                await cls.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<WebPhoneBook> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls == null || cls.Count <= 0) return res;
                foreach (var item in cls)
                    res.AddReturnedValue(await SaveAsync(item));
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
