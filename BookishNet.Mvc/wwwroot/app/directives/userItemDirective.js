(function() {
    "use strict";

    angular
        .module("BookishNet")
        .directive("userItemDirective", userItemDirective);

    userItemDirective.$inject = ["$window"];

    function userItemDirective($window) {
        // Usage:
        //     <userItemDirective></userItemDirective>
        // Creates:
        // 
        var directive = {
            restrict: "EA",
            templateUrl: "/views/UserView.html"
        };
        return directive;
    }

})();