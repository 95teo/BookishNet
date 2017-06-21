using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class LogInTest : OpenCloseSelenium
    {
        [Test]
        public void Login()
        {
            Thread.Sleep(2000);
            Page.Login.Login("teo", "teo");
            Assert.IsTrue(Page.Login.GetLoginButton().IsDisplayed("LoginButton"));
        }
    }
}