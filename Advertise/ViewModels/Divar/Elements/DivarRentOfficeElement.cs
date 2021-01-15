using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Advertise.ViewModels.Divar.Elements
{
    public class DivarRentOfficeElement
    {
        private IWebDriver _drivers;

        [System.Obsolete]
        public DivarRentOfficeElement(IWebDriver driver)
        {
            _drivers = driver;
            PageFactory.InitElements(driver, this);
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
    }
}
