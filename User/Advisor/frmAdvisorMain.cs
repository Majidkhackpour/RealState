using System;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace User.Advisor
{
    public partial class frmAdvisorMain : MetroForm
    {
        private AdvisorBussines cls;
        private void SetData()
        {
            try
            {
                SetAccess();
                FillCmbPrice();
                SetTxtPrice();
                txtName.Text = cls?.Name;
                txtAddress.Text = cls?.Address;
                txtMobile1.Text = cls?.Mobile1;
                txtMobile2.Text = cls?.Mobile2;
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
                    cmbAccount.SelectedIndex = 1;
                }

                if (cls?.AccountFirst > 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 2;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetAccess()
        {
            try
            {
                txtAccount_.Visible = cmbAccount.Visible = VersionAccess.Accounting;
                label3.Visible = label6.Visible = VersionAccess.Accounting;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmAdvisorMain(AdvisorBussines obj, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (cls.Guid != Guid.Empty)
                    ucHeader.Text = "افزودن مشاور جدید";
                else
                    ucHeader.Text = !isShowMode ? $"ویرایش مشاور {cls.Name}" : $"مشاهده مشاور {cls.Name}";
                ucHeader.IsModified = true;
                grp.Enabled = !isShowMode;
                btnFinish.Enabled = !isShowMode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmAdvisorMain_Load(object sender, EventArgs e) => SetData();
        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtMobile1_Enter(object sender, EventArgs e) => txtSetter.Focus(txtMobile1);
        private void txtMobile2_Enter(object sender, EventArgs e) => txtSetter.Focus(txtMobile2);
        private void txtMobile2_Leave(object sender, EventArgs e) => txtSetter.Follow(txtMobile2);
        private void txtMobile1_Leave(object sender, EventArgs e) => txtSetter.Follow(txtMobile1);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmAdvisorMain_KeyDown(object sender, KeyEventArgs e)
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
                if (cls.Guid == Guid.Empty) cls.Guid = Guid.NewGuid();
                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Name = txtName.Text;
                cls.Address = txtAddress.Text;
                cls.Mobile1 = txtMobile1.Text;
                cls.Mobile2 = txtMobile2.Text;
                var acc = txtAccount_.TextDecimal;
                if (cmbAccount.SelectedIndex == 0) cls.AccountFirst = 0;
                else
                {
                    if (cmbAccount.SelectedIndex == 1) cls.AccountFirst = -acc;
                    else cls.AccountFirst = acc;
                }

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ثبت حساب مشاور");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
