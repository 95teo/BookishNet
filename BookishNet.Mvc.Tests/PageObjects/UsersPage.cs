using System.Threading;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    internal class UsersPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(2) > input")]
        public IWebElement FilterByUsernameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(3) > input")]
        public IWebElement FilterByFirstNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(4) > input")]
        public IWebElement FilterBySecondNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(1) > div > div > h3 > p > a")]
        public IWebElement FirstUserLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[1]/h4")]
        public IWebElement PermanentText { get; set; }

        public void FillUsernameInput(string username)
        {
            FilterByUsernameInput.SendKeys(username);
        }

        public void FillFirstNameInput(string firstName)
        {
            FilterByFirstNameInput.SendKeys(firstName);
        }

        public void FillSecondNameInput(string secondName)
        {
            FilterBySecondNameInput.SendKeys(secondName);
        }

        public void FollowFirstUserLink()
        {
            Thread.Sleep(3000);
            FirstUserLink.Click();
        }
    }
}