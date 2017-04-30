﻿(function () {
    "use strict";

    angular
        .module("BookishNet")
        .controller("registerController", registerController);

    registerController.$inject = ["$rootScope", "$scope", "$location", "userService"];

    function registerController($rootScope, $scope, $location, userService) {
        $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
        /* jshint validthis:true */
        var reg = this;
        this.username = "";
        this.role = "";
        this.isLoggedIn = false;
        reg.title = "registerController";
        reg.register = function () {
            var username = reg.username;
            var email = reg.email;
            var password = reg.password;
            var confirmPassword = reg.confirmPassword;
            var role = reg.roleSignup;
            var birthdate = reg.birthdate;
            var user = {
                "Username": username,
                "Email": email,
                "Password": password
            };
            /*userService.register(user)
                .then(function (response) {
                            $location.path("/Home");
                });*/
        };
    }
})();