using EntityCache.Bussines;
using MetroFramework.Forms;
using Payamak;
using Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Building.Tools
{
    public partial class frmShowBirthDay : MetroForm
    {
        public frmShowBirthDay(List<PeoplesBussines> list)
        {
            InitializeComponent();
            noteBindingSource.DataSource = list.ToSortableBindingList();
            btnSendSms.Enabled = VersionAccess.Sms;
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            => DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;

        private void frmShowBirthDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void btnSendSms_Click(object sender, System.EventArgs e)
        {
            try
            {
                var list = new List<Guid>();
                for (var i = 0; i < DGrid.RowCount; i++)
                    if ((bool)DGrid[dgIsChecked.Index, i].Value)
                        list.Add((Guid)DGrid[dgGuid.Index, i].Value);

                if (list.Count <= 0)
                {
                    for (var i = 0; i < DGrid.RowCount; i++)
                        list.Add((Guid)DGrid[dgGuid.Index, i].Value);
                }

                var frm = new frmSendSms(list, SettingsBussines.Setting.Global.BirthDayText);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
