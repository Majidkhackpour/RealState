using System;
using System.Linq;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcZirBana : UserControl
    {
        public event Action OnValueChanged;
        public int Value
        {
            get
            {
                if (cmbZirBana.SelectedIndex == 0)
                    return (int)txtZirBana.Value;
                if (cmbZirBana.SelectedIndex == 1)
                    return (int)txtZirBana.Value * 10000;
                return 0;
            }
            set
            {
                if (value == 0)
                {
                    txtZirBana.Value = value;
                    cmbZirBana.SelectedIndex = 0;
                }
                if (value != 0)
                {
                    if (value >= 10000)
                    {
                        txtZirBana.Value = value / 10000;
                        cmbZirBana.SelectedIndex = 1;
                    }
                    if (value <= 9999)
                    {
                        txtZirBana.Value = value;
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
        private void RaiseEvent()
        {
            var handler = OnValueChanged;
            if (handler != null)
                OnValueChanged?.Invoke();
        }
        private void txtZirBana_ValueChanged(object sender, EventArgs e) => RaiseEvent();
        private void cmbZirBana_SelectedIndexChanged(object sender, EventArgs e) => RaiseEvent();
    }
}
