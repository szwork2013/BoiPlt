var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Enums) {
                (function (Authorized) {
                    Authorized[Authorized["authorised"] = 0] = "authorised";
                    Authorized[Authorized["loginRequired"] = 1] = "loginRequired";
                    Authorized[Authorized["notAuthorised"] = 2] = "notAuthorised";
                })(Enums.Authorized || (Enums.Authorized = {}));
                var Authorized = Enums.Authorized;

                (function (PermissionCheckType) {
                    PermissionCheckType[PermissionCheckType["atLeastOne"] = 0] = "atLeastOne";
                    PermissionCheckType[PermissionCheckType["combinationRequired"] = 1] = "combinationRequired";
                })(Enums.PermissionCheckType || (Enums.PermissionCheckType = {}));
                var PermissionCheckType = Enums.PermissionCheckType;

                var UserRoles = (function () {
                    function UserRoles() {
                    }
                    UserRoles.Admin = "Admin";
                    return UserRoles;
                })();
                Enums.UserRoles = UserRoles;
            })(Client.Enums || (Client.Enums = {}));
            var Enums = Client.Enums;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=module.auth.enum.js.map
