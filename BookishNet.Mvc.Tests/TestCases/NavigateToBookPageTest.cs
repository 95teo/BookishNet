using System.Threading;
using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToBookPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToBookPage()
        {
            Thread.Sleep(2000);
            Page.Login.Login("John", "john12A");

            Thread.Sleep(3000);
            Page.Home.FollowBooksLink();

            Thread.Sleep(3000);
            Page.Books.FollowFirstBookLink();

            Thread.Sleep(2000);
            Assert.IsTrue(Page.Book.GetContactUserButton().IsDisplayed("ContactUserButton"));
        }
    }
}