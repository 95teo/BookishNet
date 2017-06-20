using System.Threading;
using BookishNet.Mvc.Tests.DTO;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class RegisterTest : OpenCloseSelenium
    {
        [Test]
        public void Register()
        {
            var registerDto = new RegisterDto
            {
                Username = "test",
                Email = "test@test.com",
                Password = "123",
                ConfirmPassword = "123",
                Birthday = "08/01/1997",
                IsAuthor = false
            };
            Thread.Sleep(2000);
            var homePage = new LoginPage();
            PageFactory.InitElements(Driver, homePage);
            homePage.FollowRegisterLink();

            Thread.Sleep(5000);
            var registerPage = new RegisterPage();
            PageFactory.InitElements(Driver, registerPage);
            registerPage.Register(registerDto);
        }
    }
}