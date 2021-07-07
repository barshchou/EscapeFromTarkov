using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class PreorderPage : BasePage
    {
        private Application app;
        public PreorderPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement PreorderButton(string edition) => _driver.FindElement(By.XPath($"//div[@class = 'button'][@data-selected = '{edition}']"));

        //table-cell

        public void ClickPreorder(string edition)
        {
            Click(PreorderButton(edition));
            WaitUntilElementIsPresent(By.XPath("//div[@class = 'close']"));
        }
            

        public bool IsLoginRequiredModalDisplayed() => IsElementPresent(By.XPath("//div[@id = 'modal']//h4[contains(text(), 'You need to register first, and then log in to your account.')]"));
    }
}
