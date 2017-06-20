using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class OpenAppTest : OpenCloseSelenium
    {
        [Test]
        public void OpenApp()
        {
            Thread.Sleep(2000);
            var homePage = new LoginPage();
            PageFactory.InitElements(Driver, homePage);
            Assert.IsTrue(homePage.LoginButton.Displayed);
        }
    }
}