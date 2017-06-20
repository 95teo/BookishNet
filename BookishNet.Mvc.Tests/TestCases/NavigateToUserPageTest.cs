using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToUserPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToUserPage()
        {
            Thread.Sleep(2000);
            var homePage = new LoginPage();
            PageFactory.InitElements(Driver, homePage);
            homePage.FollowUsersLink();

            Thread.Sleep(5000);
            var usersPage = new UsersPage();
            PageFactory.InitElements(Driver, usersPage);
            usersPage.FollowFirstUserLink();
        }
    }
}