using System.Threading;
using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class LogInTest : OpenCloseSelenium
    {
        [Test]
        public void Login()
        {
            Thread.Sleep(3000);
            Page.Login.Login("teo", "teo");
            Thread.Sleep(3000);
            Assert.IsTrue(Page.Home.GetPermanentText() == "BookishNet - Aplicatia care te aduce mai aproape de cartile tale preferate!");
        }
    }
}