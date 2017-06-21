using System.Threading;
using BookishNet.Mvc.Tests.DTO;
using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PagePartials;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class RegisterPage : NavbarContent
    {
        [FindsBy(How = How.CssSelector, Using = "body > nav > div > ul > li:nth-child(4) > a")]
        [CacheLookup]
        private IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.Id, Using = "user")]
        [CacheLookup]
        private IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "confirmPassword")]
        [CacheLookup]
        private IWebElement ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "birthday")]
        [CacheLookup]
        private IWebElement BirthdayInput { get; set; }

        [FindsBy(How = How.Id, Using = "signup-as-author-btn")]
        [CacheLookup]
        private IWebElement AuthorRadioInput { get; set; }

        [FindsBy(How = How.Id, Using = "signup-as-user-btn")]
        [CacheLookup]
        private IWebElement UserRadioInput { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "#container > div > div > div.login-container > div.form-box > form > button")]
        [CacheLookup]
        private IWebElement RegisterButton { get; set; }

        public IWebElement GetRegisterButton()
        {
            return RegisterButton;
        }

        public void FollowRegisterLink()
        {
            RegisterLink.ClickOnIt("RegisterLink");
        }

        public void Register(RegisterDto registerDto)
        {
            UsernameInput.EnterText(registerDto.Username, "UsernameInput");
            EmailInput.EnterText(registerDto.Email, "EmailInput");
            PasswordInput.EnterText(registerDto.Password, "PasswordInput");
            ConfirmPasswordInput.EnterText(registerDto.ConfirmPassword, "ConfirmPasswordInput");
            BirthdayInput.SendKeys(registerDto.Birthday);
            if (registerDto.IsAuthor)
                AuthorRadioInput.ClickOnIt("AuthorRadioInput");
            else
                UserRadioInput.ClickOnIt("UserRadioInput");
            Thread.Sleep(2000);
            RegisterButton.ClickOnIt("RegisterButton");
        }
    }
}