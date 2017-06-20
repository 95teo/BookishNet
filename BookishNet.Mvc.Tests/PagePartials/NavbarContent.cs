using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookishNet.Mvc.Tests.PagePartials
{
    public abstract class NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > div > a")]
        public IWebElement LogoLink { get; set; }

        // TODO: add an id to home link
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(1) > a")]
        public IWebElement HomeLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(2) > a")]
        public IWebElement BooksLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(3) > a")]
        public IWebElement UsersLink { get; set; }

        public void FollowLogoLink()
        {
            LogoLink.Click();
        }

        public void FollowHomeLink()
        {
            HomeLink.Click();
        }

        public void FollowBooksLink()
        {
            BooksLink.Click();
        }

        public void FollowUsersLink()
        {
            UsersLink.Click();
        }
    }
}
