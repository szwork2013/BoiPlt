var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Modules) {
                'use strict';

                

                var UserManager = (function () {
                    function UserManager() {
                    }
                    UserManager.Name = "userManager";

                    UserManager.BaseUrl = "http://localhost/Protiviti.Boilerplate.Server/api/UserManager";
                    UserManager.services = {
                        userManager: 'userManagerService'
                    };

                    UserManager.controllers = {
                        updateUserDetails: 'UpdateUserRolesController',
                        listUsers: 'ListUsersController',
                        listExternalLogins: 'ListExternalLoginsController'
                    };
                    return UserManager;
                })();
                Modules.UserManager = UserManager;

                var app = angular.module(Modules.UserManager.Name, [
                    'ngRoute',
                    'LocalStorageModule',
                    'common',
                    Modules.Core.Name,
                    Modules.Authentication.Name
                ]);
            })(Client.Modules || (Client.Modules = {}));
            var Modules = Client.Modules;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=module.userManager.js.map
