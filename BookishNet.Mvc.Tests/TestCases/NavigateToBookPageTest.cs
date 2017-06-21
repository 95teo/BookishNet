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
    class NavigateToBookPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToBookPage()
        {
            Thread.Sleep(2000);
            Page.Login.Login("John", "john12A");

            Thread.Sleep(2000);
            Page.Home.FollowBooksLink();

            Thread.Sleep(5000);
            Page.Books.FollowFirstBookLink();

            Thread.Sleep(2000);
            Assert.IsTrue(Page.Book.GetContactUserButton().IsDisplayed("ContactUserButton"));
        }
    }
}
