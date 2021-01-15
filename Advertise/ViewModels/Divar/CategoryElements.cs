using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Advertise.ViewModels.Divar
{
    public class CategoryElements
    {
        private IWebDriver _drivers;

        [System.Obsolete]
        public CategoryElements(IWebDriver driver)
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
    }
}
