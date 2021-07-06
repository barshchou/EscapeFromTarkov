using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTarkov.Pages
{
    public class SupportPage : BasePage
    {
        private Application app;
        public SupportPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement SearchField => _driver.FindElement(By.CssSelector("#main_search"));
        private IWebElement SearchResult(string text) => _driver.FindElement(By.XPath($"//a[contains(text(), '{text}')]"));

        public void ClickSearchResult(string text) => Click(SearchResult(text));

        public KnowledgeBaseTopicPage SearchTopic(string text)
        {
            Type(text, SearchField);
            ClickSearchResult(text);
            return new KnowledgeBaseTopicPage(app);
        }

    }
}
