﻿using System;
using System.IO;
using Services;

namespace Print.Classes
{
    public class clsContract
    {
        public static string FolderName => "قولنامه";

        public class One
        {
            public static Stimulsoft.Report.StiReport GetSti(Stimulsoft.Report.StiReport sti, EnPrintType peper)
            {
                try
                {
                    ReportPath.CreatePath(ReportPath.ReportPath_);
                    ReportPath.CreatePath(ReportPath.ReportPath_ + @"\" + FolderName);
                    switch (peper)
                    {
                        case EnPrintType.A4: return Contract_One_A4(sti);
                        case EnPrintType.A5: return Contract_One_A5(sti);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return sti;
            }
            public static Stimulsoft.Report.StiReport Contract_One_A4(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\Contract_One_A4.mrt";

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
            public static Stimulsoft.Report.StiReport Contract_One_A5(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\Contract_One_A5.mrt";

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
                        case EnPrintType.A4: return Contract_List_A4(sti);
                        case EnPrintType.A5: return Contract_List_A5(sti);
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return sti;
            }
            public static Stimulsoft.Report.StiReport Contract_List_A4(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\Contract_List_A4.mrt";

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
            public static Stimulsoft.Report.StiReport Contract_List_A5(Stimulsoft.Report.StiReport sti)
            {
                try
                {
                    var fullAdd = ReportPath.ReportPath_ + @"\" + FolderName + @"\Contract_List_A5.mrt";

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
