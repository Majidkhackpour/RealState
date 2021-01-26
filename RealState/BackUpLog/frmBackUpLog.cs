using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings;

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
        private async Task RestoreAsync(string path)
        {
            try
            {
                if (MessageBox.Show(this,
                        "توجه داشته باشید درصورت بازگردانی اطلاعات، اطلاعات قبلی به کلی از بین خواهد رفت. آیا ادامه میدهید؟",
                        "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var res = await DataBaseUtilities.DataBase.ReStoreStartAsync(this,
                    AppSettings.DefaultConnectionString, ENSource.Building, path);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                frmNotification.PublicInfo.ShowMessage("بازیابی فایل پشتیبان با موفقیت انجام شد");
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
            => DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        private void frmBackUpLog_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this,
                        "آیا مایلید فایل پشتیبان جدید ایجاد کنید؟",
                        "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var res = await DataBaseUtilities.DataBase.BackUpStartAsync(this,
                    AppSettings.DefaultConnectionString, ENSource.Building, EnBackUpType.Manual);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                frmNotification.PublicInfo.ShowMessage("پشتیبان گیری با موفقیت انجام شد");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuRestoreFromSelectedFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var path = DGrid[dgPath.Index, DGrid.CurrentRow.Index].Value?.ToString();
                await RestoreAsync(path);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuRestoreFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                await RestoreAsync("");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
