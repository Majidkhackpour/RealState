using System;
using System.Drawing;
using Services;

namespace Notification
{
    public static class clsNotification
    {
        public static void Init(Color color)
        {
            try
            {
                Color = color;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public static Color Color { get; set; }
    }
}
