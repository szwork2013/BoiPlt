module Protiviti.Boilerplate.Client.Enums {
    export enum Authorized {
        authorised= 0,
        loginRequired= 1,
        notAuthorised= 2
    }

    export enum PermissionCheckType {
        atLeastOne= 0,
        combinationRequired= 1
    }

    export class UserRoles {
        public static Admin: string = "Admin";
    }
} 