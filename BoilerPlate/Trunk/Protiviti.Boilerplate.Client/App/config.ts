module Protiviti.Boilerplate.Client.Modules {
        'use strict'

    var app = angular.module(Core.Name);

    // Configure Toastr
    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';

    var remoteServiceBase: string = 'http://localhost/protiviti.boilerplate.server/';
    var remoteApiServiceBase: string = remoteServiceBase + 'api/';


    var events = {
        controllerActivateSuccess: 'controller.activateSuccess',
        spinnerToggle: 'spinner.toggle'
    };

    var config = {
        appErrorPrefix: '[Boilerplate Error] ', //Configure the exceptionHandler decorator
        docTitle: 'CDS Boilerplate: ',
        events: events,
        remoteServiceBase: remoteServiceBase,
        remoteApiServiceBase: remoteApiServiceBase,
        externalLoginRedirectUrl: 'http://localhost/protiviti.boilerplate.client/externalLogin.html',
        version: '1.0.0',
        ClientId: 'ProtivitiBoilerplate'
    };

    app.value('config', config);

    app.config(['$logProvider', $logProvider => {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
    }]);

    /*Constants*/
    //Authentication Events
    app.constant('AUTH_EVENTS', {
        loginSuccess: 'auth-login-success',
        loginFailed: 'auth-login-failed',
        logoutSuccess: 'auth-logout-success',
        sessionTimeout: 'auth-session-timeout',
        notAuthenticated: 'auth-not-authenticated',
        notAuthorized: 'auth-not-authorized'
    });
    //Roles
    app.constant('USER_ROLES', {
        admin: 'admin',
        member: 'member',
    });

    app.value('UserSessionInfo', {
        isAuthenticated: false, // true, if user is logged in into the system
        isInternal: true,
        userName: "", //name used to logged in into system
        displayName: "", // Name to display on screen
        roles: "" // can contains multiple roles with comma separated string
    });
    //Urls 
    app.constant('SERVICE_URLS', {
        registerUser: 'account/register',

    });
}