using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace User
{
    public partial class frmForgetPassword : MetroForm
    {
        public frmForgetPassword()
        {
            InitializeComponent();
            Size = new Size(364, 118);
            FillCmb();
            cmbQuestion.SelectedIndex = 0;
        }

        private void SetPanels()
        {
            try
            {
                if (rbtnQuestion.Checked)
                {
                    grpQuestion.Visible = true;
                    grpEmail.Visible = false;
                    grpMobile.Visible = false;
                    Size = new Size(458, 288);
                }
                if (rbtnMobile.Checked)
                {
                    grpQuestion.Visible = false;
                    grpEmail.Visible = false;
                    grpMobile.Visible = true;
                    Size = new Size(458, 250);
                }
                if (rbtnEmail.Checked)
                {
                    grpQuestion.Visible = false;
                    grpEmail.Visible = true;
                    grpMobile.Visible = false;
                    Size = new Size(458, 250);
                }
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
                cmbQuestion.Items.Add(EnSecurityQuestion.One.GetDisplay());
                cmbQuestion.Items.Add(EnSecurityQuestion.Tow.GetDisplay());
                cmbQuestion.Items.Add(EnSecurityQuestion.Three.GetDisplay());
                cmbQuestion.Items.Add(EnSecurityQuestion.Four.GetDisplay());
                cmbQuestion.Items.Add(EnSecurityQuestion.Five.GetDisplay());
                cmbQuestion.Items.Add(EnSecurityQuestion.Six.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmForgetPassword_Load(object sender, System.EventArgs e)
        {
            rbtnEmail.Checked = false;
            rbtnQuestion.Checked = false;
            rbtnMobile.Checked = false;
        }

        private void rbtnQuestion_CheckedChanged(object sender, System.EventArgs e)
        {
            SetPanels();
        }

        private void rbtnMobile_CheckedChanged(object sender, EventArgs e)
        {
            SetPanels();
        }

        private void rbtnEmail_CheckedChanged(object sender, EventArgs e)
        {
            SetPanels();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                UserBussines cls = null;
                if (rbtnQuestion.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtAnswer.Text))
                    {
                        frmNotification.PublicInfo.ShowMessage("پاسخ سوال امنیتی نمی تواند خالی باشد");
                        txtAnswer.Focus();
                        return;
                    }

                    var res = await UserBussines.GetAllAsync((EnSecurityQuestion)cmbQuestion.SelectedIndex,
                        txtAnswer.Text);
                    if (res.Count > 1)
                    {
                        frmNotification.PublicInfo.ShowMessage(
                            $"تعداد {res.Count} کاربر با سوال و پاسخ مشابه یافت شد. لطفا از گزینه های دیگر استفاده نمایید");
                        txtAnswer.Focus();
                        return;
                    }

                    if (res.Count == 1)
                        cls = res?.First();
                }

                if (rbtnEmail.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        frmNotification.PublicInfo.ShowMessage("لطفا ایمیل خود را وارد نمایید");
                        txtEmail.Focus();
                        return;
                    }

                    cls = await UserBussines.GetByEmailAsync(txtEmail.Text);
                }

                if (rbtnMobile.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtMobile.Text))
                    {
                        frmNotification.PublicInfo.ShowMessage("لطفا موبایل خود را وارد نمایید");
                        txtMobile.Focus();
                        return;
                    }

                    cls = await UserBussines.GetByMobileAsync(txtMobile.Text);
                }

                if (cls == null)
                {
                    frmNotification.PublicInfo.ShowMessage("کاربر موردنظر یافت نشد !!!");
                    return;
                }

                var frm = new frmRegisterPassword(cls);
                if (frm.ShowDialog() == DialogResult.OK)
                    Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmForgetPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        DialogResult = DialogResult.Cancel;
                        Close();
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
