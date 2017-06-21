﻿using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class UserProfilePage : NavbarContent
    {
        [FindsBy(How = How.Id, Using = "single-button")]
        private IWebElement ProfileDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "# bs-example-navbar-collapse-1 > ul > li > ul > li:nth-child(1) > a")]
        private new IWebElement HomeLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bs-example-navbar-collapse-1 > ul > li > ul > li:nth-child(2) > a")]
        private IWebElement ProfileLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#bs-example-navbar-collapse-1 > ul > li > ul > li.ng-scope > a")]
        private IWebElement LogoutLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > div > div:nth-child(2) > button")]
        private IWebElement EditButton { get; set; }

        public IWebElement GetEditButton()
        {
            return EditButton;
        }

        public void ExpandDropdown()
        {
            ProfileDropdown.Click();
        }

        public new void FollowHomeLink()
        {
            ExpandDropdown();
            HomeLink.ClickOnIt("HomeLink");
        }

        public void OpenUserProfile()
        {
            ExpandDropdown();
            ProfileLink.ClickOnIt("ProfileLink");
        }

        public void Logout()
        {
            ExpandDropdown();
            LogoutLink.ClickOnIt("LogoutLink");
        }

        public void OpenProfileEditor()
        {
            EditButton.ClickOnIt("EditButton");
        }
    }
}
