using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Hesab
{
    public partial class frmSelectTafsil : MetroForm
    {
        public Guid SelectedGuid { get; set; }
        private HesabType _type = HesabType.All;
        private bool? _isFromReception = null;
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                List<TafsilBussines> list = null;
                if (_isFromReception != null && _isFromReception.Value)
                {
                    list = await TafsilBussines.GetAllAsync(search);
                    list = list.Where(q => q.HesabType != HesabType.Hazine).ToList();
                }
                else
                    list = await TafsilBussines.GetAllAsync(search, _type);

                Invoke(new MethodInvoker(() => TafsilBindingSource.DataSource =
                    list.OrderBy(q => q.Code).Where(q => q.Status).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSelectTafsil(HesabType htype = HesabType.All)
        {
            InitializeComponent();
            _type = htype;
            DGrid.Focus();
        }
        public frmSelectTafsil(bool isFromReception)
        {
            InitializeComponent();
            _isFromReception = isFromReception;
            DGrid.Focus();
        }

        private async void frmSelectTafsil_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void frmSelectTafsil_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.Enter:
                        btnSelect.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_DoubleClick(object sender, EventArgs e) => btnSelect.PerformClick();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
    }
}
