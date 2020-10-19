using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Microsoft.Office.Interop.Excel;
using Notification;
using Services;

namespace Peoples
{
    public class ExportToExcel
    {
        public static void Export(IEnumerable<PeoplesBussines> list,IWin32Window owner)
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
                ws.Cells[1, 1] = "کد شخص";
                ws.Cells[1, 2] = "عنوان";
                ws.Cells[1, 3] = "کدملی";
                ws.Cells[1, 4] = "ش شناسنامه";
                ws.Cells[1, 5] = "نام پدر";
                ws.Cells[1, 6] = "محل تولد";
                ws.Cells[1, 7] = "تاریخ تولد";
                ws.Cells[1, 8] = "آدرس";
                ws.Cells[1, 9] = "کدپستی";
                ws.Cells[1, 10] = "مانده اول دوره";
                ws.Cells[1, 11] = "مانده فعلی";
                ws.Cells[1, 12] = "وضعیت حساب";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.Code;
                    ws.Cells[index, 2] = item.Name;
                    ws.Cells[index, 3] = item.NationalCode;
                    ws.Cells[index, 4] = item.IdCode;
                    ws.Cells[index, 5] = item.FatherName;
                    ws.Cells[index, 6] = item.PlaceBirth;
                    ws.Cells[index, 7] = item.DateBirth;
                    ws.Cells[index, 8] = item.Address;
                    ws.Cells[index, 9] = item.PostalCode;
                    ws.Cells[index, 10] = item.AccountFirst.ToString("N0");
                    ws.Cells[index, 11] = item.Account_.ToString("N0");
                    if (item.Account == 0) ws.Cells[index, 12] = "بی حساب";
                    if (item.Account > 0) ws.Cells[index, 12] = "بدهکار";
                    if (item.Account < 0) ws.Cells[index, 12] = "بستانکار";
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
