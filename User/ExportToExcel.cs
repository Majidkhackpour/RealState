using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Microsoft.Office.Interop.Excel;
using Notification;
using Services;

namespace User
{
    public class ExportToExcel
    {
        public static void ExportLog(IEnumerable<UserLogBussines> list,IWin32Window owner)
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
                ws.Cells[1, 1] = "تاریخ";
                ws.Cells[1, 2] = "زمان";
                ws.Cells[1, 3] = "عملیات";
                ws.Cells[1, 4] = "بخش";
                ws.Cells[1, 5] = "توضیحات";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.DateSh;
                    ws.Cells[index, 2] = item.Time;
                    ws.Cells[index, 3] = item.ActionName;
                    ws.Cells[index, 4] = item.PartName;
                    ws.Cells[index, 5] = item.Description;
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
