module Protiviti.Boilerplate.Client.Directives {
    'use strict';

    var app = angular.module(Modules.Authentication.Name);

    app.directive('isvisibleonauthentication', ['authService', function (authService) {
        //Usage:
        //<div isVisiableOnAuthentication=true>......</div>
        var directive = {
            link: link,
            restrict: 'AEC' //E = element, A = attribute, C = class, M = comment   
        };
        return directive;

        function link(scope, element, attrs) { //DOM manipulation

            var makeVisible = function () {
                element.removeClass('hidden');
            }
            var makeHidden = function () {
                element.addClass('hidden');
            }
            function determineVisibility() {

                var resetFirst = (attrs.isvisibleonauthentication == "true" || attrs.isvisibleonauthentication == true) ? true : false;

                if (resetFirst) {
                    makeVisible();
                }
                if (authService.currentUser.isAuthenticated && resetFirst== false) {
                    makeHidden();
                    
                } else {
                    makeVisible();
                }
            }

            determineVisibility();

            scope.$on(Modules.Authentication.events.userAuthenticationChanged, function () {
                determineVisibility();
            });

        }
    }]);
} 