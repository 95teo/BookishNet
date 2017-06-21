using System.Threading;
using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class BooksPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(2) > input")]
        [CacheLookup]
        private IWebElement FilterByTitleInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(3) > input")]
        [CacheLookup]
        private IWebElement FilterByAuthorInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(4) > input")]
        [CacheLookup]
        private IWebElement FilterByPublishingYearInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(1) > div > div > h3 > p > a")]
        [CacheLookup]
        private IWebElement FirstBookLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[1]/h4")]
        [CacheLookup]
        private IWebElement PermanentText { get; set; }

        public IWebElement GetPermanentText()
        {
            return PermanentText;
        }

        public void FillTitleInput(string title)
        {
            FilterByTitleInput.EnterText(title, "FilterByTitleInput");
        }

        public void FillAuthorInput(string author)
        {
            FilterByAuthorInput.EnterText(author, "FilterByAuthorInput");
        }

        public void FillYearInput(string year)
        {
            FilterByPublishingYearInput.EnterText(year, "FilterByPublishingYearInput");
        }

        public void FollowFirstBookLink()
        {
            Thread.Sleep(3000);
            FirstBookLink.ClickOnIt("FirstBookLink");
        }
    }
}