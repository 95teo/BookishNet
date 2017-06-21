using System.Threading;
using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class LogoutTest : OpenCloseSelenium
    {
        [Test]
        public void Logout()
        {
            Thread.Sleep(2000);
            Page.Login.Login("teo", "teo");

            Thread.Sleep(3000);
            Page.Home.Logout();

            Thread.Sleep(3000);
            Assert.IsTrue(Page.Login.GetLoginButton().IsDisplayed("LoginButton"));
        }
    }
}