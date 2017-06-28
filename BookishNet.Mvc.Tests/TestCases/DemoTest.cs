using System.Threading;
using BookishNet.Mvc.Tests.DTO;
using BookishNet.Mvc.Tests.Extensions;
using BookishNet.Mvc.Tests.PageObjects;
using NUnit.Framework;

namespace BookishNet.Mvc.Tests.TestCases
{
    internal class DemoTest : OpenCloseSelenium
    {
        [Test]
        public void Demo()
        {
            var bookDto = new BookDto
            {
                Title = "Laleaua neagra",
                Author = "Alexandre Dumas",
                Description =
                    "O carte recomandata in momentele in care vrei sa evadezi din paginile literaturii contemporane, lipsita uneori de aerul acela clasic, senzatia unui moment anume ales parca pentru ritualul povestirii, intr-un cuvant farmecul romanelor de demult.",
                Year = 2017
            };
            var registerDto = new RegisterDto
            {
                Username = "ionel",
                Email = "ionel@gmail.com",
                Password = "ionel12A",
                ConfirmPassword = "ionel12A",
                Birthday = "08/01/1997",
                IsAuthor = false
            };
            const string username = "mike";
            const string password = "mike12A";
            const string message = "Goodbye. Thanks for watching! :)";
            Thread.Sleep(4000);
            Page.Login.Login(username, password);

            Thread.Sleep(8000);
            Page.Home.FollowBooksLink();

            Thread.Sleep(4000);
            Page.Books.OpenAddBookModal();

            Thread.Sleep(2000);
            Page.Books.AddBook(bookDto);

            Thread.Sleep(2000);
            Page.Books.FillTitleInput(bookDto.Title);

            Thread.Sleep(1000);
            Page.Books.ClearTitleFilter();

            Thread.Sleep(2000);
            Page.Books.FillAuthorInput(bookDto.Author);

            Thread.Sleep(1000);
            Page.Books.ClearAuthorFilter();

            Thread.Sleep(2000);
            Page.Books.FillYearInput(bookDto.Year);

            Thread.Sleep(1000);
            Page.Books.ClearYearInput();

            Thread.Sleep(3000);
            Page.Books.FollowFirstBookLink();

            Thread.Sleep(3000);
            Page.Books.FollowBooksLink();

            Thread.Sleep(3000);
            Page.Books.FollowSecondBookLink();

            Thread.Sleep(3000);
            Page.Book.FollowUsersLink();

            Thread.Sleep(3000);
            Page.Users.FollowFirstUserLink();

            Thread.Sleep(3000);
            Page.User.OpenUserProfile();

            Thread.Sleep(3000);
            Page.User.Logout();

            Thread.Sleep(3000);
            Page.Login.FollowBooksLink();

            Thread.Sleep(3000);
            Page.Books.FollowFirstBookLink();

            Thread.Sleep(3000);
            Page.NotLoggedBook.FollowUsersLink();

            Thread.Sleep(3000);
            Page.Users.FollowFirstUserLink();

            Thread.Sleep(3000);
            Page.NotLoggedUser.FollowRegisterLink();

            Thread.Sleep(3000);
            Page.Register.Register(registerDto);

            Thread.Sleep(5000);
            Page.Login.Login(registerDto.Username, registerDto.Password);

            Thread.Sleep(6000);
            Page.Home.SendMessage(message);

            Thread.Sleep(4000);
            Assert.IsTrue(Page.Home.GetSentMessage().IsDisplayed("SentMessage"));
        }
    }
}