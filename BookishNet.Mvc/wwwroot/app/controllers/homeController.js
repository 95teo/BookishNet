(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("homeController", homeController);

    homeController.$inject = ["$rootScope", "$location", "$scope"];

    function homeController($rootScope, $location, $scope) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        if ($rootScope.sessionData.isLoggedIn) {
            $scope.message = "Welcome back " + $rootScope.sessionData.role + "  " + $rootScope.sessionData.username;
            $scope.isAdministrator = $rootScope.sessionData.role === "Profesor";
        } else {
            $location.path("/");
        }
        $scope.navigateToDashboard = function() {
            $location.path("/Prof");
        };
    }
})();