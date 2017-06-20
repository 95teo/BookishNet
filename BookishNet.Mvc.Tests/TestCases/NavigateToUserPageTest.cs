﻿using BookishNet.Mvc.Tests.PageObjects;
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
    class NavigateToUserPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToUserPage()
        {
            Thread.Sleep(2000);
            var homePage = new HomePage();
            PageFactory.InitElements(Driver, homePage);
            homePage.FollowUsersLink();

            Thread.Sleep(5000);
            var usersPage = new UsersPage();
            PageFactory.InitElements(Driver, usersPage);
            usersPage.FollowFirstUserLink();
        }
    }
}
