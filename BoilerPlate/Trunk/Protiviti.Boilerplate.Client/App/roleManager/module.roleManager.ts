module Protiviti.Boilerplate.Client.Modules {
    'use strict'
    // #region Interfaces

    export interface IRoleManagerControllers {
        editRole: string;
        listRole: string;

    }

    export interface IRoleManagerServices {
        roleManager: string;
    }

    /*
     * Settings can be used in authentication module
     */
    export class RoleManager {
        public static Name: string = "roleManager";

        public static BaseUrl: string = "http://localhost/Protiviti.Boilerplate.Server/api/RoleManager";

        public static services: IRoleManagerServices = {
            roleManager: 'roleManagerService'
        }

        public static controllers: IRoleManagerControllers = {
            editRole: 'EditRoleController',
            listRole: 'ListRolesController'
        }
    }

    /*
     * Angular module
     */

    var app = angular.module(Modules.RoleManager.Name, [
        'ngRoute',
        'LocalStorageModule',
        'common',
        Modules.Core.Name,
        Modules.Authentication.Name
    ]);
} 