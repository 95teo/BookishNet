using System.Configuration;
using BookishNet.Mvc.Tests.WrapperFactory;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests
{
    [TestFixture]
    public abstract class OpenCloseSelenium
    {
        [SetUp]
        public void TestInitialize()
        {
            // Start Selenium drivers
            BrowserFactory.InitBrowser("Chrome");
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
        }


        [TearDown]
        public void TestCleanup()
        {
            BrowserFactory.CloseAllDrivers();
        }

        //protected IWebDriver Driver { get; set; }
    }
}