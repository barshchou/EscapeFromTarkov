using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class WikiSearchResultsPage : BasePage
    {
        private Application app;
        public WikiSearchResultsPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement AmmoCaliber => _driver.FindElement(By.XPath("//td[contains(text(), 'Caliber')]/following-sibling::td[@class = 'va-infobox-content']/a"));

        public string GetGunCaliber() => AmmoCaliber.Text;

        public bool IsGunCaliberCorrespond(string caliber) => GetGunCaliber().Contains(caliber);
    }
}
