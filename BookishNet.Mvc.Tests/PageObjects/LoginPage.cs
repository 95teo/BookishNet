﻿using System.Threading;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class LoginPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(4) > a")]
        private IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.Id, Using = "user")]
        private IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > div.form-box > form > button")]
        private IWebElement LoginButton { get; set; }

        public IWebElement GetLoginButton()
        {
            return LoginButton;
        }

        public void FollowRegisterLink()
        {
            RegisterLink.ClickOnIt("RegisterLink");
        }

        public void Login(string username, string password)
        {
            UsernameInput.EnterText(username, "UsernameInput");
            PasswordInput.EnterText(password, "PasswordInput");
            Thread.Sleep(2000);
            LoginButton.ClickOnIt("LoginButton");
        }
    }
}