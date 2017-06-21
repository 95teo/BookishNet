using BookishNet.Mvc.Tests.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public static class Page
    {
        public static HomePage Home => GetPage<HomePage>();

        public static LoginPage Login => GetPage<LoginPage>();

        public static RegisterPage Register => GetPage<RegisterPage>();

        public static BookPage Book => GetPage<BookPage>();

        public static BooksPage Books => GetPage<BooksPage>();

        public static NotLoggedBookPage NotLoggedBook => GetPage<NotLoggedBookPage>();

        public static UserPage User => GetPage<UserPage>();

        public static UsersPage Users => GetPage<UsersPage>();

        public static NotLoggedUserPage NotLoggedUser => GetPage<NotLoggedUserPage>();

        public static UserProfilePage UserProfile => GetPage<UserProfilePage>();

        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }
    }
}