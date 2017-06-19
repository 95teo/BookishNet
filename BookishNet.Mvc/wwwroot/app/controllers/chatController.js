(function() {
    "use strict";

    angular
        .module("BookishNet")
        .controller("chatController", chatController);

    chatController.$inject = ["$rootScope", "$location", "$scope"];

    function chatController($rootScope, $location, $scope) {
        $rootScope.sessionData = JSON.parse(sessionStorage.getItem("session"));
        $scope.messages = [];
        $scope.message = "";
        var protocol = location.protocol === "https:" ? "wss:" : "ws:";
        var wsUri = protocol + "//" + window.location.host;
        var socket = new WebSocket(wsUri);
        socket.onopen = e => {
            console.log("socket opened", e);
        };

        socket.onclose = function(e) {
            console.log("socket closed", e);
        };

        socket.onmessage = function(e) {
            var username = JSON.parse(JSON.stringify(e.data)).split(/:(.+)/)[0];
            var message = JSON.parse(JSON.stringify(e.data)).split(/:(.+)/)[1];
            $scope.messages.push({ Username: username, Message: message });
            $scope.$apply();
        };

        socket.onerror = function(e) {
            console.error(e.data);
        };

        $scope.send = function() {
            var message = $rootScope.sessionData.username + ": " + $scope.message;
            socket.send(message);
            $scope.message = "";
        };

        $("#MessageField").keypress(function(e) {
            if (e.which != 13) {
                return;
            }

            e.preventDefault();

            var message = $rootScope.sessionData.username + ": " + $scope.message;
            socket.send(message);
            $scope.message = "";
            $("#MessageField").val("");
        });

    };
})();