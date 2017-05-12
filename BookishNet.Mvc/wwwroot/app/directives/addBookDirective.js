(function() {
    "use strict";

    angular
        .module("BookishNet")
        .directive("addBookDirective", addBookDirective);

    addBookDirective.$inject = ["$window"];

    function addBookDirective($window) {
        // Usage:
        //     <addBookDirective></addBookDirective>
        // Creates:
        // 
        var directive = {
            restrict: "EA",
            templateUrl: "/views/NewBook.html"
            /*controller: 'booksController',
            controllerAs: 'books'*/
        };
        return directive;
    }

})();