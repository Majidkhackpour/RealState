﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EntityCache.Bussines;
using MetroFramework.Forms;
using System.Windows.Forms;
using Notification;
using Services;

namespace User
{
    public partial class frmUserMain : MetroForm
    {
        private UserBussines cls;
        private decimal fAccount;
        private EnLogAction action;

        private void SetData()
        {
            try
            {
                FillCmb();
                FillCmbPrice();
                SetTxtPrice();
                txtName.Text = cls?.Name;
                txtUserName.Text = cls?.UserName;
                txtEmail.Text = cls?.Email;
                txtMobile.Text = cls?.Mobile;
                txtAnswer.Text = cls?.AnswerQuestion;
                if (cls?.Guid == Guid.Empty) cmbQuestion.SelectedIndex = 0;
                else cmbQuestion.SelectedIndex = (int)cls?.SecurityQuestion;
                fAccount = cls.AccountFirst;
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
        private void FillCmbPrice()
        {
            try
            {
                cmbAccount.Items.Add(EnAccountType.BiHesab.GetDisplay());
                cmbAccount.Items.Add(EnAccountType.Bed.GetDisplay());
                cmbAccount.Items.Add(EnAccountType.Bes.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtPrice()
        {
            try
            {
                if (cls?.AccountFirst == 0)
                {
                    txtAccount_.TextDecimal = cls?.AccountFirst ?? 0;
                    cmbAccount.SelectedIndex = 0;
                }

                if (cls?.AccountFirst < 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 2;
                }

                if (cls?.AccountFirst > 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmUserMain()
        {
            InitializeComponent();
            cls = new UserBussines();
            action = EnLogAction.Insert;
        }
        public frmUserMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = UserBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            action = EnLogAction.Update;
        }

        #region TxtSetter
        private void txtName_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtName);
        }

        private void txtUserName_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtUserName);
        }

        private void txtPass1_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtPass1);
        }

        private void txtPass2_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtPass2);
        }

        private void txtEmail_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtEmail);
        }

        private void txtMobile_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtMobile);
        }

        private void txtAnswer_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtAnswer);
        }

        private void txtAnswer_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtAnswer);
        }

        private void txtMobile_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtMobile);
        }

        private void txtEmail_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtEmail);
        }

        private void txtPass2_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtPass2);
        }

        private void txtPass1_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtPass1);
        }

        private void txtUserName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtUserName);
        }
        #endregion

        private async void frmUserMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
                var myCollection = new AutoCompleteStringCollection();
                var list = await UserBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.Email);
                txtName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmUserMain_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    res.AddError("نام و نام خانوادگی نمی تواند خالی باشد");
                    txtName.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    res.AddError("نام کاربری نمی تواند خالی باشد");
                    txtUserName.Focus();
                }

                if (!await UserBussines.CheckUserNameAsync(cls.Guid, txtUserName.Text))
                {
                    res.AddError("نام کاربری تکراری می باشد");
                    txtUserName.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtPass1.Text))
                {
                    res.AddError("کلمه عبور نمی تواند خالی باشد");
                    txtPass1.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtPass2.Text))
                {
                    res.AddError("تکرار کلمه عبور نمی تواند خالی باشد");
                    txtPass2.Focus();
                }

                if (txtPass1.Text != txtPass2.Text)
                {
                    res.AddError("کلمه عبور با تکرار آن همخوانی ندارد");
                    txtPass1.Focus();
                }

                if (!CheckPerssonValidation.CheckEmail(txtEmail.Text.Trim()))
                {
                    res.AddError("ایمیل وارد شده صحیح نمی باشد");
                    txtEmail.Focus();
                }

                if (!CheckPerssonValidation.CheckMobile(txtMobile.Text.Trim()))
                {
                    res.AddError("شماره موبایل وارد شده صحیح نمی باشد");
                    txtMobile.Focus();
                }

                if (txtAccount_.TextDecimal != 0 && cmbAccount.SelectedIndex == 0)
                {
                    res.AddError("مانده حساب وارد شده صحیح نمی باشد");
                    txtAccount_.Focus();
                }

                if (res.HasError) return;
                cls.Name = txtName.Text.Trim();
                cls.UserName = txtUserName.Text.Trim();
                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes(txtPass1.Text.Trim());
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                cls.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                cls.Email = txtEmail.Text.Trim();
                cls.Mobile = txtMobile.Text.Trim();
                cls.AnswerQuestion = txtAnswer.Text;
                cls.SecurityQuestion = (EnSecurityQuestion)cmbQuestion.SelectedIndex;
                var acc = txtAccount_.TextDecimal;
                if (cmbAccount.SelectedIndex == 1) cls.AccountFirst = acc;
                else cls.AccountFirst = -acc;

                if (cls.Account == 0) cls.Account = cls.AccountFirst;
                else
                {
                    cls.Account -= fAccount;
                    cls.Account += cls.AccountFirst;
                }

                res.AddReturnedValue(await cls.SaveAsync(true, true));
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ثبت کاربر");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else
                {
                    UserLog.Save(action, EnLogPart.Users);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
