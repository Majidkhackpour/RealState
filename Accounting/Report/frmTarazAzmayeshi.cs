using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Print;
using Services;

namespace Accounting.Report
{
    public partial class frmTarazAzmayeshi : MetroForm
    {
        private CancellationTokenSource _token = new CancellationTokenSource();
        private IEnumerable<TarazAzmayeshiViewModel> _list;

        private async Task LoadDataAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                _list = await SanadDetailBussines.GetAllTarazAzmayeshiAsync(_token.Token);
                Invoke(new MethodInvoker(() => TarazBindingSource.DataSource = _list.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmTarazAzmayeshi()
        {
            InitializeComponent();
            ucHeader.Text = "تراز آزمایشی";
        }

        private void frmTarazAzmayeshi_Load(object sender, EventArgs e) => _ = Task.Run(LoadDataAsync);
        private void frmTarazAzmayeshi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void picPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize(false);
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType == EnPrintType.Excel) return;
                var cls = new ReportGenerator(StiType.TarazAzmayeshi, frm._PrintType) { Lst = new List<object>(_list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
