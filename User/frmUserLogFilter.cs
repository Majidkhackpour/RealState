using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace User
{
    public partial class frmUserLogFilter : MetroForm
    {
        private void SetData()
        {
            try
            {
                LoadUsers();
                txtDate1.Text = Calendar.MiladiToShamsi(Calendar.StartDayOfPersianMonth());
                txtDate2.Text = Calendar.MiladiToShamsi(Calendar.EndDayOfPersianMonth());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadUsers()
        {
            try
            {
                var list = UserBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                userBindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmUserLogFilter()
        {
            InitializeComponent();
        }

        private void frmUserLogFilter_Load(object sender, EventArgs e)
        {
            SetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUserLogFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUser.SelectedValue == null)
                {
                    frmNotification.PublicInfo.ShowMessage("کاربر نمی تواند خالی باشد");
                    cmbUser.Focus();
                    return;
                }


                var userGuid = (Guid)cmbUser.SelectedValue;
                var d1 = Calendar.ShamsiToMiladi(txtDate1.Text);
                var d2 = Calendar.ShamsiToMiladi(txtDate2.Text);

                var frm = new frmUserLog(userGuid, d1, d2);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
