using System;
using System.Linq;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcZirBana : UserControl
    {
        public int Value
        {
            get
            {
                if (cmbZirBana.SelectedIndex == 0)
                    return txtZirBana.Text.ParseToInt();
                if (cmbZirBana.SelectedIndex == 1)
                    return txtZirBana.Text.ParseToInt() * 10000;
                return 0;
            }
            set
            {
                if (value == 0)
                {
                    txtZirBana.Text = value.ToString();
                    cmbZirBana.SelectedIndex = 0;
                }
                if (value != 0)
                {
                    if (value >= 10000)
                    {
                        txtZirBana.Text = (value / 10000).ToString();
                        cmbZirBana.SelectedIndex = 1;
                    }
                    if (value <= 9999)
                    {
                        txtZirBana.Text = value.ToString();
                        cmbZirBana.SelectedIndex = 0;
                    }
                }
            }
        }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public UcZirBana()
        {
            InitializeComponent();
            FillCmbMetr();
        }
        private void FillCmbMetr()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnMetr)).Cast<EnMetr>();
                foreach (var item in values)
                    cmbZirBana.Items.Add(item.GetDisplay());

                cmbZirBana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
