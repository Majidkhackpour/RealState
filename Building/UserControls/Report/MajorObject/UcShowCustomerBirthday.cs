using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.Tools;
using Building.UserControls.Report.MinorObjects;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Report.MajorObject
{
    public partial class UcShowCustomerBirthday : UserControl
    {
        private List<PeoplesBussines> list;
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
                list = await PeoplesBussines.GetAllBirthDayAsync(newDate);
                if (list != null && list.Count > 0)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelCustomerBirthDay.Visible = true;
                        lblBirthDayNone.Visible = false;
                        fPanelCustomerBirthDay.Controls?.Clear();
                        foreach (var item in list)
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
        private void label3_MouseEnter(object sender, EventArgs e) => label3.ForeColor = Color.Red;
        private void label3_MouseLeave(object sender, EventArgs e) => label3.ForeColor = Color.FromArgb(65, 81, 219);
        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(list?.Any() ?? false)) return;
                var frm = new frmShowBirthDay(list);
                frm.ShowDialog(FindForm());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
