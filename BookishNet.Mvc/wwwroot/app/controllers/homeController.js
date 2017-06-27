(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("homeController", homeController);

    homeController.$inject = ["$rootScope", "$location", "$scope"];

    function homeController($rootScope, $location, $scope) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        if ($rootScope.sessionData.isLoggedIn) {
            $scope.message = "Bine ai revenit, " + $rootScope.sessionData.username;
        } else {
            $location.path("/");
        }
        $scope.navigateToDashboard = function() {
            $location.path("/Prof");
        };
    }
})();