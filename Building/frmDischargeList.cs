using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Payamak;
using Services;

namespace Building
{
    public partial class frmDischargeList : MetroForm
    {
        public frmDischargeList() => InitializeComponent();

        private async void frmDischargeList_Load(object sender, System.EventArgs e)
        {
            try
            {
                var list = await ContractBussines.DischargeListAsync();
                disBindingSource.DataSource = list?.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmDischargeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private void mnuOwnerSms_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var list = new List<Guid> {(Guid) DGrid[dgFSideGuid.Index, DGrid.CurrentRow.Index].Value};

                var frm = new frmSendSms(list, "");
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuMostajerSms_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var list = new List<Guid> { (Guid)DGrid[dgSSideGuid.Index, DGrid.CurrentRow.Index].Value };

                var frm = new frmSendSms(list, "");
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
