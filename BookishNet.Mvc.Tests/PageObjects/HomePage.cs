﻿using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PagePartials;
using BookishNet.Mvc.Tests.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class HomePage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(1) > a")]
        public new IWebElement BooksLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(2) > a")]
        public new IWebElement UsersLink { get; set; }

        [FindsBy(How = How.Id, Using = "single-button")]
        private IWebElement ProfileDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "# bs-example-navbar-collapse-1 > ul > li > ul > li:nth-child(1) > a")]
        private new IWebElement HomeLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bs-example-navbar-collapse-1 > ul > li > ul > li:nth-child(2) > a")]
        private IWebElement ProfileLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bs-example-navbar-collapse-1 > ul > li > ul > li.ng-scope > a")]
        private IWebElement LogoutLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='MessageField']")]
        private IWebElement MessageInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='container']/div/div/div/div/div/button")]
        private IWebElement SendMessageButton { get; set; }

        private IWebElement Message { get; set; }

        public new void FollowBooksLink()
        {
            BooksLink.ClickOnIt("BooksLink");
        }

        public new void FollowUsersLink()
        {
            UsersLink.ClickOnIt("UsersLink");
        }

        public void ExpandDropdown()
        {
            ProfileDropdown.Click();
        }

        public new void FollowHomeLink()
        {
            ExpandDropdown();
            HomeLink.ClickOnIt("HomeLink");
        }

        public void OpenUserProfile()
        {
            ExpandDropdown();
            ProfileLink.ClickOnIt("ProfileLink");
        }

        public void Logout()
        {
            ExpandDropdown();
            LogoutLink.ClickOnIt("LogoutLink");
        }

        public void SendMessage(string message)
        {
            MessageInput.EnterText(message, "MessageInput");
            SendMessageButton.ClickOnIt("SendMessageButton");
        }

        public IWebElement GetSentMessage()
        {
            Message = BrowserFactory.Driver.FindElement(By.XPath("//*[@id='container']/div/div/div/ul/li[1]"));
            return Message;
        }
    }
}