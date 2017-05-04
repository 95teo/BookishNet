(function() {
    "use strict";

    angular
        .module("BookishNet")
        .service("bookService", bookService);

    bookService.$inject = ["$http", "$location", "$q"];

    function bookService($http, $location, $q) {
        this.getBooks = function() {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/book"
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };

        this.getBook = function(bookId) {
            var deferred = $q.defer();
            //jobId = $location.url().split(":")[1];
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/book/" + bookId
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.addBook = function(book) {
            var deferred = $q.defer();
            $http({
                    method: "POST",
                    url: "http://localhost:45719/api/book",
                    data: JSON.stringify(book),
                    headers: {
                        'Content-Type': "application/json"
                    }
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };

        this.updateBook = function(book) {
            var deferred = $q.defer();
            var bookId = $location.url().split(":")[1];
            $http({
                    method: "PUT",
                    url: "http://localhost:45719/api/book/" + bookId,
                    data: JSON.stringify(book),
                    headers: {
                        'Content-Type': "application/json"
                    }
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);
                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.deleteBook = function(bookId) {
            var deferred = $q.defer();
            $http({
                    method: "DELETE",
                    url: "http://localhost:45719/api/book/" + bookId
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.getBookByTitle = function(bookTitle) {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/book/book" + bookTitle
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.getBooksByAuthorName = function(authorName) {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/book/book/author/" + authorName
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.getBooksByLoanerId = function(loanerId) {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/book/book/books/user/" + loanerId
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
    }
})();