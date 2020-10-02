using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Services;
using Settings.Classes;


namespace Advertise.Classes
{
    public class DivarAdv
    {
        #region Fields
        private IWebDriver _driver;
        public static event Action SubmitEvent;
        public static event Action SubmitEvent_Update;
        private int MaxImgForAdv { get; }
        #endregion
        private static void RaiseEvent()
        {
            var handler = SubmitEvent;
            if (handler != null)
                SubmitEvent();
        }

        private static void RaiseEvent_Update()
        {
            var handler = SubmitEvent_Update;
            if (handler != null) SubmitEvent_Update();
        }
        private static DivarAdv _me;

        private DivarAdv()
        {
            // if (string.IsNullOrEmpty(_advRootPath)) _advRootPath = ConfigurationManager.AppSettings.Get("RootPath");
        }

        public static DivarAdv GetInstance()
        {
            return _me ?? (_me = new DivarAdv());
        }

        #region MyRegion

        private List<string> lstMessage = new List<string>();
        public async Task StartRegisterAdv(List<long> numbers = null, int count = 1, bool isRaiseEvent = true)
        {
            var counter = 0;
            try
            {
                var res = await Utilities.PingHostAsync();
                while (res.HasError)
                {
                    await Utility.Wait(10);
                    lstMessage.Clear();
                    lstMessage.Add("خطای اتصال به شبکه");
                    Utility.ShowBalloon("لطفا اتصال به شبکه را چک نمایید", lstMessage);
                    counter++;
                    res = await Utilities.PingHostAsync();
                }


                foreach (var number in numbers)
                {
                    var sim = await SimcardBussines.GetAsync(number);
                    var hasToken = sim?.Token ?? null;
                    if (string.IsNullOrEmpty(hasToken))
                    {
                        lstMessage.Clear();
                        lstMessage.Add("نوع آگهی: دیوار");
                        lstMessage.Add($"شماره: {number}");
                        lstMessage.Add("نداشتن_توکن#");
                        lstMessage.Add($"مالک: {sim.Owner}");
                        lstMessage.Add("بدلیل توکن نداشتن، موفق به لاگین نشد");
                        Utility.ShowBalloon("عدم انجام لاگین", lstMessage);
                        await sim.SaveAsync();
                        return;
                    }
                    if (!await Login(number, false) || !await UpdateAllRegisteredAdvOfSimCard(number)) continue;
                    for (var i = 0; i < count; i++)
                    {
                        var adv = await GetNextAdv(number);
                        if (adv == null) continue;
                        await RegisterAdv(adv, isRaiseEvent);
                        await Utility.Wait(1);
                        sim.Modified = DateTime.Now;
                        await sim.SaveAsync();
                    }
                }
            }
            catch (WebException)
            {
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public async Task<bool> Login(long simCardNumber, bool isFromSimForm)
        {
            try
            {
                if (isFromSimForm)
                {
                    _driver = Utility.RefreshDriver(_driver);
                    if (!_driver.Url.Contains("divar.ir"))
                        _driver.Navigate().GoToUrl("https://divar.ir");
                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    var tokenInDatabase = sim?.Token ?? null;
                    var hastoken = !string.IsNullOrEmpty(tokenInDatabase);

                    var listLinkItems = _driver.FindElements(By.TagName("a"));
                    var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                    if (isLogined && !string.IsNullOrEmpty(tokenInDatabase))
                    {
                        var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == tokenInDatabase)
                            return true;
                    }

                    if (isLogined)
                    {
                        _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                        _driver.Manage().Cookies.DeleteCookieNamed("token");
                    }

                    if (!string.IsNullOrEmpty(tokenInDatabase))
                    {
                        var token = new OpenQA.Selenium.Cookie("token", tokenInDatabase);
                        _driver.Manage().Cookies.AddCookie(token);
                        _driver.Navigate().Refresh();
                    }
                    else
                    {
                        _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                        await Utility.Wait();
                        _driver.FindElement(By.ClassName("login-message__login-btn")).Click();
                        await Utility.Wait();
                        var currentWindow = _driver.CurrentWindowHandle;
                        _driver.SwitchTo().Window(currentWindow);
                        if (_driver.FindElements(By.Name("mobile")).Count > 0)
                            _driver.FindElement(By.Name("mobile")).SendKeys("0" + simCardNumber);
                    }

                    var repeat = 0;
                    while (repeat < 20)
                    {
                        listLinkItems = _driver.FindElements(By.TagName("a"));
                        if (listLinkItems.Count < 5) return false;

                        var isLogin = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                        if (isLogin)
                        {
                            //var all = _driver.Manage().Cookies.AllCookies.ToList();
                            tokenInDatabase = _driver.Manage().Cookies.GetCookieNamed("token").Value;

                            sim.Token = tokenInDatabase;
                            sim.Modified = DateTime.Now;
                            sim.Number = simCardNumber;

                            await sim.SaveAsync();

                            _driver.ExecuteJavaScript(@"alert('لاگین انجام شد');");
                            await Utility.Wait();
                            _driver.SwitchTo().Alert().Accept();
                            return true;
                        }
                        else
                        {
                            var message = $@"مالک: {sim.Owner} \r\nشماره: {simCardNumber}  \r\nلطفا لاگین نمائید ";
                            _driver.ExecuteJavaScript($"alert('{message}');");

                            await Utility.Wait(3);
                            try
                            {
                                _driver.SwitchTo().Alert().Accept();
                                await Utility.Wait(3);
                                repeat++;
                            }
                            catch
                            {
                                await Utility.Wait(10);
                            }
                        }
                    }
                }
                else
                {
                    _driver = Utility.RefreshDriver(_driver);
                    if (!_driver.Url.Contains("divar.ir"))
                        _driver.Navigate().GoToUrl("https://divar.ir");

                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    var tokenInDatabase = sim?.Token ?? null;
                    if (string.IsNullOrEmpty(tokenInDatabase))
                    {
                        return false;
                    }

                    var listLinkItems = _driver.FindElements(By.TagName("a"));
                    var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                    if (isLogined && !string.IsNullOrEmpty(tokenInDatabase))
                    {
                        var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == tokenInDatabase)
                            return true;
                    }

                    if (isLogined)
                    {
                        _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                        _driver.Manage().Cookies.DeleteCookieNamed("token");
                    }

                    if (!string.IsNullOrEmpty(tokenInDatabase))
                    {
                        var token = new OpenQA.Selenium.Cookie("token", tokenInDatabase);
                        _driver.Manage().Cookies.AddCookie(token);
                        _driver.Navigate().Refresh();
                    }
                    else
                    {
                        _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                        await Utility.Wait();
                        _driver.FindElement(By.ClassName("login-message__login-btn")).Click();
                        await Utility.Wait();
                        var currentWindow = _driver.CurrentWindowHandle;
                        _driver.SwitchTo().Window(currentWindow);
                        if (_driver.FindElements(By.Name("mobile")).Count > 0)
                            _driver.FindElement(By.Name("mobile")).SendKeys("0" + simCardNumber);
                    }

                    var repeat = 0;
                    while (repeat < 3)
                    {
                        listLinkItems = _driver.FindElements(By.TagName("a"));
                        if (listLinkItems.Count < 5) return false;

                        var isLogin = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                        if (isLogin)
                        {
                            await Utility.Wait();
                            return true;
                        }
                        else
                        {
                            var menu = _driver.FindElements(By.ClassName("menu")).Any();
                            if (menu)
                            {
                                listLinkItems = _driver.FindElements(By.ClassName("item"));
                                isLogin = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");
                                if (isLogin)
                                    return true; ;
                            }
                            var exMenu = _driver.FindElements(By.ClassName("sidebar")).Any();
                            if (exMenu)
                            {
                                _driver.FindElements(By.ClassName("sidebar")).FirstOrDefault()?.Click();
                                continue;
                            }

                            await Utility.Wait(3);
                            try
                            {
                                await Utility.Wait(3);
                                repeat++;
                            }
                            catch
                            {
                                await Utility.Wait(10);
                            }
                        }
                    }
                }

                return false;
            }
            catch (WebException) { return false; }
            catch (Exception ex)
            {
                if (ex.Source != "WebDriver")
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }

        private async Task RegisterAdv(AdvertiseLogBussines adv, bool isRaiseEvent)
        {
            var ret = new ReturnedSaveFuncInfo();
            //try
            //{
            //    _driver = Utility.RefreshDriver(_driver);
            //    _driver.Navigate().GoToUrl("https://divar.ir/new");
            //    await Utility.Wait(1);
            //    //کلیک کردن روی کتگوری اصلی
            //    if (string.IsNullOrEmpty(adv.Category))
            //        adv.Category = clsAdvertise.Category1 ?? "";
            //    _driver.FindElements(By.ClassName("expanded-category-selector__item"))
            //        .FirstOrDefault(p => p.Text == adv.Category)?.Click();
            //    await Utility.Wait(2);
            //    //کلیک روی ساب کتگوری 1
            //    if (string.IsNullOrEmpty(adv.SubCategory1))
            //        adv.SubCategory1 = clsAdvertise.Category2 ?? "";
            //    _driver.FindElements(By.ClassName("expanded-category-selector__item"))
            //        .FirstOrDefault(p => p.Text == adv.SubCategory1)?.Click();
            //    await Utility.Wait(2);
            //    //کلیک روی ساب کتگوری2
            //    if (string.IsNullOrEmpty(adv.SubCategory2))
            //        adv.SubCategory2 = clsAdvertise.Category3 ?? "";
            //    _driver.FindElements(By.ClassName("expanded-category-selector__item"))
            //        .FirstOrDefault(p => p.Text == adv.SubCategory2)?.Click();

            //    await Utility.Wait(2);
            //    var load = _driver.FindElements(By.ClassName("location-selector__city")).Any();

            //    //درج عکسها

            //    _driver.FindElement(By.ClassName("image-uploader__dropzone")).FindElement(By.TagName("input"))
            //        .SendKeys(adv.ImagesPath);
            //    await Utility.Wait();

            //    _driver.FindElement(By.ClassName("location-selector__city")).FindElement(By.TagName("input"))
            //        .SendKeys(adv.City + "\n");

            //    await Utility.Wait();
            //    var el = _driver.FindElements(By.ClassName("location-selector__district")).Any();
            //    await Utility.Wait();
            //    if (el)
            //    {
            //        var cty = await CityBusiness.GetAsync(adv?.City);
            //        await Utility.Wait(1);
            //        var cityGuid = cty.Guid;
            //        var lst = await RegionBusiness.GetAllAsync(cityGuid);
            //        var regionList = lst?.ToList() ?? new List<RegionBusiness>();
            //        if (regionList.Count > 0)
            //        {
            //            var rnd = new Random().Next(0, regionList.Count);
            //            var regName = regionList[rnd].Name;
            //            await Utility.Wait(2);


            //            _driver.FindElement(By.ClassName("location-selector__district"))
            //                .FindElement(By.TagName("input")).SendKeys(regName + "\n");
            //            adv.Region = regName;
            //        }
            //    }


            //    //درج قیمت
            //    if (adv.Price1 > 0)
            //        _driver.FindElement(By.CssSelector("input[type=tel]")).SendKeys(adv.Price1.ToString());
            //    await Utility.Wait();
            //    //درج عنوان آگهی
            //    _driver.FindElements(By.CssSelector("input[type=text]")).Last().SendKeys(adv.Title);
            //    await Utility.Wait();
            //    //درج محتوای آگهی
            //    var thread = new Thread(() => Clipboard.SetText(adv.Content));
            //    thread.SetApartmentState(ApartmentState.STA);
            //    thread.Start();

            //    var t = _driver.FindElement(By.TagName("textarea"));
            //    t.Click();
            //    await Utility.Wait();
            //    t.SendKeys(OpenQA.Selenium.Keys.Control + "v");
            //    var thread1 = new Thread(Clipboard.Clear);
            //    thread1.SetApartmentState(ApartmentState.STA);
            //    thread1.Start();
            //    await Utility.Wait();

            //    await Utility.Wait();

            //    var loadImg = _driver.FindElements(By.ClassName("image-item__progress")).ToList();
            //    while (loadImg.Count > 0)
            //    {
            //        await Utility.Wait(2);
            //        loadImg = _driver.FindElements(By.ClassName("image-item__progress")).ToList();
            //    }

            //    if (_driver.FindElements(By.ClassName("location-selector__district")).Count > 0 &&
            //        (string.IsNullOrEmpty(adv.Region) || adv.Region == "-"))
            //        _driver.FindElement(By.ClassName("location-selector__district")).FindElement(By.TagName("input"))
            //            .SendKeys("\n");

            //    var but = _driver.FindElements(By.TagName("button")).Any(q => q.Text.Contains("ارسال آگهی"));
            //    if (but)
            //        //کلیک روی دکمه ثبت آگهی
            //        _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text.Contains("ارسال آگهی"))
            //            ?.Click();

            //    await Utility.Wait(2);

            //    adv.URL = _driver.Url;
            //    adv.UpdateDesc = @"در صف انتشار";
            //    adv.StatusCode = StatusCode.InPublishQueue;
            //    adv.IP = await Utility.GetLocalIpAddress();
            //    await adv.SaveAsync();

            //    if (_driver.Url != adv.URL)
            //        _driver.Navigate().GoToUrl(adv.URL);
            //    await Utility.Wait(1);

            //    if (isRaiseEvent) RaiseEvent();
            //}
            //catch (ElementClickInterceptedException)
            //{
            //}
            //catch (WebDriverException)
            //{
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //    ret.AddReturnedValue(ex);
            //}
        }
        private async Task<AdvertiseLogBussines> GetNextAdv(long simCardNumber)
        {
            var getUrlertiseLogBusiness = new AdvertiseLogBussines();
            //try
            //{
            //    getUrlertiseLogBusiness.SimcardNumber = simCardNumber;

            //    string path = null;
            //    if (Adv == null) return null;

            //    #region FindNextTitle
            //    //تایتل آگهی دریافت می شود
            //    if (!(Adv.Titles?.Count > 0)) return null;

            //    var nextTitleIndex = new Random(DateTime.Now.Millisecond).Next(Adv.Titles.Count);
            //    getUrlertiseLogBusiness.Title = Adv.Titles[nextTitleIndex];


            //    if (string.IsNullOrEmpty(getUrlertiseLogBusiness.Content)) return null;
            //    #endregion

            //    #region GetContent
            //    //کانتنت آگهی دریافت می شود


            //    getUrlertiseLogBusiness.Content = Adv.Content;


            //    if (string.IsNullOrEmpty(getUrlertiseLogBusiness.Content)) return null;

            //    #endregion

            //    #region FindImages
            //    //عکسهای آگهی دریافت می شود
            //    getUrlertiseLogBusiness.ImagesPathList = GetNextImages(getUrlertiseLogBusiness.Adv,
            //        clsAdvertise.PicCountInPerAdv.ParseToInt());
            //    #endregion

            //    //قیمت آگهی دریافت می شود
            //    getUrlertiseLogBusiness.Price1 = Adv.Price;
            //    var city = await CityBusiness.GetNextRandomCityAsync(getUrlertiseLogBusiness.MasterVisitorGuid);
            //    getUrlertiseLogBusiness.City = city?.CityName;

            //    return getUrlertiseLogBusiness;
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //    return null;
            //}
            return getUrlertiseLogBusiness;
        }


        private List<string> GetNextImages(string advFullPath, int imgCount = 3)
        {
            var resultImages = new List<string>();
            try
            {
                if (string.IsNullOrEmpty(advFullPath)) return resultImages;
                var picturesPath = Path.Combine(advFullPath, "Pictures");
                var allImages = Utility.GetFiles(picturesPath, "*.jpg");
                var selectedImages = new List<string>();
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


        public async Task<bool> UpdateAllAdvStatus(int takeCount, int dayCount = 0, long number = 0, bool isRaisEvent = true, string toDate = null)
        {
            while (true)
            {
                try
                {
                    List<AdvertiseLogBussines> allAdvertiseLog = null;
                    _driver = Utility.RefreshDriver(_driver);

                    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                    {
                        dayCount = 7;
                        var lastWeek = DateTime.Now.AddDays(-dayCount);
                        var lst = await AdvertiseLogBussines
                            .GetAllSpecialAsync(p => p.DateM > lastWeek && p.URL.Contains("manage"));
                        allAdvertiseLog = lst.OrderBy(q => q.LastUpdate).ToList();
                        if (allAdvertiseLog.Count <= 0) return true;
                    }
                    else
                    {
                        if (dayCount == 0)
                            dayCount = clsAdvertise.DayCountForUpdateState.ParseToInt();
                        var lastWeek = DateTime.Now.AddDays(-dayCount);
                        if (number == 0)
                        {
                            var lst = await AdvertiseLogBussines
                                .GetAllSpecialAsync(p => p.DateM > lastWeek && p.URL.Contains("manage"));
                            allAdvertiseLog = lst.OrderBy(q => q.LastUpdate).ToList();
                            if (allAdvertiseLog.Count <= 0) return true;
                            if (takeCount != 0)
                            {
                                var dayOfWeek = allAdvertiseLog.First().LastUpdate.DayOfWeek;
                                if (dayOfWeek == DateTime.Now.DayOfWeek) return true;
                                if (allAdvertiseLog.Count > takeCount)
                                    allAdvertiseLog = allAdvertiseLog.Take(takeCount).ToList();
                            }
                        }
                        else
                        {
                            var lst = await AdvertiseLogBussines
                                .GetAllSpecialAsync(p =>
                                    p.DateM > lastWeek && p.URL.Contains("manage") && p.SimcardNumber == number);
                            allAdvertiseLog = lst.OrderByDescending(q => q.LastUpdate).ToList();
                            if (allAdvertiseLog.Count <= 0) return true;
                            if (takeCount != 0)
                            {
                                if (allAdvertiseLog.Count > takeCount)
                                    allAdvertiseLog = allAdvertiseLog.Take(takeCount).ToList();
                            }
                        }

                        if (toDate != null)
                        {
                            var from = Calendar.ShamsiToMiladi(toDate);
                            var tommorrow = from.AddDays(1);
                            var lst = await AdvertiseLogBussines
                                .GetAllSpecialAsync(p =>
                                    p.DateM >= from && p.DateM <= tommorrow && p.URL.Contains("manage"));
                            allAdvertiseLog = lst.OrderByDescending(q => q.LastUpdate).ToList();
                            if (allAdvertiseLog.Count <= 0) return true;
                        }
                    }

                    var tryCount = 0;
                    var listNumbers = new List<long>();
                    foreach (var adv in allAdvertiseLog)
                    {
                        if (tryCount >= 3) continue;
                        try
                        {
                            _driver.Navigate().GoToUrl(adv.URL);
                            await Utility.Wait(2);
                            listNumbers.Add(adv.SimcardNumber);
                            var notFound = _driver
                                .FindElements(By.ClassName("title")).Any(q => q.Text == "این راه به جایی نمیرسد!");
                            if (notFound)
                            {
                                adv.UpdateDesc = "لینک مدیریتی باطل شده";
                                adv.StatusCode = StatusCode.Failed;
                                adv.LastUpdate = DateTime.Now;
                                adv.URL = "---";
                                await adv.SaveAsync();
                                continue;
                            }

                            await Utility.Wait(2);
                            var element = _driver.FindElement(By.ClassName("manage-header__status"));
                            if (element == null) continue;
                            var advStatus = element.Text;
                            element = _driver.FindElement(By.ClassName("manage-header__description"));
                            if (element == null) continue;
                            adv.UpdateDesc = element.Text;
                            adv.StatusCode = GetAdvStatusCodeByStatus(advStatus);
                            var tel = _driver.FindElement(By.ClassName("post-fields-item__value"));
                            if (tel != null)
                                adv.SimcardNumber = tel.Text.FixString().ParseToLong();


                            //بروزرسانی آمار بازدید منتشر شده ها
                            if (adv.StatusCode == StatusCode.Published)
                            {
                                var visitCountEl = _driver.FindElement(By.ClassName("post-stats__summary"));
                                if (visitCountEl != null && visitCountEl.Text.Length > 11)
                                {
                                    int.TryParse(visitCountEl.Text.Substring(11).Trim().FixString(), out var cnt);
                                    adv.VisitCount = cnt;
                                }
                            }

                            adv.LastUpdate = DateTime.Now;

                            await adv.SaveAsync();
                            tryCount = 0;
                            if (isRaisEvent) RaiseEvent();

                        }
                        catch (Exception ex)
                        {
                            if (ex.Source != "WebDriver")
                                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                            await Utility.Wait();
                            tryCount++;
                        }
                    }
                    var t = listNumbers.GroupBy(q => q).Where(q => q.Count() == 1).Select(q => q.Key).ToList();
                    listNumbers.Clear();
                    listNumbers.AddRange(t);

                    return true;
                }
                catch (Exception ex)
                {
                    if (ex.Source != "WebDriver")
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    return false;
                }
            }

        }
        private async Task<bool> UpdateAdvStatus(AdvertiseLogBussines adv, long number = 0)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver);
                if (!adv.URL.Contains("manage")) return false;
                if (_driver.Url != adv.URL)
                    _driver.Navigate().GoToUrl(adv.URL);
                await Utility.Wait();
                var notFound = _driver
                    .FindElements(By.ClassName("title")).Any(q => q.Text == "این راه به جایی نمیرسد!");
                if (notFound)
                {
                    adv.UpdateDesc = "لینک مدیریتی باطل شده";
                    adv.StatusCode = StatusCode.Failed;
                    adv.LastUpdate = DateTime.Now;
                    adv.URL = "---";
                    await adv.SaveAsync();
                    return true;
                }

                await Utility.Wait(1);
                var date = _driver.FindElement(By.ClassName("post-header__publish-time")).Text;
                adv.DateM = GetDateMFromPublishTime(date);
                var advStatus = _driver.FindElement(By.ClassName("manage-header__status")).Text;
                adv.UpdateDesc = _driver.FindElement(By.ClassName("manage-header__description")).Text;
                adv.StatusCode = GetAdvStatusCodeByStatus(advStatus);
                adv.LastUpdate = DateTime.Now;
                if (number != 0)
                    adv.SimcardNumber = number;
                await adv.SaveAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAdvStatus(long number)
        {
            try
            {
                var log = await Login(number, false);
                if (!log) return false;
                _driver = Utility.RefreshDriver(_driver);
                _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                await Utility.Wait(2);
                var allPost = _driver.FindElements(By.ClassName("my-post")).Where(q => q.Text.Contains("منتشر شده"))
                    .ToList();
                var manageLinks = new List<string>();
                foreach (var post in allPost)
                {
                    var url = post.GetAttribute("href");

                    if (url.Contains("manage")) manageLinks.Add(url);
                }

                foreach (var item in manageLinks)
                {
                    var adv = await AdvertiseLogBussines.GetAsync(item);
                    if (adv == null) continue;
                    await UpdateAdvStatus(adv, number);
                }

                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public StatusCode GetAdvStatusCodeByUrl(string url)
        {
            try
            {
                if (!url.Contains("manage")) return StatusCode.Unknown;

                _driver.Navigate().GoToUrl(url);

                if (_driver.FindElements(By.ClassName("manage-header__status")).Count <= 0) return StatusCode.Unknown;

                var status = _driver.FindElement(By.ClassName("manage-header__status")).Text;
                return GetAdvStatusCodeByStatus(status);
            }
            catch
            {
                return StatusCode.Unknown;
            }

        }

        private StatusCode GetAdvStatusCodeByStatus(string advStatus)
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



        public async Task UpdateAdvVisitCount()
        {
            try
            {
                var allAdvertiseLog = await
                    AdvertiseLogBussines.GetAllSpecialAsync(p => p.StatusCode == StatusCode.Published);
                if (allAdvertiseLog.Count > 0)
                {
                    _driver = Utility.RefreshDriver(_driver);
                    foreach (var adv in allAdvertiseLog)
                    {
                        if (adv.URL.Contains("manage"))
                        {
                            _driver.Navigate().GoToUrl(adv.URL);
                            await Utility.Wait();
                            var visitElement = _driver.FindElement(By.ClassName("post-stats__summary"));
                            if (visitElement.Text.Length <= 11) continue;
                            int.TryParse(visitElement.Text.Substring(11).Trim().FixString(), out var cnt);
                            adv.VisitCount = cnt;
                            await adv.SaveAsync();
                            await UpdateAdvStatus(adv);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public async Task<string> GetScreenShot()
        {
            try
            {
                var rootPath = Path.Combine(Application.StartupPath, "ScreenShots");
                var savePath = Path.Combine(rootPath, Guid.NewGuid() + ".jpg");

                if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);
                await Utility.Wait(3);
                _driver = Utility.RefreshDriver(_driver);
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(savePath, ScreenshotImageFormat.Jpeg);

                return savePath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return "";
        }

        private async Task<bool> DeleteAdvFromDivar(AdvertiseLogBussines adv)
        {
            try
            {
                if (!adv.URL.Contains("manage")) return false;
                if (await DeleteAdvFromDivar(adv.URL)) return await UpdateAdvStatus(adv);
                await UpdateAdvStatus(adv);
                return false;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> DeleteAdvFromDivar(string url)
        {
            try
            {
                if (!url.Contains("manage")) return false;
                _driver = Utility.RefreshDriver(_driver);
                if (_driver.Url != url) _driver.Navigate().GoToUrl(url);
                await Utility.Wait();
                //کلیک روی دکمه حذف
                var el = _driver.FindElements(By.ClassName("trash")).Any();
                if (!el) return false;
                _driver.FindElement(By.ClassName("trash")).Click();
                await Utility.Wait();
                _driver.SwitchTo().ActiveElement();
                //انتخاب رادیو باتن دومی-از فروش منصرف شدم
                var options = _driver.FindElements(By.ClassName("manage-delete__option"));
                if (options.Count <= 2) return false;
                options[3].Click();
                await Utility.Wait();
                //کلیک روی دکمه تائید 
                _driver.FindElement(By.ClassName("manage-delete__actions")).FindElement(By.ClassName("button"))?.Click();
                await Utility.Wait();
                if (_driver.Url != url) _driver.Navigate().GoToUrl(url);
                _driver.Navigate().Refresh();
                await Utility.Wait();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task DeleteAllAdvFromDivar(int fromNDayBefore, StatusCode statusCode)
        {
            try
            {
                var date = DateTime.Now.AddDays(-fromNDayBefore);
                var advList = await
                    AdvertiseLogBussines.GetAllSpecialAsync(p => p.DateM < date && p.StatusCode == statusCode);
                advList = advList.OrderByDescending(q => q.DateM).ToList();
                foreach (var adv in advList)
                    await DeleteAdvFromDivar(adv);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        private async Task<bool> UpdateAllRegisteredAdvOfSimCard(long simCardNumber)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver);
                _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                var allPost = _driver.FindElements(By.ClassName("my-post"));
                var manageLinks = new List<string>();
                foreach (var post in allPost)
                {
                    var url = post.GetAttribute("href");

                    if (url.Contains("manage")) manageLinks.Add(url);
                }

                foreach (var url in manageLinks)
                {
                    var getUrl = await AdvertiseLogBussines.GetAsync(url) ?? new AdvertiseLogBussines
                    {
                        URL = url,
                        SimcardNumber = simCardNumber,
                        Category = "-",
                        SubCategory1 = "-",
                        SubCategory2 = "-"
                    };
                    var distance = DateTime.Now - getUrl.LastUpdate;
                    if (distance.Hours < 10) continue;
                    _driver.Navigate().GoToUrl(url);
                    //dateM
                    await Utility.Wait();
                    var publishDateEl = _driver.FindElement(By.ClassName("post-header__publish-time"));
                    if (publishDateEl != null) getUrl.DateM = GetDateMFromPublishTime(publishDateEl.Text);
                    //price and city
                    var postFieldElements = _driver.FindElements(By.ClassName("post-fields-item"));
                    foreach (var fieldElement in postFieldElements)
                    {
                        var title = fieldElement.FindElement(By.ClassName("post-fields-item__title")).Text;
                        var value = fieldElement.FindElement(By.ClassName("post-fields-item__value")).Text;

                        switch (title)
                        {
                            case "قیمت":
                                getUrl.Price1 = value.FixString().Replace("تومان", "").Replace("٫", "").Trim()
                                    .ParseToDecimal();
                                break;
                            case "محل":
                                getUrl.City = value;
                                break;
                        }
                        getUrl.Modified = DateTime.Now;
                    }
                    //status
                    await Utility.Wait();
                    var advStatus = _driver.FindElement(By.ClassName("manage-header__status")).Text;
                    getUrl.StatusCode = GetAdvStatusCodeByStatus(advStatus);

                    //updateDesc - desc
                    var statusDescEl = _driver.FindElement(By.ClassName("manage-header__description"));
                    if (statusDescEl != null) getUrl.UpdateDesc = statusDescEl.Text;

                    //title
                    getUrl.Title = _driver.FindElement(By.ClassName("post-header__title")).Text;

                    //content
                    getUrl.Content = _driver.FindElement(By.ClassName("post-page__description")).Text;

                    //imagesPath
                    if (getUrl.ImagesPathList is null) getUrl.ImagesPathList = new List<string>();
                    var imgElements = _driver.FindElements(By.TagName("img"));
                    foreach (var img in imgElements)
                    {
                        var src = img.GetAttribute("src");
                        if (src.Contains("manage_pictures") && getUrl.ImagesPathList.IndexOf(src) < 0)
                            getUrl.ImagesPathList.Add(img.GetAttribute("src"));
                    }

                    //visit Count
                    var visitCountEl = _driver.FindElement(By.ClassName("post-stats__summary"));
                    if (visitCountEl != null && visitCountEl.Text.Length > 11)
                    {
                        int.TryParse(visitCountEl.Text.Substring(11).Trim().FixString(), out var cnt);
                        getUrl.VisitCount = cnt;
                    }

                    getUrl.LastUpdate = DateTime.Now;
                    await getUrl.SaveAsync();
                }



                return true;
            }
            catch (WebDriverException)
            {
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return true;
            }
        }
        private DateTime GetDateMFromPublishTime(string publishStr)
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


        public async Task GetPost(long number, string Cat1, string Cat2, string Cat3, string city, int count)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver);
                var log = await Login(number, false);
                if (!log) return;
                _driver.Navigate().GoToUrl("https://divar.ir/");
                await Utility.Wait();
                //انتخاب شهر
                _driver.FindElement(By.ClassName("city-selector")).Click();
                await Utility.Wait();
                _driver.FindElements(By.TagName("a")).LastOrDefault(q => q.Text == city)?.Click();
                await Utility.Wait(2);
                var savePathFile = Path.Combine(Application.StartupPath, "TelegramImages");
                if (!Directory.Exists(savePathFile)) Directory.CreateDirectory(savePathFile);
                //testBanner__.jpg حتما در پوشه برنامه موجود شود
                var bannerPath = Path.Combine(Application.StartupPath, "testBanner__.jpg");
                if (!File.Exists(bannerPath)) return;
                await Utility.Wait(3);
                //انتخاب دسته بندی

                if (!string.IsNullOrEmpty(Cat1))
                {
                    await Utility.Wait(1);
                    var p = _driver.FindElements(By.ClassName("category-dropdown__icon")).Any();
                    if (!p) return;
                    _driver.FindElements(By.ClassName("category-dropdown__icon")).FirstOrDefault()?.Click();
                    await Utility.Wait(1);
                    _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == Cat1)
                        ?.Click();
                    if (string.IsNullOrEmpty(Cat2))
                        return;
                    if (string.IsNullOrEmpty(Cat3))
                        _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == Cat2)
                            ?.Click();
                    else
                        _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == Cat3)
                            ?.Click();
                    await Utility.Wait();
                }




                var counter = _driver.FindElements(By.ClassName("col-xs-12")).ToList();
                while (counter.Count <= 0)
                {
                    counter = _driver.FindElements(By.ClassName("col-xs-12")).ToList();
                }
                while (counter.Count <= count)
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    await Utility.Wait();
                    counter = _driver.FindElements(By.ClassName("col-xs-12")).ToList();
                }

                //دریافت آگهی ها
                for (var i = 0; i < count; i++)
                {
                    await Utility.Wait();
                    _driver.FindElements(By.ClassName("col-xs-12"))[i + 1]?.Click();
                    await Utility.Wait(1);
                    var noPic = _driver.FindElements(By.ClassName("no-picture-image")).Any();
                    if (noPic)
                    {
                        _driver.Navigate().Back();
                        await Utility.Wait(1);
                        continue;
                    }
                    var im = _driver.FindElements(By.TagName("img")).ToList();
                    if (im.Count > 0)
                    {
                        //دریافت اولین تصویر آگهی
                        var ul = _driver.FindElements(By.ClassName("slick-dots")).Any();
                        List<IWebElement> li = null;
                        if (ul)
                        {
                            //اگر چندتا عکس داشت، اولی رو بردار
                            li = _driver.FindElement(By.ClassName("slick-dots")).FindElements(By.TagName("li"))
                                .ToList();
                        }
                        else
                        {
                            //اگر یک عکس داشت بردار
                            li = new List<IWebElement>();
                            li.Add(_driver.FindElement(By.ClassName("slick-track")));
                        }

                        await Utility.Wait(1);
                        var src = li.FirstOrDefault()?.FindElement(By.TagName("img"))
                            .GetAttribute("src");
                        var path = Path.Combine(savePathFile, Guid.NewGuid() + ".jpg");
                        var pathsave = Path.Combine(savePathFile, Guid.NewGuid() + ".jpg");
                        var finnalPath = Path.Combine(savePathFile, Guid.NewGuid() + ".jpg");
                        //دانلود تصویر
                        DownloadImage(src, path);
                        //ایجاد تصویر با بنر
                        CreateNewImage(path, bannerPath, pathsave);
                        //دریافت محتویات پست
                        var title = _driver.FindElement(By.ClassName("post-header__title")).Text.FixString();
                        var content = _driver.FindElement(By.ClassName("post-page__description")).Text;
                        //دریافت شماره پست 
                        await Utility.Wait(1);
                        _driver.FindElement(By.ClassName("post-actions__get-contact")).Click();
                        await Utility.Wait();

                        var a = _driver.FindElements(By.ClassName("primary"))
                            .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم");
                        await Utility.Wait(1);
                        if (a != null)
                            _driver.FindElements(By.ClassName("primary"))
                                .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم")?.Click();
                        await Utility.Wait();
                        var pr = _driver.FindElements(By.ClassName("post-fields-item__value"))
                                     .FirstOrDefault(q => q.Text.Contains("تومان") || q.Text.Contains("توافقی"))?.Text
                                     ?.FixString() ?? "توافقی";

                        await Utility.Wait(1);
                        var num = "";
                        var txt = _driver.FindElements(By.ClassName("post-fields-item__value")).FirstOrDefault()?.Text;
                        if (txt == "(پنهان‌شده؛ چت کنید)") txt = "";
                        if (!string.IsNullOrEmpty(txt)) num = txt.FixString();
                        var passage = title + "\r\n" + content + "\r\n" + num;
                        //ایجاد تصویر نهایی
                        WriteTextOnImage(title, num, pr, pathsave, finnalPath);


                        //ارسال به تلگرام
                        var the = new Thread(async () => await SendMessageAsync("@Test2_2211201", passage, finnalPath));
                        the.Start();
                        _driver.Navigate().Back();
                        await Utility.Wait(1);
                    }
                    else
                    {
                        _driver.Navigate().Back();
                        await Utility.Wait(1);
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DownloadImage(string src, string path)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(src, path);
        }

        private void CreateNewImage(string bodyPath, string bannerPath, string savePath)
        {
            try
            {
                var banner = Image.FromFile(bannerPath);
                var body = Image.FromFile(bodyPath);
                var bitmap = new Bitmap(body.Width, body.Height);
                var canvas = Graphics.FromImage(bitmap);
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.DrawImage(body, new Rectangle(0, 0, body.Width, body.Height),
                    new Rectangle(0, 0, body.Width, body.Height), GraphicsUnit.Pixel);
                canvas.DrawImage(banner, 0, body.Height - 75, body.Width, 75);
                canvas.Save();
                bitmap.Save(savePath);
                bitmap.Dispose();
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
            }
        }

        private void WriteTextOnImage(string text, string num, string pric, string filePath, string savePath)
        {
            try
            {
                var firstText = text;
                var number = num;
                var price = pric;
                var link = "arad_enj@yahoo.com";

                var imageFilePath = filePath;
                var bitmap = (Bitmap)Image.FromFile(imageFilePath);


                var firstLocation = new PointF();
                if (firstText.Length < 20)
                    firstLocation = new PointF(bitmap.Width - 200, bitmap.Height - 70);
                else if (firstText.Length >= 20 && firstText.Length < 30)
                    firstLocation = new PointF(bitmap.Width - 300, bitmap.Height - 70);
                else if (firstText.Length >= 30 && firstText.Length < 40)
                    firstLocation = new PointF(bitmap.Width - 415, bitmap.Height - 70);
                else if (firstText.Length > 40)
                    firstLocation = new PointF(bitmap.Width - 435, bitmap.Height - 70);
                var numberLocation = new PointF(number.Length * 20, bitmap.Height - 30);
                var linkLocation = new PointF(bitmap.Width - 150, bitmap.Height - 20);
                var priceLocation = new PointF(firstText.Length, bitmap.Height - 65);

                if (firstText.Length > 40)
                    firstText = "..." + firstText.Remove(38, firstText.Length - 38);

                var graphics = Graphics.FromImage(bitmap);


                var arialFont = new Font("B Mehr", 18);
                var numberFont = new Font("B Yekan", 14);
                var linkFont = new Font("B Yekan", 8);
                var priceFont = new Font("B Morvarid", 18);



                graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
                graphics.DrawString(number, numberFont, Brushes.Red, numberLocation);
                graphics.DrawString(link, linkFont, Brushes.Black, linkLocation);
                graphics.DrawString(price, priceFont, Brushes.White, priceLocation);

                bitmap.Save(savePath);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task SendMessageAsync(string chatId, string passage, string picPath)
        {
            //try
            //{
            //    await BotInitial();
            //    var picFile = new FileStream(picPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            //    await _bot.SendPhotoAsync(chatId, picFile, passage);
            //}
            //catch (Telegram.Bot.Exceptions.BadRequestException)
            //{
            //    await SendMessageAsync(chatId, passage, picPath);
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //}
        }

        private async Task BotInitial()
        {
            try
            {
                //var proxy = new HttpToSocks5Proxy("192.168.1.11", 1080) { ResolveHostnamesLocally = false };
                //_bot = new TelegramBotClient(@"942511223:AAFxQXqFRm10gmo_ls9Ng20WKsk6kLcgPZw", proxy);
                //var fileName = @"C:\Users\NP\Desktop\Sample_EXE\12.txt";
                //using (var sendFileStream = File.Open(fileName, FileMode.Open))
                //{
                //    await _bot.SendDocumentAsync("66025596", new Telegram.Bot.Types.InputFiles.InputOnlineFile(sendFileStream, fileName));
                //}
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        //private TelegramBotClient _bot;
        #endregion

    }
}
