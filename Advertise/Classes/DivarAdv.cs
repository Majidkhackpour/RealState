using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Services;
using Settings.Classes;
using WebHesabBussines;

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
        public async Task<ReturnedSaveFuncInfo> StartRegisterAdv(long number)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                var res = await Utilities.PingHostAsync();
                if (res.HasError)
                {
                    ret.AddError("لطفا اتصال به شبکه را چک نمایید");
                    return ret;
                }

                var sim = await SimcardBussines.GetAsync(number);
                var tt = await Utility.CheckToken(number, AdvertiseType.Divar);
                if (tt.HasError)
                {
                    ret.AddError($"شماره {number} به دلیل نداشتن توکن دیوار، موفق به لاگین نشد");
                    sim.NextUseDivar = DateTime.Now.AddDays(1);
                    await sim.SaveAsync();
                    return ret;
                }

                if (!await Login(number, false) /*|| !await UpdateAllRegisteredAdvOfSimCard(number)*/) return ret;
                //await GetEditNeededAdv(number);
                //await Utility.Wait(1);
                // await RemoveWaitForPayment();
                //await RegisterAdv(adv, isRaiseEvent);
                //await Utility.Wait(1);
                //sim.Modified = DateTime.Now;
                //var full = _driver.FindElements(By.ClassName("header"))
                //    .Any(q => q.Text == "لطفا به موارد زیر توجه کنید:");
                //if (full) return;
                //await sim.SaveAsync();
            }
            catch (WebException) { }
            catch (Exception ex) { WebErrorLog.ErrorInstence.StartErrorLog(ex); }

            return ret;
        }
        public async Task<bool> Login(long simCardNumber, bool isFromSimForm)
        {
            try
            {
                if (isFromSimForm)
                {
                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
                    _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
                    if (!_driver.Url.Contains("divar.ir"))
                        _driver.Navigate().GoToUrl("https://divar.ir");

                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.Divar);
                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    if (simBusiness.HasError)
                    {
                        TelegramSender.GetChatLog_bot()
                            .Send(
                                $"#نداشتن_توکن \r\n سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n شماره: {simCardNumber} \r\n مالک: {sim.Owner} \r\n وضعیت توکن دیوار: حذف شده \r\nلطفا مجددا توکن گیری شود");
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
                        $"#نداشتن_توکن \r\n سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n شماره {simCardNumber} به مالکیت {sim.Owner} توکن آگهی دیوار داشته، اما منقضی شده و موفق به لاگین آگهی نشد " +
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
                    _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
                    _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
                    if (!_driver.Url.Contains("https://chat.divar.ir/"))
                        _driver.Navigate().GoToUrl("https://chat.divar.ir/");

                    var sim = await SimcardBussines.GetAsync(simCardNumber);
                    var simBusiness = await Utility.CheckToken(simCardNumber, AdvertiseType.DivarChat);
                    if (simBusiness.HasError)
                    {
                        TelegramSender.GetChatLog_bot()
                            .Send(
                                $"#نداشتن_توکن \r\n سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n شماره: {simCardNumber} \r\n مالک: {sim.Owner} \r\n وضعیت توکن چت دیوار: حذف شده \r\n لطفا مجددا توکن گیری شود");
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
                        $"#نداشتن_توکن \r\n سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n شماره {simCardNumber} به مالکیت {sim.Owner} توکن چت دیوار داشته، اما منقضی شده و موفق به لاگین چت نشد " +
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
        public async Task<bool> LoginForScrappAsync(string token)
        {
            try
            {
                _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
                if (!_driver.Url.Contains("divar.ir"))
                    _driver.Navigate().GoToUrl("https://divar.ir");

                var listLinkItems = _driver.FindElements(By.TagName("a"));
                var isLogined = listLinkItems.Any(linkItem => linkItem.Text == @"خروج");
                //اگر کاربر لاگین شده فعلی همان کاربر مورد نظر است نیازی به لاگین نیست 
                if (isLogined)
                {
                    var currentTokenOnDivar = _driver.Manage().Cookies.GetCookieNamed("token").Value;
                    if (!string.IsNullOrEmpty(currentTokenOnDivar) && currentTokenOnDivar == token)
                        return true;
                }

                //اگر کاربرلاگین شده کاربر مد نظر ما نیست از آن کاربری خارج می شود
                if (isLogined)
                {
                    _driver.Manage().Cookies.DeleteCookieNamed("_gat");
                    _driver.Manage().Cookies.DeleteCookieNamed("token");
                }

                //در صورتیکه توکن قبلا ثبت شده باشد لاگین می کند
                if (!string.IsNullOrEmpty(token))
                {
                    var token_ = new OpenQA.Selenium.Cookie("token", token);
                    _driver.Manage().Cookies.AddCookie(token_);
                    _driver.Navigate().Refresh();
                }

                //انتظار برای لاگین شدن
                var repeat = 0;
                //حدود 120 ثانیه فرصت لاگین دارد
                while (repeat < 3)
                {
                    //تا زمانی که لاگین اوکی نشده باشد این حلقه تکرار می شود
                    listLinkItems = _driver.FindElements(By.TagName("a"));
                    if (listLinkItems.Count < 5) return false;
                    var loginList = _driver.FindElements(By.ClassName("kt-button--inlined"))
                        ?.FirstOrDefault(q => q.Text == "دیوار من");
                    var isLogin = false;
                    if (loginList != null)
                    {
                        try
                        {
                            loginList?.Click();
                            await Utility.Wait();
                            isLogin = _driver.FindElements(By.ClassName("kt-fullwidth-link__title"))
                                .Any(q => q.Text == "خروج");
                        }
                        catch
                        {
                        }
                    }

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
            _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
        //public async Task<bool> UpdateAllAdvStatus(int takeCount, int dayCount = 0, long number = 0,
        //    bool isRaisEvent = true, string date1 = null, string date2 = null)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            List<AdvertiseLogBussines> allAdvertiseLog = null;
        //            _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
        //            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
        //            {
        //                dayCount = 7;
        //                var lastWeek = DateTime.Now.AddDays(-dayCount);
        //                var lst = await AdvertiseLogBussines
        //                    .GetAllSpecialAsync(p => p.DateM > lastWeek && p.URL.Contains("manage"));
        //                allAdvertiseLog = lst.OrderBy(q => q.LastUpdate).ToList();
        //                if (allAdvertiseLog.Count <= 0) return true;
        //            }
        //            else
        //            {
        //                if (dayCount == 0)
        //                    dayCount = clsAdvertise.Divar_DayCountForUpdateState;
        //                var lastWeek = DateTime.Now.AddDays(-dayCount);
        //                if (number == 0)
        //                {
        //                    var lst = await AdvertiseLogBussines
        //                        .GetAllSpecialAsync(p => p.DateM > lastWeek && p.URL.Contains("manage"));
        //                    allAdvertiseLog = lst.OrderBy(q => q.LastUpdate).ToList();
        //                    if (allAdvertiseLog.Count <= 0) return true;
        //                    if (takeCount != 0)
        //                    {
        //                        var dayOfWeek = allAdvertiseLog.First().LastUpdate.DayOfWeek;
        //                        if (dayOfWeek == DateTime.Now.DayOfWeek) return true;
        //                        if (allAdvertiseLog.Count > takeCount)
        //                            allAdvertiseLog = allAdvertiseLog.Take(takeCount).ToList();
        //                    }
        //                }
        //                else
        //                {
        //                    var lst = await AdvertiseLogBussines
        //                        .GetAllSpecialAsync(p =>
        //                            p.DateM > lastWeek && p.URL.Contains("manage") && p.SimcardNumber == number);
        //                    allAdvertiseLog = lst.OrderByDescending(q => q.LastUpdate).ToList();
        //                    if (allAdvertiseLog.Count <= 0) return true;
        //                    if (takeCount != 0)
        //                    {
        //                        if (allAdvertiseLog.Count > takeCount)
        //                            allAdvertiseLog = allAdvertiseLog.Take(takeCount).ToList();
        //                    }
        //                }

        //                if (date1 != null)
        //                {
        //                    var from = Calendar.ShamsiToMiladi(date1);
        //                    var to = Calendar.ShamsiToMiladi(date2);
        //                    var lst = await AdvertiseLogBussines
        //                        .GetAllSpecialAsync(p =>
        //                            p.DateM >= from && p.DateM <= to && p.URL.Contains("manage"));
        //                    allAdvertiseLog = lst.OrderByDescending(q => q.LastUpdate).ToList();
        //                    if (allAdvertiseLog.Count <= 0) return true;
        //                }
        //            }

        //            //var listNumbers = new List<long>();
        //            foreach (var adv in allAdvertiseLog)
        //            {
        //                try
        //                {
        //                    _driver.Navigate().GoToUrl(adv.URL);
        //                    await Utility.Wait(2);
        //                    //listNumbers.Add(adv.SimCardNumber);
        //                    var notFound = _driver
        //                        .FindElements(By.ClassName("title")).Any(q => q.Text == "این راه به جایی نمیرسد!");
        //                    if (notFound)
        //                    {
        //                        adv.UpdateDesc = "لینک مدیریتی باطل شده";
        //                        adv.StatusCode = StatusCode.Failed;
        //                        adv.LastUpdate = DateTime.Now;
        //                        adv.URL = "---";
        //                        await adv.SaveAsync();
        //                        continue;
        //                    }


        //                    var notAllowed = _driver
        //                        .FindElements(By.ClassName("ui")).Any(q =>
        //                            q.Text == "برای ادامهٔ استفاده از دیوار، نیاز است وارد حساب خود شوید.");
        //                    if (notAllowed)
        //                    {
        //                        _driver.FindElement(By.ClassName("close"))?.Click();
        //                        await Utility.Wait();
        //                    }



        //                    await Utility.Wait(2);
        //                    var element = _driver.FindElement(By.ClassName("manage-header__status"));
        //                    if (element == null) continue;
        //                    var advStatus = element.Text;
        //                    element = _driver.FindElement(By.ClassName("manage-header__description"));
        //                    if (element == null) continue;
        //                    adv.UpdateDesc = element.Text;
        //                    adv.StatusCode = Utility.GetAdvStatusCodeByStatus(advStatus);
        //                    var tel = _driver.FindElement(By.ClassName("kt-unexpandable-row__action"));
        //                    if (tel != null)
        //                        adv.SimcardNumber = tel.Text.FixString().ParseToLong();


        //                    //بروزرسانی آمار بازدید منتشر شده ها
        //                    if (adv.StatusCode == StatusCode.Published)
        //                    {
        //                        var visitCountEl = _driver.FindElement(By.ClassName("post-stats__summary"));
        //                        if (visitCountEl != null && visitCountEl.Text.Length > 11)
        //                        {
        //                            int.TryParse(visitCountEl.Text.Substring(11).Trim().FixString(), out var cnt);
        //                            adv.VisitCount = cnt;
        //                        }
        //                    }

        //                    adv.LastUpdate = DateTime.Now;
        //                    await adv.SaveAsync();
        //                    if (isRaisEvent) RaiseEvent();

        //                }
        //                catch (Exception ex)
        //                {
        //                    if (ex.Source != "WebDriver")
        //                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //                    await Utility.Wait();
        //                }
        //            }
        //            //var t = listNumbers.GroupBy(q => q).Where(q => q.Count() == 1).Select(q => q.Key).ToList();
        //            //listNumbers.Clear();
        //            //listNumbers.AddRange(t);
        //            //if (t.Count <= 0) return true;
        //            //foreach (var adv in t)
        //            //{
        //            //    var token = await AdvTokensBusiness.GetToken(adv, AdvertiseType.DivarChat);
        //            //    if (string.IsNullOrEmpty(token.Token)) continue;
        //            //    await Utility.SendChat(adv);
        //            //}

        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ex.Source != "WebDriver")
        //                WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //            return false;
        //        }
        //    }

        //}
        private async Task<bool> UpdateAdvStatus(AdvertiseLogBussines adv, long number = 0)
        {
            try
            {
                _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
                _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
            _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
                _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
        //public async Task DeleteAllAdvFromDivar(int fromNDayBefore, StatusCode statusCode)
        //{
        //    try
        //    {
        //        var date = DateTime.Now.AddDays(-fromNDayBefore);
        //        var advList = await
        //            AdvertiseLogBussines.GetAllSpecialAsync(p => p.DateM < date && p.StatusCode == statusCode);
        //        advList = advList.OrderByDescending(q => q.DateM).ToList();
        //        foreach (var adv in advList)
        //        {
        //            await DeleteAdvFromDivar(adv);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //    }
        //}
        private async Task GetEditNeededAdv(long number)
        {
            try
            {
                _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
                        $"#نیاز_به_اصلاح \r\n سیستم مرجع: {await Utilities.GetNetworkIpAddress()} \r\n عنوان آگهی: {adv} \r\n شماره: {number} \r\n مالک: {sim.Owner} \r\n وضعیت آگهی: {editNeeded?.Text} \r\n لینک مدیریتی: {url}");
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
                _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
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
        //private async Task RemoveWaitForPayment()
        //{
        //    try
        //    {
        //        _driver = Utility.RefreshDriver(clsAdvertise.IsSilent);
        //        _driver.Navigate().GoToUrl("https://divar.ir/my-divar/my-posts");

        //        var allPost = _driver.FindElements(By.ClassName("my-post")).Where(q => q.Text.Contains("منتظر پرداخت"))
        //            .ToList();
        //        await Utility.Wait(1);
        //        var manageLinks = new List<string>();
        //        foreach (var post in allPost)
        //        {
        //            var url = post.GetAttribute("href");

        //            if (url.Contains("manage")) manageLinks.Add(url);
        //        }


        //        foreach (var item in manageLinks)
        //        {
        //            _driver.Navigate().GoToUrl(item);
        //            await Utility.Wait(1);
        //            var delAdv = _driver.FindElements(By.ClassName("kt-text-truncate"))
        //                .FirstOrDefault(q => q.Text == "حذف آگهی");
        //            delAdv?.Click();
        //            await Utility.Wait(1);
        //            var rbtn = _driver.FindElements(By.ClassName("kt-switch__input")).ToList();
        //            if (rbtn.Count <= 0) continue;
        //            rbtn[3]?.Click();
        //            await Utility.Wait(1);
        //            _driver.FindElements(By.ClassName("kt-text-truncate"))?.FirstOrDefault(q => q.Text == "تأیید")
        //                ?.Click();
        //            await Utility.Wait(1);
        //            _driver.FindElements(By.ClassName("kt-text-truncate"))?.FirstOrDefault(q => q.Text == "تأیید")
        //                ?.Click();
        //            await Utility.Wait(1);


        //            var adv = await AdvertiseLogBussines.GetAsync(item);
        //            if (adv == null) continue;
        //            adv.StatusCode = StatusCode.Deleted;
        //            adv.UpdateDesc = "حذف آگهی های منتظر پرداخت به صورت خودکار";
        //            adv.LastUpdate = DateTime.Now;

        //            await adv.SaveAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //    }
        //}
        //public async Task<List<BuildingViewModel>> GetBuildingAsync(EnRequestType reqType, decimal fPrice1, decimal sPrice1, decimal fPrice2, decimal sPrice2, int metrazh1, int metrazh2, int count, List<string> regionList)
        //{
        //    var res = new List<BuildingViewModel>();
        //    try
        //    {
        //        var allSim = await SimcardBussines.GetAllAsync();
        //        var sim = allSim.FirstOrDefault(q => q.HasDivarToken);
        //        if (sim == null) return res;

        //        if (fPrice2 > 0) fPrice2 /= 10;
        //        if (sPrice2 > 0) sPrice2 /= 10;
        //        fPrice1 /= 10;
        //        sPrice1 /= 10;

        //        var city = await CitiesBussines.GetAsync(Guid.Parse(clsEconomyUnit.EconomyCity));

        //        if (!await Login(sim.Number, false)) return res;

        //        _driver.FindElement(By.ClassName("city-selector")).Click();
        //        await Utility.Wait();
        //        _driver.FindElements(By.TagName("a")).LastOrDefault(q => q.Text == city.Name)?.Click();
        //        await Utility.Wait(2);

        //        var p = _driver.FindElements(By.ClassName("category-dropdown__icon")).Any();
        //        if (!p) return res;
        //        await Utility.Wait(1);
        //        _driver.FindElements(By.ClassName("category-dropdown__icon")).FirstOrDefault()?.Click();
        //        await Utility.Wait();

        //        var cat = await SetCategory(reqType);
        //        if (string.IsNullOrEmpty(cat)) return res;

        //        _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text.Contains("املاک"))
        //            ?.Click();
        //        await Utility.Wait(1);

        //        _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == cat)
        //            ?.Click();

        //        await Utility.Wait(1);

        //        if (reqType == EnRequestType.Rahn)
        //        {
        //            //محل
        //            if (regionList != null && regionList.Count > 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "محل")?.Click();
        //                await Utility.Wait();
        //                _driver.FindElement(By.ClassName("browse-select-field__value-container"))?.Click();
        //                await Utility.Wait();
        //                foreach (var item in regionList)
        //                {
        //                    _driver.FindElement(By.Id("react-select-location-select-input"))?.SendKeys(item + "\n");
        //                    await Utility.Wait();
        //                }
        //            }

        //            var listVadiee = _driver.FindElements(By.Id("react-select-int-field-input")).ToList();
        //            //رهن
        //            if (fPrice1 != 0 || sPrice1 != 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "ودیعه")?.Click();
        //                await Utility.Wait(1);
        //                listVadiee[0]?.SendKeys(fPrice1 + "\n");
        //                await Utility.Wait(1);
        //                listVadiee[1]?.SendKeys(sPrice1 + "\n");
        //            }

        //            //اجاره
        //            if (fPrice2 != 0 || sPrice2 != 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "اجاره")?.Click();
        //                await Utility.Wait(1);
        //                listVadiee[2]?.SendKeys(fPrice2 + "\n");
        //                await Utility.Wait(1);
        //                listVadiee[3]?.SendKeys(sPrice2 + "\n");
        //            }

        //            //متراژ
        //            if (metrazh1 != 0 || metrazh2 != 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "متراژ")?.Click();
        //                await Utility.Wait(1);
        //                listVadiee[4]?.SendKeys(metrazh1 + "\n");
        //                await Utility.Wait(1);
        //                listVadiee[5]?.SendKeys(metrazh2 + "\n");
        //            }


        //            var j = 0;

        //            for (var i = 0; j < count; i++)
        //            {
        //                if (j == count) return res;

        //                if (_driver.Url.Contains("https://divar.ir/v/")) _driver.Navigate().Back();

        //                await Utility.Wait(1);
        //                var viewModel = new BuildingViewModel();
        //                _driver.FindElements(By.ClassName("kt-post-card__body"))[i + 1]?.Click();
        //                await Utility.Wait(2);

        //                _driver.FindElement(By.ClassName("post-actions__get-contact")).Click();
        //                await Utility.Wait(1.5);

        //                var a = _driver.FindElements(By.ClassName("kt-button"))
        //                    .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم");
        //                await Utility.Wait();
        //                if (a != null)
        //                    _driver.FindElements(By.ClassName("kt-button"))
        //                        .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم")?.Click();
        //                await Utility.Wait();

        //                var num = _driver.FindElement(By.ClassName("kt-unexpandable-row__action")).Text.FixString();
        //                if (num != "(پنهان‌شده؛ چت کنید)") viewModel.Mobile = num;

        //                var pList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value")).ToList();

        //                viewModel.Region = _driver.FindElements(By.ClassName("kt-unexpandable-row__action"))[1]?.Text.FixString();
        //                viewModel.Address = _driver.FindElements(By.ClassName("kt-unexpandable-row__action"))[1]?.Text.FixString();
        //                viewModel.Metrazh = (int)pList[1]?.Text?.FixString()
        //                    .Replace("متر", "")?.ParseToInt();
        //                viewModel.SaleSakht = pList[2]?.Text.FixString();
        //                viewModel.RoomCount = pList[3]?.Text.FixString();
        //                var p1 = pList[4]?.Text.FixString()?.Replace("تومان", "")?.Replace("٫", "");
        //                var p2 = pList[5]?.Text.FixString()?.Replace("تومان", "")?.Replace("٫", "");
        //                viewModel.Price1 = p1.ParseToDecimal() * 10;
        //                viewModel.Price2 = p2.ParseToDecimal() * 10;
        //                viewModel.Tabdil = pList[6]?.Text;
        //                viewModel.RentalAuthority = pList[7]?.Text;
        //                var options = new List<string>();
        //                if (pList.Count == 12)
        //                {
        //                    options.Add($"پارکینگ: {pList[9]?.Text}");
        //                    options.Add($"انباری: {pList[10]?.Text}");
        //                    options.Add($"بالکن: {pList[11]?.Text}");

        //                }
        //                else if (pList.Count == 13)
        //                {
        //                    viewModel.Tabaqe = pList[9]?.Text?.FixString();
        //                    options.Add($"پارکینگ: {pList[10]?.Text}");
        //                    options.Add($"انباری: {pList[11]?.Text}");
        //                    options.Add($"بالکن: {pList[12]?.Text}");
        //                }

        //                viewModel.Options = options;
        //                viewModel.Description = _driver
        //                    .FindElement(By.ClassName("kt-description-row__text"))?.Text;
        //                viewModel.Parent = "سایت دیوار";
        //                viewModel.Type = EnRequestType.Rahn;

        //                res.Add(viewModel);

        //                j++;

        //                _driver.Navigate().Back();
        //            }
        //        }
        //        else if (reqType == EnRequestType.Forush)
        //        {
        //            //محل
        //            if (regionList != null && regionList.Count > 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "محل")?.Click();
        //                await Utility.Wait();
        //                _driver.FindElement(By.ClassName("browse-select-field__value-container"))?.Click();
        //                await Utility.Wait();
        //                foreach (var item in regionList)
        //                {
        //                    _driver.FindElement(By.Id("react-select-location-select-input"))?.SendKeys(item + "\n");
        //                    await Utility.Wait();
        //                }
        //            }

        //            var listVadiee = _driver.FindElements(By.Id("react-select-int-field-input")).ToList();
        //            //فی کل
        //            if (fPrice1 != 0 || sPrice1 != 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "قیمت کل")?.Click();
        //                await Utility.Wait(1);
        //                listVadiee[0]?.SendKeys(fPrice1 + "\n");
        //                await Utility.Wait(1);
        //                listVadiee[1]?.SendKeys(sPrice1 + "\n");
        //            }

        //            //متراژ
        //            if (metrazh1 != 0 || metrazh2 != 0)
        //            {
        //                _driver.FindElements(By.ClassName("browse-accordion__title"))
        //                    ?.FirstOrDefault(q => q.Text == "متراژ")?.Click();
        //                await Utility.Wait(1);
        //                listVadiee[2]?.SendKeys(metrazh1 + "\n");
        //                await Utility.Wait(1);
        //                listVadiee[3]?.SendKeys(metrazh2 + "\n");
        //            }

        //            var j = 0;

        //            for (var i = 0; j < count; i++)
        //            {
        //                if (j == count) return res;

        //                if (_driver.Url.Contains("https://divar.ir/v/")) _driver.Navigate().Back();

        //                await Utility.Wait(1);
        //                var viewModel = new BuildingViewModel();
        //                _driver.FindElements(By.ClassName("kt-post-card__body"))[i + 1]?.Click();
        //                await Utility.Wait(2);

        //                _driver.FindElement(By.ClassName("post-actions__get-contact")).Click();
        //                await Utility.Wait(1.5);

        //                var a = _driver.FindElements(By.ClassName("kt-button"))
        //                    .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم");
        //                await Utility.Wait();
        //                if (a != null)
        //                    _driver.FindElements(By.ClassName("kt-button"))
        //                        .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم")?.Click();
        //                await Utility.Wait();

        //                var num = _driver.FindElement(By.ClassName("kt-unexpandable-row__action")).Text.FixString();
        //                if (num != "(پنهان‌شده؛ چت کنید)") viewModel.Mobile = num;

        //                var pList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value")).ToList();

        //                viewModel.Region = _driver.FindElements(By.ClassName("kt-unexpandable-row__action"))[1]?.Text.FixString();
        //                viewModel.Address = _driver.FindElements(By.ClassName("kt-unexpandable-row__action"))[1]?.Text.FixString();
        //                viewModel.Metrazh = (int)pList[1]?.Text?.FixString()
        //                    .Replace("متر", "")?.ParseToInt();
        //                viewModel.SaleSakht = pList[2]?.Text.FixString();
        //                viewModel.RoomCount = pList[3]?.Text.FixString();
        //                var p1 = pList[4]?.Text.FixString()?.Replace("تومان", "")?.Replace("٫", "");
        //                viewModel.Price1 = p1.ParseToDecimal() * 10;

        //                var options = new List<string>();
        //                if (pList.Count == 10)
        //                {
        //                    viewModel.Tabaqe = pList[6]?.Text?.FixString();
        //                    options.Add($"پارکینگ: {pList[7]?.Text}");
        //                    options.Add($"انباری: {pList[8]?.Text}");
        //                    options.Add($"بالکن: {pList[9]?.Text}");
        //                }
        //                else if (pList.Count == 11)
        //                {
        //                    viewModel.Tabaqe = pList[7]?.Text?.FixString();
        //                    options.Add($"پارکینگ: {pList[8]?.Text}");
        //                    options.Add($"انباری: {pList[9]?.Text}");
        //                    options.Add($"بالکن: {pList[10]?.Text}");
        //                }

        //                viewModel.Options = options;
        //                viewModel.Description = _driver
        //                    .FindElement(By.ClassName("kt-description-row__text"))?.Text;
        //                viewModel.Parent = "سایت دیوار";
        //                viewModel.Type = EnRequestType.Forush;

        //                res.Add(viewModel);

        //                j++;

        //                _driver.Navigate().Back();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //    }

        //    return res;
        //}
        private async Task<string> SetCategory(EnRequestType reqType)
        {
            try
            {
                switch (reqType)
                {
                    case EnRequestType.Rahn: return "اجاره مسکونی";
                    case EnRequestType.Forush: return "فروش مسکونی";
                    case EnRequestType.Moavezeh: return "";
                    case EnRequestType.Mosharekat: return "مشارکت در ساخت";
                    case EnRequestType.PishForush: return "پیش‌فروش";
                    default: return "";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        //public async Task GetBuildingFromDivarAsync(EnRequestType reqType, long number)
        //{
        //    try
        //    {
        //        var login = await Login(number, false);
        //        if (!login) return;

        //        var city = await CitiesBussines.GetAsync(Guid.Parse(clsEconomyUnit.EconomyCity));

        //        _driver.FindElement(By.ClassName("city-selector")).Click();
        //        await Utility.Wait();
        //        _driver.FindElements(By.TagName("a")).LastOrDefault(q => q.Text == city.Name)?.Click();
        //        await Utility.Wait(2);

        //        var p = _driver.FindElements(By.ClassName("category-dropdown__icon")).Any();
        //        if (!p) return;
        //        await Utility.Wait(1);
        //        _driver.FindElements(By.ClassName("category-dropdown__icon")).FirstOrDefault()?.Click();
        //        await Utility.Wait();

        //        var cat = await SetCategory(reqType);
        //        if (string.IsNullOrEmpty(cat)) return;

        //        _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text.Contains("املاک"))
        //            ?.Click();
        //        await Utility.Wait(1);

        //        _driver.FindElements(By.ClassName("category-button")).FirstOrDefault(q => q.Text == cat)
        //            ?.Click();

        //        await Utility.Wait(1);



        //        if (reqType == EnRequestType.Rahn)
        //        {
        //            try
        //            {
        //                while (true)
        //                {
        //                    var j = _driver.FindElements(By.ClassName("kt-post-card__body")).ToList();
        //                    for (var i = 0; i < j.Count - 1; i++)
        //                    {
        //                        if (_driver.Url.Contains("https://divar.ir/v/")) _driver.Navigate().Back();

        //                        await Utility.Wait(1);
        //                        var viewModel = new BuildingBussines
        //                        {
        //                            Guid = Guid.NewGuid(),
        //                            Modified = DateTime.Now,
        //                            Status = true,
        //                            CreateDate = DateTime.Now,
        //                            Code = await BuildingBussines.NextCodeAsync(),
        //                        };

        //                        _driver.FindElements(By.ClassName("kt-post-card__body"))[i]?.Click();
        //                        await Utility.Wait(3);

        //                        //Region
        //                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
        //                        if (!string.IsNullOrEmpty(fullText))
        //                        {
        //                            var indexRemovedCity = fullText.IndexOf('،');
        //                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
        //                            var indexRemovedCat = removedCity.IndexOf('|');
        //                            var regionName = removedCity.Remove(indexRemovedCat - 1,
        //                                removedCity.Length - indexRemovedCat + 1);

        //                            var region = await RegionsBussines.GetAsync(regionName);
        //                            if (region == null)
        //                            {
        //                                region = new RegionsBussines()
        //                                {
        //                                    Guid = Guid.NewGuid(),
        //                                    Name = regionName,
        //                                    Modified = DateTime.Now,
        //                                    Status = true,
        //                                    CityGuid = city.Guid
        //                                };
        //                                await region.SaveAsync();
        //                            }

        //                            viewModel.RegionGuid = region.Guid;
        //                            viewModel.CityGuid = city.Guid;
        //                            viewModel.Address = regionName;


        //                            //BuildingType
        //                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
        //                                .Replace("|", "")
        //                                .Trim();
        //                            var type = await BuildingTypeBussines.GetAsync(typeName);
        //                            if (type == null)
        //                            {
        //                                type = new BuildingTypeBussines()
        //                                {
        //                                    Guid = Guid.NewGuid(),
        //                                    Name = typeName,
        //                                    Modified = DateTime.Now,
        //                                    Status = true
        //                                };
        //                                await type.SaveAsync();
        //                            }

        //                            viewModel.BuildingTypeGuid = type.Guid;
        //                        }



        //                        var mList = _driver.FindElements(By.ClassName("kt-group-row-item__value")).ToList();

        //                        //Metrazh
        //                        viewModel.Masahat = mList[0].Text.FixString().ParseToInt();

        //                        //SaleSakht
        //                        viewModel.SaleSakht = mList[1].Text.FixString();

        //                        //RoomCount
        //                        viewModel.RoomCount = mList[2].Text.FixString().ParseToInt();

        //                        if (mList.Count == 6)
        //                        {
        //                            viewModel.OptionList = new List<BuildingRelatedOptionsBussines>();

        //                            //Asansor
        //                            if (!mList[3].Text.Contains("ندارد"))
        //                            {
        //                                var evelator = await BuildingOptionsBussines.GetAsync("آسانسور");
        //                                if (evelator == null)
        //                                {
        //                                    evelator = new BuildingOptionsBussines()
        //                                    {
        //                                        Guid = Guid.NewGuid(),
        //                                        Modified = DateTime.Now,
        //                                        Name = "آسانسور",
        //                                        Status = true
        //                                    };
        //                                    await evelator.SaveAsync();
        //                                }

        //                                var op1 = new BuildingRelatedOptionsBussines()
        //                                {
        //                                    Guid = Guid.NewGuid(),
        //                                    Modified = DateTime.Now,
        //                                    BuildingOptionGuid = evelator.Guid,
        //                                    BuildinGuid = viewModel.Guid
        //                                };
        //                                viewModel.OptionList.Add(op1);
        //                            }

        //                            //Parking
        //                            if (!mList[4].Text.Contains("ندارد"))
        //                            {
        //                                var parking = await BuildingOptionsBussines.GetAsync("پارکینگ");
        //                                if (parking == null)
        //                                {
        //                                    parking = new BuildingOptionsBussines()
        //                                    {
        //                                        Guid = Guid.NewGuid(),
        //                                        Modified = DateTime.Now,
        //                                        Name = "پارکینگ",
        //                                        Status = true
        //                                    };
        //                                    await parking.SaveAsync();
        //                                }

        //                                var op2 = new BuildingRelatedOptionsBussines()
        //                                {
        //                                    Guid = Guid.NewGuid(),
        //                                    Modified = DateTime.Now,
        //                                    BuildingOptionGuid = parking.Guid,
        //                                    BuildinGuid = viewModel.Guid
        //                                };
        //                                viewModel.OptionList.Add(op2);
        //                            }

        //                            //Anbari
        //                            if (!mList[5].Text.Contains("ندارد"))
        //                            {
        //                                var anbari = await BuildingOptionsBussines.GetAsync("انباری");
        //                                if (anbari == null)
        //                                {
        //                                    anbari = new BuildingOptionsBussines()
        //                                    {
        //                                        Guid = Guid.NewGuid(),
        //                                        Modified = DateTime.Now,
        //                                        Name = "انباری",
        //                                        Status = true
        //                                    };
        //                                    await anbari.SaveAsync();
        //                                }

        //                                var op3 = new BuildingRelatedOptionsBussines()
        //                                {
        //                                    Guid = Guid.NewGuid(),
        //                                    Modified = DateTime.Now,
        //                                    BuildingOptionGuid = anbari.Guid,
        //                                    BuildinGuid = viewModel.Guid
        //                                };
        //                                viewModel.OptionList.Add(op3);
        //                            }
        //                        }

        //                        var pList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value"))
        //                            .ToList();

        //                        //Rahn
        //                        var p1 = pList[0]?.Text.FixString()?.Replace("تومان", "")?.Replace("٫", "");
        //                        viewModel.RahnPrice1 = p1.ParseToDecimal() * 10;


        //                        //Ejare
        //                        if (pList[1]?.Text == "مجانی")
        //                            viewModel.EjarePrice1 = 0;
        //                        else
        //                        {
        //                            var p2 = pList[1]?.Text.FixString()?.Replace("تومان", "")?.Replace("٫", "");
        //                            viewModel.EjarePrice1 = p2.ParseToDecimal() * 10;
        //                        }


        //                        //Rental
        //                        if (pList.Count >= 4)
        //                        {
        //                            var rent = pList[3]?.Text;
        //                            if (!string.IsNullOrEmpty(rent))
        //                            {
        //                                var rental = await RentalAuthorityBussines.GetAsync(rent);
        //                                if (rental == null)
        //                                {
        //                                    rental = new RentalAuthorityBussines()
        //                                    {
        //                                        Guid = Guid.NewGuid(),
        //                                        Name = rent,
        //                                        Modified = DateTime.Now,
        //                                        Status = true
        //                                    };

        //                                    await rental.SaveAsync();
        //                                }

        //                                viewModel.RentalAutorityGuid = rental.Guid;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            var allrent = await RentalAuthorityBussines.GetAllAsync(new CancellationToken());
        //                            var rentRand = new Random().Next(0, allrent.Count);
        //                            viewModel.RentalAutorityGuid = allrent[rentRand].Guid;
        //                        }

        //                        //Tabaqe
        //                        if (pList.Count == 6)
        //                        {
        //                            if (pList[5].Text.Contains("از"))
        //                            {
        //                                if (pList[5].Text.Contains("همکف"))
        //                                {
        //                                    var a = pList[5].Text.Replace("همکف از", "");
        //                                    viewModel.TabaqeNo = 0;
        //                                    viewModel.TedadTabaqe = a.FixString().ParseToInt();
        //                                }
        //                                else
        //                                {
        //                                    var a = pList[5].Text.Replace("از", "");
        //                                    viewModel.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
        //                                    viewModel.TedadTabaqe = a.Remove(0, 2).FixString().ParseToInt();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                viewModel.TabaqeNo = pList[5].Text.FixString().ParseToInt();
        //                                viewModel.TedadTabaqe = viewModel.TabaqeNo;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            viewModel.TabaqeNo = 0;
        //                            viewModel.TedadTabaqe = 0;
        //                        }


        //                        //Description
        //                        viewModel.ShortDesc = _driver.FindElement(By.ClassName("kt-description-row__text"))
        //                            ?.Text;

        //                        var moreDetail = _driver.FindElements(By.ClassName("kt-selector-row__title"))
        //                            .Any(q => q.Text == "نمایش همهٔ جزئیات");
        //                        if (moreDetail)
        //                        {
        //                            _driver.FindElements(By.ClassName("kt-selector-row__title"))
        //                                .FirstOrDefault(q => q.Text == "نمایش همهٔ جزئیات")?.Click();
        //                            await Utility.Wait(2);


        //                            var vahed = _driver.FindElements(By.ClassName("kt-base-row__title"))
        //                                            .FirstOrDefault(q => q.Text == "تعداد واحد در طبقه")?.Text?
        //                                            .ParseToInt() ?? 1;

        //                            var side = GetSide(_driver.FindElements(By.ClassName("kt-base-row__title"))
        //                                                   .FirstOrDefault(q => q.Text == "جهت ساختمان")?.Text ??
        //                                               "");

        //                            viewModel.Side = side;
        //                            viewModel.VahedPerTabaqe = vahed;

        //                            _driver.FindElement(By.ClassName("kt-modal__close-button"))?.Click();
        //                        }


        //                        //Images
        //                        viewModel.GalleryList = new List<BuildingGalleryBussines>();
        //                        var imgElements = _driver.FindElements(By.TagName("img"));
        //                        foreach (var img in imgElements)
        //                        {
        //                            var src = img.GetAttribute("src");
        //                            if (src.Contains("s100.divarcdn.com"))
        //                            {
        //                                var path = Path.Combine(Application.StartupPath, "Images");
        //                                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        //                                var name = Guid.NewGuid() + ".jpg";
        //                                var filePath = Path.Combine(path, name);
        //                                DownloadImage(src, filePath);
        //                                var im = new BuildingGalleryBussines()
        //                                {
        //                                    Guid = Guid.NewGuid(),
        //                                    Modified = DateTime.Now,
        //                                    ImageName = name,
        //                                    BuildingGuid = viewModel.Guid
        //                                };
        //                                viewModel.GalleryList.Add(im);
        //                            }
        //                        }



        //                        var allOwner = await PeoplesBussines.GetAllAsync(new CancellationToken());
        //                        if (allOwner.Count > 0)
        //                        {
        //                            var rand = new Random().Next(0, allOwner.Count);
        //                            viewModel.OwnerGuid = allOwner[rand].Guid;
        //                        }

        //                        viewModel.SellPrice = 0;
        //                        viewModel.VamPrice = 0;
        //                        viewModel.QestPrice = 0;
        //                        viewModel.Dang = 6;

        //                        var allDoc = await DocumentTypeBussines.GetAllAsync(new CancellationToken());
        //                        var docRand = new Random().Next(0, allDoc.Count);
        //                        viewModel.DocumentType = allDoc[docRand].Guid;

        //                        viewModel.Tarakom = EnTarakom.Min;
        //                        viewModel.RahnPrice2 = 0;
        //                        viewModel.EjarePrice2 = 0;
        //                        viewModel.IsShortTime = false;
        //                        viewModel.IsOwnerHere = false;
        //                        viewModel.PishPrice = 0;
        //                        viewModel.PishTotalPrice = 0;
        //                        viewModel.DeliveryDate = DateTime.Now;
        //                        viewModel.PishDesc = "";
        //                        viewModel.MoavezeDesc = "";
        //                        viewModel.MosharekatDesc = "";
        //                        viewModel.ZirBana = viewModel.Masahat + 15;

        //                        var allCond = await BuildingConditionBussines.GetAllAsync(new CancellationToken());
        //                        var condRand = new Random().Next(0, allCond.Count);
        //                        viewModel.BuildingConditionGuid = allCond[condRand].Guid;

        //                        var allAccType = await BuildingAccountTypeBussines.GetAllAsync(new CancellationToken());
        //                        var accTypeRand = new Random().Next(0, allAccType.Count);
        //                        viewModel.BuildingAccountTypeGuid = allAccType[accTypeRand].Guid;
        //                        viewModel.MetrazhTejari = 0;

        //                        var allView = await BuildingViewBussines.GetAllAsync(new CancellationToken());
        //                        var viewRand = new Random().Next(0, allView.Count);
        //                        viewModel.BuildingViewGuid = allView[viewRand].Guid;

        //                        var allFloor = await FloorCoverBussines.GetAllAsync(new CancellationToken());
        //                        var floorRand = new Random().Next(0, allFloor.Count);
        //                        viewModel.FloorCoverGuid = allFloor[floorRand].Guid;

        //                        var allKitchen = await KitchenServiceBussines.GetAllAsync(new CancellationToken());
        //                        var kitchenRand = new Random().Next(0, allKitchen.Count);
        //                        viewModel.KitchenServiceGuid = allKitchen[kitchenRand].Guid;

        //                        viewModel.Water = EnKhadamati.Mostaqel;
        //                        viewModel.Barq = EnKhadamati.Mostaqel;
        //                        viewModel.Gas = EnKhadamati.Mostaqel;
        //                        viewModel.Tell = EnKhadamati.Mostaqel;

        //                        viewModel.MetrazhKouche = 0;
        //                        viewModel.ErtefaSaqf = 0;
        //                        viewModel.Hashie = 0;

        //                        viewModel.DateParvane =
        //                            Calendar.MiladiToShamsi(Calendar.ShamsiToMiladi(viewModel.SaleSakht)
        //                                .AddYears(-1));
        //                        viewModel.ParvaneSerial = "";

        //                        viewModel.BonBast = false;
        //                        viewModel.MamarJoda = true;

        //                        var allUser = await UserBussines.GetAllAsync(new CancellationToken());
        //                        var userRand = new Random().Next(0, allUser.Count);
        //                        viewModel.UserGuid = allUser[userRand].Guid;


        //                        await viewModel.SaveAsync();

        //                        _driver.Navigate().Back();
        //                    }

        //                    ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        //                    await Utility.Wait();
        //                }
        //            }
        //            catch { }
        //        }
        //    }
        //    catch { }
        //}
        
        #endregion
        private static List<Divar> GetDataFromUrl(string url)
        {
            var list = new List<Divar>();
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var o = doc.DocumentNode.SelectNodes("//script[@type='application/ld+json']")?.LastOrDefault();
                var text = o?.InnerText;
                list = JsonConvert.DeserializeObject<List<Divar>>(text);
                foreach (var divar in list)
                {
                    try
                    {
                        var newDoc = web.Load(divar.Url);
                        var o_ = newDoc.DocumentNode.SelectNodes("/html[1]/body[1]/script[1]")?.FirstOrDefault();
                        if (o_ == null) continue;
                        var text_ = o_.InnerText.Replace(@"\", "").Replace("window.production = true;", "")
                            .Replace("window.__PRELOADED_STATE__ = \"{", "{")
                            .Replace(",\"PERFORMANCE_MONITOR_RULE\":\"[0۰]$\"}\";", "}");
                        var index = text_.IndexOf("  window.env");
                        text_ = text_.Remove(index - 3);
                        index = text_.IndexOf(",\"exitLinkWarn");
                        var index2 = text_.IndexOf("u003Cu002Fau003Eu003Cu002Fpu003E\"");
                        text_ = text_.Remove(index, index2 - index).Replace("u003Cu002Fau003Eu003Cu002Fpu003E\"", "");
                        var root = JObject.Parse(text_);
                        var guestValues = root["currentPost"]["post"]["widgets"]["listData"];
                        divar.listData = JsonConvert.DeserializeObject<List<ListData>>(guestValues.ToString());
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        private async Task<string> GetNumberAsync()
        {
            var res = "";
            try
            {
                await Utility.Wait(2);
                _driver.FindElement(By.ClassName("post-actions__get-contact")).Click();
                await Utility.Wait(1.5);

                var a = _driver.FindElements(By.ClassName("kt-button"))
                    .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم");
                if (a != null)
                    _driver.FindElements(By.ClassName("kt-button"))
                        .FirstOrDefault(q => q.Text == "با قوانین دیوار موافقم")?.Click();
                await Utility.Wait(3);

                var block = _driver.FindElements(By.TagName("p")).Any(q =>
                    q.Text == "دسترسی شما به اطلاعات تماس آگهی‌های دیوار موقتاً محدود شده است.");

                if (block)
                {
                    _driver.FindElements(By.ClassName("no-pointer-event"))?.FirstOrDefault(q => q.Text == "باشه")
                        ?.Click();
                    return "";
                }

                var num = _driver.FindElements(By.ClassName("kt-unexpandable-row__action"))?.FirstOrDefault().Text.FixString();
                if (num != "(پنهان‌شده؛ چت کنید)")
                {
                    if (num.ParseToLong() == 0)
                    {
                        _driver.Navigate().Back();
                        res = "";
                        return res;
                    }
                    res = num;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<List<WebScrapper>> GetAllRentAppartmentAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/rent-apartment?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    try
                    {
                        var web = new WebScrapper()
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar
                        };

                        if (item.listData[2].value == "مجانی") web.EjarePrice = 0;
                        else
                            web.EjarePrice = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal();
                        if (item.listData[6].value.Contains("از"))
                        {
                            if (item.listData[6].value.Contains("همکف"))
                            {
                                var a = item.listData[6].value.Replace("همکف از", "");
                                web.TabaqeNo = 0;
                                web.TabaqeCount = a.FixString().ParseToInt();
                            }
                            else
                            {
                                var a = item.listData[6].value.Replace("از", "");
                                web.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                                web.TabaqeCount = a.Remove(0, 2).FixString().ParseToInt();
                            }
                        }
                        else if (item.listData[6].value == "زیرهمکف")
                        {
                            web.TabaqeNo = -1;
                            web.TabaqeCount = 1;
                        }
                        else
                        {
                            web.TabaqeNo = item.listData[6].value.FixString().ParseToInt();
                            web.TabaqeCount = web.TabaqeNo;
                        }

                        if (item.listData[7].items[0].value.FixString().Contains("ندارد"))
                            web.Evelator = false;
                        else
                            web.Evelator = !string.IsNullOrEmpty(item.listData[7].items[0].value.FixString());
                        if (item.listData[7].items[1].value.FixString().Contains("ندارد"))
                            web.Parking = false;
                        else
                            web.Parking = !string.IsNullOrEmpty(item.listData[7].items[1].value.FixString());
                        if (item.listData[7].items[2].value.FixString().Contains("ندارد"))
                            web.Store = false;
                        else
                            web.Store = !string.IsNullOrEmpty(item.listData[7].items[2].value.FixString());

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "")
                                .Trim();

                            web.BuildingType = typeName.Replace("اجاره ", "");
                        }

                        var pList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value"))
                            .ToList();

                        //Rental
                        if (pList.Count >= 4)
                        {
                            var rent = pList[3]?.Text;
                            if (!string.IsNullOrEmpty(rent))
                                web.RentalAuthority = rent;
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        var moreDetail = _driver.FindElements(By.ClassName("kt-selector-row__title"))
                            .Any(q => q.Text == "نمایش همهٔ جزئیات");
                        if (moreDetail)
                        {
                            _driver.FindElements(By.ClassName("kt-selector-row__title"))
                                .FirstOrDefault(q => q.Text == "نمایش همهٔ جزئیات")?.Click();
                            await Utility.Wait(2);

                            var moreList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value-box"))?.ToList();
                            if (moreList != null && moreList.Count > 0)
                            {
                                if (moreList.Count >= 8)
                                    web.VahedPerTabaqe = moreList[7]?.Text?.FixString().ParseToInt() ?? 1;
                                if (moreList.Count >= 9)
                                    web.BuildingSide = moreList[8]?.Text.FixString() ?? "";
                            }

                            _driver.FindElement(By.ClassName("kt-modal__close-button"))?.Click();
                        }

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllRentVillaAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/rent-villa?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;

                    try
                    {
                        var web = new WebScrapper()
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Evelator = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeCount = 1,
                            TabaqeNo = 1
                        };

                        if (item.listData[2].value == "مجانی") web.EjarePrice = 0;
                        else
                            web.EjarePrice = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal();

                        if (item.listData[6].items[0].value.FixString().Contains("ندارد"))
                            web.Parking = false;
                        else
                            web.Parking = !string.IsNullOrEmpty(item.listData[6].items[0].value.FixString());
                        if (item.listData[6].items[1].value.FixString().Contains("ندارد"))
                            web.Store = false;
                        else
                            web.Store = !string.IsNullOrEmpty(item.listData[6].items[1].value.FixString());
                        if (item.listData[6].items[2].value.FixString().Contains("ندارد"))
                            web.Balcony = false;
                        else
                            web.Balcony = !string.IsNullOrEmpty(item.listData[6].items[2].value.FixString());

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "")
                                .Trim();

                            web.BuildingType = typeName.Replace("اجاره ", "");
                        }

                        var pList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value"))
                            .ToList();

                        //Rental
                        if (pList.Count >= 4)
                        {
                            var rent = pList[3]?.Text;
                            if (!string.IsNullOrEmpty(rent))
                                web.RentalAuthority = rent;
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        var moreDetail = _driver.FindElements(By.ClassName("kt-selector-row__title"))
                            .Any(q => q.Text == "نمایش همهٔ جزئیات");
                        if (moreDetail)
                        {
                            _driver.FindElements(By.ClassName("kt-selector-row__title"))
                                .FirstOrDefault(q => q.Text == "نمایش همهٔ جزئیات")?.Click();
                            await Utility.Wait(2);

                            var moreList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value-box"))?.ToList();
                            if (moreList != null && moreList.Count > 0)
                            {
                                if (moreList.Count >= 8)
                                    web.VahedPerTabaqe = moreList[7]?.Text?.FixString().ParseToInt() ?? 1;
                                if (moreList.Count >= 9)
                                    web.BuildingSide = moreList[8]?.Text.FixString() ?? "";
                            }

                            _driver.FindElement(By.ClassName("kt-modal__close-button"))?.Click();
                        }

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllRentOfficeAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/rent-office?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    try
                    {
                        var web = new WebScrapper()
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar
                        };

                        if (item.listData[2].value == "مجانی") web.EjarePrice = 0;
                        else
                            web.EjarePrice = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal();

                        if (item.listData[5].value.Contains("از"))
                        {
                            if (item.listData[5].value.Contains("همکف"))
                            {
                                var a = item.listData[5].value.Replace("همکف از", "");
                                web.TabaqeNo = 0;
                                web.TabaqeCount = a.FixString().ParseToInt();
                            }
                            else
                            {
                                var a = item.listData[5].value.Replace("از", "");
                                web.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                                web.TabaqeCount = a.Remove(0, 2).FixString().ParseToInt();
                            }
                        }
                        else if (item.listData[5].value == "زیرهمکف")
                        {
                            web.TabaqeNo = -1;
                            web.TabaqeCount = 1;
                        }
                        else
                        {
                            web.TabaqeNo = item.listData[5].value.FixString().ParseToInt();
                            web.TabaqeCount = web.TabaqeNo;
                        }

                        if (item.listData[6].items[0].value.FixString().Contains("ندارد"))
                            web.Evelator = false;
                        else
                            web.Evelator = !string.IsNullOrEmpty(item.listData[6].items[0].value.FixString());
                        if (item.listData[6].items[1].value.FixString().Contains("ندارد"))
                            web.Parking = false;
                        else
                            web.Parking = !string.IsNullOrEmpty(item.listData[6].items[1].value.FixString());
                        if (item.listData[6].items[2].value.FixString().Contains("ندارد"))
                            web.Store = false;
                        else
                            web.Store = !string.IsNullOrEmpty(item.listData[6].items[2].value.FixString());

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "")
                                .Trim();

                            web.BuildingType = typeName.Replace("اجاره ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        var moreDetail = _driver.FindElements(By.ClassName("kt-selector-row__title"))
                            .Any(q => q.Text == "نمایش همهٔ جزئیات");
                        if (moreDetail)
                        {
                            _driver.FindElements(By.ClassName("kt-selector-row__title"))
                                .FirstOrDefault(q => q.Text == "نمایش همهٔ جزئیات")?.Click();
                            await Utility.Wait(2);

                            var moreList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value-box"))?.ToList();
                            if (moreList != null && moreList.Count > 0)
                            {
                                if (moreList.Count >= 8)
                                    web.VahedPerTabaqe = moreList[7]?.Text?.FixString().ParseToInt() ?? 1;
                                if (moreList.Count >= 9)
                                    web.BuildingSide = moreList[8]?.Text.FixString() ?? "";
                            }

                            _driver.FindElement(By.ClassName("kt-modal__close-button"))?.Click();
                        }

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllRentStoreAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/rent-store?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;

                    try
                    {
                        var web = new WebScrapper()
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar
                        };

                        if (item.listData[2].value == "مجانی") web.EjarePrice = 0;
                        else
                            web.EjarePrice = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal();

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "")
                                .Trim();

                            web.BuildingType = typeName.Replace("اجاره ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllRentIndustrialAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/rent-industrial-agricultural-property?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || (item.listData[0].items?.Count ?? 0) < 2) continue;
                    try
                    {
                        var web = new WebScrapper()
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar
                        };

                        if (item.listData[0].items.Count >= 3)
                            web.RoomCount = item.listData[0].items[2].value.FixString().ParseToInt();

                        if (item.listData[2].value == "مجانی") web.EjarePrice = 0;
                        else
                            web.EjarePrice = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal();

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "")
                                .Trim();

                            web.BuildingType = typeName.Replace("اجاره ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        public async Task<List<WebScrapper>> GetAllBuyAppartmentAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/buy-apartment?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || item.listData.Count <= 5) continue;
                    try
                    {
                        var web = new WebScrapper()
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = 0,
                            EjarePrice = 0,
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar
                        };

                        if (item.listData[4].value.Contains("از"))
                        {
                            if (item.listData[4].value.Contains("همکف"))
                            {
                                var a = item.listData[4].value.Replace("همکف از", "");
                                web.TabaqeNo = 0;
                                web.TabaqeCount = a.FixString().ParseToInt();
                            }
                            else
                            {
                                var a = item.listData[4].value.Replace("از", "");
                                web.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                                web.TabaqeCount = a.Remove(0, 2).FixString().ParseToInt();
                            }
                        }
                        else if (item.listData[4].value == "زیرهمکف")
                        {
                            web.TabaqeNo = -1;
                            web.TabaqeCount = 1;
                        }
                        else
                        {
                            web.TabaqeNo = item.listData[4].value.FixString().ParseToInt();
                            web.TabaqeCount = web.TabaqeNo;
                        }

                        if (item.listData[5].items[0].value.FixString().Contains("ندارد"))
                            web.Evelator = false;
                        else
                            web.Evelator = !string.IsNullOrEmpty(item.listData[5].items[0].value.FixString());
                        if (item.listData[5].items[1].value.FixString().Contains("ندارد"))
                            web.Parking = false;
                        else
                            web.Parking = !string.IsNullOrEmpty(item.listData[5].items[1].value.FixString());
                        if (item.listData[5].items[2].value.FixString().Contains("ندارد"))
                            web.Store = false;
                        else
                            web.Store = !string.IsNullOrEmpty(item.listData[5].items[2].value.FixString());

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        web.RentalAuthority = "";

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        var moreDetail = _driver.FindElements(By.ClassName("kt-selector-row__title"))
                            .Any(q => q.Text == "نمایش همهٔ جزئیات");
                        if (moreDetail)
                        {
                            _driver.FindElements(By.ClassName("kt-selector-row__title"))
                                .FirstOrDefault(q => q.Text == "نمایش همهٔ جزئیات")?.Click();
                            await Utility.Wait(2);

                            var moreList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value-box"))?.ToList();
                            if (moreList != null && moreList.Count > 0)
                            {
                                if (moreList.Count >= 8)
                                    web.VahedPerTabaqe = moreList[7]?.Text?.FixString().ParseToInt() ?? 1;
                                if (moreList.Count >= 9)
                                    web.BuildingSide = moreList[8]?.Text.FixString() ?? "";
                            }

                            _driver.FindElement(By.ClassName("kt-modal__close-button"))?.Click();
                        }

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllBuyVillaAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/buy-villa?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || item.listData.Count <= 4) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = 0,
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            Evelator = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeNo = 1,
                            TabaqeCount = 1
                        };

                        if (item.listData[4].items[0].value.FixString().Contains("ندارد"))
                            web.Parking = false;
                        else
                            web.Parking = !string.IsNullOrEmpty(item.listData[4].items[0].value.FixString());
                        if (item.listData[4].items[1].value.FixString().Contains("ندارد"))
                            web.Store = false;
                        else
                            web.Store = !string.IsNullOrEmpty(item.listData[4].items[1].value.FixString());
                        if (item.listData[4].items[2].value.FixString().Contains("ندارد"))
                            web.Balcony = false;
                        else
                            web.Balcony = !string.IsNullOrEmpty(item.listData[4].items[2].value.FixString());

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();
                        var moreDetail = _driver.FindElements(By.ClassName("kt-selector-row__title"))
                            .Any(q => q.Text == "نمایش همهٔ جزئیات");
                        if (moreDetail)
                        {
                            _driver.FindElements(By.ClassName("kt-selector-row__title"))
                                .FirstOrDefault(q => q.Text == "نمایش همهٔ جزئیات")?.Click();
                            await Utility.Wait(2);

                            var moreList = _driver.FindElements(By.ClassName("kt-unexpandable-row__value-box"))?.ToList();
                            if (moreList != null && moreList.Count > 0)
                            {
                                if (moreList.Count >= 8)
                                    web.VahedPerTabaqe = moreList[7]?.Text?.FixString().ParseToInt() ?? 1;
                                if (moreList.Count >= 9)
                                    web.BuildingSide = moreList[8]?.Text.FixString() ?? "";
                            }

                            _driver.FindElement(By.ClassName("kt-modal__close-button"))?.Click();
                        }

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllBuyOldHouseAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/buy-old-house?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = item.listData[0].value.FixString().ParseToInt(),
                            RahnPrice = 0,
                            RoomCount = 0,
                            SaleSakht = "",
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            Evelator = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeNo = 1,
                            TabaqeCount = 1,
                            Parking = false,
                            Balcony = false,
                            Store = false
                        };

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllBuyOfficeAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/buy-office?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = 0,
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal(),
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                        };

                        if (item.listData.Count > 6)
                        {
                            if (item.listData[5].value.Contains("از"))
                            {
                                if (item.listData[5].value.Contains("همکف"))
                                {
                                    var a = item.listData[5].value.Replace("همکف از", "");
                                    web.TabaqeNo = 0;
                                    web.TabaqeCount = a.FixString().ParseToInt();
                                }
                                else
                                {
                                    var a = item.listData[5].value.Replace("از", "");
                                    web.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                                    web.TabaqeCount = a.Remove(0, 2).FixString().ParseToInt();
                                }
                            }
                            else if (item.listData[5].value == "زیرهمکف")
                            {
                                web.TabaqeNo = -1;
                                web.TabaqeCount = 1;
                            }
                            else
                            {
                                web.TabaqeNo = item.listData[5].value.FixString().ParseToInt();
                                web.TabaqeCount = web.TabaqeNo;
                            }

                            if (item.listData[6].items[0].value.FixString().Contains("ندارد"))
                                web.Evelator = false;
                            else
                                web.Evelator = !string.IsNullOrEmpty(item.listData[6].items[0].value.FixString());
                            if (item.listData[6].items[1].value.FixString().Contains("ندارد"))
                                web.Parking = false;
                            else
                                web.Parking = !string.IsNullOrEmpty(item.listData[6].items[1].value.FixString());
                            if (item.listData[6].items[2].value.FixString().Contains("ندارد"))
                                web.Store = false;
                            else
                                web.Store = !string.IsNullOrEmpty(item.listData[6].items[2].value.FixString());
                        }
                        else
                        {
                            web.TabaqeNo = 1;
                            web.TabaqeCount = 1;

                            web.Evelator = false;
                            web.Parking = false;
                            web.Store = false;
                        }

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllBuyStoreAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/buy-store?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = 0,
                            RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "")
                                .ParseToDecimal(),
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeNo = 1,
                            TabaqeCount = 1,
                            Evelator = false,
                            Parking = false,
                            Store = false,
                        };

                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllBuyIndustrialAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/buy-industrial-agricultural-property?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || (item.listData[0].items?.Count ?? 0) <= 1) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                            RahnPrice = 0,
                            SaleSakht = item.listData[0].items[1].value.FixString(),
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "")
                                .ParseToDecimal(),
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeNo = 1,
                            TabaqeCount = 1,
                            Evelator = false,
                            Parking = false,
                            Store = false,
                            RoomCount = item.listData[0].items.Count == 3
                                ? item.listData[0].items[2].value.FixString().ParseToInt()
                                : 0,
                        };
                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";


                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        public async Task<List<WebScrapper>> GetAllContributionConstructionAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/contribution-construction?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || listDivar.Count <= 0) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = 0,
                            RahnPrice = 0,
                            SaleSakht = "",
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeNo = 1,
                            TabaqeCount = 1,
                            Evelator = false,
                            Parking = false,
                            Store = false,
                            RoomCount = 0,
                        };
                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";

                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<WebScrapper>> GetAllPreSellAsync()
        {
            var list = new List<WebScrapper>();
            try
            {
                var url = $"https://divar.ir/s/mashhad/pre-sell-home?user_type=personal";
                var listDivar = GetDataFromUrl(url);
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || listDivar.Count <= 0) continue;
                    try
                    {
                        var web = new WebScrapper
                        {
                            Masahat = 0,
                            RahnPrice = 0,
                            SaleSakht = "",
                            State = "خراسان رضوی",
                            City = "مشهد",
                            Guid = Guid.NewGuid(),
                            SellPrice = 0,
                            Balcony = false,
                            DateM = DateTime.Now,
                            Type = AdvertiseType.Divar,
                            TabaqeNo = 1,
                            TabaqeCount = 1,
                            Evelator = false,
                            Parking = false,
                            Store = false,
                            RoomCount = 0,
                        };
                        _driver.Navigate().GoToUrl(item.Url);

                        //Title
                        web.Title = _driver.FindElement(By.ClassName("kt-page-title__title--responsive-sized"))?.Text.FixString() ?? "";

                        //Region
                        var fullText = _driver.FindElement(By.ClassName("kt-page-title__subtitle"))?.Text;
                        if (!string.IsNullOrEmpty(fullText))
                        {
                            var indexRemovedCity = fullText.IndexOf('،');
                            var removedCity = fullText.Remove(0, indexRemovedCity + 1);
                            var indexRemovedCat = removedCity.IndexOf('|');
                            var regionName = removedCity.Remove(indexRemovedCat - 1,
                                removedCity.Length - indexRemovedCat + 1);

                            web.Region = regionName;


                            //BuildingType
                            var typeName = removedCity.Replace(regionName, "").Replace("اجاره", "")
                                .Replace("|", "").Trim();

                            web.BuildingType = typeName.Replace("فروش ", "");
                        }

                        //Description
                        web.Description = _driver.FindElement(By.ClassName("kt-description-row__text"))?.Text;
                        web.Number = await GetNumberAsync();

                        //Images
                        var imgElements = _driver.FindElements(By.TagName("img"));
                        var imgList = new List<string>();
                        foreach (var img in imgElements)
                        {
                            var src = img.GetAttribute("src");
                            if (src.Contains("s100.divarcdn.com"))
                                imgList.Add(src);
                        }

                        web.ImagesList = Json.ToStringJson(imgList);

                        list.Add(web);
                    }
                    catch (Exception ex)
                    {
                        WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    }
                }
                _driver.Navigate().GoToUrl("https://divar.ir");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
