using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class WikiPage : BasePage
    {
        private Application app;
        public WikiPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement SearchField => _driver.FindElement(By.XPath("//input[@type = 'search']"));
        private IWebElement SearchSubmit => _driver.FindElement(By.XPath("//div[@id = 'simpleSearch']/input[@type = 'submit']"));

        public WikiSearchResultsPage SearchTopic(string topic)
        {
            Type(topic, SearchField);
            Click(SearchSubmit);
            return new WikiSearchResultsPage(app);
        }
    }
}
