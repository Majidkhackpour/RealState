using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Payamak.FixSms
{
    public class RequestSend
    {
        public static async Task<ReturnedSaveFuncInfo> SendAsync(BuildingRequestBussines bu)
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
                var pe = await PhoneBookBussines.GetAllAsync(bu.AskerGuid, true);
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

        private static string Text(BuildingRequestBussines bu)
        {
            var res = "";
            try
            {
                res = Settings.Classes.Payamak.SayerText;

                if (res.Contains(Replacor.Request.DateSabt)) res = res.Replace(Replacor.Request.DateSabt, bu.DateSh);
                if (res.Contains(Replacor.Request.Name))
                {
                    var owner = PeoplesBussines.Get(bu.AskerGuid);
                    res = res.Replace(Replacor.Request.Name, owner?.Name);
                }
                if (res.Contains(Replacor.Request.UserName))
                {
                    var user = UserBussines.Get(bu.UserGuid);
                    res = res.Replace(Replacor.Request.UserName, user?.Name);
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
