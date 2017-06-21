﻿using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToBooksPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToBooksPage()
        {
            Thread.Sleep(2000);
            Page.Login.FollowBooksLink();

            Thread.Sleep(5000);
            Assert.AreEqual("Cauta cartea preferata", Page.Books.GetPermanentText().Text);
        }
    }
}