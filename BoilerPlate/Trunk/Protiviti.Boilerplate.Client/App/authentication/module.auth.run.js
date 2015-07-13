var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Modules) {
                'use strict';

                var app = angular.module(Modules.Authentication.Name);

                app.run([
                    '$route', '$state', '$rootScope', '$location', 'authService', function ($route, $state, $rootScope, $location, authService) {
                        $rootScope.$on("$stateChangeStart", function (event, next) {
                            var authorised;
                            if (next.access !== undefined) {
                                $rootScope.oldState = $state.current;
                                authorised = authService.authorize(next.access.loginRequired, next.access.permissions, next.access.permissionCheckType);
                                if (authorised === 1 /* loginRequired */) {
                                    event.preventDefault();
                                    $state.go('login');
                                } else if (authorised === 2 /* notAuthorised */) {
                                    event.preventDefault();
                                    $state.go(Modules.Authentication.Routes.notAuthorized);
                                }
                            }
                        });
                    }]);
            })(Client.Modules || (Client.Modules = {}));
            var Modules = Client.Modules;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=module.auth.run.js.map
