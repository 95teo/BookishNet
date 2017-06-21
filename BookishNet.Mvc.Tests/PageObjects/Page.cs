using BookishNet.Mvc.Tests.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static HomePage Home
        {
            get { return GetPage<HomePage>(); }
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static RegisterPage Register
        {
            get { return GetPage<RegisterPage>(); }
        }

        public static BookPage Book
        {
            get { return GetPage<BookPage>(); }
        }

        public static BooksPage Books
        {
            get { return GetPage<BooksPage>(); }
        }

        public static NotLoggedBookPage NotLoggedBook
        {
            get { return GetPage<NotLoggedBookPage>(); }
        }

        public static UserPage User
        {
            get { return GetPage<UserPage>(); }
        }

        public static UsersPage Users
        {
            get { return GetPage<UsersPage>(); }
        }

        public static NotLoggedUserPage NotLoggedUser
        {
            get { return GetPage<NotLoggedUserPage>(); }
        }

        public static UserProfilePage UserProfile
        {
            get { return GetPage<UserProfilePage>(); }
        }
    }
}
