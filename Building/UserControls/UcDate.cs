using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls
{
    public partial class UcDate : UserControl
    {
        private string _dateSh;
        public string DateSh
        {
            get
            {
                var date = "";
                try
                {
                    date = $"{txtYear.Value}/{cmbMounth.SelectedIndex + 1}/{cmbDay.SelectedIndex + 1}";
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
                return date;
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                        value = Calendar.MiladiToShamsi(DateTime.Now);
                    _dateSh = value;
                    var year = _dateSh.Substring(0, 4).ParseToInt();
                    var mounth = _dateSh.Substring(5, 2).ParseToInt();
                    var day = _dateSh.Substring(8, 2).ParseToInt();
                    txtYear.Value = year;
                    cmbMounth.SelectedIndex = mounth - 1;
                    cmbDay.SelectedIndex = day - 1;
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }
        public UcDate() => InitializeComponent();
    }
}
