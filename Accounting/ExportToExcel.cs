using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Microsoft.Office.Interop.Excel;
using Notification;
using Services;

namespace Accounting
{
    public class ExportToExcel
    {
        public static void ExportGardesh(IEnumerable<GardeshHesabBussines> list)
        {
            try
            {
                var sfd = new SaveFileDialog() { Filter = "Excel Files|*.xls" };
                if (sfd.ShowDialog() != DialogResult.OK) return;
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                var ws = (Worksheet)excel.ActiveSheet;
                excel.Visible = false;
                var index = 1;

                var frm = new frmSplash(list.ToList().Count);
                frm.Show();


                //Add column
                ws.Cells[1, 1] = "تاریخ";
                ws.Cells[1, 2] = "زمان";
                ws.Cells[1, 3] = "مبلغ";
                ws.Cells[1, 4] = "";
                ws.Cells[1, 5] = "بابت";
                ws.Cells[1, 6] = "توضیحات";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.DateSh;
                    ws.Cells[index, 2] = item.Time;
                    ws.Cells[index, 3] = item.Price.ToString("N0");
                    ws.Cells[index, 4] = item.TypeName;
                    ws.Cells[index, 5] = item.BabatName;
                    ws.Cells[index, 6] = item.Description;
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
