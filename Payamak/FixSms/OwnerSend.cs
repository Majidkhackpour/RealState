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


                var text = Text(bu);
                if (string.IsNullOrEmpty(text))
                {
                    res.AddReturnedValue(ReturnedState.Error, "متن پیش فرض خالی می باشد");
                    return res;
                }

                if (string.IsNullOrEmpty(Settings.Classes.Payamak.DefaultPanelGuid))
                {
                    res.AddReturnedValue(ReturnedState.Error, "پنل پبش فرض تعریف نشده است");
                    return res;
                }

                var panel = SmsPanelsBussines.Get(Guid.Parse(Settings.Classes.Payamak.DefaultPanelGuid));
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
                        UserGuid = User.clsUser.CurrentUser.Guid,
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
        private static string Text(BuildingBussines bu)
        {
            var res = "";
            try
            {
                res = Settings.Classes.Payamak.OwnerText;

                if (res.Contains(Replacor.Owner.Code)) res = res.Replace(Replacor.Owner.Code, bu.Code);
                if (res.Contains(Replacor.Owner.DateSabt)) res = res.Replace(Replacor.Owner.DateSabt, bu.DateSh);
                if (res.Contains(Replacor.Owner.OwnerName))
                {
                    var owner = PeoplesBussines.Get(bu.OwnerGuid);
                    res = res.Replace(Replacor.Owner.OwnerName, owner?.Name);
                }
                if (res.Contains(Replacor.Owner.Region))
                {
                    var reg = RegionsBussines.Get(bu.RegionGuid);
                    res = res.Replace(Replacor.Owner.Region, reg?.Name);
                }
                if (res.Contains(Replacor.Owner.UserName))
                {
                    var user = UserBussines.Get(bu.UserGuid);
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
