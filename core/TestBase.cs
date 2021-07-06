using EscapeFromTarkov.core.driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EscapeFromTarkov.core
{
    [TestFixture]
    public class TestBase
    {
        protected Application Driver { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.Driver = new Application();

        }

        [TearDown]
        public void TearDown()
        {
            this.Driver.QuitDriver();
        }
    }
}
