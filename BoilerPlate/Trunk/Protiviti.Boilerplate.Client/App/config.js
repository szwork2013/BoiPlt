var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Modules) {
                'use strict';

                var app = angular.module(Modules.Core.Name);

                toastr.options.timeOut = 4000;
                toastr.options.positionClass = 'toast-bottom-right';

                var remoteServiceBase = 'http://localhost/protiviti.boilerplate.server/';
                var remoteApiServiceBase = remoteServiceBase + 'api/';

                var events = {
                    controllerActivateSuccess: 'controller.activateSuccess',
                    spinnerToggle: 'spinner.toggle'
                };

                var config = {
                    appErrorPrefix: '[Boilerplate Error] ',
                    docTitle: 'CDS Boilerplate: ',
                    events: events,
                    remoteServiceBase: remoteServiceBase,
                    remoteApiServiceBase: remoteApiServiceBase,
                    externalLoginRedirectUrl: 'http://localhost/protiviti.boilerplate.client/externalLogin.html',
                    version: '1.0.0',
                    ClientId: 'ProtivitiBoilerplate'
                };

                app.value('config', config);

                app.config([
                    '$logProvider', function ($logProvider) {
                        if ($logProvider.debugEnabled) {
                            $logProvider.debugEnabled(true);
                        }
                    }]);

                app.constant('AUTH_EVENTS', {
                    loginSuccess: 'auth-login-success',
                    loginFailed: 'auth-login-failed',
                    logoutSuccess: 'auth-logout-success',
                    sessionTimeout: 'auth-session-timeout',
                    notAuthenticated: 'auth-not-authenticated',
                    notAuthorized: 'auth-not-authorized'
                });

                app.constant('USER_ROLES', {
                    admin: 'admin',
                    member: 'member'
                });

                app.value('UserSessionInfo', {
                    isAuthenticated: false,
                    isInternal: true,
                    userName: "",
                    displayName: "",
                    roles: ""
                });

                app.constant('SERVICE_URLS', {
                    registerUser: 'account/register'
                });
            })(Client.Modules || (Client.Modules = {}));
            var Modules = Client.Modules;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=config.js.map
