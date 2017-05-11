(function() {
    "use strict";

    angular
        .module("BookishNet")
        .directive("editUserDirective", editUserDirective);

    editUserDirective.$inject = ["$window"];

    function editUserDirective($window) {
        // Usage:
        //     <editUserDirective></editUserDirective>
        // Creates:
        // 
        var directive = {
            restrict: "EA",
            templateUrl: "/views/UserProfileEditor.html"
            /*controller: 'booksController',
            controllerAs: 'books'*/
        };
        return directive;
    }

})();