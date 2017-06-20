using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookishNet.Mvc.Tests.PageObjects
{
    class BooksPage: NavbarContent
    {
        [FindsBy(How = How.Id, Using = "user")]
        public IWebElement FilterByTitleInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement FilterByAuthorInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement FilterByPublishingYearInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(1) > div > div > h3 > p > a")]
        public IWebElement FirstBookLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[1]/h4")]
        public IWebElement PermanentText { get; set; }

        public void FillTitleInput(string title)
        {
            FilterByTitleInput.SendKeys(title);
        }

        public void FillAuthorInput(string author)
        {
            FilterByAuthorInput.SendKeys(author);
        }

        public void FillYearInput(string year)
        {
            FilterByPublishingYearInput.SendKeys(year);
        }

        public void FollowFirstBookLink()
        {
            Thread.Sleep(3000);
            FirstBookLink.Click();
        }
    }
}
