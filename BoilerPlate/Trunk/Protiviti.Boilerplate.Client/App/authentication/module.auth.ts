module Protiviti.Boilerplate.Client.Modules {
    'use strict'
    // #region Interfaces
    export interface IAuthenticationEvents {
        userLoggedIn: string;
        userLoggedOut: string;
        userPermissionChanged: string;
        userAuthenticationChanged: string;
        redirectToLogin: string;
        signInError: string;
    }

    export interface IAuthenticationControllers {
        login: string;
        associate: string;
        verifyCode: string;
    }

    export interface IAuthenticationRoutes {
        login: string;
        notAuthorized: string;
        verifyCode: string;
    }

    export interface IAuthenticationServices {
        authentication: string;
        authenticationInterceptor: string;
    }

    /*
     * Settings can be used in authentication module
     */
    export class Authentication {
        public static Name: string = "auth";
        //public static get Name(): string { return this._name; }
        public static events: IAuthenticationEvents = {
            userLoggedIn: 'userLoggedIn',
            userLoggedOut: 'userLoggedOut',
            userPermissionChanged: 'permissionsChanged',
            userAuthenticationChanged: 'authenticationChanged',
            redirectToLogin: 'redirectToLogin',
            signInError: 'registerationValidationError'
        }

        public static services: IAuthenticationServices = {
            authentication: 'authService',
            authenticationInterceptor: 'authInterceptorService'
        }

        public static controllers: IAuthenticationControllers = {
            login: 'loginController',
            associate: 'associateController',
            verifyCode: 'verifyCodeController'
        }
        
        private static _routes: IAuthenticationRoutes = {
            login: '/login',
            notAuthorized: '/not-authorised',
            verifyCode: 'verifycode'
        }

        public static get Routes(): IAuthenticationRoutes { return this._routes; }

        public static bearerTokenName: string = "authorizationData";
    }


    /*
     * Angular module
     */

    var app = angular.module(Modules.Authentication.Name, [
        'ngRoute',
        'LocalStorageModule',
        'common',
        Modules.Core.Name
    ]);
} 