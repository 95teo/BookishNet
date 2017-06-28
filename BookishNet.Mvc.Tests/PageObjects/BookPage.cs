using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class BookPage : HomePage
    {
        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > ul > li:nth-child(4) > button")]
        [CacheLookup]
        private IWebElement ContactUserButton { get; set; }

        public IWebElement GetContactUserButton()
        {
            return ContactUserButton;
        }
    }
}