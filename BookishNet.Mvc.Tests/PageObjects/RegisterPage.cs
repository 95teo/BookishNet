using System.Threading;
using BookishNet.Mvc.Tests.DTO;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    internal class RegisterPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(4) > a")]
        public IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.Id, Using = "user")]
        public IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "confirmPassword")]
        public IWebElement ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "birthday")]
        public IWebElement BirthdayInput { get; set; }

        [FindsBy(How = How.Id, Using = "signup-as-author-btn")]
        public IWebElement AuthorRadioInput { get; set; }

        [FindsBy(How = How.Id, Using = "signup-as-user-btn")]
        public IWebElement UserRadioInput { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "#container > div > div > div.login-container > div.form-box > form > button")]
        public IWebElement RegisterButton { get; set; }

        public void FollowRegisterLink()
        {
            RegisterLink.Click();
        }

        public void Register(RegisterDto registerDto)
        {
            UsernameInput.SendKeys(registerDto.Username);
            EmailInput.SendKeys(registerDto.Email);
            PasswordInput.SendKeys(registerDto.Password);
            ConfirmPasswordInput.SendKeys(registerDto.ConfirmPassword);
            BirthdayInput.SendKeys(registerDto.Birthday);
            if (registerDto.IsAuthor)
                AuthorRadioInput.Click();
            else
                UserRadioInput.Click();
            Thread.Sleep(2000);
            //RegisterButton.Click();
        }
    }
}