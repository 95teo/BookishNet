using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class NotLoggedBookPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(4) > a")]
        [CacheLookup]
        private IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > h3:nth-child(2)")]
        [CacheLookup]
        private IWebElement PermanentText { get; set; }

        public string GetPermanentText()
        {
            return PermanentText.Text;
        }
    }
}