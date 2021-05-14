using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Print;
using Services;

namespace Accounting.Report
{
    public partial class frmRoozname : MetroForm
    {
        private DateTime _d1, _d2;
        private CancellationTokenSource _token = new CancellationTokenSource();
        private IEnumerable<GardeshBussines> _list;

        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                _list = await GardeshBussines.GetAllRooznameAsync(_d1, _d2, search, _token.Token);
                Invoke(new MethodInvoker(() => RooznameBindingSource.DataSource = _list.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmRoozname(DateTime d1, DateTime d2)
        {
            InitializeComponent();
            ucHeader.Text = "گزارش دفتر روزنامه";
            _d1 = d1;
            _d2 = d2;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync(txtSearch.Text));
        private void frmRoozname_KeyDown(object sender, KeyEventArgs e)
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
                var cls = new ReportGenerator(StiType.Roozname, frm._PrintType) { Lst = new List<object>(_list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmRoozname_Load(object sender, EventArgs e) => _ = Task.Run(() => LoadDataAsync());
    }
}
