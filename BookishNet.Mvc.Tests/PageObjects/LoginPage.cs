using System.Threading;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    internal class LoginPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(4) > a")]
        public IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.Id, Using = "user")]
        public IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > div.form-box > form > button")]
        public IWebElement LoginButton { get; set; }

        public void FollowRegisterLink()
        {
            RegisterLink.Click();
        }

        public void Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            Thread.Sleep(2000);
            LoginButton.Click();
        }
    }
}