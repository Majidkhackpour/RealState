using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Services;

namespace Advertise.ViewModels.Divar
{
    public class FixElements
    {
        private IWebDriver _drivers;

        public FixElements(IWebDriver driver)
        {
            _drivers = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement FirsCategory(string cat)
            => _drivers.FindElements(By.ClassName("kt-selector-row__title")).FirstOrDefault(p => p.Text == cat);
        public IWebElement SecondCategory(string cat)
            => _drivers.FindElements(By.ClassName("kt-selector-row__title")).FirstOrDefault(p => p.Text == cat);
        public IWebElement ThirdCategory(string cat)
            => _drivers.FindElements(By.ClassName("kt-selector-row__title")).FirstOrDefault(p => p.Text == cat);
        public IWebElement ImageContainer()
            => _drivers.FindElement(By.ClassName("image-uploader__zone")).FindElement(By.TagName("input"));
        public IWebElement CitySearcher() => _drivers.FindElement(By.ClassName("kt-select--searchable"));
        public IWebElement City() => _drivers.FindElement(By.ClassName("kt-select__search-field"));
        public async Task SetRegionAsync(string regionName)
        {
            var regEl = _drivers.FindElements(By.ClassName("text-field")).Any(q => q.Text == "محدودهٔ آگهی");
            if (regEl)
            {
                var element = _drivers.FindElements(By.ClassName("text-field")).FirstOrDefault(q => q.Text == "محدودهٔ آگهی");
                var actions = new Actions(_drivers);
                actions.MoveToElement(element);
                actions.Perform();

                _drivers.FindElements(By.ClassName("kt-select__field-label--placeholder-shown"))?[0].Click();
                await Utility.Wait(2);
                if (!string.IsNullOrEmpty(regionName) && regionName != "-")
                    _drivers.FindElements(By.ClassName("kt-dropdown-item"))?.FirstOrDefault(q => q.Text == regionName)?.Click();
                else
                {
                    var list = _drivers.FindElements(By.ClassName("kt-dropdown-item")).ToList();
                    if (list.Count > 1) list[1]?.Click();
                }
            }
        }
        public IWebElement Sender_Shakhsi() => _drivers.FindElements(By.TagName("input[type=radio]")).FirstOrDefault();
        public IWebElement Sender_Amlak() => _drivers.FindElements(By.TagName("input[type=radio]")).LastOrDefault();
        public IWebElement Masahat() => _drivers.FindElements(By.TagName("input[type=tel]"))[0];
        public IWebElement Rahn() => _drivers.FindElements(By.TagName("input[type=tel]"))[1];
        public IWebElement Sell() => _drivers.FindElements(By.TagName("input[type=tel]"))[1];
        public IWebElement Ejare() => _drivers.FindElements(By.TagName("input[type=tel]"))[2];
        public IWebElement Tabdil(int index) => SelectDropDown(index);
        public IWebElement RoomCount(int index) => SelectDropDown(index);
        public IWebElement SaleSakht(int index) => SelectDropDown(index);
        public IWebElement Tabaqe(int index) => SelectDropDown(index);
        public IWebElement Asansor(int index) => SelectDropDown(index);
        public IWebElement Parking(int index) => SelectDropDown(index);
        public IWebElement Anbari(int index) => SelectDropDown(index);
        public IWebElement Balkon(int index) => SelectDropDown(index);
        public IWebElement Rental(int index) => SelectDropDown(index);
        public IWebElement Chat() => _drivers.FindElements(By.ClassName("kt-switch__label")).FirstOrDefault(q => q.Text == "چت دیوار فعال شود");
        public IWebElement Title() => _drivers.FindElements(By.TagName("input[type=text]")).Last();
        public IWebElement SanadEdari() => _drivers.FindElements(By.ClassName("kt-switch__label")).FirstOrDefault(q => q.Text == "سند اداری");
        public List<IWebElement> ImageProgress => _drivers.FindElements(By.ClassName("image-item__progress")).ToList();
        public string Url => _drivers.Url;
        public void SelectDropDown(string text) => _drivers.FindElements(By.ClassName("kt-dropdown-item"))?.FirstOrDefault(q => q.Text == text)?.Click();
        public void SendContent(string content)
        {
            try
            {
                var thread = new Thread(() => Clipboard.SetText(content));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

                var t = _drivers.FindElement(By.TagName("textarea"));
                t.Click();
                Utility.Wait_(1);
                t.SendKeys(OpenQA.Selenium.Keys.Control + "v");
                var thread1 = new Thread(Clipboard.Clear);
                thread1.SetApartmentState(ApartmentState.STA);
                thread1.Start();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private IWebElement SelectDropDown(int index) => _drivers.FindElements(By.ClassName("kt-select"))?[index];
        public void SendAdv()
        {
            try
            {
                while (ImageProgress.Count > 0)
                    Utility.Wait_(2);

                _drivers.FindElements(By.TagName("button")).FirstOrDefault(q => q.Text.Contains("ارسال آگهی"))
                    ?.Click();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
