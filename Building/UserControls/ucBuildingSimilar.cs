using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace Building.UserControls
{
    public partial class ucBuildingSimilar : UserControl
    {
        public event Func<clsBuildingSimilar, Task> OnClosed;
        private clsBuildingSimilar _bu;
        public clsBuildingSimilar Building
        {
            get => _bu;
            set
            {
                _bu = value;
                if (_bu == null) return;
                lblMasahat.Text = _bu.Masahat.ToString();
                lblEjare.Text = _bu.EjarePrice.ToString("N0");
                lblRahn.Text = _bu.RahnPrice.ToString("N0");
                lblSellPrice.Text = _bu.SellPrice.ToString("N0");
                lblZirBana.Text = _bu.ZirBana.ToString();
                lblRoomCount.Text = _bu.RoomCount.ToString();
                lblTabaqeNo.Text = _bu.TabaqeNo.ToString();
            }
        }
        public ucBuildingSimilar()
        {
            InitializeComponent();
        }
        private void RaiseEvent()
        {
            try
            {
                var handler = OnClosed;
                if (handler != null) OnClosed?.Invoke(_bu);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("آیا از ذخیره ملک مشابه جاری منصرف شده اید؟", "پیغام سیستم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No) return;
                RaiseEvent();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
