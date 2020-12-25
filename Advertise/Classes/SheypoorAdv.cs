using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Services;
using Settings.Classes;

namespace Advertise.Classes
{
    public class SheypoorAdv
    {
        private IWebDriver _driver;
        public SheypoorAdv() { }
        public async Task StartRegisterAdv(AdvertiseLogBussines adv, long number)
        {
            var counter = 0;

            try
            {
                var res__ = await Utilities.PingHostAsync();
                while (res__.HasError)
                {
                    await Utility.Wait(10);
                    lstMessage.Clear();
                    lstMessage.Add("خطای اتصال به شبکه");
                    Utility.ShowBalloon("لطفا اتصال به شبکه را چک نمایید", lstMessage);
                    counter++;
                }

                var sim = await SimcardBussines.GetAsync(number);
                if (sim.isSheypoorBlocked)
                {
                    lstMessage.Clear();
                    lstMessage.Add($"نوع آگهی: شیپور");
                    lstMessage.Add($"شماره: {number}");
                    lstMessage.Add($"مالک: {sim.Owner}");
                    lstMessage.Add("بدلیل بلاک بودن، موفق به لاگین نشد");
                    Utility.ShowBalloon("عدم انجام لاگین", lstMessage);
                    sim.NextUseSheypoor = DateTime.Now.AddDays(1);
                    await sim.SaveAsync();
                    return;
                }

                var tt = await Utility.CheckToken(number, AdvertiseType.Sheypoor);
                if (tt.HasError)
                {
                    lstMessage.Clear();
                    lstMessage.Add($"نوع آگهی: شیپور");
                    lstMessage.Add($"شماره: {number}");
                    lstMessage.Add($"مالک: {sim.Owner}");
                    lstMessage.Add("بدلیل توکن نداشتن، موفق به لاگین نشد");
                    Utility.ShowBalloon("عدم انجام لاگین", lstMessage);
                    sim.NextUseSheypoor = DateTime.Now.AddDays(1);
                    await sim.SaveAsync();
                    return;
                }
                if (!await Login(number, false)) return;

                await GetChatCount(number);

                var res_ = await RegisterAdv(adv);
                if (res_.HasError) return;

                //تشخیص بلاکی
                _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
                await Utility.Wait(2);
                var el = _driver.FindElements(By.TagName("article")).Any();
                await Utility.Wait();
                if (el) return;
                TelegramSender.GetChatLog_bot().Send($"#گزارش_تشخیص_بلاکی_در_شیپور \r\n" +
                                                     $" سیمکارت {number} " +
                                                     $"\r\n به مالکیت {sim.Owner}" +
                                                     $" \r\n در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} " +
                                                     $"\r\n و ساعت {DateTime.Now.ToLongTimeString()} " +
                                                     $"\r\n از سوی ربات، بلاک شده تشخیص داده شد");
            }
            catch (WebDriverException) { }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task GetChatCount(long number)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                await Utility.Wait();
                var link = _driver.FindElements(By.TagName("span")).Any(q => q.Text == "حساب من");
                if (!link) return;
                await Utility.Wait();
                _driver.FindElements(By.TagName("span")).FirstOrDefault(q => q.Text == "حساب من")?.Click();
                await Utility.Wait();
                var badge = _driver.FindElements(By.ClassName("badge")).Any();
                if (!badge) return;
                await Utility.Wait();
                var newChat = _driver.FindElement(By.ClassName("badge"))?.FindElement(By.TagName("span"))?.Text ?? "";
                if (string.IsNullOrEmpty(newChat)) return;
                var sim = await SimcardBussines.GetAsync(number);
                TelegramSender.GetChatLog_bot()
                    .Send(
                        $"#چت_شیپور \r\nسیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n شماره: {number} \r\n مالک: {sim.Owner} \r\n تعداد چت شیپور: {newChat.FixString()}");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<ReturnedSaveFuncInfo> RegisterAdv(AdvertiseLogBussines adv)
        {
            var ret = new ReturnedSaveFuncInfo();
            //try
            //{
            //    var counter = 0;
            //    adv.AdvType = AdvertiseType.Sheypoor;
            //    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
            //    _driver.Navigate().GoToUrl("https://www.sheypoor.com/listing/new");
            //    await Utility.Wait();

            //    //کلیک کردن روی کتگوری اصلی
            //    _driver.FindElements(By.ClassName("form-select")).FirstOrDefault()?.Click();
            //    await Utility.Wait();

            //    //کلیک روی ساب کتگوری 1
            //    if (string.IsNullOrEmpty(adv.SubCategory1))
            //        adv.SubCategory1 = clsAdvertise.SheypoorSetting?.Category1 ?? "";

            //    if (string.IsNullOrEmpty(adv.SubCategory1))
            //        adv.SubCategory1 = clsAdvertise.SheypoorSetting?.Category1;

            //    _driver.FindElements(By.ClassName("link")).FirstOrDefault(q => q.Text == adv.SubCategory1)?.Click();

            //    await Utility.Wait();

            //    //کلیک روی ساب کتگوری2
            //    if (string.IsNullOrEmpty(adv.SubCategory2))
            //        adv.SubCategory2 = clsAdvertise.SheypoorSetting?.Category2 ?? "";

            //    if (string.IsNullOrEmpty(adv.SubCategory2))
            //        adv.SubCategory2 = clsAdvertise.SheypoorSetting?.Category2;

            //    _driver.FindElements(By.ClassName("link")).FirstOrDefault(q => q.Text == adv.SubCategory2)?.Click();

            //    //درج عکسها
            //    _driver.FindElement(By.ClassName("qq-upload-button-selector")).FindElement(By.TagName("input"))
            //        .SendKeys(adv.ImagesPath);

            //    //درج عنوان آگهی
            //    _driver.FindElement(By.Name("name")).SendKeys("");
            //    _driver.FindElement(By.Name("name")).SendKeys(adv.Title);
            //    //await Wait();
            //    //درج محتوای آگهی
            //    var thread = new Thread(() => Clipboard.SetText(adv.Content.Replace('(', '<').Replace(')', '>')));
            //    thread.SetApartmentState(ApartmentState.STA);
            //    thread.Start();
            //    var t = _driver.FindElement(By.Id("item-form-description"));
            //    t.Click();
            //    await Utility.Wait();
            //    t.SendKeys(OpenQA.Selenium.Keys.Control + "v");
            //    var thread1 = new Thread(Clipboard.Clear);
            //    thread1.SetApartmentState(ApartmentState.STA);
            //    thread1.Start();


            //    //درج قیمت
            //    //var txtPrice = _driver.FindElements(By.Id("item-form-price")).Count;
            //    //if (adv?.Price1 > 0 && txtPrice != 0)
            //    //{
            //    //    line = 30;
            //    //    _driver.FindElement(By.Id("item-form-price"))?.SendKeys("");
            //    //    line = 31;
            //    //    _driver.FindElement(By.Id("item-form-price"))?.SendKeys(adv.Price.ToString());
            //    //}

            //    await Utility.Wait();

            //    //انتخاب شهر
            //    await Utility.Wait();
            //    _driver.FindElements(By.ClassName("form-select")).LastOrDefault()?.Click();
            //    await Utility.Wait();
            //    var a = _driver.FindElements(By.ClassName("mode-district")).Any();
            //    if (a)
            //    {
            //        _driver.FindElement(By.ClassName("mode-district")).FindElement(By.ClassName("link"))?.Click();
            //        await Utility.Wait();
            //        _driver.FindElement(By.ClassName("mode-city")).FindElement(By.ClassName("link"))?.Click();
            //    }

            //    await Utility.Wait();
            //    _driver.FindElements(By.TagName("li"))?.FirstOrDefault(q => q.Text.Contains(adv.State))?.Click();
            //    await Utility.Wait();
            //    var cc = _driver.FindElements(By.TagName("li")).FirstOrDefault(q => q.Text.Contains(adv.City));
            //    cc?.Click();
            //    var cty = await CityBusiness.GetAsync(adv?.City);
            //    var randCity = await CityBusiness.GetNextRandomCityAsync(adv.MasterVisitorGuid, AdvertiseType.Sheypoor);
            //    await Utility.Wait();
            //    var cityGuid = !string.IsNullOrEmpty(adv?.City) ? cty.Guid : randCity.Guid;
            //    var lst = await RegionBusiness.GetAllAsync(cityGuid, AdvertiseType.Sheypoor);
            //    var regionList = lst?.ToList() ?? new List<RegionBusiness>();
            //    if (regionList.Count > 0)
            //    {
            //        var rnd = new Random().Next(0, regionList.Count);
            //        var regName = regionList[rnd].Name;
            //        await Utility.Wait();
            //        _driver.FindElements(By.TagName("li"))?.FirstOrDefault(q => q.Text == regName)
            //            ?.Click();
            //        adv.Region = regName;
            //    }
            //    // await Wait();

            //    //کلیک روی دکمه ثبت آگهی
            //    while (_driver.Url == "https://www.sheypoor.com/listing/new")
            //    {
            //        try
            //        {
            //            _driver.SwitchTo().Alert().Accept();
            //        }
            //        catch { }

            //        counter++;
            //        await Utility.Wait(2);
            //        _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "ثبت آگهی")
            //            ?.Click();
            //        await Utility.Wait();
            //        var box = _driver.FindElements(By.ClassName("box")).Any(q => q.Text.Contains("حساب کاربری"));
            //        if (box) return ret;
            //        if (counter < 60) continue;
            //        await Utility.GetScreenShot(_driver);
            //        adv.URL = "---";
            //        adv.UpdateDesc = @"خطای درج";
            //        adv.StatusCode = StatusCode.InsertError;
            //        adv.AdvType = AdvertiseType.Sheypoor;
            //        adv.IP = await Utility.GetLocalIpAddress();
            //        await adv.SaveAsync();
            //        await Utility.Wait();
            //        counter = 0;
            //        _driver.Navigate().GoToUrl("https://www.sheypoor.com");
            //        return ret;
            //    }
            //    //اگر آگهی با موفقیت ثبت شود لینک مدیریت آگهی ذخیره می شود
            //    await Utility.Wait();
            //    counter = 0;
            //    adv.URL = await MakeUrl(_driver.Url);
            //    adv.UpdateDesc = @"در صف انتشار";
            //    adv.StatusCode = StatusCode.InPublishQueue;
            //    adv.AdvType = AdvertiseType.Sheypoor;
            //    adv.IP = await Utility.GetLocalIpAddress();
            //    await adv.SaveAsync();
            //    await Utility.Wait();
            //    var _30days = _driver.FindElements(By.TagName("strong"))
            //        .Any(q => q.Text.Contains("شما به سقف ۳۰ آگهی در دوره‌ی ۳۰ روزه رسیده‌اید"));
            //    if (_30days)
            //        ret.AddReturnedValue(ReturnedState.Error, "پر شدن تعداد آگهی در ماه");


            //    //await Utility.InsertDataInAdvVisitLog(adv, AdvertiseType.Sheypoor);
            //    if (!_driver.Url.Contains(adv.URL))
            //        _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
            //}
            //catch (ElementClickInterceptedException) { }
            //catch (WebDriverException) { }
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //    ret.AddReturnedValue(ex);
            //}

            return ret;
        }
        public async Task ViewAdv(long simCard, string url)
        {
            try
            {
                if (await Login(simCard, false))
                    _driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public async Task<bool> Login(long simCardNumber, bool isFromSimcard)
        {
            try
            {
                var sim_ = await SimcardBussines.GetAsync(simCardNumber);
                if (isFromSimcard)
                {
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.Sheypoor);

                    //   در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                    if (!simBusiness.HasError)
                    {

                        // token = _driver.Manage().Cookies.GetCookieNamed("ts").ToString().Substring(3, 32);
                        _driver.Navigate().GoToUrl("https://www.sheypoor.com");
                        _driver.Manage().Cookies.DeleteCookieNamed("ts");

                        var newToken = new OpenQA.Selenium.Cookie("ts", simBusiness.value);
                        _driver.Manage().Cookies.AddCookie(newToken);
                        _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
                        var linksElements = _driver.FindElements(By.TagName("a")).ToList();
                        foreach (var link in linksElements)
                        {
                            if (link?.GetAttribute("href") == null || !link.GetAttribute("href").Contains("logout"))
                                continue;
                            _driver.ExecuteJavaScript(@"alert('لاگین انجام شد');");
                            await Utility.Wait();
                            _driver.SwitchTo().Alert().Accept();
                            return true;
                        }
                    }
                    //اگر قبلا توکن نداشته و یا توکن اشتباه باشد وارد صفحه دریافت کد تائید لاگین می شود 
                    _driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 2, 0);
                    _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
                    //var all = _driver.Manage().Cookies.AllCookies;
                    if (_driver.FindElements(By.Id("username")).Count > 0)
                        _driver.FindElement(By.Id("username")).SendKeys(simCardNumber + "\n");

                    //انتظار برای لاگین شدن
                    int repeat = 0;
                    //حدود 120 ثانیه فرصت لاگین دارد
                    while (repeat < 20)
                    {
                        //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
                        var badGateWay = _driver.FindElements(By.TagName("h1"))
                            .Any(q => q.Text == "502 Bad Gateway" || q.Text == "Error 503 Service Unavailable");
                        if (badGateWay) return false;

                        var message = $@"مالک: {sim_.Owner} \r\nشماره: {simCardNumber}  \r\nلطفا لاگین نمائید ";
                        _driver.ExecuteJavaScript($"alert('{message}');");
                        //Wait();

                        await Utility.Wait(5);
                        try
                        {
                            _driver.SwitchTo().Alert().Accept();
                            await Utility.Wait(10);
                            repeat++;
                        }
                        catch
                        {
                            await Utility.Wait(15);
                        }

                        var linksElements = _driver?.FindElements(By.TagName("a")).ToList() ?? null;

                        AdvTokenBussines advToken = null;
                        foreach (var link in linksElements)
                        {
                            if (link?.GetAttribute("href") == null || !link.GetAttribute("href").Contains("logout"))
                                continue;
                            advToken = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.Sheypoor);
                            var token = _driver.Manage().Cookies.GetCookieNamed("ts").ToString().Substring(3, 32);
                            if (advToken != null)
                                advToken.Token = token;
                            else
                                advToken = new AdvTokenBussines()
                                {
                                    Type = AdvertiseType.Sheypoor,
                                    Token = token,
                                    Number = simCardNumber,
                                    Modified = DateTime.Now,
                                    Guid = Guid.NewGuid(),
                                };


                            await advToken.SaveAsync();
                            _driver.ExecuteJavaScript(@"alert('لاگین انجام شد');");
                            await Utility.Wait();
                            _driver.SwitchTo().Alert().Accept();
                            return true;
                        }
                    }

                    var linksElements1 = _driver?.FindElements(By.TagName("a")).FirstOrDefault(q => q.Text == "خروج") ??
                                         null;
                    if (linksElements1 == null)
                    {
                        var msg = $@"فرصت لاگین کردن به اتمام رسید. لطفا دقایقی بعد مجددا امتحان نمایید";
                        _driver.ExecuteJavaScript($"alert('{msg}');");
                        _driver.SwitchTo().Alert().Accept();
                        await Utility.Wait(3);
                    }

                    await Utility.Wait();
                }
                else
                {
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.Sheypoor);

                    //   در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                    if (!simBusiness.HasError)
                    {

                        // token = _driver.Manage().Cookies.GetCookieNamed("ts").ToString().Substring(3, 32);
                        _driver.Navigate().GoToUrl("https://www.sheypoor.com");
                        _driver.Manage().Cookies.DeleteCookieNamed("ts");

                        var newToken = new OpenQA.Selenium.Cookie("ts", simBusiness.value);
                        _driver.Manage().Cookies.AddCookie(newToken);
                        _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
                        var linksElements = _driver.FindElements(By.TagName("a")).ToList();
                        foreach (var link in linksElements)
                        {
                            if (link?.GetAttribute("href") == null || !link.GetAttribute("href").Contains("logout"))
                                continue;
                            _driver.ExecuteJavaScript(@"alert('لاگین انجام شد');");
                            await Utility.Wait();
                            _driver.SwitchTo().Alert().Accept();
                            return true;
                        }
                    }
                    _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");

                    //انتظار برای لاگین شدن
                    int repeat = 0;
                    //حدود 120 ثانیه فرصت لاگین دارد
                    while (repeat < 5)
                    {
                        //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
                        var badGateWay = _driver.FindElements(By.TagName("h1"))
                            .Any(q => q.Text == "502 Bad Gateway" || q.Text == "Error 503 Service Unavailable");
                        if (!badGateWay) return false;

                        var message = $@"مالک: {sim_.Owner} \r\nشماره: {simCardNumber}  \r\nلطفا لاگین نمائید ";
                        _driver.ExecuteJavaScript($"alert('{message}');");
                        //Wait();

                        await Utility.Wait(2);
                        try
                        {
                            _driver.SwitchTo().Alert().Accept();
                            await Utility.Wait(1);
                            repeat++;
                        }
                        catch
                        {
                            await Utility.Wait(15);
                        }

                        var linksElements = _driver?.FindElements(By.TagName("a")).ToList() ?? null;

                        AdvTokenBussines advToken = null;
                        foreach (var link in linksElements)
                        {
                            if (link?.GetAttribute("href") == null || !link.GetAttribute("href").Contains("logout"))
                                continue;
                            var token = _driver.Manage().Cookies.GetCookieNamed("ts").ToString().Substring(3, 32);
                            advToken = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.Sheypoor);
                            if (advToken != null)
                                advToken.Token = token;
                            else
                                advToken = new AdvTokenBussines()
                                {
                                    Type = AdvertiseType.Sheypoor,
                                    Token = token,
                                    Number = simCardNumber,
                                    Modified = DateTime.Now,
                                    Guid = Guid.NewGuid(),
                                };
                        }

                        await advToken?.SaveAsync();
                        _driver.ExecuteJavaScript(@"alert('لاگین انجام شد');");
                        await Utility.Wait();
                        _driver.SwitchTo().Alert().Accept();
                        return true;
                    }
                }

                await Utility.Wait();
                TelegramSender.GetChatLog_bot().Send(
                    $"#نداشتن_توکن \r\n سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n شماره {simCardNumber} به مالکیت {sim_.Owner} توکن ارسال آگهی شیپور داشته، اما منقضی شده و موفق به لاگین  نشد " +
                    $"\r\n به همین سبب توکن شیپور این شماره از دیتابیس حذف خواهد شد " +
                    $"\r\n لطفا نسبت به دریافت مجدد توکن اقدام گردد.");
                var advTokens = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.Sheypoor);
                await advTokens?.RemoveAsync();
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
        public async Task<List<string>> GetAllRegionFromSheypoor(string state, string city)
        {
            var region = new List<string>();
            _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
            string Name = "";
            _driver.Navigate().GoToUrl("https://Sheypoor.com/listing/new");
            try
            {
                _driver.FindElements(By.ClassName("form-select")).LastOrDefault()?.Click();
                await Utility.Wait(1);
                _driver.FindElements(By.TagName("li")).FirstOrDefault(q => q.Text == state)?.Click();
                await Utility.Wait(1);
                _driver.FindElements(By.TagName("li")).FirstOrDefault(q => q.Text == city)?.Click();
                await Utility.Wait(1);
                var regions = _driver.FindElements(By.ClassName("list-items"))?.First();
                foreach (var item in regions.Text)
                {
                    if (item == '\n') continue;
                    if (item != '\r') Name = Name + item;
                    else
                    {
                        region.Add(Name);
                        Name = "";
                    }
                }
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
            }

            return region;
        }
        public static SheypoorAdv GetInstance()
        {
            return _me ?? (_me = new SheypoorAdv());
        }
        private static SheypoorAdv _me;
        public async Task<bool> UpdateAllAdvStatus(int TakeCount, int dayCount = 0)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                List<AdvertiseLogBussines> allAdvertiseLog = null;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                {
                    dayCount = 7;
                    var lastWeek = DateTime.Now.AddDays(-dayCount);
                    var lst = await AdvertiseLogBussines.GetAllSpecialAsync(p =>
                        p.DateM > lastWeek && p.AdvType == AdvertiseType.Sheypoor);
                    allAdvertiseLog = lst.OrderBy(q => q.LastUpdate).ToList();
                    if (allAdvertiseLog.Count <= 0) return true;
                }
                else
                {
                    if (dayCount == 0)
                        dayCount = clsAdvertise.Sheypoor_DayCountForUpdateState;
                    var lastWeek = DateTime.Now.AddDays(-dayCount);
                    var lst = await AdvertiseLogBussines.GetAllSpecialAsync(p =>
                        p.DateM > lastWeek && p.AdvType == AdvertiseType.Sheypoor);
                    allAdvertiseLog = lst.OrderBy(q => q.LastUpdate).ToList();
                    if (allAdvertiseLog.Count <= 0) return true;
                    if (TakeCount != 0)
                    {
                        var dayOfWeek = allAdvertiseLog.First().LastUpdate.DayOfWeek;
                        if (dayOfWeek == DateTime.Now.DayOfWeek) return true;
                        if (allAdvertiseLog.Count > TakeCount)
                            allAdvertiseLog = allAdvertiseLog.Take(TakeCount).ToList();
                    }
                }

                if (allAdvertiseLog == null || allAdvertiseLog.Count <= 0) return false;
                var tryCount = 0;
                long mobile = 0;
                foreach (var adv in allAdvertiseLog)
                {
                    if (tryCount >= 3) continue;
                    try
                    {
                        var sim = await SimcardBussines.GetAsync(adv.SimcardNumber);
                        if (sim.isSheypoorBlocked) continue;
                        if (mobile != adv.SimcardNumber)
                        {
                            var ls = await Utility.CheckToken(adv.SimcardNumber, AdvertiseType.Sheypoor);
                            if (ls.HasError) continue;
                            mobile = adv.SimcardNumber;
                            var log = await Login(adv.SimcardNumber, false);
                            if (!log)
                            {
                                mobile = 0;
                                continue;
                            }
                        }

                        if (adv.URL == "---") continue;
                        var code = adv.URL.Remove(0, 25) ?? null;
                        await Utility.Wait();
                        var el = _driver.FindElements(By.TagName("img")).Any(q =>
                            q.GetAttribute("src").Contains("/img/empty-state/mylistings.png"));
                        if (el)
                        {
                            adv.UpdateDesc = "در انتظار تایید ادمین/ رد شده/ حذف شده";
                            adv.StatusCode = StatusCode.Failed;
                            adv.LastUpdate = DateTime.Now;
                            await adv.SaveAsync();
                            continue;
                        }

                        var element = _driver.FindElements(By.Id("listing-" + code)).Any();
                        await Utility.Wait();
                        if (!element || string.IsNullOrEmpty(code))
                        {
                            adv.UpdateDesc = "در انتظار تایید ادمین/ رد شده/ حذف شده";
                            adv.StatusCode = StatusCode.Failed;
                            adv.LastUpdate = DateTime.Now;
                            await adv.SaveAsync();
                            continue;
                        }

                        _driver.FindElement(By.Id("listing-" + code))?.Click();
                        await Utility.Wait();
                        adv.UpdateDesc = "آگهی منتشر شده و در لیست آگهی های شیپور قرار گرفته است";
                        var counter = _driver.FindElement(By.ClassName("stat-view"))?.Text.FixString() ?? "0";
                        adv.VisitCount = counter.ParseToInt();
                        adv.StatusCode = StatusCode.Published;
                        adv.AdvType = AdvertiseType.Sheypoor;
                        adv.LastUpdate = DateTime.Now;
                        await adv.SaveAsync();
                        tryCount = 0;
                        _driver.Navigate().Back();
                        await Utility.Wait();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Source != "WebDriver")
                            WebErrorLog.ErrorInstence.StartErrorLog(ex);
                        await Utility.Wait();
                        tryCount++;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Source != "WebDriver")
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        private async Task<string> MakeUrl(string url)
        {
            try
            {
                var charUrl = url.ToCharArray();
                var counterUrl = 0;
                var counterCode = 0;
                var newUrl = "";
                var code = "";
                foreach (var item in charUrl)
                {
                    if (counterUrl >= 3)
                        break;
                    newUrl = newUrl + item;
                    if (item == '/')
                        counterUrl++;
                }
                foreach (var item in charUrl)
                {
                    if (item == '/')
                        counterCode++;
                    if (counterCode == 5)
                    {
                        code = code + item;
                    }

                }

                if (code != "")
                    code = code.Remove(0, 1);
                newUrl = newUrl + code;
                return newUrl;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public async Task<List<SheypoorCities>> GetAllCityFromSheypoor()
        {
            var cities = new List<SheypoorCities>();
            var states = await StatesBussines.GetAllAsync();
            _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
            _driver.Navigate().GoToUrl("https://www.sheypoor.com");
            try
            {
                _driver.FindElements(By.ClassName("form-select")).LastOrDefault()?.Click();

                foreach (var stateItem in states)
                {
                    _driver.FindElements(By.TagName("li")).FirstOrDefault(q => q.Text == stateItem.Name)?.Click();


                    var cc = _driver.FindElements(By.TagName("span"))
                        .Where(d => d.GetAttribute("class").Contains("t-city")).ToList();
                    foreach (var item in cc)
                    {
                        if (item.Text == "") continue;
                        var a = new SheypoorCities
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.Text
                        };
                        cities.Add(a);
                    }

                    _driver
                        .FindElements(By.TagName("span"))
                        .FirstOrDefault(d => d.GetAttribute("class").Contains("link") && d.Text.Contains("بازگشت"))?
                        .Click();
                }
            }
            catch { }

            return cities;
        }

        private List<string> lstMessage = new List<string>();
        //public async Task GetCategory()
        //{
        //    try
        //    {
        //        _driver = Utility.RefreshDriver(_driver, AppSetting.isSilent);
        //        _driver.Navigate().GoToUrl("https://www.sheypoor.com/listing/new");
        //        await Utility.Wait();
        //        _driver.FindElements(By.ClassName("form-select")).FirstOrDefault()?.Click();
        //        await Utility.Wait();
        //        var listCat = _driver.FindElements(By.TagName("ul")).Where(q => !string.IsNullOrEmpty(q.Text))
        //            .ToList();
        //        listCat = listCat[3].FindElements(By.TagName("li")).ToList();
        //        var listAll = await AdvCategoryBusiness.GetAllAsync();
        //        listAll = listAll.Where(q => q.Type == AdvertiseType.Sheypoor).ToList();
        //        if (listAll.Count > 0)
        //            await AdvCategoryBusiness.RemoveAllAsync(listAll);
        //        foreach (var item in listCat)
        //        {
        //            var a = new AdvCategoryBusiness()
        //            {
        //                Guid = Guid.NewGuid(),
        //                Type = AdvertiseType.Sheypoor,
        //                Name = item.Text.Trim().FixString(),
        //                Modified = DateTime.Now,
        //                ParentGuid = Guid.Empty
        //            };
        //            await a.SaveAsync();
        //        }
        //        listAll = await AdvCategoryBusiness.GetAllAsync();
        //        listAll = listAll.Where(q => q.Type == AdvertiseType.Sheypoor).ToList();
        //        if (listAll.Count <= 0) return;
        //        foreach (var element in listAll)
        //        {
        //            _driver.FindElements(By.ClassName("link")).FirstOrDefault(q => q.Text == element.Name)?.Click();
        //            await Utility.Wait();
        //            var listCat2 = _driver.FindElements(By.TagName("ul")).Where(q => !string.IsNullOrEmpty(q.Text))
        //                .ToList();
        //            listCat2 = listCat2[3].FindElements(By.TagName("li")).ToList();
        //            foreach (var item in listCat2)
        //            {
        //                var a = new AdvCategoryBusiness()
        //                {
        //                    Guid = Guid.NewGuid(),
        //                    Type = AdvertiseType.Sheypoor,
        //                    Name = item.Text.Trim().FixString(),
        //                    Modified = DateTime.Now,
        //                    ParentGuid = element.Guid
        //                };
        //                await a.SaveAsync();
        //            }


        //            var newList = await AdvCategoryBusiness.GetAllAsync(element.Guid, AdvertiseType.Sheypoor);
        //            if (newList.Count <= 0) continue;
        //            _driver.FindElements(By.TagName("span")).FirstOrDefault(q => q.Text.Contains("بازگشت"))?.Click();
        //            await Utility.Wait();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorLogInstance.StartLog(ex);
        //    }
        //}
        public async Task DeleteAllAdvFromSheypoor(int count, long number)
        {
            try
            {
                var log = await Login(number, false);
                if (!log) return;
                _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
                var allPost = _driver.FindElements(By.ClassName("serp-item"));
                var manageLinks = new List<string>();
                foreach (var post in allPost)
                {
                    var url = post.GetAttribute("data-href");
                    if (!url.Contains("sheypoor.com")) continue;
                    manageLinks.Add(url);
                }

                foreach (var item in manageLinks.Take(count))
                {
                    var url = item.Remove(25, 19);
                    var adv = await AdvertiseLogBussines.GetAsync(url);
                    var i = _driver.FindElements(By.ClassName("serp-item"))
                        .FirstOrDefault(q => q.GetAttribute("data-href") == item)
                        ?.FindElement(By.ClassName("icon-trash"));
                    await Utility.Wait();
                    i?.Click();
                    await Utility.Wait();
                    var yes = _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بله");
                    yes?.Click();
                    if (adv == null) continue;
                    adv.AdvType = AdvertiseType.Sheypoor;
                    adv.UpdateDesc = "حذف شده توسط ربات";
                    adv.StatusCode = StatusCode.Deleted;
                    adv.LastUpdate = DateTime.Now;
                    await adv.SaveAsync();
                }
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
                var log = await Login(simCardNumber, false);
                if (!log) return false;
                _driver.Navigate().GoToUrl("https://www.sheypoor.com/session/myListings");
                var allPost = _driver.FindElements(By.ClassName("serp-item"));
                var manageLinks = new List<string>();
                if (allPost == null || allPost.Count <= 0) return true;
                foreach (var post in allPost)
                {
                    var url = post.GetAttribute("data-href");
                    if (!url.Contains("sheypoor.com")) continue;
                    manageLinks.Add(url);
                }
                foreach (var url in manageLinks)
                {
                    var getUrl = await AdvertiseLogBussines.GetAsync(url);
                    if (!string.IsNullOrEmpty(getUrl?.URL)) continue;
                    _driver.Navigate().GoToUrl(url);

                    if (getUrl is null) //اگر آگهی قبلا در دیتابیس ثبت نشده باشد
                    {
                        getUrl = new AdvertiseLogBussines()
                        {
                            URL = url,
                            SimcardNumber = simCardNumber,
                            Category = "برای کسب و کار",
                            SubCategory1 = "-",
                            SubCategory2 = "-",
                            AdvType = AdvertiseType.Sheypoor
                        };
                        //dateM
                        await Utility.Wait();
                        var publishDateEl = _driver.FindElement(By.TagName("time"));
                        if (publishDateEl != null) getUrl.DateM = Utility.GetDateMFromPublishTime(publishDateEl.Text);
                        //price and city
                        var postFieldElements = _driver.FindElement(By.Id("breadcrumbs")).FindElements(By.TagName("a"))
                            .ToList();
                        var fieldElements = postFieldElements.ToList();
                        if (!fieldElements.Any()) continue;
                        for (var i = 0; i < fieldElements.Count(); i++)
                        {
                            if (fieldElements[i].Text == "") continue;
                            // if (i == 1) getUrl.State = fieldElements[i].Text.FixString();
                            if (i == 2) getUrl.City = fieldElements[i].Text.FixString();
                            if (i == 3 && fieldElements.Count() == 5) getUrl.SubCategory1 = fieldElements[i].Text.FixString();
                            if (i == 4 && fieldElements.Count() == 5) getUrl.SubCategory2 = fieldElements[i].Text.FixString();
                            if (i == 3 && fieldElements.Count() == 6) getUrl.Region = fieldElements[i].Text.FixString();
                            if (i == 4 && fieldElements.Count() == 6) getUrl.SubCategory1 = fieldElements[i].Text.FixString();
                            if (i == 5 && fieldElements.Count() == 6) getUrl.SubCategory2 = fieldElements[i].Text.FixString();
                        }

                        var price = _driver.FindElement(By.ClassName("item-price"));
                        if (price == null) continue;
                        //getUrl.Price = price.Text.FixString().Replace("تومان", "").ParseToDecimal();
                    }
                    getUrl.Modified = DateTime.Now;

                    //status
                    await Utility.Wait();
                    getUrl.StatusCode = StatusCode.Published;
                    //updateDesc - desc
                    getUrl.UpdateDesc = "آگهی منتشر شده و در لیست آگهی های شیپور قرار گرفته است";

                    //title
                    getUrl.Title = _driver.FindElement(By.ClassName("content")).FindElement(By.TagName("h2")).Text.FixString();

                    //visit Count
                    var visitCountEl = _driver.FindElement(By.ClassName("stat-view"));
                    getUrl.VisitCount = visitCountEl.Text.FixString().ParseToInt();

                    //content
                    var ul = getUrl.URL.Remove(25, 19);
                    _driver.Navigate().GoToUrl(ul);
                    await Utility.Wait();
                    getUrl.Content = _driver.FindElement(By.ClassName("description")).Text.FixString();
                    getUrl.URL = ul;
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
    }
}
