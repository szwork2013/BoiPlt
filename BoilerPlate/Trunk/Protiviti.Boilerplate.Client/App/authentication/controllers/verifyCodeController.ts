

module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = Modules.Authentication.controllers.verifyCode;
    angular.module(Modules.Authentication.Name).controller(controllerId,
        ['$http', '$rootScope', '$scope', '$location', '$timeout', 'authService', 'config', 'common', 'localStorageService', verifyCodeController]);


    function verifyCodeController($http, $rootScope, $scope, $location, $timeout, authService, config, common, localStorageService) {

        // Standard initialization
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.providers = [{ name: 'Email', value: 'EmailCode' }, { name: 'SMS', value: 'PhoneCode' }];
        $scope.selectedProvider = '';
        $scope.code = '';
        

        $scope.getProviders = function () {
            var self = this;
            var userInfo = $rootScope.requiresverification.data.split('&');
            var formData = { Email: userInfo[0].split('=')[1], Password: userInfo[1].split('=')[1] };
            $http.post(config.remoteApiServiceBase + 'account/providers', formData)
                .success(function (response: any) {
                }).error(function (err, status) {
                });
        }

        $scope.getCode = function () {
            if ($scope.selectedProvider == null || !angular.isDefined($scope.selectedProvider.value)) {
                $scope.message = "Select Authentication Provider";
                return false;
            }
            var self = this;
            var userInfo = $rootScope.requiresverification.data.split('&');
            var formData = {
                Email: userInfo[0].split('=')[1],
                Password: userInfo[1].split('=')[1],
                Provider: $scope.selectedProvider.value
            };
            $http.post(config.remoteApiServiceBase + 'account/sendcode', formData)
                .success(function (response: any) {
                    $scope.message = 'Verification code send successfully.';
                }).error(function (err, status) {
                    $scope.message = err;
                });
        }

        $scope.verifyCode = function () {
            if ($scope.selectedProvider == null || !angular.isDefined($scope.selectedProvider.value)) {
                $scope.message = "Select Authentication Provider";
                return false;
            }
            if ($scope.length<=0) {
                $scope.message = "Enter verification code.";
                return false;
            }
            var self = this;
            var userInfo = $rootScope.requiresverification.data.split('&');
            var formData = {
                Email: userInfo[0].split('=')[1],
                Password: userInfo[1].split('=')[1],
                Provider: $scope.selectedProvider.value,
                Code: $scope.code
            };
            $http.post(config.remoteApiServiceBase + 'account/verifycode', formData)
                .success(function (response: any) {
                    if (response != null) {
                        $scope.message = "Verified Successfully. You will be logged in 2 secs.";
                        $scope.savedSuccessfully = true;
                        localStorageService.set(Modules.Authentication.bearerTokenName,
                            { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles });

                        authService.currentUser.isAuthenticated = true;
                        authService.currentUser.isInternal = true;
                        authService.currentUser.userName = response.userName;
                        authService.currentUser.displayName = response.displayName;
                        authService.currentUser.roles = response.roles;

                        $rootScope.$broadcast(Modules.Authentication.events.userLoggedIn);
                        $rootScope.$broadcast(Modules.Authentication.events.userPermissionChanged);
                        $rootScope.$broadcast(Modules.Authentication.events.userAuthenticationChanged);

                        startTimer();
                    }
                    else {
                        $scope.savedSuccessfully = false;
                        $scope.message = "Code is not verified. Make sure the code you enter is valid one. Code is valid only for 3 mins.";
                    }
                }).error(function (err, status) {
                    $scope.message = err;
                });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/');
            }, 2000);
        }


        this.activate = function () {
            var promises = '';// [$scope.getProviders()];

            common.activateController(promises, controllerId).then(function () {
                //$scope.userInfo = $rootScope.requiresverification;
                log('Activated VerifyCode View');
            });
        }

        // Activate current controller
        this.activate();

    };

}