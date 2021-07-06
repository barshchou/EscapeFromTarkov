using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;

namespace EscapeFromTarkov.Pages
{
    public class MerchPage : BasePage
    {
        private Application app;
        public MerchPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement BooksCategory => _driver.FindElement(By.XPath("//p[@class= 'category__title'][contains(text(), 'Книги')]"));

        public BooksPage OpenBooksCategory()
        {
            Click(BooksCategory);
            return new BooksPage(app);
        }
            

    }
}
