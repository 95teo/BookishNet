using System.Threading;
using BookishNet.Mvc.Tests.DTO;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using BookishNet.Mvc.Tests.WrapperFactory;
using BookishNet.Mvc.Tests.Extensions;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class RegisterTest : OpenCloseSelenium
    {
        [Test]
        public void Register()
        {
            var registerDto = new RegisterDto
            {
                Username = "John",
                Email = "john@gmail.com",
                Password = "john12A",
                ConfirmPassword = "john12A",
                Birthday = "08/01/1997",
                IsAuthor = false
            };
            Thread.Sleep(2000);
            Page.Login.FollowRegisterLink();

            Thread.Sleep(5000);
            Page.Register.Register(registerDto);

            Thread.Sleep(2000);
            Assert.IsTrue(Page.Login.GetLoginButton().IsDisplayed("LoginButton"));
        }
    }
}