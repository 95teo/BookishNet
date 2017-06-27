using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class OpenAppTest : OpenCloseSelenium
    {
        [Test]
        public void OpenApp()
        {
            Thread.Sleep(4000);
            Assert.IsTrue(Page.Login.GetLoginButton().Displayed);
        }
    }
}