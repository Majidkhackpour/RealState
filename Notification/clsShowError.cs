using System;
using System.Drawing;
using System.Linq;
using System.Text;
using Services;

namespace Notification
{
    public class clsShowError
    {
        private string title;

        public string Text { get; set; }
        public string Title
        {
            get => title;
            set
            {
                try
                {
                    var t = (value?.Length ?? 0) > 500 ? value?.Substring(0, 500) : value;
                    var list = t?.Replace("\r", "")?.Split('\n');
                    list = list?.Where(q => !string.IsNullOrEmpty(q))?.ToArray();
                    if (list?.Count() > 5) t = string.Join("\r\n", list?.Take(5));
                    title = t;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public enType Type { get; set; }
        public Image Icon { get; set; }
        public string MoreDetail { get; set; } = "...";



        public static ENSource Source { get; set; }
    }

    public enum enType
    {
        Error = 0,
        Warning = 1,
        Information = 2
    }
}
