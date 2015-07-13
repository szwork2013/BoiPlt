var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Services) {
                'use strict';

                angular.module(Client.Modules.Authentication.Name).factory(Client.Modules.Authentication.services.authentication, [
                    '$http', '$rootScope', '$location', 'config', 'common', 'localStorageService', 'UserSessionInfo', 'modalService',
                    function ($http, $rootScope, $location, config, common, localStorageService, user, modalService) {
                        return new Protiviti.Boilerplate.Client.Services.AuthenticationService($http, $rootScope, $location, config, common, localStorageService, user, modalService);
                    }]);

                var externalAuthData = {
                    provider: "",
                    userName: "",
                    externalAccessToken: ""
                };

                var AuthenticationService = (function () {
                    function AuthenticationService($http, $rootScope, $location, config, common, localStorageService, user, modalService) {
                        this.buildFormData = function (formData) {
                            var dataString = '';
                            for (var prop in formData) {
                                if (formData.hasOwnProperty(prop)) {
                                    dataString += (prop + '=' + formData[prop] + '&');
                                }
                            }
                            return dataString.slice(0, dataString.length - 1);
                        };
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
                    AuthenticationService.prototype.redirectToLogin = function () {
                        this.$rootScope.$broadcast(Client.Modules.Authentication.events.redirectToLogin, null);
                    };

                    AuthenticationService.prototype.userHasRole = function (role) {
                        var hasRole = false;

                        return hasRole;
                    };

                    Object.defineProperty(AuthenticationService.prototype, "currentUser", {
                        get: function () {
                            return this.user;
                        },
                        enumerable: true,
                        configurable: true
                    });

                    AuthenticationService.prototype.saveRegistration = function (registration) {
                        var self = this;
                        this.logout();
                        var result = '';
                        this.$http.post(this.config.remoteApiServiceBase + 'account/register', registration).success(function (response) {
                            self.$rootScope.requiresverification = "username=" + registration.email + "&password=" + registration.password;
                            self.$location.path(Client.Modules.Authentication.Routes.verifyCode);
                            self.$q.defer().resolve(response);
                        }).error(function (err, status) {
                            self.$rootScope.$broadcast(Client.Modules.Authentication.events.signInError, err);
                            self.$q.reject(err);
                        });

                        return this.$q.when(result);
                    };

                    AuthenticationService.prototype.logout = function () {
                        this.localStorageService.remove(Client.Modules.Authentication.bearerTokenName);
                        this.user.isAuthenticated = false;
                        this.user.userName = "";
                        this.user.displayName = "";
                        this.user.isInternal = "";
                        this.user.roles = "";
                        return this.$q.when(this.user);
                    };

                    AuthenticationService.prototype.fillAuthData = function () {
                        var authData = this.localStorageService.get(Client.Modules.Authentication.bearerTokenName);
                        if (authData) {
                            this.user.isAuthenticated = true;
                            this.user.userName = authData.email;
                            this.user.displayName = authData.displayName;
                            this.user.roles = authData.roles;
                            this.user.isInternal = authData.isInternal;
                        }
                    };

                    AuthenticationService.prototype.login = function (loginData) {
                        var self = this;
                        var formData = { username: loginData.email, password: loginData.password, grant_type: 'password' };
                        var deferred = this.$q.defer();
                        this.$http.post(this.config.remoteServiceBase + 'token', this.buildFormData(formData), { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                            self.localStorageService.set(Client.Modules.Authentication.bearerTokenName, { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles, isInternal: true });

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
                    };

                    AuthenticationService.prototype.authorize = function (loginRequired, requiredPermissions, permissionCheckType) {
                        var result = 0 /* authorised */, user = this.user, loweredPermissions = [], hasPermission = true, permission, i;

                        permissionCheckType = permissionCheckType || 0 /* atLeastOne */.toString();

                        if (loginRequired === true && user.isAuthenticated === false) {
                            result = 1 /* loginRequired */;
                        } else if ((loginRequired === true && user.isAuthenticated === true) && (requiredPermissions === undefined || requiredPermissions.length === 0)) {
                            result = 0 /* authorised */;
                        } else if (loginRequired === false && user.isAuthenticated === false) {
                            result = 2 /* notAuthorised */;
                        } else if (user.isAuthenticated === true && requiredPermissions.length > 0) {
                            loweredPermissions = [];
                            if (angular.isArray(user.roles.split(','))) {
                                angular.forEach(user.roles.split(','), function (permission) {
                                    loweredPermissions.push(permission.toLowerCase());
                                });
                            } else {
                                loweredPermissions.push(user.roles.toLowerCase());
                            }

                            if (loweredPermissions.length > 0 && loweredPermissions.indexOf(Client.Enums.UserRoles.Admin.toLowerCase()) < 0) {
                                for (i = 0; i < requiredPermissions.length; i += 1) {
                                    permission = requiredPermissions[i].toLowerCase();

                                    if (permissionCheckType === 1 /* combinationRequired */.toString()) {
                                        hasPermission = hasPermission && loweredPermissions.indexOf(permission) > -1;

                                        if (hasPermission === false) {
                                            break;
                                        }
                                    } else if (permissionCheckType === 0 /* atLeastOne */.toString()) {
                                        hasPermission = loweredPermissions.indexOf(permission) > -1;

                                        if (hasPermission) {
                                            break;
                                        }
                                    }
                                }
                            }
                            result = hasPermission ? 0 /* authorised */ : 2 /* notAuthorised */;
                        }

                        return result;
                    };

                    AuthenticationService.prototype.obtainAccessToken = function (externalData) {
                        var self = this;
                        var deferred = this.$q.defer();

                        this.$http.get(this.config.remoteApiServiceBase + 'account/ObtainLocalAccessToken', { params: { provider: externalData.provider, externalAccessToken: externalData.externalAccessToken } }).success(function (response) {
                            if (response != null) {
                                self.localStorageService.set(Client.Modules.Authentication.bearerTokenName, { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles, isInternal: false });

                                self.user.isAuthenticated = true;
                                self.user.isInternal = false;
                                self.user.userName = response.userName;
                                self.user.displayName = response.displayName;
                                self.user.roles = response.roles;

                                deferred.resolve(response);
                            } else {
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
                    };

                    AuthenticationService.prototype.registerExternal = function (registerExternalData) {
                        var self = this;
                        var deferred = this.$q.defer();

                        this.$http.post(this.config.remoteApiServiceBase + 'account/registerexternal', registerExternalData).success(function (response) {
                            self.localStorageService.set(Client.Modules.Authentication.bearerTokenName, { token: response.access_token, userName: response.userName, displayName: response.displayName, roles: response.roles, isInternal: false });

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
                    };
                    return AuthenticationService;
                })();
                Services.AuthenticationService = AuthenticationService;
            })(Client.Services || (Client.Services = {}));
            var Services = Client.Services;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=authService.js.map
