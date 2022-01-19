using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Payamak.FixSms
{
    public class OwnerSend
    {
        public static async Task<ReturnedSaveFuncInfo> SendAsync(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await Utilities.PingHostAsync());
                if (res.HasError) return res;


                var text = await GetTextAsync(bu);
                if (string.IsNullOrEmpty(text))
                {
                    res.AddReturnedValue(ReturnedState.Error, "متن پیش فرض خالی می باشد");
                    return res;
                }

                if (SettingsBussines.Setting.Sms.DefaultPanelGuid==Guid.Empty)
                {
                    res.AddReturnedValue(ReturnedState.Error, "پنل پبش فرض تعریف نشده است");
                    return res;
                }

                var panel = await SmsPanelsBussines.GetAsync(SettingsBussines.Setting.Sms.DefaultPanelGuid);
                if (panel == null)
                {
                    res.AddReturnedValue(ReturnedState.Error, "پنل پیش فرض معتبر نمی باشد");
                    return res;
                }

                var sApi = new Sms.Api(panel.API.Trim());

                var list = new List<string>();
                var pe = await PhoneBookBussines.GetAllAsync(bu.OwnerGuid, true);
                foreach (var item in pe)
                    list.Add(item.Tell);

                var res_ = sApi.Send(panel.Sender, list, text);
                if (res_.Count <= 0)
                {
                    res.AddReturnedValue(ReturnedState.Error, "ارتباط با پنل با شکست مواجه شد");
                    return res;
                }

                foreach (var result in res_)
                {
                    var smsLog = new SmsLogBussines()
                    {
                        Guid = Guid.NewGuid(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Cost = result.Cost,
                        Message = result.Message,
                        MessageId = result.Messageid,
                        Reciver = result.Receptor,
                        Sender = result.Sender,
                        StatusText = result.StatusText
                    };

                    await smsLog.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<string> GetTextAsync(BuildingBussines bu)
        {
            var res = "";
            try
            {
                res = SettingsBussines.Setting.Sms.OwnerText;

                if (res.Contains(Replacor.Owner.Code)) res = res.Replace(Replacor.Owner.Code, bu.Code);
                if (res.Contains(Replacor.Owner.DateSabt)) res = res.Replace(Replacor.Owner.DateSabt, bu.DateSh);
                if (res.Contains(Replacor.Owner.OwnerName))
                {
                    var owner = await PeoplesBussines.GetAsync(bu.OwnerGuid,null);
                    res = res.Replace(Replacor.Owner.OwnerName, owner?.Name);
                }
                if (res.Contains(Replacor.Owner.Region))
                {
                    var reg = await RegionsBussines.GetAsync(bu.RegionGuid);
                    res = res.Replace(Replacor.Owner.Region, reg?.Name);
                }
                if (res.Contains(Replacor.Owner.UserName))
                {
                    var user = await UserBussines.GetAsync(bu.UserGuid);
                    res = res.Replace(Replacor.Owner.UserName, user?.Name);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
