(function() {
    "use strict";

    angular
        .module("BookishNet")
        .directive("contactUserDirective", contactUserDirective);

    contactUserDirective.$inject = ["$window"];

    function contactUserDirective($window) {
        // Usage:
        //     <contactUserDirective></contactUserDirective>
        // Creates:
        // 
        var directive = {
            restrict: "EA",
            templateUrl: "/views/UserContact.html"
        };
        return directive;
    }

})();