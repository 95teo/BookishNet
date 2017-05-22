(function() {
    "use strict";

    angular
        .module("BookishNet")
        .service("genreService", genreService);

    genreService.$inject = ["$http", "$location", "$q"];

    function genreService($http, $location, $q) {
        this.getGenres = function() {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/genre"
                })
                .then(function successCallback(response) {
                    return deferred.resolve(response);

                }), function failCallback(response) {
                return deferred.reject(response.data);
            };
            return deferred.promise;
        };
        this.getGenre = function(genreId) {
            var deferred = $q.defer();
            $http({
                    method: "GET",
                    url: "http://localhost:45719/api/genre/" + genreId
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