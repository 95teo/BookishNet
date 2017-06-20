﻿using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToBookPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToBookPage()
        {
            Thread.Sleep(2000);
            var homePage = new LoginPage();
            PageFactory.InitElements(Driver, homePage);
            homePage.FollowBooksLink();

            Thread.Sleep(5000);
            var booksPage = new BooksPage();
            PageFactory.InitElements(Driver, booksPage);
            booksPage.FollowFirstBookLink();
        }
    }
}