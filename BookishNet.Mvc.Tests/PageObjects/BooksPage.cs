using System.Threading;
using BookishNet.Mvc.Tests.DTO;
using BookishNet.Mvc.Tests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookishNet.Mvc.Tests.PageObjects
{
    public class BooksPage : HomePage
    {
        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(2) > input")]
        [CacheLookup]
        private IWebElement FilterByTitleInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(3) > input")]
        [CacheLookup]
        private IWebElement FilterByAuthorInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#filters > li:nth-child(4) > input")]
        [CacheLookup]
        private IWebElement FilterByPublishingYearInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(1) > div > div > h3 > a")]
        [CacheLookup]
        private IWebElement FirstBookLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#accordion > li:nth-child(2) > div > div > h3 > a")]
        [CacheLookup]
        private IWebElement SecondBookLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[5]/button")]
        [CacheLookup]
        private IWebElement AddBookButton { get; set; }

        [FindsBy(How = How.Id, Using = "bookTitle")]
        [CacheLookup]
        private IWebElement BookTitleInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='genre']/option[3]")]
        [CacheLookup]
        private IWebElement GenreNameButton { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        [CacheLookup]
        private IWebElement DescriptionInput { get; set; }

        [FindsBy(How = How.Id, Using = "author")]
        [CacheLookup]
        private IWebElement AuthorInput { get; set; }

        [FindsBy(How = How.Id, Using = "year")]
        [CacheLookup]
        private IWebElement YearInput { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "#addBookModal > div > div > div.modal-body > form > button.btn.btn-success")]
        [CacheLookup]
        private IWebElement AddBookModalButton { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "#addBookModal > div > div > div.modal-body > form > button.btn.btn-default")]
        [CacheLookup]
        private IWebElement CancelAddBookModalButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='filters']/li[1]/h4")]
        [CacheLookup]
        private IWebElement PermanentText { get; set; }

        public new IWebElement GetPermanentText()
        {
            return PermanentText;
        }

        public void FillTitleInput(string title)
        {
            FilterByTitleInput.EnterText(title, "FilterByTitleInput");
        }

        public void ClearTitleFilter()
        {
            FilterByTitleInput.Clear();
        }

        public void FillAuthorInput(string author)
        {
            FilterByAuthorInput.EnterText(author, "FilterByAuthorInput");
        }

        public void ClearAuthorFilter()
        {
            FilterByAuthorInput.Clear();
        }

        public void FillYearInput(int year)
        {
            FilterByPublishingYearInput.EnterText(year.ToString(), "FilterByPublishingYearInput");
        }

        public void ClearYearInput()
        {
            FilterByPublishingYearInput.Clear();
        }

        public void FollowFirstBookLink()
        {
            FirstBookLink.ClickOnIt("FirstBookLink");
        }

        public void FollowSecondBookLink()
        {
            SecondBookLink.ClickOnIt("SecondBookLink");
        }

        public void OpenAddBookModal()
        {
            AddBookButton.ClickOnIt("AddBookButton");
        }

        public void AddBook(BookDto book)
        {
            BookTitleInput.EnterText(book.Title, "BookTitleInput");
            GenreNameButton.ClickOnIt("GenreNameButton");
            DescriptionInput.EnterText(book.Description, "DescriptionInput");
            AuthorInput.EnterText(book.Author, "AuthorInput");
            YearInput.EnterText(book.Year.ToString(), "YearInput");
            //CancelAddBookModalButton.ClickOnIt("CancelButton");
            Thread.Sleep(2000);
            AddBookModalButton.ClickOnIt("AddBookButton");
        }
    }
}