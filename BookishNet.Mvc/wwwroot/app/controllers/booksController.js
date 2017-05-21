(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("booksController", booksController);

    booksController.$inject = ["$rootScope", "$scope", "$location", "bookService"];

    function booksController($rootScope, $scope, $location, bookService) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        /* jshint validthis:true */
        var books = this;
        books.ctrlTitle = "booksController";
        bookService.getBooks()
            .then(function(response) {
                books.bookList = response.data;
            });
        $scope.addBook = function() {
            var book = {
                "AuthorName": books.authorName,
                "Title": books.title,
                "GenreId": 1,
                "IsBorrowed": false,
                "LoanerId": $rootScope.sessionData.id,
                "Description": books.description,
                "PublishingYear": books.publishingYear,
                "IsDeleted": false,
                "Timestamp": new Date()
            };
            bookService.addBook(book).then(function(responseCode) {
                books.title = "";
                books.authorName = "";
                books.publishingYear = "";
                books.description = "";
                books.genreId = "";
                $("#addBookModal").modal("toggle");
                bookService.getBooks().then(function(response) {
                    books.bookList = response.data;
                });
            });
        };
        $scope.cancelAdd = function() {
            books.title = "";
            books.authorName = "";
            books.publishingYear = "";
            books.description = "";
            books.genreId = "";
        };
    };
})();