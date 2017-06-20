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
    class OpenAppTest : OpenCloseSelenium
    {
        [Test]
        public void OpenApp()
        {
            Thread.Sleep(2000);
            var homePage = new HomePage();
            PageFactory.InitElements(Driver, homePage);
            Assert.IsTrue(homePage.LoginButton.Displayed);
        }
    }
}
