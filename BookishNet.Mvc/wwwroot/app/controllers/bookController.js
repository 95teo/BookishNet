(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("bookController", bookController);

    bookController.$inject = ["$rootScope", "$location", "bookService", "genreService", "userService"];

    function bookController($rootScope, $location, bookService, genreService, userService) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        /* jshint validthis:true */
        var bookId = $location.url().split(":")[1];
        var book = this;
        book.ctrlTitle = "bookController";
        book.canAddBorrower = true;
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
                    book.isBorrowed = book.bookEntity.isBorrowed;
                    genreService.getGenre(book.genreId)
                        .then(function(response) {
                            book.genre = response.data.name;
                        });
                    userService.getUser(book.loanerId)
                        .then(function(response) {
                            book.userPhone = response.data.phone;
                            if (book.userPhone !== null) {
                                book.canShowPhone = true;
                            } else {
                                book.canShowPhone = false;
                            }
                        });
                });
            genreService.getGenres()
                .then(function(response) {
                    book.genreList = response.data;
                });
            userService.getUsers()
                .then(function(response) {
                    book.userList = response.data;
                });

        }
        book.removeBook = function() {
            bookService.deleteBook(bookId)
                .then(function(response) {
                    $location.path("/books");
                });
        };
        book.updateBook = function(edit) {
            for (var i = 0; i < book.genreList.length; i++) {
                if (book.genre === book.genreList[i].name) {
                    book.genreId = i + 1;
                }
            }
            var updateObj = {
                "Id": bookId,
                "AuthorName": book.authorName,
                "Title": book.title,
                "GenreId": book.genreId,
                "IsBorrowed": book.isBorrowed,
                "LoanerId": book.loanerId,
                "Description": book.description,
                "PublishingYear": book.publishingYear,
                "IsDeleted": book.isDeleted,
                "Timestamp": new Date()
            };
            bookService.updateBook(updateObj).then(function() {
                bookService.getBook(bookId).then(function(response) {
                    book.bookEntity = response.data;
                    genreService.getGenre(book.genreId)
                        .then(function(responseObj) {
                            book.genre = responseObj.data.name;
                        });
                    edit.$setUntouched();
                    $("#editBookModal").modal("toggle");
                });
            });
        };
        book.cancelEdit = function(edit) {
            book.title = book.bookEntity.title;
            book.authorName = book.bookEntity.authorName;
            book.publishingYear = book.bookEntity.publishingYear;
            book.description = book.bookEntity.description;
            book.loanerId = book.bookEntity.loanerId;
            book.isDeleted = book.bookEntity.isDeleted;
            edit.$setUntouched();
            genreService.getGenre(book.genreId)
                .then(function(response) {
                    book.genre = response.data.name;
                });
        };
        book.preAddBorrower = function() {
            book.canAddBorrower = false;
        };

        book.addBorrower = function() {
            book.isBorrowed = true;
            userService.getUserDetails(book.user.username)
                .then(function(response) {
                    var userId = response.data.id;
                    var updateObj = {
                        "Id": bookId,
                        "AuthorName": book.authorName,
                        "Title": book.title,
                        "GenreId": book.genreId,
                        "IsBorrowed": book.isBorrowed,
                        "LoanerId": book.loanerId,
                        "BorrowerId": userId,
                        "Description": book.description,
                        "PublishingYear": book.publishingYear,
                        "IsDeleted": book.isDeleted,
                        "Timestamp": new Date()
                    };
                    bookService.updateBook(updateObj).then(function() {
                        bookService.getBook(bookId).then(function(response) {
                            book.bookEntity = response.data;
                            genreService.getGenre(book.genreId)
                                .then(function(responseObj) {
                                    book.genre = responseObj.data.name;
                                });
                        });
                    });
                });
            book.canAddBorrower = true;
        };

        book.abordAddBorrower = function() {
            book.canAddBorrower = true;
            book.user.username = "";
        };

        book.removeBorrower = function() {
            book.isBorrowed = false;
            var updateObj = {
                "Id": bookId,
                "AuthorName": book.authorName,
                "Title": book.title,
                "GenreId": book.genreId,
                "IsBorrowed": book.isBorrowed,
                "LoanerId": book.loanerId,
                "BorrowerId": null,
                "Description": book.description,
                "PublishingYear": book.publishingYear,
                "IsDeleted": book.isDeleted,
                "Timestamp": new Date()
            };
            bookService.updateBook(updateObj).then(function() {
                bookService.getBook(bookId).then(function(response) {
                    book.bookEntity = response.data;
                    genreService.getGenre(book.genreId)
                        .then(function(responseObj) {
                            book.genre = responseObj.data.name;
                        });
                });
            });
        };
    };
})();