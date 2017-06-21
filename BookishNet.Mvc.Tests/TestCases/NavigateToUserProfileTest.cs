using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToUserProfileTest : OpenCloseSelenium
    {
        [Test]
        public void GoToUserProfileTest()
        {
            Thread.Sleep(2000);
            Page.Login.Login("teo", "teo");

            Thread.Sleep(8000);
            Page.Home.OpenUserProfile();

            Thread.Sleep(3000);
            Assert.IsTrue(Page.UserProfile.GetEditButton().IsDisplayed("EditButton"));
        }
    }
}