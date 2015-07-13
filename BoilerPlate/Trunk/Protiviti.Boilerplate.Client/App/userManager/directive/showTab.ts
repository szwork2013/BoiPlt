module Protiviti.Boilerplate.Client.Directives {
    'use strict';

    var app = angular.module(Modules.UserManager.Name);

    app.directive('showtab', ['', function (authService) {
        
        return {
            link: function (scope, element, attrs) {
                element.click(function (e) {
                    e.preventDefault();
                    $(element).tab('show');
                });
            }
        };
        
    }]);
} 