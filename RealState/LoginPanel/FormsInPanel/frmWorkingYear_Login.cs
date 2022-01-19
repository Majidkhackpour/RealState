using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Assistence;
using EntityCache.Bussines;
using Ertegha;
using Notification;
using Persistence;
using Services;
using Settings;
using Settings.Classes;
using Settings.WorkingYear;
using User;

namespace RealState.LoginPanel.FormsInPanel
{
    public partial class frmWorkingYear_Login : Form
    {
        private Color Color => Color.FromArgb(65, 81, 219);

        private void SetDesign()
        {
            try
            {
                lblSoftwareSerial.Text = clsRegistery.GetRegistery("U1001ML");
                lblCpuSerial.Text = clsRegistery.GetRegistery("X1001MA");

                LoadWorkingYearData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadWorkingYearData()
        {
            try
            {
                var list = WorkingYear.GetAll().OrderBy(q => q.DbName);
                if ((!list?.Any() ?? false))
                {
                    userBindingSource.DataSource = null;
                    return;
                }
                workingYearBindingSource.DataSource = list;
                if (workingYearBindingSource.Count <= 0) return;
                cmbWorkingYear.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadUsersAsync()
        {
            try
            {
                var list = await UserBussines.GetAllAsync(new CancellationToken());
                userBindingSource.DataSource = list?.Where(q => q.Status)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmWorkingYear_Login() => InitializeComponent();

        private void lblCreate_MouseEnter(object sender, System.EventArgs e) => lblCreate.ForeColor = Color.Red;
        private void lblEdit_MouseEnter(object sender, System.EventArgs e) => lblEdit.ForeColor = Color.Red;
        private void lblDelete_MouseEnter(object sender, System.EventArgs e) => lblDelete.ForeColor = Color.Red;
        private void lblRestore_MouseEnter(object sender, System.EventArgs e) => lblRestore.ForeColor = Color.Red;
        private void lblRestore_MouseLeave(object sender, System.EventArgs e) => lblRestore.ForeColor = Color;
        private void lblDelete_MouseLeave(object sender, System.EventArgs e) => lblDelete.ForeColor = Color;
        private void lblEdit_MouseLeave(object sender, System.EventArgs e) => lblEdit.ForeColor = Color;
        private void lblCreate_MouseLeave(object sender, System.EventArgs e) => lblCreate.ForeColor = Color;
        private async void frmWorkingYear_Login_Load(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            lblOk.Enabled = false;
            try
            {
                SetDesign();
                res.AddReturnedValue(await Initializer.InitializeAsync(lblCpuSerial.Text, this));
                lblCpuSerial.Text = await clsGlobalSetting.GetHardDriveSerialAsync();

                if (res.HasError || res.HasWarning) return;

                cmbUserName.Enabled = txtPassword.Enabled = true;
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError || res.HasWarning)
                {
                    this.ShowError(res);
                    lblOk.Enabled = false;
                }
                else lblOk.Enabled = true;
            }
        }
        private async void cmbWorkingYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (workingYearBindingSource.Count <= 0) return;
                if (cmbWorkingYear.SelectedValue == null) return;

                var guid = (Guid)cmbWorkingYear.SelectedValue;
                var cn = WorkingYear.Get(guid);
                if (cn == null) return;

                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Arad", "BuildingCn", cn.ConnectionString);
                AppSettings.DefaultConnectionString = cn.ConnectionString;
                Cache.ConnectionString = cn.ConnectionString;

                cmbUserName.Enabled = txtPassword.Enabled = true;
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void lblOk_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (userBindingSource.Count <= 0)
                {
                    res.AddError("نام کاربری نمی تواند خالی باشد");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    res.AddError("کلمه عبور نمی تواند خالی باشد");
                    return;
                }

                var user = await UserBussines.GetAsync(cmbUserName.Text.Trim());
                if (user == null)
                {
                    res.AddError($"کاربر با نام کاربری {cmbUserName.Text} یافت نشد");
                    return;
                }

                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes(txtPassword.Text.Trim());
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                var password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                if (password != user.Password)
                {
                    res.AddError("رمز عبور اشتباه است");
                    return;
                }

                UserBussines.CurrentUser = user;
                UserBussines.DateVorrod = DateTime.Now;

                await UserLogBussines.SaveAsync(EnLogAction.Login, EnLogPart.Login,null,"", null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطای سیستم");
                else
                {
                    frmLoginMain.Instance.DialogResult = DialogResult.OK;
                    frmLoginMain.Instance.Close();
                }
            }
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            frmLoginMain.Instance.DialogResult = DialogResult.Cancel;
            frmLoginMain.Instance.Close();
        }
        private void frmWorkingYear_Login_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtPassword.Focused)
                    lblOk_Click(null, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblCreate_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoginMain.Instance.CurrentForm = new frmCreateWorkingYear();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (workingYearBindingSource.Count <= 0) return;
                if (cmbWorkingYear.SelectedValue == null) return;

                var guid = (Guid)cmbWorkingYear.SelectedValue;
                frmLoginMain.Instance.CurrentForm = new frmCreateWorkingYear(guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void lblDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (workingYearBindingSource.Count <= 0) return;
                if (cmbWorkingYear.SelectedValue == null) return;

                if (MessageBox.Show(this,
                        $@"آیا از حذف {cmbWorkingYear.Text} اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                var guid = (Guid)cmbWorkingYear.SelectedValue;

                var res = WorkingYear.Delete(guid);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                LoadWorkingYearData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void lblRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this,
                        "توجه داشته باشید درصورت بازگردانی اطلاعات، اطلاعات قبلی به کلی از بین خواهد رفت. آیا ادامه میدهید؟",
                        "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var guid = (Guid)cmbWorkingYear.SelectedValue;

                var cn = WorkingYear.Get(guid)?.ConnectionString;
                var res = await DataBaseUtilities.DataBase.ReStoreStartAsync(this, cn, ENSource.Building);
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
        private void lblRecoveryPassword_MouseEnter(object sender, EventArgs e) => lblRecoveryPassword.ForeColor = Color.Red;
        private void lblRecoveryPassword_MouseLeave(object sender, EventArgs e) => lblRecoveryPassword.ForeColor = Color;
        private void lblRecoveryPassword_Click(object sender, EventArgs e)
        {
            try
            {
                new frmForgetPassword().ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
