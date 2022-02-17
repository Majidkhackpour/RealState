using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.UserControls.Report.MinorObjects;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Report.MajorObject
{
    public partial class UcShowCustomerBirthday : UserControl
    {
        public UcShowCustomerBirthday() => InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var dateSh = Calendar.MiladiToShamsi(DateTime.Now);
                var day = Calendar.GetDayOfDateSh(dateSh);
                var dayStr = day.ToString();
                if (day < 10) dayStr = $"0{day}";
                var mounth = Calendar.GetMonthOfDateSh(dateSh);
                var mounthStr = mounth.ToString();
                if (mounth < 10) mounthStr = $"0{mounth}";
                var newDate = $"/{mounthStr}/{dayStr}";
                var birthdayList = await PeoplesBussines.GetAllBirthDayAsync(newDate);
                if (birthdayList != null && birthdayList.Count > 0)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelCustomerBirthDay.Controls?.Clear();
                        foreach (var item in birthdayList)
                        {
                            var c = new ucCustomerBirthday { People = item, Width = fPanelCustomerBirthDay.Width - 30 };
                            fPanelCustomerBirthDay.Controls.Add(c);
                        }
                    }));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelCustomerBirthDay.Visible = false;
                        lblBirthDayNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
