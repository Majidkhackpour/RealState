using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace RealState.CalendarForms
{
    public partial class frmCalendar : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await CalendarBussines.GetAllAsync(search, (int)txtYear.Value, _token.Token);
                Invoke(new MethodInvoker(() => CalendarBindingSource.DataSource =
                    list.OrderBy(q => q.DateM).ToSortableBindingList()));
                SetGridColor();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetGridColor()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(SetGridColor));
                    return;
                }
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    var tatile = (bool)DGrid[dgTatil.Index, i].Value;
                    if (tatile)
                    {
                        DGrid.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                        DGrid.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmCalendar()
        {
            InitializeComponent();
            txtYear.Value = Calendar.GetYearOfDateSh(Calendar.MiladiToShamsi(DateTime.Now));
        }

        private void frmCalendar_Load(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync());
        private void txtSearch_TextChanged(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync(txtSearch.Text));
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                btnFinish.Enabled = false;
                res.AddReturnedValue(await Utilities.PingHostAsync());
                if (res.HasError) return;
                res.AddReturnedValue(await CalendarBussines.SaveFromServerAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                btnFinish.Enabled = true;
                if (res.HasError) this.ShowError(res, "خطا در دریافت اطلاعات از سرور");
                else _ = Task.Run(() => LoadDataAsync());
            }
        }
        private void frmCalendar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
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
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtYear_ValueChanged(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync(txtSearch.Text));
    }
}
