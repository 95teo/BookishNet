(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("bookController", bookController);

    bookController.$inject = ["$rootScope", "$location", "bookService"];

    function bookController($rootScope, $location, bookService, $routeParams) {
        $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
        /* jshint validthis:true */
        var bookId = $location.url().split(":")[1];
        var book = this;
        book.ctrlTitle = "bookController";
        if ($rootScope.sessionData.isLoggedIn) {
            bookService.getBook(bookId)
                .then(function(response) {
                    book.bookEntity = response.data;
                    book.title = book.bookEntity.title;
                    book.authorName = book.bookEntity.authorName;
                    book.publishingYear = book.bookEntity.publishingYear;
                    book.description = book.bookEntity.description;
                    book.genreId = book.bookEntity.genreId;
                    book.loanerId = book.bookEntity.loanerId;
                    book.isDeleted = book.bookEntity.isDeleted;
                    book.IsBorrowed = book.bookEntity.IsBorrowed;
                });
        }
        book.removeBook = function() {
            bookService.deleteBook(bookId)
                .then(function(response) {
                    $location.path("/books");
                });
        };
        book.updateBook = function() {
            var updateObj = {
                "Id": bookId,
                "AuthorName": book.authorName,
                "Title": book.title,
                "GenreId": book.genreId,
                "IsBorrowed": book.IsBorrowed,
                "LoanerId": book.loanerId,
                "Description": book.description,
                "PublishingYear": book.publishingYear,
                "IsDeleted": book.isDeleted,
                "Timestamp": new Date()
            };
            bookService.updateBook(updateObj).then(function() {
                bookService.getBook(bookId).then(function(response) {
                    book.bookEntity = response.data;
                    $("#editBookModal").modal("toggle");
                });
            });
        };
        book.cancelEdit = function() {
            book.title = book.bookEntity.title;
            book.authorName = book.bookEntity.authorName;
            book.publishingYear = book.bookEntity.publishingYear;
            book.description = book.bookEntity.description;
            book.loanerId = book.bookEntity.loanerId;
            book.isDeleted = book.bookEntity.isDeleted;
        };
    };
})();