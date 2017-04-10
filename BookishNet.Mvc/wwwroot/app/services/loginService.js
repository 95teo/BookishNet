(function() {
    "use strict";

    angular
        .module("BookishNet")
        .service("loginService", loginService);

    loginService.$inject = ["$http", "$location", "$q"];

    function loginService($http, $location, $q) {
        this.Error = "";
        this.login = function(loginDetails) {
            var deferred = $q.defer();
            $http({
                    method: "POST",
                    url: "http://localhost:64910/api/account/login",
                    data: JSON.stringify(loginDetails),
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
        this.logout = function() {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:64910/api/account/logout"
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