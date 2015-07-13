var Protiviti;
(function (Protiviti) {
    (function (Boilerplate) {
        (function (Client) {
            (function (Controllers) {
                'use strict';
                var controllerId = Client.Modules.UserManager.controllers.listExternalLogins;
                angular.module(Client.Modules.UserManager.Name).controller(controllerId, ['$http', '$scope', '$state', 'common', 'authService', 'dataservice', 'modalService', 'config', ListUsersController]);

                function ListUsersController($http, $scope, $state, common, authService, dataservice, modalService, config) {
                    var getLogFn = common.logger.getLogFn;
                    var log = getLogFn(controllerId);
                    var path = '';

                    dataservice.initialize("usermanager", config.remoteApiServiceBase);

                    $scope.initializing = true;
                    $scope.news = {
                        title: 'Protiviti Boilerplate',
                        description: 'Protiviti Boilerplate'
                    };
                    $scope.externalLogins = [];
                    $scope.title = 'List External Logins';
                    $scope.allowCollapse = true;

                    $scope.pagingInfo = {
                        page: 1,
                        itemsPerPage: 10,
                        orderBy: 'UserName',
                        nameFilter: '',
                        totalItems: 100,
                        reverse: false
                    };

                    $scope.$watch('pagingInfo.nameFilter', function () {
                        if (!$scope.initializing) {
                            $scope.getExternalLogins();
                        }
                    });

                    $scope.deleteUser = function (userName) {
                        var modalOptions = {
                            closeButtonText: 'Cancel',
                            actionButtonText: 'Delete External Login',
                            headerText: 'Delete user (' + userName + ') ?',
                            bodyText: 'Are you sure you want to delete this User?'
                        };

                        modalService.showModal({}, modalOptions).then(function (result) {
                            if (result === 'ok') {
                                var newUser = { Name: userName };
                                $http.post(Client.Modules.UserManager.BaseUrl + '/DeleteUser', newUser).then(function (response) {
                                    if (response.data.Succeeded == true) {
                                        for (var i = 0; i < $scope.externalLogins.length; i++) {
                                            if ($scope.externalLogins[i].UserName == userName) {
                                                $scope.externalLogins.splice(i, 1);
                                                break;
                                            }
                                        }
                                    } else {
                                        alert(response.data.Errors[0]);
                                    }
                                }), (function (error) {
                                    alert("Error deleting User: " + error);
                                });
                            }
                        });
                    };

                    $scope.getExternalLogins = function () {
                        $scope.selectFirstPage();
                    };

                    $scope.searchExternalLogins = function () {
                        dataservice.clear();
                        dataservice.expand = 'Logins';
                        dataservice.filter = dataservice.getPredicate("UserName", dataservice.FilterQueryOp.Contains, $scope.pagingInfo.nameFilter);
                        if ($scope.pagingInfo.reverse) {
                            dataservice.orderBy = $scope.pagingInfo.orderBy + ' desc';
                        } else {
                            dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc';
                        }
                        dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
                        dataservice.take = $scope.pagingInfo.itemsPerPage;
                        return dataservice.search('ExternalLogins', (function (response) {
                            if (response.results != null) {
                                if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                                    $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                                } else {
                                    $scope.externalLogins = response.results;
                                }
                            }
                        }), (function (error) {
                            alert("Error filtering Users: " + error);
                        }));
                    };

                    $scope.sortUsers = function (orderBy) {
                        if (orderBy === $scope.pagingInfo.orderBy) {
                            $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
                        } else {
                            $scope.pagingInfo.orderBy = orderBy;
                            $scope.pagingInfo.reverse = false;
                        }
                        $scope.pagingInfo.page = 1;
                        $scope.searchExternalLogins();
                    };

                    $scope.filterUsers = function () {
                        $scope.pagingInfo.page = 1;
                        $scope.searchExternalLogins();
                    };

                    $scope.selectFirstPage = function () {
                        $scope.pagingInfo.page = 1;
                        $scope.searchExternalLogins();
                    };

                    $scope.selectPreviosPage = function (page) {
                        if ($scope.pagingInfo.page > 1) {
                            $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                            $scope.searchExternalLogins();
                        }
                    };

                    $scope.selectNextPage = function (page) {
                        $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
                        $scope.searchExternalLogins();
                    };

                    function activate() {
                        var promises = [$scope.getExternalLogins()];
                        $scope.message = "";
                        common.activateController(promises, controllerId).then(function () {
                            log('Activated External Logins View');
                        });
                    }

                    activate();
                }
            })(Client.Controllers || (Client.Controllers = {}));
            var Controllers = Client.Controllers;
        })(Boilerplate.Client || (Boilerplate.Client = {}));
        var Client = Boilerplate.Client;
    })(Protiviti.Boilerplate || (Protiviti.Boilerplate = {}));
    var Boilerplate = Protiviti.Boilerplate;
})(Protiviti || (Protiviti = {}));
//# sourceMappingURL=listExternalLoginsController.js.map
