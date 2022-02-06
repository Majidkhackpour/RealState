using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.WebService;
using Ertegha;
using Notification;
using Persistence;
using Services;
using Services.Settings;
using Settings;
using Settings.Classes;
using Settings.WorkingYear;
using WebHesabBussines;

namespace RealState
{
    public class Initializer
    {
        public static bool IsAdmin()
        {
            try
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public static async Task<ReturnedSaveFuncInfo> InitializeAsync(string hardSerial, IWin32Window owner)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var conString = clsRegistery.GetConnectionRegistery("BuildingCn");
                if (!conString.HasError && !string.IsNullOrEmpty(conString.value))
                {
                    AppSettings.DefaultConnectionString = conString.value;
                    Cache.ConnectionString = conString.value;
                }

                res.AddReturnedValue(InitConfigs());
                if (res.HasError) return res;

                var list = WorkingYear.GetAll()?.OrderBy(q => q.DbName)?.ToList();
                if (list == null || list.Count <= 0)
                {
                    res.AddWarning("متاسفانه هیچ واحد اقتصادی فعال یافت نشد. لطفا ابتدا واحد اقتصادی خود را ایجاد نمایید");
                    return res;
                }

                if (SettingsBussines.Setting == null)
                    SettingsBussines.Setting = new GlobalSetting();
                if (SettingsBussines.AdvertiseSetting == null)
                    SettingsBussines.AdvertiseSetting = new AdvertiseSetting();

                res.AddReturnedValue(await SetDefultsAsync(owner));
                if (res.HasError) return res;

                res.AddReturnedValue(await CheckHardSerialAsync(hardSerial));
                if (res.HasError) return res;

                _ = Task.Run(CheckHardSerialWithServerAsync);

                res.AddReturnedValue(await CheckVersionAsync());
                if (res.HasError) return res;

                Cache.Path = Application.StartupPath;

                SetVersionAccess();

                if (!VersionAccess.Building)
                {
                    res.AddWarning("سریال نرم افزار شما، مجوز استفاده از نرم افزار را ندارد. لطفا جهت ارتقای نسخه نرم افزار خود اقدام نمایید");
                    return res;
                }

                WebServiceHandlers.Instance.Init(Cache.Path);

                _ = Task.Run(BuildingBussines.SetArchiveAsync);
                _ = Task.Run(BuildingRequestBussines.DeleteAfter60DaysAsync);

                FileFormatter.Init();
                if (!Cache.IsClient)
                {
                    DivarFiles.Init();
                    AutoBackUp.Init(owner);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo InitConfigs()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                ErrorHandler.AddHandler(Assembly.GetExecutingAssembly().GetName().Version.ToString(), ENSource.Building,
                    Application.StartupPath, clsRegistery.GetRegistery("X1001MA"));
                ClsCache.Init(AppSettings.DefaultConnectionString, clsRegistery.GetRegistery("X1001MA"));
                Logger.init(Application.StartupPath, "BuidlingEventLog.txt", true);
                ErrorManager.Init(ENSource.Building, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> SetDefultsAsync(IWin32Window owner)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var currentVersion = AccGlobalSettings.AppVersion.ParseToInt();
                var dbVersion = (await clsGlobalSetting.GetApplicationVersionAsync()).ParseToInt();
                if (dbVersion <= 0 || currentVersion > dbVersion)
                {
                    res.AddReturnedValue(await clsErtegha.StartErteghaAsync(AppSettings.DefaultConnectionString, owner, false, !Cache.IsClient));
                    await ClsCache.InserDefultsAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> CheckHardSerialAsync(string hardSerial)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var free = clsRegistery.GetRegistery("U1008FD");
                if (string.IsNullOrEmpty(free))
                {
                    //Register
                    var serialNumber = clsRegistery.GetRegistery("U1001ML");
                    var client = clsRegistery.GetRegistery("X1001MR");
                    if (!string.IsNullOrEmpty(client) && client.ParseToBoolean())
                    {
                        await clsGlobalSetting.SetHardDriveSerialAsync(clsRegistery.GetRegistery("X1001MA"));
                        return res;
                    }
                    var codeDb = SoftwareLock.GenerateActivationCodeClient.ActivationCode();
                    var setting = await clsGlobalSetting.GetHardDriveSerialAsync();
                    if (string.IsNullOrEmpty(setting))
                    {
                        await clsGlobalSetting.SetHardDriveSerialAsync(codeDb);
                        hardSerial = codeDb;
                    }
                    if (codeDb != hardSerial)
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
        private static async Task CheckHardSerialWithServerAsync()
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

                    AccGlobalSettings.IsAuthorize = await SendRequestAsync(await clsGlobalSetting.GetHardDriveSerialAsync());
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
        private static async Task<bool> SendRequestAsync(string hSerial)
        {
            try
            {
                var customer = await WebHesabBussines.WebCustomer.GetByHardSerialAsync(hSerial);
                if (customer == null || customer.isBlock) return false;
                WebHesabBussines.WebCustomer.Customer = customer;
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        private static async Task<ReturnedSaveFuncInfo> CheckVersionAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var currentVersion = AccGlobalSettings.AppVersion.ParseToInt();
                var sett = await clsGlobalSetting.GetApplicationVersionAsync();
                var dbVersion = sett.ParseToInt();

                if (dbVersion <= 0)
                {
                    dbVersion = currentVersion;
                    await clsGlobalSetting.SetApplicationVersionAsync(dbVersion.ToString());
                }

                if (currentVersion < dbVersion)
                {
                    res.AddError($"نسخه فایل اجرایی {currentVersion} و نسخه بانک اطلاعاتی {dbVersion} می باشد. \r\n" +
                                 $"لطفا جهت بروزرسانی نسخه اجرایی خود، با تیم پشتیبانی تماس حاصل فرمایید");
                    return res;
                }

                if (currentVersion > dbVersion)
                    await clsGlobalSetting.SetApplicationVersionAsync(currentVersion.ToString());

                if (string.IsNullOrEmpty(SettingsBussines.Setting.CompanyInfo.EconomyName))
                {
                    var frm = new frmEconomyUnit { TopMost = true };
                    if (frm.ShowDialog() == DialogResult.Cancel)
                        Application.Exit();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static void SetVersionAccess()
        {
            try
            {
                var serial = "";
                if (WebCustomer.CheckCustomer() && !string.IsNullOrEmpty(WebCustomer.Customer.AppSerial))
                    serial = WebCustomer.Customer.AppSerial;
                else serial = clsRegistery.GetRegistery("U1001ML");

                if (string.IsNullOrEmpty(serial)) return;
                var serialList = new List<string>();
                var code = "";
                foreach (var item in serial.ToList())
                {
                    if (code.Length < 2)
                    {
                        code += item;
                        if (code.Length == 2)
                        {
                            serialList.Add(code);
                            code = "";
                        }
                    }
                    else
                    {
                        serialList.Add(code);
                        code = "";
                    }
                }


                foreach (var item in serialList)
                {
                    switch ((EnAppSerial)item.ParseToInt())
                    {
                        case EnAppSerial.Building: VersionAccess.Building = true; break;
                        case EnAppSerial.Sms: VersionAccess.Sms = true; break;
                        case EnAppSerial.Advertise: VersionAccess.Advertise = true; break;
                        case EnAppSerial.Telegram: VersionAccess.Telegram = true; break;
                        case EnAppSerial.WhatsApp: VersionAccess.WhatsApp = true; break;
                        case EnAppSerial.Excel: VersionAccess.Excel = true; break;
                        case EnAppSerial.AutoBackUp: VersionAccess.AutoBackUp = true; break;
                        case EnAppSerial.Accounting: VersionAccess.Accounting = true; break;
                        case EnAppSerial.WebSite: break;
                        case EnAppSerial.MobileApp: break;
                        case EnAppSerial.WebService:
                            VersionAccess.WebService = true;
                            Cache.IsSendToServer = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
