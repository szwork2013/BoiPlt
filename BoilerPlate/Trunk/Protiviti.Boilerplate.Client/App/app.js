var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            'use strict';
            var app = angular.module('app', [
                'angular-loading-bar',
                'ngAnimate',
                'common.bootstrap',
                Client.Modules.Core.Name,
                Client.Modules.Authentication.Name,
                Client.Modules.RoleManager.Name,
                Client.Modules.UserManager.Name,
                'angularFileUpload',
                'fileUpload',
                ,
                'breeze.angular',
                'breeze.directives',
                'ui.bootstrap',
                'kendo.directives',
                'xeditable',
                'infinite-scroll',
                'angulartics',
                'angulartics.google.analytics'
            ]);

            app.config([
                '$httpProvider', function ($httpProvider) {
                    $httpProvider.interceptors.push('authInterceptorService');
                }]);

            app.config([
                'zDirectivesConfigProvider', function (cfg) {
                    cfg.zValidateTemplate = '<span class="invalid"><i class="glyphicon glyphicon-warning-sign"></i>' + '%error%</span>';
                }]);

            app.run([
                'authService', function (authService) {
                    authService.fillAuthData();
                }]);

            app.run(function (editableOptions) {
                editableOptions.theme = 'bs3';
            });
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=app.js.map
