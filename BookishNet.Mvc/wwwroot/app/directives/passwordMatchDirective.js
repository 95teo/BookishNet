(function () {
    "use strict";

    angular
        .module("BookishNet")
        .directive("passwordMatchDirective", passwordMatchDirective);

    passwordMatchDirective.$inject = ["$window"];

    function passwordMatchDirective($window) {
        // Usage:
        //     <passwordMatchDirective></passwordMatchDirective>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: "EA",
            require: "ngModel"
        };
        return directive;

        function link(scope, element, attrs, ctrl) {
            scope.$watch(attrs["passwordMatchDirective"], function (newVal, oldVal) {               
                ctrl.$validators.match = function (modelValue, viewValue) {
                    if (newVal === modelValue) {
                        return true;
                    } else {
                        return false;
                    }
                }
                ctrl.$validate();
            });
        }
    }

})();