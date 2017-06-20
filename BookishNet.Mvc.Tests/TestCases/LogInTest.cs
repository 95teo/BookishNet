using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookishNet.Mvc.Tests.TestCases
{
    class LogInTest : OpenCloseSelenium
    {

        [Test]
        public void Login()
        {
            Thread.Sleep(2000);
            var homePage = new HomePage();
            PageFactory.InitElements(Driver, homePage);
            homePage.Login("teo", "teo");
            //Assert.IsTrue(homePage.loginButton.Displayed);

        }

    }
}
