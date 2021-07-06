using EscapeFromTarkov.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace EscapeFromTarkov.core.driver
{
    public class Application
    {
        private static ConcurrentDictionary<string, IWebDriver> DriverCollection = new ConcurrentDictionary<string, IWebDriver>();

        public static IWebDriver Driver
        {
            get
            {
                return DriverCollection.First(pair => pair.Key == TestContext.CurrentContext.Test.ID).Value;
            }

            set => DriverCollection.TryAdd(TestContext.CurrentContext.Test.ID, value);
        }

        public WebDriverWait Wait { get; set; }
        public HomePage HomePage { get; set; }

        public Application()
        {
            Driver = CreateDriver();
            HomePage = new HomePage(this);
        }

        private IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-web-security");
            options.AddArguments("--disable-gpu");
            options.AddArguments("start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); //this.Wait
            return driver;
        }


        public void QuitDriver()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
