using System.Threading;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class UsersPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(2) > input")]
        private IWebElement FilterByUsernameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(3) > input")]
        private IWebElement FilterByFirstNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(4) > input")]
        private IWebElement FilterBySecondNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(1) > div > div > h3 > p > a")]
        private IWebElement FirstUserLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[1]/h4")]
        private IWebElement PermanentText { get; set; }

        public IWebElement GetPermanentText()
        {
            return PermanentText;
        }

        public void FillUsernameInput(string username)
        {
            FilterByUsernameInput.EnterText(username, "FilterByUsernameInput");
        }

        public void FillFirstNameInput(string firstName)
        {
            FilterByFirstNameInput. EnterText(firstName, "FilterByFirstNameInput");
        }

        public void FillSecondNameInput(string secondName)
        {
            FilterBySecondNameInput.EnterText(secondName, "FilterBySecondNameInput");
        }

        public void FollowFirstUserLink()
        {
            Thread.Sleep(3000);
            FirstUserLink.ClickOnIt("FirstUserLink");
        }
    }
}