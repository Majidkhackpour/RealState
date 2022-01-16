using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Print;
using Services;

namespace User
{
    public partial class frmUserLog : MetroForm
    {
        private Guid userGuid;
        private DateTime d1, d2;
        private IEnumerable<UserLogBussines> list;
        private async Task LoadDataAsync()
        {
            try
            {
                ucHeader.Text = $"گزارش عملکرد {(await UserBussines.GetAsync(userGuid))?.Name ?? ""}";
                list = await UserLogBussines.GetAllAsync(userGuid, d1, d2);
                logBindingSource.DataSource = list.OrderByDescending(q => q.Date).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmUserLog_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void frmUserLog_KeyDown(object sender, KeyEventArgs e)
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.User_Performence_List, frm._PrintType)
                    { Lst = new List<object>(list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportLog(list, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private async void DGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter) return;
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid?)DGrid[dgObjGuid.Index, DGrid.CurrentRow.Index].Value;
                var part = (EnLogPart)DGrid[dgLogPart.Index, DGrid.CurrentRow.Index].Value;

                await Switcher.SwitchAsync(part, guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmUserLog(Guid _userGuid, DateTime _d1, DateTime _d2)
        {
            InitializeComponent();
            userGuid = _userGuid;
            d1 = _d1;
            d2 = _d2;
        }
    }
}
