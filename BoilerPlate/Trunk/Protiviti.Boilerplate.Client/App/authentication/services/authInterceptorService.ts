
module Protiviti.Boilerplate.Client.Services {
'use strict'
angular.module(Modules.Authentication.Name).factory(Modules.Authentication.services.authenticationInterceptor,
        ['$rootScope', '$q', '$location', 'localStorageService', function ($rootScope, $q, $location, localStorageService) {

            var authInterceptorServiceFactory = {
                request: _request,
                responseError: _responseError
            };

            var _request = function (config) {
                config.headers = config.headers || {};

                /* Adding the authorization header in  every request if available  
                * This authorization header is based on OAuth bearer token
                */
                config.headers.Authorization = getHeaders();
                return config;
            }

            var _responseError = function (rejection) {
                /* If server return Unauthorized access i.e. HTTP Status Code=401
                 * Then redirect the user to login page
                 */
                switch (rejection.status) {
                    case 401: // UnAuthorized Request
                        /*
                         * If user is logged in and even then we are receiving the unauthorized response then
                         * most probably the requested resource is also protected "Roles" and "Users" level security
                         * then in this case redirect to not-authorized page rather than on login page
                         */
                        var authData = localStorageService.get(Modules.Authentication.bearerTokenName);
                        if (authData) {
                            $location.path(Modules.Authentication.Routes.notAuthorized);
                        } else {
                            $rootScope.$broadcast(Modules.Authentication.events.redirectToLogin, null);
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
            }

            authInterceptorServiceFactory.request = _request;
            authInterceptorServiceFactory.responseError = _responseError;

            return authInterceptorServiceFactory;


            // we have to include the Bearer token with each call to the Web API controllers. 
            function getHeaders() {
                var authData = localStorageService.get(Modules.Authentication.bearerTokenName);
                if (authData) {
                    return 'Bearer ' + authData.token;
                }
            }
        }]);
}