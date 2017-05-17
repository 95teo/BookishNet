(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("emailController", emailController);

    emailController.$inject = ["$location", "$rootScope", "$scope", "emailService"];

    function emailController($location, $rootScope, $scope, emailService) {
        $rootScope.sessionData = JSON.parse(localStorage.getItem("session"));
        /* jshint validthis:true */
        var email = this;
        email.title = "emailController";
        $scope.sendEmail = function(contact) {
            var emailObj = {
                username: $rootScope.sessionData.username,
                sender: email.sender,
                //TODO: remove my email when finish testing
                receiver: "teofil.ursan@gmail.com",
                subject: email.subject,
                body: "Buna, " +
                    email.receiver +
                    "! Ai primit acest email deoarece utilizatorul " +
                    $rootScope.sessionData.username +
                    " de pe platforma BookishNet doreste sa te contacteze. Iata ce ti-a scris: '" +
                    email.body +
                    "'. Utilizatorul poate fi contactat la adresa de email: " +
                    email.sender
            };
            emailService.sendEmail(emailObj)
                .then(function(response) {
                    email.username = "";
                    email.sender = "";
                    email.receiver = "";
                    email.body = "";
                    email.subject = "";
                    contact.$setUntouched();
                    $("#contactUserModal").modal("toggle");
                });
        };

        $scope.cancelSending = function(contact) {
            email.username = "";
            email.sender = "";
            email.receiver = "";
            email.body = "";
            email.subject = "";
            contact.$setUntouched();
        };
    }
})();