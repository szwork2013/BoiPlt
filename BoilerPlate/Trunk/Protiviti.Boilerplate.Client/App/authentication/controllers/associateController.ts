

module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = Modules.Authentication.controllers.associate;
    angular.module(Modules.Authentication.Name).controller(controllerId,
        ['$rootScope', '$scope', '$location', '$timeout', 'authService', associateController]);


    function associateController($rootScope, $scope, $location, $timeout, authService) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.registerData = {
            userName: authService.externalAuthData.userName,
            provider: authService.externalAuthData.provider,
            externalAccessToken: authService.externalAuthData.externalAccessToken
        };

        $scope.registerExternal = function () {

            authService.registerExternal($scope.registerData).then(function (response) {

                $scope.savedSuccessfully = true;
                $scope.message = "User has been registered successfully, you will be redirected to orders page in 2 seconds.";

                $rootScope.$broadcast(Modules.Authentication.events.userLoggedIn);
                $rootScope.$broadcast(Modules.Authentication.events.userPermissionChanged);
                $rootScope.$broadcast(Modules.Authentication.events.userAuthenticationChanged);

                startTimer();
            },
                function (response) {
                    var errors = [];
                    for (var key in response.modelState) {
                        errors.push(response.modelState[key]);
                    }
                    $scope.message = "Failed to register user due to:" + errors.join(' ');
                });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/');
            }, 2000);
        }

};

}