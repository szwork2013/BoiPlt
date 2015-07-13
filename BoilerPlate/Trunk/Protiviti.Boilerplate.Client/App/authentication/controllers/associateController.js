var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Controllers) {
                'use strict';
                var controllerId = Client.Modules.Authentication.controllers.associate;
                angular.module(Client.Modules.Authentication.Name).controller(controllerId, ['$rootScope', '$scope', '$location', '$timeout', 'authService', associateController]);

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

                            $rootScope.$broadcast(Client.Modules.Authentication.events.userLoggedIn);
                            $rootScope.$broadcast(Client.Modules.Authentication.events.userPermissionChanged);
                            $rootScope.$broadcast(Client.Modules.Authentication.events.userAuthenticationChanged);

                            startTimer();
                        }, function (response) {
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
                    };
                }
                ;
            })(Client.Controllers || (Client.Controllers = {}));
            var Controllers = Client.Controllers;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=associateController.js.map
