using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookishNet.Mvc.Tests
{
    [TestFixture]
    public abstract class OpenCloseSelenium
    {
        [SetUp]
        public void TestInitialize()
        {
            // Start Selenium drivers
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Url = "http://bookishnet.azurewebsites.net";
        }


        [TearDown]
        public void TestCleanup()
        {
            Driver.Quit();
        }

        protected IWebDriver Driver { get; set; }
    }
}