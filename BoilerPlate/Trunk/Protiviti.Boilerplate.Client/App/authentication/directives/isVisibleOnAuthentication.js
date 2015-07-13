var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Directives) {
                'use strict';

                var app = angular.module(Client.Modules.Authentication.Name);

                app.directive('isvisibleonauthentication', [
                    'authService', function (authService) {
                        var directive = {
                            link: link,
                            restrict: 'AEC'
                        };
                        return directive;

                        function link(scope, element, attrs) {
                            var makeVisible = function () {
                                element.removeClass('hidden');
                            };
                            var makeHidden = function () {
                                element.addClass('hidden');
                            };
                            function determineVisibility() {
                                var resetFirst = (attrs.isvisibleonauthentication == "true" || attrs.isvisibleonauthentication == true) ? true : false;

                                if (resetFirst) {
                                    makeVisible();
                                }
                                if (authService.currentUser.isAuthenticated && resetFirst == false) {
                                    makeHidden();
                                } else {
                                    makeVisible();
                                }
                            }

                            determineVisibility();

                            scope.$on(Client.Modules.Authentication.events.userAuthenticationChanged, function () {
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
//# sourceMappingURL=isVisibleOnAuthentication.js.map
