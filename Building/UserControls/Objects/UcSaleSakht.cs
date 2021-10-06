using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcSaleSakht : UserControl
    {
        public string SaleSakht
        {
            get
            {
                var oldDate = DateTime.Now.AddYears(-cmbSaleSakht.SelectedIndex);
                return Calendar.GetYearOfDateSh(Calendar.MiladiToShamsi(oldDate)).ToString();
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                        cmbSaleSakht.SelectedIndex = 0;
                    else
                    {
                        var year1 = Calendar.GetYearOfDateSh(Calendar.MiladiToShamsi(DateTime.Now));
                        var year2 = value.Length > 4
                            ? Calendar.GetYearOfDateSh(value)
                            : value.ParseToInt();
                        var dis = year1 - year2;
                        if (dis < 0) dis = 0;
                        if (dis > 36) dis = 35;
                        cmbSaleSakht.SelectedIndex = dis;
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }
            }
        }

        public UcSaleSakht() => InitializeComponent();
    }
}
