using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using User;

namespace Payamak
{
    public partial class frmSmsLog : MetroForm
    {
        private void LoadData(string search = "")
        {
            try
            {
                txtMessage.Text = "";
                if (cmbUsers.SelectedValue == null) return;
                var list = SmsLogBussines.GetAll(search, (Guid)cmbUsers.SelectedValue);
                logBindingSource.DataSource = list.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmb()
        {
            try
            {

                var list = UserBussines.GetAll().ToList();
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

        private void frmSmsLog_Load(object sender, EventArgs e)
        {
            FillCmb();
            LoadData();
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(txtSearch.Text);
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

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(txtSearch.Text);
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
                    LoadData();
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

        private void mnuUpAll_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<string>();
                list = SmsLogBussines.GetAll().Select(q => q.MessageId.ToString()).ToList();

                UpdateStatus(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
