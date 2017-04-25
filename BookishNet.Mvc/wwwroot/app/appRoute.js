﻿(function() {
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
                    .when("/Home",
                        {
                            controller: "homeController",
                            controllerAs: "home",
                            templateUrl: "views/Home.html"
                        })
                    .otherwise({
                        redirectTo: "/"
                    });
                $locationProvider.html5Mode({
                    enabled: true,
                    requireBase: false,
                    rewriteLinks: true
                });
            }
        ]);
})();