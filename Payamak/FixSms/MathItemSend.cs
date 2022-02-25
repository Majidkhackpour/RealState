using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Payamak.FixSms
{
    public class MathItemSend
    {
        public static async Task<ReturnedSaveFuncInfo> SendAsync(string text, List<string> numbers)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await Utilities.PingHostAsync());
                if (res.HasError) return res;

                if (string.IsNullOrEmpty(text))
                {
                    res.AddReturnedValue(ReturnedState.Error, "متن پیش فرض خالی می باشد");
                    return res;
                }

                if (SettingsBussines.Setting.Sms.DefaultPanelGuid == Guid.Empty)
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


                var res_ = sApi.Send(panel.Sender, numbers, text);
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
        public static string GetText(BuildingRequestBussines bu)
        {
            var res = "";
            try
            {
                res = SettingsBussines.Setting?.Sms?.SendMatchText ?? "";
                if (string.IsNullOrEmpty(res)) return res;

                if (res.Contains(Replacor.MathItems.Name)) res = res.Replace(Replacor.MathItems.Name, bu.AskerName);
                if (res.Contains(Replacor.MathItems.DateSh)) res = res.Replace(Replacor.MathItems.DateSh, Calendar.MiladiToShamsi(DateTime.Now));
                if (res.Contains(Replacor.MathItems.TelegramChannel))
                {
                    var telChn = SettingsBussines.Setting.Telegram.Channel;
                    if (!string.IsNullOrEmpty(telChn))
                        res = res.Replace(Replacor.MathItems.TelegramChannel, telChn);
                }
                if (res.Contains(Replacor.MathItems.Tell))
                {
                    var tell = SettingsBussines.Setting.CompanyInfo.ManagerTell;
                    if (!string.IsNullOrEmpty(tell))
                        res = res.Replace(Replacor.MathItems.Tell, tell);
                }
                if (res.Contains(Replacor.MathItems.Address))
                {
                    var add = SettingsBussines.Setting.CompanyInfo.ManagerAddress;
                    if (!string.IsNullOrEmpty(add))
                        res = res.Replace(Replacor.MathItems.Address, add);
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
