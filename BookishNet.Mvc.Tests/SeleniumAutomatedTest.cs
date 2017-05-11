using NUnit.Framework;

namespace BookishNet.Mvc.Tests
{
    [TestFixture]
    public class SeleniumAutomatedTest : OpenDotnet
    {
        public SeleniumAutomatedTest() : base("BookishNet.Mvc")
        {
        }

        [Test]
        public void OpenApp()
        {
            ChromeDriver.Url = "http://localhost:45719/";
            //Assert.IsTrue(ChromeDriver.FindElementByXPath("//*[@id=\"content\"]/div[3]/fieldset[2]/h4/a").Displayed);
        }
    }
}