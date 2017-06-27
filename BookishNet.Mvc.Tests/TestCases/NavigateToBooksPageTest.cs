using System.Threading;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class NavigateToBooksPageTest : OpenCloseSelenium
    {
        [Test]
        public void GoToBooksPage()
        {
            Thread.Sleep(2000);
            Page.Login.FollowBooksLink();

            Thread.Sleep(3000);
            Assert.AreEqual("Cauta cartea preferata", Page.Books.GetPermanentText().Text);
        }
    }
}