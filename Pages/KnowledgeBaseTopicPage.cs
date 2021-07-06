using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTarkov.Pages
{
    public class KnowledgeBaseTopicPage : BasePage
    {
        private Application app;
        public KnowledgeBaseTopicPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement NameHeadline(string kbName) => _driver.FindElement(By.XPath($"//div[@class = 'header']/h1[contains(text(), '{kbName}')]"));

        public bool IsTopicOpened(string kbName) => NameHeadline(kbName).Displayed;
    }
}
