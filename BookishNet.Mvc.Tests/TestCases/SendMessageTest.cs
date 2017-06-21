using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class SendMessageTest : OpenCloseSelenium
    {
        [Test]
        public void SendMessage()
        {
            Thread.Sleep(2000);
            Page.Login.Login("teo", "teo");

            Thread.Sleep(3000);
            Page.Home.SendMessage("Hello");

            Thread.Sleep(2000);
            Assert.IsTrue(Page.Home.GetSentMessage().IsDisplayed("SentMessage"));
        }
    }
}