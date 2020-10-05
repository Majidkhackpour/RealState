using System;
using System.Collections.Generic;
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
    public class DivarAdv
    {
        #region Fields
        private IWebDriver _driver;
        public static event Action SubmitEvent;
        public static event Action SubmitEvent_Update;
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
        private DivarAdv() { }
        public static DivarAdv GetInstance()
        {
            return _me ?? (_me = new DivarAdv());
        }
        #region MyRegion
        private List<string> lstMessage = new List<string>();
        public async Task StartRegisterAdv(bool isUpdateNextUse, List<long> numbers = null, int count = 1, bool isRaiseEvent = true)
        {
            try
            {
                var res = await Utilities.PingHostAsync();
                if (res.HasError)
                {

                    lstMessage.Clear();
                    lstMessage.Add("خطای اتصال به شبکه");
                    Utility.ShowBalloon("لطفا اتصال به شبکه را چک نمایید", lstMessage);
                    return;
                }

                foreach (var number in numbers)
                {
                    var sim = await SimcardBussines.GetAsync(number);
                    var tt = await Utility.CheckToken(number, AdvertiseType.Divar);
                    if (tt.HasError)
                    {
                        lstMessage.Clear();
                        lstMessage.Add("نوع آگهی: دیوار");
                        lstMessage.Add($"شماره: {number}");
                        lstMessage.Add("#نداشتن_توکن");
                        lstMessage.Add($"مالک: {sim.Owner}");
                        lstMessage.Add("بدلیل توکن نداشتن، موفق به لاگین نشد");
                        Utility.ShowBalloon("عدم انجام لاگین", lstMessage);
                        sim.NextUseDivar = DateTime.Now.AddDays(1);
                        await sim.SaveAsync();
                        var msg = $"سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n";
                        foreach (var items in lstMessage) msg += items + "\r\n";
                        TelegramSender.GetChatLog_bot().Send(msg);
                        return;
                    }

                    if (!await Login(number, false) /*|| !await UpdateAllRegisteredAdvOfSimCard(number)*/) continue;
                    await GetEditNeededAdv(number);
                    await Utility.Wait(1);
                    // await RemoveWaitForPayment();
                    for (var i = 0; i < count; i++)
                    {
                        var res_ = await Utility.GetNextAdv(AdvertiseType.Divar, number);
                        if (res_.HasError) continue;
                        if (res_.value == null) continue;
                        await RegisterAdv(res_.value, isRaiseEvent);
                        await Utility.Wait(1);
                        sim.Modified = DateTime.Now;
                        var full = _driver.FindElements(By.ClassName("header"))
                            .Any(q => q.Text == "لطفا به موارد زیر توجه کنید:");
                        if (full) return;
                        if (isUpdateNextUse) sim.NextUseDivar = DateTime.Now.AddHours(2);
                        await sim.SaveAsync();
                    }
                }
            }
            catch (WebException) { }
            catch (Exception ex) { WebErrorLog.ErrorInstence.StartErrorLog(ex); }
        }
        public async Task<bool> Login(long simCardNumber, bool isFromSimForm)
        {
            try
            {
                if (isFromSimForm)
                {
                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                    if (!_driver.Url.Contains("divar.ir"))
                        _driver.Navigate().GoToUrl("https://divar.ir");

                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.Divar);
                    var listLinkItems = _driver.FindElements(By.TagName("a"));
                    var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");
                    //اگر کاربر لاگین شده فعلی همان کاربر مورد نظر است نیازی به لاگین نیست 
                    if (isLogined && !simBusiness.HasError)
                    {
                        var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == simBusiness.value)
                            return true;
                    }

                    //اگر کاربرلاگین شده کاربر مد نظر ما نیست از آن کاربری خارج می شود
                    if (isLogined)
                    {
                        _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                        _driver.Manage().Cookies.DeleteCookieNamed("token");
                    }

                    //در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                    if (!simBusiness.HasError)
                    {
                        var token = new OpenQA.Selenium.Cookie("token", simBusiness.value);
                        _driver.Manage().Cookies.AddCookie(token);
                        _driver.Navigate().Refresh();
                    }
                    //اگر قبلا توکن نداشته وارد صفحه دریافت کد تائید لاگین می شود 
                    else
                    {
                        _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                        //کلیک روی دکمه ورود و ثبت نام
                        await Utility.Wait();
                        _driver.FindElement(By.ClassName("login-message__login-btn")).Click();
                        await Utility.Wait();
                        var currentWindow = _driver.CurrentWindowHandle;
                        _driver.SwitchTo().Window(currentWindow);
                        if (_driver.FindElements(By.Name("mobile")).Count > 0)
                            _driver.FindElement(By.Name("mobile")).SendKeys("0" + simCardNumber);
                    }

                    //انتظار برای لاگین شدن
                    var repeat = 0;
                    //حدود 120 ثانیه فرصت لاگین دارد
                    while (repeat < 20)
                    {
                        //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
                        listLinkItems = _driver.FindElements(By.TagName("a"));
                        if (listLinkItems.Count < 5) return false;
                        var isLogin = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");
                        var advToken = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.Divar);

                        if (isLogin)
                        {
                            var token = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                            if (advToken != null)
                                advToken.Token = token;
                            else
                                advToken = new AdvTokenBussines()
                                {
                                    Type = AdvertiseType.Divar,
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
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                    if (!_driver.Url.Contains("divar.ir"))
                        _driver.Navigate().GoToUrl("https://divar.ir");

                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.Divar);
                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    if (simBusiness.HasError)
                    {
                        TelegramSender.GetChatLog_bot()
                            .Send(
                                $"#نداشتن_توکن \r\n سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n شماره: {simCardNumber} \r\n مالک: {sim.Owner} \r\n وضعیت توکن دیوار: حذف شده \r\nلطفا مجددا توکن گیری شود");
                        return false;
                    }

                    var listLinkItems = _driver.FindElements(By.TagName("a"));
                    var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");
                    //اگر کاربر لاگین شده فعلی همان کاربر مورد نظر است نیازی به لاگین نیست 
                    if (isLogined && !simBusiness.HasError)
                    {
                        var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == simBusiness.value)
                            return true;
                    }

                    //اگر کاربرلاگین شده کاربر مد نظر ما نیست از آن کاربری خارج می شود
                    if (isLogined)
                    {
                        _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                        _driver.Manage().Cookies.DeleteCookieNamed("token");
                    }

                    //در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                    if (!simBusiness.HasError)
                    {
                        var token = new OpenQA.Selenium.Cookie("token", simBusiness.value);
                        _driver.Manage().Cookies.AddCookie(token);
                        _driver.Navigate().Refresh();
                    }
                    //اگر قبلا توکن نداشته وارد صفحه دریافت کد تائید لاگین می شود 
                    else
                    {
                        _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                        //کلیک روی دکمه ورود و ثبت نام
                        await Utility.Wait();
                        _driver.FindElement(By.ClassName("login-message__login-btn")).Click();
                        await Utility.Wait();
                        var currentWindow = _driver.CurrentWindowHandle;
                        _driver.SwitchTo().Window(currentWindow);
                        if (_driver.FindElements(By.Name("mobile")).Count > 0)
                            _driver.FindElement(By.Name("mobile")).SendKeys("0" + simCardNumber);
                    }

                    //انتظار برای لاگین شدن
                    var repeat = 0;
                    //حدود 120 ثانیه فرصت لاگین دارد
                    while (repeat < 3)
                    {
                        //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
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
                                if (isLogin) return true;
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

                    var advToken = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.Divar);
                    await advToken?.RemoveAsync();
                    TelegramSender.GetChatLog_bot().Send(
                        $"#نداشتن_توکن \r\n سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n شماره {simCardNumber} به مالکیت {sim.Owner} توکن آگهی دیوار داشته، اما منقضی شده و موفق به لاگین آگهی نشد " +
                        $"\r\n به همین سبب توکن آگهی دیوار این شماره از دیتابیس حذف خواهد شد " +
                        $"\r\n لطفا نسبت به دریافت مجدد توکن اقدام گردد.");
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
        public async Task<bool> LoginChat(long simCardNumber, bool isFromSimcard)
        {
            try
            {
                if (isFromSimcard)
                {
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                    if (!_driver.Url.Contains("https://chat.divar.ir/"))
                        _driver.Navigate().GoToUrl("https://chat.divar.ir/");

                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.DivarChat);

                    var listLinkItems = _driver.FindElements(By.TagName("a"));
                    var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                    //اگر کاربر لاگین شده فعلی همان کاربر مورد نظر است نیازی به لاگین نیست 
                    if (isLogined && !simBusiness.HasError)
                    {
                        var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        await Utility.Wait(1);
                        var aouth = _driver.FindElements(By.ClassName("auth__body__text")).Any();
                        if (aouth)
                            _driver.FindElement(By.TagName("input")).SendKeys(sim.Owner + '\n');

                        if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == simBusiness.value)
                            return true;
                    }

                    //اگر کاربرلاگین شده کاربر مد نظر ما نیست از آن کاربری خارج می شود
                    if (isLogined)
                    {
                        _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                        _driver.Manage().Cookies.DeleteCookieNamed("token");
                    }

                    //در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                    if (!simBusiness.HasError)
                    {
                        var token = new OpenQA.Selenium.Cookie("token", simBusiness.value);
                        _driver.Manage().Cookies.AddCookie(token);
                        await Utility.Wait();
                        _driver.Navigate().Refresh();
                        await Utility.Wait();
                    }
                    //اگر قبلا توکن نداشته وارد صفحه دریافت کد تائید لاگین می شود 
                    else
                    {
                        _driver.Navigate().GoToUrl("https://chat.divar.ir/");
                        //کلیک روی دکمه ورود و ثبت نام
                        await Utility.Wait();
                        var currentWindow = _driver.CurrentWindowHandle;
                        _driver.SwitchTo().Window(currentWindow);
                        await Utility.Wait(1);
                        if (_driver.FindElements(By.TagName("input")).Count > 0)
                            _driver.FindElements(By.TagName("input")).FirstOrDefault()
                                ?.SendKeys("0" + simCardNumber + "\n");
                    }

                    var invalid = _driver.FindElements(By.TagName("p")).Any(q => q.Text == "invalid_token");
                    if (invalid)
                    {
                        _driver.Navigate().GoToUrl("https://chat.divar.ir/");
                        //کلیک روی دکمه ورود و ثبت نام
                        await Utility.Wait();
                        var currentWindow = _driver.CurrentWindowHandle;
                        _driver.SwitchTo().Window(currentWindow);
                        if (_driver.FindElements(By.TagName("input")).Count > 0)
                            _driver.FindElements(By.TagName("input")).FirstOrDefault()
                                ?.SendKeys("0" + simCardNumber + "\n");
                    }

                    //انتظار برای لاگین شدن
                    var repeat = 0;
                    //حدود 120 ثانیه فرصت لاگین دارد
                    while (repeat < 20)
                    {
                        //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
                        listLinkItems = _driver.FindElements(By.TagName("a"));
                        if (listLinkItems.Count < 5) return false;

                        var isLogin = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");
                        var advToken = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.DivarChat);
                        var token = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        if (isLogin)
                        {

                            _driver.ExecuteJavaScript(@"alert('لاگین انجام شد');");
                            await Utility.Wait();
                            _driver.SwitchTo().Alert().Accept();
                            if (advToken != null)
                                advToken.Token = token;
                            else
                                advToken = new AdvTokenBussines()
                                {
                                    Type = AdvertiseType.DivarChat,
                                    Token = token,
                                    Number = simCardNumber,
                                    Modified = DateTime.Now,
                                    Guid = Guid.NewGuid(),
                                };


                            await advToken.SaveAsync();


                            await Utility.Wait(1);

                            var aouth = _driver.FindElements(By.ClassName("auth__body__text")).Any();
                            if (aouth)
                                _driver.FindElement(By.TagName("input")).SendKeys(sim.Owner + '\n');

                            await Utility.Wait();


                            return true;
                        }
                        else
                        {
                            var message = $@"مالک: {sim.Owner} \r\nشماره: {simCardNumber}  \r\nلطفا لاگین نمائید ";
                            _driver.ExecuteJavaScript($"alert('{message}');");
                            await Utility.Wait(2);
                            try
                            {
                                _driver.SwitchTo().Alert().Accept();
                                await Utility.Wait(5);
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
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                    if (!_driver.Url.Contains("https://chat.divar.ir/"))
                        _driver.Navigate().GoToUrl("https://chat.divar.ir/");

                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.DivarChat);
                    if (simBusiness.HasError)
                    {
                        TelegramSender.GetChatLog_bot()
                            .Send(
                                $"#نداشتن_توکن \r\n سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n شماره: {simCardNumber} \r\n مالک: {sim.Owner} \r\n وضعیت توکن چت دیوار: حذف شده \r\n لطفا مجددا توکن گیری شود");
                        return false;
                    }

                    var listLinkItems = _driver.FindElements(By.TagName("a"));
                    var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                    //اگر کاربر لاگین شده فعلی همان کاربر مورد نظر است نیازی به لاگین نیست 
                    if (isLogined && !simBusiness.HasError)
                    {
                        var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                        await Utility.Wait(1);
                        var aouth = _driver.FindElements(By.ClassName("auth__body__text")).Any();
                        if (aouth)
                            _driver.FindElement(By.TagName("input")).SendKeys(sim.Owner + '\n');

                        if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == simBusiness.value)
                            return true;
                    }

                    //اگر کاربرلاگین شده کاربر مد نظر ما نیست از آن کاربری خارج می شود
                    if (isLogined)
                    {
                        _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                        _driver.Manage().Cookies.DeleteCookieNamed("token");
                    }

                    //در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                    if (!simBusiness.HasError)
                    {
                        var token = new OpenQA.Selenium.Cookie("token", simBusiness.value);
                        _driver.Manage().Cookies.AddCookie(token);
                        await Utility.Wait();
                        _driver.Navigate().Refresh();
                        await Utility.Wait();
                    }
                    //انتظار برای لاگین شدن
                    var repeat = 0;
                    //حدود 120 ثانیه فرصت لاگین دارد
                    while (repeat < 3)
                    {
                        //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
                        listLinkItems = _driver.FindElements(By.TagName("a"));
                        if (listLinkItems.Count < 5) return false;

                        var isLogin = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");

                        if (isLogin)
                        {
                            await Utility.Wait(1);

                            var aouth = _driver.FindElements(By.ClassName("auth__body__text")).Any();
                            if (aouth)
                                _driver.FindElement(By.TagName("input")).SendKeys(sim.Owner + '\n');

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

                    TelegramSender.GetChatLog_bot().Send(
                        $"#نداشتن_توکن \r\n سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n شماره {simCardNumber} به مالکیت {sim.Owner} توکن چت دیوار داشته، اما منقضی شده و موفق به لاگین چت نشد " +
                        $"\r\n به همین سبب توکن چت دیوار این شماره از دیتابیس حذف خواهد شد " +
                        $"\r\n لطفا نسبت به دریافت مجدد توکن اقدام گردد.");

                    var adToken = await AdvTokenBussines.GetTokenAsync(simCardNumber, AdvertiseType.DivarChat);
                    await adToken?.RemoveAsync();
                }

                return false;
            }
            catch (WebException)
            {
                return false;
            }
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
            //    adv.AdvType = AdvertiseType.Divar;
            //    line = 2;
            //    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
            //    line = 3;
            //    _driver.Navigate().GoToUrl("https://divar.ir/new");
            //    line = 4;
            //    await Utility.Wait(1);
            //    //کلیک کردن روی کتگوری اصلی
            //    if (string.IsNullOrEmpty(adv.Category))
            //    {
            //        line = 5;
            //        adv.Category = clsAdvertise.DivarSetting?.Category1 ?? "";
            //    }

            //    line = 6;
            //    _driver.FindElements(By.ClassName("expanded-category-selector__item"))
            //        .FirstOrDefault(p => p.Text == adv.Category)?.Click();
            //    line = 7;
            //    await Utility.Wait(2);
            //    //کلیک روی ساب کتگوری 1
            //    if (string.IsNullOrEmpty(adv.SubCategory1))
            //    {
            //        line = 8;
            //        adv.SubCategory1 = clsAdvertise.DivarSetting?.Category2 ?? "";
            //    }

            //    line = 9;
            //    _driver.FindElements(By.ClassName("expanded-category-selector__item"))
            //        .FirstOrDefault(p => p.Text == adv.SubCategory1)?.Click();
            //    line = 10;
            //    await Utility.Wait(2);
            //    //کلیک روی ساب کتگوری2
            //    if (string.IsNullOrEmpty(adv.SubCategory2))
            //    {
            //        line = 11;
            //        adv.SubCategory2 = clsAdvertise.DivarSetting?.Category3 ?? "";
            //    }

            //    line = 12;
            //    _driver.FindElements(By.ClassName("expanded-category-selector__item"))
            //        .FirstOrDefault(p => p.Text == adv.SubCategory2)?.Click();
            //    line = 13;
            //    await Utility.Wait(2);
            //    line = 14;
            //    var load = _driver.FindElements(By.ClassName("location-selector__city")).Any();

            //    //درج عکسها
            //    line = 15;
            //    _driver.FindElement(By.ClassName("image-uploader__item")).FindElement(By.TagName("input"))
            //        .SendKeys(adv.ImagesPath);
            //    await Utility.Wait();
            //    line = 16;
            //    _driver.FindElement(By.ClassName("kt-select__field--placeholder-shown"))?.Click();

            //    await Utility.Wait();

            //    _driver.FindElement(By.ClassName("kt-select__search-field"))?.SendKeys(adv.City + "\n");

            //    line = 17;
            //    var el = _driver.FindElements(By.ClassName("text-field")).Any(q => q.Text == "محدودهٔ آگهی");
            //    await Utility.Wait();
            //    if (el)
            //    {
            //        line = 18;
            //        var cty = await CitiesBussines.GetAsync(adv.City);
            //        line = 19;
            //        await Utility.Wait(1);
            //        line = 20;
            //        var cityGuid = cty.Guid;
            //        line = 21;
            //        var lst = await RegionsBussines.GetAllAsync(cityGuid, AdvertiseType.Divar);
            //        line = 22;
            //        var regionList = lst.ToList() ?? new List<RegionsBussines>();
            //        line = 23;
            //        if (regionList.Count > 0)
            //        {
            //            line = 24;
            //            var rnd = new Random().Next(0, regionList.Count);
            //            line = 25;
            //            var regName = regionList[rnd].Name;
            //            await Utility.Wait(2);

            //            line = 26;
            //            _driver.FindElements(By.ClassName("kt-select__field--placeholder-shown"))?[0].Click();
            //            await Utility.Wait(2);

            //            _driver.FindElements(By.ClassName("kt-select__search-field"))?[1]?.SendKeys(regName + "\n");
            //            line = 27;
            //            adv.Region = regName;
            //        }
            //    }

            //    await Utility.Wait();
            //    //بررسی وضعیت
            //    line = 28;
            //    var status = _driver.FindElements(By.ClassName("text-field")).Any(q => q.Text == "وضعیت");
            //    if (status)
            //    {
            //        await Utility.Wait();
            //        line = 29;
            //        _driver.FindElement(By.Id("root_status"))?.Click();
            //        await Utility.Wait();
            //        line = 30;
            //        _driver.FindElements(By.ClassName("kt-select__option")).FirstOrDefault(q => q.Text == "نو")?.Click();
            //    }


            //    //درج قیمت
            //    line = 31;
            //    var pr = _driver.FindElements(By.CssSelector("input[type=tel]")).Any();
            //    await Utility.Wait();
            //    if (pr)
            //    {
            //        line = 32;
            //        _driver.FindElement(By.CssSelector("input[type=tel]")).SendKeys(adv.Price.ToString());
            //    }
            //    await Utility.Wait();
            //    //درج عنوان آگهی
            //    line = 33;
            //    _driver.FindElements(By.CssSelector("input[type=text]")).Last().SendKeys(adv.Title);
            //    await Utility.Wait();
            //    //درج محتوای آگهی
            //    line = 34;
            //    var thread = new Thread(() => Clipboard.SetText(adv.Content));
            //    line = 35;
            //    thread.SetApartmentState(ApartmentState.STA);
            //    line = 36;
            //    thread.Start();
            //    line = 37;
            //    var t = _driver.FindElement(By.TagName("textarea"));
            //    line = 38;
            //    t.Click();
            //    await Utility.Wait();
            //    line = 39;
            //    t.SendKeys(OpenQA.Selenium.Keys.Control + "v");
            //    line = 40;
            //    var thread1 = new Thread(Clipboard.Clear);
            //    line = 41;
            //    thread1.SetApartmentState(ApartmentState.STA);
            //    line = 42;
            //    thread1.Start();
            //    await Utility.Wait();

            //    await Utility.Wait();
            //    line = 43;
            //    var loadImg = _driver.FindElements(By.ClassName("kt-progress-bar__inner")).ToList();
            //    line = 44;
            //    while (loadImg.Count > 0)
            //    {
            //        await Utility.Wait(2);
            //        line = 45;
            //        loadImg = _driver.FindElements(By.ClassName("kt-progress-bar__inner")).ToList();
            //    }

            //    //var listtttt = _driver.FindElements(By.ClassName("kt-select__search-field")).ToList();
            //    //line = 46;
            //    //if (listtttt.Count > 0 &&
            //    //    (string.IsNullOrEmpty(adv.Region) || adv.Region == "-"))
            //    //{
            //    //    _driver.FindElements(By.ClassName("kt-select__field--placeholder-shown"))?[0].Click();
            //    //    await Utility.Wait();

            //    //    line = 27;
            //    //    adv.Region = adv.Region;
            //    //}

            //    line = 48;
            //    var but = _driver.FindElements(By.TagName("button")).Any(q => q.Text.Contains("ارسال آگهی"));
            //    if (but)
            //    //کلیک روی دکمه ثبت آگهی
            //    {
            //        line = 49;
            //        _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text.Contains("ارسال آگهی"))
            //            ?.Click();
            //    }






            //    await Utility.Wait(2);
            //    line = 50;
            //    adv.URL = _driver.Url;
            //    line = 51;
            //    var element = _driver.FindElement(By.ClassName("manage-header__status"));
            //    line = 400;
            //    var advStatus = element.Text;
            //    line = 420;
            //    element = _driver.FindElement(By.ClassName("manage-header__description"));
            //    line = 440;
            //    adv.UpdateDesc = element.Text;
            //    line = 450;
            //    adv.StatusCode = Utility.GetAdvStatusCodeByStatus(advStatus);
            //    line = 55;
            //    if (_driver.Url != adv.URL)
            //    {
            //        line = 56;
            //        _driver.Navigate().GoToUrl(adv.URL);
            //    }

            //    await Utility.Wait();
            //    line = 57;
            //    if (_driver.Url.Contains("manage")) await adv.SaveAsync();

            //    await Utility.Wait(1);
            //    line = 58;
            //    if (isRaiseEvent) RaiseEvent();
            //}
            //catch (ElementClickInterceptedException) { }
            //catch (WebDriverException) { }
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorLogInstance.StartLog(ex, $"Error in Line {line}");
            //    ret.AddReturnedValue(ex);
            //}
            //finally { monitor.Dispose(); }
        }
        public async Task<List<DivarRegion>> GetAllRegionFromDivar(List<DivarCities> City)
        {
            var region = new List<DivarRegion>();
            _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
            _driver.Navigate().GoToUrl("https://divar.ir/new");
            //کلیک کردن روی کتگوری اصلی
            _driver.FindElements(By.ClassName("expanded-category-selector__item"))
                .FirstOrDefault(p => p.Text.Contains("کسب"))?.Click();
            await Utility.Wait();
            //کلیک روی ساب کتگوری 1
            _driver.FindElements(By.ClassName("expanded-category-selector__item"))
                .FirstOrDefault(p => p.Text.Contains("تجهیزات"))?.Click();
            await Utility.Wait();
            //کلیک روی ساب کتگوری2
            _driver.FindElements(By.ClassName("expanded-category-selector__item"))
                .FirstOrDefault(p => p.Text.Contains("فروشگاه"))?.Click();

            await Utility.Wait(2);
            try
            {
                foreach (var item in City)
                {
                    await Utility.Wait(2);

                    var t = _driver.FindElements(By.ClassName("kt-select__field"))[0];

                    await Utility.Wait();
                    t?.Click();
                    var t2 = _driver.FindElement(By.ClassName("kt-select__search-field"));
                    t2?.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    t2?.SendKeys(OpenQA.Selenium.Keys.Backspace);
                    t?.Click();
                    await Utility.Wait();
                    t?.Click();
                    _driver.FindElement(By.ClassName("kt-select__search-field"))
                        .SendKeys(item.Name + "\n");
                    await Utility.Wait(2);
                    _driver.FindElements(By.ClassName("kt-select__field"))?[1].Click();
                    await Utility.Wait(1);
                    var allEl = _driver.FindElements(By.ClassName("kt-select__option")).Where(q => q.Text != "").ToList();
                    if (allEl.Count <= 0) continue;
                    foreach (var temp in allEl)
                    {
                        if (string.IsNullOrEmpty(temp.Text)) continue;
                        var clsRegionBusiness = new DivarRegion()
                        {
                            Guid = Guid.NewGuid(),
                            CityGuid = item.Guid,
                            Modified = DateTime.Now,
                            Name = temp.Text
                        };
                        region.Add(clsRegionBusiness);
                    }

                }
            }
            catch (Exception e)
            {
                region = null;
                WebErrorLog.ErrorInstence.StartErrorLog(e);
            }

            return region;
        }
        public async Task<bool> UpdateAllAdvStatus(int takeCount, int dayCount = 0, long number = 0,
            bool isRaisEvent = true, string date1 = null, string date2 = null)
        {
            while (true)
            {
                try
                {
                    List<AdvertiseLogBussines> allAdvertiseLog = null;
                    _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
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
                            dayCount = clsAdvertise.DivarSetting?.DayCountForUpdateState ?? 10;
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

                        if (date1 != null)
                        {
                            var from = Calendar.ShamsiToMiladi(date1);
                            var to = Calendar.ShamsiToMiladi(date2);
                            var lst = await AdvertiseLogBussines
                                .GetAllSpecialAsync(p =>
                                    p.DateM >= from && p.DateM <= to && p.URL.Contains("manage"));
                            allAdvertiseLog = lst.OrderByDescending(q => q.LastUpdate).ToList();
                            if (allAdvertiseLog.Count <= 0) return true;
                        }
                    }

                    //var listNumbers = new List<long>();
                    foreach (var adv in allAdvertiseLog)
                    {
                        try
                        {
                            _driver.Navigate().GoToUrl(adv.URL);
                            await Utility.Wait(2);
                            //listNumbers.Add(adv.SimCardNumber);
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


                            var notAllowed = _driver
                                .FindElements(By.ClassName("ui")).Any(q =>
                                    q.Text == "برای ادامهٔ استفاده از دیوار، نیاز است وارد حساب خود شوید.");
                            if (notAllowed)
                            {
                                _driver.FindElement(By.ClassName("close"))?.Click();
                                await Utility.Wait();
                            }



                            await Utility.Wait(2);
                            var element = _driver.FindElement(By.ClassName("manage-header__status"));
                            if (element == null) continue;
                            var advStatus = element.Text;
                            element = _driver.FindElement(By.ClassName("manage-header__description"));
                            if (element == null) continue;
                            adv.UpdateDesc = element.Text;
                            adv.StatusCode = Utility.GetAdvStatusCodeByStatus(advStatus);
                            var tel = _driver.FindElement(By.ClassName("kt-unexpandable-row__action"));
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
                            if (isRaisEvent) RaiseEvent();

                        }
                        catch (Exception ex)
                        {
                            if (ex.Source != "WebDriver")
                                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                            await Utility.Wait();
                        }
                    }
                    //var t = listNumbers.GroupBy(q => q).Where(q => q.Count() == 1).Select(q => q.Key).ToList();
                    //listNumbers.Clear();
                    //listNumbers.AddRange(t);
                    //if (t.Count <= 0) return true;
                    //foreach (var adv in t)
                    //{
                    //    var token = await AdvTokensBusiness.GetToken(adv, AdvertiseType.DivarChat);
                    //    if (string.IsNullOrEmpty(token.Token)) continue;
                    //    await Utility.SendChat(adv);
                    //}

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
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
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
                adv.AdvType = AdvertiseType.Divar;
                adv.DateM = Utility.GetDateMFromPublishTime(date);
                var advStatus = _driver.FindElement(By.ClassName("manage-header__status")).Text;
                adv.UpdateDesc = _driver.FindElement(By.ClassName("manage-header__description")).Text;
                adv.StatusCode = Utility.GetAdvStatusCodeByStatus(advStatus);
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
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
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
        public List<DivarCities> GetAllCityFromDivar()
        {
            var cities = new List<DivarCities>();
            _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
            if (_driver.Url != "https://divar.ir/")
                _driver.Navigate().GoToUrl("https://divar.ir/");
            try
            {
                var cityElements = _driver.FindElements(By.TagName("h2")).ToList();
                var newList = cityElements.GroupBy(q => q.Text).Where(q => q.Count() == 1).Select(q => q.Key).ToList();
                foreach (var element in newList)
                {
                    var a = new DivarCities
                    {
                        Guid = Guid.NewGuid(),
                        Name = element
                    };
                    cities.Add(a);
                }
            }
            catch { }

            return cities;
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
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
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
                {
                    await DeleteAdvFromDivar(adv);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task GetEditNeededAdv(long number)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");
                var sim = await SimcardBussines.GetAsync(number);
                if (sim == null) return;
                var allPost = _driver.FindElements(By.ClassName("my-post")).ToList();
                foreach (var post in allPost)
                {
                    var editNeeded = post.FindElements(By.TagName("span")).FirstOrDefault(q => q.Text == "نیاز به اصلاح");
                    if (editNeeded == null) continue;
                    var adv = post.FindElements(By.ClassName("my-post__title")).FirstOrDefault()?.Text;
                    var url = post.GetAttribute("href");
                    TelegramSender.GetChatLog_bot().Send(
                        $"#نیاز_به_اصلاح \r\n سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n عنوان آگهی: {adv} \r\n شماره: {number} \r\n مالک: {sim.Owner} \r\n وضعیت آگهی: {editNeeded?.Text} \r\n لینک مدیریتی: {url}");
                }
            }
            catch (WebDriverException)
            { }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task<bool> UpdateAllRegisteredAdvOfSimCard(long simCardNumber)
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
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
                    if (publishDateEl != null) getUrl.DateM = Utility.GetDateMFromPublishTime(publishDateEl.Text);
                    //price and city
                    var postFieldElements = _driver.FindElements(By.ClassName("post-fields-item"));
                    foreach (var fieldElement in postFieldElements)
                    {
                        var title = fieldElement.FindElement(By.ClassName("post-fields-item__title")).Text;
                        var value = fieldElement.FindElement(By.ClassName("post-fields-item__value")).Text;
                        switch (title)
                        {
                            case "قیمت":
                                //getUrl.Price = value.FixString().Replace("تومان", "").Replace("٫", "").Trim()
                                //.ParseToDecimal();
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
                    getUrl.StatusCode = Utility.GetAdvStatusCodeByStatus(advStatus);
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
        public async Task ViewAdv(long simCard, string url)
        {
            try
            {
                if (await Login(simCard, false))
                    _driver.Navigate().GoToUrl(url);

                //بروزرسانی آگهی
                var adv = await AdvertiseLogBussines.GetAsync(url);
                try
                {
                    _driver.Navigate().GoToUrl(adv.URL);
                    await Utility.Wait(1);
                    var notFound = _driver
                        .FindElements(By.ClassName("title")).Any(q => q.Text == "این راه به جایی نمیرسد!");
                    if (notFound)
                    {
                        adv.UpdateDesc = "لینک مدیریتی باطل شده";
                        adv.StatusCode = StatusCode.Failed;
                        adv.LastUpdate = DateTime.Now;
                        adv.URL = "---";
                        await adv.SaveAsync();
                        RaiseEvent_Update();
                        return;
                    }
                    var element = _driver.FindElement(By.ClassName("manage-header__status"));
                    if (element == null)
                    {
                        RaiseEvent_Update();
                        return;
                    }
                    if (element.Text != StatusCode.EditNeeded.GetDisplay())
                    {
                        var advStatus = element.Text;
                        element = _driver.FindElement(By.ClassName("manage-header__description"));
                        if (element == null) return;
                        adv.UpdateDesc = element.Text;
                        adv.StatusCode = Utility.GetAdvStatusCodeByStatus(advStatus);
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
                        RaiseEvent_Update();
                        return;
                    }
                    element = _driver.FindElement(By.ClassName("manage-header__description"));
                    if (element == null)
                    {
                        RaiseEvent_Update();
                        return;
                    }
                    _driver.FindElements(By.ClassName("manage-header__button")).FirstOrDefault(q => q.Text == "ویرایش")
                        ?.Click();
                }
                catch (Exception ex)
                {
                    if (ex.Source != "WebDriver")
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    await Utility.Wait();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        //public async Task SendChat(long number, List<string> msg, int count, string city, string cat1, string cat2, string cat3, bool isSendToTelegram)
        //{
        //    try
        //    {
        //        if (number == 0) return;
        //        var log = await Login(number, false);
        //        if (!log) return;
        //        _driver.Navigate().GoToUrl("https://divar.ir/");
        //        await Utility.Wait();

        //        _driver.FindElement(By.ClassName("city-selector")).Click();
        //        await Utility.Wait();
        //        _driver.FindElements(By.TagName("a")).LastOrDefault(q => q.Text == city)?.Click();
        //        await Utility.Wait(2);

        //        var allAdv = _driver.FindElements(By.ClassName("category-dropdown__title"))
        //            .Any(q => q.Text == "همهٔ آگهی‌ها");

        //        var allCount = 0;
        //        while (allAdv)
        //        {
        //            if (allCount >= 3) return;
        //            var p = _driver.FindElements(By.ClassName("category-dropdown__icon")).Any();
        //            if (!p) return;
        //            await Utility.Wait(1);
        //            _driver.FindElements(By.ClassName("category-dropdown__icon")).FirstOrDefault()?.Click();
        //            await Utility.Wait();
        //            if (cat1 == "استخدام و کاریابی (غیر رایگان)") cat1 = cat1.Remove(17);
        //            _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text.Contains(cat1))
        //                ?.Click();
        //            await Utility.Wait(1);
        //            if (string.IsNullOrEmpty(cat2))
        //                return;
        //            if (string.IsNullOrEmpty(cat3))
        //                _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == cat2)
        //                    ?.Click();
        //            else
        //            {
        //                if (cat3.Contains("لوازم")) cat3 = cat3.Replace("لوازم", "مودم");
        //                _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == cat3)
        //                    ?.Click();
        //            }

        //            await Utility.Wait(1);
        //            allAdv = _driver.FindElements(By.ClassName("category-dropdown__title"))
        //                .Any(q => q.Text == "همهٔ آگهی‌ها");
        //            allCount++;
        //        }

        //        var j = 0;

        //        var counter = _driver.FindElements(By.ClassName("kt-post-card__body")).ToList();
        //        var total = counter.Count;
        //        var scroll = 0;
        //        while (counter.Count <= count)
        //        {
        //            if (scroll >= 10) break;
        //            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        //            await Utility.Wait();
        //            counter = _driver.FindElements(By.ClassName("kt-post-card__body")).ToList();
        //            if (total == counter.Count) break;
        //            scroll++;
        //        }

        //        if (counter.Count <= count)
        //            count = counter.Count - 1;

        //        for (var i = 0; j < count; i++)
        //        {
        //            if (j == count) return;
        //            await Utility.Wait();
        //            var notFound_ = _driver
        //                .FindElements(By.ClassName("title")).Any(q => q.Text == "این راه به جایی نمیرسد!");
        //            if (notFound_)
        //            {
        //                _driver.Navigate().Back();
        //                continue;
        //            }
        //            _driver.FindElements(By.ClassName("kt-post-card__body"))[i + 1]?.Click();
        //            await Utility.Wait(2);

        //            var chat = _driver.FindElements(By.ClassName("post-actions__chat")).Any();
        //            if (!chat)
        //            {
        //                _driver.Navigate().Back();
        //                continue;
        //            }

        //            _driver.FindElement(By.ClassName("post-actions__get-contact")).Click();
        //            await Utility.Wait(1.5);

        //            var a = _driver.FindElements(By.ClassName("kt-button"))
        //                .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم");
        //            if (a != null)
        //                _driver.FindElements(By.ClassName("kt-button"))
        //                    .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم")?.Click();
        //            await Utility.Wait();

        //            var num = _driver.FindElement(By.ClassName("kt-unexpandable-row__action")).Text.FixString();
        //            if (num != "(پنهان‌شده؛ چت کنید)")
        //            {
        //                if (num.ParseToLong() == 0)
        //                {
        //                    _driver.Navigate().Back();
        //                    continue;
        //                }

        //                var notExist = await ChatNumberBusiness.CheckNumber(num);
        //                if (!notExist) //exist
        //                {
        //                    _driver.Navigate().Back();
        //                    continue;
        //                }
        //            }

        //            _driver.FindElement(By.ClassName("post-actions__chat")).Click();
        //            var qanoon = _driver.FindElements(By.TagName("button"))
        //                .Where(q => q.Text == "با قوانین دیوار موافقم").ToList();
        //            if (qanoon.Count > 0)
        //                qanoon.FirstOrDefault()?.Click();
        //            var dc = _driver.WindowHandles.Count;
        //            if (dc > 1)
        //                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        //            var logEl = _driver.FindElements(By.ClassName("auth__input__view")).Any();
        //            if (logEl)
        //            {
        //                var tt = await LoginChat(number, false);
        //                if (!tt) return;
        //            }

        //            await Utility.Wait(1);

        //            var notFound1 = _driver.FindElements(By.ClassName("content")).Any(q => q.Text == "یافت نشد!");
        //            if (notFound1)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                await Utility.Wait();
        //            }

        //            var notAllowed2 = _driver.FindElements(By.ClassName("content"))
        //                .Any(q => q.Text == "این آگهی موجود نیست یا قابلیت چت ندارد!");
        //            if (notAllowed2)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                continue;
        //            }



        //            if (!isSendToTelegram)
        //            {
        //                var postchi = _driver.FindElements(By.ClassName("conversation-item__title")).Any();
        //                if (postchi)
        //                {
        //                    _driver.FindElements(By.ClassName("conversation-item__title")).FirstOrDefault()?.Click();
        //                    await Utility.Wait();

        //                    _driver.Navigate().Back();
        //                }


        //                await Utility.Wait();
        //                var chatCount = _driver.FindElements(By.ClassName("conversation-item__conversation-status"))
        //                    .Count(q => q.Text == "(پیام جدید)");
        //                await Utility.Wait();
        //                if (chatCount > 0)
        //                {
        //                    var sim = await SimCardBusiness.GetAsync(number);
        //                    var owner = await OwnerBusiness.GetAsync(sim.OwnerGuid);
        //                    TelegramSender.GetChatLog_bot()
        //                        .Send(
        //                            $"#چت_دیوار \r\n سیستم مرجع: {await Utility.GetNetworkIpAddress()} \r\n شماره: {number} \r\n مالک: {owner.FullName} \r\n تعداد چت موجود: {count} \r\n");
        //                }

        //                isSendToTelegram = true;
        //            }


        //            var aouth = _driver.FindElements(By.ClassName("auth__body__text")).Any();
        //            if (aouth)
        //            {
        //                var simbus = await SimCardBusiness.GetAsync(number);
        //                var owner = await OwnerBusiness.GetAsync(simbus.OwnerGuid);
        //                _driver.FindElement(By.TagName("input")).SendKeys(owner.FullName + '\n');
        //            }

        //            var notAllowed = _driver.FindElements(By.TagName("p"))
        //                .Any(q => q.Text == "در حال حاضر امکان ارسال این نوع پیام وجود ندارد.");
        //            if (notAllowed)
        //            {
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                return;
        //            }

        //            var chatBox = _driver.FindElements(By.ClassName("chat-box__input")).Any();
        //            var co = 0;
        //            while (!chatBox)
        //            {
        //                if (co > 10)
        //                {
        //                    _driver.Close();
        //                    _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                    _driver.Navigate().Back();
        //                    break;
        //                }
        //                await Utility.Wait(2);
        //                chatBox = _driver.FindElements(By.ClassName("chat-box__input")).Any();
        //                co++;
        //            }

        //            if (co > 10) continue;
        //            var notFound = _driver.FindElements(By.ClassName("content")).Any(q => q.Text == "یافت نشد!");
        //            if (notFound)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                continue;
        //            }

        //            var serverError = _driver.FindElements(By.ClassName("content"))
        //                .Any(q => q.Text.Contains("Internal Server Error "));
        //            if (serverError)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                continue;
        //            }

        //            var rnd = new Random().Next(0, msg.Count);
        //            var thread = new Thread(() => Clipboard.SetText(msg[rnd] + '\n'));
        //            thread.SetApartmentState(ApartmentState.STA);
        //            thread.Start();
        //            var t = _driver.FindElement(By.ClassName("chat-box__input"));
        //            t?.Click();
        //            await Utility.Wait();
        //            var notChat = _driver.FindElements(By.ClassName("content"))
        //                .Any(q => q.Text == "این آگهی موجود نیست یا قابلیت چت ندارد!");
        //            if (notChat)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                var thr = new Thread(Clipboard.Clear);
        //                thr.SetApartmentState(ApartmentState.STA);
        //                thr.Start();
        //                continue;
        //            }

        //            t.SendKeys(OpenQA.Selenium.Keys.Control + "v");
        //            var thread1 = new Thread(Clipboard.Clear);
        //            thread1.SetApartmentState(ApartmentState.STA);
        //            thread1.Start();
        //            t.SendKeys("\n");
        //            await Utility.Wait();
        //            j++;
        //            var notPoss = _driver.FindElements(By.ClassName("content")).Any(q =>
        //                q.Text == "در حال حاضر امکان ارسال این نوع پیام وجود ندارد.");
        //            if (notPoss)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                var thr = new Thread(Clipboard.Clear);
        //                thr.SetApartmentState(ApartmentState.STA);
        //                thr.Start();
        //                return;
        //            }
        //            var notChat_ = _driver.FindElements(By.ClassName("content"))
        //                .Any(q => q.Text == "استفاده شما از چت دیوار موقتاً محدود شده است.");
        //            if (notChat_)
        //            {
        //                _driver.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text == "بستن")?.Click();
        //                _driver.Close();
        //                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //                _driver.Navigate().Back();
        //                var thr = new Thread(Clipboard.Clear);
        //                thr.SetApartmentState(ApartmentState.STA);
        //                thr.Start();
        //                return;
        //            }

        //            if (num != "(پنهان‌شده؛ چت کنید)")
        //            {
        //                var chn = new ChatNumberBusiness
        //                {
        //                    Guid = Guid.NewGuid(),
        //                    Number = num,
        //                    DateM = DateTime.Now,
        //                    Modified = DateTime.Now,
        //                    City = city,
        //                    Category = $"{cat1}_{cat2}_{cat3}"
        //                };
        //                await chn.SaveAsync();
        //            }

        //            _driver.Close();
        //            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        //            _driver.Navigate().Back();
        //        }
        //    }
        //    catch (WebDriverException)
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!ex.Message.Contains("out of range"))
        //            WebErrorLog.ErrorLogInstance.StartLog(ex);
        //    }
        //}
        private async Task RemoveWaitForPayment()
        {
            try
            {
                _driver = Utility.RefreshDriver(_driver, clsAdvertise.IsSilent);
                _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");

                var allPost = _driver.FindElements(By.ClassName("my-post")).Where(q => q.Text.Contains("منتظر پرداخت"))
                    .ToList();
                await Utility.Wait(1);
                var manageLinks = new List<string>();
                foreach (var post in allPost)
                {
                    var url = post.GetAttribute("href");

                    if (url.Contains("manage")) manageLinks.Add(url);
                }


                foreach (var item in manageLinks)
                {
                    _driver.Navigate().GoToUrl(item);
                    await Utility.Wait(1);
                    var delAdv = _driver.FindElements(By.ClassName("kt-text-truncate"))
                        .FirstOrDefault(q => q.Text == "حذف آگهی");
                    delAdv?.Click();
                    await Utility.Wait(1);
                    var rbtn = _driver.FindElements(By.ClassName("kt-switch__input")).ToList();
                    if (rbtn.Count <= 0) continue;
                    rbtn[3]?.Click();
                    await Utility.Wait(1);
                    _driver.FindElements(By.ClassName("kt-text-truncate"))?.FirstOrDefault(q => q.Text == "تأیید")
                        ?.Click();
                    await Utility.Wait(1);
                    _driver.FindElements(By.ClassName("kt-text-truncate"))?.FirstOrDefault(q => q.Text == "تأیید")
                        ?.Click();
                    await Utility.Wait(1);


                    var adv = await AdvertiseLogBussines.GetAsync(item);
                    if (adv == null) continue;
                    adv.StatusCode = StatusCode.Deleted;
                    adv.UpdateDesc = "حذف آگهی های منتظر پرداخت به صورت خودکار";
                    adv.LastUpdate = DateTime.Now;

                    await adv.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        #endregion

    }
}
