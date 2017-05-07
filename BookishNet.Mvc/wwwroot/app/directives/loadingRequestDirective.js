(function () {
    "use strict";

    angular
        .module("BookishNet")
        .directive("loadingRequestDirective", loadingRequestDirective);

    loadingRequestDirective.$inject = ["$http"];

    function loadingRequestDirective($http) {
        return {
            restrict: "A",
            link: function (scope, elem) {
                scope.isLoading = isLoading;

                scope.$watch(scope.isLoading, toggleElement);

                ////////

                function toggleElement(loading) {
                    if (loading) {
                        elem.show();
                    } else {
                        elem.hide();
                    }
                }

                function isLoading() {
                    return $http.pendingRequests.length > 0;
                }
            }
        };
    }

})();