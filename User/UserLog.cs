using System;
using EntityCache.Bussines;
using PacketParser.Interfaces;
using Services;

namespace User
{
    public class UserLog : IUserLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid UserGuid { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(Date);
        public string Time => Date.ToShortTimeString();
        public EnLogAction Action { get; set; }
        public string ActionName => Action.GetDisplay();
        public EnLogPart Part { get; set; }
        public string PartName => Part.GetDisplay();
        public string Description { get; set; }

        public static void Save(EnLogAction action, EnLogPart part)
        {
            try
            {
                var log = new UserLogBussines
                {
                    Guid = Guid.NewGuid(),
                    UserGuid = clsUser.CurrentUser.Guid,
                    Description =
                        $"انجام عملیات {action.GetDisplay()} در بخش {part.GetDisplay()} در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} در ساعت {DateTime.Now.ToShortTimeString()}",
                    Action = action,
                    Part = part
                };

                log.Save();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

    }
}
