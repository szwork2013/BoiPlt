var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Services) {
                'use strict';
                angular.module(Client.Modules.Authentication.Name).factory(Client.Modules.Authentication.services.authenticationInterceptor, [
                    '$rootScope', '$q', '$location', 'localStorageService', function ($rootScope, $q, $location, localStorageService) {
                        var authInterceptorServiceFactory = {
                            request: _request,
                            responseError: _responseError
                        };

                        var _request = function (config) {
                            config.headers = config.headers || {};

                            config.headers.Authorization = getHeaders();
                            return config;
                        };

                        var _responseError = function (rejection) {
                            switch (rejection.status) {
                                case 401:
                                    var authData = localStorageService.get(Client.Modules.Authentication.bearerTokenName);
                                    if (authData) {
                                        $location.path(Client.Modules.Authentication.Routes.notAuthorized);
                                    } else {
                                        $rootScope.$broadcast(Client.Modules.Authentication.events.redirectToLogin, null);
                                    }
                                    break;
                                case 400:
                                    if (rejection.data.error === 'user_requiresverification') {
                                        $rootScope.requiresverification = rejection.config;
                                        $location.path(Client.Modules.Authentication.Routes.verifyCode);
                                    }
                                    break;
                                default:
                            }
                            return $q.reject(rejection);
                        };

                        authInterceptorServiceFactory.request = _request;
                        authInterceptorServiceFactory.responseError = _responseError;

                        return authInterceptorServiceFactory;

                        function getHeaders() {
                            var authData = localStorageService.get(Client.Modules.Authentication.bearerTokenName);
                            if (authData) {
                                return 'Bearer ' + authData.token;
                            }
                        }
                    }]);
            })(Client.Services || (Client.Services = {}));
            var Services = Client.Services;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=authInterceptorService.js.map
