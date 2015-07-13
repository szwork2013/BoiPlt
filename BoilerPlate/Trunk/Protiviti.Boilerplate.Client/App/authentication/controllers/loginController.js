'use strict';
var controllerId = Protiviti.Boilerplate.Client.Modules.Authentication.controllers.login;
angular.module(Protiviti.Boilerplate.Client.Modules.Authentication.Name).controller(controllerId, [
    '$rootScope', '$scope', '$location', '$state', 'config', 'common', 'authService',
    function ($rootScope, $scope, $location, $state, config, common, authService, controllerId) {
        return new Protiviti.Boilerplate.Client.Controllers.LoginController($rootScope, $scope, $location, $state, config, common, authService, controllerId);
    }]);

var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Controllers) {
                var LoginController = (function () {
                    function LoginController($rootScope, $scope, $location, $state, config, common, authService, controllerId) {
                        this.$rootScope = $rootScope;
                        this.$scope = $scope;
                        this.$location = $location;
                        this.$state = $state;
                        this.config = config;
                        this.common = common;
                        this.authService = authService;
                        this.controllerId = controllerId;
                        var getLogFn = common.logger.getLogFn;
                        var log = getLogFn(controllerId);
                        var path = '';

                        $scope.reset = function () {
                            $scope.loginData = angular.copy($scope.master);
                        };

                        $scope.activate = function () {
                            $scope.reset();
                            $scope.message = "";
                            common.activateController('', controllerId).then(function () {
                                log('Activated Login View');
                            });
                        };

                        $scope.login = function () {
                            authService.login($scope.loginData).then(function (status) {
                                if (!status) {
                                    $scope.errorMessage = 'Unable to login';
                                    return;
                                }

                                if (angular.isDefined($rootScope.oldState)) {
                                    path = path + $rootScope.oldState.url;
                                }
                                $rootScope.$broadcast(Client.Modules.Authentication.events.userLoggedIn);
                                $rootScope.$broadcast(Client.Modules.Authentication.events.userPermissionChanged);
                                $rootScope.$broadcast(Client.Modules.Authentication.events.userAuthenticationChanged);

                                $location.path(path);
                            }, function (err) {
                                $scope.message = err.error_description;
                            });
                        };

                        $scope.authExternalProvider = function (provider) {
                            var redirectUri = config.externalLoginRedirectUrl;

                            var externalProviderUrl = config.remoteApiServiceBase + "account/externallogin?provider=" + provider + "&response_type=token&client_id=" + config.ClientId + "&redirect_uri=" + redirectUri;

                            window.$windowScope = $scope;

                            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
                        };

                        $scope.externalAuthenticationCompleted = function (fragment) {
                            $scope.$apply(function () {
                                if (fragment.haslocalaccount == 'False') {
                                    authService.logout();

                                    authService.externalAuthData = {
                                        provider: fragment.provider,
                                        userName: fragment.external_user_name,
                                        externalAccessToken: fragment.external_access_token
                                    };
                                    $state.go('associate');
                                } else {
                                    var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };

                                    authService.obtainAccessToken(externalData).then(function (response) {
                                        $rootScope.$broadcast(Client.Modules.Authentication.events.userLoggedIn);
                                        $rootScope.$broadcast(Client.Modules.Authentication.events.userPermissionChanged);
                                        $rootScope.$broadcast(Client.Modules.Authentication.events.userAuthenticationChanged);
                                        $state.go('dashboard');
                                    }, function (err) {
                                        $scope.message = err.error_description;
                                    });
                                }
                            });
                        };
                    }
                    return LoginController;
                })();
                Controllers.LoginController = LoginController;
            })(Client.Controllers || (Client.Controllers = {}));
            var Controllers = Client.Controllers;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=loginController.js.map
