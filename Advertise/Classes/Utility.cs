using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.ViewModels.Divar.Rent.Office;
using Advertise.ViewModels.Divar.Rent.Residential;
using Advertise.ViewModels.Divar.Sell.Office;
using Advertise.ViewModels.Divar.Sell.Residential;
using EntityCache.Bussines;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Services;
using Settings.Classes;

namespace Advertise.Classes
{
    public static class Utility
    {
        public static IWebDriver _driver;
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        const int WtsCurrentSession = -1;
        static readonly IntPtr WtsCurrentServerHandle = IntPtr.Zero;
        public static async Task Wait(double second = 0.1) => await Task.Delay((int)(second * 1000));
        public static List<string> GetFiles(string path, string filePattern = "*.*") =>
            Directory.Exists(path) ? Directory.GetFiles(path, filePattern).ToList() : null;
        public static void CloseAllChromeWindows()
        {
            try
            {
                var userName = Environment.UserName;
                foreach (var item in Process.GetProcesses())
                    if (item.ProcessName == "chromedriver" || item.ProcessName == "chrome")
                    {
                        var userOfProcess = GetProcessUser(item);
                        if (userOfProcess == userName) item.Kill();
                    }
            }
            catch { }
        }
        private static string GetProcessUser(Process process)
        {
            var processHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, 8, out processHandle);
                var wi = new WindowsIdentity(processHandle);
                var user = wi.Name;
                return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\", StringComparison.Ordinal) + 1) : user;
            }
            catch { return null; }
            finally { if (processHandle != IntPtr.Zero) CloseHandle(processHandle); }
        }
        public static string GetHtmlCode(string url)
        {
            var data = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (receiveStream != null)
                    {
                        readStream = string.IsNullOrWhiteSpace(response.CharacterSet)
                            ? new StreamReader(receiveStream)
                            : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    data = readStream?.ReadToEnd();

                    response.Close();
                    readStream?.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return data;

        }
        public static void Navigate(string url)
        {
            try
            {
                _driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        #region RefreshDriver
        private static IWebDriver OpenDriverSilent(IWebDriver driver)
        {
            try
            {
                CloseAllChromeWindows();
                var options = new ChromeOptions();
                options.AddArgument("headless");
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                driver = new ChromeDriver(driverService, options);
            }
            catch (Exception)
            {
                CloseAllChromeWindows();
                var options = new ChromeOptions();
                options.AddArgument("headless");
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                driver = new ChromeDriver(driverService, options);
            }

            return driver;
        }
        private static IWebDriver OpenDriver(IWebDriver driver)
        {
            try
            {
                CloseAllChromeWindows();
                driver = new ChromeDriver();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(200);
                driver?.Manage().Window.Maximize();
            }
            catch (Exception)
            {
                CloseAllChromeWindows();
                driver = new ChromeDriver();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(200);
                driver?.Manage().Window.Maximize();
            }

            return driver;
        }
        public static IWebDriver RefreshDriver(bool isSilent)
        {
            try
            {
                if (_driver?.Title == null)
                    _driver = isSilent ? OpenDriverSilent(_driver) : OpenDriver(_driver);
            }
            catch (Exception)
            {
                _driver = isSilent ? OpenDriverSilent(_driver) : OpenDriver(_driver);
            }
            return _driver;
        }
        #endregion

        public static void ShowBalloon(string title, List<string> body)
        {
            var notifyIcon = new NotifyIcon { Visible = true, Icon = SystemIcons.Application };
            try
            {
                notifyIcon.BalloonTipTitle = title;
                var text = "";
                foreach (var item in body) text += item + '\n';
                notifyIcon.BalloonTipText = text;
                notifyIcon.ShowBalloonTip(30000);
            }
            finally { notifyIcon.Dispose(); }
        }
        //private static async Task UpdateAdvStatus(int dayCount = 0)
        //{
        //    try
        //    {
        //        TelegramSender.GetAdvertiseLog_bot()
        //            .Send($"سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n آغاز فرایند بروز رسانی آگهی ها");
        //        DeleteTemp();

        //        var divar = DivarAdv.GetInstance();
        //        await divar.UpdateAllAdvStatus(500, dayCount);

        //        var sheypoor = SheypoorAdv.GetInstance();
        //        await sheypoor.UpdateAllAdvStatus(500, dayCount);

        //        DeleteTemp();
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //    }
        //}

        #region DeleteTemp
        private static void DeleteLocalTemp(string path)
        {
            try
            {
                var folders = new DirectoryInfo(path).GetDirectories().ToList();
                if (folders.Count <= 0)
                    return;
                foreach (var ff in folders)
                {
                    try
                    {
                        File.SetAttributes(ff.FullName, FileAttributes.Normal);
                        Directory.Delete(ff.FullName, true);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void DeleteGlobalTemp(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                foreach (var ff in files)
                {
                    try
                    {
                        File.Delete(ff);
                    }
                    catch { }
                }

                try
                {
                    var tempPath = Path.Combine(Application.StartupPath, "Temp");
                    if (Directory.Exists(tempPath)) Directory.Delete(tempPath, true);
                }
                catch { }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static void DeleteTemp()
        {
            try
            {
                var item = Path.GetTempPath();

                DeleteLocalTemp(item);

                DeleteGlobalTemp(item);
            }
            catch (Exception) { }
        }
        #endregion

        #region SendChat
        //public static async Task<ReturnedSaveFuncInfo> SendChat(long number)
        //{
        //    var res = new ReturnedSaveFuncInfo();
        //    try
        //    {
        //        res.AddReturnedValue(await CheckToken(number, AdvertiseType.DivarChat));
        //        if (res.HasError) return res;

        //        var sim = await SimCardBusiness.GetAsync(number);
        //        var owner = await OwnerBusiness.GetAsync(sim.OwnerGuid);

        //        res.AddReturnedValue(await SendChat_(number, owner.VisitorGuid));
        //        if (res.HasError) return res;

        //        CloseAllChromeWindows();
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorLogInstance.StartLog(ex);
        //        res.AddReturnedValue(ex);
        //    }

        //    return res;
        //}
        public static async Task<ReturnedSaveFuncInfoWithValue<string>> CheckToken(long number, AdvertiseType type)
        {
            var res = new ReturnedSaveFuncInfoWithValue<string>();
            try
            {
                var tk = await AdvTokenBussines.GetTokenAsync(number, type);
                if (tk == null)
                {
                    res.AddReturnedValue(ReturnedState.Error, "Token is Null");
                    return res;
                }
                if (string.IsNullOrEmpty(tk.Token))
                {
                    res.AddReturnedValue(ReturnedState.Error, "Token is Empty");
                    return res;
                }

                res.value = tk.Token;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

        //private static async Task<ReturnedSaveFuncInfo> SendChat_(long number, Guid visitorGuid)
        //{
        //    var res = new ReturnedSaveFuncInfo();
        //    try
        //    {
        //        AdvDepartmentBusiness dep;
        //        if (visitorGuid == Guid.Empty)
        //            dep = await AdvDepartmentBusiness.GetAsync("نوین پرداز");
        //        else
        //        {
        //            var visitor = await VisitorBusiness.GetAsync(visitorGuid);
        //            dep = await AdvDepartmentBusiness.GetAsync(visitor?.DepartmentGuid ?? Guid.Empty);
        //        }

        //        if (dep == null)
        //        {
        //            res.AddReturnedValue(ReturnedState.Error, "Department is Null");
        //            return res;
        //        }

        //        if (!dep.IsSendChat)
        //        {
        //            res.AddReturnedValue(ReturnedState.Error, "Dont Permition Send Chat");
        //            return res;
        //        }
        //        var list = new List<string>();
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc1)) list.Add(dep.ChatList.Desc1);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc2)) list.Add(dep.ChatList.Desc2);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc3)) list.Add(dep.ChatList.Desc3);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc4)) list.Add(dep.ChatList.Desc4);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc5)) list.Add(dep.ChatList.Desc5);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc6)) list.Add(dep.ChatList.Desc6);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc7)) list.Add(dep.ChatList.Desc7);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc8)) list.Add(dep.ChatList.Desc8);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc9)) list.Add(dep.ChatList.Desc9);
        //        if (!string.IsNullOrEmpty(dep.ChatList.Desc10)) list.Add(dep.ChatList.Desc10);

        //        var cityList = new List<string>();
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City1)) cityList.Add(dep.ChatCity.City1);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City2)) cityList.Add(dep.ChatCity.City2);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City3)) cityList.Add(dep.ChatCity.City3);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City4)) cityList.Add(dep.ChatCity.City4);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City5)) cityList.Add(dep.ChatCity.City5);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City6)) cityList.Add(dep.ChatCity.City6);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City7)) cityList.Add(dep.ChatCity.City7);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City8)) cityList.Add(dep.ChatCity.City8);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City9)) cityList.Add(dep.ChatCity.City9);
        //        if (!string.IsNullOrEmpty(dep.ChatCity.City10)) cityList.Add(dep.ChatCity.City10);
        //        var rand = new Random().Next(0, cityList.Count);
        //        var catList = await DepartmentCategoryBusiness.GetAllAsync(dep.Guid);
        //        var rnd = new Random().Next(0, catList.ToList().Count);
        //        var d = DivarAdv.GetInstance();
        //        await d.SendChat(number, list, dep.ChatCount, cityList[rand], catList[rnd].FirstLevel,
        //            catList[rnd].SecondLevel,
        //            catList[rnd].ThirdLevel, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorLogInstance.StartLog(ex);
        //        res.AddReturnedValue(ex);
        //    }

        //    return res;
        //}
        #endregion


        private static async Task<ReturnedSaveFuncInfo> SendDivarAdv(BuildingBussines bu, long simCardNumber, bool isGiveChat, string sender, int imageCount, string title, string content)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.Parent == null || bu.Parent == EnBuildingParent.None)
                {
                    res.AddError("کاربری ملک معتبر نمی باشد");
                    return res;
                }
                if (bu.Parent == EnBuildingParent.RentAprtment || bu.Parent == EnBuildingParent.FullRentAprtment)
                {
                    var ret = new Divar_ResidentialApartmentRent(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.RentHome || bu.Parent == EnBuildingParent.FullRentHome)
                {
                    var ret = new Divar_ResidentialVillaRent(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.RentOffice || bu.Parent == EnBuildingParent.FullRentOffice)
                {
                    var ret = new Divar_OfficeOfficeRent(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.RentStore || bu.Parent == EnBuildingParent.FullRentStore)
                {
                    var ret = new Divar_OfficeStoreRent(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.RahnPrice1 > 0 || bu.EjarePrice1 > 0)
                {
                    if (bu.BuildingAccountTypeName.Contains("صنعتی") ||
                        bu.BuildingAccountTypeName.Contains("کشاورزی") ||
                        bu.BuildingAccountTypeName.Contains("دامداری") ||
                        bu.BuildingAccountTypeName.Contains("مرغداری") ||
                        bu.BuildingAccountTypeName.Contains("زراعی"))
                    {
                        var ret = new Divar_OfficeKeshavarziRent(bu, imageCount, isGiveChat, sender, title, content);
                        res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                        return res;
                    }

                }
                if (bu.Parent == EnBuildingParent.SellAprtment)
                {
                    var ret = new Divar_ResidentialApartmentSell(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.SellHome || bu.Parent == EnBuildingParent.SellVilla)
                {
                    var ret = new Divar_ResidentialVillaSell(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.SellOldHouse || bu.Parent == EnBuildingParent.SellLand)
                {
                    var ret = new Divar_ResidentialZaminSell(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.SellOffice)
                {
                    var ret = new Divar_OfficeOfficeSell(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.Parent == EnBuildingParent.SellStore)
                {
                    var ret = new Divar_OfficeStoreSell(bu, imageCount, isGiveChat, sender, title, content);
                    res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                    return res;
                }
                if (bu.SellPrice > 0)
                {
                    if (bu.BuildingAccountTypeName.Contains("صنعتی") ||
                        bu.BuildingAccountTypeName.Contains("کشاورزی") ||
                        bu.BuildingAccountTypeName.Contains("دامداری") ||
                        bu.BuildingAccountTypeName.Contains("مرغداری") ||
                        bu.BuildingAccountTypeName.Contains("زراعی"))
                    {
                        var ret = new Divar_OfficeKeshavarziSell(bu, imageCount, isGiveChat, sender, title, content);
                        res.AddReturnedValue(await ret.SendAsync(simCardNumber));
                        return res;
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
        public static StatusCode GetAdvStatusCodeByStatus(string advStatus)
        {
            switch (advStatus)
            {
                case "در صف انتشار": return StatusCode.InPublishQueue;
                case "منتشر شده": return StatusCode.Published;
                case "نیاز به اصلاح": return StatusCode.EditNeeded;
                case "منتظر پرداخت": return StatusCode.WaitForPayment;
                case "رد شده": return StatusCode.Failed;
                case "حذف شده": return StatusCode.Deleted;
                case "منقضی شده": return StatusCode.Expired;
                case "خطای درج": return StatusCode.InsertError;
                default: return StatusCode.Unknown;
            }
        }
        public static DateTime GetDateMFromPublishTime(string publishStr)
        {
            var resultDate = DateTime.Now;
            switch (publishStr)
            {
                case "دیروز":
                    resultDate = resultDate.AddDays(-1);
                    break;
                case "پریروز":
                    resultDate = resultDate.AddDays(-2);
                    break;
                case "۳ روز پیش":
                    resultDate = resultDate.AddDays(-3);
                    break;
                case "۴ روز پیش":
                    resultDate = resultDate.AddDays(-4);
                    break;
                case "۵ روز پیش":
                    resultDate = resultDate.AddDays(-5);
                    break;
                case "۶ روز پیش":
                    resultDate = resultDate.AddDays(-6);
                    break;
                case "هفتهٔ پیش":
                    resultDate = resultDate.AddDays(-7);
                    break;
                case "۱ هفته پیش":
                    resultDate = resultDate.AddDays(-7);
                    break;
                case "۲ هفته پیش":
                    resultDate = resultDate.AddDays(-14);
                    break;
                case "۳ هفته پیش":
                    resultDate = resultDate.AddDays(-21);
                    break;
                case "۴ هفته پیش":
                    resultDate = resultDate.AddDays(-28);
                    break;
                case "۵ هفته پیش":
                    resultDate = resultDate.AddDays(-35);
                    break;
                case "۶ هفته پیش":
                    resultDate = resultDate.AddDays(-42);
                    break;
                case "۷ هفته پیش":
                    resultDate = resultDate.AddDays(-49);
                    break;
            }

            return resultDate;
        }
        public static async Task<string> GetScreenShot()
        {
            try
            {
                var rootPath = Path.Combine(Application.StartupPath, "ScreenShots");
                var savePath = Path.Combine(rootPath, Guid.NewGuid() + ".jpg");

                if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);
                await Wait(3);
                _driver = RefreshDriver(SettingsBussines.AdvertiseSetting.IsSilent);
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(savePath, ScreenshotImageFormat.Jpeg);

                return savePath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return "";
        }
        public static async Task<ReturnedSaveFuncInfo> Init(long number)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var divar = DivarAdv.GetInstance();
                res.AddReturnedValue(await divar.StartRegisterAdv(number));
                Navigate("https://divar.ir/new");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> ManageAdvSend(BuildingBussines bu, SimcardBussines simcard, AdvertiseType type, bool isGiveChat, string sender, int imageCount, string title, string content)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (type == AdvertiseType.Divar)
                    res.AddReturnedValue(await SendDivarAdv(bu, simcard.Number, isGiveChat, sender, imageCount, title, content));

                //if (type == AdvertiseType.Sheypoor)
                //    res.AddReturnedValue(await SendAdv(adv.value, number.Number, AdvertiseType.Sheypoor));

                //if (type == AdvertiseType.Both)
                //{
                //    var divarAdv = await GetNextAdv(bu, AdvertiseType.Divar, number.Number);
                //    var sheypoorAdv = await GetNextAdv(bu, AdvertiseType.Sheypoor, number.Number);

                //    res.AddReturnedValue(await SendAdv(divarAdv.value, number.Number, AdvertiseType.Divar));
                //    res.AddReturnedValue(await SendAdv(sheypoorAdv.value, number.Number, AdvertiseType.Sheypoor));
                //}

                CloseAllChromeWindows();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAdv(AdvertiseType type, string fCat, string sCat,
            string thCat, string state, string city, string region, string title, string content, long number,
            decimal price1, decimal price2, string url)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var log = new AdvertiseLogBussines()
                {
                    Guid = Guid.NewGuid(),
                    Region = region,
                    Title = title,
                    Content = content,
                    City = city,
                    State = state,
                    SimcardNumber = number,
                    Price2 = price2,
                    Price1 = price1,
                    DateM = DateTime.Now,
                    SubCategory2 = thCat,
                    Category = fCat,
                    SubCategory1 = sCat,
                    AdvType = type,
                    IP = Utilities.GetNetworkIpAddress(),
                    LastUpdate = DateTime.Now,
                    StatusCode = StatusCode.InPublishQueue,
                    URL = url,
                    UpdateDesc = "آگهی در صف انتشار قرارداد",
                    VisitCount = 0
                };
                res.AddReturnedValue(await log.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
