﻿using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class LogInTest : OpenCloseSelenium
    {
        [Test]
        public void Login()
        {
            Thread.Sleep(2000);
            var loginPage = new LoginPage();
            PageFactory.InitElements(Driver, loginPage);
            loginPage.Login("teo", "teo");
            //Assert.IsTrue(homePage.loginButton.Displayed);
        }
    }
}