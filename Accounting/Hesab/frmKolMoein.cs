﻿using System;
using System.Linq;
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
        public Guid KolGuid
        {
            get => _kolGuid;
            set
            {
                _kolGuid = value;
                _ = Task.Run(() => LoadMoeinAsync(txtSearchMoein.Text));
            }
        }

        private async Task LoadKolAsync(string search = "")
        {
            try
            {
                var list = await KolBussines.GetAllAsync(search);
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
                var list = await MoeinBussines.GetAllAsync(search, KolGuid);
                Invoke(new MethodInvoker(() =>
                    MoeinBindingSource.DataSource = list?.OrderBy(q => q.Code).ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmKolMoein()
        {
            InitializeComponent();
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
            if (e.KeyCode == Keys.Escape) Close();
            if (e.KeyCode == Keys.Down)
            {
                if (txtSearchMoein.Focused)
                    DGridMoein.Focus();
                if (txtSearchKol.Focused)
                    DGridKol.Focus();
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
    }
}
