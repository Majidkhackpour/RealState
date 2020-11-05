using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Microsoft.Office.Interop.Excel;
using Notification;
using Services;

namespace Payamak
{
    public class ExportToExcel
    {
        public static void ExportLog(IEnumerable<SmsLogBussines> list, IWin32Window owner)
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
                ws.Cells[1, 1] = "تاریخ ارسال";
                ws.Cells[1, 2] = "کاربر ارسال کننده";
                ws.Cells[1, 3] = "هزینه به ریال";
                ws.Cells[1, 4] = "وضعیت";
                ws.Cells[1, 5] = "متن ارسال شده";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.DateSh;
                    ws.Cells[index, 2] = item.UserName;
                    ws.Cells[index, 3] = item.Cost.ToString("N0");
                    ws.Cells[index, 4] = item.StatusText;
                    ws.Cells[index, 5] = item.Message;
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
