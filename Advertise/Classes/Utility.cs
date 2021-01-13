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
using Advertise.ViewModels.Divar.Rent.Residential;
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
        private static async Task<ReturnedSaveFuncInfo> SendAdv(AdvertiseLogBussines adv, long number, AdvertiseType type)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (type == AdvertiseType.Divar) res.AddReturnedValue(await DivarSend(adv, number));
                else if (type == AdvertiseType.Sheypoor)
                    res.AddReturnedValue(await SheypoorSend(adv, number));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> DivarSend(AdvertiseLogBussines adv, long number)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (clsAdvertise.Divar_AdvCountInDay == 0)
                {
                    res.AddReturnedValue(ReturnedState.Error, "Divar AdvCountInDay=0");
                    return res;
                }
                res.AddReturnedValue(await Utilities.PingHostAsync());

                if (!res.HasError)
                {
                    var divar = DivarAdv.GetInstance();
                    await divar.StartRegisterAdv(adv, number);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> SheypoorSend(AdvertiseLogBussines adv, long number)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (clsAdvertise.Sheypoor_AdvCountInDay == 0)
                {
                    res.AddReturnedValue(ReturnedState.Error, "Sheypoor AdvCountInDay=0");
                    return res;
                }
                res.AddReturnedValue(await Utilities.PingHostAsync());
                if (!res.HasError)
                {
                    var sheypoor = SheypoorAdv.GetInstance();
                    await sheypoor.StartRegisterAdv(adv, number);
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
                    .Send($"سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n آغاز فرایند بروز رسانی آگهی ها");
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
        private static async Task<ReturnedSaveFuncInfo> SendDivarAdv(BuildingBussines bu, long simCardNumber)
        {
            var res = new ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>();
            try
            {


                res.value = new AdvertiseLogBussines { SimcardNumber = simCardNumber };

                res.AddReturnedValue(await GetAdvTitle(bu, res));
                res.AddReturnedValue(await GetAdvContent(bu, res));
                res.AddReturnedValue(await GetAdvOption(bu, res));

                var path = Path.Combine(Application.StartupPath, "Images");
                res.value.ImagesPathList = GetNextImages(bu, path);

                if (bu.RahnPrice1 > 0 || bu.RahnPrice2 > 0)
                {
                    res.value.Price1 = bu.RahnPrice1;
                    res.value.Price2 = bu.EjarePrice1;
                    if (bu.RahnPrice2 > 0 || bu.EjarePrice2 > 0)
                        res.value.Tabdil = "قابل تبدیل";
                    else res.value.Tabdil = "غیر قابل تبدیل";

                    var rentAuth = await RentalAuthorityBussines.GetAsync(bu.RentalAutorityGuid ?? Guid.Empty);
                    if (rentAuth != null && rentAuth.Name.Contains("مجرد"))
                        res.value.RentalAuthority = "خانواده و مجرد";
                }
                else if (bu.SellPrice > 0)
                {
                    res.value.Price1 = bu.SellPrice;
                    res.value.Price2 = 0;
                }

                res.value.IP = await Utilities.GetLocalIpAddress();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetAdvTitle(BuildingBussines bu,
            ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines> res)
        {
            try
            {
                var type = "";
                var regionName = "";

                if (bu.RahnPrice1 > 0 || bu.RahnPrice2 > 0) type = "رهن و اجاره";
                else if (bu.SellPrice > 0) type = "فروش";

                if (bu.RegionGuid != Guid.Empty) regionName = RegionsBussines.Get(bu.RegionGuid)?.Name ?? "";

                res.value.Title = $"{type} ملک در {regionName}";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetAdvContent(BuildingBussines bu,
            ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines> res)
        {
            try
            {
                var content = new StringBuilder();
                var reg = "";
                if (bu.RegionGuid != Guid.Empty)
                    reg = RegionsBussines.Get(bu.RegionGuid)?.Name ?? "";

                content.AppendLine($"محدوده: {reg}");
                content.AppendLine($"متراژ: {bu.Masahat}");
                content.AppendLine($"سال ساخت: {bu.SaleSakht}");
                content.AppendLine($"تعداد اتاق: {bu.RoomCount}");
                content.AppendLine($"طبقه: {bu.TabaqeNo} از {bu.TedadTabaqe}");

                res.value.Content = content.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static List<string> GetNextImages(BuildingBussines bu, string imageAddress, int imgCount = 3)
        {
            var resultImages = new List<string>();
            try
            {
                if (string.IsNullOrEmpty(imageAddress)) return resultImages;
                //گرفتن تمام عکسهای پوشه و فیلتر کردن عکسهای درست
                var advFullPath = bu.GalleryList.Select(q => q.ImageName);
                var allImages = new List<string>();
                foreach (var imgName in advFullPath)
                {
                    var fullPath = Path.Combine(imageAddress, imgName + ".jpg");
                    if (!File.Exists(fullPath)) continue;
                    allImages.Add(fullPath);
                }
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
        private static async Task<ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines>> GetAdvOption(BuildingBussines bu,
            ReturnedSaveFuncInfoWithValue<AdvertiseLogBussines> res)
        {
            try
            {
                var options = bu.OptionList;
                if (options == null) return res;

                var asansor = options.Any(q => q.OptionName.Contains("آسانسور") || q.OptionName.Contains("اسانسور"));
                var parking = options.Any(q => q.OptionName.Contains("پارکینگ"));
                var anbar = options.Any(q => q.OptionName.Contains("انبار"));
                var balkon = options.Any(q => q.OptionName.Contains("بالکن") || q.OptionName.Contains("تراس"));

                res.value.Asansor = asansor;
                res.value.Parking = parking;
                res.value.Anbari = anbar;
                res.value.Balkon = balkon;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
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
        public static async Task<ReturnedSaveFuncInfo> ManageAdvSend(List<BuildingBussines> buList, List<SimcardBussines> simcardList, AdvertiseType type)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var number in simcardList)
                {
                    var rand = new Random().Next(0, buList.Count);
                    var bu = buList[rand];


                    if (type == AdvertiseType.Divar)
                        res.AddReturnedValue(await SendDivarAdv(bu, number.Number));

                    //if (type == AdvertiseType.Sheypoor)
                    //    res.AddReturnedValue(await SendAdv(adv.value, number.Number, AdvertiseType.Sheypoor));

                    //if (type == AdvertiseType.Both)
                    //{
                    //    var divarAdv = await GetNextAdv(bu, AdvertiseType.Divar, number.Number);
                    //    var sheypoorAdv = await GetNextAdv(bu, AdvertiseType.Sheypoor, number.Number);

                    //    res.AddReturnedValue(await SendAdv(divarAdv.value, number.Number, AdvertiseType.Divar));
                    //    res.AddReturnedValue(await SendAdv(sheypoorAdv.value, number.Number, AdvertiseType.Sheypoor));
                    //}
                }
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
