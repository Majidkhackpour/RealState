using System;
using System.IO;
using Services;

namespace Print.Classes
{
    public class clsUserPerformence
    {
        public static string FolderName => "عملکرد کاربران";

        public class List
        {
            public static Stimulsoft.Report.StiReport GetSti(Stimulsoft.Report.StiReport sti, EnPrintType peper)
            {
                try
                {
                    ReportPath.CreatePath(ReportPath.ReportPath_);
                    ReportPath.CreatePath(ReportPath.ReportPath_ + @"\" + FolderName);
                    switch (peper)
                    {
                        case EnPrintType.A4: return User_Prf_List_A4(sti);
                        case EnPrintType.A5: return User_Prf_List_A5(sti);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return sti;
            }
            public static Stimulsoft.Report.StiReport User_Prf_List_A4(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\User_Prf_List_A4.mrt";

                    if (!File.Exists(fullAdd))
                        File.WriteAllBytes(fullAdd, null /*AddReportFileToResourceAndResourceNameIsHere*/);
                    sti.Load(fullAdd);
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return sti;
            }
            public static Stimulsoft.Report.StiReport User_Prf_List_A5(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\User_Prf_List_A5.mrt";

                    if (!File.Exists(fullAdd))
                        File.WriteAllBytes(fullAdd, null /*AddReportFileToResourceAndResourceNameIsHere*/);
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
