using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    internal class HomePage : OpenCloseSelenium
    {
        [FindsBy(How = How.Id, Using = "single-button")]
        public IWebElement ProfileDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "# bs-example-navbar-collapse-1 > ul > li > ul > li:nth-child(1) > a")]
        public IWebElement HomeLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bs-example-navbar-collapse-1 > ul > li > ul > li:nth-child(2) > a")]
        public IWebElement ProfileLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bs-example-navbar-collapse-1 > ul > li > ul > li.ng-scope > a")]
        public IWebElement LogoutLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='MessageField']")]
        public IWebElement MessageInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='container']/div/div/div/div/div/button")]
        public IWebElement SendMessageButton { get; set; }

        public void ExpandDropdown()
        {
            ProfileDropdown.Click();
        }

        public void FollowHomeLink()
        {
            ExpandDropdown();
            HomeLink.Click();
        }

        public void OpenUserProfile()
        {
            ExpandDropdown();
            ProfileLink.Click();
        }

        public void Logout()
        {
            ExpandDropdown();
            LogoutLink.Click();
        }

        public void SendMessage(string message)
        {
            MessageInput.SendKeys(message);
            SendMessageButton.Click();
        }
    }
}