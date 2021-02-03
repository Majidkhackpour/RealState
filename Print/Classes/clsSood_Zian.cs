using System;
using System.IO;
using Services;

namespace Print.Classes
{
    public class clsSood_Zian
    {
        public static string FolderName => "ترازنامه";
        public class One
        {
            public static Stimulsoft.Report.StiReport GetSti(Stimulsoft.Report.StiReport sti, EnPrintType peper)
            {
                try
                {
                    ReportPath.CreatePath(ReportPath.ReportPath_);
                    ReportPath.CreatePath(ReportPath.ReportPath_ + @"\" + FolderName);
                    return Taraz_One_A5(sti);
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return sti;
            }
            public static Stimulsoft.Report.StiReport Taraz_One_A5(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\Taraz_One_A4.mrt";

                    if (!File.Exists(fullAdd))
                        File.WriteAllBytes(fullAdd, Properties.Resources.Taraz_One_A4);
                    sti.Load(fullAdd);
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return sti;
            }
        }
    }
}
