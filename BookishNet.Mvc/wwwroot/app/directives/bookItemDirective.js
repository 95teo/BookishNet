(function() {
    "use strict";

    angular
        .module("BookishNet")
        .directive("bookItemDirective", bookItemDirective);

    bookItemDirective.$inject = ["$window"];

    function bookItemDirective($window) {
        // Usage:
        //     <bookItemDirective></bookItemDirective>
        // Creates:
        // 
        var directive = {
            restrict: "EA",
            templateUrl: "/views/BookView.html"
            /*controller: 'booksController',
            controllerAs: 'books'*/
        };
        return directive;
    }

})();