using EscapeFromTarkov.core;
using NUnit.Framework;

namespace Kinopoisk.Tests
{

    [TestFixture, Parallelizable(ParallelScope.All)]
    public class HomePageTests : TestBase
    {

        [TestCase]
        public void GeneralTest()
        {
            Driver.HomePage.OpenNews();
            Assert.IsTrue(Driver.HomePage.IsNewsDisplayed(), "New Section is not displayed");
        }

        [TestCase]
        public void PlayMediaTest()
        {
            Driver.HomePage.PlayMedia();
        }

        [TestCase]
        public void CheckBooksMerchPriceTest()
        {
            var price = 260;
            var merchPage = Driver.HomePage.OpenMerchPage();
            var booksPage = merchPage.OpenBooksCategory();
            Assert.IsTrue(booksPage.IsPriceEqual("Книга \"Хозяин Ночи\" Цифровое издание (Русская версия)", price), "Price is not correspond to expected or not displayed");
        }

        [TestCase]
        public void SupportTest()
        {
            var topicName = "Error 208";
            var supportPage = Driver.HomePage.OpenSupportPage();
            var kbPage = supportPage.SearchTopic(topicName);
            Assert.IsTrue(kbPage.IsTopicOpened(topicName), "Page is not displayed");

        }
    }
}
