(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("registerController", registerController);

    registerController.$inject = ["$rootScope", "$scope", "$location", "userService"];

    function registerController($rootScope, $scope, $location, userService) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        /* jshint validthis:true */
        var reg = this;
        this.username = "";
        this.role = "";
        this.isLoggedIn = false;
        reg.title = "registerController";
        $scope.emailFormat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;
        $scope.passwordFormat = /^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20})$/;
        reg.register = function() {
            var username = reg.username;
            var email = reg.email;
            var password = reg.password;
            var confirmPassword = reg.confirmPassword;
            var role = reg.roleSignup;
            var birthday = new Date(reg.birthdate);
            var timestamp = new Date();
            /*var salt = CryptoJS.lib.WordArray.random(128 / 8);
            var key512Bits = CryptoJS.PBKDF2(password, salt, { keySize: 512 / 32, iterations: 1 });*/
            var roleId = 0;
            if (role === "author") {
                roleId = 3;
            } else {
                roleId = 2;
            }
            var user = {
                "Username": username,
                "Email": email,
                "Password": password,
                "DateOfBirth": birthday,
                "Timestamp": timestamp,
                "RoleId": roleId,
                "IsDeleted": false,
                "Stars": 0
            };
            userService.register(user)
                .then(function(response) {
                    $location.path("/home");
                });
        };
    }
})();