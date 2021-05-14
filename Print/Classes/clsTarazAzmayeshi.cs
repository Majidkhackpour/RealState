﻿using System;
using System.IO;
using Services;

namespace Print.Classes
{
    public class clsTarazAzmayeshi
    {
        public static string FolderName => "تراز آزمایشی";

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
                        case EnPrintType.Pdf_A4: return TarazAzmayeshi_A4(sti);
                        case EnPrintType.Pdf_A5: return TarazAzmayeshi_A5(sti);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return sti;
            }
            public static Stimulsoft.Report.StiReport TarazAzmayeshi_A4(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\TarazAzmayeshi_A4.mrt";

                    if (!File.Exists(fullAdd))
                        File.WriteAllBytes(fullAdd, Properties.Resources.TarazAzmayeshi_A4);
                    sti.Load(fullAdd);
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return sti;
            }
            public static Stimulsoft.Report.StiReport TarazAzmayeshi_A5(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\TarazAzmayeshi_A5.mrt";

                    if (!File.Exists(fullAdd))
                        File.WriteAllBytes(fullAdd, Properties.Resources.TarazAzmayeshi_A5);
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
