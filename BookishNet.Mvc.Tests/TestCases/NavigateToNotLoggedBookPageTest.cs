﻿using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToNotLoggedBookPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToNotLoggedBookPage()
        {
            Thread.Sleep(2000);
            Page.Login.FollowBooksLink();

            Thread.Sleep(5000);
            Page.Books.FollowFirstBookLink();

            Thread.Sleep(2000);
            Assert.AreEqual("Pentru a vedea mai multe detalii despre cartea dorita este necesara logarea.", Page.NotLoggedBook.GetPermanentText());
        }
    }
}