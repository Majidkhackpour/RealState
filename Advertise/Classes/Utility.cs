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
using EntityCache.Bussines;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Services;
using Settings.Classes;

namespace Advertise.Classes
{
    public static class Utility
    {

        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        const int WtsCurrentSession = -1;
        static readonly IntPtr WtsCurrentServerHandle = IntPtr.Zero;
        public static async Task<string> GetLocalIpAddress()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

                request.UserAgent = "curl";

                string publicIpAddress;

                request.Method = "GET";
                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                    publicIpAddress = reader.ReadToEnd();

                return publicIpAddress.Replace("\n", "");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<string> GetNetworkIpAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                    if (ip.AddressFamily == AddressFamily.InterNetwork) return ip.ToString();
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static async Task Wait(double second = 0.1, [System.Runtime.CompilerServices.CallerMemberName]
            string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath]
            string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber]
            int sourceLineNumber = 0)
        {
            await Task.Delay((int)(second * 1000));
        }

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
        public static IWebDriver RefreshDriver(IWebDriver driver, bool isSilent)
        {
            try
            {
                if (driver?.Title == null)
                    driver = isSilent ? OpenDriverSilent(driver) : OpenDriver(driver);
            }
            catch (Exception)
            {
                driver = isSilent ? OpenDriverSilent(driver) : OpenDriver(driver);
            }
            return driver;
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
        private static async Task<ReturnedSaveFuncInfo> SendAdv(int index, List<long> lst, int maxDailyCountDivar,
            int maxDailyCountSheypoor)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (index == (int)AdvertiseType.Divar) res.AddReturnedValue(await DivarSend(lst, maxDailyCountDivar));
                else if (index == (int)AdvertiseType.Sheypoor)
                    res.AddReturnedValue(await SheypoorSend(lst, maxDailyCountSheypoor));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> DivarSend(List<long> lst, int maxDailyCountDivar)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (clsAdvertise.DivarSetting.AdvCountInDay == 0)
                {
                    res.AddReturnedValue(ReturnedState.Error, "Divar AdvCountInDay=0");
                    return res;
                }
                res.AddReturnedValue(await Utilities.PingHostAsync());

                if (!res.HasError)
                {
                    var divar = DivarAdv.GetInstance();
                    await divar.StartRegisterAdv(false, lst, maxDailyCountDivar);
                    //await SendChat(lst[0]);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> SheypoorSend(List<long> lst, int maxDailyCountSheypoor)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (clsAdvertise.SheypoorSetting.AdvCountInDay == 0)
                {
                    res.AddReturnedValue(ReturnedState.Error, "Sheypoor AdvCountInDay=0");
                    return res;
                }
                res.AddReturnedValue(await Utilities.PingHostAsync());
                if (!res.HasError)
                {
                    var sheypoor = SheypoorAdv.GetInstance();
                    await sheypoor.StartRegisterAdv(lst, maxDailyCountSheypoor);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task UpdateAdvStatus(int dayCount = 0)
        {
            try
            {
                TelegramSender.GetAdvertiseLog_bot()
                    .Send($"سیستم مرجع: {await GetNetworkIpAddress()} \r\n آغاز فرایند بروز رسانی آگهی ها");
                DeleteTemp();

                var divar = DivarAdv.GetInstance();
                await divar.UpdateAllAdvStatus(500, dayCount);

                var sheypoor = SheypoorAdv.GetInstance();
                await sheypoor.UpdateAllAdvStatus(500, dayCount);

                DeleteTemp();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

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

        #region GetAdv
        public static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetNextAdv(AdvertiseType type, long simCardNumber)
        {
            var res = new ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>();
            try
            {
                res.value = new AdvertiseLogBussines { SimcardNumber = simCardNumber };
                //var replacements = await VisitorBusiness.GetMasterSlaveAdvReplacementsAsync(res.value.SimcardNumber);
                //res.AddReturnedValue(await GetMasterSlaveReplaceMentAdv(replacements, res));
                //var adv = await BuildingBussines.GetAsync(Guid.NewGuid());
                //res.AddReturnedValue(await GetAdvAddress(type, adv, res));
                //res.AddReturnedValue(await GetAdvTitle(adv, res));
                //res.AddReturnedValue(await GetAdvContent(type, adv, replacements, res));
                //res.AddReturnedValue(await GetAdvImages(type, res));
                //res.AddReturnedValue(await GetAdvCity(type, res));
                //res.AddReturnedValue(await GetAdvCategory(type, adv, res));
                //res.value.Price1 = adv.SellPrice;
                res.value.IP = await GetLocalIpAddress();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
      
        private static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetAdvTitle(EntityCache.ViewModels.Advertise adv,
            ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines> res)
        {
            try
            {

                if (adv.Titles?.Count <= 0)
                {
                    res.AddReturnedValue(ReturnedState.Error, $"Adv Titles is Null");
                    return res;
                }

                var nextTitleIndex = new Random(DateTime.Now.Millisecond).Next(adv.Titles.Count);
                res.value.Title = adv.Titles[nextTitleIndex];


                if (string.IsNullOrEmpty(res.value.Title))
                {
                    res.AddReturnedValue(ReturnedState.Error, $"AdvLog Title is Null");
                    return res;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
       //private static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetAdvCity(AdvertiseType type,
       //     ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines> res)
       // {
       //     try
       //     {

       //         var city = new CityBusiness();
       //         if (type == AdvertiseType.Divar)
       //             city = await CityBusiness.GetNextRandomCityAsync(res.value.MasterVisitorGuid,
       //                 AdvertiseType.Divar);
       //         else if (type == AdvertiseType.Sheypoor)
       //             city = await CityBusiness.GetNextRandomCityAsync(res.value.MasterVisitorGuid,
       //                 AdvertiseType.Sheypoor);
       //         res.value.City = city?.CityName;
       //         res.value.State = city?.State?.StateName;
       //     }
       //     catch (Exception ex)
       //     {
       //         WebErrorLog.ErrorLogInstance.StartLog(ex);
       //         res.AddReturnedValue(ex);
       //     }

       //     return res;
       // }
        //private static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetAdvCategory(
        //    AdvertiseType type, EntityCache.ViewModels.Advertise adv, ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines> res)
        //{
        //    try
        //    {
        //        if (type == AdvertiseType.Divar)
        //        {
        //            if (adv.DivarCats != null &&
        //                adv.DivarCats.Count > 0)
        //            {
        //                var random = new Random().Next(0, adv.DivarCats.Count);
        //                res.value.Category = adv?.DivarCats[random].Item1 ?? "";
        //                res.value.SubCategory1 = adv?.DivarCats[random].Item2 ?? "";
        //                res.value.SubCategory2 = adv?.DivarCats[random].Item3 ?? "";
        //            }
        //            else
        //            {
        //                res.value.SubCategory1 = null;
        //                res.value.SubCategory2 = null;
        //            }
        //        }

        //        if (type == AdvertiseType.Sheypoor)
        //        {
        //            if (adv.SheypoorCats != null && adv.SheypoorCats.Count > 0)
        //            {
        //                var random = new Random().Next(0, adv.SheypoorCats.Count);
        //                res.value.SubCategory1 = adv?.SheypoorCats[random].Item1 ?? "";
        //                res.value.SubCategory2 = adv?.SheypoorCats[random].Item2 ?? "";
        //            }
        //            else
        //            {
        //                res.value.SubCategory1 = null;
        //                res.value.SubCategory2 = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorLogInstance.StartLog(ex);
        //        res.AddReturnedValue(ex);
        //    }

        //    return res;
        //}
        private static List<string> GetNextImages(string advFullPath, int imgCount = 3)
        {
            var resultImages = new List<string>();
            try
            {
                if (string.IsNullOrEmpty(advFullPath)) return resultImages;
                //گرفتن تمام عکسهای پوشه و فیلتر کردن عکسهای درست
                var picturesPath = Path.Combine(advFullPath, "Pictures");
                var allImages = Utility.GetFiles(picturesPath, "*.jpg");
                var selectedImages = new List<string>();
                //حذف عکسهای زیر پیکسل 600*600
                foreach (var imgItem in allImages)
                {
                    var img = Image.FromFile(imgItem);
                    if (img.Width < 600 || img.Height < 600)
                        try
                        {
                            img.Dispose();
                            File.Delete(imgItem);
                        }
                        catch
                        {
                            /**/
                        }
                    img.Dispose();
                }
                allImages = Utility.GetFiles(picturesPath, "*.jpg");

                if (allImages.Count <= imgCount) selectedImages = allImages;
                else
                {
                    var indexes = new List<int>();
                    var rnd = new Random();
                    while (indexes.Count < imgCount)
                    {
                        var index = rnd.Next(allImages.Count);
                        if (!indexes.Contains(index))
                            indexes.Add(index);
                    }

                    selectedImages.AddRange(indexes.Select(index => allImages[index]));
                }


                //ویرایش عکسها
                foreach (var img in selectedImages)
                    resultImages.Add(ImageManager.ModifyImage(img));

                return resultImages;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return resultImages;
            }
        }
        #endregion

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
        public static async Task<string> GetScreenShot(IWebDriver _driver)
        {
            try
            {
                var rootPath = Path.Combine(Application.StartupPath, "ScreenShots");
                var savePath = Path.Combine(rootPath, Guid.NewGuid() + ".jpg");

                if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);
                await Wait(3);
                _driver = RefreshDriver(_driver, clsAdvertise.IsSilent);
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(savePath, ScreenshotImageFormat.Jpeg);

                return savePath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return "";
        }

    }
}
