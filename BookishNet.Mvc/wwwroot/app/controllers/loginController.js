(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("loginController", loginController);

    loginController.$inject = ["$rootScope", "$scope", "$location", "loginService", "userService"];

    function loginController($rootScope, $scope, $location, loginService, userService) {
        if (localStorage.getItem("session") === null) {

            var emptySession = {
                'id': "",
                'username': "",
                'role': "",
                'isLoggedIn': false
            };
            localStorage.removeItem("session");
            localStorage.setItem("session", JSON.stringify(emptySession));
        }
        $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
        /* jshint validthis:true */
        var log = this;
        this.username = "";
        this.role = "";
        this.isLoggedIn = false;
        log.show = false;
        log.logging = false;
        log.title = "loginController";
        log.login = function() {
            log.logging = true;
            log.loadingLogin = "Incercam autentificarea. Va rugam asteptati";
            var username = log.username;
            var password = log.password;
            var dto = {
                "Username": username,
                "Password": password
            };
            loginService.login(dto)
                .then(function(response) {
                    if (response.data !== null) {
                        log.username = dto.Username;
                        var responseJson = JSON.parse(JSON.stringify(response.data));
                        if (responseJson[0] === "authenticated") {
                            log.isLoggedIn = true;
                            log.role = responseJson[1];
                            userService.getUserDetails(log.username)
                                .then(function(user) {
                                    log.id = user.data.id;
                                    var session = {
                                        'id': log.id,
                                        'username': log.username,
                                        'role': log.role,
                                        'isLoggedIn': log.isLoggedIn
                                    };
                                    log.show = false;
                                    log.logging = false;
                                    localStorage.removeItem("session");
                                    localStorage.setItem("session", JSON.stringify(session));
                                    $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
                                    $location.path("/home");
                                });
                        } else {
                            log.show = true;
                            log.logging = false;
                            log.error = "Combinatia nume utilizator/parola este eronata. Va rugam reincercati.";
                        }
                    }
                });
        };
        $scope.logout = function() {
            loginService.logout()
                .then(function(response) {
                    if (response.data !== null) {
                        var responseJson = JSON.parse(JSON.stringify(response.data));
                        if (responseJson === "logged off") {
                            log.id = "";
                            log.username = "";
                            log.isLoggedIn = false;
                            log.role = "";
                            var newEmptySession = {
                                'id': log.id,
                                'username': log.username,
                                'role': log.role,
                                'isLoggedIn': log.isLoggedIn
                            };
                            localStorage.removeItem("session");
                            localStorage.setItem("session", JSON.stringify(newEmptySession));
                            $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
                            $location.path("/home");
                        }
                    }
                });
        };
    }
})();