module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = Modules.RoleManager.controllers.listRole.toString();
    angular.module(Modules.RoleManager.Name).controller(controllerId,
        ['$http', '$scope', '$state', 'common', 'authService', 'dataservice', 'modalService','config', ListRolesController]);

    function ListRolesController($http, $scope, $state, common, authService, dataservice, modalService, config) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var path = '';

        // Initialize dataservice with a web api controller
        dataservice.initialize("RoleManager", config.remoteApiServiceBase);

        // Properties
        $scope.initializing = true;
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.roles = [];
        $scope.title = 'List Roles';
        $scope.allowCollapse = true;
        //$scope.showPager = false;
        $scope.pagingInfo = {
            page: 1,
            itemsPerPage: 10,
            orderBy: 'Name',
            nameFilter: '',
            totalItems: 100,
            reverse: false
        };

        // Watch methods
        $scope.$watch('pagingInfo.nameFilter', function () {
            if (!$scope.initializing) {
                $scope.searchRoles();
                $scope.showPager();
            }
        });

        $scope.showPager = function () {
            if ($scope.roles.length >= $scope.pagingInfo.itemsPerPage) {
                return true;
            } else { return false };

        }

        $scope.deleteRole = function (roleId,roleName) {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Role',
                headerText: 'Delete ' + roleName + '?',
                bodyText: 'Are you sure you want to delete this role?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    var newRole = { Id: roleId, Name: roleName }
                    $http.post(Modules.RoleManager.BaseUrl + '/DeleteRole', newRole).then(function (response) {
                        if (response.data.Succeeded == true) {
                            for (var i = 0; i < $scope.roles.length; i++) {
                                if ($scope.roles[i].Name == roleName) {
                                    $scope.roles.splice(i, 1);
                                    break;
                                }
                            }
                        }
                        else {
                            alert(response.data.Errors[0]);
                        }

                    }), (function (error) {
                        alert("Error deleting role: " + error);
                    });
                }
            });
        }

        // Methods
        $scope.getRoles = function () {
            $scope.selectFirstPage();
        }
        // Methods
        $scope.searchRoles = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.expand = 'Users';
            dataservice.filter = dataservice.getPredicate("Name", dataservice.FilterQueryOp.Contains, $scope.pagingInfo.nameFilter);
            if ($scope.pagingInfo.reverse) {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' desc';
            }
            else {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc';
            }
            dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
            dataservice.take = $scope.pagingInfo.itemsPerPage;
            return dataservice.search('Roles', (function (response) {
                if (response.results != null) {
                    if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                        $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                    }
                    else {
                        $scope.roles = response.results;
                    }

                }
            }), (function (error) {
                    alert("Error getting roles: " + error);
                }));
        }

        $scope.sortRoles = function (orderBy) {
            if (orderBy === $scope.pagingInfo.orderBy) {
                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.orderBy = orderBy;
                $scope.pagingInfo.reverse = false;
            }
            $scope.pagingInfo.page = 1;
            $scope.searchRoles();
        };

        $scope.filterRoles = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchRoles();
        }
        $scope.selectFirstPage = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchRoles();
        };
        $scope.selectPreviosPage = function (page) {
            if ($scope.pagingInfo.page > 1) {
                $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                $scope.searchRoles();
            }
        };
        $scope.selectNextPage = function (page) {
            $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
            $scope.searchRoles();
        };



        function activate() {
            var promises = [$scope.getRoles()];
            $scope.message = "";
            common.activateController(promises, controllerId)
                .then(function () {
                    log('Activated List Role View');
                });
        }

        activate();
    }
}