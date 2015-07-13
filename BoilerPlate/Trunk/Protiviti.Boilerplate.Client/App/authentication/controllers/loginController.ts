/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular-ui-router.d.ts" />



//['$rootScope', '$scope',  '$state', '$stateParams', 'config', 'common', 'authService', loginController]);

'use strict';

var controllerId = Protiviti.Boilerplate.Client.Modules.Authentication.controllers.login;
angular.module(Protiviti.Boilerplate.Client.Modules.Authentication.Name).controller(controllerId,
    ['$rootScope', '$scope', '$location', '$state', 'config', 'common', 'authService',
        ($rootScope, $scope, $location, $state, config, common, authService, controllerId) =>
            new Protiviti.Boilerplate.Client.Controllers.LoginController($rootScope, $scope, $location, $state, config, common, authService, controllerId)]);



module Protiviti.Boilerplate.Client.Controllers {

    declare var window: MyWindow;

    export interface IAppRootScope extends ng.IRootScopeService {
        oldState: any;
    }

    export interface ILoginData {
        userName: string;
        password: string;
    }

    export interface ILoginControllerScope extends ng.IScope {
        loginData: ILoginData;
        message: string;
        errorMessage: string;
        master: any;
        reset(): void;
        activate(): void;
        login(): void;
        authExternalProvider(provider: any): void;
        externalAuthenticationCompleted(fragment: any): void;
    }

    export interface MyWindow extends Window {
        $windowScope: any;
        open(url: string, caption: string, size: string): any;
    }

    export class LoginController {
        constructor(
            private $rootScope: IAppRootScope,
            private $scope: ILoginControllerScope,
            private $location: ng.ILocationService,
            private $state: ng.ui.IStateService,
            private config: any,
            private common: any,
            private authService: any,
            private controllerId: string
            ) {


            var getLogFn = common.logger.getLogFn;
            var log = getLogFn(controllerId);
            var path = '';

            //Reset method
            $scope.reset = () => {
                $scope.loginData = angular.copy($scope.master);
            }

        $scope.activate = () => {
                $scope.reset();
                $scope.message = "";
                common.activateController('', controllerId)
                    .then(function () {
                        log('Activated Login View');
                    });
            }

        $scope.login = () => {
                /*
                 * Calling the authentication service login function with promise
                 */
                authService.login($scope.loginData).then(function (status) {
                    //they were trying to go to initially
                    if (!status) {
                        $scope.errorMessage = 'Unable to login';
                        return;
                    }
                    /*
                     * As $state functions go and transitionTo are not passing parameters during state transitions hence
                     * using the global oldState i.e. at rootScope level param to implement the redirection feature after login
                     * will use the angularjs stateParams feature when found resolution for $state.go or $state.transitionTo
                     */

                    //if (status && $stateParams && $stateParams.redirect) {
                    //    path = path + $stateParams.redirect;
                    //}

                    //***************** 

                    if (angular.isDefined($rootScope.oldState)) {
                        path = path + $rootScope.oldState.url;
                    }
                    $rootScope.$broadcast(Modules.Authentication.events.userLoggedIn);
                    $rootScope.$broadcast(Modules.Authentication.events.userPermissionChanged);
                    $rootScope.$broadcast(Modules.Authentication.events.userAuthenticationChanged);

                    $location.path(path);
                },
                    function (err) {
                        $scope.message = err.error_description;
                    });
            };

            //External Provider Method
            $scope.authExternalProvider = (provider) => {

                var redirectUri = config.externalLoginRedirectUrl;
                
                var externalProviderUrl = config.remoteApiServiceBase + "account/externallogin?provider=" + provider
                    + "&response_type=token&client_id=" + config.ClientId
                    + "&redirect_uri=" + redirectUri;

                window.$windowScope = $scope;

                var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
            }

        //This method is executed after successful login from social logins for e.g. Google, Facebook etc.
            $scope.externalAuthenticationCompleted = (fragment) => {
                $scope.$apply(function () {

                    if (fragment.haslocalaccount == 'False') {

                        authService.logout();

                        authService.externalAuthData = {
                            provider: fragment.provider,
                            userName: fragment.external_user_name,
                            externalAccessToken: fragment.external_access_token
                        };
                        $state.go('associate');

                    }
                    else {
                        //Obtain access token 
                        var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };

                        authService.obtainAccessToken(externalData).then(function (response) {
                            $rootScope.$broadcast(Modules.Authentication.events.userLoggedIn);
                            $rootScope.$broadcast(Modules.Authentication.events.userPermissionChanged);
                            $rootScope.$broadcast(Modules.Authentication.events.userAuthenticationChanged);
                            $state.go('dashboard');

                        },
                            function (err) {
                                $scope.message = err.error_description;
                            });
                    }

                });
            }
    }
    }

}