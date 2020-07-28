using System;
using EntityCache.Bussines;
using PacketParser.Services;

namespace User
{
    public static class clsUser
    {
        public static DateTime DateVorrod { get; set; }
        public static string DateSh => Calendar.MiladiToShamsi(DateVorrod);
        public static UserBussines CurrentUser { get; set; }
    }
}
