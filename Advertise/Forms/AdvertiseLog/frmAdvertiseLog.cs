using MetroFramework.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Advertise.Forms.AdvertiseLog
{
    public partial class frmAdvertiseLog : MetroForm
    {
        private DateTime? _d1 = null, _d2 = null;
        private string _number = "";

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                var list = await AdvertiseLogBussines.GetAllAsync(search, _d1, _d2, _number.ParseToLong());
                while (!IsHandleCreated)
                {
                    await Task.Delay(100);
                    if (IsDisposed) return;
                }
                BeginInvoke(new MethodInvoker(() => LogBindingSource.DataSource = list?.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmAdvertiseLog_Load(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync());
        private void txtSearch_TextChanged(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync(txtSearch.Text));
        private void frmAdvertiseLog_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmAdvertiseLog(DateTime? d1, DateTime? d2, string number)
        {
            try
            {
                InitializeComponent();
                _d1 = d1;
                _d2 = d2;
                _number = number;

                if (!string.IsNullOrEmpty(_number))
                    dgNumber.Visible = false;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
