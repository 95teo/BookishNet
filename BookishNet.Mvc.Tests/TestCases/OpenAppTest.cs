using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class OpenAppTest : OpenCloseSelenium
    {
        [Test]
        public void OpenApp()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(Page.Login.GetLoginButton().Displayed);
        }
    }
}