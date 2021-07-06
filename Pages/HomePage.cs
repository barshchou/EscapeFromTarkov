using EscapeFromTarkov.core.driver;
using EscapeFromTarkov.core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EscapeFromTarkov.Pages
{
    public class HomePage : BasePage
    {
        private Application app;

        public HomePage(Application app) : base(app)
        {
            this.app = app;
            Application.Driver.Navigate().GoToUrl(BrowserConfig.BaseUrl);
        }

        private IWebElement NewsButton => _driver.FindElement(By.XPath("//a[contains(text(), 'News')]"));
        private IWebElement MerchButton => _driver.FindElement(By.XPath("//a[contains(text(), 'Merch')]"));
        private IWebElement SupportButton => _driver.FindElement(By.XPath("//a[contains(text(), 'Support')]"));
        private IWebElement MediaButton => _driver.FindElement(By.XPath("//a[contains(text(), 'Media')]")); 
        private IWebElement MediaContentPoster => _driver.FindElement(By.XPath("//ul[@id = 'media-list']//a[1]"));  
        private IWebElement MediaPlayerPlayButton => _driver.FindElement(By.XPath("//div[@class = 'slide']//a"));
        private IWebElement PlayerFrame => _driver.FindElement(By.XPath("//div[@class = 'video-content slide-content video-playing']/iframe")); 
        private IWebElement YTPlayButton => _driver.FindElement(By.XPath("//div[@class = 'ytp-left-controls']/button"));
        private IWebElement MediaPlayerCloseButton => _driver.FindElement(By.XPath("//a[@class = 'close']"));

        public void OpenNews() => Click(NewsButton);
        public void ScrollToMedia() => Click(MediaButton);
        public void ClickMediaContentPoster() => Click(MediaContentPoster);
        public void ClickMdeiaPlayerPlayButton() => Click(MediaPlayerPlayButton);
        public void ClickYTPlayButton() => Click(YTPlayButton);
        public void ClickMdeiaPlayerCloseButton() => Click(YTPlayButton);

        public MerchPage OpenMerchPage()
        {
            Click(MerchButton);
            SwitchTab();
            return new MerchPage(app);
        }

        public SupportPage OpenSupportPage()
        {
            Click(SupportButton);
            return new SupportPage(app);
        }

        public void SwitchTab(int i = 1)
        {
            WaitHelper.PollingWait(() => _driver.WindowHandles.Count == i + 1);
            _driver.SwitchTo().Window(_driver.WindowHandles[i]);
            WaitHelper.PollingWait(() => _driver.Url != null);
        }

        public void CloseTab()
        {
            SwitchTab();
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        }


        /// <summary>
        /// Open first video, play for a second, pause and close player
        /// </summary>
        public void PlayMedia()
        {
            ScrollToMedia();
            ClickMediaContentPoster();
            ClickMdeiaPlayerPlayButton();
            _driver.SwitchTo().Frame(PlayerFrame);
            ShowHiddenPlayerButton();
            ClickYTPlayButton();
            CloseMediaPlayer();

        }

        /// <summary>
        /// Close Media Player
        /// </summary>
        public void CloseMediaPlayer()
        {
            _driver.SwitchTo().DefaultContent();
            WaitUntilElementIsPresent(By.XPath("//a[@class = 'close']"));
            Click(MediaPlayerCloseButton);
        }

        public void ShowHiddenPlayerButton()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(YTPlayButton).Build().Perform();
        }


        public bool IsNewsDisplayed() => _driver.FindElements(By.XPath("//h2[contains(text(), 'News')]")).Count > 0;

    }
}
