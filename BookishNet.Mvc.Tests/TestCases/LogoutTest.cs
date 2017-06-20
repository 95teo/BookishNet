using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class LogoutTest : OpenCloseSelenium
    {
        [Test]
        public void Logout()
        {
            /*var loginTest = new LogInTest();
            loginTest.Login();*/
            Thread.Sleep(2000);
            var loginPage = new LoginPage();
            PageFactory.InitElements(Driver, loginPage);
            loginPage.Login("teo", "teo");

            Thread.Sleep(3000);
            var homePage = new HomePage();
            PageFactory.InitElements(Driver, homePage);
            homePage.Logout();

            Thread.Sleep(3000);
            PageFactory.InitElements(Driver, loginPage);
            Assert.IsTrue(loginPage.LoginButton.Displayed);
        }
    }
}