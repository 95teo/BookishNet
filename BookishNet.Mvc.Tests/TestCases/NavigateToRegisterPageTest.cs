using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToRegisterPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToRegisterPage()
        {
            Thread.Sleep(2000);
            Page.Login.FollowRegisterLink();

            Thread.Sleep(5000);
            Assert.IsTrue(Page.Register.GetRegisterButton().IsDisplayed("RegisterButton"));
        }
    }
}