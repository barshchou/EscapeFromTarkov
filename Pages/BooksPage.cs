using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;
using System;

namespace EscapeFromTarkov.Pages
{
    public class BooksPage : BasePage
    {
        private Application app;
        public BooksPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement Book(string description) => _driver.FindElement(By.XPath($"//span[@class = 'title'][contains(text(), '{description}')]//ancestor::div[@class = 'tarkov-card']"));
        
        public string GetBookPrice(string description) => Book(description).FindElement(By.XPath("//span[@class = 'price']")).Text;

        public bool IsPriceEqual(string bookDescription, int price)
        {
            var priceUI = int.Parse(GetBookPrice(bookDescription).Split('₽')[0]);
            return priceUI == price;
        }
            

    }
}
