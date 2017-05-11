(function() {
    "use strict";

    angular
        .module("BookishNet")
        .service("userService", userService);

    userService.$inject = ["$http", "$location", "$q"];

    function userService($http, $location, $q) {
        this.Error = "";
        this.register = function(registerDetails) {
            var deferred = $q.defer();
            $http({
                    method: "POST",
                    url: "http://localhost:45719/api/account/register",
                    data: JSON.stringify(registerDetails),
                    headers: {
                        'Content-Type': "application/json"
                    }
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.getUserDetails = function(username) {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/user/users/user/" + username
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.getUser = function(userId) {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/user/" + userId
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
    }
})();