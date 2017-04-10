(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("loginController", loginController);

    loginController.$inject = ["$rootScope", "$location", "loginService"];

    function loginController($rootScope, $location, loginService) {
        if (localStorage.getItem("session") === null) {

            var emptySession = {
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
        log.title = "loginController";
        log.login = function() {
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
                        var responseJson = JSON.parse(response.data);
                        if (responseJson[0] === "authenticated") {
                            log.isLoggedIn = true;
                            log.role = responseJson[1];
                            var session = {
                                'username': log.username,
                                'role': log.role,
                                'isLoggedIn': log.isLoggedIn
                            };
                            localStorage.removeItem("session");
                            localStorage.setItem("session", JSON.stringify(session));
                            $location.path("/Home");
                        } else {
                            log.error = "Username or password incorrect";
                        }
                    }
                });
        };
        log.logout = function() {
            loginService.logout()
                .then(function(response) {
                    if (response.data !== null) {
                        var responseJson = JSON.parse(response.data);
                        if (responseJson[0] === "logged off") {
                            log.username = "";
                            log.isLoggedIn = false;
                            log.role = "";
                            var newEmptySession = {
                                'username': log.username,
                                'role': log.role,
                                'isLoggedIn': log.isLoggedIn
                            };
                            localStorage.removeItem("session");
                            localStorage.setItem("session", JSON.stringify(newEmptySession));
                            $location.path("/Home");
                        }
                    }
                });
        };
    }
})();