var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Modules) {
                'use strict';

                

                var RoleManager = (function () {
                    function RoleManager() {
                    }
                    RoleManager.Name = "roleManager";

                    RoleManager.BaseUrl = "http://localhost/Protiviti.Boilerplate.Server/api/RoleManager";

                    RoleManager.services = {
                        roleManager: 'roleManagerService'
                    };

                    RoleManager.controllers = {
                        editRole: 'EditRoleController',
                        listRole: 'ListRolesController'
                    };
                    return RoleManager;
                })();
                Modules.RoleManager = RoleManager;

                var app = angular.module(Modules.RoleManager.Name, [
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
//# sourceMappingURL=module.roleManager.js.map
