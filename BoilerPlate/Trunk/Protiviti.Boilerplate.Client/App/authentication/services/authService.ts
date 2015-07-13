module Protiviti.Boilerplate.Client.Services {
'use strict'

    angular.module(Modules.Authentication.Name).factory(Modules.Authentication.services.authentication,
        ['$http', '$rootScope', '$location', 'config', 'common', 'localStorageService', 'UserSessionInfo', 'modalService',
            ($http, $rootScope, $location, config, common, localStorageService, user, modalService) =>
                new Protiviti.Boilerplate.Client.Services.AuthenticationService($http, $rootScope, $location, config, common, localStorageService, user, modalService)]);

    export interface IAuthenticationService {
        saveRegistration(registration: any): ng.IPromise<any>;
        login(loginData: ILoginData): ng.IPromise<any>;
        logout(): ng.IPromise<any>;
        fillAuthData(): void;
        redirectToLogin(): void;
        userHasRole(role: string): boolean;
        currentUser(): any;
        authorize(loginRequired: boolean, requiredPermissions: string, permissionCheckType: string): number;
        obtainAccessToken(externalData: any): ng.IPromise<any>;
        registerExternal(registerExternalData: any);

    }

    export interface ILoginData {
        email: string;
        password: string;
        displayName: string;
    }

    var externalAuthData = {
        provider: "",
        userName: "",
        externalAccessToken: ""
    };

    export class AuthenticationService implements IAuthenticationService {
        private config: any;
        private $rootScope: any;
        private common: any;
        private $q: ng.IQService;
        private localStorageService: any;
        private user: any;
        private $http: any;
        private modalService: any;
        private $location: ng.ILocationService;

        constructor($http: any, $rootScope: any, $location: ng.ILocationService, config: any, common: any, localStorageService: any, user: any, modalService: any) {
            this.$rootScope = $rootScope;
            this.$http = $http;
            this.config = config;
            this.common = common;
            this.$q = common.$q;
            this.localStorageService = localStorageService;
            this.user = user;
            this.modalService = modalService;
            this.$location = $location;
        }

        public redirectToLogin(): void {
            //clear user profile data from client
            //this.logout();
            this.$rootScope.$broadcast(Modules.Authentication.events.redirectToLogin, null);
        }

        // Checking whether user has role or not
        public userHasRole(role: string): boolean {
            var hasRole: boolean = false;

            return hasRole;
        }

        public get currentUser(): any {
            return this.user;
        }

        /* Register new user */
        public saveRegistration(registration: any): ng.IPromise<any> {
            var self = this;
            this.logout();
            var result = '';
            this.$http.post(this.config.remoteApiServiceBase + 'account/register', registration).success(function (response: any) {
                self.$rootScope.requiresverification = "username=" + registration.email + "&password=" + registration.password;
                self.$location.path(Client.Modules.Authentication.Routes.verifyCode);
                self.$q.defer().resolve(response);
            }).error(function (err, status) {
                    self.$rootScope.$broadcast(Modules.Authentication.events.signInError, err);
                    self.$q.reject(err);
                });

            return this.$q.when(result);
        }

        /* Logout the current logged in user
        * This will remove the authentication token key 'authorizationData' from client browser's local storage
        */
        public logout(): ng.IPromise<any> {
            this.localStorageService.remove(Modules.Authentication.bearerTokenName);
            this.user.isAuthenticated = false;
            this.user.userName = "";
            this.user.displayName = "";
            this.user.isInternal = "";
            this.user.roles = "";
            return this.$q.when(this.user);
        }

        public fillAuthData(): void {
            var authData: any = this.localStorageService.get(Modules.Authentication.bearerTokenName);
            if (authData) {
                this.user.isAuthenticated = true;
                this.user.userName = authData.email;
                this.user.displayName = authData.displayName;
                this.user.roles = authData.roles;
                this.user.isInternal = authData.isInternal;
            }
        }

        /** Request Authentication Token
         * This function uses the OAuth resource owner credentials method to get the token
         * After receiving the token storing it on client's browser's local storage with key 'authorizationData' for further processing
         */
        public login(loginData: ILoginData): ng.IPromise<any> {
            var self = this;
            var formData = { username: loginData.email, password: loginData.password, grant_type: 'password' };
            var deferred: any = this.$q.defer();
            this.$http.post(this.config.remoteServiceBase + 'token', this.buildFormData(formData), { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response: any) {
                    self.localStorageService.set(Modules.Authentication.bearerTokenName,
                        { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles, isInternal: true });

                    self.user.isAuthenticated = true;
                    self.user.isInternal = true;
                    self.user.userName = response.userName;
                    self.user.displayName = response.displayName;
                    self.user.roles = response.roles;

                    deferred.resolve(response);
                }).error(function (error) {
                    alert(error.error_description);
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        /*
         * Authorize the user 
         */
        public authorize(loginRequired: boolean, requiredPermissions: string, permissionCheckType: string): number {
            var result = Enums.Authorized.authorised,
                user = this.user,
                loweredPermissions = [],
                hasPermission = true,
                permission, i;

            //Checking the permission type if not set then set for atleastone.
            permissionCheckType = permissionCheckType || Enums.PermissionCheckType.atLeastOne.toString();

            if (loginRequired === true && user.isAuthenticated === false) {
                result = Enums.Authorized.loginRequired;
            } else if ((loginRequired === true && user.isAuthenticated === true) &&
                (requiredPermissions === undefined || requiredPermissions.length === 0)) {
                // Login is required but no specific permissions are specified.
                result = Enums.Authorized.authorised;
            } else if (loginRequired === false && user.isAuthenticated === false) {
                // Login is not required.
                result = Enums.Authorized.notAuthorised;
            } else if (user.isAuthenticated === true && requiredPermissions.length > 0) {
                loweredPermissions = [];
                if (angular.isArray(user.roles.split(','))) {
                    angular.forEach(user.roles.split(','), function (permission) {
                        loweredPermissions.push(permission.toLowerCase());
                    });
                }
                else {
                    loweredPermissions.push(user.roles.toLowerCase());
                }
                /*
                 * If logged in user have some roles then
                 * Admin user have all permissions
                 */
                if (loweredPermissions.length > 0 && loweredPermissions.indexOf(Enums.UserRoles.Admin.toLowerCase()) < 0) {
                    for (i = 0; i < requiredPermissions.length; i += 1) {
                        permission = requiredPermissions[i].toLowerCase();

                        if (permissionCheckType === Enums.PermissionCheckType.combinationRequired.toString()) {
                            hasPermission = hasPermission && loweredPermissions.indexOf(permission) > -1;
                            // if all the permissions are required and hasPermission is false there is no point carrying on
                            if (hasPermission === false) {
                                break;
                            }
                        } else if (permissionCheckType === Enums.PermissionCheckType.atLeastOne.toString()) {
                            hasPermission = loweredPermissions.indexOf(permission) > -1;
                            // if we only need one of the permissions and we have it there is no point carrying on
                            if (hasPermission) {
                                break;
                            }
                        }
                    }
                }
                result = hasPermission ? Enums.Authorized.authorised : Enums.Authorized.notAuthorised;
            }

            return result;
        }

        /*
         * Build request in OAuth format.
         */
        public buildFormData = function (formData) {
            var dataString = '';
            for (var prop in formData) {
                if (formData.hasOwnProperty(prop)) {
                    dataString += (prop + '=' + formData[prop] + '&');
                }
            }
            return dataString.slice(0, dataString.length - 1);
        }

        public obtainAccessToken(externalData: any): ng.IPromise<any> {
            var self = this;
            var deferred = this.$q.defer();

            this.$http.get(this.config.remoteApiServiceBase + 'account/ObtainLocalAccessToken',
                { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } })
                .success(function (response) {
                    if (response != null) {
                        self.localStorageService.set(Modules.Authentication.bearerTokenName,
                            { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles, isInternal: false });

                        self.user.isAuthenticated = true;
                        self.user.isInternal = false;
                        self.user.userName = response.userName;
                        self.user.displayName = response.displayName;
                        self.user.roles = response.roles;

                        deferred.resolve(response);
                    }
                    else {
                        var modalOptions = {
                            closeButtonText: 'Cancel',
                            actionButtonText: 'Ok',
                            headerText: 'Info ?',
                            bodyText: 'There is a problem in authenticating you in system. Please check with your site admin for this.'
                        };

                        self.modalService.showModal({}, modalOptions).then(function (result) {
                            if (result === 'ok') {

                            }
                        });
                    }

                }).error(function (err, status) {
                    self.logout();
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        public registerExternal(registerExternalData: any): ng.IPromise<any> {
            var self = this;
            var deferred = this.$q.defer();

            this.$http.post(this.config.remoteApiServiceBase + 'account/registerexternal', registerExternalData).success(function (response) {

                self.localStorageService.set(Modules.Authentication.bearerTokenName,
                    { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles, isInternal: false });

                self.user.isAuthenticated = true;
                self.user.isInternal = false;
                self.user.userName = response.userName;
                self.user.displayName = response.displayName;
                self.user.roles = response.roles;

                deferred.resolve(response);

            }).error(function (err, status) {
                    self.logout();
                    deferred.reject(err);
                });

            return deferred.promise;

        }

    }
}