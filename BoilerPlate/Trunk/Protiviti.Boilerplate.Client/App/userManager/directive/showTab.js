var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Directives) {
                'use strict';

                var app = angular.module(Client.Modules.UserManager.Name);

                app.directive('showtab', [
                    '', function (authService) {
                        return {
                            link: function (scope, element, attrs) {
                                element.click(function (e) {
                                    e.preventDefault();
                                    $(element).tab('show');
                                });
                            }
                        };
                    }]);
            })(Client.Directives || (Client.Directives = {}));
            var Directives = Client.Directives;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=showTab.js.map
