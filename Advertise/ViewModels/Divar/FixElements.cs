using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Advertise.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Services;

namespace Advertise.ViewModels.Divar
{
    public class FixElements
    {
        private IWebDriver _drivers;

        [System.Obsolete]
        public FixElements(IWebDriver driver)
        {
            _drivers = driver;
            PageFactory.InitElements(driver, this);
        }

        public IWebElement FirsCategory(string cat)
        {
            return _drivers.FindElements(By.ClassName("kt-selector-row__title"))
                .FirstOrDefault(p => p.Text == cat);
        }
        public IWebElement SecondCategory(string cat)
        {
            return _drivers.FindElements(By.ClassName("kt-selector-row__title"))
                .FirstOrDefault(p => p.Text == cat);
        }
        public IWebElement ThirdCategory(string cat)
        {
            return _drivers.FindElements(By.ClassName("kt-selector-row__title"))
                .FirstOrDefault(p => p.Text == cat);
        }
        public IWebElement ImageContainer()
            => _drivers.FindElement(By.ClassName("image-uploader__zone")).FindElement(By.TagName("input"));
        public IWebElement CitySearcher()
            => _drivers.FindElement(By.ClassName("kt-select--searchable"));
        public IWebElement City()
            => _drivers.FindElement(By.ClassName("kt-select__search-field"));
        public IWebElement RegionSearcher()
            => _drivers.FindElements(By.ClassName("kt-select__field--placeholder-shown"))?[0];
        public IWebElement Region()
        {
            var el = _drivers.FindElements(By.ClassName("text-field")).Any(q => q.Text == "محدودهٔ آگهی");
            return el ? _drivers.FindElements(By.ClassName("kt-select__search-field"))?[1] : null;
        }
        public IWebElement Sender_Shakhsi()
            => _drivers.FindElements(By.TagName("input[type=radio]")).FirstOrDefault();
        public IWebElement Sender_Amlak()
            => _drivers.FindElements(By.TagName("input[type=radio]")).LastOrDefault();
        public IWebElement Masahat()
            => _drivers.FindElements(By.TagName("input[type=tel]"))[0];
        public IWebElement Rahn()
            => _drivers.FindElements(By.TagName("input[type=tel]"))[1];
        public IWebElement Sell()
            => _drivers.FindElements(By.TagName("input[type=tel]"))[1];
        public IWebElement Ejare()
            => _drivers.FindElements(By.TagName("input[type=tel]"))[2];
        public IWebElement Tabdil()
            => _drivers.FindElement(By.Id("root_rent_credit_transform"));
        public IWebElement RoomCount()
            => _drivers.FindElement(By.Id("root_rooms"));
        public IWebElement SaleSakht()
            => _drivers.FindElement(By.Id("root_year"));
        public IWebElement Tabaqe()
            => _drivers.FindElement(By.Id("root_floor"));
        public IWebElement Asansor()
            => _drivers.FindElement(By.Id("root_elevator"));
        public IWebElement Parking()
            => _drivers.FindElement(By.Id("root_parking"));
        public IWebElement Anbari()
            => _drivers.FindElement(By.Id("root_warehouse"));
        public IWebElement Balkon()
            => _drivers.FindElement(By.Id("root_balcony"));
        public IWebElement Rental()
            => _drivers.FindElement(By.Id("root_rent_to_single"));
        public IWebElement Chat()
            => _drivers.FindElements(By.ClassName("kt-switch__label"))
                .FirstOrDefault(q => q.Text == "چت دیوار فعال شود");
        public IWebElement Title()
            => _drivers.FindElements(By.TagName("input[type=text]")).Last();
        public List<IWebElement> ImageProgress 
            => _drivers.FindElements(By.ClassName("image-item__progress")).ToList();
        public string Url => _drivers.Url;

        public void SelectDropDown(string text) => _drivers.FindElements(By.ClassName("kt-dropdown-item"))
            ?.FirstOrDefault(q => q.Text == text)?.Click();
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
        public void SendAdv()
        {
            try
            {
                while (ImageProgress.Count>0)
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
