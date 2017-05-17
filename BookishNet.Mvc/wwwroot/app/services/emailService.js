(function() {
    "use strict";

    angular
        .module("BookishNet")
        .service("emailService", emailService);

    emailService.$inject = ["$http", "$location", "$q"];

    function emailService($http, $location, $q) {
        this.sendEmail = function(emailObj) {
            var deferred = $q.defer();
            $http({
                    method: "POST",
                    url: "http://localhost:45719/api/email",
                    data: JSON.stringify(emailObj),
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
    }
})();