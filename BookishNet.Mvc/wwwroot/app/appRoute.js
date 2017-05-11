(function() {
    "use strict";
    angular.module("BookishNet")
        .config([
            "$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
                $routeProvider
                    .when("/",
                        {
                            controller: "loginController",
                            controllerAs: "log",
                            templateUrl: "views/Login.html"
                        })
                    .when("/home",
                        {
                            controller: "homeController",
                            controllerAs: "home",
                            templateUrl: "views/Home.html"
                        })
                    .when("/register",
                        {
                            controller: "registerController",
                            controllerAs: "reg",
                            templateUrl: "views/Register.html"
                        })
                    .when("/books",
                        {
                            controller: "booksController",
                            controllerAs: "books",
                            templateUrl: "views/Books.html"
                        })
                    .when("/books:bookId",
                        {
                            controller: "bookController",
                            controllerAs: "book",
                            templateUrl: "views/Book.html"
                        })
                    .when("/users:userId",
                        {
                            controller: "userController",
                            controllerAs: "user",
                            templateUrl: "views/UserProfile.html"
                        })
                    .otherwise({
                        redirectTo: "/"
                    });
                /*$locationProvider.html5Mode({
                    enabled: true,
                    requireBase: false,
                    rewriteLinks: true
                });*/
            }
        ]);
})();