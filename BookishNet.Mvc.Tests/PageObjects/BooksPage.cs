using System.Threading;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class BooksPage : NavbarContent
    {

        [FindsBy(How = How.Id, Using = "user")]
        private IWebElement FilterByTitleInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement FilterByAuthorInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement FilterByPublishingYearInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(1) > div > div > h3 > p > a")]
        private IWebElement FirstBookLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[1]/h4")]
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