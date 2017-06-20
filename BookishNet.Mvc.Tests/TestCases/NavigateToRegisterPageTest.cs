using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToRegisterPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToRegisterPage()
        {
            Thread.Sleep(2000);
            var homePage = new LoginPage();
            PageFactory.InitElements(Driver, homePage);
            homePage.FollowRegisterLink();

            Thread.Sleep(5000);
            var registerPage = new RegisterPage();
            PageFactory.InitElements(Driver, registerPage);
        }
    }
}