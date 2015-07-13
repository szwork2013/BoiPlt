// Entry point for angularjs app
module Protiviti.Boilerplate.Client.Modules {
    'use strict'

    var app = angular.module(Modules.Authentication.Name);

    app.run(['$route', '$state', '$rootScope', '$location', 'authService', function ($route, $state, $rootScope, $location, authService) {
        /*
         * Include $route (or $state for ui-router) to kick start the router.
         * Client-side security. Server-side framework MUST add it's own security as well since client-based security is easily hacked
         */
        $rootScope.$on("$stateChangeStart", function (event, next) {
            var authorised;
            if (next.access !== undefined) {
                $rootScope.oldState = $state.current;
                authorised = authService.authorize(next.access.loginRequired, next.access.permissions, next.access.permissionCheckType);
                if (authorised === Enums.Authorized.loginRequired) {
                    event.preventDefault();
                    $state.go('login');
                } else if (authorised === Enums.Authorized.notAuthorised) {
                    event.preventDefault();
                    $state.go(Authentication.Routes.notAuthorized);
                }
            }
        });
    }]);
} 