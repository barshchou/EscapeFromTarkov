using EscapeFromTarkov.core.driver;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace EscapeFromTarkov.Pages
{
    public class RatingsPage : BasePage
    {
        private Application app;
        public RatingsPage(Application app) : base(app)
        {
            this.app = app;
        }

        private IWebElement RatingCategoryDropdown => _driver.FindElement(By.XPath($"//div[@data-name= 'category']"));
        private IWebElement RatingCategory(string category) => _driver.FindElement(By.XPath($"//li[@data-val = '{category}']"));
        private ReadOnlyCollection<IWebElement> TableColumnValues(string columnName) => _driver.FindElements(By.XPath($"//td[@data-col-name = '{columnName}']"));

        public void SelectRatingCategory(string category) => Click(RatingCategory(category));
        public void ClickRatingDropdown() => Click(RatingCategoryDropdown);

        public bool IsKillsRatingSorted(string category, string columnName)
        {
            OpenCategory(category);

            var valuesList = TableColumnValues(columnName);
            var result = true;
            for (int i = 0; i < valuesList.Count - 1; i++)
            {
                if (int.Parse(valuesList[i].Text) >= int.Parse(valuesList[i + 1].Text))
                {
                    continue;
                }
                result = false;
                break;
            }
            return result;
        }

        public bool IsCorrectEntriesAmountDisplayed(string columnName, int expectedValueAmount) => TableColumnValues(columnName).Count == expectedValueAmount;

        public bool IsLevelValidNumber(string category, string columnName)
        {
            OpenCategory(category);

            var valuesList = TableColumnValues(columnName);
            var result = true;
            
            for (int i = 0; i < valuesList.Count; i++)
            {
                var numberString = valuesList[i].Text;

                if (!int.TryParse(numberString, out int number))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public void OpenCategory(string category)
        {
            ClickRatingDropdown();
            SelectRatingCategory(category);
            WaitUntilElementIsPresent(By.XPath("//g[@id = 'circle1']"));
        }

    }
}
