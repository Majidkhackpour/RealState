using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using Microsoft.Office.Interop.Excel;
using Notification;
using Services;

namespace Building
{
    public class ExportToExcel
    {
        public static void ExportContract(IEnumerable<ContractBussines> list,IWin32Window owner)
        {
            try
            {
                var sfd = new SaveFileDialog() { Filter = "Excel Files|*.xls" };
                if (sfd.ShowDialog(owner) != DialogResult.OK) return;
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                var ws = (Worksheet)excel.ActiveSheet;
                excel.Visible = false;
                var index = 1;

                var frm = new frmSplash(list.ToList().Count);
                frm.Show(owner);


                //Add column
                ws.Cells[1, 1] = "تاریخ ثبت";
                ws.Cells[1, 2] = "کد قرارداد";
                ws.Cells[1, 3] = "طرف اول/فروشنده/موجر";
                ws.Cells[1, 4] = "طرف دوم/خریدار/مستاجر";
                ws.Cells[1, 5] = "کاربر ثبت کننده";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.DateSh;
                    ws.Cells[index, 2] = item.Code;
                    ws.Cells[index, 3] = item.FirstSideName;
                    ws.Cells[index, 4] = item.SecondSideName;
                    ws.Cells[index, 5] = item.UserName;
                }


                ws.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false,
                    XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing,
                    Type.Missing);
                excel.Quit();
                frm.Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public static void ExportRequest(IEnumerable<BuildingRequestBussines> list,IWin32Window owner)
        {
            try
            {
                var sfd = new SaveFileDialog() { Filter = "Excel Files|*.xls" };
                if (sfd.ShowDialog(owner) != DialogResult.OK) return;
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                var ws = (Worksheet)excel.ActiveSheet;
                excel.Visible = false;
                var index = 1;

                var frm = new frmSplash(list.ToList().Count);
                frm.Show(owner);


                //Add column
                ws.Cells[1, 1] = "متقاضی";
                ws.Cells[1, 2] = "مشاور";
                ws.Cells[1, 3] = "توضیحات";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.AskerName;
                    ws.Cells[index, 2] = item.UserName;
                    ws.Cells[index, 3] = item.ShortDesc;
                }


                ws.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false,
                    XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing,
                    Type.Missing);
                excel.Quit();
                frm.Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static void ExportBuilding (IEnumerable<BuildingReportBussines> list,IWin32Window owner)
        {
            try
            {
                var sfd = new SaveFileDialog() { Filter = "Excel Files|*.xls" };
                if (sfd.ShowDialog(owner) != DialogResult.OK) return;
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                var ws = (Worksheet)excel.ActiveSheet;
                excel.Visible = false;
                var index = 1;

                var frm = new frmSplash(list.ToList().Count);
                frm.Show(owner);


                //Add column
                ws.Cells[1, 1] = "کد ملک";
                ws.Cells[1, 2] = "تاریخ ثبت";
                ws.Cells[1, 3] = "مالک";
                ws.Cells[1, 4] = "نوع ملک";
                ws.Cells[1, 5] = "تعداد اتاق";
                ws.Cells[1, 6] = "مساحت";
                ws.Cells[1, 7] = "زیربنا";
                ws.Cells[1, 8] = "محدوده";
                ws.Cells[1, 9] = "اولویت";
                ws.Cells[1, 10] = "مشاور";

                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.Code;
                    ws.Cells[index, 2] = item.DateSh;
                    ws.Cells[index, 3] = item.OwnerName;
                    ws.Cells[index, 4] = item.BuildingTypeName;
                    ws.Cells[index, 5] = item.RoomCount;
                    ws.Cells[index, 6] = item.Masahat;
                    ws.Cells[index, 7] = item.ZirBana;
                    ws.Cells[index, 8] = item.RegionName;
                    ws.Cells[index, 9] = item.Priority;
                    ws.Cells[index, 10] = item.UserName;
                }


                ws.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false,
                    XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing,
                    Type.Missing);
                excel.Quit();
                frm.Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
