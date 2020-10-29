using System;
using System.Linq;
using System.Windows.Forms;
using Ertegha;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Settings.WorkingYear
{
    public partial class frmShowWorkingYears : MetroForm
    {
        private void LoadData()
        {
            try
            {
                var list = WorkingYear.GetAll().OrderBy(q => q.DbName);
                workingYearBindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmShowWorkingYears()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmWorkingYearMain();
                if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowWorkingYears_Load(object sender, EventArgs e) => LoadData();

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmWorkingYearMain(guid);
                if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                if (MessageBox.Show(this,
                        $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;

                var res = WorkingYear.Delete(guid);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cn = WorkingYear.Get(guid);
                if (cn == null) return;

                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Arad",
                    "BuildingCn", cn.ConnectionString);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;

                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var cn = WorkingYear.Get(guid);
                if (cn == null) return;
                txtConnectionString.Text = cn.ConnectionString;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_DoubleClick(object sender, EventArgs e) => btnSelect.PerformClick();

        private void frmShowWorkingYears_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter: btnSelect.PerformClick();
                        break;
                    case Keys.Escape: Application.Exit();
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
