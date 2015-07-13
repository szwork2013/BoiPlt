(function () {
    'use strict';

    var controllerId = 'topnav';
    angular.module('app').controller(controllerId,
        ['$rootScope', '$scope', '$location', '$route', '$state', '$stateParams', 'config', 'routes', 'authService', topnav]);

    function topnav($rootScope, $scope, $location, $route, $state, $stateParams, config, routes, authService) {

        $scope.logOut = function () {
            authService.logout();
            $location.path('/');
        }
        $scope.displayName = "";

        $scope.currentUser = authService.currentUser;

        $scope.isAdmin = "";

        var vm = this;

        vm.isCurrent = isCurrent;

        activate();

        function activate() {
            //Check whether the logged in user is admin  or not
            if (angular.isDefined(authService.currentUser.roles)) {
                $scope.isAdmin = (authService.currentUser.roles.indexOf("Admin") > -1 ? true : false);
            }
            else {
                $scope.isAdmin = false;
            }
            getNavRoutes();
            setLoggedInUserDisplayName();
        }

        function getNavRoutes() {
            var allRoutes = routes.filter(function (r) {
                return r.settings && r.settings.nav;
            }).sort(function (r1, r2) {
                return r1.settings.nav - r2.settings.nav;
            });
            vm.navRoutes = $.grep(allRoutes, function (r) {
                return (r.url != '/login' && r.url != '/signup');
            });
        }

        function isCurrent(route) {
            if (!route.title || !$route.current || !$route.current.title) {
                return '';
            }
            var menuName = route.title;
            return $route.current.title.substr(0, menuName.length) === menuName ? 'current' : '';
        }

        $scope.loginOut = function () {
            var isAuthenticated = authService.currentUser.isAuthenticated;
            if (isAuthenticated) { //logout 
                authService.logout().then(function () {
                    $location.path('/');
                    setLoggedInUserDisplayName();
                    $rootScope.$broadcast('permissionsChanged');
                    $rootScope.$broadcast('authenticationChanged');
                    return;
                });
            }
        };

        $scope.$on('userLoggedIn', function (loggedIn) {
            setLoggedInUserDisplayName();
            setAdminStatus();
        });

        function setAdminStatus() {
            if (angular.isDefined(authService.currentUser.roles)) {
                $scope.isAdmin = (authService.currentUser.roles.indexOf("Admin") > -1 ? true : false);
            }
            else {
                $scope.isAdmin = false;
            }
        }
        //Setting custom display name for screen
        function setLoggedInUserDisplayName() {
            var displayName = authService.currentUser.displayName;
            $scope.displayName = displayName !== "" && typeof (displayName) !== "undefined" && authService.currentUser.isAuthenticated ? displayName : authService.currentUser.userName;
        }
    };
})();
