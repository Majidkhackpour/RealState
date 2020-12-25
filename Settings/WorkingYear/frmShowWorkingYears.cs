using System;
using System.Linq;
using System.Windows.Forms;
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
                if (workingYearBindingSource.Count > 0)
                    cmb.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowWorkingYears() => InitializeComponent();

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
                if (workingYearBindingSource.Count <= 0) return;
                if (cmb.SelectedValue == null) return;

                var guid = (Guid)cmb.SelectedValue;
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
                if (workingYearBindingSource.Count <= 0) return;
                if (cmb.SelectedValue == null) return;

                if (MessageBox.Show(this,
                        $@"آیا از حذف {cmb.Text} اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                var guid = (Guid)cmb.SelectedValue;

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
                if (workingYearBindingSource.Count <= 0) return;
                if (cmb.SelectedValue == null) return;

                var guid = (Guid)cmb.SelectedValue;
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
        private void frmShowWorkingYears_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter: btnSelect.PerformClick(); break;
                    case Keys.Escape: Application.Exit(); break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this,
                        "توجه داشته باشید درصورت بازگردانی اطلاعات، اطلاعات قبلی به کلی از بین خواهد رفت. آیا ادامه میدهید؟",
                        "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var res = await DataBaseUtilities.DataBase.ReStoreStartAsync(this,
                    txtConnectionString.Text, ENSource.Building);
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
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (workingYearBindingSource.Count <= 0) return;
                if (cmb.SelectedValue == null) return;

                var guid = (Guid)cmb.SelectedValue;
                var cn = WorkingYear.Get(guid);
                if (cn == null) return;
                txtConnectionString.Text = cn.ConnectionString;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
