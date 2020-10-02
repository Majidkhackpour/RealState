using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using User;

namespace Payamak
{
    public partial class frmSmsLog : MetroForm
    {
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                txtMessage.Text = "";
                if (cmbUsers.SelectedValue == null) return;
                var list = await SmsLogBussines.GetAllAsync(search, (Guid)cmbUsers.SelectedValue);
                logBindingSource.DataSource = list.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillCmbAsync()
        {
            try
            {

                var list = await UserBussines.GetAllAsync();
                list.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[کلیه کاربران]"
                });
                userBindingSource.DataSource = list.OrderBy(q => q.Name);
                cmbUsers.SelectedValue = clsUser.CurrentUser?.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private SmsPanelsBussines cls;
        public frmSmsLog(SmsPanelsBussines pnl)
        {
            InitializeComponent();
            cls = pnl;
        }

        private async void frmSmsLog_Load(object sender, EventArgs e)
        {
            await FillCmbAsync();
            await LoadDataAsync();
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmSmsLog_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
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

        private async void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var log = SmsLogBussines.Get(guid);
                if (log == null) return;

                txtMessage.Text = log.Message;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void UpdateStatus(List<string> lstMessageId)
        {
            try
            {
                var api = new Sms.Api(cls.API.Trim());
                var resList = api.Status(lstMessageId);

                foreach (var item in resList)
                {
                    var log = await SmsLogBussines.GetAsync(item.Messageid);
                    if (log == null) continue;
                    log.StatusText = item.Statustext;
                    await log.SaveAsync();
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void mnuUpSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var log = SmsLogBussines.Get(guid);
                if (log == null) return;

                var list = new List<string> { log.MessageId.ToString() };

                UpdateStatus(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void mnuUpAll_Click(object sender, EventArgs e)
        {
            try
            {
                var list = await SmsLogBussines.GetAllAsync();

                UpdateStatus(list.Select(q => q.MessageId.ToString()).ToList());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
