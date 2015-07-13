/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../scripts/typings/breeze/breeze.d.ts" />


module Protiviti.Boilerplate.Client.Controllers {
    'use strict';
    var controllerId = 'employee';
    angular.module('app').controller(controllerId, ['$rootScope', '$window', '$scope', '$location', '$routeParams', '$stateParams',
        '$timeout', '$state', 'config', 'common', 'dataservice', 'modalService', listEmployeeController]);

    function listEmployeeController($rootScope, $window, $scope, $location, $routeParams, $stateParams, $timeout, $state, config, common, dataservice, modalService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var path = '';

        // Initialize dataservice with a web api controller
        dataservice.initialize("Employee", config.remoteApiServiceBase);

        // Properties
        $scope.initializing = true;
        $scope.news = {
            title: 'Protiviti Boilerplate',
            description: 'Protiviti Boilerplate'
        };
        $scope.employees = [];
        $scope.employee = {};
        $scope.title = 'List Employees';
        $scope.allowCollapse = true;
        $scope.pagingInfo = {
            page: 1,
            itemsPerPage: 10,
            orderBy: 'FirstName',
            nameFilter: '',
            totalItems: 100,
            reverse: false
        };

        // Watch methods
        $scope.$watch('pagingInfo.nameFilter', function () {
            if (!$scope.initializing) {
                $scope.searchEmployees();
                $scope.showPager();
            }
        });

        $scope.deleteEmployee = function (id) {

            var emp = getEmployeeById(id);
            var empName = emp.FirstName + ' ' + emp.LastName;

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Employee',
                headerText: 'Delete ' + empName + '?',
                bodyText: 'Are you sure you want to delete this employee?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {

                    dataservice.clear();
                    dataservice.expand = 'Division,Designation';
                    dataservice.filter = dataservice.getPredicate("ID", dataservice.FilterQueryOp.Equals, id);
                    // Retrieve related entities

                    dataservice.search('Employees', (function (response) {
                        if (response.results != null && response.results.length >= 1) {
                            $scope.employee = response.results[0];
                            $scope.employee.IsActive = false;
                            dataservice.saveChanges().then(function (data) {
                                for (var i = 0; i < $scope.employees.length; i++) {
                                    if ($scope.employees[i].ID == id) {
                                        $scope.employees.splice(i, 1);
                                        break;
                                    }
                                }
                            }, function (error) {
                                    $window.alert('Error deleting employee: ' + error.message);
                                });
                        }
                    }), (function (error) {
                            alert("Error deleting employee: " + error);
                        }));


                }
            });
        }

        // Methods
        $scope.getEmployees = function () {
            $scope.selectFirstPage();
        }
        // Methods
        $scope.searchEmployees = function () {
            // Clear old criteria before setting up new criteria
            dataservice.clear();
            dataservice.expand = 'Division,Designation';

            var p1 = dataservice.getPredicate("FirstName", dataservice.FilterQueryOp.Contains, $scope.pagingInfo.nameFilter);
            var p2 = dataservice.getPredicate("IsActive", dataservice.FilterQueryOp.Equals, true);
            var pred = breeze.Predicate.and([p1, p2]);
            dataservice.filter = pred;

            if ($scope.pagingInfo.reverse) {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' desc';
            }
            else {
                dataservice.orderBy = $scope.pagingInfo.orderBy + ' asc';
            }
            dataservice.skip = $scope.pagingInfo.itemsPerPage * ($scope.pagingInfo.page - 1);
            dataservice.take = $scope.pagingInfo.itemsPerPage;
            return dataservice.search('employees', (function (response) {
                if (response.results != null) {
                    if ((response.results.length == 0) && ($scope.pagingInfo.page > 1)) {
                        $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                    }
                    else {
                        $scope.employees = response.results;
                    }

                }
            }), (function (error) {
                    alert("Error getting employees: " + error);
                }));
        }

        $scope.sortEmployees = function (orderBy) {
            if (orderBy === $scope.pagingInfo.orderBy) {
                $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
            } else {
                $scope.pagingInfo.orderBy = orderBy;
                $scope.pagingInfo.reverse = false;
            }
            $scope.pagingInfo.page = 1;
            $scope.searchEmployees();
        };

        $scope.filterEmployees = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchEmployees();
        }
        $scope.selectFirstPage = function () {
            $scope.pagingInfo.page = 1;
            $scope.searchEmployees();
        };
        $scope.selectPreviosPage = function (page) {
            if ($scope.pagingInfo.page > 1) {
                $scope.pagingInfo.page = $scope.pagingInfo.page - 1;
                $scope.searchEmployees();
            }
        };
        $scope.selectNextPage = function (page) {
            $scope.pagingInfo.page = $scope.pagingInfo.page + 1;
            $scope.searchEmployees();
        };


        function getEmployeeById(id) {
            for (var i = 0; i < $scope.employees.length; i++) {
                var emp = $scope.employees[i];
                if (emp.ID === id) {
                    return emp;
                }
            }
            return null;
        }

        function activate() {
            var promises = [$scope.getEmployees()];
            $scope.message = "";
            common.activateController(promises, controllerId)
                .then(function () {
                    log('Activated List Role View');
                });
        }

        activate();

    }
}