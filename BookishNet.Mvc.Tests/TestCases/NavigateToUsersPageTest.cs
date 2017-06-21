using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToUsersPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToUsersPage()
        {
            Thread.Sleep(2000);
            Page.Login.FollowUsersLink();

            Thread.Sleep(5000);
            Assert.AreEqual("Cauta un utilizator", Page.Users.GetPermanentText().Text);
        }
    }
}