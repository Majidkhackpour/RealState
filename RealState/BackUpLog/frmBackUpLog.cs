using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace RealState.BackUpLog
{
    public partial class frmBackUpLog : MetroForm
    {
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await BackUpLogBussines.GetAllAsync();
                logBindingSource.DataSource = list.OrderByDescending(q => q.InsertedDate).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmBackUpLog()
        {
            InitializeComponent();
        }

        private async void frmBackUpLog_Load(object sender, EventArgs e) => await LoadDataAsync();

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void frmBackUpLog_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape: Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
