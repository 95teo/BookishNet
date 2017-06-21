using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookishNet.Mvc.Tests.TestCases
{
    class NavigateToUserPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToUserPage()
        {
            Thread.Sleep(2000);
            Page.Login.Login("John", "john12A");

            Thread.Sleep(3000);
            Page.Home.FollowUsersLink();

            Thread.Sleep(2000);
            Page.Users.FollowFirstUserLink();

            Thread.Sleep(2000);
            Assert.IsTrue(Page.User.GetContactUserButton().IsDisplayed("ContactUserButton"));
        }
    }
}
