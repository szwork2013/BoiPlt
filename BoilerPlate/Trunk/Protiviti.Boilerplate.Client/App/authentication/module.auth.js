var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Modules) {
                'use strict';

                

                var Authentication = (function () {
                    function Authentication() {
                    }
                    Object.defineProperty(Authentication, "Routes", {
                        get: function () {
                            return this._routes;
                        },
                        enumerable: true,
                        configurable: true
                    });
                    Authentication.Name = "auth";

                    Authentication.events = {
                        userLoggedIn: 'userLoggedIn',
                        userLoggedOut: 'userLoggedOut',
                        userPermissionChanged: 'permissionsChanged',
                        userAuthenticationChanged: 'authenticationChanged',
                        redirectToLogin: 'redirectToLogin',
                        signInError: 'registerationValidationError'
                    };

                    Authentication.services = {
                        authentication: 'authService',
                        authenticationInterceptor: 'authInterceptorService'
                    };

                    Authentication.controllers = {
                        login: 'loginController',
                        associate: 'associateController',
                        verifyCode: 'verifyCodeController'
                    };

                    Authentication._routes = {
                        login: '/login',
                        notAuthorized: '/not-authorised',
                        verifyCode: 'verifycode'
                    };

                    Authentication.bearerTokenName = "authorizationData";
                    return Authentication;
                })();
                Modules.Authentication = Authentication;

                var app = angular.module(Modules.Authentication.Name, [
                    'ngRoute',
                    'LocalStorageModule',
                    'common',
                    Modules.Core.Name
                ]);
            })(Client.Modules || (Client.Modules = {}));
            var Modules = Client.Modules;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=module.auth.js.map
