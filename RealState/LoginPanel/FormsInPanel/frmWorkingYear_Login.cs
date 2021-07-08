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

namespace RealState.LoginPanel.FormsInPanel
{
    public partial class frmWorkingYear_Login : Form
    {
        private ReturnedSaveFuncInfo result = new ReturnedSaveFuncInfo();
        public Color Color => Color.FromArgb(65, 81, 219);

        private void SetDesign()
        {
            try
            {
                lblSoftwareSerial.Text = clsRegistery.GetRegistery("U1001ML");
                lblCpuSerial.Text = SoftwareLock.GenerateActivationCodeClient.ActivationCode();
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
                userBindingSource.DataSource = list?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void InitConfigs()
        {
            try
            {
                ErrorHandler.AddHandler(Assembly.GetExecutingAssembly().GetName().Version.ToString(), ENSource.Building,
                    Application.StartupPath, clsRegistery.GetRegistery("U1001ML"));
                ClsCache.Init(AppSettings.DefaultConnectionString, lblCpuSerial.Text);
                Logger.init(Application.StartupPath, "BuidlingEventLog.txt", true);
                ErrorManager.Init(ENSource.Building, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<ReturnedSaveFuncInfo> SetDefultsAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var currentVersion = AccGlobalSettings.AppVersion.ParseToInt();
                var dbVersion = clsGlobalSetting.ApplicationVersion.ParseToInt();
                if (dbVersion <= 0 || currentVersion > dbVersion)
                {
                    res.AddReturnedValue(await clsErtegha.StartErteghaAsync(AppSettings.DefaultConnectionString, this, false));
                    ClsCache.InserDefults();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private ReturnedSaveFuncInfo CheckHardSerial()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var free = clsRegistery.GetRegistery("U1008FD");
                if (string.IsNullOrEmpty(free))
                {
                    //Register
                    var serialNumber = clsRegistery.GetRegistery("U1001ML");
                    var codeHdd = lblCpuSerial.Text;
                    var codeDb = clsGlobalSetting.HardDriveSerial;
                    if (string.IsNullOrEmpty(codeDb))
                    {
                        clsGlobalSetting.HardDriveSerial = codeHdd;
                        codeDb = clsGlobalSetting.HardDriveSerial;
                    }
                    if (codeDb != codeHdd)
                    {
                        var frm = new SoftwareLock.frmClient(serialNumber, true);
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            res.AddError("خطا در تایید شناسه فنی ");
                            return res;
                        }
                        serialNumber = clsRegistery.GetRegistery("U1001ML");
                    }
                    if (string.IsNullOrEmpty(serialNumber))
                    {
                        var frm = new SoftwareLock.frmClient(serialNumber, true);
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            res.AddError("خطا در تایید شناسه فنی ");
                            return res;
                        }
                    }
                }
                else
                {
                    //10 Days Free
                    var fDate = free.ParseToDate();
                    if (fDate < DateTime.Now)
                    {
                        //Expire Free Time
                        MessageBox.Show("مهلت استفاده 10 روزه رایگان شما از نرم افزار به اتمام رسیده است");
                        var frm = new SoftwareLock.frmClient("", false);
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            res.AddError("خطا در تایید شناسه فنی ");
                            return res;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task CheckHardSerialWithServerAsync()
        {
            try
            {
                while (!AccGlobalSettings.IsAuthorize)
                {
                    var res = await Utilities.PingHostAsync();
                    if (res.HasError)
                    {
                        await Task.Delay(12000000);
                        continue;
                    }

                    AccGlobalSettings.IsAuthorize = SendRequest(clsGlobalSetting.HardDriveSerial);
                    if (AccGlobalSettings.IsAuthorize) continue;
                    Application.Exit();
                    return;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private bool SendRequest(string hSerial)
        {
            try
            {
                return WebHesabBussines.WebCheckLuck.CheckHardSerial(hSerial);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        private ReturnedSaveFuncInfo CheckVersion()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var currentVersion = AccGlobalSettings.AppVersion.ParseToInt();
                var dbVersion = clsGlobalSetting.ApplicationVersion.ParseToInt();

                if (dbVersion <= 0)
                {
                    dbVersion = currentVersion;
                    clsGlobalSetting.ApplicationVersion = dbVersion.ToString();
                }

                if (currentVersion < dbVersion)
                {
                    res.AddError($"نسخه فایل اجرایی {currentVersion} و نسخه بانک اطلاعاتی {dbVersion} می باشد. \r\n" +
                                    $"لطفا جهت بروزرسانی نسخه اجرایی خود، با تیم پشتیبانی تماس حاصل فرمایید");
                    return res;
                }

                if (currentVersion > dbVersion)
                    clsGlobalSetting.ApplicationVersion = currentVersion.ToString();

                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyName))
                {
                    var frm = new frmEconomyUnit { TopMost = true };
                    if (frm.ShowDialog() == DialogResult.Cancel) Application.Exit();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
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
            try
            {
                SetDesign();

                var conString = clsRegistery.GetConnectionRegistery("BuildingCn");
                if (!conString.HasError && !string.IsNullOrEmpty(conString.value))
                {
                    AppSettings.DefaultConnectionString = conString.value;
                    Cache.ConnectionString = conString.value;
                }

                InitConfigs();
                LoadWorkingYearData();
                Invoke(new MethodInvoker(() => prgBar.Value = 1));
                result.AddReturnedValue(await SetDefultsAsync());
                Invoke(new MethodInvoker(() => prgBar.Value = 35));
                if (result.HasError) return;

                var color = Color.FromArgb(255, 192, 128);
                clsNotification.Init(color);
                Invoke(new MethodInvoker(() => prgBar.Value = 45));

                result.AddReturnedValue(CheckHardSerial());
                Invoke(new MethodInvoker(() => prgBar.Value = 65));
                if (result.HasError) return;

                //_ = Task.Run(CheckHardSerialWithServerAsync);

                result.AddReturnedValue(CheckVersion());
                Invoke(new MethodInvoker(() => prgBar.Value = 90));
                if (result.HasError) return;

                await Task.Delay(1000);
                Invoke(new MethodInvoker(() => prgBar.Value = 100));
                await Task.Delay(1000);
                prgBar.Value = 0;


                if (result.HasError) return;

                cmbUserName.Enabled = txtPassword.Enabled = true;
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                result.AddReturnedValue(ex);
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

                await SetDefultsAsync();

                if (result.HasError) this.ShowError(result, "خطای سیستم");

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
                if (result.HasError) return;
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

                clsGlobalSetting.LastUser = user.UserName;

                await UserLogBussines.SaveAsync(EnLogAction.Login, EnLogPart.Login, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                result.AddReturnedValue(ex);
            }
            finally
            {
                if (result.HasError) this.ShowError(result, "خطای سیستم");
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
    }
}
