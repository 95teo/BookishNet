(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("userController", userController);

    userController.$inject = ["$rootScope", "$location", "userService", "bookService"];

    function userController($rootScope, $location, userService, bookService) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        /* jshint validthis:true */
        var userId = $location.url().split(":")[1];
        var user = this;
        user.id = userId;
        user.title = "userController";
        if ($rootScope.sessionData.isLoggedIn) {
            userService.getUser(userId)
                .then(function(response) {
                    user.userEntity = response.data;
                    user.id = user.userEntity.id;
                    user.address = user.userEntity.address;
                    user.dateOfBirth = new Date(user.userEntity.dateOfBirth);
                    user.email = user.userEntity.email;
                    user.firstName = user.userEntity.firstName;
                    user.password = user.userEntity.password;
                    user.roleId = user.userEntity.roleId;
                    user.secondName = user.userEntity.secondName;
                    user.stars = user.userEntity.stars;
                    user.timestamp = user.userEntity.timestamp;
                    user.username = user.userEntity.username;
                    user.isDeleted = user.userEntity.isDeleted;
                });
            bookService.getBooksByLoanerId(userId)
                .then(function(response) {
                    user.bookList = response.data;
                    for (var i = 0; i < user.bookList.length; i++) {
                        if (user.bookList[i].borrowerId != null) {
                            userService.getUser(user.bookList[i].borrowerId)
                                .then(function(userObj) {
                                    user.borrowerUsername = userObj.data.username;
                                });
                        }
                    }
                });
        }
        user.updateUserProfile = function() {
            var updateObj = {
                "Id": userId,
                "FirstName": user.firstName,
                "SecondName": user.secondName,
                "RoleId": user.roleId,
                "Username": user.username,
                "Password": user.password,
                "Address": user.address,
                "DateOfBirth": user.dateOfBirth,
                "IsDeleted": user.isDeleted,
                "Timestamp": user.timestamp,
                "Email": user.email,
                "Stars": user.stars
            };
            userService.updateUser(updateObj).then(function() {
                userService.getUser(userId).then(function(response) {
                    user.userEntity = response.data;
                    $("#editUserDataModal").modal("toggle");
                });
            });
        };
        user.cancelEdit = function() {
            user.address = user.userEntity.address;
            user.dateOfBirth = new Date(user.userEntity.dateOfBirth);
            user.email = user.userEntity.email;
            user.firstName = user.userEntity.firstName;
            user.password = user.userEntity.password;
            user.secondName = user.userEntity.secondName;
            user.username = user.userEntity.username;
        };

    }
})();