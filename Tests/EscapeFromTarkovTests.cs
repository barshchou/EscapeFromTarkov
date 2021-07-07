using EscapeFromTarkov.core;
using NUnit.Framework;

namespace EscapeFromTarkov.Tests
{

    [TestFixture, Parallelizable(ParallelScope.All)]
    public class EscapeFromTarkovTests : TestBase
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

        [TestCase]
        public void WikiTest()
        {
            var ammoCaliber = "5.45x39";
            var topic = "AK-74M";
            var wikiSearchResultsPage = Driver.HomePage.OpenWikiPage().SearchTopic(topic);

            Assert.IsTrue(wikiSearchResultsPage.IsGunCaliberCorrespond(ammoCaliber), "Ammo caliber is not corresponded");
        }

        [TestCase]
        public void PreorderTest()
        {
            var edition = "standard";
            var preorderPage = Driver.HomePage.OpenPreorderPage();
            preorderPage.ClickPreorder(edition);

            Assert.IsTrue(preorderPage.IsLoginRequiredModalDisplayed(), "Login is not required or user is already logged in");
        }

        [TestCase]
        public void RatingTest()
        {
            var category = "kills";
            var killsColumnName = "kills";
            var levelColumnName = "Lvl";
            var ratingsPage = Driver.HomePage.OpenRatingsPage();

            Assert.IsTrue(ratingsPage.IsLevelValidNumber(category, levelColumnName), "Levels are not valid numbers");
            Assert.IsTrue(ratingsPage.IsCorrectEntriesAmountDisplayed(killsColumnName, 100), "Levels are not valid numbers");
            Assert.IsTrue(ratingsPage.IsKillsRatingSorted(category, killsColumnName), "Levels are not valid numbers");

        }
    }
}
