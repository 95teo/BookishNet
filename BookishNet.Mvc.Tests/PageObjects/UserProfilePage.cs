using BookishNet.Mvc.Tests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class UserProfilePage : HomePage
    {
        [FindsBy(How = How.CssSelector, Using = "#container > div > div > div > div > div:nth-child(2) > button")]
        [CacheLookup]
        private IWebElement EditButton { get; set; }

        public IWebElement GetEditButton()
        {
            return EditButton;
        }

        public void OpenProfileEditor()
        {
            EditButton.ClickOnIt("EditButton");
        }
    }
}