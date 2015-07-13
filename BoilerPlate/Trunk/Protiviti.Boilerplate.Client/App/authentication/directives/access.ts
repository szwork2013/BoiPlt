module Protiviti.Boilerplate.Client.Directives {
    'use strict';

    var app = angular.module(Modules.Authentication.Name);

    app.directive('access', ['authService', function (authService) {
        //Usage:
        //<div access="Admin">......</div>
        var directive = {
            link: link,
            restrict: 'AEC' //E = element, A = attribute, C = class, M = comment   
        };
        return directive;

        function link(scope, element, attrs) { //DOM manipulation
            if (!angular.isString(attrs.access))
                throw "access value must be a string";
            
            var makeVisible = function () {
                element.removeClass('hidden');
            }
            var makeHidden = function () {
                element.addClass('hidden');
            }
            function determineVisibility () {
                var resetFirst = roles.length > 0 ? true : false;

                var result;
                if (resetFirst) {
                    makeVisible();
                }

                result = authService.authorize(true, roles, attrs.accessPermissionType);
                if (result === Enums.Authorized.authorised) {
                    makeVisible();
                } else {
                    makeHidden();
                }
            }
            var roles = attrs.access.split(',');

            determineVisibility();

            scope.$on(Modules.Authentication.events.userPermissionChanged, function () {
                determineVisibility();
            });

        }
    }]);
} 