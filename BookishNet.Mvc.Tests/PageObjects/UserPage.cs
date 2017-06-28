using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class UserPage : HomePage
    {
        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > div > div:nth-child(2) > button")]
        [CacheLookup]
        private IWebElement ContactUserButton { get; set; }

        public IWebElement GetContactUserButton()
        {
            return ContactUserButton;
        }
    }
}