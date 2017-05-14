(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("usersController", usersController);

    usersController.$inject = ["$rootScope", "$location", "userService"];

    function usersController($rootScope, $location, userService) {
        $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
        /* jshint validthis:true */
        var users = this;
        users.title = "usersController";
        userService.getUsers()
            .then(function(response) {
                users.userList = response.data;
            });
    }
})();