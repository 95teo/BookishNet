(function() {
    "use strict";

    angular
        .module("BookishNet")
        .directive("editBookDirective", editBookDirective);

    editBookDirective.$inject = ["$window"];

    function editBookDirective($window) {
        // Usage:
        //     <edtiBookDirective></edtiBookDirective>
        // Creates:
        // 
        var directive = {
            restrict: "EA",
            templateUrl: "/views/BookEditor.html"
            /*controller: 'booksController',
            controllerAs: 'books'*/
        };
        return directive;
    }

})();