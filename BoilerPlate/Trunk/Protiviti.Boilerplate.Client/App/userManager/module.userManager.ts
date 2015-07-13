module Protiviti.Boilerplate.Client.Modules {
    'use strict'
    // #region Interfaces

    export interface IUserManagerControllers {
        updateUserDetails: string;
        listUsers: string;
        listExternalLogins: string;

    }

    export interface IUserManagerServices {
        userManager: string;
    }

    /*
     * Settings can be used in authentication module
     */
    export class UserManager {
        public static Name: string = "userManager";

        public static BaseUrl: string = "http://localhost/Protiviti.Boilerplate.Server/api/UserManager";
        public static services: IUserManagerServices = {
            userManager: 'userManagerService'
        }

        public static controllers: IUserManagerControllers = {
            updateUserDetails: 'UpdateUserRolesController',
            listUsers: 'ListUsersController',
            listExternalLogins: 'ListExternalLoginsController'
        }
    }

    /*
     * Angular module
     */

    var app = angular.module(Modules.UserManager.Name, [
        'ngRoute',
        'LocalStorageModule',
        'common',
        Modules.Core.Name,
        Modules.Authentication.Name
    ]);
} 