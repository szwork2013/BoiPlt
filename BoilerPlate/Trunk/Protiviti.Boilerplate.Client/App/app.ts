// Entry point for angularjs app
module Protiviti.Boilerplate.Client {
    'use strict'
    var app = angular.module('app', [
    //Angular Module 
        'angular-loading-bar',
        'ngAnimate',
    // Custom modules 
        'common.bootstrap',     // bootstrap dialog wrapper functions
        Modules.Core.Name,
        Modules.Authentication.Name,
        Modules.RoleManager.Name,
        Modules.UserManager.Name,
        'angularFileUpload',
        'fileUpload',
        // 3rd Party Modules
        , 'breeze.angular'
        , 'breeze.directives'
        , 'ui.bootstrap'
        , 'kendo.directives'
        , 'xeditable'
        , 'infinite-scroll'
        , 'angulartics'
        , 'angulartics.google.analytics'
    ]);

    //#region Configure the common services via commonConfig

    app.config(['$httpProvider', $httpProvider => {
        $httpProvider.interceptors.push('authInterceptorService');
    }]);

    //#region Configure the Breeze Validation Directive
    app.config(['zDirectivesConfigProvider', function (cfg) {
        cfg.zValidateTemplate =
        '<span class="invalid"><i class="glyphicon glyphicon-warning-sign"></i>' +
        '%error%</span>';
    }]);

    app.run(['authService', authService => {
        authService.fillAuthData();
    }]);

    app.run(function (editableOptions) {
        editableOptions.theme = 'bs3'; // Try 'default'
    });
}