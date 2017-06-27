using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToNotLoggedUserPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToNotLoggedUserPage()
        {
            Thread.Sleep(2000);
            Page.Login.FollowUsersLink();

            Thread.Sleep(3000);
            Page.Users.FollowFirstUserLink();

            Thread.Sleep(2000);
            Assert.AreEqual("Ne pare rau, dar pentru aceasta actiune este necesara logarea.",
                Page.NotLoggedUser.GetPermanentText());
        }
    }
}