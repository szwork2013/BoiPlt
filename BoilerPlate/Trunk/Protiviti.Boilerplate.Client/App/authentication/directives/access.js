var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Directives) {
                'use strict';

                var app = angular.module(Client.Modules.Authentication.Name);

                app.directive('access', [
                    'authService', function (authService) {
                        var directive = {
                            link: link,
                            restrict: 'AEC'
                        };
                        return directive;

                        function link(scope, element, attrs) {
                            if (!angular.isString(attrs.access))
                                throw "access value must be a string";

                            var makeVisible = function () {
                                element.removeClass('hidden');
                            };
                            var makeHidden = function () {
                                element.addClass('hidden');
                            };
                            function determineVisibility() {
                                var resetFirst = roles.length > 0 ? true : false;

                                var result;
                                if (resetFirst) {
                                    makeVisible();
                                }

                                result = authService.authorize(true, roles, attrs.accessPermissionType);
                                if (result === 0 /* authorised */) {
                                    makeVisible();
                                } else {
                                    makeHidden();
                                }
                            }
                            var roles = attrs.access.split(',');

                            determineVisibility();

                            scope.$on(Client.Modules.Authentication.events.userPermissionChanged, function () {
                                determineVisibility();
                            });
                        }
                    }]);
            })(Client.Directives || (Client.Directives = {}));
            var Directives = Client.Directives;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=access.js.map
