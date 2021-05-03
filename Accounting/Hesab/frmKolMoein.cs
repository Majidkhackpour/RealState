using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Hesab
{
    public partial class frmKolMoein : MetroForm
    {
        private Guid _kolGuid = Guid.Empty;
        private bool isSelectMode;
        private CancellationTokenSource _token = new CancellationTokenSource();

        public Guid KolGuid
        {
            get => _kolGuid;
            set
            {
                _kolGuid = value;
                _ = Task.Run(() => LoadMoeinAsync(txtSearchMoein.Text));
            }
        }
        public Guid SelectedMoeinGuid { get; set; }

        private async Task LoadKolAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await KolBussines.GetAllAsync(search, _token.Token);
                KolBindingSource.DataSource = list?.OrderBy(q => q.Code).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadMoeinAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await MoeinBussines.GetAllAsync(search, KolGuid, _token.Token);
                Invoke(new MethodInvoker(() =>
                    MoeinBindingSource.DataSource = list?.OrderBy(q => q.Code).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmKolMoein(bool _selectMode)
        {
            InitializeComponent();
            isSelectMode = _selectMode;
        }

        private async void frmKolMoein_Load(object sender, EventArgs e)
        {
            await LoadKolAsync();
            await LoadMoeinAsync();
        }
        private void DGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGridKol.RowCount <= 0 || DGridKol.CurrentRow == null)
                {
                    KolGuid = Guid.Empty;
                    return;
                }

                KolGuid = (Guid)DGridKol[dgKolGuid.Index, DGridKol.CurrentRow.Index].Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmKolMoein_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) Close();
                if (e.KeyCode == Keys.Down)
                {
                    if (txtSearchMoein.Focused)
                        DGridMoein.Focus();
                    if (txtSearchKol.Focused)
                        DGridKol.Focus();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadKolAsync(txtSearchKol.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void txtSearchMoein_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadMoeinAsync(txtSearchMoein.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGridMoein_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!isSelectMode) return;
                    if (DGridMoein.RowCount <= 0 || DGridMoein.CurrentRow == null) return;
                    SelectedMoeinGuid = (Guid)DGridMoein[dgMoeinGuid.Index, DGridMoein.CurrentRow.Index].Value;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
