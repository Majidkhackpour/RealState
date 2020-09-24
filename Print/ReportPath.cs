using System;
using System.IO;
using System.Windows.Forms;
using Services;

namespace Print
{
    public class ReportPath
    {
        public static string ReportPath_ => Application.StartupPath + @"\گزارشات";
        public static string Create()
        {
            try
            {
                var path = CreatePath(ReportPath_);
                return path;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static string CreatePath(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
