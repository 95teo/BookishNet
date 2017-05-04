(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("booksController", booksController);

    booksController.$inject = ["$rootScope", "$location", "bookService"];

    function booksController($rootScope, $location, bookService) {
        $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
        /* jshint validthis:true */
        var books = this;
        books.title = "booksController";
        bookService.getBooks()
            .then(function(response) {
                books.bookList = response.data;
            });
    };
})();