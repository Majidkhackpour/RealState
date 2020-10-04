using System;
using System.Threading.Tasks;
using Services;

namespace Advertise.Classes
{
    public class TelegramSender
    {
        public string ApiKey { get; set; }
        public string ChatID { get; set; }
        public EnTelegramType ContactType { get; set; }


        public static TelegramSender GetChatLog_bot()
        {
            return new TelegramSender()
            {
                ApiKey = "1266025458:AAHiE5WcQWUIf_CizjFyBQyeChzQzxamNjM",
                ChatID = "@Chat_Log_Advertise",
                ContactType = EnTelegramType.Channel
            };
        }
        public static TelegramSender GetAdvertiseLog_bot()
        {
            return new TelegramSender()
            {
                ApiKey = "1250868882:AAGndzM_0qQ5jGdhIxnjjEejRgJoh2sS72w",
                ChatID = "@AdvertiseLog",
                ContactType = EnTelegramType.Channel
            };
        }


        public void Send(string message = "") => Task.Run(() => SendAsync(message));
        private async Task SendAsync(string message = "")
        {
            try
            {
                //var toWebTelegram = new WebTelegramMessage()
                //{
                //    Guid = Guid.NewGuid(),
                //    Message = message,
                //    ApiKey = ApiKey,
                //    contactType = ContactType,
                //    ContactInfo = ChatID,
                //};
                //await toWebTelegram.Sent2webAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
