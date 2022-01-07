using System;
using System.Windows.Forms;
using Services;

namespace Print
{
    public partial class UcDate : UserControl
    {
        public event Action<string> OnDateChanged;
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
                    if (string.IsNullOrEmpty(value) || value == "0/0/0" || value.Length < 10)
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
        public DateTime DateM => Calendar.ShamsiToMiladi(DateSh);
        public UcDate() => InitializeComponent();
        private void RaiseDateChange(string date)
        {
            try
            {
                var handler = OnDateChanged;
                if (handler != null) OnDateChanged?.Invoke(date);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e) => RaiseDateChange(DateSh);
        private void cmbMounth_SelectedIndexChanged(object sender, EventArgs e) => RaiseDateChange(DateSh);
        private void txtYear_ValueChanged(object sender, EventArgs e) => RaiseDateChange(DateSh);
    }
}
