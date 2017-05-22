(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("booksController", booksController);

    booksController.$inject = ["$rootScope", "$scope", "$location", "bookService", "genreService"];

    function booksController($rootScope, $scope, $location, bookService, genreService) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        /* jshint validthis:true */
        var books = this;
        books.ctrlTitle = "booksController";
        bookService.getBooks()
            .then(function(response) {
                books.bookList = response.data;
            });
        genreService.getGenres()
            .then(function(response) {
                books.genreList = response.data;
            });
        $scope.addBook = function() {
            for (var i = 0; i < books.genreList.length; i++) {
                if (books.genre === books.genreList[i].name) {
                    books.genreId = i + 1;
                }
            }
            var book = {
                "AuthorName": books.authorName,
                "Title": books.title,
                "GenreId": books.genreId,
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
                books.genre = "";
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
            books.genre = "";
        };
    };
})();