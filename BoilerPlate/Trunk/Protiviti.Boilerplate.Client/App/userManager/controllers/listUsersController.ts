module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = Modules.UserManager.controllers.listUsers;
    angular.module(Modules.UserManager.Name).controller(controllerId,
        ['$http', '$scope', '$state', 'common', 'authService', 'dataservice', 'modalService', 'config', ListUsersController]);

    function ListUsersController($http, $scope, $state, common, authService, dataservice, modalService, config) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var path = '';

        // Initialize dataservice with a web api controller
        dataservice.initialize("Registration", config.remoteApiServiceBase);

        // Properties
        $scope.initializing = true;
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.users = [];
        $scope.title = 'List Users';
        $scope.allowCollapse = true;
        //$scope.showPager = false;
        $scope.pagingInfo = {
            page: 1,
            itemsPerPage: 10,
            orderBy: 'UserName',
            nameFilter: '',
            totalItems: 100,
            reverse: false
        };

        // Watch methods
        $scope.$watch('pagingInfo.nameFilter', function () {
            if (!$scope.initializing) {
                $scope.searchUsers();
                $scope.showPager();
            }
        });

        $scope.showPager = function () {
            if ($scope.users.length >= $scope.pagingInfo.itemsPerPage) {
                return true;
            } else { return false };

        }

        // Methods

        $scope.deleteUser = function (userName,fullName) {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete User',
                headerText: 'Delete user (' + fullName + ') ?',
                bodyText: 'Are you sure you want to delete this User?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    var newUser = { Name: userName }
                    $http.post(Modules.UserManager.BaseUrl + '/DeleteUser', newUser).then(function (response) {
                        if (response.data.Succeeded == true) {
                            for (var i = 0; i < $scope.users.length; i++) {
                                if ($scope.users[i].UserName == userName) {
                                    $scope.users.splice(i, 1);
                                    break;
                                }
                            }
                            $scope.getUsers();
                        }
                        else {
                            alert(response.data.Errors[0]);
                        }

                    }), (function (error) {
                        alert("Error deleting User: " + error);
                    });
                }
            });
        }

        $scope.activateUser = function (userName, fullName) {
            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Activate User',
                headerText: 'Activate user (' + fullName + ') ?',
                bodyText: 'Are you sure you want to activate this User?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    var newUser = { Name: userName }
                    $http.post(Modules.UserManager.BaseUrl + '/ActivateUser', newUser).then(function (response) {
                        if (response.data.Succeeded == true) {
                            for (var i = 0; i < $scope.users.length; i++) {
                                if ($scope.users[i].UserName == userName) {
                                    $scope.users.splice(i, 1);
                                    break;
                                }   
                            }
                            $scope.getUsers();
                        }
                        else {
                            alert(response.data.Errors[0]);
                        }

                    }), (function (error) {
                        alert("Error activating User: " + error);
                    });

                }
            });
        }
        $scope.getUsers = function () {
            $scope.selectFirstPage();
        }       
        // Methods
        $scope.searchUsers = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.filter = dataservice.getPredicate("UserName", dataservice.FilterQueryOp.Contains, $scope.pagingInfo.nameFilter);
            if ($scope.pagingInfo.reverse) {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' desc';
            }
            else {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc';
            }
            dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
            dataservice.take = $scope.pagingInfo.itemsPerPage;   
            return dataservice.search('GetAllUsers', (function (response) {
                if (response.results != null) {
                    if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                        $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                    }
                    else {
                        $scope.users = response.results;
                    }

                }
            }), (function (error) {
                    alert("Error filtering Users: " + error);
                }));
        }

        $scope.sortUsers = function (orderBy) {
            if (orderBy === $scope.pagingInfo.orderBy) {
                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.orderBy = orderBy;
                $scope.pagingInfo.reverse = false;
            }
            $scope.pagingInfo.page = 1;
            $scope.searchUsers();
        };

        $scope.filterUsers = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchUsers();
        }

        $scope.selectFirstPage = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchUsers();
        };

        $scope.selectPreviosPage = function (page) {
            if ($scope.pagingInfo.page > 1) {
                $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                $scope.searchUsers();
            }
        };

        $scope.selectNextPage = function (page) {
            $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
            $scope.searchUsers();
        };

        function activate() {
            var promises = [$scope.getUsers()];
            $scope.message = "";
            common.activateController(promises, controllerId)
                .then(function () {
                    log('Activated List User View');
                });
        }

        activate();
    }
}