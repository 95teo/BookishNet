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
                            templateUrl: "views/login.html"
                        })
                    .when("/Home",
                        {
                            controller: "homeController",
                            controllerAs: "home",
                            templateUrl: "views/home.html"
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