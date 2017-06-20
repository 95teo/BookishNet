using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
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
            var homePage = new HomePage();
            PageFactory.InitElements(Driver, homePage);
            homePage.FollowBooksLink();

            Thread.Sleep(5000);
            var booksPage = new BooksPage();
            PageFactory.InitElements(Driver, booksPage);
            booksPage.FollowFirstBookLink();
        }
    }
}
